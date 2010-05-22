namespace Shove
{
    using ICSharpCode.SharpZipLib.Zip.Compression;
    using Shove.HTML;
    using System;
    using System.Configuration;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class _String
    {
        public static string BytesToHexString(byte[] Input)
        {
            string str = "0x";
            if (Input.Length != 0)
            {
                foreach (byte num in Input)
                {
                    str = str + num.ToString("X").PadLeft(2, '0');
                }
            }
            return str;
        }

        public static string BytesToString(byte[] bytes)
        {
            string str = "0x";
            if (bytes.Length != 0)
            {
                foreach (byte num in bytes)
                {
                    str = str + num.ToString("X").PadLeft(2, '0');
                }
            }
            return str;
        }

        public static byte[] Compress(string str)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(str);
            Deflater deflater = new Deflater(Deflater.BEST_COMPRESSION);
            deflater.SetInput(bytes);
            deflater.Finish();
            MemoryStream stream = new MemoryStream(bytes.Length);
            try
            {
                byte[] output = new byte[0x400];
                while (!deflater.IsFinished)
                {
                    int count = deflater.Deflate(output);
                    stream.Write(output, 0, count);
                }
            }
            finally
            {
                stream.Close();
            }
            byte[] buffer3 = stream.ToArray();
            if ((buffer3.Length % 2) == 0)
            {
                return buffer3;
            }
            byte[] buffer4 = new byte[buffer3.Length + 1];
            for (int i = 0; i < buffer3.Length; i++)
            {
                buffer4[i] = buffer3[i];
            }
            buffer4[buffer3.Length] = 0;
            return buffer4;
        }

        public static string Cut(string Input, int Length)
        {
            if (Length < 0)
            {
                Length = 0;
            }
            Length *= 2;
            if (GetLength(Input) <= Length)
            {
                return Input;
            }
            string str = "";
            for (int i = 0; (GetLength(str) < Length) && (i < Input.Length); i++)
            {
                str = str + Input[i].ToString();
            }
            if (str != Input)
            {
                str = str + "..";
            }
            return str;
        }

        public static string DecodeBase64(string str)
        {
            string str2 = "";
            if ((str != null) && (str != ""))
            {
                str2 = Encoding.Default.GetString(Convert.FromBase64String(str));
            }
            return str2;
        }

        public static string Decompress(byte[] data)
        {
            if (data == null)
            {
                return "";
            }
            if (data.Length == 0)
            {
                return "";
            }
            Inflater inflater = new Inflater();
            inflater.SetInput(data);
            MemoryStream stream = new MemoryStream(data.Length);
            try
            {
                byte[] buf = new byte[0x400];
                while (!inflater.IsFinished)
                {
                    int count = inflater.Inflate(buf);
                    stream.Write(buf, 0, count);
                }
            }
            finally
            {
                stream.Close();
            }
            return Encoding.Unicode.GetString(stream.ToArray());
        }

        public static string EncodeBase64(string str)
        {
            string str2 = "";
            if ((str != null) && (str != ""))
            {
                str2 = Convert.ToBase64String(Encoding.Default.GetBytes(str));
            }
            return str2;
        }

        public static int GetLength(string str)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            int num = 0;
            for (int i = 0; i <= (bytes.Length - 1); i++)
            {
                if (bytes[i] == 0x3f)
                {
                    num++;
                }
                num++;
            }
            return num;
        }

        public static string HtmlTextCut(string Input, int Length)
        {
            if (Length < 0)
            {
                Length = 0;
            }
            Length *= 2;
            if (!Input.Contains("<body>"))
            {
                Input = "<body>" + Input;
            }
            Input = Shove.HTML.HTML.StandardizationHTML(Input, true, true, true);
            Input = Shove.HTML.HTML.GetText(Input, 0);
            return Cut(Input, Length);
        }

        public static bool isChineseCharacters(char ch)
        {
            int num = ch - '一';
            return ((num >= 0) && (num <= 0x51a4));
        }

        public static bool isDBCCharacters(char ch)
        {
            int num = ch;
            return ((num == 0x3000) || ((num > 0xff00) && (num < 0xff5f)));
        }

        public static string Reverse(string sSourceStr)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = sSourceStr.Length - 1; i >= 0; i--)
            {
                builder.Append(sSourceStr[i]);
            }
            return builder.ToString();
        }

        public static string StandardizationIdentifier(string str)
        {
            str = str.Trim();
            if (str == "")
            {
                return "CHERY_ADD";
            }
            char ch = str[0];
            if ("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_".IndexOf(ch.ToString()) < 0)
            {
                str = "CHERY_ADD_" + str;
            }
            string str2 = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_";
            string str3 = "";
            for (int i = 0; i < str.Length; i++)
            {
                char ch2 = str[i];
                if (str2.IndexOf(ch2.ToString()) >= 0)
                {
                    str3 = str3 + str[i].ToString();
                }
            }
            return str3;
        }

        public static int StringAt(string str, char ch)
        {
            if (str == null)
            {
                return 0;
            }
            int num = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ch)
                {
                    num++;
                }
            }
            return num;
        }

        public class Valid
        {
            public static bool isBankCardNumber(string BankCardNumber)
            {
                int num = _Convert.StrToInt(ConfigurationSettings.AppSettings["Valid_BankCardNumberMinLength"], 12);
                int num2 = _Convert.StrToInt(ConfigurationSettings.AppSettings["Valid_BankCardNumberMaxLength"], 0x16);
                if (num < 1)
                {
                    num = 1;
                }
                if (num2 < num)
                {
                    num2 = num;
                }
                string pattern = @"^\d{" + num.ToString() + "," + num2.ToString() + "}$";
                return Regex.IsMatch(BankCardNumber, pattern);
            }

            public static bool isDate(string DateString)
            {
                return Regex.IsMatch(DateString, @"^\d{4}[\-\/\s]?((((0[13578])|(1[02]))[\-\/\s]?(([0-2][0-9])|(3[01])))|(((0[469])|(11))[\-\/\s]?(([0-2][0-9])|(30)))|(02[\-\/\s]?[0-2][0-9]))$");
            }

            public static bool isDateTime(string DateTimeString)
            {
                return Regex.IsMatch(DateTimeString, @"^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))(\s(((0?[1-9])|(1[0-2]))\:([0-5][0-9])((\s)|(\:([0-5][0-9])\s))([AM|PM|am|pm]{2,2})))?$");
            }

            public static bool isEmail(string Email)
            {
                return Regex.IsMatch(Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            }

            public static bool isIDCardNumber(string IDCardNumber)
            {
                return Regex.IsMatch(IDCardNumber, @"(^\d{17}|^\d{14})(\d|x|X|y|Y)$");
            }

            public static bool isIDCardNumber_Hongkong(string IDCardNumber)
            {
                return Regex.IsMatch(IDCardNumber, @"[A-Za-z]{1,2}\d{6}\([Aa0-9]\)");
            }

            public static bool isIDCardNumber_Macau(string IDCardNumber)
            {
                return Regex.IsMatch(IDCardNumber, @"\d{7}\([0-9]\)");
            }

            public static bool isIDCardNumber_Singapore(string IDCardNumber)
            {
                return Regex.IsMatch(IDCardNumber, @"\d{7}[A-JZa-jz]");
            }

            public static bool isIDCardNumber_Taiwan(string IDCardNumber)
            {
                return Regex.IsMatch(IDCardNumber, @"[A-Za-z][12]\d{8}");
            }

            public static bool isIPAddress(string Address)
            {
                return Regex.IsMatch(Address, @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");
            }

            public static bool isMobile(string MobileNumber)
            {
                return Regex.IsMatch(MobileNumber, @"^(13|15||18)[\d]{9}$");
            }

            public static bool isUrl(string Url)
            {
                return Regex.IsMatch(Url, @"^(http://|([\w-]+\.))+[\w-]+(/[\w-./?%&=]*)?$");
            }
        }
    }
}

