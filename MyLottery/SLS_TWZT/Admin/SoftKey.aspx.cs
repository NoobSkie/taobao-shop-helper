using ASP;
using Shove._Web;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_SoftKey : AdminPageBase, IRequiresSessionState
{

    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            SystemOptions options = new SystemOptions();
            options["SerialNumberForShoveSoft_MHB"] = new OptionValue(this.tbKeyOK.Text);
        }
        catch (Exception exception)
        {
            PF.GoError(1, exception.Message, "Admin_SoftKey.aspx");
            return;
        }
        JavaScript.Alert(this.Page, "注册成功。");
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
            this.tbKey.Text = PF.GetMID();
        }
    }


}

