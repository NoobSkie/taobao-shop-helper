using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_SupperCoBuy : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        DataTable dt = MSSQL.Select("select top 10 SchemeNumber, InitiateName, Money, PlayTypeName, Share, Schedule, ID from V_Schemes with (nolock) where SiteID = " + base._Site.ID.ToString() + "  and Share > BuyedShare and QuashStatus = 0  and LotteryID = " + this.ddlLottery.SelectedValue + " and datediff(mi,getdate(),SystemEndTime) > 0 order by [Money] desc", new MSSQL.Parameter[0]);
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_SchemeAtTop");
        }
        else
        {
            PF.DataGridBindData(this.g, dt, this.gPager);
        }
    }

    private void BindDataForLottery()
    {
        DataTable dt = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[Order]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_SchemeAtTop");
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlLottery, dt, "Name", "ID");
        }
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void g_ItemCheckedChanged(object sender, EventArgs e)
    {
        CheckBox box = (CheckBox)sender;
        DataGridItem parent = (DataGridItem)box.Parent.Parent;
        long num = _Convert.StrToLong(parent.Cells[7].Text, 0L);
        bool flag = box.Checked;
        int num2 = _Convert.StrToInt(Utility.GetRequest("TypeState"), 1);
        string commandText = "";
        if (flag)
        {
            if (!this.IsCheck(num.ToString()))
            {
                commandText = string.Concat(new object[] { "insert T_SchemeSupperCobuy values(", num, ",", num2, ")" });
            }
        }
        else
        {
            commandText = string.Concat(new object[] { "delete T_SchemeSupperCobuy where SchemeID=", num, " and TypeState = ", num2 });
        }
        if (MSSQL.ExecuteNonQuery(commandText, new MSSQL.Parameter[0]) < 0)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_SupperCoBuy");
        }
        else
        {
            Shove._Web.Cache.ClearCache("SupperCobuy");
        }
    }

    protected void g_ItemCreated(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            CheckBox box = (CheckBox)e.Item.Cells[6].FindControl("cbCommend");
            box.CheckedChanged += new EventHandler(this.g_ItemCheckedChanged);
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            CheckBox box = (CheckBox)e.Item.Cells[6].FindControl("cbCommend");
            box.Checked = this.IsCheck(e.Item.Cells[7].Text);
        }
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindData();
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindData();
    }

    private bool IsCheck(string schemeID)
    {
        bool flag = false;
        DataTable table = new Tables.T_SchemeSupperCobuy().Open("", "TypeState=" + Utility.GetRequest("TypeState"), "");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_SchemeAtTop");
            return flag;
        }
        foreach (DataRow row in table.Rows)
        {
            if (row["SchemeID"].ToString() == schemeID)
            {
                return true;
            }
        }
        return flag;
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
            this.BindDataForLottery();
            this.BindData();
            this.g.Columns[6].Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "FillContent" }));
        }
    }
}

