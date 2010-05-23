using AjaxPro;
using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Web.UI;
using SLS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Lottery_Buy_SYYDJ : RoomPageBase, IRequiresSessionState
{
    public string DZ = "";
    public int LotteryID;
    public string LotteryName;
    public string script = "";

    [AjaxMethod(HttpSessionStateRequirement.Read)]
    public string AnalyseScheme(string Content, string LotteryID, int PlayTypeID)
    {
        return new Lottery()[_Convert.StrToInt(LotteryID, 0)].AnalyseScheme(Content, PlayTypeID).Trim();
    }

    private void BindDataForAliBuy(long BuyID)
    {
        DataTable table = new Tables.T_AlipayBuyTemp().Open("", "ID=" + BuyID.ToString(), "");
        if ((table != null) && (table.Rows.Count != 0))
        {
            DataRow row = table.Rows[0];
            string s = row["IsuseID"].ToString();
            string str2 = row["PlayTypeID"].ToString();
            bool flag = _Convert.StrToBool(row["IsChase"].ToString(), false);
            bool flag2 = _Convert.StrToBool(row["IsCoBuy"].ToString(), false);
            string str3 = row["Share"].ToString();
            string str4 = row["BuyShare"].ToString();
            string str5 = row["AssureShare"].ToString();
            string str6 = row["OpenUsers"].ToString();
            string str7 = row["Title"].ToString();
            string str8 = row["Description"].ToString();
            string str9 = row["StopwhenwinMoney"].ToString();
            string str10 = row["SecrecyLevel"].ToString();
            string str11 = row["LotteryNumber"].ToString();
            string str12 = row["SumMoney"].ToString();
            string str13 = row["AssureMoney"].ToString();
            string str14 = row["LotteryID"].ToString();
            string str15 = row["Multiple"].ToString();
            string xml = row["AdditionasXml"].ToString();
            if (str15 == "")
            {
                str15 = "1";
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
                num = double.Parse(str12);
                num2 = int.Parse(str3);
                num3 = int.Parse(str4);
                num4 = double.Parse(str13);
                num5 = int.Parse(str15);
                num6 = short.Parse(str10);
                playType = int.Parse(str2);
                num8 = int.Parse(str14);
                long.Parse(s);
                double.Parse(str9);
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
            if (flag)
            {
                double.Parse(str12);
            }
            string str17 = str11;
            if (str17[str17.Length - 1] == '\n')
            {
                str17 = str17.Substring(0, str17.Length - 1);
            }
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<script type='text/javascript' defer='defer'>");
            builder.AppendLine("function clickPlayClass(i,obj)").AppendLine("{").AppendLine("var tds = obj.offsetParent.rows[0].cells;").AppendLine("for(var a=0; a<tds.length-1; a++)").AppendLine("{").AppendLine("if(a%2==1)").AppendLine("{").AppendLine("tds[a].className = 'nsplay';").AppendLine("}").AppendLine("if($Id('playTypes' + String(a))!=null)").AppendLine("{").AppendLine("$Id('playTypes' + String(a)).style.display = 'none';").AppendLine("}").AppendLine("}").AppendLine("var pt = $Id('playTypes' + String(i));").AppendLine("pt.style.display = '';");
            builder.AppendLine("obj.className = 'msplay';").AppendLine("}");
            builder.Append("var playclass =").Append("$Id('playType").Append(playType.ToString()).AppendLine("').parentNode.id.substr(9,1);");
            builder.Append("clickPlayClass(playclass,").Append("$Id('tbPlayTypeMenu").Append(num8.ToString()).AppendLine("').rows[0].cells[playclass*2+1]);");
            builder.Append("$Id('playType").Append(playType.ToString()).AppendLine("').checked = true;");
            builder.AppendLine("clickPlayType('" + playType.ToString() + "');");
            builder.AppendLine("function BindDataForFromAli(){");
            if (flag)
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(xml);
                foreach (XmlNode node in document.ChildNodes[0].ChildNodes)
                {
                    builder.Append("$Id('times").Append(node.Attributes["IsuseID"].Value).Append("').value = '").Append(node.Attributes["Multiple"].Value).AppendLine("';");
                    builder.Append("$Id('money").Append(node.Attributes["IsuseID"].Value).Append("').value = '").Append(node.Attributes["Money"].Value).AppendLine("';");
                    builder.Append("$Id('check").Append(node.Attributes["IsuseID"].Value).AppendLine("').checked = true;");
                    builder.Append("$Id('times").Append(node.Attributes["IsuseID"].Value).AppendLine("').disabled = '';");
                }
            }
            str17 = str17.Replace("\r", "");
            int num9 = 0;
            string canonicalNumber = "";
            foreach (string str19 in str17.Split(new char[] { '\n' }))
            {
                num9 += new Lottery()[num8].ToSingle(str19, ref canonicalNumber, playType).Length;
                builder.AppendLine("var option = document.createElement('option');");
                builder.AppendLine("$Id('list_LotteryNumber').options.add(option);");
                builder.Append("option.innerText = '").Append(str19).AppendLine("';");
                builder.Append("option.value = '").Append(str19).AppendLine("';");
            }
            if (flag)
            {
                builder.AppendLine("$Id('Chase').checked = true;");
                builder.AppendLine("oncbInitiateTypeClick($Id('Chase'));");
            }
            if (flag2)
            {
                builder.AppendLine("$Id('CoBuy').checked = true;");
                builder.AppendLine("oncbInitiateTypeClick($Id('CoBuy'));");
            }
            builder.Append("$Id('tb_LotteryNumber').value = '").Append(str11.Replace("\r", @"\r").Replace("\n", @"\n")).AppendLine("';");
            builder.Append("$Id('tb_Share').value = '").Append(str3).AppendLine("';");
            builder.Append("$Id('tb_BuyShare').value = '").Append(str4).AppendLine("';");
            builder.Append("$Id('tb_AssureShare').value = '").Append(str5).AppendLine("';");
            builder.Append("$Id('tb_OpenUserList').value = '").Append(str6).AppendLine("';");
            builder.Append("$Id('tb_Title').value = '").Append(str7).AppendLine("';");
            builder.Append("$Id('tb_Description').value = '").Append(str8.Replace("\r", @"\r").Replace("\n", @"\n")).AppendLine("';");
            builder.Append("$Id('tbAutoStopAtWinMoney').value = '").Append(str9).AppendLine("';");
            builder.Append("$Id('SecrecyLevel").Append(num6.ToString()).AppendLine("').checked = true;");
            builder.Append("$Id('tb_hide_SumMoney').value = '").Append(str12).AppendLine("';");
            builder.Append("$Id('tb_hide_AssureMoney').value = '").Append(num4.ToString("N0")).AppendLine("';");
            builder.Append("$Id('tb_Multiple').value = '").Append(num5.ToString()).AppendLine("';");
            builder.Append("$Id('lab_AssureMoney').innerText = '").Append(num4.ToString("N0")).AppendLine("';");
            builder.Append("$Id('lab_SumMoney').innerText = '").Append(num.ToString("N0")).AppendLine("';");
            builder.Append("$Id('LbSumMoney').innerText = '").Append(num.ToString("N0")).AppendLine("';");
            builder.Append("$Id('lab_Num').innerText = '").Append(num9.ToString()).AppendLine("';");
            builder.AppendLine("CalcResult();");
            builder.AppendLine("}");
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
        this.Buy(base._User);
    }

    private void Buy(Users _User)
    {
        string request = Shove._Web.Utility.GetRequest("HidIsuseID");
        string str2 = Shove._Web.Utility.GetRequest("HidIsuseEndTime");
        string s = Shove._Web.Utility.GetRequest("tbPlayTypeID");
        string str4 = Shove._Web.Utility.GetRequest("Chase");
        Shove._Web.Utility.GetRequest("CoBuy");
        string str5 = Shove._Web.Utility.GetRequest("tb_Share");
        string str6 = Shove._Web.Utility.GetRequest("tb_BuyShare");
        Shove._Web.Utility.GetRequest("tb_AssureShare");
        string str7 = Shove._Web.Utility.GetRequest("tb_OpenUserList");
        string str8 = Shove._Web.Utility.GetRequest("tb_Title");
        string str9 = Shove._Web.Utility.GetRequest("tb_Description");
        string str10 = Shove._Web.Utility.GetRequest("tbAutoStopAtWinMoney");
        string str11 = Shove._Web.Utility.GetRequest("SecrecyLevel");
        string str12 = Shove._Web.Utility.FilteSqlInfusion(base.Request["tb_LotteryNumber"]);
        string str13 = Shove._Web.Utility.GetRequest("tb_hide_SumMoney");
        string str14 = Shove._Web.Utility.GetRequest("tb_hide_AssureMoney");
        string str15 = Shove._Web.Utility.GetRequest("tb_hide_SumNum");
        Shove._Web.Utility.GetRequest("HidIsuseCount");
        string str16 = Shove._Web.Utility.GetRequest("HidLotteryID");
        Shove._Web.Utility.GetRequest("HidIsAlipay");
        string str17 = Shove._Web.Utility.GetRequest("tb_Multiple");
        Shove._Web.Utility.GetRequest("HidIsuseName");
        Shove._Web.Utility.GetRequest("tbPlayTypeName");
        string str18 = Shove._Web.Utility.GetRequest("tb_hide_ChaseBuyedMoney");
        string str19 = Shove._Web.Utility.GetRequest("tb_SchemeBonusScale");
        string str20 = Shove._Web.Utility.GetRequest("tb_SchemeBonusScalec");
        int num = 2;
        if (str17 == "")
        {
            str17 = "1";
        }
        double money = 0.0;
        int share = 0;
        int buyShare = 0;
        double assureMoney = 0.0;
        int multiple = 0;
        int num7 = 0;
        short num8 = 0;
        int playType = 0;
        int lotteryID = 0;
        long isuseID = 0L;
        double stopWhenWinMoney = 0.0;
        double schemeBonusScale = 0.0;
        double schemeBonusScalec = 0.0;
        try
        {
            money = double.Parse(str13);
            share = int.Parse(str5);
            buyShare = int.Parse(str6);
            assureMoney = double.Parse(str14);
            multiple = int.Parse(str17);
            num7 = int.Parse(str15);
            num8 = short.Parse(str11);
            playType = int.Parse(s);
            lotteryID = int.Parse(str16);
            isuseID = long.Parse(request);
            stopWhenWinMoney = double.Parse(str10);
            schemeBonusScale = double.Parse(str19);
            schemeBonusScalec = double.Parse(str20);
        }
        catch
        {
            JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
            return;
        }
        if ((money > 0.0) && (num7 >= 1))
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
                    double num15 = (buyShare * (money / ((double)share))) + assureMoney;
                    if (str4 != "")
                    {
                        num15 = double.Parse(str18);
                    }
                    if (num15 > _User.Balance)
                    {
                        this.SaveDataForAliBuy();
                    }
                    else if (num15 > 10000000.0)
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
                    else if ((schemeBonusScalec < 0.0) && (schemeBonusScalec > 10.0))
                    {
                        JavaScript.Alert(this.Page, "佣金比例只能在0~10之间");
                    }
                    else if ((schemeBonusScalec.ToString().IndexOf("-") > -1) || (schemeBonusScalec.ToString().IndexOf(".") > -1))
                    {
                        JavaScript.Alert(this.Page, "佣金比例输入有误");
                    }
                    else
                    {
                        schemeBonusScale /= 100.0;
                        schemeBonusScalec /= 100.0;
                        string number = str12;
                        if (number[number.Length - 1] == '\n')
                        {
                            number = number.Substring(0, number.Length - 1);
                        }
                        Lottery lottery = new Lottery();
                        string[] strArray = this.SplitLotteryNumber(number);
                        if ((strArray == null) || (strArray.Length < 1))
                        {
                            JavaScript.Alert(this.Page, "选号发生异常，请重新选择号码投注，谢谢。(-694)");
                        }
                        else
                        {
                            int num17 = 0;
                            foreach (string str22 in strArray)
                            {
                                string str23 = lottery[lotteryID].AnalyseScheme(str22, playType);
                                if (!string.IsNullOrEmpty(str23))
                                {
                                    string[] strArray3 = str23.Split(new char[] { '|' });
                                    if ((strArray3 != null) && (strArray3.Length >= 1))
                                    {
                                        num17 += _Convert.StrToInt(strArray3[strArray3.Length - 1], 0);
                                    }
                                }
                            }
                            if (num17 != num7)
                            {
                                JavaScript.Alert(this.Page, "选号发生异常，请重新选择号码投注，谢谢。");
                            }
                            else
                            {
                                StringBuilder builder = new StringBuilder();
                                int num19 = 0;
                                string detailXML = "";
                                string returnDescription = "";
                                if (str4 == "1")
                                {
                                    foreach (string str26 in base.Request.Form.AllKeys)
                                    {
                                        if (str26.IndexOf("check") > -1)
                                        {
                                            int num20 = _Convert.StrToInt(str26.Replace("check", ""), -1);
                                            if (num20 > 0)
                                            {
                                                num19++;
                                                int num21 = (_Convert.StrToInt(base.Request.Form["tb_hide_SumNum"], -1) * num) * _Convert.StrToInt(base.Request.Form["times" + num20.ToString()], -1);
                                                builder.Append(base.Request.Form[str26]).Append(",").Append(base.Request.Form["times" + num20.ToString()]).Append(",").Append(num21.ToString()).Append(";");
                                            }
                                        }
                                    }
                                    if (builder.Length > 0)
                                    {
                                        builder.Remove(builder.Length - 1, 1);
                                    }
                                    if (number[number.Length - 1] == '\n')
                                    {
                                        number = number.Substring(0, number.Length - 1);
                                    }
                                    try
                                    {
                                        money = double.Parse(str13);
                                    }
                                    catch
                                    {
                                        JavaScript.Alert(this.Page, "输入有错误，请仔细检查。(-1325)");
                                        return;
                                    }
                                    if (money < 2.0)
                                    {
                                        JavaScript.Alert(this.Page, "输入有错误，请仔细检查。(-1332)");
                                    }
                                    else
                                    {
                                        string[] strArray5 = builder.ToString().Split(new char[] { ';' });
                                        int length = strArray5.Length;
                                        string[] str = new string[length * 6];
                                        DateTime time2 = DateTime.Parse(Functions.F_GetIsuseSystemEndTime(long.Parse(strArray5[0].Split(new char[] { ',' })[0]), playType).ToString());
                                        if (DateTime.Now >= time2)
                                        {
                                            JavaScript.Alert(this.Page, "您选择的追号期号中包含已截止的期，请重新选择。");
                                        }
                                        else
                                        {
                                            for (int i = 0; i < length; i++)
                                            {
                                                str[i * 6] = strArray5[i].Split(new char[] { ',' })[0];
                                                str[(i * 6) + 1] = playType.ToString();
                                                str[(i * 6) + 2] = number;
                                                str[(i * 6) + 3] = strArray5[i].Split(new char[] { ',' })[1];
                                                str[(i * 6) + 4] = strArray5[i].Split(new char[] { ',' })[2];
                                                str[(i * 6) + 5] = num8.ToString();
                                                if ((_Convert.StrToDouble(str[(i * 6) + 3], 0.0) * money) != _Convert.StrToDouble(str[(i * 6) + 4], 1.0))
                                                {
                                                    JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
                                                    return;
                                                }
                                                if (_Convert.StrToDouble(str[(i * 6) + 3], 0.0) < multiple)
                                                {
                                                    JavaScript.Alert(this.Page, "追号倍数有错误，请仔细检查！");
                                                    return;
                                                }
                                                if (((double.Parse(str[(i * 6) + 3]) * num7) * num) != double.Parse(str[(i * 6) + 4]))
                                                {
                                                    JavaScript.Alert(this.Page, "追号金额有错误，请仔细检查！可能原因：浏览器不兼容，建议使用IE 7.0");
                                                    return;
                                                }
                                            }
                                            detailXML = PF.BuildIsuseAdditionasXmlForChase(str);
                                            if (detailXML == "")
                                            {
                                                JavaScript.Alert(this.Page, "追号发生错误。");
                                            }
                                            else if (_User.InitiateChaseTask(str8.Trim(), str9.Trim(), lotteryID, stopWhenWinMoney, detailXML, number, schemeBonusScalec, ref returnDescription) < 0)
                                            {
                                                PF.GoError(1, returnDescription, base.GetType().FullName + "(-754)");
                                            }
                                            else
                                            {
                                                Shove._Web.Cache.ClearCache("Home_Room_CoBuy_BindDataForType" + isuseID.ToString());
                                                Shove._Web.Cache.ClearCache("Home_Room_SchemeAll_BindData" + isuseID.ToString());
                                                Shove._Web.Cache.ClearCache(base._Site.ID.ToString() + "AccountFreezeDetail_" + _User.ID.ToString());
                                                base.Response.Redirect("../Home/Room/UserBuySuccess.aspx?LotteryID=" + lotteryID.ToString() + "&Type=2&Money=" + num15.ToString());
                                            }
                                        }
                                    }
                                }
                                else if (DateTime.Now >= _Convert.StrToDateTime(str2.Replace("/", "-"), DateTime.Now.AddDays(-1.0).ToString()))
                                {
                                    JavaScript.Alert(this.Page, "本期投注已截止，谢谢。");
                                }
                                else if (((num * num7) * multiple) != money)
                                {
                                    JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
                                }
                                else
                                {
                                    long num25 = _User.InitiateScheme(isuseID, playType, (str8.Trim() == "") ? "(无标题)" : str8.Trim(), str9.Trim(), number, "", multiple, money, assureMoney, share, buyShare, str7.Trim(), short.Parse(num8.ToString()), schemeBonusScale, ref returnDescription);
                                    if (num25 < 0L)
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
                                        base.Response.Redirect("../Home/Room/UserBuySuccess.aspx?LotteryID=" + lotteryID.ToString() + "&&Money=" + num15.ToString() + "&SchemeID=" + num25.ToString());
                                    }
                                }
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

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public void ClearTheadChartCache()
    {
        Shove._Web.Cache.ClearCache("SYDJ_FBZS");
        Shove._Web.Cache.ClearCache("SYDJ_DWZS");
        Shove._Web.Cache.ClearCache("SYDJ_HZFB");
        Shove._Web.Cache.ClearCache("SYDJ_Q2FBT");
        Shove._Web.Cache.ClearCache("SYDJ_Q2ZXDYB");
        Shove._Web.Cache.ClearCache("SYDJ_Q2HZ");
        Shove._Web.Cache.ClearCache("SYDJ_Q3FWT");
        Shove._Web.Cache.ClearCache("SYDJ_Q3FBT");
        Shove._Web.Cache.ClearCache("SYDJ_Q3HZT");
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string ConvertDanToDT(string Number, int PlayTypeID)
    {
        string[] strArray = Number.Split(new char[] { ',' });
        if (strArray.Length != 2)
        {
            return null;
        }
        int num = 0;
        switch (PlayTypeID)
        {
            case 0x183a:
            case 0x1843:
                num = 2;
                break;

            case 0x183b:
            case 0x1844:
                num = 3;
                break;

            case 0x183c:
                num = 4;
                break;

            case 0x183d:
                num = 5;
                break;

            case 0x183e:
                num = 6;
                break;

            case 0x183f:
                num = 7;
                break;
        }
        string[] strArray2 = this.FilterRepeated(strArray[0].Trim().Split(new char[] { ' ' }));
        string[] strArray3 = this.FilterRepeated(strArray[1].Trim().Split(new char[] { ' ' }));
        string[] strArray4 = this.FilterRepeated(strArray2, strArray3);
        if ((((strArray4.Length + strArray3.Length) < num) || (strArray4.Length < 1)) || (((strArray4.Length > (num - 1)) || (strArray3.Length < 1)) || (strArray3.Length > 10)))
        {
            return null;
        }
        ArrayList list = new ArrayList();
        int length = strArray4.Length;
        int num4 = strArray3.Length;
        switch (num)
        {
            case 2:
                if (length == 1)
                {
                    for (int j = 0; j < num4; j++)
                    {
                        list.Add(strArray4[0].ToString() + " " + strArray3[j].ToString());
                    }
                }
                break;

            case 3:
                if (length != 1)
                {
                    if (length == 2)
                    {
                        for (int m = 0; m < num4; m++)
                        {
                            list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray3[m].ToString());
                        }
                    }
                    break;
                }
                for (int k = 0; k < (num4 - 1); k++)
                {
                    for (int n = k + 1; n < num4; n++)
                    {
                        list.Add(strArray4[0].ToString() + " " + strArray3[k].ToString() + " " + strArray3[n].ToString());
                    }
                }
                break;

            case 4:
                if (length != 1)
                {
                    switch (length)
                    {
                        case 2:
                            for (int num12 = 0; num12 < (num4 - 1); num12++)
                            {
                                for (int num13 = num12 + 1; num13 < num4; num13++)
                                {
                                    list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray3[num12].ToString() + " " + strArray3[num13].ToString());
                                }
                            }
                            break;

                        case 3:
                            for (int num14 = 0; num14 < num4; num14++)
                            {
                                list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray4[2].ToString() + " " + strArray3[num14].ToString());
                            }
                            break;
                    }
                    break;
                }
                for (int num9 = 0; num9 < (num4 - 2); num9++)
                {
                    for (int num10 = num9 + 1; num10 < (num4 - 1); num10++)
                    {
                        for (int num11 = num10 + 1; num11 < num4; num11++)
                        {
                            list.Add(strArray4[0].ToString() + " " + strArray3[num9].ToString() + " " + strArray3[num10].ToString() + " " + strArray3[num11].ToString());
                        }
                    }
                }
                break;

            case 5:
                if (length != 1)
                {
                    if (length == 2)
                    {
                        for (int num19 = 0; num19 < (num4 - 2); num19++)
                        {
                            for (int num20 = num19 + 1; num20 < (num4 - 1); num20++)
                            {
                                for (int num21 = num20 + 1; num21 < num4; num21++)
                                {
                                    list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray3[num19].ToString() + " " + strArray3[num20].ToString() + " " + strArray3[num21].ToString());
                                }
                            }
                        }
                    }
                    else if (length == 3)
                    {
                        for (int num22 = 0; num22 < (num4 - 1); num22++)
                        {
                            for (int num23 = num22 + 1; num23 < num4; num23++)
                            {
                                list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray4[2].ToString() + " " + strArray3[num22].ToString() + " " + strArray3[num23].ToString());
                            }
                        }
                    }
                    else if (length == 4)
                    {
                        for (int num24 = 0; num24 < num4; num24++)
                        {
                            list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray4[2].ToString() + " " + strArray4[3].ToString() + " " + strArray3[num24].ToString());
                        }
                    }
                    break;
                }
                for (int num15 = 0; num15 < (num4 - 3); num15++)
                {
                    for (int num16 = num15 + 1; num16 < (num4 - 2); num16++)
                    {
                        for (int num17 = num16 + 1; num17 < (num4 - 1); num17++)
                        {
                            for (int num18 = num17 + 1; num18 < num4; num18++)
                            {
                                list.Add(strArray4[0].ToString() + " " + strArray3[num15].ToString() + " " + strArray3[num16].ToString() + " " + strArray3[num17].ToString() + " " + strArray3[num18].ToString());
                            }
                        }
                    }
                }
                break;

            case 6:
                if (length != 1)
                {
                    if (length == 2)
                    {
                        for (int num30 = 0; num30 < (num4 - 3); num30++)
                        {
                            for (int num31 = num30 + 1; num31 < (num4 - 2); num31++)
                            {
                                for (int num32 = num31 + 1; num32 < (num4 - 1); num32++)
                                {
                                    for (int num33 = num32 + 1; num33 < num4; num33++)
                                    {
                                        list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray3[num30].ToString() + " " + strArray3[num31].ToString() + " " + strArray3[num32].ToString() + " " + strArray3[num33].ToString());
                                    }
                                }
                            }
                        }
                    }
                    else if (length == 3)
                    {
                        for (int num34 = 0; num34 < (num4 - 2); num34++)
                        {
                            for (int num35 = num34 + 1; num35 < (num4 - 1); num35++)
                            {
                                for (int num36 = num35 + 1; num36 < num4; num36++)
                                {
                                    list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray4[2].ToString() + " " + strArray3[num34].ToString() + " " + strArray3[num35].ToString() + " " + strArray3[num36].ToString());
                                }
                            }
                        }
                    }
                    else if (length == 4)
                    {
                        for (int num37 = 0; num37 < (num4 - 1); num37++)
                        {
                            for (int num38 = num37 + 1; num38 < num4; num38++)
                            {
                                list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray4[2].ToString() + " " + strArray4[3].ToString() + " " + strArray3[num37].ToString() + " " + strArray3[num38].ToString());
                            }
                        }
                    }
                    else if (length == 5)
                    {
                        for (int num39 = 0; num39 < num4; num39++)
                        {
                            list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray4[2].ToString() + " " + strArray4[3].ToString() + " " + strArray4[4].ToString() + " " + strArray3[num39].ToString());
                        }
                    }
                    break;
                }
                for (int num25 = 0; num25 < (num4 - 4); num25++)
                {
                    for (int num26 = num25 + 1; num26 < (num4 - 3); num26++)
                    {
                        for (int num27 = num26 + 1; num27 < (num4 - 2); num27++)
                        {
                            for (int num28 = num27 + 1; num28 < (num4 - 1); num28++)
                            {
                                for (int num29 = num28 + 1; num29 < num4; num29++)
                                {
                                    list.Add(strArray4[0].ToString() + " " + strArray3[num25].ToString() + " " + strArray3[num26].ToString() + " " + strArray3[num27].ToString() + " " + strArray3[num28].ToString() + " " + strArray3[num29].ToString());
                                }
                            }
                        }
                    }
                }
                break;

            case 7:
                if (length != 1)
                {
                    if (length == 2)
                    {
                        for (int num46 = 0; num46 < (num4 - 4); num46++)
                        {
                            for (int num47 = num46 + 1; num47 < (num4 - 3); num47++)
                            {
                                for (int num48 = num47 + 1; num48 < (num4 - 2); num48++)
                                {
                                    for (int num49 = num48 + 1; num49 < (num4 - 1); num49++)
                                    {
                                        for (int num50 = num49 + 1; num50 < num4; num50++)
                                        {
                                            list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray3[num46].ToString() + " " + strArray3[num47].ToString() + " " + strArray3[num48].ToString() + " " + strArray3[num49].ToString() + " " + strArray3[num50].ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (length == 3)
                    {
                        for (int num51 = 0; num51 < (num4 - 3); num51++)
                        {
                            for (int num52 = num51 + 1; num52 < (num4 - 2); num52++)
                            {
                                for (int num53 = num52 + 1; num53 < (num4 - 1); num53++)
                                {
                                    for (int num54 = num53 + 1; num54 < num4; num54++)
                                    {
                                        list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray4[2].ToString() + " " + strArray3[num51].ToString() + " " + strArray3[num52].ToString() + " " + strArray3[num53].ToString() + " " + strArray3[num54].ToString());
                                    }
                                }
                            }
                        }
                    }
                    else if (length == 4)
                    {
                        for (int num55 = 0; num55 < (num4 - 2); num55++)
                        {
                            for (int num56 = num55 + 1; num56 < (num4 - 1); num56++)
                            {
                                for (int num57 = num56 + 1; num57 < num4; num57++)
                                {
                                    list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray4[2].ToString() + " " + strArray4[3].ToString() + " " + strArray3[num55].ToString() + " " + strArray3[num56].ToString() + " " + strArray3[num57].ToString());
                                }
                            }
                        }
                    }
                    else if (length == 5)
                    {
                        for (int num58 = 0; num58 < (num4 - 1); num58++)
                        {
                            for (int num59 = num58 + 1; num59 < num4; num59++)
                            {
                                list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray4[2].ToString() + " " + strArray4[3].ToString() + " " + strArray4[4].ToString() + " " + strArray3[num58].ToString() + " " + strArray3[num59].ToString());
                            }
                        }
                    }
                    else if (length == 6)
                    {
                        for (int num60 = 0; num60 < num4; num60++)
                        {
                            list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray4[2].ToString() + " " + strArray4[3].ToString() + " " + strArray4[4].ToString() + " " + strArray4[5].ToString() + " " + strArray3[num60].ToString());
                        }
                    }
                    break;
                }
                for (int num40 = 0; num40 < (num4 - 5); num40++)
                {
                    for (int num41 = num40 + 1; num41 < (num4 - 4); num41++)
                    {
                        for (int num42 = num41 + 1; num42 < (num4 - 3); num42++)
                        {
                            for (int num43 = num42 + 1; num43 < (num4 - 2); num43++)
                            {
                                for (int num44 = num43 + 1; num44 < (num4 - 1); num44++)
                                {
                                    for (int num45 = num44 + 1; num45 < num4; num45++)
                                    {
                                        list.Add(strArray4[0].ToString() + " " + strArray3[num40].ToString() + " " + strArray3[num41].ToString() + " " + strArray3[num42].ToString() + " " + strArray3[num43].ToString() + " " + strArray3[num44].ToString() + " " + strArray3[num45].ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                break;
        }
        if (list.Count == 0)
        {
            return null;
        }
        string str = "";
        for (int i = 0; i < list.Count; i++)
        {
            ArrayList list2 = new ArrayList();
            foreach (string str2 in list[i].ToString().Split(new char[] { ' ' }))
            {
                list2.Add(str2);
            }
            list2.Sort(new CompareToAscii());
            string str3 = "";
            for (int num63 = 0; num63 < list2.Count; num63++)
            {
                str3 = str3 + list2[num63].ToString() + " ";
            }
            str = str + str3.Trim() + ",";
        }
        if (str.EndsWith(","))
        {
            str = str.Substring(0, str.Length - 1);
        }
        return str.Trim();
    }

    private class CompareToAscii : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            return new CaseInsensitiveComparer().Compare(x, y);
        }
    }

    private string DataBindIsuseCount(int lotteryID)
    {
        string key = "Home_Room_Buy_SYYDJ_DataBindIsuseCount";
        string[] cache = Shove._Web.Cache.GetCache(key) as string[];
        if ((cache == null) || (cache.Length < 2))
        {
            cache = Functions.F_GetIsuseCount(lotteryID).Split(new char[] { ',' });
            if ((cache == null) || (cache.Length < 2))
            {
                return "";
            }
            Shove._Web.Cache.SetCache(key, cache, 60);
        }
        return ("今日已开&nbsp;<span class='red12'>" + cache[0] + "</span>&nbsp;期，还剩&nbsp;<span class='red12'>" + cache[1] + "</span>&nbsp;期");
    }

    private string[] FilterRepeated(string[] NumberPart)
    {
        ArrayList al = new ArrayList();
        for (int i = 0; i < NumberPart.Length; i++)
        {
            int ball = _Convert.StrToInt(NumberPart[i], -1);
            if (((ball >= 1) && (ball <= 11)) && !this.isExistBall(al, ball))
            {
                al.Add(NumberPart[i]);
            }
        }
        CompareToAscii comparer = new CompareToAscii();
        al.Sort(comparer);
        string[] strArray = new string[al.Count];
        for (int j = 0; j < al.Count; j++)
        {
            strArray[j] = al[j].ToString().PadLeft(2, '0');
        }
        return strArray;
    }

    private string[] FilterRepeated(string[] NumberPart1, string[] NumberPart2)
    {
        ArrayList al = new ArrayList();
        for (int i = 0; i < NumberPart2.Length; i++)
        {
            al.Add(NumberPart2[i]);
        }
        ArrayList list2 = new ArrayList();
        for (int j = 0; j < NumberPart1.Length; j++)
        {
            int ball = _Convert.StrToInt(NumberPart1[j], -1);
            if (!this.isExistBall(al, ball))
            {
                list2.Add(NumberPart1[j]);
            }
        }
        CompareToAscii comparer = new CompareToAscii();
        list2.Sort(comparer);
        string[] strArray = new string[list2.Count];
        for (int k = 0; k < list2.Count; k++)
        {
            strArray[k] = list2[k].ToString().PadLeft(2, '0');
        }
        return strArray;
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetExample(string PlayTypeID)
    {
        string str = "";
        switch (PlayTypeID)
        {
            case "6201":
                str = "选号：01\n";
                return (str + "开奖号码：01 02 03 04 05\n" + "中奖：13元");

            case "6202":
                str = "选号：01 05\n";
                return (str + "开奖号码：01 02 03 04 05\n" + "中奖：6元");

            case "6203":
                str = "选号：01 02 04\n";
                return (str + "开奖号码：01 02 03 04 05\n" + "中奖：19元");

            case "6204":
                str = "选号：01 02 04 05\n";
                return (str + "开奖号码：01 02 03 04 05\n" + "中奖：78元");

            case "6205":
                str = "选号：01 02 03 04 05\n";
                return (str + "开奖号码：01 02 03 04 05\n" + "中奖：540元");

            case "6206":
                str = "选号：01 02 03 04 05 06\n";
                return (str + "开奖号码：01 02 03 04 05\n" + "中奖：90元");

            case "6207":
                str = "选号：01 02 03 04 05 06 07\n";
                return (str + "开奖号码：01 02 03 04 05\n" + "中奖：26元");

            case "6208":
                str = "选号：01 02 03 04 05 06 07 08\n";
                return (str + "开奖号码：01 02 03 04 05\n" + "中奖：9元");

            case "6209":
                str = "选号：01 02\n";
                return (str + "开奖号码：01 02 03 04 05\n" + "中奖：130元");

            case "6210":
                str = "选号：01 02 03\n";
                return (str + "开奖号码：01 02 03 04 05\n" + "中奖：1170元");

            case "6211":
                str = "选号：02 01\n";
                return (str + "开奖号码：01 02 03 04 05\n" + "中奖：65元");

            case "6212":
                str = "选号：02 01 03\n";
                return (str + "开奖号码：01 02 03 04 05\n" + "中奖：195元");
        }
        return str;
    }

    private string GetHotOrCool(List<int> sort, int RX)
    {
        sort.Sort();
        string str = "温";
        if (RX < 0x23)
        {
            str = "冷";
        }
        if (RX >= sort[8])
        {
            str = "热";
        }
        if (((IEnumerable<int>)sort).Max() == RX)
        {
            str = "<font color=\"#CC0000\">热</font>";
        }
        if (((IEnumerable<int>)sort).Min() == RX)
        {
            str = "<font color=\"#999999\">冷</font>";
        }
        return str;
    }

    private string GetIsuseChase(int LotteryID)
    {
        try
        {
            DataTable isusesInfo = DataCache.GetIsusesInfo(LotteryID);
            int num = DataCache.LotteryEndAheadMinute[0x3e];
            DataRow[] rowArray = isusesInfo.Select("('" + DateTime.Now.ToString() + "' < StartTime or ('" + DateTime.Now.ToString() + "'>StartTime and '" + DateTime.Now.AddMinutes((double)num).ToString() + "'<EndTime))", "EndTime");
            if (rowArray.Length == 0)
            {
                return "";
            }
            StringBuilder builder = new StringBuilder();
            int num2 = 0;
            builder.Append("<table cellpadding='0' cellspacing='1' style='width: 100%; text-align: center; background-color: #E2EAED;'><tbody style='background-color: White;'>");
            foreach (DataRow row in rowArray)
            {
                num2++;
                builder.Append("<tr>").Append("<td style='width: 10%;'>").Append("<input id='check").Append(row["ID"].ToString()).Append("' type='checkbox' name='check").Append(row["ID"].ToString()).Append("' onclick='check(this);' value='").Append(row["ID"].ToString()).Append("'/>").Append("</td>").Append("<td style='width: 40%;'>").Append("<span>").Append(row["Name"].ToString()).Append("</span>").Append("<span>").Append((num2 == 1) ? "<font color='red'>[本期]</font>" : ((num2 == 2) ? "<font color='red'>[下期]</font>" : "")).Append("</span>").Append("</td>").Append("<td style='width: 20%;'>").Append("<input name='times").Append(row["ID"].ToString()).Append("' type='text' value='1' id='times").Append(row["ID"].ToString()).Append("' class='TextBox' onchange='onTextChange(this);' onkeypress='return InputMask_Number();' disabled='disabled' onblur='CheckMultiple2(this);' style='width: 45px;' />倍").Append("</td>").Append("<td style='width: 30%;'>").Append("<input name='money").Append(row["ID"].ToString()).Append("' type='text' value='0' id='money").Append(row["ID"].ToString()).Append("' class='TextBox' disabled='disabled' style='width: 45px;' />元").Append("</td>").Append("</tr>");
            }
            builder.Append("</tbody></table>");
            return builder.ToString();
        }
        catch (Exception exception)
        {
            new Log("TWZT").Write("AlipayTask Running Error: " + exception.Message);
            return "";
        }
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetIsuseInfo(int LotteryID)
    {
        try
        {
            DataTable isusesInfo = DataCache.GetIsusesInfo(LotteryID);
            string str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DataRow[] rowArray = isusesInfo.Select("'" + str + "' > StartTime and '" + str + "' < EndTime", "EndTime desc");
            if (rowArray.Length == 0)
            {
                return "";
            }
            if (rowArray.Length == 0)
            {
                rowArray = isusesInfo.Select("EndTime < '" + str + "'", "EndTime desc");
            }
            int num = _Convert.StrToInt(rowArray[0]["ID"].ToString(), -1);
            string str3 = rowArray[0]["Name"].ToString();
            int num2 = DataCache.LotteryEndAheadMinute[LotteryID];
            string str4 = Convert.ToDateTime(rowArray[0]["EndTime"]).AddMinutes((double)(num2 * -1)).ToString("yyyy/MM/dd HH:mm:ss");
            StringBuilder builder = new StringBuilder();
            builder.Append(num.ToString()).Append(",").Append(str3).Append(",").Append(str4).Append("|").Append(this.GetIsuseChase(LotteryID));
            return builder.ToString();
        }
        catch (Exception exception)
        {
            new Log("TWZT").Write(base.GetType() + exception.Message);
            return "";
        }
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetNewsInfo(int LotteryID)
    {
        return DataCache.GetLotteryNews(LotteryID);
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetNextIsuseInfo(int LotteryID)
    {
        try
        {
            DataTable isusesInfo = DataCache.GetIsusesInfo(LotteryID);
            string str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return Convert.ToDateTime(isusesInfo.Select("'" + str + "' < EndTime", "StartTime asc")[1]["StartTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
        }
        catch (Exception exception)
        {
            new Log("TWZT").Write(base.GetType() + exception.Message);
            return "";
        }
    }

    private string GetQuanXuan(int Number, int[,] SYYDJ)
    {
        StringBuilder builder = new StringBuilder();
        int[] source = new int[11];
        for (int i = 0; i < Number; i++)
        {
            builder.Append("<table width=\"400\" border=\"0\" cellpadding=\"0\" cellspacing=\"3\">").Append("<tr>").Append("<td class='blue' width='72px'>").Append("百期开出数：").Append("</td>");
            for (int j = 0; j < 11; j++)
            {
                int num3 = SYYDJ[i, j];
                builder.Append("<td class='black30'>").Append(num3.ToString()).Append("</td>");
                source[j] = num3;
            }
            builder.Append("</tr>").Append("</table>").Append("-").Append("<table width=\"400\" border=\"0\" cellpadding=\"0\" cellspacing=\"3\">").Append("<tr>").Append("<td class='blue' width='72px'>").Append("冷温热分析：").Append("</td>");
            foreach (int num5 in source)
            {
                builder.Append("<td class='black30'>").Append(this.GetHotOrCool(source.ToList<int>(), num5)).Append("</td>");
            }
            builder.Append("</tr>").Append("</table>").Append("-");
        }
        return builder.ToString();
    }

    private string GetRenXuan(int[,] SYYDJ)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<table width=\"410\" border=\"0\" cellpadding=\"0\" cellspacing=\"3\">").Append("<tr>").Append("<td class='blue1' width='72px' align='center'>").Append("百期开出数：").Append("</td>");
        int num = 0;
        int[] source = new int[11];
        for (int i = 0; i < 11; i++)
        {
            num = (((SYYDJ[0, i] + SYYDJ[1, i]) + SYYDJ[2, i]) + SYYDJ[3, i]) + SYYDJ[4, i];
            builder.Append("<td class='black30' style='color:#999999'>").Append(num.ToString()).Append("</td>");
            source[i] = num;
        }
        builder.Append("</tr>").Append("</table>").Append("-").Append("<table width=\"410\" border=\"0\" cellpadding=\"0\" cellspacing=\"3\">").Append("<tr>").Append("<td class='blue1' width='72px'>").Append("冷温热分析：").Append("</td>");
        foreach (int num4 in source)
        {
            builder.Append("<td class='black30'>").Append(this.GetHotOrCool(source.ToList<int>(), num4)).Append("</td>");
        }
        builder.Append("</tr>").Append("</table>");
        return builder.ToString();
    }

    [AjaxMethod(HttpSessionStateRequirement.Read)]
    public string GetSchemeBonusScalec()
    {
        DataTable table = new Tables.T_Sites().Open("Opt_InitiateSchemeBonusScale,Opt_InitiateSchemeLimitLowerScaleMoney,Opt_InitiateSchemeLimitLowerScale,Opt_InitiateSchemeLimitUpperScaleMoney,Opt_InitiateSchemeLimitUpperScale", "", "");
        string str = (_Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeBonusScale"].ToString(), 0.0) * 100.0).ToString();
        string str2 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitLowerScaleMoney"].ToString(), 100.0).ToString();
        string str3 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitLowerScale"].ToString(), 0.2).ToString();
        string str4 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitUpperScaleMoney"].ToString(), 10000.0).ToString();
        string str5 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitUpperScale"].ToString(), 0.05).ToString();
        return (str + "|" + str2 + "|" + str3 + "|" + str4 + "|" + str5 + "|十一运夺金");
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetSysTime()
    {
        return _Convert.StrToDateTime(new Views.V_GetDate().Open("", "", "").Rows[0]["Now"].ToString(), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")).ToString("yyyy/MM/dd HH:mm:ss");
    }

    private void GetSYYDJHotAndCool()
    {
        string key = "Home_Room_Buy_GetSYYDJHotAndCool";
        this.lbMiss.Text = Shove._Web.Cache.GetCacheAsString(key, "");
        if (this.lbMiss.Text == "")
        {
            DataTable table = new Tables.T_Isuses().Open("top 100 WinLotteryNumber", "LotteryID = 62 and GETDATE()>EndTime and ISNULL(WinLotteryNumber,'')<>'' and IsOpened=1", "EndTime desc");
            if (table == null)
            {
                new Log("System").Write(base.GetType().FullName + "数据库繁忙，请重试(GetSYYDJHotAndCool)");
            }
            else
            {
                int[,] sYYDJ = new int[5, 11];
                foreach (DataRow row in table.Rows)
                {
                    string[] strArray = row["WinLotteryNumber"].ToString().Split(new char[] { ' ' });
                    if (strArray.Length == 5)
                    {
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            int num2 = _Convert.StrToInt(strArray[i], 0);
                            sYYDJ[i, num2 - 1]++;
                        }
                    }
                }
                this.lbMiss.Text = this.GetRenXuan(sYYDJ) + "|" + this.GetQuanXuan(2, sYYDJ) + "|" + this.GetQuanXuan(3, sYYDJ);
                Shove._Web.Cache.SetCache(key, this.lbMiss.Text, 120);
            }
        }
    }

    private bool isExistBall(ArrayList al, int Ball)
    {
        if (al.Count != 0)
        {
            for (int i = 0; i < al.Count; i++)
            {
                if (int.Parse(al[i].ToString()) == Ball)
                {
                    return true;
                }
            }
        }
        return false;
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
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Lottery_Buy_SYYDJ), this.Page);
        this.LotteryID = 0x3e;
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
        this.LotteryName = "十一运夺金";
        if (!base.IsPostBack)
        {
            long buyID = _Convert.StrToLong(Shove._Web.Utility.GetRequest("BuyID"), -1L);
            if (buyID > 0L)
            {
                this.BindDataForAliBuy(buyID);
            }
            this.tbWin1.InnerHtml = this.BindWinList(DataCache.GetWinInfo(this.LotteryID));
            this.GetSYYDJHotAndCool();
            this.DZ = Encrypt.UnEncryptString(PF.GetCallCert(), Shove._Web.Utility.GetRequest("DZ"));
        }
    }

    private void SaveDataForAliBuy()
    {
        string request = Shove._Web.Utility.GetRequest("HidIsuseID");
        Shove._Web.Utility.GetRequest("HidIsuseEndTime");
        string s = Shove._Web.Utility.GetRequest("tbPlayTypeID");
        string str3 = Shove._Web.Utility.GetRequest("Chase");
        string str4 = Shove._Web.Utility.GetRequest("Cobuy");
        string str5 = Shove._Web.Utility.GetRequest("tb_Share");
        string str6 = Shove._Web.Utility.GetRequest("tb_BuyShare");
        string str7 = Shove._Web.Utility.GetRequest("tb_AssureShare");
        string str8 = Shove._Web.Utility.GetRequest("tb_OpenUserList");
        string str9 = Shove._Web.Utility.GetRequest("tb_Title");
        string str10 = Shove._Web.Utility.GetRequest("tb_Description");
        string str11 = Shove._Web.Utility.GetRequest("tbAutoStopAtWinMoney");
        string str12 = Shove._Web.Utility.GetRequest("SecrecyLevel");
        Shove._Web.Utility.GetRequest("tbPlayTypeName");
        string str13 = Shove._Web.Utility.FilteSqlInfusion(base.Request["tb_LotteryNumber"]);
        string str14 = Shove._Web.Utility.GetRequest("tb_hide_SumMoney");
        string str15 = Shove._Web.Utility.GetRequest("tb_hide_AssureMoney");
        string str = Shove._Web.Utility.GetRequest("tb_hide_SumNum");
        Shove._Web.Utility.GetRequest("HidIsuseCount");
        string str17 = Shove._Web.Utility.GetRequest("HidLotteryID");
        Shove._Web.Utility.GetRequest("HidIsAlipay");
        string str18 = Shove._Web.Utility.GetRequest("tb_Multiple");
        string str19 = "";
        StringBuilder builder = new StringBuilder();
        int num = 0;
        int num2 = 2;
        if (str18 == "")
        {
            str18 = "1";
        }
        if (str3 == "1")
        {
            foreach (string str20 in base.Request.Form.AllKeys)
            {
                if (str20.IndexOf("check") > -1)
                {
                    int num4 = _Convert.StrToInt(str20.Replace("check", ""), -1);
                    if (num4 > 0)
                    {
                        num++;
                        int num5 = (_Convert.StrToInt(str, -1) * num2) * _Convert.StrToInt(base.Request.Form["times" + num4.ToString()], -1);
                        builder.Append(base.Request.Form[str20]).Append(",").Append(base.Request.Form["times" + num4.ToString()]).Append(",").Append(num5.ToString()).Append(";");
                    }
                }
            }
            string str21 = str13;
            if (builder.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
            }
            if (str21[str21.Length - 1] == '\n')
            {
                str21 = str21.Substring(0, str21.Length - 1);
            }
            string[] strArray2 = builder.ToString().Split(new char[] { ';' });
            int length = strArray2.Length;
            string[] strArray3 = new string[length * 6];
            DateTime time2 = DateTime.Parse(Functions.F_GetIsuseSystemEndTime(long.Parse(strArray2[0].Split(new char[] { ',' })[0]), int.Parse(s)).ToString());
            if (DateTime.Now >= time2)
            {
                JavaScript.Alert(this.Page, "您选择的追号期号中包含已截止的期，请重新选择。");
                return;
            }
            for (int i = 0; i < length; i++)
            {
                strArray3[i * 6] = strArray2[i].Split(new char[] { ',' })[0];
                strArray3[(i * 6) + 1] = s;
                strArray3[(i * 6) + 2] = str21;
                strArray3[(i * 6) + 3] = strArray2[i].Split(new char[] { ',' })[1];
                strArray3[(i * 6) + 4] = strArray2[i].Split(new char[] { ',' })[2];
                strArray3[(i * 6) + 5] = str12;
            }
            str19 = PF.BuildIsuseAdditionasXmlForChase(strArray3);
        }
        long num8 = new Tables.T_AlipayBuyTemp
        {
            SiteID = { Value = 1 },
            UserID = { Value = -1 },
            Money = { Value = str14 },
            HandleResult = { Value = 0 },
            IsChase = { Value = str3 == "1" },
            IsCoBuy = { Value = str4 == "2" },
            LotteryID = { Value = str17 },
            IsuseID = { Value = request },
            PlayTypeID = { Value = s },
            StopwhenwinMoney = { Value = str11 },
            AdditionasXml = { Value = str19 },
            Title = { Value = str9 },
            Description = { Value = str10 },
            LotteryNumber = { Value = str13 },
            UpdateloadFileContent = { Value = "" },
            Multiple = { Value = str18 },
            BuyMoney = { Value = str6 },
            SumMoney = { Value = str14 },
            AssureMoney = { Value = str15 },
            Share = { Value = str5 },
            BuyShare = { Value = str6 },
            AssureShare = { Value = str7 },
            OpenUsers = { Value = str8 },
            SecrecyLevel = { Value = str12 }
        }.Insert();
        if (num8 < 0L)
        {
            new Log("System").Write("T_AlipayBuyTemp 数据库读写错误。");
        }
        JavaScript.Alert(this.Page, "您的账户余额不足，请先充值，谢谢。", "../Home/Room/OnlinePay/Default.aspx?BuyID=" + num8.ToString());
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
    public string SplitScheme(string LotteryNumber, int PlayTypeID)
    {
        Lottery lottery = new Lottery();
        string canonicalNumber = "";
        string[] strArray = lottery[0x3e].ToSingle(LotteryNumber, ref canonicalNumber, PlayTypeID);
        if ((strArray == null) || (strArray.Length < 1))
        {
            return "";
        }
        LotteryNumber = "";
        foreach (string str2 in strArray)
        {
            LotteryNumber = LotteryNumber + str2.Replace(" ", "|") + ",";
        }
        int length = strArray.Length;
        return (LotteryNumber + length.ToString());
    }
}

