using DAL;
using SLS.Security;
using System;

public class CardPassword
{
    public int Add(int AgentID, int PeriodMonths, double Money, int Count, ref string ReturnDescription)
    {
        int returnValue = -1;
        ReturnDescription = "";
        if (PeriodMonths < 1)
        {
            ReturnDescription = "有效月份数超出范围";
            return -3;
        }
        if (Money < 1.0)
        {
            ReturnDescription = "面值超出范围";
            return -4;
        }
        if (Count < 1)
        {
            ReturnDescription = "生成卡密总数超出范围";
            return -5;
        }
        if (Procedures.P_CardPasswordAdd(AgentID, PeriodMonths, Money, Count, ref returnValue, ref ReturnDescription) < 0)
        {
            ReturnDescription = "数据库读取错误";
            return -6;
        }
        return returnValue;
    }

    public string GenNumber(string CallCert, int AgentID, long CardPasswordID)
    {
        if (CallCert != PF.GetCallCert())
        {
            throw new Exception("Call the CardPassword.GenNumber is request a CallCert.");
        }
        return SLS.Security.CardPassword.GenNumber(CallCert, AgentID, CardPasswordID);
    }

    public long GetCardPasswordID(string CallCert, string Number, ref int AgentID)
    {
        if (CallCert != PF.GetCallCert())
        {
            throw new Exception("Call the CardPassword.GenNumber is request a CallCert.");
        }
        AgentID = -1;
        return SLS.Security.CardPassword.GetCardPasswordID(CallCert, Number, ref AgentID);
    }

    public int Use(string Number, long SiteID, long UserID, ref string ReturnDescription)
    {
        int returnValue = -1;
        int agentID = -1;
        long cardPasswordID = this.GetCardPasswordID(PF.GetCallCert(), Number, ref agentID);
        if ((cardPasswordID < 0L) || (agentID < 0))
        {
            returnValue = 0;
            ReturnDescription = "";
            Procedures.P_CardPasswordTryErrorAdd(UserID, Number, ref returnValue, ref ReturnDescription);
            ReturnDescription = "卡号非法";
            return -1;
        }
        double money = 0.0;
        short state = 0;
        long userID = 0L;
        DateTime now = DateTime.Now;
        DateTime period = DateTime.Now;
        DateTime useDateTime = DateTime.Now;
        returnValue = 0;
        ReturnDescription = "";
        cardPasswordID = this.Valid(agentID, cardPasswordID, ref money, ref now, ref period, ref state, ref userID, ref useDateTime, ref ReturnDescription);
        if (cardPasswordID < 0L)
        {
            returnValue = 0;
            ReturnDescription = "";
            Procedures.P_CardPasswordTryErrorAdd(UserID, Number, ref returnValue, ref ReturnDescription);
            ReturnDescription = "卡号非法";
            return -1;
        }
        if (state == -2)
        {
            ReturnDescription = "此卡号已经停用";
            return -2;
        }
        if ((state == -1) || (period < DateTime.Now))
        {
            ReturnDescription = "此卡号已经过期";
            return -3;
        }
        if (state == 1)
        {
            ReturnDescription = "此卡号已经使用";
            return -4;
        }
        if (state != 0)
        {
            ReturnDescription = "此卡号不能使用";
            return -5;
        }
        ReturnDescription = "";
        if (Procedures.P_CardPasswordUse(agentID, cardPasswordID, Number, SiteID, UserID, ref returnValue, ref ReturnDescription) < 0)
        {
            ReturnDescription = "数据库读取错误";
            return -6;
        }
        if (returnValue < 0)
        {
            return returnValue;
        }
        return returnValue;
    }

    public long Valid(int AgentID, long CardPasswordID, ref double Money, ref DateTime CreateDateTime, ref DateTime Period, ref short State, ref long UserID, ref DateTime UseDateTime, ref string ReturnDescription)
    {
        int returnValue = -1;
        ReturnDescription = "";
        if (Procedures.P_CardPasswordGet(AgentID, CardPasswordID, ref CreateDateTime, ref Period, ref Money, ref State, ref UserID, ref UseDateTime, ref returnValue, ref ReturnDescription) < 0)
        {
            ReturnDescription = "数据库读取错误";
            return -2L;
        }
        if (returnValue < 0)
        {
            return (long)returnValue;
        }
        return CardPasswordID;
    }
}

