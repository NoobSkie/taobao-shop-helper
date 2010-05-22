using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Database;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class WinQuery_Default : SitePageBase, IRequiresSessionState
{

    private void BindNewsForLottery()
    {
        string key = "WinQuery_OpenInfoList_ExpertsPredict";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            string commandText = "";
            commandText = "select Top 12 Title,Content,DateTime,b.Name as TypeName from (select ID,Title,Content,TypeID,[DateTime],isCommend from dbo.T_News where isShow = 1 ) a inner join dbo.T_NewsTypes b on a.TypeID = b.ID where (b.ID='102001' or b.ID='102006') order by isCommend,DateTime desc";
            cacheAsDataTable = MSSQL.Select(commandText, new MSSQL.Parameter[0]);
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
        }
        StringBuilder builder = new StringBuilder();
        builder.Append("<table width='95%' border='0' cellspacing='0' cellpadding='0'>");
        string input = "";
        string str4 = "";
        int num = 0;
        foreach (DataRow row in cacheAsDataTable.Rows)
        {
            num++;
            input = row["Title"].ToString().Trim();
            if (num > 5)
            {
                break;
            }
            if ((input.IndexOf("<font class=red12>") > -1) || (input.IndexOf("<font class=black12>") > -1))
            {
                if (input.Contains("<font class=red12>"))
                {
                    str4 = "red12";
                }
                if (input.Contains("<font class=black12>"))
                {
                    str4 = "black12";
                }
                input = input.Replace("<font class=red12>", "").Replace("<font class=black12>", "").Replace("</font>", "");
                builder.Append("<tr>").Append("<td width='2' height='32' align='left'>").Append("<span class='hui14'>&#9642;</span>").Append("</td>").Append("<td width='96%' align='left' class='blue12_3'>").Append("<a href='" + row["Content"].ToString() + "' target='_blank'>").Append("<font class = '" + str4 + "'>").Append(_String.Cut(input, 13)).Append("</font>").Append("</a></td></tr>");
                continue;
            }
            builder.Append("<tr>").Append("<td width='2' height='32' align='left'>").Append("<span class='hui14'>&#9642;</span>").Append("</td>").Append("<td width='96%' align='left' class='blue12_3'>").Append("<a href='" + row["Content"].ToString() + "' target='_blank'>").Append(_String.Cut(input, 13)).Append("</a></td></tr>");
        }
        builder.Append("</table>");
        this.ExpertsPredict.InnerHtml = builder.ToString();
    }

    private string BindOpenInfoList(int LotteryID, string LotteryCode)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("");
        string str = "";
        string str2 = "";
        DataTable winNumber = this.GetWinNumber(LotteryID, LotteryCode);
        builder.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
        for (int i = 0; i < winNumber.Rows.Count; i++)
        {
            str = winNumber.Rows[i]["Name"].ToString();
            str2 = winNumber.Rows[i]["WinLotteryNumber"].ToString();
            if ((i % 2) == 0)
            {
                builder.AppendLine("<tr>").AppendLine("<td width='50%' height='28'>").Append(string.Concat(new object[] { "<a href='", LotteryID, "-", winNumber.Rows[i]["ID"].ToString(), "-0.aspx' target='_blank'><span class='hui14'>&#9642;</span>&nbsp;第", str, "期&nbsp;&nbsp;&nbsp;&nbsp;" })).Append("<span style='color:#F86F00;'>" + str2 + "</span>").AppendLine("</a></td>");
            }
            else
            {
                builder.AppendLine("<td width='50%' height='28'>").Append(string.Concat(new object[] { "<a href='", LotteryID, "-", winNumber.Rows[i]["ID"].ToString(), "-0.aspx' target='_blank'><span class='hui14'>&#9642;</span>&nbsp;第", str, "期&nbsp;&nbsp;&nbsp;&nbsp;" })).Append("<span style='color:#F86F00;'>" + str2 + "</span>").AppendLine("</a></td>").AppendLine("</tr>");
            }
        }
        builder.Append("</table>");
        return builder.ToString();
    }

    private void BindWinList()
    {
        string key = "Default_GetUserListByWinMoney";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            string commandText = "select b.InitiateUserID, c.Name as InitiateName, Win, 62 as LotteryID from(\r\n\t\t                                select top 9 * InitiateUserID, SUM(WinMoney) as Win from T_Schemes WITH (nolock) where WinMoney > 0 \r\n\t\t                               group by a.InitiateUserID order by d.Win desc\r\n                            )as b inner join T_Users c WITH (nolock) on b.InitiateUserID = c.ID order by Win desc";
            cacheAsDataTable = MSSQL.Select(commandText, new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                return;
            }
            if (cacheAsDataTable.Rows.Count > 0)
            {
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 600);
            }
        }
        StringBuilder builder = new StringBuilder();
        int num = 0;
        string s = "";
        string str4 = "";
        string input = "";
        foreach (DataRow row in cacheAsDataTable.Rows)
        {
            str4 = _Convert.StrToDouble(row["Win"].ToString(), 0.0).ToString("N0").Split(new char[] { '.' })[0];
            input = row["InitiateName"].ToString();
            num++;
            builder.AppendLine("<tr>").Append("<td width=\"10%\" height=\"28\" align='center'>").Append("<img src=\"../Home/Room/images/num_" + num.ToString() + ".gif\" width=\"13\" height=\"13\" />").AppendLine("</td>").Append("<td width=\"33%\" class=\"blue12\" align='center' title='" + input + "'>").Append("<a href='../Home/Web/Score.aspx?id=").Append(row["InitiateUserID"].ToString()).Append("&LotteryID=62' target='_blank'>").Append(_String.Cut(input, 5)).Append("</a>").AppendLine("</td>").Append("<td width=\"33%\" class=\"hui12\" align='center'>");
            builder.Append(str4).AppendLine("</td>").Append("<td width=\"24%\" class=\"red12_3\" align='center'>");
            s = "followScheme(62);$Id(\"iframeFollowScheme\").src=\"../Home/Room/FollowFriendSchemeAdd.aspx?LotteryID=62&FollowUserID=" + row["InitiateUserID"].ToString() + "&FollowUserName=" + HttpUtility.UrlEncode(row["InitiateName"].ToString()) + "\"";
            s = Encrypt.EncryptString(PF.GetCallCert(), s);
            s = "<a href='../Home/Room/Buy_SYYDJ.aspx?DZ=" + s + "' onclick=\"return CreateLogin();\">";
            builder.Append(s + "定制</a>").AppendLine("</td>").AppendLine("</tr>");
        }
        this.tbWin.InnerHtml = builder.ToString();
    }

    private static string FormatWinNumber(string WinNumber, int LotteryID)
    {
        string str = "";
        if (((LotteryID == 6) || (LotteryID == 0x3f)) || (((LotteryID == 0x40) || (LotteryID == 3)) || (LotteryID == 0x1d)))
        {
            for (int i = 0; i < WinNumber.Length; i++)
            {
                str = str + "<span style='padding-left:5px'>" + WinNumber.Substring(i, 1) + "</span>";
            }
            return str;
        }
        if ((LotteryID == 5) || (LotteryID == 13))
        {
            string[] strArray = WinNumber.Replace(" + ", " ").Split(new char[] { ' ' });
            str = "";
            for (int j = 0; j < strArray.Length; j++)
            {
                if (j < (strArray.Length - 1))
                {
                    str = str + strArray[j] + " ";
                }
                else
                {
                    str = str + "<span class=\"blue12\">" + strArray[j] + "</span>";
                }
            }
            return str;
        }
        if (LotteryID == 0x3a)
        {
            string str3 = WinNumber.Replace("+", " ");
            for (int k = 0; k < (str3.Length - 1); k++)
            {
                str = str + "<span style='padding-left:5px'>" + str3.Substring(k, 1) + "</span>";
            }
            return (str + "<span class=\"blue12\">" + str3.Substring(str3.Length - 1, 1) + "</span>");
        }
        if (LotteryID == 0x27)
        {
            string[] strArray2 = WinNumber.Replace("+", "").Split(new char[] { ' ' });
            str = "";
            for (int m = 0; m < strArray2.Length; m++)
            {
                if (m < (strArray2.Length - 2))
                {
                    str = str + strArray2[m] + " ";
                }
                else
                {
                    str = str + "<span style='padding-left:5px' class=\"blue12\">" + strArray2[m] + "</span>";
                }
            }
            return str;
        }
        if (LotteryID == 0x41)
        {
            str = WinNumber.Replace("+", "");
            return (str.Substring(0, str.Length - 2) + "<span class=\"blue12\">" + str.Substring(str.Length - 2, 2) + "</span>");
        }
        return WinNumber;
    }

    private DataTable GetWinNumber(int LotteryID, string LotteryCode)
    {
        string key = LotteryCode + "WinNumber" + LotteryID.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
        {
            cacheAsDataTable = new Tables.T_Isuses().Open("top 10 ID, Name, WinLotteryNumber, EndTime", "LotteryID=" + LotteryID + " and IsOpened = 1 and IsNull(WinLotteryNumber,'')<>''", "EndTime Desc");
            if (cacheAsDataTable == null)
            {
                return null;
            }
            if (cacheAsDataTable.Rows.Count > 0)
            {
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 600);
            }
        }
        return cacheAsDataTable;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.ssqInfo.InnerHtml = this.BindOpenInfoList(5, "ssq");
            this.syydjInfo.InnerHtml = this.BindOpenInfoList(0x3e, "syydj");
            this.cjdltInfo.InnerHtml = this.BindOpenInfoList(0x27, "cjdlt");
            this.sslInfo.InnerHtml = this.BindOpenInfoList(0x1d, "ssl");
            this.fc3dInfo.InnerHtml = this.BindOpenInfoList(6, "fc3d");
            this.qlcInfo.InnerHtml = this.BindOpenInfoList(13, "qlc");
            this.sscInfo.InnerHtml = this.BindOpenInfoList(0x3d, "ssc");
            this.BindWinList();
            this.BindNewsForLottery();
        }
    }
}

