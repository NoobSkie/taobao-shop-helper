using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Database;
using SLS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.XPath;
 
public partial class ElectronTicket_HPSH_Receive : Page, IRequiresSessionState
{
    private string ElectronTicket_HPSH_Getway;
    private string ElectronTicket_HPSH_IP;
    private bool ElectronTicket_HPSH_Status_ON;
    private string ElectronTicket_HPSH_UserName;
    private string ElectronTicket_HPSH_UserPassword;
    private const int TimeoutSeconds = 100;
    private string TransMessage;
    private string TransType;

    private string GetBody(string XML)
    {
        Regex regex = new Regex(@"(?<body><Body[\S\s]*?>[\S\s]*?</Body>)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        return regex.Match(XML).Groups["body"].Value;
    }

    private string GetClientIPAddress()
    {
        if (this.Context.Request.ServerVariables["HTTP_VIA"] != null)
        {
            return this.Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        return this.Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
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

    private int GetLotteryID(string LotteryName)
    {
        switch (LotteryName)
        {
            case "ssq":
                return 5;

            case "3d":
                return 6;

            case "307":
                return 13;

            case "ssl":
                return 0x1d;

            case "601":
                return 0x3a;

            case "155":
                return 0x3b;

            case "4d":
                return 60;
        }
        return -1;
    }

    private string GetLotteryName(int LotteryID)
    {
        switch (LotteryID)
        {
            case 5:
                return "ssq";

            case 6:
                return "3d";

            case 13:
                return "307";

            case 0x3a:
                return "601";

            case 0x3b:
                return "155";

            case 60:
                return "4d";

            case 0x1d:
                return "ssl";
        }
        return "";
    }

    private string GetSchemeWinDescription(string WinList, int LotteryID, int size)
    {
        string str = "";
        return (str + this.GetWinDescription(LotteryID, WinList) + size.ToString() + "注");
    }

    private string GetWinDescription(int LotteryID, string Rank)
    {
        switch (LotteryID)
        {
            case 0x3a:
                switch (Rank)
                {
                    case "1":
                        return "一等奖";

                    case "2":
                        return "二等奖";

                    case "3":
                        return "三等奖";

                    case "4":
                        return "四等奖";

                    case "5":
                        return "五等奖";

                    case "6":
                        return "六等奖";
                }
                return "";

            case 0x3b:
                switch (Rank)
                {
                    case "0":
                        return "特等奖";

                    case "1":
                        return "一等奖";

                    case "2":
                        return "二等奖";

                    case "3":
                        return "派送奖";
                }
                return "";

            case 60:
                switch (Rank)
                {
                    case "1":
                        return "直选奖";

                    case "2":
                        return "组四奖";

                    case "3":
                        return "组六奖";

                    case "4":
                        return "组12奖";

                    case "5":
                        return "组24奖";
                }
                return "";

            case 0x1d:
                switch (Rank)
                {
                    case "1":
                        return "直选奖";

                    case "2":
                        return "组三奖";

                    case "3":
                        return "组六奖";

                    case "4":
                        return "前二奖";

                    case "5":
                        return "后二奖";

                    case "6":
                        return "前一奖";

                    case "7":
                        return "后一奖";
                }
                return "";

            case 5:
                switch (Rank)
                {
                    case "1":
                        return "一等奖";

                    case "2":
                        return "二等奖";

                    case "3":
                        return "三等奖";

                    case "4":
                        return "四等奖";

                    case "5":
                        return "五等奖";

                    case "6":
                        return "六等奖";

                    case "7":
                        return "快乐星期天";
                }
                return "";

            case 6:
                switch (Rank)
                {
                    case "1":
                        return "直选奖";

                    case "2":
                        return "组3奖";

                    case "3":
                        return "组6奖";
                }
                return "";

            case 13:
                switch (Rank)
                {
                    case "1":
                        return "一等奖";

                    case "2":
                        return "二等奖";

                    case "3":
                        return "三等奖";

                    case "4":
                        return "四等奖";

                    case "5":
                        return "五等奖";

                    case "6":
                        return "六等奖";

                    case "7":
                        return "七等奖";
                }
                return "";
        }
        return "";
    }

    private string GetWinNumber(int LotteryID, string WinNumber)
    {
        int num = LotteryID;
        if (num <= 13)
        {
            switch (num)
            {
                case 5:
                    return WinNumber.Replace(",", " ").Replace("#", " + ");

                case 6:
                    return WinNumber.Replace(",", "");

                case 13:
                    return WinNumber.Replace(",", " ").Replace("#", " + ");
            }
            return WinNumber;
        }
        switch (num)
        {
            case 0x3a:
                return WinNumber.Replace(",", "").Replace("#01", "+鼠").Replace("#02", "+牛").Replace("#03", "+虎").Replace("#04", "+兔").Replace("#05", "+龙").Replace("#06", "+蛇").Replace("#07", "+马").Replace("#08", "+羊").Replace("#09", "+猴").Replace("#10", "+鸡").Replace("#11", "+狗").Replace("#12", "+猪");

            case 0x3b:
                return WinNumber.Replace(",", " ").Replace("#", " ");

            case 60:
                return WinNumber.Replace(",", "");

            case 0x1d:
                return WinNumber.Replace(",", "");
        }
        return WinNumber;
    }

    private void IsuseNotice(string TransMessage)
    {
        XmlDocument document = new XmlDocument();
        XmlNodeList elementsByTagName = null;
        XmlNodeList list2 = null;
        try
        {
            document.Load(new StringReader(TransMessage));
            elementsByTagName = document.GetElementsByTagName("*");
            list2 = document.GetElementsByTagName("issue");
        }
        catch
        {
        }
        if (elementsByTagName == null)
        {
            base.Response.End();
        }
        else
        {
            Tables.T_Isuses isuses = new Tables.T_Isuses();
            for (int i = 0; i < elementsByTagName.Count; i++)
            {
                if ((elementsByTagName[i].Name.ToUpper() == "BODY") && (elementsByTagName[i].FirstChild.Name.ToUpper() == "ISSUENOTIFY"))
                {
                    for (int j = 0; j < list2.Count; j++)
                    {
                        string str = list2[j].Attributes["number"].Value;
                        string lotteryName = list2[j].Attributes["gameName"].Value;
                        string str3 = list2[j].Attributes["status"].Value;
                        string s = list2[j].Attributes["startTime"].Value;
                        string str5 = list2[j].Attributes["stopTime"].Value;
                        int lotteryID = this.GetLotteryID(lotteryName);
                        string winNumber = "";
                        try
                        {
                            winNumber = this.GetWinNumber(lotteryID, list2[j].Attributes["bonusCode"].Value);
                        }
                        catch
                        {
                        }
                        if ((lotteryID >= 0) && !string.IsNullOrEmpty(str))
                        {
                            if (isuses.GetCount("LotteryID = " + lotteryID.ToString() + " and [Name] = '" + Utility.FilteSqlInfusion(str) + "'") < 1L)
                            {
                                DateTime now = DateTime.Now;
                                DateTime endTime = DateTime.Now;
                                try
                                {
                                    now = DateTime.Parse(s);
                                    endTime = DateTime.Parse(str5);
                                }
                                catch
                                {
                                    goto Label_0611;
                                }
                                long isuseID = -1L;
                                string returnDescription = "";
                                if ((Procedures.P_IsuseAdd(lotteryID, str, now, endTime, "", ref isuseID, ref returnDescription) < 0) || (isuseID < 0L))
                                {
                                    goto Label_0611;
                                }
                            }
                            DataTable table = isuses.Open("ID, State, WinLotteryNumber", "LotteryID = " + lotteryID.ToString() + " and [Name] = '" + Utility.FilteSqlInfusion(str) + "'", "");
                            if ((table != null) && (table.Rows.Count >= 1))
                            {
                                if (str3 == "4")
                                {
                                    int returnValue = 0;
                                    string returnDescptrion = "";
                                    if (Procedures.P_ElectronTicketAgentSchemeQuash(_Convert.StrToLong(table.Rows[0]["ID"].ToString(), 0L), ref returnValue, ref returnDescptrion) < 0)
                                    {
                                        new Log(@"ElectronTicket\HPSH").Write("电子票方案撤单错误_P_ElectronTicketAgentSchemeQuash");
                                        goto Label_0611;
                                    }
                                }
                                bool flag = false;
                                if (table.Rows[0]["State"].ToString() != str3)
                                {
                                    isuses.State.Value = str3;
                                    isuses.StateUpdateTime.Value = DateTime.Now;
                                    flag = true;
                                }
                                if (!string.IsNullOrEmpty(winNumber) && (table.Rows[0]["WinLotteryNumber"].ToString() != winNumber))
                                {
                                    isuses.WinLotteryNumber.Value = winNumber;
                                    flag = true;
                                    if (lotteryID == 0x1d)
                                    {
                                        DataTable table2 = new Tables.T_WinTypes().Open("", "LotteryID =" + lotteryID.ToString(), "");
                                        double[] winMoneyList = new double[table2.Rows.Count * 2];
                                        for (int k = 0; k < table2.Rows.Count; k++)
                                        {
                                            winMoneyList[k * 2] = _Convert.StrToDouble(table2.Rows[k]["DefaultMoney"].ToString(), 1.0);
                                            winMoneyList[(k * 2) + 1] = _Convert.StrToDouble(table2.Rows[k]["DefaultMoneyNoWithTax"].ToString(), 1.0);
                                        }
                                        DataTable table3 = new Tables.T_ChaseTaskDetails().Open("", "IsuseID=" + table.Rows[0]["ID"].ToString() + " and SchemeID IS NOT NULL", "");
                                        for (int m = 0; m < table3.Rows.Count; m++)
                                        {
                                            string number = table3.Rows[m]["LotteryNumber"].ToString();
                                            string description = "";
                                            double winMoneyNoWithTax = 0.0;
                                            double winMoney = new Lottery()[lotteryID].ComputeWin(number, winNumber, ref description, ref winMoneyNoWithTax, int.Parse(table3.Rows[m]["PlayTypeID"].ToString()), winMoneyList);
                                            if (winMoney >= 1.0)
                                            {
                                                int num10 = 0;
                                                string str11 = "";
                                                if (Procedures.P_ChaseTaskStopWhenWin(_Convert.StrToLong(table3.Rows[m]["SiteID"].ToString(), 1L), _Convert.StrToLong(table3.Rows[m]["SchemeID"].ToString(), 0L), winMoney, ref num10, ref str11) < 0)
                                                {
                                                    new Log(@"ElectronTicket\HPSH").Write("电子票撤销追号错误_P_ChaseTaskStopWhenWin。");
                                                }
                                            }
                                        }
                                    }
                                }
                                if (flag)
                                {
                                    isuses.Update("LotteryID = " + lotteryID.ToString() + " and [Name] = '" + Utility.FilteSqlInfusion(str) + "'");
                                }
                            }
                        Label_0611: ;
                        }
                    }
                }
            }
            string messageID = elementsByTagName[0].Attributes["id"].Value;
            this.ReNotice(messageID, "501");
        }
    }

    private void IsuseOpenNotice(string Transmessage)
    {
        XmlDocument document = new XmlDocument();
        XmlNodeList elementsByTagName = null;
        XmlNodeList list2 = null;
        XmlNodeList list3 = null;
        try
        {
            document.Load(new StringReader(Transmessage));
            elementsByTagName = document.GetElementsByTagName("*");
            list2 = document.GetElementsByTagName("bonusItem");
            list3 = document.GetElementsByTagName("issue");
        }
        catch
        {
        }
        if (elementsByTagName != null)
        {
            string winNumber = "";
            for (int i = 0; i < elementsByTagName.Count; i++)
            {
                if ((elementsByTagName[i].Name.ToUpper() == "BODY") && (elementsByTagName[i].FirstChild.Name.ToUpper() == "BONUSNOTIFY"))
                {
                    winNumber = elementsByTagName[i].FirstChild.Attributes["bonusNumber"].InnerText;
                }
            }
            if (list3 == null)
            {
                base.Response.End();
            }
            else
            {
                string messageID = elementsByTagName[0].Attributes["id"].Value;
                string input = list3[0].Attributes["number"].Value;
                string lotteryName = list3[0].Attributes["gameName"].Value;
                int LotteryID = this.GetLotteryID(lotteryName);
                string str5 = this.GetWinNumber(LotteryID, winNumber);
                DataTable table = new Tables.T_Isuses().Open("", " [Name] = '" + Utility.FilteSqlInfusion(input) + "' and LotteryID = " + LotteryID.ToString() + " and IsOpened = 0", "");
                if ((table == null) || (table.Rows.Count < 1))
                {
                    base.Response.End();
                }
                else
                {
                    string str = table.Rows[0]["ID"].ToString();
                    new Tables.T_Isuses { WinLotteryNumber = { Value = str5 }, OpenOperatorID = { Value = 1 } }.Update(" ID = " + str);
                    string bonusXML = "<Schemes>";
                    string agentBonusXML = "<Schemes>";
                    if ((list2 != null) && (list2.Count > 0))
                    {
                        string s = Transmessage.Substring(Transmessage.IndexOf("<bonusNotify"), Transmessage.LastIndexOf("</body>") - Transmessage.IndexOf("<bonusNotify"));
                        DataSet set = new DataSet();
                        try
                        {
                            set.ReadXml(new StringReader(s));
                        }
                        catch (Exception exception)
                        {
                            new Log(@"ElectronTicket\HPSH").Write("电子票开奖，第 " + input + " 期解析开奖数据错误：" + exception.Message);
                            base.Response.End();
                            return;
                        }
                        if ((set == null) || (set.Tables.Count < 3))
                        {
                            new Log(@"ElectronTicket\HPSH").Write("电子票开奖，第 " + input + " 期开奖数据格式不符合要求。");
                            base.Response.End();
                            return;
                        }
                        DataTable source = set.Tables[2];
                        DataTable table3 = MSSQL.Select("SELECT SchemeID, AgentID, SchemesMultiple as Multiple, Identifiers FROM V_ElectronTicketAgentSchemesSendToCenter WHERE (IsuseID = " + str + ") UNION ALL SELECT SchemeID, 0 AS AgentID, SchemesMultiple as Multiple, Identifiers FROM V_SchemesSendToCenter WHERE (IsuseID = " + str + ")", new MSSQL.Parameter[0]);
                        if (table3 == null)
                        {
                            new Log(@"ElectronTicket\HPSH").Write("电子票开奖，第 " + input + " 期，读取本地方案错误。");
                            base.Response.End();
                            return;
                        }
                        try
                        {
                            foreach (var type in from NewDt in
                                                     (from NewDt in
                                                          (from NewDtTickets in source.AsEnumerable()
                                                           join NewdtScheme in table3.AsEnumerable() on NewDtTickets.Field<string>("ticketID") equals NewdtScheme.Field<string>("Identifiers")
                                                           select new { ID = NewdtScheme.Field<long>("SchemeID"), AgentID = NewdtScheme.Field<long>("AgentID"), Multiple = NewdtScheme.Field<int>("Multiple"), Bonus = _Convert.StrToDouble(NewDtTickets.Field<string>("money"), 0.0), BonusLevel = NewDtTickets.Field<string>("bonusLevel"), Size = _Convert.StrToInt(NewDtTickets.Field<string>("size"), 1) }).AsQueryable()
                                                      group NewDt by new { NewDt.ID, NewDt.BonusLevel, NewDt.AgentID, NewDt.Multiple } into gg
                                                      select new { ID = gg.Key.ID, AgentID = gg.Key.AgentID, Multiple = gg.Key.Multiple, Bonus = gg.Sum(NewDt => NewDt.Bonus), BonusLevel = this.GetSchemeWinDescription(gg.Key.BonusLevel, LotteryID, gg.Sum(NewDt => NewDt.Size) / gg.Key.Multiple) }).AsQueryable()
                                                 group NewDt by new { ID = NewDt.ID, Multiple = NewDt.Multiple, AgentID = NewDt.AgentID } into t_dtSchemes
                                                 select new { SchemeID = t_dtSchemes.Key.ID, AgentID = t_dtSchemes.Key.AgentID, Multiple = t_dtSchemes.Key.Multiple, Bonus = t_dtSchemes.Sum(NewDt => NewDt.Bonus), BonusLevel = t_dtSchemes.Merge(NewDt => NewDt.BonusLevel) + ((t_dtSchemes.Key.Multiple != 1) ? ("(" + t_dtSchemes.Key.Multiple.ToString() + "倍)") : "") })
                            {
                                string str10;
                                if (type.AgentID == 0L)
                                {
                                    str10 = bonusXML;
                                    bonusXML = str10 + "<Scheme SchemeID=\"" + type.SchemeID.ToString() + "\" WinMoney=\"" + type.Bonus.ToString() + "\" WinDescription=\"" + type.BonusLevel + "\" />";
                                }
                                else
                                {
                                    str10 = agentBonusXML;
                                    agentBonusXML = str10 + "<Scheme SchemeID=\"" + type.SchemeID.ToString() + "\" WinMoney=\"" + type.Bonus.ToString() + "\" WinDescription=\"" + type.BonusLevel + "\" />";
                                }
                            }
                        }
                        catch (Exception exception2)
                        {
                            new Log(@"ElectronTicket\HPSH").Write("电子票开奖，第 " + input + " 期详细中奖数据解析错误：" + exception2.Message);
                            base.Response.End();
                            return;
                        }
                    }
                    bonusXML = bonusXML + "</Schemes>";
                    agentBonusXML = agentBonusXML + "</Schemes>";
                    table = new Tables.T_Isuses().Open("", "[ID] = " + str + " and IsOpened = 0", "");
                    if ((table == null) || (table.Rows.Count < 1))
                    {
                        base.Response.End();
                    }
                    else
                    {
                        int returnValue = 0;
                        string returnDescription = "";
                        DataSet ds = null;
                        int num5 = 0;
                        int num6 = -1;
                        string appSettingsString = WebConfig.GetAppSettingsString("ConnectionString");
                        if (appSettingsString.StartsWith("0x78AD"))
                        {
                            appSettingsString = Encrypt.Decrypt3DES(PF.GetCallCert(), appSettingsString.Substring(6), PF.DesKey);
                        }
                        SqlConnection conn = MSSQL.CreateDataConnection(appSettingsString + ";Connect Timeout=150;");
                        if (conn != null)
                        {
                            while ((num6 < 0) && (num5 < 5))
                            {
                                returnValue = 0;
                                returnDescription = "";
                                num6 = this.P_ElectronTicketWin(conn, ref ds, _Convert.StrToLong(str, 0L), bonusXML, agentBonusXML, ref returnValue, ref returnDescription);
                                if (num6 < 0)
                                {
                                    string[] strArray = new string[] { "电子票第 ", (num5 + 1).ToString(), " 次派奖出现错误(IsuseOpenNotice) 期号为: ", input, "，彩种为: ", LotteryID.ToString() };
                                    new Log(@"ElectronTicket\HPSH").Write(string.Concat(strArray));
                                    num5++;
                                    if (num5 < 5)
                                    {
                                        Thread.Sleep(0x2710);
                                    }
                                }
                            }
                            if (returnValue < 0)
                            {
                                new Log(@"ElectronTicket\HPSH").Write("电子票派奖出现错误(IsuseOpenNotice) 期号为: " + input + "，彩种为: " + LotteryID.ToString() + "，错误：" + returnDescription);
                                base.Response.End();
                            }
                            else
                            {
                                PF.SendWinNotification(ds);
                                DataTable table4 = new Tables.T_WinTypes().Open("", " LotteryID =" + LotteryID.ToString(), "");
                                if ((table4 != null) && (table4.Rows.Count > 0))
                                {
                                    double[] winMoneyList = new double[table4.Rows.Count * 2];
                                    double num8 = 0.0;
                                    double num9 = 0.0;
                                    for (int j = 0; j < table4.Rows.Count; j++)
                                    {
                                        num8 = _Convert.StrToDouble(table4.Rows[j]["DefaultMoney"].ToString(), 0.0);
                                        num9 = _Convert.StrToDouble(table4.Rows[j]["DefaultMoneyNoWithTax"].ToString(), 0.0);
                                        winMoneyList[j * 2] = (num8 == 0.0) ? 1.0 : num9;
                                        winMoneyList[(j * 2) + 1] = (num9 == 0.0) ? 1.0 : num9;
                                    }
                                    DataTable table5 = new Views.V_Schemes().Open("", " IsuseName = '" + Utility.FilteSqlInfusion(input) + "' and LotteryID = " + LotteryID.ToString() + " and WinMoney = 0  and Buyed = 0 and ID in ( select ID from V_ChaseTaskDetails where IsuseName = '" + Utility.FilteSqlInfusion(input) + "' and LotteryID = " + LotteryID.ToString() + ")", "");
                                    string number = "";
                                    Lottery.LotteryBase base2 = new Lottery()[LotteryID];
                                    string description = "";
                                    double winMoneyNoWithTax = 0.0;
                                    for (int k = 0; k < table5.Rows.Count; k++)
                                    {
                                        number = table5.Rows[k]["LotteryNumber"].ToString();
                                        description = "";
                                        winMoneyNoWithTax = 0.0;
                                        double winMoney = base2.ComputeWin(number, str5.Trim(), ref description, ref winMoneyNoWithTax, int.Parse(table5.Rows[k]["PlayTypeID"].ToString()), winMoneyList);
                                        if ((winMoney > 0.0) && (Procedures.P_ChaseTaskStopWhenWin(_Convert.StrToLong(table5.Rows[k]["SiteID"].ToString(), 0L), _Convert.StrToLong(table5.Rows[k]["ID"].ToString(), 0L), winMoney, ref returnValue, ref returnDescription) < 0))
                                        {
                                            new Log(@"ElectronTicket\HPSH").Write("执行电子票--判断是否停止追号的时候出现错误");
                                        }
                                    }
                                }
                                messageID = elementsByTagName[0].Attributes["id"].Value;
                                this.ReNotice(messageID, "508");
                            }
                        }
                        else
                        {
                            base.Response.End();
                        }
                    }
                }
            }
        }
    }

    private int P_ElectronTicketWin(SqlConnection conn, ref DataSet ds, long IsuseID, string BonusXML, string AgentBonusXML, ref int ReturnValue, ref string ReturnDescription)
    {
        MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
        return MSSQL.ExecuteStoredProcedureWithQuery(conn, "P_ElectronTicketWin", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID), new MSSQL.Parameter("BonusXML", SqlDbType.NText, 0, ParameterDirection.Input, BonusXML), new MSSQL.Parameter("AgentBonusXML", SqlDbType.NText, 0, ParameterDirection.Input, AgentBonusXML), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int)ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SystemOptions options = new SystemOptions();
        this.ElectronTicket_HPSH_Status_ON = options["ElectronTicket_HPSH_Status_ON"].ToBoolean(false);
        this.ElectronTicket_HPSH_Getway = options["ElectronTicket_HPSH_Getway"].ToString("");
        this.ElectronTicket_HPSH_UserName = options["ElectronTicket_HPSH_UserName"].ToString("");
        this.ElectronTicket_HPSH_UserPassword = options["ElectronTicket_HPSH_UserPassword"].ToString("");
        this.ElectronTicket_HPSH_IP = options["ElectronTicket_HPSH_IP"].ToString("").Trim();
        if (!this.ElectronTicket_HPSH_Status_ON)
        {
            base.Response.End();
        }
        else if (!base.IsPostBack)
        {
            if (string.IsNullOrEmpty(this.ElectronTicket_HPSH_IP))
            {
                this.ElectronTicket_HPSH_IP = "," + this.ElectronTicket_HPSH_IP + ",";
                if (this.ElectronTicket_HPSH_IP.IndexOf("," + this.GetClientIPAddress() + ",") < 0)
                {
                    new Log(@"ElectronTicket\HPSH").Write("电子票异常客户端 IP 请求。" + this.GetClientIPAddress());
                    base.Response.End();
                    return;
                }
            }
            this.TransType = Utility.GetRequest("transType");
            this.TransMessage = Utility.GetRequest("transMessage");
            this.WriteElectronTicketLog(false, this.TransType, "transType=" + this.TransType + "&transMessage=" + this.TransMessage);
            if (((this.TransType != "") && (this.TransMessage != "")) && this.ValidMessage(this.TransType, this.TransMessage))
            {
                this.Receive(this.TransType, this.TransMessage);
            }
        }
    }

    private void Receive(string TransType, string TransMessage)
    {
        string str = TransType;
        if (str != null)
        {
            if (!(str == "101"))
            {
                if (!(str == "108"))
                {
                    return;
                }
            }
            else
            {
                this.IsuseNotice(TransMessage);
                return;
            }
            this.IsuseOpenNotice(TransMessage);
        }
    }

    private void ReNotice(string MessageID, string Type)
    {
        DateTime now = DateTime.Now;
        string str = "<body><response code=\"0000\" message=\"成功，系统处理正常\"/></body>";
        string str2 = now.ToString("yyyyMMdd") + now.ToString("HHmmss");
        string str3 = "<?xml version=\"1.0\" encoding=\"GBK\"?>";
        str3 = (((((((str3 + "<message version=\"1.0\" id=\"" + MessageID + "\">") + "<header>") + "<messengerID>" + this.ElectronTicket_HPSH_UserName + "</messengerID>") + "<timestamp>" + str2 + "</timestamp>") + "<transactionType>" + Type + "</transactionType>") + "<digest>" + Encrypt.MD5(MessageID + str2 + this.ElectronTicket_HPSH_UserPassword + str, "gb2312") + "</digest>") + "</header>") + str + "</message>";
        base.Response.Write("transType=" + Type + "&transMessage=" + str3);
        this.WriteElectronTicketLog(true, Type, "transType=" + Type + "&transMessage=" + str3);
        base.Response.End();
    }

    private bool ValidMessage(string TransType, string TransMessage)
    {
        XmlDocument document = new XmlDocument();
        XmlNodeList elementsByTagName = null;
        try
        {
            document.Load(new StringReader(TransMessage));
            elementsByTagName = document.GetElementsByTagName("*");
        }
        catch
        {
        }
        if (elementsByTagName == null)
        {
            return false;
        }
        string innerText = "";
        string str2 = "";
        string str3 = "";
        string body = "";
        for (int i = 0; i < elementsByTagName.Count; i++)
        {
            if (elementsByTagName[i].Name.ToUpper() == "MESSAGE")
            {
                if (this.ElectronTicket_HPSH_UserName != this.GetFromXPath(TransMessage, "message/header/messengerID"))
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
        body = this.GetBody(TransMessage);
        return (str3.ToLower() == Encrypt.MD5(str2 + innerText + this.ElectronTicket_HPSH_UserPassword + body, "gb2312").ToLower());
    }

    private void WriteElectronTicketLog(bool isSend, string TransType, string TransMessage)
    {
        new Log(@"ElectronTicket\HPSH").Write("isSend: " + isSend.ToString() + "\tTransType: " + TransType + "\t" + TransMessage);
    }



    private class CompareToLength : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            long num = _Convert.StrToLong(x.ToString(), -1L);
            long num2 = _Convert.StrToLong(y.ToString(), -1L);
            return num.CompareTo(num2);
        }
    }
}

