
using System;

using ICSharpCode.SharpZipLib.Checksums;

namespace ICSharpCode.SharpZipLib.Zip.Compression 
{
	public enum DeflateStrategy 
	{
		Default  = 0,
		

		Filtered = 1,

			
		HuffmanOnly = 2
	}



	public class DeflaterEngine : DeflaterConstants 
	{
		#region Constants
		const int TooFar = 4096;
		#endregion
		
		#region Constructors

		public DeflaterEngine(DeflaterPending pending) 
		{
			this.pending = pending;
			huffman = new DeflaterHuffman(pending);
			adler = new Adler32();
			
			window = new byte[2 * WSIZE];
			head   = new short[HASH_SIZE];
			prev   = new short[WSIZE];
			
			blockStart = strstart = 1;
		}

		#endregion

		public bool Deflate(bool flush, bool finish)
		{
			bool progress;
			do 
			{
				FillWindow();
				bool canFlush = flush && (inputOff == inputEnd);

#if DebugDeflation
				if (DeflaterConstants.DEBUGGING) {
					Console.WriteLine("window: [" + blockStart + "," + strstart + ","
								+ lookahead + "], " + compressionFunction + "," + canFlush);
				}
#endif
				switch (compressionFunction) 
				{
					case DEFLATE_STORED:
						progress = DeflateStored(canFlush, finish);
						break;
					case DEFLATE_FAST:
						progress = DeflateFast(canFlush, finish);
						break;
					case DEFLATE_SLOW:
						progress = DeflateSlow(canFlush, finish);
						break;
					default:
						throw new InvalidOperationException("unknown compressionFunction");
				}
			} while (pending.IsFlushed && progress); 
			return progress;
		}


		public void SetInput(byte[] buffer, int offset, int count)
		{
			if ( buffer == null ) 
			{
				throw new ArgumentNullException("buffer");
			}

			if ( offset < 0 ) 
			{
				throw new ArgumentOutOfRangeException("offset");
			}

			if ( count < 0 ) 
			{
				throw new ArgumentOutOfRangeException("count");
			}

			if (inputOff < inputEnd) 
			{
				throw new InvalidOperationException("Old input was not completely processed");
			}
			
			int end = offset + count;
			

			if ((offset > end) || (end > buffer.Length) ) 
			{
				throw new ArgumentOutOfRangeException("count");
			}
			
			inputBuf = buffer;
			inputOff = offset;
			inputEnd = end;
		}


		public bool NeedsInput()
		{
			return (inputEnd == inputOff);
		}


		public void SetDictionary(byte[] buffer, int offset, int length) 
		{
#if DebugDeflation
			if (DeflaterConstants.DEBUGGING && (strstart != 1) ) 
			{
				throw new InvalidOperationException("strstart not 1");
			}
#endif
			adler.Update(buffer, offset, length);
			if (length < MIN_MATCH) 
			{
				return;
			}

			if (length > MAX_DIST) 
			{
				offset += length - MAX_DIST;
				length = MAX_DIST;
			}
			
			System.Array.Copy(buffer, offset, window, strstart, length);
			
			UpdateHash();
			--length;
			while (--length > 0) 
			{
				InsertString();
				strstart++;
			}
			strstart += 2;
			blockStart = strstart;
		}
		
		
		public void Reset()
		{
			huffman.Reset();
			adler.Reset();
			blockStart = strstart = 1;
			lookahead = 0;
			totalIn   = 0;
			prevAvailable = false;
			matchLen = MIN_MATCH - 1;
			
			for (int i = 0; i < HASH_SIZE; i++) {
				head[i] = 0;
			}
			
			for (int i = 0; i < WSIZE; i++) {
				prev[i] = 0;
			}
		}

	
		public void ResetAdler()
		{
			adler.Reset();
		}

	
		public int Adler {
			get {
				return unchecked((int)adler.Value);
			}
		}
	
		public long TotalIn {
			get {
				return totalIn;
			}
		}

	
		public DeflateStrategy Strategy {
			get {
				return strategy;
			}
			set {
				strategy = value;
			}
		}
		

