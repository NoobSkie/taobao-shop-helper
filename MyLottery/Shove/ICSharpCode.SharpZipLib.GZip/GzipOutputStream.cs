using System;
using System.IO;

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.GZip 
{
	
	
	public class GZipOutputStream : DeflaterOutputStream
	{
        enum OutputState
        {
            Header,
            Footer, 
            Finished,
            Closed,
        };

		#region Instance Fields

		protected Crc32 crc = new Crc32();
        OutputState state_ = OutputState.Header;
		#endregion

		#region Constructors

		public GZipOutputStream(Stream baseOutputStream)
			: this(baseOutputStream, 4096)
		{
		}
		
		
		public GZipOutputStream(Stream baseOutputStream, int size) : base(baseOutputStream, new Deflater(Deflater.DEFAULT_COMPRESSION, true), size)
		{
		}
		#endregion
	
		#region Public API
		
		public void SetLevel(int level)
		{
			if (level < Deflater.BEST_SPEED) {
				throw new ArgumentOutOfRangeException("level");
			}
			deflater_.SetLevel(level);
		}
		
		
		public int GetLevel()
		{
			return deflater_.GetLevel();
		}
		#endregion
		
		#region Stream overrides
		
		public override void Write(byte[] buffer, int offset, int count)
		{
			if ( state_ == OutputState.Header ) {
				WriteHeader();
			}

            if( state_!=OutputState.Footer )
            {
                throw new InvalidOperationException("Write not permitted in current state");
            }

			crc.Update(buffer, offset, count);
			base.Write(buffer, offset, count);
		}
		
	
		public override void Close()
		{
			try {
				Finish();
			}
			finally {
                if ( state_ != OutputState.Closed ) {
                    state_ = OutputState.Closed;
				    if( IsStreamOwner ) {
					    baseOutputStream_.Close();
				    }
                }
			}
		}
		#endregion
		
		#region DeflaterOutputStream overrides
		
		public override void Finish()
		{
			if ( state_ == OutputState.Header ) {
				WriteHeader();
			}

            if( state_ == OutputState.Footer)
            {
                state_=OutputState.Finished;
                base.Finish();

                uint totalin=(uint)(deflater_.TotalIn&0xffffffff);
                uint crcval=(uint)(crc.Value&0xffffffff);

                byte[] gzipFooter;

                unchecked
                {
                    gzipFooter=new byte[] {
					(byte) crcval, (byte) (crcval >> 8),
					(byte) (crcval >> 16), (byte) (crcval >> 24),
					
					(byte) totalin, (byte) (totalin >> 8),
					(byte) (totalin >> 16), (byte) (totalin >> 24)
				};
                }

                baseOutputStream_.Write(gzipFooter, 0, gzipFooter.Length);
            }
		}
		#endregion
		
		#region Support Routines
		void WriteHeader()
		{
			if ( state_ == OutputState.Header ) 
			{
                state_=OutputState.Footer;

				int mod_time = (int)((DateTime.Now.Ticks - new DateTime(1970, 1, 1).Ticks) / 10000000L);  
				byte[] gzipHeader = {
	
					(byte) (GZipConstants.GZIP_MAGIC >> 8), (byte) (GZipConstants.GZIP_MAGIC & 0xff),

					(byte) Deflater.DEFLATED,

					0,

					(byte) mod_time, (byte) (mod_time >> 8),
					(byte) (mod_time >> 16), (byte) (mod_time >> 24),

					0,

					(byte) 255
				};
				baseOutputStream_.Write(gzipHeader, 0, gzipHeader.Length);
			}
		}
		#endregion
	}
}
