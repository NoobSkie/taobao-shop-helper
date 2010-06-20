using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using J.SLS.Facade;
using J.SLS.Common.Logs;
using HPGatewayModels;
using J.SLS.Common.Xml;
using J.SLS.Common;
using Shove._Web;

public partial class Lottery_SHSSL_Buy : LotteryBasePage
{
    protected override int LotteryId
    {
        get
        {
            return 29;
        }
    }

    protected override string LotteryName
    {
        get
        {
            return "时时乐";
        }
    }

    protected override string LotteryCode
    {
        get { return "ssl"; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Lottery_SHSSL_Buy));

        if (!IsPostBack)
        {
            IssuseInfo isuseInfo = lotteryFacade.GetPrevIsuse(LotteryCode);
            if (isuseInfo != null)
            {
                lblPrevInfo.Text = isuseInfo.IssuseNumber + "期开奖：";
                string[] codes = isuseInfo.BonusCode.Split(',');
                if (codes.Length == 3)
                {
                    lblNum1.Text = codes[0];
                    lblNum2.Text = codes[1];
                    lblNum3.Text = codes[2];
                }
            }
            if (CurrentUser == null)
            {
                CtrlInnerUserInfo1.Visible = false;
                CtrlInnerLogin1.Visible = true;
            }
            else
            {
                CtrlInnerUserInfo1.Visible = true;
                CtrlInnerLogin1.Visible = false;
            }
        }
    }

    private IList<IssuseInfo> GetNext10IssuseList(string gameName)
    {
        List<IssuseInfo> issuseList = new List<IssuseInfo>();
        IssuseInfo isuseInfo = lotteryFacade.GetCurrentIsuse(gameName);
        if (isuseInfo != null)
        {
            issuseList.Add(isuseInfo);
            string currentIsssueNumber = isuseInfo.IssuseNumber;
            string year = currentIsssueNumber.Substring(0, 4);
            string month = currentIsssueNumber.Substring(4, 2);
            string day = currentIsssueNumber.Substring(6, 2);
            string numString = currentIsssueNumber.Substring(8, 2);
            DateTime dt = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
            int number = int.Parse(numString);
            int index = 0;
            while (true)
            {
                if (index >= 10)
                {
                    break;
                }
                number++;
                if (number > 23)
                {
                    number = 1;
                    dt = dt.AddDays(1);
                }
                string issueString = dt.ToString("yyyyMMdd") + number.ToString().PadLeft(2, '0');
                IssuseInfo info = new IssuseInfo();
                info.GameName = gameName;
                info.IssuseNumber = issueString;
                issuseList.Add(info);
            }
        }
        return issuseList;
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
        if (CurrentUser == null)
        {
            JavaScript.Alert(this.Page, "请先登录系统！");
            Response.Redirect("~/Users/Login.aspx");
        }
        else
        {
            DoBuy();
        }
    }

    private void DoBuy()
    {
        string issueIdString = HidIsuseID.Value;
        string isuseNumber = HidIsuseNumber.Value;
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
        try
        {
            HPBuyRequestInfo requestInfo = new HPBuyRequestInfo();

            decimal money = decimal.Parse(sumMoneyString);
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

            BuyType buyType;
            List<string> anteCodes;
            // 分析选择的玩法类型和号码
            GetAnteCodes(playType, lotteryNumber, out buyType, out anteCodes);

            TicketInfo ticket = new TicketInfo();
            ticket.TicketId = messengerId + DateTime.Now.ToString("yyyyMMdd") + PostManager.EightSerialNumber;
            ticket.BuyType = buyType;
            ticket.Money = money;
            ticket.Amount = multiple;
            ticket.AnteCodes = anteCodes;
            ticket.IssueInfo = issueInfo;
            ticket.UserProfile = GetAgencyUserProfileInfo();

            HPBuyRequestInfo.Body requestBody = new HPBuyRequestInfo.Body();
            requestBody._Request = new HPBuyRequestInfo.Body.Request();
            requestBody._Request.TicketList = new XmlMappingList<TicketInfo>();
            requestBody._Request.TicketList.Add(ticket);

            string bodyXml = requestBody.ToXmlString("body");

            CommunicationObject.RequestHeaderObject requestHeader = new CommunicationObject.RequestHeaderObject();
            requestHeader.MessengerId = GetAgenceAccountUserName();
            requestHeader.Timestamp = timestamp;
            requestHeader.TransactionType = TranType.Request103;
            requestHeader.Digest = PostManager.MD5(messageId + timestamp + userPassword + bodyXml, "gb2312");

            string headerXml = requestHeader.ToXmlString("header");

            string requestXml = "<?xml version=\"1.0\" encoding=\"GBK\"?><message version=\"1.0\" id=\"" + messageId + "\">" + headerXml + bodyXml + "</message>";

            //Response.Write("投注方式：" + (int)ticket.BuyType);
            //Response.Write("<br />");
            //Response.Write("投注金额：" + money);
            //Response.Write("<br /><br />");
            //Response.Write(string.Join("<br />", anteCodes.ToArray()));

            string result = @"投注结果\n\n";
            try
            {
                string requestText = "transType=" + (int)TranType.Request103 + "&transMessage=" + requestXml;
                TicketFacade ticketFacade = new TicketFacade();
                ticketFacade.BuyTicket(ticket, CurrentUser);
                string xml = PostManager.Post(GateWayManager.HPIssueQuery_GateWay, requestText, 1200);
                HPResponseInfo info = XmlAnalyzer.AnalyseResponse<HPResponseInfo>(xml);
                ticketFacade.UpdateTicketStatus(ticket, CurrentUser, info);
                if (info.Code == "0000")
                {
                    result += "成功 - " + info.Message;
                }
                else
                {
                    throw new Exception("失败 - " + info.Code + " - " + info.Message);
                }
            }
            catch (Exception ex)
            {
                result += "失败！";
                LogWriter.Write(LogCategory.Lottery, "投注错误", ex);
            }
            JavaScript.Alert(this.Page, result);
        }
        catch
        {
            JavaScript.Alert(this.Page, "输入有错误，请仔细检查。");
            return;
        }
    }

    delegate string GetAnteCode(string orginCode);

    private void GetAnteCodes(int playTypeValue, string numbers, out BuyType buyType, out List<string> anteCodes)
    {
        GetAnteCode action;
        switch (playTypeValue)
        {
            case 2901:  // 直选单式
                buyType = BuyType.B201;
                action = new GetAnteCode(GetSingleCodeFormat);
                break;
            case 2902:  // 直选复式
                buyType = BuyType.B208;
                action = new GetAnteCode(GetManyCodeFormat);
                break;
            case 2903:  // 组选单式
                buyType = BuyType.B202;
                action = new GetAnteCode(GetSingleCodeFormat);
                break;
            //case 2904:  // 组选6
            //    buyType = BuyType.B230;
            //    action = new GetAnteCode(GetSingleCodeFormat);
            //    break;
            //case 2905:  // 组选3
            //    buyType = BuyType.B230;
            //    action = new GetAnteCode(GetSingleCodeFormat);
            //    break;
            case 2908:  // 前二单式
                buyType = BuyType.B201;
                action = new GetAnteCode(GetSingleCodeFormat_Left);
                break;
            case 2909:  // 前二复式
                buyType = BuyType.B208;
                action = new GetAnteCode(GetManyCodeFormat_Left2);
                break;
            case 2910:  // 后二单式
                buyType = BuyType.B201;
                action = new GetAnteCode(GetSingleCodeFormat_Right);
                break;
            case 2911:  // 后二复式
                buyType = BuyType.B208;
                action = new GetAnteCode(GetManyCodeFormat_Right2);
                break;
            case 2912:  // 前一单式
                buyType = BuyType.B201;
                action = new GetAnteCode(GetSingleCodeFormat_Left);
                break;
            case 2913:  // 前一复式
                buyType = BuyType.B208;
                action = new GetAnteCode(GetManyCodeFormat_Left1);
                break;
            case 2914:  // 后一单式
                buyType = BuyType.B201;
                action = new GetAnteCode(GetSingleCodeFormat_Right);
                break;
            case 2915:  // 后一复式
                buyType = BuyType.B208;
                action = new GetAnteCode(GetManyCodeFormat_Right1);
                break;
            default:
                throw new ArgumentOutOfRangeException("玩法类型超出范围：" + playTypeValue);
        }

        anteCodes = new List<string>();
        foreach (string code in numbers.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
        {
            string anteCode = action(code);
            anteCodes.Add(anteCode);
        }
    }

    private string GetSingleCodeFormat(string number)
    {
        string str = "";
        foreach (char c in number)
        {
            str += c.ToString() + ",";
        }
        return str.TrimEnd(',');
    }

    private string GetSingleCodeFormat_Left(string number)
    {
        number = number.PadRight(3, '_');
        return GetSingleCodeFormat(number);
    }

    private string GetSingleCodeFormat_Right(string number)
    {
        number = number.PadLeft(3, '_');
        return GetSingleCodeFormat(number);
    }

    private string GetManyCodeFormat(string number)
    {
        number = number.TrimStart('(').TrimEnd(')');
        return number.Replace(")(", ",");
    }

    private string GetManyCodeFormat_Left1(string number)
    {
        number = number.TrimStart('(').TrimEnd(')');
        return number + ",_,_";
    }

    private string GetManyCodeFormat_Left2(string number)
    {
        number = number + "(_)";
        return GetManyCodeFormat(number);
    }

    private string GetManyCodeFormat_Right1(string number)
    {
        number = number.TrimStart('(').TrimEnd(')');
        return "_,_," + number;
    }

    private string GetManyCodeFormat_Right2(string number)
    {
        number = "(_)" + number;
        return GetManyCodeFormat(number);
    }
}
