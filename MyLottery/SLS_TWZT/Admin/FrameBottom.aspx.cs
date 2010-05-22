using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_FrameBottom : AdminPageBase, IRequiresSessionState
{


    protected void lbLogout_Click(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            string returnDescription = "";
            base._User.Logout(ref returnDescription);
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
        if (base._User.Competences.CompetencesList == "")
        {
            PF.GoError(3, "对不起，您没有足够的权限访问此页面", "Admin_FrameBottom");
        }
    }


}

