using ASP;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.IO;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_WebConfig : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        this.tbContent.Text = File.ReadAllText(base.Server.MapPath("~/Web.Config"));
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            File.WriteAllText(base.Server.MapPath("~/Web.Config"), this.tbContent.Text);
        }
        catch (Exception exception)
        {
            PF.GoError(1, exception.Message, base.GetType().BaseType.FullName);
            return;
        }
        JavaScript.Alert(this.Page, "配置文件已经保存成功。");
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Options" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
        }
    }

}

