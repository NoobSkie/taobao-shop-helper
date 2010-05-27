using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace J.SLS.Common
{
    public static class EncryptTool
    {
        public static string MD5(string SourceString)
        {
            return MD5(SourceString, Encoding.Default);
        }

        public static string MD5(string SourceString, Encoding encoding)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(encoding.GetBytes(SourceString));
            StringBuilder builder = new StringBuilder(0x20);
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x").PadLeft(2, '0'));
            }
            return builder.ToString();
        }
    }
}
