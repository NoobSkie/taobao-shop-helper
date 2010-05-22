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

public partial class Admin_SchemeAtTop : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        if (this.ddlIsuse.Items.Count >= 1)
        {
            string str;
            if (this.cbUserApplication.Checked)
            {
                str = "select * from V_SchemeSchedules where SiteID = " + base._Site.ID.ToString() + " and IsuseID = " + this.ddlIsuse.SelectedValue + " and QuashStatus = 0 and Buyed = 0 and AtTopStatus = 1 order by [Money] desc";
            }
            else
            {
                str = "select * from V_SchemeSchedules where SiteID = " + base._Site.ID.ToString() + " and IsuseID = " + this.ddlIsuse.SelectedValue + " and QuashStatus = 0 and Buyed = 0 order by [Money] desc";
            }
            DataTable dt = MSSQL.Select(str, new MSSQL.Parameter[0]);
            if (dt == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_SchemeAtTop");
            }
            else
            {
                PF.DataGridBindData(this.g, dt, this.gPager);
            }
        }
    }

    private void BindDataForIsuse()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            DataTable dt = new Tables.T_Isuses().Open("", "StartTime < GetDate() and LotteryID = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue), "EndTime desc");
            if (dt == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_SchemeAtTop");
            }
            else
            {
                this.ddlIsuse.Items.Clear();
                ControlExt.FillDropDownList(this.ddlIsuse, dt, "Name", "ID");
            }
        }
    }

    private void BindDataForLottery()
    {
        DataTable dt = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryListRestrictions == "") ? "-1" : base._Site.UseLotteryListRestrictions) + ")", "[Order]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_SchemeAtTop");
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlLottery, dt, "Name", "ID");
        }
    }

    protected void cbUserApplication_CheckedChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void ddlIsuse_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindDataForIsuse();
        this.BindData();
    }

    protected void g_ItemCheckedChanged(object sender, EventArgs e)
    {
        CheckBox box = (CheckBox)sender;
        DataGridItem parent = (DataGridItem)box.Parent.Parent;
        long num = _Convert.StrToLong(parent.Cells[7].Text, 0L);
        bool flag = box.Checked;
        if (MSSQL.ExecuteNonQuery("update T_Schemes set AtTopStatus = " + (flag ? "2" : "0") + " where [ID] = " + num.ToString(), new MSSQL.Parameter[0]) < 0)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_SchemeAtTop");
        }
    }

    protected void g_ItemCreated(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            CheckBox box = (CheckBox)e.Item.Cells[6].FindControl("cbAtTop");
            box.CheckedChanged += new EventHandler(this.g_ItemCheckedChanged);
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            CheckBox box = (CheckBox)e.Item.Cells[6].FindControl("cbAtTop");
            box.Checked = _Convert.StrToShort(e.Item.Cells[8].Text, 0) == 2;
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

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "LotteryIsuseScheme", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataForLottery();
            this.BindDataForIsuse();
            this.BindData();
            this.g.Columns[6].Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "LotteryIsuseScheme" }));
        }
    }
}

