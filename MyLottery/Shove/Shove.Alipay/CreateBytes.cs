namespace Shove.Alipay
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Text;

    public class CreateBytes
    {
        private Encoding enUTF8 = Encoding.UTF8;

        public byte[] CreateFieldData(string fieldName, string fieldValue)
        {
            string s = string.Format(this.Boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n", fieldName, fieldValue);
            return this.enUTF8.GetBytes(s);
        }

        public byte[] CreateFieldData(string fieldName, string filename, string contentType, byte[] fileBytes)
        {
            string s = "\r\n";
            string str3 = string.Format(this.Boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n", fieldName, filename, contentType);
            byte[] bytes = this.enUTF8.GetBytes(str3);
            byte[] buffer2 = this.enUTF8.GetBytes(s);
            byte[] array = new byte[(bytes.Length + fileBytes.Length) + buffer2.Length];
            bytes.CopyTo(array, 0);
            fileBytes.CopyTo(array, bytes.Length);
            buffer2.CopyTo(array, (int) (bytes.Length + fileBytes.Length));
            return array;
        }

        public byte[] JoinBytes(ArrayList byteArrays)
        {
            int num = 0;
            int index = 0;
            string s = this.Boundary + "--\r\n";
            byte[] bytes = this.enUTF8.GetBytes(s);
            byteArrays.Add(bytes);
            foreach (byte[] buffer2 in byteArrays)
            {
                num += buffer2.Length;
            }
            byte[] array = new byte[num];
            foreach (byte[] buffer4 in byteArrays)
            {
                buffer4.CopyTo(array, index);
                index += buffer4.Length;
            }
            return array;
        }

        public bool UploadData(string uploadUrl, byte[] bytes, out byte[] responseBytes)
        {
            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", this.ContentType);
            try
            {
                responseBytes = client.UploadData(uploadUrl, bytes);
                return true;
            }
            catch (WebException exception)
            {
                Stream responseStream = exception.Response.GetResponseStream();
                responseBytes = new byte[exception.Response.ContentLength];
                responseStream.Read(responseBytes, 0, responseBytes.Length);
            }
            return false;
        }

        public string Boundary
        {
            get
            {
                string[] strArray2 = this.ContentType.Split(new char[] { ';' });
                if (strArray2[0].Trim().ToLower() == "multipart/form-data")
                {
                    string[] strArray = strArray2[1].Split(new char[] { '=' });
                    return ("--" + strArray[1]);
                }
                return null;
            }
        }

        public string ContentType
        {
            get
            {
                return "multipart/form-data; boundary=---------------------------7d5b915500cee";
            }
        }
    }
}

