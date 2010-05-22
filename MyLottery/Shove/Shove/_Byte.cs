namespace Shove
{
    using System;
    using System.Text;

    public class _Byte
    {
        public static bool ByteCompare(byte[] input1, byte[] input2)
        {
            if ((input1 == null) || (input2 == null))
            {
                return false;
            }
            if (input1.Length != input2.Length)
            {
                return false;
            }
            for (int i = 0; i < input1.Length; i++)
            {
                if (input1[i] != input2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static void ByteCopy(byte[] Source, int StartIndex, int Count, byte[] Destination, int DestinationStartIndex)
        {
            for (int i = StartIndex; i < (StartIndex + Count); i++)
            {
                Destination[(DestinationStartIndex + i) - StartIndex] = Source[i];
            }
        }

        public static string BytesToHexString(byte[] Input)
        {
            string str = "";
            if (Input.Length != 0)
            {
                foreach (byte num in Input)
                {
                    str = str + num.ToString("X").PadLeft(2, '0');
                }
            }
            return str;
        }

        public static byte[] ExtractBytesFromBuffer(byte[] Buffer, int Index, int Count)
        {
            if (Buffer == null)
            {
                return null;
            }
            if (Index >= Buffer.Length)
            {
                return null;
            }
            byte[] buffer = new byte[Count];
            for (int i = Index; i < (Index + Count); i++)
            {
                buffer[i - Index] = Buffer[i];
            }
            return buffer;
        }

        public static double ExtractDoubleFromBuffer(byte[] Buffer, int Index, int Count)
        {
            return BitConverter.ToDouble(Buffer, Index);
        }

        public static float ExtractFloatFromBuffer(byte[] Buffer, int Index, int Count)
        {
            return BitConverter.ToSingle(Buffer, Index);
        }

        public static int ExtractIntFromBuffer(byte[] Buffer, int Index, int Count)
        {
            return BitConverter.ToInt32(Buffer, Index);
        }

        public static long ExtractLongFromBuffer(byte[] Buffer, int Index, int Count)
        {
            return BitConverter.ToInt64(Buffer, Index);
        }

        public static string ExtractStringFromBuffer(byte[] Buffer, int Index, int Count)
        {
            string str = Encoding.Default.GetString(Buffer, Index, Count);
            while (str[str.Length - 1] == '\0')
            {
                str = str.Remove(str.Length - 1);
            }
            return str;
        }

        public static byte[] HexToBytes(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            if ((input.Length % 2) != 0)
            {
                return null;
            }
            byte[] buffer = new byte[input.Length / 2];
            for (int i = 0; i < (input.Length / 2); i++)
            {
                string str = input.Substring(i * 2, 2);
                byte num2 = 0;
                try
                {
                    num2 = Convert.ToByte(str, 0x10);
                }
                catch
                {
                    return null;
                }
                buffer[i] = num2;
            }
            return buffer;
        }

        public static string HexToString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "";
            }
            if ((input.Length % 2) != 0)
            {
                return "";
            }
            string str = "";
            for (int i = 0; i < (input.Length / 2); i++)
            {
                string str2 = input.Substring(i * 2, 2);
                byte num2 = 0;
                try
                {
                    num2 = Convert.ToByte(str2, 0x10);
                }
                catch
                {
                    return "";
                }
                str = str + ((char) num2).ToString();
            }
            return str;
        }

        public static string StringToHex(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "";
            }
            string str = "";
            foreach (byte num in Encoding.Default.GetBytes(input))
            {
                str = str + string.Format("{0:X}", num);
            }
            return str;
        }
    }
}

