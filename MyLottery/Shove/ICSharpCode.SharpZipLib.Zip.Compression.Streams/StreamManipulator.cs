
using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams 
{
	public class StreamManipulator
	{
		#region Constructors

		public StreamManipulator()
		{
		}
		#endregion


		public int PeekBits(int bitCount)
		{
			if (bitsInBuffer_ < bitCount) {
				if (windowStart_ == windowEnd_) {
					return -1; 
				}
				buffer_ |= (uint)((window_[windowStart_++] & 0xff |
								 (window_[windowStart_++] & 0xff) << 8) << bitsInBuffer_);
				bitsInBuffer_ += 16;
			}
			return (int)(buffer_ & ((1 << bitCount) - 1));
		}
		

		public void DropBits(int bitCount)
		{
			buffer_ >>= bitCount;
			bitsInBuffer_ -= bitCount;
		}
		

		public int GetBits(int bitCount)
		{
			int bits = PeekBits(bitCount);
			if (bits >= 0) {
				DropBits(bitCount);
			}
			return bits;
		}
		

		public int AvailableBits {
			get {
				return bitsInBuffer_;
			}
		}
		

		public int AvailableBytes {
			get {
				return windowEnd_ - windowStart_ + (bitsInBuffer_ >> 3);
			}
		}
		

		public void SkipToByteBoundary()
		{
			buffer_ >>= (bitsInBuffer_ & 7);
			bitsInBuffer_ &= ~7;
		}

		public bool IsNeedingInput {
			get {
				return windowStart_ == windowEnd_;
			}
		}
		

		public int CopyBytes(byte[] output, int offset, int length)
		{
			if (length < 0) {
				throw new ArgumentOutOfRangeException("length");
			}

			if ((bitsInBuffer_ & 7) != 0) {
				
				throw new InvalidOperationException("Bit buffer is not byte aligned!");
			}
			
			int count = 0;
			while ((bitsInBuffer_ > 0) && (length > 0)) {
				output[offset++] = (byte) buffer_;
				buffer_ >>= 8;
				bitsInBuffer_ -= 8;
				length--;
				count++;
			}
			
			if (length == 0) {
				return count;
			}
			
			int avail = windowEnd_ - windowStart_;
			if (length > avail) {
				length = avail;
			}
			System.Array.Copy(window_, windowStart_, output, offset, length);
			windowStart_ += length;
			
			if (((windowStart_ - windowEnd_) & 1) != 0) {
				
				buffer_ = (uint)(window_[windowStart_++] & 0xff);
				bitsInBuffer_ = 8;
			}
			return count + length;
		}
		

		public void Reset()
		{
			buffer_ = 0;
			windowStart_ = windowEnd_ = bitsInBuffer_ = 0;
		}


		public void SetInput(byte[] buffer, int offset, int count)
		{
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

			if (windowStart_ < windowEnd_) {
				throw new InvalidOperationException("Old input was not completely processed");
			}
			
			int end = offset + count;
			

			if ((offset > end) || (end > buffer.Length) ) {
				throw new ArgumentOutOfRangeException("count");
			}
			
			if ((count & 1) != 0) {

				buffer_ |= (uint)((buffer[offset++] & 0xff) << bitsInBuffer_);
				bitsInBuffer_ += 8;
			}
			
			window_ = buffer;
			windowStart_ = offset;
			windowEnd_ = end;
		}

		#region Instance Fields
		private byte[] window_;
		private int windowStart_;
		private int windowEnd_;

		private uint buffer_;
		private int bitsInBuffer_;
		#endregion
	}
}
