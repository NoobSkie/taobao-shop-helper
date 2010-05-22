using System;

namespace ICSharpCode.SharpZipLib.Checksums 
{
	public sealed class Adler32 : IChecksum
	{

		const uint BASE = 65521;

		public long Value {
			get {
				return checksum;
			}
		}

		public Adler32()
		{
			Reset();
		}

		public void Reset()
		{
			checksum = 1;
		}

		public void Update(int value)
		{
			uint s1 = checksum & 0xFFFF;
			uint s2 = checksum >> 16;
			
			s1 = (s1 + ((uint)value & 0xFF)) % BASE;
			s2 = (s1 + s2) % BASE;
			
			checksum = (s2 << 16) + s1;
		}
		
		public void Update(byte[] buffer)
		{
			if ( buffer == null ) {
				throw new ArgumentNullException("buffer");
			}

			Update(buffer, 0, buffer.Length);
		}
		
		public void Update(byte[] buffer, int offset, int count)
		{
			if (buffer == null) {
				throw new ArgumentNullException("buffer");
			}
			
			if (offset < 0) {
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("offset");
#else
				throw new ArgumentOutOfRangeException("offset", "cannot be negative");
#endif				
			}

			if ( count < 0 ) 
			{
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("count");
#else
				throw new ArgumentOutOfRangeException("count", "cannot be negative");
#endif				
			}

			if (offset >= buffer.Length) 
			{
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("offset");
#else
				throw new ArgumentOutOfRangeException("offset", "not a valid index into buffer");
#endif				
			}
			
			if (offset + count > buffer.Length) 
			{
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("count");
#else
				throw new ArgumentOutOfRangeException("count", "exceeds buffer size");
#endif				
			}


			uint s1 = checksum & 0xFFFF;
			uint s2 = checksum >> 16;
			
			while (count > 0) {
				int n = 3800;
				if (n > count) {
					n = count;
				}
				count -= n;
				while (--n >= 0) {
					s1 = s1 + (uint)(buffer[offset++] & 0xff);
					s2 = s2 + s1;
				}
				s1 %= BASE;
				s2 %= BASE;
			}
			
			checksum = (s2 << 16) | s1;
		}
		
		#region Instance Fields
		uint checksum;
		#endregion
	}
}
