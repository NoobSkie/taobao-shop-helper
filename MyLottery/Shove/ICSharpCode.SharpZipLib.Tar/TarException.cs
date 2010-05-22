using System;

#if !NETCF_1_0 && !NETCF_2_0
using System.Runtime.Serialization;
#endif

using ICSharpCode.SharpZipLib;

namespace ICSharpCode.SharpZipLib.Tar {
	

#if !NETCF_1_0 && !NETCF_2_0
	[Serializable]
#endif
	public class TarException : SharpZipBaseException
	{
#if !NETCF_1_0 && !NETCF_2_0
		protected TarException(SerializationInfo info, StreamingContext context)
			: base(info, context)

		{
		}
#endif

		public TarException()
		{
		}
		
		public TarException(string message)
			: base(message)
		{
		}

		public TarException(string message, Exception exception)
			: base(message, exception)
		{
		}
	}
}
