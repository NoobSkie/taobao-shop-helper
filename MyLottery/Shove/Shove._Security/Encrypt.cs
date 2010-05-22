namespace Shove._Security
{
    using Shove;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web.Security;

    public class Encrypt
    {
        private static string GetCallCert()
        {
            string sSourceStr = "";
            string str2 = _String.Reverse("ShoveSoft" + " " + "CO.,Ltd ");
            str2 = _String.Reverse(_String.Reverse(str2) + ("--" + " by Shove "));
            sSourceStr = "20050709";
            sSourceStr = _String.Reverse(sSourceStr + " 深圳" + "宝安");
            return (_String.Reverse(str2) + _String.Reverse(sSourceStr));
        }

        public static string Decrypt3DES(string CallPassword, string input, string key)
        {
            if (CallPassword != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                return "";
            }
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            provider.Key = Encoding.UTF8.GetBytes(key);
            provider.Mode = CipherMode.ECB;
            provider.Padding = PaddingMode.Zeros;
            ICryptoTransform transform = provider.CreateDecryptor();
            byte[] inputBuffer = new byte[input.Length / 2];
            for (int i = 0; i < (input.Length / 2); i++)
            {
                inputBuffer[i] = (byte) Convert.ToInt16(input.Substring(i * 2, 2), 0x10);
            }
            string str = "";
            try
            {
                str = Encoding.UTF8.GetString(transform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
            }
            catch
            {
            }
            return TrimSlashZero(str);
        }

        public static string Encrypt3DES(string CallPassword, string input, string key)
        {
            if (CallPassword != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                return "";
            }
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            provider.Key = Encoding.UTF8.GetBytes(key);
            provider.Mode = CipherMode.ECB;
            provider.Padding = PaddingMode.Zeros;
            ICryptoTransform transform = provider.CreateEncryptor();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] buffer2 = transform.TransformFinalBlock(bytes, 0, bytes.Length);
            string str = "";
            foreach (byte num in buffer2)
            {
                str = str + num.ToString("X").PadLeft(2, '0');
            }
            return str;
        }

        public static string EncryptString(string CallPassword, string s)
        {
            return Encrypt05String(CallPassword, s);
        }

        private static string Encrypt04String(string CallPassword, string s)
        {
            if (CallPassword != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                return "";
            }
            if (s == "")
            {
                return "";
            }
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            int length = bytes.Length;
            int num2 = (DateTime.Now.Millisecond + 200) / 2;
            int[] numArray = new int[] { num2 / 100, (num2 % 100) / 10, num2 % 10 };
            string str = num2.ToString().PadLeft(3, '0');
            for (int i = 0; i < length; i++)
            {
                int num4 = bytes[i];
                num4 += numArray[i % 3];
                str = str + num4.ToString().PadLeft(3, '0');
            }
            KeysTwo c = new KeysTwo();
            for (int j = 0; j < 0x34; j++)
            {
                str = str.Replace(c.strings[0, j], c.strings[1, j]);
            }
            return ("04" + str);
        }

        public static string GetMachineSerialNumber(string CallPassword, bool isUseBiosSerialNumber, bool isUseIdeDiskSerialNumber, bool isUseNetAdapterMacAddress, bool isUseCpuSerialNumber)
        {
            if (CallPassword != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                return "";
            }
            string sourceStr = "";
            if (isUseBiosSerialNumber)
            {
                sourceStr = sourceStr + "System Serial Number";
            }
            if (isUseIdeDiskSerialNumber)
            {
                sourceStr = sourceStr + "";
            }
            if (isUseNetAdapterMacAddress)
            {
                sourceStr = sourceStr + "00:1D:60:8D:7F:27";
            }
            if (isUseCpuSerialNumber)
            {
                sourceStr = sourceStr + "178BFBFF00060FB2";
            }
            return NoUnEncryptString(CallPassword, sourceStr, "MID-", 5, 5, 0);
        }

        private static string DeEncrypt04String(string CallPassword, string s)
        {
            int num;
            if (CallPassword != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                return "";
            }
            if (((s == null) || (s == "")) || ((s.Length < 2) || !s.StartsWith("04")))
            {
                return "";
            }
            s = s.Substring(2, s.Length - 2);
            KeysTwo c = new KeysTwo();
            for (num = 0x33; num >= 0; num--)
            {
                s = s.Replace(c.strings[1, num], c.strings[0, num]);
            }
            int num3 = int.Parse(s.Substring(0, 3));
            int[] numArray = new int[] { num3 / 100, (num3 % 100) / 10, num3 % 10 };
            s = s.Substring(3, s.Length - 3);
            int num2 = s.Length / 3;
            byte[] bytes = new byte[num2];
            for (num = 0; num < num2; num++)
            {
                bytes[num] = (byte) (int.Parse(s.Substring(num * 3, 3)) - numArray[num % 3]);
            }
            return Encoding.UTF8.GetString(bytes);
        }

        private static string DecompressString(string CallPassword, string s)
        {
            int num;
            if (CallPassword != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                return "";
            }
            if ((s == null) || (s == ""))
            {
                return "";
            }
            KeysOne c = new KeysOne();
            for (num = 0x33; num >= 0; num--)
            {
                s = s.Replace(c.strings[1, num], c.strings[0, num]);
            }
            int num3 = int.Parse(s.Substring(0, 3));
            s = s.Substring(3, s.Length - 3);
            int num2 = s.Length / 3;
            byte[] data = new byte[num2];
            for (num = 0; num < num2; num++)
            {
                data[num] = (byte) (int.Parse(s.Substring(num * 3, 3)) - num3);
            }
            return _String.Decompress(data);
        }

        private static string CompressString(string CallPassword, string s)
        {
            if (CallPassword != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                return "";
            }
            if (s == "")
            {
                return "";
            }
            byte[] buffer = _String.Compress(s);
            int length = buffer.Length;
            int num2 = (DateTime.Now.Millisecond + 200) / 2;
            string str = num2.ToString().PadLeft(3, '0');
            for (int i = 0; i < length; i++)
            {
                int num5 = buffer[i] + num2;
                str = str + num5.ToString().PadLeft(3, '0');
            }
            KeysOne c = new KeysOne();
            for (int j = 0; j < 0x34; j++)
            {
                str = str.Replace(c.strings[0, j], c.strings[1, j]);
            }
            return str;
        }

        private static string Encrypt02String(string CallPassword, string p1)
        {
            if (CallPassword != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                return "";
            }
            if (p1 == "")
            {
                return "";
            }
            byte[] bytes = Encoding.UTF8.GetBytes(p1);
            int length = bytes.Length;
            int num2 = (DateTime.Now.Millisecond + 200) / 2;
            int[] numArray = new int[] { num2 / 100, (num2 % 100) / 10, num2 % 10 };
            string str = num2.ToString().PadLeft(3, '0');
            for (int i = 0; i < length; i++)
            {
                int num4 = bytes[i];
                num4 += numArray[i % 3];
                str = str + num4.ToString().PadLeft(3, '0');
            }
            KeysOne c = new KeysOne();
            for (int j = 0; j < 0x54; j++)
            {
                str = str.Replace(c.strings[0, j], c.strings[1, j]);
            }
            return ("02" + str);
        }

        private static string TrimSlashZero(string str)
        {
            while (str.EndsWith("\0"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private static string DeEncrypt03String(string CallPassword, string p1)
        {
            int num;
            if (CallPassword != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                return "";
            }
            if (((p1 == null) || (p1 == "")) || ((p1.Length < 2) || !p1.StartsWith("03")))
            {
                return "";
            }
            p1 = p1.Substring(2, p1.Length - 2);
            KeysOne c = new KeysOne();
            for (num = 0x33; num >= 0; num--)
            {
                p1 = p1.Replace(c.strings[1, num], c.strings[0, num]);
            }
            int num3 = int.Parse(p1.Substring(0, 3));
            int[] numArray = new int[] { num3 / 100, (num3 % 100) / 10, num3 % 10 };
            p1 = p1.Substring(3, p1.Length - 3);
            int num2 = p1.Length / 3;
            byte[] bytes = new byte[num2];
            for (num = 0; num < num2; num++)
            {
                bytes[num] = (byte) (int.Parse(p1.Substring(num * 3, 3)) - numArray[num % 3]);
            }
            return Encoding.UTF8.GetString(bytes);
        }

        public static string GetUserName(params string[] StringValue)
        {
            if (StringValue.Length < 2)
            {
                return "";
            }
            string str = StringValue[0];
            string str2 = StringValue[1];
            if (str.Length < 10)
            {
                return "";
            }
            string str3 = str.Substring(9);
            str = str.Substring(0, 9);
            if (ValidUserAndPassword(new string[] { str, str2 }))
            {
                return "";
            }
            return str3;
        }

        private static string GetObjectString(object obj)
        {
            if (obj is DateTime)
            {
                DateTime time = (DateTime) obj;
                return time.ToString("yyyyMMddHHmmss");
            }
            if (obj is DataTable)
            {
                return _Convert.DataTableToXML((DataTable) obj);
            }
            if (obj is DataSet)
            {
                return ((DataSet) obj).GetXml();
            }
            if (obj is string)
            {
                return (string) obj;
            }
            return obj.ToString();
        }

        public static string MD5(string SourceString)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(SourceString, "MD5");
        }

        public static string MD5(string SourceString, string CharsetName)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding(CharsetName).GetBytes(SourceString));
            StringBuilder builder = new StringBuilder(0x20);
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x").PadLeft(2, '0'));
            }
            return builder.ToString();
        }

        public static string NoUnEncryptString(string CallPassword, string s)
        {
            if (CallPassword != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                return "";
            }
            int num3 = 1;
            int length = s.Length;
            for (int i = 0; i < length; i++)
            {
                num3 *= s[(length - i) - 1];
                while (num3 > 0x1869f)
                {
                    num3 /= 10;
                }
            }
            while (num3 < 0x989680)
            {
                num3 *= 11;
            }
            while (num3 > 0x5f5e0ff)
            {
                num3 /= 10;
            }
            return num3.ToString();
        }

        public static string NoUnEncryptString(string CallPassword, string SourceStr, string Marking_str, int Part_Num, int Part_Len, int Ch_Type)
        {
            int num;
            if (CallPassword != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                return "";
            }
            int[,] numArray = new int[,] { { _Convert.Asc('0'), _Convert.Asc('9') }, { _Convert.Asc('A'), _Convert.Asc('Z') }, { _Convert.Asc('a'), _Convert.Asc('z') } };
            int[] numArray2 = new int[Part_Num];
            string[] strArray = new string[Part_Num];
            string[] strArray2 = new string[Part_Num];
            numArray2[0] = 0x173;
            for (num = 1; num <= (Part_Num - 1); num++)
            {
                numArray2[num] = numArray2[num - 1] * 3;
            }
            int length = SourceStr.Length;
            for (num = 0; num < Part_Num; num++)
            {
                int startIndex = 0;
                while (startIndex < length)
                {
                    string str;
                    numArray2[num] = Math.Abs((int) (numArray2[num] + Math.Abs((int) (numArray2[num] * _Convert.Asc(SourceStr[startIndex])))));
                Label_00F9:
                    try
                    {
                        str = numArray2[num].ToString();
                    }
                    catch
                    {
                        numArray2[num] /= 10;
                        goto Label_00F9;
                    }
                    str = _String.Reverse(str);
                Label_0132:
                    try
                    {
                        numArray2[num] = int.Parse(str);
                    }
                    catch
                    {
                        str = str.Substring(1, str.Length - 1);
                        goto Label_0132;
                    }
                    startIndex++;
                }
                strArray[num] = numArray2[num].ToString();
                while (strArray[num].Length < (Part_Len + 1))
                {
                    numArray2[num] = Math.Abs((int) (numArray2[num] * 3));
                    strArray[num] = strArray[num] + numArray2[num].ToString();
                }
                strArray2[num] = "";
                for (startIndex = 0; startIndex < Part_Len; startIndex++)
                {
                    int i = int.Parse(strArray[num].Substring(startIndex, 2));
                    if (i == 0)
                    {
                        i = 0x35;
                    }
                    goto Label_0225;
                Label_01F3:
                    i *= 11;
                Label_01FA:
                    if (i < numArray[Ch_Type, 0])
                    {
                        goto Label_01F3;
                    }
                    while (i > numArray[Ch_Type, 1])
                    {
                        i /= 2;
                    }
                Label_0225:
                    if ((i < numArray[Ch_Type, 0]) || (i > numArray[Ch_Type, 1]))
                    {
                        goto Label_01FA;
                    }
                    strArray2[num] = strArray2[num] + _Convert.Chr(i).ToString();
                }
            }
            string str2 = Marking_str;
            for (num = 0; num < Part_Num; num++)
            {
                if (num > 0)
                {
                    str2 = str2 + "-";
                }
                str2 = str2 + strArray2[num];
            }
            return str2;
        }

        public static string ParamterSignature(string Key, params object[] Params)
        {
            string str = "";
            foreach (object obj2 in Params)
            {
                str = str + GetObjectString(obj2);
            }
            return MD5(str + Key);
        }

        private static string Encrypt03String(string CallPassword, string s)
        {
            if (CallPassword != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                return "";
            }
            if (s == "")
            {
                return "";
            }
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            int length = bytes.Length;
            int num2 = (DateTime.Now.Millisecond + 200) / 2;
            int[] numArray = new int[] { num2 / 100, (num2 % 100) / 10, num2 % 10 };
            string str = num2.ToString().PadLeft(3, '0');
            for (int i = 0; i < length; i++)
            {
                int num4 = bytes[i];
                num4 += numArray[i % 3];
                str = str + num4.ToString().PadLeft(3, '0');
            }
            KeysOne c = new KeysOne();
            for (int j = 0; j < 0x34; j++)
            {
                str = str.Replace(c.strings[0, j], c.strings[1, j]);
            }
            return ("03" + str);
        }

        public static string UnEncryptString(string CallPassword, string s)
        {
            if ((s == null) || (s == ""))
            {
                return "";
            }
            if (s.Length >= 2)
            {
                switch (s.Substring(0, 2))
                {
                    case "02":
                        return DeEncrypt02String(CallPassword, s);

                    case "03":
                        return DeEncrypt03String(CallPassword, s);

                    case "04":
                        return DeEncrypt04String(CallPassword, s);

                    case "05":
                        return DeEncrypt05String(CallPassword, s);
                }
            }
            return DecompressString(CallPassword, s);
        }

        public static bool ValidUserAndPassword(params string[] StringValue)
        {
            if (StringValue.Length < 2)
            {
                return true;
            }
            string str = StringValue[0];
            string str2 = StringValue[1];
            if (str.Length < 9)
            {
                return true;
            }
            char[] chArray = str.ToCharArray();
            if (chArray.Length > 9)
            {
                return true;
            }
            if (chArray[7] != 'f')
            {
                return true;
            }
            if (chArray[1] != 'h')
            {
                return true;
            }
            if (chArray[2] != 'o')
            {
                return true;
            }
            if (chArray[3] != 'v')
            {
                return true;
            }
            if (chArray[0] != 's')
            {
                return true;
            }
            if (chArray[5] != 's')
            {
                return true;
            }
            if (chArray[6] != 'o')
            {
                return true;
            }
            if (chArray[4] != 'e')
            {
                return true;
            }
            if (chArray[8] != 't')
            {
                return true;
            }
            //Service service = new Service();
            int num = 0;
            bool flag = false;
            string d = "";
            while (!flag && (num < 3))
            {
                try
                {
                    //d = service.GetSupperCert("Shovesoft at 20080613 at China, shenzhen.!@#$%^&*()))QWERT12345#$%^&");
                    d = "Shovesoft at 20080613 at China, shenzhen.!@#$%^&*()))QWERT12345#$%^&";
                    flag = true;
                }
                catch
                {
                }
                num++;
            }
            //service.Dispose();
            if (d == "")
            {
                return true;
            }
            try
            {
                d = UnEncryptString("ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安", d);
            }
            catch
            {
            }
            return (str2 != d);
        }

        private static string DeEncrypt05String(string CallPassword, string s)
        {
            if (CallPassword != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                return "";
            }
            if (((s == null) || (s == "")) || ((s.Length < 2) || !s.StartsWith("05")))
            {
                return "";
            }
            s = s.Substring(2, s.Length - 2);
            string key = ConfigurationSettings.AppSettings["DesKey"];
            if (string.IsNullOrEmpty(key))
            {
                key = "56GtyNkop97Ht334TtyurfgQ";
            }
            return Decrypt3DES(CallPassword, s, key);
        }

        private static string DeEncrypt02String(string CallPassword, string s)
        {
            int num;
            if (CallPassword != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                return "";
            }
            if (((s == null) || (s == "")) || ((s.Length < 2) || !s.StartsWith("02")))
            {
                return "";
            }
            s = s.Substring(2, s.Length - 2);
            KeysOne c = new KeysOne();
            for (num = 0x53; num >= 0; num--)
            {
                s = s.Replace(c.strings[1, num], c.strings[0, num]);
            }
            int num3 = int.Parse(s.Substring(0, 3));
            int[] numArray = new int[] { num3 / 100, (num3 % 100) / 10, num3 % 10 };
            s = s.Substring(3, s.Length - 3);
            int num2 = s.Length / 3;
            byte[] bytes = new byte[num2];
            for (num = 0; num < num2; num++)
            {
                bytes[num] = (byte) (int.Parse(s.Substring(num * 3, 3)) - numArray[num % 3]);
            }
            return Encoding.UTF8.GetString(bytes);
        }

        private static string Encrypt05String(string CallPassword, string input)
        {
            if (CallPassword != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                return "";
            }
            if (input == "")
            {
                return "";
            }
            string str = ConfigurationSettings.AppSettings["DesKey"];
            if (string.IsNullOrEmpty(str))
            {
                str = "56GtyNkop97Ht334TtyurfgQ";
            }
            return ("05" + Encrypt3DES(CallPassword, input, str));
        }

        private class KeysOne
        {
            public string[,] strings = new string[2, 0x54];

            public KeysOne()
            {
                this.strings[0, 0] = "00";
                this.strings[1, 0] = "A";
                this.strings[0, 1] = "11";
                this.strings[1, 1] = "B";
                this.strings[0, 2] = "22";
                this.strings[1, 2] = "C";
                this.strings[0, 3] = "33";
                this.strings[1, 3] = "D";
                this.strings[0, 4] = "44";
                this.strings[1, 4] = "E";
                this.strings[0, 5] = "55";
                this.strings[1, 5] = "F";
                this.strings[0, 6] = "66";
                this.strings[1, 6] = "G";
                this.strings[0, 7] = "77";
                this.strings[1, 7] = "H";
                this.strings[0, 8] = "88";
                this.strings[1, 8] = "I";
                this.strings[0, 9] = "99";
                this.strings[1, 9] = "J";
                this.strings[0, 10] = "10";
                this.strings[1, 10] = "K";
                this.strings[0, 11] = "20";
                this.strings[1, 11] = "L";
                this.strings[0, 12] = "30";
                this.strings[1, 12] = "M";
                this.strings[0, 13] = "40";
                this.strings[1, 13] = "N";
                this.strings[0, 14] = "50";
                this.strings[1, 14] = "O";
                this.strings[0, 15] = "60";
                this.strings[1, 15] = "P";
                this.strings[0, 0x10] = "70";
                this.strings[1, 0x10] = "Q";
                this.strings[0, 0x11] = "80";
                this.strings[1, 0x11] = "R";
                this.strings[0, 0x12] = "90";
                this.strings[1, 0x12] = "S";
                this.strings[0, 0x13] = "01";
                this.strings[1, 0x13] = "T";
                this.strings[0, 20] = "21";
                this.strings[1, 20] = "U";
                this.strings[0, 0x15] = "31";
                this.strings[1, 0x15] = "V";
                this.strings[0, 0x16] = "41";
                this.strings[1, 0x16] = "W";
                this.strings[0, 0x17] = "51";
                this.strings[1, 0x17] = "X";
                this.strings[0, 0x18] = "61";
                this.strings[1, 0x18] = "Y";
                this.strings[0, 0x19] = "71";
                this.strings[1, 0x19] = "Z";
                this.strings[0, 0x1a] = "81";
                this.strings[1, 0x1a] = "a";
                this.strings[0, 0x1b] = "91";
                this.strings[1, 0x1b] = "b";
                this.strings[0, 0x1c] = "02";
                this.strings[1, 0x1c] = "c";
                this.strings[0, 0x1d] = "12";
                this.strings[1, 0x1d] = "d";
                this.strings[0, 30] = "32";
                this.strings[1, 30] = "e";
                this.strings[0, 0x1f] = "42";
                this.strings[1, 0x1f] = "f";
                this.strings[0, 0x20] = "52";
                this.strings[1, 0x20] = "g";
                this.strings[0, 0x21] = "62";
                this.strings[1, 0x21] = "h";
                this.strings[0, 0x22] = "72";
                this.strings[1, 0x22] = "i";
                this.strings[0, 0x23] = "82";
                this.strings[1, 0x23] = "j";
                this.strings[0, 0x24] = "92";
                this.strings[1, 0x24] = "k";
                this.strings[0, 0x25] = "03";
                this.strings[1, 0x25] = "l";
                this.strings[0, 0x26] = "13";
                this.strings[1, 0x26] = "m";
                this.strings[0, 0x27] = "23";
                this.strings[1, 0x27] = "n";
                this.strings[0, 40] = "43";
                this.strings[1, 40] = "o";
                this.strings[0, 0x29] = "53";
                this.strings[1, 0x29] = "p";
                this.strings[0, 0x2a] = "63";
                this.strings[1, 0x2a] = "q";
                this.strings[0, 0x2b] = "73";
                this.strings[1, 0x2b] = "r";
                this.strings[0, 0x2c] = "83";
                this.strings[1, 0x2c] = "s";
                this.strings[0, 0x2d] = "93";
                this.strings[1, 0x2d] = "t";
                this.strings[0, 0x2e] = "04";
                this.strings[1, 0x2e] = "u";
                this.strings[0, 0x2f] = "14";
                this.strings[1, 0x2f] = "v";
                this.strings[0, 0x30] = "24";
                this.strings[1, 0x30] = "w";
                this.strings[0, 0x31] = "34";
                this.strings[1, 0x31] = "x";
                this.strings[0, 50] = "54";
                this.strings[1, 50] = "y";
                this.strings[0, 0x33] = "64";
                this.strings[1, 0x33] = "z";
                this.strings[0, 0x34] = "74";
                this.strings[1, 0x34] = "!";
                this.strings[0, 0x35] = "84";
                this.strings[1, 0x35] = "@";
                this.strings[0, 0x36] = "94";
                this.strings[1, 0x36] = "#";
                this.strings[0, 0x37] = "05";
                this.strings[1, 0x37] = "$";
                this.strings[0, 0x38] = "15";
                this.strings[1, 0x38] = "%";
                this.strings[0, 0x39] = "25";
                this.strings[1, 0x39] = "^";
                this.strings[0, 0x3a] = "35";
                this.strings[1, 0x3a] = "&";
                this.strings[0, 0x3b] = "45";
                this.strings[1, 0x3b] = "*";
                this.strings[0, 60] = "65";
                this.strings[1, 60] = "(";
                this.strings[0, 0x3d] = "75";
                this.strings[1, 0x3d] = ")";
                this.strings[0, 0x3e] = "85";
                this.strings[1, 0x3e] = "_";
                this.strings[0, 0x3f] = "95";
                this.strings[1, 0x3f] = "-";
                this.strings[0, 0x40] = "06";
                this.strings[1, 0x40] = "+";
                this.strings[0, 0x41] = "16";
                this.strings[1, 0x41] = "=";
                this.strings[0, 0x42] = "26";
                this.strings[1, 0x42] = "|";
                this.strings[0, 0x43] = "36";
                this.strings[1, 0x43] = @"\";
                this.strings[0, 0x44] = "46";
                this.strings[1, 0x44] = "<";
                this.strings[0, 0x45] = "56";
                this.strings[1, 0x45] = ">";
                this.strings[0, 70] = "76";
                this.strings[1, 70] = ",";
                this.strings[0, 0x47] = "86";
                this.strings[1, 0x47] = ".";
                this.strings[0, 0x48] = "96";
                this.strings[1, 0x48] = "?";
                this.strings[0, 0x49] = "07";
                this.strings[1, 0x49] = "/";
                this.strings[0, 0x4a] = "17";
                this.strings[1, 0x4a] = "[";
                this.strings[0, 0x4b] = "27";
                this.strings[1, 0x4b] = "]";
                this.strings[0, 0x4c] = "37";
                this.strings[1, 0x4c] = "{";
                this.strings[0, 0x4d] = "47";
                this.strings[1, 0x4d] = "}";
                this.strings[0, 0x4e] = "57";
                this.strings[1, 0x4e] = ":";
                this.strings[0, 0x4f] = "67";
                this.strings[1, 0x4f] = ";";
                this.strings[0, 80] = "87";
                this.strings[1, 80] = "\"";
                this.strings[0, 0x51] = "97";
                this.strings[1, 0x51] = "'";
                this.strings[0, 0x52] = "08";
                this.strings[1, 0x52] = "`";
                this.strings[0, 0x53] = "18";
                this.strings[1, 0x53] = "~";
            }
        }

        private class KeysTwo
        {
            public string[,] strings = new string[2, 0x54];

            public KeysTwo()
            {
                this.strings[0, 0] = "00";
                this.strings[1, 0] = "S";
                this.strings[0, 1] = "11";
                this.strings[1, 1] = "B";
                this.strings[0, 2] = "22";
                this.strings[1, 2] = "H";
                this.strings[0, 3] = "33";
                this.strings[1, 3] = "e";
                this.strings[0, 4] = "44";
                this.strings[1, 4] = "F";
                this.strings[0, 5] = "55";
                this.strings[1, 5] = "E";
                this.strings[0, 6] = "66";
                this.strings[1, 6] = "G";
                this.strings[0, 7] = "77";
                this.strings[1, 7] = "z";
                this.strings[0, 8] = "88";
                this.strings[1, 8] = "I";
                this.strings[0, 9] = "99";
                this.strings[1, 9] = "b";
                this.strings[0, 10] = "10";
                this.strings[1, 10] = "K";
                this.strings[0, 11] = "20";
                this.strings[1, 11] = "L";
                this.strings[0, 12] = "30";
                this.strings[1, 12] = "g";
                this.strings[0, 13] = "40";
                this.strings[1, 13] = "N";
                this.strings[0, 14] = "50";
                this.strings[1, 14] = "l";
                this.strings[0, 15] = "60";
                this.strings[1, 15] = "n";
                this.strings[0, 0x10] = "70";
                this.strings[1, 0x10] = "Q";
                this.strings[0, 0x11] = "80";
                this.strings[1, 0x11] = "R";
                this.strings[0, 0x12] = "90";
                this.strings[1, 0x12] = "a";
                this.strings[0, 0x13] = "01";
                this.strings[1, 0x13] = "T";
                this.strings[0, 20] = "21";
                this.strings[1, 20] = "U";
                this.strings[0, 0x15] = "31";
                this.strings[1, 0x15] = "j";
                this.strings[0, 0x16] = "41";
                this.strings[1, 0x16] = "W";
                this.strings[0, 0x17] = "51";
                this.strings[1, 0x17] = "X";
                this.strings[0, 0x18] = "61";
                this.strings[1, 0x18] = "w";
                this.strings[0, 0x19] = "71";
                this.strings[1, 0x19] = "Z";
                this.strings[0, 0x1a] = "81";
                this.strings[1, 0x1a] = "A";
                this.strings[0, 0x1b] = "91";
                this.strings[1, 0x1b] = "J";
                this.strings[0, 0x1c] = "02";
                this.strings[1, 0x1c] = "c";
                this.strings[0, 0x1d] = "12";
                this.strings[1, 0x1d] = "d";
                this.strings[0, 30] = "32";
                this.strings[1, 30] = "D";
                this.strings[0, 0x1f] = "42";
                this.strings[1, 0x1f] = "f";
                this.strings[0, 0x20] = "52";
                this.strings[1, 0x20] = "M";
                this.strings[0, 0x21] = "62";
                this.strings[1, 0x21] = "h";
                this.strings[0, 0x22] = "72";
                this.strings[1, 0x22] = "i";
                this.strings[0, 0x23] = "82";
                this.strings[1, 0x23] = "V";
                this.strings[0, 0x24] = "92";
                this.strings[1, 0x24] = "k";
                this.strings[0, 0x25] = "03";
                this.strings[1, 0x25] = "O";
                this.strings[0, 0x26] = "13";
                this.strings[1, 0x26] = "m";
                this.strings[0, 0x27] = "23";
                this.strings[1, 0x27] = "P";
                this.strings[0, 40] = "43";
                this.strings[1, 40] = "o";
                this.strings[0, 0x29] = "53";
                this.strings[1, 0x29] = "p";
                this.strings[0, 0x2a] = "63";
                this.strings[1, 0x2a] = "x";
                this.strings[0, 0x2b] = "73";
                this.strings[1, 0x2b] = "t";
                this.strings[0, 0x2c] = "83";
                this.strings[1, 0x2c] = "s";
                this.strings[0, 0x2d] = "93";
                this.strings[1, 0x2d] = "r";
                this.strings[0, 0x2e] = "04";
                this.strings[1, 0x2e] = "u";
                this.strings[0, 0x2f] = "14";
                this.strings[1, 0x2f] = "v";
                this.strings[0, 0x30] = "24";
                this.strings[1, 0x30] = "Y";
                this.strings[0, 0x31] = "34";
                this.strings[1, 0x31] = "q";
                this.strings[0, 50] = "54";
                this.strings[1, 50] = "y";
                this.strings[0, 0x33] = "64";
                this.strings[1, 0x33] = "C";
                this.strings[0, 0x34] = "74";
                this.strings[1, 0x34] = "!";
                this.strings[0, 0x35] = "84";
                this.strings[1, 0x35] = "@";
                this.strings[0, 0x36] = "94";
                this.strings[1, 0x36] = "#";
                this.strings[0, 0x37] = "05";
                this.strings[1, 0x37] = "$";
                this.strings[0, 0x38] = "15";
                this.strings[1, 0x38] = "%";
                this.strings[0, 0x39] = "25";
                this.strings[1, 0x39] = "^";
                this.strings[0, 0x3a] = "35";
                this.strings[1, 0x3a] = "&";
                this.strings[0, 0x3b] = "45";
                this.strings[1, 0x3b] = "*";
                this.strings[0, 60] = "65";
                this.strings[1, 60] = "(";
                this.strings[0, 0x3d] = "75";
                this.strings[1, 0x3d] = ")";
                this.strings[0, 0x3e] = "85";
                this.strings[1, 0x3e] = "_";
                this.strings[0, 0x3f] = "95";
                this.strings[1, 0x3f] = "-";
                this.strings[0, 0x40] = "06";
                this.strings[1, 0x40] = "+";
                this.strings[0, 0x41] = "16";
                this.strings[1, 0x41] = "=";
                this.strings[0, 0x42] = "26";
                this.strings[1, 0x42] = "|";
                this.strings[0, 0x43] = "36";
                this.strings[1, 0x43] = @"\";
                this.strings[0, 0x44] = "46";
                this.strings[1, 0x44] = "<";
                this.strings[0, 0x45] = "56";
                this.strings[1, 0x45] = ">";
                this.strings[0, 70] = "76";
                this.strings[1, 70] = ",";
                this.strings[0, 0x47] = "86";
                this.strings[1, 0x47] = ".";
                this.strings[0, 0x48] = "96";
                this.strings[1, 0x48] = "?";
                this.strings[0, 0x49] = "07";
                this.strings[1, 0x49] = "/";
                this.strings[0, 0x4a] = "17";
                this.strings[1, 0x4a] = "[";
                this.strings[0, 0x4b] = "27";
                this.strings[1, 0x4b] = "]";
                this.strings[0, 0x4c] = "37";
                this.strings[1, 0x4c] = "{";
                this.strings[0, 0x4d] = "47";
                this.strings[1, 0x4d] = "}";
                this.strings[0, 0x4e] = "57";
                this.strings[1, 0x4e] = ":";
                this.strings[0, 0x4f] = "67";
                this.strings[1, 0x4f] = ";";
                this.strings[0, 80] = "87";
                this.strings[1, 80] = "\"";
                this.strings[0, 0x51] = "97";
                this.strings[1, 0x51] = "'";
                this.strings[0, 0x52] = "08";
                this.strings[1, 0x52] = "`";
                this.strings[0, 0x53] = "18";
                this.strings[1, 0x53] = "~";
            }
        }
    }
}

