

using System;
using System.IO;

#if !NETCF_1_0
using System.Security.Cryptography;
#endif

using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Checksums;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams 
{

	public class InflaterInputBuffer
	{
		#region Constructors

		public InflaterInputBuffer(Stream stream) : this(stream , 4096)
		{
		}
		

		public InflaterInputBuffer(Stream stream, int bufferSize)
		{
			inputStream = stream;
			if ( bufferSize < 1024 ) {
				bufferSize = 1024;
			}
			rawData = new byte[bufferSize];
			clearText = rawData;
		}
		#endregion

		public int RawLength
		{
			get { 
				return rawLength; 
			}
		}
		

		public byte[] RawData
		{
			get {
				return rawData;
			}
		}
		

		public int ClearTextLength
		{
			get {
				return clearTextLength;
			}
		}
		

		public byte[] ClearText
		{
			get {
				return clearText;
			}
		}
		

		public int Available
		{
			get { return available; }
			set { available = value; }
		}

		public void SetInflaterInput(Inflater inflater)
		{
			if ( available > 0 ) {
				inflater.SetInput(clearText, clearTextLength - available, available);
				available = 0;
			}
		}

		public void Fill()
		{
			rawLength = 0;
			int toRead = rawData.Length;
			
			while (toRead > 0) {
				int count = inputStream.Read(rawData, rawLength, toRead);
				if ( count <= 0 ) {
					if (rawLength == 0) {
						throw new SharpZipBaseException("Unexpected EOF"); 
					}
					break;
				}
				rawLength += count;
				toRead -= count;
			}
			
#if !NETCF_1_0
			if ( cryptoTransform != null ) {
				clearTextLength = cryptoTransform.TransformBlock(rawData, 0, rawLength, clearText, 0);
			}
			else 
#endif				
			{
				clearTextLength = rawLength;
			}

			available = clearTextLength;
		}
		

		public int ReadRawBuffer(byte[] buffer)
		{
			return ReadRawBuffer(buffer, 0, buffer.Length);
		}


		public int ReadRawBuffer(byte[] outBuffer, int offset, int length)
		{
			if ( length < 0 ) {
				throw new ArgumentOutOfRangeException("length");
			}
			
			int currentOffset = offset;
			int currentLength = length;
			
			while ( currentLength > 0 ) {
				if ( available <= 0 ) {
					Fill();
					if (available <= 0) {
						return 0;
					}
				}
				int toCopy = Math.Min(currentLength, available);
				System.Array.Copy(rawData, rawLength - (int)available, outBuffer, currentOffset, toCopy);
				currentOffset += toCopy;
				currentLength -= toCopy;
				available -= toCopy;
			}
			return length;
		}
		

		public int ReadClearTextBuffer(byte[] outBuffer, int offset, int length)
		{
			if ( length < 0 ) {
				throw new ArgumentOutOfRangeException("length");
			}
			
			int currentOffset = offset;
			int currentLength = length;
			
			while ( currentLength > 0 ) {
				if ( available <= 0 ) {
					Fill();
					if (available <= 0) {
						return 0;
					}
				}
				
				int toCopy = Math.Min(currentLength, available);
				System.Array.Copy(clearText, clearTextLength - (int)available, outBuffer, currentOffset, toCopy);
				currentOffset += toCopy;
				currentLength -= toCopy;
				available -= toCopy;
			}
			return length;
		}
		

		public int ReadLeByte()
		{
			if (available <= 0) {
				Fill();
				if (available <= 0) {
					throw new ZipException("EOF in header");
				}
			}
			byte result = rawData[rawLength - available];
			available -= 1;
			return result;
		}
		

		public int ReadLeShort()
		{
			return ReadLeByte() | (ReadLeByte() << 8);
		}
		

		public int ReadLeInt()
		{
			return ReadLeShort() | (ReadLeShort() << 16);
		}
		

		public long ReadLeLong()
		{
			return (uint)ReadLeInt() | ((long)ReadLeInt() << 32);
		}

#if !NETCF_1_0

		public ICryptoTransform CryptoTransform
		{
			set { 
				cryptoTransform = value;
				if ( cryptoTransform != null ) {
					if ( rawData == clearText ) {
						if ( internalClearText == null ) {
							internalClearText = new byte[rawData.Length];
						}
						clearText = internalClearText;
					}
					clearTextLength = rawLength;
					if ( available > 0 ) {
						cryptoTransform.TransformBlock(rawData, rawLength - available, available, clearText, rawLength - available);
					}
				} else {
					clearText = rawData;
					clearTextLength = rawLength;
				}
			}
		}
#endif

		#region Instance Fields
		int rawLength;
		byte[] rawData;
		
		int clearTextLength;
		byte[] clearText;
#if !NETCF_1_0		
		byte[] internalClearText;
#endif
		
		int available;
		
#if !NETCF_1_0
		ICryptoTransform cryptoTransform;
#endif		
		Stream inputStream;
		#endregion
	}
	

	public class InflaterInputStream : Stream
	{
		#region Constructors

		public InflaterInputStream(Stream baseInputStream)
			: this(baseInputStream, new Inflater(), 4096)
		{
		}
		

		public InflaterInputStream(Stream baseInputStream, Inflater inf)
			: this(baseInputStream, inf, 4096)
		{
		}
		

		public InflaterInputStream(Stream baseInputStream, Inflater inflater, int bufferSize)
		{
			if (baseInputStream == null) {
				throw new ArgumentNullException("baseInputStream");
			}
			
			if (inflater == null) {
				throw new ArgumentNullException("inflater");
			}
			
			if (bufferSize <= 0) {
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			
			this.baseInputStream = baseInputStream;
			this.inf = inflater;
			
			inputBuffer = new InflaterInputBuffer(baseInputStream, bufferSize);
		}
		
		#endregion


		public bool IsStreamOwner
		{
			get { return isStreamOwner; }
			set { isStreamOwner = value; }
		}
		

		public long Skip(long count)
		{
			if (count <= 0) {
				throw new ArgumentOutOfRangeException("count");
			}
			
	
			if (baseInputStream.CanSeek) {
				baseInputStream.Seek(count, SeekOrigin.Current);
				return count;
			} 
			else {
				int length = 2048;
				if (count < length) {
					length = (int) count;
				}

				byte[] tmp = new byte[length];
				int readCount = 1;
				long toSkip = count;

				while ((toSkip > 0) && (readCount > 0) ) {
					if (toSkip < length) {
						length = (int)toSkip;
					}

					readCount = baseInputStream.Read(tmp, 0, length);
					toSkip -= readCount;
				}

				return count - toSkip;
			}
		}
		
	
		protected void StopDecrypting()
		{
#if !NETCF_1_0			
			inputBuffer.CryptoTransform = null;
#endif			
		}


		public virtual int Available 
		{
			get {
				return inf.IsFinished ? 0 : 1;
			}
		}
		

		protected void Fill()
		{
			inputBuffer.Fill();
			inputBuffer.SetInflaterInput(inf);
		}

		#region Stream Overrides

		public override bool CanRead 
		{
			get {
				return baseInputStream.CanRead;
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
				return inputBuffer.RawLength;
			}
		}
		

		public override long Position {
			get {
				return baseInputStream.Position;
			}
			set {
				throw new NotSupportedException("InflaterInputStream Position not supported");
			}
		}
		

		public override void Flush()
		{
			baseInputStream.Flush();
		}
		

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("Seek not supported");
		}
		

		public override void SetLength(long value)
		{
			throw new NotSupportedException("InflaterInputStream SetLength not supported");
		}
		

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("InflaterInputStream Write not supported");
		}
		

		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("InflaterInputStream WriteByte not supported");
		}
		

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("InflaterInputStream BeginWrite not supported");
		}
		

		public override void Close()
		{
			if ( !isClosed ) {
				isClosed = true;
				if ( isStreamOwner ) {
					baseInputStream.Close();
				}
			}
		}


		public override int Read(byte[] buffer, int offset, int count) 
		{
			if (inf.IsNeedingDictionary)
			{
				throw new SharpZipBaseException("Need a dictionary");
			}

			int remainingBytes = count;
			while (true) {
				int bytesRead = inf.Inflate(buffer, offset, remainingBytes); 
				offset += bytesRead;
				remainingBytes -= bytesRead;

				if (remainingBytes == 0 || inf.IsFinished) {
					break; 
				}

				if ( inf.IsNeedingInput ) {
					Fill();
				}
				else if ( bytesRead == 0 ) {
					throw new ZipException("Dont know what to do");
				}
			}
			return count - remainingBytes;
		}
		#endregion
		#region Instance Fields

		protected Inflater inf;


		protected InflaterInputBuffer inputBuffer;


		protected Stream baseInputStream;
		

		protected long csize;


		bool isClosed;


		bool isStreamOwner = true;
		#endregion
	}
}
