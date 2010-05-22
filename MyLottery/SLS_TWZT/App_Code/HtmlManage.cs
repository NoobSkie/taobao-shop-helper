using System;
using System.IO;
using System.Text;
using System.Web;
using Shove._IO;

public class HmtlManage
{
    public static string GetHtml(string path)
    {
        if (!System.IO.File.Exists(path))
        {
            new Log("System").Write("未找到文件 " + path);
            return "";
        }
        FileInfo info = new FileInfo(path);
        DateTime lastWriteTime = info.LastWriteTime;
        string str = "Html_" + info.Name;
        object obj2 = HttpContext.Current.Application[str];
        string str2 = "";
        DateTime time2 = lastWriteTime;
        if (obj2 == null)
        {
            StreamReader reader = new StreamReader(path, Encoding.GetEncoding("GBK"));
            str2 = reader.ReadToEnd();
            reader.Close();
        }
        else
        {
            object[] objArray = (object[])obj2;
            str2 = (string)objArray[0];
            time2 = (DateTime)objArray[1];
        }
        if (lastWriteTime != time2)
        {
            object[] objArray3 = new object[] { str2, time2 };
            HttpContext.Current.Application.Lock();
            HttpContext.Current.Application[str] = objArray3;
            HttpContext.Current.Application.UnLock();
        }
        return str2;
    }
}

