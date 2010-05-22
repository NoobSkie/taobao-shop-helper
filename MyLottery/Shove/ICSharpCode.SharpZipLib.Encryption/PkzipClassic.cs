


#if !NETCF_1_0

using System;
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.Checksums;

namespace ICSharpCode.SharpZipLib.Encryption
{
	
	public abstract class PkzipClassic : SymmetricAlgorithm
	{
		static public byte[] GenerateKeys(byte[] seed)
		{
			if ( seed == null ) {
				throw new ArgumentNullException("seed");
			}

			if ( seed.Length == 0 ) {
				throw new ArgumentException("Length is zero", "seed");
			}

			uint[] newKeys = new uint[] {
				0x12345678,
				0x23456789,
				0x34567890
			 };
			
			for (int i = 0; i < seed.Length; ++i) {
				newKeys[0] = Crc32.ComputeCrc32(newKeys[0], seed[i]);
				newKeys[1] = newKeys[1] + (byte)newKeys[0];
				newKeys[1] = newKeys[1] * 134775813 + 1;
				newKeys[2] = Crc32.ComputeCrc32(newKeys[2], (byte)(newKeys[1] >> 24));
			}

			byte[] result = new byte[12];
			result[0] = (byte)(newKeys[0] & 0xff);
			result[1] = (byte)((newKeys[0] >> 8) & 0xff);
			result[2] = (byte)((newKeys[0] >> 16) & 0xff);
			result[3] = (byte)((newKeys[0] >> 24) & 0xff);
			result[4] = (byte)(newKeys[1] & 0xff);
			result[5] = (byte)((newKeys[1] >> 8) & 0xff);
			result[6] = (byte)((newKeys[1] >> 16) & 0xff);
			result[7] = (byte)((newKeys[1] >> 24) & 0xff);
			result[8] = (byte)(newKeys[2] & 0xff);
			result[9] = (byte)((newKeys[2] >> 8) & 0xff);
			result[10] = (byte)((newKeys[2] >> 16) & 0xff);
			result[11] = (byte)((newKeys[2] >> 24) & 0xff);
			return result;
		}
	}

	
	class PkzipClassicCryptoBase
	{
		protected byte TransformByte()
		{
			uint temp = ((keys[2] & 0xFFFF) | 2);
			return (byte)((temp * (temp ^ 1)) >> 8);
		}

		protected void SetKeys(byte[] keyData)
		{
			if ( keyData == null ) {
				throw new ArgumentNullException("keyData");
			}
		
			if ( keyData.Length != 12 ) {
				throw new InvalidOperationException("Key length is not valid");
			}
			
			keys = new uint[3];
			keys[0] = (uint)((keyData[3] << 24) | (keyData[2] << 16) | (keyData[1] << 8) | keyData[0]);
			keys[1] = (uint)((keyData[7] << 24) | (keyData[6] << 16) | (keyData[5] << 8) | keyData[4]);
			keys[2] = (uint)((keyData[11] << 24) | (keyData[10] << 16) | (keyData[9] << 8) | keyData[8]);
		}

	
		protected void UpdateKeys(byte ch)
		{
			keys[0] = Crc32.ComputeCrc32(keys[0], ch);
			keys[1] = keys[1] + (byte)keys[0];
			keys[1] = keys[1] * 134775813 + 1;
			keys[2] = Crc32.ComputeCrc32(keys[2], (byte)(keys[1] >> 24));
		}

	
		protected void Reset()
		{
			keys[0] = 0;
			keys[1] = 0;
			keys[2] = 0;
		}
		
		#region Instance Fields
		uint[] keys;
		#endregion
	}

	
	class PkzipClassicEncryptCryptoTransform : PkzipClassicCryptoBase, ICryptoTransform
	{
		public PkzipClassicEncryptCryptoTransform(byte[] keyBlock)
		{
			SetKeys(keyBlock);
		}

