using ASP;
using Shove._Web;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_Default : RoomPageBase, IRequiresSessionState
{
    protected override void OnLoad(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = "~/Home/Room/OnlinePay/Default.aspx";
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebConfig.GetAppSettingsInt("OnlinePayType", 2) == 1)
        {
            base.Response.Redirect("Alipay01/Send.aspx", true);
        }
        else
        {
            base.Response.Redirect("Alipay02/Send_Default.aspx", true);
        }
    }
}

