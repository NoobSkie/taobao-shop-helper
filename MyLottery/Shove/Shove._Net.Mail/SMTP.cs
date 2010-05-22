namespace Shove._Net.Mail
{
    using System;
    using System.Data;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class SMTP : TcpClient
    {
        private string strCharset = "gb2312";
        private bool isHtml;
        private string strUser;
        private int intPort;
        private string strHtmlBody = "";
        private string strFrom = "";
        private string strPass;
        private string strTName = "";
        private int intPriority;
        private string strServer;
        private DataTable filelist;
        private string strTo = "";
        private string strEncode = "8bit";
        private string strBody = "";
        private string strFName = "";
        private string strSub = "";

        private void WriteStream(string strCmd)
        {
            strCmd = strCmd + "\r\n";
            Stream stream = base.GetStream();
            byte[] bytes = Encoding.GetEncoding(this.strCharset).GetBytes(strCmd.ToCharArray());
            int offset = 0;
            int length = bytes.Length;
            int num3 = 0;
            int num4 = 75;
            int count = num4;
            try
            {
                if (length > 75)
                {
                    if (((length / num4) * num4) < length)
                    {
                        num3 = (length / num4) + 1;
                    }
                    else
                    {
                        num3 = length / num4;
                    }
                    for (int i = 0; i < num3; i++)
                    {
                        offset = i * num4;
                        if (i == (num3 - 1))
                        {
                            count = length - (i * num4);
                        }
                        stream.Write(bytes, offset, count);
                    }
                }
                else
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception)
            {
            }
        }

        public bool getMailServer()
        {
            try
            {
                IPAddress address = (IPAddress)Dns.GetHostEntry(this.strServer).AddressList.GetValue(0);
                IPEndPoint remoteEP = new IPEndPoint(address, this.intPort);
                base.Connect(remoteEP);
                this.ReceiveStream();
                if (this.strUser != null)
                {
                    if (!this.OperaStream("EHLO Localhost", "250"))
                    {
                        base.Close();
                        return false;
                    }
                    if (!this.OperaStream("AUTH LOGIN", "334"))
                    {
                        base.Close();
                        return false;
                    }
                    this.strUser = this.EncodeB64(this.strUser);
                    if (!this.OperaStream(this.strUser, "334"))
                    {
                        base.Close();
                        return false;
                    }
                    this.strPass = this.EncodeB64(this.strPass);
                    if (!this.OperaStream(this.strPass, "235"))
                    {
                        base.Close();
                        return false;
                    }
                    return true;
                }
                return this.OperaStream("HELO Localhost", "250");
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                return false;
            }
        }

        private bool OperaStream(string strCmd, string state)
        {
            bool flag = false;
            try
            {
                this.WriteStream(strCmd);
                if (this.ReceiveStream().IndexOf(state) != -1)
                {
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
            }
            return flag;
        }

        public void LoadAttFile(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            byte[] buffer = new byte[Convert.ToInt32(stream.Length)];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();
            string str = Convert.ToBase64String(buffer);
            DataRow row = this.filelist.NewRow();
            row[0] = Path.GetFileName(path);
            row[1] = str;
            this.filelist.Rows.Add(row);
        }

        private string ReceiveStream()
        {
            string str = null;
            byte[] buffer = new byte[0x400];
            if (base.GetStream().Read(buffer, 0, buffer.Length) > 0)
            {
                str = Encoding.Default.GetString(buffer);
            }
            return str;
        }

        private string EncodeB64(string strSrc)
        {
            try
            {
                strSrc = Convert.ToBase64String(Encoding.Default.GetBytes(strSrc.ToCharArray()));
            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
            return strSrc;
        }

        public bool quitMailServer()
        {
            if (!this.OperaStream("quit", "250"))
            {
                return false;
            }
            return true;
        }

        public void Send()
        {
            this.filelist = new DataTable();
            this.filelist.Columns.Add(new DataColumn("filename", typeof(string)));
            this.filelist.Columns.Add(new DataColumn("filecontent", typeof(string)));
            this.WriteStream("mail From: " + this.strFrom);
            this.WriteStream("rcpt to: " + this.strTo);
            this.WriteStream("data");
            this.WriteStream("Date: " + DateTime.Now);
            this.WriteStream("From: " + this.strFName + "<" + this.strFrom + ">");
            this.WriteStream("Subject: " + this.strSub);
            this.WriteStream("To:" + this.strTName + "<" + this.strTo + ">");
            this.WriteStream("Content-Type: multipart/mixed; boundary=\"unique-boundary-1\"");
            this.WriteStream("Reply-To:" + this.strFrom);
            this.WriteStream("X-Priority:" + this.intPriority);
            this.WriteStream("MIME-Version:1.0");
            this.WriteStream("Message-Id: " + DateTime.Now.ToFileTime() + "@security.com");
            this.WriteStream("Content-Transfer-Encoding:" + this.strEncode);
            this.WriteStream("X-Mailer:DS Mail Sender V1.0");
            this.WriteStream("");
            this.WriteStream(this.EncodeB64("This is a multi-part message in MIME format."));
            this.WriteStream("");
            this.WriteStream("--unique-boundary-1");
            this.WriteStream("Content-Type: multipart/alternative;Boundary=\"unique-boundary-2\"");
            this.WriteStream("");
            if (!this.isHtml)
            {
                this.WriteStream("--unique-boundary-2");
                this.WriteStream("Content-Type: text/plain;charset=" + this.strCharset);
                this.WriteStream("Content-Transfer-Encoding:" + this.strEncode);
                this.WriteStream("");
                this.WriteStream(this.strBody);
                this.WriteStream("");
                this.WriteStream("--unique-boundary-2--");
                this.WriteStream("");
            }
            else
            {
                this.WriteStream("--unique-boundary-2");
                this.WriteStream("Content-Type: text/html;charset=" + this.strCharset);
                this.WriteStream("Content-Transfer-Encoding:" + this.strEncode);
                this.WriteStream("");
                this.WriteStream(this.strHtmlBody);
                this.WriteStream("");
                this.WriteStream("--unique-boundary-2--");
                this.WriteStream("");
            }
            this.Attachment();
            this.WriteStream("");
            this.WriteStream("--unique-boundary-1--");
            if (!this.OperaStream(".", "250"))
            {
                base.Close();
            }
        }

        private void Attachment()
        {
            for (int i = 0; i < this.filelist.Rows.Count; i++)
            {
                DataRow row = this.filelist.Rows[i];
                this.WriteStream("--unique-boundary-1");
                this.WriteStream("Content-Type: application/octet-stream;name=\"" + row[0].ToString() + "\"");
                this.WriteStream("Content-Transfer-Encoding: base64");
                this.WriteStream("Content-Disposition:attachment;filename=\"" + row[0].ToString() + "\"");
                this.WriteStream("");
                string str = row[1].ToString();
                this.WriteStream(str);
                this.WriteStream("");
            }
        }

        public string body
        {
            get
            {
                return this.strBody;
            }
            set
            {
                if (this.strBody != value)
                {
                    this.strBody = value;
                }
            }
        }

        public string charset
        {
            get
            {
                return this.strCharset;
            }
            set
            {
                if (this.strCharset != value)
                {
                    this.strCharset = value;
                }
            }
        }

        public string encode
        {
            get
            {
                return this.strEncode;
            }
            set
            {
                if (this.strEncode != value)
                {
                    this.strEncode = value;
                }
            }
        }

        public string from
        {
            get
            {
                return this.strFrom;
            }
            set
            {
                if (this.strFrom != value)
                {
                    this.strFrom = value;
                }
            }
        }

        public string fromname
        {
            get
            {
                return this.strFName;
            }
            set
            {
                if (this.strFName != value)
                {
                    this.strFName = value;
                }
            }
        }

        public bool html
        {
            get
            {
                return this.isHtml;
            }
            set
            {
                if (this.isHtml != value)
                {
                    this.isHtml = value;
                }
            }
        }

        public string htmlbody
        {
            get
            {
                return this.strHtmlBody;
            }
            set
            {
                if (this.strHtmlBody != value)
                {
                    this.strHtmlBody = value;
                }
            }
        }

        public string password
        {
            get
            {
                return this.strPass;
            }
            set
            {
                if (this.strPass != value)
                {
                    this.strPass = value;
                }
            }
        }

        public int port
        {
            get
            {
                return this.intPort;
            }
            set
            {
                if (this.intPort != value)
                {
                    this.intPort = value;
                }
            }
        }

        public int priority
        {
            get
            {
                return this.intPriority;
            }
            set
            {
                if (this.intPriority != value)
                {
                    this.intPriority = value;
                }
            }
        }

        public string server
        {
            get
            {
                return this.strServer;
            }
            set
            {
                if (this.strServer != value)
                {
                    this.strServer = value;
                }
            }
        }

        public string subject
        {
            get
            {
                return this.strSub;
            }
            set
            {
                if (this.strSub != value)
                {
                    this.strSub = value;
                }
            }
        }

        public string to
        {
            get
            {
                return this.strTo;
            }
            set
            {
                if (this.strTo != value)
                {
                    this.strTo = value;
                }
            }
        }

        public string toname
        {
            get
            {
                return this.strTName;
            }
            set
            {
                if (this.strTName != value)
                {
                    this.strTName = value;
                }
            }
        }

        public string username
        {
            get
            {
                return this.strUser;
            }
            set
            {
                if (this.strUser != value)
                {
                    this.strUser = value;
                }
            }
        }
    }
}

