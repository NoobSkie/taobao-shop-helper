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
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_Invest : RoomPageBase, IRequiresSessionState
{
    private int[] arrLotteries = new int[] { 5, 6, 0x1d, 0x27 };

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
                this.ddlLottery.Items.Add(new ListItem(table2.Rows[0]["LotteryName"].ToString(), table2.Rows[0]["LotteryID"].ToString()));
            }
            if (this.ddlLottery.Items.Count > 0)
            {
                this.BindDataForPlayType(this.ddlLottery.Items[0].Value);
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

    private void BindDataReward()
    {
        if (base._User != null)
        {
            string key = "Invest_Reward_" + base._User.ID.ToString();
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = new Views.V_BuyDetailsWithQuashedAll().Open("UserID, SchemeID, LotteryNumber, IsuseName, SchemeWinMoney, LotteryName, WinMoneyNoWithTax,DetailMoney", "[UserID] = " + base._User.ID.ToString() + " and EndTime < GetDate() and WinMoneyNoWithTax > 0", "[DateTime] desc, [ID]");
                if (cacheAsDataTable == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试(732)", base.GetType().FullName);
                    return;
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xe10);
            }
            this.gReward.DataSource = cacheAsDataTable;
            this.gReward.DataBind();
            this.lblRewardCount.Text = cacheAsDataTable.Rows.Count.ToString();
            this.lblRewardMoney.Text = PF.GetSumByColumn(cacheAsDataTable, 6, false, this.gReward.PageSize, 0).ToString("N");
        }
    }

    private void BindHistoryData()
    {
        string key = "Home_Room_Invest_BindHistoryData" + base._User.ID.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from (select LotteryID,LotteryName,PlayTypeID,InitiateName,PlayTypeName, ").Append("SchemeShare,a.Money,b.Share,b.DetailMoney,SchemeWinMoney, b.WinMoneyNoWithTax,a.DateTime, ").Append("b.SchemeID,QuashStatus,Buyed,AssureMoney,BuyedShare,IsOpened,c.Memo  from   ").Append("(select UserID,SchemeID,SUM(Share) as Share,SUM(DetailMoney) as DetailMoney, ").Append("sum(WinMoneyNoWithTax) as  WinMoneyNoWithTax  from V_BuyDetailsWithQuashedAll   ").Append("where  UserID = " + base._User.ID.ToString() + " and InitiateUserID = UserID group by SchemeID,UserID)b ").Append("left join (select * from V_BuyDetailsWithQuashedAll where UserID = " + base._User.ID.ToString() + " and   ").Append("UserID = InitiateUserID and isWhenInitiate = 1)a ").Append("on a.UserID = b.UserID and ").Append("a.SchemeID = b.SchemeID  left join (select SchemeID,Memo from T_UserDetails where ").Append("OperatorType = 9 and UserID = " + base._User.ID.ToString() + ") c  ").Append("on b.SchemeID = c.SchemeID union select  LotteryID,LotteryName,PlayTypeID,InitiateName, ").Append("PlayTypeName,SchemeShare,a.Money,Share,DetailMoney,SchemeWinMoney, WinMoneyNoWithTax, ").Append("a.DateTime,a.SchemeID,QuashStatus,Buyed,AssureMoney,BuyedShare,IsOpened,b.Memo from  ").Append("(select * from V_BuyDetailsWithQuashedAll where UserID = " + base._User.ID.ToString() + " and UserID<>InitiateUserID) a left join (select SchemeID,Memo from T_UserDetails where  ").Append("OperatorType = 9 and UserID = " + base._User.ID.ToString() + ")b on a.SchemeID = b.SchemeID)a order by DateTime desc");
            cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 60);
        }
        string filterExpression = "1=1";
        if (this.ddlLottery.SelectedValue != "-1")
        {
            filterExpression = filterExpression + " and LotteryID=" + _Convert.StrToInt(this.ddlLottery.SelectedValue, -1).ToString();
        }
        if (this.ddlPlayType.SelectedValue != "-1")
        {
            filterExpression = filterExpression + " and PlayTypeID = " + _Convert.StrToInt(this.ddlPlayType.SelectedValue, -1).ToString();
        }
        DataTable dt = cacheAsDataTable.Clone();
        foreach (DataRow row in cacheAsDataTable.Select(filterExpression, "[DateTime] desc"))
        {
            dt.Rows.Add(row.ItemArray);
        }
        PF.DataGridBindData(this.gHistory, dt, this.gPagerHistory);
        this.gPagerHistory.Visible = true;
        this.lblPageBuySum.Text = PF.GetSumByColumn(dt, 8, true, this.gPagerHistory.PageSize, this.gPagerHistory.PageIndex).ToString("N");
        this.lblPageSumWinMoney.Text = PF.GetSumByColumn(dt, 10, true, this.gPagerHistory.PageSize, this.gPagerHistory.PageIndex).ToString("N");
        this.lblBuySum.Text = PF.GetSumByColumn(dt, 8, false, this.gPagerHistory.PageSize, this.gPagerHistory.PageIndex).ToString("N");
        this.lblSumWinMoney.Text = PF.GetSumByColumn(dt, 10, false, this.gPagerHistory.PageSize, this.gPagerHistory.PageIndex).ToString("N");
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
        this.BindDataForPlayType(this.ddlLottery.SelectedValue);
    }

    protected void g_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        DataGrid grid = (DataGrid)source;
        string iD = grid.ID;
        if (iD != null)
        {
            if (!(iD == "gHistory"))
            {
                if (!(iD == "gReward"))
                {
                    return;
                }
            }
            else
            {
                this.BindHistoryData();
                return;
            }
            this.BindDataReward();
        }
    }

    protected void gHistory_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            string text = e.Item.Cells[0].Text;
            if (text.Length > 6)
            {
                e.Item.Cells[0].Text = text.Substring(0, 6) + "…";
            }
            e.Item.Cells[0].Attributes.Add("title", text);
            long num = _Convert.StrToLong(e.Item.Cells[13].Text, 0L);
            string str2 = e.Item.Cells[2].Text;
            if (str2.Length > 6)
            {
                str2 = str2.Substring(0, 5) + "..";
            }
            e.Item.Cells[2].Text = "<span class='red12_2'><a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'>" + str2 + "</a></span>";
            double num2 = _Convert.StrToDouble(e.Item.Cells[4].Text, 0.0);
            e.Item.Cells[4].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            num2 = _Convert.StrToDouble(e.Item.Cells[6].Text, 0.0);
            e.Item.Cells[6].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            double num3 = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            double num4 = _Convert.StrToDouble(e.Item.Cells[5].Text, 0.0);
            if (num4 >= num3)
            {
                e.Item.Cells[7].Text = "100%";
            }
            else if (num3 > 0.0)
            {
                e.Item.Cells[7].Text = Math.Round((double)((num4 / num3) * 100.0), 2).ToString() + "%";
            }
            num2 = _Convert.StrToDouble(e.Item.Cells[8].Text, 0.0);
            e.Item.Cells[8].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            num2 = _Convert.StrToDouble(e.Item.Cells[9].Text, 0.0);
            e.Item.Cells[9].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            if (num2 == 0.0)
            {
                e.Item.Cells[10].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'>未中奖</a>";
                e.Item.Cells[10].Style.Add(HtmlTextWriterStyle.Color, "FFFFCC");
            }
            else
            {
                e.Item.Cells[10].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'><font color=\"red\">中奖啦!</font></a>";
                e.Item.Cells[10].Style.Add(HtmlTextWriterStyle.Color, "#FF0000");
            }
            bool flag = false;
            try
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                flag = _Convert.StrToBool(dataItem.Row["IsOpened"].ToString(), false);
                if (!flag)
                {
                    e.Item.Cells[10].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'>未开奖</a>";
                    e.Item.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFCA");
                }
            }
            catch
            {
            }
            if (_Convert.StrToShort(e.Item.Cells[14].Text, 0) != 0)
            {
                string str3 = "已撤单";
                e.Item.Cells[12].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'>" + str3 + "</a>";
            }
            else if (!flag)
            {
                if (_Convert.StrToBool(e.Item.Cells[15].Text, false))
                {
                    e.Item.Cells[12].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'><Font color='Red'>已成功</font></a>";
                }
                else
                {
                    int num7 = _Convert.StrToInt(e.Item.Cells[0x11].Text, 0);
                    int num8 = _Convert.StrToInt(e.Item.Cells[3].Text, 0);
                    if (num7 >= num8)
                    {
                        e.Item.Cells[12].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'><Font color='Red'>已满员</font></a>";
                    }
                    else
                    {
                        e.Item.Cells[12].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'>未满员</a>";
                    }
                }
            }
            else
            {
                e.Item.Cells[12].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'>已成功</a>";
            }
        }
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        ShoveGridPager pager = (ShoveGridPager)Sender;
        if (pager.ID == "gPagerHistory")
        {
            this.hdCurDiv.Value = "divHistory";
            this.BindHistoryData();
        }
        else if (pager.ID == "gPager_Reward")
        {
            this.hdCurDiv.Value = "divReward";
            this.BindDataReward();
        }
    }

    protected void gReward_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            double num = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            e.Item.Cells[3].Text = (num == 0.0) ? "" : num.ToString("N");
            double num2 = _Convert.StrToDouble(e.Item.Cells[4].Text, 0.0);
            e.Item.Cells[4].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            num2 = _Convert.StrToDouble(e.Item.Cells[5].Text, 0.0);
            e.Item.Cells[5].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            if (num2 > 0.0)
            {
                e.Item.Cells[7].Text = "<font color=\"red\">中奖啦!</font>";
            }
            else
            {
                e.Item.Cells[7].Text = "未中奖";
            }
            e.Item.ToolTip = e.Item.Cells[2].Text;
            e.Item.Cells[2].Text = "<span class='red12_2'><a href='Scheme.aspx?id=" + e.Item.Cells[8].Text + "' target='_blank'>投注内容</a></span>";
            double num3 = _Convert.StrToDouble(e.Item.Cells[5].Text, 0.0);
            double num4 = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            double num5 = num3 - num4;
            double num6 = num5 / num4;
            if (num6 >= 1.0)
            {
                e.Item.Cells[6].Text = Math.Round(num6, 2).ToString() + "倍";
            }
            else
            {
                e.Item.Cells[6].Text = ((Math.Round(num6, 2) * 100.0)).ToString() + "%";
            }
            if (num5 < 0.0)
            {
                e.Item.Cells[6].Text = "";
            }
        }
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
            this.BindHistoryData();
            this.BindDataReward();
            if (Utility.GetRequest("Type") == "1")
            {
                this.hdCurDiv.Value = "divHistory";
            }
        }
    }
}

