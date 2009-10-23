using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace TOP.Common.CompressionTool
{
    public static class CompressionHelper
    {
        /// <summary>
        /// 提供内部使用，压缩字流的方法
        /// </summary>
        public static byte[] Compress(byte[] data)
        {
            DeflateStream zip = null;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    zip = new DeflateStream(ms, CompressionMode.Compress, true);
                    zip.Write(data, 0, data.Length);
                    zip.Close();
                    byte[] bs = ms.ToArray();
                    return bs;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("解压缩流发生异常：" + ex.Message, ex);
            }
            finally
            {
                if (zip != null) zip.Close();
            }
        }

        /// <summary>
        /// 提供内部使用，解压缩字流的方法
        /// </summary>
        public static byte[] Decompress(byte[] data)
        {
            DeflateStream zip = null;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    ms.Position = 0;
                    zip = new DeflateStream(ms, CompressionMode.Decompress, true);
                    using (MemoryStream os = new MemoryStream())
                    {
                        int SIZE = 1024;
                        byte[] buf = new byte[SIZE];
                        int l = 0;
                        do
                        {
                            l = zip.Read(buf, 0, SIZE);
                            if (l == 0) l = zip.Read(buf, 0, SIZE);
                            os.Write(buf, 0, l);
                        } while (l != 0);
                        byte[] bs = os.ToArray();

                        os.Close();
                        zip.Close();

                        return bs;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("解压缩流发生异常 - " + ex.Message, ex);
            }
            finally
            {
                if (zip != null) zip.Close();
            }
        }

        public static string Compress(string uncompressedString)
        {
            byte[] bytData = System.Text.Encoding.Unicode.GetBytes(uncompressedString);
            using (MemoryStream ms = new MemoryStream())
            {
                using (Stream s = new ICSharpCode.SharpZipLib.BZip2.BZip2OutputStream(ms))
                {
                    s.Write(bytData, 0, bytData.Length);
                    s.Close();
                }
                byte[] compressedData = (byte[])ms.ToArray();
                return System.Convert.ToBase64String(compressedData, 0, compressedData.Length);
            }
        }

        public static string Decompress(string compressedString)
        {
            System.Text.StringBuilder uncompressedString = new System.Text.StringBuilder();
            int totalLength = 0;
            byte[] bytInput = System.Convert.FromBase64String(compressedString);
            byte[] writeData = new byte[4096];
            Stream s2 = new ICSharpCode.SharpZipLib.BZip2.BZip2InputStream(new MemoryStream(bytInput));
            while (true)
            {
                int size = s2.Read(writeData, 0, writeData.Length);
                if (size > 0)
                {
                    totalLength += size;
                    uncompressedString.Append(System.Text.Encoding.Unicode.GetString(writeData, 0, size));
                }
                else
                {
                    break;
                }
            }
            s2.Close();
            return uncompressedString.ToString();
        }
    }
}
