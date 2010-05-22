

using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	public class Deflater
	{
		#region Public Constants

		public const  int BEST_COMPRESSION = 9;
		

		public const  int BEST_SPEED = 1;
		

		public const  int DEFAULT_COMPRESSION = -1;
		

		public const  int NO_COMPRESSION = 0;
				

		public const  int DEFLATED = 8;
		#endregion
		#region Local Constants
		private const  int IS_SETDICT              = 0x01;
		private const  int IS_FLUSHING             = 0x04;
		private const  int IS_FINISHING            = 0x08;
		
		private const  int INIT_STATE              = 0x00;
		private const  int SETDICT_STATE           = 0x01;
		private const  int BUSY_STATE              = 0x10;
		private const  int FLUSHING_STATE          = 0x14;
		private const  int FINISHING_STATE         = 0x1c;
		private const  int FINISHED_STATE          = 0x1e;
		private const  int CLOSED_STATE            = 0x7f;
		#endregion
		#region Constructors

		public Deflater() : this(DEFAULT_COMPRESSION, false)
		{
			
		}
		

		public Deflater(int level) : this(level, false)
		{
			
		}
		

		public Deflater(int level, bool noZlibHeaderOrFooter)
		{
			if (level == DEFAULT_COMPRESSION) {
				level = 6;
			} else if (level < NO_COMPRESSION || level > BEST_COMPRESSION) {
				throw new ArgumentOutOfRangeException("level");
			}
			
			pending = new DeflaterPending();
			engine = new DeflaterEngine(pending);
			this.noZlibHeaderOrFooter = noZlibHeaderOrFooter;
			SetStrategy(DeflateStrategy.Default);
			SetLevel(level);
			Reset();
		}
		#endregion
		

		public void Reset()
		{
			state = (noZlibHeaderOrFooter ? BUSY_STATE : INIT_STATE);
			totalOut = 0;
			pending.Reset();
			engine.Reset();
		}

		public int Adler {
			get {
				return engine.Adler;
			}
		}
		

		public long TotalIn {
			get {
				return engine.TotalIn;
			}
		}
		

		public long TotalOut {
			get {
				return totalOut;
			}
		}
		

		public void Flush() 
		{
			state |= IS_FLUSHING;
		}
		

		public void Finish() 
		{
			state |= (IS_FLUSHING | IS_FINISHING);
		}
		

		public bool IsFinished {
			get {
				return (state == FINISHED_STATE) && pending.IsFlushed;
			}
		}
		

		public bool IsNeedingInput {
			get {
				return engine.NeedsInput();
			}
		}
		

		public void SetInput(byte[] input)
		{
			SetInput(input, 0, input.Length);
		}
		

		public void SetInput(byte[] input, int offset, int count)
		{
			if ((state & IS_FINISHING) != 0) {
				throw new InvalidOperationException("Finish() already called");
			}
			engine.SetInput(input, offset, count);
		}
		

		public void SetLevel(int level)
		{
			if (level == DEFAULT_COMPRESSION) {
				level = 6;
			} else if (level < NO_COMPRESSION || level > BEST_COMPRESSION) {
				throw new ArgumentOutOfRangeException("level");
			}
			
			if (this.level != level) {
				this.level = level;
				engine.SetLevel(level);
			}
		}
		

		public int GetLevel() {
			return level;
		}
		

		public void SetStrategy(DeflateStrategy strategy)
		{
			engine.Strategy = strategy;
		}
		

		public int Deflate(byte[] output)
		{
			return Deflate(output, 0, output.Length);
		}
		

		public int Deflate(byte[] output, int offset, int length)
		{
			int origLength = length;
			
			if (state == CLOSED_STATE) {
				throw new InvalidOperationException("Deflater closed");
			}
			
			if (state < BUSY_STATE) {

				int header = (DEFLATED +
					((DeflaterConstants.MAX_WBITS - 8) << 4)) << 8;
				int level_flags = (level - 1) >> 1;
				if (level_flags < 0 || level_flags > 3) {
					level_flags = 3;
				}
				header |= level_flags << 6;
				if ((state & IS_SETDICT) != 0) {
	
					header |= DeflaterConstants.PRESET_DICT;
				}
				header += 31 - (header % 31);
				
				pending.WriteShortMSB(header);
				if ((state & IS_SETDICT) != 0) {
					int chksum = engine.Adler;
					engine.ResetAdler();
					pending.WriteShortMSB(chksum >> 16);
					pending.WriteShortMSB(chksum & 0xffff);
				}
				
				state = BUSY_STATE | (state & (IS_FLUSHING | IS_FINISHING));
			}
			
			for (;;) {
				int count = pending.Flush(output, offset, length);
				offset   += count;
				totalOut += count;
				length   -= count;
				
				if (length == 0 || state == FINISHED_STATE) {
					break;
				}
				
				if (!engine.Deflate((state & IS_FLUSHING) != 0, (state & IS_FINISHING) != 0)) {
					if (state == BUSY_STATE) {

						return origLength - length;
					} else if (state == FLUSHING_STATE) {
						if (level != NO_COMPRESSION) {

							int neededbits = 8 + ((-pending.BitCount) & 7);
							while (neededbits > 0) {

								pending.WriteBits(2, 10);
								neededbits -= 10;
							}
						}
						state = BUSY_STATE;
					} else if (state == FINISHING_STATE) {
						pending.AlignToByte();


						if (!noZlibHeaderOrFooter) {
							int adler = engine.Adler;
							pending.WriteShortMSB(adler >> 16);
							pending.WriteShortMSB(adler & 0xffff);
						}
						state = FINISHED_STATE;
					}
				}
			}
			return origLength - length;
		}
		

		public void SetDictionary(byte[] dictionary)
		{
			SetDictionary(dictionary, 0, dictionary.Length);
		}
		

		public void SetDictionary(byte[] dictionary, int index, int count)
		{
			if (state != INIT_STATE) {
				throw new InvalidOperationException();
			}
			
			state = SETDICT_STATE;
			engine.SetDictionary(dictionary, index, count);
		}

		#region Instance Fields

		int level;
		

		bool noZlibHeaderOrFooter;
		

		int state;
		

		long totalOut;
		

		DeflaterPending pending;
		

		DeflaterEngine engine;
		#endregion
	}
}
