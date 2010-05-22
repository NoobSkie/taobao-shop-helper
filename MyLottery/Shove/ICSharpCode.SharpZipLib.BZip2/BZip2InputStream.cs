using System;
using System.IO;

using ICSharpCode.SharpZipLib.Checksums;

namespace ICSharpCode.SharpZipLib.BZip2 
{
	public class BZip2InputStream : Stream
	{
		#region Constants
		const int START_BLOCK_STATE = 1;
		const int RAND_PART_A_STATE = 2;
		const int RAND_PART_B_STATE = 3;
		const int RAND_PART_C_STATE = 4;
		const int NO_RAND_PART_A_STATE = 5;
		const int NO_RAND_PART_B_STATE = 6;
		const int NO_RAND_PART_C_STATE = 7;
		#endregion
		#region Constructors
		public BZip2InputStream(Stream stream) 
		{
			for (int i = 0; i < BZip2Constants.GroupCount; ++i) 
			{
				limit[i] = new int[BZip2Constants.MaximumAlphaSize];
				baseArray[i]  = new int[BZip2Constants.MaximumAlphaSize];
				perm[i]  = new int[BZip2Constants.MaximumAlphaSize];
			}
			
			BsSetStream(stream);
			Initialize();
			InitBlock();
			SetupBlock();
		}
		
		#endregion

	
		public bool IsStreamOwner
		{
			get { return isStreamOwner; }
			set { isStreamOwner = value; }
		}
		

		#region Stream Overrides
	
