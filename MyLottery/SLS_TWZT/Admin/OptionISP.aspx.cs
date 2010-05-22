using ASP;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_OptionISP : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        this.tb1.Text = base._Site.SiteOptions["Opt_ISP_HostName"].ToString("");
        this.tb2.Text = base._Site.SiteOptions["Opt_ISP_HostPort"].ToString("");
        this.tb3.Text = base._Site.SiteOptions["Opt_ISP_UserID"].ToString("");
        this.tb4.Text = base._Site.SiteOptions["Opt_ISP_UserPassword"].ToString("");
        this.tb5.Text = base._Site.SiteOptions["Opt_ISP_RegCode"].ToString("");
        this.tb6.Text = base._Site.SiteOptions["Opt_ISP_ServiceNumber"].ToString("");
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            base._Site.SiteOptions["Opt_ISP_HostName"] = new OptionValue(this.tb1.Text);
            base._Site.SiteOptions["Opt_ISP_HostPort"] = new OptionValue(this.tb2.Text);
            base._Site.SiteOptions["Opt_ISP_UserID"] = new OptionValue(this.tb3.Text);
            base._Site.SiteOptions["Opt_ISP_UserPassword"] = new OptionValue(this.tb4.Text);
            base._Site.SiteOptions["Opt_ISP_RegCode"] = new OptionValue(this.tb5.Text);
            base._Site.SiteOptions["Opt_ISP_ServiceNumber"] = new OptionValue(this.tb6.Text);
        }
        catch (Exception exception)
        {
            JavaScript.Alert(this.Page, exception.Message);
            return;
        }
        JavaScript.Alert(this.Page, "设置成功。");
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Options", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
            this.btnOK.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "Options" }));
        }
        this.tb4.Attributes.Add("value", this.tb4.Text);
    }


}

