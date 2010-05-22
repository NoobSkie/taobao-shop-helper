using Shove._IO;
using System;
using System.IO;
using System.Text;

public class Log
{
    private string FileName;
    private string PathName;

    public Log(string pathname)
    {
        if (string.IsNullOrEmpty(pathname))
        {
            throw new Exception("没有初始化 Log 类的 PathName 变量");
        }
        this.PathName = AppDomain.CurrentDomain.BaseDirectory + @"App_Log\" + pathname;
        if (!Directory.Exists(this.PathName))
        {
            try
            {
                Directory.CreateDirectory(this.PathName);
            }
            catch
            {
            }
        }
        if (!Directory.Exists(this.PathName))
        {
            this.PathName = AppDomain.CurrentDomain.BaseDirectory + "App_Log";
            if (!Directory.Exists(this.PathName))
            {
                try
                {
                    Directory.CreateDirectory(this.PathName);
                }
                catch
                {
                }
            }
            if (!Directory.Exists(this.PathName))
            {
                this.PathName = AppDomain.CurrentDomain.BaseDirectory;
            }
        }
        this.FileName = this.PathName + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
    }

    public void Write(string Message)
    {
        if (!string.IsNullOrEmpty(this.FileName))
        {
            using (FileStream stream = new FileStream(this.FileName, FileMode.Append, FileAccess.Write, FileShare.Write))
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

    public void WriteIni(string Message)
    {
        this.WriteIni("Log", Message);
    }

    public void WriteIni(string Section, string Message)
    {
        if (!string.IsNullOrEmpty(this.FileName))
        {
            new IniFile(this.FileName).Write(Section, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + DateTime.Now.Millisecond.ToString(), Message);
        }
    }
}

