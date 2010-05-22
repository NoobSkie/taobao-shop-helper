using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using SLS;
using System;
using System.Data;
using System.Text;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class ElectronTicket_Agent_Gateway : WebService
{
    [WebMethod]
    public DataSet Betting(long AgentID, DateTime TimeStamp, string Sign, int LotteryID, string IssueName, int PlayTypeID, string SchemeNumber, string LotteryNumber, double Amount, int Multiple, int Share, string InitiateName, string InitiateAlipayName, string InitiateAlipayID, string InitiateRealityName, string InitiateIDCard, string InitiateTelephone, string InitiateMobile, string InitiateEmail, double InitiateBonusScale, double InitiateBonusLimitLower, double InitiateBonusLimitUpper, string dtJoinDetailXml)
    {
        new Log(@"Agent\ElectronTicket").Write(string.Format("Method=Betting\tAgentID={0}\tTimeStamp={1}\tSign={2}\tLotteryID={3}\tIssueName={4}\tPlayTypeID={5}\tSchemeNumber={6}\tAmount={7}\tMultiple={8}\tShare={9}", new object[] { AgentID, TimeStamp, Sign, LotteryID, IssueName, PlayTypeID, SchemeNumber, Amount, Multiple, Share }));
        DataSet ds = new DataSet();
        string useLotteryList = "";
        double balance = 0.0;
        short state = 0;
        DataTable table = _Convert.XMLToDataTable(dtJoinDetailXml);
        if ((((string.IsNullOrEmpty(SchemeNumber) || (Amount <= 0.0)) || ((Multiple < 1) || (Share < 1))) || ((string.IsNullOrEmpty(InitiateName) || string.IsNullOrEmpty(InitiateAlipayName)) || (string.IsNullOrEmpty(InitiateAlipayID) || string.IsNullOrEmpty(InitiateRealityName)))) || ((string.IsNullOrEmpty(InitiateIDCard) || string.IsNullOrEmpty(InitiateMobile)) || ((table == null) || (table.Rows.Count < 1))))
        {
            this.BuildReturnDataSetForError(-22, "参数不符合规定或者未提供", ref ds);
            new Log(@"Agent\ElectronTicket").Write("参数不符合规定或者未提供");
            return ds;
        }
        if (this.Valid(ref ds, ref useLotteryList, ref balance, ref state, AgentID, TimeStamp, Sign, new object[] { 
            LotteryID, IssueName, PlayTypeID, SchemeNumber, LotteryNumber, Amount, Multiple, Share, InitiateName, InitiateAlipayName, InitiateAlipayID, InitiateRealityName, InitiateIDCard, InitiateTelephone, InitiateMobile, InitiateEmail, 
            InitiateBonusScale, InitiateBonusLimitLower, InitiateBonusLimitUpper, dtJoinDetailXml
         }) >= 0)
        {
            if (state != 1)
            {
                this.BuildReturnDataSetForError(-1, "代理商ID错误", ref ds);
                new Log(@"Agent\ElectronTicket").Write("代理商ID错误");
                return ds;
            }
            if (balance <= 0.0)
            {
                this.BuildReturnDataSetForError(-7, "投注金额超限", ref ds);
                new Log(@"Agent\ElectronTicket").Write("投注金额超限");
                return ds;
            }
            if (this.ValidLotteryID(ref ds, useLotteryList, LotteryID) < 0)
            {
                return ds;
            }
            DataTable table2 = new Tables.T_Isuses().Open("[ID], StartTime, EndTime, State", "LotteryID = " + LotteryID.ToString() + " and [Name] = '" + Utility.FilteSqlInfusion(IssueName) + "'", "");
            if ((table2 == null) || (table2.Rows.Count < 1))
            {
                this.BuildReturnDataSetForError(-4, "奖期不存在", ref ds);
                new Log(@"Agent\ElectronTicket").Write("奖期不存在");
                return ds;
            }
            long isuseID = _Convert.StrToLong(table2.Rows[0]["ID"].ToString(), -1L);
            DateTime time = _Convert.StrToDateTime(table2.Rows[0]["StartTime"].ToString(), "1980-1-1 0:0:0");
            DateTime time2 = _Convert.StrToDateTime(table2.Rows[0]["EndTime"].ToString(), "1980-1-1 0:0:0");
            short num4 = _Convert.StrToShort(table2.Rows[0]["State"].ToString(), -1);
            if (isuseID < 0L)
            {
                this.BuildReturnDataSetForError(-4, "奖期不存在", ref ds);
                new Log(@"Agent\ElectronTicket").Write("奖期不存在");
                return ds;
            }
            DateTime now = DateTime.Now;
            if (now < time)
            {
                this.BuildReturnDataSetForError(-5, "奖期未开启", ref ds);
                new Log(@"Agent\ElectronTicket").Write("奖期未开启");
                return ds;
            }
            if ((now >= time2) || (num4 > 1))
            {
                this.BuildReturnDataSetForError(-6, "奖期已截止投注", ref ds);
                new Log(@"Agent\ElectronTicket").Write(string.Concat(new object[] { "奖期已截止投注|", now.ToString(), "|", num4 }));
                return ds;
            }
            DataTable table3 = new Tables.T_PlayTypes().Open("Price, MaxMultiple", "LotteryID = " + LotteryID.ToString() + " and [ID] = " + PlayTypeID.ToString(), "");
            if (table3 == null)
            {
                this.BuildReturnDataSetForError(-9999, "未知错误", ref ds);
                new Log(@"Agent\ElectronTicket").Write("未知错误");
                return ds;
            }
            if (table3.Rows.Count < 1)
            {
                this.BuildReturnDataSetForError(-21, "玩法ID不存在", ref ds);
                new Log(@"Agent\ElectronTicket").Write("玩法ID不存在");
                return ds;
            }
            double num5 = _Convert.StrToDouble(table3.Rows[0]["Price"].ToString(), 2.0);
            int num6 = _Convert.StrToInt(table3.Rows[0]["MaxMultiple"].ToString(), 200);
            if ((PlayTypeID == 0xf3f) || (PlayTypeID == 0xf40))
            {
                num5 = 3.0;
            }
            if ((Multiple < 1) || (Multiple > num6))
            {
                this.BuildReturnDataSetForError(-8, "倍数超限", ref ds);
                new Log(@"Agent\ElectronTicket").Write("倍数超限");
                return ds;
            }
            if (new Tables.T_ElectronTicketAgentSchemes().GetCount("AgentID = " + AgentID.ToString() + " and SchemeNumber = '" + Utility.FilteSqlInfusion(SchemeNumber) + "'") > 0L)
            {
                this.BuildReturnDataSetForError(-15, "方案号重复", ref ds);
                new Log(@"Agent\ElectronTicket").Write("方案号重复");
                return ds;
            }
            if (((InitiateBonusScale < 0.0) || (InitiateBonusScale > 1.0)) || (InitiateBonusLimitLower < 0.0))
            {
                this.BuildReturnDataSetForError(-10, "佣金设置不符合要求", ref ds);
                new Log(@"Agent\ElectronTicket").Write("佣金设置不符合要求");
                return ds;
            }
            int num = 0;
            LotteryNumber = this.GetLotteryNumber(LotteryID, PlayTypeID, LotteryNumber, ref num);
            if (num == 0)
            {
                this.BuildReturnDataSetForError(-17, "投注号码格式错误", ref ds);
                new Log(@"Agent\ElectronTicket").Write("投注号码格式错误");
                return ds;
            }
            if (((num * Multiple) * num5) != Amount)
            {
                this.BuildReturnDataSetForError(-9, "投注金额与票面金额不符", ref ds);
                new Log(@"Agent\ElectronTicket").Write("投注金额与票面金额不符");
                return ds;
            }
            if ((Share > 1) && (table.Rows.Count < 2))
            {
                this.BuildReturnDataSetForError(-11, "方案份数(金额)与购买明细份数(金额)不符合", ref ds);
                new Log(@"Agent\ElectronTicket").Write("方案份数(金额)与购买明细份数(金额)不符合");
                return ds;
            }
            int num8 = 0;
            double num9 = 0.0;
            string detailXML = "<Details>";
            int num10 = 0;
            foreach (DataRow row in table.Rows)
            {
                string str3 = "";
                string str4 = "";
                string str5 = "";
                string str6 = "";
                string str7 = "";
                string str8 = "";
                string str9 = "";
                int num11 = -1;
                double num12 = -1.0;
                try
                {
                    str3 = row["Name"].ToString();
                    str4 = row["AlipayName"].ToString();
                    str5 = row["RealityName"].ToString();
                    str6 = row["IDCard"].ToString();
                    str7 = row["Telephone"].ToString();
                    str8 = row["Mobile"].ToString();
                    str9 = row["Email"].ToString();
                    num11 = _Convert.StrToInt(row["Share"].ToString(), -1);
                    num12 = _Convert.StrToDouble(row["Amount"].ToString(), -1.0);
                }
                catch
                {
                    this.BuildReturnDataSetForError(-23, "购买明细格式错误", ref ds);
                    new Log(@"Agent\ElectronTicket").Write("购买明细格式错误");
                    return ds;
                }
                if (((string.IsNullOrEmpty(str3) || string.IsNullOrEmpty(str4)) || (string.IsNullOrEmpty(str5) || string.IsNullOrEmpty(str6))) || ((string.IsNullOrEmpty(str7) || (num11 < 1)) || (num12 < 0.0)))
                {
                    this.BuildReturnDataSetForError(-23, "购买明细格式错误", ref ds);
                    new Log(@"Agent\ElectronTicket").Write("购买明细格式错误");
                    return ds;
                }
                num8 += num11;
                num9 += num12;
                detailXML = detailXML + string.Format("<Detail No=\"{0}\" Name=\"{1}\" AlipayName=\"{2}\" RealityName=\"{3}\" IDCard=\"{4}\" Telephone=\"{5}\" Mobile=\"{6}\" Email=\"{7}\" Share=\"{8}\" Amount=\"{9}\" />", new object[] { num10++, str3, str4, str5, str6, str7, str8, str9, num11, num12 });
            }
            detailXML = detailXML + "</Details>";
            if ((num8 != Share) || (num9 != Amount))
            {
                this.BuildReturnDataSetForError(-11, "方案份数(金额)与购买明细份数(金额)不符合", ref ds);
                new Log(@"Agent\ElectronTicket").Write("方案份数(金额)与购买明细份数(金额)不符合");
                return ds;
            }
            if (balance < Amount)
            {
                this.BuildReturnDataSetForError(-7, "投注金额超限", ref ds);
                new Log(@"Agent\ElectronTicket").Write("投注金额超限");
                return ds;
            }
            long schemeID = -1L;
            string returnDescription = "";
            if (Procedures.P_ElectronTicketAgentSchemeAdd(AgentID, SchemeNumber, LotteryID, PlayTypeID, isuseID, LotteryNumber, Amount, Multiple, Share, InitiateName, InitiateAlipayName, InitiateAlipayID, InitiateRealityName, InitiateIDCard, InitiateTelephone, InitiateMobile, InitiateEmail, InitiateBonusScale, InitiateBonusLimitLower, InitiateBonusLimitUpper, detailXML, ref schemeID, ref returnDescription) < 0)
            {
                this.BuildReturnDataSetForError(-9999, "未知错误", ref ds);
                new Log(@"Agent\ElectronTicket").Write("未知错误");
                return ds;
            }
            if (schemeID < 0L)
            {
                this.BuildReturnDataSetForError((int)schemeID, returnDescription, ref ds);
                return ds;
            }
            this.BuildReturnDataSet(0L, ref ds);
            ds.Tables.Add(new DataTable());
        }
        return ds;
    }

    [WebMethod]
    public DataSet BettingWithin(long AgentID, DateTime TimeStamp, string Sign, int LotteryID, string IssueName, int PlayTypeID, string SchemeNumber, string LotteryNumber, double Amount, int Multiple, int Share, string InitiateName, string InitiateAlipayName, string InitiateAlipayID, string InitiateRealityName, string InitiateIDCard, string InitiateTelephone, string InitiateMobile, string InitiateEmail, double InitiateBonusScale, double InitiateBonusLimitLower, double InitiateBonusLimitUpper, string dtJoinDetailXml, string Op_Type)
    {
        new Log(@"Agent\ElectronTicket").Write(string.Format("Method=BettingWithin\tAgentID={0}\tTimeStamp={1}\tSign={2}\tLotteryID={3}\tIssueName={4}\tPlayTypeID={5}\tSchemeNumber={6}\tAmount={7}\tMultiple={8}\tShare={9}\tOp_Type={10}", new object[] { AgentID, TimeStamp, Sign, LotteryID, IssueName, PlayTypeID, SchemeNumber, Amount, Multiple, Share, Op_Type }));
        DataSet ds = new DataSet();
        string useLotteryList = "";
        double balance = 0.0;
        short state = 0;
        if (Op_Type != "0001")
        {
            this.BuildReturnDataSetForError(-101, "不是有效的内部参数调用", ref ds);
            new Log(@"Agent\ElectronTicket").Write("不是有效的内部参数调用");
            return ds;
        }
        DataTable table = _Convert.XMLToDataTable(dtJoinDetailXml);
        if ((((string.IsNullOrEmpty(SchemeNumber) || (Amount <= 0.0)) || ((Multiple < 1) || (Share < 1))) || ((string.IsNullOrEmpty(InitiateName) || string.IsNullOrEmpty(InitiateAlipayName)) || (string.IsNullOrEmpty(InitiateAlipayID) || string.IsNullOrEmpty(InitiateRealityName)))) || ((string.IsNullOrEmpty(InitiateIDCard) || string.IsNullOrEmpty(InitiateMobile)) || ((table == null) || (table.Rows.Count < 1))))
        {
            this.BuildReturnDataSetForError(-22, "参数不符合规定或者未提供", ref ds);
            new Log(@"Agent\ElectronTicket").Write("参数不符合规定或者未提供");
            return ds;
        }
        if (this.Valid(ref ds, ref useLotteryList, ref balance, ref state, AgentID, TimeStamp, Sign, new object[] { 
            LotteryID, IssueName, PlayTypeID, SchemeNumber, LotteryNumber, Amount, Multiple, Share, InitiateName, InitiateAlipayName, InitiateAlipayID, InitiateRealityName, InitiateIDCard, InitiateTelephone, InitiateMobile, InitiateEmail, 
            InitiateBonusScale, InitiateBonusLimitLower, InitiateBonusLimitUpper, dtJoinDetailXml
         }) >= 0)
        {
            if (state != 1)
            {
                this.BuildReturnDataSetForError(-1, "代理商ID错误", ref ds);
                new Log(@"Agent\ElectronTicket").Write("代理商ID错误");
                return ds;
            }
            if (balance <= 0.0)
            {
                this.BuildReturnDataSetForError(-7, "投注金额超限", ref ds);
                new Log(@"Agent\ElectronTicket").Write("投注金额超限");
                return ds;
            }
            if (this.ValidLotteryID(ref ds, useLotteryList, LotteryID) < 0)
            {
                return ds;
            }
            DataTable table2 = new Tables.T_Isuses().Open("[ID], StartTime, EndTime, State", "LotteryID = " + LotteryID.ToString() + " and [Name] = '" + Utility.FilteSqlInfusion(IssueName) + "'", "");
            if ((table2 == null) || (table2.Rows.Count < 1))
            {
                this.BuildReturnDataSetForError(-4, "奖期不存在", ref ds);
                new Log(@"Agent\ElectronTicket").Write("奖期不存在");
                return ds;
            }
            long isuseID = _Convert.StrToLong(table2.Rows[0]["ID"].ToString(), -1L);
            DateTime time = _Convert.StrToDateTime(table2.Rows[0]["StartTime"].ToString(), "1980-1-1 0:0:0");
            DateTime time2 = _Convert.StrToDateTime(table2.Rows[0]["EndTime"].ToString(), "1980-1-1 0:0:0");
            short num4 = _Convert.StrToShort(table2.Rows[0]["State"].ToString(), -1);
            if (isuseID < 0L)
            {
                this.BuildReturnDataSetForError(-4, "奖期不存在", ref ds);
                new Log(@"Agent\ElectronTicket").Write("奖期不存在");
                return ds;
            }
            DateTime now = DateTime.Now;
            if (now < time)
            {
                this.BuildReturnDataSetForError(-5, "奖期未开启", ref ds);
                new Log(@"Agent\ElectronTicket").Write("奖期未开启");
                return ds;
            }
            if ((now >= time2) || (num4 > 1))
            {
                this.BuildReturnDataSetForError(-6, "奖期已截止投注", ref ds);
                new Log(@"Agent\ElectronTicket").Write(string.Concat(new object[] { "奖期已截止投注|", now.ToString(), "|", num4 }));
                return ds;
            }
            DataTable table3 = new Tables.T_PlayTypes().Open("Price, MaxMultiple", "LotteryID = " + LotteryID.ToString() + " and [ID] = " + PlayTypeID.ToString(), "");
            if (table3 == null)
            {
                this.BuildReturnDataSetForError(-9999, "未知错误", ref ds);
                new Log(@"Agent\ElectronTicket").Write("未知错误");
                return ds;
            }
            if (table3.Rows.Count < 1)
            {
                this.BuildReturnDataSetForError(-21, "玩法ID不存在", ref ds);
                new Log(@"Agent\ElectronTicket").Write("玩法ID不存在");
                return ds;
            }
            double num5 = _Convert.StrToDouble(table3.Rows[0]["Price"].ToString(), 2.0);
            int num6 = _Convert.StrToInt(table3.Rows[0]["MaxMultiple"].ToString(), 200);
            if ((PlayTypeID == 0xf3f) || (PlayTypeID == 0xf40))
            {
                num5 = 3.0;
            }
            if ((Multiple < 1) || (Multiple > num6))
            {
                this.BuildReturnDataSetForError(-8, "倍数超限", ref ds);
                new Log(@"Agent\ElectronTicket").Write("倍数超限");
                return ds;
            }
            if (new Tables.T_ElectronTicketAgentSchemes().GetCount("AgentID = " + AgentID.ToString() + " and SchemeNumber = '" + Utility.FilteSqlInfusion(SchemeNumber) + "'") > 0L)
            {
                this.BuildReturnDataSetForError(-15, "方案号重复", ref ds);
                new Log(@"Agent\ElectronTicket").Write("方案号重复");
                return ds;
            }
            if (((InitiateBonusScale < 0.0) || (InitiateBonusScale > 1.0)) || (InitiateBonusLimitLower < 0.0))
            {
                this.BuildReturnDataSetForError(-10, "佣金设置不符合要求", ref ds);
                new Log(@"Agent\ElectronTicket").Write("佣金设置不符合要求");
                return ds;
            }
            int num = 0;
            LotteryNumber = this.GetLotteryNumber(LotteryID, PlayTypeID, UnEncryptString(LotteryNumber), ref num);
            if (num == 0)
            {
                this.BuildReturnDataSetForError(-17, "投注号码格式错误", ref ds);
                new Log(@"Agent\ElectronTicket").Write("投注号码格式错误");
                return ds;
            }
            if (((num * Multiple) * num5) != Amount)
            {
                this.BuildReturnDataSetForError(-9, "投注金额与票面金额不符", ref ds);
                new Log(@"Agent\ElectronTicket").Write("投注金额与票面金额不符");
                return ds;
            }
            if ((Share > 1) && (table.Rows.Count < 2))
            {
                this.BuildReturnDataSetForError(-11, "方案份数(金额)与购买明细份数(金额)不符合", ref ds);
                new Log(@"Agent\ElectronTicket").Write("方案份数(金额)与购买明细份数(金额)不符合");
                return ds;
            }
            int num8 = 0;
            double num9 = 0.0;
            string detailXML = "<Details>";
            int num10 = 0;
            foreach (DataRow row in table.Rows)
            {
                string str3 = "";
                string str4 = "";
                string str5 = "";
                string str6 = "";
                string str7 = "";
                string str8 = "";
                string str9 = "";
                int num11 = -1;
                double num12 = -1.0;
                try
                {
                    str3 = row["Name"].ToString();
                    str4 = row["AlipayName"].ToString();
                    str5 = row["RealityName"].ToString();
                    str6 = row["IDCard"].ToString();
                    str7 = row["Telephone"].ToString();
                    str8 = row["Mobile"].ToString();
                    str9 = row["Email"].ToString();
                    num11 = _Convert.StrToInt(row["Share"].ToString(), -1);
                    num12 = _Convert.StrToDouble(row["Amount"].ToString(), -1.0);
                }
                catch
                {
                    this.BuildReturnDataSetForError(-23, "购买明细格式错误", ref ds);
                    new Log(@"Agent\ElectronTicket").Write("购买明细格式错误");
                    return ds;
                }
                if (((string.IsNullOrEmpty(str3) || string.IsNullOrEmpty(str4)) || (string.IsNullOrEmpty(str5) || string.IsNullOrEmpty(str6))) || ((string.IsNullOrEmpty(str7) || (num11 < 1)) || (num12 < 0.0)))
                {
                    this.BuildReturnDataSetForError(-23, "购买明细格式错误", ref ds);
                    new Log(@"Agent\ElectronTicket").Write("购买明细格式错误");
                    return ds;
                }
                num8 += num11;
                num9 += num12;
                detailXML = detailXML + string.Format("<Detail No=\"{0}\" Name=\"{1}\" AlipayName=\"{2}\" RealityName=\"{3}\" IDCard=\"{4}\" Telephone=\"{5}\" Mobile=\"{6}\" Email=\"{7}\" Share=\"{8}\" Amount=\"{9}\" />", new object[] { num10++, str3, str4, str5, str6, str7, str8, str9, num11, num12 });
            }
            detailXML = detailXML + "</Details>";
            if ((num8 != Share) || (num9 != Amount))
            {
                this.BuildReturnDataSetForError(-11, "方案份数(金额)与购买明细份数(金额)不符合", ref ds);
                new Log(@"Agent\ElectronTicket").Write("方案份数(金额)与购买明细份数(金额)不符合");
                return ds;
            }
            if (balance < Amount)
            {
                this.BuildReturnDataSetForError(-7, "投注金额超限", ref ds);
                new Log(@"Agent\ElectronTicket").Write("投注金额超限");
                return ds;
            }
            long schemeID = 0L;
            string returnDescription = "";
            if (Procedures.P_ElectronTicketAgentSchemeAdd(AgentID, SchemeNumber, LotteryID, PlayTypeID, isuseID, LotteryNumber, Amount, Multiple, Share, InitiateName, InitiateAlipayName, InitiateAlipayID, InitiateRealityName, InitiateIDCard, InitiateTelephone, InitiateMobile, InitiateEmail, InitiateBonusScale, InitiateBonusLimitLower, InitiateBonusLimitUpper, detailXML, ref schemeID, ref returnDescription) < 0)
            {
                this.BuildReturnDataSetForError(-9999, "未知错误", ref ds);
                new Log(@"Agent\ElectronTicket").Write("未知错误");
                return ds;
            }
            if (schemeID < 0L)
            {
                this.BuildReturnDataSetForError((int)schemeID, returnDescription, ref ds);
                return ds;
            }
            this.BuildReturnDataSet(0L, ref ds);
            ds.Tables.Add(new DataTable());
        }
        return ds;
    }

    private void BuildReturnDataSet(long ReturnNumber, ref DataSet ds)
    {
        DataTable table = new DataTable();
        table.Columns.Add("Result", typeof(long));
        table.Columns.Add("Description", typeof(string));
        DataRow row = table.NewRow();
        row["Result"] = ReturnNumber;
        row["Description"] = "接口调用成功";
        table.Rows.Add(row);
        if (ds == null)
        {
            ds = new DataSet();
        }
        ds.Tables.Clear();
        ds.Tables.Add(table);
    }

    private void BuildReturnDataSetForError(int ErrorNumber, string Description, ref DataSet ds)
    {
        DataTable table = new DataTable();
        table.Columns.Add("Result", typeof(long));
        table.Columns.Add("Description", typeof(string));
        DataRow row = table.NewRow();
        row["Result"] = ErrorNumber;
        row["Description"] = Description;
        table.Rows.Add(row);
        if (ds == null)
        {
            ds = new DataSet();
        }
        ds.Tables.Clear();
        ds.Tables.Add(table);
    }

    private string GetClientIPAddress()
    {
        if (base.Context.Request.ServerVariables["HTTP_VIA"] != null)
        {
            return base.Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        return base.Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
    }

    [WebMethod]
    public DataSet GetIssueBonus(long AgentID, DateTime TimeStamp, string Sign, int LotteryID, string IssueName)
    {
        new Log(@"Agent\ElectronTicket").Write(string.Format("Method=GetIssueBonus\tAgentID={0}\tTimeStamp={1}\tSign={2}\tLotteryID={3}\tIssueName={4}", new object[] { AgentID, TimeStamp, Sign, LotteryID, IssueName }));
        DataSet returnDS = new DataSet();
        string useLotteryList = "";
        double balance = 0.0;
        short state = 0;
        if (this.Valid(ref returnDS, ref useLotteryList, ref balance, ref state, AgentID, TimeStamp, Sign, new object[] { LotteryID, IssueName }) >= 0)
        {
            if (this.ValidLotteryID(ref returnDS, useLotteryList, LotteryID) < 0)
            {
                return returnDS;
            }
            DataTable table = new Tables.T_Isuses().Open("[ID], StartTime, EndTime, State, isOpened", "LotteryID = " + LotteryID.ToString() + "and [Name] = '" + Utility.FilteSqlInfusion(IssueName) + "'", "");
            if ((table == null) || (table.Rows.Count < 1))
            {
                this.BuildReturnDataSetForError(-4, "奖期不存在", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("奖期不存在");
                return returnDS;
            }
            long num3 = _Convert.StrToLong(table.Rows[0]["ID"].ToString(), -1L);
            DateTime time = _Convert.StrToDateTime(table.Rows[0]["StartTime"].ToString(), "1980-1-1 0:0:0");
            _Convert.StrToDateTime(table.Rows[0]["EndTime"].ToString(), "1980-1-1 0:0:0");
            short num4 = _Convert.StrToShort(table.Rows[0]["State"].ToString(), -1);
            bool flag = _Convert.StrToBool(table.Rows[0]["isOpened"].ToString(), false);
            if (num3 < 0L)
            {
                this.BuildReturnDataSetForError(-4, "奖期不存在", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("奖期不存在");
                return returnDS;
            }
            if ((DateTime.Now < time) || (num4 < 1))
            {
                this.BuildReturnDataSetForError(-5, "奖期未开启", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("奖期未开启");
                return returnDS;
            }
            if (!flag)
            {
                this.BuildReturnDataSetForError(-18, "奖期尚未开奖", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("奖期尚未开奖");
                return returnDS;
            }
            this.BuildReturnDataSet(0L, ref returnDS);
            DataTable table2 = new Views.V_ElectronTicketAgentSchemes().Open("LotteryID, IsuseName as IssueName, SchemeNumber, WinMoney as Bonus, WinMoneyWithoutTax as BonusWithoutTax, WinLotteryNumber as BonusNumber, WinDescription as BonusDescription", "AgentID = " + AgentID.ToString() + " and LotteryID = " + LotteryID.ToString() + " and IsuseID = " + num3.ToString() + " and WinMoney <> 0", "[ID]");
            returnDS.Tables.Add(table2);
        }
        return returnDS;
    }

    [WebMethod]
    public DataSet GetIssueInformation(long AgentID, DateTime TimeStamp, string Sign, int LotteryID, string IssueName)
    {
        new Log(@"Agent\ElectronTicket").Write(string.Format("Method=GetIssueInformation\tAgentID={0}\tTimeStamp={1}\tSign={2}\tLotteryID={3}\tIssueName={4}", new object[] { AgentID, TimeStamp, Sign, LotteryID, IssueName }));
        DataSet returnDS = new DataSet();
        string useLotteryList = "";
        double balance = 0.0;
        short state = 0;
        if (this.Valid(ref returnDS, ref useLotteryList, ref balance, ref state, AgentID, TimeStamp, Sign, new object[] { LotteryID, IssueName }) >= 0)
        {
            if (this.ValidLotteryID(ref returnDS, useLotteryList, LotteryID) < 0)
            {
                return returnDS;
            }
            DataTable table = new Tables.T_Isuses().Open("LotteryID, [Name] as IssueName, StartTime, EndTime, State as Status, WinLotteryNumber as BonusNumber", "LotteryID = " + LotteryID.ToString() + " and [Name] = '" + Utility.FilteSqlInfusion(IssueName) + "'", "");
            if (table == null)
            {
                this.BuildReturnDataSetForError(-9999, "未知错误", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("未知错误");
                return returnDS;
            }
            if (table.Rows.Count < 1)
            {
                this.BuildReturnDataSetForError(-4, "奖期不存在", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("奖期不存在");
                return returnDS;
            }
            this.BuildReturnDataSet(0L, ref returnDS);
            returnDS.Tables.Add(table);
        }
        return returnDS;
    }

    [WebMethod]
    public DataSet GetIssues(long AgentID, DateTime TimeStamp, string Sign, int LotteryID, DateTime StartTime, DateTime EndTime)
    {
        new Log(@"Agent\ElectronTicket").Write(string.Format("Method=GetIssues\tAgentID={0}\tTimeStamp={1}\tSign={2}\tLotteryID={3}\tStartTime={4}\tEndTime={5}", new object[] { AgentID, TimeStamp, Sign, LotteryID, StartTime, EndTime }));
        DataSet returnDS = new DataSet();
        string useLotteryList = "";
        double balance = 0.0;
        short state = 0;
        if (this.Valid(ref returnDS, ref useLotteryList, ref balance, ref state, AgentID, TimeStamp, Sign, new object[] { LotteryID, StartTime, EndTime }) >= 0)
        {
            if (LotteryID >= 0)
            {
                if (this.ValidLotteryID(ref returnDS, useLotteryList, LotteryID) < 0)
                {
                    return returnDS;
                }
            }
            else if (useLotteryList == "")
            {
                this.BuildReturnDataSetForError(-3, "彩种ID不存在或暂不支持", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("彩种ID不存在或暂不支持");
                return returnDS;
            }
            DataTable table = null;
            if (LotteryID >= 0)
            {
                table = new Tables.T_Isuses().Open("LotteryID, [Name] as IssueName, StartTime, EndTime, State as Status, WinLotteryNumber as BonusNumber", "LotteryID = " + LotteryID.ToString() + " and StartTime between '" + StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "'", "StartTime");
            }
            else
            {
                table = new Tables.T_Isuses().Open("LotteryID, [Name] as IssueName, StartTime, EndTime, State as Status, WinLotteryNumber as BonusNumber", "LotteryID in (" + useLotteryList + ") and StartTime between '" + StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "'", "StartTime");
            }
            if (table == null)
            {
                this.BuildReturnDataSetForError(-9999, "未知错误", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("未知错误");
                return returnDS;
            }
            this.BuildReturnDataSet(0L, ref returnDS);
            returnDS.Tables.Add(table);
        }
        return returnDS;
    }

    private long GetIsuseID(int LotteryID, string IsuseName)
    {
        DataTable table = new Tables.T_Isuses().Open("[ID]", "LotteryID = " + LotteryID.ToString() + "and [Name] = '" + Utility.FilteSqlInfusion(IsuseName) + "'", "");
        if ((table != null) && (table.Rows.Count >= 1))
        {
            return _Convert.StrToLong(table.Rows[0]["ID"].ToString(), -1L);
        }
        return -1L;
    }

    private string GetLotteryNumber(int LotteryID, int PlayTypeID, string BettingNumber, ref int Num)
    {
        Num = 0;
        if (string.IsNullOrEmpty(BettingNumber))
        {
            return "";
        }
        Lottery.LotteryBase base2 = new Lottery()[LotteryID];
        if (base2 == null)
        {
            return "";
        }
        string str = base2.AnalyseScheme(BettingNumber, PlayTypeID);
        if (string.IsNullOrEmpty(str))
        {
            return "";
        }
        string[] strArray = str.Split(new char[] { '\n' });
        if ((strArray == null) || (strArray.Length < 1))
        {
            return "";
        }
        string str2 = "";
        foreach (string str3 in strArray)
        {
            string str4 = str3.Trim();
            if (!string.IsNullOrEmpty(str4))
            {
                string[] strArray3 = str4.Split(new char[] { '|' });
                if ((strArray3 != null) && (strArray3.Length == 2))
                {
                    int num2 = _Convert.StrToInt(strArray3[1], -1);
                    if (!string.IsNullOrEmpty(strArray3[0]) && (num2 >= 1))
                    {
                        str2 = str2 + strArray3[0] + "\n";
                        Num += num2;
                    }
                }
            }
        }
        if (str2.EndsWith("\n"))
        {
            str2 = str2.Substring(0, str2.Length - 1);
        }
        return str2;
    }

    [WebMethod]
    public DataSet GetSchemes(long AgentID, DateTime TimeStamp, string Sign, int LotteryID, string IssueName)
    {
        new Log(@"Agent\ElectronTicket").Write(string.Format("Method=GetSchemes\tAgentID={0}\tTimeStamp={1}\tSign={2}\tLotteryID={3}\tIssueName={4}", new object[] { AgentID, TimeStamp, Sign, LotteryID, IssueName }));
        DataSet returnDS = new DataSet();
        string useLotteryList = "";
        double balance = 0.0;
        short state = 0;
        if (this.Valid(ref returnDS, ref useLotteryList, ref balance, ref state, AgentID, TimeStamp, Sign, new object[] { LotteryID, IssueName }) >= 0)
        {
            if (this.ValidLotteryID(ref returnDS, useLotteryList, LotteryID) < 0)
            {
                return returnDS;
            }
            DataTable table = new Tables.T_Isuses().Open("[ID], StartTime, EndTime, State, isOpened", "LotteryID = " + LotteryID.ToString() + "and [Name] = '" + Utility.FilteSqlInfusion(IssueName) + "'", "");
            if ((table == null) || (table.Rows.Count < 1))
            {
                this.BuildReturnDataSetForError(-4, "奖期不存在", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("奖期不存在");
                return returnDS;
            }
            long num3 = _Convert.StrToLong(table.Rows[0]["ID"].ToString(), -1L);
            DateTime time = _Convert.StrToDateTime(table.Rows[0]["StartTime"].ToString(), "1980-1-1 0:0:0");
            short num4 = _Convert.StrToShort(table.Rows[0]["State"].ToString(), -1);
            if (num3 < 0L)
            {
                this.BuildReturnDataSetForError(-4, "奖期不存在", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("奖期不存在");
                return returnDS;
            }
            if ((DateTime.Now < time) || (num4 < 1))
            {
                this.BuildReturnDataSetForError(-5, "奖期未开启", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("奖期未开启");
                return returnDS;
            }
            this.BuildReturnDataSet(0L, ref returnDS);
            DataTable table2 = new Tables.T_ElectronTicketAgentSchemes().Open("SchemeNumber, State", "AgentID = " + AgentID.ToString() + " and IsuseID = " + num3.ToString(), "[ID]");
            returnDS.Tables.Add(table2);
        }
        return returnDS;
    }

    [WebMethod]
    public DataSet GetSchemeTickets(long AgentID, DateTime TimeStamp, string Sign, string SchemeNumber)
    {
        new Log(@"Agent\ElectronTicket").Write(string.Format("Method=GetSchemeTickets\tAgentID={0}\tTimeStamp={1}\tSign={2}\tSchemeNumber={3}", new object[] { AgentID, TimeStamp, Sign, SchemeNumber }));
        DataSet returnDS = new DataSet();
        string useLotteryList = "";
        double balance = 0.0;
        short state = 0;
        if (this.Valid(ref returnDS, ref useLotteryList, ref balance, ref state, AgentID, TimeStamp, Sign, new object[] { SchemeNumber }) >= 0)
        {
            DataTable table = new Tables.T_ElectronTicketAgentSchemes().Open("[ID]", "AgentID = " + AgentID.ToString() + " and SchemeNumber = '" + Utility.FilteSqlInfusion(SchemeNumber) + "'", "");
            if ((table == null) || (table.Rows.Count < 1))
            {
                this.BuildReturnDataSetForError(-16, "方案号不存在", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("方案号不存在");
                return returnDS;
            }
            long num3 = _Convert.StrToLong(table.Rows[0]["ID"].ToString(), -1L);
            if (num3 < 0L)
            {
                this.BuildReturnDataSetForError(-16, "方案号不存在", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("方案号不存在");
                return returnDS;
            }
            table = new Tables.T_ElectronTicketAgentSchemesSendToCenter().Open("Identifiers, Multiple, Money, Ticket, Sends, HandleResult, HandleDescription, WinMoney as Bonus, BonusLevel", "SchemeID = " + num3.ToString(), "[ID]");
            if (table == null)
            {
                this.BuildReturnDataSetForError(-9999, "未知错误", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("未知错误");
                return returnDS;
            }
            this.BuildReturnDataSet(0L, ref returnDS);
            returnDS.Tables.Add(table);
        }
        return returnDS;
    }

    [WebMethod]
    public DataSet GetUnsuccessfulSchemes(long AgentID, DateTime TimeStamp, string Sign, int LotteryID, string IssueName)
    {
        new Log(@"Agent\ElectronTicket").Write(string.Format("Method=GetUnsuccessfulSchemes\tAgentID={0}\tTimeStamp={1}\tSign={2}\tLotteryID={3}\tIssueName={4}", new object[] { AgentID, TimeStamp, Sign, LotteryID, IssueName }));
        DataSet returnDS = new DataSet();
        string useLotteryList = "";
        double balance = 0.0;
        short state = 0;
        if (this.Valid(ref returnDS, ref useLotteryList, ref balance, ref state, AgentID, TimeStamp, Sign, new object[] { LotteryID, IssueName }) >= 0)
        {
            if (this.ValidLotteryID(ref returnDS, useLotteryList, LotteryID) < 0)
            {
                return returnDS;
            }
            DataTable table = new Tables.T_Isuses().Open("[ID], StartTime, EndTime, State, isOpened", "LotteryID = " + LotteryID.ToString() + "and [Name] = '" + Utility.FilteSqlInfusion(IssueName) + "'", "");
            if ((table == null) || (table.Rows.Count < 1))
            {
                this.BuildReturnDataSetForError(-4, "奖期不存在", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("奖期不存在");
                return returnDS;
            }
            long num3 = _Convert.StrToLong(table.Rows[0]["ID"].ToString(), -1L);
            DateTime time = _Convert.StrToDateTime(table.Rows[0]["StartTime"].ToString(), "1980-1-1 0:0:0");
            short num4 = _Convert.StrToShort(table.Rows[0]["State"].ToString(), -1);
            if (num3 < 0L)
            {
                this.BuildReturnDataSetForError(-4, "奖期不存在", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("奖期不存在");
                return returnDS;
            }
            if ((DateTime.Now < time) || (num4 < 1))
            {
                this.BuildReturnDataSetForError(-5, "奖期未开启", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("奖期未开启");
                return returnDS;
            }
            this.BuildReturnDataSet(0L, ref returnDS);
            DataTable table2 = new Tables.T_ElectronTicketAgentSchemes().Open("SchemeNumber, State", "AgentID = " + AgentID.ToString() + " and IsuseID = " + num3.ToString() + " and State <> 1", "[ID]");
            returnDS.Tables.Add(table2);
        }
        return returnDS;
    }

    private string ParamterToString(object Param)
    {
        if (Param is DateTime)
        {
            DateTime time = (DateTime)Param;
            return time.ToString("yyyyMMdd HHmmss");
        }
        if (Param is DataTable)
        {
            return _Convert.DataTableToXML((DataTable)Param);
        }
        if (Param is string)
        {
            return (string)Param;
        }
        return Param.ToString();
    }

    [WebMethod]
    public DataSet QueryBetting(long AgentID, DateTime TimeStamp, string Sign, string SchemeNumber)
    {
        new Log(@"Agent\ElectronTicket").Write(string.Format("Method=QueryBetting\tAgentID={0}\tTimeStamp={1}\tSign={2}\tSchemeNumber={3}", new object[] { AgentID, TimeStamp, Sign, SchemeNumber }));
        DataSet returnDS = new DataSet();
        string useLotteryList = "";
        double balance = 0.0;
        short state = 0;
        if (this.Valid(ref returnDS, ref useLotteryList, ref balance, ref state, AgentID, TimeStamp, Sign, new object[] { SchemeNumber }) >= 0)
        {
            DataTable table = new Tables.T_ElectronTicketAgentSchemes().Open("[ID], State, BettingDescription", "AgentID = " + AgentID.ToString() + " and SchemeNumber = '" + Utility.FilteSqlInfusion(SchemeNumber) + "'", "");
            if (table == null)
            {
                this.BuildReturnDataSetForError(-9999, "未知错误", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("未知错误");
                return returnDS;
            }
            if (table.Rows.Count < 1)
            {
                this.BuildReturnDataSetForError(-16, "方案号不存在", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("方案号不存在");
                return returnDS;
            }
            long num3 = _Convert.StrToLong(table.Rows[0]["ID"].ToString(), -1L);
            short num4 = _Convert.StrToShort(table.Rows[0]["State"].ToString(), -1);
            string str2 = table.Rows[0]["BettingDescription"].ToString();
            if ((num3 < 0L) || (num4 < 0))
            {
                this.BuildReturnDataSetForError(-9999, "未知错误", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("未知错误");
                return returnDS;
            }
            if (num4 == 0)
            {
                this.BuildReturnDataSetForError(-24, "等待出票", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("等待出票");
                return returnDS;
            }
            if (num4 >= 2)
            {
                this.BuildReturnDataSetForError(-13, "出票失败(" + str2 + ")", ref returnDS);
                new Log(@"Agent\ElectronTicket").Write("出票失败(" + str2 + ")");
                return returnDS;
            }
            this.BuildReturnDataSet(0L, ref returnDS);
            DataTable table2 = new Tables.T_ElectronTicketAgentSchemesSendToCenter().Open("Identifiers as TicketID", "SchemeID = " + num3.ToString(), "[ID]");
            returnDS.Tables.Add(table2);
        }
        return returnDS;
    }

    private static string UnEncryptString(string d)
    {
        int num;
        if (((d == null) || (d == "")) || (d.Length < 2))
        {
            return "";
        }
        ReplaceKey key = new ReplaceKey();
        for (num = 0x33; num >= 0; num--)
        {
            d = d.Replace(key.Key[1, num], key.Key[0, num]);
        }
        int num2 = int.Parse(d.Substring(0, 3));
        int[] numArray = new int[] { num2 / 100, (num2 % 100) / 10, num2 % 10 };
        d = d.Substring(3, d.Length - 3);
        int num3 = d.Length / 3;
        byte[] bytes = new byte[num3];
        for (num = 0; num < num3; num++)
        {
            bytes[num] = (byte)(int.Parse(d.Substring(num * 3, 3)) - numArray[num % 3]);
        }
        return Encoding.UTF8.GetString(bytes);
    }

    private int Valid(ref DataSet ReturnDS, ref string UseLotteryList, ref double Balance, ref short State, long AgentID, DateTime TimeStamp, string Sign, params object[] Params)
    {
        UseLotteryList = "";
        Balance = 0.0;
        State = 0;
        TimeSpan span = (TimeSpan)(DateTime.Now - TimeStamp);
        if (Math.Abs(span.TotalSeconds) > 300.0)
        {
            this.BuildReturnDataSetForError(-20, "访问超时", ref ReturnDS);
            new Log(@"Agent\ElectronTicket").Write("访问超时");
            return -20;
        }
        DataTable table = new Tables.T_ElectronTicketAgents().Open("", "[ID] = " + AgentID.ToString(), "");
        if (table == null)
        {
            this.BuildReturnDataSetForError(-9999, "未知错误", ref ReturnDS);
            new Log(@"Agent\ElectronTicket").Write("未知错误");
            return -9999;
        }
        if (table.Rows.Count < 1)
        {
            this.BuildReturnDataSetForError(-1, "代理商ID错误", ref ReturnDS);
            new Log(@"Agent\ElectronTicket").Write("代理商ID错误");
            return -1;
        }
        string str = table.Rows[0]["IPAddressLimit"].ToString();
        if ((str != "") && (("," + str + ",").IndexOf("," + this.GetClientIPAddress() + ",") < 0))
        {
            this.BuildReturnDataSetForError(-25, "IP地址限制", ref ReturnDS);
            new Log(@"Agent\ElectronTicket").Write("IP地址限制");
            return -25;
        }
        string str2 = table.Rows[0]["Key"].ToString();
        string str3 = AgentID.ToString() + this.ParamterToString(TimeStamp);
        foreach (object obj2 in Params)
        {
            str3 = str3 + this.ParamterToString(obj2);
        }
        if (Encrypt.MD5(str3 + str2).ToLower() != Sign.ToLower())
        {
            this.BuildReturnDataSetForError(-2, "签名校验失败", ref ReturnDS);
            new Log(@"Agent\ElectronTicket").Write("签名校验失败");
            return -2;
        }
        UseLotteryList = table.Rows[0]["UseLotteryList"].ToString();
        Balance = _Convert.StrToDouble(table.Rows[0]["Balance"].ToString(), 0.0);
        State = _Convert.StrToShort(table.Rows[0]["State"].ToString(), 0);
        return 0;
    }

    private int ValidLotteryID(ref DataSet ReturnDS, string UseLotteryList, int LotteryID)
    {
        if (string.IsNullOrEmpty(UseLotteryList))
        {
            UseLotteryList = "";
        }
        else
        {
            UseLotteryList = "," + UseLotteryList + ",";
        }
        if (UseLotteryList.IndexOf("," + LotteryID.ToString() + ",") < 0)
        {
            this.BuildReturnDataSetForError(-3, "彩种ID不存在或暂不支持", ref ReturnDS);
            new Log(@"Agent\ElectronTicket").Write("彩种ID不存在或暂不支持");
            return -3;
        }
        return 0;
    }

    private class ReplaceKey
    {
        public string[,] Key = new string[2, 0x54];

        public ReplaceKey()
        {
            this.Key[0, 0] = "00";
            this.Key[1, 0] = "A";
            this.Key[0, 1] = "11";
            this.Key[1, 1] = "B";
            this.Key[0, 2] = "22";
            this.Key[1, 2] = "H";
            this.Key[0, 3] = "33";
            this.Key[1, 3] = "e";
            this.Key[0, 4] = "44";
            this.Key[1, 4] = "F";
            this.Key[0, 5] = "55";
            this.Key[1, 5] = "E";
            this.Key[0, 6] = "66";
            this.Key[1, 6] = "M";
            this.Key[0, 7] = "77";
            this.Key[1, 7] = "z";
            this.Key[0, 8] = "88";
            this.Key[1, 8] = "I";
            this.Key[0, 9] = "99";
            this.Key[1, 9] = "b";
            this.Key[0, 10] = "10";
            this.Key[1, 10] = "K";
            this.Key[0, 11] = "20";
            this.Key[1, 11] = "L";
            this.Key[0, 12] = "30";
            this.Key[1, 12] = "C";
            this.Key[0, 13] = "40";
            this.Key[1, 13] = "N";
            this.Key[0, 14] = "50";
            this.Key[1, 14] = "l";
            this.Key[0, 15] = "60";
            this.Key[1, 15] = "n";
            this.Key[0, 0x10] = "70";
            this.Key[1, 0x10] = "m";
            this.Key[0, 0x11] = "80";
            this.Key[1, 0x11] = "R";
            this.Key[0, 0x12] = "90";
            this.Key[1, 0x12] = "a";
            this.Key[0, 0x13] = "01";
            this.Key[1, 0x13] = "T";
            this.Key[0, 20] = "21";
            this.Key[1, 20] = "U";
            this.Key[0, 0x15] = "31";
            this.Key[1, 0x15] = "j";
            this.Key[0, 0x16] = "41";
            this.Key[1, 0x16] = "W";
            this.Key[0, 0x17] = "51";
            this.Key[1, 0x17] = "X";
            this.Key[0, 0x18] = "61";
            this.Key[1, 0x18] = "V";
            this.Key[0, 0x19] = "71";
            this.Key[1, 0x19] = "Z";
            this.Key[0, 0x1a] = "81";
            this.Key[1, 0x1a] = "S";
            this.Key[0, 0x1b] = "91";
            this.Key[1, 0x1b] = "J";
            this.Key[0, 0x1c] = "02";
            this.Key[1, 0x1c] = "c";
            this.Key[0, 0x1d] = "12";
            this.Key[1, 0x1d] = "d";
            this.Key[0, 30] = "32";
            this.Key[1, 30] = "D";
            this.Key[0, 0x1f] = "42";
            this.Key[1, 0x1f] = "f";
            this.Key[0, 0x20] = "52";
            this.Key[1, 0x20] = "G";
            this.Key[0, 0x21] = "62";
            this.Key[1, 0x21] = "h";
            this.Key[0, 0x22] = "72";
            this.Key[1, 0x22] = "i";
            this.Key[0, 0x23] = "82";
            this.Key[1, 0x23] = "w";
            this.Key[0, 0x24] = "92";
            this.Key[1, 0x24] = "k";
            this.Key[0, 0x25] = "03";
            this.Key[1, 0x25] = "O";
            this.Key[0, 0x26] = "13";
            this.Key[1, 0x26] = "Q";
            this.Key[0, 0x27] = "23";
            this.Key[1, 0x27] = "P";
            this.Key[0, 40] = "43";
            this.Key[1, 40] = "o";
            this.Key[0, 0x29] = "53";
            this.Key[1, 0x29] = "p";
            this.Key[0, 0x2a] = "63";
            this.Key[1, 0x2a] = "x";
            this.Key[0, 0x2b] = "73";
            this.Key[1, 0x2b] = "t";
            this.Key[0, 0x2c] = "83";
            this.Key[1, 0x2c] = "s";
            this.Key[0, 0x2d] = "93";
            this.Key[1, 0x2d] = "r";
            this.Key[0, 0x2e] = "04";
            this.Key[1, 0x2e] = "u";
            this.Key[0, 0x2f] = "14";
            this.Key[1, 0x2f] = "v";
            this.Key[0, 0x30] = "24";
            this.Key[1, 0x30] = "Y";
            this.Key[0, 0x31] = "34";
            this.Key[1, 0x31] = "q";
            this.Key[0, 50] = "54";
            this.Key[1, 50] = "y";
            this.Key[0, 0x33] = "64";
            this.Key[1, 0x33] = "g";
            this.Key[0, 0x34] = "74";
            this.Key[1, 0x34] = "!";
            this.Key[0, 0x35] = "84";
            this.Key[1, 0x35] = "@";
            this.Key[0, 0x36] = "94";
            this.Key[1, 0x36] = "#";
            this.Key[0, 0x37] = "05";
            this.Key[1, 0x37] = "$";
            this.Key[0, 0x38] = "15";
            this.Key[1, 0x38] = "%";
            this.Key[0, 0x39] = "25";
            this.Key[1, 0x39] = "^";
            this.Key[0, 0x3a] = "35";
            this.Key[1, 0x3a] = "&";
            this.Key[0, 0x3b] = "45";
            this.Key[1, 0x3b] = "*";
            this.Key[0, 60] = "65";
            this.Key[1, 60] = "(";
            this.Key[0, 0x3d] = "75";
            this.Key[1, 0x3d] = ")";
            this.Key[0, 0x3e] = "85";
            this.Key[1, 0x3e] = "_";
            this.Key[0, 0x3f] = "95";
            this.Key[1, 0x3f] = "-";
            this.Key[0, 0x40] = "06";
            this.Key[1, 0x40] = "+";
            this.Key[0, 0x41] = "16";
            this.Key[1, 0x41] = "=";
            this.Key[0, 0x42] = "26";
            this.Key[1, 0x42] = "|";
            this.Key[0, 0x43] = "36";
            this.Key[1, 0x43] = @"\";
            this.Key[0, 0x44] = "46";
            this.Key[1, 0x44] = "<";
            this.Key[0, 0x45] = "56";
            this.Key[1, 0x45] = ">";
            this.Key[0, 70] = "76";
            this.Key[1, 70] = ",";
            this.Key[0, 0x47] = "86";
            this.Key[1, 0x47] = ".";
            this.Key[0, 0x48] = "96";
            this.Key[1, 0x48] = "?";
            this.Key[0, 0x49] = "07";
            this.Key[1, 0x49] = "/";
            this.Key[0, 0x4a] = "17";
            this.Key[1, 0x4a] = "[";
            this.Key[0, 0x4b] = "27";
            this.Key[1, 0x4b] = "]";
            this.Key[0, 0x4c] = "37";
            this.Key[1, 0x4c] = "{";
            this.Key[0, 0x4d] = "47";
            this.Key[1, 0x4d] = "}";
            this.Key[0, 0x4e] = "57";
            this.Key[1, 0x4e] = ":";
            this.Key[0, 0x4f] = "67";
            this.Key[1, 0x4f] = ";";
            this.Key[0, 80] = "87";
            this.Key[1, 80] = "\"";
            this.Key[0, 0x51] = "97";
            this.Key[1, 0x51] = "'";
            this.Key[0, 0x52] = "08";
            this.Key[1, 0x52] = "`";
            this.Key[0, 0x53] = "18";
            this.Key[1, 0x53] = "~";
        }
    }
}

