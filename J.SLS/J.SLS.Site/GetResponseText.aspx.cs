using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using J.SLS.Common.Logs;
using J.SLS.Facade;
using System.Text;

public partial class GetResponseText : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DateTime fromTime = GetRequestDate();
            IssueNoticeFacade facade = new IssueNoticeFacade();
            IList<string> list = facade.GetRequestTextList(fromTime);
            string r = string.Join("@", list.ToArray());
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(Server.UrlEncode(r));
            Response.OutputStream.Write(bytes, 0, bytes.Length);
        }
        catch (Exception ex)
        {
            LogWriter.Write(LogCategory.Application, "同步通知数据失败", ex);
        }
    }

    private DateTime GetRequestDate()
    {
        using (StreamReader reader = new StreamReader(Request.InputStream))
        {
            string request = reader.ReadToEnd();
            return DateTime.Parse(request);
        }
    }
}
