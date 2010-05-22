using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_NewsPaper : SitePageBase, IRequiresSessionState
{
    private static Dictionary<int, string> LotteryOpenedDay = new Dictionary<int, string>();

    private void BindddlIsuses()
    {
        string key = "Home_Room_NewsPaper";
        if (Shove._Web.Cache.GetCacheAsDataTable(key) == null)
        {
            DataTable dt = new Tables.T_NewsPaperIsuses().Open("", "", " ID desc");
            if (dt == null)
            {
                PF.GoError(4, "数据库繁忙，请重试！", base.GetType().BaseType.FullName);
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    row["Name"] = row["Name"].ToString() + "期";
                }
                ControlExt.FillDropDownList(this.ddlIsusesID, dt, "Name", "ID");
            }
        }
    }

    private void BindNewsPaper()
    {
        string key = "Home_Room_NewsPaper_BindNewsPaper_" + this.ddlIsusesID.SelectedValue;
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        cacheAsDataTable = null;
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_NewsPaperIsuses().Open("", "ID = " + this.ddlIsusesID.SelectedValue, "[ID]");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return;
            }
            if (cacheAsDataTable.Rows.Count > 0)
            {
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xe10);
            }
        }
        if (cacheAsDataTable.Rows.Count > 0)
        {
            this.LoadOpenDay(cacheAsDataTable.Rows[0]["Name"].ToString());
            this.tdIsuseOpenInfo.InnerHtml = cacheAsDataTable.Rows[0]["NPMessage"].ToString().Replace("<$Content>", this.BindWinNumber(cacheAsDataTable.Rows[0]["Name"].ToString()));
        }
        string text = this.ddlIsusesID.SelectedItem.Text;
        this.lbTime.Text = "今天是：" + DateTime.Now.ToString("yyyy年MM月dd日") + "&nbsp 彩友报<span class='red14_2'>" + text.Substring(0, text.Length - 1) + "</span>期";
    }

    private string BindWinNumber(string Name)
    {
        string key = "Home_Room_NewsPaper_BindWinNumber";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select  a.Name,WinLotteryNumber,b.Name as LotteryName,TotalMoney,LotteryID from T_Isuses a ").Append("left join T_Lotteries b on a.LotteryID = b.ID ").Append("left join T_TotalMoney c on a.ID = c.IsuseID ").Append("where a.IsOpened = 1 and LotteryID in(3,5,6,9,13,39,58,59,63,64) and a.ID = (select top 1 ID from T_Isuses where LotteryID = a.LotteryID and IsOpened = 1 order by EndTime desc)");
            cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据繁忙，请重试！", base.GetType().BaseType.FullName);
                return "";
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xe10);
        }
        return this.BindWinTable(cacheAsDataTable, Name);
    }

    private string BindWinTable(DataTable dt, string Name)
    {
        StringBuilder builder = new StringBuilder();
        string str = "";
        int num = 0;
        int num2 = 0;
        if (Name == "0902")
        {
            builder.Append("<table cellspacing='1' cellpadding='0' width='450' bgcolor='#dddddd' border='0'> ").Append("<tbody>").Append("<tr>").Append("<td class='blue14' align='center' width='75' bgcolor='#ecf9ff' height='30'><strong>彩种</strong></td>").Append("<td class='blue14' align='center' width='62' bgcolor='#ecf9ff'><strong>期号</strong></td>").Append("<td class='blue14' align='center' width='191' bgcolor='#ecf9ff'><strong>开奖号码</strong></td>").Append("<td class='blue14' align='center' width='117' bgcolor='#ecf9ff'><strong>开奖时间</strong></td>").Append("</tr>");
            double num3 = 0.0;
            foreach (DataRow row in dt.Rows)
            {
                num = _Convert.StrToInt(row["LotteryID"].ToString(), 0);
                if (LotteryOpenedDay.Keys.Contains<int>(num))
                {
                    str = "#ffffff";
                    if ((num2 % 2) != 0)
                    {
                        str = "#f7f7f7";
                    }
                    num2++;
                    builder.Append("<tr>").Append("<td height=\"30\" align=\"left\" bgcolor=\"" + str + "\" class=\"hui12\" style=\"padding-left:10px;\">").Append(row["LotteryName"].ToString()).Append("</td>").Append("<td align=\"left\" bgcolor=\"" + str + "\" class=\"hui12\" style=\"padding-left:10px;\">").Append(row["Name"].ToString()).Append("</td>").Append("<td align=\"left\" bgcolor=\"" + str + "\" class=\"hui14_2\" style=\"padding-left:10px;\"");
                    num3 = _Convert.StrToDouble(row["TotalMoney"].ToString(), 0.0);
                    if (num3 > 0.0)
                    {
                        builder.Append("height=\"60\"");
                    }
                    builder.Append(">").Append(this.FormatLotteryWinNumber(num.ToString(), row["WinLotteryNumber"].ToString()));
                    if (num3 > 0.0)
                    {
                        builder.Append("<table width=\"92%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">").Append("<tr>").Append("<td height=\"8\"><div id=\"hr\"></div></td>").Append("</tr>").Append("<tr>").Append("<td class=\"blue12\">").Append("奖池滚存：").Append(num3.ToString("N")).Append("元</td></tr></table>");
                    }
                    builder.Append("</td>").Append("<td align=\"center\" bgcolor=\"" + str + "\" class=\"hui12\" >").Append(LotteryOpenedDay[num]).Append("</td></tr>");
                }
            }
        }
        else if (Name == "0903")
        {
            builder.Append("<table width='98%' border='0' cellpadding='0' cellspacing='1' style='background-color: #CCC'").Append("<tbody>").Append("<tr  class='blue11'>").Append("<td width='22%' height='24' align='center' valign='middle' bgcolor='#E6F6F8'>彩种</td>").Append("<td width='17%' height='24' align='center' valign='middle' bgcolor='#E6F6F8'>期号</td>").Append("<td width='41%' height='24' align='center' valign='middle' bgcolor='#E6F6F8'>开奖号码</td>").Append("<td width='20%' height='24' align='center' valign='middle' bgcolor='#E6F6F8'>开奖时间</td>").Append("</tr>");
            foreach (DataRow row2 in dt.Rows)
            {
                num = _Convert.StrToInt(row2["LotteryID"].ToString(), 0);
                if (LotteryOpenedDay.Keys.Contains<int>(num))
                {
                    str = "#FFFFFF";
                    if ((num2 % 2) != 0)
                    {
                        str = "#F6F9F9";
                    }
                    num2++;
                    builder.Append("<tr>").Append("<td height='24' align='center' bgcolor=\"" + str + "\" class='hui14_2'>").Append(row2["LotteryName"].ToString()).Append("</td>").Append("<td height='24' align='center' bgcolor=\"" + str + "\" class='hui12'>").Append(row2["Name"].ToString()).Append("</td>").Append("<td height='24' align='center' bgcolor=\"" + str + "\" class='hui14_2'>").Append(this.FormatLotteryWinNumber(num.ToString(), row2["WinLotteryNumber"].ToString())).Append("</td>").Append("<td height='24' align='center' bgcolor=\"" + str + "\" class='hui12'>").Append(LotteryOpenedDay[num]).Append("</td>").Append("</tr>");
                }
            }
            builder.Append("</tbody></table>");
        }
        return builder.ToString();
    }

    protected void ddlIsusesID_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindNewsPaper();
    }

    private string FormatLotteryWinNumber(string lotteryID, string lotteryWinNumber)
    {
        lotteryWinNumber = lotteryWinNumber.Trim();
        if (string.IsNullOrEmpty(lotteryWinNumber))
        {
            return lotteryWinNumber;
        }
        string str = "";
        if (((lotteryID == "5") || (lotteryID == "39")) || ((lotteryID == "13") || (lotteryID == "58")))
        {
            return ("<span class=\"red14_2\"  style =\"font-weight:normal\" >" + lotteryWinNumber.Split(new char[] { '+' })[0] + "</span> +<span class=\"blue14\" style =\"font-weight:normal\">" + lotteryWinNumber.Split(new char[] { '+' })[1] + "</span>");
        }
        if ((lotteryID == "59") || (lotteryID == "9"))
        {
            return ("<span class=\"red14_2\" style =\"font-weight:normal\">" + lotteryWinNumber + "</span>");
        }
        if ((!(lotteryID == "6") && !(lotteryID == "3")) && (!(lotteryID == "63") && !(lotteryID == "64")))
        {
            return str;
        }
        str = "<span class=\"red14_2\" style =\"font-weight:normal\">";
        for (int i = 0; i < lotteryWinNumber.Length; i++)
        {
            str = str + lotteryWinNumber.Substring(i, 1) + "&nbsp;";
        }
        return (str + "</span>");
    }

    private string GetOpenDay(int[] weeks)
    {
        int dayOfWeek = (int)DateTime.Now.DayOfWeek;
        dayOfWeek = (dayOfWeek == 7) ? 0 : dayOfWeek;
        int num2 = 0;
        foreach (int num4 in weeks)
        {
            num2 = num4 - dayOfWeek;
            if (num2 >= 0)
            {
                if (num2 == 0)
                {
                    return "(今日开奖)";
                }
                if (num2 == 1)
                {
                    return "(明天开奖)";
                }
                if (num2 == 2)
                {
                    return "(后天开奖)";
                }
            }
        }
        return "(今日开奖)";
    }

    private void LoadOpenDay(string Name)
    {
        LotteryOpenedDay[0x3b] = "每日";
        LotteryOpenedDay[9] = "每日";
        LotteryOpenedDay[0x3f] = "每日";
        LotteryOpenedDay[0x40] = "每日";
        LotteryOpenedDay[6] = "每日";
        if (Name == "0903")
        {
            LotteryOpenedDay[5] = "二 四 日 ";
            LotteryOpenedDay[0x27] = "一 三 六 ";
            LotteryOpenedDay[13] = "一 三 五 ";
            LotteryOpenedDay[0x3a] = "一 三 六 ";
            LotteryOpenedDay[3] = "二 五 日 ";
        }
        else
        {
            int[] weeks = new int[] { 2, 4, 7 };
            LotteryOpenedDay[5] = "二 四 日 " + this.GetOpenDay(weeks);
            weeks = new int[] { 1, 3, 6 };
            LotteryOpenedDay[0x27] = "一 三 六 " + this.GetOpenDay(weeks);
            weeks = new int[] { 1, 3, 5 };
            LotteryOpenedDay[13] = "一 三 五 " + this.GetOpenDay(weeks);
            weeks = new int[] { 1, 3, 6 };
            LotteryOpenedDay[0x3a] = "一 三 六 " + this.GetOpenDay(weeks);
            LotteryOpenedDay[6] = "每日";
            weeks = new int[] { 2, 5, 7 };
            LotteryOpenedDay[3] = "二 五 日 " + this.GetOpenDay(weeks);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindddlIsuses();
            this.BindNewsPaper();
        }
    }
}