		public void SetLevel(int level)
		{
			if ( (level < 0) || (level > 9) )
			{
				throw new ArgumentOutOfRangeException("level");
			}

			goodLength = DeflaterConstants.GOOD_LENGTH[level];
			max_lazy   = DeflaterConstants.MAX_LAZY[level];
			niceLength = DeflaterConstants.NICE_LENGTH[level];
			max_chain  = DeflaterConstants.MAX_CHAIN[level];
			
			if (DeflaterConstants.COMPR_FUNC[level] != compressionFunction) {

#if DebugDeflation
				if (DeflaterConstants.DEBUGGING) {
				   Console.WriteLine("Change from " + compressionFunction + " to "
										  + DeflaterConstants.COMPR_FUNC[level]);
				}
#endif
				switch (compressionFunction) {
					case DEFLATE_STORED:
						if (strstart > blockStart) {
							huffman.FlushStoredBlock(window, blockStart,
								strstart - blockStart, false);
							blockStart = strstart;
						}
						UpdateHash();
						break;

					case DEFLATE_FAST:
						if (strstart > blockStart) {
							huffman.FlushBlock(window, blockStart, strstart - blockStart,
								false);
							blockStart = strstart;
						}
						break;

					case DEFLATE_SLOW:
						if (prevAvailable) {
							huffman.TallyLit(window[strstart-1] & 0xff);
						}
						if (strstart > blockStart) {
							huffman.FlushBlock(window, blockStart, strstart - blockStart, false);
							blockStart = strstart;
						}
						prevAvailable = false;
						matchLen = MIN_MATCH - 1;
						break;
				}
				compressionFunction = COMPR_FUNC[level];
			}
		}
		

		public void FillWindow()
		{

			if (strstart >= WSIZE + MAX_DIST) 
			{
				SlideWindow();
			}
			

			while (lookahead < DeflaterConstants.MIN_LOOKAHEAD && inputOff < inputEnd) 
			{
				int more = 2 * WSIZE - lookahead - strstart;
				
				if (more > inputEnd - inputOff) 
				{
					more = inputEnd - inputOff;
				}
				
				System.Array.Copy(inputBuf, inputOff, window, strstart + lookahead, more);
				adler.Update(inputBuf, inputOff, more);
				
				inputOff += more;
				totalIn  += more;
				lookahead += more;
			}
			
			if (lookahead >= MIN_MATCH) 
			{
				UpdateHash();
			}
		}
		
		void UpdateHash() 
		{
			ins_h = (window[strstart] << HASH_SHIFT) ^ window[strstart + 1];
		}
		

		int InsertString() 
		{
			short match;
			int hash = ((ins_h << HASH_SHIFT) ^ window[strstart + (MIN_MATCH -1)]) & HASH_MASK;

#if DebugDeflation
			if (DeflaterConstants.DEBUGGING) 
			{
				if (hash != (((window[strstart] << (2*HASH_SHIFT)) ^ 
								  (window[strstart + 1] << HASH_SHIFT) ^ 
								  (window[strstart + 2])) & HASH_MASK)) {
						throw new SharpZipBaseException("hash inconsistent: " + hash + "/"
												+window[strstart] + ","
												+window[strstart + 1] + ","
												+window[strstart + 2] + "," + HASH_SHIFT);
					}
			}
#endif
			prev[strstart & WMASK] = match = head[hash];
			head[hash] = unchecked((short)strstart);
			ins_h = hash;
			return match & 0xffff;
		}
		
		void SlideWindow()
		{
			Array.Copy(window, WSIZE, window, 0, WSIZE);
			matchStart -= WSIZE;
			strstart   -= WSIZE;
			blockStart -= WSIZE;
			

			for (int i = 0; i < HASH_SIZE; ++i) {
				int m = head[i] & 0xffff;
				head[i] = (short)(m >= WSIZE ? (m - WSIZE) : 0);
			}
			
			for (int i = 0; i < WSIZE; i++) {
				int m = prev[i] & 0xffff;
				prev[i] = (short)(m >= WSIZE ? (m - WSIZE) : 0);
			}
		}
		

