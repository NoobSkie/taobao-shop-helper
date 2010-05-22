using System;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar 
{
	public class TarHeader : ICloneable
	{
		#region Constants

		public const int NAMELEN = 100;
	
		public const int MODELEN = 8;

		public const int UIDLEN = 8;

		public const int GIDLEN = 8;

		public const int CHKSUMLEN = 8;

		public const int CHKSUMOFS = 148;
	
		public const int SIZELEN = 12;

		public const int MAGICLEN = 6;

		public const int VERSIONLEN = 2;

		public const int MODTIMELEN = 12;

		public const int UNAMELEN = 32;

		public const int GNAMELEN = 32;

		public const int DEVLEN = 8;
		
		public const byte	LF_OLDNORM	= 0;
		
		public const byte	LF_NORMAL	= (byte) '0';

		public const byte	LF_LINK		= (byte) '1';
	
		public const byte	LF_SYMLINK	= (byte) '2';

		public const byte	LF_CHR		= (byte) '3';
	
		public const byte	LF_BLK		= (byte) '4';
	
		public const byte	LF_DIR		= (byte) '5';
	
		public const byte	LF_FIFO		= (byte) '6';
	
		public const byte	LF_CONTIG	= (byte) '7';
	
		public const byte   LF_GHDR    = (byte) 'g';
	
		public const byte   LF_XHDR    = (byte) 'x';
		

		public const byte   LF_ACL            = (byte) 'A';

		public const byte   LF_GNU_DUMPDIR    = (byte) 'D';

		public const byte   LF_EXTATTR        = (byte) 'E' ;
	
		public const byte   LF_META           = (byte) 'I';
	
		public const byte   LF_GNU_LONGLINK   = (byte) 'K';
	
		public const byte   LF_GNU_LONGNAME   = (byte) 'L';

		public const byte   LF_GNU_MULTIVOL   = (byte) 'M';
	
		public const byte   LF_GNU_NAMES      = (byte) 'N';

		public const byte   LF_GNU_SPARSE     = (byte) 'S';
	
		public const byte   LF_GNU_VOLHDR     = (byte) 'V';
	
		public const string	TMAGIC		= "ustar ";
		
		public const string	GNU_TMAGIC	= "ustar  ";

		const long     timeConversionFactor = 10000000L;          
		readonly static DateTime dateTime1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0); 
		#endregion

		#region Constructors

		public TarHeader()
		{
			this.Magic = TarHeader.TMAGIC;
			this.Version = " ";
			
			this.Name     = "";
			this.LinkName = "";
			
			this.UserId    = defaultUserId;
			this.GroupId   = defaultGroupId;
			this.UserName  = defaultUser;
			this.GroupName = defaultGroupName;
			this.Size      = 0;
		}
		#endregion

		#region Properties

		public string Name
		{
			get { return name; }
			set { 
				if ( value == null ) {
					throw new ArgumentNullException("value");
				}
				name = value;	
			}
		}


		[Obsolete("Use the Name property instead", true)]
		public string GetName()
		{
			return name;
		}

		public int Mode
		{
			get { return mode; }
			set { mode = value; }
		}
		
		

		public int UserId
		{
			get { return userId; }
			set { userId = value; }
		}
		
		

		public int GroupId
		{
			get { return groupId; }
			set { groupId = value; }
		}
		

	
		public long Size
		{
			get { return size; }
			set { 
				if ( value < 0 ) {
#if NETCF_1_0
					throw new ArgumentOutOfRangeException("value");
#else
					throw new ArgumentOutOfRangeException("value", "Cannot be less than zero");
#endif					
				}
				size = value; 
			}
		}
		
		
	
		public DateTime ModTime
		{
			get { return modTime; }
			set {
				if ( value < dateTime1970 )
				{
#if NETCF_1_0
					throw new ArgumentOutOfRangeException("value");
#else
					throw new ArgumentOutOfRangeException("value", "ModTime cannot be before Jan 1st 1970");
#endif					
				}
				modTime = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
			}
		}
		
		

		public int Checksum
		{
			get { return checksum; }
		}
		
		
		
		public bool IsChecksumValid
		{
			get { return isChecksumValid; }
		}
		
		
	
		public byte TypeFlag
		{
			get { return typeFlag; }
			set { typeFlag = value; }
		}

		
		
		public string LinkName
		{
			get { return linkName; }
			set {
				if ( value == null ) {
					throw new ArgumentNullException("value");
				}
				linkName = value; 
			}
		}
		
		
		
		public string Magic
		{
			get { return magic; }
			set { 
				if ( value == null ) {
					throw new ArgumentNullException("value");
				}
				magic = value; 
			}
		}
		
		
		
		public string Version
		{
			get {
				return version;
			}

			set { 
				if ( value == null ) {
					throw new ArgumentNullException("value");
				}
				version = value; 
			}
		}
		
		
		public string UserName
		{
			get { return userName; }
			set {
				if (value != null) {
					userName = value.Substring(0, Math.Min(UNAMELEN, value.Length));
				}
				else {
#if NETCF_1_0 || NETCF_2_0
					string currentUser = "PocketPC";
#else
					string currentUser = Environment.UserName;
#endif
					if (currentUser.Length > UNAMELEN) {
						currentUser = currentUser.Substring(0, UNAMELEN);
					}
					userName = currentUser;
				}
			}
		}
		
		
		public string GroupName
		{
			get { return groupName; }
			set { 
				if ( value == null ) {
					groupName = "None";
				}
				else {
					groupName = value; 
				}
			}
		}
		
		
		public int DevMajor
		{
			get { return devMajor; }
			set { devMajor = value; }
		}
		

		public int DevMinor
		{
			get { return devMinor; }
			set { devMinor = value; }
		}
		
		#endregion

		#region ICloneable Members
		public object Clone()
		{
			return this.MemberwiseClone();
		}
		#endregion


		public void ParseBuffer(byte[] header)
		{
			if ( header == null ) 
			{
				throw new ArgumentNullException("header");
			}

			int offset = 0;
			
			name = TarHeader.ParseName(header, offset, TarHeader.NAMELEN).ToString();
			offset += TarHeader.NAMELEN;
			
			mode = (int)TarHeader.ParseOctal(header, offset, TarHeader.MODELEN);
			offset += TarHeader.MODELEN;
			
			UserId = (int)TarHeader.ParseOctal(header, offset, TarHeader.UIDLEN);
			offset += TarHeader.UIDLEN;
			
			GroupId = (int)TarHeader.ParseOctal(header, offset, TarHeader.GIDLEN);
			offset += TarHeader.GIDLEN;
			
			Size = TarHeader.ParseOctal(header, offset, TarHeader.SIZELEN);
			offset += TarHeader.SIZELEN;
			
			ModTime = GetDateTimeFromCTime(TarHeader.ParseOctal(header, offset, TarHeader.MODTIMELEN));
			offset += TarHeader.MODTIMELEN;
			
			checksum = (int)TarHeader.ParseOctal(header, offset, TarHeader.CHKSUMLEN);
			offset += TarHeader.CHKSUMLEN;
			
			TypeFlag = header[ offset++ ];

			LinkName = TarHeader.ParseName(header, offset, TarHeader.NAMELEN).ToString();
			offset += TarHeader.NAMELEN;
			
			Magic = TarHeader.ParseName(header, offset, TarHeader.MAGICLEN).ToString();
			offset += TarHeader.MAGICLEN;
			
			Version = TarHeader.ParseName(header, offset, TarHeader.VERSIONLEN).ToString();
			offset += TarHeader.VERSIONLEN;
			
			UserName = TarHeader.ParseName(header, offset, TarHeader.UNAMELEN).ToString();
			offset += TarHeader.UNAMELEN;
			
			GroupName = TarHeader.ParseName(header, offset, TarHeader.GNAMELEN).ToString();
			offset += TarHeader.GNAMELEN;
			
			DevMajor = (int)TarHeader.ParseOctal(header, offset, TarHeader.DEVLEN);
			offset += TarHeader.DEVLEN;
			
			DevMinor = (int)TarHeader.ParseOctal(header, offset, TarHeader.DEVLEN);

			
			isChecksumValid = Checksum == TarHeader.MakeCheckSum(header);
		}


		public void WriteHeader(byte[] outBuffer)
		{
			if ( outBuffer == null ) 
			{
				throw new ArgumentNullException("outBuffer");
			}

			int offset = 0;
			
			offset = GetNameBytes(this.Name, outBuffer, offset, TarHeader.NAMELEN);
			offset = GetOctalBytes(this.mode, outBuffer, offset, TarHeader.MODELEN);
			offset = GetOctalBytes(this.UserId, outBuffer, offset, TarHeader.UIDLEN);
			offset = GetOctalBytes(this.GroupId, outBuffer, offset, TarHeader.GIDLEN);
			
			long size = this.Size;
			
			offset = GetLongOctalBytes(size, outBuffer, offset, TarHeader.SIZELEN);
			offset = GetLongOctalBytes(GetCTime(this.ModTime), outBuffer, offset, TarHeader.MODTIMELEN);
			
			int csOffset = offset;
			for (int c = 0; c < TarHeader.CHKSUMLEN; ++c) 
			{
				outBuffer[offset++] = (byte)' ';
			}
			
			outBuffer[offset++] = this.TypeFlag;
			
			offset = GetNameBytes(this.LinkName, outBuffer, offset, NAMELEN);
			offset = GetAsciiBytes(this.Magic, 0, outBuffer, offset, MAGICLEN);
			offset = GetNameBytes(this.Version, outBuffer, offset, VERSIONLEN);
			offset = GetNameBytes(this.UserName, outBuffer, offset, UNAMELEN);
			offset = GetNameBytes(this.GroupName, outBuffer, offset, GNAMELEN);
			
			if (this.TypeFlag == LF_CHR || this.TypeFlag == LF_BLK) 
			{
				offset = GetOctalBytes(this.DevMajor, outBuffer, offset, DEVLEN);
				offset = GetOctalBytes(this.DevMinor, outBuffer, offset, DEVLEN);
			}
			
			for ( ; offset < outBuffer.Length; ) 
			{
				outBuffer[offset++] = 0;
			}
			
			checksum = ComputeCheckSum(outBuffer);
			
			GetCheckSumOctalBytes(checksum, outBuffer, csOffset, CHKSUMLEN);
			isChecksumValid = true;
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
		

		public override bool Equals(object obj)
		{
			TarHeader localHeader = obj as TarHeader;

			if ( localHeader != null ) 
			{
				return name == localHeader.name
					&& mode == localHeader.mode
					&& UserId == localHeader.UserId
					&& GroupId == localHeader.GroupId
					&& Size == localHeader.Size
					&& ModTime == localHeader.ModTime
					&& Checksum == localHeader.Checksum
					&& TypeFlag == localHeader.TypeFlag
					&& LinkName == localHeader.LinkName
					&& Magic == localHeader.Magic
					&& Version == localHeader.Version
					&& UserName == localHeader.UserName
					&& GroupName == localHeader.GroupName
					&& DevMajor == localHeader.DevMajor
					&& DevMinor == localHeader.DevMinor;
			}
			else 
			{
				return false;
			}
		}
		

		static public void SetValueDefaults(int userId, string userName, int groupId, string groupName)
		{
			defaultUserId = userIdAsSet = userId;
			defaultUser = userNameAsSet = userName;
			defaultGroupId = groupIdAsSet = groupId;
			defaultGroupName = groupNameAsSet = groupName;
		}

		static public void RestoreSetValues()
		{
			defaultUserId = userIdAsSet;
			defaultUser = userNameAsSet;
			defaultGroupId = groupIdAsSet;
			defaultGroupName = groupNameAsSet;
		}


		static public long ParseOctal(byte[] header, int offset, int length)
		{
			if ( header == null ) {
				throw new ArgumentNullException("header");
			}

			long result = 0;
			bool stillPadding = true;
			
			int end = offset + length;
			for (int i = offset; i < end ; ++i) {
				if (header[i] == 0) {
					break;
				}
				
				if (header[i] == (byte)' ' || header[i] == '0') {
					if (stillPadding) {
						continue;
					}
					
					if (header[i] == (byte)' ') {
						break;
					}
				}
				
				stillPadding = false;
				
				result = (result << 3) + (header[i] - '0');
			}
			
			return result;
		}
		

		static public StringBuilder ParseName(byte[] header, int offset, int length)
		{
			if ( header == null ) {
				throw new ArgumentNullException("header");
			}

			if ( offset < 0 ) {
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("offset");
#else
				throw new ArgumentOutOfRangeException("offset", "Cannot be less than zero");
#endif				
			}

			if ( length < 0 )
			{
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("length");
#else
				throw new ArgumentOutOfRangeException("length", "Cannot be less than zero");
#endif				
			}

			if ( offset + length > header.Length )
			{
				throw new ArgumentException("Exceeds header size", "length");
			}

			StringBuilder result = new StringBuilder(length);
			
			for (int i = offset; i < offset + length; ++i) {
				if (header[i] == 0) {
					break;
				}
				result.Append((char)header[i]);
			}
			
			return result;
		}

		public static int GetNameBytes(StringBuilder name, int nameOffset, byte[] buffer, int bufferOffset, int length)
		{
			if ( name == null ) {
				throw new ArgumentNullException("name");
			}

			if ( buffer == null ) {
				throw new ArgumentNullException("buffer");
			}

			return GetNameBytes(name.ToString(), nameOffset, buffer, bufferOffset, length);
		}
		

		public static int GetNameBytes(string name, int nameOffset, byte[] buffer, int bufferOffset, int length)
		{
			if ( name == null ) 
			{
				throw new ArgumentNullException("name");
			}

			if ( buffer == null )
			{
				throw new ArgumentNullException("buffer");
			}

			int i;
			
			for (i = 0 ; i < length - 1 && nameOffset + i < name.Length; ++i) {
				buffer[bufferOffset + i] = (byte)name[nameOffset + i];
			}
			
			for (; i < length ; ++i) {
				buffer[bufferOffset + i] = 0;
			}
			
			return bufferOffset + length;
		}


		public static int GetNameBytes(StringBuilder name, byte[] buffer, int offset, int length)
		{

			if ( name == null ) {
				throw new ArgumentNullException("name");
			}

			if ( buffer == null ) {
				throw new ArgumentNullException("buffer");
			}

			return GetNameBytes(name.ToString(), 0, buffer, offset, length);
		}
		

		public static int GetNameBytes(string name, byte[] buffer, int offset, int length)
		{

			if ( name == null ) {
				throw new ArgumentNullException("name");
			}

			if ( buffer == null ) 
			{
				throw new ArgumentNullException("buffer");
			}

			return GetNameBytes(name, 0, buffer, offset, length);
		}
		

		public static int GetAsciiBytes(string toAdd, int nameOffset, byte[] buffer, int bufferOffset, int length )
		{
			if ( toAdd == null ) {
				throw new ArgumentNullException("toAdd");
			}

			if ( buffer == null ) {
				throw new ArgumentNullException("buffer");
			}

			for (int i = 0 ; i < length && nameOffset + i < toAdd.Length; ++i) 
			{
				buffer[bufferOffset + i] = (byte)toAdd[nameOffset + i];
			}
			return bufferOffset + length;
		}


		public static int GetOctalBytes(long value, byte[] buffer, int offset, int length)
		{
			if ( buffer == null ) {
				throw new ArgumentNullException("buffer");
			}

			int localIndex = length - 1;


			buffer[offset + localIndex] = 0;
			--localIndex;

			if (value > 0) {
				for ( long v = value; (localIndex >= 0) && (v > 0); --localIndex ) {
					buffer[offset + localIndex] = (byte)((byte)'0' + (byte)(v & 7));
					v >>= 3;
				}
			}
				
			for ( ; localIndex >= 0; --localIndex ) {
				buffer[offset + localIndex] = (byte)'0';
			}
			
			return offset + length;
		}
		

		public static int GetLongOctalBytes(long value, byte[] buffer, int offset, int length)
		{
			return GetOctalBytes(value, buffer, offset, length);
		}
		

		static int GetCheckSumOctalBytes(long value, byte[] buffer, int offset, int length)
		{
			TarHeader.GetOctalBytes(value, buffer, offset, length - 1);
			return offset + length;
		}
		

		static int ComputeCheckSum(byte[] buffer)
		{
			int sum = 0;
			for (int i = 0; i < buffer.Length; ++i) {
				sum += buffer[i];
			}
			return sum;
		}
		

		static int MakeCheckSum(byte[] buffer)
		{
			int sum = 0;
			for ( int i = 0; i < CHKSUMOFS; ++i )
			{
				sum += buffer[i];
			}
		
			for ( int i = 0; i < TarHeader.CHKSUMLEN; ++i)
			{
				sum += (byte)' ';
			}
		
			for (int i = CHKSUMOFS + CHKSUMLEN; i < buffer.Length; ++i) 
			{
				sum += buffer[i];
			}
			return sum;
		}
		
		static int GetCTime(System.DateTime dateTime)
		{
			return unchecked((int)((dateTime.Ticks - dateTime1970.Ticks) / timeConversionFactor));
		}
		
		static DateTime GetDateTimeFromCTime(long ticks)
		{
			DateTime result;
			
			try {
				result = new DateTime(dateTime1970.Ticks + ticks * timeConversionFactor);
			}
			catch(ArgumentOutOfRangeException) {
				result = dateTime1970;
			}
			return result;
		}

		#region Instance Fields
		string name;
		int mode;
		int userId;
		int groupId;
		long size;
		DateTime modTime;
		int checksum;
		bool isChecksumValid;
		byte typeFlag;
		string linkName;
		string magic;
		string version;
		string userName;
		string groupName;
		int devMajor;
		int devMinor;
		#endregion

		#region Class Fields
		static public int userIdAsSet;
		static public int groupIdAsSet;
		static public string userNameAsSet;
		static public string groupNameAsSet = "None";
		
		static public int defaultUserId;
		static public int defaultGroupId;
		static public string defaultGroupName = "None";
		static public string defaultUser;
		#endregion
	}
}
