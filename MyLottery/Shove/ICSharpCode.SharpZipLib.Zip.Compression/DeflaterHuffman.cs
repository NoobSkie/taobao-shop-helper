

using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression 
{
	public class DeflaterHuffman
	{
		const  int BUFSIZE = 1 << (DeflaterConstants.DEFAULT_MEM_LEVEL + 6);
		const  int LITERAL_NUM = 286;

		const  int DIST_NUM = 30;

		const  int BITLEN_NUM = 19;

		const  int REP_3_6    = 16;

		const  int REP_3_10   = 17;

		const  int REP_11_138 = 18;

		const  int EOF_SYMBOL = 256;

		static readonly int[] BL_ORDER = { 16, 17, 18, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 14, 1, 15 };
		
		static readonly byte[] bit4Reverse = {
			0,
			8,
			4,
			12,
			2,
			10,
			6,
			14,
			1,
			9,
			5,
			13,
			3,
			11,
			7,
			15
		};

		static short[] staticLCodes;
		static byte[]  staticLLength;
		static short[] staticDCodes;
		static byte[]  staticDLength;
		
		class Tree 
		{
			#region Instance Fields
			public short[] freqs;
			
			public byte[]  length;
			
			public int     minNumCodes;
			
			public int     numCodes;
			
			short[] codes;
			int[]   bl_counts;
			int     maxLength;
			DeflaterHuffman dh;
			#endregion

			#region Constructors
			public Tree(DeflaterHuffman dh, int elems, int minCodes, int maxLength) 
			{
				this.dh =  dh;
				this.minNumCodes = minCodes;
				this.maxLength  = maxLength;
				freqs  = new short[elems];
				bl_counts = new int[maxLength];
			}
			
			#endregion


			public void Reset() 
			{
				for (int i = 0; i < freqs.Length; i++) {
					freqs[i] = 0;
				}
				codes = null;
				length = null;
			}
			
			public void WriteSymbol(int code)
			{
				dh.pending.WriteBits(codes[code] & 0xffff, length[code]);
			}
			

			public void CheckEmpty()
			{
				bool empty = true;
				for (int i = 0; i < freqs.Length; i++) {
					if (freqs[i] != 0) {
						empty = false;
					}
				}
				
				if (!empty) {
					throw new SharpZipBaseException("!Empty");
				}
			}


			public void SetStaticCodes(short[] staticCodes, byte[] staticLengths)
			{
				codes = staticCodes;
				length = staticLengths;
			}
			

			public void BuildCodes() 
			{
				int numSymbols = freqs.Length;
				int[] nextCode = new int[maxLength];
				int code = 0;

				codes = new short[freqs.Length];
				

				
				for (int bits = 0; bits < maxLength; bits++) {
					nextCode[bits] = code;
					code += bl_counts[bits] << (15 - bits);
				}

#if DebugDeflation
				if ( DeflaterConstants.DEBUGGING && (code != 65536) ) 
				{
					throw new SharpZipBaseException("Inconsistent bl_counts!");
				}
#endif				
				for (int i=0; i < numCodes; i++) {
					int bits = length[i];
					if (bits > 0) {

						codes[i] = BitReverse(nextCode[bits-1]);
						nextCode[bits-1] += 1 << (16 - bits);
					}
				}
			}
			
			public void BuildTree()
			{
				int numSymbols = freqs.Length;
				

				int[] heap = new int[numSymbols];
				int heapLen = 0;
				int maxCode = 0;
				for (int n = 0; n < numSymbols; n++) {
					int freq = freqs[n];
					if (freq != 0) {

						int pos = heapLen++;
						int ppos;
						while (pos > 0 && freqs[heap[ppos = (pos - 1) / 2]] > freq) {
							heap[pos] = heap[ppos];
							pos = ppos;
						}
						heap[pos] = n;
						
						maxCode = n;
					}
				}
				
		
				while (heapLen < 2) {
					int node = maxCode < 2 ? ++maxCode : 0;
					heap[heapLen++] = node;
				}
				
				numCodes = Math.Max(maxCode + 1, minNumCodes);
				
				int numLeafs = heapLen;
				int[] childs = new int[4 * heapLen - 2];
				int[] values = new int[2 * heapLen - 1];
				int numNodes = numLeafs;
				for (int i = 0; i < heapLen; i++) {
					int node = heap[i];
					childs[2 * i]   = node;
					childs[2 * i + 1] = -1;
					values[i] = freqs[node] << 8;
					heap[i] = i;
				}

				do {
					int first = heap[0];
					int last  = heap[--heapLen];
					

					int ppos = 0;
					int path = 1;
					
					while (path < heapLen) {
						if (path + 1 < heapLen && values[heap[path]] > values[heap[path+1]]) {
							path++;
						}
							
						heap[ppos] = heap[path];
						ppos = path;
						path = path * 2 + 1;
					}
						

					int lastVal = values[last];
					while ((path = ppos) > 0 && values[heap[ppos = (path - 1)/2]] > lastVal) {
						heap[path] = heap[ppos];
					}
					heap[path] = last;
					
					
					int second = heap[0];
					

					last = numNodes++;
					childs[2 * last] = first;
					childs[2 * last + 1] = second;
					int mindepth = Math.Min(values[first] & 0xff, values[second] & 0xff);
					values[last] = lastVal = values[first] + values[second] - mindepth + 1;
					

					ppos = 0;
					path = 1;
					
					while (path < heapLen) {
						if (path + 1 < heapLen && values[heap[path]] > values[heap[path+1]]) {
							path++;
						}
							
						heap[ppos] = heap[path];
						ppos = path;
						path = ppos * 2 + 1;
					}
						
					while ((path = ppos) > 0 && values[heap[ppos = (path - 1)/2]] > lastVal) {
						heap[path] = heap[ppos];
					}
					heap[path] = last;
				} while (heapLen > 1);
				
				if (heap[0] != childs.Length / 2 - 1) {
					throw new SharpZipBaseException("Heap invariant violated");
				}
				
				BuildLength(childs);
			}
			
			public int GetEncodedLength()
			{
				int len = 0;
				for (int i = 0; i < freqs.Length; i++) {
					len += freqs[i] * length[i];
				}
				return len;
			}
			

			public void CalcBLFreq(Tree blTree) 
			{
				int max_count;             
				int min_count;               
				int count;                  
				int curlen = -1;             
				
				int i = 0;
				while (i < numCodes) {
					count = 1;
					int nextlen = length[i];
					if (nextlen == 0) {
						max_count = 138;
						min_count = 3;
					} else {
						max_count = 6;
						min_count = 3;
						if (curlen != nextlen) {
							blTree.freqs[nextlen]++;
							count = 0;
						}
					}
					curlen = nextlen;
					i++;
					
					while (i < numCodes && curlen == length[i]) {
						i++;
						if (++count >= max_count) {
							break;
						}
					}
					
					if (count < min_count) {
						blTree.freqs[curlen] += (short)count;
					} else if (curlen != 0) {
						blTree.freqs[REP_3_6]++;
					} else if (count <= 10) {
						blTree.freqs[REP_3_10]++;
					} else {
						blTree.freqs[REP_11_138]++;
					}
				}
			}
		

			public void WriteTree(Tree blTree)
			{
				int max_count;              
				int min_count;             
				int count;                 
				int curlen = -1;            
				
				int i = 0;
				while (i < numCodes) {
					count = 1;
					int nextlen = length[i];
					if (nextlen == 0) {
						max_count = 138;
						min_count = 3;
					} else {
						max_count = 6;
						min_count = 3;
						if (curlen != nextlen) {
							blTree.WriteSymbol(nextlen);
							count = 0;
						}
					}
					curlen = nextlen;
					i++;
					
					while (i < numCodes && curlen == length[i]) {
						i++;
						if (++count >= max_count) {
							break;
						}
					}
					
					if (count < min_count) {
						while (count-- > 0) {
							blTree.WriteSymbol(curlen);
						}
					} else if (curlen != 0) {
						blTree.WriteSymbol(REP_3_6);
						dh.pending.WriteBits(count - 3, 2);
					} else if (count <= 10) {
						blTree.WriteSymbol(REP_3_10);
						dh.pending.WriteBits(count - 3, 3);
					} else {
						blTree.WriteSymbol(REP_11_138);
						dh.pending.WriteBits(count - 11, 7);
					}
				}
			}

			void BuildLength(int[] childs)
			{
				this.length = new byte [freqs.Length];
				int numNodes = childs.Length / 2;
				int numLeafs = (numNodes + 1) / 2;
				int overflow = 0;
				
				for (int i = 0; i < maxLength; i++) {
					bl_counts[i] = 0;
				}
				

				int[] lengths = new int[numNodes];
				lengths[numNodes-1] = 0;
				
				for (int i = numNodes - 1; i >= 0; i--) {
					if (childs[2 * i + 1] != -1) {
						int bitLength = lengths[i] + 1;
						if (bitLength > maxLength) {
							bitLength = maxLength;
							overflow++;
						}
						lengths[childs[2 * i]] = lengths[childs[2 * i + 1]] = bitLength;
					} else {
						int bitLength = lengths[i];
						bl_counts[bitLength - 1]++;
						this.length[childs[2*i]] = (byte) lengths[i];
					}
				}
				
				
				if (overflow == 0) {
					return;
				}
				
				int incrBitLen = maxLength - 1;
				do {
					while (bl_counts[--incrBitLen] == 0)
						;
					do {
						bl_counts[incrBitLen]--;
						bl_counts[++incrBitLen]++;
						overflow -= 1 << (maxLength - 1 - incrBitLen);
					} while (overflow > 0 && incrBitLen < maxLength - 1);
				} while (overflow > 0);
				

				bl_counts[maxLength-1] += overflow;
				bl_counts[maxLength-2] -= overflow;
				
				int nodePtr = 2 * numLeafs;
				for (int bits = maxLength; bits != 0; bits--) {
					int n = bl_counts[bits-1];
					while (n > 0) {
						int childPtr = 2*childs[nodePtr++];
						if (childs[childPtr + 1] == -1) {
							length[childs[childPtr]] = (byte) bits;
							n--;
						}
					}
				}
			}
			
		}

		#region Instance Fields

		public DeflaterPending pending;
		
		Tree literalTree;
		Tree distTree;
		Tree blTree;
		

		short[] d_buf;
		byte[]  l_buf;
		int last_lit;
		int extra_bits;
		#endregion

		static DeflaterHuffman() 
		{
			staticLCodes = new short[LITERAL_NUM];
			staticLLength = new byte[LITERAL_NUM];

			int i = 0;
			while (i < 144) {
				staticLCodes[i] = BitReverse((0x030 + i) << 8);
				staticLLength[i++] = 8;
			}

			while (i < 256) {
				staticLCodes[i] = BitReverse((0x190 - 144 + i) << 7);
				staticLLength[i++] = 9;
			}

			while (i < 280) {
				staticLCodes[i] = BitReverse((0x000 - 256 + i) << 9);
				staticLLength[i++] = 7;
			}

			while (i < LITERAL_NUM) {
				staticLCodes[i] = BitReverse((0x0c0 - 280 + i)  << 8);
				staticLLength[i++] = 8;
			}
			

			staticDCodes = new short[DIST_NUM];
			staticDLength = new byte[DIST_NUM];
			for (i = 0; i < DIST_NUM; i++) {
				staticDCodes[i] = BitReverse(i << 11);
				staticDLength[i] = 5;
			}
		}
		

		public DeflaterHuffman(DeflaterPending pending)
		{
			this.pending = pending;
			
			literalTree = new Tree(this, LITERAL_NUM, 257, 15);
			distTree    = new Tree(this, DIST_NUM, 1, 15);
			blTree      = new Tree(this, BITLEN_NUM, 4, 7);
			
			d_buf = new short[BUFSIZE];
			l_buf = new byte [BUFSIZE];
		}
		
		public void Reset() 
		{
			last_lit = 0;
			extra_bits = 0;
			literalTree.Reset();
			distTree.Reset();
			blTree.Reset();
		}
		

		public void SendAllTrees(int blTreeCodes)
		{
			blTree.BuildCodes();
			literalTree.BuildCodes();
			distTree.BuildCodes();
			pending.WriteBits(literalTree.numCodes - 257, 5);
			pending.WriteBits(distTree.numCodes - 1, 5);
			pending.WriteBits(blTreeCodes - 4, 4);
			for (int rank = 0; rank < blTreeCodes; rank++) {
				pending.WriteBits(blTree.length[BL_ORDER[rank]], 3);
			}
			literalTree.WriteTree(blTree);
			distTree.WriteTree(blTree);

#if DebugDeflation
			if (DeflaterConstants.DEBUGGING) {
				blTree.CheckEmpty();
			}
#endif
		}


		public void CompressBlock()
		{
			for (int i = 0; i < last_lit; i++) {
				int litlen = l_buf[i] & 0xff;
				int dist = d_buf[i];
				if (dist-- != 0) {
					
					int lc = Lcode(litlen);
					literalTree.WriteSymbol(lc);
					
					int bits = (lc - 261) / 4;
					if (bits > 0 && bits <= 5) {
						pending.WriteBits(litlen & ((1 << bits) - 1), bits);
					}
					
					int dc = Dcode(dist);
					distTree.WriteSymbol(dc);
					
					bits = dc / 2 - 1;
					if (bits > 0) {
						pending.WriteBits(dist & ((1 << bits) - 1), bits);
					}
				} else {

					literalTree.WriteSymbol(litlen);
				}
			}

#if DebugDeflation
			if (DeflaterConstants.DEBUGGING) {
				Console.Write("EOF: ");
			}
#endif
			literalTree.WriteSymbol(EOF_SYMBOL);

#if DebugDeflation
			if (DeflaterConstants.DEBUGGING) {
				literalTree.CheckEmpty();
				distTree.CheckEmpty();
			}
#endif
		}
		

		public void FlushStoredBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
		{
#if DebugDeflation
			//			if (DeflaterConstants.DEBUGGING) {
			//				//Console.WriteLine("Flushing stored block "+ storedLength);
			//			}
#endif
			pending.WriteBits((DeflaterConstants.STORED_BLOCK << 1) + (lastBlock ? 1 : 0), 3);
			pending.AlignToByte();
			pending.WriteShort(storedLength);
			pending.WriteShort(~storedLength);
			pending.WriteBlock(stored, storedOffset, storedLength);
			Reset();
		}

		public void FlushBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
		{
			literalTree.freqs[EOF_SYMBOL]++;
			

			literalTree.BuildTree();
			distTree.BuildTree();
			
			literalTree.CalcBLFreq(blTree);
			distTree.CalcBLFreq(blTree);
			
			blTree.BuildTree();
			
			int blTreeCodes = 4;
			for (int i = 18; i > blTreeCodes; i--) {
				if (blTree.length[BL_ORDER[i]] > 0) {
					blTreeCodes = i+1;
				}
			}
			int opt_len = 14 + blTreeCodes * 3 + blTree.GetEncodedLength() + 
				literalTree.GetEncodedLength() + distTree.GetEncodedLength() + 
				extra_bits;
			
			int static_len = extra_bits;
			for (int i = 0; i < LITERAL_NUM; i++) {
				static_len += literalTree.freqs[i] * staticLLength[i];
			}
			for (int i = 0; i < DIST_NUM; i++) {
				static_len += distTree.freqs[i] * staticDLength[i];
			}
			if (opt_len >= static_len) {
				opt_len = static_len;
			}
			
			if (storedOffset >= 0 && storedLength + 4 < opt_len >> 3) {

				FlushStoredBlock(stored, storedOffset, storedLength, lastBlock);
			} else if (opt_len == static_len) {
				pending.WriteBits((DeflaterConstants.STATIC_TREES << 1) + (lastBlock ? 1 : 0), 3);
				literalTree.SetStaticCodes(staticLCodes, staticLLength);
				distTree.SetStaticCodes(staticDCodes, staticDLength);
				CompressBlock();
				Reset();
			} else {
				pending.WriteBits((DeflaterConstants.DYN_TREES << 1) + (lastBlock ? 1 : 0), 3);
				SendAllTrees(blTreeCodes);
				CompressBlock();
				Reset();
			}
		}
		

		public bool IsFull()
		{
			return last_lit >= BUFSIZE;
		}
		
		public bool TallyLit(int literal)
		{
			d_buf[last_lit] = 0;
			l_buf[last_lit++] = (byte)literal;
			literalTree.freqs[literal]++;
			return IsFull();
		}
		

		public bool TallyDist(int distance, int length)
		{	
			d_buf[last_lit]   = (short)distance;
			l_buf[last_lit++] = (byte)(length - 3);
			
			int lc = Lcode(length - 3);
			literalTree.freqs[lc]++;
			if (lc >= 265 && lc < 285) {
				extra_bits += (lc - 261) / 4;
			}
			
			int dc = Dcode(distance - 1);
			distTree.freqs[dc]++;
			if (dc >= 4) {
				extra_bits += dc / 2 - 1;
			}
			return IsFull();
		}

		

		public static short BitReverse(int toReverse) 
		{
			return (short) (bit4Reverse[toReverse & 0xF] << 12 | 
			                bit4Reverse[(toReverse >> 4) & 0xF] << 8 | 
			                bit4Reverse[(toReverse >> 8) & 0xF] << 4 |
			                bit4Reverse[toReverse >> 12]);
		}
		
		static int Lcode(int length) 
		{
			if (length == 255) {
				return 285;
			}
			
			int code = 257;
			while (length >= 8) {
				code += 4;
				length >>= 1;
			}
			return code + length;
		}
		
		static int Dcode(int distance) 
		{
			int code = 0;
			while (distance >= 4) {
				code += 2;
				distance >>= 1;
			}
			return code + distance;
		}
	}
}
