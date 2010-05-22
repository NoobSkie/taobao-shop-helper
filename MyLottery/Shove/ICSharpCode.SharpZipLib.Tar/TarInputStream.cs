using System;
using System.IO;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar 
{
	public class TarInputStream : Stream
	{
		#region Constructors
		public TarInputStream(Stream inputStream)
			: this(inputStream, TarBuffer.DefaultBlockFactor)
		{
		}

		public TarInputStream(Stream inputStream, int blockFactor)
		{
			this.inputStream = inputStream;
			this.buffer      = TarBuffer.CreateInputTarBuffer(inputStream, blockFactor);
		}

		#endregion

		#region Stream Overrides

		public override bool CanRead 
		{
			get {
				return inputStream.CanRead;
			}
		}
		

		public override bool CanSeek {
			get {
				return false;
			}
		}
		

		public override bool CanWrite {
			get {
				return false;
			}
		}
		

		public override long Length {
			get {
				return inputStream.Length;
			}
		}
		

		public override long Position {
			get {
				return inputStream.Position;
			}
			set {
				throw new NotSupportedException("TarInputStream Seek not supported");
			}
		}
		

		public override void Flush()
		{
			inputStream.Flush();
		}
		

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("TarInputStream Seek not supported");
		}
		

		public override void SetLength(long value)
		{
			throw new NotSupportedException("TarInputStream SetLength not supported");
		}
		

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("TarInputStream Write not supported");
		}
		

		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("TarInputStream WriteByte not supported");
		}

		public override int ReadByte()
		{
			byte[] oneByteBuffer = new byte[1];
			int num = this.Read(oneByteBuffer, 0, 1);
			if (num <= 0) 
			{
				return -1;
			}
			return (int)oneByteBuffer[0];
		}
		

		public override int Read(byte[] buffer, int offset, int count)
		{
			if ( buffer == null ) 
			{
				throw new ArgumentNullException("buffer");
			}

			int totalRead = 0;
			
			if (this.entryOffset >= this.entrySize) 
			{
				return 0;
			}
			
			long numToRead = count;
			
			if ((numToRead + this.entryOffset) > this.entrySize) 
			{
				numToRead = this.entrySize - this.entryOffset;
			}
			
			if (this.readBuffer != null) 
			{
				int sz = (numToRead > this.readBuffer.Length) ? this.readBuffer.Length : (int)numToRead;
				
				Array.Copy(this.readBuffer, 0, buffer, offset, sz);
				
				if (sz >= this.readBuffer.Length) 
				{
					this.readBuffer = null;
				} 
				else 
				{
					int newLen = this.readBuffer.Length - sz;
					byte[] newBuf = new byte[newLen];
					Array.Copy(this.readBuffer, sz, newBuf, 0, newLen);
					this.readBuffer = newBuf;
				}
				
				totalRead += sz;
				numToRead -= sz;
				offset += sz;
			}
			
			while (numToRead > 0) 
			{
				byte[] rec = this.buffer.ReadBlock();
				if (rec == null) 
				{
					throw new TarException("unexpected EOF with " + numToRead + " bytes unread");
				}
				
				int sz     = (int)numToRead;
				int recLen = rec.Length;
				
				if (recLen > sz) 
				{
					Array.Copy(rec, 0, buffer, offset, sz);
					this.readBuffer = new byte[recLen - sz];
					Array.Copy(rec, sz, this.readBuffer, 0, recLen - sz);
				} 
				else 
				{
					sz = recLen;
					Array.Copy(rec, 0, buffer, offset, recLen);
				}
				
				totalRead += sz;
				numToRead -= sz;
				offset += sz;
			}
			
			this.entryOffset += totalRead;
			
			return totalRead;
		}
		

		public override void Close()
		{
			this.buffer.Close();
		}
		
		#endregion


		public void SetEntryFactory(IEntryFactory factory)
		{
			this.entryFactory = factory;
		}

		public int RecordSize
		{
			get { return buffer.RecordSize; }
		}

		[Obsolete("Use RecordSize property instead")]
		public int GetRecordSize()
		{
			return this.buffer.RecordSize;
		}
		

		public long Available {
			get {
				return this.entrySize - this.entryOffset;
			}
		}
		

		public void Skip(long skipCount)
		{
			byte[] skipBuf = new byte[8 * 1024];
			
			for (long num = skipCount; num > 0;) {
				int toRead = num > skipBuf.Length ? skipBuf.Length : (int)num;
				int numRead = this.Read(skipBuf, 0, toRead);
				
				if (numRead == -1) {
					break;
				}
				
				num -= numRead;
			}
		}
		

		public bool IsMarkSupported {
			get {
				return false;
			}
		}
		

		public void Mark(int markLimit)
		{
		}
		

		public void Reset()
		{
		}
		

		public TarEntry GetNextEntry()
		{
			if (this.hasHitEOF) {
				return null;
			}
			
			if (this.currentEntry != null) {
				SkipToNextEntry();
			}
			
			byte[] headerBuf = this.buffer.ReadBlock();
			
			if (headerBuf == null) {
				this.hasHitEOF = true;
			} else if (TarBuffer.IsEndOfArchiveBlock(headerBuf)) {
				this.hasHitEOF = true;
			}
			
			if (this.hasHitEOF) {
				this.currentEntry = null;
			} else {
				try {
					TarHeader header = new TarHeader();
					header.ParseBuffer(headerBuf);
					if ( !header.IsChecksumValid )
					{
						throw new TarException("Header checksum is invalid");
					}
					this.entryOffset = 0;
					this.entrySize = header.Size;
					
					StringBuilder longName = null;
					
					if (header.TypeFlag == TarHeader.LF_GNU_LONGNAME) {
						
						byte[] nameBuffer = new byte[TarBuffer.BlockSize];
						long numToRead = this.entrySize;
						
						longName = new StringBuilder();
						
						while (numToRead > 0) {
							int numRead = this.Read(nameBuffer, 0, (numToRead > nameBuffer.Length ? nameBuffer.Length : (int)numToRead));
							
							if (numRead == -1) {
								throw new InvalidHeaderException("Failed to read long name entry");
							}
							
							longName.Append(TarHeader.ParseName(nameBuffer, 0, numRead).ToString());
							numToRead -= numRead;
						}
						
						SkipToNextEntry();
						headerBuf = this.buffer.ReadBlock();
					} else if (header.TypeFlag == TarHeader.LF_GHDR) {  
		
						SkipToNextEntry();
						headerBuf = this.buffer.ReadBlock();
					} else if (header.TypeFlag == TarHeader.LF_XHDR) {  

						SkipToNextEntry();
						headerBuf = this.buffer.ReadBlock();
					} else if (header.TypeFlag == TarHeader.LF_GNU_VOLHDR) {

						SkipToNextEntry();
						headerBuf = this.buffer.ReadBlock();
					} else if (header.TypeFlag != TarHeader.LF_NORMAL && 
							   header.TypeFlag != TarHeader.LF_OLDNORM &&
							   header.TypeFlag != TarHeader.LF_DIR) {

						SkipToNextEntry();
						headerBuf = this.buffer.ReadBlock();
					}
					
					if (this.entryFactory == null) {
						this.currentEntry = new TarEntry(headerBuf);
						if (longName != null) {
							currentEntry.Name = longName.ToString();
						}
					} else {
						this.currentEntry = this.entryFactory.CreateEntry(headerBuf);
					}
		
					
					this.entryOffset = 0;
	
					this.entrySize = this.currentEntry.Size;
				} catch (InvalidHeaderException ex) {
					this.entrySize = 0;
					this.entryOffset = 0;
					this.currentEntry = null;
					string errorText = string.Format("Bad header in record {0} block {1} {2}",
						buffer.CurrentRecord, buffer.CurrentBlock, ex.Message);
					throw new InvalidHeaderException(errorText);
				}
			}
			return this.currentEntry;
		}
		

		public void CopyEntryContents(Stream outputStream)
		{
			byte[] tempBuffer = new byte[32 * 1024];
			
			while (true) {
				int numRead = this.Read(tempBuffer, 0, tempBuffer.Length);
				if (numRead <= 0) {
					break;
				}
				outputStream.Write(tempBuffer, 0, numRead);
			}
		}

		void SkipToNextEntry()
		{
			long numToSkip = this.entrySize - this.entryOffset;
			
			if (numToSkip > 0) 
			{
				this.Skip(numToSkip);
			}
			
			this.readBuffer = null;
		}
		

		public interface IEntryFactory
		{

			TarEntry CreateEntry(string name);
			

			TarEntry CreateEntryFromFile(string fileName);
			

			TarEntry CreateEntry(byte[] headerBuffer);
		}


		public class EntryFactoryAdapter : IEntryFactory
		{
			public TarEntry CreateEntry(string name)
			{
				return TarEntry.CreateTarEntry(name);
			}
			

			public TarEntry CreateEntryFromFile(string fileName)
			{
				return TarEntry.CreateEntryFromFile(fileName);
			}


			public TarEntry CreateEntry(byte[] headerBuffer)
			{
				return new TarEntry(headerBuffer);
			}
		}

		#region Instance Fields

		protected bool hasHitEOF;
		
		protected long entrySize;

		protected long entryOffset;
		
		protected byte[] readBuffer;

		protected TarBuffer buffer;

		TarEntry  currentEntry;

		protected IEntryFactory entryFactory;

		Stream inputStream;
		#endregion
	}
}
	
