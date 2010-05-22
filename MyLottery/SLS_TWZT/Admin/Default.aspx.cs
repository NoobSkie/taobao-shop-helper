using ASP;
using Shove._Web;
using System;
using System.Web.Profile;
using System.Web.SessionState;

public partial class Admin_Default : AdminPageBase, IRequiresSessionState
{
    public string SubPage = "Welcome.aspx";

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (base._User.Competences.CompetencesList == "")
        {
            PF.GoError(3, "对不起，您没有足够的权限访问此页面", "Admin_Default");
        }
        else
        {
            this.SubPage = Utility.GetRequest("SubPage");
            if (this.SubPage == "")
            {
                this.SubPage = "Welcome.aspx";
            }
        }
    }


}

