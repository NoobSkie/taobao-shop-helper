using System;

#if !NETCF_1_0 && !NETCF_2_0
using System.Runtime.Serialization;
#endif

using ICSharpCode.SharpZipLib;

namespace ICSharpCode.SharpZipLib.GZip
{

#if !NETCF_1_0 && !NETCF_2_0
	[Serializable]
#endif	
	public class GZipException : SharpZipBaseException
	{
#if !NETCF_1_0 && !NETCF_2_0
		protected GZipException(SerializationInfo info, StreamingContext context)
			: base(info, context)

		{
		}
#endif


		public GZipException()
		{
		}
		

		public GZipException(string message)
			: base(message)
		{
		}

		public GZipException(string message, Exception innerException)
			: base (message, innerException)
		{	
		}
	}
}
