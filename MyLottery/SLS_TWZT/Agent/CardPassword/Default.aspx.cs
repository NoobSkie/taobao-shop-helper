using ASP;
using Shove._Web;
using System;
using System.Web.Profile;
using System.Web.SessionState;

public partial class Agent_CardPassword_Default : CardPasswordPageBase, IRequiresSessionState
{
    public string SubPage = "Welcome.aspx";

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SubPage = Utility.GetRequest("SubPage");
        if (this.SubPage == "")
        {
            this.SubPage = "Welcome.aspx";
        }
    }


}

