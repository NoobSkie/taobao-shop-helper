namespace Shove._IO
{
    using System;
    using System.IO;
    using System.Text;

    public class Log
    {
        private string log_Folder;
        private string filePath;

        public Log(string pathname)
        {
            if (string.IsNullOrEmpty(pathname))
            {
                throw new Exception("没有初始化 Log 类的 PathName 变量");
            }
            this.log_Folder = AppDomain.CurrentDomain.BaseDirectory + @"App_Log\" + pathname;
            if (!Directory.Exists(this.log_Folder))
            {
                try
                {
                    Directory.CreateDirectory(this.log_Folder);
                }
                catch
                {
                }
            }
            if (!Directory.Exists(this.log_Folder))
            {
                this.log_Folder = AppDomain.CurrentDomain.BaseDirectory + "App_Log";
                if (!Directory.Exists(this.log_Folder))
                {
                    try
                    {
                        Directory.CreateDirectory(this.log_Folder);
                    }
                    catch
                    {
                    }
                }
                if (!Directory.Exists(this.log_Folder))
                {
                    this.log_Folder = AppDomain.CurrentDomain.BaseDirectory;
                }
            }
            this.filePath = this.log_Folder + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
        }

        public void Write(string Message)
        {
            if (!string.IsNullOrEmpty(this.filePath))
            {
                using (FileStream stream = new FileStream(this.filePath, FileMode.Append, FileAccess.Write, FileShare.Write))
                {
                    StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding("GBK"));
                    try
                    {
                        writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + DateTime.Now.Millisecond.ToString() + "\t\t" + Message + "\r\n");
                    }
                    catch
                    {
                    }
                    writer.Close();
                }
            }
        }
    }
}