		public override bool CanRead 
		{
			get {
				return baseStream.CanRead;
			}
		}
		
		
		public override bool CanSeek {
			get {
				return baseStream.CanSeek;
			}
		}
		
		
		public override bool CanWrite {
			get {
				return false;
			}
		}
		
		
		public override long Length {
			get {
				return baseStream.Length;
			}
		}
		
	
		public override long Position {
			get {
				return baseStream.Position;
			}
			set {
				throw new NotSupportedException("BZip2InputStream position cannot be set");
			}
		}
		
		
		public override void Flush()
		{
			if (baseStream != null) {
				baseStream.Flush();
			}
		}
		
	
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("BZip2InputStream Seek not supported");
		}
		
	
		public override void SetLength(long value)
		{
			throw new NotSupportedException("BZip2InputStream SetLength not supported");
		}
		
		
		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("BZip2InputStream Write not supported");
		}
		
		
		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("BZip2InputStream WriteByte not supported");
		}
		
	
		public override int Read(byte[] buffer, int offset, int count)
		{
			if ( buffer == null )
			{
				throw new ArgumentNullException("buffer");
			}

			for (int i = 0; i < count; ++i) {
				int rb = ReadByte();
				if (rb == -1) {
					return i;
				}
				buffer[offset + i] = (byte)rb;
			}
			return count;
		}
		

		public override void Close()
		{
			if ( IsStreamOwner && (baseStream != null) ) {
				baseStream.Close();
			}
		}

		public override int ReadByte()
		{
			if (streamEnd) 
			{
				return -1; 
			}
			
			int retChar = currentChar;
			switch (currentState) 
			{
				case RAND_PART_B_STATE:
					SetupRandPartB();
					break;
				case RAND_PART_C_STATE:
					SetupRandPartC();
					break;
				case NO_RAND_PART_B_STATE:
					SetupNoRandPartB();
					break;
				case NO_RAND_PART_C_STATE:
					SetupNoRandPartC();
					break;
				case START_BLOCK_STATE:
				case NO_RAND_PART_A_STATE:
				case RAND_PART_A_STATE:
					break;
				default:
					break;
			}
			return retChar;
		}
		
		#endregion

		void MakeMaps() 
		{
			nInUse = 0;
			for (int i = 0; i < 256; ++i) {
				if (inUse[i]) {
					seqToUnseq[nInUse] = (byte)i;
					unseqToSeq[i] = (byte)nInUse;
					nInUse++;
				}
			}
		}
				
		void Initialize() 
		{
			char magic1 = BsGetUChar();
			char magic2 = BsGetUChar();
			
			char magic3 = BsGetUChar();
			char magic4 = BsGetUChar();
			
			if (magic1 != 'B' || magic2 != 'Z' || magic3 != 'h' || magic4 < '1' || magic4 > '9') {
				streamEnd = true;
				return;
			}
			
			SetDecompressStructureSizes(magic4 - '0');
			computedCombinedCRC = 0;
		}
		
		void InitBlock() 
		{
			char magic1 = BsGetUChar();
			char magic2 = BsGetUChar();
			char magic3 = BsGetUChar();
			char magic4 = BsGetUChar();
			char magic5 = BsGetUChar();
			char magic6 = BsGetUChar();
			
			if (magic1 == 0x17 && magic2 == 0x72 && magic3 == 0x45 && magic4 == 0x38 && magic5 == 0x50 && magic6 == 0x90) {
				Complete();
				return;
			}
			
			if (magic1 != 0x31 || magic2 != 0x41 || magic3 != 0x59 || magic4 != 0x26 || magic5 != 0x53 || magic6 != 0x59) {
				BadBlockHeader();
				streamEnd = true;
				return;
			}
			
			storedBlockCRC  = BsGetInt32();
			
			blockRandomised = (BsR(1) == 1);
			
			GetAndMoveToFrontDecode();
			
			mCrc.Reset();
			currentState = START_BLOCK_STATE;
		}
		
		void EndBlock() 
		{
			computedBlockCRC = (int)mCrc.Value;
			
			if (storedBlockCRC != computedBlockCRC) {
				CrcError();
			}

			computedCombinedCRC = ((computedCombinedCRC << 1) & 0xFFFFFFFF) | (computedCombinedCRC >> 31);
			computedCombinedCRC = computedCombinedCRC ^ (uint)computedBlockCRC;
		}
		
		void Complete() 
		{
			storedCombinedCRC = BsGetInt32();
			if (storedCombinedCRC != (int)computedCombinedCRC) {
				CrcError();
			}
			
			streamEnd = true;
		}
		
		void BsSetStream(Stream stream) 
		{
			baseStream = stream;
			bsLive = 0;
			bsBuff = 0;
		}
		
		void FillBuffer()
		{
			int thech = 0;
			
			try {
				thech = baseStream.ReadByte();
			} catch (Exception) {
				CompressedStreamEOF();
			}
			
			if (thech == -1) {
				CompressedStreamEOF();
			}
			
			bsBuff = (bsBuff << 8) | (thech & 0xFF);
			bsLive += 8;
		}
		
		int BsR(int n) 
		{
			while (bsLive < n) {
				FillBuffer();
			}
			
			int v = (bsBuff >> (bsLive - n)) & ((1 << n) - 1);
			bsLive -= n;
			return v;
		}
		
		char BsGetUChar() 
		{
			return (char)BsR(8);
		}
		
		int BsGetIntVS(int numBits) 
		{
			return BsR(numBits);
		}
		
		int BsGetInt32()
		{
			int result = BsR(8);
			result = (result << 8) | BsR(8);
			result = (result << 8) | BsR(8);
			result = (result << 8) | BsR(8);
			return result;
		}
		
		void RecvDecodingTables() 
		{
			char[][] len = new char[BZip2Constants.GroupCount][];
			for (int i = 0; i < BZip2Constants.GroupCount; ++i) {
				len[i] = new char[BZip2Constants.MaximumAlphaSize];
			}
			
			bool[] inUse16 = new bool[16];
			

			for (int i = 0; i < 16; i++) {
				inUse16[i] = (BsR(1) == 1);
			} 
			
			for (int i = 0; i < 16; i++) {
				if (inUse16[i]) {
					for (int j = 0; j < 16; j++) {
						inUse[i * 16 + j] = (BsR(1) == 1);
					}
				} else {
					for (int j = 0; j < 16; j++) {
						inUse[i * 16 + j] = false;
					}
				}
			}
			
			MakeMaps();
			int alphaSize = nInUse + 2;
			

			int nGroups    = BsR(3);
			int nSelectors = BsR(15);
			
			for (int i = 0; i < nSelectors; i++) {
				int j = 0;
				while (BsR(1) == 1) {
					j++;
				}
				selectorMtf[i] = (byte)j;
			}
			

			byte[] pos = new byte[BZip2Constants.GroupCount];
			for (int v = 0; v < nGroups; v++) {
				pos[v] = (byte)v;
			}
			
			for (int i = 0; i < nSelectors; i++) {
				int  v   = selectorMtf[i];
				byte tmp = pos[v];
				while (v > 0) {
					pos[v] = pos[v - 1];
					v--;
				}
				pos[0]      = tmp;
				selector[i] = tmp;
			}
			

			for (int t = 0; t < nGroups; t++) {
				int curr = BsR(5);
				for (int i = 0; i < alphaSize; i++) {
					while (BsR(1) == 1) {
						if (BsR(1) == 0) {
							curr++;
						} else {
							curr--;
						}
					}
					len[t][i] = (char)curr;
				}
			}

			for (int t = 0; t < nGroups; t++) {
				int minLen = 32;
				int maxLen = 0;
				for (int i = 0; i < alphaSize; i++) {
					maxLen = Math.Max(maxLen, len[t][i]);
					minLen = Math.Min(minLen, len[t][i]);
				}
				HbCreateDecodeTables(limit[t], baseArray[t], perm[t], len[t], minLen, maxLen, alphaSize);
				minLens[t] = minLen;
			}
		}
		
		void GetAndMoveToFrontDecode() 
		{
			byte[] yy = new byte[256];
			int nextSym;
			
			int limitLast = BZip2Constants.BaseBlockSize * blockSize100k;
			origPtr = BsGetIntVS(24);
			
			RecvDecodingTables();
			int EOB = nInUse+1;
			int groupNo = -1;
			int groupPos = 0;
			

			for (int i = 0; i <= 255; i++) {
				unzftab[i] = 0;
			}
			
			for (int i = 0; i <= 255; i++) {
				yy[i] = (byte)i;
			}
			
			last = -1;
			
			if (groupPos == 0) {
				groupNo++;
				groupPos = BZip2Constants.GroupSize;
			}
			
			groupPos--;
			int zt = selector[groupNo];
			int zn = minLens[zt];
			int zvec = BsR(zn);
			int zj;
			
			while (zvec > limit[zt][zn]) {
				if (zn > 20) { 
					throw new BZip2Exception("Bzip data error");
				}
				zn++;
				while (bsLive < 1) {
					FillBuffer();
				}
				zj = (bsBuff >> (bsLive-1)) & 1;
				bsLive--;
				zvec = (zvec << 1) | zj;
			}
			if (zvec - baseArray[zt][zn] < 0 || zvec - baseArray[zt][zn] >= BZip2Constants.MaximumAlphaSize) {
				throw new BZip2Exception("Bzip data error");
			}
			nextSym = perm[zt][zvec - baseArray[zt][zn]];
			
			while (true) {
				if (nextSym == EOB) {
					break;
				}
				
				if (nextSym == BZip2Constants.RunA || nextSym == BZip2Constants.RunB) {
					int s = -1;
					int n = 1;
					do {
						if (nextSym == BZip2Constants.RunA) {
							s += (0 + 1) * n;
						} else if (nextSym == BZip2Constants.RunB) {
							s += (1 + 1) * n;
						}

						n <<= 1;
						
						if (groupPos == 0) {
							groupNo++;
							groupPos = BZip2Constants.GroupSize;
						}
						
						groupPos--;
						
						zt = selector[groupNo];
						zn = minLens[zt];
						zvec = BsR(zn);
						
						while (zvec > limit[zt][zn]) {
							zn++;
							while (bsLive < 1) {
								FillBuffer();
							}
							zj = (bsBuff >> (bsLive - 1)) & 1;
							bsLive--;
							zvec = (zvec << 1) | zj;
						}
						nextSym = perm[zt][zvec - baseArray[zt][zn]];
					} while (nextSym == BZip2Constants.RunA || nextSym == BZip2Constants.RunB);
					
					s++;
					byte ch = seqToUnseq[yy[0]];
					unzftab[ch] += s;
					
					while (s > 0) {
						last++;
						ll8[last] = ch;
						s--;
					}
					
					if (last >= limitLast) {
						BlockOverrun();
					}
					continue;
				} else {
					last++;
					if (last >= limitLast) {
						BlockOverrun();
					}
					
					byte tmp = yy[nextSym - 1];
					unzftab[seqToUnseq[tmp]]++;
					ll8[last] = seqToUnseq[tmp];
					
					for (int j = nextSym-1; j > 0; --j) {
						yy[j] = yy[j - 1];
					}
					yy[0] = tmp;
					
					if (groupPos == 0) {
						groupNo++;
						groupPos = BZip2Constants.GroupSize;
					}
					
					groupPos--;
					zt = selector[groupNo];
					zn = minLens[zt];
					zvec = BsR(zn);
					while (zvec > limit[zt][zn]) {
						zn++;
						while (bsLive < 1) {
							FillBuffer();
						}
						zj = (bsBuff >> (bsLive-1)) & 1;
						bsLive--;
						zvec = (zvec << 1) | zj;
					}
					nextSym = perm[zt][zvec - baseArray[zt][zn]];
					continue;
				}
			}
		}
		
		void SetupBlock() 
		{
			int[] cftab = new int[257];
			
			cftab[0] = 0;
			Array.Copy(unzftab, 0, cftab, 1, 256);
			
			for (int i = 1; i <= 256; i++) {
				cftab[i] += cftab[i - 1];
			}
			
			for (int i = 0; i <= last; i++) {
				byte ch = ll8[i];
				tt[cftab[ch]] = i;
				cftab[ch]++;
			}
			
			cftab = null;
			
			tPos = tt[origPtr];
			
			count = 0;
			i2    = 0;
			ch2   = 256; 
			
			if (blockRandomised) {
				rNToGo = 0;
				rTPos = 0;
				SetupRandPartA();
			} else {
				SetupNoRandPartA();
			}
		}
		
		void SetupRandPartA() 
		{
			if (i2 <= last) {
				chPrev = ch2;
				ch2  = ll8[tPos];
				tPos = tt[tPos];
				if (rNToGo == 0) {
					rNToGo = BZip2Constants.RandomNumbers[rTPos];
					rTPos++;
					if (rTPos == 512) {
						rTPos = 0;
					}
				}
				rNToGo--;
				ch2 ^= (int)((rNToGo == 1) ? 1 : 0);
				i2++;
				
				currentChar  = ch2;
				currentState = RAND_PART_B_STATE;
				mCrc.Update(ch2);
			} else {
				EndBlock();
				InitBlock();
				SetupBlock();
			}
		}
		
		void SetupNoRandPartA() 
		{
			if (i2 <= last) {
				chPrev = ch2;
				ch2  = ll8[tPos];
				tPos = tt[tPos];
				i2++;
				
				currentChar = ch2;
				currentState = NO_RAND_PART_B_STATE;
				mCrc.Update(ch2);
			} else {
				EndBlock();
				InitBlock();
				SetupBlock();
			}
		}
		
		void SetupRandPartB() 
		{
			if (ch2 != chPrev) {
				currentState = RAND_PART_A_STATE;
				count = 1;
				SetupRandPartA();
			} else {
				count++;
				if (count >= 4) {
					z = ll8[tPos];
					tPos = tt[tPos];
					if (rNToGo == 0) {
						rNToGo = BZip2Constants.RandomNumbers[rTPos];
						rTPos++;
						if (rTPos == 512) {
							rTPos = 0;
						}
					}
					rNToGo--;
					z ^= (byte)((rNToGo == 1) ? 1 : 0);
					j2 = 0;
					currentState = RAND_PART_C_STATE;
					SetupRandPartC();
				} else {
					currentState = RAND_PART_A_STATE;
					SetupRandPartA();
				}
			}
		}
		
		void SetupRandPartC() 
		{
			if (j2 < (int)z) {
				currentChar = ch2;
				mCrc.Update(ch2);
				j2++;
			} else {
				currentState = RAND_PART_A_STATE;
				i2++;
				count = 0;
				SetupRandPartA();
			}
		}
		
		void SetupNoRandPartB() 
		{
			if (ch2 != chPrev) {
				currentState = NO_RAND_PART_A_STATE;
				count = 1;
				SetupNoRandPartA();
			} else {
				count++;
				if (count >= 4) {
					z = ll8[tPos];
					tPos = tt[tPos];
					currentState = NO_RAND_PART_C_STATE;
					j2 = 0;
					SetupNoRandPartC();
				} else {
					currentState = NO_RAND_PART_A_STATE;
					SetupNoRandPartA();
				}
			}
		}
		
		void SetupNoRandPartC() 
		{
			if (j2 < (int)z) {
				currentChar = ch2;
				mCrc.Update(ch2);
				j2++;
			} else {
				currentState = NO_RAND_PART_A_STATE;
				i2++;
				count = 0;
				SetupNoRandPartA();
			}
		}
		
		void SetDecompressStructureSizes(int newSize100k) 
		{
			if (!(0 <= newSize100k && newSize100k <= 9 && 0 <= blockSize100k && blockSize100k <= 9)) {
				throw new BZip2Exception("Invalid block size");
			}
			
			blockSize100k = newSize100k;
			
			if (newSize100k == 0) {
				return;
			}
			
			int n = BZip2Constants.BaseBlockSize * newSize100k;
			ll8 = new byte[n];
			tt  = new int[n];
		}

		static void CompressedStreamEOF() 
		{
			throw new EndOfStreamException("BZip2 input stream end of compressed stream");
		}
		
		static void BlockOverrun() 
		{
			throw new BZip2Exception("BZip2 input stream block overrun");
		}
		
		static void BadBlockHeader() 
		{
			throw new BZip2Exception("BZip2 input stream bad block header");
		}
		
		static void CrcError() 
		{
			throw new BZip2Exception("BZip2 input stream crc error");
		}
		
		static void HbCreateDecodeTables(int[] limit, int[] baseArray, int[] perm, char[] length, int minLen, int maxLen, int alphaSize) 
		{
			int pp = 0;
			
			for (int i = minLen; i <= maxLen; ++i) 
			{
				for (int j = 0; j < alphaSize; ++j) 
				{
					if (length[j] == i) 
					{
						perm[pp] = j;
						++pp;
					}
				}
			}
			
			for (int i = 0; i < BZip2Constants.MaximumCodeLength; i++) 
			{
				baseArray[i] = 0;
			}
			
			for (int i = 0; i < alphaSize; i++) 
			{
				++baseArray[length[i] + 1];
			}
			
			for (int i = 1; i < BZip2Constants.MaximumCodeLength; i++) 
			{
				baseArray[i] += baseArray[i - 1];
			}
			
			for (int i = 0; i < BZip2Constants.MaximumCodeLength; i++) 
			{
				limit[i] = 0;
			}
			
			int vec = 0;
			
			for (int i = minLen; i <= maxLen; i++) 
			{
				vec += (baseArray[i + 1] - baseArray[i]);
				limit[i] = vec - 1;
				vec <<= 1;
			}
			
			for (int i = minLen + 1; i <= maxLen; i++) 
			{
				baseArray[i] = ((limit[i - 1] + 1) << 1) - baseArray[i];
			}
		}
		
		#region Instance Fields

		int last;
		

		int origPtr;
		

		int blockSize100k;
		
		bool blockRandomised;
		
		int bsBuff;
		int bsLive;
		IChecksum mCrc = new StrangeCRC();
		
		bool[] inUse = new bool[256];
		int    nInUse;
		
		byte[] seqToUnseq = new byte[256];
		byte[] unseqToSeq = new byte[256];
		
		byte[] selector    = new byte[BZip2Constants.MaximumSelectors];
		byte[] selectorMtf = new byte[BZip2Constants.MaximumSelectors];
		
		int[] tt;
		byte[] ll8;
		
		int[] unzftab = new int[256];
		
		int[][] limit     = new int[BZip2Constants.GroupCount][];
		int[][] baseArray = new int[BZip2Constants.GroupCount][];
		int[][] perm      = new int[BZip2Constants.GroupCount][];
		int[] minLens     = new int[BZip2Constants.GroupCount];
		
		Stream baseStream;
		bool   streamEnd;
		
		int currentChar = -1;
	
		int currentState = START_BLOCK_STATE;
		
		int storedBlockCRC, storedCombinedCRC;
		int computedBlockCRC;
		uint computedCombinedCRC;
		
		int count, chPrev, ch2;
		int tPos;
		int rNToGo;
		int rTPos;
		int i2, j2;
		byte z;
		bool isStreamOwner = true;
		#endregion
	}
}