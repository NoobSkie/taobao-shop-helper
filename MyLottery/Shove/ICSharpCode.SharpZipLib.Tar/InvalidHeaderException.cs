using System;

#if !NETCF_1_0 && !NETCF_2_0
using System.Runtime.Serialization;
#endif

namespace ICSharpCode.SharpZipLib.Tar {
	
#if !NETCF_1_0 && !NETCF_2_0
	[Serializable]
#endif
	public class InvalidHeaderException : TarException
	{

#if !NETCF_1_0 && !NETCF_2_0
		
		protected InvalidHeaderException(SerializationInfo information, StreamingContext context)
			: base(information, context)

		{
		}
#endif

	
		public InvalidHeaderException()
		{
		}

		
		public InvalidHeaderException(string message)
			: base(message)
		{
		}

		
		public InvalidHeaderException(string message, Exception exception)
			: base(message, exception)
		{
		}
	}
}

