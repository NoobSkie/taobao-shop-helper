using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using J.SLS.Facade;
using J.SLS.Common.Logs;

public partial class UpdateRequestData : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            IssueNoticeFacade facade = new IssueNoticeFacade();
            DateTime fromTime = facade.GetCurrentUpdateTime();
            string r = Post("http://222.186.12.129:8099/GetResponseText.aspx", fromTime.ToString("yyyy-MM-dd HH:mm:ss"), 5000);
            if (!string.IsNullOrEmpty(r))
            {
                r = Server.UrlDecode(r);
                string[] list = r.Split('@');
                int i = 0;
                foreach (string body in list)
                {
                    string str = Post("http://localhost:47599/J.SLS.Site/HP_Recevie.aspx", body, 5000);
                    Response.Write(Server.UrlDecode(str) + "<br />");
                    i++;
                }
                facade.ModifyCurrentUpdateTime();
                Response.Write("<br />");
                Response.Write("<b>成功同步 " + i + "条请求数据！</b><br />");
            }
            else
            {
                Response.Write("<b>nothing</b><br />");
            }
        }
        catch (Exception ex)
        {
            LogWriter.Write(LogCategory.Application, "同步通知失败", ex);
            Response.Write("<b>同步发生异常 - " + ex.Message + "</b><br />");
        }
    }

    public string Post(string Url, string RequestString, int TimeoutSeconds)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
        if (TimeoutSeconds > 0)
        {
            request.Timeout = 0x3e8 * TimeoutSeconds;
        }
        request.Method = "POST";
        request.AllowAutoRedirect = true;
        request.ContentType = "application/x-www-form-urlencoded";
        byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(RequestString);
        Stream requestStream = request.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);
        requestStream.Close();
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));
        return reader.ReadToEnd();
    }
}
