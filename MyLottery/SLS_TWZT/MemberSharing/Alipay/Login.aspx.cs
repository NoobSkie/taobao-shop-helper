using Alipay.Gateway;
using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class MemberSharing_Alipay_Login : Page, IRequiresSessionState
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string url = new Member().BuildLoginUrl();
        base.Response.Redirect(url, true);
    }
}

