using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_Admin_NewsPaper : AdminPageBase, IRequiresSessionState
{

    private void BindDataForNewsPaperTypes()
    {
        DataTable dt = new Tables.T_NewsPaperIsuses().Open("", "", "[ID]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlNewsTypes, dt, "Name", "ID");
        }
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.ddlNewsTypes.SelectedValue))
        {
            if (MSSQL.ExecuteNonQuery("delete T_NewsPaperIsuses where ID=" + this.ddlNewsTypes.SelectedValue, new MSSQL.Parameter[0]) < 0)
            {
                JavaScript.Alert(this.Page, "删除失败！");
            }
            JavaScript.Alert(this.Page, "删除成功！");
            this.BindDataForNewsPaperTypes();
        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("Admin_NPIsusesAdd.aspx?ID=" + this.ddlNewsTypes.SelectedValue, true);
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "FillContent", "Administrator" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataForNewsPaperTypes();
            this.LinkButton1.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "FillContent" }));
            this.LinkButton2.Visible = this.LinkButton1.Visible;
        }
    }

 
}

