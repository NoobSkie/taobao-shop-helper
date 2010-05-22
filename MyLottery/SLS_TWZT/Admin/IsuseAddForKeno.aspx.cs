using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_IsuseAddForKeno : AdminPageBase, IRequiresSessionState
{

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DateTime time;
        try
        {
            time = DateTime.Parse(this.tbDate.Text);
        }
        catch
        {
            JavaScript.Alert(this.Page, "开始日期输入错误。");
            return;
        }
        int num = _Convert.StrToInt(this.tbDays.Text, 0);
        if (num >= 1)
        {
            if (num > 10)
            {
                JavaScript.Alert(this.Page, "高频彩种一次最多只能增加10天。");
            }
            else
            {
                int lotteryID = int.Parse(this.tbLotteryID.Text);
                if (lotteryID == 0x1c)
                {
                    string str = Functions.F_GetLotteryIntervalType(lotteryID);
                    int num3 = int.Parse(str.Substring(1, str.IndexOf(";") - 1));
                    string str2 = str.Substring(str.IndexOf(";") + 1, 8);
                    int.Parse(str.Substring(str.LastIndexOf(";") + 1));
                    for (int i = 0; i < num; i++)
                    {
                        DataTable table;
                        string str3 = time.Date.ToShortDateString();
                        table = table = new Tables.T_Isuses().Open("[ID]", "StartTime between '" + str3 + " 02:00:00' and '" + str3 + " 23:59:59' and LotteryID = " + Utility.FilteSqlInfusion(this.tbLotteryID.Text), "");
                        if (table == null)
                        {
                            PF.GoError(4, "数据库繁忙，请重试", "Admin_IsuseAddForKeno");
                            return;
                        }
                        if (table.Rows.Count > 0)
                        {
                            time = time.AddDays(1.0);
                        }
                        else
                        {
                            DateTime startTime = DateTime.Parse(time.Date.ToShortDateString() + " 0:0:0");
                            DateTime endTime = startTime.AddMinutes(5.0);
                            string name = time.Year.ToString() + time.Month.ToString().PadLeft(2, '0') + time.Day.ToString().PadLeft(2, '0') + "-001";
                            long isuseID = 0L;
                            string returnDescription = "";
                            if (Procedures.P_IsuseAdd(lotteryID, name, startTime, endTime, "", ref isuseID, ref returnDescription) < 0)
                            {
                                PF.GoError(4, "数据库繁忙，请重试", "Admin_IsuseAddForKeno");
                                return;
                            }
                            if (isuseID < 0L)
                            {
                                PF.GoError(1, returnDescription, "Admin_IsuseAddForKeno");
                                return;
                            }
                            for (int j = 2; j <= 0x17; j++)
                            {
                                startTime = endTime;
                                endTime = endTime.AddMinutes(5.0);
                                name = name = time.Year.ToString() + time.Month.ToString().PadLeft(2, '0') + time.Day.ToString().PadLeft(2, '0') + "-" + j.ToString().PadLeft(3, '0');
                                if (Procedures.P_IsuseAdd(lotteryID, name, startTime, endTime, "", ref isuseID, ref returnDescription) < 0)
                                {
                                    break;
                                }
                            }
                            startTime = DateTime.Parse(time.Date.ToShortDateString() + " 01:55:00");
                            endTime = DateTime.Parse(time.Date.ToShortDateString() + " " + str2);
                            name = time.Year.ToString() + time.Month.ToString().PadLeft(2, '0') + time.Day.ToString().PadLeft(2, '0') + "-024";
                            if (Procedures.P_IsuseAdd(lotteryID, name, startTime, endTime, "", ref isuseID, ref returnDescription) < 0)
                            {
                                PF.GoError(4, "数据库繁忙，请重试", "Admin_IsuseAddForKeno");
                                return;
                            }
                            for (int k = 0x19; k <= 0x60; k++)
                            {
                                startTime = endTime;
                                endTime = endTime.AddMinutes((double)num3);
                                name = name = time.Year.ToString() + time.Month.ToString().PadLeft(2, '0') + time.Day.ToString().PadLeft(2, '0') + "-" + k.ToString().PadLeft(3, '0');
                                if (Procedures.P_IsuseAdd(lotteryID, name, startTime, endTime, "", ref isuseID, ref returnDescription) < 0)
                                {
                                    break;
                                }
                            }
                            if (lotteryID == 0x1c)
                            {
                                for (int m = 0x61; m <= 120; m++)
                                {
                                    startTime = endTime;
                                    endTime = endTime.AddMinutes(5.0);
                                    name = this.ConvertIsuseName(lotteryID, time.Year.ToString() + time.Month.ToString().PadLeft(2, '0') + time.Day.ToString().PadLeft(2, '0') + "-" + m.ToString().PadLeft(3, '0'));
                                    if (Procedures.P_IsuseAdd(lotteryID, name, startTime, endTime, "", ref isuseID, ref returnDescription) < 0)
                                    {
                                        break;
                                    }
                                }
                            }
                            time = time.AddDays(1.0);
                        }
                    }
                }
                else
                {
                    string str6 = Functions.F_GetLotteryIntervalType(lotteryID);
                    int num25 = int.Parse(str6.Substring(1, str6.IndexOf(";") - 1));
                    string str7 = str6.Substring(str6.IndexOf(";") + 1, 8);
                    int num26 = int.Parse(str6.Substring(str6.LastIndexOf(";") + 1));
                    for (int n = 0; n < num; n++)
                    {
                        string str8 = time.Date.ToShortDateString();
                        DataTable table2 = new Tables.T_Isuses().Open("[ID]", "StartTime between '" + str8 + " 0:0:0' and '" + str8 + " 23:59:59' and LotteryID = " + Utility.FilteSqlInfusion(this.tbLotteryID.Text), "");
                        if (table2 == null)
                        {
                            PF.GoError(4, "数据库繁忙，请重试", "Admin_IsuseAddForKeno");
                            return;
                        }
                        if (table2.Rows.Count > 0)
                        {
                            time = time.AddDays(1.0);
                        }
                        else
                        {
                            DateTime time10 = DateTime.Parse(time.Date.ToShortDateString() + " 0:0:0");
                            DateTime time12 = DateTime.Parse(time.Date.ToShortDateString() + " " + str7);
                            string str9 = this.ConvertIsuseName(lotteryID, time.Year.ToString() + time.Month.ToString().PadLeft(2, '0') + time.Day.ToString().PadLeft(2, '0') + "01");
                            long num29 = -1L;
                            string str10 = "";
                            if (Procedures.P_IsuseAdd(lotteryID, str9, time10, time12, "", ref num29, ref str10) < 0)
                            {
                                PF.GoError(4, "数据库繁忙，请重试", "Admin_IsuseAddForKeno");
                                return;
                            }
                            if (num29 < 0L)
                            {
                                PF.GoError(1, str10, "Admin_IsuseAddForKeno");
                                return;
                            }
                            for (int num31 = 2; num31 <= num26; num31++)
                            {
                                time10 = time12;
                                time12 = time12.AddMinutes((double)num25);
                                str9 = this.ConvertIsuseName(lotteryID, time.Year.ToString() + time.Month.ToString().PadLeft(2, '0') + time.Day.ToString().PadLeft(2, '0') + num31.ToString().PadLeft(2, '0'));
                                if (Procedures.P_IsuseAdd(lotteryID, str9, time10, time12, "", ref num29, ref str10) < 0)
                                {
                                    break;
                                }
                            }
                            time = time.AddDays(1.0);
                        }
                    }
                }
                base.Response.Redirect("Isuse.aspx?LotteryID=" + this.tbLotteryID.Text, true);
            }
        }
        else
        {
            JavaScript.Alert(this.Page, "请输入要连续增加的天数。");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("Isuse.aspx?LotteryID=" + this.tbLotteryID.Text, true);
    }

    private string ConvertIsuseName(int LotteryID, string IsuseName)
    {
        switch (LotteryID)
        {
            case 0x30:
                return PF.ConvertIsuseName_HBKLPK(IsuseName);

            case 0x31:
                return PF.ConvertIsuseName_SDKLPK(IsuseName);

            case 50:
                return PF.ConvertIsuseName_HeBKLPK(IsuseName);

            case 0x33:
                return PF.ConvertIsuseName_AHKLPK(IsuseName);

            case 0x34:
                return PF.ConvertIsuseName_HLJKLPK(IsuseName);

            case 0x35:
                return PF.ConvertIsuseName_LLKLPK(IsuseName);

            case 0x36:
                return PF.ConvertIsuseName_SXKLPK(IsuseName);

            case 0x37:
                return PF.ConvertIsuseName_ZJKLPK(IsuseName);

            case 0x38:
                return PF.ConvertIsuseName_SCKLPK(IsuseName);

            case 0x39:
                return PF.ConvertIsuseName_ShXKLPK(IsuseName);

            case 0x3a:
            case 0x3b:
            case 60:
            case 0x3f:
            case 0x40:
            case 0x41:
            case 0x42:
            case 0x43:
            case 0x44:
            case 0x45:
                return IsuseName;

            case 0x3d:
                return PF.ConvertIsuseName_JxSSC(IsuseName);

            case 0x3e:
                return PF.ConvertIsuseName_SYYDJ(IsuseName);

            case 70:
                return PF.ConvertIsuseName_SYYDJ(IsuseName);
        }
        return IsuseName;
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "LotteryIsuseScheme" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            int lotteryID = _Convert.StrToInt(Utility.GetRequest("LotteryID"), -1);
            if (!PF.ValidLotteryID(base._Site, lotteryID))
            {
                PF.GoError(1, "参数错误", "Admin_IsuseAddForKeno");
            }
            else
            {
                this.tbLotteryID.Text = lotteryID.ToString();
                if (!Functions.F_GetLotteryIntervalType(lotteryID).StartsWith("分"))
                {
                    base.Response.Redirect("IsuseAdd.aspx?LotteryID=" + lotteryID.ToString(), true);
                }
                else
                {
                    object obj2 = MSSQL.ExecuteScalar("SELECT ISNULL(MAX(EndTime), DATEADD([day], - 1, GETDATE())) AS LastDate from T_Isuses where LotteryID = " + lotteryID.ToString(), new MSSQL.Parameter[0]);
                    if (obj2 == null)
                    {
                        PF.GoError(4, "数据库繁忙，请重试", "Admin_IsuseAddForKeno");
                    }
                    else
                    {
                        DateTime time2 = DateTime.Parse(obj2.ToString()).AddDays(1.0);
                        this.tbDate.Text = time2.Year.ToString() + "-" + time2.Month.ToString() + "-" + time2.Day.ToString();
                    }
                }
            }
        }
    }


}

