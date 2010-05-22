using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

public partial class Scheme : Page, IRequiresSessionState
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.Response.Redirect("Home/Room/Scheme.aspx?" + base.Request.Url.Query, true);
    }
}

