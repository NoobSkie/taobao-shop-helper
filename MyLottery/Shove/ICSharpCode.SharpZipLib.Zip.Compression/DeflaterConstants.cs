

using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression 
{
	public class DeflaterConstants 
	{
		public const bool DEBUGGING = false;
	
		public const int STORED_BLOCK = 0;

		public const int STATIC_TREES = 1;
		
		public const int DYN_TREES    = 2;
		

		public const int PRESET_DICT  = 0x20;
		
	
		public const int DEFAULT_MEM_LEVEL = 8;
		
		public const int MAX_MATCH = 258;
		

		public const int MIN_MATCH = 3;
		
	
		public const int MAX_WBITS = 15;
		
	
		public const int WSIZE = 1 << MAX_WBITS;
		
		
		public const int WMASK = WSIZE - 1;
		
		
		public const int HASH_BITS = DEFAULT_MEM_LEVEL + 7;
		
	
		public const int HASH_SIZE = 1 << HASH_BITS;
		
			
		public const int HASH_MASK = HASH_SIZE - 1;
		
	
		public const int HASH_SHIFT = (HASH_BITS + MIN_MATCH - 1) / MIN_MATCH;
		
		
		public const int MIN_LOOKAHEAD = MAX_MATCH + MIN_MATCH + 1;
		
	
		public const int MAX_DIST = WSIZE - MIN_LOOKAHEAD;
		
	
		public const int PENDING_BUF_SIZE = 1 << (DEFAULT_MEM_LEVEL + 8);
		
		
		public static int MAX_BLOCK_SIZE = Math.Min(65535, PENDING_BUF_SIZE - 5);
		
	
		public const int DEFLATE_STORED = 0;
		
	
		public const int DEFLATE_FAST   = 1;
		
		
		public const int DEFLATE_SLOW   = 2;
		
	
		public static int[] GOOD_LENGTH = { 0, 4,  4,  4,  4,  8,   8,   8,   32,   32 };
		
			
		public static int[] MAX_LAZY    = { 0, 4,  5,  6,  4, 16,  16,  32,  128,  258 };
		
	
		public static int[] NICE_LENGTH = { 0, 8, 16, 32, 16, 32, 128, 128,  258,  258 };
		
		
		public static int[] MAX_CHAIN   = { 0, 4,  8, 32, 16, 32, 128, 256, 1024, 4096 };
		
	
		public static int[] COMPR_FUNC  = { 0, 1,  1,  1,  1,  2,   2,   2,    2,    2 };
		
	}
}