		bool FindLongestMatch(int curMatch) 
		{
			int chainLength = this.max_chain;
			int niceLength  = this.niceLength;
			short[] prev    = this.prev;
			int scan        = this.strstart;
			int match;
			int best_end = this.strstart + matchLen;
			int best_len = Math.Max(matchLen, MIN_MATCH - 1);
			
			int limit = Math.Max(strstart - MAX_DIST, 0);
			
			int strend = strstart + MAX_MATCH - 1;
			byte scan_end1 = window[best_end - 1];
			byte scan_end  = window[best_end];
			

			if (best_len >= this.goodLength) {
				chainLength >>= 2;
			}
			

			if (niceLength > lookahead) {
				niceLength = lookahead;
			}
			
#if DebugDeflation

			if (DeflaterConstants.DEBUGGING && (strstart > 2 * WSIZE - MIN_LOOKAHEAD))
			{
				throw new InvalidOperationException("need lookahead");
			}
#endif			
	
			do {

#if DebugDeflation

				if (DeflaterConstants.DEBUGGING && (curMatch >= strstart) )
				{
					throw new InvalidOperationException("no future");
				}
#endif            
				if (window[curMatch + best_len] != scan_end      || 
					window[curMatch + best_len - 1] != scan_end1 || 
					window[curMatch] != window[scan]             || 
					window[curMatch + 1] != window[scan + 1]) {
					continue;
				}
				
				match = curMatch + 2;
				scan += 2;
				

				while (
					window[++scan] == window[++match] && 
					window[++scan] == window[++match] && 
					window[++scan] == window[++match] && 
					window[++scan] == window[++match] && 
					window[++scan] == window[++match] && 
					window[++scan] == window[++match] && 
					window[++scan] == window[++match] && 
					window[++scan] == window[++match] &&
					(scan < strend))
				{

				}
				
				if (scan > best_end) {
#if DebugDeflation
					if (DeflaterConstants.DEBUGGING && (ins_h == 0) )
						Console.Error.WriteLine("Found match: " + curMatch + "-" + (scan - strstart));
#endif
					matchStart = curMatch;
					best_end = scan;
					best_len = scan - strstart;
					
					if (best_len >= niceLength) {
						break;
					}
					
					scan_end1  = window[best_end - 1];
					scan_end   = window[best_end];
				}
				scan = strstart;
			} while ((curMatch = (prev[curMatch & WMASK] & 0xffff)) > limit && --chainLength != 0);
			
			matchLen = Math.Min(best_len, lookahead);
			return matchLen >= MIN_MATCH;
		}
		
		bool DeflateStored(bool flush, bool finish)
		{
			if (!flush && (lookahead == 0)) {
				return false;
			}
			
			strstart += lookahead;
			lookahead = 0;
			
			int storedLength = strstart - blockStart;
			
			if ((storedLength >= DeflaterConstants.MAX_BLOCK_SIZE) || 
				(blockStart < WSIZE && storedLength >= MAX_DIST) ||   
				flush) {
				bool lastBlock = finish;
				if (storedLength > DeflaterConstants.MAX_BLOCK_SIZE) {
					storedLength = DeflaterConstants.MAX_BLOCK_SIZE;
					lastBlock = false;
				}
				
#if DebugDeflation
				if (DeflaterConstants.DEBUGGING) 
				{
				   Console.WriteLine("storedBlock[" + storedLength + "," + lastBlock + "]");
				}
#endif

				huffman.FlushStoredBlock(window, blockStart, storedLength, lastBlock);
				blockStart += storedLength;
				return !lastBlock;
			}
			return true;
		}
		
		bool DeflateFast(bool flush, bool finish)
		{
			if (lookahead < MIN_LOOKAHEAD && !flush) {
				return false;
			}
			
			while (lookahead >= MIN_LOOKAHEAD || flush) {
				if (lookahead == 0) {
					huffman.FlushBlock(window, blockStart, strstart - blockStart, finish);
					blockStart = strstart;
					return false;
				}
				
				if (strstart > 2 * WSIZE - MIN_LOOKAHEAD) {
					SlideWindow();
				}
				
				int hashHead;
				if (lookahead >= MIN_MATCH && 
					(hashHead = InsertString()) != 0 && 
					strategy != DeflateStrategy.HuffmanOnly &&
					strstart - hashHead <= MAX_DIST && 
					FindLongestMatch(hashHead)) {

#if DebugDeflation
					if (DeflaterConstants.DEBUGGING) 
					{
						for (int i = 0 ; i < matchLen; i++) {
							if (window[strstart + i] != window[matchStart + i]) {
								throw new SharpZipBaseException("Match failure");
							}
						}
					}
#endif					

					bool full = huffman.TallyDist(strstart - matchStart, matchLen);

					lookahead -= matchLen;
					if (matchLen <= max_lazy && lookahead >= MIN_MATCH) {
						while (--matchLen > 0) {
							++strstart;
							InsertString();
						}
						++strstart;
					} else {
						strstart += matchLen;
						if (lookahead >= MIN_MATCH - 1) {
							UpdateHash();
						}
					}
					matchLen = MIN_MATCH - 1;
					if (!full) {
						continue;
					}
				} else {
					huffman.TallyLit(window[strstart] & 0xff);
					++strstart;
					--lookahead;
				}
				
				if (huffman.IsFull()) {
					bool lastBlock = finish && (lookahead == 0);
					huffman.FlushBlock(window, blockStart, strstart - blockStart, lastBlock);
					blockStart = strstart;
					return !lastBlock;
				}
			}
			return true;
		}
		
