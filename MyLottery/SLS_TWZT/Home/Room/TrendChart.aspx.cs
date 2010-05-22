using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_TrendChart : SitePageBase, IRequiresSessionState
{

    protected void Page_Load(object sender, EventArgs e)
    {
        base.Response.Redirect("~/TrendCharts");
    }
}

