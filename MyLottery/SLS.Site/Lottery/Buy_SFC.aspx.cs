using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SLS.Site.App_Code;
using System.Web.SessionState;
using AjaxPro;
using Shove;
using SLS.Site.App_Code.DAL;
using System.Text;
using System.Xml;
using Shove._Web;
using Shove._IO;
using Shove._Security;
using Shove.Database;

namespace SLS.Site.Lottery
{
    public partial class Buy_SFC : RoomPageBase, IRequiresSessionState
    {
        public string DZ = "";

        public int LotteryID;
        public string LotteryName;
        public int Number = 3;
        public string script = "";


        [AjaxMethod(HttpSessionStateRequirement.Read)]
        public string AnalyseScheme(string Content, string LotteryID, int PlayTypeID)
        {
            return new SLS.Lottery()[_Convert.StrToInt(LotteryID, 0)].AnalyseScheme(Content, PlayTypeID).Trim();
        }

        private void BindDataForAliBuy(long BuyID)
        {
            DataTable table = new Tables.T_AlipayBuyTemp().Open("", "ID=" + BuyID.ToString(), "");
            if ((table != null) && (table.Rows.Count != 0))
            {
                DataRow row = table.Rows[0];
                string s = row["IsuseID"].ToString();
                string str2 = row["PlayTypeID"].ToString();
                bool flag = _Convert.StrToBool(row["IsCoBuy"].ToString(), false);
                string str3 = row["Share"].ToString();
                string str4 = row["BuyShare"].ToString();
                string str5 = row["AssureShare"].ToString();
                string str6 = row["OpenUsers"].ToString();
                string str7 = row["Title"].ToString();
                string str8 = row["Description"].ToString();
                string str9 = row["SecrecyLevel"].ToString();
                string str10 = row["LotteryNumber"].ToString();
                string str11 = row["SumMoney"].ToString();
                string str12 = row["AssureMoney"].ToString();
                string str13 = row["LotteryID"].ToString();
                string str14 = row["Multiple"].ToString();
                if (str14 == "")
                {
                    str14 = "1";
                }
                double num = 0.0;
                int num2 = 0;
                int num3 = 0;
                double num4 = 0.0;
                int num5 = 0;
                short num6 = 0;
                int playType = 0;
                int num8 = 0;
                try
                {
                    num = double.Parse(str11);
                    num2 = int.Parse(str3);
                    num3 = int.Parse(str4);
                    num4 = double.Parse(str12);
                    num5 = int.Parse(str14);
                    num6 = short.Parse(str9);
                    playType = int.Parse(str2);
                    num8 = int.Parse(str13);
                    long.Parse(s);
                }
                catch
                {
                }
                if ((num3 == num2) && (num4 == 0.0))
                {
                    num2 = 1;
                    num3 = 1;
                }
                double num1 = num / ((double)num2);
                string str15 = str10;
                if (!string.IsNullOrEmpty(str15) && (str15[str15.Length - 1] == '\n'))
                {
                    str15 = str15.Substring(0, str15.Length - 1);
                }
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("<script type='text/javascript' defer='defer'>");
                builder.Append("$Id('playType").Append(playType.ToString()).AppendLine("').checked = true;");
                builder.AppendLine("clickPlayType('" + playType.ToString() + "');");
                builder.AppendLine("function BindDataForFromAli(){");
                str15 = str15.Replace("\r", "");
                int num9 = 0;
                string canonicalNumber = "";
                foreach (string str17 in str15.Split(new char[] { '\n' }))
                {
                    if (!string.IsNullOrEmpty(str17))
                    {
                        num9 += new SLS.Lottery()[num8].ToSingle(str17, ref canonicalNumber, playType).Length;
                        builder.AppendLine("var option = document.createElement('option');");
                        builder.AppendLine("$Id('list_LotteryNumber').options.add(option);");
                        builder.Append("option.innerText = '").Append(str17).AppendLine("';");
                        builder.Append("option.value = '").Append(str17).AppendLine("';");
                    }
                }
                if (flag)
                {
                    builder.AppendLine("$Id('CoBuy').checked = true;");
                    builder.AppendLine("oncbInitiateTypeClick();");
                }
                builder.Append("$Id('tb_LotteryNumber').value = '").Append(str10.Replace("\r", @"\r").Replace("\n", @"\n")).AppendLine("';");
                builder.Append("$Id('tb_Share').value = '").Append(str3).AppendLine("';");
                builder.Append("$Id('tb_BuyShare').value = '").Append(str4).AppendLine("';");
                builder.Append("$Id('tb_AssureShare').value = '").Append(str5).AppendLine("';");
                builder.Append("$Id('tb_OpenUserList').value = '").Append(str6).AppendLine("';");
                builder.Append("$Id('tb_Title').value = '").Append(str7).AppendLine("';");
                builder.Append("$Id('tb_Description').value = '").Append(str8.Replace("\r", @"\r").Replace("\n", @"\n")).AppendLine("';");
                builder.Append("$Id('SecrecyLevel").Append(num6.ToString()).AppendLine("').checked = true;");
                builder.Append("$Id('tb_hide_SumMoney').value = '").Append(str11).AppendLine("';");
                builder.Append("$Id('tb_hide_AssureMoney').value = '").Append(num4.ToString("N0")).AppendLine("';");
                builder.Append("$Id('tb_Multiple').value = '").Append(num5.ToString()).AppendLine("';");
                builder.Append("$Id('lab_AssureMoney').innerText = '").Append(num4.ToString("N0")).AppendLine("';");
                builder.Append("$Id('lab_SumMoney').innerText = '").Append(num.ToString("N0")).AppendLine("';");
                builder.Append("$Id('lab_Num').innerText = '").Append(num9.ToString()).AppendLine("';");
                builder.Append("$Id('tb_SchemeMoney').value = '").Append(num.ToString()).AppendLine("';");
                builder.AppendLine("CalcResult();");
                builder.AppendLine("}");
                if (str2.Length != (num8.ToString().Length + 2))
                {
                    builder.AppendLine("BindDataForFromAli()");
                }
                builder.AppendLine("</script>");
                this.script = builder.ToString();
            }
        }

