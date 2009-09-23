using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace TOP.Core.Domain
{
    public class TaobaoClient
    {
        /// <summary> 
        /// 执行HTTP POST请求。 
        /// </summary> 
        /// <param name="parameters">请求参数</param> 
        /// <returns>HTTP响应</returns> 
        public string InvokeAPI(IDictionary<string, string> parameters)
        {
            // Create a request for the URL.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://gw.api.taobao.com/router/rest");
            // Set the request verb.
            request.Method = "POST";
            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";

            byte[] postData = Encoding.UTF8.GetBytes(BuildPostData(parameters));

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(postData, 0, postData.Length);
                stream.Close();
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Encoding encoding = Encoding.GetEncoding(response.CharacterSet);
                return GetResponseAsString(response, encoding);
            }
        }

        /// <summary> 
        /// 执行带文件上传的HTTP POST请求。 
        /// </summary> 
        /// <param name="textParams">请求文本参数</param> 
        /// <param name="fileParams">请求文件参数</param> 
        /// <returns>HTTP响应</returns> 
        public string InvokeAPI(IDictionary<string, string> textParams, IDictionary<string, FileInfo> fileParams)
        {
            string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线 

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://gw.api.taobao.com/router/rest");
            req.Method = "POST";
            req.KeepAlive = true;
            req.ContentType = "multipart/form-data;boundary=" + boundary;

            using (Stream reqStream = req.GetRequestStream())
            {
                byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
                byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                // 组装文本请求参数 
                string entryTemplate = "Content-Disposition:form-data;name=\"{0}\"\r\nContent-Type:text/plain\r\n\r\n{1}";
                IEnumerator<KeyValuePair<string, string>> textEnum = textParams.GetEnumerator();
                while (textEnum.MoveNext())
                {
                    string formItem = string.Format(entryTemplate, textEnum.Current.Key, textEnum.Current.Value);
                    byte[] itemBytes = Encoding.UTF8.GetBytes(formItem);
                    reqStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                    reqStream.Write(itemBytes, 0, itemBytes.Length);
                }

                // 组装文件请求参数 
                string fileTemplate = "Content-Disposition:form-data;name=\"{0}\";filename=\"{1}\"\r\nContent-Type:{2}\r\n\r\n";
                IEnumerator<KeyValuePair<string, FileInfo>> fileEnum = fileParams.GetEnumerator();
                while (fileEnum.MoveNext())
                {
                    string key = fileEnum.Current.Key;
                    FileInfo file = fileEnum.Current.Value;
                    string fileItem = string.Format(fileTemplate, key, file.FullName, GetMimeType(file.FullName));
                    byte[] itemBytes = Encoding.UTF8.GetBytes(fileItem);
                    reqStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                    reqStream.Write(itemBytes, 0, itemBytes.Length);

                    using (Stream fileStream = file.OpenRead())
                    {
                        byte[] buffer = new byte[1024];
                        int readBytes = 0;
                        while ((readBytes = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            reqStream.Write(buffer, 0, readBytes);
                        }
                    }
                }

                reqStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
                reqStream.Close();
            }

            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                Encoding encoding = Encoding.GetEncoding(response.CharacterSet);
                return GetResponseAsString(response, encoding);
            }
        }

        /// <summary> 
        /// 根据文件名后缀获取图片型文件的Mime-Type。 
        /// </summary> 
        /// <param name="filePath">文件全名</param> 
        /// <returns>图片文件的Mime-Type</returns> 
        private string GetMimeType(string filePath)
        {
            string mimeType;

            switch (Path.GetExtension(filePath).ToLower())
            {
                case ".bmp": mimeType = "image/bmp"; break;
                case ".gif": mimeType = "image/gif"; break;
                case ".ico": mimeType = "image/x-icon"; break;
                case ".jpeg": mimeType = "image/jpeg"; break;
                case ".jpg": mimeType = "image/jpeg"; break;
                case ".png": mimeType = "image/png"; break;
                default: mimeType = "application/octet-stream"; break;
            }

            return mimeType;
        }

        /// <summary> 
        /// 组装普通文本请求参数。 
        /// </summary> 
        /// <param name="parameters">Key-Value形式请求参数字典</param> 
        /// <returns>URL编码后的请求数据</returns> 
        private string BuildPostData(IDictionary<string, string> parameters)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;

            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数 
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }

                    postData.Append(name);
                    postData.Append("=");
                    postData.Append(Uri.EscapeDataString(value));
                    hasParam = true;
                }
            }

            return postData.ToString();
        }

        /// <summary> 
        /// 把响应流转换为文本。 
        /// </summary> 
        /// <param name="rsp">响应流对象</param> 
        /// <param name="encoding">编码方式</param> 
        /// <returns>响应文本</returns> 
        private string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            StringBuilder result = new StringBuilder();
            // 以字符流的方式读取HTTP响应 
            using (Stream stream = rsp.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    // 每次读取不大于512个字符，并写入字符串 
                    char[] buffer = new char[512];
                    int readBytes = 0;
                    while ((readBytes = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        result.Append(buffer, 0, readBytes);
                    }
                    reader.Close();
                    stream.Close();
                }
            }
            return result.ToString();
        }
    }
}
