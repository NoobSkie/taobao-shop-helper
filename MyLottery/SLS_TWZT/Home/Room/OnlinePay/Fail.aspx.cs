using ASP;
using Shove._Web;
using System;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_OnlinePay_Fail : RoomPageBase, IRequiresSessionState
{
    protected override void OnLoad(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isAllowPageCache = false;
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            string request = Utility.GetRequest("errMsg");
            this.lab1.Text = string.IsNullOrEmpty(request) ? base._Site.Name : HttpUtility.UrlDecode(request, Encoding.GetEncoding("GB2312"));
        }
    }
}

