using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.BZip2
{
	public sealed class BZip2
	{
		public static void Decompress(Stream inStream, Stream outStream) 
		{
			if ( inStream == null ) {
				throw new ArgumentNullException("inStream");
			}
			
			if ( outStream == null ) {
				throw new ArgumentNullException("outStream");
			}
			
			using ( outStream ) {
				using ( BZip2InputStream bzis = new BZip2InputStream(inStream) ) {
					int ch = bzis.ReadByte();
					while (ch != -1) {
						outStream.WriteByte((byte)ch);
						ch = bzis.ReadByte();
					}
				}
			}
		}
		
		public static void Compress(Stream inStream, Stream outStream, int blockSize) 
		{			
			if ( inStream == null ) {
				throw new ArgumentNullException("inStream");
			}
			
			if ( outStream == null ) {
				throw new ArgumentNullException("outStream");
			}
			
			using ( inStream ) {
				using (BZip2OutputStream bzos = new BZip2OutputStream(outStream, blockSize)) {
					int ch = inStream.ReadByte();
					while (ch != -1) {
						bzos.WriteByte((byte)ch);
						ch = inStream.ReadByte();
					}
				}
			}
		}


		BZip2()
		{
		}
	}
}