		bool DeflateSlow(bool flush, bool finish)
		{
			if (lookahead < MIN_LOOKAHEAD && !flush) {
				return false;
			}
			
			while (lookahead >= MIN_LOOKAHEAD || flush) {
				if (lookahead == 0) {
					if (prevAvailable) {
						huffman.TallyLit(window[strstart-1] & 0xff);
					}
					prevAvailable = false;
					
#if DebugDeflation
					if (DeflaterConstants.DEBUGGING && !flush) 
					{
						throw new SharpZipBaseException("Not flushing, but no lookahead");
					}
#endif               
					huffman.FlushBlock(window, blockStart, strstart - blockStart,
						finish);
					blockStart = strstart;
					return false;
				}
				
				if (strstart >= 2 * WSIZE - MIN_LOOKAHEAD) {

					SlideWindow();
				}
				
				int prevMatch = matchStart;
				int prevLen = matchLen;
				if (lookahead >= MIN_MATCH) {

					int hashHead = InsertString();

					if (strategy != DeflateStrategy.HuffmanOnly &&
						hashHead != 0 &&
						strstart - hashHead <= MAX_DIST &&
						FindLongestMatch(hashHead)) {
						

						if (matchLen <= 5 && (strategy == DeflateStrategy.Filtered || (matchLen == MIN_MATCH && strstart - matchStart > TooFar))) {
							matchLen = MIN_MATCH - 1;
						}
					}
				}
				

				if ((prevLen >= MIN_MATCH) && (matchLen <= prevLen) ) {
#if DebugDeflation
					if (DeflaterConstants.DEBUGGING) 
					{
					   for (int i = 0 ; i < matchLen; i++) {
						  if (window[strstart-1+i] != window[prevMatch + i])
							 throw new SharpZipBaseException();
						}
					}
#endif
					huffman.TallyDist(strstart - 1 - prevMatch, prevLen);
					prevLen -= 2;
					do {
						strstart++;
						lookahead--;
						if (lookahead >= MIN_MATCH) {
							InsertString();
						}
					} while (--prevLen > 0);

					strstart ++;
					lookahead--;
					prevAvailable = false;
					matchLen = MIN_MATCH - 1;
				} else {
					if (prevAvailable) {
						huffman.TallyLit(window[strstart-1] & 0xff);
					}
					prevAvailable = true;
					strstart++;
					lookahead--;
				}
				
				if (huffman.IsFull()) {
					int len = strstart - blockStart;
					if (prevAvailable) {
						len--;
					}
					bool lastBlock = (finish && (lookahead == 0) && !prevAvailable);
					huffman.FlushBlock(window, blockStart, len, lastBlock);
					blockStart += len;
					return !lastBlock;
				}
			}
			return true;
		}
		
		#region Instance Fields

		int ins_h;


		short[] head;


		short[] prev;
		
		int    matchStart;

		int    matchLen;

		bool   prevAvailable;
		int    blockStart;

		int    strstart;


		int    lookahead;


		byte[] window;
		
		DeflateStrategy strategy;
		int max_chain, max_lazy, niceLength, goodLength;
		

		int compressionFunction;
		

		byte[] inputBuf;
		

		long totalIn;
		

		int inputOff;
		

		int inputEnd;
		
		DeflaterPending pending;
		DeflaterHuffman huffman;
		
		Adler32 adler;
		#endregion
	}
}
