using ASP;
using DAL;
using Shove;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_ExpertsPredictNews : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        this.hlExpertsPredictNewAdd.NavigateUrl = "ExpertsPredictNewsAdd.aspx";
        DataTable table = new Tables.T_ExpertsPredictNews().Open("", "", "");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(-62)");
        }
        else
        {
            this.g.DataSource = table;
            this.g.DataBind();
        }
    }

    private void BindExpertsPredict()
    {
        DataTable table = new Tables.T_ExpertsPredict().Open("", "", "[ID]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(-40)");
        }
        else
        {
            this.ddlExpertsPredictNews.DataSource = table;
            this.ddlExpertsPredictNews.DataTextField = "Name";
            this.ddlExpertsPredictNews.DataValueField = "ID";
            this.ddlExpertsPredictNews.DataBind();
        }
    }

    protected void ddlExpertsPredictNews_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            base.Response.Redirect("ExpertsPredictNewsEdit.aspx?ID=" + e.Item.Cells[6].Text, true);
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            CheckBox box = (CheckBox)e.Item.Cells[4].FindControl("cbisShow");
            box.Checked = _Convert.StrToBool(e.Item.Cells[7].Text, true);
            CheckBox box2 = (CheckBox)e.Item.Cells[3].FindControl("cbisWinning");
            box2.Checked = _Convert.StrToBool(e.Item.Cells[8].Text, true);
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "FillContent" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindExpertsPredict();
            this.BindData();
        }
    }


}

