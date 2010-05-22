using ASP;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_ExecSQLScript : AdminPageBase, IRequiresSessionState
{

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (this.tbPassword.Text != (base._User.Name + base._User.Balance.ToString()))
        {
            JavaScript.Alert(this.Page, "系统密码错误，请向开发商咨询此密码！");
        }
        else if (MSSQL.ExecuteSQLScript(this.tbSQL.Text))
        {
            JavaScript.Alert(this.Page, "脚本执行成功！");
        }
        else
        {
            JavaScript.Alert(this.Page, "脚本执行失败！请检查 SQL 脚本是否符合规范。");
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Administrator" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }


}

