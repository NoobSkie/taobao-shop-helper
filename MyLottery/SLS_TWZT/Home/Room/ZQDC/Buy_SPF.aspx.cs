using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_ZCDC_Buy_SPF : RoomPageBase, IRequiresSessionState
{
    protected string MatchList = "";

    private void bindMatchs()
    {
        if (this.ddlIssues.SelectedIndex != -1)
        {
            this.expect.Value = this.ddlIssues.SelectedItem.Text;
            this.isuseid.Value = this.ddlIssues.SelectedValue;
            this.GetMatchsByIssueName(this.expect.Value);
        }
    }

    private void createHTML(DataTable dt, ref string strHTML, ref int jzCount, ref int rqCount, ref int frqCount, ref int jzrqCount, ref int jzfrqCount)
    {
        jzCount = 0;
        rqCount = 0;
        frqCount = 0;
        jzrqCount = 0;
        jzfrqCount = 0;
        strHTML = "";
        if ((dt.Rows != null) && (dt.Rows.Count > 0))
        {
            StringBuilder builder = new StringBuilder();
            int num = 0;
            int num2 = 0;
            DateTime now = DateTime.Now;
            DateTime time2 = DateTime.Now;
            DateTime time3 = DateTime.Now;
            DateTime time4 = DateTime.Now;
            string str = "";
            string str2 = "";
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    time3 = _Convert.StrToDateTime(row["DateTime"].ToString(), DateTime.Now.ToString());
                    time4 = _Convert.StrToDateTime(row["SaleEndTime"].ToString(), DateTime.Now.ToString());
                    if (num2 == 0)
                    {
                        if (string.Compare(time3.ToString("HH:mm"), "10:00") >= 0)
                        {
                            now = _Convert.StrToDateTime(time3.ToString("yyyy-MM-dd") + " 10:00:00", DateTime.Now.ToString());
                            time2 = _Convert.StrToDateTime(time3.AddDays(1.0).ToString("yyyy-MM-dd") + " 10:00:00", DateTime.Now.ToString());
                        }
                        else
                        {
                            now = _Convert.StrToDateTime(time3.AddDays(-1.0).ToString("yyyy-MM-dd") + " 10:00:00", DateTime.Now.ToString());
                            time2 = _Convert.StrToDateTime(time3.ToString("yyyy-MM-dd") + " 10:00:00", DateTime.Now.ToString());
                        }
                        builder.AppendLine("<tr>").AppendLine("<td height=\"24\" colspan=\"15\" align=\"center\" bgcolor=\"#E6E6E6\" class=\"black12\"><strong>").AppendLine(now.ToString("yyyy-MM-dd") + " " + this.getWeekDayName(now.DayOfWeek) + "(10：00--次日10：00)</strong></td>").AppendLine("</tr>");
                    }
                    else if (time3 > time2)
                    {
                        now = now.AddDays(1.0);
                        time2 = time2.AddDays(1.0);
                        builder.AppendLine("<tr>").AppendLine("<td height=\"22\" colspan=\"15\" align=\"center\" bgcolor=\"#E6E6E6\" class=\"black12\"><strong>").AppendLine(now.ToString("yyyy-MM-dd") + " " + this.getWeekDayName(now.DayOfWeek) + "(10：00--次日10：00)</strong></td>").AppendLine("</tr>");
                    }
                    str = ((num2 % 2) == 0) ? "form_tr_2" : "form_tr";
                    int num3 = _Convert.StrToInt(row["LetBall"].ToString(), 0);
                    int num4 = _Convert.StrToInt(row["IsDue"].ToString(), 0);
                    str2 = (num3 == 0) ? "hui12" : ((num3 > 0) ? "red12" : "green12");
                    if (num4 == 0)
                    {
                        builder.AppendLine("<tr style=\"display:;\" id=\"tr_vs_" + row["NO"].ToString() + "\" index=\"" + num.ToString() + "\" isdisable=\"0\" teamname=\"" + row["LeagueTypeName"].ToString() + "\" class=\"" + str + "\" onmouseout=\"this.className='" + str + "'\" onmouseover=\"this.className='form_tr_3'\">").AppendLine("<td height=\"25\" id=\"index_" + num.ToString() + "\" index=\"" + row["NO"].ToString() + "\"><input type=\"checkbox\" checked=\"checked\" onclick=\"sg_vote.cancelSelect(" + num.ToString() + ", this)\" />" + row["NO"].ToString() + "</td>").AppendLine("<td bgcolor=\"" + row["MarkersColor"].ToString() + "\" class=\"bai12_2\"><a href=\"#\" target=\"_blank\">" + row["LeagueTypeName"].ToString() + "</a></td>").AppendLine("<td alt=\"开赛日期：" + time3.ToString("yyyy-MM-dd HH:mm") + "\">" + time3.ToString("HH:mm") + "</td>").AppendLine("<td tradeendtime=\"" + time4.ToString("yyyy-MM-dd HH:mm") + "\" zhggendtime=\"" + time4.ToString("yyyy-MM-dd HH:mm") + "\">" + time4.ToString("HH:mm") + "</td>").AppendLine("<td class=\"blue12_line\"><a href=\"#\" target=\"_blank\">" + row["HostTeam"].ToString() + "</a></td>").AppendLine("<td class=\"" + str2 + "\">" + row["LetBall"].ToString() + "</td>").AppendLine("<td class=\"blue12_line\"><a href=\"#\" target=\"_blank\">" + row["QuestTeam"].ToString() + "</a></td>").AppendLine("<td><span class=\"red12\">&nbsp;" + row["Result"].ToString() + "&nbsp;</span></td>").AppendLine("<td>" + row["EuropeSSP"].ToString() + "</td>").AppendLine("<td>" + row["EuropePSP"].ToString() + "</td>").AppendLine("<td>" + row["EuropeFSP"].ToString() + "</td>").AppendLine("<td align=\"left\"><input id=\"ck_" + num.ToString() + "_0\" type=\"checkbox\" /><span>" + row["SPFSSP"].ToString().Replace("--", "") + "</span></td>").AppendLine("<td align=\"left\"><input id=\"ck_" + num.ToString() + "_1\" type=\"checkbox\" /><span>" + row["SPFPSP"].ToString().Replace("--", "") + "</span></td>").AppendLine(" <td align=\"left\"><input id=\"ck_" + num.ToString() + "_2\" type=\"checkbox\" /><span>" + row["SPFFSP"].ToString().Replace("--", "") + "</span></td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "\" onclick=\"sg_vote.selectAll(" + num.ToString() + ", this.checked);\" type=\"checkbox\" /></td></tr>");
                        if (num3 == 0)
                        {
                            frqCount++;
                        }
                        else
                        {
                            rqCount++;
                        }
                        num++;
                    }
                    else
                    {
                        builder.AppendLine("<tr style=\"display:none;\" id=\"tr_vs_" + row["NO"].ToString() + "\" index=\"0\" isdisable=\"1\" teamname=\"" + row["LeagueTypeName"].ToString() + "\" class=\"" + str + "\" onmouseout=\"this.className='" + str + "'\" onmouseover=\"this.className='form_tr_3'\">").AppendLine("<td height=\"25\"><input type=\"checkbox\" disabled onclick=\"sg_vote.cancelSelect(0, this)\" />" + row["NO"].ToString() + "</td>").AppendLine("<td bgcolor=\"" + row["MarkersColor"].ToString() + "\" class=\"bai12_2\"><a href=\"#\" target=\"_blank\">" + row["LeagueTypeName"].ToString() + "</a></td>").AppendLine("<td alt=\"开赛日期：" + time3.ToString("yyyy-MM-dd HH:mm") + "\">" + time3.ToString("HH:mm") + "</td>").AppendLine("<td tradeendtime=\"" + time4.ToString("yyyy-MM-dd HH:mm") + "\" zhggendtime=\"" + time4.ToString("yyyy-MM-dd HH:mm") + "\">" + time4.ToString("HH:mm") + "</td>").AppendLine("<td class=\"blue12_line\"><a href=\"#\" target=\"_blank\">" + row["HostTeam"].ToString() + "</a></td>").AppendLine("<td class=\"" + str2 + "\">" + row["LetBall"].ToString() + "</td>").AppendLine("<td class=\"blue12_line\"><a href=\"#\" target=\"_blank\">" + row["QuestTeam"].ToString() + "</a></td>").AppendLine("<td><span class=\"red12\">&nbsp;" + row["Result"].ToString() + "&nbsp;</span></td>").AppendLine("<td>" + row["EuropeSSP"].ToString() + "</td>").AppendLine("<td>" + row["EuropePSP"].ToString() + "</td>").AppendLine("<td>" + row["EuropeFSP"].ToString() + "</td>");
                        int num5 = _Convert.StrToInt(row["SPFResult"].ToString(), -1);
                        for (int i = 1; i <= 3; i++)
                        {
                            if ((((i == 1) && (num5 == 3)) || ((i == 2) && (num5 == 1))) || ((i == 3) && (num5 == 0)))
                            {
                                builder.AppendLine("<td align=\"left\"><input type=\"checkbox\" disabled />" + row["SPF_SP"].ToString() + "</td>");
                            }
                            else
                            {
                                builder.AppendLine("<td align=\"left\"><input type=\"checkbox\" disabled /> -- </td>");
                            }
                        }
                        builder.AppendLine("<td><input type=\"checkbox\" disabled /></td></tr>");
                        if (num3 == 0)
                        {
                            jzfrqCount++;
                        }
                        else
                        {
                            jzrqCount++;
                        }
                        jzCount++;
                    }
                    num2++;
                }
            }
            catch (Exception exception)
            {
                new Log("TWZT").Write(base.GetType() + exception.Message);
                strHTML = "";
            }
            strHTML = builder.ToString();
            this.noMatch.Value = num.ToString();
        }
    }

    protected void ddlIssues_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.bindMatchs();
    }

    private void GetIsusesInfo()
    {
        Shove._Web.Cache.ClearCache("DataCache_IsusesInfo45");
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("DataCache_IsusesInfo45");
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT TOP 10 ID, Name FROM dbo.T_Isuses WHERE LotteryID=45 ORDER BY EndTime DESC");
            cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据读取错误，请重试", base.GetType().BaseType.FullName);
                return;
            }
            if (cacheAsDataTable != null)
            {
                Shove._Web.Cache.SetCache("DataCache_IsusesInfo45", cacheAsDataTable, 0x1770);
            }
        }
        this.ddlIssues.DataTextField = "Name";
        this.ddlIssues.DataValueField = "Id";
        this.ddlIssues.DataSource = cacheAsDataTable;
        this.ddlIssues.DataBind();
        this.bindMatchs();
    }

    private DataTable getMatchs(string IssueName)
    {
        Shove._Web.Cache.ClearCache("DataCache_Matchs_45_" + IssueName);
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("DataCache_Matchs_45_" + IssueName);
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
        {
            int returnValue = 0;
            string returnDescription = "";
            DataSet ds = null;
            Procedures.P_GetZCDCSPFMessage(ref ds, IssueName, ref returnValue, ref returnDescription);
            if (ds == null)
            {
                PF.GoError(4, "数据库繁忙，请重试(128)", base.GetType().BaseType.FullName);
                return null;
            }
            if (returnValue < 0)
            {
                JavaScript.Alert(this.Page, returnDescription);
                return null;
            }
            if (ds.Tables.Count < 1)
            {
                PF.GoError(4, "数据库繁忙，请重试(142)", base.GetType().BaseType.FullName);
                return null;
            }
            cacheAsDataTable = ds.Tables[0];
            if (cacheAsDataTable != null)
            {
                Shove._Web.Cache.SetCache("DataCache_Matchs_45_" + IssueName, cacheAsDataTable, 0x708);
            }
        }
        return cacheAsDataTable;
    }

    private void GetMatchsByIssueName(string IssueName)
    {
        DataTable dt = this.getMatchs(IssueName);
        int jzCount = 0;
        int rqCount = 0;
        int frqCount = 0;
        int jzrqCount = 0;
        int jzfrqCount = 0;
        string strHTML = "";
        this.createHTML(dt, ref strHTML, ref jzCount, ref rqCount, ref frqCount, ref jzrqCount, ref jzfrqCount);
        this.jzrq_changci.Value = jzrqCount.ToString();
        this.jzfrq_changci.Value = jzfrqCount.ToString();
        this.jz_changci.Value = jzCount.ToString();
        this.rq_changci.Value = rqCount.ToString();
        this.frq_changci.Value = frqCount.ToString();
        this.MatchList = strHTML;
    }

    private string getWeekDayName(DayOfWeek weekday)
    {
        switch (weekday)
        {
            case DayOfWeek.Sunday:
                return "星期日";

            case DayOfWeek.Monday:
                return "星期一";

            case DayOfWeek.Tuesday:
                return "星期二";

            case DayOfWeek.Wednesday:
                return "星期三";

            case DayOfWeek.Thursday:
                return "星期四";

            case DayOfWeek.Friday:
                return "星期五";

            case DayOfWeek.Saturday:
                return "星期六";
        }
        return "";
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isRequestLogin = false;
        base.isAtFramePageLogin = false;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.GetIsusesInfo();
        }
    }
}

