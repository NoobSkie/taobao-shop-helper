using ASP;
using FreeTextBoxControls;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Admin_RegisterAgreement : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        this.tbContent.Text = base._Site.SiteOptions["Opt_UserRegisterAgreement"].ToString("");
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            base._Site.SiteOptions["Opt_UserRegisterAgreement"] = new OptionValue(this.tbContent.Text);
        }
        catch (Exception exception)
        {
            PF.GoError(1, exception.Message, "Admin_Questions");
            return;
        }
        JavaScript.Alert(this.Page, "保存成功。");
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "FillContent", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
            this.btnOK.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "FillContent" }));
        }
    }


}

