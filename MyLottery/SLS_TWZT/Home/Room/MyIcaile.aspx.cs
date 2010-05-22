using AjaxPro;
using ASP;
using DAL;
using Shove;
using Shove._Security;
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

public partial class Home_Room_MyIcaile : RoomPageBase, IRequiresSessionState
{
    private int[] arrLotteries = new int[] { 5, 6, 0x1d, 0x27 };
    public string Balance;
    private DataTable dta;
    public string isAdministrator = "false";
    public static int LotteryID;
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

    private void BindDataInvestHistory()
    {
        if (base._User != null)
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
            this.gInvestHistory.DataSource = cacheAsDataTable;
            this.gInvestHistory.DataBind();
            this.lblBuySum.Text = PF.GetSumByColumn(cacheAsDataTable, 8, false, this.gInvestHistory.PageSize, this.gPagerHistory.PageIndex).ToString("N");
            this.lblSumWinMoney.Text = PF.GetSumByColumn(cacheAsDataTable, 9, false, this.gInvestHistory.PageSize, this.gPagerHistory.PageIndex).ToString("N");
            this.lblMySumWinMoney.Text = PF.GetSumByColumn(cacheAsDataTable, 10, false, this.gInvestHistory.PageSize, this.gPagerHistory.PageIndex).ToString("N");
            double num10 = _Convert.StrToDouble(this.lblSumWinMoney.Text, 0.0);
            double num11 = _Convert.StrToDouble(this.lblBuySum.Text, 0.0);
            double num12 = num10 - num11;
            if (num12 <= 0.0)
            {
                this.lblSumWinProfitPoints.Text = "0.00";
            }
            else
            {
                double num13 = num12 / num11;
                if (num13 > 1.0)
                {
                    this.lblSumWinProfitPoints.Text = Math.Round(num13, 2).ToString("N") + "倍";
                }
                else
                {
                    this.lblSumWinProfitPoints.Text = ((Math.Round(num13, 2) * 100.0)).ToString("N") + "%";
                }
            }
            this.lbgInvestHistoryMessage.Text = "显示 10 条，共 " + cacheAsDataTable.Rows.Count.ToString() + " 条记录 ，<span class=\"blue12_line\"><a  href='InvestHistory.aspx'>[查看全部记录]</a></span>";
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
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 120);
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

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public string GetBackUrl(string urls)
    {
        string s = "MyIcaile.aspx";
        return Encrypt.EncryptString(PF.GetCallCert(), s);
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

    protected void gInvestHistory_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                e.Item.Cells[10].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'>中奖啦!</a>";
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
            if (!flag)
            {
                short num6 = _Convert.StrToShort(e.Item.Cells[14].Text, 0);
                if (num6 != 0)
                {
                    string str3 = "已撤单";
                    if (num6 == 1)
                    {
                        str3 = "用户撤单";
                    }
                    else if (!string.IsNullOrEmpty(e.Item.Cells[0x12].Text.Trim()))
                    {
                        str3 = e.Item.Cells[0x12].Text;
                    }
                    e.Item.Cells[12].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'>" + str3 + "</a>";
                }
                else if (_Convert.StrToBool(e.Item.Cells[15].Text, false))
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
                        e.Item.Cells[12].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'>未成功</a>";
                    }
                }
            }
            else if (num2 > 0.0)
            {
                e.Item.Cells[12].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'><font color=\"red\">中奖啦!</font></a>";
            }
            else
            {
                e.Item.Cells[12].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'>未中奖</a>";
            }
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

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public string isLoginsas()
    {
        return Users.GetCurrentUser(1L).ID.ToString();
    }

    private void MenuByStatus()
    {
        Users users1 = base._User;
        DataTable table = new Tables.T_Sites().Open("Opt_Promotion_Status_ON", "", "");
        if ((table != null) && (table.Rows.Count > 0))
        {
            bool.Parse(table.Rows[0]["Opt_Promotion_Status_ON"].ToString());
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = "MyIcaile.aspx";
        base.isRequestLogin = true;
        base.isAtFramePageLogin = false;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataGetWinNumber();
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
            this.PopNews();
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

    private void PopNews()
    {
        if (base._User != null)
        {
            string key = "Get_Win_Info_" + base._User.ID.ToString();
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("Get_Win_Info_" + base._User.ID.ToString());
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = new Views.V_BuyDetails().Open("top 1 LotteryName,IsuseName,WinLotteryNumber,LotteryNumber,WinMoneyNoWithTax", "IsOpened = 1 and UserID = " + base._User.ID, "ID DESC");
                if (cacheAsDataTable == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试(537)", base.GetType().FullName);
                    return;
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 300);
            }
            StringBuilder builder = new StringBuilder();
            builder.Append(base._User.Name).Append(",");
            if (cacheAsDataTable.Rows.Count != 0)
            {
                Shove._Web.Utility.GetUrl();
                for (int i = 0; i < cacheAsDataTable.Rows.Count; i++)
                {
                    builder.Append(cacheAsDataTable.Rows[i]["LotteryName"].ToString()).Append("第").Append(cacheAsDataTable.Rows[i]["IsuseName"].ToString()).Append("期中奖号码是 ").Append(cacheAsDataTable.Rows[i]["WinLotteryNumber"].ToString()).Append(" 您投注的号码是").Append(_String.Cut(cacheAsDataTable.Rows[i]["LotteryNumber"].ToString(), 15)).Append(" ，").Append((_Convert.StrToDouble(cacheAsDataTable.Rows[i]["WinMoneyNoWithTax"].ToString(), 0.0) > 0.0) ? "<font style='color:red;'>中奖了</font>，希望您再接再厉，夺得更多奖金。" : "没有中奖，希望您继续努力，祝您早日中大奖。");
                }
                this.label1.Text = HmtlManage.GetHtml(AppDomain.CurrentDomain.BaseDirectory + "Home/Room/Template/FloatNotify.html").Replace("$FloatNotifyContent$", builder.ToString());
            }
        }
    }
}

