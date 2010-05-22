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

public partial class Admin_Advertisements : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        this.hlAdd.NavigateUrl = "AdvertisementsAdd.aspx?LotteryID=" + this.ddlLotteries.SelectedValue + "&TypeID=" + this.ddlType.SelectedValue;
        DataTable table = new Tables.T_Advertisements().Open("", "LotteryID=" + Utility.FilteSqlInfusion(this.ddlLotteries.SelectedValue) + " and [Name]='" + Utility.FilteSqlInfusion(this.ddlType.SelectedItem.Text) + "'", "[Order]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(59)");
        }
        else
        {
            this.g.DataSource = table;
            this.g.DataBind();
        }
    }

    private void BindType()
    {
        string request = Utility.GetRequest("LotteryID");
        string str2 = Utility.GetRequest("TypeID");
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
        if (this.ddlType.Items.FindByValue(str2) != null)
        {
            this.ddlType.SelectedValue = str2;
        }
    }

    protected void ddlLotteries_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            base.Response.Redirect("AdvertisementsEdit.aspx?ID=" + e.Item.Cells[6].Text + "&LotteryID=" + this.ddlLotteries.SelectedValue + "&TypeID=" + this.ddlType.SelectedValue, true);
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            CheckBox box = (CheckBox)e.Item.Cells[4].FindControl("cbisShow");
            box.Checked = _Convert.StrToBool(e.Item.Cells[7].Text, true);
            e.Item.Cells[0].Text = e.Item.Cells[0].Text.Split(new string[] { "Color" }, StringSplitOptions.None)[0];
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
            this.BindType();
            this.ddlType_SelectedIndexChanged(this.ddlType, new EventArgs());
            this.hlAdd.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "FillContent" }));
            this.g.Columns[5].Visible = this.hlAdd.Visible;
        }
    }

}

