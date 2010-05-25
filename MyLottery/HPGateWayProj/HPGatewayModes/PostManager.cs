using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Security;
using System.Security.Cryptography;

namespace HPGatewayModels
{
    /// <summary>
    /// 向恒朋接口发起请求
    /// </summary>
    public class PostManager
    {
        private static int eserialNumber=0;
        /// <summary>
        /// 8位递增流水号从1开始到99999999,每次递增1, 
        /// 到达99999999之后重新从1开始
        /// 不足8位的左边补0
        /// </summary>
        public static string EightSerialNumber
        {
            get 
            {
                Random random = new Random();

                eserialNumber += random.Next(1000000);
                eserialNumber++;
                if (eserialNumber > 99999999)
                    eserialNumber = 1;
                return eserialNumber.ToString().PadLeft(8,'0');
            }
        }

        private static long tserialNumber = 0;
        /// <summary>
        /// 10位递增流水号从1开始到99999999,每次递增1, 
        /// 到达99999999之后重新从1开始
        /// 不足8位的左边补0
        /// </summary>
        public static string TenSerialNumber
        {
            get
            {
                tserialNumber++;
                if (tserialNumber > 9999999999)
                    tserialNumber = 1;
                return tserialNumber.ToString().PadLeft(10, '0');
            }
        }


        /// <summary>
        /// 利用Web应用程序Forms验证服务生成适合存储于配置文件中的哈希密码
        /// </summary>
        /// <param name="SourceString">源字符串</param>
        /// <returns>加密结果字符串</returns>
        public static string MD5(string SourceString)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(SourceString, "MD5");
        }

        /// <summary>
        /// 用指定编码得到哈希密码
        /// </summary>
        /// <param name="SourceString">源字符串</param>
        /// <param name="CharsetName">字符集编码字符串</param>
        /// <returns>加密结果字符串</returns>
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

        /// <summary>
        /// 向恒朋接口发起请求
        /// </summary>
        /// <param name="Url">网关地址</param>
        /// <param name="RequestString">请求消息包</param>
        /// <param name="TimeoutSeconds">获得请求或相应流的超时值，以毫秒为单位</param>
        /// <returns>响应消息包</returns>
        public static string Post(string Url, string RequestString, int TimeoutSeconds)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            if (TimeoutSeconds > 0)
            {
                request.Timeout = 0x3e8 * TimeoutSeconds;
            }
            request.Method = "POST";
            request.AllowAutoRedirect = true;
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(RequestString);
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));
            return reader.ReadToEnd();
        }
    }
}
