using ASP;
using Shove._Web;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Web_UserRegAgree : SitePageBase, IRequiresSessionState
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            string str = base.Request["type"];
            string str2 = "Opt_UserRegisterAgreement";
            if (!string.IsNullOrEmpty(str) && (str.Trim().ToUpper() == "CPS"))
            {
                str2 = "Opt_CpsRegisterAgreement";
            }
            this.labAgreement.Text = base._Site.SiteOptions[str2].ToString("").Replace("[SiteName]", base._Site.Name).Replace("[SiteUrl]", Utility.GetUrl()).Replace("http://www.icaile.com", Utility.GetUrl());
        }
    }

}

