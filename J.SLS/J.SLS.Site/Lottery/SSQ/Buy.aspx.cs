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
using J.SLS.Common.Logs;
using J.SLS.Common.Xml;
using J.SLS.Common;

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
    public string GetIsuseInfo(string gameName)
    {
        try
        {
            IssuseInfo isuseInfo = lotteryFacade.GetCurrentIsuse(gameName);
            if (isuseInfo == null)
            {
                return "";
            }
            long issueId = isuseInfo.Id;
            string number = isuseInfo.IssuseNumber;
            int aheadMinute = DataCache.LotteryEndAheadMinute[gameName];
            string stopTime = isuseInfo.StopTime.AddMinutes((double)(aheadMinute * -1)).ToString("yyyy/MM/dd HH:mm:ss");

            return string.Format("{0},{1},{2}", issueId, number, stopTime);
        }
        catch (Exception ex)
        {
            LogWriter.Write(LogCategory.Issue, "Get Isuse Info", ex);
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
        string issueIdString = HidIsuseID.Value;
        string isuseNumber = Shove._Web.Utility.GetRequest("currIsuseName");
        string endTime = HidIsuseEndTime.Value;
        string playTypeString = Shove._Web.Utility.GetRequest("playType");
        string lotteryNumber = Shove._Web.Utility.FilteSqlInfusion(base.Request["tb_LotteryNumber"]);
        string sumMoneyString = Shove._Web.Utility.GetRequest("tb_hide_SumMoney");
        string sumNumberString = Shove._Web.Utility.GetRequest("tb_hide_SumNum");
        string lotteryIdString = Shove._Web.Utility.GetRequest("HidLotteryID");
        string multipleString = Shove._Web.Utility.GetRequest("tb_Multiple");
        if (multipleString == "")
        {
            multipleString = "1";
        }
        StringBuilder sb = new StringBuilder();
        try
        {
            HPBuyRequestInfo requestInfo = new HPBuyRequestInfo();

            double money = double.Parse(sumMoneyString);
            int multiple = int.Parse(multipleString);
            int sumNumber = int.Parse(sumNumberString);
            int playType = int.Parse(playTypeString);
            int lotteryId = int.Parse(lotteryIdString);
            long isuseId = long.Parse(issueIdString);

            string messengerId = GetAgenceAccountUserName();
            string userPassword = GetAgenceAccountPassword();
            string messageId = messengerId + DateTime.Now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");

            IssueInfo issueInfo = new IssueInfo();
            issueInfo.GameName = LotteryCode;
            issueInfo.Number = isuseNumber;

            UserProfileInfo userProfile = new UserProfileInfo();
            userProfile.UserName = CurrentUser.UserId;
            userProfile.CardType = (J.SLS.Common.CardType)CurrentUser.CardType;
            userProfile.CardNumber = CurrentUser.CardNumber;
            userProfile.Mail = CurrentUser.Email;
            userProfile.Mobile = CurrentUser.Mobile;
            userProfile.RealName = CurrentUser.RealName;
            userProfile.BonusPhone = CurrentUser.Mobile;

            List<string> anteCodes = new List<string>();
            lotteryNumber = lotteryNumber.Replace(" + ", "#").Replace(' ', ',');
            anteCodes.AddRange(lotteryNumber.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

            TicketInfo ticket = new TicketInfo();
            ticket.TicketId = messengerId + DateTime.Now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
            ticket.BuyType = BuyType.A101;   // TODO
            ticket.Money = money.ToString("0.00");
            ticket.Amount = multiple.ToString();
            ticket.AnteCodes = anteCodes;
            ticket.IssueInfo = issueInfo;
            ticket.UserProfile = userProfile;

            HPBuyRequestInfo.Body requestBody = new HPBuyRequestInfo.Body();
            requestBody._Request = new HPBuyRequestInfo.Body.Request();
            requestBody._Request.TicketList = new XmlMappingList<TicketInfo>();
            requestBody._Request.TicketList.Add(ticket);

            CommunicationObject.RequestHeaderObject requestHeader = new CommunicationObject.RequestHeaderObject();
            requestHeader.MessengerId = GetAgenceAccountUserName();
            requestHeader.Timestamp = timestamp;
            requestHeader.TransactionType = TranType.Request103;
            requestHeader.Digest = PostManager.MD5(messageId + timestamp + userPassword + requestBody.ToXmlString(), "gb2312");

            requestInfo.XmlHeader = "<?xml version=\"1.0\" encoding=\"gb2312\"?>";
            requestInfo.Id = messageId;
            requestInfo.Version = "1.0";
            requestInfo._Header = requestHeader;
            requestInfo._Body = requestBody;

            //AccountNumber accountN = GetAccountNumber();
            //LotteryType lotteryType = LotteryType.ShangHaiWelfareLottery;
            //IIssueQueryGateway gateway = GatewayFactroy.CreateIssueQueryGatewayFactory(lotteryType);
            //TransactionTypeManager transTypeM = new TransactionTypeManager(lotteryType);
            //TransactionType transType = transTypeM.GetTransactionTypeByTypeCode(lotteryType, "102");
            //PlayMethodManager pleyMethodM = new PlayMethodManager(lotteryType);
            //transType = transTypeM.GetTransactionTypeByTypeCode(lotteryType, "103");



            //List<Ticket> tickets = new List<Ticket>();
            //Ticket ticketOne = new Ticket();
            //ticketOne.TicketId = accountN.UserName + DateTime.Now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
            //string gameName = "双色球";
            //ticketOne.PlayTypeInfo = pleyMethodM.GetMethodType(lotteryType, gameName).PlayTypes[0];
            //ticketOne.IssueInfo = new Issue();
            //ticketOne.IssueInfo.PlayMethodInfo = pleyMethodM.GetMethodType(lotteryType, gameName);
            //// 期号
            //ticketOne.IssueInfo.Number = isuseNumber;
            //// 倍投数
            //ticketOne.Amount = multiple.ToString();
            //// 购买金额
            //ticketOne.Money = money.ToString();
            //// 要投注的彩票号码(测试时，每张彩票一注)
            //ticketOne.AnteCodes = lotteryNumber.Trim();

            //UserProfile user = new UserProfile();
            //// 彩票用户名
            //user.UserName = CurrentUser.UserId;
            //// 用户证件类型(1、身份证；2、军官证；3、护照)
            //user.CardTypeInfo = (CardType)CurrentUser.CardType;
            //// 证件号码
            //user.CardNumber = CurrentUser.CardNumber;
            //// 用户邮箱地址
            //user.Mail = CurrentUser.Email;
            //// 用户手机号(无纸化彩票中大奖的凭证之一)
            //user.Mobile = CurrentUser.Mobile;
            //// 用户真实姓名
            //user.RealName = CurrentUser.RealName;

            //ticketOne.UserProfile = user;
            //tickets.Add(ticketOne);
            //ticketOne.TicketId = accountN.UserName + DateTime.Now.ToString("yyyyMMdd") + PostManager.TenSerialNumber;
            //tickets.Add(ticketOne);

            string result = @"投注结果\n\n";
            try
            {
                string requestText = "transType=" + (int)TranType.Request103 + "&transMessage=" + requestInfo.ToXmlString();
                string xml = PostManager.Post(GateWayManager.HPIssueQuery_GateWay, requestText, 1200);
                //string xml = gateway.LotteryRequest(accountN, transType, tickets);
                HPResponseInfo info = XmlAnalyzer.AnalyseResponse<HPResponseInfo>(xml);
                result += info.Code + " - " + info.Message;
            }
            catch (Exception ex)
            {
                result += "错误 - " + ex.Message;
                LogWriter.Write(LogCategory.Lottery, "投注错误", ex);
                // sbResult.AppendLine(ex.Message);
            }
            JavaScript.Alert(this.Page, result);
            return;
        }
        catch
        {
            JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
            return;
        }
    }

    //private void RequestGateway(LotteryType lotteryType, string gameName, string issueNumber)
    //{
    //    AccountNumber accountN = GetAccountNumber();
    //    IIssueQueryGateway gateway = GatewayFactroy.CreateIssueQueryGatewayFactory(lotteryType);
    //    TransactionTypeManager transTypeM = new TransactionTypeManager(lotteryType);
    //    TransactionType transType = transTypeM.GetTransactionTypeByTypeCode(lotteryType, "102");
    //    PlayMethodManager pleyMethodM = new PlayMethodManager(lotteryType);
    //    transType = transTypeM.GetTransactionTypeByTypeCode(lotteryType, "103");

    //    List<Ticket> tickets = new List<Ticket>();
    //    Ticket ticketOne = new Ticket();
    //    ticketOne.TicketId = accountN.UserName + DateTime.Now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
    //    string gameName = "双色球";
    //    ticketOne.PlayTypeInfo = pleyMethodM.GetMethodType(lotteryType, gameName).PlayTypes[0];
    //    ticketOne.IssueInfo = new Issue();
    //    ticketOne.IssueInfo.PlayMethodInfo = pleyMethodM.GetMethodType(lotteryType, gameName);
    //    // 期号
    //    ticketOne.IssueInfo.Number = issueNumber;
    //    // 倍投数
    //    ticketOne.Amount = multiple.ToString();
    //    // 购买金额
    //    ticketOne.Money = assureMoney.ToString();
    //    // 要投注的彩票号码(测试时，每张彩票一注)
    //    ticketOne.AnteCodes = str12.Trim();

    //    UserProfile user = new UserProfile();
    //    // 彩票用户名
    //    user.UserName = CurrentUser.UserId;
    //    // 用户证件类型(1、身份证；2、军官证；3、护照)
    //    user.CardTypeInfo = (CardType)CurrentUser.CardType;
    //    // 证件号码
    //    user.CardNumber = CurrentUser.CardNumber;
    //    // 用户邮箱地址
    //    user.Mail = CurrentUser.Email;
    //    // 用户手机号(无纸化彩票中大奖的凭证之一)
    //    user.Mobile = CurrentUser.Mobile;
    //    // 用户真实姓名
    //    user.RealName = CurrentUser.RealName;

    //    ticketOne.UserProfile = user;
    //    tickets.Add(ticketOne);
    //    ticketOne.TicketId = accountN.UserName + DateTime.Now.ToString("yyyyMMdd") + PostManager.TenSerialNumber;
    //    tickets.Add(ticketOne);

    //    StringBuilder sbResult = new StringBuilder();
    //    sbResult.AppendLine("投注结果");
    //    sbResult.AppendLine();
    //    try
    //    {
    //        string result = gateway.LotteryRequest(accountN, transType, tickets);
    //        sbResult.AppendLine(result);
    //    }
    //    catch (Exception ex)
    //    {
    //        sbResult.AppendLine("错误");
    //        // sbResult.AppendLine(ex.Message);
    //    }
    //}
}
