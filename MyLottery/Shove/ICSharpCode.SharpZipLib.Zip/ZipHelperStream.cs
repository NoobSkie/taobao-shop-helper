using System;
using System.IO;
using System.Text;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class DescriptorData
	{
		public long CompressedSize
		{
			get { return compressedSize; }
			set { compressedSize = value; }
		}

		public long Size
		{
			get { return size; }
			set { size = value; }
		}

		public long Crc
		{
			get { return crc; }
			set { crc = (value & 0xffffffff); }
		}

		#region Instance Fields
		long size;
		long compressedSize;
		long crc;
		#endregion
	}

	class EntryPatchData
	{
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
		
		#region Instance Fields
		long sizePatchOffset_;
		long crcPatchOffset_;
		#endregion
	}
	

	internal class ZipHelperStream : Stream
	{
		#region Constructors
		public ZipHelperStream(string name)
		{
			stream_ = new FileStream(name, FileMode.Open, FileAccess.ReadWrite);
			isOwner_ = true;
		}

		public ZipHelperStream(Stream stream)
		{
			stream_ = stream;
		}
		#endregion

		public bool IsStreamOwner
		{
			get { return isOwner_; }
			set { isOwner_ = value; }
		}

		#region Base Stream Methods
		public override bool CanRead
		{
			get { return stream_.CanRead; }
		}

		public override bool CanSeek
		{
			get { return stream_.CanSeek; }
		}

#if !NET_1_0 && !NET_1_1 && !NETCF_1_0
		public override bool CanTimeout
		{
			get { return stream_.CanTimeout; }
		}
#endif

		public override long Length
		{
			get { return stream_.Length; }
		}

		public override long Position
		{
			get { return stream_.Position; }
			set { stream_.Position = value;	}
		}

		public override bool CanWrite
		{
			get { return stream_.CanWrite; }
		}

		public override void Flush()
		{
			stream_.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return stream_.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			stream_.SetLength(value);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return stream_.Read(buffer, offset, count);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			stream_.Write(buffer, offset, count);
		}


		override public void Close()
		{
			Stream toClose = stream_;
			stream_ = null;
			if (isOwner_ && (toClose != null))
			{
				isOwner_ = false;
				toClose.Close();
			}
		}
		#endregion
		

		void WriteLocalHeader(ZipEntry entry, EntryPatchData patchData) 
		{
			CompressionMethod method = entry.CompressionMethod;
			bool headerInfoAvailable = true; 
			bool patchEntryHeader = false;

			WriteLEInt(ZipConstants.LocalHeaderSignature);
			
			WriteLEShort(entry.Version);
			WriteLEShort(entry.Flags);
			WriteLEShort((byte)method);
			WriteLEInt((int)entry.DosTime);

			if (headerInfoAvailable == true) {
				WriteLEInt((int)entry.Crc);
				if ( entry.LocalHeaderRequiresZip64 ) {
					WriteLEInt(-1);
					WriteLEInt(-1);
				}
				else {
					WriteLEInt(entry.IsCrypted ? (int)entry.CompressedSize + ZipConstants.CryptoHeaderSize : (int)entry.CompressedSize);
					WriteLEInt((int)entry.Size);
				}
			} else {
				if (patchData != null) {
					patchData.CrcPatchOffset = stream_.Position;
				}
				WriteLEInt(0);	
				
				if ( patchData != null ) {
					patchData.SizePatchOffset = stream_.Position;
				}

				if ( entry.LocalHeaderRequiresZip64 && patchEntryHeader ) {
					WriteLEInt(-1);
					WriteLEInt(-1);
				}
				else {
					WriteLEInt(0);	
					WriteLEInt(0);	
				}
			}

			byte[] name = ZipConstants.ConvertToArray(entry.Flags, entry.Name);
			
			if (name.Length > 0xFFFF) {
				throw new ZipException("Entry name too long.");
			}

			ZipExtraData ed = new ZipExtraData(entry.ExtraData);

			if (entry.LocalHeaderRequiresZip64 && (headerInfoAvailable || patchEntryHeader)) {
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
				
				if ( patchData != null ) {
					patchData.SizePatchOffset = ed.CurrentReadIndex;
				}
			}
			else {
				ed.Delete(1);
			}
			
			byte[] extra = ed.GetEntryData();

			WriteLEShort(name.Length);
			WriteLEShort(extra.Length);

			if ( name.Length > 0 ) {
				stream_.Write(name, 0, name.Length);
			}
			
			if ( entry.LocalHeaderRequiresZip64 && patchEntryHeader ) {
				patchData.SizePatchOffset += stream_.Position;
			}

			if ( extra.Length > 0 ) {
				stream_.Write(extra, 0, extra.Length);
			}
		}
	

		public long LocateBlockWithSignature(int signature, long endLocation, int minimumBlockSize, int maximumVariableData)
		{
			long pos = endLocation - minimumBlockSize;
			if ( pos < 0 ) {
				return -1;
			}

			long giveUpMarker = Math.Max(pos - maximumVariableData, 0);

			do {
				if ( pos < giveUpMarker ) {
					return -1;
				}
				Seek(pos--, SeekOrigin.Begin);
			} while ( ReadLEInt() != signature );

			return Position;
		}


		public void WriteZip64EndOfCentralDirectory(long noOfEntries, long sizeEntries, long centralDirOffset)
		{
			long centralSignatureOffset = stream_.Position;
			WriteLEInt(ZipConstants.Zip64CentralFileHeaderSignature);
			WriteLELong(44);    
			WriteLEShort(ZipConstants.VersionMadeBy);   
			WriteLEShort(ZipConstants.VersionZip64);  
			WriteLEInt(0);     
			WriteLEInt(0);      
			WriteLELong(noOfEntries);      
			WriteLELong(noOfEntries);     
			WriteLELong(sizeEntries);       
			WriteLELong(centralDirOffset);  
			
			WriteLEInt(ZipConstants.Zip64CentralDirLocatorSignature);
	
			WriteLEInt(0);

			WriteLELong(centralSignatureOffset);

			WriteLEInt(1);
		}

		
		public void WriteEndOfCentralDirectory(long noOfEntries, long sizeEntries,
			long startOfCentralDirectory, byte[] comment)
		{

			if ( (noOfEntries >= 0xffff) ||
				(startOfCentralDirectory >= 0xffffffff) ||
				(sizeEntries >= 0xffffffff) ) {
				WriteZip64EndOfCentralDirectory(noOfEntries, sizeEntries, startOfCentralDirectory);
			}

			WriteLEInt(ZipConstants.EndOfCentralDirectorySignature);

			
			WriteLEShort(0);                  
			WriteLEShort(0);                 

			
			
			if ( noOfEntries >= 0xffff ) {
				WriteLEUshort(0xffff);  
				WriteLEUshort(0xffff);
			}
			else {
				WriteLEShort(( short )noOfEntries);          
				WriteLEShort(( short )noOfEntries);         
			}


			if ( sizeEntries >= 0xffffffff ) {
				WriteLEUint(0xffffffff);    
			}
			else {
				WriteLEInt(( int )sizeEntries);            
			}



			if ( startOfCentralDirectory >= 0xffffffff ) {
				WriteLEUint(0xffffffff);    
			}
			else {
				WriteLEInt(( int )startOfCentralDirectory);
			}

			int commentLength = (comment != null) ? comment.Length : 0;

			if ( commentLength > 0xffff ) {
				throw new ZipException(string.Format("Comment length({0}) is too long can only be 64K", commentLength));
			}

			WriteLEShort(commentLength);

			if ( commentLength > 0 ) {
				Write(comment, 0, comment.Length);
			}
		}

		#region LE value reading/writing

		public int ReadLEShort()
		{
			int byteValue1 = stream_.ReadByte();

			if (byteValue1 < 0) {
				throw new EndOfStreamException();
			}

			int byteValue2 = stream_.ReadByte();
			if (byteValue2 < 0) {
				throw new EndOfStreamException();
			}

			return byteValue1 | (byteValue2 << 8);
		}


		public int ReadLEInt()
		{
			return ReadLEShort() | (ReadLEShort() << 16);
		}


		public long ReadLELong()
		{
			return (uint)ReadLEInt() | ((long)ReadLEInt() << 32);
		}

	
		public void WriteLEShort(int value)
		{
			stream_.WriteByte(( byte )(value & 0xff));
			stream_.WriteByte(( byte )((value >> 8) & 0xff));
		}

		public void WriteLEUshort(ushort value)
		{
			stream_.WriteByte(( byte )(value & 0xff));
			stream_.WriteByte(( byte )(value >> 8));
		}


		public void WriteLEInt(int value)
		{
			WriteLEShort(value);
			WriteLEShort(value >> 16);
		}


		public void WriteLEUint(uint value)
		{
			WriteLEUshort(( ushort )(value & 0xffff));
			WriteLEUshort(( ushort )(value >> 16));
		}


		public void WriteLELong(long value)
		{
			WriteLEInt(( int )value);
			WriteLEInt(( int )(value >> 32));
		}


		public void WriteLEUlong(ulong value)
		{
			WriteLEUint(( uint )(value & 0xffffffff));
			WriteLEUint(( uint )(value >> 32));
		}

		#endregion


		public int WriteDataDescriptor(ZipEntry entry)
		{
			if (entry == null) {
				throw new ArgumentNullException("entry");
			}

			int result=0;

			if ((entry.Flags & (int)GeneralBitFlags.Descriptor) != 0)
			{
				WriteLEInt(ZipConstants.DataDescriptorSignature);
				WriteLEInt(unchecked((int)(entry.Crc)));

				result+=8;

				if (entry.LocalHeaderRequiresZip64)
				{
					WriteLELong(entry.CompressedSize);
					WriteLELong(entry.Size);
					result+=16;
				}
				else
				{
					WriteLEInt((int)entry.CompressedSize);
					WriteLEInt((int)entry.Size);
					result+=8;
				}
			}

			return result;
		}


		public void ReadDataDescriptor(bool zip64, DescriptorData data)
		{
			int intValue = ReadLEInt();


			if (intValue != ZipConstants.DataDescriptorSignature) {
				throw new ZipException("Data descriptor signature not found");
			}

			data.Crc = ReadLEInt();
			
			if (zip64) {
				data.CompressedSize = ReadLELong();
				data.Size = ReadLELong();
			}
			else {
				data.CompressedSize = ReadLEInt();
				data.Size = ReadLEInt();
			}
		}

		#region Instance Fields
		bool isOwner_;
		Stream stream_;
		#endregion
	}
}
