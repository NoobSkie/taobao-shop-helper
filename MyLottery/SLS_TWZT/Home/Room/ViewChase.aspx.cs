using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_ViewChase : RoomPageBase, IRequiresSessionState
{

    private void BindChaseComboData()
    {
        string key = "Home_Room_ViewChase_BindChaseComboData" + base._User.ID.ToString() + this.tbTitle.Text;
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select a.ID,Name, DateTime,IsuseCount,IsuseCount*Multiple*Nums*Price as SumMoney,Money,QuashStatus,ExecutedCount,").Append("IsuseCount-ExecutedCount as NoExecutedCount,Title from T_Chases a inner join T_Lotteries b ").Append("on a.LotteryID = b.ID  and a.UserID = " + base._User.ID.ToString() + " ");
            if (this.tbTitle.Text != "")
            {
                builder.Append("and Title like '%" + Utility.FilteSqlInfusion(this.tbTitle.Text) + "%'");
            }
            builder.Append("  left join (select ChaseID,count(SchemeID) as ExecutedCount from  T_ExecutedChases group by ChaseID)c on a.ID = c.ChaseID");
            cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable);
        }
        PF.DataGridBindData(this.g2, cacheAsDataTable, this.gPager2);
        this.gPager2.Visible = true;
        double num3 = 0.0;
        foreach (DataRow row in cacheAsDataTable.Rows)
        {
            num3 += _Convert.StrToDouble(row["SumMoney"].ToString(), 0.0);
        }
        this.lblTotalMoney.Text = num3.ToString("N");
    }

    private void BindData()
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(base._Site.ID.ToString() + "MemberChase" + base._User.ID.ToString());
        string condition = string.Concat(new object[] { "[UserID] = ", base._User.ID.ToString(), " and SiteID = ", base._Site.ID });
        if (this.isDateValid())
        {
            string str2 = condition;
            condition = str2 + " and Convert(datetime,[DateTime]) between '" + this.txtStartDate.Text + " 0:0:0' and '" + this.txtEndDate.Text + " 23:59:59'";
        }
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Views.V_ChaseTasksTotal().Open("", condition, "[DateTime] desc");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Room_ViewChase");
                return;
            }
            Shove._Web.Cache.SetCache(base._Site.ID.ToString() + "MemberChase" + base._User.ID.ToString(), cacheAsDataTable);
        }
        PF.DataGridBindData(this.g1, cacheAsDataTable, this.gPager1);
        this.gPager1.Visible = true;
        this.lblPageBuyMoney.Text = PF.GetSumByColumn(cacheAsDataTable, 12, true, this.gPager1.PageSize, this.gPager1.PageIndex).ToString("N");
        this.lblTotalBuyMoney.Text = PF.GetSumByColumn(cacheAsDataTable, 12, false, this.gPager1.PageSize, this.gPager1.PageIndex).ToString("N");
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        Shove._Web.Cache.ClearCache(base._Site.ID.ToString() + "MemberChase" + base._User.ID.ToString());
        if (this.isDateValid())
        {
            this.BindData();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindChaseComboData();
    }

    protected void g1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            string str = e.Item.Cells[2].Text.Trim();
            if (str.Length > 8)
            {
                str = str.Substring(0, 7) + "..";
            }
            e.Item.Cells[2].Text = "<a href='ChaseDetail.aspx?id=" + e.Item.Cells[8].Text + "'><font color=\"#330099\">" + str + "</Font></a>";
            string text = e.Item.Cells[1].Text;
            e.Item.Cells[1].Text = "<a href='ChaseDetail.aspx?id=" + e.Item.Cells[8].Text + "'><font color=\"#330099\">" + text + "</Font></a>";
            double num = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            e.Item.Cells[3].Text = (num == 0.0) ? "" : num.ToString("N");
            int num2 = _Convert.StrToInt(e.Item.Cells[4].Text, 0);
            int num3 = _Convert.StrToInt(e.Item.Cells[5].Text, 0);
            int num4 = _Convert.StrToInt(e.Item.Cells[6].Text, 0);
            e.Item.Cells[7].Text = (num2 > (num3 + num4)) ? "<Font color='Red'>进行中</font>" : "已终止";
        }
    }

    protected void g1_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        this.BindData();
    }

    protected void g2_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            int num = _Convert.StrToInt(e.Item.Cells[4].Text, 0);
            int num2 = _Convert.StrToInt(e.Item.Cells[5].Text, 0);
            int num3 = _Convert.StrToInt(e.Item.Cells[7].Text, 0);
            e.Item.Cells[7].Text = (num3 == 1) ? "已终止" : ((num == num2) ? "已完成" : "<Font color='Red'>进行中</font>");
            e.Item.Cells[2].Text = "<a style='TEXT-DECORATION: underline;color:red' href='ChaseExecutedSchemes.aspx?id=" + e.Item.Cells[8].Text + "' target='_blank'>" + e.Item.Cells[2].Text + "</a>";
        }
    }

    protected void g2_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        this.BindChaseComboData();
    }

    protected void gPager1_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindData();
    }

    protected void gPager1_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindData();
    }

    protected void gPager2_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindChaseComboData();
    }

    protected void gPager2_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindChaseComboData();
    }

    private bool isDateValid()
    {
        if (_Convert.StrToDateTime(this.txtStartDate.Text, "2000-1-1") > _Convert.StrToDateTime(this.txtEndDate.Text, "2000-1-1"))
        {
            JavaScript.Alert(this.Page, "终止日期要大于等于起始日期！");
            return false;
        }
        if (!(_Convert.StrToDateTime(this.txtStartDate.Text, "2000-1-1") == Convert.ToDateTime("2000-1-1")) && !(_Convert.StrToDateTime(this.txtEndDate.Text, "2000-1-1") == Convert.ToDateTime("2000-1-1")))
        {
            return true;
        }
        JavaScript.Alert(this.Page, "请输入正确的起始日期(格式: 2009-1-1)！");
        return false;
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.txtStartDate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            this.txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.BindData();
            this.BindChaseComboData();
        }
    }
}

