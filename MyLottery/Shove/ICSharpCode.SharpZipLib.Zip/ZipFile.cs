using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Globalization;

#if !NETCF_1_0
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.Encryption;
#endif

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using ICSharpCode.SharpZipLib.Zip.Compression;

namespace ICSharpCode.SharpZipLib.Zip 
{
	#region Keys Required Event Args
	public class KeysRequiredEventArgs : EventArgs
	{
		#region Constructors
		public KeysRequiredEventArgs(string name)
		{
			fileName = name;
		}
	
		public KeysRequiredEventArgs(string name, byte[] keyValue)
		{
			fileName = name;
			key = keyValue;
		}

		#endregion
		#region Properties

		public string FileName
		{
			get { return fileName; }
		}
	

		public byte[] Key
		{
			get { return key; }
			set { key = value; }
		}
		#endregion
		
		#region Instance Fields
		string fileName;
		byte[] key;
		#endregion
	}
	#endregion
	
	#region Test Definitions

	public enum TestStrategy
	{
		FindFirstError,
		FindAllErrors,
	}

	public enum TestOperation
	{
		Initialising,
		EntryHeader,
		EntryData,
		EntryComplete,
		MiscellaneousTests,
		Complete
	}


	public class TestStatus
	{
		#region Constructors
		public TestStatus(ZipFile file)
		{
			file_ = file;
		}
		#endregion
		
		#region Properties


		public TestOperation Operation
		{
			get { return operation_; }
		}


		public ZipFile File
		{
			get { return file_; }
		}


		public ZipEntry Entry
		{
			get { return entry_; }
		}

		public int ErrorCount
		{
			get { return errorCount_; }
		}


		public long BytesTested
		{
			get { return bytesTested_; }
		}


		public bool EntryValid
		{
			get { return entryValid_; }
		}
		#endregion
		
		#region Internal API
		internal void AddError()
		{
			errorCount_++;
			entryValid_ = false;
		}

		internal void SetOperation(TestOperation operation)
		{
			operation_ = operation;
		}

		internal void SetEntry(ZipEntry entry)
		{
			entry_ = entry;
			entryValid_ = true;
			bytesTested_ = 0;
		}

		internal void SetBytesTested(long value)
		{
			bytesTested_ = value;
		}
		#endregion
		
		#region Instance Fields
		ZipFile file_;
		ZipEntry entry_;
		bool entryValid_;
		int errorCount_;
		long bytesTested_;
		TestOperation operation_;
		#endregion
	}


	public delegate void ZipTestResultHandler(TestStatus status, string message);
	#endregion
	
	#region Update Definitions

	public enum FileUpdateMode
	{
		Safe,
		Direct
	}
	#endregion
	
	#region ZipFile Class
	public class ZipFile : IEnumerable, IDisposable
	{
		#region KeyHandling

		public delegate void KeysRequiredEventHandler(
			object sender,
			KeysRequiredEventArgs e
		);

	
		public KeysRequiredEventHandler KeysRequired;

		void OnKeysRequired(string fileName)
		{
			if (KeysRequired != null) {
				KeysRequiredEventArgs krea = new KeysRequiredEventArgs(fileName, key);
				KeysRequired(this, krea);
				key = krea.Key;
			}
		}
		
		
		byte[] Key
		{
			get { return key; }
			set { key = value; }
		}
		
#if !NETCF_1_0				
		
		public string Password
		{
			set 
			{
				if ( (value == null) || (value.Length == 0) ) {
					key = null;
				}
				else {
					key = PkzipClassic.GenerateKeys(ZipConstants.ConvertToArray(value));
				}
			}
		}
#endif

	
		bool HaveKeys
		{
			get { return key != null; }
		}
		#endregion
		
		#region Constructors

		public ZipFile(string name)
		{
			if ( name == null ) {
				throw new ArgumentNullException("name");
			}
			
			name_ = name;

			baseStream_ = File.OpenRead(name);
			isStreamOwner = true;
			
			try {
				ReadEntries();
			}
			catch {
				DisposeInternal(true);
				throw;
			}
		}
		
		
		public ZipFile(FileStream file)
		{
			if ( file == null ) {
				throw new ArgumentNullException("file");
			}

			if ( !file.CanSeek ) {
				throw new ArgumentException("Stream is not seekable", "file");
			}

			baseStream_  = file;
			name_ = file.Name;
			isStreamOwner = true;
			
			try {
				ReadEntries();
			}
			catch {
				DisposeInternal(true);
				throw;
			}
		}
		
	
		public ZipFile(Stream stream)
		{
			if ( stream == null ) {
				throw new ArgumentNullException("stream");
			}

			if ( !stream.CanSeek ) {
				throw new ArgumentException("Stream is not seekable", "stream");
			}

			baseStream_  = stream;
			isStreamOwner = true;
		
			if ( baseStream_.Length > 0 ) {
				try {
					ReadEntries();
				}
				catch {
					DisposeInternal(true);
					throw;
				}
			} else {
				entries_ = new ZipEntry[0];
				isNewArchive_ = true;
			}
		}

	
		internal ZipFile()
		{
			entries_ = new ZipEntry[0];
			isNewArchive_ = true;
		}
		
		#endregion
		
		#region Destructors and Closing
		
		~ZipFile()
		{
			Dispose(false);
		}
		
		
		public void Close()
		{
			DisposeInternal(true);
			GC.SuppressFinalize(this);
		}
		
		#endregion
		
		#region Creators
		
		public static ZipFile Create(string fileName)
		{
			if ( fileName == null ) {
				throw new ArgumentNullException("fileName");
			}

			FileStream fs = File.Create(fileName);
			
			ZipFile result = new ZipFile();
			result.name_ = fileName;
			result.baseStream_ = fs;
			result.isStreamOwner = true;
			return result;
		}
		
	
		public static ZipFile Create(Stream outStream)
		{
			if ( outStream == null ) {
				throw new ArgumentNullException("outStream");
			}

			if ( !outStream.CanWrite ) {
				throw new ArgumentException("Stream is not writeable", "outStream");
			}

			if ( !outStream.CanSeek ) {
				throw new ArgumentException("Stream is not seekable", "outStream");
			}

			ZipFile result = new ZipFile();
			result.baseStream_ = outStream;
			return result;
		}
		
		#endregion
		
		#region Properties
		
		public bool IsStreamOwner
		{
			get { return isStreamOwner; }
			set { isStreamOwner = value; }
		}
		
	
		public bool IsEmbeddedArchive
		{
			get { return offsetOfFirstEntry > 0; }
		}


		public bool IsNewArchive
		{
			get { return isNewArchive_; }
		}

		
		public string ZipFileComment 
		{
			get { return comment_; }
		}
		
		public string Name 
		{
			get { return name_; }
		}
		

		[Obsolete("Use the Count property instead")]
		public int Size 
		{
			get 
			{
				return entries_.Length;
			}
		}
		

		public long Count 
		{
			get 
			{
				return entries_.Length;
			}
		}
		

		[System.Runtime.CompilerServices.IndexerNameAttribute("EntryByIndex")]
		public ZipEntry this[int index] 
		{
			get {
				return (ZipEntry) entries_[index].Clone();	
			}
		}
		
		#endregion
		
		#region Input Handling

		public IEnumerator GetEnumerator()
		{
			if (isDisposed_) {
				throw new ObjectDisposedException("ZipFile");
			}

			return new ZipEntryEnumerator(entries_);
		}
		

		public int FindEntry(string name, bool ignoreCase)
		{
			if (isDisposed_) {
				throw new ObjectDisposedException("ZipFile");
			}			
			
			for (int i = 0; i < entries_.Length; i++) {
				if (string.Compare(name, entries_[i].Name, ignoreCase, CultureInfo.InvariantCulture) == 0) {
					return i;
				}
			}
			return -1;
		}
		

		public ZipEntry GetEntry(string name)
		{
			if (isDisposed_) {
				throw new ObjectDisposedException("ZipFile");
			}			
						
			int index = FindEntry(name, true);
			return (index >= 0) ? (ZipEntry) entries_[index].Clone() : null;
		}


		public Stream GetInputStream(ZipEntry entry)
		{
			if ( entry == null ) {
				throw new ArgumentNullException("entry");
			}

			if ( isDisposed_ ) {
				throw new ObjectDisposedException("ZipFile");
			}
			
			long index = entry.ZipFileIndex;
			if ( (index < 0) || (index >= entries_.Length) || (entries_[index].Name != entry.Name) ) {
				index = FindEntry(entry.Name, true);
				if (index < 0) {
					throw new ZipException("Entry cannot be found");
				}
			}
			return GetInputStream(index);			
		}
		

		public Stream GetInputStream(long entryIndex)
		{
			if ( isDisposed_ ) {
				throw new ObjectDisposedException("ZipFile");
			}
			
			long start = LocateEntry(entries_[entryIndex]);
			CompressionMethod method = entries_[entryIndex].CompressionMethod;
			Stream result = new PartialInputStream(this, start, entries_[entryIndex].CompressedSize);

			if (entries_[entryIndex].IsCrypted == true) {
#if NETCF_1_0
				throw new ZipException("decryption not supported for Compact Framework 1.0");
#else
				result = CreateAndInitDecryptionStream(result, entries_[entryIndex]);
				if (result == null) {
					throw new ZipException("Unable to decrypt this entry");
				}
#endif				
			}

			switch (method) {
				case CompressionMethod.Stored:
					break;

				case CompressionMethod.Deflated:
					result = new InflaterInputStream(result, new Inflater(true));
					break;

				default:
					throw new ZipException("Unsupported compression method " + method);
			}

			return result;
		}

		#endregion
		
		#region Archive Testing

		public bool TestArchive(bool testData)
		{
			return TestArchive(testData, TestStrategy.FindFirstError, null);
		}
		