		#region ICryptoTransform Members

		
		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			byte[] result = new byte[inputCount];
			TransformBlock(inputBuffer, inputOffset, inputCount, result, 0);
			return result;
		}

		
		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			for (int i = inputOffset; i < inputOffset + inputCount; ++i) {
				byte oldbyte = inputBuffer[i];
				outputBuffer[outputOffset++] = (byte)(inputBuffer[i] ^ TransformByte());
				UpdateKeys(oldbyte);
			}
			return inputCount;
		}

	
		public bool CanReuseTransform
		{
			get {
				return true;
			}
		}

		
		public int InputBlockSize
		{
			get {
				return 1;
			}
		}

		
		public int OutputBlockSize
		{
			get {
				return 1;
			}
		}

		
		public bool CanTransformMultipleBlocks
		{
			get {
				return true;
			}
		}

		#endregion

		#region IDisposable Members

		
		public void Dispose()
		{
			Reset();
		}

		#endregion
	}


	
	class PkzipClassicDecryptCryptoTransform : PkzipClassicCryptoBase, ICryptoTransform
	{
		
		public PkzipClassicDecryptCryptoTransform(byte[] keyBlock)
		{
			SetKeys(keyBlock);
		}

		#region ICryptoTransform Members

		
		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			byte[] result = new byte[inputCount];
			TransformBlock(inputBuffer, inputOffset, inputCount, result, 0);
			return result;
		}

	
		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			for (int i = inputOffset; i < inputOffset + inputCount; ++i) {
				byte newByte = (byte)(inputBuffer[i] ^ TransformByte());
				outputBuffer[outputOffset++] = newByte;
				UpdateKeys(newByte);
			}
			return inputCount;
		}

		
		public bool CanReuseTransform
		{
			get {
				return true;
			}
		}

		
		public int InputBlockSize
		{
			get {
				return 1;
			}
		}

		
		public int OutputBlockSize
		{
			get {
				return 1;
			}
		}

		
		public bool CanTransformMultipleBlocks
		{
			get {
				return true;
			}
		}

		#endregion

		#region IDisposable Members

		
		public void Dispose()
		{
			Reset();
		}

		#endregion
	}

	
	public sealed class PkzipClassicManaged : PkzipClassic
	{
		public override int BlockSize 
		{
			get { 
				return 8; 
			}

			set {
				if (value != 8) {
					throw new CryptographicException("Block size is invalid");
				}
			}
		}

		public override KeySizes[] LegalKeySizes
		{
			get {
				KeySizes[] keySizes = new KeySizes[1];
				keySizes[0] = new KeySizes(12 * 8, 12 * 8, 0);
				return keySizes; 
			}
		}

		public override void GenerateIV()
		{
		}

		public override KeySizes[] LegalBlockSizes
		{
			get {
				KeySizes[] keySizes = new KeySizes[1];
				keySizes[0] = new KeySizes(1 * 8, 1 * 8, 0);
				return keySizes; 
			}
		}

		public override byte[] Key
		{
			get {
				if ( key_ == null ) {
					GenerateKey();
				}
				
				return (byte[]) key_.Clone();
			}
		
			set {
				if ( value == null ) {
					throw new ArgumentNullException("value");
				}
				
				if ( value.Length != 12 ) {
					throw new CryptographicException("Key size is illegal");
				}
				
				key_ = (byte[]) value.Clone();
			}
		}

		public override void GenerateKey()
		{
			key_ = new byte[12];
			Random rnd = new Random();
			rnd.NextBytes(key_);
		}

		public override ICryptoTransform CreateEncryptor(
			byte[] rgbKey,
			byte[] rgbIV)
		{
			key_ = rgbKey;
			return new PkzipClassicEncryptCryptoTransform(Key);
		}


		public override ICryptoTransform CreateDecryptor(
			byte[] rgbKey,
			byte[] rgbIV)
		{
			key_ = rgbKey;
			return new PkzipClassicDecryptCryptoTransform(Key);
		}
		
		#region Instance Fields
		byte[] key_;
		#endregion
	}
}
#endif
