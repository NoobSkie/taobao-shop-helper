using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_SmsPlay : RoomPageBase, IRequiresSessionState
{

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isAllowPageCache = false;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}

