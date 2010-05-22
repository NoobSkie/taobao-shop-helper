using System;
using System.IO;

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.GZip 
{
	public class GZipInputStream : InflaterInputStream
	{
		#region Instance Fields

		protected Crc32 crc = new Crc32();
		

		protected bool eos;
		
		bool readGZIPHeader;
		#endregion

		#region Constructors

		public GZipInputStream(Stream baseInputStream)
			: this(baseInputStream, 4096)
		{
		}
	
		public GZipInputStream(Stream baseInputStream, int size)
			: base(baseInputStream, new Inflater(true), size)
		{
		}
		#endregion	

		#region Stream overrides

		public override int Read(byte[] buffer, int offset, int count) 
		{

			if (!readGZIPHeader) {
				ReadHeader();
			}
			
			if (eos) {
				return 0;
			}
			

			int bytesRead = base.Read(buffer, offset, count);
			if (bytesRead > 0) {
				crc.Update(buffer, offset, bytesRead);
			}
			
			if (inf.IsFinished) {
				ReadFooter();
			}
			return bytesRead;
		}
		#endregion	

		#region Support routines
		void ReadHeader() 
		{

			Crc32 headCRC = new Crc32();
			int magic = baseInputStream.ReadByte();

			if (magic < 0) {
				throw new EndOfStreamException("EOS reading GZIP header");
			}

			headCRC.Update(magic);
			if (magic != (GZipConstants.GZIP_MAGIC >> 8)) {
				throw new GZipException("Error GZIP header, first magic byte doesn't match");
			}
				
			magic = baseInputStream.ReadByte();

			if (magic < 0) {
				throw new EndOfStreamException("EOS reading GZIP header");
			}
			
			if (magic != (GZipConstants.GZIP_MAGIC & 0xFF)) {
				throw new GZipException("Error GZIP header,  second magic byte doesn't match");
			}

			headCRC.Update(magic);
			

			int compressionType = baseInputStream.ReadByte();

			if ( compressionType < 0 ) {
				throw new EndOfStreamException("EOS reading GZIP header");
			}
		
			if ( compressionType != 8 ) {
				throw new GZipException("Error GZIP header, data not in deflate format");
			}
			headCRC.Update(compressionType);
			

			int flags = baseInputStream.ReadByte();
			if (flags < 0) {
				throw new EndOfStreamException("EOS reading GZIP header");
			}
			headCRC.Update(flags);

			
			if ((flags & 0xE0) != 0) {
				throw new GZipException("Reserved flag bits in GZIP header != 0");
			}
			

			for (int i=0; i< 6; i++) {
				int readByte = baseInputStream.ReadByte();
				if (readByte < 0) {
					throw new EndOfStreamException("EOS reading GZIP header");
				}
				headCRC.Update(readByte);
			}
			

			if ((flags & GZipConstants.FEXTRA) != 0) {
				for (int i=0; i< 2; i++) {
					int readByte = baseInputStream.ReadByte();
					if (readByte < 0) {
						throw new EndOfStreamException("EOS reading GZIP header");
					}
					headCRC.Update(readByte);
				}

				if (baseInputStream.ReadByte() < 0 || baseInputStream.ReadByte() < 0) {
					throw new EndOfStreamException("EOS reading GZIP header");
				}
				
				int len1, len2;
				len1 = baseInputStream.ReadByte();
				len2 = baseInputStream.ReadByte();
				if ((len1 < 0) || (len2 < 0)) {
					throw new EndOfStreamException("EOS reading GZIP header");
				}
				headCRC.Update(len1);
				headCRC.Update(len2);
				
				int extraLen = (len1 << 8) | len2;
				for (int i = 0; i < extraLen;i++) {
					int readByte = baseInputStream.ReadByte();
					if (readByte < 0) 
					{
						throw new EndOfStreamException("EOS reading GZIP header");
					}
					headCRC.Update(readByte);
				}
			}
			
	
			if ((flags & GZipConstants.FNAME) != 0) {
				int readByte;
				while ( (readByte = baseInputStream.ReadByte()) > 0) {
					headCRC.Update(readByte);
				}
				
				if (readByte < 0) {
					throw new EndOfStreamException("EOS reading GZIP header");
				}
				headCRC.Update(readByte);
			}
		
			if ((flags & GZipConstants.FCOMMENT) != 0) {
				int readByte;
				while ( (readByte = baseInputStream.ReadByte()) > 0) {
					headCRC.Update(readByte);
				}
				
				if (readByte < 0) {
					throw new EndOfStreamException("EOS reading GZIP header");
				}

				headCRC.Update(readByte);
			}
		
			if ((flags & GZipConstants.FHCRC) != 0) {
				int tempByte;
				int crcval = baseInputStream.ReadByte();
				if (crcval < 0) {
					throw new EndOfStreamException("EOS reading GZIP header");
				}
				
				tempByte = baseInputStream.ReadByte();
				if (tempByte < 0) {
					throw new EndOfStreamException("EOS reading GZIP header");
				}
				
				crcval = (crcval << 8) | tempByte;
				if (crcval != ((int) headCRC.Value & 0xffff)) {
					throw new GZipException("Header CRC value mismatch");
				}
			}
			
			readGZIPHeader = true;
		}
		
		void ReadFooter() 
		{
			byte[] footer = new byte[8];
			int avail = inf.RemainingInput;
			
			if (avail > 8) {
				avail = 8;
			}
			
			System.Array.Copy(inputBuffer.RawData, inputBuffer.RawLength - inf.RemainingInput, footer, 0, avail);
			int needed = 8 - avail;
			
			while (needed > 0) {
				int count = baseInputStream.Read(footer, 8 - needed, needed);
				if (count <= 0) {
					throw new EndOfStreamException("EOS reading GZIP footer");
				}
				needed -= count; 
			}

			int crcval = (footer[0] & 0xff) | ((footer[1] & 0xff) << 8) | ((footer[2] & 0xff) << 16) | (footer[3] << 24);
			if (crcval != (int) crc.Value) {
				throw new GZipException("GZIP crc sum mismatch, theirs \"" + crcval + "\" and ours \"" + (int) crc.Value);
			}
			
		
			uint total = 
				(uint)((uint)footer[4] & 0xff) |
				(uint)(((uint)footer[5] & 0xff) << 8) |
				(uint)(((uint)footer[6] & 0xff) << 16) |
				(uint)((uint)footer[7] << 24);

			if ((inf.TotalOut & 0xffffffff) != total) {
				throw new GZipException("Number of bytes mismatch in footer");
			}
			
			
			eos = true;
		}
		#endregion
	}
}
