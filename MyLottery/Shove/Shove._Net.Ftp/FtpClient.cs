namespace Shove._Net.Ftp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Text;

    public class FtpClient
    {
        private string FtpServer;
        private FtpWebRequest FtpRequest;
        private string FtpPassword;
        private string FtpUserName;

        public FtpClient(string ftpServer, string ftpUserName, string ftpPassword) : this(ftpServer, ftpUserName, ftpPassword, 21)
        {
        }

        public FtpClient(string ftpServer, string ftpUserName, string ftpPassword, int ftpServerPort)
        {
            this.FtpServer = ftpServer;
            this.FtpUserName = ftpUserName;
            this.FtpPassword = ftpPassword;
            this.FtpServer = this.FtpServer + ((ftpServerPort > 0) ? string.Format(":{0}", ftpServerPort) : string.Empty);
        }

        private void Connect()
        {
            this.Connect("ftp://" + this.FtpServer + "/");
        }

        public bool CreateDirectory(string dirPath)
        {
            try
            {
                string str = "ftp://" + this.FtpServer + "/" + dirPath;
                this.Connect(str);
                this.FtpRequest.KeepAlive = false;
                this.FtpRequest.Method = "MKD";
                this.FtpRequest.Proxy = null;
                ((FtpWebResponse) this.FtpRequest.GetResponse()).Close();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public bool DeleteDirectory(string dirPath)
        {
            try
            {
                string str = "ftp://" + this.FtpServer + "/" + dirPath;
                this.Connect(str);
                this.FtpRequest.Method = "RMD";
                ((FtpWebResponse) this.FtpRequest.GetResponse()).Close();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public void DeleteFileName(string fileName)
        {
            string str = "ftp://" + this.FtpServer + "/" + fileName;
            try
            {
                this.Connect(str);
                this.FtpRequest.KeepAlive = false;
                this.FtpRequest.Method = "DELE";
                ((FtpWebResponse) this.FtpRequest.GetResponse()).Close();
            }
            catch (Exception exception)
            {
                throw new Exception(string.Format("删除文件“{0}”时出错！\n\n{1}", str, exception.Message));
            }
        }

        public bool Download(string filePath, string fileName, bool overWriteLocalFile, out string errorinfo)
        {
            return this.Download(filePath, fileName, overWriteLocalFile, null, out errorinfo);
        }

        public bool Download(string filePath, string fileName, bool overWriteLocalFile, TransmissionProcess transProcess, out string errorinfo)
        {
            if (transProcess == null)
            {
                transProcess = new TransmissionProcess();
            }
            errorinfo = string.Empty;
            try
            {
                string str = Path.GetFileName(fileName);
                string path = filePath + @"\" + str;
                if (System.IO.File.Exists(path) && !overWriteLocalFile)
                {
                    transProcess.TransStatus = TransferStatus.Failed;
                    errorinfo = string.Format("本地文件{0}已存在,无法下载", path);
                    return false;
                }
                if (System.IO.File.Exists(path))
                {
                    try
                    {
                        System.IO.File.Move(path, path);
                    }
                    catch
                    {
                        transProcess.TransStatus = TransferStatus.Failed;
                        errorinfo = "本地文件被占用！无法覆盖！";
                        return false;
                    }
                }
                string str3 = "ftp://" + this.FtpServer + "/" + fileName;
                this.Connect(str3);
                this.FtpRequest.Credentials = new NetworkCredential(this.FtpUserName, this.FtpPassword);
                FtpWebResponse response = (FtpWebResponse) this.FtpRequest.GetResponse();
                Stream responseStream = response.GetResponseStream();
                long contentLength = response.ContentLength;
                int count = 0x800;
                byte[] buffer = new byte[count];
                transProcess.FileName = str3;
                transProcess.TotalBytes = contentLength;
                if (transProcess.TransStatus != TransferStatus.InTransit)
                {
                    transProcess.TransStatus = TransferStatus.InTransit;
                }
                int bytes = responseStream.Read(buffer, 0, count);
                transProcess.AppendBytes(bytes);
                FileStream stream2 = new FileStream(path, FileMode.Create, FileAccess.Write);
                while (bytes > 0)
                {
                    stream2.Write(buffer, 0, bytes);
                    bytes = responseStream.Read(buffer, 0, count);
                    transProcess.AppendBytes(bytes);
                }
                responseStream.Close();
                stream2.Close();
                response.Close();
                transProcess.FinishBytes();
                return true;
            }
            catch (Exception exception)
            {
                transProcess.TransStatus = TransferStatus.Failed;
                errorinfo = string.Format("因{0},无法下载", exception.Message);
                return false;
            }
        }

        public string[] GetFileList()
        {
            return this.ReadContent("ftp://" + this.FtpServer + "/", "NLST");
        }

        public string[] GetFileList(string path)
        {
            return this.ReadContent("ftp://" + this.FtpServer + "/" + path, "NLST");
        }

        public string[] GetFilesDetailList()
        {
            return this.GetFilesDetailList(string.Empty);
        }

        public string[] GetFilesDetailList(string path)
        {
            return this.ReadContent("ftp://" + this.FtpServer + "/" + path, "LIST");
        }

        public long GetFileSize(string filename)
        {
            long contentLength = 0L;
            string str = "ftp://" + this.FtpServer + "/" + filename;
            try
            {
                this.Connect(str);
                this.FtpRequest.Method = "SIZE";
                FtpWebResponse response = (FtpWebResponse) this.FtpRequest.GetResponse();
                contentLength = response.ContentLength;
                response.Close();
            }
            catch (Exception exception)
            {
                throw new Exception(string.Format("获得文件“{0}”大小时出错！\n\n{1}", str, exception.Message));
            }
            return contentLength;
        }

        private string[] ReadContent(string strServer, string strCmd)
        {
            string[] strArray;
            List<string> list = new List<string>();
            try
            {
                this.Connect(strServer);
                this.FtpRequest.Method = strCmd;
                WebResponse response = this.FtpRequest.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                for (string str = reader.ReadLine(); str != null; str = reader.ReadLine())
                {
                    list.Add(str);
                }
                reader.Close();
                response.Close();
                strArray = list.ToArray();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return strArray;
        }

        private void Connect(string p0)
        {
            this.FtpRequest = (FtpWebRequest) WebRequest.Create(p0);
            this.FtpRequest.UseBinary = true;
            this.FtpRequest.UsePassive = false;
            this.FtpRequest.Credentials = new NetworkCredential(this.FtpUserName, this.FtpPassword);
        }

        public void Rename(string currentFilename, string newFilename)
        {
            string str = "ftp://" + this.FtpServer + "/" + currentFilename;
            try
            {
                this.Connect(str);
                this.FtpRequest.Method = "RENAME";
                this.FtpRequest.RenameTo = newFilename;
                ((FtpWebResponse) this.FtpRequest.GetResponse()).Close();
            }
            catch (Exception exception)
            {
                throw new Exception(string.Format("重命名文件“{0}”大小时出错！\n\n{1}", str, exception.Message));
            }
        }

        public bool TestConnection()
        {
            string errorInfo = string.Empty;
            return this.TestConnection(out errorInfo);
        }

        public bool TestConnection(out string errorInfo)
        {
            errorInfo = string.Empty;
            try
            {
                this.GetFileList();
                return true;
            }
            catch (Exception exception)
            {
                errorInfo = "【连接错误】详细信息是：" + exception.Message;
                return false;
            }
        }

        public void Upload(string filename, string serverPath)
        {
            this.Upload(filename, serverPath, null);
        }

        public void Upload(string filename, string serverPath, TransmissionProcess transProcess)
        {
            if (transProcess == null)
            {
                transProcess = new TransmissionProcess();
            }
            FileInfo info = new FileInfo(filename);
            string str = string.Format("ftp://{0}/{1}/{2}", this.FtpServer, serverPath, info.Name);
            transProcess.FileName = str;
            transProcess.TotalBytes = info.Length;
            this.Connect(str);
            this.FtpRequest.KeepAlive = false;
            this.FtpRequest.Method = "STOR";
            this.FtpRequest.ContentLength = info.Length;
            int count = 2048;
            byte[] buffer = new byte[count];
            FileStream stream = info.OpenRead();
            try
            {
                Stream requestStream = this.FtpRequest.GetRequestStream();
                for (int i = stream.Read(buffer, 0, count); i != 0; i = stream.Read(buffer, 0, count))
                {
                    if (transProcess.TransStatus != TransferStatus.InTransit)
                    {
                        transProcess.TransStatus = TransferStatus.InTransit;
                    }
                    requestStream.Write(buffer, 0, i);
                    transProcess.AppendBytes(i);
                }
                requestStream.Close();
                stream.Close();
                transProcess.TransStatus = TransferStatus.TranFinished;
            }
            catch (Exception exception)
            {
                transProcess.TransStatus = TransferStatus.Failed;
                throw new Exception(string.Format("向服务器上传文件时出错！\n\n{0}", exception.Message));
            }
        }
    }
}

