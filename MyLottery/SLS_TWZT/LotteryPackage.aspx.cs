using AjaxPro;
using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using SLS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class LotteryPackage : RoomPageBase, IRequiresSessionState
{
    private static Dictionary<int, int[]> NumberCount = new Dictionary<int, int[]>();
    public string script = "";

    static LotteryPackage()
    {
        NumberCount[5] = new int[] { 6, 1 };
        int[] numArray2 = new int[2];
        numArray2[0] = 3;
        NumberCount[6] = numArray2;
        NumberCount[0x27] = new int[] { 5, 2 };
        int[] numArray4 = new int[2];
        numArray4[0] = 3;
        NumberCount[0x3f] = numArray4;
        int[] numArray5 = new int[2];
        numArray5[0] = 5;
        NumberCount[0x40] = numArray5;
    }

    [AjaxMethod(HttpSessionStateRequirement.Read)]
    public string AnalyseScheme(string Content, int LotteryID)
    {
        return new Lottery()[LotteryID].AnalyseScheme(Content, (LotteryID * 100) + 1).Trim();
    }

    private void BindUsers()
    {
        string key = "LotteryPackage_BindUsers";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = MSSQL.Select("select UserID,LotteryID,b.Name as UserName,c.Name as LotteryName,case Type when 1 then '吉祥包月' when 2 then '如意包季' when 3 then '幸福半年' when 4 then '安康包年' end as TypeName, IsuseCount*Price*Multiple*Nums as Moneys from T_Chases a inner join T_Users b on a.UserID = b.ID inner join T_Lotteries c on a.LotteryID = c.ID order by a.ID desc", new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xe10);
        }
        StringBuilder builder = new StringBuilder();
        builder.Append("<div id='scrollWinUsers' style='overflow:hidden;height:290px'>").Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
        foreach (DataRow row in cacheAsDataTable.Rows)
        {
            builder.Append("<tr>").Append("<td width=\"23%\" height=\"24\" align=\"center\" bgcolor=\"#FFFFFF\" class=\"blue12\">").Append("<a href='../Web/Score.aspx?id=" + row["UserID"].ToString() + "&LotteryID=" + row["LotteryID"].ToString() + "' target=\"_blank\" title='" + row["UserName"].ToString() + "'>" + _String.Cut(row["UserName"].ToString(), 3) + "</a>").Append("</td>").Append("<td width=\"25%\" height=\"24\" align=\"center\" bgcolor=\"#FFFFFF\" class=\"blue12\">").Append(row["LotteryName"].ToString()).Append("</td>").Append("<td width=\"24%\" height=\"24\" align=\"center\" bgcolor=\"#FFFFFF\" class=\"red12_2\">").Append(row["TypeName"].ToString()).Append("</td>").Append("<td width=\"27%\" height=\"24\" align=\"center\" bgcolor=\"#FFFFFF\" class=\"blue12\">").Append(_Convert.StrToDouble(row["Moneys"].ToString(), 0.0).ToString("N").Split(new char[] { '.' })[0]).Append("</td>").Append("</tr>");
        }
        builder.Append("</table></div>");
        this.tdUsers.InnerHtml = builder.ToString();
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (!PF.IsSystemRegister())
        {
            PF.GoError(4, "请联系网站管理员输入软件序列号", base.GetType().BaseType.FullName);
        }
        else
        {
            int isuseCount = _Convert.StrToInt(this.HidIsuseCount.Value, -1);
            int lotteryID = _Convert.StrToInt(this.HidLotteryID.Value, -1);
            short type = _Convert.StrToShort(this.HidType.Value, -1);
            int multiple = _Convert.StrToInt(this.HidMultiple.Value, -1);
            int nums = _Convert.StrToInt(this.HidNums.Value, -1);
            short betType = _Convert.StrToShort(this.HidBetType.Value, -1);
            double money = _Convert.StrToDouble(this.HidMoney.Value, -1.0);
            string request = Shove._Web.Utility.GetRequest("tbTitle1");
            int playType = _Convert.StrToInt(this.HidPlayTypeID.Value, -1);
            if (string.IsNullOrEmpty(request))
            {
                request = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if ((((isuseCount < 0) || (lotteryID < 0)) || ((type < 0) || (multiple < 0))) || (((nums < 0) || (betType < 0)) || ((money < 0.0) || (playType < 0))))
            {
                JavaScript.Alert(this.Page, "投注信息有误！");
            }
            else if (base._User.Balance < money)
            {
                JavaScript.Alert(this.Page, "您的余额不足，请充值！");
            }
            else
            {
                int price = 2;
                if (playType == 0xf3f)
                {
                    price = 3;
                }
                if ((((isuseCount * multiple) * nums) * price) != money)
                {
                    JavaScript.Alert(this.Page, "投注总金额与投注倍数、注数、期数不相符！");
                }
                else
                {
                    DateTime now = DateTime.Now;
                    switch (type)
                    {
                        case 1:
                            now = now.AddMonths(1);
                            break;

                        case 2:
                            now = now.AddMonths(3);
                            break;

                        case 3:
                            now = now.AddMonths(6);
                            break;

                        case 4:
                            now = now.AddYears(1);
                            break;
                    }
                    string chaseXML = "";
                    if (betType != 1)
                    {
                        if (string.IsNullOrEmpty(this.HidLotteryNumber.Value))
                        {
                            JavaScript.Alert(this.Page, "发起追号套餐有异常！");
                            return;
                        }
                        if (multiple != _Convert.StrToInt(Shove._Web.Utility.GetRequest("selectMultiple"), 0))
                        {
                            JavaScript.Alert(this.Page, "投注倍数出现异常！");
                            return;
                        }
                        Lottery lottery2 = new Lottery();
                        string[] strArray6 = this.SplitLotteryNumber(this.HidLotteryNumber.Value);
                        if ((strArray6 == null) || (strArray6.Length < 1))
                        {
                            JavaScript.Alert(this.Page, "选号发生异常，请重新选择号码投注，谢谢。");
                            return;
                        }
                        int num15 = 0;
                        foreach (string str5 in strArray6)
                        {
                            string str6 = lottery2[lotteryID].AnalyseScheme(str5, playType);
                            if (!string.IsNullOrEmpty(str6))
                            {
                                string[] strArray8 = str6.Split(new char[] { '|' });
                                if ((strArray8 != null) && (strArray8.Length >= 1))
                                {
                                    num15 += _Convert.StrToInt(strArray8[strArray8.Length - 1], 0);
                                }
                            }
                        }
                        if (num15 != nums)
                        {
                            JavaScript.Alert(this.Page, "选号发生异常，请重新选择号码投注，谢谢。");
                            return;
                        }
                    }
                    else
                    {
                        string[] strArray2;
                        if (nums != _Convert.StrToInt(Shove._Web.Utility.GetRequest("selectMultiple"), 0))
                        {
                            JavaScript.Alert(this.Page, "投注注数出现异常！");
                            return;
                        }
                        if (multiple != 1)
                        {
                            JavaScript.Alert(this.Page, "投注倍数出现异常！");
                            return;
                        }
                        this.HidLotteryNumber.Value = "";
                        chaseXML = "<ChaseDetails>";
                        Lottery lottery = new Lottery();
                        switch (lotteryID)
                        {
                            case 5:
                                strArray2 = lottery[5].BuildNumber(6, 1, nums * isuseCount).Split(new string[] { "\n" }, StringSplitOptions.None);
                                break;

                            case 0x27:
                                strArray2 = lottery[0x27].BuildNumber(5, 2, nums * isuseCount).Split(new string[] { "\n" }, StringSplitOptions.None);
                                break;

                            default:
                                strArray2 = lottery[lotteryID].BuildNumber(nums * isuseCount).Split(new string[] { "\n" }, StringSplitOptions.None);
                                break;
                        }
                        if (strArray2.Length != (nums * isuseCount))
                        {
                            JavaScript.Alert(this.Page, "随机生成号码时出现异常！");
                            return;
                        }
                        int num12 = 1;
                        int num13 = 0;
                        string str3 = "";
                        foreach (string str4 in strArray2)
                        {
                            str3 = str3 + str4 + "\n";
                            if ((num12 % nums) == 0)
                            {
                                chaseXML = chaseXML + "<Chase ChaseLotteryNumber=\"" + str3 + "\"/>";
                                num13++;
                                str3 = "";
                            }
                            num12++;
                        }
                        if (num13 != isuseCount)
                        {
                            JavaScript.Alert(this.Page, "随机生成号码时出现异常！");
                            return;
                        }
                        chaseXML = chaseXML + "</ChaseDetails>";
                    }
                    string returnDescription = "";
                    if (base._User.InitiateCustomChase(lotteryID, playType, price, type, now, isuseCount, multiple, nums, betType, this.HidLotteryNumber.Value, 1, 0.0, money, request, chaseXML, ref returnDescription) < 0)
                    {
                        JavaScript.Alert(this.Page, returnDescription);
                    }
                    else
                    {
                        Shove._Web.Cache.ClearCache("LotteryPackage_BindUsers");
                        Shove._Web.Cache.ClearCache(base._Site.ID.ToString() + "AccountFreezeDetail_" + base._User.ID.ToString());
                        Shove._Web.Cache.ClearCache("Home_Room_ViewChaseCombo_BindData" + base._User.ID.ToString());
                        JavaScript.Alert(this.Page, "定制追号套餐成功！", "LotteryPackage.aspx");
                    }
                }
            }
        }
    }

    private string FormatLuckLotteryNumber(int LotteryID, string LotteryNumber)
    {
        if (string.IsNullOrEmpty(LotteryNumber))
        {
            return "";
        }
        string str = null;
        string str2 = null;
        if ((((LotteryID == 5) || (LotteryID == 0x3b)) || ((LotteryID == 13) || (LotteryID == 0x27))) || ((LotteryID == 9) || (LotteryID == 0x41)))
        {
            LotteryNumber = LotteryNumber.Replace(" + ", " ");
        }
        if (((LotteryID == 0x3a) || (LotteryID == 6)) || (((LotteryID == 3) || (LotteryID == 0x3f)) || (LotteryID == 0x40)))
        {
            str = LotteryNumber.Split(new char[] { '+' })[0];
            try
            {
                str2 = LotteryNumber.Split(new char[] { '+' })[1];
            }
            catch
            {
                str2 = "";
            }
            LotteryNumber = "";
            for (int i = 0; i < str.Length; i++)
            {
                LotteryNumber = LotteryNumber + str.Substring(i, 1) + " ";
            }
            LotteryNumber = LotteryNumber + str2;
            LotteryNumber = LotteryNumber.Trim();
        }
        return LotteryNumber;
    }

    [AjaxMethod(HttpSessionStateRequirement.Read)]
    public string GenerateLuckLotteryNumber(int LotteryID, string Type, string Name)
    {
        string key = "Home_Room_Buy_GenerateLuckLotteryNumber" + LotteryID.ToString();
        Type = Shove._Web.Utility.FilteSqlInfusion(Type);
        Name = Shove._Web.Utility.FilteSqlInfusion(Name);
        if (Type == "3")
        {
            try
            {
                DateTime time = Convert.ToDateTime(Name);
                Name = time.ToString("yyyy-MM-dd");
                if (time > DateTime.Now)
                {
                    return "出生日期不能超过当前日期！";
                }
            }
            catch
            {
                return "日期格式不正确！";
            }
        }
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
        {
            cacheAsDataTable = new Tables.T_LuckNumber().Open("", "datediff(d,getdate(),DateTime)=0 and LotteryID=" + LotteryID.ToString(), "");
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xe10);
        }
        string lotteryNumber = "";
        DataRow[] rowArray = cacheAsDataTable.Select("Type=" + Type + " and Name='" + Name + "'");
        if ((rowArray != null) && (rowArray.Length > 0))
        {
            lotteryNumber = rowArray[0]["LotteryNumber"].ToString();
        }
        else
        {
            if (LotteryID == 5)
            {
                lotteryNumber = new Lottery()[LotteryID].BuildNumber(6, 1, 1);
            }
            else if (LotteryID == 0x27)
            {
                lotteryNumber = new Lottery()[LotteryID].BuildNumber(5, 2, 1);
            }
            else
            {
                lotteryNumber = new Lottery()[LotteryID].BuildNumber(1);
            }
            Tables.T_LuckNumber number = new Tables.T_LuckNumber
            {
                LotteryID = { Value = LotteryID },
                LotteryNumber = { Value = lotteryNumber },
                Name = { Value = Name },
                Type = { Value = Type }
            };
            number.Insert();
            number.Delete("datediff(d,DateTime,getdate())>0");
            Shove._Web.Cache.ClearCache(key);
        }
        return (lotteryNumber + "|" + this.FormatLuckLotteryNumber(LotteryID, lotteryNumber));
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string InitLuckLotteryNumber(int LotteryID)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin-top: 10px;\">").AppendLine("<tr>").AppendLine("<td height=\"22\" align=\"center\">").AppendLine("&nbsp;</td>");
        for (int i = 0; i < NumberCount[LotteryID][0]; i++)
        {
            builder.AppendLine("<td align=\"center\">").AppendLine("<table width=\"22\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" background=\"Home/Room/images/ssq_bg_td.jpg\">").AppendLine("<tr>").AppendLine("<td height=\"22\" align=\"center\" class=\"red12\" id='tdLuckNumber" + i.ToString() + "'>").AppendLine("-").AppendLine("</td></tr></table></td>");
        }
        for (int j = 0; j < NumberCount[LotteryID][1]; j++)
        {
            int num3 = NumberCount[LotteryID][0] + j;
            builder.AppendLine("<td align=\"center\">").AppendLine("<table width=\"22\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" background=\"Home/Room/images/ssq_bg_td.jpg\">").AppendLine("<tr>").AppendLine("<td height=\"22\" align=\"center\" class=\"blue12\" id='tdLuckNumber" + num3.ToString() + "'>").AppendLine("-").AppendLine("</td></tr></table></td>");
        }
        builder.AppendLine("<td>&nbsp;</td>").AppendLine("</tr>").AppendLine("</table>");
        return builder.ToString();
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
        AjaxPro.Utility.RegisterTypeForAjax(typeof(LotteryPackage), this.Page);
        if (!base.IsPostBack)
        {
            if (base._User == null)
            {
                this.NoLogin.Visible = true;
                this.Login.Visible = false;
            }
            else
            {
                this.NoLogin.Visible = false;
                this.Login.Visible = true;
            }
            this.HidLotteryID.Value = Shove._Web.Utility.GetRequest("LotteryID");
            if ((this.HidLotteryID.Value == "") || (((this.HidLotteryID.Value != "5") && (this.HidLotteryID.Value != "6")) && (this.HidLotteryID.Value != "39")))
            {
                this.HidLotteryID.Value = "5";
            }
            this.HidType.Value = Shove._Web.Utility.GetRequest("Type");
            if (((this.HidType.Value == "") || (_Convert.StrToInt(this.HidType.Value, 0) > 4)) || (_Convert.StrToInt(this.HidType.Value, 0) < 1))
            {
                this.HidType.Value = "4";
            }
            this.BindUsers();
        }
    }

    private string[] SplitLotteryNumber(string Number)
    {
        string[] strArray = Number.Split(new char[] { '\n' });
        if (strArray.Length == 0)
        {
            return null;
        }
        for (int i = 0; i < strArray.Length; i++)
        {
            strArray[i] = strArray[i].Trim();
        }
        return strArray;
    }

    [AjaxMethod(HttpSessionStateRequirement.Read)]
    public string SplitScheme(string LotteryNumber, int LotteryID)
    {
        Lottery lottery = new Lottery();
        string canonicalNumber = "";
        string[] strArray = lottery[LotteryID].ToSingle(LotteryNumber, ref canonicalNumber, (LotteryID * 100) + 1);
        if ((strArray == null) || (strArray.Length < 1))
        {
            return "";
        }
        LotteryNumber = "";
        foreach (string str2 in strArray)
        {
            LotteryNumber = LotteryNumber + str2 + ",";
        }
        int length = strArray.Length;
        return (LotteryNumber + length.ToString());
    }
}

