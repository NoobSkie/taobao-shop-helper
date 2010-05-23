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
    public partial class Buy_SSL : RoomPageBase, IRequiresSessionState
    {
        public string DZ = "";
        public int LotteryID;
        public string LotteryName;
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
                builder.AppendLine("$Id('playTypes').style.display = ((i == 1 || i == 2 || i == 3) ? 'none':'');");
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
                        builder.Append("$Id('share").Append(node.Attributes["IsuseID"].Value).Append("').value = '").Append(node.Attributes["Share"].Value).AppendLine("';");
                        builder.Append("$Id('buyedShare").Append(node.Attributes["IsuseID"].Value).Append("').value = '").Append(node.Attributes["BuyedShare"].Value).AppendLine("';");
                        builder.Append("$Id('assureShare").Append(node.Attributes["IsuseID"].Value).Append("').value = '").Append(node.Attributes["AssureShare"].Value).AppendLine("';");
                        builder.Append("$Id('check").Append(node.Attributes["IsuseID"].Value).AppendLine("').checked = true;");
                        builder.Append("$Id('times").Append(node.Attributes["IsuseID"].Value).AppendLine("').disabled = '';");
                        builder.Append("$Id('share").Append(node.Attributes["IsuseID"].Value).AppendLine("').disabled = '';");
                        builder.Append("$Id('buyedShare").Append(node.Attributes["IsuseID"].Value).AppendLine("').disabled = '';");
                        builder.Append("$Id('assureShare").Append(node.Attributes["IsuseID"].Value).AppendLine("').disabled = '';");
                    }
                }
                str17 = str17.Replace("\r", "");
                int num9 = 0;
                string canonicalNumber = "";
                foreach (string str19 in str17.Split(new char[] { '\n' }))
                {
                    num9 += new SLS.Lottery()[num8].ToSingle(str19, ref canonicalNumber, playType).Length;
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
            string s = Shove._Web.Utility.GetRequest("playType");
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
                            SLS.Lottery lottery = new SLS.Lottery();
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
                                                    builder.Append(base.Request.Form[str26]).Append(",").Append(base.Request.Form["times" + num20.ToString()]).Append(",").Append(num21.ToString()).Append(",").Append(base.Request.Form["share" + num20.ToString()]).Append(",").Append(base.Request.Form["buyedShare" + num20.ToString()]).Append(",").Append(base.Request.Form["assureShare" + num20.ToString()]).Append(";");
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
                                            string[] str = new string[length * 9];
                                            DateTime time2 = DateTime.Parse(Functions.F_GetIsuseSystemEndTime(long.Parse(strArray5[0].Split(new char[] { ',' })[0]), playType).ToString());
                                            if (DateTime.Now >= time2)
                                            {
                                                JavaScript.Alert(this.Page, "您选择的追号期号中包含已截止的期，请重新选择。");
                                            }
                                            else
                                            {
                                                for (int i = 0; i < length; i++)
                                                {
                                                    str[i * 9] = strArray5[i].Split(new char[] { ',' })[0];
                                                    str[(i * 9) + 1] = playType.ToString();
                                                    str[(i * 9) + 2] = number;
                                                    str[(i * 9) + 3] = strArray5[i].Split(new char[] { ',' })[1];
                                                    str[(i * 9) + 4] = strArray5[i].Split(new char[] { ',' })[2];
                                                    str[(i * 9) + 5] = num8.ToString();
                                                    str[(i * 9) + 6] = strArray5[i].Split(new char[] { ',' })[3];
                                                    str[(i * 9) + 7] = strArray5[i].Split(new char[] { ',' })[4];
                                                    str[(i * 9) + 8] = strArray5[i].Split(new char[] { ',' })[5];
                                                    if ((_Convert.StrToDouble(str[(i * 9) + 3], 0.0) * money) != _Convert.StrToDouble(str[(i * 9) + 4], 1.0))
                                                    {
                                                        JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
                                                        return;
                                                    }
                                                    if (_Convert.StrToDouble(str[(i * 9) + 3], 0.0) < multiple)
                                                    {
                                                        JavaScript.Alert(this.Page, "追号倍数有错误，请仔细检查！");
                                                        return;
                                                    }
                                                    if (((double.Parse(str[(i * 9) + 3]) * num7) * num) != double.Parse(str[(i * 9) + 4]))
                                                    {
                                                        JavaScript.Alert(this.Page, "追号金额有错误，请仔细检查！可能原因：浏览器不兼容，建议使用IE 7.0");
                                                        return;
                                                    }
                                                }
                                                detailXML = PF.BuildIsuseAdditionasXmlForBJKL8(str);
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
                                            base.Response.Redirect("../Home/Room/UserBuySuccess.aspx?LotteryID=" + lotteryID.ToString() + "&Money=" + num15.ToString() + "&SchemeID=" + num25.ToString());
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
        public string DataBindIsuseCount(int lotteryID)
        {
            string key = "Home_Room_Buy_SSL_DataBindIsuseCount";
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

        private string FormatWinNumber(string winNumber)
        {
            StringBuilder builder = new StringBuilder();
            if (winNumber.Length > 0)
            {
                for (int i = 0; i < winNumber.Length; i++)
                {
                    builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(winNumber.Substring(i, 1));
                }
            }
            return builder.ToString();
        }

        private string GetIsuseChase(int LotteryID)
        {
            try
            {
                DataTable isusesInfo = DataCache.GetIsusesInfo(LotteryID);
                int num = DataCache.LotteryEndAheadMinute[LotteryID];
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
                    builder.Append("<tr>").Append("<td style='width: 10%;'>").Append("<input id='check").Append(row["ID"].ToString()).Append("' type='checkbox' name='check").Append(row["ID"].ToString()).Append("' onclick='check(this);' value='").Append(row["ID"].ToString()).Append("'/>").Append("</td>").Append("<td style='width: 20%;'>").Append("<span>").Append(row["Name"].ToString()).Append("</span>").Append("<span>").Append((num2 == 1) ? "<font color='red'>[本期]</font>" : ((num2 == 2) ? "<font color='red'>[下期]</font>" : "")).Append("</span>").Append("</td>").Append("<td style='width: 13%;'>").Append("<input name='times").Append(row["ID"].ToString()).Append("' type='text' value='1' id='times").Append(row["ID"].ToString()).Append("' class='TextBox' onchange='onTextChange(this);' onkeypress='return InputMask_Number();' disabled='disabled' onblur='CheckMultiple2(this);' style='width: 30px;' />倍").Append("</td>").Append("<td style='width: 14%;'>").Append("<input name='money").Append(row["ID"].ToString()).Append("' type='text' value='0' id='money").Append(row["ID"].ToString()).Append("' class='TextBox' disabled='disabled' style='width: 35px;' />元").Append("</td>").Append("<td style='width: 12%;'>").Append("<input name='share").Append(row["ID"].ToString()).Append("' type='text' value='1' id='share").Append(row["ID"].ToString()).Append("' class='TextBox'  onkeypress='return InputMask_Number();' disabled='disabled'  style='width: 30px;' onblur='CheckShare2(1,this);'/>份").Append("</td>").Append("<td style='width: 13%;'>").Append("<input name='buyedShare").Append(row["ID"].ToString()).Append("' type='text' value='1' id='buyedShare").Append(row["ID"].ToString()).Append("' class='TextBox'  onkeypress='return InputMask_Number();' disabled='disabled' onblur='CheckShare2(2,this);'  style='width: 35px;' />份").Append("</td>").Append("<td style='width: 15%;'>").Append("<input name='assureShare").Append(row["ID"].ToString()).Append("' type='text' value='0' id='assureShare").Append(row["ID"].ToString()).Append("' class='TextBox'  onkeypress='return InputMask_Number();' onblur='CheckShare2(3,this);' disabled='disabled'  style='width: 35px;' />份").Append("</td>").Append("</tr>");
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
                Shove._Web.Cache.ClearCache(DataCache.IsusesInfo + LotteryID.ToString());
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
                string str5 = "";
                string shsslMiss = this.GetShsslMiss(ref str5);
                StringBuilder builder = new StringBuilder();
                builder.Append(num.ToString()).Append(",").Append(str3).Append(",").Append(str4).Append("|").Append(this.GetIsuseChase(LotteryID));
                builder.Append("|").Append(shsslMiss);
                return builder.ToString();
            }
            catch (Exception exception)
            {
                new Log("TWZT").Write(base.GetType() + exception.Message);
                return "";
            }
        }

        [AjaxMethod(HttpSessionStateRequirement.None)]
        public string GetLastIsuseInfo(int LotteryID)
        {
            try
            {
                Shove._Web.Cache.ClearCache(DataCache.IsusesInfo + LotteryID.ToString());
                Shove._Web.Cache.ClearCache("Home_Room_Buy_SSL_DataBindIsuseCount");
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
                    rowArray = rowArray2;
                }
                if (rowArray2.Length == 0)
                {
                    rowArray2 = rowArray;
                }
                string str3 = rowArray[0]["StartTime"].ToString();
                string str4 = rowArray2[0]["Name"].ToString();
                string winNumber = rowArray2[0]["WinLotteryNumber"].ToString().Trim();
                string str6 = rowArray2[0]["StartTime"].ToString();
                winNumber = this.FormatWinNumber(winNumber);
                StringBuilder builder = new StringBuilder();
                builder.Append("<table cellspacing='5' cellpadding='0' style='text-align: center; font-weight: bold;'><tr><td  height='25' class='hui12'>").Append(str4).Append("&nbsp;期开奖:&nbsp;&nbsp;&nbsp;&nbsp;").Append(winNumber).Append("</td>");
                string str7 = "";
                this.GetShsslMiss(ref str7);
                builder.Append("<td>").Append("&nbsp;&nbsp;&nbsp;&nbsp;温馨提示：组选三连续").Append("<span class='num_1'>" + str7 + "</span>").Append("期未开出").Append("</td>");
                builder.Append("</tr></table>");
                if (new Tables.T_Isuses().GetCount(string.Concat(new object[] { "StartTime between '", str6, "' and '", str3, "' and LotteryID=", LotteryID })) >= 3L)
                {
                    builder.Append("|1");
                }
                else
                {
                    builder.Append("|2");
                }
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

        [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
        public string GetSchemeBonusScalec()
        {
            DataTable table = new Tables.T_Sites().Open("Opt_InitiateSchemeBonusScale,Opt_InitiateSchemeLimitLowerScaleMoney,Opt_InitiateSchemeLimitLowerScale,Opt_InitiateSchemeLimitUpperScaleMoney,Opt_InitiateSchemeLimitUpperScale", "", "");
            string str = (_Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeBonusScale"].ToString(), 0.0) * 100.0).ToString();
            string str2 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitLowerScaleMoney"].ToString(), 100.0).ToString();
            string str3 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitLowerScale"].ToString(), 0.2).ToString();
            string str4 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitUpperScaleMoney"].ToString(), 10000.0).ToString();
            string str5 = _Convert.StrToDouble(table.Rows[0]["Opt_InitiateSchemeLimitUpperScale"].ToString(), 0.05).ToString();
            return (str + "|" + str2 + "|" + str3 + "|" + str4 + "|" + str5 + "|时时乐");
        }

        private string GetShsslMiss(ref string Zu3Miss)
        {
            try
            {
                int returnValue = -1;
                string returnDescptrion = "";
                string str2 = "";
                string key = "Home_Room_Buy_GetShsslMiss";
                DataSet cacheAsDataSet = Shove._Web.Cache.GetCacheAsDataSet(key);
                if (cacheAsDataSet == null)
                {
                    if (Procedures.P_Analysis_SHSSL_HotAndCoolAndMiss(ref cacheAsDataSet, ref returnValue, ref returnDescptrion) < 0)
                    {
                        PF.GoError(4, "数据库读写错误", base.GetType().FullName);
                        new Log("System").Write(base.GetType().FullName + "数据库繁忙，请重试(P_Analysis_SHSSL_HotAndCoolAndMiss)");
                        return "";
                    }
                    if (returnValue < 0)
                    {
                        PF.GoError(1, returnDescptrion, base.GetType().FullName);
                        return "";
                    }
                    if (cacheAsDataSet.Tables.Count < 3)
                    {
                        new Log("System").Write(base.GetType().FullName + "数据库繁忙，请重试(P_Analysis_SHSSL_HotAndCoolAndMiss)");
                        return "";
                    }
                    Shove._Web.Cache.SetCache(key, cacheAsDataSet, 60);
                }
                Zu3Miss = cacheAsDataSet.Tables[0].Rows[0][0].ToString();
                DataTable table = cacheAsDataSet.Tables[2];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string str5 = str2;
                    string str6 = str5 + table.Rows[i]["Number_0"].ToString() + "," + table.Rows[i]["Number_1"].ToString() + "," + table.Rows[i]["Number_2"].ToString() + "," + table.Rows[i]["Number_3"].ToString() + ",";
                    str2 = ((str6 + table.Rows[i]["Number_4"].ToString() + "," + table.Rows[i]["Number_5"].ToString() + "," + table.Rows[i]["Number_6"].ToString() + "," + table.Rows[i]["Number_7"].ToString() + ",") + table.Rows[i]["Number_8"].ToString() + "," + table.Rows[i]["Number_9"].ToString()) + ";";
                }
                if (str2.EndsWith(";"))
                {
                    str2 = str2.Substring(0, str2.Length - 1);
                }
                return str2;
            }
            catch (Exception exception)
            {
                new Log("TWZT").Write(base.GetType().FullName + exception.Message);
                return "";
            }
        }

        [AjaxMethod(HttpSessionStateRequirement.None)]
        public string GetSysTime()
        {
            return _Convert.StrToDateTime(new Views.V_GetDate().Open("", "", "").Rows[0]["Now"].ToString(), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")).ToString("yyyy/MM/dd HH:mm:ss");
        }

        [AjaxMethod(HttpSessionStateRequirement.None)]
        public string GetWinNumber(int lotteryID)
        {
            DataTable winNumber = DataCache.GetWinNumber(lotteryID);
            StringBuilder builder = new StringBuilder();
            if ((winNumber != null) && (winNumber.Rows.Count > 0))
            {
                int num = 1;
                foreach (DataRow row in winNumber.Rows)
                {
                    builder.Append("<tr>").Append("<td height=\"22\" align=\"center\" bgcolor=\"#FFFFFF\" class=\"blue12\">").Append(row["Name"].ToString()).Append("</td>").Append("<td align=\"center\" bgcolor=\"#FFFFFF\" class=\"hui12\">").Append(_Convert.StrToDateTime(row["EndTime"].ToString(), DateTime.Now.ToString()).ToString("HH:mm")).Append("</td>").Append("<td align=\"center\" bgcolor=\"#FFFFFF\" class=\"red2\">").Append(row["WinLotteryNumber"].ToString()).Append("</td>").Append("</tr>");
                    if (((num % 10) == 0) && (num != winNumber.Rows.Count))
                    {
                        builder.Append("|");
                    }
                    num++;
                }
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
            this.LotteryID = 0x1d;
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
            this.LotteryName = "时时乐";
            if (!base.IsPostBack)
            {
                long buyID = _Convert.StrToLong(Shove._Web.Utility.GetRequest("BuyID"), -1L);
                if (buyID > 0L)
                {
                    this.BindDataForAliBuy(buyID);
                }
                this.tbWin1.InnerHtml = this.BindWinList(DataCache.GetWinInfo(this.LotteryID));
                this.DZ = Encrypt.UnEncryptString(PF.GetCallCert(), Shove._Web.Utility.GetRequest("DZ"));
            }
        }

        private void SaveDataForAliBuy()
        {
            string request = Shove._Web.Utility.GetRequest("HidIsuseID");
            Shove._Web.Utility.GetRequest("HidIsuseEndTime");
            string s = Shove._Web.Utility.GetRequest("playType");
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
                            builder.Append(base.Request.Form[str20]).Append(",").Append(base.Request.Form["times" + num4.ToString()]).Append(",").Append(num5.ToString()).Append(",").Append(base.Request.Form["share" + num4.ToString()]).Append(",").Append(base.Request.Form["buyedShare" + num4.ToString()]).Append(",").Append(base.Request.Form["assureShare" + num4.ToString()]).Append(";");
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
                string[] strArray3 = new string[length * 9];
                DateTime time2 = DateTime.Parse(Functions.F_GetIsuseSystemEndTime(long.Parse(strArray2[0].Split(new char[] { ',' })[0]), int.Parse(s)).ToString());
                if (DateTime.Now >= time2)
                {
                    JavaScript.Alert(this.Page, "您选择的追号期号中包含已截止的期，请重新选择。");
                    return;
                }
                for (int i = 0; i < length; i++)
                {
                    strArray3[i * 9] = strArray2[i].Split(new char[] { ',' })[0];
                    strArray3[(i * 9) + 1] = s;
                    strArray3[(i * 9) + 2] = str21;
                    strArray3[(i * 9) + 3] = strArray2[i].Split(new char[] { ',' })[1];
                    strArray3[(i * 9) + 4] = strArray2[i].Split(new char[] { ',' })[2];
                    strArray3[(i * 9) + 5] = str12;
                    strArray3[(i * 9) + 6] = strArray2[i].Split(new char[] { ',' })[3];
                    strArray3[(i * 9) + 7] = strArray2[i].Split(new char[] { ',' })[4];
                    strArray3[(i * 9) + 8] = strArray2[i].Split(new char[] { ',' })[5];
                }
                str19 = PF.BuildIsuseAdditionasXmlForBJKL8(strArray3);
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
    }
}
