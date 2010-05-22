using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_Welcome : RoomPageBase, IRequiresSessionState
{
    private int[] arrLotteries = new int[] { 5, 6, 0x1d, 0x27 };
    public string Balance;
    private DataTable dta;
    public string isAdministrator = "false";
    public static int LotteryID;
    private int sumWinProfitPoints;
    public string UserName;

    private void BindDataForLottery()
    {
        this.ddlLottery.Items.Clear();
        this.ddlLottery.Items.Add(new ListItem("全部彩种", "-1"));
        if (base._Site.UseLotteryList == "")
        {
            PF.GoError(1, "暂无玩法", "Room_InvestHistory");
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
                this.ddlLottery.Items.Add(new ListItem(cacheAsDataTable.Rows[i]["Name"].ToString(), cacheAsDataTable.Rows[i]["ID"].ToString()));
            }
        }
    }

    private void BindDataGetWinNumber()
    {
        if (Shove._Web.Cache.GetCacheAsDataTable("Room_Welcome_GetWinNumber") == null)
        {
            int returnValue = 0;
            string returnDescription = "";
            DataSet ds = null;
            Procedures.P_GetWinLotteryNumber(ref ds, base._Site.ID, -1, 0, ref returnValue, ref returnDescription);
            if (ds == null)
            {
                PF.GoError(4, "数据库繁忙，请重试(128)", base.GetType().BaseType.FullName);
            }
            else if (returnValue < 0)
            {
                JavaScript.Alert(this.Page, returnDescription);
            }
            else if (ds.Tables.Count < 1)
            {
                PF.GoError(4, "数据库繁忙，请重试(142)", base.GetType().BaseType.FullName);
            }
            else
            {
                DataTable table = ds.Tables[0];
                Shove._Web.Cache.SetCache("Room_Welcome_GetWinNumber", table, 600);
            }
        }
    }

    private void BindDataInvest()
    {
        if (base._User != null)
        {
            string key = "Room_Welcome_Invest_" + base._User.ID.ToString();
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = new Views.V_BuyDetailsNonce().Open("UserID, SchemeID, LotteryNumber, IsuseName, SchemeWinMoney, LotteryName, Money, InitiateName, Schedule, Buyed, QuashStatus,DetailMoney", "[UserID] = " + base._User.ID.ToString(), " [DateTime] desc ,[id]");
                if (cacheAsDataTable == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试(537)", base.GetType().FullName);
                    return;
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 30);
            }
            this.gInvest.DataSource = cacheAsDataTable;
            this.gInvest.DataBind();
            this.lbgInvestMessage.Text = "显示 10 条，共 " + cacheAsDataTable.Rows.Count.ToString() + " 条记录 ，<span class='blue'><a  href='Invest.aspx'>[查看全部记录]</a></span>";
        }
    }

    private void BindDataInvestHistory()
    {
        if (base._User != null)
        {
            string key = "Room_Welcome_InvestHistory_" + base._User.ID.ToString();
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            string condition = "[UserID] = " + base._User.ID.ToString() + " and EndTime < GetDate()";
            if (this.ddlLottery.SelectedIndex > 0)
            {
                condition = condition + " and LotteryID=" + _Convert.StrToInt(this.ddlLottery.SelectedValue, -1).ToString();
            }
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = new Views.V_BuyDetailsWithQuashedAll().Open("UserID, SchemeID, LotteryNumber, IsuseName, SchemeWinMoney, LotteryName, WinMoneyNoWithTax, IsOpened,DetailMoney", condition, "[DateTime] desc, [ID]");
                if (cacheAsDataTable == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试(641)", base.GetType().FullName);
                    return;
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 300);
            }
            this.gInvestHistory.DataSource = cacheAsDataTable;
            this.gInvestHistory.DataBind();
            this.lblBuySum.Text = PF.GetSumByColumn(cacheAsDataTable, 8, false, this.gInvestHistory.PageSize, this.gPagerHistory.PageIndex).ToString("N");
            this.lblSumWinMoney.Text = PF.GetSumByColumn(cacheAsDataTable, 4, false, this.gInvestHistory.PageSize, this.gPagerHistory.PageIndex).ToString("N");
            this.lblMySumWinMoney.Text = PF.GetSumByColumn(cacheAsDataTable, 6, false, this.gInvestHistory.PageSize, this.gPagerHistory.PageIndex).ToString("N");
            double num7 = _Convert.StrToDouble(this.lblSumWinMoney.Text, 0.0);
            double num8 = _Convert.StrToDouble(this.lblSumWinMoney.Text, 0.0);
            double num9 = num7 - num8;
            if (num9 <= 0.0)
            {
                this.lblSumWinProfitPoints.Text = "0.00";
            }
            else
            {
                double num10 = num9 / num8;
                if (num10 > 1.0)
                {
                    this.lblSumWinProfitPoints.Text = Math.Round(num10, 2).ToString("N") + "倍";
                }
                else
                {
                    this.lblSumWinProfitPoints.Text = ((Math.Round(num10, 2) * 100.0)).ToString("N") + "%";
                }
            }
            this.lbgInvestHistoryMessage.Text = "显示 10 条，共 " + cacheAsDataTable.Rows.Count.ToString() + " 条记录 ，<span class=\"blue\"><a  href='InvestHistory.aspx'>[查看全部记录]</a></span>";
        }
    }

    private void BindDataReward()
    {
        if (base._User != null)
        {
            string key = "Room_Welcome_Reward_" + base._User.ID.ToString();
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = new Views.V_BuyDetailsWithQuashedAll().Open("UserID, SchemeID, LotteryNumber, IsuseName, SchemeWinMoney, LotteryName, WinMoneyNoWithTax,DetailMoney", "[UserID] = " + base._User.ID.ToString() + " and EndTime < GetDate() and WinMoneyNoWithTax > 0", "[DateTime] desc, [ID]");
                if (cacheAsDataTable == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试(732)", base.GetType().FullName);
                    return;
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 300);
            }
            this.gReward.DataSource = cacheAsDataTable;
            this.gReward.DataBind();
            this.lblRewardCount.Text = cacheAsDataTable.Rows.Count.ToString();
            this.lblRewardMoney.Text = PF.GetSumByColumn(cacheAsDataTable, 6, false, this.gReward.PageSize, 0).ToString("N");
        }
    }

    private void BindViewAccountData()
    {
        this.labUserType.Text = (base._User.UserType == 1) ? "普通用户" : ((base._User.UserType == 3) ? "VIP" : "高级用户");
        this.labBalance.Text = ((base._User.Balance + base._User.Freeze)).ToString("N") + "元";
        this.labFreeze.Text = base._User.Freeze.ToString("N");
        this.labBalanceDo.Text = base._User.Balance.ToString("N");
        this.labScoring.Text = base._User.Scoring.ToString();
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            Shove._Web.Cache.ClearCache("Room_Welcome_InvestHistory_" + base._User.ID.ToString());
            this.BindDataInvestHistory();
        }
    }

    protected void dlExpertsCommends_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            DataRow row = this.dta.Rows[e.Item.ItemIndex];
            Label label = (Label)e.Item.FindControl("Title1");
            label.Text = row["Title1"].ToString();
            if (row["Title1"].ToString().Length > 0x12)
            {
                label.Text = row["Title1"].ToString().Substring(0, 0x12);
            }
        }
    }

    private string GetDateofWeek(string Date)
    {
        switch (Date)
        {
            case "Monday":
                return "1";

            case "Tuesday":
                return "2";

            case "Wednesday":
                return "3";

            case "Thursday":
                return "4";

            case "Friday":
                return "5";

            case "Saturday":
                return "6";

            case "Sunday":
                return "7";
        }
        return "1";
    }

    protected void gInvest_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            double num = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            e.Item.Cells[3].Text = (num == 0.0) ? "" : num.ToString("N");
            e.Item.ToolTip = e.Item.Cells[2].Text;
            if (e.Item.Cells[2].Text.Trim().Length > 20)
            {
                e.Item.Cells[2].Text = "<span class='red12_2'><a href='Scheme.aspx?id=" + e.Item.Cells[7].Text + "' target='_blank' >投注内容</a></span>";
            }
            double num2 = _Convert.StrToDouble(e.Item.Cells[10].Text, 0.0);
            if (_Convert.StrToShort(e.Item.Cells[8].Text, 0) != 0)
            {
                e.Item.Cells[6].Text = "<font color='Blue'>撤单</font>";
            }
            else if (_Convert.StrToBool(e.Item.Cells[9].Text, false))
            {
                e.Item.Cells[6].Text = "<font color='Red'>成功</font>";
            }
            else if (num2 >= 100.0)
            {
                e.Item.Cells[6].Text = "<font color='Red'>满员</font>";
            }
            else
            {
                e.Item.Cells[6].Text = "未满员";
            }
            string str = e.Item.Cells[5].Text.Trim();
            if (str.Length > 10)
            {
                e.Item.Cells[5].Text = str.Substring(0, 9) + "*";
            }
        }
    }

    protected void gInvestHistory_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[7].Text = "<a href='Scheme.aspx?id=" + _Convert.StrToLong(e.Item.Cells[8].Text, 0L).ToString() + "' target='_blank'><font color=\"#330099\">详情</Font></a>";
            double num2 = _Convert.StrToDouble(e.Item.Cells[4].Text, 0.0);
            e.Item.Cells[4].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            num2 = _Convert.StrToDouble(e.Item.Cells[5].Text, 0.0);
            e.Item.Cells[5].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            bool flag = _Convert.StrToBool(e.Item.Cells[9].Text, false);
            if (num2 > 0.0)
            {
                e.Item.Cells[7].Text = "<font color=\"red\">中奖啦!</font>";
            }
            else if (flag)
            {
                e.Item.Cells[7].Text = "未中奖";
            }
            else
            {
                e.Item.Cells[7].Text = "<font color=\"Blue\">未开奖</font>";
            }
            e.Item.ToolTip = e.Item.Cells[2].Text;
            e.Item.Cells[2].Text = "<span class='red12_2'><a href='Scheme.aspx?id=" + e.Item.Cells[8].Text + "' target='_blank' class = 'red12_2'>投注内容</a></span>";
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
            this.sumWinProfitPoints += _Convert.StrToInt(e.Item.Cells[6].Text, 0);
        }
    }

    protected void gInvestHistory_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        this.BindDataInvestHistory();
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindDataInvestHistory();
    }

    protected void gReward_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            double num = _Convert.StrToDouble(e.Item.Cells[4].Text, 0.0);
            e.Item.Cells[4].Text = (num == 0.0) ? "" : num.ToString("N");
            num = _Convert.StrToDouble(e.Item.Cells[5].Text, 0.0);
            e.Item.Cells[5].Text = (num == 0.0) ? "" : num.ToString("N");
            if (num > 0.0)
            {
                e.Item.Cells[7].Text = "<font color=\"red\">中奖啦!</font>";
            }
            else
            {
                e.Item.Cells[7].Text = "未中奖";
            }
            e.Item.ToolTip = e.Item.Cells[2].Text;
            e.Item.Cells[2].Text = "<span class='red12_2'><a href='Scheme.aspx?id=" + e.Item.Cells[8].Text + "' target='_blank' class = 'red12_2'>投注内容</a></span>";
            double num2 = _Convert.StrToDouble(e.Item.Cells[5].Text, 0.0);
            double num3 = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            double num4 = num2 - num3;
            double num5 = num4 / num3;
            if (num5 >= 1.0)
            {
                e.Item.Cells[6].Text = Math.Round(num5, 2).ToString() + "倍";
            }
            else
            {
                e.Item.Cells[6].Text = ((Math.Round(num5, 2) * 100.0)).ToString() + "%";
            }
            if (num4 < 0.0)
            {
                e.Item.Cells[6].Text = "";
            }
        }
    }

    protected void gRewardPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindDataInvestHistory();
    }

    protected void gRewardPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindDataInvestHistory();
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = "Welcome.aspx";
        base.isRequestLogin = false;
        base.isAtFramePageLogin = false;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataGetWinNumber();
            this.BindDataInvest();
            this.BindDataInvestHistory();
            this.BindDataReward();
            this.BindDataForLottery();
            this.Balance = "0";
            this.myIcaileTab.Style.Add("display", "none");
            if (base._User != null)
            {
                this.myIcaileTab.Style.Remove("display");
                this.BindViewAccountData();
            }
        }
        if (base._User != null)
        {
            this.isAdministrator = Functions.F_GetIsAdministrator(base._Site.ID, base._User.ID).ToString().ToLower();
            this.Balance = base._User.Balance.ToString();
            this.UserName = base._User.Name.ToString();
            StringBuilder builder = new StringBuilder();
            builder.Append("<a href='OnlinePay/Default.aspx'>").Append("【我要充值】").Append("</a>");
            this.sp_isGoLogin.InnerHtml = builder.ToString();
        }
        else
        {
            StringBuilder builder2 = new StringBuilder();
            builder2.Append("<a onclick='return CreateLogin()' style='cursor:hand;'>").Append("【我要充值】").Append("</a>");
            this.sp_isGoLogin.InnerHtml = builder2.ToString();
        }
    }
}

