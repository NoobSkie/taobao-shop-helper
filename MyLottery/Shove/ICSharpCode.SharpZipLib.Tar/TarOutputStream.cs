using System;
using System.IO;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar 
{
	public class TarOutputStream : Stream
	{
		#region Constructors
		public TarOutputStream(Stream outputStream)
			: this(outputStream, TarBuffer.DefaultBlockFactor)
		{
		}
		

		public TarOutputStream(Stream outputStream, int blockFactor)
		{
			if ( outputStream == null )
			{
				throw new ArgumentNullException("outputStream");
			}

			this.outputStream = outputStream;
			buffer = TarBuffer.CreateOutputTarBuffer(outputStream, blockFactor);
			
			assemblyBuffer = new byte[TarBuffer.BlockSize];
			blockBuffer  = new byte[TarBuffer.BlockSize];
		}
		#endregion		


		public override bool CanRead 
		{
			get 
			{
				return outputStream.CanRead;
			}
		}
		

		public override bool CanSeek 
		{
			get 
			{
				return outputStream.CanSeek;
			}
		}
		

		public override bool CanWrite 
		{
			get 
			{
				return outputStream.CanWrite;
			}
		}
		

		public override long Length 
		{
			get 
			{
				return outputStream.Length;
			}
		}
		
	
		public override long Position 
		{
			get 
			{
				return outputStream.Position;
			}
			set 
			{
				outputStream.Position = value;
			}
		}
		

		public override long Seek(long offset, SeekOrigin origin)
		{
			return outputStream.Seek(offset, origin);
		}
		

		public override void SetLength(long value)
		{
			outputStream.SetLength(value);
		}
		

		public override int ReadByte()
		{
			return outputStream.ReadByte();
		}
		

		public override int Read(byte[] buffer, int offset, int count)
		{
			return outputStream.Read(buffer, offset, count);
		}

	
		public override void Flush()
		{
			outputStream.Flush();
		}
				

		public void Finish()
		{
			if ( IsEntryOpen ) 
			{
				CloseEntry();
			}
			WriteEofBlock();
		}
		

		public override void Close()
		{
			if ( !isClosed )
			{
				isClosed = true;
				Finish();
				buffer.Close();
			}
		}
		

		public int RecordSize
		{
			get { return buffer.RecordSize; }
		}


		[Obsolete("Use RecordSize property instead")]
		public int GetRecordSize()
		{
			return buffer.RecordSize;
		}
		

		bool IsEntryOpen
		{
			get { return (currBytes < currSize); }

		}


		public void PutNextEntry(TarEntry entry)
		{
			if ( entry == null ) {
				throw new ArgumentNullException("entry");
			}

			if (entry.TarHeader.Name.Length >= TarHeader.NAMELEN) {
				TarHeader longHeader = new TarHeader();
				longHeader.TypeFlag = TarHeader.LF_GNU_LONGNAME;
				longHeader.Name = longHeader.Name + "././@LongLink";
				longHeader.UserId = 0;
				longHeader.GroupId = 0;
				longHeader.GroupName = "";
				longHeader.UserName = "";
				longHeader.LinkName = "";
                longHeader.Size = entry.TarHeader.Name.Length;

				longHeader.WriteHeader(this.blockBuffer);
				this.buffer.WriteBlock(this.blockBuffer);

				int nameCharIndex = 0;

				while (nameCharIndex < entry.TarHeader.Name.Length) {
					Array.Clear(blockBuffer, 0, blockBuffer.Length);
					TarHeader.GetAsciiBytes(entry.TarHeader.Name, nameCharIndex, this.blockBuffer, 0, TarBuffer.BlockSize);
					nameCharIndex += TarBuffer.BlockSize;
					buffer.WriteBlock(blockBuffer);
				}
			}
			
			entry.WriteEntryHeader(blockBuffer);
			buffer.WriteBlock(blockBuffer);
			
			currBytes = 0;
			
			currSize = entry.IsDirectory ? 0 : entry.Size;
		}
		
		
		public void CloseEntry()
		{
			if (assemblyBufferLength > 0) {
				Array.Clear(assemblyBuffer, assemblyBufferLength, assemblyBuffer.Length - assemblyBufferLength);
				
				buffer.WriteBlock(assemblyBuffer);
				
				currBytes += assemblyBufferLength;
				assemblyBufferLength = 0;
			}
			
			if (currBytes < currSize) {
				string errorText = string.Format(
					"Entry closed at '{0}' before the '{1}' bytes specified in the header were written",
					currBytes, currSize);
				throw new TarException(errorText);
			}
		}
		
	
		public override void WriteByte(byte value)
		{
			Write(new byte[] { value }, 0, 1);
		}
		
		
		public override void Write(byte[] buffer, int offset, int count)
		{
			if ( buffer == null ) {
				throw new ArgumentNullException("buffer");
			}
			
			if ( offset < 0 )
			{
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("offset");
#else
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
#endif				
			}

			if ( buffer.Length - offset < count )
			{
				throw new ArgumentException("offset and count combination is invalid");
			}

			if ( count < 0 )
			{
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("count");
#else
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
#endif
			}

			if ( (currBytes + count) > currSize ) {
				string errorText = string.Format("request to write '{0}' bytes exceeds size in header of '{1}' bytes",
					count, this.currSize);
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("count");
#else
				throw new ArgumentOutOfRangeException("count", errorText);
#endif				
			}

			if (assemblyBufferLength > 0) {
				if ((assemblyBufferLength + count ) >= blockBuffer.Length) {
					int aLen = blockBuffer.Length - assemblyBufferLength;
					
					Array.Copy(assemblyBuffer, 0, blockBuffer, 0, assemblyBufferLength);
					Array.Copy(buffer, offset, blockBuffer, assemblyBufferLength, aLen);
					
					this.buffer.WriteBlock(blockBuffer);
					
					currBytes += blockBuffer.Length;
					
					offset    += aLen;
					count -= aLen;
					
					assemblyBufferLength = 0;
				} else {
					Array.Copy(buffer, offset, assemblyBuffer, assemblyBufferLength, count);
					offset += count;
					assemblyBufferLength += count;
					count -= count;
				}
			}
			

			while (count > 0) {
				if (count < blockBuffer.Length) {
					Array.Copy(buffer, offset, assemblyBuffer, assemblyBufferLength, count);
					assemblyBufferLength += count;
					break;
				}
				
				this.buffer.WriteBlock(buffer, offset);
				
				int bufferLength = blockBuffer.Length;
				currBytes += bufferLength;
				count -= bufferLength;
				offset += bufferLength;
			}
		}
		

		void WriteEofBlock()
		{
			Array.Clear(blockBuffer, 0, blockBuffer.Length);
			buffer.WriteBlock(blockBuffer);
		}

		#region Instance Fields

		long currBytes;
		

		int assemblyBufferLength;


		bool isClosed;


		protected long currSize;

		protected byte[] blockBuffer;


		protected byte[] assemblyBuffer;
		
	
		protected TarBuffer buffer;
		

		protected Stream outputStream;
		#endregion
	}
}
