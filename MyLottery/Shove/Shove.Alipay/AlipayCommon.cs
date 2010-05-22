namespace Shove.Alipay
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class AlipayCommon
    {
        public static string[] BubbleSort(string[] r)
        {
            for (int i = 0; i < r.Length; i++)
            {
                bool flag = false;
                for (int j = r.Length - 2; j >= i; j--)
                {
                    if (string.CompareOrdinal(r[j + 1], r[j]) < 0)
                    {
                        string str = r[j + 1];
                        r[j + 1] = r[j];
                        r[j] = str;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    return r;
                }
            }
            return r;
        }

        public static string GetFileMD5(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open);
            int length = (int) stream.Length;
            byte[] buffer = new byte[length];
            stream.Read(buffer, 0, length);
            stream.Close();
            byte[] buffer2 = new MD5CryptoServiceProvider().ComputeHash(buffer);
            string str = " ";
            foreach (byte num2 in buffer2)
            {
                string str2 = "0" + Convert.ToString(num2, 0x10);
                str2 = str2.Substring(str2.Length - 2);
                str = str + str2;
            }
            return str;
        }

        public static string GetSign(string[] fields, string safeCode)
        {
            string[] strArray = BubbleSort(fields);
            string s = "";
            foreach (string str2 in strArray)
            {
                s = s + str2 + "&";
            }
            s = s.TrimEnd(new char[] { '&' }) + safeCode;
            byte[] bytes = new byte[s.Length];
            bytes = Encoding.Default.GetBytes(s);
            byte[] buffer2 = new MD5CryptoServiceProvider().ComputeHash(bytes);
            string str3 = " ";
            foreach (byte num2 in buffer2)
            {
                string str4 = "0" + Convert.ToString(num2, 0x10);
                str4 = str4.Substring(str4.Length - 2);
                str3 = str3 + str4;
            }
            return str3;
        }
    }
}

