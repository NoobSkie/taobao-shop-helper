using ASP;
using Shove._Web;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class MemberSharing_Alipay_Receive : Page, IRequiresSessionState
{

    private string Get_Http(string a_strUrl, int timeout)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(a_strUrl);
            request.Timeout = timeout;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            StringBuilder builder = new StringBuilder();
            while (-1 != reader.Peek())
            {
                builder.Append(reader.ReadLine());
            }
            return builder.ToString();
        }
        catch (Exception exception)
        {
            return ("错误：" + exception.Message);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (base.Request.QueryString.Count < 1)
        {
            JavaScript.Alert(this.Page, "接口调用失败，请重新登录。", "../../Home/Web/Default.aspx");
        }
        else
        {
            SystemOptions options = new SystemOptions();
            string str = "http://notify.alipay.com/trade/notify_query.do?";
            string str2 = options["MemberSharing_Alipay_UserNumber"].ToString("");
            str = str + "partner=" + str2 + "&notify_id=" + base.Request.QueryString["notify_id"];
            if (this.Get_Http(str, 0x1d4c0) == "false")
            {
                JavaScript.Alert(this.Page, "接口调用失败，请重新登录。", "../../Home/Web/Default.aspx");
            }
            else
            {
                string url = base.Request.Url.AbsoluteUri.Replace("/MemberSharing/Alipay/Receive.aspx?", "/Home/Web/UserRegisterForAlipayMemberSharing.aspx?");
                base.Response.Redirect(url, true);
            }
        }
    }
}

