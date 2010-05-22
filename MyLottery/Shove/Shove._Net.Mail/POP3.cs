namespace Shove._Net.Mail
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class POP3 : TcpClient
    {
        private string strServer = "";/*POP3服务器域名*/
        private int intPort = 110;    /*POP3服务器端口*/
        private string strUser = "";  /*用户名*/
        private string strPass = "";  /*密码*/
        private string strSub = "";   /*主题*/
        private string strBody = "";  /*邮件内容*/
        private string strMId = "";   /*邮件编号*/
        private string strFrom = "";  /*发件人地址*/
        private string strReply = ""; /*回复地址*/
        private string strTo = "";    /*收件人地址*/
        private string strFName = ""; /*发件人姓名*/
        private string strTName = ""; /*收件人姓名*/
        private string strDate = "";  /*邮件日期*/
        private string strType = "";  /*邮件类型*/
        private string strEncode = "";/*邮件编码*/
        private int intPriority = 0;      /*邮件优先级*/
        private string strCharset = "gb2312";/*语言编码*/
        private int attachmentCount = 0;/*邮件的附件数量*/
        public DataTable filelist;    /*附件列表*/


        /*向服务器写入命令的方法*/
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

        public bool delMail(int mIndex)
        {
            if (!this.OpenStream("DELE " + Convert.ToSingle(mIndex), "+OK"))
            {
                return false;
            }
            return true;
        }

        public string getAttachment(int AttachmentIndex)
        {
            return this.filelist.Rows[AttachmentIndex][1].ToString();
        }

        public string getAttachmentName(int AttachmentIndex)
        {
            return this.filelist.Rows[AttachmentIndex][0].ToString();
        }

        /*接收指定编号的邮件*/
        public bool getMail(int mIndex)
        {
            WriteStream("RETR   " + Convert.ToString(mIndex));
            StreamReader sr;
            String strRet = "";
            String oldHead = "";
            String boundary = "";
            bool isBody = false;
            bool isAttachment = false;
            bool isBodyEnd = false;
            String strAm = "";
            String strAmName = "";
            String[] arrTmp;
            DataRow dr;
            String mailEncode = "8bit";
            filelist = new DataTable();
            filelist.Columns.Add(new DataColumn("filename", typeof(string)));//文件名     
            filelist.Columns.Add(new DataColumn("filecontent", typeof(string)));//文件内容     
            sr = new StreamReader(this.GetStream(), Encoding.Default);
            if (!(sr.ReadLine().Split("   ".ToCharArray())[0] == "+OK"))
            {
                return false;
            }
            while (sr.Peek() != 46)
            {
                strRet = sr.ReadLine().Trim();
                arrTmp = null;
                if (strRet == "")
                {
                    oldHead = "";
                    if (!isBody)
                    {
                        arrTmp = strType.Split(";".ToCharArray());
                        for (int i = 0; i < arrTmp.Length; i++)
                        {
                            if (arrTmp[i].Trim().Length > 10)
                            {
                                if (arrTmp[i].Trim().Substring(0, 10) == "boundary=\"")
                                {
                                    boundary = arrTmp[i].Trim();
                                    boundary = boundary.Substring(11, boundary.Length - 12);
                                }
                            }
                        }
                        arrTmp = null;
                        strSub = deCode(strSub);
                        strFrom = deCode(strFrom);
                        strFName = deCode(strFName);
                        strTo = deCode(strTo);
                        strTName = deCode(strTName);
                    }
                    isBody = true;
                }
                if (!isBody)
                {
                    arrTmp = strRet.Split(":".ToCharArray());
                    if (arrTmp.Length == 1)
                    {
                        switch (oldHead)
                        {
                            case ("Return-Path"):
                                strReply += arrTmp[0].Trim();
                                break;

                            case ("Date"):
                                strDate += arrTmp[0].Trim();
                                break;

                            case ("From"):
                                strFrom += arrTmp[0].Trim();
                                break;

                            case ("Message-Id"):
                                strMId += arrTmp[0].Trim();
                                break;

                            case ("To"):
                                strTo += arrTmp[0].Trim();
                                break;

                            case ("Subject"):
                                strSub += arrTmp[0].Trim();
                                break;

                            case ("Content-Type"):
                                strType += arrTmp[0].Trim();
                                break;

                            case ("Content-Transfer-Encoding"):
                                strEncode += arrTmp[0].Trim();
                                break;
                        }
                    }
                    else
                    {
                        switch (arrTmp[0].Trim())
                        {
                            case ("Return-Path"):
                                strReply = arrTmp[arrTmp.Length - 1].Trim();
                                break;

                            case ("Date"):
                                for (int i = 1; i < arrTmp.Length; i++)
                                {
                                    strDate += arrTmp[i].Trim();
                                }
                                break;

                            case ("From"):
                                strFrom = arrTmp[arrTmp.Length - 1].Trim();
                                break;

                            case ("Message-Id"):
                                strMId = arrTmp[arrTmp.Length - 1].Trim();
                                break;

                            case ("To"):
                                strTo = arrTmp[arrTmp.Length - 1].Trim();
                                break;

                            case ("Subject"):
                                strSub = arrTmp[arrTmp.Length - 1].Trim();
                                break;

                            case ("Content-Type"):
                                strType = arrTmp[arrTmp.Length - 1].Trim();
                                break;

                            case ("Content-Transfer-Encoding"):
                                strEncode = arrTmp[arrTmp.Length - 1].Trim();
                                break;
                        }
                        oldHead = arrTmp[0].Trim();
                    }
                }
                else
                {
                    strRet = strRet.Trim();
                    if (isBodyEnd)
                    {
                        if (!isAttachment)
                        {
                            if (strRet.IndexOf("name=") >= 0)
                            {
                                strRet = strRet.Substring(strRet.IndexOf("name=") + 6);
                                strAmName = deCode(strRet.Substring(0, strRet.Length).Trim());
                            }
                            if (strRet.IndexOf("Content-Transfer-Encoding") >= 0)
                            {
                                mailEncode = strRet.Substring(27).Trim();
                            }
                            if (strRet.IndexOf("Content-Disposition:   attachment") >= 0)
                            {
                                attachmentCount += 1;
                            }
                        }
                        else
                        {
                            if (strRet == "" && attachmentCount > filelist.Rows.Count)
                            {
                                if (mailEncode == "base64")
                                {
                                    strAm = deCodeB64(strAm);
                                }
                                else
                                {
                                    if (mailEncode == "quoted-printable")
                                    {
                                        strAm = deCodeQP(strAm);
                                    }
                                }
                                dr = filelist.NewRow();
                                dr[0] = strAmName;
                                dr[1] = strAm;
                                this.filelist.Rows.Add(dr);
                                strAm = "";
                                strAmName = "";
                                mailEncode = "8bit";
                                isAttachment = false;
                            }
                            if (strRet != "" && attachmentCount > filelist.Rows.Count)
                            {
                                strAm += strRet;
                            }
                        }
                        if (strRet == "")
                        {
                            isAttachment = true;
                        }
                    }
                    if (strRet.IndexOf(boundary) > 0)
                    {
                        isBodyEnd = true;
                        isAttachment = false;
                    }
                }
                if (attachmentCount < 1)
                {
                    strBody += strRet;
                }
            }
            strBody += "--" + boundary;
            return true;
        }

        public int getMailCount()
        {
            this.WriteStream("stat");
            string str = this.ReceiveStream();
            if (!(str.Split(" ".ToCharArray())[0] == "+OK"))
            {
                return -1;
            }
            return Convert.ToInt16(str.Split(" ".ToCharArray())[1]);
        }

        public bool getMailServer()
        {
            try
            {
                IPAddress address = (IPAddress)Dns.GetHostEntry(this.strServer).AddressList.GetValue(0);
                IPEndPoint remoteEP = new IPEndPoint(address, this.intPort);
                base.Connect(remoteEP);
                if (this.ReceiveStream().Substring(0, 3) == "+OK")
                {
                    if (!this.OpenStream("user " + this.strUser, "+OK"))
                    {
                        base.Close();
                        return false;
                    }
                    if (!this.OpenStream("pass " + this.strPass, "+OK"))
                    {
                        base.Close();
                        return false;
                    }
                    return true;
                }
                Console.Write("Cann't conect the mail server.");
                return false;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                return false;
            }
        }

        /*发出命令并判断返回信息是否正确*/
        private bool OpenStream(string strCmd, string state)
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

        /*接收服务器的返回信息*/
        private string ReceiveStream()
        {
            string str = null;
            byte[] buffer = new byte[1024];
            if (base.GetStream().Read(buffer, 0, buffer.Length) > 0)
            {
                str = Encoding.Default.GetString(buffer);
            }
            return str;
        }

        /*解码*/
        private string deCode(string strSrc)
        {
            int index = strSrc.IndexOf("=?GB2312?");
            if (index == -1)
            {
                index = strSrc.IndexOf("=?gb2312?");
            }
            if (index >= 0)
            {
                string str = strSrc.Substring(0, index);
                string str2 = strSrc.Substring(index + 9, 1);
                strSrc = strSrc.Substring(index + 11);
                int length = strSrc.IndexOf("?=");
                if (length == -1)
                {
                    length = strSrc.Length;
                }
                string str3 = strSrc.Substring(length + 2, (strSrc.Length - length) - 2);
                strSrc = strSrc.Substring(0, length);
                if (str2 == "B")
                {
                    strSrc = str + this.deCodeB64(strSrc) + str3;
                }
                else if (str2 == "Q")
                {
                    strSrc = str + this.deCodeQP(strSrc) + str3;
                }
                else
                {
                    strSrc = str + strSrc + str3;
                }
                index = strSrc.IndexOf("=?GB2312?");
                if (index == -1)
                {
                    index = strSrc.IndexOf("=?gb2312?");
                }
                if (index >= 0)
                {
                    strSrc = this.deCode(strSrc);
                }
            }
            return strSrc;
        }

        /*Quoted-Printable   解码*/
        private string deCodeQP(string strSrc)
        {
            string str = "";
            char[] chArray = strSrc.ToCharArray();
            for (int i = 0; i < strSrc.Length; i++)
            {
                char ch = chArray[i];
                if (ch == '=')
                {
                    int num2;
                    int num3;
                    i++;
                    char ch2 = chArray[i];
                    if (ch2 == '\n')
                    {
                        continue;
                    }
                    i++;
                    char ch3 = chArray[i];
                    if (ch2 > '9')
                    {
                        num2 = ((ch2 - 'A') + 10) * 16;
                    }
                    else
                    {
                        num2 = (ch2 - '0') * 16;
                    }
                    if (ch3 > '9')
                    {
                        num3 = (ch2 - 'A') + 10;
                    }
                    else
                    {
                        num3 = ch2 - '0';
                    }
                    ch = Convert.ToChar((int)(num2 + num3));
                }
                str = str + ch.ToString();
            }
            return str;
        }

        public bool quitMailServer()
        {
            if (!this.OpenStream("quit", "+OK"))
            {
                return false;
            }
            return true;
        }

        /*Base64   解码*/
        private string deCodeB64(string strSrc)
        {
            try
            {
                if (strSrc != "")
                {
                    byte[] bytes = Convert.FromBase64String(strSrc);
                    strSrc = Encoding.Default.GetString(bytes);
                }
            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
            return strSrc;
        }

        public int ACount
        {
            get
            {
                return this.attachmentCount;
            }
            set
            {
                if (this.attachmentCount != value)
                {
                    this.attachmentCount = value;
                }
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

        public string content_type
        {
            get
            {
                return this.strType;
            }
            set
            {
                if (this.strType != value)
                {
                    this.strType = value;
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

        public string mailId
        {
            get
            {
                return this.strMId;
            }
            set
            {
                if (this.strMId != value)
                {
                    this.strMId = value;
                }
            }
        }

        public string mDate
        {
            get
            {
                return this.strDate;
            }
            set
            {
                if (this.strDate != value)
                {
                    this.strDate = value;
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

        public string reply
        {
            get
            {
                return this.strReply;
            }
            set
            {
                if (this.strReply != value)
                {
                    this.strReply = value;
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

