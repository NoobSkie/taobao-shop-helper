using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class JoinAllBuy : SitePageBase, IRequiresSessionState
{
    public static Dictionary<int, string> Lotteries = new Dictionary<int, string>();
    public string script = "";


    static JoinAllBuy()
    {
        Lotteries[0x3b] = "15X5";
        Lotteries[9] = "22X5";
        Lotteries[0x41] = "31X7";
        Lotteries[6] = "3D";
        Lotteries[0x27] = "CJDLT";
        Lotteries[0x3a] = "DF6J1";
        Lotteries[2] = "JQC";
        Lotteries[15] = "LCBQC";
        Lotteries[0x3f] = "PL3";
        Lotteries[0x40] = "PL5";
        Lotteries[13] = "QLC";
        Lotteries[3] = "QXC";
        Lotteries[1] = "SFC";
        Lotteries[0x3d] = "SSC";
        Lotteries[0x1d] = "SSL";
        Lotteries[5] = "SSQ";
        Lotteries[0x3e] = "SYYDJ";
    }

    private void BindActiveMembers()
    {
        string key = "Home_Room_JoinAllBuy_BindActiveMembers";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            string commandText = "Select b.Name,a.* from T_ActiveAllBuyStar a inner join T_Lotteries  b on b.ID = a.LotterieID order by a.[Order] asc";
            cacheAsDataTable = MSSQL.Select(commandText, new MSSQL.Parameter[0]);
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
        }
        StringBuilder builder = new StringBuilder();
        builder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\">");
        string str3 = "";
        string[] strArray = null;
        string str4 = "";
        string str5 = "";
        string str6 = "";
        for (int i = 0; (i < cacheAsDataTable.Rows.Count) && (i < 4); i++)
        {
            str3 = "#FFFFE6";
            if ((i % 2) != 0)
            {
                str3 = "#F7F7F7";
            }
            strArray = cacheAsDataTable.Rows[i]["UserList"].ToString().Trim().Split(new char[] { ',' });
            str4 = cacheAsDataTable.Rows[i]["LotterieID"].ToString();
            builder.Append("<tr>").Append("<td width=\"27%\" height=\"36\" align=\"center\" bgcolor=\"" + str3 + "\" class=\"black12\">").Append(cacheAsDataTable.Rows[i]["Name"].ToString()).Append("</td>").Append("<td width=\"73%\" align=\"left\" class=\"blue12_line\" style=\"padding: 5px;\">");
            builder.Append("<table>");
            int num2 = 0;
            bool flag = false;
            foreach (string str7 in strArray)
            {
                str5 = str7.Split(new char[] { '|' })[0].Trim();
                str6 = str7.Split(new char[] { '|' })[1].Trim();
                if ((num2 % 2) == 0)
                {
                    flag = false;
                    builder.Append("<tr>");
                }
                else
                {
                    flag = true;
                }
                builder.Append("<td");
                if ((strArray.Length - num2) == 1)
                {
                    builder.Append(" colspan='2'>");
                }
                else
                {
                    builder.Append(">");
                }
                builder.Append("<a target='blank' href='Home/Web/Score.aspx?id=" + str6 + "&LotteryID=" + str4 + "'>").Append(str5).Append("</a>&nbsp;").Append("</td>");
                if (((num2 % 2) == 0) && flag)
                {
                    builder.Append("</tr>");
                }
                num2++;
            }
            builder.Append("</table></td>").Append("</tr>");
        }
        builder.Append("</table>");
        this.tdActiveMembers.InnerHtml = builder.ToString();
    }

    private void BindCobuyRecord()
    {
        string key = "Admin_RecallingRecord_BindData";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            string commandText = "select b.ID,a.State,LotteryID,Level, \r\n                            InitiateUserID, LotteryName,InitiateName,Money,WinMoney,\r\n                            WinMoney/Money as Win from T_RecallingAllBuyStar a inner join V_Schemes  b \r\n                            on a.SchemesID = b.ID and WinMoney>0 and Buyed = 1 and IsOpened = 1 and a.State = 0 \r\n                            order by WinMoney desc ";
            cacheAsDataTable = MSSQL.Select(commandText, new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
        }
        DataTable dt = cacheAsDataTable.Clone();
        dt.Columns.Add("Count", typeof(int));
        string filterExpression = "1=1";
        if (this.ddlLottery1.SelectedValue != "-1")
        {
            filterExpression = "LotteryID=" + this.ddlLottery1.SelectedValue;
        }
        DataRow[] rowArray = cacheAsDataTable.Select(filterExpression, "WinMoney desc");
        for (int i = 0; i < rowArray.Length; i++)
        {
            dt.Rows.Add(rowArray[i].ItemArray);
            dt.Rows[i]["Count"] = i + 1;
        }
        PF.DataGridBindData(this.g1, dt, this.gPager1);
    }

    private void BindData()
    {
        string commandText = "select LotteryName, InitiateName,Level, \r\n                            Money, Schedule,Title,case Schedule when 100 then 1 else 0 end as IsFull,LotteryID,SchemeBonusScale, ID, QuashStatus,(Share-BuyedShare) as ResShare,AssureMoney,Money/Share as ShareMoney,IsuseID,EndTime,AtTopStatus,PlayTypeID \r\n                        from V_Schemes with (nolock) where IsuseID in \r\n                        (select id from T_Isuses where  getdate() between StartTime and EndTime) \r\n                        and Share > 1 and money >= 10 order by QuashStatus asc,IsFull asc,Schedule desc,[Money] desc";
        string key = "Home_Room_JoinAllBuy_BindData";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = MSSQL.Select(commandText, new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 600);
        }
        DataTable dt = cacheAsDataTable.Clone();
        dt.Columns.Add("Count", typeof(int));
        string filterExpression = "1=1";
        if (this.ddlLottery.SelectedValue != "-1")
        {
            if (this.ddlLottery.SelectedValue == "0")
            {
                filterExpression = filterExpression + " and LotteryID not in(5,6,1,19,39,62,29)";
            }
            else if (this.ddlLottery.SelectedValue == "19")
            {
                filterExpression = filterExpression + " and (PlayTypeID = 103 or PlayTypeID = 104) and LotteryID = 1";
            }
            else
            {
                filterExpression = filterExpression + " and LotteryID=" + this.ddlLottery.SelectedValue;
                if (this.ddlLottery.SelectedValue == "1")
                {
                    filterExpression = filterExpression + " and (PlayTypeID = 101 or PlayTypeID = 102)";
                }
            }
        }
        if (this.ddlMoney.SelectedValue != "-1")
        {
            filterExpression = filterExpression + " and " + this.ddlMoney.SelectedValue;
        }
        if (this.ddlBonus.SelectedValue != "-1")
        {
            filterExpression = filterExpression + " and SchemeBonusScale<=" + this.ddlBonus.SelectedValue;
        }
        if (this.ddlCondition.SelectedValue != "-1")
        {
            filterExpression = filterExpression + " and " + this.ddlCondition.SelectedValue;
        }
        if (this.tbName.Text != "")
        {
            filterExpression = filterExpression + " and InitiateName like '%" + Utility.FilteSqlInfusion(this.tbName.Text) + "%'";
        }
        int num = 0;
        foreach (DataRow row in cacheAsDataTable.Select(filterExpression, "QuashStatus asc,IsFull asc, Schedule desc,[Money] desc"))
        {
            dt.Rows.Add(row.ItemArray);
            dt.Rows[num]["Count"] = num + 1;
            num++;
        }
        PF.DataGridBindData(this.g, dt, this.gPager);
    }

    private void BindDataForLottery(DropDownList ddl)
    {
        string key = "Home_Room_JoinAllBuy_BindDataForLottery";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[Order]");
            if (cacheAsDataTable == null)
            {
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
        }
        ddl.DataSource = cacheAsDataTable;
        ddl.DataTextField = "Name";
        ddl.DataValueField = "ID";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("全部彩种", "-1"));
    }

    private void BindLastestUsers()
    {
        string key = "Home_Room_JoinAllBuy_BindLastestUsers";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Views.V_BuyDetails().Open("top 100 Name,DetailMoney, InitiateName", "Money >= 50 and IsuseID in (select id from T_Isuses where  getdate() between StartTime and EndTime) and SchemeShare> 1 and UserID<>InitiateUserID", "DateTime desc");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 600);
        }
        StringBuilder builder = new StringBuilder();
        builder.Append("<table width=\"230\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"1\">").Append("<tr>").Append("<td width=\"69\" height=\"22\" align=\"center\" bgcolor=\"#FFCC33\" class=\"black12\">").Append("用户名").Append("</td>").Append("<td width=\"88\" align=\"center\" bgcolor=\"#FFCC33\" class=\"black12\">").Append("发起人").Append("</td>").Append("<td width=\"69\" align=\"center\" bgcolor=\"#FFCC33\" class=\"black12\">").Append("跟单金额").Append("</td>").Append("</tr>").Append("<tr>").Append("<td colspan='3' width=\"230\">").Append("<div id='scrollWinUsers' style='overflow:hidden;height:260px'>").Append("<table>");
        foreach (DataRow row in cacheAsDataTable.Rows)
        {
            builder.AppendLine("<tr>").AppendLine("<td width=\"69\" height=\"22\" align=\"left\" class=\"blue12\" title='" + row["Name"].ToString() + "'><nobr>").AppendLine(_String.Cut(row["Name"].ToString(), 4)).AppendLine("</nobr></td>").AppendLine("<td width=\"88\" class=\"black12\" align=\"left\" title='" + row["InitiateName"].ToString() + "'><nobr>").AppendLine(_String.Cut(row["InitiateName"].ToString(), 7)).AppendLine("</nobr></td>").AppendLine("<td width=\"69\" class=\"red12\" align=\"left\">").Append("￥").AppendLine(_Convert.StrToDouble(row["DetailMoney"].ToString(), 0.0).ToString("N")).AppendLine("</td>").AppendLine("</tr>");
        }
        builder.Append("</table>").Append("</div>").Append("</td>").Append("</tr>").Append("</table>");
        this.divUserList.InnerHtml = builder.ToString();
    }

    private void BindNews()
    {
        string key = "Home_Room_JoinAllBuy_BindNews";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Views.V_News().Open("top 5 Title,Content", "isShow = 1  and [TypeName] = '热门人物追踪'", "isCommend,DateTime desc");
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                return;
            }
            Shove._Web.Cache.SetCache(key, 0x1770);
        }
        StringBuilder builder = new StringBuilder();
        foreach (DataRow row in cacheAsDataTable.Rows)
        {
            builder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">").Append("<tr>").Append(" <td align=\"left\" class=\"hui12\" style=\"padding: 3px 0px 3px 0px;\">").Append("<a href='" + row["Content"].ToString() + "' target='_blank'>").Append(row["Title"].ToString()).Append("</a>").Append("</td>").Append("</tr>").Append("<tr>").Append("<td class=\"hui12\" height=\"15\">").Append("<div id=\"hr\">").Append("</div>").Append("</td>").Append("</tr>").Append("</table>");
        }
        this.tdNews.InnerHtml = builder.ToString();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void ddlBonus_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void ddlCondition_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.script = "document.getElementById('g').focus();";
        this.BindData();
    }

    protected void ddlLottery1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.script = "document.getElementById('tdActiveMembers').focus();";
        this.BindCobuyRecord();
    }

    protected void ddlMoney_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Buy")
        {
            if ((base._User != null) && (string.IsNullOrEmpty(base._User.IDCardNumber) || string.IsNullOrEmpty(base._User.RealityName)))
            {
                base.Response.Write("<script>alert('对不起，您的身份证号码或者真实姓名没有填写，为了不影响您的领奖，请先完善这些资料。谢谢！');window.open('UserEdit.aspx');</script>");
            }
            else
            {
                TextBox box = e.Item.FindControl("tbShare") as TextBox;
                int share = _Convert.StrToInt(box.Text, 0);
                double num2 = 0.0;
                try
                {
                    num2 = _Convert.StrToDouble(e.Item.Cells[6].Text, 0.0);
                }
                catch
                {
                    JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
                    return;
                }
                if ((num2 > 0.0) && (share >= 1))
                {
                    if (_Convert.StrToInt(e.Item.Cells[8].Text, 0) < share)
                    {
                        JavaScript.Alert(this.Page, "认购份数不能超过剩余份数(" + e.Item.Cells[8].Text + "份)");
                        box.Text = "1";
                    }
                    else
                    {
                        DateTime time3 = _Convert.StrToDateTime(e.Item.Cells[14].Text, DateTime.Now.AddMonths(-1).ToString());
                        if (DateTime.Now > time3)
                        {
                            JavaScript.Alert(this.Page, "投注时间已经截止，不能认购。");
                        }
                        else if ((num2 * share) > base._User.Balance)
                        {
                            base.Response.Write("<script>alert('您的账户余额不足，请先充值，谢谢。');window.open('Home/Room/OnlinePay/Default.aspx');</script>");
                        }
                        else
                        {
                            string returnDescription = "";
                            if (base._User.JoinScheme(_Convert.StrToLong(e.Item.Cells[12].Text, 0L), share, ref returnDescription) < 0)
                            {
                                JavaScript.Alert(this.Page, returnDescription);
                            }
                            else
                            {
                                Shove._Web.Cache.ClearCache("Home_Room_JoinAllBuy_BindData");
                                Shove._Web.Cache.ClearCache("Home_Room_JoinAllBuy_BindLastestUsers");
                                Shove._Web.Cache.ClearCache("Home_Room_CoBuy_BindDataForType" + e.Item.Cells[15].Text);
                                Shove._Web.Cache.ClearCache("Home_Room_SchemeAll_BindData" + e.Item.Cells[15].Text);
                                JavaScript.Alert(this.Page, "认购成功！", "JoinAllBuy.aspx");
                            }
                        }
                    }
                }
                else
                {
                    JavaScript.Alert(this.Page, "请输入认购份数。");
                }
            }
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[1].Text = "<a href='Home/Room/Scheme.aspx?id=" + e.Item.Cells[12].Text + "' target='_blank'>" + e.Item.Cells[1].Text + "</a>";
            string text = e.Item.Cells[2].Text;
            e.Item.Cells[2].Text = _String.Cut(text, 5);
            e.Item.Cells[2].ToolTip = text;
            if (_Convert.StrToDouble(e.Item.Cells[11].Text, 0.0) > 0.0)
            {
                TableCell cell1 = e.Item.Cells[2];
                cell1.Text = cell1.Text + "<font color='red'>(保)</font>";
            }
            double num = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            e.Item.Cells[3].Text = "";
            for (int i = 0; i < num; i++)
            {
                if (num >= 3.0)
                {
                    TableCell cell2 = e.Item.Cells[3];
                    cell2.Text = cell2.Text + "<img src='Home/Room/Images/star.gif' border='0'>";
                }
                else
                {
                    TableCell cell3 = e.Item.Cells[3];
                    cell3.Text = cell3.Text + "<img src='Home/Room/Images/icon_star.gif' border='0'>";
                }
            }
            string input = e.Item.Cells[4].Text.Trim();
            if (input == "(无标题)")
            {
                input = "";
            }
            e.Item.Cells[4].Text = "<a href='Home/Room/Scheme.aspx?id=" + e.Item.Cells[12].Text + "' target='_blank'>" + _String.Cut(input, 10) + "</a>";
            e.Item.Cells[4].ToolTip = input;
            short num3 = _Convert.StrToShort(e.Item.Cells[13].Text, 0);
            int num4 = _Convert.StrToInt(e.Item.Cells[8].Text, 0);
            TableCell cell4 = e.Item.Cells[7];
            cell4.Text = cell4.Text + "%";
            if (num3 != 0)
            {
                e.Item.Cells[10].Text = "已撤单";
            }
            else if (num4 < 1)
            {
                e.Item.Cells[10].Text = "已满员";
            }
            TextBox box = e.Item.FindControl("tbShare") as TextBox;
            box.ToolTip = "可认购" + e.Item.Cells[8].Text + "份";
            if (((e.Item.Cells[0x10].Text.Trim() == "103") || (e.Item.Cells[0x10].Text.Trim() == "104")) && (e.Item.Cells[1].Text.Trim() == "胜负彩"))
            {
                e.Item.Cells[1].Text = "任九场";
            }
        }
    }

    protected void g1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "DZ")
        {
            string s = "followScheme(" + e.Item.Cells[8].Text + ");$Id(\"iframeFollowScheme\").src=\"Home/Room/FollowFriendSchemeAdd.aspx?LotteryID=" + e.Item.Cells[8].Text + "&FollowUserID=" + e.Item.Cells[9].Text + "&FollowUserName=" + HttpUtility.UrlEncode(e.Item.Cells[2].Text) + "\"";
            s = Encrypt.EncryptString(PF.GetCallCert(), s);
            base.Response.Redirect(this.GetURL(e.Item.Cells[8].Text, s));
        }
    }

    protected void g1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            double num = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            e.Item.Cells[3].Text = "";
            for (int i = 0; i < num; i++)
            {
                if (num >= 3.0)
                {
                    TableCell cell1 = e.Item.Cells[3];
                    cell1.Text = cell1.Text + "<img src='Home/Room/Images/star.gif' border='0'>";
                }
                else
                {
                    TableCell cell2 = e.Item.Cells[3];
                    cell2.Text = cell2.Text + "<img src='Home/Room/Images/icon_star.gif' border='0'>";
                }
            }
            if (e.Item.Cells[11].Text == "1")
            {
                e.Item.Cells[1].Text = "<a href='Home/Room/Scheme.aspx?id=" + e.Item.Cells[10].Text + "&Source=1' target='_blank''>" + e.Item.Cells[1].Text + "</a>";
            }
            else
            {
                e.Item.Cells[1].Text = "<a href='Home/Room/Scheme.aspx?id=" + e.Item.Cells[10].Text + "' target='_blank''>" + e.Item.Cells[1].Text + "</a>";
            }
        }
    }

    private string GetURL(string LotteryID, string para)
    {
        int num = _Convert.StrToInt(LotteryID, 5);
        return ("Lottery/Lottery/Buy_" + Lotteries[num] + ".aspx?DZ=" + para);
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindData();
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindData();
    }

    protected void gPager1_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindCobuyRecord();
    }

    protected void gPager1_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindCobuyRecord();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataForLottery(this.ddlLottery1);
            this.BindLastestUsers();
            this.BindData();
            this.BindNews();
            this.BindActiveMembers();
            this.BindCobuyRecord();
        }
    }
}

