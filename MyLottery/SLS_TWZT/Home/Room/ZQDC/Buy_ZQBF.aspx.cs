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

public partial class Home_Room_ZCDC_Buy_ZQBF : RoomPageBase, IRequiresSessionState
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

    private void createHTML(DataTable dt, ref string strHTML, ref int jzCount)
    {
        jzCount = 0;
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
                        builder.AppendLine("<tr>").AppendLine("<td height=\"24\" colspan=\"17\" align=\"center\" bgcolor=\"#E6E6E6\" class=\"black12\"> ").AppendLine(now.ToString("yyyy-MM-dd") + " " + this.getWeekDayName(now.DayOfWeek) + "(10：00--次日10：00) </td>").AppendLine("</tr>");
                    }
                    else if (time3 > time2)
                    {
                        now = now.AddDays(1.0);
                        time2 = time2.AddDays(1.0);
                        builder.AppendLine("<tr>").AppendLine("<td height=\"22\" colspan=\"17\" align=\"center\" bgcolor=\"#E6E6E6\" class=\"black12\"> ").AppendLine(now.ToString("yyyy-MM-dd") + " " + this.getWeekDayName(now.DayOfWeek) + "(10：00--次日10：00) </td>").AppendLine("</tr>");
                    }
                    str = ((num2 % 2) == 0) ? "form_tr_2" : "form_tr";
                    int num3 = _Convert.StrToInt(row["LetBall"].ToString(), 0);
                    if (_Convert.StrToInt(row["IsDue"].ToString(), 0) == 0)
                    {
                        builder.AppendLine("<tr style=\"display:;\" isdisable=\"0\" class=\"" + str + "\" onmouseout=\"this.className='" + str + "'\" onmouseover=\"this.className='form_tr_3'\">").AppendLine("<td height=\"25\" id=\"index_" + num.ToString() + "\" index=\"" + row["NO"].ToString() + "\"><input type=\"checkbox\" checked=\"checked\"  onclick=\"sg_vote.cancelSelect(" + num.ToString() + ", this)\"/>" + row["NO"].ToString() + "</td>").AppendLine("<td bgcolor=\"" + row["MarkersColor"].ToString() + "\" class=\"bai12_2\"><a href=\"#\" target=\"_blank\">" + row["LeagueTypeName"].ToString() + "</a></td>").AppendLine("<td>" + time3.ToString("HH:mm") + "</td>").AppendLine("<td tradeendtime=\"" + time4.ToString("yyyy-MM-dd HH:mm") + "\" zhggendtime=\"" + time4.ToString("yyyy-MM-dd HH:mm") + "\">" + time4.ToString("HH:mm") + "</td>").AppendLine("<td class=\"blue12_line\"><a href=\"#\" target=\"_blank\">" + row["HostTeam"].ToString() + "</a></td>").AppendLine("<td class=\"blue12_line\"><a href=\"#\" target=\"_blank\">" + row["QuestTeam"].ToString() + "</a></td>").AppendLine("<td><span class=\"red12\">&nbsp;" + row["Result"].ToString() + "</span></td>").AppendLine("<td>" + row["EuropeSSP"].ToString() + "</td>").AppendLine("<td>" + row["EuropePSP"].ToString() + "</td>").AppendLine("<td>" + row["EuropeFSP"].ToString() + "</td>").AppendLine("<td><img id=\"ttr_img_" + num2.ToString() + "\" src=\"images/btn_sp_show.gif\" width=\"81\" height=\"17\" onclick=\"sg_vote.hideSP('ttr_" + num2.ToString() + "', this)\" /></td>").AppendLine("</tr>");
                        builder.AppendLine("<tr style=\"display:none;\" id=\"ttr_" + num2.ToString() + "\"><td colspan=\"12\">").AppendLine("<table cellspacing=\"1\" class=\"bf_sp_tb\">").AppendLine("<tr class=\"bf_sp_tr1\">").AppendLine("<td width=\"45\">胜</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_0\" type=\"checkbox\" /> 1:0<br> (" + row["ZQBFS1Then0SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_1\" type=\"checkbox\" /> 2:0<br> (" + row["ZQBFS2Then0SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_2\" type=\"checkbox\" /> 2:1<br> (" + row["ZQBFS2Then1SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_3\" type=\"checkbox\" /> 3:0<br> (" + row["ZQBFS3Then0SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_4\" type=\"checkbox\" /> 3:1<br> (" + row["ZQBFS3Then1SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_5\" type=\"checkbox\" /> 3:2<br> (" + row["ZQBFS3Then2SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_6\" type=\"checkbox\" /> 4:0<br> (" + row["ZQBFS4Then0SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_7\" type=\"checkbox\" /> 4:1<br> (" + row["ZQBFS4Then1SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_8\" type=\"checkbox\" /> 4:2<br> (" + row["ZQBFS4Then2SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_9\" type=\"checkbox\" /> 胜其它<br> (" + row["ZQBFSSOtherSP"].ToString() + ")</td>").AppendLine("<td><input id=\"ALL_" + num.ToString() + "_0\" onclick=\"sg_vote.selectAll(" + num.ToString() + ", this.checked,0);\" type=\"checkbox\" />包</td>").AppendLine("</tr>").AppendLine("<tr class=\"bf_sp_tr2\">").AppendLine("<td>平</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_10\" type=\"checkbox\" /> 0:0<br> (" + row["ZQBFP0Then0SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_11\" type=\"checkbox\" /> 1:1<br> (" + row["ZQBFP1Then1SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_12\" type=\"checkbox\" /> 2:2<br> (" + row["ZQBFP2Then2SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_13\" type=\"checkbox\" /> 3:3<br> (" + row["ZQBFP3Then3SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_14\" type=\"checkbox\" /> 平其它<br> (" + row["ZQBFPPOtherSP"].ToString() + ")</td>").AppendLine("<td colspan=\"5\"></td>").AppendLine("<td><input id=\"ALL_" + num.ToString() + "_1\" onclick=\"sg_vote.selectAll(" + num.ToString() + ", this.checked,1);\" type=\"checkbox\" />包</td>").AppendLine("</tr>").AppendLine("<tr class=\"bf_sp_tr3\">").AppendLine("<td>负</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_15\" type=\"checkbox\" /> 0:1<br> (" + row["ZQBFF0Then1SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_16\" type=\"checkbox\" /> 0:2<br> (" + row["ZQBFF0Then2SP"].ToString() + ")</td>").AppendLine("<td> <input id=\"ck_" + num.ToString() + "_17\" type=\"checkbox\" /> 1:2<br> (" + row["ZQBFF1Then2SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_18\" type=\"checkbox\" /> 0:3<br> (" + row["ZQBFF0Then3SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_19\" type=\"checkbox\" /> 1:3<br> (" + row["ZQBFF1Then3SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_20\" type=\"checkbox\" /> 2:3<br> (" + row["ZQBFF2Then3SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_21\" type=\"checkbox\" /> 0:4<br> (" + row["ZQBFF0Then4SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_22\" type=\"checkbox\" /> 1:4<br> (" + row["ZQBFF1Then4SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_23\" type=\"checkbox\" /> 2:4<br> (" + row["ZQBFF2Then4SP"].ToString() + ")</td>").AppendLine("<td><input id=\"ck_" + num.ToString() + "_24\" type=\"checkbox\" /> 负其它<br> (" + row["ZQBFFFOtherSP"].ToString() + ")</td>").AppendLine("<td><input id=\"ALL_" + num.ToString() + "_2\" onclick=\"sg_vote.selectAll(" + num.ToString() + ", this.checked,2);\" type=\"checkbox\" />包</td>").AppendLine("</tr>").AppendLine("</table>").AppendLine("</td></tr>");
                        num++;
                    }
                    else
                    {
                        builder.AppendLine("<tr style=\"display:none;\" isdisable=\"1\" class=\"" + str + "\" onmouseout=\"this.className='" + str + "'\" onmouseover=\"this.className='form_tr_3'\">").AppendLine("<td><input type=\"checkbox\" disabled />" + row["NO"].ToString() + "</td>").AppendLine("<td bgcolor=\"" + row["MarkersColor"].ToString() + "\" class=\"bai12_2\"><a href=\"#\" target=\"_blank\">" + row["LeagueTypeName"].ToString() + "</a></td>").AppendLine("<td>" + time3.ToString("HH:mm") + "</td>").AppendLine("<td tradeendtime=\"" + time4.ToString("yyyy-MM-dd HH:mm") + "\" zhggendtime=\"" + time4.ToString("yyyy-MM-dd HH:mm") + "\">" + time4.ToString("HH:mm") + "</td>").AppendLine("<td class=\"blue12_line\"><a href=\"#\" target=\"_blank\">" + row["HostTeam"].ToString() + "</a></td>").AppendLine("<td class=\"blue12_line\"><a href=\"#\" target=\"_blank\">" + row["QuestTeam"].ToString() + "</a></td>").AppendLine("<td><span class=\"red12\">&nbsp;" + row["Result"].ToString() + "</span></td>").AppendLine("<td>" + row["EuropeSSP"].ToString() + "</td>").AppendLine("<td>" + row["EuropePSP"].ToString() + "</td>").AppendLine("<td>" + row["EuropeFSP"].ToString() + "</td>").AppendLine("<td><img id=\"ttr_img_" + num2.ToString() + "\" src=\"images/btn_sp.gif\" width=\"81\" height=\"17\" onclick=\"sg_vote.hideSP('ttr_" + num2.ToString() + "', this,1)\" /></td>").AppendLine("</tr>");
                        int num5 = _Convert.StrToInt(row["ZQBFResult"].ToString(), -1);
                        string[] strArray38 = new string[] { 
                            "1:0", "2:0", "2:1", "3:0", "3:1", "3:2", "4:0", "4:1", "4:2", "胜其他", "0:0", "1:1", "2:2", "3:3", "平其他", "0:1", 
                            "0:2", "1:2", "0:3", "1:3", "2:3", "0:4", "1:4", "2:4", "负其他"
                         };
                        builder.AppendLine("<tr style=\"display:none;\" id=\"ttr_" + num2.ToString() + "\"><td colspan=\"12\"><div class=\"bf_sp_box\">").AppendLine("<table width=\"100%\" class=\"bf_sp_tb\" cellspacing=\"1\" cellpadding=\"2\"> ").AppendLine("<tr class=\"bf_sp_tr1\">").AppendLine("<td >胜</td>");
                        for (int i = 1; i <= 0x19; i++)
                        {
                            if (i == num5)
                            {
                                builder.AppendLine("<td><input type=\"checkbox\" disabled /> " + strArray38[i - 1] + "(" + row["ZQBF_SP"].ToString() + ")</td>");
                            }
                            else
                            {
                                builder.AppendLine("<td><input type=\"checkbox\" disabled />" + strArray38[i - 1] + "(--) </td>");
                            }
                            switch (i)
                            {
                                case 10:
                                    builder.AppendLine("<td><input type=\"checkbox\" disabled />包</td>").AppendLine("</tr>").AppendLine("<tr class=\"bf_sp_tr2\">").AppendLine("<td>平</td>");
                                    break;

                                case 15:
                                    builder.AppendLine("<td colspan=\"5\"></td>").AppendLine("<td><input type=\"checkbox\" disabled />包</td>").AppendLine("</tr>").AppendLine("<tr class=\"bf_sp_tr3\">").AppendLine("<td>负</td>");
                                    break;

                                case 0x19:
                                    builder.AppendLine("<td><input type=\"checkbox\" disabled />包</td>").AppendLine("</tr>").AppendLine("</table>").AppendLine("</div></td></tr>");
                                    break;
                            }
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
        string strHTML = "";
        this.createHTML(dt, ref strHTML, ref jzCount);
        this.jz_changci.Value = jzCount.ToString();
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

