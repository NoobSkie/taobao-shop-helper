using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Services;
using Shove._IO;
using SLS.Security;

[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1), WebService(Namespace = "http://tempuri.org/")]
public class CardPassword_Gateway : WebService
{
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

    [WebMethod]
    public DataSet Exchange(int AgentID, string TimeStamp, string Sign, string CardsXml)
    {
        new Log(@"Agent\CardPassword").Write(string.Format("Method=Exchange\tAgentID={0}\tTimeStamp={1}\tSign={2}\tCardsXml={3}", new object[] { AgentID, TimeStamp, Sign, CardsXml }));
        DataSet ds = new DataSet();
        short state = 0;
        DataTable table = _Convert.XMLToDataTable(CardsXml);
        if ((table == null) || (table.Rows.Count < 1))
        {
            this.BuildReturnDataSetForError(-8, "参数不符合规定或者未提供", ref ds);
            return ds;
        }
        if (this.Valid(ref ds, ref state, AgentID, TimeStamp, Sign, new object[] { CardsXml }) >= 0)
        {
            Regex regex = new Regex(@"^[\d]{20}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            CardsXml = "<Cards>";
            CardPassword password = new CardPassword();
            int agentID = -1;
            foreach (DataRow row in table.Rows)
            {
                string input = row["Number"].ToString();
                if (!regex.IsMatch(input))
                {
                    this.BuildReturnDataSetForError(-8, "参数不符合规定或者未提供", ref ds);
                    return ds;
                }
                long num3 = password.GetCardPasswordID(PF.GetCallCert(), input, ref agentID);
                if ((num3 < 0L) || (agentID != AgentID))
                {
                    this.BuildReturnDataSetForError(-5, "卡号不存在", ref ds);
                    return ds;
                }
                CardsXml = CardsXml + "<Card ID=\"" + num3.ToString() + "\" />";
            }
            CardsXml = CardsXml + "</Cards>";
            int returnValue = -1;
            string returnDescription = "";
            this.BuildReturnDataSet(0L, ref ds);
            if (Procedures.P_CardPasswordExchange(ref ds, AgentID, CardsXml, ref returnValue, ref returnDescription) < 0)
            {
                this.BuildReturnDataSetForError(-9999, "未知错误", ref ds);
                return ds;
            }
            if (returnValue < 0)
            {
                this.BuildReturnDataSetForError(returnValue, returnDescription, ref ds);
                return ds;
            }
            DataTable table2 = ds.Tables[1];
            table2.Columns.Add("Number", typeof(string));
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                table2.Rows[i]["Number"] = password.GenNumber(PF.GetCallCert(), AgentID, _Convert.StrToLong(table2.Rows[i]["ID"].ToString(), -1L));
                table2.AcceptChanges();
            }
            table2.Columns.Remove(table2.Columns[0]);
        }
        return ds;
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
    public DataSet GetNumberInformation(int AgentID, string TimeStamp, string Sign, string Number)
    {
        new Log(@"Agent\CardPassword").Write(string.Format("Method=GetNumberInformation\tAgentID={0}\tTimeStamp={1}\tSign={2}\tNumber={3}", new object[] { AgentID, TimeStamp, Sign, Number }));
        DataSet returnDS = new DataSet();
        short state = 0;
        if (this.Valid(ref returnDS, ref state, AgentID, TimeStamp, Sign, new object[] { Number }) >= 0)
        {
            int agentID = -1;
            long num3 = new CardPassword().GetCardPasswordID(PF.GetCallCert(), Number, ref agentID);
            if ((num3 < 0L) || (agentID != AgentID))
            {
                this.BuildReturnDataSetForError(-5, "卡号不存在", ref returnDS);
                return returnDS;
            }
            DataTable table = new Tables.T_CardPasswords().Open("[DateTime], [Money], Period, State", string.Concat(new object[] { "AgentID = ", AgentID, " and [ID] = ", num3.ToString() }), "");
            if (table == null)
            {
                this.BuildReturnDataSetForError(-9999, "未知错误", ref returnDS);
                return returnDS;
            }
            this.BuildReturnDataSet(0L, ref returnDS);
            returnDS.Tables.Add(table);
        }
        return returnDS;
    }

    [WebMethod]
    public DataSet GetNumbers(int AgentID, string TimeStamp, string Sign, string StartTime, string EndTime)
    {
        StartTime = Utility.FilteSqlInfusion(StartTime);
        EndTime = Utility.FilteSqlInfusion(EndTime);
        new Log(@"Agent\CardPassword").Write(string.Format("Method=GetNumbers\tAgentID={0}\tTimeStamp={1}\tSign={2}\tStartTime={3}\tEndTime={4}", new object[] { AgentID, TimeStamp, Sign, StartTime, EndTime }));
        DataSet returnDS = new DataSet();
        short state = 0;
        if (this.Valid(ref returnDS, ref state, AgentID, TimeStamp, Sign, new object[] { StartTime, EndTime }) >= 0)
        {
            DataTable table = new Tables.T_CardPasswords().Open("[ID], [DateTime], [Money], State, Period", "AgentID = " + AgentID.ToString() + " and (DateTime between '" + StartTime + "' and '" + EndTime + "' )", "[ID]");
            if (table == null)
            {
                this.BuildReturnDataSetForError(-9999, "未知错误", ref returnDS);
                return returnDS;
            }
            table.Columns.Add("Number", typeof(string));
            CardPassword password = new CardPassword();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["Number"] = password.GenNumber(PF.GetCallCert(), AgentID, _Convert.StrToLong(table.Rows[i]["ID"].ToString(), -1L));
                table.AcceptChanges();
            }
            table.Columns.Remove(table.Columns[0]);
            this.BuildReturnDataSet(0L, ref returnDS);
            returnDS.Tables.Add(table);
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
    public DataSet SetPeriod(int AgentID, string TimeStamp, string Sign, string Number, string Period)
    {
        new Log(@"Agent\CardPassword").Write(string.Format("Method=SetPeriod\tAgentID={0}\tTimeStamp={1}\tSign={2}\tNumber={3}\tPeriod={4}", new object[] { AgentID, TimeStamp, Sign, Number, Period }));
        DataSet returnDS = new DataSet();
        short state = 0;
        if (this.Valid(ref returnDS, ref state, AgentID, TimeStamp, Sign, new object[] { Number, Period }) >= 0)
        {
            DateTime time;
            try
            {
                time = DateTime.Parse(Period);
            }
            catch
            {
                this.BuildReturnDataSetForError(-8, "参数不符合规定或者未提供", ref returnDS);
                return returnDS;
            }
            long cardPasswordID = 0L;
            int agentID = -1;
            cardPasswordID = new CardPassword().GetCardPasswordID(PF.GetCallCert(), Number, ref agentID);
            if ((cardPasswordID < 0L) || (agentID != AgentID))
            {
                this.BuildReturnDataSetForError(-5, "卡号不存在", ref returnDS);
                return returnDS;
            }
            int returnValue = -1;
            string returnDescription = "";
            if (Procedures.P_CardPasswordSetPeriod(AgentID, cardPasswordID, time, ref returnValue, ref returnDescription) < 0)
            {
                this.BuildReturnDataSetForError(-9999, "未知错误", ref returnDS);
                return returnDS;
            }
            if (returnValue < 0)
            {
                this.BuildReturnDataSetForError(returnValue, returnDescription, ref returnDS);
                return returnDS;
            }
            this.BuildReturnDataSet(0L, ref returnDS);
            returnDS.Tables.Add(new DataTable());
        }
        return returnDS;
    }

    private int Valid(ref DataSet ReturnDS, ref short State, int AgentID, string TimeStamp, string Sign, params object[] Params)
    {
        DateTime time;
        try
        {
            time = DateTime.Parse(TimeStamp);
        }
        catch
        {
            this.BuildReturnDataSetForError(-11, "时间戳格式错误", ref ReturnDS);
            return -4;
        }
        State = 0;
        TimeSpan span = (TimeSpan)(DateTime.Now - time);
        if (Math.Abs(span.TotalSeconds) > 300.0)
        {
            this.BuildReturnDataSetForError(-2, "访问超时", ref ReturnDS);
            return -2;
        }
        Thread.Sleep(200);
        DataTable table = new Tables.T_CardPasswordAgents().Open("", "[ID] = " + AgentID.ToString(), "");
        if (table == null)
        {
            this.BuildReturnDataSetForError(-9999, "未知错误", ref ReturnDS);
            return -9999;
        }
        if (table.Rows.Count < 1)
        {
            this.BuildReturnDataSetForError(-1, "代理商ID错误", ref ReturnDS);
            return -1;
        }
        string str = table.Rows[0]["IPAddressLimit"].ToString();
        if ((str != "") && (("," + str + ",").IndexOf("," + this.GetClientIPAddress() + ",") < 0))
        {
            this.BuildReturnDataSetForError(-3, "IP地址限制", ref ReturnDS);
            return -3;
        }
        string str2 = table.Rows[0]["Key"].ToString();
        string str3 = AgentID.ToString() + TimeStamp;
        foreach (object obj2 in Params)
        {
            str3 = str3 + this.ParamterToString(obj2);
        }
        if (Encrypt.MD5(str3 + str2).ToLower() != Sign.ToLower())
        {
            this.BuildReturnDataSetForError(-4, "签名校验失败", ref ReturnDS);
            return -4;
        }
        State = _Convert.StrToShort(table.Rows[0]["State"].ToString(), 0);
        return 0;
    }
}

