using System;
using System.IO;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar 
{
	public class TarBuffer
	{
		#region Constants
		
		public const int BlockSize = 512;
		
	
		public const int DefaultBlockFactor = 20;
		
		
		public const int DefaultRecordSize = BlockSize * DefaultBlockFactor;
		#endregion

		public int RecordSize 
		{
			get { 
				return recordSize; 
			}
		}

		
		[Obsolete("Use RecordSize property instead")]
		public int GetRecordSize()
		{
			return recordSize;
		}

		public int BlockFactor {
			get { 
				return blockFactor; 
			}
		}

		
		[Obsolete("Use BlockFactor property instead")]
		public int GetBlockFactor()
		{
			return this.blockFactor;
		}
		
		
		protected TarBuffer()
		{
		}
		
		
		public static TarBuffer CreateInputTarBuffer(Stream inputStream)
		{
			if ( inputStream == null )
			{
				throw new ArgumentNullException("inputStream");
			}

			return CreateInputTarBuffer(inputStream, TarBuffer.DefaultBlockFactor);
		}

		
		public static TarBuffer CreateInputTarBuffer(Stream inputStream, int blockFactor)
		{
			if ( inputStream == null )
			{
				throw new ArgumentNullException("inputStream");
			}
			
			if ( blockFactor <= 0 )
			{
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("blockFactor");
#else
				throw new ArgumentOutOfRangeException("blockFactor", "Factor cannot be negative");
#endif				
			}

			TarBuffer tarBuffer = new TarBuffer();
			tarBuffer.inputStream  = inputStream;
			tarBuffer.outputStream = null;
			tarBuffer.Initialize(blockFactor);
			
			return tarBuffer;
		}

		
		public static TarBuffer CreateOutputTarBuffer(Stream outputStream)
		{
			if ( outputStream == null )
			{
				throw new ArgumentNullException("outputStream");
			}

			return CreateOutputTarBuffer(outputStream, TarBuffer.DefaultBlockFactor);
		}

		
		public static TarBuffer CreateOutputTarBuffer(Stream outputStream, int blockFactor)
		{
			if ( outputStream == null )
			{
				throw new ArgumentNullException("outputStream");
			}

			if ( blockFactor <= 0 )
			{
#if NETCF_1_0
				throw new ArgumentOutOfRangeException("blockFactor");
#else
				throw new ArgumentOutOfRangeException("blockFactor", "Factor cannot be negative");
#endif				
			}

			TarBuffer tarBuffer = new TarBuffer();
			tarBuffer.inputStream  = null;
			tarBuffer.outputStream = outputStream;
			tarBuffer.Initialize(blockFactor);
			
			return tarBuffer;
		}
		
	
		void Initialize(int blockFactor)
		{
			this.blockFactor  = blockFactor;
			recordSize   = blockFactor * BlockSize;
			recordBuffer  = new byte[RecordSize];
			
			if (inputStream != null) {
				currentRecordIndex = -1;
				currentBlockIndex = BlockFactor;
			}
			else {
				currentRecordIndex = 0;
				currentBlockIndex = 0;
			}
		}
		
		
		[Obsolete("Use IsEndOfArchiveBlock instead")]
		public bool IsEOFBlock(byte[] block)
		{
			if ( block == null ) {
				throw new ArgumentNullException("block");
			}

			if ( block.Length != BlockSize ) 
			{
				throw new ArgumentException("block length is invalid");
			}

			for (int i = 0; i < BlockSize; ++i) {
				if (block[i] != 0) {
					return false;
				}
			}
			
			return true;
		}


	
		public static bool IsEndOfArchiveBlock(byte[] block)
		{
			if ( block == null ) {
				throw new ArgumentNullException("block");
			}

			if ( block.Length != BlockSize ) {
				throw new ArgumentException("block length is invalid");
			}

			for ( int i = 0; i < BlockSize; ++i ) {
				if ( block[i] != 0 ) {
					return false;
				}
			}

			return true;
		}
		
		
		public void SkipBlock()
		{
			if (this.inputStream == null) {
				throw new TarException("no input stream defined");
			}
			
			if (currentBlockIndex >= BlockFactor) {
				if (!ReadRecord()) {
					throw new TarException("Failed to read a record");
				}
			}
			
			currentBlockIndex++;
		}
		
		
		public byte[] ReadBlock()
		{
			if (inputStream == null) {
				throw new TarException("TarBuffer.ReadBlock - no input stream defined");
			}
			
			if (currentBlockIndex >= BlockFactor) {
				if (!ReadRecord()) {
					throw new TarException("Failed to read a record");
				}
			}
			
			byte[] result = new byte[BlockSize];
			
			Array.Copy(recordBuffer, (currentBlockIndex * BlockSize), result, 0, BlockSize );
			currentBlockIndex++;
			return result;
		}
		
		
		bool ReadRecord()
		{
			if (inputStream == null) {
				throw new TarException("no input stream stream defined");
			}
						
			currentBlockIndex = 0;
			
			int offset = 0;
			int bytesNeeded = RecordSize;

			while (bytesNeeded > 0) {
				long numBytes = inputStream.Read(recordBuffer, offset, bytesNeeded);
				
				
				if (numBytes <= 0) {
					break;
				}
				
				offset      += (int)numBytes;
				bytesNeeded -= (int)numBytes;
			}
			
			currentRecordIndex++;
			return true;
		}
		
		
		public int CurrentBlock
		{
			get { return currentBlockIndex; }
		}

		
		[Obsolete("Use CurrentBlock property instead")]
		public int GetCurrentBlockNum()
		{
			return this.currentBlockIndex;
		}
		
		
		public int CurrentRecord
		{
			get { return currentRecordIndex; }
		}

		
		[Obsolete("Use CurrentRecord property instead")]
		public int GetCurrentRecordNum()
		{
			return this.currentRecordIndex;
		}
		
		
		public void WriteBlock(byte[] block)
		{
			if ( block == null ) {
				throw new ArgumentNullException("block");
			}

			if (outputStream == null) {
				throw new TarException("TarBuffer.WriteBlock - no output stream defined");
			}
						
			if (block.Length != BlockSize) {
				string errorText = string.Format("TarBuffer.WriteBlock - block to write has length '{0}' which is not the block size of '{1}'",
					block.Length, BlockSize );
				throw new TarException(errorText);
			}
			
			if (currentBlockIndex >= BlockFactor) {
				WriteRecord();
			}

			Array.Copy(block, 0, recordBuffer, (currentBlockIndex * BlockSize), BlockSize);
			currentBlockIndex++;
		}
		
		
		public void WriteBlock(byte[] buffer, int offset)
		{
			if ( buffer == null ) {
				throw new ArgumentNullException("buffer");
			}

			if (outputStream == null) {
				throw new TarException("TarBuffer.WriteBlock - no output stream stream defined");
			}
						
			if ( (offset < 0) || (offset >= buffer.Length) )
			{
				throw new ArgumentOutOfRangeException("offset");
			}

			if ((offset + BlockSize) > buffer.Length) {
				string errorText = string.Format("TarBuffer.WriteBlock - record has length '{0}' with offset '{1}' which is less than the record size of '{2}'",
					buffer.Length, offset, this.recordSize);
				throw new TarException(errorText);
			}
			
			if (currentBlockIndex >= BlockFactor) {
				WriteRecord();
			}
			
			Array.Copy(buffer, offset, recordBuffer, (currentBlockIndex * BlockSize), BlockSize);
			
			currentBlockIndex++;
		}
		
		
		void WriteRecord()
		{
			if (outputStream == null)
			{
				throw new TarException("TarBuffer.WriteRecord no output stream defined");
			}
			
			outputStream.Write(recordBuffer, 0, RecordSize);
			outputStream.Flush();
			
			currentBlockIndex = 0;
			currentRecordIndex++;
		}
		
		
		void Flush()
		{
			if (outputStream == null) 
			{
				throw new TarException("TarBuffer.Flush no output stream defined");
			}
			
			if (currentBlockIndex > 0) 
			{
				int dataBytes = currentBlockIndex * BlockSize;
				Array.Clear(recordBuffer, dataBytes, RecordSize - dataBytes);
				WriteRecord();
			}

			outputStream.Flush();
		}
		
		
		public void Close()
		{
			if (outputStream != null)
			{
				Flush();
	
				outputStream.Close();
				outputStream = null;
			}
			else if (inputStream != null)
			{
				inputStream.Close();
				inputStream = null;
			}
		}

		#region Instance Fields
		Stream inputStream;
		Stream outputStream;
		
		byte[] recordBuffer;
		int currentBlockIndex;
		int currentRecordIndex;

		int recordSize = DefaultRecordSize;
		int blockFactor = DefaultBlockFactor;
		#endregion
	}
}
