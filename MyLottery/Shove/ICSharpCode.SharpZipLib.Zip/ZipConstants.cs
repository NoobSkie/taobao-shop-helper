using System;
using System.Text;
using System.Threading;

#if NETCF_1_0 || NETCF_2_0
using System.Globalization;
#endif

namespace ICSharpCode.SharpZipLib.Zip 
{

	#region Enumerations
	

	public enum UseZip64
	{
		Off,
		On,
		Dynamic,
	}
	

	public enum CompressionMethod
	{
		Stored     = 0,
		Deflated   = 8,
		Deflate64  = 9,
		BZip2      = 11,
		WinZipAES  = 99
		
	}
	

	public enum EncryptionAlgorithm
	{
		None           = 0,
		PkzipClassic   = 1,
		Des            = 0x6601,
		RC2            = 0x6602,
		TripleDes168   = 0x6603,
		TripleDes112   = 0x6609,
		Aes128         = 0x660e,
		Aes192         = 0x660f,
		Aes256         = 0x6610,
		RC2Corrected   = 0x6702,
		Blowfish = 0x6720,
		Twofish = 0x6721,
		RC4            = 0x6801,
		Unknown        = 0xffff
	}

	[Flags]
	public enum GeneralBitFlags : int
	{
		Encrypted = 0x0001,
		Method = 0x0006,
		Descriptor = 0x0008,
		ReservedPKware4 = 0x0010,
		Patched = 0x0020,
		StrongEncryption = 0x0040,
		Unused7 = 0x0080,
		Unused8 = 0x0100,
		Unused9 = 0x0200,
		Unused10 = 0x0400,
		UnicodeText = 0x0800,
		EnhancedCompress = 0x1000,
		HeaderMasked = 0x2000,
		ReservedPkware14 = 0x4000,
		ReservedPkware15 = 0x8000
	}
	
	#endregion


	public sealed class ZipConstants
	{
		#region Versions
		public const int VersionMadeBy = 45;

		[Obsolete("Use VersionMadeBy instead")]
		public const int VERSION_MADE_BY = 45;
		
		public const int VersionStrongEncryption = 50;


		[Obsolete("Use VersionStrongEncryption instead")]
		public const int VERSION_STRONG_ENCRYPTION = 50;
		

		public const int VersionZip64 = 45;
		#endregion
		
		#region Header Sizes
		public const int LocalHeaderBaseSize = 30;
		
		[Obsolete("Use LocalHeaderBaseSize instead")]
		public const int LOCHDR = 30;
		
		public const int Zip64DataDescriptorSize = 24;
		
		public const int DataDescriptorSize = 16;
		
		[Obsolete("Use DataDescriptorSize instead")]
		public const int EXTHDR = 16;
		
		public const int CentralHeaderBaseSize = 46;
		
		[Obsolete("Use CentralHeaderBaseSize instead")]
		public const int CENHDR = 46;
		
		public const int EndOfCentralRecordBaseSize = 22;

		[Obsolete("Use EndOfCentralRecordBaseSize instead")]
		public const int ENDHDR = 22;
		
		public const int CryptoHeaderSize = 12;
		
		[Obsolete("Use CryptoHeaderSize instead")]
		public const int CRYPTO_HEADER_SIZE = 12;
		#endregion
		
		#region Header Signatures
		
		public const int LocalHeaderSignature = 'P' | ('K' << 8) | (3 << 16) | (4 << 24);


		[Obsolete("Use LocalHeaderSignature instead")]
		public const int LOCSIG = 'P' | ('K' << 8) | (3 << 16) | (4 << 24);


		public const int SpanningSignature = 'P' | ('K' << 8) | (7 << 16) | (8 << 24);
		

		[Obsolete("Use SpanningSignature instead")]
		public const int SPANNINGSIG = 'P' | ('K' << 8) | (7 << 16) | (8 << 24);
		
	
		public const int SpanningTempSignature = 'P' | ('K' << 8) | ('0' << 16) | ('0' << 24);
		

