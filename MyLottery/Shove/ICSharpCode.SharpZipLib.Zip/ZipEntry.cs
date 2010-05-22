using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	public enum HostSystemID
	{
		Msdos = 0,
		Amiga = 1,
		OpenVms = 2,
		Unix = 3,
		VMCms = 4,
		AtariST = 5,
		OS2 = 6,
		Macintosh = 7,
		ZSystem = 8,
		Cpm = 9,
		WindowsNT = 10,
		MVS = 11,
		Vse = 12,
		AcornRisc = 13,
		Vfat = 14,
		AlternateMvs = 15,
		BeOS = 16,
		Tandem = 17,
		OS400 = 18,
		OSX = 19,
		WinZipAES = 99,
	}
	

	public class ZipEntry : ICloneable
	{
		[Flags]
		enum Known : byte
		{
			None = 0,
			Size = 0x01,
			CompressedSize = 0x02,
			Crc = 0x04,
			Time = 0x08,
			ExternalAttributes = 0x10,
		}
		
		#region Constructors
		public ZipEntry(string name)
			: this(name, 0, ZipConstants.VersionMadeBy, CompressionMethod.Deflated)
		{
		}


		internal ZipEntry(string name, int versionRequiredToExtract)
			: this(name, versionRequiredToExtract, ZipConstants.VersionMadeBy,
			CompressionMethod.Deflated)
		{
		}
		

		internal ZipEntry(string name, int versionRequiredToExtract, int madeByInfo,
			CompressionMethod method)
		{
			if (name == null) {
				throw new System.ArgumentNullException("name");
			}

			if ( name.Length > 0xffff )	{
				throw new ArgumentException("Name is too long", "name");
			}

			if ( (versionRequiredToExtract != 0) && (versionRequiredToExtract < 10) ) {
				throw new ArgumentOutOfRangeException("versionRequiredToExtract");
			}
			
			this.DateTime = System.DateTime.Now;
			this.name = name;
			this.versionMadeBy = (ushort)madeByInfo;
			this.versionToExtract = (ushort)versionRequiredToExtract;
			this.method = method;
		}
		

		[Obsolete("Use Clone instead")]
		public ZipEntry(ZipEntry entry)
		{
			if ( entry == null ) {
				throw new ArgumentNullException("entry");
			}

			known                  = entry.known;
			name                   = entry.name;
			size                   = entry.size;
			compressedSize         = entry.compressedSize;
			crc                    = entry.crc;
			dosTime                = entry.dosTime;
			method                 = entry.method;
			comment                = entry.comment;
			versionToExtract       = entry.versionToExtract;
			versionMadeBy          = entry.versionMadeBy;
			externalFileAttributes = entry.externalFileAttributes;
			flags                  = entry.flags;

			zipFileIndex           = entry.zipFileIndex;
			offset                 = entry.offset;

			forceZip64_			   = entry.forceZip64_;

			if ( entry.extra != null ) {
				extra = new byte[entry.extra.Length];
				Array.Copy(entry.extra, 0, extra, 0, entry.extra.Length);
			}
		}

		#endregion

		public bool HasCrc 
		{
			get {
				return (known & Known.Crc) != 0;
			}
		}


		public bool IsCrypted 
		{
			get {
				return (flags & 1) != 0; 
			}
			set {
				if (value) {
					flags |= 1;
				} 
				else {
					flags &= ~1;
				}
			}
		}


		public bool IsUnicodeText
		{
			get {
				return ( flags & (int)GeneralBitFlags.UnicodeText ) != 0;
			}
			set {
				if ( value ) {
					flags |= (int)GeneralBitFlags.UnicodeText;
				}
				else {
					flags &= ~(int)GeneralBitFlags.UnicodeText;
				}
			}
		}
		

		internal byte CryptoCheckValue
		{
			get {
				return cryptoCheckValue_;
			}

			set	{
				cryptoCheckValue_ = value;
			}
		}


		public int Flags 
		{
			get { 
				return flags; 
			}
			set {
				flags = value; 
			}
		}


		public long ZipFileIndex 
		{
			get {
				return zipFileIndex;
			}
			set {
				zipFileIndex = value;
			}
		}
		

		public long Offset 
		{
			get {
				return offset;
			}
			set {
				offset = value;
			}
		}


		public int ExternalFileAttributes 
		{
			get {
				if ((known & Known.ExternalAttributes) == 0) {
					return -1;
				} 
				else {
					return externalFileAttributes;
				}
			}
			
			set {
				externalFileAttributes = value;
				known |= Known.ExternalAttributes;
			}
		}


		public int VersionMadeBy 
		{
			get { 
				return (versionMadeBy & 0xff);
			}
		}


		public bool IsDOSEntry
		{
			get {
				return ((HostSystem == ( int )HostSystemID.Msdos) ||
					(HostSystem == ( int )HostSystemID.WindowsNT));
			}
		}

		bool HasDosAttributes(int attributes)
		{
			bool result = false;
			if ( (known & Known.ExternalAttributes) != 0 ) {
				if ( ((HostSystem == (int)HostSystemID.Msdos) || 
					(HostSystem == (int)HostSystemID.WindowsNT)) && 
					(ExternalFileAttributes & attributes) == attributes) {
					result = true;
				}
			}
			return result;
		}


		public int HostSystem 
		{
			get {
				return (versionMadeBy >> 8) & 0xff; 
			}

			set {
				versionMadeBy &= 0xff;
				versionMadeBy |= (ushort)((value & 0xff) << 8);
			}
		}
		
		
		public int Version 
		{
			get {
				if (versionToExtract != 0) {
					return versionToExtract;
				} 
				else {
					int result = 10;
					if ( CentralHeaderRequiresZip64 ) {
						result = ZipConstants.VersionZip64;	
					}
					else if (CompressionMethod.Deflated == method) {
						result = 20;
					} 
					else if (IsDirectory == true) {
						result = 20;
					} 
					else if (IsCrypted == true) {
						result = 20;
					} 
					else if (HasDosAttributes(0x08) ) {
						result = 11;
					}
					return result;
				}
			}
		}

		
		public bool CanDecompress
		{
			get {
				return (Version <= ZipConstants.VersionMadeBy) &&
					((Version == 10) ||
					(Version == 11) ||
					(Version == 20) ||
					(Version == 45)) &&
					IsCompressionMethodSupported();
			}
		}

		
		public void ForceZip64()
		{
			forceZip64_ = true;
		}
		
		
		public bool IsZip64Forced()
		{
			return forceZip64_;
		}

		
		public bool LocalHeaderRequiresZip64 
		{
			get {
				bool result = forceZip64_;

				if ( !result ) {
					ulong trueCompressedSize = compressedSize;

					if ( (versionToExtract == 0) && IsCrypted ) {
						trueCompressedSize += ZipConstants.CryptoHeaderSize;
					}

					
					result =
						((this.size >= uint.MaxValue) || (trueCompressedSize >= uint.MaxValue)) &&
						((versionToExtract == 0) || (versionToExtract >= ZipConstants.VersionZip64));
				}

				return result;
			}
		}
		
	
		public bool CentralHeaderRequiresZip64
		{
			get {
				return LocalHeaderRequiresZip64 || (offset >= uint.MaxValue);
			}
		}
		
		
		public long DosTime 
		{
			get {
				if ((known & Known.Time) == 0) {
					return 0;
				} 
				else {
					return dosTime;
				}
			}
			
			set {
				unchecked {
					dosTime = (uint)value;
				}

				known |= Known.Time;
			}
		}
			

		public DateTime DateTime 
		{
			get {
				uint sec  = Math.Min(59, 2 * (dosTime & 0x1f));
				uint min  = Math.Min(59, (dosTime >> 5) & 0x3f);
				uint hrs  = Math.Min(23, (dosTime >> 11) & 0x1f);
				uint mon  = Math.Max(1, Math.Min(12, ((dosTime >> 21) & 0xf)));
				uint year = ((dosTime >> 25) & 0x7f) + 1980;
				int day = Math.Max(1, Math.Min(DateTime.DaysInMonth((int)year, (int)mon), (int)((dosTime >> 16) & 0x1f)));
				return new System.DateTime((int)year, (int)mon, day, (int)hrs, (int)min, (int)sec);
			}

			set {
				uint year = (uint) value.Year;
				uint month = (uint) value.Month;
				uint day = (uint) value.Day;
				uint hour = (uint) value.Hour;
				uint minute = (uint) value.Minute;
				uint second = (uint) value.Second;
				
				if ( year < 1980 ) {
					year = 1980;
					month = 1;
					day = 1;
					hour = 0;
					minute = 0;
					second = 0;
				}
				else if ( year > 2107 ) {
					year = 2107;
					month = 12;
					day = 31;
					hour = 23;
					minute = 59;
					second = 59;
				}
				
				DosTime = ((year - 1980) & 0x7f) << 25 | 
					(month << 21) |
					(day << 16) |
					(hour << 11) |
					(minute << 5) |
					(second >> 1);
			}
		}
		

		public string Name 
		{
			get {
				return name;
			}
		}
		

		public long Size 
		{
			get {
				return (known & Known.Size) != 0 ? (long)size : -1L;
			}
			set {
				this.size  = (ulong)value;
				this.known |= Known.Size;
			}
		}
		

		public long CompressedSize 
		{
			get {
				return (known & Known.CompressedSize) != 0 ? (long)compressedSize : -1L;
			}
			set {
				this.compressedSize = (ulong)value;
				this.known |= Known.CompressedSize;
			}
		}


		public long Crc 
		{
			get {
				return (known & Known.Crc) != 0 ? crc & 0xffffffffL : -1L;
			}
			set {
				if (((ulong)crc & 0xffffffff00000000L) != 0) {
					throw new ArgumentOutOfRangeException("value");
				}
				this.crc = (uint)value;
				this.known |= Known.Crc;
			}
		}
		

		public CompressionMethod CompressionMethod {
			get {
				return method;
			}

			set {
				if ( !IsCompressionMethodSupported(value) ) {
					throw new NotSupportedException("Compression method not supported");
				}
				this.method = value;
			}
		}
		

		public byte[] ExtraData {
			
			get {

				return extra;
			}

			set {
				if (value == null) {
					extra = null;
				}
				else {
					if (value.Length > 0xffff) {
						throw new System.ArgumentOutOfRangeException("value");
					}
				
					extra = new byte[value.Length];
					Array.Copy(value, 0, extra, 0, value.Length);
				}
			}
		}
		

		internal void ProcessExtraData(bool localHeader)
		{
			ZipExtraData extraData = new ZipExtraData(this.extra);

			if ( extraData.Find(0x0001) ) {
				if ( (versionToExtract & 0xff) < ZipConstants.VersionZip64 ) {
					throw new ZipException("Zip64 Extended information found but version is not valid");
				}

				forceZip64_ = true;

				if ( extraData.ValueLength < 4 ) {
					throw new ZipException("Extra data extended Zip64 information length is invalid");
				}

				if ( localHeader || (size == uint.MaxValue) ) {
					size = (ulong)extraData.ReadLong();
				}

				if ( localHeader || (compressedSize == uint.MaxValue) ) {
					compressedSize = (ulong)extraData.ReadLong();
				}

				if ( !localHeader && (offset == uint.MaxValue) ) {
					offset = extraData.ReadLong();
				}
			}
			else {
				if ( 
					((versionToExtract & 0xff) >= ZipConstants.VersionZip64) &&
					((size == uint.MaxValue) || (compressedSize == uint.MaxValue))
				) {
					throw new ZipException("Zip64 Extended information required but is missing.");
				}
			}

			if ( extraData.Find(10) ) {
				if ( extraData.ValueLength < 8 ) {
					throw new ZipException("NTFS Extra data invalid");
				}

				extraData.ReadInt(); 

				while ( extraData.UnreadCount >= 4 ) {
					int ntfsTag = extraData.ReadShort();
					int ntfsLength = extraData.ReadShort();
					if ( ntfsTag == 1 ) {
						if ( ntfsLength >= 24 ) {
							long lastModification = extraData.ReadLong();
							long lastAccess = extraData.ReadLong();
							long createTime = extraData.ReadLong();

							DateTime = System.DateTime.FromFileTime(lastModification);
						}
						break;
					}
					else {
						extraData.Skip(ntfsLength);
					}
				}
			}
			else if ( extraData.Find(0x5455) ) {
				int length = extraData.ValueLength;	
				int flags = extraData.ReadByte();
					
				if ( ((flags & 1) != 0) && (length >= 5) ) {
					int iTime = extraData.ReadInt();

					DateTime = (new System.DateTime ( 1970, 1, 1, 0, 0, 0 ).ToUniversalTime() +
						new TimeSpan ( 0, 0, 0, iTime, 0 )).ToLocalTime();
				}
			}
		}

		public string Comment {
			get {
				return comment;
			}
			set {

				if ( (value != null) && (value.Length > 0xffff) ) {
#if NETCF_1_0
					throw new ArgumentOutOfRangeException("value");
#else
					throw new ArgumentOutOfRangeException("value", "cannot exceed 65535");
#endif
				}
				
				comment = value;
			}
		}
		

		public bool IsDirectory 
		{
			get {
				int nameLength = name.Length;
				bool result = 
					((nameLength > 0) && 
					((name[nameLength - 1] == '/') || (name[nameLength - 1] == '\\'))) ||
					HasDosAttributes(16)
					;
				return result;
			}
		}
		

		public bool IsFile
		{
			get {
				return !IsDirectory && !HasDosAttributes(8);
			}
		}
		

		public bool IsCompressionMethodSupported()
		{
			return IsCompressionMethodSupported(CompressionMethod);
		}
		
		#region ICloneable Members

		public object Clone()
		{
			ZipEntry result = (ZipEntry)this.MemberwiseClone();

			if ( extra != null ) {
				result.extra = new byte[extra.Length];
				Array.Copy(extra, 0, result.extra, 0, extra.Length);
			}

			return result;
		}
		
		#endregion


		public override string ToString()
		{
			return name;
		}


		public static bool IsCompressionMethodSupported(CompressionMethod method)
		{
			return
				( method == CompressionMethod.Deflated ) ||
				( method == CompressionMethod.Stored );
		}
		

		public static string CleanName(string name)
		{
			if (name == null) {
				return string.Empty;
			}
			
			if (Path.IsPathRooted(name) == true) {

				name = name.Substring(Path.GetPathRoot(name).Length);
			}

			name = name.Replace(@"\", "/");
			
			while ( (name.Length > 0) && (name[0] == '/')) {
				name = name.Remove(0, 1);
			}
			return name;
		}

		#region Instance Fields
		Known known;
		int    externalFileAttributes = -1;   
		
		ushort versionMadeBy;					
												
		
		string name;
		ulong  size;
		ulong  compressedSize;
		ushort versionToExtract;             
		uint   crc;
		uint   dosTime;
		
		CompressionMethod  method = CompressionMethod.Deflated;
		byte[] extra;
		string comment;
		
		int flags;                            

		long zipFileIndex = -1;               
		long offset;                        
		
		bool forceZip64_;
		byte cryptoCheckValue_;
		#endregion
	}
}