        private string BindWinList(DataTable dt)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<tr>").Append("<td width='8%' height='25' bgcolor='#E8E8E8'>").Append("</td>").Append("<td width='31%' bgcolor='#E8E8E8'>").Append("用户名").Append("</td>").Append("<td width='30%' bgcolor='#E8E8E8'>").Append("奖金").Append("</td>").Append("<td width='13%' bgcolor='#E8E8E8'>").Append("跟单").Append("</td>").Append("</tr>");
            int num = 0;
            foreach (DataRow row in dt.Rows)
            {
                num++;
                string str = row["InitiateName"].ToString();
                str = (str.Length > 5) ? (str.Substring(0, 4) + "*") : str;
                builder.Append("<tr><td height='25'><img src='../Home/Room/Images/num_").Append(num.ToString()).Append(".gif'/></td><td class='black12' title='" + row["InitiateName"].ToString() + "'>").Append(string.Concat(new object[] { "<a href='../Home/Web/Score.aspx?id=", row["InitiateUserID"].ToString(), "&LotteryID=", this.LotteryID, "'target='_blank'>" })).Append(str).Append("</a>").Append("</td><td class='black12'>").Append(_Convert.StrToDouble(row["Win"].ToString(), 0.0).ToString("N0")).Append("</td><td class='red12_2'><a href='javascript:;' onclick=\"if(CreateLogin()){followScheme(" + this.LotteryID + ");$Id('iframeFollowScheme').src='").Append("../Home/Room/FollowFriendSchemeAdd.aspx?LotteryID=").Append(this.LotteryID.ToString()).Append("&FollowUserID=").Append(row["InitiateUserID"].ToString()).Append("&FollowUserName=").Append(HttpUtility.UrlEncode(row["InitiateName"].ToString())).Append("'}\">定制</a></td></tr>");
            }
            return builder.ToString();
        }

