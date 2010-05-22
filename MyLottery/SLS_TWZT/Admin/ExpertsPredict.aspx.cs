using ASP;
using DAL;
using Shove;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_ExpertsPredict : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        this.hlAdd.NavigateUrl = "ExpertsPredictAdd.aspx";
        DataTable table = new Tables.T_ExpertsPredict().Open("", "LotteryID=" + this.ddlLotteries.SelectedValue, "");
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

    private void BindLotteryType()
    {
        DataTable table = new Tables.T_Lotteries().Open("[ID], [Name], [Code]", "[ID] in(" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[ID]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(-46)");
        }
        else
        {
            this.ddlLotteries.DataSource = table;
            this.ddlLotteries.DataTextField = "Name";
            this.ddlLotteries.DataValueField = "ID";
            this.ddlLotteries.DataBind();
        }
    }

    protected void ddlLotteries_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            base.Response.Redirect("ExpertsPredictEdit.aspx?ID=" + e.Item.Cells[6].Text, true);
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            CheckBox box = (CheckBox)e.Item.Cells[4].FindControl("cbisShow");
            box.Checked = _Convert.StrToBool(e.Item.Cells[7].Text, true);
        }
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
            this.BindLotteryType();
            this.BindData();
            this.hlAdd.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "FillContent" }));
            this.hlExpertsPredictNew.Visible = this.hlAdd.Visible;
            this.hlExpertsPredictNewAdd.Visible = this.hlAdd.Visible;
            this.g.Columns[5].Visible = this.hlAdd.Visible;
        }
    }
}

