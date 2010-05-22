
namespace ICSharpCode.SharpZipLib.GZip 
{
	sealed public class GZipConstants
	{
		public const int GZIP_MAGIC = 0x1F8B;

		public const int FTEXT    = 0x1;

		public const int FHCRC    = 0x2;

		public const int FEXTRA   = 0x4;

		public const int FNAME    = 0x8;

		public const int FCOMMENT = 0x10;

		GZipConstants()
		{
		}
	}
}
