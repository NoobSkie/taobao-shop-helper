using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Database;
using SLS;
using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.XPath;

public partial class ElectronTicket_HPCQ_Receive : Page, IRequiresSessionState
{
    private string ElectronTicket_HPCQ_Getway;
    private bool ElectronTicket_HPCQ_Status_ON;
    private string ElectronTicket_HPCQ_UserName;
    private string ElectronTicket_HPCQ_UserPassword;
    private const int TimeoutSeconds = 120;
    private string TransMessage;
    private string TransType;

    private void BonusQuery(string TransMessage)
    {
        XmlDocument document = new XmlDocument();
        document.Load(new StringReader(TransMessage));
        XmlNodeList elementsByTagName = document.GetElementsByTagName("*");
        string winNumber = "";
        string input = "";
        string gameName = "";
        if (elementsByTagName != null)
        {
            for (int i = 0; i < elementsByTagName.Count; i++)
            {
                if (elementsByTagName[i].Name.ToUpper() == "BONUSQUERYRESULT")
                {
                    winNumber = elementsByTagName[i].Attributes["bonusNumber"].Value.Replace(",", "");
                }
                if (elementsByTagName[i].Name.ToUpper() == "ISSUE")
                {
                    input = elementsByTagName[i].Attributes["number"].Value;
                    gameName = elementsByTagName[i].Attributes["gameName"].Value;
                }
            }
            int lotteryID = this.GetLotteryID(gameName);
            if (lotteryID >= 0)
            {
                DataTable table = new Tables.T_Isuses().Open("top 1 *", "LotteryID = " + lotteryID.ToString() + " and [Name] = '" + Utility.FilteSqlInfusion(input) + "' and isOpened = 0 and EndTime < GetDate()", "");
                if (table == null)
                {
                    new Log(@"ElectronTicket\HPCQ").Write("恒朋-重庆电子票网关自动开奖错误，彩种：" + gameName + "，期号：" + input);
                }
                else if (table.Rows.Count >= 1)
                {
                    DataTable table2 = new Tables.T_WinTypes().Open("DefaultMoney, DefaultMoneyNoWithTax", "LotteryID = " + lotteryID.ToString(), "[Order]");
                    if (table2 == null)
                    {
                        new Log(@"ElectronTicket\HPCQ").Write("恒朋-重庆电子票网关自动开奖错误，彩种：" + gameName + "，期号：" + input);
                    }
                    else
                    {
                        double[] winMoneyList = new double[table2.Rows.Count * 2];
                        for (int j = 0; j < table2.Rows.Count; j++)
                        {
                            winMoneyList[j * 2] = _Convert.StrToDouble(table2.Rows[j][0].ToString(), 0.0);
                            winMoneyList[(j * 2) + 1] = _Convert.StrToDouble(table2.Rows[j][1].ToString(), 0.0);
                        }
                        DataTable table3 = new Tables.T_Schemes().Open("", "IsuseID = " + table.Rows[0]["ID"].ToString() + " and isOpened = 0", "");
                        if (table3 == null)
                        {
                            new Log(@"ElectronTicket\HPCQ").Write("恒朋-重庆电子票网关自动开奖错误，彩种：" + gameName + "，期号：" + input);
                        }
                        else
                        {
                            if (table3.Rows.Count > 0)
                            {
                                for (int k = 0; k < table3.Rows.Count; k++)
                                {
                                    string number = table3.Rows[k]["LotteryNumber"].ToString();
                                    string description = "";
                                    double winMoneyNoWithTax = 0.0;
                                    double num6 = new Lottery()[lotteryID].ComputeWin(number, winNumber, ref description, ref winMoneyNoWithTax, int.Parse(table3.Rows[k]["PlayTypeID"].ToString()), winMoneyList);
                                    MSSQL.ExecuteNonQuery("update T_Schemes set PreWinMoney = @p1, PreWinMoneyNoWithTax = @p2, EditWinMoney = @p3, EditWinMoneyNoWithTax = @p4, WinDescription = @p5 where [ID] = " + table3.Rows[k]["ID"].ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("p1", SqlDbType.Money, 0, ParameterDirection.Input, num6 * _Convert.StrToInt(table3.Rows[k]["Multiple"].ToString(), 1)), new MSSQL.Parameter("p2", SqlDbType.Money, 0, ParameterDirection.Input, winMoneyNoWithTax * _Convert.StrToInt(table3.Rows[k]["Multiple"].ToString(), 1)), new MSSQL.Parameter("p3", SqlDbType.Money, 0, ParameterDirection.Input, num6 * _Convert.StrToInt(table3.Rows[k]["Multiple"].ToString(), 1)), new MSSQL.Parameter("p4", SqlDbType.Money, 0, ParameterDirection.Input, winMoneyNoWithTax * _Convert.StrToInt(table3.Rows[k]["Multiple"].ToString(), 1)), new MSSQL.Parameter("p5", SqlDbType.VarChar, 0, ParameterDirection.Input, description) });
                                }
                            }
                            DataSet ds = null;
                            PF.SendWinNotification(ds);
                        }
                    }
                }
            }
        }
    }

    private void Concentration(string TransMessage)
    {
        XmlDocument document = new XmlDocument();
        document.Load(new StringReader(TransMessage));
        XmlNodeList elementsByTagName = document.GetElementsByTagName("*");
        if (elementsByTagName != null)
        {
            for (int i = 0; i < elementsByTagName.Count; i++)
            {
                if (elementsByTagName[i].Name.ToUpper() == "MESSAGE")
                {
                    elementsByTagName[i].Attributes["id"].Value.Substring(elementsByTagName[i].Attributes["id"].Value.Length, 8);
                    string text1 = elementsByTagName[i].FirstChild.FirstChild["messengerID"].Value;
                }
                if ((elementsByTagName[i].Name.ToUpper() == "RESPONSE") && (elementsByTagName[i].FirstChild.Attributes["code"].Value == "0000"))
                {
                    string text2 = elementsByTagName[i].FirstChild.Attributes["message"].Value;
                }
            }
        }
    }

    private void ConcentrationNotice(string TransMessage)
    {
        XmlDocument document = new XmlDocument();
        document.Load(new StringReader(TransMessage));
        document.GetElementsByTagName("messengerID");
        XmlNodeList elementsByTagName = document.GetElementsByTagName("ticket");
        if (elementsByTagName != null)
        {
            for (int i = 0; i < elementsByTagName.Count; i++)
            {
                string str = elementsByTagName[i].Attributes["id"].Value;
                string text1 = elementsByTagName[i].Attributes["dealTime"].Value;
                string text2 = elementsByTagName[i].Attributes["status"].Value;
                string text3 = elementsByTagName[i].Attributes["message"].Value;
                int num2 = 0;
                int num3 = 0;
                if (num3 < 0)
                {
                    PF.GoError(4, "数据库繁忙，请重试", "ElectronTicket_HPCQ_Receive");
                    return;
                }
                if (num2 < 0)
                {
                    new Log(@"ElectronTicket\HPCQ").Write("对恒朋-重庆电子票网所发送的电子票数据处理出错：部分票写入错误。票号：" + str.ToString());
                }
            }
            this.ReNotice(this.GetFromXPath(TransMessage, "message/header/messengerID"), "504");
        }
    }

    public static string GetBody(string XML)
    {
        Regex regex = new Regex(@"(?<body><Body[\S\s]*?>[\S\s]*?</Body>)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        return regex.Match(XML).Groups["body"].Value;
    }

    private string GetFromXPath(string XML, string XPath)
    {
        if (XML.Trim() == "")
        {
            return "";
        }
        string str = "";
        try
        {
            XPathDocument document = new XPathDocument(new StringReader(XML));
            XPathNodeIterator iterator = document.CreateNavigator().Select(XPath);
            while (iterator.MoveNext())
            {
                str = str + iterator.Current.Value;
            }
        }
        catch
        {
            return "";
        }
        return str;
    }

    private string GetGameName(int LotteryID)
    {
        switch (LotteryID)
        {
            case 5:
                return "ssq";

            case 0x1c:
                return "ssc";
        }
        return "";
    }

    private int GetLotteryID(string gameName)
    {
        switch (gameName)
        {
            case "ssq":
                return 5;

            case "ssc":
                return 0x1c;
        }
        return -1;
    }

    private void InitiativeNotice(string TransMessage)
    {
        XmlDocument document = new XmlDocument();
        document.Load(new StringReader(TransMessage));
        XmlNodeList elementsByTagName = document.GetElementsByTagName("*");
        if (elementsByTagName != null)
        {
            for (int i = 0; i < elementsByTagName.Count; i++)
            {
                if (elementsByTagName[i].Name.ToUpper() == "MESSENGERID")
                {
                    string text1 = elementsByTagName[i].Value;
                }
            }
        }
    }

    private void IssueInquiry(string TransMessage)
    {
        XmlDocument document = new XmlDocument();
        document.Load(new StringReader(TransMessage));
        XmlNodeList elementsByTagName = document.GetElementsByTagName("response");
        XmlNodeList list2 = document.GetElementsByTagName("issue");
        string gameName = "";
        string input = "";
        if (((elementsByTagName != null) && (elementsByTagName[0].Attributes["code"].Value == "0000")) && (list2 != null))
        {
            for (int i = 0; i < list2.Count; i++)
            {
                gameName = list2[i].Attributes["gameName"].Value;
                input = list2[i].Attributes["number"].Value;
                DateTime startTime = DateTime.Parse(list2[i].Attributes["startTime"].Value);
                DateTime endTime = DateTime.Parse(list2[i].Attributes["stopTime"].Value);
                int lotteryID = this.GetLotteryID(gameName);
                if (gameName == "ssc")
                {
                    string str3 = Functions.F_GetLotteryIntervalType(lotteryID);
                    int num3 = int.Parse(str3.Substring(1, str3.IndexOf(";") - 1));
                    startTime = endTime.AddMinutes((double)-num3);
                }
                if ((lotteryID > 0) && (new Tables.T_Isuses().GetCount("LotteryID = " + lotteryID.ToString() + " and [Name] = '" + Utility.FilteSqlInfusion(input) + "'") < 1L))
                {
                    long isuseID = -1L;
                    string returnDescription = "";
                    if (Procedures.P_IsuseAdd(lotteryID, input, startTime, endTime, "", ref isuseID, ref returnDescription) < 0)
                    {
                        new Log(@"ElectronTicket\HPCQ").Write("写入恒朋-重庆电子票网关通知的期号错误，彩种：" + gameName + "，期号：" + input);
                        return;
                    }
                    if (isuseID < 0L)
                    {
                        new Log(@"ElectronTicket\HPCQ").Write("写入恒朋-重庆电子票网关通知的期号错误：" + returnDescription + "，彩种：" + gameName + "，期号：" + input);
                        return;
                    }
                }
                Thread.Sleep(0x7d0);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SystemOptions options = new SystemOptions();
        this.ElectronTicket_HPCQ_Status_ON = options["ElectronTicket_HPCQ_Status_ON"].ToBoolean(false);
        this.ElectronTicket_HPCQ_Getway = options["ElectronTicket_HPCQ_Getway"].ToString("");
        this.ElectronTicket_HPCQ_UserName = options["ElectronTicket_HPCQ_UserName"].ToString("");
        this.ElectronTicket_HPCQ_UserPassword = options["ElectronTicket_HPCQ_UserPassword"].ToString("");
        if (this.ElectronTicket_HPCQ_Status_ON && !base.IsPostBack)
        {
            this.TransType = Utility.GetRequest("transType");
            this.TransMessage = Utility.GetRequest("transMessage");
            if (((this.TransType != "") && (this.TransMessage != "")) && this.ValidMessage(this.TransType, this.TransMessage))
            {
                this.Receive(this.TransType, this.TransMessage);
            }
        }
    }

    private void PassiveNotice(string TransMessage)
    {
        XmlDocument document = new XmlDocument();
        document.Load(new StringReader(TransMessage));
        XmlNodeList elementsByTagName = document.GetElementsByTagName("*");
        XmlNodeList list2 = document.GetElementsByTagName("issue");
        string input = "";
        string gameName = "";
        string messageID = "";
        if (elementsByTagName != null)
        {
            for (int i = 0; i < elementsByTagName.Count; i++)
            {
                if ((elementsByTagName[i].Name.ToUpper() == "BODY") && (elementsByTagName[i].FirstChild.Name.ToUpper() == "ISSUENOTIFY"))
                {
                    for (int j = 0; j < list2.Count; j++)
                    {
                        input = list2[j].Attributes["number"].Value;
                        gameName = list2[j].Attributes["gameName"].Value;
                        string str5 = list2[j].Attributes["status"].Value;
                        if (str5 != null)
                        {
                            if (!(str5 == "1"))
                            {
                                if (((!(str5 == "2") && !(str5 == "3")) && !(str5 == "4")) && (str5 == "5"))
                                {
                                    goto Label_01C8;
                                }
                            }
                            else if (new Tables.T_Isuses().GetCount("LotteryID = " + this.GetLotteryID(gameName).ToString() + " and [Name] = '" + Utility.FilteSqlInfusion(input) + "'") < 1L)
                            {
                                this.QueryIssue(gameName, input);
                            }
                        }
                        goto Label_01CE;
                    Label_01C8:
                        this.QueryOpen();
                    Label_01CE: ;
                    }
                }
            }
            messageID = elementsByTagName[0].Attributes["id"].Value;
            this.ReNotice(messageID, "501");
        }
    }

    private void QueryIssue(string LotteryName, string Number)
    {
        DateTime now = DateTime.Now;
        string str = "<body><issueQuery><issue gameName=\"" + LotteryName + "\" number=\"" + Number + "\"/></issueQuery></body>";
        string str2 = this.ElectronTicket_HPCQ_UserName + now.ToString("yyyyMMdd") + now.ToString("HHmmss") + "00";
        string str3 = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
        string str5 = PF.Post(this.ElectronTicket_HPCQ_Getway, "transType=102&transMessage=" + (((((((("<?xml version=\"1.0\" encoding=\"GBK\"?>" + "<message version=\"1.0\" id=\"" + str2 + "\">") + "<header>") + "<messengerID>" + this.ElectronTicket_HPCQ_UserName + "</messengerID>") + "<timestamp>" + str3 + "</timestamp>") + "<transactionType>102</transactionType>") + "<digest>" + Encrypt.MD5(str2 + str3 + this.ElectronTicket_HPCQ_UserPassword + str, "gb2312") + "</digest>") + "</header>") + str + "</message>"), 120);
        this.IssueInquiry(str5.Substring(0x1b));
    }

    private void QueryOpen()
    {
        DataTable table = new Views.V_Isuses().Open("top 1 [ID], LotteryID, [Name]", " IsOpened = 0 and EndTime <  GetDate()", " EndTime desc");
        if ((table != null) && (table.Rows.Count >= 1))
        {
            DataRow row = table.Rows[0];
            DateTime now = DateTime.Now;
            string str = "<body><bonusQuery><issue gameName=\"" + this.GetGameName(int.Parse(row["LotteryID"].ToString())) + "\" number=\"" + row["Name"].ToString() + "\"/></bonusQuery></body>";
            string str2 = this.ElectronTicket_HPCQ_UserName + now.ToString("yyyyMMdd") + now.ToString("HHmmss") + "00";
            string str3 = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
            string str5 = PF.Post(this.ElectronTicket_HPCQ_Getway, "transType=106&transMessage=" + (((((((("<?xml version=\"1.0\" encoding=\"GBK\"?>" + "<message version=\"1.0\" id=\"" + str2 + "\">") + "<header>") + "<messengerID>" + this.ElectronTicket_HPCQ_UserName + "</messengerID>") + "<timestamp>" + str3 + "</timestamp>") + "<transactionType>106</transactionType>") + "<digest>" + Encrypt.MD5(str2 + str3 + this.ElectronTicket_HPCQ_UserPassword + str, "gb2312") + "</digest>") + "</header>") + str + "</message>"), 120);
            this.BonusQuery(str5.Substring(0x1b));
        }
    }

    private void Receive(string TransType, string TransMessage)
    {
        switch (TransType)
        {
            case "501":
                this.InitiativeNotice(TransMessage);
                return;

            case "502":
                this.IssueInquiry(TransMessage);
                return;

            case "503":
                this.Concentration(TransMessage);
                return;

            case "104":
                this.ConcentrationNotice(TransMessage);
                return;

            case "505":
                this.TicketInquiry(TransMessage);
                return;

            case "506":
                break;

            case "507":
                this.SalesVolumeInquiry(TransMessage);
                return;

            case "101":
                this.PassiveNotice(TransMessage);
                break;

            default:
                return;
        }
    }

    private void ReNotice(string MessageID, string Type)
    {
        DateTime now = DateTime.Now;
        string str = "<body><response code=\"0000\" message=\"成功，系统处理正常\"/></body>";
        string str2 = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
        string str3 = "<?xml version=\"1.0\" encoding=\"GBK\"?>";
        str3 = (((((((str3 + "<message version=\"1.0\" id=\"" + MessageID + "\">") + "<header>") + "<messengerID>" + this.ElectronTicket_HPCQ_UserName + "</messengerID>") + "<timestamp>" + str2 + "</timestamp>") + "<transactionType>" + Type + "</transactionType>") + "<digest>" + Encrypt.MD5(MessageID + str2 + this.ElectronTicket_HPCQ_UserPassword + str, "gb2312") + "</digest>") + "</header>") + str + "</message>";
        base.Response.Write("transType=" + Type + "&transMessage=" + str3);
        base.Response.End();
    }

    private void SalesVolumeInquiry(string Transmessage)
    {
        XmlDocument document = new XmlDocument();
        document.Load(new StringReader(this.TransMessage));
        XmlNodeList elementsByTagName = document.GetElementsByTagName("body");
        if (((elementsByTagName != null) && (elementsByTagName[0].Name.ToUpper() == "RESPONSE")) && ((elementsByTagName[0].FirstChild.Attributes["code"].Value == "0000") && (elementsByTagName[0].FirstChild.FirstChild.Name.ToUpper() == "BALANCEQUERYRESULT")))
        {
            string text1 = elementsByTagName[0].FirstChild.FirstChild.Attributes["salesMoney"].Value;
            string text2 = elementsByTagName[0].FirstChild.FirstChild.Attributes["bonusMoney"].Value;
            string text3 = elementsByTagName[0].FirstChild.FirstChild.FirstChild.Attributes["gameName"].Value;
            string text4 = elementsByTagName[0].FirstChild.FirstChild.FirstChild.Attributes["number"].Value;
        }
    }

    private void TicketInquiry(string TransMessage)
    {
        XmlDocument document = new XmlDocument();
        document.Load(new StringReader(TransMessage));
        XmlNodeList elementsByTagName = document.GetElementsByTagName("ticket");
        if (elementsByTagName != null)
        {
            for (int i = 0; i < elementsByTagName.Count; i++)
            {
                string text1 = elementsByTagName[i].Attributes["id"].Value;
                string text2 = elementsByTagName[i].Attributes["status"].Value;
                string text3 = elementsByTagName[i].Attributes["message"].Value;
            }
        }
    }

    private bool ValidMessage(string TransType, string TransMessage)
    {
        XmlDocument document = new XmlDocument();
        document.Load(new StringReader(TransMessage));
        XmlNodeList elementsByTagName = document.GetElementsByTagName("*");
        string innerText = "";
        string str2 = "";
        string str3 = "";
        string body = "";
        if (elementsByTagName == null)
        {
            return false;
        }
        for (int i = 0; i < elementsByTagName.Count; i++)
        {
            if (elementsByTagName[i].Name.ToUpper() == "MESSAGE")
            {
                if (this.ElectronTicket_HPCQ_UserName != this.GetFromXPath(TransMessage, "message/header/messengerID"))
                {
                    return false;
                }
                str2 = elementsByTagName[i].Attributes["id"].Value;
            }
            if (elementsByTagName[i].Name.ToUpper() == "TIMESTAMP")
            {
                innerText = elementsByTagName[i].InnerText;
            }
            if (elementsByTagName[i].Name.ToUpper() == "DIGEST")
            {
                str3 = elementsByTagName[i].InnerText;
            }
        }
        body = GetBody(TransMessage);
        return (str3.ToLower() == Encrypt.MD5(str2 + innerText + this.ElectronTicket_HPCQ_UserPassword + body, "gb2312").ToLower());
    }

}

