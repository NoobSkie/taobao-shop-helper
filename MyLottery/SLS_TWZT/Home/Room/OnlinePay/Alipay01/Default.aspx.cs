using ASP;
using Shove._Web;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_Alipay01_Default : RoomPageBase, IRequiresSessionState
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
        if (WebConfig.GetAppSettingsInt("OnlinePayType", 2) == 2)
        {
            base.Response.Redirect("../Alipay02/Default.aspx", true);
        }
    }

  
}

