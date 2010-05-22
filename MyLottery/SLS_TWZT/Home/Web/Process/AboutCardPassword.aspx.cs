using ASP;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Web_Process_AboutCardPassword : SitePageBase, IRequiresSessionState
{

    protected void Page_Load(object sender, EventArgs e)
    {
        base.Response.Cache.SetExpires(DateTime.Now.AddSeconds(600.0));
        base.Response.Cache.SetCacheability(HttpCacheability.Server);
        base.Response.Cache.VaryByParams["*"] = true;
        base.Response.Cache.SetValidUntilExpires(true);
        base.Response.Cache.SetVaryByCustom("SitePage");
    }
}

