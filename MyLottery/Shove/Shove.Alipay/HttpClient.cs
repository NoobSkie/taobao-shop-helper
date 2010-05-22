namespace Shove.Alipay
{
    using System;
    using System.IO;
    using System.Text;

    public class HttpClient
    {
        private Stream writer;
        private string boundary = "";

        public void AppendEnd()
        {
            byte[] buffer = this.GetBytes(this.boundary + "--\r\n");
            this.writer.Write(buffer, 0, buffer.Length);
        }

        public void AppendFile(string txtName, string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open);
            int length = (int) stream.Length;
            byte[] buffer = new byte[length];
            stream.Read(buffer, 0, length);
            stream.Close();
            byte[] buffer2 = this.GetBytes(this.boundary + "\r\n");
            this.writer.Write(buffer2, 0, buffer2.Length);
            byte[] buffer3 = this.GetBytes("Content-Disposition: form-data; name=\"" + txtName + "\"; filename=\"" + fileName + "\"\r\n");
            this.writer.Write(buffer3, 0, buffer3.Length);
            byte[] buffer4 = this.GetBytes("Content-Type: application/octet-stream\r\n\r\n");
            this.writer.Write(buffer4, 0, buffer4.Length);
            this.writer.Write(buffer, 0, length);
            this.writer.Write(Encoding.Default.GetBytes("\r\n"), 0, 2);
        }

        public void AppendText(string txtName, string content)
        {
            string s = string.Format(this.boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n", txtName, content);
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            this.writer.Write(bytes, 0, bytes.Length);
        }

        private byte[] GetBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public string Boundary
        {
            get
            {
                return this.boundary;
            }
            set
            {
                this.boundary = value;
            }
        }

        public Stream Writer
        {
            set
            {
                this.writer = value;
            }
        }
    }
}

