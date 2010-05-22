using System;

#if !NETCF_1_0 && !NETCF_2_0
using System.Runtime.Serialization;
#endif

namespace ICSharpCode.SharpZipLib.Zip 
{
#if !NETCF_1_0 && !NETCF_2_0
	[Serializable]
#endif
	public class ZipException : SharpZipBaseException
	{
#if !NETCF_1_0 && !NETCF_2_0
		protected ZipException(SerializationInfo info, StreamingContext context )
			: base( info, context )
		{
		}
#endif


		public ZipException()
		{
		}
		

		public ZipException(string message)
			: base(message)
		{
		}

		public ZipException(string message, Exception exception)
			: base(message, exception)
		{
		}
	}
}
