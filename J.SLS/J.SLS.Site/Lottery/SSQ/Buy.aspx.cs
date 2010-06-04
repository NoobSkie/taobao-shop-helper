using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SLS.Facade;
using System.Text;
using AjaxPro;
using HPGatewayModels;
using HPGatewayFactory;
using IHPGateway;
using Shove._Web;

public partial class Lottery_SSQ_Buy : LotteryBasePage
{
    protected override int LotteryId
    {
        get
        {
            return 5;
        }
    }

    protected override string LotteryName
    {
        get
        {
            return "双色球";
        }
    }

    protected override string LotteryCode
    {
        get { return "SSQ"; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Lottery_SSQ_Buy));
    }

    #region 客户端AJAX调用

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetSysTime()
    {
        CommonFacade facade = new CommonFacade();
        return facade.GetCurrentTime().ToString("yyyy/MM/dd HH:mm:ss");
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetIsuseInfo(int lotteryId)
    {
        try
        {
            IsuseInfo isuseInfo = lotteryFacade.GetCurrentIsuse(lotteryId);
            if (isuseInfo == null)
            {
                return "";
            }
            int num = isuseInfo.Id;
            string str3 = isuseInfo.Name;
            int num2 = DataCache.LotteryEndAheadMinute[lotteryId];
            string str4 = isuseInfo.EndTime.AddMinutes((double)(num2 * -1)).ToString("yyyy/MM/dd HH:mm:ss");
            StringBuilder builder = new StringBuilder();
            builder.Append(num.ToString()).Append(",").Append(str3).Append(",").Append(str4).Append("|").Append(this.GetIsuseChase(lotteryId));
            return builder.ToString();
        }
        catch (Exception ex)
        {
            LogWriter.Write(GetType().FullName, "Get Isuse Info", ex);
            return "";
        }
    }

    // 追号信息，生成追号表格
    private string GetIsuseChase(int lotteryId)
    {
        try
        {
            IList<IsuseInfo> isuseList = lotteryFacade.GetCommonIsuseList(lotteryId);
            if (isuseList.Count == 0)
            {
                return "";
            }
            int num = DataCache.LotteryEndAheadMinute[lotteryId];
            StringBuilder builder = new StringBuilder();
            int num2 = 0;
            builder.Append("<table cellpadding='0' cellspacing='1' style='width: 100%; text-align: center; background-color: #E2EAED;'><tbody style='background-color: White;'>");
            foreach (IsuseInfo isuseInfo in isuseList)
            {
                if (isuseInfo.StartTime > DateTime.Now
                    || (isuseInfo.StartTime < DateTime.Now && isuseInfo.EndTime > DateTime.Now.AddMinutes(num)))
                {
                    num2++;
                    #region 添加一行追号的数据

                    builder.Append("<tr>")
                        .Append("<td style='width: 10%;'>")
                        .Append("<input id='check")
                        .Append(isuseInfo.Id)
                        .Append("' type='checkbox' name='check")
                        .Append(isuseInfo.Id)
                        .Append("' onclick='check(this);' value='")
                        .Append(isuseInfo.Id)
                        .Append("'/>")
                        .Append("</td>")
                        .Append("<td style='width: 20%;'>")
                        .Append("<span>")
                        .Append(isuseInfo.Name)
                        .Append("</span>")
                        .Append("<span>")
                        .Append((num2 == 1) ? "<font color='red'>[本期]</font>" : ((num2 == 2) ? "<font color='red'>[下期]</font>" : ""))
                        .Append("</span>")
                        .Append("</td>")
                        .Append("<td style='width: 13%;'>")
                        .Append("<input name='times")
                        .Append(isuseInfo.Id)
                        .Append("' type='text' value='1' id='times")
                        .Append(isuseInfo.Id)
                        .Append("' class='TextBox' onchange='onTextChange(this);' onkeypress='return InputMask_Number();' disabled='disabled' onblur='CheckMultiple2(this);' style='width: 30px;' />倍")
                        .Append("</td>")
                        .Append("<td style='width: 14%;'>")
                        .Append("<input name='money")
                        .Append(isuseInfo.Id)
                        .Append("' type='text' value='0' id='money")
                        .Append(isuseInfo.Id)
                        .Append("' class='TextBox' disabled='disabled' style='width: 35px;' />元")
                        .Append("</td>")
                        .Append("<td style='width: 12%;'>")
                        .Append("<input name='share")
                        .Append(isuseInfo.Id)
                        .Append("' type='text' value='1' id='share")
                        .Append(isuseInfo.Id)
                        .Append("' class='TextBox'  onkeypress='return InputMask_Number();' disabled='disabled'  style='width: 30px;' onblur='CheckShare2(1,this);'/>份")
                        .Append("</td>")
                        .Append("<td style='width: 13%;'>")
                        .Append("<input name='buyedShare")
                        .Append(isuseInfo.Id)
                        .Append("' type='text' value='1' id='buyedShare")
                        .Append(isuseInfo.Id)
                        .Append("' class='TextBox'  onkeypress='return InputMask_Number();' disabled='disabled' onblur='CheckShare2(2,this);'  style='width: 35px;' />份")
                        .Append("</td>")
                        .Append("<td style='width: 15%;'>")
                        .Append("<input name='assureShare")
                        .Append(isuseInfo.Id)
                        .Append("' type='text' value='0' id='assureShare")
                        .Append(isuseInfo.Id)
                        .Append("' class='TextBox'  onkeypress='return InputMask_Number();' onblur='CheckShare2(3,this);' disabled='disabled'  style='width: 35px;' />份")
                        .Append("</td>")
                        .Append("</tr>");

                    #endregion
                }
            }
            builder.Append("</tbody></table>");
            return builder.ToString();
        }
        catch (Exception ex)
        {
            LogWriter.Write(GetType().FullName, "AlipayTask Running Error", ex);
            return "";
        }
    }

    #endregion

    protected void btn_OK_Click(object sender, EventArgs e)
    {
        DoBuy();
    }

    private void DoBuy()
    {
        string request = HidIsuseID.Value;
        string isuseName = Shove._Web.Utility.GetRequest("currIsuseName");
        string str2 = HidIsuseEndTime.Value;
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
        StringBuilder sb = new StringBuilder();
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

            AccountNumber accountN = GetAccountNumber();
            LotteryType lotteryType = LotteryType.ShangHaiWelfareLottery;
            IIssueQueryGateway gateway = GatewayFactroy.CreateIssueQueryGatewayFactory(lotteryType);
            TransactionTypeManager transTypeM = new TransactionTypeManager(lotteryType);
            TransactionType transType = transTypeM.GetTransactionTypeByTypeCode(lotteryType, "102");
            PlayMethodManager pleyMethodM = new PlayMethodManager(lotteryType);
            transType = transTypeM.GetTransactionTypeByTypeCode(lotteryType, "103");

            List<Ticket> tickets = new List<Ticket>();
            Ticket ticketOne = new Ticket();
            ticketOne.TicketId = accountN.UserName + DateTime.Now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
            string gameName = "双色球";
            ticketOne.PlayTypeInfo = pleyMethodM.GetMethodType(lotteryType, gameName).PlayTypes[0];
            ticketOne.IssueInfo = new Issue();
            ticketOne.IssueInfo.PlayMethodInfo = pleyMethodM.GetMethodType(lotteryType, gameName);
            // 期号
            ticketOne.IssueInfo.Number = isuseName;
            // 倍投数
            ticketOne.Amount = multiple.ToString();
            // 购买金额
            ticketOne.Money = assureMoney.ToString();
            // 要投注的彩票号码(测试时，每张彩票一注)
            ticketOne.AnteCodes = str12.Trim();

            UserProfile user = new UserProfile();
            // 彩票用户名
            user.UserName = CurrentUser.UserId;
            // 用户证件类型(1、身份证；2、军官证；3、护照)
            user.CardTypeInfo = (CardType)CurrentUser.CardType;
            // 证件号码
            user.CardNumber = CurrentUser.CardNumber;
            // 用户邮箱地址
            user.Mail = CurrentUser.Email;
            // 用户手机号(无纸化彩票中大奖的凭证之一)
            user.Mobile = CurrentUser.Mobile;
            // 用户真实姓名
            user.RealName = CurrentUser.RealName;

            ticketOne.UserProfile = user;
            tickets.Add(ticketOne);
            ticketOne.TicketId = accountN.UserName + DateTime.Now.ToString("yyyyMMdd") + PostManager.TenSerialNumber;
            tickets.Add(ticketOne);

            StringBuilder sbResult = new StringBuilder();
            sbResult.AppendLine("投注结果");
            sbResult.AppendLine();
            try
            {
                string result = gateway.LotteryRequest(accountN, transType, tickets);
                sbResult.AppendLine(result);
            }
            catch (Exception ex)
            {
                sbResult.AppendLine("错误");
                // sbResult.AppendLine(ex.Message);
            }
            JavaScript.Alert(this.Page, sbResult.ToString());
            return;
        }
        catch
        {
            JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
            return;
        }
    }
}
