using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_AccountDetail : RoomPageBase, IRequiresSessionState
{
    private int inCount;
    private double inMoney;
    private int inScoreCount;
    private double inScoreMoney;
    private int outCount;
    private double outMoney;
    private int outScoreCount;
    private double outScoreMoney;

    private void BinDataForDay()
    {
        this.ddlDay.Items.Clear();
        int[] numArray = new int[] { 1, 3, 5, 7, 8, 10, 12 };
        DateTime now = DateTime.Now;
        int year = now.Year;
        int day = now.Day;
        int num3 = int.Parse(this.ddlMonth.SelectedValue);
        int num4 = 0;
        foreach (int num6 in numArray)
        {
            if (num3 == num6)
            {
                num4 = 0x1f;
                break;
            }
            if (num3 == 2)
            {
                if ((((year % 4) == 0) && ((year % 100) != 0)) && ((year % 400) == 0))
                {
                    num4 = 0x1d;
                }
                else
                {
                    num4 = 0x1c;
                }
                break;
            }
            num4 = 30;
        }
        for (int i = 1; i <= num4; i++)
        {
            this.ddlDay.Items.Add(new ListItem(i.ToString() + "日", i.ToString()));
        }
        if (day > num4)
        {
            day = num4;
        }
        this.ddlDay.SelectedIndex = day - 1;
    }

    private void BinDataForDay1()
    {
        this.ddlDay1.Items.Clear();
        int[] numArray = new int[] { 1, 3, 5, 7, 8, 10, 12 };
        DateTime now = DateTime.Now;
        int year = now.Year;
        int day = now.Day;
        int num3 = int.Parse(this.ddlMonth.SelectedValue);
        int num4 = 0;
        foreach (int num6 in numArray)
        {
            if (num3 == num6)
            {
                num4 = 0x1f;
                break;
            }
            if (num3 == 2)
            {
                if ((((year % 4) == 0) && ((year % 100) != 0)) && ((year % 400) == 0))
                {
                    num4 = 0x1d;
                }
                else
                {
                    num4 = 0x1c;
                }
                break;
            }
            num4 = 30;
        }
        for (int i = 1; i <= num4; i++)
        {
            this.ddlDay1.Items.Add(new ListItem(i.ToString() + "日", i.ToString()));
        }
        if (day > num4)
        {
            day = num4;
        }
        this.ddlDay1.SelectedIndex = day - 1;
    }

    private void BindData()
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(WebConfig.GetAppSettingsString("SystemPreFix") + base._Site.ID.ToString() + "AccountDetail_" + base._User.ID.ToString());
        DateTime time2 = _Convert.StrToDateTime(this.ddlYear.SelectedValue + "-" + this.ddlMonth.SelectedValue + "-" + this.ddlDay.SelectedValue + " 00:00:00", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        DateTime now = _Convert.StrToDateTime(this.ddlYear1.SelectedValue + "-" + this.ddlMonth1.SelectedValue + "-" + this.ddlDay1.SelectedValue + " 23:59:59", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        if (cacheAsDataTable == null)
        {
            if (this.ddlYear.Items.Count < 1)
            {
                return;
            }
            if (DateTime.Now.CompareTo(now) <= 0)
            {
                now = DateTime.Now;
            }
            if (now.CompareTo(time2) < 0)
            {
                JavaScript.Alert(this.Page, "开始时间不能小于结束时间.");
                return;
            }
            int returnValue = 0;
            string returnDescription = "";
            DataSet ds = null;
            Procedures.P_GetUserAccountDetails(ref ds, 1L, base._User.ID, time2, now, ref returnValue, ref returnDescription);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(4, "数据库繁忙，请重试", "Room_AccountDetail");
                return;
            }
            if (returnValue < 0)
            {
                JavaScript.Alert(this.Page, returnDescription);
                return;
            }
            cacheAsDataTable = ds.Tables[0];
            Shove._Web.Cache.SetCache(WebConfig.GetAppSettingsString("SystemPreFix") + base._Site.ID.ToString() + "AccountDetail_" + base._User.ID.ToString(), cacheAsDataTable);
        }
        PF.DataGridBindData(this.g, cacheAsDataTable, this.gPager);
        this.lblInCount.Text = this.inCount.ToString();
        this.lblOutCount.Text = this.outCount.ToString();
        this.lblInMoney.Text = this.inMoney.ToString("N");
        this.lblOutMoney.Text = this.outMoney.ToString("N");
    }

    private void BindDataForYearMonth()
    {
        this.ddlYear.Items.Clear();
        DateTime now = DateTime.Now;
        int year = now.Year;
        int month = now.Month;
        if (year < 0x7d8)
        {
            this.btnGO.Enabled = false;
        }
        else
        {
            for (int i = 0x7d8; i <= year; i++)
            {
                this.ddlYear.Items.Add(new ListItem(i.ToString() + "年", i.ToString()));
            }
            this.ddlYear.SelectedIndex = this.ddlYear.Items.Count - 1;
            if (month >= 4)
            {
                this.ddlMonth.SelectedIndex = month - 4;
            }
            else
            {
                this.ddlMonth.SelectedIndex = 0;
            }
        }
    }

    private void BindDataForYearMonth1()
    {
        this.ddlYear1.Items.Clear();
        DateTime now = DateTime.Now;
        int year = now.Year;
        int month = now.Month;
        if (year < 0x7d8)
        {
            this.btnGO.Enabled = false;
        }
        else
        {
            for (int i = 0x7d8; i <= year; i++)
            {
                this.ddlYear1.Items.Add(new ListItem(i.ToString() + "年", i.ToString()));
            }
            this.ddlYear1.SelectedIndex = this.ddlYear.Items.Count - 1;
            this.ddlMonth1.SelectedIndex = month - 1;
        }
    }

    private void BindDistills()
    {
        if (base._User != null)
        {
            string key = "Room_UserDistills_" + base._User.ID.ToString();
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = new Views.V_UserDistills().Open("ID,[DateTime],[Money],FormalitiesFees,Result,Memo", "[UserID] = " + base._User.ID.ToString(), "[DateTime] desc, [ID]");
                if (cacheAsDataTable == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试(732)", base.GetType().FullName);
                    return;
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 60);
            }
            this.gUserDistills.DataSource = cacheAsDataTable;
            this.gUserDistills.DataBind();
            this.lblDistillCount.Text = cacheAsDataTable.Rows.Count.ToString();
            this.lblDistillMoney.Text = PF.GetSumByColumn(cacheAsDataTable, 2, false, this.gUserDistills.PageSize, 0).ToString("N");
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
        PF.DataGridBindData(this.gHistory, cacheAsDataTable, this.gPagerHistory);
        int num7 = 0;
        double num8 = 0.0;
        foreach (DataRow row in cacheAsDataTable.Rows)
        {
            if (row["QuashStatus"].ToString() == "0")
            {
                num7++;
                num8 += _Convert.StrToDouble(row["DetailMoney"].ToString(), 0.0);
            }
        }
        this.lblBuyOutCount.Text = num7.ToString();
        this.lblBuyOutMoney.Text = num8.ToString("N");
        this.gPagerHistory.Visible = true;
    }

    private void BindRewardData()
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
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 60);
            }
            this.gReward.DataSource = cacheAsDataTable;
            this.gReward.DataBind();
            this.lblRewardCount.Text = cacheAsDataTable.Rows.Count.ToString();
            this.lblRewardMoney.Text = PF.GetSumByColumn(cacheAsDataTable, 6, false, this.gPagerReward.PageSize, this.gPagerReward.PageIndex).ToString("N");
        }
    }

    private void BindScoring()
    {
        if (base._User != null)
        {
            string key = "Room_UserScoring_" + base._User.ID.ToString();
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = new Views.V_UserScoringDetails().Open("ID,[DateTime],[Scoring],OperatorType", "[UserID] = " + base._User.ID.ToString(), "[DateTime] desc, [ID]");
                if (cacheAsDataTable == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试(732)", base.GetType().FullName);
                    return;
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 60);
            }
            this.gScoring.DataSource = cacheAsDataTable;
            this.gScoring.DataBind();
            this.lblScoreInCount.Text = this.inScoreCount.ToString();
            this.lblScoreOutCount.Text = this.outScoreCount.ToString();
            this.lblScoreInMoney.Text = this.inScoreMoney.ToString("N");
            this.lblScoreOutMoney.Text = this.outScoreMoney.ToString("N");
        }
    }

    private void BindUserPayData()
    {
        if (base._User != null)
        {
            string key = "Room_UserPayDetail_" + base._User.ID.ToString();
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = new Views.V_UserPayDetails().Open("ID,[DateTime],PayType,[Money],FormalitiesFees", "[UserID] = " + base._User.ID.ToString() + " and Result = 1", "[DateTime] desc, [ID]");
                if (cacheAsDataTable == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试(732)", base.GetType().FullName);
                    return;
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 60);
            }
            this.gUserPay.DataSource = cacheAsDataTable;
            this.gUserPay.DataBind();
            this.lblUserPayCount.Text = cacheAsDataTable.Rows.Count.ToString();
            this.lblUserPayMoney.Text = PF.GetSumByColumn(cacheAsDataTable, 3, false, this.gUserPay.PageSize, 0).ToString("N");
        }
    }

    protected void btnGO_Click(object sender, EventArgs e)
    {
        Shove._Web.Cache.ClearCache(WebConfig.GetAppSettingsString("SystemPreFix") + base._Site.ID.ToString() + "AccountDetail_" + base._User.ID.ToString());
        this.BindData();
    }

    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BinDataForDay();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            double num = _Convert.StrToDouble(e.Item.Cells[2].Text, 0.0);
            e.Item.Cells[2].Text = (num == 0.0) ? "" : num.ToString("N");
            if (num != 0.0)
            {
                this.inCount++;
                this.inMoney += num;
            }
            num = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            e.Item.Cells[3].Text = (num == 0.0) ? "" : num.ToString("N");
            if (num != 0.0)
            {
                this.outCount++;
                this.outMoney += num;
            }
            num = _Convert.StrToDouble(e.Item.Cells[4].Text, 0.0);
            e.Item.Cells[4].Text = (num == 0.0) ? "" : num.ToString("N");
            num = _Convert.StrToDouble(e.Item.Cells[5].Text, 0.0);
            e.Item.Cells[5].Text = (num == 0.0) ? "0.00" : num.ToString("N");
            num = _Convert.StrToDouble(e.Item.Cells[6].Text, 0.0);
            e.Item.Cells[6].Text = (num == 0.0) ? "" : num.ToString("N");
            num = _Convert.StrToDouble(e.Item.Cells[7].Text, 0.0);
            e.Item.Cells[7].Text = (num == 0.0) ? "" : num.ToString("N");
            long num2 = _Convert.StrToLong(e.Item.Cells[8].Text, 0L);
            if (num2 > 0L)
            {
                e.Item.Cells[1].Text = "<span class='red12_2'><a href='Scheme.aspx?id=" + num2.ToString() + "' target='_blank'>" + e.Item.Cells[1].Text + "</a></span>";
            }
        }
    }

    protected void g_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        DataGrid grid = (DataGrid)source;
        string iD = grid.ID;
        if (iD != null)
        {
            if (!(iD == "g"))
            {
                if (!(iD == "gHistory"))
                {
                    if (!(iD == "gReward"))
                    {
                        if (!(iD == "gUserPay"))
                        {
                            if (!(iD == "gUserDistills"))
                            {
                                if (iD == "gScoring")
                                {
                                    this.BindScoring();
                                }
                                return;
                            }
                            this.BindDistills();
                            return;
                        }
                        this.BindUserPayData();
                        return;
                    }
                    this.BindRewardData();
                    return;
                }
            }
            else
            {
                this.BindData();
                return;
            }
            this.BindHistoryData();
        }
    }

    private string getBankName(string bankCode)
    {
        string str = "";
        string[] strArray = bankCode.Split(new char[] { '_' });
        if (strArray.Length < 2)
        {
            return "未知银行";
        }
        if (strArray[0].ToUpper() == "ALIPAY")
        {
            switch (strArray[1].ToUpper())
            {
                case "ALIPAY":
                    return "支付宝";

                case "ICBCB2C":
                    return "中国工商银行";

                case "GDB":
                    return "广东发展银行";

                case "CEBBANK":
                    return "中国光大银行";

                case "CCB":
                    return "中国建设银行";

                case "COMM":
                    return "中国交通银行";

                case "ABC":
                    return "中国农业银行";

                case "SPDB":
                    return "上海浦发银行";

                case "SDB":
                    return "深圳发展银行";

                case "CIB":
                    return "兴业银行";

                case "HZCBB2C":
                    return "杭州银行";

                case "CMBC":
                    return "杭州银行";

                case "BOCB2C":
                    return "中国银行";

                case "CMB":
                    return "中国招商银行";

                case "CITIC":
                    return "中信银行";
            }
            return "支付宝";
        }
        if (strArray[0].ToUpper() == "TENPAY")
        {
            switch (strArray[1].ToUpper())
            {
                case "0":
                    return "财付通";

                case "1001":
                    return "招商银行";

                case "1002":
                    return "中国工商银行";

                case "1003":
                    return "中国建设银行";

                case "1004":
                    return "上海浦东发展银行";

                case "1005":
                    return "中国农业银行";

                case "1006":
                    return "中国民生银行";

                case "1008":
                    return "深圳发展银行";

                case "1009":
                    return "兴业银行";

                case "1028":
                    return "广州银联";

                case "1032":
                    return "   北京银行";

                case "1020":
                    return "   中国交通银行";

                case "1022":
                    return "   中国光大银行";
            }
            return "财付通";
        }
        if (strArray[0].ToUpper() == "51ZFK")
        {
            string str4 = strArray[1].ToUpper();
            if (str4 == null)
            {
                return str;
            }
            if (!(str4 == "SZX"))
            {
                if (str4 != "ZFK")
                {
                    return str;
                }
            }
            else
            {
                return "神州行充值卡";
            }
            return "51支付卡";
        }
        if (strArray[0].ToLower() == "007KA")
        {
            return "神州行充值卡";
        }
        return str;
    }

    protected void gHistory_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            long num = _Convert.StrToLong(e.Item.Cells[13].Text, 0L);
            string text = e.Item.Cells[2].Text;
            if (text.Length > 6)
            {
                text = text.Substring(0, 5) + "..";
            }
            e.Item.Cells[2].Text = "<span class='red12_2'><a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'>" + text + "</a></span>";
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
                e.Item.Cells[10].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'><font color=\"blue\"> 未中奖 </font></a>";
                e.Item.Cells[10].Style.Add(HtmlTextWriterStyle.Color, "FFFFCC");
            }
            else
            {
                e.Item.Cells[10].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'><font color=\"red\">中奖啦!</font></a>";
            }
            bool flag = false;
            try
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                flag = _Convert.StrToBool(dataItem.Row["IsOpened"].ToString(), false);
                if (!flag)
                {
                    e.Item.BackColor = Color.FromName("#FFFFCA");
                    e.Item.Cells[10].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'><font color=\"blue\">未开奖</font></a>";
                    e.Item.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFCA");
                }
            }
            catch
            {
            }
            if (_Convert.StrToShort(e.Item.Cells[14].Text, 1) != 0)
            {
                string str2 = "已撤单";
                e.Item.Cells[12].Text = "<span class='red12_2'><a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'>" + str2 + "</a></span>";
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
                        e.Item.Cells[12].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'><font color=\"blue\"><Font color='Red'>已满员</font></a>";
                    }
                    else
                    {
                        e.Item.Cells[12].Text = "<span class='red12_2'><a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'>未满员</a></span>";
                    }
                }
            }
            else
            {
                e.Item.Cells[12].Text = "<a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'><font color=\"red\">已成功</font></a>";
            }
        }
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        string iD = ((ShoveGridPager)Sender).ID;
        if (iD != null)
        {
            if (!(iD == "gPager"))
            {
                if (!(iD == "gPagerHistory"))
                {
                    if (!(iD == "gPagerReward"))
                    {
                        if (!(iD == "gPagerUserPay"))
                        {
                            if (!(iD == "gPagergDistills"))
                            {
                                if (iD == "gPagerScoring")
                                {
                                    this.hdCurDiv.Value = "divScoring";
                                    this.BindScoring();
                                }
                                return;
                            }
                            this.hdCurDiv.Value = "divUserDistills";
                            this.BindDistills();
                            return;
                        }
                        this.hdCurDiv.Value = "divUserPay";
                        this.BindUserPayData();
                        return;
                    }
                    this.hdCurDiv.Value = "divReward";
                    this.BindRewardData();
                    return;
                }
            }
            else
            {
                this.hdCurDiv.Value = "divAccountDetail";
                this.BindData();
                return;
            }
            this.hdCurDiv.Value = "divBuy";
            this.BindHistoryData();
        }
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindHistoryData();
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
            e.Item.Cells[2].Text = "<span class='red12_2'><a href='Scheme.aspx?id=" + e.Item.Cells[8].Text + "' target='_blank'>投注内容</a></span>";
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

    protected void gScoring_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            double num = _Convert.StrToDouble(e.Item.Cells[1].Text, 0.0);
            e.Item.Cells[1].Text = (num == 0.0) ? "" : num.ToString("N");
            if (num != 0.0)
            {
                this.inScoreCount++;
                this.inScoreMoney += num;
            }
            num = _Convert.StrToDouble(e.Item.Cells[2].Text, 0.0);
            e.Item.Cells[2].Text = (num == 0.0) ? "" : num.ToString("N");
            if (num != 0.0)
            {
                this.outScoreCount++;
                this.outScoreMoney += num;
            }
            switch (e.Item.Cells[3].Text)
            {
                case "1":
                    e.Item.Cells[3].Text = "购彩奖积分";
                    return;

                case "2":
                    e.Item.Cells[3].Text = "下级购彩奖积分";
                    return;

                case "3":
                    e.Item.Cells[3].Text = "系统奖励积分";
                    return;

                case "4":
                    e.Item.Cells[3].Text = "手工增加积分";
                    return;

                case "101":
                    e.Item.Cells[3].Text = "兑换积分";
                    return;

                case "201":
                    e.Item.Cells[3].Text = "惩罚扣积分";
                    e.Item.Cells[2].Text = e.Item.Cells[1].Text;
                    e.Item.Cells[1].Text = "";
                    return;
            }
            e.Item.Cells[3].Text = "";
        }
    }

    protected void gUserDistills_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        HiddenField field = (HiddenField)e.Item.FindControl("tdDistillID");
        int num = _Convert.StrToInt(field.Value, 0);
        if (e.CommandName == "QuashDistills")
        {
            string key = "Room_UserDistills_" + base._User.ID.ToString();
            string returnDescription = "";
            if (base._User.DistillQuash((long)num, ref returnDescription) < 0)
            {
                JavaScript.Alert(this.Page, "数据库读写错误.");
                return;
            }
            if (returnDescription != "")
            {
                JavaScript.Alert(this.Page, returnDescription);
                return;
            }
            JavaScript.Alert(this.Page, "撤销成功。");
            Shove._Web.Cache.ClearCache(key);
            this.BindDistills();
        }
        else if (e.CommandName == "ShowDistillDetail")
        {
            this.isShowDistill.Visible = true;
            string str3 = "";
            string str4 = "";
            string str5 = "";
            DataTable table = new Tables.T_UserDistills().Open("BankCardNumber,AlipayName,[DateTime],BankName", "id = " + num, "");
            str3 = table.Rows[0]["BankCardNumber"].ToString();
            str4 = table.Rows[0]["AlipayName"].ToString();
            str5 = table.Rows[0]["DateTime"].ToString();
            if (str3 == "")
            {
                this.lblDistillBankType.Text = "支付宝提款";
                this.lblDistillBanks.Text = "支付宝账号: ";
                this.lblDistillBankDetail.Text = str4;
                this.lbAccountBank.Visible = false;
                this.lbAccountBankDetail.Visible = false;
            }
            else
            {
                this.lblDistillBankType.Text = "银行卡提款";
                this.lblDistillBankDetail.Text = str3;
                this.lblDistillBanks.Text = "银行卡号: ";
                this.lbAccountBank.Visible = true;
                this.lbAccountBankDetail.Visible = true;
                this.lbAccountBank.Text = table.Rows[0]["BankName"].ToString();
            }
            this.lblDistillTime.Text = str5.ToString();
        }
        this.BindUserPayData();
        this.BindDistills();
    }

    protected void gUserDistills_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            double num = _Convert.StrToDouble(e.Item.Cells[1].Text, 0.0);
            e.Item.Cells[1].Text = (num == 0.0) ? "" : num.ToString("N");
            num = _Convert.StrToDouble(e.Item.Cells[2].Text, 0.0);
            e.Item.Cells[2].Text = (num == 0.0) ? "" : num.ToString("N");
            e.Item.Cells[3].Text = "提款";
            switch (e.Item.Cells[4].Text)
            {
                case "0":
                    e.Item.Cells[4].Text = "申请状态";
                    return;

                case "-1":
                    e.Item.Cells[4].Text = "不受理";
                    return;

                case "1":
                    e.Item.Cells[4].Text = "已受理";
                    return;

                case "-2":
                    e.Item.Cells[4].Text = "已取消";
                    return;
            }
            e.Item.Cells[4].Text = "";
        }
    }

    protected void gUserPay_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        HiddenField field = (HiddenField)e.Item.FindControl("tdUserPayDetail");
        int num = _Convert.StrToInt(field.Value.ToString(), 0);
        string bankCode = "";
        string str2 = "";
        string str3 = "";
        if (e.CommandName == "ShowUserPayDetail")
        {
            this.isShowUserPay.Visible = true;
            DataTable table = new Tables.T_UserPayDetails().Open("PayType , [Money] , [DateTime]", "id = " + num, "");
            bankCode = table.Rows[0]["PayType"].ToString();
            str2 = table.Rows[0]["Money"].ToString();
            str3 = table.Rows[0]["DateTime"].ToString();
            this.lblUserPayBank.Text = this.getBankName(bankCode);
            this.lblUserPayMoneys.Text = str2.Substring(0, str2.IndexOf('.')) + str2.Substring(str2.IndexOf('.'), 3);
            this.lblUserPayTime.Text = str3;
        }
        this.BindUserPayData();
        this.BindDistills();
    }

    protected void gUserPay_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            double num = _Convert.StrToDouble(e.Item.Cells[1].Text, 0.0);
            e.Item.Cells[1].Text = (num == 0.0) ? "" : num.ToString("N");
            num = _Convert.StrToDouble(e.Item.Cells[2].Text, 0.0);
            e.Item.Cells[2].Text = (num == 0.0) ? "" : num.ToString("N");
            e.Item.Cells[3].Text = this.getBankName(e.Item.Cells[3].Text);
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
            this.BindDataForYearMonth();
            this.BindDataForYearMonth1();
            this.BinDataForDay();
            this.BinDataForDay1();
            this.BindData();
            this.BindHistoryData();
            this.BindRewardData();
            this.BindUserPayData();
            this.BindDistills();
            this.BindScoring();
        }
    }
}

