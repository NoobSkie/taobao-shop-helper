namespace Ionic.Utils.Zip
{
    using System;
    using System.IO;

    public class CRC32
    {
        private int _TotalBytesRead = 0;
        private const int BUFFER_SIZE = 0x2000;
        private uint[] crc32Table;

        public CRC32()
        {
            uint num = 0xedb88320;
            this.crc32Table = new uint[0x100];
            for (uint i = 0; i < 0x100; i++)
            {
                uint num4 = i;
                for (uint j = 8; j > 0; j--)
                {
                    if ((num4 & 1) == 1)
                    {
                        num4 = (num4 >> 1) ^ num;
                    }
                    else
                    {
                        num4 = num4 >> 1;
                    }
                }
                this.crc32Table[i] = num4;
            }
        }

        public uint GetCrc32(Stream input)
        {
            return this.GetCrc32AndCopy(input, null);
        }

        public uint GetCrc32AndCopy(Stream input, Stream output)
        {
            uint maxValue = uint.MaxValue;
            byte[] buffer = new byte[0x2000];
            int count = 0x2000;
            this._TotalBytesRead = 0;
            int num3 = input.Read(buffer, 0, count);
            if (output != null)
            {
                output.Write(buffer, 0, num3);
            }
            this._TotalBytesRead += num3;
            while (num3 > 0)
            {
                for (int i = 0; i < num3; i++)
                {
                    maxValue = (maxValue >> 8) ^ this.crc32Table[(int) ((IntPtr) (buffer[i] ^ (maxValue & 0xff)))];
                }
                num3 = input.Read(buffer, 0, count);
                if (output != null)
                {
                    output.Write(buffer, 0, num3);
                }
                this._TotalBytesRead += num3;
            }
            return ~maxValue;
        }

        public int TotalBytesRead
        {
            get
            {
                return this._TotalBytesRead;
            }
        }
    }
}

