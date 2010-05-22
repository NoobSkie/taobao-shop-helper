using AjaxPro;
using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using SLS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_Scheme : RoomPageBase, IRequiresSessionState
{
    private string dingZhi = "";
    public static Dictionary<int, string> Lotteries = new Dictionary<int, string>();
    public string LotteryID = "5";
    public string LotteryName;
    private bool Opt_FullSchemeCanQuash;
    public int PlayTypeID;
    protected long SchemeID = -1L;
    static Home_Room_Scheme()
    {
        Lotteries[0x3b] = "15X5";
        Lotteries[9] = "22X5";
        Lotteries[0x41] = "31X7";
        Lotteries[6] = "3D";
        Lotteries[0x27] = "CJDLT";
        Lotteries[0x3a] = "DF6J1";
        Lotteries[2] = "JQC";
        Lotteries[15] = "LCBQC";
        Lotteries[0x3f] = "PL3";
        Lotteries[0x40] = "PL5";
        Lotteries[13] = "QLC";
        Lotteries[3] = "QXC";
        Lotteries[1] = "SFC";
        Lotteries[0x3d] = "SSC";
        Lotteries[0x1d] = "SSL";
        Lotteries[5] = "SSQ";
        Lotteries[0x3e] = "SYYDJ";
    }

    [AjaxMethod(HttpSessionStateRequirement.Read)]
    public string AnalyseScheme(string Content, string LotteryID, int PlayTypeID)
    {
        return new Lottery()[_Convert.StrToInt(LotteryID, 5)].AnalyseScheme(Content, PlayTypeID).Trim();
    }

    private void BindData()
    {
        DataTable table = new Views.V_SchemeSchedulesWithQuashed().Open("", "SiteID = " + base._Site.ID.ToString() + " and [id] = " + Shove._Web.Utility.FilteSqlInfusion(this.tbSchemeID.Text), "");
        if ((table == null) || (table.Rows.Count < 1))
        {
            PF.GoError(4, "数据库繁忙，请重试(-141)", base.GetType().BaseType.FullName);
        }
        else
        {
            DataTable table4;
            DataRow row = table.Rows[0];
            long num = _Convert.StrToLong(row["InitiateUserID"].ToString(), 0L);
            this.hfID.Value = num.ToString();
            this.LotteryName = row["LotteryName"].ToString();
            if (this.LotteryName == "江西时时彩")
            {
                this.LotteryName = this.LotteryName.Replace("江西", "");
            }
            this.Label3.Text = this.LotteryName + "<font class='red14'>" + row["IsuseName"].ToString() + "</font>期" + row["PlayTypeName"].ToString() + "认购方案";
            this.labTitle.Text = row["IsuseName"].ToString();
            this.labStartTime.Text = row["StartTime"].ToString();
            this.tbIsuseID.Text = row["IsuseID"].ToString();
            this.tbLotteryID.Text = row["LotteryID"].ToString();
            this.LotteryID = this.tbLotteryID.Text;
            this.PlayTypeID = _Convert.StrToInt(row["PlayTypeID"].ToString(), 0);
            this.labEndTime.Text = row["SystemEndTime"].ToString();
            if (_Convert.StrToInt(row["LotteryID"].ToString(), 0) == 0x2d)
            {
                string scheme = row["LotteryNumber"].ToString();
                string buyContent = "";
                string cnLocateWaysAndMultiples = "";
                Lottery lottery = new Lottery();
                if (lottery["45"].GetSchemeSplit(scheme, ref buyContent, ref cnLocateWaysAndMultiples))
                {
                    string str4 = buyContent.Split(new char[] { '|' })[0].ToString();
                    DataTable table2 = new Views.V_IsuseForZCDC().Open("DateTime", "[IsuseID]=" + this.tbIsuseID.Text + " and [No]=" + str4.Split(new char[] { '(' })[0], "");
                    if ((table2 == null) || (table2.Rows.Count == 0))
                    {
                        PF.GoError(4, "数据库繁忙，请重试(-184)", base.GetType().FullName);
                        return;
                    }
                    DataTable table3 = new Tables.T_PlayTypes().Open("SystemEndAheadMinute", "[ID] = " + row["PlayTypeID"], "");
                    this.labEndTime.Text = _Convert.StrToDateTime(table2.Rows[0][0].ToString(), DateTime.Now.ToString()).AddMinutes(_Convert.StrToDouble(table3.Rows[0][0].ToString(), 0.0)).ToString();
                }
            }
            this.labInitiateUser.Text = row["InitiateName"].ToString() + "&nbsp;&nbsp;【<A class=li3 href='../Web/Score.aspx?id=" + row["InitiateUserID"].ToString() + "&LotteryID=" + this.tbLotteryID.Text + "' target='_blank'>发起人历史战绩</A>】";
            short num2 = _Convert.StrToShort(row["QuashStatus"].ToString(), 0);
            Shove._Web.Cache.SetCache("All_QuashStatus" + this.SchemeID, num2, 0xe10);
            bool flag = _Convert.StrToBool(row["Buyed"].ToString(), false);
            int num3 = _Convert.StrToInt(row["Share"].ToString(), 0);
            int num4 = _Convert.StrToInt(row["BuyedShare"].ToString(), 0);
            double num5 = _Convert.StrToDouble(row["Money"].ToString(), 0.0);
            double num6 = _Convert.StrToDouble(row["AssureMoney"].ToString(), 0.0);
            double num7 = _Convert.StrToDouble(row["WinMoney"].ToString(), 0.0);
            short num8 = _Convert.StrToShort(row["SecrecyLevel"].ToString(), 0);
            bool flag2 = false;
            _Convert.StrToBool(row["isCanChat"].ToString(), false);
            if (num3 > 1)
            {
                this.trBonusScale.Visible = true;
                this.lbSchemeBonus.Text = ((_Convert.StrToDouble(row["SchemeBonusScale"].ToString(), 0.04) * 100.0)).ToString() + "%";
            }
            this.HidSchedule.Value = row["Schedule"].ToString();
            table4 = table4 = new Views.V_Isuses().Open("IsOpened, WinLotteryNumber,Code", "[id] = " + row["IsuseID"].ToString(), "");
            if (table4 == null)
            {
                PF.GoError(4, "数据库繁忙，请重试(-213)", base.GetType().FullName);
            }
            else if (table4.Rows.Count < 1)
            {
                PF.GoError(1, "系统错误(-220)", base.GetType().FullName);
            }
            else
            {
                flag2 = _Convert.StrToBool(table4.Rows[0]["IsOpened"].ToString(), true);
                this.lbWinNumber.Text = table4.Rows[0]["WinLotteryNumber"].ToString();
                this.ImageLogo.ImageUrl = "images/lottery/" + table4.Rows[0]["Code"].ToString().ToLower() + ".jpg";
                if (!base._Site.SiteOptions["Opt_FullSchemeCanQuash"].ToBoolean(false))
                {
                    this.btnQuashScheme.Visible = (((num2 == 0) && !flag) && ((num3 > num4) && (base._User != null))) && (num == base._User.ID);
                }
                else
                {
                    this.btnQuashScheme.Visible = (((num2 == 0) && !flag) && (base._User != null)) && (num == base._User.ID);
                }
                short num10 = _Convert.StrToShort(row["AtTopStatus"].ToString(), 0);
                bool flag4 = num10 != 0;
                if (num10 == 0)
                {
                    this.cbAtTopApplication.Visible = (((num2 == 0) && !flag) && ((num3 > num4) && (base._User != null))) && (num == base._User.ID);
                    this.cbAtTopApplication.Checked = flag4;
                }
                else
                {
                    this.labAtTop.Visible = true;
                }
                bool flag5 = false;
                bool flag6 = false;
                DateTime time5 = _Convert.StrToDateTime(this.labEndTime.Text, DateTime.Now.ToString());
                if (DateTime.Now >= time5)
                {
                    flag6 = true;
                    this.tbStop.Text = flag6.ToString();
                }
                if (num2 > 0)
                {
                    if (num2 == 2)
                    {
                        this.labState.Text = "已撤单(系统撤单)";
                    }
                    else
                    {
                        this.labState.Text = "已撤单";
                    }
                }
                else if (flag6)
                {
                    this.labState.Text = "已截止";
                }
                else if (flag)
                {
                    this.labState.Text = "<FONT color='red'>已成功</font>";
                }
                else if (num3 <= num4)
                {
                    this.labState.Text = "<FONT color='red'>已满员</font>";
                }
                else
                {
                    this.labState.Text = "<font color='red'>抢购中...</font>";
                    flag5 = true;
                }
                this.labMultiple.Text = row["Multiple"].ToString();
                if (((num8 == 1) && !flag6) && ((base._User == null) || (((base._User != null) && (num != base._User.ID)) && !base._User.isOwnedViewSchemeCompetence())))
                {
                    this.labLotteryNumber.Text = "投注内容已经被保密，将在本期投注截止后公开。";
                }
                else if (((num8 == 2) && !flag2) && ((base._User == null) || (((base._User != null) && (num != base._User.ID)) && !base._User.isOwnedViewSchemeCompetence())))
                {
                    this.labLotteryNumber.Text = "投注内容已经被保密，将在本期开奖后公开。";
                }
                else if ((num8 == 3) && ((base._User == null) || (((base._User != null) && (num != base._User.ID)) && !base._User.isOwnedViewSchemeCompetence())))
                {
                    this.labLotteryNumber.Text = "投注内容已经被保密。";
                }
                else
                {
                    int num11 = base._Site.SiteOptions["Opt_MaxShowLotteryNumberRows"].ToShort(0);
                    string str = "";
                    try
                    {
                        str = row["LotteryNumber"].ToString();
                    }
                    catch
                    {
                    }
                    if (_String.StringAt(str, '\n') < num11)
                    {
                        if (new Lottery.ZCDC().CheckPlayType(_Convert.StrToInt(row["PlayTypeID"].ToString(), -1)))
                        {
                            string vote = "";
                            DataTable table5 = PF.GetZCDCBuyContent(str, this.SchemeID, ref vote);
                            if (table5 == null)
                            {
                                PF.GoError(4, "数据访问错误(-358)", base.GetType().FullName);
                                return;
                            }
                            this.labMultiple.Text = vote;
                            this.rptScheme.DataSource = table5;
                            this.rptScheme.DataBind();
                            this.rptScheme.Visible = true;
                        }
                        else
                        {
                            this.labLotteryNumber.Text = _Convert.ToHtmlCode(str) + "&nbsp;";
                            if (flag2)
                            {
                                this.NumberDuiBi(this.labLotteryNumber.Text, this.lbWinNumber.Text, this.PlayTypeID);
                            }
                        }
                    }
                    else
                    {
                        this.linkDownloadScheme.Visible = true;
                        this.linkDownloadLotteryIdentifiers.Visible = (base._User == null) || ((base._User != null) && ((base._User.ID.ToString() == row["InitiateUserID"].ToString()) || base._User.Competences["Administrator"]));
                        this.linkDownloadLotteryIdentifiers.NavigateUrl = "../Web/DownLotteryIdentifiers.aspx?id=" + this.tbSchemeID.Text;
                        this.linkDownloadScheme.NavigateUrl = "../Web/DownloadSchemeFile.aspx?id=" + this.tbSchemeID.Text;
                    }
                }
                this.labSchemeNumber.Text = row["SchemeNumber"].ToString();
                this.labSchemeDateTime.Text = row["DateTime"].ToString();
                this.labSchemeMoney.Text = _Convert.StrToDouble(row["Money"].ToString(), 0.0).ToString("N");
                this.labSchemeTitle.Text = row["Title"].ToString() + "&nbsp;";
                this.labSchemeDescription.Text = row["Description"].ToString() + "&nbsp;";
                this.labSchemeADUrl.Text = Shove._Web.Utility.GetUrl() + "/Home/Room/Scheme.aspx?id=" + this.tbSchemeID.Text;
                object[] args = new object[] { this.labSchemeMoney.Text, num3, (num5 / ((double)num3)).ToString("N"), num4, ((num5 / ((double)num3)) * num4).ToString("N") };
                this.labSchemeDetail.Text = string.Format("此方案总金额 <FONT color='red'>{0}</font> 元，共 <FONT color='red'>{1}</font> 份，每份 <FONT color='red'>{2}</font> 元。<br />已认购 <FONT color='red'>{3}</font> 份（金额 <FONT color='red'>{4}</font> 元）", args) + (flag5 ? string.Format("，还有 <FONT color='red'>{0}</font> 份（金额 <FONT color='red'>{1}</font> 元）可以认购！", num3 - num4, ((num5 / ((double)num3)) * (num3 - num4)).ToString("N")) : "");
                if ((string.IsNullOrEmpty(row["LotteryNumber"].ToString()) && (((this.LotteryID == "1") || (this.LotteryID == "2")) || (this.LotteryID == "15"))) && (((num2 == 0) && !flag6) && !flag))
                {
                    this.labLotteryNumber.Text = "未上传";
                    if ((base._User != null) && (row["InitiateUserID"].ToString() == base._User.ID.ToString()))
                    {
                        this.lbUploadScheme.Visible = true;
                    }
                }
                if (flag)
                {
                    this.labLotteryCode.Text = "已出票，彩票标识：";
                    this.linkDownloadLotteryIdentifiers.Visible = true;
                    this.linkDownloadLotteryIdentifiers.NavigateUrl = "../Web/DownLotteryIdentifiers.aspx?id=" + this.tbSchemeID.Text;
                }
                else
                {
                    this.labLotteryCode.Text = "暂未出票";
                    this.linkDownloadLotteryIdentifiers.Visible = false;
                }
                this.labAssureMoney.Text = (num6 > 0.0) ? string.Format("发起人保底 <FONT color='red'>{0}</font> 份，<FONT color='red'>{1}</font> 元", Math.Round((double)(num6 / (num5 / ((double)num3))), 0).ToString(), num6.ToString("N")) : "未保底";
                if (num2 > 0)
                {
                    if (num2 == 2)
                    {
                        this.labWin.Text = "已撤单(系统撤单)";
                    }
                    else
                    {
                        this.labWin.Text = "已撤单";
                    }
                }
                else if (flag6)
                {
                    this.labWin.Text = string.Format("<FONT color='red'>{0}</font> 元", num7.ToString("N"));
                    string str7 = row["WinDescription"].ToString();
                    if (str7 != "")
                    {
                        this.labWin.Text = this.labWin.Text + "<br />" + str7;
                    }
                    else if (flag2)
                    {
                        this.labWin.Text = this.labWin.Text + "  未中奖";
                    }
                    else
                    {
                        this.labWin.Text = this.labWin.Text + "  <font color='red'>【注】</font>中奖结果在开奖后需要一段时间才能显示。";
                    }
                }
                else
                {
                    this.labWin.Text = "尚未截止";
                }
                if (flag2 && (((this.LotteryID == "1") || (this.LotteryID == "2")) || (this.LotteryID == "15")))
                {
                    this.labWin.Text = this.labWin.Text + "(命中<font color='red'>" + this.CompareLotteryNumberToWinNumber(row["LotteryNumber"].ToString(), row["WinLotteryNumber"].ToString()).ToString() + "</font>场)";
                }
                if (flag6)
                {
                    this.labCannotBuyTip.Text = "方案已截止，不能认购";
                    this.labCannotBuyTip.Visible = true;
                    this.pBuy.Visible = false;
                    this.btnOK.Enabled = false;
                }
                else if (num2 > 0)
                {
                    this.labCannotBuyTip.Text = "方案已撤单，不能认购";
                    this.labCannotBuyTip.Visible = true;
                    this.pBuy.Visible = false;
                    this.btnOK.Enabled = false;
                }
                else if (num4 >= num3)
                {
                    this.labCannotBuyTip.Text = "方案已满员，不能认购";
                    this.labCannotBuyTip.Visible = true;
                    this.pBuy.Visible = false;
                    this.btnOK.Enabled = false;
                }
                else
                {
                    this.labCannotBuyTip.Visible = false;
                    this.pBuy.Visible = true;
                    this.btnOK.Enabled = true;
                }
                this.labShare.Text = (num3 - num4).ToString();
                this.labShareMoney.Text = (num5 / ((double)num3)).ToString("N");
                this.BindDataForUserList();
                if (base._User != null)
                {
                    DataTable dt = new Views.V_BuyDetailsWithQuashedAll().Open("[id],[DateTime],[Money],Share,SchemeShare,BuyedShare,QuashStatus,Buyed,IsuseID,Code,Schedule,DetailMoney,isWhenInitiate, WinMoneyNoWIthTax", "SiteID = " + base._Site.ID.ToString() + " and SchemeID = " + Shove._Web.Utility.FilteSqlInfusion(this.tbSchemeID.Text) + " and [UserID] = " + base._User.ID.ToString(), "[id]");
                    if (dt == null)
                    {
                        PF.GoError(4, "数据库繁忙，请重试(-518)", base.GetType().FullName);
                    }
                    else
                    {
                        if (dt.Rows.Count == 0)
                        {
                            this.labMyBuy.Text = "此方案还没有我的认购记录。";
                            this.labMyBuy.Visible = true;
                            this.g.Visible = false;
                        }
                        else
                        {
                            this.labMyBuy.Visible = false;
                            this.g.Visible = true;
                            PF.DataGridBindData(this.g, dt);
                            if (flag2)
                            {
                                double num23 = 0.0;
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    num23 += double.Parse(dt.Rows[i]["WinMoneyNoWIthTax"].ToString());
                                }
                                this.lbReward.Text = num23.ToString("N");
                            }
                        }
                        if (base._User.UserType < 2)
                        {
                            this.btnOK.Enabled = false;
                            this.btnQuashScheme.Enabled = false;
                        }
                    }
                }
            }
        }
    }

    private void BindDataForUserList()
    {
        string commandText = "select * from V_BuyDetailsWithQuashed with (nolock) where SiteID = @SiteID and SchemeID = @SchemeID and QuashStatus = 0 order by [id]";
        if (_Convert.StrToInt(Shove._Web.Cache.GetCache("All_QuashStatus" + this.SchemeID).ToString(), 0) == 2)
        {
            commandText = "SELECT dbo.T_BuyDetails.DateTime, dbo.T_BuyDetails.Share,dbo.T_BuyDetails.Share * (dbo.T_Schemes.Money / dbo.T_Schemes.Share) AS DetailMoney, dbo.T_Users.Name FROM dbo.T_BuyDetails INNER JOIN   dbo.T_Users ON dbo.T_BuyDetails.UserID = dbo.T_Users.ID INNER JOIN dbo.T_Schemes ON dbo.T_BuyDetails.SchemeID = dbo.T_Schemes.ID AND dbo.T_BuyDetails.QuashStatus <> 1 where T_Schemes.SiteID = @SiteID and SchemeID = @SchemeID order by T_Schemes.[id]";
        }
        DataTable table = MSSQL.Select(commandText, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, base._Site.ID), new MSSQL.Parameter("SchemeID", SqlDbType.VarChar, 0, ParameterDirection.Input, Shove._Web.Utility.FilteSqlInfusion(this.tbSchemeID.Text)) });
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试(-503)", base.GetType().FullName);
        }
        else
        {
            this.labUserList.Text = string.Format("总共有 <font color='red'>{0}</font> 个用户参与。", table.Rows.Count) + ((table.Rows.Count > 0) ? "&nbsp;&nbsp;【<A class=li3 href='javascript:onUserListClick();'>打开/隐藏明细</A>】" : "");
            this.gUserList.DataSource = table.DefaultView;
            this.gUserList.DataBind();
        }
    }

    protected void btn_All_Click(object sender, ImageClickEventArgs e)
    {
        this.ResponseTailor(false);
    }

    protected void btn_Single_Click(object sender, EventArgs e)
    {
        this.ResponseTailor(true);
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (base._User.UserType == 1)
        {
            JavaScript.Alert(this.Page, "对不起，您还不是高级会员，请先免费升级为高级会员。谢谢！");
        }
        else if (this.panelInvestPassword.Visible && (PF.EncryptPassword(this.tbInvestPassword.Text) != base._User.PasswordAdv))
        {
            JavaScript.Alert(this.Page, "投注密码错误！");
        }
        else
        {
            DateTime time = DateTime.Parse(this.labEndTime.Text);
            if (DateTime.Now > time)
            {
                JavaScript.Alert(this.Page, "投注时间已经截止，不能认购。");
            }
            else if (!base._User.isCanViewSchemeContent(this.SchemeID))
            {
                JavaScript.Alert(this.Page, "对不起，您不在此方案的招股对象之内。");
            }
            else
            {
                double num = 0.0;
                int share = 0;
                try
                {
                    num = double.Parse(this.labShareMoney.Text);
                    share = int.Parse(this.tbShare.Text);
                }
                catch
                {
                    JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
                    return;
                }
                if (((num > 0.0) && (share >= 1)) && (share <= _Convert.StrToInt(this.labShare.Text, 0)))
                {
                    if ((num * share) > base._User.Balance)
                    {
                        JavaScript.Alert(this.Page, "您的账户余额不足，请先充值，谢谢。");
                    }
                    else
                    {
                        string returnDescription = "";
                        if ((base._User.JoinScheme((long)int.Parse(this.tbSchemeID.Text), share, ref returnDescription) >= 0) && !(returnDescription != ""))
                        {
                            this.tbShare.Text = "";
                            Shove._Web.Cache.ClearCache("Home_Room_CoBuy_BindDataForType" + this.tbIsuseID.Text);
                            Shove._Web.Cache.ClearCache("Home_Room_SchemeAll_BindData" + this.tbIsuseID.Text);
                            Shove._Web.Cache.ClearCache("Home_Room_JoinAllBuy_BindData");
                            string[] strArray4 = new string[] { "<script>try{window.opener.parent.ReloadSchedule();} catch(ex) {};window.location.href='UserBuySuccess.aspx?LotteryID=", this.LotteryID.ToString(), "&Type=3&Money=", (num * share).ToString(), "&SchemeID=", this.tbSchemeID.Text, "'</script>" };
                            base.Response.Write(string.Concat(strArray4));
                        }
                        else
                        {
                            if (returnDescription.IndexOf("方案剩余份数已不足") > -1)
                            {
                                try
                                {
                                    string str2 = returnDescription.Split(new string[] { ",剩余 " }, StringSplitOptions.None)[1].Split(new char[] { ' ' })[0].ToString();
                                    ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "alert('" + returnDescription + "');document.getElementById('tbShare').value='" + str2 + "';document.getElementById('labShare').innerText='" + str2 + "';", true);
                                    return;
                                }
                                catch
                                {
                                    string[] strArray3 = new string[] { "alert('方案剩余份数已不足 ", share.ToString(), " 份');document.getElementById('tbShare').value='", (share - 1).ToString(), "';" };
                                    ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", string.Concat(strArray3), true);
                                    return;
                                }
                            }
                            JavaScript.Alert(this.Page, returnDescription);
                        }
                    }
                }
                else
                {
                    JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
                }
            }
        }
    }

    protected void btnQuashScheme_Click(object sender, EventArgs e)
    {
        if (base._User.UserType == 1)
        {
            JavaScript.Alert(this.Page, "对不起，您还不是高级会员，请先免费升级为高级会员。谢谢！");
        }
        else if (this.panelInvestPassword.Visible && (PF.EncryptPassword(this.tbInvestPassword.Text) != base._User.PasswordAdv))
        {
            JavaScript.Alert(this.Page, "投注密码错误！");
        }
        else
        {
            DateTime time = DateTime.Parse(this.labEndTime.Text);
            if (DateTime.Now > time)
            {
                JavaScript.Alert(this.Page, "投注时间已经截止，不能撤消方案。");
            }
            else
            {
                double num = _Convert.StrToDouble(new SystemOptions()["Betting_ForbidenCancel_Percent"].Value.ToString(), 0.0);
                if ((num > 0.0) && (_Convert.StrToDouble(this.HidSchedule.Value, -1.0) >= num))
                {
                    JavaScript.Alert(this.Page, "对不起，由于本方案进度已经达到 " + num.ToString("N") + "%，即将满员，不允许撤单。");
                }
                else
                {
                    string returnDescription = "";
                    if (base._User.QuashScheme((long)int.Parse(this.tbSchemeID.Text), false, ref returnDescription) < 0)
                    {
                        PF.GoError(1, returnDescription, base.GetType().FullName);
                    }
                    else
                    {
                        Shove._Web.Cache.ClearCache("Home_Room_CoBuy_BindDataForType" + this.tbIsuseID.Text);
                        Shove._Web.Cache.ClearCache("Home_Room_SchemeAll_BindData" + this.tbIsuseID.Text);
                        this.BindData();
                    }
                }
            }
        }
    }

    protected void cbAtTopApplication_CheckedChanged(object sender, EventArgs e)
    {
        int num = this.cbAtTopApplication.Checked ? 1 : 0;
        if (MSSQL.ExecuteNonQuery("update T_Schemes set AtTopStatus = " + num.ToString() + " where SiteID = " + base._Site.ID.ToString() + " and [id] = " + Shove._Web.Utility.FilteSqlInfusion(this.tbSchemeID.Text), new MSSQL.Parameter[0]) < 0)
        {
            PF.GoError(4, "数据库繁忙，请重试(-678)", base.GetType().FullName);
        }
        else
        {
            this.BindData();
        }
    }

    private int CompareLotteryNumberToWinNumber(string LotteryNumber, string WinNumber)
    {
        string[] strArray = LotteryNumber.Trim().Split(new char[] { '\n' });
        int num = 0;
        foreach (string str in strArray)
        {
            bool flag = false;
            int startIndex = -1;
            int num4 = 0;
            for (int i = 0; i < str.Trim().Length; i++)
            {
                if (!flag)
                {
                    startIndex++;
                }
                string str2 = str.Trim().Substring(i, 1);
                if (str2 == "(")
                {
                    flag = true;
                }
                else if (str2 == ")")
                {
                    flag = false;
                }
                else if (str2 == WinNumber.Substring(startIndex, 1))
                {
                    num4++;
                }
            }
            if (num4 > num)
            {
                num = num4;
            }
        }
        return num;
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "QuashBuy")
        {
            double num = _Convert.StrToDouble(new SystemOptions()["Betting_ForbidenCancel_Percent"].Value.ToString(), 0.0);
            if ((num > 0.0) && (_Convert.StrToDouble(this.HidSchedule.Value, -1.0) >= num))
            {
                JavaScript.Alert(this.Page, "对不起，由于本方案进度已经达到 " + num.ToString("N") + "%，即将满员，不允许撤单。");
            }
            else
            {
                long buyDetailID = _Convert.StrToLong(e.Item.Cells[12].Text, 0L);
                if (buyDetailID < 1L)
                {
                    PF.GoError(1, "参数错误(-694)", base.GetType().FullName);
                }
                else
                {
                    string returnDescription = "";
                    if (base._User.Quash(buyDetailID, ref returnDescription) < 0)
                    {
                        PF.GoError(1, returnDescription + "(-703)", base.GetType().FullName);
                    }
                    else
                    {
                        this.BindData();
                        Shove._Web.Cache.ClearCache("Home_Room_CoBuy_BindDataForType" + this.tbIsuseID.Text);
                        Shove._Web.Cache.ClearCache("Home_Room_SchemeAll_BindData" + this.tbIsuseID.Text);
                    }
                }
            }
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[0].Text = "<font color='red'>" + e.Item.Cells[0].Text + "</font> 份";
            double num = _Convert.StrToDouble(e.Item.Cells[1].Text, 0.0);
            e.Item.Cells[1].Text = "<font color='red'>" + ((num == 0.0) ? "0.00" : num.ToString("N")) + "</font> 元";
            e.Item.Cells[2].Text = e.Item.Cells[8].Text + e.Item.Cells[9].Text + e.Item.Cells[12].Text;
            short num2 = _Convert.StrToShort(e.Item.Cells[6].Text, 0);
            bool flag = _Convert.StrToBool(e.Item.Cells[7].Text, false);
            bool flag2 = _Convert.StrToBool(this.tbStop.Text, false);
            double num3 = _Convert.StrToDouble(e.Item.Cells[11].Text, 0.0);
            int num4 = _Convert.StrToInt(e.Item.Cells[14].Text, 0);
            int num5 = _Convert.StrToInt(e.Item.Cells[10].Text, 0);
            Button button = (Button)e.Item.Cells[5].FindControl("btnQuashBuy");
            if (num2 > 0)
            {
                button.Enabled = false;
                e.Item.Cells[4].Text = "已撤单";
            }
            else if (flag2)
            {
                if (num3 >= 100.0)
                {
                    e.Item.Cells[4].Text = "<Font color='Red'>已成功</font>";
                }
                else
                {
                    e.Item.Cells[4].Text = "未成功";
                }
                button.Enabled = false;
            }
            else
            {
                if (flag)
                {
                    e.Item.Cells[4].Text = "<Font color='Red'>已出票</font>";
                    button.Enabled = false;
                }
                else
                {
                    e.Item.Cells[4].Text = "<Font color='Red'>进行中</font>";
                }
                bool flag3 = _Convert.StrToBool(e.Item.Cells[13].Text, true);
                bool flag4 = num4 <= num5;
                if (flag3)
                {
                    button.Enabled = false;
                }
                else if (flag4)
                {
                    button.Enabled = ((base._User != null) && this.Opt_FullSchemeCanQuash) && (base._User.UserType > 1);
                }
                else
                {
                    button.Enabled = (base._User != null) && (base._User.UserType > 1);
                }
            }
        }
    }

    [AjaxMethod(HttpSessionStateRequirement.Read)]
    public string GetUserBalance()
    {
        return Users.GetCurrentUser(1L).Balance.ToString("N");
    }

    protected void gUserList_PageIndexChanged(object sender, EventArgs e)
    {
        this.BindDataForUserList();
    }

    private void NumberDuiBi(string LotteryNumber, string WinLotteryNumber, int PlayTypeID)
    {
        if (this.LotteryID == "62")
        {
            string str = LotteryNumber.Replace("&nbsp;", " ").Replace("<br/>", " ").Trim();
            string[] strArray = null;
            string[] strArray2 = WinLotteryNumber.Split(new char[] { ' ' });
            if (((PlayTypeID == 0x1839) || (PlayTypeID == 0x1841)) || (PlayTypeID == 0x1842))
            {
                strArray = str.Replace(" ", "|").Split(new char[] { '|' });
                if (PlayTypeID == 0x1839)
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (strArray[i] == strArray2[0])
                        {
                            LotteryNumber = LotteryNumber.Replace(strArray[i], "<font color='Red'>" + strArray[i] + "</font>");
                        }
                    }
                }
                else if (PlayTypeID == 0x1841)
                {
                    LotteryNumber = "";
                    for (int j = 0; j < strArray.Length; j++)
                    {
                        if (((j % 2) == 0) && (strArray[j] == strArray2[0]))
                        {
                            LotteryNumber = LotteryNumber + "<font color='Red'>" + strArray[j] + "</font>|";
                        }
                        else if (((j % 2) == 1) && (strArray[j] == strArray2[1]))
                        {
                            LotteryNumber = LotteryNumber + "<font color='Red'>" + strArray[j] + "</font>|";
                        }
                        else
                        {
                            LotteryNumber = LotteryNumber + strArray[j] + "|";
                        }
                        if ((j % 2) == 1)
                        {
                            LotteryNumber = LotteryNumber + "<br>";
                        }
                    }
                }
                else
                {
                    LotteryNumber = "";
                    for (int k = 0; k < strArray.Length; k++)
                    {
                        if (((k % 3) == 0) && (strArray[k] == strArray2[0]))
                        {
                            LotteryNumber = LotteryNumber + "<font color='Red'>" + strArray[k] + "</font>|";
                        }
                        else if (((k % 3) == 1) && (strArray[k] == strArray2[1]))
                        {
                            LotteryNumber = LotteryNumber + "<font color='Red'>" + strArray[k] + "</font>|";
                        }
                        else if (((k % 3) == 2) && (strArray[k] == strArray2[2]))
                        {
                            LotteryNumber = LotteryNumber + "<font color='Red'>" + strArray[k] + "</font>|";
                        }
                        else
                        {
                            LotteryNumber = LotteryNumber + strArray[k] + "|";
                        }
                        if ((k % 3) == 2)
                        {
                            LotteryNumber = LotteryNumber + "<br>";
                        }
                    }
                }
                this.labLotteryNumber.Text = LotteryNumber;
            }
            else if ((PlayTypeID == 0x1843) || (PlayTypeID == 0x1844))
            {
                string[] strArray3 = LotteryNumber.Replace("<br/>", " ").Split(new char[] { ' ' });
                string[] strArray4 = null;
                LotteryNumber = "";
                if (PlayTypeID == 0x1844)
                {
                    for (int m = 0; m < strArray3.Length; m++)
                    {
                        strArray4 = strArray3[m].Replace("&nbsp;", " ").Split(new char[] { ' ' });
                        for (int n = 0; n < strArray4.Length; n++)
                        {
                            if (((strArray4[n] == strArray2[0]) || (strArray4[n] == strArray2[1])) || (strArray4[n] == strArray2[2]))
                            {
                                LotteryNumber = LotteryNumber + "<font color='Red'>" + strArray4[n] + "</font>&nbsp;";
                            }
                            else
                            {
                                LotteryNumber = LotteryNumber + strArray4[n] + "&nbsp;";
                            }
                        }
                        LotteryNumber = LotteryNumber + "<br>";
                    }
                }
                else
                {
                    for (int num6 = 0; num6 < strArray3.Length; num6++)
                    {
                        strArray4 = strArray3[num6].Replace("&nbsp;", " ").Split(new char[] { ' ' });
                        for (int num7 = 0; num7 < strArray4.Length; num7++)
                        {
                            if ((strArray4[num7] == strArray2[0]) || (strArray4[num7] == strArray2[1]))
                            {
                                LotteryNumber = LotteryNumber + "<font color='Red'>" + strArray4[num7] + "</font>&nbsp;";
                            }
                            else
                            {
                                LotteryNumber = LotteryNumber + strArray4[num7] + "&nbsp;";
                            }
                        }
                        LotteryNumber = LotteryNumber + "<br>";
                    }
                }
                this.labLotteryNumber.Text = LotteryNumber;
            }
            else
            {
                foreach (string str2 in str.Replace("|", " ").Split(new char[] { ' ' }))
                {
                    if (WinLotteryNumber.IndexOf(str2) > -1)
                    {
                        LotteryNumber = LotteryNumber.Replace(str2, "<font color='Red'>" + str2 + "</font>");
                    }
                }
                this.labLotteryNumber.Text = LotteryNumber;
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isRequestLogin = false;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Home_Room_Scheme), this.Page);
        this.SchemeID = _Convert.StrToLong(Shove._Web.Utility.GetRequest("id"), -1L);
        if (this.SchemeID < 1L)
        {
            PF.GoError(1, "参数错误(-26)", base.GetType().FullName);
        }
        else
        {
            this.Opt_FullSchemeCanQuash = base._Site.SiteOptions["Opt_FullSchemeCanQuash"].ToBoolean(false);
            if (!base.IsPostBack)
            {
                this.tbSchemeID.Text = this.SchemeID.ToString();
                if (base._User != null)
                {
                    this.labBalance.Text = base._User.Balance.ToString("N");
                }
                this.BindData();
                bool flag = base._Site.SiteOptions["Opt_isBuyValidPasswordAdv"].ToBoolean(false);
                if (flag)
                {
                    flag = false;
                }
                this.panelInvestPassword.Visible = flag;
            }
        }
    }

    private void ResponseTailor(bool b)
    {
        long num = _Convert.StrToLong(this.hfID.Value, -1L);
        int lotteryID = _Convert.StrToInt(this.tbLotteryID.Text, -1);
        int num3 = -1;
        if (b)
        {
            num3 = lotteryID;
        }
        string str = string.Concat(new object[] { "followScheme(", num3, ");$Id(\"iframeFollowScheme\").src=\"../Home/Room/FollowFriendSchemeAdd.aspx?LotteryID=", num3, "&DzLotteryID=", num3 });
        if (num < 1L)
        {
            PF.GoError(1, "参数错误", base.GetType().FullName);
        }
        else if (!new Lottery().ValidID(lotteryID))
        {
            PF.GoError(1, "参数错误！(彩种)", base.GetType().FullName);
        }
        else
        {
            Users users = new Users(base._Site.ID)
            {
                ID = num
            };
            this.dingZhi = string.Concat(new object[] { "&FollowUserID=", num, "&FollowUserName=", HttpUtility.UrlEncode(users.Name), "\"" });
            string returnDescription = "";
            if (users.GetUserInformationByID(ref returnDescription) == 0)
            {
                this.dingZhi = Encrypt.EncryptString(PF.GetCallCert(), str + this.dingZhi);
                base.Response.Redirect("../../Lottery/Buy_" + Lotteries[lotteryID] + ".aspx?DZ=" + this.dingZhi);
            }
        }
    }

    [AjaxMethod(HttpSessionStateRequirement.Read)]
    public string UpdateLotteryNumber(string id, string content)
    {
        if (new Tables.T_Schemes { LotteryNumber = { Value = content } }.Update("ID=" + id) < 0L)
        {
            return "修改方案号码失败！";
        }
        return "上传成功！";
    }
}

