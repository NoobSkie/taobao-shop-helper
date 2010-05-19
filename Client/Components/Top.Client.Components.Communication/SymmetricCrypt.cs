using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Top.Client.Components.Communication
{
    internal static class SymmetricCrypt
    {
        // Methods
        public static string Decrypt(string key, string IV, string input)
        {
            string s = IV;
            string password = key;
            byte[] buffer = Convert.FromBase64String(input);
            byte[] salt = Encoding.UTF8.GetBytes(s);
            AesManaged managed = new AesManaged();
            Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, salt);
            managed.BlockSize = managed.LegalBlockSizes[0].MaxSize;
            managed.KeySize = managed.LegalKeySizes[0].MaxSize;
            managed.Key = bytes.GetBytes(managed.KeySize / 8);
            managed.IV = bytes.GetBytes(managed.BlockSize / 8);
            ICryptoTransform transform = managed.CreateDecryptor();
            using (MemoryStream stream = new MemoryStream())
            {
                using (CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write))
                {
                    stream2.Write(buffer, 0, buffer.Length);
                    stream2.Close();
                }
                byte[] buffer3 = stream.ToArray();
                return Encoding.UTF8.GetString(buffer3, 0, buffer3.Length);
            }
        }

        public static string Encrypt(string key, string IV, string input)
        {
            string s = IV;
            string password = key;
            byte[] buffer = Encoding.UTF8.GetBytes(input);
            byte[] salt = Encoding.UTF8.GetBytes(s);
            AesManaged managed = new AesManaged();
            Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, salt);
            managed.BlockSize = managed.LegalBlockSizes[0].MaxSize;
            managed.KeySize = managed.LegalKeySizes[0].MaxSize;
            managed.Key = bytes.GetBytes(managed.KeySize / 8);
            managed.IV = bytes.GetBytes(managed.BlockSize / 8);
            ICryptoTransform transform = managed.CreateEncryptor();
            using (MemoryStream stream = new MemoryStream())
            {
                using (CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write))
                {
                    stream2.Write(buffer, 0, buffer.Length);
                    stream2.Close();
                }
                return Convert.ToBase64String(stream.ToArray());
            }
        }
    }
}
