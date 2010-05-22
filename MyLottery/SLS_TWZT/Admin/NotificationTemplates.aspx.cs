using ASP;
using DAL;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_NotificationTemplates : AdminPageBase, IRequiresSessionState
{

    private void BindDataForNotificationType()
    {
        DataTable table = new Tables.T_NotificationTypes().Open("[Name], [Code]", "", "[ID]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_NotificationTemplates");
        }
        else
        {
            this.listTemplateFile.DataSource = table;
            this.listTemplateFile.DataTextField = "Name";
            this.listTemplateFile.DataValueField = "Code";
            this.listTemplateFile.DataBind();
            this.listTemplateFile.SelectedIndex = 0;
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            base._Site.SiteNotificationTemplates[short.Parse(this.ddlTemplateType.SelectedValue), this.listTemplateFile.SelectedValue] = this.tbContent.Text;
        }
        catch (Exception exception)
        {
            JavaScript.Alert(this.Page, exception.Message);
            return;
        }
        JavaScript.Alert(this.Page, "保存成功。");
    }

    protected void ddlTemplateType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.listTemplateFile_SelectedIndexChanged(this.listTemplateFile, new EventArgs());
    }

    protected void listTemplateFile_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.tbContent.Text = base._Site.SiteNotificationTemplates[short.Parse(this.ddlTemplateType.SelectedValue), this.listTemplateFile.SelectedValue];
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
            this.BindDataForNotificationType();
            this.ddlTemplateType_SelectedIndexChanged(this.ddlTemplateType, e);
            this.btnOK.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "Options" }));
        }
    }


}