        protected void btn_OK_Click(object sender, EventArgs e)
        {
            if (!PF.IsSystemRegister())
            {
                PF.GoError(4, "请联系网站管理员输入软件序列号", base.GetType().BaseType.FullName);
            }
            else
            {
                this.Buy(base._User);
            }
        }

        private void Buy(Users _User)
        {
            string request = Shove._Web.Utility.GetRequest("HidIsuseID");
            string str2 = Shove._Web.Utility.GetRequest("HidIsuseEndTime");
            string str3 = Shove._Web.Utility.GetRequest("playType");
            Shove._Web.Utility.GetRequest("CoBuy");
            string s = Shove._Web.Utility.GetRequest("tb_Share");
            string str5 = Shove._Web.Utility.GetRequest("tb_BuyShare");
            Shove._Web.Utility.GetRequest("tb_AssureShare");
            string str6 = Shove._Web.Utility.GetRequest("tb_OpenUserList");
            string str7 = Shove._Web.Utility.GetRequest("tb_Title");
            string str8 = Shove._Web.Utility.GetRequest("tb_Description");
            string str9 = Shove._Web.Utility.GetRequest("SecrecyLevel");
            string str10 = Shove._Web.Utility.FilteSqlInfusion(base.Request["tb_LotteryNumber"]);
            string str11 = Shove._Web.Utility.GetRequest("tb_hide_SumMoney");
            string str12 = Shove._Web.Utility.GetRequest("tb_hide_AssureMoney");
            string str13 = Shove._Web.Utility.GetRequest("tb_hide_SumNum");
            string str14 = Shove._Web.Utility.GetRequest("HidLotteryID");
            string str15 = Shove._Web.Utility.GetRequest("tb_Multiple");
            string str16 = Shove._Web.Utility.GetRequest("tb_SchemeBonusScale");
            string str17 = Shove._Web.Utility.GetRequest("tbPlayTypeID");
            string str18 = Shove._Web.Utility.GetRequest("tb_SchemeMoney");
            int num = 2;
            if (str15 == "")
            {
                str15 = "1";
            }
            double money = 0.0;
            int share = 0;
            int buyShare = 0;
            double assureMoney = 0.0;
            int multiple = 0;
            int num7 = 0;
            short num8 = 0;
            int playType = 0;
            int num10 = 0;
            long isuseID = 0L;
            double schemeBonusScale = 0.0;
            try
            {
                money = double.Parse(str11);
                share = int.Parse(s);
                buyShare = int.Parse(str5);
                assureMoney = double.Parse(str12);
                multiple = int.Parse(str15);
                num7 = int.Parse(str13);
                num8 = short.Parse(str9);
                playType = int.Parse(str17);
                num10 = int.Parse(str14);
                isuseID = long.Parse(request);
                schemeBonusScale = double.Parse(str16);
            }
            catch
            {
                JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
                return;
            }
            if (str17 != str3)
            {
                money = double.Parse(str18);
            }
            if ((money > 0.0) && ((num7 >= 1) || !(str17 == str3)))
            {
                if (assureMoney < 0.0)
                {
                    JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
                }
                else if (share < 1)
                {
                    JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
                }
                else
                {
                    if ((buyShare == share) && (assureMoney == 0.0))
                    {
                        share = 1;
                        buyShare = 1;
                    }
                    if ((money / ((double)share)) < 1.0)
                    {
                        JavaScript.Alert(this.Page, "每份金额最低不能少于 1 元。");
                    }
                    else
                    {
                        double num13 = (buyShare * (money / ((double)share))) + assureMoney;
                        if (num13 > _User.Balance)
                        {
                            this.SaveDataForAliBuy();
                        }
                        else if (num13 > 10000000.0)
                        {
                            JavaScript.Alert(this.Page, "投注金额不能大于" + 0x989680.ToString() + "，谢谢。");
                        }
                        else if (multiple > 0x3e7)
                        {
                            JavaScript.Alert(this.Page, "投注倍数不能大于 999 倍，谢谢。");
                        }
                        else if ((schemeBonusScale < 0.0) && (schemeBonusScale > 10.0))
                        {
                            JavaScript.Alert(this.Page, "佣金比例只能在0~10之间");
                        }
                        else if ((schemeBonusScale.ToString().IndexOf("-") > -1) || (schemeBonusScale.ToString().IndexOf(".") > -1))
                        {
                            JavaScript.Alert(this.Page, "佣金比例输入有误");
                        }
                        else
                        {
                            schemeBonusScale /= 100.0;
                            string number = str10;
                            if (str17 == str3)
                            {
                                if (number[number.Length - 1] == '\n')
                                {
                                    number = number.Substring(0, number.Length - 1);
                                }
                                SLS.Lottery lottery = new SLS.Lottery();
                                string[] strArray = this.SplitLotteryNumber(number);
                                if ((strArray == null) || (strArray.Length < 1))
                                {
                                    JavaScript.Alert(this.Page, "选号发生异常，请重新选择号码投注，谢谢。(-694)");
                                    return;
                                }
                                int num15 = 0;
                                foreach (string str20 in strArray)
                                {
                                    string str21 = lottery[num10].AnalyseScheme(str20, playType);
                                    if (!string.IsNullOrEmpty(str21))
                                    {
                                        string[] strArray3 = str21.Split(new char[] { '|' });
                                        if ((strArray3 != null) && (strArray3.Length >= 1))
                                        {
                                            num15 += _Convert.StrToInt(strArray3[strArray3.Length - 1], 0);
                                        }
                                    }
                                }
                                if (num15 != num7)
                                {
                                    JavaScript.Alert(this.Page, "选号发生异常，请重新选择号码投注，谢谢。");
                                    return;
                                }
                            }
                            string returnDescription = "";
                            if (DateTime.Now >= _Convert.StrToDateTime(str2.Replace("/", "-"), DateTime.Now.AddDays(-1.0).ToString()))
                            {
                                JavaScript.Alert(this.Page, "本期投注已截止，谢谢。");
                            }
                            else if ((str3 == str17) && (((num * num7) * multiple) != money))
                            {
                                JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
                            }
                            else
                            {
                                long num17 = _User.InitiateScheme(isuseID, playType, (str7.Trim() == "") ? "(无标题)" : str7.Trim(), str8.Trim(), number, "", multiple, money, assureMoney, share, buyShare, str6.Trim(), short.Parse(num8.ToString()), schemeBonusScale, ref returnDescription);
                                if (num17 < 0L)
                                {
                                    PF.GoError(1, returnDescription, base.GetType().FullName + "(-755)");
                                }
                                else
                                {
                                    Shove._Web.Cache.ClearCache("Home_Room_CoBuy_BindDataForType" + isuseID.ToString());
                                    Shove._Web.Cache.ClearCache("Home_Room_SchemeAll_BindData" + isuseID.ToString());
                                    if ((money > 50.0) && (share > 1))
                                    {
                                        Shove._Web.Cache.ClearCache("Home_Room_JoinAllBuy_BindData");
                                    }
                                    base.Response.Redirect("../Home/Room/UserBuySuccess.aspx?LotteryID=" + num10.ToString() + "&&Money=" + num13.ToString() + "&SchemeID=" + num17.ToString());
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
            }
        }

        private string FormatWinNumber(string winNumber)
        {
            StringBuilder builder = new StringBuilder();
            if (winNumber.Length > 0)
            {
                builder.Append("</td><td align='left' class='red14'>").Append(winNumber);
            }
            return builder.ToString();
        }

        [AjaxMethod(HttpSessionStateRequirement.None)]
        public string GetAddone(int LotteryID, string IsuseID)
        {
            string str = "";
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("DataCache_SFC");
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                cacheAsDataTable = new Tables.T_IsuseForSFC().Open(" top 14 * ", "IsuseID = " + IsuseID, "[No]");
                if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count != 14))
                {
                    return "";
                }
                Shove._Web.Cache.SetCache("DataCache_SFC", cacheAsDataTable, 300);
            }
            for (int i = 0; i < cacheAsDataTable.Rows.Count; i++)
            {
                string str2 = str;
                str = str2 + cacheAsDataTable.Rows[i]["HostTeam"].ToString().Trim() + "," + cacheAsDataTable.Rows[i]["QuestTeam"].ToString().Trim() + "," + cacheAsDataTable.Rows[i]["DateTime"].ToString();
                if (i < (cacheAsDataTable.Rows.Count - 1))
                {
                    str = str + ";";
                }
            }
            return str;
        }

        [AjaxMethod(HttpSessionStateRequirement.None)]
        public string GetIsuseInfo(int LotteryID)
        {
            try
            {
                DataTable isusesInfo = DataCache.GetIsusesInfo(LotteryID);
                string str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                DataRow[] rowArray = isusesInfo.Select("'" + str + "' > StartTime and '" + str + "' < EndTime", "EndTime desc");
                DataRow[] rowArray2 = isusesInfo.Select("EndTime < '" + str + "' and WinLotteryNumber<>''", "EndTime desc");
                if ((rowArray.Length == 0) && (rowArray2.Length == 0))
                {
                    return "";
                }
                if (rowArray.Length == 0)
                {
                    rowArray = isusesInfo.Select("EndTime < '" + str + "'", "EndTime desc");
                }
                if (rowArray2.Length == 0)
                {
                    rowArray2 = rowArray;
                }
                int num = _Convert.StrToInt(rowArray[0]["ID"].ToString(), -1);
                string str3 = rowArray[0]["Name"].ToString();
                int num2 = DataCache.LotteryEndAheadMinute[LotteryID];
                string str4 = Convert.ToDateTime(rowArray[0]["EndTime"]).AddMinutes((double)(num2 * -1)).ToString("yyyy/MM/dd HH:mm:ss");
                string str5 = rowArray2[0]["Name"].ToString();
                string winNumber = rowArray2[0]["WinLotteryNumber"].ToString().Trim();
                winNumber = this.FormatWinNumber(winNumber);
                StringBuilder builder = new StringBuilder();
                builder.Append(num.ToString()).Append(",").Append(str3).Append(",").Append(str4).Append("|<table cellspacing='5' cellpadding='0' style='text-align: center; font-weight: bold;'><tr><td align='left'  height='25' class='hui12'>").Append(str5).Append("&nbsp;期开奖:&nbsp;&nbsp;&nbsp;&nbsp;").Append(winNumber).Append("</td></tr>");
                string totalMoneySFC = this.GetTotalMoneySFC(num.ToString());
                if (totalMoneySFC != "")
                {
                    double d = _Convert.StrToDouble(totalMoneySFC, 0.0) / 5000000.0;
                    double num4 = Math.Floor(d);
                    builder.Append("<tr style='font-weight:normal;'><td colspan='2' align='left'><span class=\"hui12\">奖池累积奖金已达</span><span class='red12' style='font-weight: bold;'>" + totalMoneySFC + "</span><span class=\"hui12\">元</span>");
                    if (num4 > 0.0)
                    {
                        builder.Append("<span class=\"hui12\">，可开出</span><span class='red12' style='font-weight: bold;'>" + num4 + "</span><span class=\"hui12\">个足额500万</span>");
                    }
                    builder.Append("</td></tr>");
                }
                builder.Append("</table>");
                return builder.ToString();
            }
            catch (Exception exception)
            {
                new Log("TWZT").Write(base.GetType() + exception.Message);
                return exception.Message;
            }
        }

        [AjaxMethod(HttpSessionStateRequirement.None)]
        public string GetNewsInfo(int LotteryID)
        {
            return DataCache.GetLotteryNews(LotteryID);
        }

        [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
        public string GetSchemeBonusScalec(int lotteryId)
        {
            DataTable table = new Tables.T_Sites().Open("Opt_InitiateSchemeBonusScale,Opt_InitiateSchemeLimitLowerScaleMoney,Opt_InitiateSchemeLimitLowerScale,Opt_InitiateSchemeLimitUpperScaleMoney,Opt_InitiateSchemeLimitUpperScale", "", "");
            string str = (_Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeBonusScale"].ToString(), 0.0) * 100.0).ToString();
            string str2 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitLowerScaleMoney"].ToString(), 100.0).ToString();
            string str3 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitLowerScale"].ToString(), 0.2).ToString();
            string str4 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitUpperScaleMoney"].ToString(), 10000.0).ToString();
            string str5 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitUpperScale"].ToString(), 0.05).ToString();
            string str6 = DataCache.Lotteries[lotteryId];
            int num6 = 0;
            return (str + "|" + str2 + "|" + str3 + "|" + str4 + "|" + str5 + "|" + lotteryId.ToString() + "|" + str6 + "|" + num6.ToString());
        }

        [AjaxMethod(HttpSessionStateRequirement.None)]
        public string GetSysTime()
        {
            return _Convert.StrToDateTime(new Views.V_GetDate().Open("", "", "").Rows[0]["Now"].ToString(), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")).ToString("yyyy/MM/dd HH:mm:ss");
        }

        private string GetTotalMoneySFC(string IsuseID)
        {
            string str = "";
            string key = "Home_Room_Buy_GetTotalMoneySFC_" + IsuseID;
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = new Tables.T_TotalMoney().Open("", "IsuseID=" + IsuseID, "");
                if (cacheAsDataTable == null)
                {
                    new Log("System").Write(base.GetType().FullName + "数据库繁忙，请重试(GetTotalMoneySFC)");
                    return "";
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 120);
            }
            if (cacheAsDataTable.Rows.Count > 0)
            {
                str = cacheAsDataTable.Rows[0]["TotalMoney"].ToString();
            }
            return str;
        }

        private string GetWinListHM(int LotteryID, int Number)
        {
            string key = "Home_Room_Buy_ZC_GetWinListHM_" + LotteryID.ToString() + Number.ToString();
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            cacheAsDataTable = null;
            if (cacheAsDataTable == null)
            {
                string commandText = "";
                if (LotteryID == 1)
                {
                    if (Number == 1)
                    {
                        commandText = "select top 8 b.ID,IsuseID,LotteryID ,InitiateUserID ,InitiateName, Money ,Schedule from T_SchemeSupperCobuy a inner join V_Schemes b on a.SchemeID = b.ID and TypeState = 2 and IsuseID=(select top 1 ID from T_Isuses where LotteryID =" + LotteryID.ToString() + " and GETDATE() between StartTime and EndTime and Schedule<100 order by IsuseID desc) and (PlayTypeID = 103 or  PlayTypeID = 104) and QuashStatus = 0 order by AtTopStatus desc,Money desc";
                    }
                    else
                    {
                        commandText = "select top 8 b.ID,IsuseID,LotteryID ,InitiateUserID ,InitiateName, Money ,Schedule from T_SchemeSupperCobuy a inner join V_Schemes b on a.SchemeID = b.ID and TypeState = 2 and IsuseID=(select top 1 ID from T_Isuses where LotteryID =" + LotteryID.ToString() + " and GETDATE() between StartTime and EndTime and Schedule<100 order by IsuseID desc) and (PlayTypeID = 101 or  PlayTypeID = 102) and QuashStatus = 0 order by AtTopStatus desc,Money desc";
                    }
                }
                else
                {
                    commandText = "select top 8 b.ID,IsuseID,LotteryID ,InitiateUserID ,InitiateName, Money ,Schedule from T_SchemeSupperCobuy a inner join V_Schemes b on a.SchemeID = b.ID and TypeState = 2 and IsuseID=(select top 1 ID from T_Isuses where LotteryID =" + LotteryID.ToString() + " and GETDATE() between StartTime and EndTime and Schedule<100 order by IsuseID desc) and QuashStatus = 0 order by AtTopStatus desc,Money desc";
                }
                cacheAsDataTable = MSSQL.Select(commandText, new MSSQL.Parameter[0]);
                if (cacheAsDataTable == null)
                {
                    new Log("TWZT").Write("GetWinListHM方法出错!");
                    return "";
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 600);
            }
            StringBuilder builder = new StringBuilder();
            foreach (DataRow row in cacheAsDataTable.Rows)
            {
                string str3 = row["InitiateName"].ToString();
                str3 = (str3.Length > 5) ? (str3.Substring(0, 4) + "*") : str3;
                builder.Append("<tr><td class='black12' title='" + row["InitiateName"].ToString() + "'>").Append(string.Concat(new object[] { "<a href='../Home/Web/Score.aspx?id=", row["InitiateUserID"].ToString(), "&LotteryID=", LotteryID, "'target='_blank'>" })).Append(str3).Append("</a>").Append("</td><td class='black12'>").Append(_Convert.StrToDouble(row["Money"].ToString(), 0.0).ToString("N0")).Append("</td><td class='black12'>").Append(_Convert.StrToDouble(row["Schedule"].ToString(), 0.0)).Append("%").Append("</td><td class='red12_2'><a target='_blank' href='").Append("../Home/Room/Scheme.aspx?LotteryID=").Append(LotteryID.ToString()).Append("&ID=").Append(row["ID"].ToString()).Append("'}\">入伙</a></td></tr>");
            }
            return builder.ToString();
        }

        [AjaxMethod(HttpSessionStateRequirement.None)]
        public string GetZCExpertList(int lotteryID)
        {
            DataTable zCExpertList = DataCache.GetZCExpertList(lotteryID);
            StringBuilder builder = new StringBuilder();
            if ((zCExpertList != null) && (zCExpertList.Rows.Count > 0))
            {
                int num = 1;
                foreach (DataRow row in zCExpertList.Rows)
                {
                    string str = row["UserName"].ToString();
                    str = (str.Length > 6) ? (str.Substring(0, 5) + "*") : str;
                    builder.AppendLine("<tr align=\"center\">").AppendLine("<td  height=\"22\"  bgcolor=\"#FFFFFF\" class=\"black12\"  title='" + row["UserName"].ToString() + "'>").Append("<a href='../Home/Web/Score.aspx?id=").Append(row["UserID"].ToString()).Append("&LotteryID=").Append(lotteryID + "' target='_blank'>").AppendLine(str).Append("</a>").AppendLine("</td>").AppendLine("<td  align=\"center\" bgcolor=\"#FFFFFF\" class=\"black12\">").AppendLine(row["LotteryName"].ToString()).Append("</td>").Append("<td bgcolor=\"#FFFFFF\" class='red12_2'><a href='javascript:;' onclick=\"if(CreateLogin()){followScheme(" + this.LotteryID + ");$Id('iframeFollowScheme').src='").Append("../Home/Room/FollowFriendSchemeAdd.aspx?LotteryID=").Append(lotteryID).Append("&FollowUserID=").Append(row["UserID"]).Append("&FollowUserName=").Append(row["UserName"].ToString()).Append("'}\">定制</a></td></tr>");
                    if (((num % 10) == 0) && (num != zCExpertList.Rows.Count))
                    {
                        builder.Append("|");
                    }
                    num++;
                }
            }
            else
            {
                builder.AppendLine("<tr>").AppendLine("<td colspan=\"3\" height=\"22\" align=\"center\" bgcolor=\"#FFFFFF\" class=\"blue12\">").AppendLine("<span style=\"color:red;\">暂无数据</span>").AppendLine("</td>");
            }
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
            AjaxPro.Utility.RegisterTypeForAjax(this.GetType(), this.Page);
            this.LotteryID = 1;
            bool flag = false;
            string cacheAsString = Shove._Web.Cache.GetCacheAsString("Site_UseLotteryList" + base._Site.ID, "");
            string[] strArray = null;
            if (cacheAsString == "")
            {
                cacheAsString = Functions.F_GetUsedLotteryList(base._Site.ID);
                if (cacheAsString != "")
                {
                    Shove._Web.Cache.SetCache("Site_UseLotteryList" + base._Site.ID, cacheAsString);
                }
            }
            strArray = cacheAsString.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if (this.LotteryID.ToString().Equals(strArray[i]))
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                base.Response.Redirect("../Default.aspx");
            }
            this.hlAgreement.NavigateUrl = "../Home/Room/BuyProtocol.aspx?LotteryID=" + this.LotteryID;
            this.LotteryName = DataCache.Lotteries[this.LotteryID];
            if (!base.IsPostBack)
            {
                long buyID = _Convert.StrToLong(Shove._Web.Utility.GetRequest("BuyID"), -1L);
                if (buyID > 0L)
                {
                    this.BindDataForAliBuy(buyID);
                }
                this.tbSFC.InnerHtml = this.GetWinListHM(1, 0);
                this.tbRJC.InnerHtml = this.GetWinListHM(1, 1);
                this.tbJQC.InnerHtml = this.GetWinListHM(2, 0);
                this.tbLCJQC.InnerHtml = this.GetWinListHM(15, 0);
                this.tbWin1.InnerHtml = this.BindWinList(DataCache.GetWinInfo(this.LotteryID));
                this.DZ = Encrypt.UnEncryptString(PF.GetCallCert(), Shove._Web.Utility.GetRequest("DZ"));
            }
        }

        private void SaveDataForAliBuy()
        {
            string request = Shove._Web.Utility.GetRequest("HidIsuseID");
            Shove._Web.Utility.GetRequest("HidIsuseEndTime");
            string str2 = Shove._Web.Utility.GetRequest("playType");
            string str3 = Shove._Web.Utility.GetRequest("Cobuy");
            string str4 = Shove._Web.Utility.GetRequest("tb_Share");
            string str5 = Shove._Web.Utility.GetRequest("tb_BuyShare");
            string str6 = Shove._Web.Utility.GetRequest("tb_AssureShare");
            string str7 = Shove._Web.Utility.GetRequest("tb_OpenUserList");
            string str8 = Shove._Web.Utility.GetRequest("tb_Title");
            string str9 = Shove._Web.Utility.GetRequest("tb_Description");
            string str10 = Shove._Web.Utility.GetRequest("SecrecyLevel");
            string str11 = Shove._Web.Utility.FilteSqlInfusion(base.Request["tb_LotteryNumber"]);
            string str12 = Shove._Web.Utility.GetRequest("tb_hide_SumMoney");
            string str13 = Shove._Web.Utility.GetRequest("tb_hide_AssureMoney");
            Shove._Web.Utility.GetRequest("tb_hide_SumNum");
            string str14 = Shove._Web.Utility.GetRequest("HidLotteryID");
            string str15 = Shove._Web.Utility.GetRequest("tb_Multiple");
            string str16 = Shove._Web.Utility.GetRequest("tbPlayTypeID");
            string str17 = Shove._Web.Utility.GetRequest("tb_SchemeMoney");
            if (str15 == "")
            {
                str15 = "1";
            }
            Tables.T_AlipayBuyTemp temp = new Tables.T_AlipayBuyTemp
            {
                SiteID = { Value = 1 },
                UserID = { Value = -1 }
            };
            if (str16 == str2)
            {
                temp.Money.Value = str12;
            }
            else
            {
                temp.Money.Value = str17;
            }
            temp.HandleResult.Value = 0;
            temp.IsCoBuy.Value = str3 == "2";
            temp.LotteryID.Value = str14;
            temp.IsuseID.Value = request;
            temp.PlayTypeID.Value = str2;
            temp.Title.Value = str8;
            temp.Description.Value = str9;
            temp.LotteryNumber.Value = str11;
            temp.UpdateloadFileContent.Value = "";
            temp.Multiple.Value = str15;
            temp.BuyMoney.Value = str5;
            temp.SumMoney.Value = str12;
            temp.AssureMoney.Value = str13;
            temp.Share.Value = str4;
            temp.BuyShare.Value = str5;
            temp.AssureShare.Value = str6;
            temp.OpenUsers.Value = str7;
            temp.SecrecyLevel.Value = str10;
            temp.Number.Value = this.Number;
            long num = temp.Insert();
            if (num < 0L)
            {
                new Log("System").Write("T_AlipayBuyTemp 数据库读写错误。");
            }
            JavaScript.Alert(this.Page, "您的账户余额不足，请先充值，谢谢。", "../Home/Room/OnlinePay/Default.aspx?BuyID=" + num.ToString());
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
    }
}
