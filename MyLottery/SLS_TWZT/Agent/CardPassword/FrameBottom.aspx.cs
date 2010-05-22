using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Agent_CardPassword_FrameBottom : CardPasswordPageBase, IRequiresSessionState
{


    protected void lbLogout_Click(object sender, EventArgs e)
    {
        if (base._CardPasswordAgentUser != null)
        {
            string returnDescription = "";
            base._CardPasswordAgentUser.Logout(ref returnDescription);
        }
        base.Response.Write("<script language=\"javascript\">window.top.location.href=\"../Default.aspx\"</script>");
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isAtFramePageLogin = false;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }


}

