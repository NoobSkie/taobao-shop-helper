using System;

#if !NETCF_1_0 && !NETCF_2_0
using System.Runtime.Serialization;
#endif

namespace ICSharpCode.SharpZipLib
{
#if !NETCF_1_0 && !NETCF_2_0
	[Serializable]
#endif
	public class SharpZipBaseException : ApplicationException
	{
#if !NETCF_1_0 && !NETCF_2_0
		protected SharpZipBaseException(SerializationInfo info, StreamingContext context )
			: base( info, context )
		{
		}
#endif
		
		public SharpZipBaseException()
		{
		}
		

		public SharpZipBaseException(string message)
			: base(message)
		{
		}


		public SharpZipBaseException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
