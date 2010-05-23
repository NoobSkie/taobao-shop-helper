using SLS.Site.App_Code.DAL;
using Shove;
using Shove._Security;
using Shove._System;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using SLS;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace SLS.Site.App_Code
{
    public class PF
    {
        public static string AlipayAccountRegisterPid = WebConfig.GetAppSettingsString("AlipayAccountRegisterPid");
        public static double AlipayRegDonateMoney = WebConfig.GetAppSettingsDouble("AlipayRegDonateMoney", 0.0);
        public static string CenterMD5Key = WebConfig.GetAppSettingsString("CenterMD5Key");
        public static string DesKey = WebConfig.GetAppSettingsString("DesKey");
        public const int SchemeMaxBettingMoney = 0x989680;
        public const int SystemStartYear = 0x7d8;

        public static string BuildIsuseAdditionasXmlFor1Team(int Count, params string[] str)
        {
            string str2 = "<Teams>";
            for (int i = 0; i < Count; i++)
            {
                string str3 = str2;
                string[] strArray = new string[] { str3, "<Team No=\"", (i + 1).ToString(), "\" Team=\"", str[i * 2], "\" Time=\"", str[(i * 2) + 1], "\"/>" };
                str2 = string.Concat(strArray);
            }
            return (str2 + "</Teams>");
        }

        public static string BuildIsuseAdditionasXmlFor2Team(int Count, params string[] str)
        {
            string str2 = "<Teams>";
            for (int i = 0; i < Count; i++)
            {
                string str3 = str2;
                string[] strArray = new string[] { str3, "<Team No=\"", (i + 1).ToString(), "\" HostTeam=\"", str[i * 3], "\" QuestTeam=\"", str[(i * 3) + 1], "\" Time=\"", str[(i * 3) + 2], "\"/>" };
                str2 = string.Concat(strArray);
            }
            return (str2 + "</Teams>");
        }

        public static string BuildIsuseAdditionasXmlForBJKL8(params string[] str)
        {
            string str2 = "<ChaseDetail>";
            for (int i = 0; i < (str.Length / 9); i++)
            {
                string str3 = str2;
                str2 = str3 + "<Isuse IsuseID=\"" + str[i * 9] + "\" PlayTypeID = \"" + str[(i * 9) + 1] + "\" LotteryNumber = \"" + str[(i * 9) + 2] + "\" Multiple = \"" + str[(i * 9) + 3] + "\" Money = \"" + str[(i * 9) + 4] + "\" SecrecyLevel =\"" + str[(i * 9) + 5] + "\" Share=\"" + str[(i * 9) + 6] + "\" BuyedShare=\"" + str[(i * 9) + 7] + "\" AssureShare=\"" + str[(i * 9) + 8] + "\"/>";
            }
            return (str2 = str2 + "</ChaseDetail>");
        }

        public static string BuildIsuseAdditionasXmlForChase(params string[] str)
        {
            string str2 = "<ChaseDetail>";
            for (int i = 0; i < (str.Length / 6); i++)
            {
                string str3 = str2;
                str2 = str3 + "<Isuse IsuseID=\"" + str[i * 6] + "\" PlayTypeID = \"" + str[(i * 6) + 1] + "\" LotteryNumber = \"" + str[(i * 6) + 2] + "\" Multiple = \"" + str[(i * 6) + 3] + "\" Money = \"" + str[(i * 6) + 4] + "\" SecrecyLevel =\"" + str[(i * 6) + 5] + "\" Share=\"1\" BuyedShare=\"1\" AssureShare=\"0\"/>";
            }
            return (str2 = str2 + "</ChaseDetail>");
        }

        public static string BuildIsuseAdditionasXmlForZCDC(params string[] str)
        {
            string str2 = "<Teams>";
            for (int i = 0; i < (str.Length / 5); i++)
            {
                string str3 = str2;
                string[] strArray = new string[] { str3, "<Team LeagueTypeID=\"", str[i * 5], "\" No=\"", (i + 1).ToString(), "\" HostTeam=\"", str[(i * 5) + 1], "\" QuestTeam=\"", str[(i * 5) + 2], "\" LetBall=\"", str[(i * 5) + 3], "\" Time=\"", str[(i * 5) + 4], "\"/>" };
                str2 = string.Concat(strArray);
            }
            return (str2 + "</Teams>");
        }

        public static double CalculateDistillFormalitiesFees(int DistillType, double DistillMoney, string BankDetailedName)
        {
            double num = 0.0;
            if (DistillType == 1)
            {
                if (DistillMoney < 10000.0)
                {
                    return 1.0;
                }
                return 10.0;
            }
            if (DistillType == 2)
            {
                if (BankDetailedName.Replace("深圳发展", "").IndexOf("深圳") >= 0)
                {
                    if ((((BankDetailedName.IndexOf("工商银行") >= 0) || (BankDetailedName.IndexOf("招商银行") >= 0)) || ((BankDetailedName.IndexOf("建设银行") >= 0) || (BankDetailedName.IndexOf("工行") >= 0))) || ((BankDetailedName.IndexOf("招行") >= 0) || (BankDetailedName.IndexOf("建行") >= 0)))
                    {
                        return 0.0;
                    }
                    return 2.0;
                }
                if ((BankDetailedName.IndexOf("工商银行") >= 0) || (BankDetailedName.IndexOf("工行") >= 0))
                {
                    num = DistillMoney * 0.009;
                    if (num < 1.8)
                    {
                        return 1.8;
                    }
                    if (num > 45.0)
                    {
                        num = 45.0;
                    }
                    return num;
                }
                if ((BankDetailedName.IndexOf("招商银行") >= 0) || (BankDetailedName.IndexOf("招行") >= 0))
                {
                    num = DistillMoney * 0.002;
                    if (num < 5.0)
                    {
                        return 5.0;
                    }
                    if (num > 50.0)
                    {
                        num = 50.0;
                    }
                    return num;
                }
                if ((BankDetailedName.IndexOf("建设银行") >= 0) || (BankDetailedName.IndexOf("建行") >= 0))
                {
                    num = DistillMoney * 0.0025;
                    if (num < 2.0)
                    {
                        return 2.0;
                    }
                    if (num > 25.0)
                    {
                        num = 25.0;
                    }
                    return num;
                }
                num = DistillMoney * 0.01;
                if (num < 10.0)
                {
                    return 10.0;
                }
                if (num > 50.0)
                {
                    num = 50.0;
                }
            }
            return num;
        }

        public static bool CheckUserName(string userName)
        {
            Regex regex = new Regex(@"^[\u4e00-\u9fa5a-zA-Z0-9_]{1}[\w]{1,29}$|^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.Match(userName).Success;
        }

        public static string ConvertDateTimeMMDDHHMM(string strDateTime)
        {
            DateTime time;
            try
            {
                time = DateTime.Parse(strDateTime);
            }
            catch
            {
                return "";
            }
            return (time.Month.ToString() + "-" + time.Day.ToString() + " " + time.Hour.ToString().PadLeft(2, '0') + ":" + time.Minute.ToString().PadLeft(2, '0'));
        }

        public static string ConvertIsuseName_AHKLPK(string IsuseName)
        {
            TimeSpan span;
            if (IsuseName.Length != 10)
            {
                return IsuseName;
            }
            string str = IsuseName.Substring(0, 4) + "-" + IsuseName.Substring(4, 2) + "-" + IsuseName.Substring(6, 2);
            try
            {
                span = (TimeSpan)(_Convert.StrToDateTime(str, "0000-00-00") - _Convert.StrToDateTime("2008-2-20", "0000-00-00"));
            }
            catch
            {
                return IsuseName;
            }
            double days = 0.0;
            double num3 = 0.0;
            days = span.Days;
            num3 = _Convert.StrToInt(IsuseName.Substring(IsuseName.Length - 2), 0);
            double num4 = ((8002065.0 + (days * 48.0)) + num3) - 1.0;
            return num4.ToString();
        }

        public static string ConvertIsuseName_HBKLPK(string IsuseName)
        {
            TimeSpan span;
            if (IsuseName.Length != 10)
            {
                return IsuseName;
            }
            string str = IsuseName.Substring(0, 4) + "-" + IsuseName.Substring(4, 2) + "-" + IsuseName.Substring(6, 2);
            try
            {
                span = (TimeSpan)(_Convert.StrToDateTime(str, "0000-00-00") - _Convert.StrToDateTime("2008-2-18", "0000-00-00"));
            }
            catch
            {
                return IsuseName;
            }
            double days = 0.0;
            double num3 = 0.0;
            days = span.Days;
            num3 = _Convert.StrToInt(IsuseName.Substring(IsuseName.Length - 2), 0);
            double num4 = ((8002010.0 + (days * 49.0)) + num3) - 1.0;
            return num4.ToString();
        }

        public static string ConvertIsuseName_HeBKLPK(string IsuseName)
        {
            TimeSpan span;
            if (IsuseName.Length != 10)
            {
                return IsuseName;
            }
            string str = IsuseName.Substring(0, 4) + "-" + IsuseName.Substring(4, 2) + "-" + IsuseName.Substring(6, 2);
            try
            {
                span = (TimeSpan)(_Convert.StrToDateTime(str, "0000-00-00") - _Convert.StrToDateTime("2008-2-20", "0000-00-00"));
            }
            catch
            {
                return IsuseName;
            }
            double days = 0.0;
            double num3 = 0.0;
            days = span.Days;
            num3 = _Convert.StrToInt(IsuseName.Substring(IsuseName.Length - 2), 0);
            double num4 = ((8002280.0 + (days * 53.0)) + num3) - 1.0;
            return num4.ToString();
        }

        public static string ConvertIsuseName_HLJKLPK(string IsuseName)
        {
            TimeSpan span;
            if (IsuseName.Length != 10)
            {
                return IsuseName;
            }
            string str = IsuseName.Substring(0, 4) + "-" + IsuseName.Substring(4, 2) + "-" + IsuseName.Substring(6, 2);
            try
            {
                span = (TimeSpan)(_Convert.StrToDateTime(str, "0000-00-00") - _Convert.StrToDateTime("2008-2-20", "0000-00-00"));
            }
            catch
            {
                return IsuseName;
            }
            double days = 0.0;
            double num3 = 0.0;
            days = span.Days;
            num3 = _Convert.StrToInt(IsuseName.Substring(IsuseName.Length - 2), 0);
            double num4 = ((8002280.0 + (days * 53.0)) + num3) - 1.0;
            return num4.ToString();
        }

        public static string ConvertIsuseName_JxSSC(string IsuseName)
        {
            if (IsuseName.Length != 10)
            {
                return IsuseName;
            }
            return IsuseName.Substring(4).Insert(4, "0");
        }

        public static string ConvertIsuseName_LLKLPK(string IsuseName)
        {
            TimeSpan span;
            if (IsuseName.Length != 10)
            {
                return IsuseName;
            }
            string str = IsuseName.Substring(0, 4) + "-" + IsuseName.Substring(4, 2) + "-" + IsuseName.Substring(6, 2);
            try
            {
                span = (TimeSpan)(_Convert.StrToDateTime(str, "0000-00-00") - _Convert.StrToDateTime("2008-2-20", "0000-00-00"));
            }
            catch
            {
                return IsuseName;
            }
            double days = 0.0;
            double num3 = 0.0;
            days = span.Days;
            num3 = _Convert.StrToInt(IsuseName.Substring(IsuseName.Length - 2), 0);
            double num4 = ((8002280.0 + (days * 53.0)) + num3) - 1.0;
            return num4.ToString();
        }

        public static string ConvertIsuseName_SCKLPK(string IsuseName)
        {
            TimeSpan span;
            if (IsuseName.Length != 10)
            {
                return IsuseName;
            }
            string str = IsuseName.Substring(0, 4) + "-" + IsuseName.Substring(4, 2) + "-" + IsuseName.Substring(6, 2);
            try
            {
                span = (TimeSpan)(_Convert.StrToDateTime(str, "0000-00-00") - _Convert.StrToDateTime("2008-2-20", "0000-00-00"));
            }
            catch
            {
                return IsuseName;
            }
            double days = 0.0;
            double num3 = 0.0;
            days = span.Days;
            num3 = _Convert.StrToInt(IsuseName.Substring(IsuseName.Length - 2), 0);
            double num4 = ((8002237.0 + (days * 52.0)) + num3) - 1.0;
            return num4.ToString();
        }

        public static string ConvertIsuseName_SDKLPK(string IsuseName)
        {
            TimeSpan span;
            if (IsuseName.Length != 10)
            {
                return IsuseName;
            }
            string str = IsuseName.Substring(0, 4) + "-" + IsuseName.Substring(4, 2) + "-" + IsuseName.Substring(6, 2);
            try
            {
                span = (TimeSpan)(_Convert.StrToDateTime(str, "0000-00-00") - _Convert.StrToDateTime("2008-2-20", "0000-00-00"));
            }
            catch
            {
                return IsuseName;
            }
            double days = 0.0;
            double num3 = 0.0;
            days = span.Days;
            num3 = _Convert.StrToInt(IsuseName.Substring(IsuseName.Length - 2), 0);
            double num4 = ((8002280.0 + (days * 53.0)) + num3) - 1.0;
            return num4.ToString();
        }

        public static string ConvertIsuseName_ShXKLPK(string IsuseName)
        {
            return IsuseName;
        }

        public static string ConvertIsuseName_SXKLPK(string IsuseName)
        {
            TimeSpan span;
            if (IsuseName.Length != 10)
            {
                return IsuseName;
            }
            string str = IsuseName.Substring(0, 4) + "-" + IsuseName.Substring(4, 2) + "-" + IsuseName.Substring(6, 2);
            try
            {
                span = (TimeSpan)(_Convert.StrToDateTime(str, "0000-00-00") - _Convert.StrToDateTime("2008-2-20", "0000-00-00"));
            }
            catch
            {
                return IsuseName;
            }
            double days = 0.0;
            double num3 = 0.0;
            days = span.Days;
            num3 = _Convert.StrToInt(IsuseName.Substring(IsuseName.Length - 2), 0);
            double num4 = ((8001936.0 + (days * 49.0)) + num3) - 1.0;
            return num4.ToString();
        }

        public static string ConvertIsuseName_SYYDJ(string IsuseName)
        {
            if (IsuseName.Length != 10)
            {
                return IsuseName;
            }
            return IsuseName.Substring(2);
        }

        public static string ConvertIsuseName_ZJKLPK(string IsuseName)
        {
            TimeSpan span;
            if (IsuseName.Length != 10)
            {
                return IsuseName;
            }
            string str = IsuseName.Substring(0, 4) + "-" + IsuseName.Substring(4, 2) + "-" + IsuseName.Substring(6, 2);
            try
            {
                span = (TimeSpan)(_Convert.StrToDateTime(str, "0000-00-00") - _Convert.StrToDateTime("2008-2-20", "0000-00-00"));
            }
            catch
            {
                return IsuseName;
            }
            double days = 0.0;
            double num3 = 0.0;
            days = span.Days;
            num3 = _Convert.StrToInt(IsuseName.Substring(IsuseName.Length - 2), 0);
            double num4 = ((8002237.0 + (days * 52.0)) + num3) - 1.0;
            return num4.ToString();
        }

        public static void DataGridBindData(DataGrid g, DataTable dt)
        {
            g.DataSource = dt;
            try
            {
                g.DataBind();
            }
            catch
            {
                g.CurrentPageIndex = 0;
                g.DataBind();
            }
        }

        public static void DataGridBindData(DataGrid g, DataTable dt, ShoveGridPager gPager)
        {
            g.DataSource = dt;
            try
            {
                g.DataBind();
            }
            catch
            {
                g.CurrentPageIndex = 0;
                gPager.PageIndex = 0;
                g.DataBind();
            }
            gPager.Visible = dt.Rows.Count > 0;
        }

        public static void DataGridBindData(DataGrid g, DataView dv, ShoveGridPager gPager)
        {
            g.DataSource = dv;
            try
            {
                g.DataBind();
            }
            catch
            {
                g.CurrentPageIndex = 0;
                gPager.PageIndex = 0;
                g.DataBind();
            }
            gPager.Visible = dv.Count > 0;
        }

        public static string EncryptPassword(string input)
        {
            if (WebConfig.GetAppSettingsBool("IsMD5", false))
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(input, "MD5");
            }
            return FormsAuthentication.HashPasswordForStoringInConfigFile(input + CenterMD5Key, "MD5");
        }

        public static string FilterNoRestrictionsLottery(string LotteryListRestrictions, string LotteryList)
        {
            if ((LotteryListRestrictions == "") || (LotteryList == ""))
            {
                return "";
            }
            LotteryListRestrictions = "," + LotteryListRestrictions + ",";
            string[] strArray = LotteryList.Split(new char[] { ',' });
            if ((strArray == null) || (strArray.Length < 1))
            {
                return "";
            }
            string str = "";
            foreach (string str2 in strArray)
            {
                if (LotteryListRestrictions.IndexOf("," + str2 + ",") >= 0)
                {
                    if (str != "")
                    {
                        str = str + ",";
                    }
                    str = str + str2;
                }
            }
            return str;
        }

        public static void FormatNumber(int LotteryID, string LastWinNumber, out string[] RedNumber, out string[] OrangeNumber, out string[] BlueNumber)
        {
            LastWinNumber = LastWinNumber.Replace("  ", " ");
            if (LotteryID == 5)
            {
                try
                {
                    RedNumber = LastWinNumber.Split(new string[] { " + " }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new char[] { ' ' });
                }
                catch
                {
                    RedNumber = new string[0];
                }
                try
                {
                    BlueNumber = new string[] { LastWinNumber.Split(new string[] { " + " }, StringSplitOptions.RemoveEmptyEntries)[1] };
                }
                catch
                {
                    BlueNumber = new string[0];
                }
                OrangeNumber = new string[0];
            }
            else if ((LotteryID == 6) || (LotteryID == 0x1d))
            {
                try
                {
                    string str = LastWinNumber.Trim();
                    BlueNumber = new string[str.Length];
                    for (int i = 0; i < BlueNumber.Length; i++)
                    {
                        BlueNumber[i] = str.Substring(i, 1);
                    }
                }
                catch
                {
                    BlueNumber = new string[0];
                }
                RedNumber = new string[0];
                OrangeNumber = new string[0];
            }
            else if (LotteryID == 13)
            {
                try
                {
                    OrangeNumber = LastWinNumber.Split(new string[] { " + " }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new char[] { ' ' });
                }
                catch
                {
                    OrangeNumber = new string[0];
                }
                try
                {
                    BlueNumber = new string[] { LastWinNumber.Split(new string[] { " + " }, StringSplitOptions.RemoveEmptyEntries)[1] };
                }
                catch
                {
                    BlueNumber = new string[0];
                }
                RedNumber = new string[0];
            }
            else if (LotteryID == 0x3b)
            {
                try
                {
                    RedNumber = LastWinNumber.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new char[] { ' ' });
                }
                catch
                {
                    RedNumber = new string[0];
                }
                try
                {
                    BlueNumber = new string[] { LastWinNumber.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries)[1] };
                }
                catch
                {
                    BlueNumber = new string[0];
                }
                OrangeNumber = new string[0];
            }
            else if (LotteryID == 0x3a)
            {
                try
                {
                    string str2 = LastWinNumber.Split(new char[] { '+' })[0];
                    OrangeNumber = new string[str2.Length];
                    for (int j = 0; j < OrangeNumber.Length; j++)
                    {
                        OrangeNumber[j] = str2.Substring(j, 1);
                    }
                }
                catch
                {
                    OrangeNumber = new string[0];
                }
                try
                {
                    BlueNumber = new string[] { LastWinNumber.Split(new char[] { '+' })[1] };
                }
                catch
                {
                    BlueNumber = new string[0];
                }
                RedNumber = new string[0];
            }
            else if ((LotteryID == 60) || (LotteryID == 0x3d))
            {
                try
                {
                    string str3 = LastWinNumber.Trim();
                    RedNumber = new string[str3.Length];
                    for (int k = 0; k < RedNumber.Length; k++)
                    {
                        RedNumber[k] = str3.Substring(k, 1);
                    }
                }
                catch
                {
                    RedNumber = new string[0];
                }
                OrangeNumber = new string[0];
                BlueNumber = new string[0];
            }
            else
            {
                RedNumber = new string[0];
                OrangeNumber = new string[0];
                BlueNumber = new string[0];
            }
        }

        public static string GetCallCert()
        {
            string sSourceStr = "";
            string str2 = _String.Reverse("ShoveSoft" + " " + "CO.,Ltd ");
            str2 = _String.Reverse(_String.Reverse(str2) + ("--" + " by Shove "));
            sSourceStr = "20050709";
            sSourceStr = _String.Reverse(sSourceStr + _String.Reverse("圳深 ") + _String.Reverse("安宝"));
            return (_String.Reverse(str2) + _String.Reverse(sSourceStr));
        }

        public static string GetDatabaseEdition()
        {
            return new SystemOptions()["SystemDatabaseVersion"].ToString("");
        }

        public static DataTable GetDataTable(DataTable dt, int Type2)
        {
            DataRow[] rowArray;
            DataColumn column = new DataColumn("Order", Type.GetType("System.String"));
            DataColumn column2 = new DataColumn("LotteryID", Type.GetType("System.String"));
            DataColumn column3 = new DataColumn("LotteryName", Type.GetType("System.String"));
            DataColumn column4 = new DataColumn("IsuseName", Type.GetType("System.String"));
            DataColumn column5 = new DataColumn("WinLotteryNumber", Type.GetType("System.String"));
            DataColumn column6 = new DataColumn("LotteryTypeID", Type.GetType("System.String"));
            DataColumn column7 = new DataColumn("LotteryType2", Type.GetType("System.String"));
            DataColumn column8 = new DataColumn("LotteryType2Name", Type.GetType("System.String"));
            DataTable table = new DataTable();
            table.Columns.Add(column);
            table.Columns.Add(column2);
            table.Columns.Add(column3);
            table.Columns.Add(column4);
            table.Columns.Add(column5);
            table.Columns.Add(column6);
            table.Columns.Add(column7);
            table.Columns.Add(column8);
            if (Type2 == 3)
            {
                object[] objArray = new object[] { "LotteryType2 = ", Type2, "and LotteryID <> ", 0x2d.ToString() };
                rowArray = dt.Select(string.Concat(objArray), "EndTime desc");
            }
            else
            {
                rowArray = dt.Select("LotteryType2 = " + Type2, "EndTime desc");
            }
            foreach (DataRow row in rowArray)
            {
                DataRow row2 = table.NewRow();
                row2[0] = row[0].ToString();
                row2[1] = row[1].ToString();
                row2[2] = row[2].ToString();
                row2[3] = row[3].ToString();
                row2[4] = new SLS.Lottery()[int.Parse(row[1].ToString())].ShowNumber(row[4].ToString());
                row2[5] = row[5].ToString();
                row2[6] = row[6].ToString();
                row2[7] = row[7].ToString();
                table.Rows.Add(row2);
            }
            return table;
        }

        public static string GetEdition()
        {
            return "5.0.001";
        }

        public static string GetHtml(string Url, string encodeing, int TimeoutSeconds)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(Url);
                request.UserAgent = "www.svnhost.cn";
                if (TimeoutSeconds > 0)
                {
                    request.Timeout = 0x3e8 * TimeoutSeconds;
                }
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encodeing));
                    return reader.ReadToEnd();
                }
                return "";
            }
            catch (SystemException)
            {
                return "";
            }
        }

        public static int GetLotteryType2(int LotteryID)
        {
            int num = 0;
            object obj2 = MSSQL.ExecuteScalar("Select [Type2] From T_Lotteries Where [ID] = @p1", new MSSQL.Parameter[] { new MSSQL.Parameter("@p1", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID) });
            if (obj2 == null)
            {
                return num;
            }
            return int.Parse(obj2.ToString());
        }

        public static Sites GetMasterSite()
        {
            return new Sites()[Functions.F_GetMasterSiteID()];
        }

        public static string GetMID()
        {
            SqlConnection connection = MSSQL.CreateDataConnection();
            if (connection == null)
            {
                return "";
            }
            string database = connection.Database;
            connection.Close();
            string sourceStr = SystemInformation.GetNetCardMACAddress() + database;
            return Encrypt.NoUnEncryptString(GetCallCert(), sourceStr, "MID-", 5, 5, 0);
        }

        public static int GetProfitPoints(double profitMoney)
        {
            int num = 0;
            if ((profitMoney >= 1.0) && (profitMoney <= 20.0))
            {
                profitMoney = 1.0;
                return num;
            }
            if ((profitMoney >= 21.0) && (profitMoney <= 50.0))
            {
                profitMoney = 2.0;
                return num;
            }
            if ((profitMoney >= 51.0) && (profitMoney <= 100.0))
            {
                profitMoney = 5.0;
                return num;
            }
            if ((profitMoney >= 101.0) && (profitMoney <= 200.0))
            {
                profitMoney = 10.0;
                return num;
            }
            if ((profitMoney >= 201.0) && (profitMoney <= 500.0))
            {
                profitMoney = 20.0;
                return num;
            }
            if ((profitMoney >= 501.0) && (profitMoney <= 1000.0))
            {
                profitMoney = 40.0;
                return num;
            }
            if ((profitMoney >= 1001.0) && (profitMoney <= 2000.0))
            {
                profitMoney = 80.0;
                return num;
            }
            if ((profitMoney >= 2001.0) && (profitMoney <= 5000.0))
            {
                profitMoney = 160.0;
                return num;
            }
            if ((profitMoney >= 5001.0) && (profitMoney <= 10000.0))
            {
                profitMoney = 320.0;
                return num;
            }
            if ((profitMoney >= 10001.0) && (profitMoney <= 20000.0))
            {
                profitMoney = 640.0;
                return num;
            }
            if ((profitMoney >= 20001.0) && (profitMoney <= 50000.0))
            {
                profitMoney = 1280.0;
                return num;
            }
            if ((profitMoney >= 50001.0) && (profitMoney <= 100000.0))
            {
                profitMoney = 2560.0;
                return num;
            }
            if ((profitMoney >= 100001.0) && (profitMoney <= 500000.0))
            {
                profitMoney = 5120.0;
                return num;
            }
            if ((profitMoney >= 500001.0) && (profitMoney <= 1000000.0))
            {
                profitMoney = 10240.0;
                return num;
            }
            if ((profitMoney >= 1000001.0) && (profitMoney <= 2000000.0))
            {
                profitMoney = 20480.0;
                return num;
            }
            if ((profitMoney >= 2000001.0) && (profitMoney <= 5000000.0))
            {
                profitMoney = 40960.0;
                return num;
            }
            if (profitMoney >= 5000001.0)
            {
                profitMoney = 81920.0;
            }
            return num;
        }

        public static double GetSumByColumn(DataTable dt, int index, bool isPage, int pageSize, int pageIndex)
        {
            double num = 0.0;
            int count = dt.Columns.Count;
            if ((index < count) && (index >= 0))
            {
                int num3 = dt.Rows.Count;
                if (!isPage)
                {
                    for (int j = 0; j < num3; j++)
                    {
                        num += _Convert.StrToDouble(dt.Rows[j][index].ToString(), 0.0);
                    }
                    return num;
                }
                num3 = (pageIndex + 1) * pageSize;
                if (num3 > dt.Rows.Count)
                {
                    num3 = (pageIndex * pageSize) + (dt.Rows.Count % pageSize);
                }
                for (int i = pageIndex * pageSize; i < num3; i++)
                {
                    num += _Convert.StrToDouble(dt.Rows[i][index].ToString(), 0.0);
                }
            }
            return num;
        }

        public static DataTable GetTeamInfo(string No, long SchemeID)
        {
            return new Views.V_SchemeForZCDC().Open("*", "[SchemesID] = " + SchemeID.ToString() + " and No = " + No, "");
        }

        public static DataTable GetZCDCBuyContent(string BuyNum, long SchemeID, ref string vote)
        {
            string scheme = _Convert.ToHtmlCode(BuyNum);
            string buyContent = "";
            new SLS.Lottery()["45"].GetSchemeSplit(scheme, ref buyContent, ref vote);
            string str3 = scheme.Split(new char[] { ';' })[0].ToString();
            string[] strArray = buyContent.Split(new char[] { '|' });
            DataTable table = new DataTable();
            DataColumn column = new DataColumn("No", Type.GetType("System.Int32"));
            table.Columns.Add(column);
            column = new DataColumn("LeagueTypeName", Type.GetType("System.String"));
            table.Columns.Add(column);
            column = new DataColumn("HostTeam", Type.GetType("System.String"));
            table.Columns.Add(column);
            column = new DataColumn("QuestTeam", Type.GetType("System.String"));
            table.Columns.Add(column);
            column = new DataColumn("Content", Type.GetType("System.String"));
            table.Columns.Add(column);
            column = new DataColumn("MarkersColor", Type.GetType("System.String"));
            table.Columns.Add(column);
            column = new DataColumn("sp", Type.GetType("System.String"));
            table.Columns.Add(column);
            column = new DataColumn("LotteryResult", Type.GetType("System.String"));
            table.Columns.Add(column);
            column = new DataColumn("GamesResult", Type.GetType("System.String"));
            table.Columns.Add(column);
            column = new DataColumn("HalftimeResult", Type.GetType("System.String"));
            table.Columns.Add(column);
            for (int i = 0; i < strArray.Length; i++)
            {
                DataTable teamInfo = GetTeamInfo(strArray[i].Split(new char[] { '(' })[0], SchemeID);
                if (teamInfo == null)
                {
                    return null;
                }
                string str4 = strArray[i].Split(new char[] { '(' })[1].Substring(0, strArray[i].Split(new char[] { '(' })[1].Length - 1);
                string str5 = "";
                string str6 = "";
                string str7 = "";
                string str8 = "";
                string str9 = "";
                int num2 = 0x1195;
                if (str3 == num2.ToString())
                {
                    str4 = str4.Replace("0", "负").Replace("1", "平").Replace("3", "胜");
                    if (teamInfo.Rows[0]["SPFResult"] != null)
                    {
                        str5 = teamInfo.Rows[0]["SPFResult"].ToString().Replace("0", "负").Replace("1", "平").Replace("3", "胜");
                    }
                    if (teamInfo.Rows[0]["SPF_SP"] != null)
                    {
                        str9 = teamInfo.Rows[0]["SPF_SP"].ToString();
                    }
                }
                int num3 = 0x1196;
                if (str3 == num3.ToString())
                {
                    str4 = str4.Replace("7", "7+");
                    if (teamInfo.Rows[0]["ZJQResult"] != null)
                    {
                        str5 = teamInfo.Rows[0]["ZJQResult"].ToString().Replace("7", "7+");
                    }
                    if (teamInfo.Rows[0]["ZJQ_SP"] != null)
                    {
                        str9 = teamInfo.Rows[0]["ZJQ_SP"].ToString();
                    }
                }
                int num4 = 0x1197;
                if (str3 == num4.ToString())
                {
                    str4 = str4.Replace("1", "上-单").Replace("2", "上-双").Replace("3", "下-单").Replace("4", "下-双");
                    if (teamInfo.Rows[0]["SXDSResult"] != null)
                    {
                        str5 = teamInfo.Rows[0]["SXDSResult"].ToString().Replace("1", "上-单").Replace("2", "上-双").Replace("3", "下-单").Replace("4", "下-双");
                    }
                    if (teamInfo.Rows[0]["SXDS_SP"] != null)
                    {
                        str9 = teamInfo.Rows[0]["SXDS_SP"].ToString();
                    }
                }
                string str10 = "";
                string str11 = "";
                int num5 = 0x1198;
                if (str3 == num5.ToString())
                {
                    string[] strArray2 = str4.Split(new char[] { ',' });
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length > 1)
                        {
                            str10 = str10 + strArray2[j].Replace("25", "负其他").Replace("24", "2:4").Replace("23", "1:4").Replace("22", "0:4").Replace("21", "2:3").Replace("20", "1:3").Replace("19", "0:3").Replace("18", "1:2").Replace("17", "0:2").Replace("16", "0:1").Replace("15", "平其他").Replace("14", "3:3").Replace("13", "2:2").Replace("12", "1:1").Replace("11", "0:0").Replace("10", "胜其他");
                        }
                        else
                        {
                            str10 = str10 + strArray2[j].Replace("1", "1:0").Replace("2", "2:0").Replace("3", "2:1").Replace("4", "3:0").Replace("5", "3:1").Replace("6", "3:2").Replace("7", "4:0").Replace("8", "4:1").Replace("9", "4:2");
                        }
                        str10 = str10 + ",";
                    }
                    str4 = str10.Substring(0, str10.Length - 1);
                    if (teamInfo.Rows[0]["ZQBFResult"] != null)
                    {
                        string[] strArray3 = teamInfo.Rows[0]["ZQBFResult"].ToString().Split(new char[] { ',' });
                        for (int k = 0; k < strArray3.Length; k++)
                        {
                            if (strArray3[k].Length > 1)
                            {
                                str11 = str11 + strArray3[k].Replace("25", "负其他").Replace("24", "2:4").Replace("23", "1:4").Replace("22", "0:4").Replace("21", "2:3").Replace("20", "1:3").Replace("19", "0:3").Replace("18", "1:2").Replace("17", "0:2").Replace("16", "0:1").Replace("15", "平其他").Replace("14", "3:3").Replace("13", "2:2").Replace("12", "1:1").Replace("11", "0:0").Replace("10", "胜其他");
                            }
                            else
                            {
                                str11 = str11 + strArray3[k].Replace("1", "1:0").Replace("2", "2:0").Replace("3", "2:1").Replace("4", "3:0").Replace("5", "3:1").Replace("6", "3:2").Replace("7", "4:0").Replace("8", "4:1").Replace("9", "4:2");
                            }
                            str11 = str11 + ",";
                        }
                        str5 = str11.Substring(0, str11.Length - 1);
                    }
                    if (teamInfo.Rows[0]["ZQBF_SP"] != null)
                    {
                        str9 = teamInfo.Rows[0]["ZQBF_SP"].ToString();
                    }
                }
                int num8 = 0x1199;
                if (str3 == num8.ToString())
                {
                    str4 = str4.Replace("1", "胜-胜").Replace("2", "胜-平").Replace("3", "胜-负").Replace("4", "平-胜").Replace("5", "平-平").Replace("6", "平-负").Replace("7", "负-胜").Replace("8", "负-平 ").Replace("9", "负-负");
                    if (teamInfo.Rows[0]["BQCSPFResult"] != null)
                    {
                        str5 = teamInfo.Rows[0]["BQCSPFResult"].ToString().Replace("1", "胜-胜").Replace("2", "胜-平").Replace("3", "胜-负").Replace("4", "平-胜").Replace("5", "平-平").Replace("6", "平-负").Replace("7", "负-胜").Replace("8", "负-平 ").Replace("9", "负-负");
                    }
                    if (teamInfo.Rows[0]["BQCSPF_SP"] != null)
                    {
                        str9 = teamInfo.Rows[0]["BQCSPF_SP"].ToString();
                    }
                }
                if (str5 == "*")
                {
                    str5 = "延时";
                    str9 = "1";
                }
                if (teamInfo.Rows[0]["Result"] != null)
                {
                    str6 = teamInfo.Rows[0]["Result"].ToString();
                }
                if (teamInfo.Rows[0]["HalftimeResult"] != null)
                {
                    str7 = teamInfo.Rows[0]["HalftimeResult"].ToString();
                }
                if (teamInfo.Rows[0]["LetBall"] != null)
                {
                    str8 = teamInfo.Rows[0]["LetBall"].ToString();
                }
                if (str8 == "0")
                {
                    str8 = "";
                }
                else
                {
                    str8 = "[" + str8 + "]";
                }
                DataRow row = table.NewRow();
                row[0] = teamInfo.Rows[0]["No"].ToString();
                row[1] = teamInfo.Rows[0]["LeagueTypeName"].ToString();
                row[2] = teamInfo.Rows[0]["HostTeam"].ToString() + str8;
                row[3] = teamInfo.Rows[0]["QuestTeam"].ToString();
                row[4] = str4;
                row[5] = teamInfo.Rows[0]["MarkersColor"].ToString();
                row[6] = str9;
                row[7] = str5;
                row[8] = str6;
                row[9] = str7;
                table.Rows.Add(row);
            }
            return table;
        }

        public static bool GetZCDCNoIsOverdue(long IsuseID, string No)
        {
            bool flag = false;
            DataTable table = new Views.V_IsuseForZCDC().Open("DateTime", "[IsuseID]=" + IsuseID.ToString() + " and [No]=" + No, "");
            if ((table == null) || (table.Rows.Count == 0))
            {
                return true;
            }
            if (DateTime.Now > _Convert.StrToDateTime(table.Rows[0][0].ToString(), DateTime.Now.ToString()))
            {
                flag = true;
            }
            return flag;
        }

        public static bool GetZCDCSchemesIsOverdue(long IsuseID, string No)
        {
            bool flag = false;
            DataTable table = new Views.V_IsuseForZCDC().Open("DateTime", "[IsuseID]=" + IsuseID.ToString() + " and [No]=" + No, "");
            if ((table == null) || (table.Rows.Count == 0))
            {
                return true;
            }
            if (DateTime.Now > _Convert.StrToDateTime(table.Rows[0][0].ToString(), DateTime.Now.ToString()).AddMinutes(30.0))
            {
                flag = true;
            }
            return flag;
        }

        public static void GoError(int ErrorNumber, string Tip, string ClassName)
        {
            GoError("~/Error.aspx", ErrorNumber, Tip, ClassName);
        }

        public static void GoError(string ErrorPageUrl, int ErrorNumber, string Tip, string ClassName)
        {
            HttpContext.Current.Response.Redirect(ErrorPageUrl + "?ErrorNumber=" + ErrorNumber.ToString() + "&Tip=" + HttpUtility.UrlEncode(Tip) + "&ClassName=" + HttpUtility.UrlEncode(Encrypt.EncryptString(GetCallCert(), ClassName)), true);
        }

        public static void GoLogin()
        {
            GoLogin("UserLogin.aspx", "", true);
        }

        public static void GoLogin(bool isAtFramePageLogin)
        {
            GoLogin("UserLogin.aspx", "", isAtFramePageLogin);
        }

        public static void GoLogin(string RequestLoginPage)
        {
            GoLogin("UserLogin.aspx", RequestLoginPage, true);
        }

        public static void GoLogin(string RequestLoginPage, bool isAtFramePageLogin)
        {
            GoLogin("UserLogin.aspx", RequestLoginPage, isAtFramePageLogin);
        }

        public static void GoLogin(string LoginPageFileName, string RequestLoginPage)
        {
            GoLogin(LoginPageFileName, RequestLoginPage, true);
        }

        public static void GoLogin(string LoginPageFileName, string RequestLoginPage, bool isAtFramePageLogin)
        {
            if (RequestLoginPage.Contains("/Home/Alipay/"))
            {
                LoginPageFileName = Utility.GetUrl() + "/Home/Alipay/Login.aspx";
            }
            else if (RequestLoginPage.Contains("/Web/OnlinePay/") || (RequestLoginPage.Contains("/Web/") && !RequestLoginPage.Contains("/Home/Web/")))
            {
                LoginPageFileName = Utility.GetUrl() + "/Web/" + LoginPageFileName;
            }
            else
            {
                LoginPageFileName = Utility.GetUrl() + "/" + LoginPageFileName;
            }
            if (isAtFramePageLogin)
            {
                HttpContext.Current.Response.Redirect(LoginPageFileName + "?RequestLoginPage=" + HttpUtility.UrlEncode(RequestLoginPage), true);
            }
            else
            {
                HttpContext.Current.Response.Write("<script language=\"javascript\">window.top.location.href=\"" + LoginPageFileName + "?RequestLoginPage=" + HttpUtility.UrlEncode(RequestLoginPage) + "\";</script>");
            }
        }

        public static bool IsSystemRegister()
        {
            if (HttpContext.Current.Application["IsSystemRegister"] != null)
            {
                return _Convert.StrToBool(HttpContext.Current.Application["IsSystemRegister"].ToString(), false);
            }
            string mID = GetMID();
            SystemOptions options = new SystemOptions();
            if (options["SerialNumberForShoveSoft_MHB"].Value.ToString() != Encrypt.NoUnEncryptString(GetCallCert(), mID, "SLS-", 5, 5, 0))
            {
                return false;
            }
            return true;
        }

        public static string Post(string Url, string RequestString, int TimeoutSeconds)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            if (TimeoutSeconds > 0)
            {
                request.Timeout = 0x3e8 * TimeoutSeconds;
            }
            request.Method = "POST";
            request.AllowAutoRedirect = true;
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(RequestString);
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));
            return reader.ReadToEnd();
        }

        public static int SendEmail(Sites Site, string MailTo, string Subject, string Body)
        {
            new SendEmailTask(Site, MailTo, Subject, Body).Run();
            return 0;
        }

        public static int SendSMS(Sites Site, long UserID, string Mobile, string Content)
        {
            if ((Site == null) || (Site.ID < 0L))
            {
                return -1;
            }
            new Tables.T_SMS { SiteID = { Value = Site.ID }, SMSID = { Value = -1 }, From = { Value = "" }, To = { Value = Mobile }, Content = { Value = Content }, IsSent = { Value = false } }.Insert();
            return 0;
        }

        public static int SendStationSMS(Sites Site, long SourceUserID, long AimUserID, short StationSMSType, string Content)
        {
            new Tables.T_StationSMS { SiteID = { Value = Site.ID }, SourceID = { Value = SourceUserID }, AimID = { Value = AimUserID }, Type = { Value = StationSMSType }, Content = { Value = Content }, isRead = { Value = (bool)false } }.Insert();
            return 0;
        }

        public static void SendWinNotification(DataSet ds)
        {
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    DataTable table = ds.Tables[i];
                    if (table.Rows.Count >= 1)
                    {
                        long siteID = long.Parse(table.Rows[0]["SiteID"].ToString());
                        bool flag = Functions.F_GetSiteSendNotificationTypes(siteID, 2).IndexOf("[Win]") >= 0;
                        bool flag2 = Functions.F_GetSiteSendNotificationTypes(siteID, 1).IndexOf("[Win]") >= 0;
                        bool flag3 = Functions.F_GetSiteSendNotificationTypes(siteID, 3).IndexOf("[Win]") >= 0;
                        if ((flag || flag2) || flag3)
                        {
                            Sites site = new Sites()[siteID];
                            if (site != null)
                            {
                                string subject = "";
                                string body = "";
                                if (flag)
                                {
                                    site.SiteNotificationTemplates.SplitEmailTemplate(site.SiteNotificationTemplates[2, "Win"], ref subject, ref body);
                                }
                                string str3 = "";
                                if (flag2)
                                {
                                    str3 = site.SiteNotificationTemplates[1, "Win"];
                                }
                                string str4 = "";
                                if (flag3)
                                {
                                    str4 = site.SiteNotificationTemplates[3, "Win"];
                                }
                                if (((subject != "") && (body != "")) || ((str3 != "") || (str4 != "")))
                                {
                                    for (int j = 0; j < table.Rows.Count; j++)
                                    {
                                        DataRow row = table.Rows[j];
                                        Users users = new Users(site.ID)[site.ID, long.Parse(row["UserID"].ToString())];
                                        if (users != null)
                                        {
                                            if (((flag && (subject != "")) && ((body != "") && (users.Email != ""))) && Functions.F_GetIsSendNotification(site.ID, 2, "Win", users.ID))
                                            {
                                                string str5 = subject.Replace("[UserName]", users.Name);
                                                string str6 = body.Replace("[UserName]", users.Name).Replace("[SchemeID]", row["SchemeID"].ToString()).Replace("[Money]", double.Parse(row["WinMoney"].ToString()).ToString("N"));
                                                SendEmail(site, users.Email, str5, str6);
                                            }
                                            if (((flag2 && (str4 != "")) && ((users.Mobile != "") && users.isMobileValided)) && Functions.F_GetIsSendNotification(site.ID, 1, "Win", users.ID))
                                            {
                                                string content = str4.Replace("[UserName]", users.Name).Replace("[SchemeID]", row["SchemeID"].ToString()).Replace("[Money]", double.Parse(row["WinMoney"].ToString()).ToString("N"));
                                                SendSMS(site, users.ID, users.Mobile, content);
                                            }
                                            if ((flag3 && (str4 != "")) && Functions.F_GetIsSendNotification(site.ID, 3, "Win", users.ID))
                                            {
                                                string str8 = str4.Replace("[UserName]", users.Name).Replace("[SchemeID]", row["SchemeID"].ToString()).Replace("[Money]", double.Parse(row["WinMoney"].ToString()).ToString("N"));
                                                SendStationSMS(site, site.AdministratorID, users.ID, 2, str8);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static string StringAddsBrightly(string Str)
        {
            if (Str.IndexOf("[") >= 0)
            {
                Str = Str.Replace("[", "<font color='red'>[").Replace("]", "]</font>");
                return Str;
            }
            return Str;
        }

        public static string UBBToHTML(string sDetail)
        {
            RegexOptions ignoreCase = RegexOptions.IgnoreCase;
            new StringBuilder();
            sDetail = Regex.Replace(sDetail, @"\[smilie\](.+?)\[\/smilie\]", "<img src=\"$1\" />", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[b(?:\s*)\]", "<b>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[i(?:\s*)\]", "<i>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[u(?:\s*)\]", "<u>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[/b(?:\s*)\]", "</b>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[/i(?:\s*)\]", "</i>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[/u(?:\s*)\]", "</u>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[sup(?:\s*)\]", "<sup>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[sub(?:\s*)\]", "<sub>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[/sup(?:\s*)\]", "</sup>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[/sub(?:\s*)\]", "</sub>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"((\r\n)*\[p\])(.*?)((\r\n)*\[\/p\])", "<p>$3</p>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            sDetail = Regex.Replace(sDetail, @"\[url(?:\s*)\](www\.(.*?))\[/url(?:\s*)\]", "<a href=\"http://$1\" target=\"_blank\">$1</a>", ignoreCase);
            sDetail = Regex.Replace(sDetail, "\\[url(?:\\s*)\\]\\s*((https?://|ftp://|gopher://|news://|telnet://|rtsp://|mms://|callto://|bctp://|ed2k://|tencent)([^\\[\"']+?))\\s*\\[\\/url(?:\\s*)\\]", "<a href=\"$1\" target=\"_blank\">$1</a>", ignoreCase);
            sDetail = Regex.Replace(sDetail, "\\[url=www.([^\\[\"']+?)(?:\\s*)\\]([\\s\\S]+?)\\[/url(?:\\s*)\\]", "<a href=\"http://www.$1\" target=\"_blank\">$2</a>", ignoreCase);
            sDetail = Regex.Replace(sDetail, "\\[url=((https?://|ftp://|gopher://|news://|telnet://|rtsp://|mms://|callto://|bctp://|ed2k://|tencent://)([^\\[\"']+?))(?:\\s*)\\]([\\s\\S]+?)\\[/url(?:\\s*)\\]", "<a href=\"$1\" target=\"_blank\">$4</a>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[email(?:\s*)\](.*?)\[\/email\]", "<a href=\"mailto:$1\" target=\"_blank\">$1</a>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[email=(.[^\[]*)(?:\s*)\](.*?)\[\/email(?:\s*)\]", "<a href=\"mailto:$1\" target=\"_blank\">$2</a>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[color=([^\[\<]+?)\]", "<font color=\"$1\">", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[size=(\d+?)\]", "<font size=\"$1\">", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[size=(\d+(\.\d+)?(px|pt|in|cm|mm|pc|em|ex|%)+?)\]", "<font style=\"font-size: $1\">", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[font=([^\[\<]+?)\]", "<font face=\"$1\">", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[align=([^\[\<]+?)\]", "<p align=\"$1\">", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[float=(left|right)\]", "<br style=\"clear: both\"><span style=\"float: $1;\">", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[/color(?:\s*)\]", "</font>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[/size(?:\s*)\]", "</font>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[/font(?:\s*)\]", "</font>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[/align(?:\s*)\]", "</p>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[/float(?:\s*)\]", "</span>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[indent(?:\s*)\]", "<blockquote>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[/indent(?:\s*)\]", "</blockquote>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[simpletag(?:\s*)\]", "<blockquote>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[/simpletag(?:\s*)\]", "</blockquote>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[list\]", "<ul>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[list=(1|A|a|I|i| )\]", "<ul type=\"$1\">", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[\*\]", "<li>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[/list\]", "</ul>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"(\[SHADOW=)(\d*?),(#*\w*?),(\d*?)\]([\s]||[\s\S]+?)(\[\/SHADOW\])", "<table width='$2'  style='filter:SHADOW(COLOR=$3, STRENGTH=$4)'>$5</table>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"(\[glow=)(\d*?),(#*\w*?),(\d*?)\]([\s]||[\s\S]+?)(\[\/glow\])", "<table width='$2'  style='filter:GLOW(COLOR=$3, STRENGTH=$4)'>$5</table>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[center\]([\s]||[\s\S]+?)\[\/center\]", "<center>$1</center>", ignoreCase);
            int index = sDetail.ToLower().IndexOf("[quote]");
            int num2 = 0;
            while (((index >= 0) && (sDetail.ToLower().IndexOf("[/quote]") >= 0)) && (num2 < 3))
            {
                num2++;
                sDetail = Regex.Replace(sDetail, @"\[quote\]([\s\S]+?)\[/quote\]", "<br /><br /><div class=\"msgheader\">引用:</div><div class=\"msgborder\">$1</div>", ignoreCase);
                index = sDetail.ToLower().IndexOf("[quote]", (int)(index + 7));
            }
            sDetail = Regex.Replace(sDetail, @"\[area=([\s\S]+?)\]([\s\S]+?)\[/area\]", "<br /><br /><div class=\"msgheader\">$1</div><div class=\"msgborder\">$2</div>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[area\]([\s\S]+?)\[/area\]", "<br /><br /><div class=\"msgheader\"></div><div class=\"msgborder\">$1</div>", ignoreCase);
            sDetail = sDetail.Replace("&amp;", "&");
            sDetail = Regex.Replace(sDetail, @"^((tencent|ed2k|thunder|vagaa):\/\/[\[\]\|A-Za-z0-9\.\/=\?%\-&_~`@':+!]+)", "<a target=\"_blank\" href=\"$1\">$1</a>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"((tencent|ed2k|thunder|vagaa):\/\/[\[\]\|A-Za-z0-9\.\/=\?%\-&_~`@':+!]+)$", "<a target=\"_blank\" href=\"$1\">$1</a>", ignoreCase);
            sDetail = Regex.Replace(sDetail, "[^>=\\]\"]((tencent|ed2k|thunder|vagaa):\\/\\/[\\[\\]\\|A-Za-z0-9\\.\\/=\\?%\\-&_~`@':+!]+)", "<a target=\"_blank\" href=\"$1\">$1</a>", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[img\]\s*(http://[^\[\<\r\n]+?)\s*\[\/img\]", "<img src=\"$1\" border=\"0\" />", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[img=(\d{1,4})[x|\,](\d{1,4})\]\s*(http://[^\[\<\r\n]+?)\s*\[\/img\]", "<img src=\"$3\" width=\"$1\" height=\"$2\" border=\"0\" />", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[image\](http://[\s\S]+?)\[/image\]", "<img src=\"$1\" border=\"0\" />", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[img\]\s*(http://[^\[\<\r\n]+?)\s*\[\/img\]", "<img src=\"$1\" border=\"0\" onload=\"attachimg(this, 'load');\" onclick=\"zoom(this)\" />", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[img=(\d{1,4})[x|\,](\d{1,4})\]\s*(http://[^\[\<\r\n]+?)\s*\[\/img\]", "<img src=\"$3\" width=\"$1\" height=\"$2\" border=\"0\" onload=\"attachimg(this, 'load');\" onclick=\"zoom(this)\"  />", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[image\](http://[\s\S]+?)\[/image\]", "<img src=\"$1\" border=\"0\" />", ignoreCase);
            sDetail = sDetail.Replace("\t", "&nbsp; &nbsp; ");
            sDetail = sDetail.Replace("  ", "&nbsp; ");
            sDetail = Regex.Replace(sDetail, @"\[r/\]", "\r", ignoreCase);
            sDetail = Regex.Replace(sDetail, @"\[n/\]", "\n", ignoreCase);
            sDetail = sDetail.Replace("\r\n", "<br />");
            sDetail = sDetail.Replace("\r", "");
            sDetail = sDetail.Replace("\n\n", "<br /><br />");
            sDetail = sDetail.Replace("\n", "<br />");
            sDetail = sDetail.Replace("{rn}", "\r\n");
            sDetail = sDetail.Replace("{nn}", "\n\n");
            sDetail = sDetail.Replace("{r}", "\r");
            sDetail = sDetail.Replace("{n}", "\n");
            return sDetail;
        }

        public static bool ValidEdition()
        {
            return (GetEdition() == GetDatabaseEdition());
        }

        public static bool ValidLotteryID(Sites Site, int LotteryID)
        {
            return (("," + Site.UseLotteryList + ",").IndexOf("," + LotteryID.ToString() + ",") >= 0);
        }

        public static object ValidLotteryTime(string Time)
        {
            DateTime time;
            Time = Time.Trim();
            Regex regex = new Regex(@"[\d]{4}[-][\d]{1,2}[-][\d]{1,2}[\s][\d]{1,2}[:][\d]{1,2}[:][\d]{1,2}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (!regex.IsMatch(Time))
            {
                return null;
            }
            try
            {
                time = DateTime.Parse(Time);
            }
            catch
            {
                return null;
            }
            return time;
        }
    }
}
