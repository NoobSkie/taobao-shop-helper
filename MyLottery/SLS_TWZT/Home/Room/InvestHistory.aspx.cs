using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using SLS;
using System;
using System.Data;
using System.Linq;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_InvestHistory : RoomPageBase, IRequiresSessionState
{
    private int[] arrLotteries = new int[] { 5, 6, 0x1d, 0x27 };

    private void BindDataForIsuse()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            this.ddlIsuse.Items.Clear();
            this.ddlIsuse.Items.Add(new ListItem("全部", "-1"));
            if (this.ddlLottery.SelectedValue != "-1")
            {
                DataTable table = new Tables.T_Isuses().Open("[ID], [Name]", "LotteryID = " + _Convert.StrToInt(this.ddlLottery.SelectedValue, -1).ToString() + " and EndTime < GetDate()", "EndTime desc");
                if (table != null)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        this.ddlIsuse.Items.Add(new ListItem(row["Name"].ToString(), row["ID"].ToString()));
                    }
                }
            }
        }
    }

    private void BindDataForLottery()
    {
        this.ddlLottery.Items.Clear();
        this.ddlLottery.Items.Add(new ListItem("全部彩种", "-1"));
        if (base._Site.UseLotteryList == "")
        {
            PF.GoError(1, "暂无玩法", base.GetType().FullName);
        }
        else
        {
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
            for (int i = 0; i < cacheAsDataTable.Rows.Count; i++)
            {
                string str2 = cacheAsDataTable.Rows[i]["ID"].ToString();
                key = "dtVPlayTypes_" + str2.ToString();
                DataTable table2 = Shove._Web.Cache.GetCacheAsDataTable(key);
                if (table2 == null)
                {
                    table2 = new Views.V_PlayTypes().Open("", "LotteryID = " + str2.ToString(), "[ID]");
                    if ((table2 == null) || (table2.Rows.Count < 1))
                    {
                        PF.GoError(7, "数据库繁忙，请重试", base.GetType().FullName);
                        return;
                    }
                    Shove._Web.Cache.SetCache(key, table2, 0x1770);
                }
                if (this.arrLotteries.Contains<int>(_Convert.StrToInt(cacheAsDataTable.Rows[i]["ID"].ToString(), 0)))
                {
                    this.ddlLottery.Items.Add(new ListItem(table2.Rows[0]["LotteryName"].ToString(), table2.Rows[0]["LotteryID"].ToString()));
                }
            }
            if (this.ddlLottery.Items.Count > 0)
            {
                this.BindDataForPlayType(this.ddlLottery.Items[0].Value);
            }
        }
    }

    private void BindDataForPlayType()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            this.ddlPlayType.Items.Clear();
            this.ddlPlayType.Items.Add(new ListItem("全部玩法", "-1"));
            if (this.ddlLottery.SelectedValue != "-1")
            {
                foreach (Lottery.PlayType type in new Lottery()[int.Parse(this.ddlLottery.SelectedValue)].GetPlayTypeList())
                {
                    this.ddlPlayType.Items.Add(new ListItem(type.Name, type.ID.ToString()));
                }
            }
        }
    }

    private void BindDataForPlayType(string LotteryID)
    {
        this.ddlPlayType.Items.Clear();
        this.ddlPlayType.Items.Add(new ListItem("全部玩法", "-1"));
        DataTable table = new Views.V_PlayTypes().Open("ID,LotteryID,Name,LotteryName,BuyFileName", "LotteryID=" + LotteryID, "");
        if (table == null)
        {
            PF.GoError(1, "暂无玩法", base.GetType().FullName);
        }
        else
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                this.ddlPlayType.Items.Add(new ListItem(table.Rows[i]["Name"].ToString(), table.Rows[i]["ID"].ToString()));
            }
        }
    }

    private void BindHistoryData()
    {
        if (this.ddlIsuse.Items.Count < 0)
        {
            JavaScript.Alert(this.Page, "请选择彩种、玩法和期号。");
        }
        else
        {
            string condition = " [UserID] = " + base._User.ID.ToString();
            if (this.ddlLottery.SelectedValue != "-1")
            {
                condition = condition + " and LotteryID=" + _Convert.StrToInt(this.ddlLottery.SelectedValue, -1).ToString();
            }
            if (this.ddlIsuse.SelectedValue == "-1")
            {
                condition = condition + " and EndTime < GetDate()";
            }
            else
            {
                condition = condition + " and IsuseID=" + _Convert.StrToLong(this.ddlIsuse.SelectedValue, -1L).ToString();
            }
            if (this.ddlPlayType.SelectedValue != "-1")
            {
                condition = condition + " and PlayTypeID = " + _Convert.StrToInt(this.ddlPlayType.SelectedValue, -1).ToString();
            }
            string key = "InvestHistory_" + condition;
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = new Views.V_BuyDetailsWithQuashedAll().Open("*", condition, "[DateTime] desc, [ID]");
                if (cacheAsDataTable == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                    return;
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 60);
            }
            PF.DataGridBindData(this.gHistory, cacheAsDataTable, this.gPagerHistory);
            this.gPagerHistory.Visible = true;
            this.lblPageBuySum.Text = PF.GetSumByColumn(cacheAsDataTable, 10, true, this.gPagerHistory.PageSize, this.gPagerHistory.PageIndex).ToString("N");
            this.lblPageRewardSum.Text = PF.GetSumByColumn(cacheAsDataTable, 8, true, this.gPagerHistory.PageSize, this.gPagerHistory.PageIndex).ToString("N");
            this.lblTotalBuySum.Text = PF.GetSumByColumn(cacheAsDataTable, 10, false, this.gPagerHistory.PageSize, this.gPagerHistory.PageIndex).ToString("N");
            this.lblTotalRewardSum.Text = PF.GetSumByColumn(cacheAsDataTable, 8, false, this.gPagerHistory.PageSize, this.gPagerHistory.PageIndex).ToString("N");
        }
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        if (this.ddlLottery.SelectedIndex < 0)
        {
            JavaScript.Alert(this.Page, "请选择彩种。");
        }
        else
        {
            this.BindHistoryData();
        }
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindDataForPlayType();
        this.BindDataForIsuse();
    }

    protected void gHistory_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            long num = _Convert.StrToLong(e.Item.Cells[12].Text, 0L);
            string text = e.Item.Cells[1].Text;
            if (text.Length > 6)
            {
                text = text.Substring(0, 5) + "..";
            }
            e.Item.Cells[1].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'><font color=\"#330099\">" + text + "</Font></a>";
            double num2 = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            e.Item.Cells[3].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            num2 = _Convert.StrToDouble(e.Item.Cells[5].Text, 0.0);
            e.Item.Cells[5].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            double num3 = _Convert.StrToDouble(e.Item.Cells[2].Text, 0.0);
            double num4 = _Convert.StrToDouble(e.Item.Cells[4].Text, 0.0);
            if (num4 >= num3)
            {
                e.Item.Cells[6].Text = "100%";
            }
            else if (num3 > 0.0)
            {
                e.Item.Cells[6].Text = Math.Round((double)((num4 / num3) * 100.0), 2).ToString() + "%";
            }
            num2 = _Convert.StrToDouble(e.Item.Cells[7].Text, 0.0);
            e.Item.Cells[7].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            num2 = _Convert.StrToDouble(e.Item.Cells[8].Text, 0.0);
            e.Item.Cells[8].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            if (num2 == 0.0)
            {
                e.Item.Cells[9].Text = "未中奖";
                e.Item.Cells[9].Style.Add(HtmlTextWriterStyle.Color, "FFFFCC");
            }
            else
            {
                e.Item.Cells[9].Text = "中奖啦!";
            }
            try
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                if (!_Convert.StrToBool(dataItem.Row["IsOpened"].ToString(), false))
                {
                    e.Item.Cells[9].Text = "未开奖";
                }
            }
            catch
            {
            }
            if (_Convert.StrToShort(e.Item.Cells[13].Text, 0) != 0)
            {
                e.Item.Cells[11].Text = "已撤单";
            }
            else if (_Convert.StrToBool(e.Item.Cells[14].Text, false))
            {
                e.Item.Cells[11].Text = "<Font color='Red'>已成功</font>";
            }
            else
            {
                int num7 = _Convert.StrToInt(e.Item.Cells[0x10].Text, 0);
                int num8 = _Convert.StrToInt(e.Item.Cells[2].Text, 0);
                if (num7 >= num8)
                {
                    e.Item.Cells[11].Text = "<Font color='Red'>已满员</font>";
                }
                else
                {
                    e.Item.Cells[11].Text = "未成功";
                }
            }
        }
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindHistoryData();
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindHistoryData();
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
            this.BindDataForLottery();
            this.BindDataForPlayType();
            this.BindDataForIsuse();
            this.BindHistoryData();
        }
    }
}

