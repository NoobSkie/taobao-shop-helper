using ASP;
using DAL;
using Shove;
using Shove._Web;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_Personages : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        this.hlAdd.NavigateUrl = "PersonagesAdd.aspx?LotteryID=" + this.ddlLotteries.SelectedValue;
        string key = "Admin_Personages";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_Personages().Open("", "", "[Order]");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(59)");
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
        }
        DataRow[] rowArray = cacheAsDataTable.Select("LotteryID=" + this.ddlLotteries.SelectedValue);
        DataTable table2 = cacheAsDataTable.Clone();
        foreach (DataRow row in rowArray)
        {
            table2.Rows.Add(row.ItemArray);
        }
        this.g.DataSource = table2;
        this.g.DataBind();
    }

    private void BindLotteryType()
    {
        string request = Utility.GetRequest("LotteryID");
        string key = "dtLotteriesUseLotteryList";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_Lotteries().Open("[ID], [Name], [Code]", "[ID] in(" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[ID]");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(-46)");
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
        }
        this.ddlLotteries.DataSource = cacheAsDataTable;
        this.ddlLotteries.DataTextField = "Name";
        this.ddlLotteries.DataValueField = "ID";
        this.ddlLotteries.DataBind();
        if (this.ddlLotteries.Items.FindByValue(request) != null)
        {
            this.ddlLotteries.SelectedValue = request;
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
            base.Response.Redirect("PersonagesEdit.aspx?ID=" + e.Item.Cells[5].Text, true);
        }
        if (e.CommandName == "Deletes")
        {
            string text = e.Item.Cells[5].Text;
            new Tables.T_Personages().Delete("ID=" + text);
            Shove._Web.Cache.ClearCache("Admin_Personages");
            this.BindData();
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            CheckBox box = (CheckBox)e.Item.Cells[3].FindControl("cbisShow");
            box.Checked = _Convert.StrToBool(e.Item.Cells[6].Text, true);
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
            this.g.Columns[4].Visible = this.hlAdd.Visible;
        }
    }


}