		[Obsolete("Use SpanningTempSignature instead")]
		public const int SPANTEMPSIG = 'P' | ('K' << 8) | ('0' << 16) | ('0' << 24);
		

		public const int DataDescriptorSignature = 'P' | ('K' << 8) | (7 << 16) | (8 << 24);
		

		[Obsolete("Use DataDescriptorSignature instead")]
		public const int EXTSIG = 'P' | ('K' << 8) | (7 << 16) | (8 << 24);
		

		[Obsolete("Use CentralHeaderSignature instead")]
		public const int CENSIG = 'P' | ('K' << 8) | (1 << 16) | (2 << 24);

		public const int CentralHeaderSignature = 'P' | ('K' << 8) | (1 << 16) | (2 << 24);

		public const int Zip64CentralFileHeaderSignature = 'P' | ('K' << 8) | (6 << 16) | (6 << 24);
		

		[Obsolete("Use Zip64CentralFileHeaderSignature instead")]
		public const int CENSIG64 = 'P' | ('K' << 8) | (6 << 16) | (6 << 24);
		

		public const int Zip64CentralDirLocatorSignature = 'P' | ('K' << 8) | (6 << 16) | (7 << 24);
		

		public const int ArchiveExtraDataSignature = 'P' | ('K' << 8) | (6 << 16) | (7 << 24);
		

		public const int CentralHeaderDigitalSignature = 'P' | ('K' << 8) | (5 << 16) | (5 << 24);
		

		[Obsolete("Use CentralHeaderDigitalSignaure instead")]
		public const int CENDIGITALSIG = 'P' | ('K' << 8) | (5 << 16) | (5 << 24);


		public const int EndOfCentralDirectorySignature = 'P' | ('K' << 8) | (5 << 16) | (6 << 24);
		

		[Obsolete("Use EndOfCentralDirectorySignature instead")]
		public const int ENDSIG = 'P' | ('K' << 8) | (5 << 16) | (6 << 24);
		#endregion
		
#if NETCF_1_0 || NETCF_2_0
		static int defaultCodePage = CultureInfo.CurrentCulture.TextInfo.ANSICodePage;
#else
		static int defaultCodePage = Thread.CurrentThread.CurrentCulture.TextInfo.OEMCodePage;
#endif
		

		public static int DefaultCodePage {
			get {
				return defaultCodePage; 
			}
			set {
				defaultCodePage = value; 
			}
		}


		public static string ConvertToString(byte[] data, int count)
		{
			if ( data == null ) {
				return string.Empty;	
			}
			
			return Encoding.GetEncoding(DefaultCodePage).GetString(data, 0, count);
		}
	

		public static string ConvertToString(byte[] data)
		{
			if ( data == null ) {
				return string.Empty;	
			}
			return ConvertToString(data, data.Length);
		}


		public static string ConvertToStringExt(int flags, byte[] data, int count)
		{
			if ( data == null ) {
				return string.Empty;	
			}
			
			if ( (flags & (int)GeneralBitFlags.UnicodeText) != 0 ) {
				return Encoding.UTF8.GetString(data, 0, count);
			}
			else {
				return ConvertToString(data, count);
			}
		}
		

		public static string ConvertToStringExt(int flags, byte[] data)
		{
			if ( data == null ) {
				return string.Empty;	
			}
			
			if ( (flags & (int)GeneralBitFlags.UnicodeText) != 0 ) {
				return Encoding.UTF8.GetString(data, 0, data.Length);
			}
			else {
				return ConvertToString(data, data.Length);
			}
		}


		public static byte[] ConvertToArray(string str)
		{
			if ( str == null ) {
				return new byte[0];
			}
			
			return Encoding.GetEncoding(DefaultCodePage).GetBytes(str);
		}


		public static byte[] ConvertToArray(int flags, string str)
		{
			if (str == null) {
				return new byte[0];
			}

			if ((flags & (int)GeneralBitFlags.UnicodeText) != 0) {
				return Encoding.UTF8.GetBytes(str);
			}
			else {
				return ConvertToArray(str);
			}
		}

		

		ZipConstants()
		{

		}
	}
}
