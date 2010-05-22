using System;

#if !NETCF_1_0 && !NETCF_2_0
using System.Runtime.Serialization;
#endif

using ICSharpCode.SharpZipLib;

namespace ICSharpCode.SharpZipLib.BZip2
{
#if !NETCF_1_0 && !NETCF_2_0
	[Serializable]
#endif	
	public class BZip2Exception : SharpZipBaseException
	{

#if !NETCF_1_0 && !NETCF_2_0

		protected BZip2Exception(SerializationInfo info, StreamingContext context)
			: base(info, context)

		{
		}
#endif
	
		public BZip2Exception()
		{
		}
		
		
		public BZip2Exception(string message) : base(message)
		{
		}

		
		public BZip2Exception(string message, Exception exception)
			: base(message, exception)
		{
		}
	}
}