		public bool TestArchive(bool testData, TestStrategy strategy, ZipTestResultHandler resultHandler)
		{
			if (isDisposed_) {
				throw new ObjectDisposedException("ZipFile");
			}
			
			TestStatus status = new TestStatus(this);

			if ( resultHandler != null ) {
				resultHandler(status, null);
			}

			HeaderTest test = testData ? (HeaderTest.Header | HeaderTest.Extract) : HeaderTest.Header;

			bool testing = true;

			try {
				int entryIndex = 0;

				while ( testing && (entryIndex < Count) ) {
					if ( resultHandler != null ) {
						status.SetEntry(this[entryIndex]);
						status.SetOperation(TestOperation.EntryHeader);
						resultHandler(status, null);
					}

					try	{
						TestLocalHeader(this[entryIndex], test);
					}
					catch(ZipException ex) {
						status.AddError();

						if ( resultHandler != null ) {
							resultHandler(status,
								string.Format("Exception during test - '{0}'", ex.Message));
						}

						if ( strategy == TestStrategy.FindFirstError ) {
							testing = false; 
						}
					}

					if ( testing && testData && this[entryIndex].IsFile ) {
						if ( resultHandler != null ) {
							status.SetOperation(TestOperation.EntryData);
							resultHandler(status, null);
						}

                        Crc32 crc = new Crc32();

                        using (Stream entryStream = this.GetInputStream(this[entryIndex]))
                        {

                            byte[] buffer = new byte[4096];
                            long totalBytes = 0;
                            int bytesRead;
                            while ((bytesRead = entryStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                crc.Update(buffer, 0, bytesRead);

                                if (resultHandler != null)
                                {
                                    totalBytes += bytesRead;
                                    status.SetBytesTested(totalBytes);
                                    resultHandler(status, null);
                                }
                            }
                        }

						if (this[entryIndex].Crc != crc.Value) {
							status.AddError();
							
							if ( resultHandler != null ) {
								resultHandler(status, "CRC mismatch");
							}

							if ( strategy == TestStrategy.FindFirstError ) {
								testing = false;
							}
						}

						if (( this[entryIndex].Flags & (int)GeneralBitFlags.Descriptor) != 0 ) {
							ZipHelperStream helper = new ZipHelperStream(baseStream_);
							DescriptorData data = new DescriptorData();
							helper.ReadDataDescriptor(this[entryIndex].LocalHeaderRequiresZip64, data);
							if (this[entryIndex].Crc != data.Crc) {
								status.AddError();
							}

							if (this[entryIndex].CompressedSize != data.CompressedSize) {
								status.AddError();
							}

							if (this[entryIndex].Size != data.Size) {
								status.AddError();
							}
						}
					}

					if ( resultHandler != null ) {
						status.SetOperation(TestOperation.EntryComplete);
						resultHandler(status, null);
					}

					entryIndex += 1;
				}

				if ( resultHandler != null ) {
					status.SetOperation(TestOperation.MiscellaneousTests);
					resultHandler(status, null);
				}
			}
			catch (Exception ex) {
				status.AddError();

				if ( resultHandler != null ) {
					resultHandler(status, string.Format("Exception during test - '{0}'", ex.Message));
				}
			}

			if ( resultHandler != null ) {
				status.SetOperation(TestOperation.Complete);
				status.SetEntry(null);
				resultHandler(status, null);
			}

			return (status.ErrorCount == 0);
		}

		[Flags]
		enum HeaderTest
		{
			Extract = 0x01, 
			Header  = 0x02,     
		}
	

		long TestLocalHeader(ZipEntry entry, HeaderTest tests)
		{
			lock(baseStream_) 
			{
				bool testHeader = (tests & HeaderTest.Header) != 0;
				bool testData = (tests & HeaderTest.Extract) != 0;

				baseStream_.Seek(offsetOfFirstEntry + entry.Offset, SeekOrigin.Begin);
				if ((int)ReadLEUint() != ZipConstants.LocalHeaderSignature) {
					throw new ZipException(string.Format("Wrong local header signature @{0:X}", offsetOfFirstEntry + entry.Offset));
				}

				short extractVersion = ( short )ReadLEUshort();
				short localFlags = ( short )ReadLEUshort();
				short compressionMethod = ( short )ReadLEUshort();
				short fileTime = ( short )ReadLEUshort();
				short fileDate = ( short )ReadLEUshort();
				uint crcValue = ReadLEUint();
				long compressedSize = ReadLEUint();
				long size = ReadLEUint();
				int storedNameLength = ReadLEUshort();
				int extraDataLength = ReadLEUshort();

				byte[] nameData = new byte[storedNameLength];
				StreamUtils.ReadFully(baseStream_, nameData);

				byte[] extraData = new byte[extraDataLength];
				StreamUtils.ReadFully(baseStream_, extraData);

				ZipExtraData localExtraData = new ZipExtraData(extraData);

				if (localExtraData.Find(1))
				{
					if (extractVersion < ZipConstants.VersionZip64)
					{
						throw new ZipException(
							string.Format("Extra data contains Zip64 information but version {0}.{1} is not high enough",
							extractVersion / 10, extractVersion % 10));
					}

					if (((uint)size != uint.MaxValue) && ((uint)compressedSize != uint.MaxValue))
					{
						throw new ZipException("Entry sizes not correct for Zip64");
					}

					size = localExtraData.ReadLong();
					compressedSize = localExtraData.ReadLong();

                    if ((localFlags & (int)GeneralBitFlags.Descriptor) != 0)
                    {
                        if ( (size != -1) && (size != entry.Size)) {
                            throw new ZipException("Size invalid for descriptor");
                        }

                        if ((compressedSize != -1) && (compressedSize != entry.CompressedSize)) {
                            throw new ZipException("Compressed size invalid for descriptor");
                        }
                    }
                }
				else
				{
					if ((extractVersion >= ZipConstants.VersionZip64) &&
						(((uint)size == uint.MaxValue) || ((uint)compressedSize == uint.MaxValue)))
					{
						throw new ZipException("Required Zip64 extended information missing");
					}
				}

				if ( testData ) {
					if ( entry.IsFile ) {
						if ( !entry.IsCompressionMethodSupported() ) {
							throw new ZipException("Compression method not supported");
						}

						if ( (extractVersion > ZipConstants.VersionMadeBy)
							|| ((extractVersion > 20) && (extractVersion < ZipConstants.VersionZip64)) ) {
							throw new ZipException(string.Format("Version required to extract this entry not supported ({0})", extractVersion));
						}

						if ( (localFlags & ( int )(GeneralBitFlags.Patched | GeneralBitFlags.StrongEncryption | GeneralBitFlags.EnhancedCompress | GeneralBitFlags.HeaderMasked)) != 0 ) {
							throw new ZipException("The library does not support the zip version required to extract this entry");
						}
					}
				}

                if (testHeader)
                {
                    if ((extractVersion <= 63) &&	
                        (extractVersion != 10) &&
                        (extractVersion != 11) &&
                        (extractVersion != 20) &&
                        (extractVersion != 21) &&
                        (extractVersion != 25) &&
                        (extractVersion != 27) &&
                        (extractVersion != 45) &&
                        (extractVersion != 46) &&
                        (extractVersion != 50) &&
                        (extractVersion != 51) &&
                        (extractVersion != 52) &&
                        (extractVersion != 61) &&
                        (extractVersion != 62) &&
                        (extractVersion != 63)
                        )
                    {
                        throw new ZipException(string.Format("Version required to extract this entry is invalid ({0})", extractVersion));
                    }


                    if ((localFlags & (int)(GeneralBitFlags.ReservedPKware4 | GeneralBitFlags.ReservedPkware14 | GeneralBitFlags.ReservedPkware15)) != 0)
                    {
                        throw new ZipException("Reserved bit flags cannot be set.");
                    }


                    if (((localFlags & (int)GeneralBitFlags.Encrypted) != 0) && (extractVersion < 20))
                    {
                        throw new ZipException(string.Format("Version required to extract this entry is too low for encryption ({0})", extractVersion));
                    }

                    if ((localFlags & (int)GeneralBitFlags.StrongEncryption) != 0)
                    {
                        if ((localFlags & (int)GeneralBitFlags.Encrypted) == 0)
                        {
                            throw new ZipException("Strong encryption flag set but encryption flag is not set");
                        }

                        if (extractVersion < 50)
                        {
                            throw new ZipException(string.Format("Version required to extract this entry is too low for encryption ({0})", extractVersion));
                        }
                    }

                    if (((localFlags & (int)GeneralBitFlags.Patched) != 0) && (extractVersion < 27))
                    {
                        throw new ZipException(string.Format("Patched data requires higher version than ({0})", extractVersion));
                    }

                    if (localFlags != entry.Flags)
                    {
                        throw new ZipException("Central header/local header flags mismatch");
                    }

                    if (entry.CompressionMethod != (CompressionMethod)compressionMethod)
                    {
                        throw new ZipException("Central header/local header compression method mismatch");
                    }

                    if (entry.Version != extractVersion)
                    {
                        throw new ZipException("Extract version mismatch");
                    }

                    if ((localFlags & (int)GeneralBitFlags.StrongEncryption) != 0)
                    {
                        if (extractVersion < 62)
                        {
                            throw new ZipException("Strong encryption flag set but version not high enough");
                        }
                    }

                    if ((localFlags & (int)GeneralBitFlags.HeaderMasked) != 0)
                    {
                        if ((fileTime != 0) || (fileDate != 0))
                        {
                            throw new ZipException("Header masked set but date/time values non-zero");
                        }
                    }

                    if ((localFlags & (int)GeneralBitFlags.Descriptor) == 0)
                    {
                        if (crcValue != (uint)entry.Crc)
                        {
                            throw new ZipException("Central header/local header crc mismatch");
                        }
                    }

                    if ((size == 0) && (compressedSize == 0))
                    {
                        if (crcValue != 0)
                        {
                            throw new ZipException("Invalid CRC for empty entry");
                        }
                    }


                    if (entry.Name.Length > storedNameLength)
                    {
                        throw new ZipException("File name length mismatch");
                    }

                    string localName = ZipConstants.ConvertToStringExt(localFlags, nameData);

                    if (localName != entry.Name)
                    {
                        throw new ZipException("Central header and local header file name mismatch");
                    }

                    if (entry.IsDirectory)
                    {
                        if (size > 0)
                        {
                            throw new ZipException("Directory cannot have size");
                        }

                        if (entry.IsCrypted)
                        {
                            if (compressedSize > ZipConstants.CryptoHeaderSize + 2)
                            {
                                throw new ZipException("Directory compressed size invalid");
                            }
                        }
                        else if (compressedSize > 2)
                        {
                            throw new ZipException("Directory compressed size invalid");
                        }
                    }

                    if (!ZipNameTransform.IsValidName(localName, true))
                    {
                        throw new ZipException("Name is invalid");
                    }
                }

				if (((localFlags & (int)GeneralBitFlags.Descriptor) == 0) ||
					((size > 0) || (compressedSize > 0))) {

					if (size != entry.Size) {
						throw new ZipException(
							string.Format("Size mismatch between central header({0}) and local header({1})",
								entry.Size, size));
					}

					if (compressedSize != entry.CompressedSize) {
						throw new ZipException(
							string.Format("Compressed size mismatch between central header({0}) and local header({1})",
							entry.CompressedSize, compressedSize));
					}
				}

				int extraLength = storedNameLength + extraDataLength;
				return offsetOfFirstEntry + entry.Offset + ZipConstants.LocalHeaderBaseSize + extraLength;
			}
		}
		
		#endregion
		
		#region Updating

		const int DefaultBufferSize = 4096;

		enum UpdateCommand
		{
			Copy,      
			Modify,    
			Add,       
		}

		#region Properties

		public INameTransform NameTransform
		{
			get {
				return updateEntryFactory_.NameTransform;
			}

			set {
				updateEntryFactory_.NameTransform = value;
			}
		}


		public IEntryFactory EntryFactory
		{
			get {
				return updateEntryFactory_;
			}

			set {
				if (value == null) {
					updateEntryFactory_ = new ZipEntryFactory();
				}
				else {
					updateEntryFactory_ = value;
				}
			}
		}


		public int BufferSize
		{
			get { return bufferSize_; }
			set {
				if ( value < 1024 ) {
#if NETCF_1_0					
					throw new ArgumentOutOfRangeException("value");
#else
					throw new ArgumentOutOfRangeException("value", "cannot be below 1024");
#endif					
				}

				if ( bufferSize_ != value ) {
					bufferSize_ = value;
					copyBuffer_ = null;
				}
			}
		}

		public bool IsUpdating
		{
			get { return updates_ != null; }
		}

		public UseZip64 UseZip64
		{
			get { return useZip64_; }
			set { useZip64_ = value; }
		}

		#endregion
		

		
		#region Deferred Updating

		public void BeginUpdate(IArchiveStorage archiveStorage, IDynamicDataSource dataSource)
		{
			if ( archiveStorage == null ) {
				throw new ArgumentNullException("archiveStorage");
			}

			if ( dataSource == null ) {
				throw new ArgumentNullException("dataSource");
			}
			
			if ( isDisposed_ ) {
				throw new ObjectDisposedException("ZipFile");
			}

			if ( IsEmbeddedArchive ) {
				throw new ZipException ("Cannot update embedded/SFX archives");
			}

			archiveStorage_ = archiveStorage;
			updateDataSource_ = dataSource;



			updateIndex_ = new Hashtable();

			updates_ = new ArrayList(entries_.Length);
			foreach(ZipEntry entry in entries_) {
				int index = updates_.Add(new ZipUpdate(entry));
				updateIndex_.Add(entry.Name, index);
			}

			updateCount_ = updates_.Count;

			contentsEdited_ = false;
			commentEdited_ = false;
			newComment_ = null;
		}


		public void BeginUpdate(IArchiveStorage archiveStorage)
		{
			BeginUpdate(archiveStorage, new DynamicDiskDataSource());
		}
		

		public void BeginUpdate()
		{
			if ( Name == null ) {
				BeginUpdate(new MemoryArchiveStorage(), new DynamicDiskDataSource());
			}
			else {
				BeginUpdate(new DiskArchiveStorage(this), new DynamicDiskDataSource());
			}
		}

		public void CommitUpdate()
		{
			if ( isDisposed_ ) {
				throw new ObjectDisposedException("ZipFile");
			}
			
			CheckUpdating();

			try {
				updateIndex_.Clear();
				updateIndex_=null;

				if( contentsEdited_ ) {
					RunUpdates();
				}
				else if( commentEdited_ ) {
					UpdateCommentOnly();
				}
				else {
					if( entries_.Length==0 ) {
						byte[] theComment=(newComment_!=null)?newComment_.RawComment:ZipConstants.ConvertToArray(comment_);
						using( ZipHelperStream zhs=new ZipHelperStream(baseStream_) ) {
							zhs.WriteEndOfCentralDirectory(0, 0, 0, theComment);
						}
					}
				}

			}
			finally {
				PostUpdateCleanup();
			}
		}

		public void AbortUpdate()
		{
			PostUpdateCleanup();
		}


		public void SetComment(string comment)
		{
			if ( isDisposed_ ) {
				throw new ObjectDisposedException("ZipFile");
			}

			CheckUpdating();

			newComment_ = new ZipString(comment);

			if ( newComment_.RawLength  > 0xffff ) {
				newComment_ = null;
				throw new ZipException("Comment length exceeds maximum - 65535");
			}

			commentEdited_ = true;
		}

		#endregion
		
		#region Adding Entries

		void AddUpdate(ZipUpdate update)
		{
			contentsEdited_ = true;

			int index = FindExistingUpdate(update.Entry.Name);

			if (index >= 0) {
				if ( updates_[index] == null ) {
					updateCount_ += 1;
				}

				updates_[index] = update;
			}
			else {
				index = updates_.Add(update);
				updateCount_ += 1;
				updateIndex_.Add(update.Entry.Name, index);
			}
		}


		public void Add(string fileName, CompressionMethod compressionMethod, bool useUnicodeText )
		{
			if (fileName == null) {
				throw new ArgumentNullException("fileName");
			}

			if ( isDisposed_ ) {
				throw new ObjectDisposedException("ZipFile");
			}

			if (!ZipEntry.IsCompressionMethodSupported(compressionMethod)) {
				throw new ArgumentOutOfRangeException("compressionMethod");
			}

			CheckUpdating();
			contentsEdited_ = true;

			ZipEntry entry = EntryFactory.MakeFileEntry(fileName);
			entry.IsUnicodeText = useUnicodeText;
			entry.CompressionMethod = compressionMethod;

			AddUpdate(new ZipUpdate(fileName, entry));
		}


		public void Add(string fileName, CompressionMethod compressionMethod)
		{
			if ( fileName == null ) {
				throw new ArgumentNullException("fileName");
			}

			if ( !ZipEntry.IsCompressionMethodSupported(compressionMethod) ) {
				throw new ArgumentOutOfRangeException("compressionMethod");
			}

			CheckUpdating();
			contentsEdited_ = true;

			ZipEntry entry = EntryFactory.MakeFileEntry(fileName);
			entry.CompressionMethod = compressionMethod;
			AddUpdate(new ZipUpdate(fileName, entry));
		}


		public void Add(string fileName)
		{
			if ( fileName == null ) {
				throw new ArgumentNullException("fileName");
			}

			CheckUpdating();
			AddUpdate(new ZipUpdate(fileName, EntryFactory.MakeFileEntry(fileName)));
		}


		public void Add(string fileName, string entryName)
		{
			if (fileName == null) {
				throw new ArgumentNullException("fileName");
			}

			if ( entryName == null ) {
				throw new ArgumentNullException("entryName");
			}
			
			CheckUpdating();
			AddUpdate(new ZipUpdate(fileName, EntryFactory.MakeFileEntry(entryName)));
		}



		public void Add(IStaticDataSource dataSource, string entryName)
		{
			if ( dataSource == null ) {
				throw new ArgumentNullException("dataSource");
			}

			if ( entryName == null ) {
				throw new ArgumentNullException("entryName");
			}

			CheckUpdating();
			AddUpdate(new ZipUpdate(dataSource, EntryFactory.MakeFileEntry(entryName, false)));
		}


		public void Add(IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod)
		{
			if ( dataSource == null ) {
				throw new ArgumentNullException("dataSource");
			}

			if ( entryName == null ) {
				throw new ArgumentNullException("entryName");
			}

			CheckUpdating();

			ZipEntry entry = EntryFactory.MakeFileEntry(entryName, false);
			entry.CompressionMethod = compressionMethod;

			AddUpdate(new ZipUpdate(dataSource, entry));
		}


		public void Add(IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod, bool useUnicodeText)
		{
			if (dataSource == null) {
				throw new ArgumentNullException("dataSource");
			}

			if ( entryName == null ) {
				throw new ArgumentNullException("entryName");
			}

			CheckUpdating();

			ZipEntry entry = EntryFactory.MakeFileEntry(entryName, false);
			entry.IsUnicodeText = useUnicodeText;
			entry.CompressionMethod = compressionMethod;

			AddUpdate(new ZipUpdate(dataSource, entry));
		}


		public void Add(ZipEntry entry)
		{
			if ( entry == null ) {
				throw new ArgumentNullException("entry");
			}

			CheckUpdating();

			if ( (entry.Size != 0) || (entry.CompressedSize != 0) ) {
				throw new ZipException("Entry cannot have any data");
			}

			AddUpdate(new ZipUpdate(UpdateCommand.Add, entry));
		}


		public void AddDirectory(string directoryName)
		{
			if ( directoryName == null ) {
				throw new ArgumentNullException("directoryName");
			}

			CheckUpdating();

			ZipEntry dirEntry = EntryFactory.MakeDirectoryEntry(directoryName);
			AddUpdate(new ZipUpdate(UpdateCommand.Add, dirEntry));
		}

		#endregion
		

		#region Deleting Entries

		public bool Delete(string fileName)
		{
			if ( fileName == null ) {
				throw new ArgumentNullException("fileName");
			}
			
			CheckUpdating();

			bool result = false;
			int index = FindExistingUpdate(fileName);
			if ( (index >= 0) && (updates_[index] != null) ) {
				result = true;
				contentsEdited_ = true;
				updates_[index] = null;
				updateCount_ -= 1;
			}
			else {
				throw new ZipException("Cannot find entry to delete");
			}
			return result;
		}


		public void Delete(ZipEntry entry)
		{
			if ( entry == null ) {
				throw new ArgumentNullException("entry");
			}
			
			CheckUpdating();

			int index = FindExistingUpdate(entry);
			if ( index >= 0 ) {
				contentsEdited_ = true;
				updates_[index] = null;
				updateCount_ -= 1;
			}
			else {
				throw new ZipException("Cannot find entry to delete");
			}
		}

		#endregion
		
		#region Update Support
		#region Writing Values/Headers
		void WriteLEShort(int value)
		{
			baseStream_.WriteByte(( byte )(value & 0xff));
			baseStream_.WriteByte(( byte )((value >> 8) & 0xff));
		}


		void WriteLEUshort(ushort value)
		{
			baseStream_.WriteByte(( byte )(value & 0xff));
			baseStream_.WriteByte(( byte )(value >> 8));
		}

		void WriteLEInt(int value)
		{
			WriteLEShort(value & 0xffff);
			WriteLEShort(value >> 16);
		}

		void WriteLEUint(uint value)
		{
			WriteLEUshort((ushort)(value & 0xffff));
			WriteLEUshort((ushort)(value >> 16));
		}


		void WriteLeLong(long value)
		{
			WriteLEInt(( int )(value & 0xffffffff));
			WriteLEInt(( int )(value >> 32));
		}

		void WriteLEUlong(ulong value)
		{
			WriteLEUint(( uint )(value & 0xffffffff));
			WriteLEUint(( uint )(value >> 32));
		}

		void WriteLocalEntryHeader(ZipUpdate update)
		{
			ZipEntry entry = update.OutEntry;

			entry.Offset = baseStream_.Position;

			if (update.Command != UpdateCommand.Copy) {
				if (entry.CompressionMethod == CompressionMethod.Deflated) {
					if (entry.Size == 0) {
						entry.CompressedSize = entry.Size;
						entry.Crc = 0;
						entry.CompressionMethod = CompressionMethod.Stored;
					}
				}
				else if (entry.CompressionMethod == CompressionMethod.Stored) {
					entry.Flags &= ~(int)GeneralBitFlags.Descriptor;
				}

				if (HaveKeys) {
					entry.IsCrypted = true;
					if (entry.Crc < 0) {
						entry.Flags |= (int)GeneralBitFlags.Descriptor;
					}
				}
				else {
					entry.IsCrypted = false;
				}

				switch (useZip64_) {
					case UseZip64.Dynamic:
						if (entry.Size < 0) {
							entry.ForceZip64();
						}
						break;

					case UseZip64.On:
						entry.ForceZip64();
						break;

					case UseZip64.Off:
						break;
				}
			}

			WriteLEInt(ZipConstants.LocalHeaderSignature);

			WriteLEShort(entry.Version);
			WriteLEShort(entry.Flags);

			WriteLEShort((byte)entry.CompressionMethod);
			WriteLEInt(( int )entry.DosTime);

			if ( !entry.HasCrc ) {
				update.CrcPatchOffset = baseStream_.Position;
				WriteLEInt(( int )0);
			}
			else {
				WriteLEInt(unchecked(( int )entry.Crc));
			}

			if (entry.LocalHeaderRequiresZip64) {
				WriteLEInt(-1);
				WriteLEInt(-1);
			}
			else {
				if ( (entry.CompressedSize < 0) || (entry.Size < 0) ) {
					update.SizePatchOffset = baseStream_.Position;
				}

				WriteLEInt(( int )entry.CompressedSize);
				WriteLEInt(( int )entry.Size);
			}

			byte[] name = ZipConstants.ConvertToArray(entry.Flags, entry.Name);

			if ( name.Length > 0xFFFF ) {
				throw new ZipException("Entry name too long.");
			}

			ZipExtraData ed = new ZipExtraData(entry.ExtraData);

			if ( entry.LocalHeaderRequiresZip64 ) {
				ed.StartNewEntry();

				ed.AddLeLong(entry.Size);
				ed.AddLeLong(entry.CompressedSize);
				ed.AddNewEntry(1);
			}
			else {
				ed.Delete(1);
			}

			entry.ExtraData = ed.GetEntryData();

			WriteLEShort(name.Length);
			WriteLEShort(entry.ExtraData.Length);

			if ( name.Length > 0 ) {
				baseStream_.Write(name, 0, name.Length);
			}

			if ( entry.LocalHeaderRequiresZip64 ) {
				if ( !ed.Find(1) ) {
					throw new ZipException("Internal error cannot find extra data");
				}

				update.SizePatchOffset = baseStream_.Position + ed.CurrentReadIndex;
			}

			if ( entry.ExtraData.Length > 0 ) {
				baseStream_.Write(entry.ExtraData, 0, entry.ExtraData.Length);
			}
		}

		int WriteCentralDirectoryHeader(ZipEntry entry)
		{
			if ( entry.CompressedSize < 0 ) {
				throw new ZipException("Attempt to write central directory entry with unknown csize");
			}

			if ( entry.Size < 0 ) {
				throw new ZipException("Attempt to write central directory entry with unknown size");
			}
			
			if ( entry.Crc < 0 ) {
				throw new ZipException("Attempt to write central directory entry with unknown crc");
			}
			

			WriteLEInt(ZipConstants.CentralHeaderSignature);


			WriteLEShort(ZipConstants.VersionMadeBy);

			WriteLEShort(entry.Version);

			WriteLEShort(entry.Flags);
			
			unchecked {
				WriteLEShort((byte)entry.CompressionMethod);
				WriteLEInt((int)entry.DosTime);
				WriteLEInt((int)entry.Crc);
			}

			if ( (entry.IsZip64Forced()) || (entry.CompressedSize >= 0xffffffff) ) {
				WriteLEInt(-1);
			}
			else {
				WriteLEInt((int)(entry.CompressedSize & 0xffffffff));
			}

			if ( (entry.IsZip64Forced()) || (entry.Size >= 0xffffffff) ) {
				WriteLEInt(-1);
			}
			else {
				WriteLEInt((int)entry.Size);
			}

			byte[] name = ZipConstants.ConvertToArray(entry.Flags, entry.Name);

			if ( name.Length > 0xFFFF ) {
				throw new ZipException("Entry name is too long.");
			}

			WriteLEShort(name.Length);

			ZipExtraData ed = new ZipExtraData(entry.ExtraData);

			if ( entry.CentralHeaderRequiresZip64 ) {
				ed.StartNewEntry();

				if ( (entry.Size >= 0xffffffff) || (useZip64_ == UseZip64.On) )
				{
					ed.AddLeLong(entry.Size);
				}

				if ( (entry.CompressedSize >= 0xffffffff) || (useZip64_ == UseZip64.On) )
				{
					ed.AddLeLong(entry.CompressedSize);
				}

				if ( entry.Offset >= 0xffffffff ) {
					ed.AddLeLong(entry.Offset);
				}


				ed.AddNewEntry(1);
			}
			else {
				ed.Delete(1);
			}

			byte[] centralExtraData = ed.GetEntryData();

			WriteLEShort(centralExtraData.Length);
			WriteLEShort(entry.Comment != null ? entry.Comment.Length : 0);

			WriteLEShort(0);	
			WriteLEShort(0);	

			if ( entry.ExternalFileAttributes != -1 ) {
				WriteLEInt(entry.ExternalFileAttributes);
			}
			else {
				if ( entry.IsDirectory ) {
					WriteLEUint(16);
				}
				else {
					WriteLEUint(0);
				}
			}

			if ( entry.Offset >= 0xffffffff ) {
				WriteLEUint(0xffffffff);
			}
			else {
				WriteLEUint((uint)(int)entry.Offset);
			}

			if ( name.Length > 0 ) {
				baseStream_.Write(name, 0, name.Length);
			}

			if ( centralExtraData.Length > 0 ) {
				baseStream_.Write(centralExtraData, 0, centralExtraData.Length);
			}

			byte[] rawComment = (entry.Comment != null) ? Encoding.ASCII.GetBytes(entry.Comment) : new byte[0];

			if ( rawComment.Length > 0 ) {
				baseStream_.Write(rawComment, 0, rawComment.Length);
			}

			return ZipConstants.CentralHeaderBaseSize + name.Length + centralExtraData.Length + rawComment.Length;
		}
		#endregion
		
		void PostUpdateCleanup()
		{
			if( archiveStorage_!=null ) {
				archiveStorage_.Dispose();
				archiveStorage_=null;
			}

			updateDataSource_=null;
			updates_ = null;
			updateIndex_ = null;
		}

		string GetTransformedFileName(string name)
		{
			return (NameTransform != null) ?
				NameTransform.TransformFile(name) :
				name;
		}

		string GetTransformedDirectoryName(string name)
		{
			return (NameTransform != null) ?
				NameTransform.TransformDirectory(name) :
				name;
		}

	
		byte[] GetBuffer()
		{
			if ( copyBuffer_ == null ) {
				copyBuffer_ = new byte[bufferSize_];
			}
			return copyBuffer_;
		}

		void CopyDescriptorBytes(ZipUpdate update, Stream dest, Stream source)
		{
			int bytesToCopy = GetDescriptorSize(update);

			if ( bytesToCopy > 0 ) {
				byte[] buffer = GetBuffer();

				while ( bytesToCopy > 0 ) {
					int readSize = Math.Min(buffer.Length, bytesToCopy);

					int bytesRead = source.Read(buffer, 0, readSize);
					if ( bytesRead > 0 ) {
						dest.Write(buffer, 0, bytesRead);
						bytesToCopy -= bytesRead;
					}
					else {
						throw new ZipException("Unxpected end of stream");
					}
				}
			}
		}

		void CopyBytes(ZipUpdate update, Stream destination, Stream source,
			long bytesToCopy, bool updateCrc)
		{
			if ( destination == source ) {
				throw new InvalidOperationException("Destination and source are the same");
			}

			Crc32 crc = new Crc32();
			byte[] buffer = GetBuffer();

			long targetBytes = bytesToCopy;
			long totalBytesRead = 0;

			int bytesRead;
			do {
				int readSize = buffer.Length;

				if ( bytesToCopy < readSize ) {
					readSize = (int)bytesToCopy;
				}

				bytesRead = source.Read(buffer, 0, readSize);
				if ( bytesRead > 0 ) {
					if ( updateCrc ) {
						crc.Update(buffer, 0, bytesRead);
					}
					destination.Write(buffer, 0, bytesRead);
					bytesToCopy -= bytesRead;
					totalBytesRead += bytesRead;
				}
			}
			while ( (bytesRead > 0) && (bytesToCopy > 0) );

			if ( totalBytesRead != targetBytes ) {
				throw new ZipException(string.Format("Failed to copy bytes expected {0} read {1}", targetBytes, totalBytesRead));
			}

			if ( updateCrc ) {
				update.OutEntry.Crc = crc.Value;
			}
		}


		int GetDescriptorSize(ZipUpdate update)
		{
			int result = 0;
			if ( (update.Entry.Flags & (int)GeneralBitFlags.Descriptor) != 0) {
				result = ZipConstants.DataDescriptorSize - 4;
				if ( update.Entry.LocalHeaderRequiresZip64 ) {
					result = ZipConstants.Zip64DataDescriptorSize - 4;
				}
			}
			return result;
		}

		void CopyDescriptorBytesDirect(ZipUpdate update, Stream stream, ref long destinationPosition, long sourcePosition)
		{
			int bytesToCopy = GetDescriptorSize(update);

			while ( bytesToCopy > 0 ) {
				int readSize = (int)bytesToCopy;
				byte[] buffer = GetBuffer();

				stream.Position = sourcePosition;
				int bytesRead = stream.Read(buffer, 0, readSize);
				if ( bytesRead > 0 ) {
					stream.Position = destinationPosition;
					stream.Write(buffer, 0, bytesRead);
					bytesToCopy -= bytesRead;
					destinationPosition += bytesRead;
					sourcePosition += bytesRead;
				}
				else {
					throw new ZipException("Unxpected end of stream");
				}
			}
		}

		void CopyEntryDataDirect(ZipUpdate update, Stream stream, bool updateCrc, ref long destinationPosition, ref long sourcePosition)
		{
			long bytesToCopy = update.Entry.CompressedSize;
			

			Crc32 crc = new Crc32();
			byte[] buffer = GetBuffer();

			long targetBytes = bytesToCopy;
			long totalBytesRead = 0;

			int bytesRead;
			do
			{
				int readSize = buffer.Length;

				if ( bytesToCopy < readSize ) {
					readSize = (int)bytesToCopy;
				}

				stream.Position = sourcePosition;
				bytesRead = stream.Read(buffer, 0, readSize);
				if ( bytesRead > 0 ) {
					if ( updateCrc ) {
						crc.Update(buffer, 0, bytesRead);
					}
					stream.Position = destinationPosition;
					stream.Write(buffer, 0, bytesRead);

					destinationPosition += bytesRead;
					sourcePosition += bytesRead;
					bytesToCopy -= bytesRead;
					totalBytesRead += bytesRead;
				}
			}
			while ( (bytesRead > 0) && (bytesToCopy > 0) );

			if ( totalBytesRead != targetBytes ) {
				throw new ZipException(string.Format("Failed to copy bytes expected {0} read {1}", targetBytes, totalBytesRead));
			}

			if ( updateCrc ) {
				update.OutEntry.Crc = crc.Value;
			}
		}

		int FindExistingUpdate(ZipEntry entry)
		{
			int result = -1;
			string convertedName = GetTransformedFileName(entry.Name);

			if (updateIndex_.ContainsKey(convertedName)) {
				result = (int)updateIndex_[convertedName];
			}
			return result;
		}

		int FindExistingUpdate(string fileName)
		{
			int result = -1;

			string convertedName = GetTransformedFileName(fileName);

			if (updateIndex_.ContainsKey(convertedName)) {
				result = (int)updateIndex_[convertedName];
			}

			return result;
		}


		Stream GetOutputStream(ZipEntry entry)
		{
			Stream result = baseStream_;

			if ( entry.IsCrypted == true ) {
#if NETCF_1_0
				throw new ZipException("Encryption not supported for Compact Framework 1.0");
#else
				result = CreateAndInitEncryptionStream(result, entry);
#endif
			}

			switch ( entry.CompressionMethod ) {
				case CompressionMethod.Stored:
					result = new UncompressedStream(result);
					break;

				case CompressionMethod.Deflated:
					DeflaterOutputStream dos = new DeflaterOutputStream(result, new Deflater(9, true));
					dos.IsStreamOwner = false;
					result = dos;
					break;

				default:
					throw new ZipException("Unknown compression method " + entry.CompressionMethod);
			}
			return result;
		}

		void AddEntry(ZipFile workFile, ZipUpdate update)
		{
			Stream source = null;

			if ( update.Entry.IsFile ) {
				source = update.GetSource();
				
				if ( source == null ) {
					source = updateDataSource_.GetSource(update.Entry, update.Filename);
				}
			}

			if ( source != null ) {
				using ( source ) {
					long sourceStreamLength = source.Length;
					if ( update.OutEntry.Size < 0 ) {
						update.OutEntry.Size = sourceStreamLength;
					}
					else {
						if ( update.OutEntry.Size != sourceStreamLength ) {
							throw new ZipException("Entry size/stream size mismatch");
						}
					}

					workFile.WriteLocalEntryHeader(update);

					long dataStart = workFile.baseStream_.Position;

					using ( Stream output = workFile.GetOutputStream(update.OutEntry) ) {
						CopyBytes(update, output, source, sourceStreamLength, true);
					}

					long dataEnd = workFile.baseStream_.Position;
					update.OutEntry.CompressedSize = dataEnd - dataStart;

					if ((update.OutEntry.Flags & (int)GeneralBitFlags.Descriptor) == (int)GeneralBitFlags.Descriptor)
					{
						ZipHelperStream helper = new ZipHelperStream(workFile.baseStream_);
						helper.WriteDataDescriptor(update.OutEntry);
					}
				}
			}
			else {
				workFile.WriteLocalEntryHeader(update);
				update.OutEntry.CompressedSize = 0;
			}

		}

		void ModifyEntry(ZipFile workFile, ZipUpdate update)
		{
			workFile.WriteLocalEntryHeader(update);
			long dataStart = workFile.baseStream_.Position;
			if ( update.Entry.IsFile && (update.Filename != null) ) {
				using ( Stream output = workFile.GetOutputStream(update.OutEntry) ) {
					using ( Stream source = this.GetInputStream(update.Entry) ) {
						CopyBytes(update, output, source, source.Length, true);
					}
				}
			}

			long dataEnd = workFile.baseStream_.Position;
			update.Entry.CompressedSize = dataEnd - dataStart;
		}

		void CopyEntryDirect(ZipFile workFile, ZipUpdate update, ref long destinationPosition)
		{
			bool skipOver = false;
			if ( update.Entry.Offset == destinationPosition ) {
				skipOver = true;
			}

			if ( !skipOver ) {
				baseStream_.Position = destinationPosition;
				workFile.WriteLocalEntryHeader(update);
				destinationPosition = baseStream_.Position;
			}

			long sourcePosition = 0;

			const int NameLengthOffset = 26;


			long entryDataOffset = update.Entry.Offset + NameLengthOffset;

			baseStream_.Seek(entryDataOffset, SeekOrigin.Begin);

			uint nameLength = ReadLEUshort();
			uint extraLength = ReadLEUshort();

			sourcePosition = baseStream_.Position + nameLength + extraLength;

			if ( skipOver ) {
				destinationPosition += 
					(sourcePosition - entryDataOffset) + NameLengthOffset +	
					update.Entry.CompressedSize + GetDescriptorSize(update);
			}
			else {
				if ( update.Entry.CompressedSize > 0 ) {
					CopyEntryDataDirect(update, baseStream_, false, ref destinationPosition, ref sourcePosition );
				}
				CopyDescriptorBytesDirect(update, baseStream_, ref destinationPosition, sourcePosition);
			}
		}

		void CopyEntry(ZipFile workFile, ZipUpdate update)
		{
			workFile.WriteLocalEntryHeader(update);

			if ( update.Entry.CompressedSize > 0 ) {
				const int NameLengthOffset = 26;

				long entryDataOffset = update.Entry.Offset + NameLengthOffset;

		
				baseStream_.Seek(entryDataOffset, SeekOrigin.Begin);

				uint nameLength = ReadLEUshort();
				uint extraLength = ReadLEUshort();

				baseStream_.Seek(nameLength + extraLength, SeekOrigin.Current);

				CopyBytes(update, workFile.baseStream_, baseStream_, update.Entry.CompressedSize, false);
			}
			CopyDescriptorBytes(update, workFile.baseStream_, baseStream_);
		}

		void Reopen(Stream source)
		{
			if ( source == null ) {
				throw new ZipException("Failed to reopen archive - no source");
			}

			isNewArchive_ = false;
			baseStream_ = source;
			ReadEntries();
		}

		void Reopen()
		{
			if (Name == null) {
				throw new InvalidOperationException("Name is not known cannot Reopen");
			}

			Reopen(File.OpenRead(Name));
		}

		void UpdateCommentOnly()
		{
			long baseLength = baseStream_.Length;

			ZipHelperStream updateFile = null;

			if ( archiveStorage_.UpdateMode == FileUpdateMode.Safe ) {
				Stream copyStream = archiveStorage_.MakeTemporaryCopy(baseStream_);
				updateFile = new ZipHelperStream(copyStream);
				updateFile.IsStreamOwner = true;

				baseStream_.Close();
				baseStream_ = null;
			}
			else {
				if (archiveStorage_.UpdateMode == FileUpdateMode.Direct) {

					baseStream_ = archiveStorage_.OpenForDirectUpdate(baseStream_);
					updateFile = new ZipHelperStream(baseStream_);
				}
				else {
					baseStream_.Close();
					baseStream_ = null;
					updateFile = new ZipHelperStream(Name);
				}
			}

			using ( updateFile ) {
				long locatedCentralDirOffset = 
					updateFile.LocateBlockWithSignature(ZipConstants.EndOfCentralDirectorySignature, 
														baseLength, ZipConstants.EndOfCentralRecordBaseSize, 0xffff);
				if ( locatedCentralDirOffset < 0 ) {
					throw new ZipException("Cannot find central directory");
				}

				const int CentralHeaderCommentSizeOffset = 16;
				updateFile.Position += CentralHeaderCommentSizeOffset;

				byte[] rawComment = newComment_.RawComment;

				updateFile.WriteLEShort(rawComment.Length);
				updateFile.Write(rawComment, 0, rawComment.Length);
				updateFile.SetLength(updateFile.Position);
			}

			if ( archiveStorage_.UpdateMode == FileUpdateMode.Safe ) {
				Reopen(archiveStorage_.ConvertTemporaryToFinal());
			}
			else {
				ReadEntries();
			}
		}


		class UpdateComparer : IComparer
		{
			public int Compare(
				object x,
				object y)
			{
				ZipUpdate zx = x as ZipUpdate;
				ZipUpdate zy = y as ZipUpdate;

				int result;

				if (zx == null) {
					if (zy == null) { 
						result = 0; 
					}
					else {
						result = -1;
					}
				}
				else if (zy == null) {
					result = 1;
				}
				else {
					int xCmdValue = ((zx.Command == UpdateCommand.Copy) || (zx.Command == UpdateCommand.Modify)) ? 0 : 1;
					int yCmdValue = ((zy.Command == UpdateCommand.Copy) || (zy.Command == UpdateCommand.Modify)) ? 0 : 1;

					result = xCmdValue - yCmdValue;
					if (result == 0) {
						long offsetDiff = zx.Entry.Offset - zy.Entry.Offset;
						if (offsetDiff < 0) {
							result = -1;
						}
						else if (offsetDiff == 0) {
							result = 0;
						}
						else {
							result = 1;
						}
					}
				}
				return result;
			}
		}

		void RunUpdates()
		{
			long sizeEntries = 0;
			long endOfStream = 0;
			bool allOk = true;
			bool directUpdate = false;
			long destinationPosition = 0;

			ZipFile workFile;

			if ( IsNewArchive ) {
				workFile = this;
				workFile.baseStream_.Position = 0;
				directUpdate = true;
			}
			else if ( archiveStorage_.UpdateMode == FileUpdateMode.Direct ) {
				workFile = this;
				workFile.baseStream_.Position = 0;
				directUpdate = true;

				updates_.Sort(new UpdateComparer());
			}
			else {
				workFile = ZipFile.Create(archiveStorage_.GetTemporaryOutput());
				workFile.UseZip64 = UseZip64;
				
				if (key != null) {
					workFile.key = (byte[])key.Clone();
				}
			}

			try {
				foreach ( ZipUpdate update in updates_ ) {
					if (update != null) {
						switch (update.Command) {
							case UpdateCommand.Copy:
								if (directUpdate) {
									CopyEntryDirect(workFile, update, ref destinationPosition);
								}
								else {
									CopyEntry(workFile, update);
								}
								break;

							case UpdateCommand.Modify:
								ModifyEntry(workFile, update);
								break;

							case UpdateCommand.Add:
								if (!IsNewArchive && directUpdate) {
									workFile.baseStream_.Position = destinationPosition;
								}

								AddEntry(workFile, update);

								if (directUpdate) {
									destinationPosition = workFile.baseStream_.Position;
								}
								break;
						}
					}
				}

				if ( !IsNewArchive && directUpdate ) {
					workFile.baseStream_.Position = destinationPosition;
				}

				long centralDirOffset = workFile.baseStream_.Position;

				foreach ( ZipUpdate update in updates_ ) {
					if (update != null) {
						sizeEntries += workFile.WriteCentralDirectoryHeader(update.OutEntry);
					}
				}

				byte[] theComment = (newComment_ != null) ? newComment_.RawComment : ZipConstants.ConvertToArray(comment_);
				using ( ZipHelperStream zhs = new ZipHelperStream(workFile.baseStream_) ) {
					zhs.WriteEndOfCentralDirectory(updateCount_, sizeEntries, centralDirOffset, theComment);
				}

				endOfStream = workFile.baseStream_.Position;


				foreach ( ZipUpdate update in updates_ ) {
					if (update != null)
					{
						if ((update.CrcPatchOffset > 0) && (update.OutEntry.CompressedSize > 0)) {
							workFile.baseStream_.Position = update.CrcPatchOffset;
							workFile.WriteLEInt((int)update.OutEntry.Crc);
						}

						if (update.SizePatchOffset > 0) {
							workFile.baseStream_.Position = update.SizePatchOffset;
							if (update.OutEntry.LocalHeaderRequiresZip64) {
								workFile.WriteLeLong(update.OutEntry.Size);
								workFile.WriteLeLong(update.OutEntry.CompressedSize);
							}
							else {
								workFile.WriteLEInt((int)update.OutEntry.CompressedSize);
								workFile.WriteLEInt((int)update.OutEntry.Size);
							}
						}
					}
				}
			}
			catch(Exception) {
				allOk = false;
			}
			finally {
				if ( directUpdate ) {
					if ( allOk ) {
						workFile.baseStream_.Flush();
						workFile.baseStream_.SetLength(endOfStream);
					}
				}
				else {
					workFile.Close();
				}
			}

			if ( allOk ) {
				if ( directUpdate ) {
					isNewArchive_ = false;
					workFile.baseStream_.Flush();
					ReadEntries();
				}
				else {
					baseStream_.Close();
					Reopen(archiveStorage_.ConvertTemporaryToFinal());
				}
			}
			else {
				workFile.Close();
				if ( !directUpdate && (workFile.Name != null) ) {
					File.Delete(workFile.Name);
				}
			}
		}

		void CheckUpdating()
		{
			if ( updates_ == null ) {
				throw new InvalidOperationException("BeginUpdate has not been called");
			}
		}

		#endregion
		
		#region ZipUpdate class

		class ZipUpdate
		{
			#region Constructors
			public ZipUpdate(string fileName, ZipEntry entry)
			{
				command_ = UpdateCommand.Add;
				entry_ = entry;
				filename_ = fileName;
			}

			[Obsolete]
			public ZipUpdate(string fileName, string entryName, CompressionMethod compressionMethod)
			{
				command_ = UpdateCommand.Add;
				entry_ = new ZipEntry(entryName);
				entry_.CompressionMethod = compressionMethod;
				filename_ = fileName;
			}

			[Obsolete]
			public ZipUpdate(string fileName, string entryName)
				: this(fileName, entryName, CompressionMethod.Deflated)
			{
			}

			[Obsolete]
			public ZipUpdate(IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod)
			{
				command_ = UpdateCommand.Add;
				entry_ = new ZipEntry(entryName);
				entry_.CompressionMethod = compressionMethod;
				dataSource_ = dataSource;
			}

			public ZipUpdate(IStaticDataSource dataSource, ZipEntry entry)
			{
				command_ = UpdateCommand.Add;
				entry_ = entry;
				dataSource_ = dataSource;
			}

			public ZipUpdate(ZipEntry original, ZipEntry updated)
			{
				throw new ZipException("Modify not currently supported");
			}

			public ZipUpdate(UpdateCommand command, ZipEntry entry)
			{
				command_ = command;
				entry_ = ( ZipEntry )entry.Clone();
			}


			public ZipUpdate(ZipEntry entry)
				: this(UpdateCommand.Copy, entry)
			{
			}
			#endregion

			public ZipEntry Entry
			{
				get { return entry_; }
			}

			public ZipEntry OutEntry
			{
				get {
					if ( outEntry_ == null ) {
						outEntry_ = (ZipEntry)entry_.Clone();
					}

					return outEntry_; 
				}
			}


			public UpdateCommand Command
			{
				get { return command_; }
			}


			public string Filename
			{
				get { return filename_; }
			}


			public long SizePatchOffset
			{
				get { return sizePatchOffset_; }
				set { sizePatchOffset_ = value; }
			}


			public long CrcPatchOffset
			{
				get { return crcPatchOffset_; }
				set { crcPatchOffset_ = value; }
			}

			public Stream GetSource()
			{
				Stream result = null;
				if ( dataSource_ != null ) {
					result = dataSource_.GetSource();
				}

				return result;
			}

			#region Instance Fields
			ZipEntry entry_;
			ZipEntry outEntry_;
			UpdateCommand command_;
			IStaticDataSource dataSource_;
			string filename_;
			long sizePatchOffset_ = -1;
			long crcPatchOffset_ = -1;
			#endregion
		}

		#endregion
		#endregion
		
		#region Disposing

		#region IDisposable Members
		void IDisposable.Dispose()
		{
			Close();
		}
		#endregion

		void DisposeInternal(bool disposing)
		{
			if ( !isDisposed_ ) {
				isDisposed_ = true;
				entries_ = new ZipEntry[0];
						
				if ( IsStreamOwner && (baseStream_ != null) ) {
					lock(baseStream_) {
						baseStream_.Close();
					}
				}
				
				PostUpdateCleanup();
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			DisposeInternal(disposing);
		}

		#endregion
		
		#region Internal routines
		#region Reading

		ushort ReadLEUshort()
		{
			int data1 = baseStream_.ReadByte();

			if ( data1 < 0 ) {
				throw new EndOfStreamException("End of stream");
			}

			int data2 = baseStream_.ReadByte();

			if ( data2 < 0 ) {
				throw new EndOfStreamException("End of stream");
			}


			return unchecked((ushort)((ushort)data1 | (ushort)(data2 << 8)));
		}


		uint ReadLEUint()
		{
			return (uint)(ReadLEUshort() | (ReadLEUshort() << 16));
		}

		ulong ReadLEUlong()
		{
			return ReadLEUint() | ((ulong)ReadLEUint() << 32);
		}

		#endregion

		long LocateBlockWithSignature(int signature, long endLocation, int minimumBlockSize, int maximumVariableData)
		{
			using ( ZipHelperStream les = new ZipHelperStream(baseStream_) ) {
				return les.LocateBlockWithSignature(signature, endLocation, minimumBlockSize, maximumVariableData);
			}
		}
	
		void ReadEntries()
		{
			if (baseStream_.CanSeek == false) {
				throw new ZipException("ZipFile stream must be seekable");
			}
			
			long locatedEndOfCentralDir = LocateBlockWithSignature(ZipConstants.EndOfCentralDirectorySignature,
				baseStream_.Length, ZipConstants.EndOfCentralRecordBaseSize, 0xffff);
			
			if (locatedEndOfCentralDir < 0) {
				throw new ZipException("Cannot find central directory");
			}


			ushort thisDiskNumber           = ReadLEUshort();
			ushort startCentralDirDisk      = ReadLEUshort();
			ulong entriesForThisDisk        = ReadLEUshort();
			ulong entriesForWholeCentralDir = ReadLEUshort();
			ulong centralDirSize            = ReadLEUint();
			long offsetOfCentralDir         = ReadLEUint();
			uint commentSize                = ReadLEUshort();
			
			if ( commentSize > 0 ) {
				byte[] comment = new byte[commentSize]; 

				StreamUtils.ReadFully(baseStream_, comment);
				comment_ = ZipConstants.ConvertToString(comment); 
			}
			else {
				comment_ = string.Empty;
			}
			
			bool isZip64 = false;

			if ( (thisDiskNumber == 0xffff) ||
				(startCentralDirDisk == 0xffff) ||
				(entriesForThisDisk == 0xffff) ||
				(entriesForWholeCentralDir == 0xffff) ||
				(centralDirSize == 0xffffffff) ||
				(offsetOfCentralDir == 0xffffffff) ) {
				isZip64 = true;

				long offset = LocateBlockWithSignature(ZipConstants.Zip64CentralDirLocatorSignature, locatedEndOfCentralDir, 0, 0x1000);
				if ( offset < 0 ) {
					throw new ZipException("Cannot find Zip64 locator");
				}

				ReadLEUint(); 
				ulong offset64 = ReadLEUlong();
				uint totalDisks = ReadLEUint();

				baseStream_.Position = (long)offset64;
				long sig64 = ReadLEUint();

				if ( sig64 != ZipConstants.Zip64CentralFileHeaderSignature ) {
					throw new ZipException(string.Format("Invalid Zip64 Central directory signature at {0:X}", offset64));
				}

				ulong recordSize = ( ulong )ReadLEUlong();
				int versionMadeBy = ReadLEUshort();
				int versionToExtract = ReadLEUshort();
				uint thisDisk = ReadLEUint();
				uint centralDirDisk = ReadLEUint();
				entriesForThisDisk = ReadLEUlong();
				entriesForWholeCentralDir = ReadLEUlong();
				centralDirSize = ReadLEUlong();
				offsetOfCentralDir = (long)ReadLEUlong();
			}
			
			entries_ = new ZipEntry[entriesForThisDisk];
			

			if ( !isZip64 && (offsetOfCentralDir < locatedEndOfCentralDir - (4 + (long)centralDirSize)) ) {
				offsetOfFirstEntry = locatedEndOfCentralDir - (4 + (long)centralDirSize + offsetOfCentralDir);
				if (offsetOfFirstEntry <= 0) {
					throw new ZipException("Invalid embedded zip archive");
				}
			}

			baseStream_.Seek(offsetOfFirstEntry + offsetOfCentralDir, SeekOrigin.Begin);
			
			for (ulong i = 0; i < entriesForThisDisk; i++) {
				if (ReadLEUint() != ZipConstants.CentralHeaderSignature) {
					throw new ZipException("Wrong Central Directory signature");
				}
				
				int versionMadeBy      = ReadLEUshort();
				int versionToExtract   = ReadLEUshort();
				int bitFlags           = ReadLEUshort();
				int method             = ReadLEUshort();
				uint dostime           = ReadLEUint();
				uint crc               = ReadLEUint();
				long csize             = (long)ReadLEUint();
				long size              = (long)ReadLEUint();
				int nameLen            = ReadLEUshort();
				int extraLen           = ReadLEUshort();
				int commentLen         = ReadLEUshort();
				
				int diskStartNo        = ReadLEUshort();  
				int internalAttributes = ReadLEUshort();  

				uint externalAttributes = ReadLEUint();
				long offset             = ReadLEUint();
				
				byte[] buffer = new byte[Math.Max(nameLen, commentLen)];
				
				StreamUtils.ReadFully(baseStream_, buffer, 0, nameLen);
				string name = ZipConstants.ConvertToStringExt(bitFlags, buffer, nameLen);
				
				ZipEntry entry = new ZipEntry(name, versionToExtract, versionMadeBy, (CompressionMethod)method);
				entry.Crc = crc & 0xffffffffL;
				entry.Size = size & 0xffffffffL;
				entry.CompressedSize = csize & 0xffffffffL;
				entry.Flags = bitFlags;
				entry.DosTime = (uint)dostime;
				entry.ZipFileIndex = (long)i;
				entry.Offset = offset;
				entry.ExternalFileAttributes = (int)externalAttributes;

				if ((bitFlags & 8) == 0) {
					entry.CryptoCheckValue = (byte)(crc >> 24);
				}
				else {
					entry.CryptoCheckValue = (byte)((dostime >> 8) & 0xff);
				}

				if (extraLen > 0) {
					byte[] extra = new byte[extraLen];
					StreamUtils.ReadFully(baseStream_, extra);
					entry.ExtraData = extra;
				}

				entry.ProcessExtraData(false);
				
				if (commentLen > 0) {
					StreamUtils.ReadFully(baseStream_, buffer, 0, commentLen);
					entry.Comment = ZipConstants.ConvertToStringExt(bitFlags, buffer, commentLen);
				}
				
				entries_[i] = entry;
			}
		}


		long LocateEntry(ZipEntry entry)
		{
			return TestLocalHeader(entry, HeaderTest.Extract);
		}
		
#if !NETCF_1_0		
		Stream CreateAndInitDecryptionStream(Stream baseStream, ZipEntry entry)
		{
			CryptoStream result = null;

			if ( (entry.Version < ZipConstants.VersionStrongEncryption)
				|| (entry.Flags & (int)GeneralBitFlags.StrongEncryption) == 0) {
				PkzipClassicManaged classicManaged = new PkzipClassicManaged();

				OnKeysRequired(entry.Name);
				if (HaveKeys == false) {
					throw new ZipException("No password available for encrypted stream");
				}

				result = new CryptoStream(baseStream, classicManaged.CreateDecryptor(key, null), CryptoStreamMode.Read);
				CheckClassicPassword(result, entry);
			}
			else {
				throw new ZipException("Decryption method not supported");
			}

			return result;
		}

		Stream CreateAndInitEncryptionStream(Stream baseStream, ZipEntry entry)
		{
			CryptoStream result = null;
			if ( (entry.Version < ZipConstants.VersionStrongEncryption)
				|| (entry.Flags & (int)GeneralBitFlags.StrongEncryption) == 0) {
				PkzipClassicManaged classicManaged = new PkzipClassicManaged();

				OnKeysRequired(entry.Name);
				if (HaveKeys == false) {
					throw new ZipException("No password available for encrypted stream");
				}


				result = new CryptoStream(new UncompressedStream(baseStream),
					classicManaged.CreateEncryptor(key, null), CryptoStreamMode.Write);

				if ( (entry.Crc < 0) || (entry.Flags & 8) != 0) {
					WriteEncryptionHeader(result, entry.DosTime << 16);
				}
				else {
					WriteEncryptionHeader(result, entry.Crc);
				}
			}
			return result;
		}
		
		static void CheckClassicPassword(CryptoStream classicCryptoStream, ZipEntry entry)
		{
			byte[] cryptbuffer = new byte[ZipConstants.CryptoHeaderSize];
			StreamUtils.ReadFully(classicCryptoStream, cryptbuffer);
			if (cryptbuffer[ZipConstants.CryptoHeaderSize - 1] != entry.CryptoCheckValue) {
				throw new ZipException("Invalid password");
			}
		}
#endif
		
		static void WriteEncryptionHeader(Stream stream, long crcValue)
		{
			byte[] cryptBuffer = new byte[ZipConstants.CryptoHeaderSize];
			Random rnd = new Random();
			rnd.NextBytes(cryptBuffer);
			cryptBuffer[11] = (byte)(crcValue >> 24);
			stream.Write(cryptBuffer, 0, cryptBuffer.Length);
		}

		#endregion
		
		#region Instance Fields
		bool       isDisposed_;
		string     name_;
		string     comment_;
		Stream     baseStream_;
		bool       isStreamOwner;
		long       offsetOfFirstEntry;
		ZipEntry[] entries_;
		byte[] key;
		bool isNewArchive_;
		
		UseZip64 useZip64_ = UseZip64.Dynamic ;
		
		#region Zip Update Instance Fields
		ArrayList updates_;
		long updateCount_; 
		Hashtable updateIndex_;
		IArchiveStorage archiveStorage_;
		IDynamicDataSource updateDataSource_;
		bool contentsEdited_;
		int bufferSize_ = DefaultBufferSize;
		byte[] copyBuffer_;
		ZipString newComment_;
		bool commentEdited_;
		IEntryFactory updateEntryFactory_ = new ZipEntryFactory();
		#endregion
		#endregion
		
		#region Support Classes

		class ZipString
		{
			#region Constructors

			public ZipString(string comment)
			{
				comment_ = comment;
				isSourceString_ = true;
			}

		
			public ZipString(byte[] rawString)
			{
				rawComment_ = rawString;
			}
			#endregion


			public bool IsSourceString
			{
				get { return isSourceString_; }
			}
			
		
			public int RawLength
			{
				get {
					MakeBytesAvailable();
					return rawComment_.Length;
				}
			}

		
			public byte[] RawComment
			{
				get {
					MakeBytesAvailable();
					return (byte[])rawComment_.Clone();
				}
			}


			public void Reset()
			{
				if ( isSourceString_ ) {
					rawComment_ = null;
				}
				else {
					comment_ = null;
				}
			}

			void MakeTextAvailable() 
			{
				if ( comment_ == null ) {
					comment_ = ZipConstants.ConvertToString(rawComment_);
				}
			}

			void MakeBytesAvailable()
			{
				if ( rawComment_ == null ) {
					rawComment_ = ZipConstants.ConvertToArray(comment_);
				}
			}


			static public implicit operator string(ZipString zipString)
			{
				zipString.MakeTextAvailable();
				return zipString.comment_;
			}

			#region Instance Fields
			string comment_;
			byte[] rawComment_;
			bool isSourceString_;
			#endregion
		}
		

		class ZipEntryEnumerator : IEnumerator
		{
			#region Constructors
			public ZipEntryEnumerator(ZipEntry[] entries)
			{
				array = entries;
			}
			
			#endregion
			#region IEnumerator Members
			public object Current 
			{
				get {
					return array[index];
				}
			}
			
			public void Reset()
			{
				index = -1;
			}
			
			public bool MoveNext() 
			{
				return (++index < array.Length);
			}
			#endregion
			#region Instance Fields
			ZipEntry[] array;
			int index = -1;
			#endregion
		}


		class UncompressedStream : Stream
		{
			#region Constructors
			public UncompressedStream(Stream baseStream)
			{
				baseStream_ = baseStream;
			}

			#endregion

	
			public override void Close()
			{

			}


			public override bool CanRead
			{
				get {
					return false;
				}
			}


			public override void Flush()
			{
				baseStream_.Flush();
			}

	
			public override bool CanWrite
			{
				get {
					return baseStream_.CanWrite;
				}
			}

	
			public override bool CanSeek
			{
				get {
					return false;
				}
			}

	
			public override long Length
			{
				get {
					return 0;
				}
			}


			public override long Position
			{
				get	{
					return baseStream_.Position;
				}
				
				set
				{
				}
			}

		
			public override int Read(byte[] buffer, int offset, int count)
			{
				return 0;
			}

		
			public override long Seek(long offset, SeekOrigin origin)
			{
				return 0;
			}

			public override void SetLength(long value)
			{
			}

		
			public override void Write(byte[] buffer, int offset, int count)
			{
				baseStream_.Write(buffer, offset, count);
			}

			#region Instance Fields
			Stream baseStream_;
			#endregion
		}
		
		
		class PartialInputStream : Stream
		{
			#region Constructors
			
			public PartialInputStream(ZipFile zipFile, long start, long length)
			{
				start_ = start;
				length_ = length;

				zipFile_ = zipFile;
				baseStream_ = zipFile_.baseStream_;
				readPos_ = start;
				end_ = start + length;
			}
			#endregion

			
			public override int ReadByte()
			{
				if (readPos_ >= end_) {
					 
					return -1;
				}
				
				lock( baseStream_ ) {
					baseStream_.Seek(readPos_++, SeekOrigin.Begin);
					return baseStream_.ReadByte();
				}
			}
			
		
			public override void Close()
			{
			}


			public override int Read(byte[] buffer, int offset, int count)
			{
				lock(baseStream_) {
					if (count > end_ - readPos_) {
						count = (int) (end_ - readPos_);
						if (count == 0) {
							return 0;
						}
					}
					
					baseStream_.Seek(readPos_, SeekOrigin.Begin);
					int readCount = baseStream_.Read(buffer, offset, count);
					if (readCount > 0) {
						readPos_ += readCount;
					}
					return readCount;
				}
			}

		
			public override void Write(byte[] buffer, int offset, int count)
			{
				throw new NotSupportedException();
			}

		
			public override void SetLength(long value)
			{
				throw new NotSupportedException();
			}

		
			public override long Seek(long offset, SeekOrigin origin)
			{
				long newPos = readPos_;
				
				switch ( origin )
				{
					case SeekOrigin.Begin:
						newPos = start_ + offset;
						break;
						
					case SeekOrigin.Current:
						newPos = readPos_ + offset;
						break;
						
					case SeekOrigin.End:
						newPos = end_ + offset;
						break;
				}
				
				if ( newPos < start_ ) {
					throw new ArgumentException("Negative position is invalid");
				}
				
				if ( newPos >= end_ ) {
					throw new IOException("Cannot seek past end");
				}
				readPos_ = newPos;
				return readPos_;
			}

		
			public override void Flush()
			{
			
			}

	
			public override long Position {
				get { return readPos_ - start_; }
				set { 
					long newPos = start_ + value;
					
					if ( newPos < start_ ) {
						throw new ArgumentException("Negative position is invalid");
					}
					
					if ( newPos >= end_ ) {
						throw new InvalidOperationException("Cannot seek past end");
					}
					readPos_ = newPos;
				}
			}

		
			public override long Length {
				get { return length_; }
			}

		
			public override bool CanWrite {
				get { return false; }
			}

		
			public override bool CanSeek {
				get { return true; }
			}

			
			public override bool CanRead {
				get { return true; }
			}
			
#if !NET_1_0 && !NET_1_1 && !NETCF_1_0
			
			public override bool CanTimeout {
				get { return baseStream_.CanTimeout; }
			}
#endif			
			#region Instance Fields
			ZipFile zipFile_;
			Stream baseStream_;
			long start_;
			long length_;
			long readPos_;
			long end_;
			#endregion	
		}
		#endregion
	}

	#endregion
	
	#region DataSources
	
	public interface IStaticDataSource
	{
	
		Stream GetSource();
	}

	
	public interface IDynamicDataSource
	{
	
		Stream GetSource(ZipEntry entry, string name);
	}

	
	public class StaticDiskDataSource : IStaticDataSource
	{
		
		public StaticDiskDataSource(string fileName)
		{
			fileName_ = fileName;
		}

		#region IDataSource Members

		
		public Stream GetSource()
		{
			return File.OpenRead(fileName_);
		}

		#endregion
		#region Instance Fields
		string fileName_;
		#endregion
	}


	
	public class DynamicDiskDataSource : IDynamicDataSource
	{
		
		public DynamicDiskDataSource()
		{
		}

		#region IDataSource Members
		
		public Stream GetSource(ZipEntry entry, string name)
		{
			Stream result = null;

			if ( name != null ) {
				result = File.OpenRead(name);
			}

			return result;
		}

		#endregion
	}

	#endregion
	
	#region Archive Storage

	public interface IArchiveStorage
	{
		FileUpdateMode UpdateMode { get; }

		Stream GetTemporaryOutput();

		Stream ConvertTemporaryToFinal();

		Stream MakeTemporaryCopy(Stream stream);

		Stream OpenForDirectUpdate(Stream stream);

		void Dispose();
	}

	abstract public class BaseArchiveStorage : IArchiveStorage
	{
		#region Constructors
		protected BaseArchiveStorage(FileUpdateMode updateMode)
		{
			updateMode_ = updateMode;
		}
		#endregion
		
		#region IArchiveStorage Members


		public abstract Stream GetTemporaryOutput();

		public abstract Stream ConvertTemporaryToFinal();

		public abstract Stream MakeTemporaryCopy(Stream stream);

		public abstract Stream OpenForDirectUpdate(Stream stream);

		public abstract void Dispose();

		public FileUpdateMode UpdateMode
		{
			get {
				return updateMode_;
			}
		}

		#endregion

		#region Instance Fields
		FileUpdateMode updateMode_;
		#endregion
	}

	public class DiskArchiveStorage : BaseArchiveStorage
	{
		#region Constructors
		public DiskArchiveStorage(ZipFile file, FileUpdateMode updateMode)
			: base(updateMode)
		{
			if ( file.Name == null ) {
				throw new ZipException("Cant handle non file archives");
			}

			fileName_ = file.Name;
		}

		public DiskArchiveStorage(ZipFile file)
			: this(file, FileUpdateMode.Safe)
		{
		}
		#endregion

		#region IArchiveStorage Members

		public override Stream GetTemporaryOutput()
		{
			if ( temporaryName_ != null ) {
				temporaryName_ = GetTempFileName(temporaryName_, true);
				temporaryStream_ = File.OpenWrite(temporaryName_);
			}
			else {
				temporaryName_ = Path.GetTempFileName();
				temporaryStream_ = File.OpenWrite(temporaryName_);
			}

			return temporaryStream_;
		}


		public override Stream ConvertTemporaryToFinal()
		{
			if ( temporaryStream_ == null ) {
				throw new ZipException("No temporary stream has been created");
			}

			Stream result = null;

			string moveTempName = GetTempFileName(fileName_, false);
			bool newFileCreated = false;

			try	{
				temporaryStream_.Close();
				File.Move(fileName_, moveTempName);
				File.Move(temporaryName_, fileName_);
				newFileCreated = true;
				File.Delete(moveTempName);

				result = File.OpenRead(fileName_);
			}
			catch(Exception) {
				result  = null;

				if ( !newFileCreated ) {
					File.Move(moveTempName, fileName_);
					File.Delete(temporaryName_);
				}

				throw;
			}

			return result;
		}

		public override Stream MakeTemporaryCopy(Stream stream)
		{
			stream.Close();

			temporaryName_ = GetTempFileName(fileName_, true);
			File.Copy(fileName_, temporaryName_, true);
			
			temporaryStream_ = new FileStream(temporaryName_, 
				FileMode.Open, 
				FileAccess.ReadWrite);
			return temporaryStream_;
		}

		public override Stream OpenForDirectUpdate(Stream stream)
		{
			Stream result;
			if ((stream == null) || !stream.CanWrite)
			{
				if (stream != null) {
					stream.Close();
				}

				result = new FileStream(fileName_,
						FileMode.Open,
						FileAccess.ReadWrite);
			}
			else
			{
				result = stream;
			}

			return result;
		}


		public override void Dispose()
		{
			if ( temporaryStream_ != null ) {
				temporaryStream_.Close();
			}
		}

		#endregion

		#region Internal routines
		static string GetTempFileName(string original, bool makeTempFile)
		{
			string result = null;
				
			if ( original == null ) {
				result = Path.GetTempFileName();
			}
			else {
				int counter = 0;
				int suffixSeed = DateTime.Now.Second;

				while ( result == null ) {
					counter += 1;
					string newName = string.Format("{0}.{1}{2}.tmp", original, suffixSeed, counter);
					if ( !File.Exists(newName) ) {
						if ( makeTempFile) {
							try	{
								using ( FileStream stream = File.Create(newName) ) {
								}
								result = newName;
							}
							catch {
								suffixSeed = DateTime.Now.Second;
							}
						}
						else {
							result = newName;
						}
					}
				}
			}
			return result;
		}
		#endregion

		#region Instance Fields
		Stream temporaryStream_;
		string fileName_;
		string temporaryName_;
		#endregion
	}


	public class MemoryArchiveStorage : BaseArchiveStorage
	{
		#region Constructors

		public MemoryArchiveStorage() 
			: base(FileUpdateMode.Direct)
		{
		}

		public MemoryArchiveStorage(FileUpdateMode updateMode)
			: base(updateMode)
		{
		}

		#endregion

		#region Properties
		public MemoryStream FinalStream
		{
			get { return finalStream_; }
		}

		#endregion

		#region IArchiveStorage Members
		public override Stream GetTemporaryOutput()
		{
			temporaryStream_ = new MemoryStream();
			return temporaryStream_;
		}

		public override Stream ConvertTemporaryToFinal()
		{
			if ( temporaryStream_ == null ) {
				throw new ZipException("No temporary stream has been created");
			}

			finalStream_ = new MemoryStream(temporaryStream_.ToArray());
			return finalStream_;
		}

		public override Stream MakeTemporaryCopy(Stream stream)
		{
			temporaryStream_ = new MemoryStream();
			stream.Position = 0;
			StreamUtils.Copy(stream, temporaryStream_, new byte[4096]);
			return temporaryStream_;
		}

		public override Stream OpenForDirectUpdate(Stream stream)
		{
			Stream result;
			if ((stream == null) || !stream.CanWrite) {

				result = new MemoryStream();

				if (stream != null) {
					stream.Position = 0;
					StreamUtils.Copy(stream, result, new byte[4096]);

					stream.Close();
				}
			}
			else {
				result = stream;
			}

			return result;
		}


		public override void Dispose()
		{
			if ( temporaryStream_ != null ) {
				temporaryStream_.Close();
			}
		}

		#endregion

		#region Instance Fields
		MemoryStream temporaryStream_;
		MemoryStream finalStream_;
		#endregion
	}

	#endregion
}
