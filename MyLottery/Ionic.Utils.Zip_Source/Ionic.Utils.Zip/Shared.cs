namespace Ionic.Utils.Zip
{
    using System;
    using System.IO;

    internal class Shared
    {
        protected internal static int DateTimeToPacked(DateTime time)
        {
            ushort num = (ushort) (((time.Day & 0x1f) | ((time.Month << 5) & 480)) | (((time.Year - 0x7bc) << 9) & 0xfe00));
            ushort num2 = (ushort) (((time.Second & 0x1f) | ((time.Minute << 5) & 0x7e0)) | ((time.Hour << 11) & 0xf800));
            return ((num << 0x10) | num2);
        }

        protected internal static long FindSignature(Stream s, int SignatureToFind)
        {
            long position = s.Position;
            int num2 = 0x400;
            byte[] buffer = new byte[] { (byte) (SignatureToFind >> 0x18), (byte) ((SignatureToFind & 0xff0000) >> 0x10), (byte) ((SignatureToFind & 0xff00) >> 8), (byte) (SignatureToFind & 0xff) };
            byte[] buffer2 = new byte[num2];
            int num3 = 0;
            bool flag = false;
        Label_0050:
            num3 = s.Read(buffer2, 0, buffer2.Length);
            if (num3 != 0)
            {
                for (int i = 0; i < num3; i++)
                {
                    if (buffer2[i] == buffer[3])
                    {
                        s.Seek((long) (i - num3), SeekOrigin.Current);
                        flag = ReadSignature(s) == SignatureToFind;
                        if (!flag)
                        {
                            s.Seek(-3L, SeekOrigin.Current);
                        }
                        break;
                    }
                }
                if (!flag)
                {
                    goto Label_0050;
                }
            }
            if (!flag)
            {
                s.Seek(position, SeekOrigin.Begin);
                return -1L;
            }
            return ((s.Position - position) - 4L);
        }

        protected internal static DateTime PackedToDateTime(int packedDateTime)
        {
            short num = (short) (packedDateTime & 0xffff);
            short num2 = (short) ((packedDateTime & 0xffff0000L) >> 0x10);
            int year = 0x7bc + ((num2 & 0xfe00) >> 9);
            int month = (num2 & 480) >> 5;
            int day = num2 & 0x1f;
            int hour = (num & 0xf800) >> 11;
            int minute = (num & 0x7e0) >> 5;
            int second = num & 0x1f;
            DateTime now = DateTime.Now;
            try
            {
                now = new DateTime(year, month, day, hour, minute, second, 0);
            }
            catch
            {
                Console.Write("\nInvalid date/time?:\nyear: {0} ", year);
                Console.Write("month: {0} ", month);
                Console.WriteLine("day: {0} ", day);
                Console.WriteLine("HH:MM:SS= {0}:{1}:{2}", hour, minute, second);
            }
            return now;
        }

        protected internal static int ReadSignature(Stream s)
        {
            byte[] buffer = new byte[4];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new Exception("Could not read signature - no data!");
            }
            return ((((((buffer[3] * 0x100) + buffer[2]) * 0x100) + buffer[1]) * 0x100) + buffer[0]);
        }

        protected internal static string StringFromBuffer(byte[] buf, int start, int maxlength)
        {
            char[] chArray = new char[maxlength];
            int index = 0;
            while (((index < maxlength) && (index < buf.Length)) && (buf[index] != 0))
            {
                chArray[index] = (char) buf[index];
                index++;
            }
            return new string(chArray, 0, index);
        }
    }
}

