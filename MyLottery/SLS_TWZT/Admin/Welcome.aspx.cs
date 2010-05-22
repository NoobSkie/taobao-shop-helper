using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Admin_Welcome : AdminPageBase, IRequiresSessionState
{


    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (base._User.Competences.CompetencesList == "")
        {
            PF.GoError(3, "对不起，您没有足够的权限访问此页面", "Admin_Welcome");
        }
    }


}

