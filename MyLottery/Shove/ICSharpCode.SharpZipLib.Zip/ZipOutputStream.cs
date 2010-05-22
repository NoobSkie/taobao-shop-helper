using System;
using System.IO;
using System.Collections;
using System.Text;

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip
{

	public class ZipOutputStream : DeflaterOutputStream
	{
		#region Constructors
	
		public ZipOutputStream(Stream baseOutputStream)
			: base(baseOutputStream, new Deflater(Deflater.DEFAULT_COMPRESSION, true))
		{
		}
		#endregion
		
		
		public bool IsFinished 
		{
			get {
				return entries == null;
			}
		}

		
		public void SetComment(string comment)
		{
			byte[] commentBytes = ZipConstants.ConvertToArray(comment);
			if (commentBytes.Length > 0xffff) {
				throw new ArgumentOutOfRangeException("comment");
			}
			zipComment = commentBytes;
		}
		
		
		public void SetLevel(int level)
		{
			deflater_.SetLevel(level);
			defaultCompressionLevel = level;
		}
		
		
		public int GetLevel()
		{
			return deflater_.GetLevel();
		}

		
		public UseZip64 UseZip64
		{
			get { return useZip64_; }
			set { useZip64_ = value; }
		}
		
		
		private void WriteLeShort(int value)
		{
			unchecked {
				baseOutputStream_.WriteByte((byte)(value & 0xff));
				baseOutputStream_.WriteByte((byte)((value >> 8) & 0xff));
			}
		}
		
	
		private void WriteLeInt(int value)
		{
			unchecked {
				WriteLeShort(value);
				WriteLeShort(value >> 16);
			}
		}
		
		private void WriteLeLong(long value)
		{
			unchecked {
				WriteLeInt((int)value);
				WriteLeInt((int)(value >> 32));
			}
		}
		
	
		
		public void PutNextEntry(ZipEntry entry)
		{
			if ( entry == null ) {
				throw new ArgumentNullException("entry");
			}

			if (entries == null) {
				throw new InvalidOperationException("ZipOutputStream was finished");
			}
			
			if (curEntry != null) {
				CloseEntry();
			}

			if (entries.Count == int.MaxValue) {
				throw new ZipException("Too many entries for Zip file");
			}
			
			CompressionMethod method = entry.CompressionMethod;
			int compressionLevel = defaultCompressionLevel;
			
			
			entry.Flags &= (int)GeneralBitFlags.UnicodeText;
			patchEntryHeader = false;

			bool headerInfoAvailable;

			if (entry.Size == 0)
			{
				entry.CompressedSize = entry.Size;
				entry.Crc = 0;
				method = CompressionMethod.Stored;
				headerInfoAvailable = true;
			}
			else
			{
				headerInfoAvailable = (entry.Size >= 0) && entry.HasCrc;

	
				if (method == CompressionMethod.Stored)
				{
					if (!headerInfoAvailable)
					{
						if (!CanPatchEntries)
						{
							method = CompressionMethod.Deflated;
							compressionLevel = 0;
						}
					}
					else 
					{
						entry.CompressedSize = entry.Size;
						headerInfoAvailable = entry.HasCrc;
					}
				}
			}

			if (headerInfoAvailable == false) {
				if (CanPatchEntries == false) {
			
					entry.Flags |= 8;
				} else {
					patchEntryHeader = true;
				}
			}
			
			if (Password != null) {
				entry.IsCrypted = true;
				if (entry.Crc < 0) {
					
					entry.Flags |= 8;
				}
			}

			entry.Offset = offset;
			entry.CompressionMethod = (CompressionMethod)method;
			
			curMethod = method;
			sizePatchPos = -1;
			
			if ( (useZip64_ == UseZip64.On) || ((entry.Size < 0) && (useZip64_ == UseZip64.Dynamic)) ) {
				entry.ForceZip64();
			}


			WriteLeInt(ZipConstants.LocalHeaderSignature);
			
			WriteLeShort(entry.Version);
			WriteLeShort(entry.Flags);
			WriteLeShort((byte)method);
			WriteLeInt((int)entry.DosTime);

		
			if (headerInfoAvailable == true) {
				WriteLeInt((int)entry.Crc);
				if ( entry.LocalHeaderRequiresZip64 ) {
					WriteLeInt(-1);
					WriteLeInt(-1);
				}
				else {
					WriteLeInt(entry.IsCrypted ? (int)entry.CompressedSize + ZipConstants.CryptoHeaderSize : (int)entry.CompressedSize);
					WriteLeInt((int)entry.Size);
				}
			} else {
				if (patchEntryHeader == true) {
					crcPatchPos = baseOutputStream_.Position;
				}
				WriteLeInt(0);	
				
				if ( patchEntryHeader ) {
					sizePatchPos = baseOutputStream_.Position;
				}

			
				if ( entry.LocalHeaderRequiresZip64 || patchEntryHeader ) {
					WriteLeInt(-1);
					WriteLeInt(-1);
				}
				else {
					WriteLeInt(0);	
					WriteLeInt(0);	
				}
			}

			byte[] name = ZipConstants.ConvertToArray(entry.Flags, entry.Name);
			
			if (name.Length > 0xFFFF) {
				throw new ZipException("Entry name too long.");
			}

			ZipExtraData ed = new ZipExtraData(entry.ExtraData);

			if (entry.LocalHeaderRequiresZip64) {
				ed.StartNewEntry();
				if (headerInfoAvailable) {
					ed.AddLeLong(entry.Size);
					ed.AddLeLong(entry.CompressedSize);
				}
				else {
					ed.AddLeLong(-1);
					ed.AddLeLong(-1);
				}
				ed.AddNewEntry(1);

				if ( !ed.Find(1) ) {
					throw new ZipException("Internal error cant find extra data");
				}
				
				if ( patchEntryHeader ) {
					sizePatchPos = ed.CurrentReadIndex;
				}
			}
			else {
				ed.Delete(1);
			}
			
			byte[] extra = ed.GetEntryData();

			WriteLeShort(name.Length);
			WriteLeShort(extra.Length);

			if ( name.Length > 0 ) {
				baseOutputStream_.Write(name, 0, name.Length);
			}
			
			if ( entry.LocalHeaderRequiresZip64 && patchEntryHeader ) {
				sizePatchPos += baseOutputStream_.Position;
			}

			if ( extra.Length > 0 ) {
				baseOutputStream_.Write(extra, 0, extra.Length);
			}
			
			offset += ZipConstants.LocalHeaderBaseSize + name.Length + extra.Length;
			
		
			curEntry = entry;
			crc.Reset();
			if (method == CompressionMethod.Deflated) {
				deflater_.Reset();
				deflater_.SetLevel(compressionLevel);
			}
			size = 0;
			
			if (entry.IsCrypted == true) {
				if (entry.Crc < 0) {			
					WriteEncryptionHeader(entry.DosTime << 16);
				} else {
					WriteEncryptionHeader(entry.Crc);
				}
			}
		}
		
	
		public void CloseEntry()
		{
			if (curEntry == null) {
				throw new InvalidOperationException("No open entry");
			}

			long csize = size;
			
		
			if (curMethod == CompressionMethod.Deflated) {
				if (size > 0) {
					base.Finish();
					csize = deflater_.TotalOut;
				}
				else {
					deflater_.Reset();
				}
			}
			
			if (curEntry.Size < 0) {
				curEntry.Size = size;
			} else if (curEntry.Size != size) {
				throw new ZipException("size was " + size + ", but I expected " + curEntry.Size);
			}
			
			if (curEntry.CompressedSize < 0) {
				curEntry.CompressedSize = csize;
			} else if (curEntry.CompressedSize != csize) {
				throw new ZipException("compressed size was " + csize + ", but I expected " + curEntry.CompressedSize);
			}
			
			if (curEntry.Crc < 0) {
				curEntry.Crc = crc.Value;
			} else if (curEntry.Crc != crc.Value) {
				throw new ZipException("crc was " + crc.Value +	", but I expected " + curEntry.Crc);
			}
			
			offset += csize;

			if (curEntry.IsCrypted == true) {
				curEntry.CompressedSize += ZipConstants.CryptoHeaderSize;
			}
				
	
			if (patchEntryHeader == true) {
				patchEntryHeader = false;

				long curPos = baseOutputStream_.Position;
				baseOutputStream_.Seek(crcPatchPos, SeekOrigin.Begin);
				WriteLeInt((int)curEntry.Crc);
				
				if ( curEntry.LocalHeaderRequiresZip64 ) {
					
					if ( sizePatchPos == -1 ) {
						throw new ZipException("Entry requires zip64 but this has been turned off");
					}
					
					baseOutputStream_.Seek(sizePatchPos, SeekOrigin.Begin);
					WriteLeLong(curEntry.Size);
					WriteLeLong(curEntry.CompressedSize);
				}
				else {
					WriteLeInt((int)curEntry.CompressedSize);
					WriteLeInt((int)curEntry.Size);
				}
				baseOutputStream_.Seek(curPos, SeekOrigin.Begin);
			}

		
			if ((curEntry.Flags & 8) != 0) {
				WriteLeInt(ZipConstants.DataDescriptorSignature);
				WriteLeInt(unchecked((int)curEntry.Crc));
				
				if ( curEntry.LocalHeaderRequiresZip64 ) {
					WriteLeLong(curEntry.CompressedSize);
					WriteLeLong(curEntry.Size);
					offset += ZipConstants.Zip64DataDescriptorSize;
				}
				else {
					WriteLeInt((int)curEntry.CompressedSize);
					WriteLeInt((int)curEntry.Size);
					offset += ZipConstants.DataDescriptorSize;
				}
			}
			
			entries.Add(curEntry);
			curEntry = null;
		}
		
		void WriteEncryptionHeader(long crcValue)
		{
			offset += ZipConstants.CryptoHeaderSize;
			
			InitializePassword(Password);
			
			byte[] cryptBuffer = new byte[ZipConstants.CryptoHeaderSize];
			Random rnd = new Random();
			rnd.NextBytes(cryptBuffer);
			cryptBuffer[11] = (byte)(crcValue >> 24);
			
			EncryptBlock(cryptBuffer, 0, cryptBuffer.Length);
			baseOutputStream_.Write(cryptBuffer, 0, cryptBuffer.Length);
		}
		
		
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (curEntry == null) {
				throw new InvalidOperationException("No open entry.");
			}
			
			if ( buffer == null ) {
				throw new ArgumentNullException("buffer");
			}
			
			if ( offset < 0 ) {
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("offset");
#else
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
#endif
			}

			if ( count < 0 ) {
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("count");
#else
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
#endif
			}

			if ( (buffer.Length - offset) < count ) {
				throw new ArgumentException("Invalid offset/count combination");
			}
			
			crc.Update(buffer, offset, count);
			size += count;
			
			switch (curMethod) {
				case CompressionMethod.Deflated:
					base.Write(buffer, offset, count);
					break;
				
				case CompressionMethod.Stored:
					if (Password != null) {
						CopyAndEncrypt(buffer, offset, count);
					} else {
						baseOutputStream_.Write(buffer, offset, count);
					}
					break;
			}
		}
		
		void CopyAndEncrypt(byte[] buffer, int offset, int count)
		{
			const int CopyBufferSize = 4096;
			byte[] localBuffer = new byte[CopyBufferSize];
			while ( count > 0 ) {
				int bufferCount = (count < CopyBufferSize) ? count : CopyBufferSize;
				
				Array.Copy(buffer, offset, localBuffer, 0, bufferCount);
				EncryptBlock(localBuffer, 0, bufferCount);
				baseOutputStream_.Write(localBuffer, 0, bufferCount);
				count -= bufferCount;
				offset += bufferCount;
			}
		}
		
		
		public override void Finish()
		{
			if (entries == null)  {
				return;
			}
			
			if (curEntry != null) {
				CloseEntry();
			}
			
			long numEntries = entries.Count;
			long sizeEntries = 0;
			
			foreach (ZipEntry entry in entries) {
				WriteLeInt(ZipConstants.CentralHeaderSignature); 
				WriteLeShort(ZipConstants.VersionMadeBy);
				WriteLeShort(entry.Version);
				WriteLeShort(entry.Flags);
				WriteLeShort((short)entry.CompressionMethod);
				WriteLeInt((int)entry.DosTime);
				WriteLeInt((int)entry.Crc);

				if ( entry.IsZip64Forced() || 
					(entry.CompressedSize >= uint.MaxValue) )
				{
					WriteLeInt(-1);
				}
				else {
					WriteLeInt((int)entry.CompressedSize);
				}

				if ( entry.IsZip64Forced() ||
					(entry.Size >= uint.MaxValue) )
				{
					WriteLeInt(-1);
				}
				else {
					WriteLeInt((int)entry.Size);
				}

				byte[] name = ZipConstants.ConvertToArray(entry.Flags, entry.Name);
				
				if (name.Length > 0xffff) {
					throw new ZipException("Name too long.");
				}
				
				ZipExtraData ed = new ZipExtraData(entry.ExtraData);

				if ( entry.CentralHeaderRequiresZip64 ) {
					ed.StartNewEntry();
					if ( entry.IsZip64Forced() ||
						(entry.Size >= 0xffffffff) )
					{
						ed.AddLeLong(entry.Size);
					}

					if ( entry.IsZip64Forced() ||
						(entry.CompressedSize >= 0xffffffff) )
					{
						ed.AddLeLong(entry.CompressedSize);
					}

					if ( entry.Offset >= 0xffffffff )
					{
						ed.AddLeLong(entry.Offset);
					}

					ed.AddNewEntry(1);
				}
				else {
					ed.Delete(1);
				}

				byte[] extra = ed.GetEntryData();
				
				byte[] entryComment = 
					(entry.Comment != null) ? 
					ZipConstants.ConvertToArray(entry.Flags, entry.Comment) :
					new byte[0];

				if (entryComment.Length > 0xffff) {
					throw new ZipException("Comment too long.");
				}
				
				WriteLeShort(name.Length);
				WriteLeShort(extra.Length);
				WriteLeShort(entryComment.Length);
				WriteLeShort(0);	
				WriteLeShort(0);	
								

				if (entry.ExternalFileAttributes != -1) {
					WriteLeInt(entry.ExternalFileAttributes);
				} else {
					if (entry.IsDirectory) {                        
						WriteLeInt(16);
					} else {
						WriteLeInt(0);
					}
				}

				if ( entry.Offset >= uint.MaxValue ) {
					WriteLeInt(-1);
				}
				else {
					WriteLeInt((int)entry.Offset);
				}
				
				if ( name.Length > 0 ) {
					baseOutputStream_.Write(name,    0, name.Length);
				}

				if ( extra.Length > 0 ) {
					baseOutputStream_.Write(extra,   0, extra.Length);
				}

				if ( entryComment.Length > 0 ) {
					baseOutputStream_.Write(entryComment, 0, entryComment.Length);
				}

				sizeEntries += ZipConstants.CentralHeaderBaseSize + name.Length + extra.Length + entryComment.Length;
			}
			
			using ( ZipHelperStream zhs = new ZipHelperStream(baseOutputStream_) ) {
				zhs.WriteEndOfCentralDirectory(numEntries, sizeEntries, offset, zipComment);
			}

			entries = null;
		}
		
		#region Instance Fields
		
		ArrayList entries  = new ArrayList();
		
		
		Crc32 crc = new Crc32();
		
	
		ZipEntry  curEntry;
		
		int defaultCompressionLevel = Deflater.DEFAULT_COMPRESSION;
		
		CompressionMethod curMethod = CompressionMethod.Deflated;

		
		long size;
		
		
		long offset;
		
		
		byte[] zipComment = new byte[0];
		
		
		bool patchEntryHeader;
		
		
		long crcPatchPos = -1;
		
		
		long sizePatchPos = -1;

		UseZip64 useZip64_ = UseZip64.Dynamic;
		#endregion
	}
}
