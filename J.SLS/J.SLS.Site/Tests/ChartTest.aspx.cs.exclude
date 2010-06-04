using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;

public partial class Tests_ChartTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        string Url = txtUrl.Text;

        lblInnerHtml.Text = DoGet(Url);
    }

    private string DoGet(string url)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        req.Method = "GET";
        req.KeepAlive = true;
        req.UserAgent = "SLS";
        req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

        HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
        Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
        return GetResponseAsString(rsp, encoding);
    }

    private string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
    {
        StringBuilder result = new StringBuilder();
        Stream stream = null;
        StreamReader reader = null;

        try
        {
            // 以字符流的方式读取HTTP响应
            stream = rsp.GetResponseStream();
            reader = new StreamReader(stream, encoding);

            // 每次读取不大于256个字符，并写入字符串
            char[] buffer = new char[256];
            int readBytes = 0;
            while ((readBytes = reader.Read(buffer, 0, buffer.Length)) > 0)
            {
                result.Append(buffer, 0, readBytes);
            }
        }
        finally
        {
            // 释放资源
            if (reader != null) reader.Close();
            if (stream != null) stream.Close();
            if (rsp != null) rsp.Close();
        }

        return result.ToString();
    }
}
