

using System;
using System.Collections;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	public interface ITaggedData
	{
		short TagID { get; }

		void SetData(byte[] data, int offset, int count);

		byte[] GetData();
	}
	

	public class RawTaggedData : ITaggedData
	{
		public RawTaggedData(short tag)
		{
			tag_ = tag;
		}

		#region ITaggedData Members

		public short TagID 
		{ 
			get { return tag_; }
			set { tag_ = value; }
		}


		public void SetData(byte[] data, int offset, int count)
		{
			if( data==null )
			{
				throw new ArgumentNullException("data");
			}

			data_=new byte[count];
			Array.Copy(data, offset, data_, 0, count);
		}


		public byte[] GetData()
		{
			return data_;
		}

		#endregion


		public byte[] Data
		{
			get { return data_; }
			set { data_=value; }
		}

		#region Instance Fields

		protected short tag_;

		byte[] data_;
		#endregion
	}


	public class ExtendedUnixData : ITaggedData
	{

		[Flags]
		public enum Flags : byte
		{
	    	ModificationTime = 0x01,
			AccessTime = 0x02,
			CreateTime = 0x04,
		}
		
		#region ITaggedData Members

		public short TagID
		{ 
			get { return 0x5455; }
		}
		
		public void SetData(byte[] data, int index, int count)
		{
			using (MemoryStream ms = new MemoryStream(data, index, count, false))
			using (ZipHelperStream helperStream = new ZipHelperStream(ms))
			{
				flags_ = (Flags)helperStream.ReadByte();
				if (((flags_ & Flags.ModificationTime) != 0) && (count >= 5))
				{
					int iTime = helperStream.ReadLEInt();

					modificationTime_ = (new System.DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime() +
						new TimeSpan(0, 0, 0, iTime, 0)).ToLocalTime();
				}

				if ((flags_ & Flags.AccessTime) != 0)
				{
					int iTime = helperStream.ReadLEInt();

					lastAccessTime_ = (new System.DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime() +
						new TimeSpan(0, 0, 0, iTime, 0)).ToLocalTime();
				}
				
				if ((flags_ & Flags.CreateTime) != 0)
				{
					int iTime = helperStream.ReadLEInt();

					createTime_ = (new System.DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime() +
						new TimeSpan(0, 0, 0, iTime, 0)).ToLocalTime();
				}
			}
		}

		public byte[] GetData()
		{
			using (MemoryStream ms = new MemoryStream())
			using (ZipHelperStream helperStream = new ZipHelperStream(ms))
			{
				helperStream.IsStreamOwner = false;
				helperStream.WriteByte((byte)flags_);     
				if ( (flags_ & Flags.ModificationTime) != 0) {
					TimeSpan span = modificationTime_.ToUniversalTime() - new System.DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime();
					int seconds = (int)span.TotalSeconds;
					helperStream.WriteLEInt(seconds);
				}
				if ( (flags_ & Flags.AccessTime) != 0) {
					TimeSpan span = lastAccessTime_.ToUniversalTime() - new System.DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime();
					int seconds = (int)span.TotalSeconds;
					helperStream.WriteLEInt(seconds);
				}
				if ( (flags_ & Flags.CreateTime) != 0) {
					TimeSpan span = createTime_.ToUniversalTime() - new System.DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime();
					int seconds = (int)span.TotalSeconds;
					helperStream.WriteLEInt(seconds);
				}
				return ms.ToArray();
			}
		}

		#endregion


		public static bool IsValidValue(DateTime value)
		{
			return (( value >= new DateTime(1901, 12, 13, 20, 45, 52)) || 
					( value <= new DateTime(2038, 1, 19, 03, 14, 07) ));
		}


		public DateTime ModificationTime
		{
			get { return modificationTime_; }
			set
			{
				if ( !IsValidValue(value) ) {
					throw new ArgumentOutOfRangeException("value");
				}
				
				flags_ |= Flags.ModificationTime;
				modificationTime_=value;
			}
		}


		public DateTime AccessTime
		{
			get { return lastAccessTime_; }
			set { 
				if ( !IsValidValue(value) ) {
					throw new ArgumentOutOfRangeException("value");
				}
			
				flags_ |= Flags.AccessTime;
				lastAccessTime_=value; 
			}
		}


		public DateTime CreateTime
		{
			get { return createTime_; }
			set {
				if ( !IsValidValue(value) ) {
					throw new ArgumentOutOfRangeException("value");
				}
			
				flags_ |= Flags.CreateTime;
				createTime_=value;
			}
		}

		Flags Include
		{
			get { return flags_; }
			set { flags_ = value; }
		}

		#region Instance Fields
		Flags flags_;
		DateTime modificationTime_ = new DateTime(1970,1,1);
		DateTime lastAccessTime_ = new DateTime(1970, 1, 1);
		DateTime createTime_ = new DateTime(1970, 1, 1);
		#endregion
	}

	public class NTTaggedData : ITaggedData
	{

		public short TagID
		{ 
			get { return 10; }
		}


		public void SetData(byte[] data, int index, int count)
		{
			using (MemoryStream ms = new MemoryStream(data, index, count, false)) 
			using (ZipHelperStream helperStream = new ZipHelperStream(ms))
			{
				helperStream.ReadLEInt(); 
				while (helperStream.Position < helperStream.Length)
				{
					int ntfsTag = helperStream.ReadLEShort();
					int ntfsLength = helperStream.ReadLEShort();
					if (ntfsTag == 1)
					{
						if (ntfsLength >= 24)
						{
							long lastModificationTicks = helperStream.ReadLELong();
							lastModificationTime_ = DateTime.FromFileTime(lastModificationTicks);

							long lastAccessTicks = helperStream.ReadLELong();
							lastAccessTime_ = DateTime.FromFileTime(lastAccessTicks);

							long createTimeTicks = helperStream.ReadLELong();
							createTime_ = DateTime.FromFileTime(createTimeTicks);
						}
						break;
					}
					else
					{
						helperStream.Seek(ntfsLength, SeekOrigin.Current);
					}
				}
			}
		}

		public byte[] GetData()
		{
			using (MemoryStream ms = new MemoryStream())
			using (ZipHelperStream helperStream = new ZipHelperStream(ms))
			{
				helperStream.IsStreamOwner = false;
				helperStream.WriteLEInt(0);      
				helperStream.WriteLEShort(1);   
				helperStream.WriteLEShort(24); 
				helperStream.WriteLELong(lastModificationTime_.ToFileTime());
				helperStream.WriteLELong(lastAccessTime_.ToFileTime());
				helperStream.WriteLELong(createTime_.ToFileTime());
				return ms.ToArray();
			}
		}

		public static bool IsValidValue(DateTime value)
		{
			bool result = true;
			try
			{
				value.ToFileTimeUtc();
			}
			catch
			{
				result = false;
			}
			return result;
		}
		

		public DateTime LastModificationTime
		{
			get { return lastModificationTime_; }
			set {
				if (! IsValidValue(value))
				{
					throw new ArgumentOutOfRangeException("value");
				}
				lastModificationTime_ = value;
			}
		}


		public DateTime CreateTime
		{
			get { return createTime_; }
			set {
				if ( !IsValidValue(value)) {
					throw new ArgumentOutOfRangeException("value");
				}
				createTime_ = value;
			}
		}


		public DateTime LastAccessTime
		{
			get { return lastAccessTime_; }
			set {
				if (!IsValidValue(value)) {
					throw new ArgumentOutOfRangeException("value");
				}
				lastAccessTime_ = value; 
			}
		}

		#region Instance Fields
		DateTime lastAccessTime_ = DateTime.FromFileTime(0);
		DateTime lastModificationTime_ = DateTime.FromFileTime(0);
		DateTime createTime_ = DateTime.FromFileTime(0);
		#endregion
	}


	interface ITaggedDataFactory
	{
		ITaggedData Create(short tag, byte[] data, int offset, int count);
	}


	sealed public class ZipExtraData : IDisposable
	{
		#region Constructors

		public ZipExtraData()
		{
			Clear();
		}

		public ZipExtraData(byte[] data)
		{
			if ( data == null )
			{
				data_ = new byte[0];
			}
			else
			{
				data_ = data;
			}
		}
		#endregion

		public byte[] GetEntryData()
		{
			if ( Length > ushort.MaxValue ) {
				throw new ZipException("Data exceeds maximum length");
			}

			return (byte[])data_.Clone();
		}


		public void Clear()
		{
			if ( (data_ == null) || (data_.Length != 0) ) {
				data_ = new byte[0];
			}
		}


		public int Length
		{
			get { return data_.Length; }
		}


		public Stream GetStreamForTag(int tag)
		{
			Stream result = null;
			if ( Find(tag) ) {
				result = new MemoryStream(data_, index_, readValueLength_, false);
			}
			return result;
		}


		private ITaggedData GetData(short tag)
		{
			ITaggedData result = null;
			if (Find(tag))
			{
				result = Create(tag, data_, readValueStart_, readValueLength_);
			}
			return result;
		}

		static ITaggedData Create(short tag, byte[] data, int offset, int count)
		{
			ITaggedData result = null;
			switch ( tag )
			{
				case 0x000A:
					result = new NTTaggedData();
					break;
				case 0x5455:
					result = new ExtendedUnixData();
					break;
				default:
					result = new RawTaggedData(tag);
					break;
			}
			result.SetData(data, offset, count);
			return result;
		}
		

		public int ValueLength
		{
			get { return readValueLength_; }
		}


		public int CurrentReadIndex
		{
			get { return index_; }
		}


		public int UnreadCount
		{
			get 
			{
				if ((readValueStart_ > data_.Length) ||
					(readValueStart_ < 4) ) {
					throw new ZipException("Find must be called before calling a Read method");
				}

				return readValueStart_ + readValueLength_ - index_; 
			}
		}


		public bool Find(int headerID)
		{
			readValueStart_ = data_.Length;
			readValueLength_ = 0;
			index_ = 0;

			int localLength = readValueStart_;
			int localTag = headerID - 1;


			while ( (localTag != headerID) && (index_ < data_.Length - 3) ) {
				localTag = ReadShortInternal();
				localLength = ReadShortInternal();
				if ( localTag != headerID ) {
					index_ += localLength;
				}
			}

			bool result = (localTag == headerID) && ((index_ + localLength) <= data_.Length);

			if ( result ) {
				readValueStart_ = index_;
				readValueLength_ = localLength;
			}

			return result;
		}


		public void AddEntry(ITaggedData taggedData)
		{
			if (taggedData == null)
			{
				throw new ArgumentNullException("taggedData");
			}
			AddEntry(taggedData.TagID, taggedData.GetData());
		}


		public void AddEntry(int headerID, byte[] fieldData)
		{
			if ( (headerID > ushort.MaxValue) || (headerID < 0)) {
				throw new ArgumentOutOfRangeException("headerID");
			}

			int addLength = (fieldData == null) ? 0 : fieldData.Length;

			if ( addLength > ushort.MaxValue ) {
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("fieldData");
#else
				throw new ArgumentOutOfRangeException("fieldData", "exceeds maximum length");
#endif
			}


			int newLength = data_.Length + addLength + 4;

			if ( Find(headerID) )
			{
				newLength -= (ValueLength + 4);
			}

			if ( newLength > ushort.MaxValue ) {
				throw new ZipException("Data exceeds maximum length");
			}
			
			Delete(headerID);

			byte[] newData = new byte[newLength];
			data_.CopyTo(newData, 0);
			int index = data_.Length;
			data_ = newData;
			SetShort(ref index, headerID);
			SetShort(ref index, addLength);
			if ( fieldData != null ) {
				fieldData.CopyTo(newData, index);
			}
		}

		public void StartNewEntry()
		{
			newEntry_ = new MemoryStream();
		}

		public void AddNewEntry(int headerID)
		{
			byte[] newData = newEntry_.ToArray();
			newEntry_ = null;
			AddEntry(headerID, newData);
		}


		public void AddData(byte data)
		{
			newEntry_.WriteByte(data);
		}


		public void AddData(byte[] data)
		{
			if ( data == null ) {
				throw new ArgumentNullException("data");
			}

			newEntry_.Write(data, 0, data.Length);
		}


		public void AddLeShort(int toAdd)
		{
			unchecked {
				newEntry_.WriteByte(( byte )toAdd);
				newEntry_.WriteByte(( byte )(toAdd >> 8));
			}
		}


		public void AddLeInt(int toAdd)
		{
			unchecked {
				AddLeShort(( short )toAdd);
				AddLeShort(( short )(toAdd >> 16));
			}
		}


		public void AddLeLong(long toAdd)
		{
			unchecked {
				AddLeInt(( int )(toAdd & 0xffffffff));
				AddLeInt(( int )(toAdd >> 32));
			}
		}


		public bool Delete(int headerID)
		{
			bool result = false;

			if ( Find(headerID) ) {
				result = true;
				int trueStart = readValueStart_ - 4;

				byte[] newData = new byte[data_.Length - (ValueLength + 4)];
				Array.Copy(data_, 0, newData, 0, trueStart);

				int trueEnd = trueStart + ValueLength + 4;
				Array.Copy(data_, trueEnd, newData, trueStart, data_.Length - trueEnd);
				data_ = newData;
			}
			return result;
		}

		#region Reading Support

		public long ReadLong()
		{
			ReadCheck(8);
			return (ReadInt() & 0xffffffff) | ((( long )ReadInt()) << 32);
		}


		public int ReadInt()
		{
			ReadCheck(4);

			int result = data_[index_] + (data_[index_ + 1] << 8) + 
				(data_[index_ + 2] << 16) + (data_[index_ + 3] << 24);
			index_ += 4;
			return result;
		}

	
		public int ReadShort()
		{
			ReadCheck(2);
			int result = data_[index_] + (data_[index_ + 1] << 8);
			index_ += 2;
			return result;
		}


		public int ReadByte()
		{
			int result = -1;
			if ( (index_ < data_.Length) && (readValueStart_ + readValueLength_ > index_) ) {
				result = data_[index_];
				index_ += 1;
			}
			return result;
		}


		public void Skip(int amount)
		{
			ReadCheck(amount);
			index_ += amount;
		}

		void ReadCheck(int length)
		{
			if ((readValueStart_ > data_.Length) ||
				(readValueStart_ < 4) ) {
				throw new ZipException("Find must be called before calling a Read method");
			}

			if (index_ > readValueStart_ + readValueLength_ - length ) {
				throw new ZipException("End of extra data");
			}
		}

		int ReadShortInternal()
		{
			if ( index_ > data_.Length - 2) {
				throw new ZipException("End of extra data");
			}

			int result = data_[index_] + (data_[index_ + 1] << 8);
			index_ += 2;
			return result;
		}

		void SetShort(ref int index, int source)
		{
			data_[index] = (byte)source;
			data_[index + 1] = (byte)(source >> 8);
			index += 2;
		}

		#endregion

		#region IDisposable Members


		public void Dispose()
		{
			if ( newEntry_ != null ) {
				newEntry_.Close();
			}
		}

		#endregion

		#region Instance Fields
		int index_;
		int readValueStart_;
		int readValueLength_;

		MemoryStream newEntry_;
		byte[] data_;
		#endregion
	}
}
