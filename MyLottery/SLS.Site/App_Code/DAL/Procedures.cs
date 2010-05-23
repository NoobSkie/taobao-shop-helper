using Shove.Database;
using System;
using System.Data;

namespace SLS.Site.App_Code.DAL
{
    public class Procedures
    {
        public static int P_AcceptUserHongbaoPromotion(long FromUserID, long ToUserID, long UserHongbaoPromotionID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_AcceptUserHongbaoPromotion(ref ds, FromUserID, ToUserID, UserHongbaoPromotionID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_AcceptUserHongbaoPromotion(ref DataSet ds, long FromUserID, long ToUserID, long UserHongbaoPromotionID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_AcceptUserHongbaoPromotion", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("FromUserID", SqlDbType.BigInt, 0, ParameterDirection.Input, FromUserID), new MSSQL.Parameter("ToUserID", SqlDbType.BigInt, 0, ParameterDirection.Input, ToUserID), new MSSQL.Parameter("UserHongbaoPromotionID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserHongbaoPromotionID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_AccountTransfer(long SiteID, long UserID, double Money, long RelatedUserID, string SecurityAnswer, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_AccountTransfer(ref ds, SiteID, UserID, Money, RelatedUserID, SecurityAnswer, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_AccountTransfer(ref DataSet ds, long SiteID, long UserID, double Money, long RelatedUserID, string SecurityAnswer, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_AccountTransfer", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Money", SqlDbType.Money, 0, ParameterDirection.Input, Money), new MSSQL.Parameter("RelatedUserID", SqlDbType.BigInt, 0, ParameterDirection.Input, RelatedUserID), new MSSQL.Parameter("SecurityAnswer", SqlDbType.VarChar, 0, ParameterDirection.Input, SecurityAnswer), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_AccountTransferAccept(long SiteID, long UserID, long TransferID, long RelatedUserID, string SecurityAnswer, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_AccountTransferAccept(ref ds, SiteID, UserID, TransferID, RelatedUserID, SecurityAnswer, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_AccountTransferAccept(ref DataSet ds, long SiteID, long UserID, long TransferID, long RelatedUserID, string SecurityAnswer, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_AccountTransferAccept", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("TransferID", SqlDbType.BigInt, 0, ParameterDirection.Input, TransferID), new MSSQL.Parameter("RelatedUserID", SqlDbType.BigInt, 0, ParameterDirection.Input, RelatedUserID), new MSSQL.Parameter("SecurityAnswer", SqlDbType.VarChar, 0, ParameterDirection.Input, SecurityAnswer), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_AccountTransferQuash(long SiteID, long UserID, long TransferID, long RelatedUserID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_AccountTransferQuash(ref ds, SiteID, UserID, TransferID, RelatedUserID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_AccountTransferQuash(ref DataSet ds, long SiteID, long UserID, long TransferID, long RelatedUserID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_AccountTransferQuash", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("TransferID", SqlDbType.BigInt, 0, ParameterDirection.Input, TransferID), new MSSQL.Parameter("RelatedUserID", SqlDbType.BigInt, 0, ParameterDirection.Input, RelatedUserID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_AddUserToCpsUId(int ID, int Uid, int CpsID, int PID, ref long ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_AddUserToCpsUId(ref ds, ID, Uid, CpsID, PID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_AddUserToCpsUId(ref DataSet ds, int ID, int Uid, int CpsID, int PID, ref long ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_AddUserToCpsUId", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ID", SqlDbType.Int, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("Uid", SqlDbType.Int, 0, ParameterDirection.Input, Uid), new MSSQL.Parameter("CpsID", SqlDbType.Int, 0, ParameterDirection.Input, CpsID), new MSSQL.Parameter("PID", SqlDbType.Int, 0, ParameterDirection.Input, PID), new MSSQL.Parameter("ReturnValue", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt64(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_AdvertisementsEdit(int ID, string Title, string Url, int Order, bool isShow, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_AdvertisementsEdit(ref ds, ID, Title, Url, Order, isShow, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_AdvertisementsEdit(ref DataSet ds, int ID, string Title, string Url, int Order, bool isShow, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_AdvertisementsEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ID", SqlDbType.Int, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Url", SqlDbType.VarChar, 0, ParameterDirection.Input, Url), new MSSQL.Parameter("Order", SqlDbType.Int, 0, ParameterDirection.Input, Order), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_Analysis_3D_Miss(ref int ReturnValue, ref string ReturnDescptrion)
        {
            DataSet ds = null;
            return P_Analysis_3D_Miss(ref ds, ref ReturnValue, ref ReturnDescptrion);
        }

        public static int P_Analysis_3D_Miss(ref DataSet ds, ref int ReturnValue, ref string ReturnDescptrion)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_Analysis_3D_Miss", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescptrion", SqlDbType.NVarChar, 200, ParameterDirection.Output, ReturnDescptrion) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescptrion = Convert.ToString(outputs["ReturnDescptrion"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_Analysis_SHSSL_HotAndCoolAndMiss(ref int ReturnValue, ref string ReturnDescptrion)
        {
            DataSet ds = null;
            return P_Analysis_SHSSL_HotAndCoolAndMiss(ref ds, ref ReturnValue, ref ReturnDescptrion);
        }

        public static int P_Analysis_SHSSL_HotAndCoolAndMiss(ref DataSet ds, ref int ReturnValue, ref string ReturnDescptrion)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_Analysis_SHSSL_HotAndCoolAndMiss", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescptrion", SqlDbType.NVarChar, 200, ParameterDirection.Output, ReturnDescptrion) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescptrion = Convert.ToString(outputs["ReturnDescptrion"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_Analysis_SHSSL_WinUsersList(int LotteryID, ref int ReturnValue, ref string ReturnDescptrion)
        {
            DataSet ds = null;
            return P_Analysis_SHSSL_WinUsersList(ref ds, LotteryID, ref ReturnValue, ref ReturnDescptrion);
        }

        public static int P_Analysis_SHSSL_WinUsersList(ref DataSet ds, int LotteryID, ref int ReturnValue, ref string ReturnDescptrion)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_Analysis_SHSSL_WinUsersList", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescptrion", SqlDbType.NVarChar, 200, ParameterDirection.Output, ReturnDescptrion) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescptrion = Convert.ToString(outputs["ReturnDescptrion"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CalculateScore(ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CalculateScore(ref ds, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CalculateScore(ref DataSet ds, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CalculateScore", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CalculateUserLevel()
        {
            DataSet ds = null;
            return P_CalculateUserLevel(ref ds);
        }

        public static int P_CalculateUserLevel(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_CalculateUserLevel", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_CanExpenseBonus(ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CanExpenseBonus(ref ds, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CanExpenseBonus(ref DataSet ds, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CanExpenseBonus", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CardPasswordAdd(int AgentID, int Period, double Money, int Count, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CardPasswordAdd(ref ds, AgentID, Period, Money, Count, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CardPasswordAdd(ref DataSet ds, int AgentID, int Period, double Money, int Count, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CardPasswordAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("AgentID", SqlDbType.Int, 0, ParameterDirection.Input, AgentID), new MSSQL.Parameter("Period", SqlDbType.Int, 0, ParameterDirection.Input, Period), new MSSQL.Parameter("Money", SqlDbType.Money, 0, ParameterDirection.Input, Money), new MSSQL.Parameter("Count", SqlDbType.Int, 0, ParameterDirection.Input, Count), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CardPasswordAgentAddMoney(long AgentID, double Amount, string Memo, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CardPasswordAgentAddMoney(ref ds, AgentID, Amount, Memo, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CardPasswordAgentAddMoney(ref DataSet ds, long AgentID, double Amount, string Memo, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CardPasswordAgentAddMoney", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("AgentID", SqlDbType.BigInt, 0, ParameterDirection.Input, AgentID), new MSSQL.Parameter("Amount", SqlDbType.Money, 0, ParameterDirection.Input, Amount), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 0, ParameterDirection.Input, Memo), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CardPasswordExchange(int AgentID, string CardsXml, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CardPasswordExchange(ref ds, AgentID, CardsXml, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CardPasswordExchange(ref DataSet ds, int AgentID, string CardsXml, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CardPasswordExchange", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("AgentID", SqlDbType.Int, 0, ParameterDirection.Input, AgentID), new MSSQL.Parameter("CardsXml", SqlDbType.NText, 0, ParameterDirection.Input, CardsXml), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CardPasswordGet(int AgentID, long CardPasswordID, ref DateTime DateTime, ref DateTime Period, ref double Money, ref short State, ref long UserID, ref DateTime UseDateTime, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CardPasswordGet(ref ds, AgentID, CardPasswordID, ref DateTime, ref Period, ref Money, ref State, ref UserID, ref UseDateTime, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CardPasswordGet(ref DataSet ds, int AgentID, long CardPasswordID, ref DateTime DateTime, ref DateTime Period, ref double Money, ref short State, ref long UserID, ref DateTime UseDateTime, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CardPasswordGet", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("AgentID", SqlDbType.Int, 0, ParameterDirection.Input, AgentID), new MSSQL.Parameter("CardPasswordID", SqlDbType.BigInt, 0, ParameterDirection.Input, CardPasswordID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 8, ParameterDirection.Output, (DateTime) DateTime), new MSSQL.Parameter("Period", SqlDbType.DateTime, 8, ParameterDirection.Output, (DateTime) Period), new MSSQL.Parameter("Money", SqlDbType.Money, 8, ParameterDirection.Output, (double) Money), new MSSQL.Parameter("State", SqlDbType.SmallInt, 2, ParameterDirection.Output, (short) State), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) UserID), new MSSQL.Parameter("UseDateTime", SqlDbType.DateTime, 8, ParameterDirection.Output, (DateTime) UseDateTime), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                DateTime = Convert.ToDateTime(outputs["DateTime"]);
            }
            catch
            {
            }
            try
            {
                Period = Convert.ToDateTime(outputs["Period"]);
            }
            catch
            {
            }
            try
            {
                Money = Convert.ToDouble(outputs["Money"]);
            }
            catch
            {
            }
            try
            {
                State = Convert.ToInt16(outputs["State"]);
            }
            catch
            {
            }
            try
            {
                UserID = Convert.ToInt64(outputs["UserID"]);
            }
            catch
            {
            }
            try
            {
                UseDateTime = Convert.ToDateTime(outputs["UseDateTime"]);
            }
            catch
            {
            }
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CardPasswordSetPeriod(int AgentID, long CardPasswordID, DateTime Period, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CardPasswordSetPeriod(ref ds, AgentID, CardPasswordID, Period, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CardPasswordSetPeriod(ref DataSet ds, int AgentID, long CardPasswordID, DateTime Period, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CardPasswordSetPeriod", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("AgentID", SqlDbType.Int, 0, ParameterDirection.Input, AgentID), new MSSQL.Parameter("CardPasswordID", SqlDbType.BigInt, 0, ParameterDirection.Input, CardPasswordID), new MSSQL.Parameter("Period", SqlDbType.DateTime, 0, ParameterDirection.Input, Period), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CardPasswordTryErrorAdd(long UserID, string Number, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CardPasswordTryErrorAdd(ref ds, UserID, Number, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CardPasswordTryErrorAdd(ref DataSet ds, long UserID, string Number, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CardPasswordTryErrorAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Number", SqlDbType.VarChar, 0, ParameterDirection.Input, Number), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CardPasswordTryErrorFreeze(long SiteID, long UserID, ref int Freeze, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CardPasswordTryErrorFreeze(ref ds, SiteID, UserID, ref Freeze, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CardPasswordTryErrorFreeze(ref DataSet ds, long SiteID, long UserID, ref int Freeze, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CardPasswordTryErrorFreeze", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Freeze", SqlDbType.Int, 4, ParameterDirection.Output, (int) Freeze), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                Freeze = Convert.ToInt32(outputs["Freeze"]);
            }
            catch
            {
            }
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CardPasswordUse(int AgentID, long CardPasswordID, string Number, long SiteID, long UserID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CardPasswordUse(ref ds, AgentID, CardPasswordID, Number, SiteID, UserID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CardPasswordUse(ref DataSet ds, int AgentID, long CardPasswordID, string Number, long SiteID, long UserID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CardPasswordUse", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("AgentID", SqlDbType.Int, 0, ParameterDirection.Input, AgentID), new MSSQL.Parameter("CardPasswordID", SqlDbType.BigInt, 0, ParameterDirection.Input, CardPasswordID), new MSSQL.Parameter("Number", SqlDbType.VarChar, 0, ParameterDirection.Input, Number), new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CelebDelete(long SiteID, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CelebDelete(ref ds, SiteID, ID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CelebDelete(ref DataSet ds, long SiteID, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CelebDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CelebEdit(long SiteID, long ID, string Title, string Intro, string Say, string Comment, string Score, long Order, bool isRecommended, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CelebEdit(ref ds, SiteID, ID, Title, Intro, Say, Comment, Score, Order, isRecommended, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CelebEdit(ref DataSet ds, long SiteID, long ID, string Title, string Intro, string Say, string Comment, string Score, long Order, bool isRecommended, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CelebEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Intro", SqlDbType.VarChar, 0, ParameterDirection.Input, Intro), new MSSQL.Parameter("Say", SqlDbType.VarChar, 0, ParameterDirection.Input, Say), new MSSQL.Parameter("Comment", SqlDbType.VarChar, 0, ParameterDirection.Input, Comment), new MSSQL.Parameter("Score", SqlDbType.VarChar, 0, ParameterDirection.Input, Score), new MSSQL.Parameter("Order", SqlDbType.BigInt, 0, ParameterDirection.Input, Order), new MSSQL.Parameter("isRecommended", SqlDbType.Bit, 0, ParameterDirection.Input, isRecommended), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ChasesAdd(long UserID, int LotteryID, int PlayTypeID, int Price, short Type, DateTime StartTime, DateTime EndTime, int IsuseCount, int Multiple, int Nums, short BetType, string LotteryNumber, short StopTypeWhenWin, double StopTypeWhenMoney, double Money, string Title, string ChaseXML, ref int ChaseID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ChasesAdd(ref ds, UserID, LotteryID, PlayTypeID, Price, Type, StartTime, EndTime, IsuseCount, Multiple, Nums, BetType, LotteryNumber, StopTypeWhenWin, StopTypeWhenMoney, Money, Title, ChaseXML, ref ChaseID, ref ReturnDescription);
        }

        public static int P_ChasesAdd(ref DataSet ds, long UserID, int LotteryID, int PlayTypeID, int Price, short Type, DateTime StartTime, DateTime EndTime, int IsuseCount, int Multiple, int Nums, short BetType, string LotteryNumber, short StopTypeWhenWin, double StopTypeWhenMoney, double Money, string Title, string ChaseXML, ref int ChaseID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ChasesAdd", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID), new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, PlayTypeID), new MSSQL.Parameter("Price", SqlDbType.Int, 0, ParameterDirection.Input, Price), new MSSQL.Parameter("Type", SqlDbType.SmallInt, 0, ParameterDirection.Input, Type), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("IsuseCount", SqlDbType.Int, 0, ParameterDirection.Input, IsuseCount), new MSSQL.Parameter("Multiple", SqlDbType.Int, 0, ParameterDirection.Input, Multiple), new MSSQL.Parameter("Nums", SqlDbType.Int, 0, ParameterDirection.Input, Nums), new MSSQL.Parameter("BetType", SqlDbType.SmallInt, 0, ParameterDirection.Input, BetType), new MSSQL.Parameter("LotteryNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, LotteryNumber), new MSSQL.Parameter("StopTypeWhenWin", SqlDbType.SmallInt, 0, ParameterDirection.Input, StopTypeWhenWin), new MSSQL.Parameter("StopTypeWhenMoney", SqlDbType.Money, 0, ParameterDirection.Input, StopTypeWhenMoney), new MSSQL.Parameter("Money", SqlDbType.Money, 0, ParameterDirection.Input, Money), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), 
                new MSSQL.Parameter("ChaseXML", SqlDbType.VarChar, 0, ParameterDirection.Input, ChaseXML), new MSSQL.Parameter("ChaseID", SqlDbType.Int, 4, ParameterDirection.Output, (int) ChaseID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 50, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                ChaseID = Convert.ToInt32(outputs["ChaseID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ChaseStopWhenWin(long SchemeID, double WinMoney, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ChaseStopWhenWin(ref ds, SchemeID, WinMoney, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ChaseStopWhenWin(ref DataSet ds, long SchemeID, double WinMoney, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ChaseStopWhenWin", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("WinMoney", SqlDbType.Money, 0, ParameterDirection.Input, WinMoney), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ChaseTaskStopWhenWin(long SiteID, long SchemeID, double WinMoney, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ChaseTaskStopWhenWin(ref ds, SiteID, SchemeID, WinMoney, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ChaseTaskStopWhenWin(ref DataSet ds, long SiteID, long SchemeID, double WinMoney, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ChaseTaskStopWhenWin", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("WinMoney", SqlDbType.Money, 0, ParameterDirection.Input, WinMoney), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CheckChaseTasks(ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CheckChaseTasks(ref ds, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CheckChaseTasks(ref DataSet ds, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CheckChaseTasks", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ClearSystemLog(long SiteID, long UserID, string IPAddress, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ClearSystemLog(ref ds, SiteID, UserID, IPAddress, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ClearSystemLog(ref DataSet ds, long SiteID, long UserID, string IPAddress, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ClearSystemLog", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("IPAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, IPAddress), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CpsAdd(long SiteID, long OwnerUserID, string Name, string Url, string LogoUrl, double BonusScale, bool ON, string Company, string Address, string PostCode, string ResponsiblePerson, string ContactPerson, string Telephone, string Fax, string Mobile, string Email, string QQ, string ServiceTelephone, string MD5Key, short Type, long ParentID, string DomainName, long OperatorID, long CommendID, ref long ID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CpsAdd(ref ds, SiteID, OwnerUserID, Name, Url, LogoUrl, BonusScale, ON, Company, Address, PostCode, ResponsiblePerson, ContactPerson, Telephone, Fax, Mobile, Email, QQ, ServiceTelephone, MD5Key, Type, ParentID, DomainName, OperatorID, CommendID, ref ID, ref ReturnDescription);
        }

        public static int P_CpsAdd(ref DataSet ds, long SiteID, long OwnerUserID, string Name, string Url, string LogoUrl, double BonusScale, bool ON, string Company, string Address, string PostCode, string ResponsiblePerson, string ContactPerson, string Telephone, string Fax, string Mobile, string Email, string QQ, string ServiceTelephone, string MD5Key, short Type, long ParentID, string DomainName, long OperatorID, long CommendID, ref long ID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CpsAdd", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("OwnerUserID", SqlDbType.BigInt, 0, ParameterDirection.Input, OwnerUserID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, Name), new MSSQL.Parameter("Url", SqlDbType.VarChar, 0, ParameterDirection.Input, Url), new MSSQL.Parameter("LogoUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, LogoUrl), new MSSQL.Parameter("BonusScale", SqlDbType.Float, 0, ParameterDirection.Input, BonusScale), new MSSQL.Parameter("ON", SqlDbType.Bit, 0, ParameterDirection.Input, ON), new MSSQL.Parameter("Company", SqlDbType.VarChar, 0, ParameterDirection.Input, Company), new MSSQL.Parameter("Address", SqlDbType.VarChar, 0, ParameterDirection.Input, Address), new MSSQL.Parameter("PostCode", SqlDbType.VarChar, 0, ParameterDirection.Input, PostCode), new MSSQL.Parameter("ResponsiblePerson", SqlDbType.VarChar, 0, ParameterDirection.Input, ResponsiblePerson), new MSSQL.Parameter("ContactPerson", SqlDbType.VarChar, 0, ParameterDirection.Input, ContactPerson), new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 0, ParameterDirection.Input, Telephone), new MSSQL.Parameter("Fax", SqlDbType.VarChar, 0, ParameterDirection.Input, Fax), new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 0, ParameterDirection.Input, Mobile), new MSSQL.Parameter("Email", SqlDbType.VarChar, 0, ParameterDirection.Input, Email), 
                new MSSQL.Parameter("QQ", SqlDbType.VarChar, 0, ParameterDirection.Input, QQ), new MSSQL.Parameter("ServiceTelephone", SqlDbType.VarChar, 0, ParameterDirection.Input, ServiceTelephone), new MSSQL.Parameter("MD5Key", SqlDbType.VarChar, 0, ParameterDirection.Input, MD5Key), new MSSQL.Parameter("Type", SqlDbType.SmallInt, 0, ParameterDirection.Input, Type), new MSSQL.Parameter("ParentID", SqlDbType.BigInt, 0, ParameterDirection.Input, ParentID), new MSSQL.Parameter("DomainName", SqlDbType.VarChar, 0, ParameterDirection.Input, DomainName), new MSSQL.Parameter("OperatorID", SqlDbType.BigInt, 0, ParameterDirection.Input, OperatorID), new MSSQL.Parameter("CommendID", SqlDbType.BigInt, 0, ParameterDirection.Input, CommendID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) ID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                ID = Convert.ToInt64(outputs["ID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CpsCalculateAllowBonus(int Year, int Month, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CpsCalculateAllowBonus(ref ds, Year, Month, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CpsCalculateAllowBonus(ref DataSet ds, int Year, int Month, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CpsCalculateAllowBonus", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("Year", SqlDbType.Int, 0, ParameterDirection.Input, Year), new MSSQL.Parameter("Month", SqlDbType.Int, 0, ParameterDirection.Input, Month), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CpsCalculateBonus(ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CpsCalculateBonus(ref ds, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CpsCalculateBonus(ref DataSet ds, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CpsCalculateBonus", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CpsDistill(long SiteID, long UserID, double Money, double FormalitiesFees, string BankUserName, string BankName, string BankCardNumber, string Memo, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CpsDistill(ref ds, SiteID, UserID, Money, FormalitiesFees, BankUserName, BankName, BankCardNumber, Memo, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CpsDistill(ref DataSet ds, long SiteID, long UserID, double Money, double FormalitiesFees, string BankUserName, string BankName, string BankCardNumber, string Memo, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CpsDistill", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Money", SqlDbType.Money, 0, ParameterDirection.Input, Money), new MSSQL.Parameter("FormalitiesFees", SqlDbType.Money, 0, ParameterDirection.Input, FormalitiesFees), new MSSQL.Parameter("BankUserName", SqlDbType.VarChar, 0, ParameterDirection.Input, BankUserName), new MSSQL.Parameter("BankName", SqlDbType.VarChar, 0, ParameterDirection.Input, BankName), new MSSQL.Parameter("BankCardNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, BankCardNumber), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 0, ParameterDirection.Input, Memo), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CpsDistillAccept(long SiteID, long UserID, long DistillID, string PayName, string PayBank, string PayCardNumber, string Memo, long HandleOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CpsDistillAccept(ref ds, SiteID, UserID, DistillID, PayName, PayBank, PayCardNumber, Memo, HandleOperatorID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CpsDistillAccept(ref DataSet ds, long SiteID, long UserID, long DistillID, string PayName, string PayBank, string PayCardNumber, string Memo, long HandleOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CpsDistillAccept", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("DistillID", SqlDbType.BigInt, 0, ParameterDirection.Input, DistillID), new MSSQL.Parameter("PayName", SqlDbType.VarChar, 0, ParameterDirection.Input, PayName), new MSSQL.Parameter("PayBank", SqlDbType.VarChar, 0, ParameterDirection.Input, PayBank), new MSSQL.Parameter("PayCardNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, PayCardNumber), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 0, ParameterDirection.Input, Memo), new MSSQL.Parameter("HandleOperatorID", SqlDbType.BigInt, 0, ParameterDirection.Input, HandleOperatorID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CpsDistillNoAccept(long SiteID, long UserID, long DistillID, string Memo, long HandleOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CpsDistillNoAccept(ref ds, SiteID, UserID, DistillID, Memo, HandleOperatorID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CpsDistillNoAccept(ref DataSet ds, long SiteID, long UserID, long DistillID, string Memo, long HandleOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CpsDistillNoAccept", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("DistillID", SqlDbType.BigInt, 0, ParameterDirection.Input, DistillID), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 0, ParameterDirection.Input, Memo), new MSSQL.Parameter("HandleOperatorID", SqlDbType.BigInt, 0, ParameterDirection.Input, HandleOperatorID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CpsDistillQuash(long SiteID, long UserID, long DistillID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CpsDistillQuash(ref ds, SiteID, UserID, DistillID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CpsDistillQuash(ref DataSet ds, long SiteID, long UserID, long DistillID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CpsDistillQuash", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("DistillID", SqlDbType.BigInt, 0, ParameterDirection.Input, DistillID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CpsEdit(long SiteID, long CpsID, string UrlName, string Url, string LogoUrl, double BonusScale, bool ON, string Company, string Address, string PostCode, string ResponsiblePerson, string ContactPerson, string Telephone, string Fax, string Mobile, string Email, string QQ, string ServiceTelephone, string MD5Key, short Type, string DomainName, bool IsShow, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CpsEdit(ref ds, SiteID, CpsID, UrlName, Url, LogoUrl, BonusScale, ON, Company, Address, PostCode, ResponsiblePerson, ContactPerson, Telephone, Fax, Mobile, Email, QQ, ServiceTelephone, MD5Key, Type, DomainName, IsShow, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CpsEdit(ref DataSet ds, long SiteID, long CpsID, string UrlName, string Url, string LogoUrl, double BonusScale, bool ON, string Company, string Address, string PostCode, string ResponsiblePerson, string ContactPerson, string Telephone, string Fax, string Mobile, string Email, string QQ, string ServiceTelephone, string MD5Key, short Type, string DomainName, bool IsShow, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CpsEdit", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 0, ParameterDirection.Input, CpsID), new MSSQL.Parameter("UrlName", SqlDbType.VarChar, 0, ParameterDirection.Input, UrlName), new MSSQL.Parameter("Url", SqlDbType.VarChar, 0, ParameterDirection.Input, Url), new MSSQL.Parameter("LogoUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, LogoUrl), new MSSQL.Parameter("BonusScale", SqlDbType.Float, 0, ParameterDirection.Input, BonusScale), new MSSQL.Parameter("ON", SqlDbType.Bit, 0, ParameterDirection.Input, ON), new MSSQL.Parameter("Company", SqlDbType.VarChar, 0, ParameterDirection.Input, Company), new MSSQL.Parameter("Address", SqlDbType.VarChar, 0, ParameterDirection.Input, Address), new MSSQL.Parameter("PostCode", SqlDbType.VarChar, 0, ParameterDirection.Input, PostCode), new MSSQL.Parameter("ResponsiblePerson", SqlDbType.VarChar, 0, ParameterDirection.Input, ResponsiblePerson), new MSSQL.Parameter("ContactPerson", SqlDbType.VarChar, 0, ParameterDirection.Input, ContactPerson), new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 0, ParameterDirection.Input, Telephone), new MSSQL.Parameter("Fax", SqlDbType.VarChar, 0, ParameterDirection.Input, Fax), new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 0, ParameterDirection.Input, Mobile), new MSSQL.Parameter("Email", SqlDbType.VarChar, 0, ParameterDirection.Input, Email), 
                new MSSQL.Parameter("QQ", SqlDbType.VarChar, 0, ParameterDirection.Input, QQ), new MSSQL.Parameter("ServiceTelephone", SqlDbType.VarChar, 0, ParameterDirection.Input, ServiceTelephone), new MSSQL.Parameter("MD5Key", SqlDbType.VarChar, 0, ParameterDirection.Input, MD5Key), new MSSQL.Parameter("Type", SqlDbType.SmallInt, 0, ParameterDirection.Input, Type), new MSSQL.Parameter("DomainName", SqlDbType.VarChar, 0, ParameterDirection.Input, DomainName), new MSSQL.Parameter("IsShow", SqlDbType.Bit, 0, ParameterDirection.Input, IsShow), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CpsGetCommendMemberBuyDetail(long SiteID, long CommenderID, long MemberID, DateTime FromTime, DateTime ToTime, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CpsGetCommendMemberBuyDetail(ref ds, SiteID, CommenderID, MemberID, FromTime, ToTime, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CpsGetCommendMemberBuyDetail(ref DataSet ds, long SiteID, long CommenderID, long MemberID, DateTime FromTime, DateTime ToTime, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CpsGetCommendMemberBuyDetail", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("CommenderID", SqlDbType.BigInt, 0, ParameterDirection.Input, CommenderID), new MSSQL.Parameter("MemberID", SqlDbType.BigInt, 0, ParameterDirection.Input, MemberID), new MSSQL.Parameter("FromTime", SqlDbType.DateTime, 0, ParameterDirection.Input, FromTime), new MSSQL.Parameter("ToTime", SqlDbType.DateTime, 0, ParameterDirection.Input, ToTime), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CpsGetCommendMemberList(long CommmenderID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CpsGetCommendMemberList(ref ds, CommmenderID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CpsGetCommendMemberList(ref DataSet ds, long CommmenderID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CpsGetCommendMemberList", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("CommmenderID", SqlDbType.BigInt, 0, ParameterDirection.Input, CommmenderID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CpsGetCommendSiteBuyDetail(long SiteID, long CommenderID, long CpsID, long MemberID, DateTime FromTime, DateTime ToTime, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CpsGetCommendSiteBuyDetail(ref ds, SiteID, CommenderID, CpsID, MemberID, FromTime, ToTime, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CpsGetCommendSiteBuyDetail(ref DataSet ds, long SiteID, long CommenderID, long CpsID, long MemberID, DateTime FromTime, DateTime ToTime, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CpsGetCommendSiteBuyDetail", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("CommenderID", SqlDbType.BigInt, 0, ParameterDirection.Input, CommenderID), new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 0, ParameterDirection.Input, CpsID), new MSSQL.Parameter("MemberID", SqlDbType.BigInt, 0, ParameterDirection.Input, MemberID), new MSSQL.Parameter("FromTime", SqlDbType.DateTime, 0, ParameterDirection.Input, FromTime), new MSSQL.Parameter("ToTime", SqlDbType.DateTime, 0, ParameterDirection.Input, ToTime), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CpsMemRecommendWebsiteList(long userid, long siteid, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CpsMemRecommendWebsiteList(ref ds, userid, siteid, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CpsMemRecommendWebsiteList(ref DataSet ds, long userid, long siteid, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CpsMemRecommendWebsiteList", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("userid", SqlDbType.BigInt, 0, ParameterDirection.Input, userid), new MSSQL.Parameter("siteid", SqlDbType.BigInt, 0, ParameterDirection.Input, siteid), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CpsPromoterList(long SiteID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CpsPromoterList(ref ds, SiteID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CpsPromoterList(ref DataSet ds, long SiteID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CpsPromoterList", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CpsTry(long SiteID, long UserID, string Content, string Name, string Url, string LogoUrl, string Company, string Address, string PostCode, string ResponsiblePerson, string ContactPerson, string Telephone, string Fax, string Mobile, string Email, string QQ, string ServiceTelephone, string MD5Key, short Type, string DomainName, long ParentID, double BonusScale, long CommendID, ref long ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CpsTry(ref ds, SiteID, UserID, Content, Name, Url, LogoUrl, Company, Address, PostCode, ResponsiblePerson, ContactPerson, Telephone, Fax, Mobile, Email, QQ, ServiceTelephone, MD5Key, Type, DomainName, ParentID, BonusScale, CommendID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CpsTry(ref DataSet ds, long SiteID, long UserID, string Content, string Name, string Url, string LogoUrl, string Company, string Address, string PostCode, string ResponsiblePerson, string ContactPerson, string Telephone, string Fax, string Mobile, string Email, string QQ, string ServiceTelephone, string MD5Key, short Type, string DomainName, long ParentID, double BonusScale, long CommendID, ref long ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CpsTry", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, Name), new MSSQL.Parameter("Url", SqlDbType.VarChar, 0, ParameterDirection.Input, Url), new MSSQL.Parameter("LogoUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, LogoUrl), new MSSQL.Parameter("Company", SqlDbType.VarChar, 0, ParameterDirection.Input, Company), new MSSQL.Parameter("Address", SqlDbType.VarChar, 0, ParameterDirection.Input, Address), new MSSQL.Parameter("PostCode", SqlDbType.VarChar, 0, ParameterDirection.Input, PostCode), new MSSQL.Parameter("ResponsiblePerson", SqlDbType.VarChar, 0, ParameterDirection.Input, ResponsiblePerson), new MSSQL.Parameter("ContactPerson", SqlDbType.VarChar, 0, ParameterDirection.Input, ContactPerson), new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 0, ParameterDirection.Input, Telephone), new MSSQL.Parameter("Fax", SqlDbType.VarChar, 0, ParameterDirection.Input, Fax), new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 0, ParameterDirection.Input, Mobile), new MSSQL.Parameter("Email", SqlDbType.VarChar, 0, ParameterDirection.Input, Email), new MSSQL.Parameter("QQ", SqlDbType.VarChar, 0, ParameterDirection.Input, QQ), 
                new MSSQL.Parameter("ServiceTelephone", SqlDbType.VarChar, 0, ParameterDirection.Input, ServiceTelephone), new MSSQL.Parameter("MD5Key", SqlDbType.VarChar, 0, ParameterDirection.Input, MD5Key), new MSSQL.Parameter("Type", SqlDbType.SmallInt, 0, ParameterDirection.Input, Type), new MSSQL.Parameter("DomainName", SqlDbType.VarChar, 0, ParameterDirection.Input, DomainName), new MSSQL.Parameter("ParentID", SqlDbType.BigInt, 0, ParameterDirection.Input, ParentID), new MSSQL.Parameter("BonusScale", SqlDbType.Float, 0, ParameterDirection.Input, BonusScale), new MSSQL.Parameter("CommendID", SqlDbType.BigInt, 0, ParameterDirection.Input, CommendID), new MSSQL.Parameter("ReturnValue", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                ReturnValue = Convert.ToInt64(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CpsTryHandle(long SiteID, long TryID, long OperatorID, short HandleResult, double BonusScale, bool ON, ref long CpsID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CpsTryHandle(ref ds, SiteID, TryID, OperatorID, HandleResult, BonusScale, ON, ref CpsID, ref ReturnDescription);
        }

        public static int P_CpsTryHandle(ref DataSet ds, long SiteID, long TryID, long OperatorID, short HandleResult, double BonusScale, bool ON, ref long CpsID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CpsTryHandle", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("TryID", SqlDbType.BigInt, 0, ParameterDirection.Input, TryID), new MSSQL.Parameter("OperatorID", SqlDbType.BigInt, 0, ParameterDirection.Input, OperatorID), new MSSQL.Parameter("HandleResult", SqlDbType.SmallInt, 0, ParameterDirection.Input, HandleResult), new MSSQL.Parameter("BonusScale", SqlDbType.Float, 0, ParameterDirection.Input, BonusScale), new MSSQL.Parameter("ON", SqlDbType.Bit, 0, ParameterDirection.Input, ON), new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) CpsID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                CpsID = Convert.ToInt64(outputs["CpsID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CustomFollowSchemesAdd(long SiteID, long UserID, long FollowSchemeID, double MoneyStart, double MoneyEnd, int BuyShareStart, int BuyShareEnd, short Type, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CustomFollowSchemesAdd(ref ds, SiteID, UserID, FollowSchemeID, MoneyStart, MoneyEnd, BuyShareStart, BuyShareEnd, Type, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CustomFollowSchemesAdd(ref DataSet ds, long SiteID, long UserID, long FollowSchemeID, double MoneyStart, double MoneyEnd, int BuyShareStart, int BuyShareEnd, short Type, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CustomFollowSchemesAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("FollowSchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, FollowSchemeID), new MSSQL.Parameter("MoneyStart", SqlDbType.Money, 0, ParameterDirection.Input, MoneyStart), new MSSQL.Parameter("MoneyEnd", SqlDbType.Money, 0, ParameterDirection.Input, MoneyEnd), new MSSQL.Parameter("BuyShareStart", SqlDbType.Int, 0, ParameterDirection.Input, BuyShareStart), new MSSQL.Parameter("BuyShareEnd", SqlDbType.Int, 0, ParameterDirection.Input, BuyShareEnd), new MSSQL.Parameter("Type", SqlDbType.SmallInt, 0, ParameterDirection.Input, Type), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_CustomFollowSchemesDelete(long SiteID, long UserID, long FollowSchemeID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_CustomFollowSchemesDelete(ref ds, SiteID, UserID, FollowSchemeID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_CustomFollowSchemesDelete(ref DataSet ds, long SiteID, long UserID, long FollowSchemeID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_CustomFollowSchemesDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("FollowSchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, FollowSchemeID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_Distill(long SiteID, long UserID, int DistillType, double Money, double FormalitiesFees, string BankUserName, string BankName, string BankCardNumber, string AlipayID, string AlipayName, string Memo, bool IsCps, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_Distill(ref ds, SiteID, UserID, DistillType, Money, FormalitiesFees, BankUserName, BankName, BankCardNumber, AlipayID, AlipayName, Memo, IsCps, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_Distill(ref DataSet ds, long SiteID, long UserID, int DistillType, double Money, double FormalitiesFees, string BankUserName, string BankName, string BankCardNumber, string AlipayID, string AlipayName, string Memo, bool IsCps, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_Distill", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("DistillType", SqlDbType.Int, 0, ParameterDirection.Input, DistillType), new MSSQL.Parameter("Money", SqlDbType.Money, 0, ParameterDirection.Input, Money), new MSSQL.Parameter("FormalitiesFees", SqlDbType.Money, 0, ParameterDirection.Input, FormalitiesFees), new MSSQL.Parameter("BankUserName", SqlDbType.VarChar, 0, ParameterDirection.Input, BankUserName), new MSSQL.Parameter("BankName", SqlDbType.VarChar, 0, ParameterDirection.Input, BankName), new MSSQL.Parameter("BankCardNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, BankCardNumber), new MSSQL.Parameter("AlipayID", SqlDbType.VarChar, 0, ParameterDirection.Input, AlipayID), new MSSQL.Parameter("AlipayName", SqlDbType.VarChar, 0, ParameterDirection.Input, AlipayName), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 0, ParameterDirection.Input, Memo), new MSSQL.Parameter("IsCps", SqlDbType.Bit, 0, ParameterDirection.Input, IsCps), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_DistillAccept(long SiteID, long UserID, long DistillID, string PayName, string PayBank, string PayCardNumber, string AlipayID, string AlipayName, string Memo, long HandleOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_DistillAccept(ref ds, SiteID, UserID, DistillID, PayName, PayBank, PayCardNumber, AlipayID, AlipayName, Memo, HandleOperatorID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_DistillAccept(ref DataSet ds, long SiteID, long UserID, long DistillID, string PayName, string PayBank, string PayCardNumber, string AlipayID, string AlipayName, string Memo, long HandleOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_DistillAccept", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("DistillID", SqlDbType.BigInt, 0, ParameterDirection.Input, DistillID), new MSSQL.Parameter("PayName", SqlDbType.VarChar, 0, ParameterDirection.Input, PayName), new MSSQL.Parameter("PayBank", SqlDbType.VarChar, 0, ParameterDirection.Input, PayBank), new MSSQL.Parameter("PayCardNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, PayCardNumber), new MSSQL.Parameter("AlipayID", SqlDbType.VarChar, 0, ParameterDirection.Input, AlipayID), new MSSQL.Parameter("AlipayName", SqlDbType.VarChar, 0, ParameterDirection.Input, AlipayName), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 0, ParameterDirection.Input, Memo), new MSSQL.Parameter("HandleOperatorID", SqlDbType.BigInt, 0, ParameterDirection.Input, HandleOperatorID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_DistillNoAccept(long SiteID, long UserID, long DistillID, string Memo, long HandleOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_DistillNoAccept(ref ds, SiteID, UserID, DistillID, Memo, HandleOperatorID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_DistillNoAccept(ref DataSet ds, long SiteID, long UserID, long DistillID, string Memo, long HandleOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_DistillNoAccept", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("DistillID", SqlDbType.BigInt, 0, ParameterDirection.Input, DistillID), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 0, ParameterDirection.Input, Memo), new MSSQL.Parameter("HandleOperatorID", SqlDbType.BigInt, 0, ParameterDirection.Input, HandleOperatorID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_DistillPaySuccess(long SiteID, long UserID, long DistillID, string Memo, long HandleOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_DistillPaySuccess(ref ds, SiteID, UserID, DistillID, Memo, HandleOperatorID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_DistillPaySuccess(ref DataSet ds, long SiteID, long UserID, long DistillID, string Memo, long HandleOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_DistillPaySuccess", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("DistillID", SqlDbType.BigInt, 0, ParameterDirection.Input, DistillID), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 0, ParameterDirection.Input, Memo), new MSSQL.Parameter("HandleOperatorID", SqlDbType.BigInt, 0, ParameterDirection.Input, HandleOperatorID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_DistillQuash(long SiteID, long UserID, long DistillID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_DistillQuash(ref ds, SiteID, UserID, DistillID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_DistillQuash(ref DataSet ds, long SiteID, long UserID, long DistillID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_DistillQuash", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("DistillID", SqlDbType.BigInt, 0, ParameterDirection.Input, DistillID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_DownloadAdd(long SiteID, DateTime DateTime, string Title, string FileUrl, bool isShow, ref long NewDownloadID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_DownloadAdd(ref ds, SiteID, DateTime, Title, FileUrl, isShow, ref NewDownloadID, ref ReturnDescription);
        }

        public static int P_DownloadAdd(ref DataSet ds, long SiteID, DateTime DateTime, string Title, string FileUrl, bool isShow, ref long NewDownloadID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_DownloadAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("FileUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, FileUrl), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("NewDownloadID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewDownloadID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                NewDownloadID = Convert.ToInt64(outputs["NewDownloadID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_DownloadDelete(long SiteID, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_DownloadDelete(ref ds, SiteID, ID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_DownloadDelete(ref DataSet ds, long SiteID, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_DownloadDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_DownloadEdit(long SiteID, long ID, DateTime DateTime, string Title, string FileUrl, bool isShow, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_DownloadEdit(ref ds, SiteID, ID, DateTime, Title, FileUrl, isShow, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_DownloadEdit(ref DataSet ds, long SiteID, long ID, DateTime DateTime, string Title, string FileUrl, bool isShow, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_DownloadEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("FileUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, FileUrl), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ElectronTicketAgentAddMoney(long AgentID, double Amount, string Memo, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ElectronTicketAgentAddMoney(ref ds, AgentID, Amount, Memo, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ElectronTicketAgentAddMoney(ref DataSet ds, long AgentID, double Amount, string Memo, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ElectronTicketAgentAddMoney", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("AgentID", SqlDbType.BigInt, 0, ParameterDirection.Input, AgentID), new MSSQL.Parameter("Amount", SqlDbType.Money, 0, ParameterDirection.Input, Amount), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 0, ParameterDirection.Input, Memo), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ElectronTicketAgentSchemeAdd(long AgentID, string SchemeNumber, int LotteryID, int PlayTypeID, long IsuseID, string LotteryNumber, double Amount, int Multiple, int Share, string InitiateName, string InitiateAlipayName, string InitiateAlipayID, string InitiateRealityName, string InitiateIDCard, string InitiateTelephone, string InitiateMobile, string InitiateEmail, double InitiateBonusScale, double InitiateBonusLimitLower, double InitiateBonusLimitUpper, string DetailXML, ref long SchemeID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ElectronTicketAgentSchemeAdd(ref ds, AgentID, SchemeNumber, LotteryID, PlayTypeID, IsuseID, LotteryNumber, Amount, Multiple, Share, InitiateName, InitiateAlipayName, InitiateAlipayID, InitiateRealityName, InitiateIDCard, InitiateTelephone, InitiateMobile, InitiateEmail, InitiateBonusScale, InitiateBonusLimitLower, InitiateBonusLimitUpper, DetailXML, ref SchemeID, ref ReturnDescription);
        }

        public static int P_ElectronTicketAgentSchemeAdd(ref DataSet ds, long AgentID, string SchemeNumber, int LotteryID, int PlayTypeID, long IsuseID, string LotteryNumber, double Amount, int Multiple, int Share, string InitiateName, string InitiateAlipayName, string InitiateAlipayID, string InitiateRealityName, string InitiateIDCard, string InitiateTelephone, string InitiateMobile, string InitiateEmail, double InitiateBonusScale, double InitiateBonusLimitLower, double InitiateBonusLimitUpper, string DetailXML, ref long SchemeID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ElectronTicketAgentSchemeAdd", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("AgentID", SqlDbType.BigInt, 0, ParameterDirection.Input, AgentID), new MSSQL.Parameter("SchemeNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, SchemeNumber), new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID), new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, PlayTypeID), new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID), new MSSQL.Parameter("LotteryNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, LotteryNumber), new MSSQL.Parameter("Amount", SqlDbType.Money, 0, ParameterDirection.Input, Amount), new MSSQL.Parameter("Multiple", SqlDbType.Int, 0, ParameterDirection.Input, Multiple), new MSSQL.Parameter("Share", SqlDbType.Int, 0, ParameterDirection.Input, Share), new MSSQL.Parameter("InitiateName", SqlDbType.VarChar, 0, ParameterDirection.Input, InitiateName), new MSSQL.Parameter("InitiateAlipayName", SqlDbType.VarChar, 0, ParameterDirection.Input, InitiateAlipayName), new MSSQL.Parameter("InitiateAlipayID", SqlDbType.VarChar, 0, ParameterDirection.Input, InitiateAlipayID), new MSSQL.Parameter("InitiateRealityName", SqlDbType.VarChar, 0, ParameterDirection.Input, InitiateRealityName), new MSSQL.Parameter("InitiateIDCard", SqlDbType.VarChar, 0, ParameterDirection.Input, InitiateIDCard), new MSSQL.Parameter("InitiateTelephone", SqlDbType.VarChar, 0, ParameterDirection.Input, InitiateTelephone), new MSSQL.Parameter("InitiateMobile", SqlDbType.VarChar, 0, ParameterDirection.Input, InitiateMobile), 
                new MSSQL.Parameter("InitiateEmail", SqlDbType.VarChar, 0, ParameterDirection.Input, InitiateEmail), new MSSQL.Parameter("InitiateBonusScale", SqlDbType.Float, 0, ParameterDirection.Input, InitiateBonusScale), new MSSQL.Parameter("InitiateBonusLimitLower", SqlDbType.Money, 0, ParameterDirection.Input, InitiateBonusLimitLower), new MSSQL.Parameter("InitiateBonusLimitUpper", SqlDbType.Money, 0, ParameterDirection.Input, InitiateBonusLimitUpper), new MSSQL.Parameter("DetailXML", SqlDbType.NText, 0, ParameterDirection.Input, DetailXML), new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) SchemeID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                SchemeID = Convert.ToInt64(outputs["SchemeID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ElectronTicketAgentSchemeQuash(long IsuseID, ref int ReturnValue, ref string ReturnDescptrion)
        {
            DataSet ds = null;
            return P_ElectronTicketAgentSchemeQuash(ref ds, IsuseID, ref ReturnValue, ref ReturnDescptrion);
        }

        public static int P_ElectronTicketAgentSchemeQuash(ref DataSet ds, long IsuseID, ref int ReturnValue, ref string ReturnDescptrion)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ElectronTicketAgentSchemeQuash", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescptrion", SqlDbType.NVarChar, 200, ParameterDirection.Output, ReturnDescptrion) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescptrion = Convert.ToString(outputs["ReturnDescptrion"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ElectronTicketAgentSchemeSendToCenterAdd(long SchemeID, int PlayTypeID, string AgrentNo, string TicketXML, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ElectronTicketAgentSchemeSendToCenterAdd(ref ds, SchemeID, PlayTypeID, AgrentNo, TicketXML, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ElectronTicketAgentSchemeSendToCenterAdd(ref DataSet ds, long SchemeID, int PlayTypeID, string AgrentNo, string TicketXML, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ElectronTicketAgentSchemeSendToCenterAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, PlayTypeID), new MSSQL.Parameter("AgrentNo", SqlDbType.NVarChar, 0, ParameterDirection.Input, AgrentNo), new MSSQL.Parameter("TicketXML", SqlDbType.NText, 0, ParameterDirection.Input, TicketXML), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ElectronTicketAgentSchemeSendToCenterAdd_Single(long SchemeID, int PlayTypeID, double Money, int Multiple, string Ticket, bool isFirstWrite, string AgrentNo, ref long ID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ElectronTicketAgentSchemeSendToCenterAdd_Single(ref ds, SchemeID, PlayTypeID, Money, Multiple, Ticket, isFirstWrite, AgrentNo, ref ID, ref ReturnDescription);
        }

        public static int P_ElectronTicketAgentSchemeSendToCenterAdd_Single(ref DataSet ds, long SchemeID, int PlayTypeID, double Money, int Multiple, string Ticket, bool isFirstWrite, string AgrentNo, ref long ID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ElectronTicketAgentSchemeSendToCenterAdd_Single", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, PlayTypeID), new MSSQL.Parameter("Money", SqlDbType.Money, 0, ParameterDirection.Input, Money), new MSSQL.Parameter("Multiple", SqlDbType.Int, 0, ParameterDirection.Input, Multiple), new MSSQL.Parameter("Ticket", SqlDbType.VarChar, 0, ParameterDirection.Input, Ticket), new MSSQL.Parameter("isFirstWrite", SqlDbType.Bit, 0, ParameterDirection.Input, isFirstWrite), new MSSQL.Parameter("AgrentNo", SqlDbType.VarChar, 0, ParameterDirection.Input, AgrentNo), new MSSQL.Parameter("ID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) ID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ID = Convert.ToInt64(outputs["ID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ElectronTicketAgentSchemesSendToCenterHandleUniteAnte(long SchemeID, DateTime DealTime, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ElectronTicketAgentSchemesSendToCenterHandleUniteAnte(ref ds, SchemeID, DealTime, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ElectronTicketAgentSchemesSendToCenterHandleUniteAnte(ref DataSet ds, long SchemeID, DateTime DealTime, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ElectronTicketAgentSchemesSendToCenterHandleUniteAnte", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("DealTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DealTime), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ElectronTicketWin(long IsuseID, string BonusXML, string AgentBonusXML, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ElectronTicketWin(ref ds, IsuseID, BonusXML, AgentBonusXML, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ElectronTicketWin(ref DataSet ds, long IsuseID, string BonusXML, string AgentBonusXML, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ElectronTicketWin", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID), new MSSQL.Parameter("BonusXML", SqlDbType.NText, 0, ParameterDirection.Input, BonusXML), new MSSQL.Parameter("AgentBonusXML", SqlDbType.NText, 0, ParameterDirection.Input, AgentBonusXML), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_EnterSchemeChatRoom(long SiteID, long UserID, long SchemeID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_EnterSchemeChatRoom(ref ds, SiteID, UserID, SchemeID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_EnterSchemeChatRoom(ref DataSet ds, long SiteID, long UserID, long SchemeID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_EnterSchemeChatRoom", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ExecChases(ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ExecChases(ref ds, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ExecChases(ref DataSet ds, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ExecChases", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ExecChaseTaskDetail(long SiteID, long ChaseTaskDetailID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ExecChaseTaskDetail(ref ds, SiteID, ChaseTaskDetailID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ExecChaseTaskDetail(ref DataSet ds, long SiteID, long ChaseTaskDetailID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ExecChaseTaskDetail", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ChaseTaskDetailID", SqlDbType.BigInt, 0, ParameterDirection.Input, ChaseTaskDetailID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ExecChaseTasks(ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ExecChaseTasks(ref ds, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ExecChaseTasks(ref DataSet ds, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ExecChaseTasks", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ExpertsCommendAdd(long SiteID, long ExpertsID, DateTime DateTime, long IsuseID, string Title, string Content, string Number, double Price, ref long NewExpertsCommendID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ExpertsCommendAdd(ref ds, SiteID, ExpertsID, DateTime, IsuseID, Title, Content, Number, Price, ref NewExpertsCommendID, ref ReturnDescription);
        }

        public static int P_ExpertsCommendAdd(ref DataSet ds, long SiteID, long ExpertsID, DateTime DateTime, long IsuseID, string Title, string Content, string Number, double Price, ref long NewExpertsCommendID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ExpertsCommendAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ExpertsID", SqlDbType.BigInt, 0, ParameterDirection.Input, ExpertsID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("Number", SqlDbType.VarChar, 0, ParameterDirection.Input, Number), new MSSQL.Parameter("Price", SqlDbType.Money, 0, ParameterDirection.Input, Price), new MSSQL.Parameter("NewExpertsCommendID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewExpertsCommendID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                NewExpertsCommendID = Convert.ToInt64(outputs["NewExpertsCommendID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ExpertsCommendDelete(long SiteID, long ExpertsCommendID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ExpertsCommendDelete(ref ds, SiteID, ExpertsCommendID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ExpertsCommendDelete(ref DataSet ds, long SiteID, long ExpertsCommendID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ExpertsCommendDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ExpertsCommendID", SqlDbType.BigInt, 0, ParameterDirection.Input, ExpertsCommendID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ExpertsCommendEdit(long SiteID, long ExpertsCommendID, DateTime DateTime, long IsuseID, string Title, string Content, string Number, double Price, double WinMoney, bool isCommend, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ExpertsCommendEdit(ref ds, SiteID, ExpertsCommendID, DateTime, IsuseID, Title, Content, Number, Price, WinMoney, isCommend, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ExpertsCommendEdit(ref DataSet ds, long SiteID, long ExpertsCommendID, DateTime DateTime, long IsuseID, string Title, string Content, string Number, double Price, double WinMoney, bool isCommend, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ExpertsCommendEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ExpertsCommendID", SqlDbType.BigInt, 0, ParameterDirection.Input, ExpertsCommendID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("Number", SqlDbType.VarChar, 0, ParameterDirection.Input, Number), new MSSQL.Parameter("Price", SqlDbType.Money, 0, ParameterDirection.Input, Price), new MSSQL.Parameter("WinMoney", SqlDbType.Money, 0, ParameterDirection.Input, WinMoney), new MSSQL.Parameter("isCommend", SqlDbType.Bit, 0, ParameterDirection.Input, isCommend), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ExpertsCommendRead(long SiteID, long ExpertsCommendID, long UserID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ExpertsCommendRead(ref ds, SiteID, ExpertsCommendID, UserID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ExpertsCommendRead(ref DataSet ds, long SiteID, long ExpertsCommendID, long UserID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ExpertsCommendRead", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ExpertsCommendID", SqlDbType.BigInt, 0, ParameterDirection.Input, ExpertsCommendID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ExpertsDelete(long SiteID, long ExpertsID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ExpertsDelete(ref ds, SiteID, ExpertsID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ExpertsDelete(ref DataSet ds, long SiteID, long ExpertsID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ExpertsDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ExpertsID", SqlDbType.BigInt, 0, ParameterDirection.Input, ExpertsID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ExpertsEdit(long SiteID, long ExpertsID, string Description, double MaxPrice, double BonusScale, bool ON, bool isCommend, int ReadCount, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ExpertsEdit(ref ds, SiteID, ExpertsID, Description, MaxPrice, BonusScale, ON, isCommend, ReadCount, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ExpertsEdit(ref DataSet ds, long SiteID, long ExpertsID, string Description, double MaxPrice, double BonusScale, bool ON, bool isCommend, int ReadCount, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ExpertsEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ExpertsID", SqlDbType.BigInt, 0, ParameterDirection.Input, ExpertsID), new MSSQL.Parameter("Description", SqlDbType.VarChar, 0, ParameterDirection.Input, Description), new MSSQL.Parameter("MaxPrice", SqlDbType.Money, 0, ParameterDirection.Input, MaxPrice), new MSSQL.Parameter("BonusScale", SqlDbType.Float, 0, ParameterDirection.Input, BonusScale), new MSSQL.Parameter("ON", SqlDbType.Bit, 0, ParameterDirection.Input, ON), new MSSQL.Parameter("isCommend", SqlDbType.Bit, 0, ParameterDirection.Input, isCommend), new MSSQL.Parameter("ReadCount", SqlDbType.Int, 0, ParameterDirection.Input, ReadCount), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ExpertsTry(long SiteID, long UserID, int LotteryID, string Description, double MaxPrice, double BonusScale, ref long NewExpertsTryID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ExpertsTry(ref ds, SiteID, UserID, LotteryID, Description, MaxPrice, BonusScale, ref NewExpertsTryID, ref ReturnDescription);
        }

        public static int P_ExpertsTry(ref DataSet ds, long SiteID, long UserID, int LotteryID, string Description, double MaxPrice, double BonusScale, ref long NewExpertsTryID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ExpertsTry", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID), new MSSQL.Parameter("Description", SqlDbType.VarChar, 0, ParameterDirection.Input, Description), new MSSQL.Parameter("MaxPrice", SqlDbType.Money, 0, ParameterDirection.Input, MaxPrice), new MSSQL.Parameter("BonusScale", SqlDbType.Float, 0, ParameterDirection.Input, BonusScale), new MSSQL.Parameter("NewExpertsTryID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewExpertsTryID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                NewExpertsTryID = Convert.ToInt64(outputs["NewExpertsTryID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ExpertsTryHandle(long SiteID, long ExpertsTryID, short HandleResult, string Description, double MaxPrice, double BonusScale, bool isCommend, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ExpertsTryHandle(ref ds, SiteID, ExpertsTryID, HandleResult, Description, MaxPrice, BonusScale, isCommend, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ExpertsTryHandle(ref DataSet ds, long SiteID, long ExpertsTryID, short HandleResult, string Description, double MaxPrice, double BonusScale, bool isCommend, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ExpertsTryHandle", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ExpertsTryID", SqlDbType.BigInt, 0, ParameterDirection.Input, ExpertsTryID), new MSSQL.Parameter("HandleResult", SqlDbType.SmallInt, 0, ParameterDirection.Input, HandleResult), new MSSQL.Parameter("Description", SqlDbType.VarChar, 0, ParameterDirection.Input, Description), new MSSQL.Parameter("MaxPrice", SqlDbType.Money, 0, ParameterDirection.Input, MaxPrice), new MSSQL.Parameter("BonusScale", SqlDbType.Float, 0, ParameterDirection.Input, BonusScale), new MSSQL.Parameter("isCommend", SqlDbType.Bit, 0, ParameterDirection.Input, isCommend), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ExpertsWinCommendAdd(long SiteID, long UserID, DateTime DateTime, long IsuseID, string Title, string Content, bool isShow, ref long NewExpertsWinCommendID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ExpertsWinCommendAdd(ref ds, SiteID, UserID, DateTime, IsuseID, Title, Content, isShow, ref NewExpertsWinCommendID, ref ReturnDescription);
        }

        public static int P_ExpertsWinCommendAdd(ref DataSet ds, long SiteID, long UserID, DateTime DateTime, long IsuseID, string Title, string Content, bool isShow, ref long NewExpertsWinCommendID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ExpertsWinCommendAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("NewExpertsWinCommendID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewExpertsWinCommendID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                NewExpertsWinCommendID = Convert.ToInt64(outputs["NewExpertsWinCommendID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ExpertsWinCommendDelete(long SiteID, long ExpertsWinCommendsID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ExpertsWinCommendDelete(ref ds, SiteID, ExpertsWinCommendsID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ExpertsWinCommendDelete(ref DataSet ds, long SiteID, long ExpertsWinCommendsID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ExpertsWinCommendDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ExpertsWinCommendsID", SqlDbType.BigInt, 0, ParameterDirection.Input, ExpertsWinCommendsID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ExpertsWinCommendEdit(long SiteID, long ExpertsWinCommendsID, DateTime DateTime, long IsuseID, string Title, string Content, bool isShow, bool ON, bool isCommend, bool isAdmin, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ExpertsWinCommendEdit(ref ds, SiteID, ExpertsWinCommendsID, DateTime, IsuseID, Title, Content, isShow, ON, isCommend, isAdmin, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ExpertsWinCommendEdit(ref DataSet ds, long SiteID, long ExpertsWinCommendsID, DateTime DateTime, long IsuseID, string Title, string Content, bool isShow, bool ON, bool isCommend, bool isAdmin, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ExpertsWinCommendEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ExpertsWinCommendsID", SqlDbType.BigInt, 0, ParameterDirection.Input, ExpertsWinCommendsID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("ON", SqlDbType.Bit, 0, ParameterDirection.Input, ON), new MSSQL.Parameter("isCommend", SqlDbType.Bit, 0, ParameterDirection.Input, isCommend), new MSSQL.Parameter("isAdmin", SqlDbType.Bit, 0, ParameterDirection.Input, isAdmin), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_FootballLeagueTypeAdd(string Name, string Code, string MarkersColor, string Description, int Order, bool isUse, ref int FootballLeagueTypeID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_FootballLeagueTypeAdd(ref ds, Name, Code, MarkersColor, Description, Order, isUse, ref FootballLeagueTypeID, ref ReturnDescription);
        }

        public static int P_FootballLeagueTypeAdd(ref DataSet ds, string Name, string Code, string MarkersColor, string Description, int Order, bool isUse, ref int FootballLeagueTypeID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_FootballLeagueTypeAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, Name), new MSSQL.Parameter("Code", SqlDbType.VarChar, 0, ParameterDirection.Input, Code), new MSSQL.Parameter("MarkersColor", SqlDbType.VarChar, 0, ParameterDirection.Input, MarkersColor), new MSSQL.Parameter("Description", SqlDbType.VarChar, 0, ParameterDirection.Input, Description), new MSSQL.Parameter("Order", SqlDbType.Int, 0, ParameterDirection.Input, Order), new MSSQL.Parameter("isUse", SqlDbType.Bit, 0, ParameterDirection.Input, isUse), new MSSQL.Parameter("FootballLeagueTypeID", SqlDbType.Int, 4, ParameterDirection.Output, (int) FootballLeagueTypeID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                FootballLeagueTypeID = Convert.ToInt32(outputs["FootballLeagueTypeID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_FootballLeagueTypeEdit(int ID, string Name, string Code, string MarkersColor, string Description, int Order, bool isUse, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_FootballLeagueTypeEdit(ref ds, ID, Name, Code, MarkersColor, Description, Order, isUse, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_FootballLeagueTypeEdit(ref DataSet ds, int ID, string Name, string Code, string MarkersColor, string Description, int Order, bool isUse, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_FootballLeagueTypeEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ID", SqlDbType.Int, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, Name), new MSSQL.Parameter("Code", SqlDbType.VarChar, 0, ParameterDirection.Input, Code), new MSSQL.Parameter("MarkersColor", SqlDbType.VarChar, 0, ParameterDirection.Input, MarkersColor), new MSSQL.Parameter("Description", SqlDbType.VarChar, 0, ParameterDirection.Input, Description), new MSSQL.Parameter("Order", SqlDbType.Int, 0, ParameterDirection.Input, Order), new MSSQL.Parameter("isUse", SqlDbType.Bit, 0, ParameterDirection.Input, isUse), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_FriendshipLinkAdd(long SiteID, string LinkName, string LogoUrl, string Url, int Order, bool isShow, ref long NewFriendshipLinkID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_FriendshipLinkAdd(ref ds, SiteID, LinkName, LogoUrl, Url, Order, isShow, ref NewFriendshipLinkID, ref ReturnDescription);
        }

        public static int P_FriendshipLinkAdd(ref DataSet ds, long SiteID, string LinkName, string LogoUrl, string Url, int Order, bool isShow, ref long NewFriendshipLinkID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_FriendshipLinkAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("LinkName", SqlDbType.VarChar, 0, ParameterDirection.Input, LinkName), new MSSQL.Parameter("LogoUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, LogoUrl), new MSSQL.Parameter("Url", SqlDbType.VarChar, 0, ParameterDirection.Input, Url), new MSSQL.Parameter("Order", SqlDbType.Int, 0, ParameterDirection.Input, Order), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("NewFriendshipLinkID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewFriendshipLinkID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                NewFriendshipLinkID = Convert.ToInt64(outputs["NewFriendshipLinkID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_FriendshipLinkDelete(long SiteID, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_FriendshipLinkDelete(ref ds, SiteID, ID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_FriendshipLinkDelete(ref DataSet ds, long SiteID, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_FriendshipLinkDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_FriendshipLinkEdit(long SiteID, long ID, string LinkName, string LogoUrl, string Url, int Order, bool isShow, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_FriendshipLinkEdit(ref ds, SiteID, ID, LinkName, LogoUrl, Url, Order, isShow, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_FriendshipLinkEdit(ref DataSet ds, long SiteID, long ID, string LinkName, string LogoUrl, string Url, int Order, bool isShow, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_FriendshipLinkEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("LinkName", SqlDbType.VarChar, 0, ParameterDirection.Input, LinkName), new MSSQL.Parameter("LogoUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, LogoUrl), new MSSQL.Parameter("Url", SqlDbType.VarChar, 0, ParameterDirection.Input, Url), new MSSQL.Parameter("Order", SqlDbType.Int, 0, ParameterDirection.Input, Order), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetAccount(long SiteID, int Year, int Month, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetAccount(ref ds, SiteID, Year, Month, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetAccount(ref DataSet ds, long SiteID, int Year, int Month, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetAccount", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("Year", SqlDbType.Int, 0, ParameterDirection.Input, Year), new MSSQL.Parameter("Month", SqlDbType.Int, 0, ParameterDirection.Input, Month), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsAccount(int Year, int Month, long CpsID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsAccount(ref ds, Year, Month, CpsID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsAccount(ref DataSet ds, int Year, int Month, long CpsID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsAccount", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("Year", SqlDbType.Int, 0, ParameterDirection.Input, Year), new MSSQL.Parameter("Month", SqlDbType.Int, 0, ParameterDirection.Input, Month), new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 0, ParameterDirection.Input, CpsID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsAccountByPid(long SiteID, long UserID, DateTime StartTime, DateTime EndTime, string pid, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsAccountByPid(ref ds, SiteID, UserID, StartTime, EndTime, pid, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsAccountByPid(ref DataSet ds, long SiteID, long UserID, DateTime StartTime, DateTime EndTime, string pid, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsAccountByPid", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("pid", SqlDbType.VarChar, 0, ParameterDirection.Input, pid), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsAccountDetail(long SiteID, long UserID, int Year, int Month, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsAccountDetail(ref ds, SiteID, UserID, Year, Month, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsAccountDetail(ref DataSet ds, long SiteID, long UserID, int Year, int Month, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsAccountDetail", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Year", SqlDbType.Int, 0, ParameterDirection.Input, Year), new MSSQL.Parameter("Month", SqlDbType.Int, 0, ParameterDirection.Input, Month), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsAccountDetailWithUser(long CpsID, DateTime StartTime, DateTime EndTime, string KeyWord, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsAccountDetailWithUser(ref ds, CpsID, StartTime, EndTime, KeyWord, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsAccountDetailWithUser(ref DataSet ds, long CpsID, DateTime StartTime, DateTime EndTime, string KeyWord, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsAccountDetailWithUser", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 0, ParameterDirection.Input, CpsID), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("KeyWord", SqlDbType.VarChar, 0, ParameterDirection.Input, KeyWord), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsAccountRevenue(long SiteID, long UserID, DateTime StartTime, DateTime EndTime, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsAccountRevenue(ref ds, SiteID, UserID, StartTime, EndTime, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsAccountRevenue(ref DataSet ds, long SiteID, long UserID, DateTime StartTime, DateTime EndTime, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsAccountRevenue", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsAccountRevenue_center(long SiteID, long UserID, DateTime StartTime, DateTime EndTime, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsAccountRevenue_center(ref ds, SiteID, UserID, StartTime, EndTime, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsAccountRevenue_center(ref DataSet ds, long SiteID, long UserID, DateTime StartTime, DateTime EndTime, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsAccountRevenue_center", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsAccountRevenueSite(long SiteID, long UserID, DateTime StartTime, DateTime EndTime, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsAccountRevenueSite(ref ds, SiteID, UserID, StartTime, EndTime, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsAccountRevenueSite(ref DataSet ds, long SiteID, long UserID, DateTime StartTime, DateTime EndTime, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsAccountRevenueSite", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsAccountRevenueSite_center(long SiteID, long UserID, DateTime StartTime, DateTime EndTime, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsAccountRevenueSite_center(ref ds, SiteID, UserID, StartTime, EndTime, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsAccountRevenueSite_center(ref DataSet ds, long SiteID, long UserID, DateTime StartTime, DateTime EndTime, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsAccountRevenueSite_center", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsAccountWithCpsID(DateTime StartTime, DateTime EndTime, long CpsID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsAccountWithCpsID(ref ds, StartTime, EndTime, CpsID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsAccountWithCpsID(ref DataSet ds, DateTime StartTime, DateTime EndTime, long CpsID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsAccountWithCpsID", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 0, ParameterDirection.Input, CpsID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsAccountWithCpsUser(long CpsID, DateTime StartTime, DateTime EndTime, string KeyWord, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsAccountWithCpsUser(ref ds, CpsID, StartTime, EndTime, KeyWord, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsAccountWithCpsUser(ref DataSet ds, long CpsID, DateTime StartTime, DateTime EndTime, string KeyWord, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsAccountWithCpsUser", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 0, ParameterDirection.Input, CpsID), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("KeyWord", SqlDbType.VarChar, 0, ParameterDirection.Input, KeyWord), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsAccountWithMonth(DateTime StartTime, DateTime EndTime, string UserName, long CpsID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsAccountWithMonth(ref ds, StartTime, EndTime, UserName, CpsID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsAccountWithMonth(ref DataSet ds, DateTime StartTime, DateTime EndTime, string UserName, long CpsID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsAccountWithMonth", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("UserName", SqlDbType.VarChar, 0, ParameterDirection.Input, UserName), new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 0, ParameterDirection.Input, CpsID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsBuyDetailByDate(long SiteID, long CpsID, DateTime FromTime, DateTime ToTime, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsBuyDetailByDate(ref ds, SiteID, CpsID, FromTime, ToTime, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsBuyDetailByDate(ref DataSet ds, long SiteID, long CpsID, DateTime FromTime, DateTime ToTime, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsBuyDetailByDate", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 0, ParameterDirection.Input, CpsID), new MSSQL.Parameter("FromTime", SqlDbType.DateTime, 0, ParameterDirection.Input, FromTime), new MSSQL.Parameter("ToTime", SqlDbType.DateTime, 0, ParameterDirection.Input, ToTime), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsByDay(long CpsID, ref int Members, ref int SumMembers, ref double TodayIncome, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsByDay(ref ds, CpsID, ref Members, ref SumMembers, ref TodayIncome, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsByDay(ref DataSet ds, long CpsID, ref int Members, ref int SumMembers, ref double TodayIncome, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsByDay", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 0, ParameterDirection.Input, CpsID), new MSSQL.Parameter("Members", SqlDbType.Int, 4, ParameterDirection.Output, (int) Members), new MSSQL.Parameter("SumMembers", SqlDbType.Int, 4, ParameterDirection.Output, (int) SumMembers), new MSSQL.Parameter("TodayIncome", SqlDbType.Money, 8, ParameterDirection.Output, (double) TodayIncome), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                Members = Convert.ToInt32(outputs["Members"]);
            }
            catch
            {
            }
            try
            {
                SumMembers = Convert.ToInt32(outputs["SumMembers"]);
            }
            catch
            {
            }
            try
            {
                TodayIncome = Convert.ToDouble(outputs["TodayIncome"]);
            }
            catch
            {
            }
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsInformationByID(long SiteID, long CpsID, ref long OwnerUserID, ref string Name, ref DateTime Datetime, ref string Url, ref string LogoUrl, ref double BonusScale, ref bool ON, ref string Company, ref string Address, ref string PostCode, ref string ResponsiblePerson, ref string ContactPerson, ref string Telephone, ref string Fax, ref string Mobile, ref string Email, ref string QQ, ref string ServiceTelephone, ref string MD5Key, ref short Type, ref long ParentID, ref string DomainName, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsInformationByID(ref ds, SiteID, CpsID, ref OwnerUserID, ref Name, ref Datetime, ref Url, ref LogoUrl, ref BonusScale, ref ON, ref Company, ref Address, ref PostCode, ref ResponsiblePerson, ref ContactPerson, ref Telephone, ref Fax, ref Mobile, ref Email, ref QQ, ref ServiceTelephone, ref MD5Key, ref Type, ref ParentID, ref DomainName, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsInformationByID(ref DataSet ds, long SiteID, long CpsID, ref long OwnerUserID, ref string Name, ref DateTime Datetime, ref string Url, ref string LogoUrl, ref double BonusScale, ref bool ON, ref string Company, ref string Address, ref string PostCode, ref string ResponsiblePerson, ref string ContactPerson, ref string Telephone, ref string Fax, ref string Mobile, ref string Email, ref string QQ, ref string ServiceTelephone, ref string MD5Key, ref short Type, ref long ParentID, ref string DomainName, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsInformationByID", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 0, ParameterDirection.Input, CpsID), new MSSQL.Parameter("OwnerUserID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) OwnerUserID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 50, ParameterDirection.Output, Name), new MSSQL.Parameter("Datetime", SqlDbType.DateTime, 8, ParameterDirection.Output, (DateTime) Datetime), new MSSQL.Parameter("Url", SqlDbType.VarChar, 100, ParameterDirection.Output, Url), new MSSQL.Parameter("LogoUrl", SqlDbType.VarChar, 200, ParameterDirection.Output, LogoUrl), new MSSQL.Parameter("BonusScale", SqlDbType.Float, 8, ParameterDirection.Output, (double) BonusScale), new MSSQL.Parameter("ON", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) ON), new MSSQL.Parameter("Company", SqlDbType.VarChar, 50, ParameterDirection.Output, Company), new MSSQL.Parameter("Address", SqlDbType.VarChar, 50, ParameterDirection.Output, Address), new MSSQL.Parameter("PostCode", SqlDbType.VarChar, 6, ParameterDirection.Output, PostCode), new MSSQL.Parameter("ResponsiblePerson", SqlDbType.VarChar, 50, ParameterDirection.Output, ResponsiblePerson), new MSSQL.Parameter("ContactPerson", SqlDbType.VarChar, 50, ParameterDirection.Output, ContactPerson), new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 50, ParameterDirection.Output, Telephone), new MSSQL.Parameter("Fax", SqlDbType.VarChar, 50, ParameterDirection.Output, Fax), 
                new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 50, ParameterDirection.Output, Mobile), new MSSQL.Parameter("Email", SqlDbType.VarChar, 50, ParameterDirection.Output, Email), new MSSQL.Parameter("QQ", SqlDbType.VarChar, 50, ParameterDirection.Output, QQ), new MSSQL.Parameter("ServiceTelephone", SqlDbType.VarChar, 30, ParameterDirection.Output, ServiceTelephone), new MSSQL.Parameter("MD5Key", SqlDbType.VarChar, 120, ParameterDirection.Output, MD5Key), new MSSQL.Parameter("Type", SqlDbType.SmallInt, 2, ParameterDirection.Output, (short) Type), new MSSQL.Parameter("ParentID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) ParentID), new MSSQL.Parameter("DomainName", SqlDbType.VarChar, 200, ParameterDirection.Output, DomainName), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                OwnerUserID = Convert.ToInt64(outputs["OwnerUserID"]);
            }
            catch
            {
            }
            try
            {
                Name = Convert.ToString(outputs["Name"]);
            }
            catch
            {
            }
            try
            {
                Datetime = Convert.ToDateTime(outputs["Datetime"]);
            }
            catch
            {
            }
            try
            {
                Url = Convert.ToString(outputs["Url"]);
            }
            catch
            {
            }
            try
            {
                LogoUrl = Convert.ToString(outputs["LogoUrl"]);
            }
            catch
            {
            }
            try
            {
                BonusScale = Convert.ToDouble(outputs["BonusScale"]);
            }
            catch
            {
            }
            try
            {
                ON = Convert.ToBoolean(outputs["ON"]);
            }
            catch
            {
            }
            try
            {
                Company = Convert.ToString(outputs["Company"]);
            }
            catch
            {
            }
            try
            {
                Address = Convert.ToString(outputs["Address"]);
            }
            catch
            {
            }
            try
            {
                PostCode = Convert.ToString(outputs["PostCode"]);
            }
            catch
            {
            }
            try
            {
                ResponsiblePerson = Convert.ToString(outputs["ResponsiblePerson"]);
            }
            catch
            {
            }
            try
            {
                ContactPerson = Convert.ToString(outputs["ContactPerson"]);
            }
            catch
            {
            }
            try
            {
                Telephone = Convert.ToString(outputs["Telephone"]);
            }
            catch
            {
            }
            try
            {
                Fax = Convert.ToString(outputs["Fax"]);
            }
            catch
            {
            }
            try
            {
                Mobile = Convert.ToString(outputs["Mobile"]);
            }
            catch
            {
            }
            try
            {
                Email = Convert.ToString(outputs["Email"]);
            }
            catch
            {
            }
            try
            {
                QQ = Convert.ToString(outputs["QQ"]);
            }
            catch
            {
            }
            try
            {
                ServiceTelephone = Convert.ToString(outputs["ServiceTelephone"]);
            }
            catch
            {
            }
            try
            {
                MD5Key = Convert.ToString(outputs["MD5Key"]);
            }
            catch
            {
            }
            try
            {
                Type = Convert.ToInt16(outputs["Type"]);
            }
            catch
            {
            }
            try
            {
                ParentID = Convert.ToInt64(outputs["ParentID"]);
            }
            catch
            {
            }
            try
            {
                DomainName = Convert.ToString(outputs["DomainName"]);
            }
            catch
            {
            }
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsInformationByOwnerUserID(long SiteID, long OwnerUserID, ref long CpsID, ref string Name, ref DateTime Datetime, ref string Url, ref string LogoUrl, ref double BonusScale, ref bool ON, ref string Company, ref string Address, ref string PostCode, ref string ResponsiblePerson, ref string ContactPerson, ref string Telephone, ref string Fax, ref string Mobile, ref string Email, ref string QQ, ref string ServiceTelephone, ref string MD5Key, ref short Type, ref long ParentID, ref string DomainName, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsInformationByOwnerUserID(ref ds, SiteID, OwnerUserID, ref CpsID, ref Name, ref Datetime, ref Url, ref LogoUrl, ref BonusScale, ref ON, ref Company, ref Address, ref PostCode, ref ResponsiblePerson, ref ContactPerson, ref Telephone, ref Fax, ref Mobile, ref Email, ref QQ, ref ServiceTelephone, ref MD5Key, ref Type, ref ParentID, ref DomainName, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsInformationByOwnerUserID(ref DataSet ds, long SiteID, long OwnerUserID, ref long CpsID, ref string Name, ref DateTime Datetime, ref string Url, ref string LogoUrl, ref double BonusScale, ref bool ON, ref string Company, ref string Address, ref string PostCode, ref string ResponsiblePerson, ref string ContactPerson, ref string Telephone, ref string Fax, ref string Mobile, ref string Email, ref string QQ, ref string ServiceTelephone, ref string MD5Key, ref short Type, ref long ParentID, ref string DomainName, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsInformationByOwnerUserID", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("OwnerUserID", SqlDbType.BigInt, 0, ParameterDirection.Input, OwnerUserID), new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) CpsID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 50, ParameterDirection.Output, Name), new MSSQL.Parameter("Datetime", SqlDbType.DateTime, 8, ParameterDirection.Output, (DateTime) Datetime), new MSSQL.Parameter("Url", SqlDbType.VarChar, 100, ParameterDirection.Output, Url), new MSSQL.Parameter("LogoUrl", SqlDbType.VarChar, 200, ParameterDirection.Output, LogoUrl), new MSSQL.Parameter("BonusScale", SqlDbType.Float, 8, ParameterDirection.Output, (double) BonusScale), new MSSQL.Parameter("ON", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) ON), new MSSQL.Parameter("Company", SqlDbType.VarChar, 50, ParameterDirection.Output, Company), new MSSQL.Parameter("Address", SqlDbType.VarChar, 50, ParameterDirection.Output, Address), new MSSQL.Parameter("PostCode", SqlDbType.VarChar, 6, ParameterDirection.Output, PostCode), new MSSQL.Parameter("ResponsiblePerson", SqlDbType.VarChar, 50, ParameterDirection.Output, ResponsiblePerson), new MSSQL.Parameter("ContactPerson", SqlDbType.VarChar, 50, ParameterDirection.Output, ContactPerson), new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 50, ParameterDirection.Output, Telephone), new MSSQL.Parameter("Fax", SqlDbType.VarChar, 50, ParameterDirection.Output, Fax), 
                new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 50, ParameterDirection.Output, Mobile), new MSSQL.Parameter("Email", SqlDbType.VarChar, 50, ParameterDirection.Output, Email), new MSSQL.Parameter("QQ", SqlDbType.VarChar, 50, ParameterDirection.Output, QQ), new MSSQL.Parameter("ServiceTelephone", SqlDbType.VarChar, 30, ParameterDirection.Output, ServiceTelephone), new MSSQL.Parameter("MD5Key", SqlDbType.VarChar, 120, ParameterDirection.Output, MD5Key), new MSSQL.Parameter("Type", SqlDbType.SmallInt, 2, ParameterDirection.Output, (short) Type), new MSSQL.Parameter("ParentID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) ParentID), new MSSQL.Parameter("DomainName", SqlDbType.VarChar, 200, ParameterDirection.Output, DomainName), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                CpsID = Convert.ToInt64(outputs["CpsID"]);
            }
            catch
            {
            }
            try
            {
                Name = Convert.ToString(outputs["Name"]);
            }
            catch
            {
            }
            try
            {
                Datetime = Convert.ToDateTime(outputs["Datetime"]);
            }
            catch
            {
            }
            try
            {
                Url = Convert.ToString(outputs["Url"]);
            }
            catch
            {
            }
            try
            {
                LogoUrl = Convert.ToString(outputs["LogoUrl"]);
            }
            catch
            {
            }
            try
            {
                BonusScale = Convert.ToDouble(outputs["BonusScale"]);
            }
            catch
            {
            }
            try
            {
                ON = Convert.ToBoolean(outputs["ON"]);
            }
            catch
            {
            }
            try
            {
                Company = Convert.ToString(outputs["Company"]);
            }
            catch
            {
            }
            try
            {
                Address = Convert.ToString(outputs["Address"]);
            }
            catch
            {
            }
            try
            {
                PostCode = Convert.ToString(outputs["PostCode"]);
            }
            catch
            {
            }
            try
            {
                ResponsiblePerson = Convert.ToString(outputs["ResponsiblePerson"]);
            }
            catch
            {
            }
            try
            {
                ContactPerson = Convert.ToString(outputs["ContactPerson"]);
            }
            catch
            {
            }
            try
            {
                Telephone = Convert.ToString(outputs["Telephone"]);
            }
            catch
            {
            }
            try
            {
                Fax = Convert.ToString(outputs["Fax"]);
            }
            catch
            {
            }
            try
            {
                Mobile = Convert.ToString(outputs["Mobile"]);
            }
            catch
            {
            }
            try
            {
                Email = Convert.ToString(outputs["Email"]);
            }
            catch
            {
            }
            try
            {
                QQ = Convert.ToString(outputs["QQ"]);
            }
            catch
            {
            }
            try
            {
                ServiceTelephone = Convert.ToString(outputs["ServiceTelephone"]);
            }
            catch
            {
            }
            try
            {
                MD5Key = Convert.ToString(outputs["MD5Key"]);
            }
            catch
            {
            }
            try
            {
                Type = Convert.ToInt16(outputs["Type"]);
            }
            catch
            {
            }
            try
            {
                ParentID = Convert.ToInt64(outputs["ParentID"]);
            }
            catch
            {
            }
            try
            {
                DomainName = Convert.ToString(outputs["DomainName"]);
            }
            catch
            {
            }
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsLinkList(long CpsID, DateTime StartTime, DateTime EndTime, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsLinkList(ref ds, CpsID, StartTime, EndTime, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsLinkList(ref DataSet ds, long CpsID, DateTime StartTime, DateTime EndTime, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsLinkList", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 0, ParameterDirection.Input, CpsID), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsList(ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsList(ref ds, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsList(ref DataSet ds, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsList", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsMemberBuyDetail(long SiteID, long UserID, DateTime FromTime, DateTime ToTime, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsMemberBuyDetail(ref ds, SiteID, UserID, FromTime, ToTime, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsMemberBuyDetail(ref DataSet ds, long SiteID, long UserID, DateTime FromTime, DateTime ToTime, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsMemberBuyDetail", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("FromTime", SqlDbType.DateTime, 0, ParameterDirection.Input, FromTime), new MSSQL.Parameter("ToTime", SqlDbType.DateTime, 0, ParameterDirection.Input, ToTime), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsMemberList(long CpsID, DateTime FromTime, DateTime ToTime, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsMemberList(ref ds, CpsID, FromTime, ToTime, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsMemberList(ref DataSet ds, long CpsID, DateTime FromTime, DateTime ToTime, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsMemberList", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 0, ParameterDirection.Input, CpsID), new MSSQL.Parameter("FromTime", SqlDbType.DateTime, 0, ParameterDirection.Input, FromTime), new MSSQL.Parameter("ToTime", SqlDbType.DateTime, 0, ParameterDirection.Input, ToTime), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsPopularizeAccountRevenue(long SiteID, long UserID, DateTime StartTime, DateTime EndTime, int type, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsPopularizeAccountRevenue(ref ds, SiteID, UserID, StartTime, EndTime, type, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsPopularizeAccountRevenue(ref DataSet ds, long SiteID, long UserID, DateTime StartTime, DateTime EndTime, int type, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsPopularizeAccountRevenue", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("type", SqlDbType.Int, 0, ParameterDirection.Input, type), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsUnionBusinessList(ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsUnionBusinessList(ref ds, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsUnionBusinessList(ref DataSet ds, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsUnionBusinessList", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetCpsWebSiteList(ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetCpsWebSiteList(ref ds, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetCpsWebSiteList(ref DataSet ds, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetCpsWebSiteList", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetDistillMoneyAndAddMoney(long SiteID, DateTime FromDate, DateTime ToDate, int DistillType, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetDistillMoneyAndAddMoney(ref ds, SiteID, FromDate, ToDate, DistillType, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetDistillMoneyAndAddMoney(ref DataSet ds, long SiteID, DateTime FromDate, DateTime ToDate, int DistillType, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetDistillMoneyAndAddMoney", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("FromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, FromDate), new MSSQL.Parameter("ToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, ToDate), new MSSQL.Parameter("DistillType", SqlDbType.Int, 0, ParameterDirection.Input, DistillType), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetDistillStatisticByAccount(long SiteID, DateTime FromDate, DateTime ToDate, string AccountName, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetDistillStatisticByAccount(ref ds, SiteID, FromDate, ToDate, AccountName, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetDistillStatisticByAccount(ref DataSet ds, long SiteID, DateTime FromDate, DateTime ToDate, string AccountName, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetDistillStatisticByAccount", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("FromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, FromDate), new MSSQL.Parameter("ToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, ToDate), new MSSQL.Parameter("AccountName", SqlDbType.NVarChar, 0, ParameterDirection.Input, AccountName), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetDistillStatisticByDistillType(long SiteID, DateTime FromDate, DateTime ToDate, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetDistillStatisticByDistillType(ref ds, SiteID, FromDate, ToDate, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetDistillStatisticByDistillType(ref DataSet ds, long SiteID, DateTime FromDate, DateTime ToDate, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetDistillStatisticByDistillType", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("FromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, FromDate), new MSSQL.Parameter("ToDate", SqlDbType.DateTime, 0, ParameterDirection.Input, ToDate), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetExpertsAccount(long SiteID, int Year, int Month, long ExpertsID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetExpertsAccount(ref ds, SiteID, Year, Month, ExpertsID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetExpertsAccount(ref DataSet ds, long SiteID, int Year, int Month, long ExpertsID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetExpertsAccount", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("Year", SqlDbType.Int, 0, ParameterDirection.Input, Year), new MSSQL.Parameter("Month", SqlDbType.Int, 0, ParameterDirection.Input, Month), new MSSQL.Parameter("ExpertsID", SqlDbType.BigInt, 0, ParameterDirection.Input, ExpertsID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetExpertsAccountDetail(long SiteID, long UserID, int Year, int Month, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetExpertsAccountDetail(ref ds, SiteID, UserID, Year, Month, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetExpertsAccountDetail(ref DataSet ds, long SiteID, long UserID, int Year, int Month, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetExpertsAccountDetail", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Year", SqlDbType.Int, 0, ParameterDirection.Input, Year), new MSSQL.Parameter("Month", SqlDbType.Int, 0, ParameterDirection.Input, Month), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetExpertsGroupUserID(int ExpertsCount)
        {
            DataSet ds = null;
            return P_GetExpertsGroupUserID(ref ds, ExpertsCount);
        }

        public static int P_GetExpertsGroupUserID(ref DataSet ds, int ExpertsCount)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_GetExpertsGroupUserID", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ExpertsCount", SqlDbType.Int, 0, ParameterDirection.Input, ExpertsCount) });
        }

        public static int P_GetFinanceAddMoney(long SiteID, long UserID, int Year, int Month, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetFinanceAddMoney(ref ds, SiteID, UserID, Year, Month, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetFinanceAddMoney(ref DataSet ds, long SiteID, long UserID, int Year, int Month, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetFinanceAddMoney", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Year", SqlDbType.Int, 0, ParameterDirection.Input, Year), new MSSQL.Parameter("Month", SqlDbType.Int, 0, ParameterDirection.Input, Month), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetFriendsInitiateSchemes(long SiteID, long UserID, long LotterID, long IsuseID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetFriendsInitiateSchemes(ref ds, SiteID, UserID, LotterID, IsuseID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetFriendsInitiateSchemes(ref DataSet ds, long SiteID, long UserID, long LotterID, long IsuseID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetFriendsInitiateSchemes", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("LotterID", SqlDbType.BigInt, 0, ParameterDirection.Input, LotterID), new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetFriendsWinInfo(long UserID, string SnsName, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetFriendsWinInfo(ref ds, UserID, SnsName, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetFriendsWinInfo(ref DataSet ds, long UserID, string SnsName, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetFriendsWinInfo", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("SnsName", SqlDbType.VarChar, 0, ParameterDirection.Input, SnsName), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetIsuseSalesAmount(long SiteID)
        {
            DataSet ds = null;
            return P_GetIsuseSalesAmount(ref ds, SiteID);
        }

        public static int P_GetIsuseSalesAmount(ref DataSet ds, long SiteID)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_GetIsuseSalesAmount", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID) });
        }

        public static int P_GetLoginCount(int Year, int Month)
        {
            DataSet ds = null;
            return P_GetLoginCount(ref ds, Year, Month);
        }

        public static int P_GetLoginCount(ref DataSet ds, int Year, int Month)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_GetLoginCount", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("Year", SqlDbType.Int, 0, ParameterDirection.Input, Year), new MSSQL.Parameter("Month", SqlDbType.Int, 0, ParameterDirection.Input, Month) });
        }

        public static int P_GetNewPayNumber(long SiteID, long UserID, string PayType, double Money, double FormalitiesFees, ref long NewPayNumber, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetNewPayNumber(ref ds, SiteID, UserID, PayType, Money, FormalitiesFees, ref NewPayNumber, ref ReturnDescription);
        }

        public static int P_GetNewPayNumber(ref DataSet ds, long SiteID, long UserID, string PayType, double Money, double FormalitiesFees, ref long NewPayNumber, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetNewPayNumber", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("PayType", SqlDbType.VarChar, 0, ParameterDirection.Input, PayType), new MSSQL.Parameter("Money", SqlDbType.Money, 0, ParameterDirection.Input, Money), new MSSQL.Parameter("FormalitiesFees", SqlDbType.Money, 0, ParameterDirection.Input, FormalitiesFees), new MSSQL.Parameter("NewPayNumber", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewPayNumber), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                NewPayNumber = Convert.ToInt64(outputs["NewPayNumber"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetPromoterInfoByIDList(long SiteID, string UserIDList, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetPromoterInfoByIDList(ref ds, SiteID, UserIDList, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetPromoterInfoByIDList(ref DataSet ds, long SiteID, string UserIDList, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetPromoterInfoByIDList", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserIDList", SqlDbType.VarChar, 0, ParameterDirection.Input, UserIDList), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetSchemeChatContents(long SiteID, long UserID, long SchemeID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetSchemeChatContents(ref ds, SiteID, UserID, SchemeID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetSchemeChatContents(ref DataSet ds, long SiteID, long UserID, long SchemeID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetSchemeChatContents", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetSedimentBalance(ref double SedimentBalance)
        {
            DataSet ds = null;
            return P_GetSedimentBalance(ref ds, ref SedimentBalance);
        }

        public static int P_GetSedimentBalance(ref DataSet ds, ref double SedimentBalance)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetSedimentBalance", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SedimentBalance", SqlDbType.Money, 8, ParameterDirection.Output, (double) SedimentBalance) });
            try
            {
                SedimentBalance = Convert.ToDouble(outputs["SedimentBalance"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetSiteInformationByID(long SiteID, ref long ParentID, ref long OwnerUserID, ref string Name, ref string LogoUrl, ref string Company, ref string Address, ref string PostCode, ref string ResponsiblePerson, ref string ContactPerson, ref string Telephone, ref string Fax, ref string Mobile, ref string Email, ref string QQ, ref string ServiceTelephone, ref string ICPCert, ref short Level, ref bool ON, ref double BonusScale, ref int MaxSubSites, ref string UseLotteryListRestrictions, ref string UseLotteryList, ref string UseLotteryListQuickBuy, ref string Urls, ref long AdministratorID, ref string PageTitle, ref string PageKeywords, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetSiteInformationByID(ref ds, SiteID, ref ParentID, ref OwnerUserID, ref Name, ref LogoUrl, ref Company, ref Address, ref PostCode, ref ResponsiblePerson, ref ContactPerson, ref Telephone, ref Fax, ref Mobile, ref Email, ref QQ, ref ServiceTelephone, ref ICPCert, ref Level, ref ON, ref BonusScale, ref MaxSubSites, ref UseLotteryListRestrictions, ref UseLotteryList, ref UseLotteryListQuickBuy, ref Urls, ref AdministratorID, ref PageTitle, ref PageKeywords, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetSiteInformationByID(ref DataSet ds, long SiteID, ref long ParentID, ref long OwnerUserID, ref string Name, ref string LogoUrl, ref string Company, ref string Address, ref string PostCode, ref string ResponsiblePerson, ref string ContactPerson, ref string Telephone, ref string Fax, ref string Mobile, ref string Email, ref string QQ, ref string ServiceTelephone, ref string ICPCert, ref short Level, ref bool ON, ref double BonusScale, ref int MaxSubSites, ref string UseLotteryListRestrictions, ref string UseLotteryList, ref string UseLotteryListQuickBuy, ref string Urls, ref long AdministratorID, ref string PageTitle, ref string PageKeywords, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetSiteInformationByID", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ParentID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) ParentID), new MSSQL.Parameter("OwnerUserID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) OwnerUserID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 50, ParameterDirection.Output, Name), new MSSQL.Parameter("LogoUrl", SqlDbType.VarChar, 200, ParameterDirection.Output, LogoUrl), new MSSQL.Parameter("Company", SqlDbType.VarChar, 50, ParameterDirection.Output, Company), new MSSQL.Parameter("Address", SqlDbType.VarChar, 50, ParameterDirection.Output, Address), new MSSQL.Parameter("PostCode", SqlDbType.VarChar, 6, ParameterDirection.Output, PostCode), new MSSQL.Parameter("ResponsiblePerson", SqlDbType.VarChar, 50, ParameterDirection.Output, ResponsiblePerson), new MSSQL.Parameter("ContactPerson", SqlDbType.VarChar, 50, ParameterDirection.Output, ContactPerson), new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 50, ParameterDirection.Output, Telephone), new MSSQL.Parameter("Fax", SqlDbType.VarChar, 50, ParameterDirection.Output, Fax), new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 50, ParameterDirection.Output, Mobile), new MSSQL.Parameter("Email", SqlDbType.VarChar, 50, ParameterDirection.Output, Email), new MSSQL.Parameter("QQ", SqlDbType.VarChar, 50, ParameterDirection.Output, QQ), new MSSQL.Parameter("ServiceTelephone", SqlDbType.VarChar, 50, ParameterDirection.Output, ServiceTelephone), 
                new MSSQL.Parameter("ICPCert", SqlDbType.VarChar, 20, ParameterDirection.Output, ICPCert), new MSSQL.Parameter("Level", SqlDbType.SmallInt, 2, ParameterDirection.Output, (short) Level), new MSSQL.Parameter("ON", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) ON), new MSSQL.Parameter("BonusScale", SqlDbType.Float, 8, ParameterDirection.Output, (double) BonusScale), new MSSQL.Parameter("MaxSubSites", SqlDbType.Int, 4, ParameterDirection.Output, (int) MaxSubSites), new MSSQL.Parameter("UseLotteryListRestrictions", SqlDbType.VarChar, 0x3e8, ParameterDirection.Output, UseLotteryListRestrictions), new MSSQL.Parameter("UseLotteryList", SqlDbType.VarChar, 0x3e8, ParameterDirection.Output, UseLotteryList), new MSSQL.Parameter("UseLotteryListQuickBuy", SqlDbType.VarChar, 100, ParameterDirection.Output, UseLotteryListQuickBuy), new MSSQL.Parameter("Urls", SqlDbType.VarChar, 0x1f40, ParameterDirection.Output, Urls), new MSSQL.Parameter("AdministratorID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) AdministratorID), new MSSQL.Parameter("PageTitle", SqlDbType.VarChar, 0x3e8, ParameterDirection.Output, PageTitle), new MSSQL.Parameter("PageKeywords", SqlDbType.VarChar, 0x3e8, ParameterDirection.Output, PageKeywords), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                ParentID = Convert.ToInt64(outputs["ParentID"]);
            }
            catch
            {
            }
            try
            {
                OwnerUserID = Convert.ToInt64(outputs["OwnerUserID"]);
            }
            catch
            {
            }
            try
            {
                Name = Convert.ToString(outputs["Name"]);
            }
            catch
            {
            }
            try
            {
                LogoUrl = Convert.ToString(outputs["LogoUrl"]);
            }
            catch
            {
            }
            try
            {
                Company = Convert.ToString(outputs["Company"]);
            }
            catch
            {
            }
            try
            {
                Address = Convert.ToString(outputs["Address"]);
            }
            catch
            {
            }
            try
            {
                PostCode = Convert.ToString(outputs["PostCode"]);
            }
            catch
            {
            }
            try
            {
                ResponsiblePerson = Convert.ToString(outputs["ResponsiblePerson"]);
            }
            catch
            {
            }
            try
            {
                ContactPerson = Convert.ToString(outputs["ContactPerson"]);
            }
            catch
            {
            }
            try
            {
                Telephone = Convert.ToString(outputs["Telephone"]);
            }
            catch
            {
            }
            try
            {
                Fax = Convert.ToString(outputs["Fax"]);
            }
            catch
            {
            }
            try
            {
                Mobile = Convert.ToString(outputs["Mobile"]);
            }
            catch
            {
            }
            try
            {
                Email = Convert.ToString(outputs["Email"]);
            }
            catch
            {
            }
            try
            {
                QQ = Convert.ToString(outputs["QQ"]);
            }
            catch
            {
            }
            try
            {
                ServiceTelephone = Convert.ToString(outputs["ServiceTelephone"]);
            }
            catch
            {
            }
            try
            {
                ICPCert = Convert.ToString(outputs["ICPCert"]);
            }
            catch
            {
            }
            try
            {
                Level = Convert.ToInt16(outputs["Level"]);
            }
            catch
            {
            }
            try
            {
                ON = Convert.ToBoolean(outputs["ON"]);
            }
            catch
            {
            }
            try
            {
                BonusScale = Convert.ToDouble(outputs["BonusScale"]);
            }
            catch
            {
            }
            try
            {
                MaxSubSites = Convert.ToInt32(outputs["MaxSubSites"]);
            }
            catch
            {
            }
            try
            {
                UseLotteryListRestrictions = Convert.ToString(outputs["UseLotteryListRestrictions"]);
            }
            catch
            {
            }
            try
            {
                UseLotteryList = Convert.ToString(outputs["UseLotteryList"]);
            }
            catch
            {
            }
            try
            {
                UseLotteryListQuickBuy = Convert.ToString(outputs["UseLotteryListQuickBuy"]);
            }
            catch
            {
            }
            try
            {
                Urls = Convert.ToString(outputs["Urls"]);
            }
            catch
            {
            }
            try
            {
                AdministratorID = Convert.ToInt64(outputs["AdministratorID"]);
            }
            catch
            {
            }
            try
            {
                PageTitle = Convert.ToString(outputs["PageTitle"]);
            }
            catch
            {
            }
            try
            {
                PageKeywords = Convert.ToString(outputs["PageKeywords"]);
            }
            catch
            {
            }
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetSiteInformationByUrl(string Url, ref long SiteID, ref long ParentID, ref long OwnerUserID, ref string Name, ref string LogoUrl, ref string Company, ref string Address, ref string PostCode, ref string ResponsiblePerson, ref string ContactPerson, ref string Telephone, ref string Fax, ref string Mobile, ref string Email, ref string QQ, ref string ServiceTelephone, ref string ICPCert, ref short Level, ref bool ON, ref double BonusScale, ref int MaxSubSites, ref string UseLotteryListRestrictions, ref string UseLotteryList, ref string UseLotteryListQuickBuy, ref string Urls, ref long AdministratorID, ref string PageTitle, ref string PageKeywords, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetSiteInformationByUrl(ref ds, Url, ref SiteID, ref ParentID, ref OwnerUserID, ref Name, ref LogoUrl, ref Company, ref Address, ref PostCode, ref ResponsiblePerson, ref ContactPerson, ref Telephone, ref Fax, ref Mobile, ref Email, ref QQ, ref ServiceTelephone, ref ICPCert, ref Level, ref ON, ref BonusScale, ref MaxSubSites, ref UseLotteryListRestrictions, ref UseLotteryList, ref UseLotteryListQuickBuy, ref Urls, ref AdministratorID, ref PageTitle, ref PageKeywords, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetSiteInformationByUrl(ref DataSet ds, string Url, ref long SiteID, ref long ParentID, ref long OwnerUserID, ref string Name, ref string LogoUrl, ref string Company, ref string Address, ref string PostCode, ref string ResponsiblePerson, ref string ContactPerson, ref string Telephone, ref string Fax, ref string Mobile, ref string Email, ref string QQ, ref string ServiceTelephone, ref string ICPCert, ref short Level, ref bool ON, ref double BonusScale, ref int MaxSubSites, ref string UseLotteryListRestrictions, ref string UseLotteryList, ref string UseLotteryListQuickBuy, ref string Urls, ref long AdministratorID, ref string PageTitle, ref string PageKeywords, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetSiteInformationByUrl", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("Url", SqlDbType.VarChar, 0, ParameterDirection.Input, Url), new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) SiteID), new MSSQL.Parameter("ParentID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) ParentID), new MSSQL.Parameter("OwnerUserID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) OwnerUserID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 50, ParameterDirection.Output, Name), new MSSQL.Parameter("LogoUrl", SqlDbType.VarChar, 200, ParameterDirection.Output, LogoUrl), new MSSQL.Parameter("Company", SqlDbType.VarChar, 50, ParameterDirection.Output, Company), new MSSQL.Parameter("Address", SqlDbType.VarChar, 50, ParameterDirection.Output, Address), new MSSQL.Parameter("PostCode", SqlDbType.VarChar, 6, ParameterDirection.Output, PostCode), new MSSQL.Parameter("ResponsiblePerson", SqlDbType.VarChar, 50, ParameterDirection.Output, ResponsiblePerson), new MSSQL.Parameter("ContactPerson", SqlDbType.VarChar, 50, ParameterDirection.Output, ContactPerson), new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 50, ParameterDirection.Output, Telephone), new MSSQL.Parameter("Fax", SqlDbType.VarChar, 50, ParameterDirection.Output, Fax), new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 50, ParameterDirection.Output, Mobile), new MSSQL.Parameter("Email", SqlDbType.VarChar, 50, ParameterDirection.Output, Email), new MSSQL.Parameter("QQ", SqlDbType.VarChar, 50, ParameterDirection.Output, QQ), 
                new MSSQL.Parameter("ServiceTelephone", SqlDbType.VarChar, 50, ParameterDirection.Output, ServiceTelephone), new MSSQL.Parameter("ICPCert", SqlDbType.VarChar, 20, ParameterDirection.Output, ICPCert), new MSSQL.Parameter("Level", SqlDbType.SmallInt, 2, ParameterDirection.Output, (short) Level), new MSSQL.Parameter("ON", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) ON), new MSSQL.Parameter("BonusScale", SqlDbType.Float, 8, ParameterDirection.Output, (double) BonusScale), new MSSQL.Parameter("MaxSubSites", SqlDbType.Int, 4, ParameterDirection.Output, (int) MaxSubSites), new MSSQL.Parameter("UseLotteryListRestrictions", SqlDbType.VarChar, 0x3e8, ParameterDirection.Output, UseLotteryListRestrictions), new MSSQL.Parameter("UseLotteryList", SqlDbType.VarChar, 0x3e8, ParameterDirection.Output, UseLotteryList), new MSSQL.Parameter("UseLotteryListQuickBuy", SqlDbType.VarChar, 100, ParameterDirection.Output, UseLotteryListQuickBuy), new MSSQL.Parameter("Urls", SqlDbType.VarChar, 0x1f40, ParameterDirection.Output, Urls), new MSSQL.Parameter("AdministratorID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) AdministratorID), new MSSQL.Parameter("PageTitle", SqlDbType.VarChar, 0x3e8, ParameterDirection.Output, PageTitle), new MSSQL.Parameter("PageKeywords", SqlDbType.VarChar, 0x3e8, ParameterDirection.Output, PageKeywords), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                SiteID = Convert.ToInt64(outputs["SiteID"]);
            }
            catch
            {
            }
            try
            {
                ParentID = Convert.ToInt64(outputs["ParentID"]);
            }
            catch
            {
            }
            try
            {
                OwnerUserID = Convert.ToInt64(outputs["OwnerUserID"]);
            }
            catch
            {
            }
            try
            {
                Name = Convert.ToString(outputs["Name"]);
            }
            catch
            {
            }
            try
            {
                LogoUrl = Convert.ToString(outputs["LogoUrl"]);
            }
            catch
            {
            }
            try
            {
                Company = Convert.ToString(outputs["Company"]);
            }
            catch
            {
            }
            try
            {
                Address = Convert.ToString(outputs["Address"]);
            }
            catch
            {
            }
            try
            {
                PostCode = Convert.ToString(outputs["PostCode"]);
            }
            catch
            {
            }
            try
            {
                ResponsiblePerson = Convert.ToString(outputs["ResponsiblePerson"]);
            }
            catch
            {
            }
            try
            {
                ContactPerson = Convert.ToString(outputs["ContactPerson"]);
            }
            catch
            {
            }
            try
            {
                Telephone = Convert.ToString(outputs["Telephone"]);
            }
            catch
            {
            }
            try
            {
                Fax = Convert.ToString(outputs["Fax"]);
            }
            catch
            {
            }
            try
            {
                Mobile = Convert.ToString(outputs["Mobile"]);
            }
            catch
            {
            }
            try
            {
                Email = Convert.ToString(outputs["Email"]);
            }
            catch
            {
            }
            try
            {
                QQ = Convert.ToString(outputs["QQ"]);
            }
            catch
            {
            }
            try
            {
                ServiceTelephone = Convert.ToString(outputs["ServiceTelephone"]);
            }
            catch
            {
            }
            try
            {
                ICPCert = Convert.ToString(outputs["ICPCert"]);
            }
            catch
            {
            }
            try
            {
                Level = Convert.ToInt16(outputs["Level"]);
            }
            catch
            {
            }
            try
            {
                ON = Convert.ToBoolean(outputs["ON"]);
            }
            catch
            {
            }
            try
            {
                BonusScale = Convert.ToDouble(outputs["BonusScale"]);
            }
            catch
            {
            }
            try
            {
                MaxSubSites = Convert.ToInt32(outputs["MaxSubSites"]);
            }
            catch
            {
            }
            try
            {
                UseLotteryListRestrictions = Convert.ToString(outputs["UseLotteryListRestrictions"]);
            }
            catch
            {
            }
            try
            {
                UseLotteryList = Convert.ToString(outputs["UseLotteryList"]);
            }
            catch
            {
            }
            try
            {
                UseLotteryListQuickBuy = Convert.ToString(outputs["UseLotteryListQuickBuy"]);
            }
            catch
            {
            }
            try
            {
                Urls = Convert.ToString(outputs["Urls"]);
            }
            catch
            {
            }
            try
            {
                AdministratorID = Convert.ToInt64(outputs["AdministratorID"]);
            }
            catch
            {
            }
            try
            {
                PageTitle = Convert.ToString(outputs["PageTitle"]);
            }
            catch
            {
            }
            try
            {
                PageKeywords = Convert.ToString(outputs["PageKeywords"]);
            }
            catch
            {
            }
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetSiteNotificationTemplate(long SiteID, short Manner, string NotificationType, ref string Value)
        {
            DataSet ds = null;
            return P_GetSiteNotificationTemplate(ref ds, SiteID, Manner, NotificationType, ref Value);
        }

        public static int P_GetSiteNotificationTemplate(ref DataSet ds, long SiteID, short Manner, string NotificationType, ref string Value)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetSiteNotificationTemplate", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("Manner", SqlDbType.SmallInt, 0, ParameterDirection.Input, Manner), new MSSQL.Parameter("NotificationType", SqlDbType.VarChar, 0, ParameterDirection.Input, NotificationType), new MSSQL.Parameter("Value", SqlDbType.VarChar, 0x3fffffff, ParameterDirection.Output, Value) });
            try
            {
                Value = Convert.ToString(outputs["Value"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetSurrogateAccount(long SiteID, int Year, int Month, long SubSiteID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetSurrogateAccount(ref ds, SiteID, Year, Month, SubSiteID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetSurrogateAccount(ref DataSet ds, long SiteID, int Year, int Month, long SubSiteID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetSurrogateAccount", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("Year", SqlDbType.Int, 0, ParameterDirection.Input, Year), new MSSQL.Parameter("Month", SqlDbType.Int, 0, ParameterDirection.Input, Month), new MSSQL.Parameter("SubSiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SubSiteID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetSurrogateSalesRanked(long SiteID, int RanksType, int Year, int Month, int Top, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetSurrogateSalesRanked(ref ds, SiteID, RanksType, Year, Month, Top, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetSurrogateSalesRanked(ref DataSet ds, long SiteID, int RanksType, int Year, int Month, int Top, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetSurrogateSalesRanked", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("RanksType", SqlDbType.Int, 0, ParameterDirection.Input, RanksType), new MSSQL.Parameter("Year", SqlDbType.Int, 0, ParameterDirection.Input, Year), new MSSQL.Parameter("Month", SqlDbType.Int, 0, ParameterDirection.Input, Month), new MSSQL.Parameter("Top", SqlDbType.Int, 0, ParameterDirection.Input, Top), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetUserAccountDetail(long SiteID, long UserID, int Year, int Month, int Day, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetUserAccountDetail(ref ds, SiteID, UserID, Year, Month, Day, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetUserAccountDetail(ref DataSet ds, long SiteID, long UserID, int Year, int Month, int Day, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetUserAccountDetail", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Year", SqlDbType.Int, 0, ParameterDirection.Input, Year), new MSSQL.Parameter("Month", SqlDbType.Int, 0, ParameterDirection.Input, Month), new MSSQL.Parameter("Day", SqlDbType.Int, 0, ParameterDirection.Input, Day), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetUserAccountDetails(long SiteID, long UserID, DateTime StartTime, DateTime EndTime, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetUserAccountDetails(ref ds, SiteID, UserID, StartTime, EndTime, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetUserAccountDetails(ref DataSet ds, long SiteID, long UserID, DateTime StartTime, DateTime EndTime, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetUserAccountDetails", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetUserBankDetail(long SiteID, long UserID, ref string BankTypeName, ref string BankName, ref string BankCardNumber, ref string BankInProvinceName, ref string BankInCityName, ref string BankUserName, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetUserBankDetail(ref ds, SiteID, UserID, ref BankTypeName, ref BankName, ref BankCardNumber, ref BankInProvinceName, ref BankInCityName, ref BankUserName, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetUserBankDetail(ref DataSet ds, long SiteID, long UserID, ref string BankTypeName, ref string BankName, ref string BankCardNumber, ref string BankInProvinceName, ref string BankInCityName, ref string BankUserName, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetUserBankDetail", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("BankTypeName", SqlDbType.VarChar, 50, ParameterDirection.Output, BankTypeName), new MSSQL.Parameter("BankName", SqlDbType.VarChar, 50, ParameterDirection.Output, BankName), new MSSQL.Parameter("BankCardNumber", SqlDbType.VarChar, 50, ParameterDirection.Output, BankCardNumber), new MSSQL.Parameter("BankInProvinceName", SqlDbType.VarChar, 50, ParameterDirection.Output, BankInProvinceName), new MSSQL.Parameter("BankInCityName", SqlDbType.VarChar, 50, ParameterDirection.Output, BankInCityName), new MSSQL.Parameter("BankUserName", SqlDbType.VarChar, 20, ParameterDirection.Output, BankUserName), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                BankTypeName = Convert.ToString(outputs["BankTypeName"]);
            }
            catch
            {
            }
            try
            {
                BankName = Convert.ToString(outputs["BankName"]);
            }
            catch
            {
            }
            try
            {
                BankCardNumber = Convert.ToString(outputs["BankCardNumber"]);
            }
            catch
            {
            }
            try
            {
                BankInProvinceName = Convert.ToString(outputs["BankInProvinceName"]);
            }
            catch
            {
            }
            try
            {
                BankInCityName = Convert.ToString(outputs["BankInCityName"]);
            }
            catch
            {
            }
            try
            {
                BankUserName = Convert.ToString(outputs["BankUserName"]);
            }
            catch
            {
            }
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetUserCustomFollowSchemes(long SiteID, long UserID, int PlayTypeID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetUserCustomFollowSchemes(ref ds, SiteID, UserID, PlayTypeID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetUserCustomFollowSchemes(ref DataSet ds, long SiteID, long UserID, int PlayTypeID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetUserCustomFollowSchemes", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, PlayTypeID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetUserFreezeDetail(long SiteID, long UserID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetUserFreezeDetail(ref ds, SiteID, UserID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetUserFreezeDetail(ref DataSet ds, long SiteID, long UserID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetUserFreezeDetail", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetUserInformationByID(long UserID, long SiteID, ref string Name, ref string NickName, ref string RealityName, ref string Password, ref string PasswordAdv, ref int CityID, ref string Sex, ref DateTime BirthDay, ref string IDCardNumber, ref string Address, ref string Email, ref bool isEmailValided, ref string QQ, ref bool isQQValided, ref string Telephone, ref string Mobile, ref bool isMobileValided, ref bool isPrivacy, ref bool isCanLogin, ref DateTime RegisterTime, ref DateTime LastLoginTime, ref string LastLoginIP, ref int LoginCount, ref short UserType, ref short BankType, ref string BankName, ref string BankCardNumber, ref double Balance,ref double CardPasswordM, ref double Freeze, ref double ScoringOfSelfBuy, ref double ScoringOfCommendBuy, ref double Scoring, ref short Level, ref long CommenderID, ref long CpsID, ref string OwnerSites, ref string AlipayID, ref double Bonus, ref double Reward, ref string AlipayName, ref bool isAlipayNameValided, ref int ComeFrom, ref bool IsCrossLogin, ref string Memo, ref double BonusThisMonth, ref double BonusAllow, ref double BonusUse, ref double PromotionMemberBonusScale, ref double PromotionSiteBonusScale, ref string VisitSource, ref string HeadUrl, ref string SecurityQuestion, ref string SecurityAnswer, ref string FriendList, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetUserInformationByID(ref ds, UserID, SiteID, ref Name, ref NickName, ref RealityName, ref Password, ref PasswordAdv, ref CityID, ref Sex, ref BirthDay, ref IDCardNumber, ref Address, ref Email, ref isEmailValided, ref QQ, ref isQQValided, ref Telephone, ref Mobile, ref isMobileValided, ref isPrivacy, ref isCanLogin, ref RegisterTime, ref LastLoginTime, ref LastLoginIP, ref LoginCount, ref UserType, ref BankType, ref BankName, ref BankCardNumber, ref Balance,ref CardPasswordM, ref Freeze, ref ScoringOfSelfBuy, ref ScoringOfCommendBuy, ref Scoring, ref Level, ref CommenderID, ref CpsID, ref OwnerSites, ref AlipayID, ref Bonus, ref Reward, ref AlipayName, ref isAlipayNameValided, ref ComeFrom, ref IsCrossLogin, ref Memo, ref BonusThisMonth, ref BonusAllow, ref BonusUse, ref PromotionMemberBonusScale, ref PromotionSiteBonusScale, ref VisitSource, ref HeadUrl, ref SecurityQuestion, ref SecurityAnswer, ref FriendList, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetUserInformationByID(ref DataSet ds, long UserID, long SiteID, ref string Name, ref string NickName, ref string RealityName, ref string Password, ref string PasswordAdv, ref int CityID, ref string Sex, ref DateTime BirthDay, ref string IDCardNumber, ref string Address, ref string Email, ref bool isEmailValided, ref string QQ, ref bool isQQValided, ref string Telephone, ref string Mobile, ref bool isMobileValided, ref bool isPrivacy, ref bool isCanLogin, ref DateTime RegisterTime, ref DateTime LastLoginTime, ref string LastLoginIP, ref int LoginCount, ref short UserType, ref short BankType, ref string BankName, ref string BankCardNumber, ref double Balance,ref double CardPasswordM, ref double Freeze, ref double ScoringOfSelfBuy, ref double ScoringOfCommendBuy, ref double Scoring, ref short Level, ref long CommenderID, ref long CpsID, ref string OwnerSites, ref string AlipayID, ref double Bonus, ref double Reward, ref string AlipayName, ref bool isAlipayNameValided, ref int ComeFrom, ref bool IsCrossLogin, ref string Memo, ref double BonusThisMonth, ref double BonusAllow, ref double BonusUse, ref double PromotionMemberBonusScale, ref double PromotionSiteBonusScale, ref string VisitSource, ref string HeadUrl, ref string SecurityQuestion, ref string SecurityAnswer, ref string FriendList, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetUserInformationByID", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 50, ParameterDirection.Output, Name), new MSSQL.Parameter("NickName", SqlDbType.VarChar, 50, ParameterDirection.Output, NickName), new MSSQL.Parameter("RealityName", SqlDbType.VarChar, 50, ParameterDirection.Output, RealityName), new MSSQL.Parameter("Password", SqlDbType.VarChar, 0x20, ParameterDirection.Output, Password), new MSSQL.Parameter("PasswordAdv", SqlDbType.VarChar, 0x20, ParameterDirection.Output, PasswordAdv), new MSSQL.Parameter("CityID", SqlDbType.Int, 4, ParameterDirection.Output, (int) CityID), new MSSQL.Parameter("Sex", SqlDbType.VarChar, 2, ParameterDirection.Output, Sex), new MSSQL.Parameter("BirthDay", SqlDbType.DateTime, 8, ParameterDirection.Output, (DateTime) BirthDay), new MSSQL.Parameter("IDCardNumber", SqlDbType.VarChar, 50, ParameterDirection.Output, IDCardNumber), new MSSQL.Parameter("Address", SqlDbType.VarChar, 50, ParameterDirection.Output, Address), new MSSQL.Parameter("Email", SqlDbType.VarChar, 50, ParameterDirection.Output, Email), new MSSQL.Parameter("isEmailValided", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isEmailValided), new MSSQL.Parameter("QQ", SqlDbType.VarChar, 50, ParameterDirection.Output, QQ), new MSSQL.Parameter("isQQValided", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isQQValided), 
                new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 50, ParameterDirection.Output, Telephone), new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 50, ParameterDirection.Output, Mobile), new MSSQL.Parameter("isMobileValided", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isMobileValided), new MSSQL.Parameter("isPrivacy", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isPrivacy), new MSSQL.Parameter("isCanLogin", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isCanLogin), new MSSQL.Parameter("RegisterTime", SqlDbType.DateTime, 8, ParameterDirection.Output, (DateTime) RegisterTime), new MSSQL.Parameter("LastLoginTime", SqlDbType.DateTime, 8, ParameterDirection.Output, (DateTime) LastLoginTime), new MSSQL.Parameter("LastLoginIP", SqlDbType.VarChar, 50, ParameterDirection.Output, LastLoginIP), new MSSQL.Parameter("LoginCount", SqlDbType.Int, 4, ParameterDirection.Output, (int) LoginCount), new MSSQL.Parameter("UserType", SqlDbType.SmallInt, 2, ParameterDirection.Output, (short) UserType), new MSSQL.Parameter("BankType", SqlDbType.SmallInt, 2, ParameterDirection.Output, (short) BankType), new MSSQL.Parameter("BankName", SqlDbType.VarChar, 50, ParameterDirection.Output, BankName), new MSSQL.Parameter("BankCardNumber", SqlDbType.VarChar, 50, ParameterDirection.Output, BankCardNumber), new MSSQL.Parameter("Balance", SqlDbType.Money, 8, ParameterDirection.Output, (double) Balance), new MSSQL.Parameter("CardPassword", SqlDbType.Money, 8, ParameterDirection.Output, (double)CardPasswordM),new MSSQL.Parameter("Freeze", SqlDbType.Money, 8, ParameterDirection.Output, (double) Freeze), new MSSQL.Parameter("ScoringOfSelfBuy", SqlDbType.Float, 8, ParameterDirection.Output, (double) ScoringOfSelfBuy), 
                new MSSQL.Parameter("ScoringOfCommendBuy", SqlDbType.Float, 8, ParameterDirection.Output, (double) ScoringOfCommendBuy), new MSSQL.Parameter("Scoring", SqlDbType.Float, 8, ParameterDirection.Output, (double) Scoring), new MSSQL.Parameter("Level", SqlDbType.SmallInt, 2, ParameterDirection.Output, (short) Level), new MSSQL.Parameter("CommenderID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) CommenderID), new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) CpsID), new MSSQL.Parameter("OwnerSites", SqlDbType.VarChar, 0x3e8, ParameterDirection.Output, OwnerSites), new MSSQL.Parameter("AlipayID", SqlDbType.VarChar, 0x20, ParameterDirection.Output, AlipayID), new MSSQL.Parameter("Bonus", SqlDbType.Money, 8, ParameterDirection.Output, (double) Bonus), new MSSQL.Parameter("Reward", SqlDbType.Money, 8, ParameterDirection.Output, (double) Reward), new MSSQL.Parameter("AlipayName", SqlDbType.VarChar, 50, ParameterDirection.Output, AlipayName), new MSSQL.Parameter("isAlipayNameValided", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isAlipayNameValided), new MSSQL.Parameter("ComeFrom", SqlDbType.Int, 4, ParameterDirection.Output, (int) ComeFrom), new MSSQL.Parameter("IsCrossLogin", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) IsCrossLogin), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 50, ParameterDirection.Output, Memo), new MSSQL.Parameter("BonusThisMonth", SqlDbType.Money, 8, ParameterDirection.Output, (double) BonusThisMonth), new MSSQL.Parameter("BonusAllow", SqlDbType.Money, 8, ParameterDirection.Output, (double) BonusAllow), 
                new MSSQL.Parameter("BonusUse", SqlDbType.Money, 8, ParameterDirection.Output, (double) BonusUse), new MSSQL.Parameter("PromotionMemberBonusScale", SqlDbType.Float, 8, ParameterDirection.Output, (double) PromotionMemberBonusScale), new MSSQL.Parameter("PromotionSiteBonusScale", SqlDbType.Float, 8, ParameterDirection.Output, (double) PromotionSiteBonusScale), new MSSQL.Parameter("VisitSource", SqlDbType.VarChar, 0xff, ParameterDirection.Output, VisitSource), new MSSQL.Parameter("HeadUrl", SqlDbType.VarChar, 500, ParameterDirection.Output, HeadUrl), new MSSQL.Parameter("SecurityQuestion", SqlDbType.VarChar, 100, ParameterDirection.Output, SecurityQuestion), new MSSQL.Parameter("SecurityAnswer", SqlDbType.VarChar, 50, ParameterDirection.Output, SecurityAnswer), new MSSQL.Parameter("FriendList", SqlDbType.VarChar, 0x3fffffff, ParameterDirection.Output, FriendList), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                Name = Convert.ToString(outputs["Name"]);
            }
            catch
            {
            }
            try
            {
                NickName = Convert.ToString(outputs["NickName"]);
            }
            catch
            {
            }
            try
            {
                RealityName = Convert.ToString(outputs["RealityName"]);
            }
            catch
            {
            }
            try
            {
                Password = Convert.ToString(outputs["Password"]);
            }
            catch
            {
            }
            try
            {
                PasswordAdv = Convert.ToString(outputs["PasswordAdv"]);
            }
            catch
            {
            }
            try
            {
                CityID = Convert.ToInt32(outputs["CityID"]);
            }
            catch
            {
            }
            try
            {
                Sex = Convert.ToString(outputs["Sex"]);
            }
            catch
            {
            }
            try
            {
                BirthDay = Convert.ToDateTime(outputs["BirthDay"]);
            }
            catch
            {
            }
            try
            {
                IDCardNumber = Convert.ToString(outputs["IDCardNumber"]);
            }
            catch
            {
            }
            try
            {
                Address = Convert.ToString(outputs["Address"]);
            }
            catch
            {
            }
            try
            {
                Email = Convert.ToString(outputs["Email"]);
            }
            catch
            {
            }
            try
            {
                isEmailValided = Convert.ToBoolean(outputs["isEmailValided"]);
            }
            catch
            {
            }
            try
            {
                QQ = Convert.ToString(outputs["QQ"]);
            }
            catch
            {
            }
            try
            {
                isQQValided = Convert.ToBoolean(outputs["isQQValided"]);
            }
            catch
            {
            }
            try
            {
                Telephone = Convert.ToString(outputs["Telephone"]);
            }
            catch
            {
            }
            try
            {
                Mobile = Convert.ToString(outputs["Mobile"]);
            }
            catch
            {
            }
            try
            {
                isMobileValided = Convert.ToBoolean(outputs["isMobileValided"]);
            }
            catch
            {
            }
            try
            {
                isPrivacy = Convert.ToBoolean(outputs["isPrivacy"]);
            }
            catch
            {
            }
            try
            {
                isCanLogin = Convert.ToBoolean(outputs["isCanLogin"]);
            }
            catch
            {
            }
            try
            {
                RegisterTime = Convert.ToDateTime(outputs["RegisterTime"]);
            }
            catch
            {
            }
            try
            {
                LastLoginTime = Convert.ToDateTime(outputs["LastLoginTime"]);
            }
            catch
            {
            }
            try
            {
                LastLoginIP = Convert.ToString(outputs["LastLoginIP"]);
            }
            catch
            {
            }
            try
            {
                LoginCount = Convert.ToInt32(outputs["LoginCount"]);
            }
            catch
            {
            }
            try
            {
                UserType = Convert.ToInt16(outputs["UserType"]);
            }
            catch
            {
            }
            try
            {
                BankType = Convert.ToInt16(outputs["BankType"]);
            }
            catch
            {
            }
            try
            {
                BankName = Convert.ToString(outputs["BankName"]);
            }
            catch
            {
            }
            try
            {
                BankCardNumber = Convert.ToString(outputs["BankCardNumber"]);
            }
            catch
            {
            }
            try
            {
                Balance = Convert.ToDouble(outputs["Balance"]);
            }
            catch
            {
            }
            try
            {
                Freeze = Convert.ToDouble(outputs["Freeze"]);
            }
            catch
            {
            }
            try
            {
                ScoringOfSelfBuy = Convert.ToDouble(outputs["ScoringOfSelfBuy"]);
            }
            catch
            {
            }
            try
            {
                ScoringOfCommendBuy = Convert.ToDouble(outputs["ScoringOfCommendBuy"]);
            }
            catch
            {
            }
            try
            {
                Scoring = Convert.ToDouble(outputs["Scoring"]);
            }
            catch
            {
            }
            try
            {
                Level = Convert.ToInt16(outputs["Level"]);
            }
            catch
            {
            }
            try
            {
                CommenderID = Convert.ToInt64(outputs["CommenderID"]);
            }
            catch
            {
            }
            try
            {
                CpsID = Convert.ToInt64(outputs["CpsID"]);
            }
            catch
            {
            }
            try
            {
                OwnerSites = Convert.ToString(outputs["OwnerSites"]);
            }
            catch
            {
            }
            try
            {
                AlipayID = Convert.ToString(outputs["AlipayID"]);
            }
            catch
            {
            }
            try
            {
                Bonus = Convert.ToDouble(outputs["Bonus"]);
            }
            catch
            {
            }
            try
            {
                Reward = Convert.ToDouble(outputs["Reward"]);
            }
            catch
            {
            }
            try
            {
                AlipayName = Convert.ToString(outputs["AlipayName"]);
            }
            catch
            {
            }
            try
            {
                isAlipayNameValided = Convert.ToBoolean(outputs["isAlipayNameValided"]);
            }
            catch
            {
            }
            try
            {
                ComeFrom = Convert.ToInt32(outputs["ComeFrom"]);
            }
            catch
            {
            }
            try
            {
                IsCrossLogin = Convert.ToBoolean(outputs["IsCrossLogin"]);
            }
            catch
            {
            }
            try
            {
                Memo = Convert.ToString(outputs["Memo"]);
            }
            catch
            {
            }
            try
            {
                BonusThisMonth = Convert.ToDouble(outputs["BonusThisMonth"]);
            }
            catch
            {
            }
            try
            {
                BonusAllow = Convert.ToDouble(outputs["BonusAllow"]);
            }
            catch
            {
            }
            try
            {
                BonusUse = Convert.ToDouble(outputs["BonusUse"]);
            }
            catch
            {
            }
            try
            {
                PromotionMemberBonusScale = Convert.ToDouble(outputs["PromotionMemberBonusScale"]);
            }
            catch
            {
            }
            try
            {
                PromotionSiteBonusScale = Convert.ToDouble(outputs["PromotionSiteBonusScale"]);
            }
            catch
            {
            }
            try
            {
                VisitSource = Convert.ToString(outputs["VisitSource"]);
            }
            catch
            {
            }
            try
            {
                HeadUrl = Convert.ToString(outputs["HeadUrl"]);
            }
            catch
            {
            }
            try
            {
                SecurityQuestion = Convert.ToString(outputs["SecurityQuestion"]);
            }
            catch
            {
            }
            try
            {
                SecurityAnswer = Convert.ToString(outputs["SecurityAnswer"]);
            }
            catch
            {
            }
            try
            {
                FriendList = Convert.ToString(outputs["FriendList"]);
            }
            catch
            {
            }
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetUserInformationByName(string Name, long SiteID, ref long UserID, ref string NickName, ref string RealityName, ref string Password, ref string PasswordAdv, ref int CityID, ref string Sex, ref DateTime BirthDay, ref string IDCardNumber, ref string Address, ref string Email, ref bool isEmailValided, ref string QQ, ref bool isQQValided, ref string Telephone, ref string Mobile, ref bool isMobileValided, ref bool isPrivacy, ref bool isCanLogin, ref DateTime RegisterTime, ref DateTime LastLoginTime, ref string LastLoginIP, ref int LoginCount, ref short UserType, ref short BankType, ref string BankName, ref string BankCardNumber, ref double Balance, ref double Freeze, ref double ScoringOfSelfBuy, ref double ScoringOfCommendBuy, ref double Scoring, ref short Level, ref long CommenderID, ref long CpsID, ref string OwnerSites, ref string AlipayID, ref double Bonus, ref double Reward, ref string AlipayName, ref bool isAlipayNameValided, ref int ComeFrom, ref bool IsCrossLogin, ref string Memo, ref double BonusThisMonth, ref double BonusAllow, ref double BonusUse, ref double PromotionMemberBonusScale, ref double PromotionSiteBonusScale, ref string VisitSource, ref string HeadUrl, ref string SecurityQuestion, ref string SecurityAnswer, ref string FriendList, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetUserInformationByName(ref ds, Name, SiteID, ref UserID, ref NickName, ref RealityName, ref Password, ref PasswordAdv, ref CityID, ref Sex, ref BirthDay, ref IDCardNumber, ref Address, ref Email, ref isEmailValided, ref QQ, ref isQQValided, ref Telephone, ref Mobile, ref isMobileValided, ref isPrivacy, ref isCanLogin, ref RegisterTime, ref LastLoginTime, ref LastLoginIP, ref LoginCount, ref UserType, ref BankType, ref BankName, ref BankCardNumber, ref Balance, ref Freeze, ref ScoringOfSelfBuy, ref ScoringOfCommendBuy, ref Scoring, ref Level, ref CommenderID, ref CpsID, ref OwnerSites, ref AlipayID, ref Bonus, ref Reward, ref AlipayName, ref isAlipayNameValided, ref ComeFrom, ref IsCrossLogin, ref Memo, ref BonusThisMonth, ref BonusAllow, ref BonusUse, ref PromotionMemberBonusScale, ref PromotionSiteBonusScale, ref VisitSource, ref HeadUrl, ref SecurityQuestion, ref SecurityAnswer, ref FriendList, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetUserInformationByName(ref DataSet ds, string Name, long SiteID, ref long UserID, ref string NickName, ref string RealityName, ref string Password, ref string PasswordAdv, ref int CityID, ref string Sex, ref DateTime BirthDay, ref string IDCardNumber, ref string Address, ref string Email, ref bool isEmailValided, ref string QQ, ref bool isQQValided, ref string Telephone, ref string Mobile, ref bool isMobileValided, ref bool isPrivacy, ref bool isCanLogin, ref DateTime RegisterTime, ref DateTime LastLoginTime, ref string LastLoginIP, ref int LoginCount, ref short UserType, ref short BankType, ref string BankName, ref string BankCardNumber, ref double Balance, ref double Freeze, ref double ScoringOfSelfBuy, ref double ScoringOfCommendBuy, ref double Scoring, ref short Level, ref long CommenderID, ref long CpsID, ref string OwnerSites, ref string AlipayID, ref double Bonus, ref double Reward, ref string AlipayName, ref bool isAlipayNameValided, ref int ComeFrom, ref bool IsCrossLogin, ref string Memo, ref double BonusThisMonth, ref double BonusAllow, ref double BonusUse, ref double PromotionMemberBonusScale, ref double PromotionSiteBonusScale, ref string VisitSource, ref string HeadUrl, ref string SecurityQuestion, ref string SecurityAnswer, ref string FriendList, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetUserInformationByName", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, Name), new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) UserID), new MSSQL.Parameter("NickName", SqlDbType.VarChar, 50, ParameterDirection.Output, NickName), new MSSQL.Parameter("RealityName", SqlDbType.VarChar, 50, ParameterDirection.Output, RealityName), new MSSQL.Parameter("Password", SqlDbType.VarChar, 0x20, ParameterDirection.Output, Password), new MSSQL.Parameter("PasswordAdv", SqlDbType.VarChar, 0x20, ParameterDirection.Output, PasswordAdv), new MSSQL.Parameter("CityID", SqlDbType.Int, 4, ParameterDirection.Output, (int) CityID), new MSSQL.Parameter("Sex", SqlDbType.VarChar, 2, ParameterDirection.Output, Sex), new MSSQL.Parameter("BirthDay", SqlDbType.DateTime, 8, ParameterDirection.Output, (DateTime) BirthDay), new MSSQL.Parameter("IDCardNumber", SqlDbType.VarChar, 50, ParameterDirection.Output, IDCardNumber), new MSSQL.Parameter("Address", SqlDbType.VarChar, 50, ParameterDirection.Output, Address), new MSSQL.Parameter("Email", SqlDbType.VarChar, 50, ParameterDirection.Output, Email), new MSSQL.Parameter("isEmailValided", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isEmailValided), new MSSQL.Parameter("QQ", SqlDbType.VarChar, 50, ParameterDirection.Output, QQ), new MSSQL.Parameter("isQQValided", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isQQValided), 
                new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 50, ParameterDirection.Output, Telephone), new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 50, ParameterDirection.Output, Mobile), new MSSQL.Parameter("isMobileValided", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isMobileValided), new MSSQL.Parameter("isPrivacy", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isPrivacy), new MSSQL.Parameter("isCanLogin", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isCanLogin), new MSSQL.Parameter("RegisterTime", SqlDbType.DateTime, 8, ParameterDirection.Output, (DateTime) RegisterTime), new MSSQL.Parameter("LastLoginTime", SqlDbType.DateTime, 8, ParameterDirection.Output, (DateTime) LastLoginTime), new MSSQL.Parameter("LastLoginIP", SqlDbType.VarChar, 50, ParameterDirection.Output, LastLoginIP), new MSSQL.Parameter("LoginCount", SqlDbType.Int, 4, ParameterDirection.Output, (int) LoginCount), new MSSQL.Parameter("UserType", SqlDbType.SmallInt, 2, ParameterDirection.Output, (short) UserType), new MSSQL.Parameter("BankType", SqlDbType.SmallInt, 2, ParameterDirection.Output, (short) BankType), new MSSQL.Parameter("BankName", SqlDbType.VarChar, 50, ParameterDirection.Output, BankName), new MSSQL.Parameter("BankCardNumber", SqlDbType.VarChar, 50, ParameterDirection.Output, BankCardNumber), new MSSQL.Parameter("Balance", SqlDbType.Money, 8, ParameterDirection.Output, (double) Balance), new MSSQL.Parameter("Freeze", SqlDbType.Money, 8, ParameterDirection.Output, (double) Freeze), new MSSQL.Parameter("ScoringOfSelfBuy", SqlDbType.Float, 8, ParameterDirection.Output, (double) ScoringOfSelfBuy), 
                new MSSQL.Parameter("ScoringOfCommendBuy", SqlDbType.Float, 8, ParameterDirection.Output, (double) ScoringOfCommendBuy), new MSSQL.Parameter("Scoring", SqlDbType.Float, 8, ParameterDirection.Output, (double) Scoring), new MSSQL.Parameter("Level", SqlDbType.SmallInt, 2, ParameterDirection.Output, (short) Level), new MSSQL.Parameter("CommenderID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) CommenderID), new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) CpsID), new MSSQL.Parameter("OwnerSites", SqlDbType.VarChar, 0x3e8, ParameterDirection.Output, OwnerSites), new MSSQL.Parameter("AlipayID", SqlDbType.VarChar, 0x20, ParameterDirection.Output, AlipayID), new MSSQL.Parameter("Bonus", SqlDbType.Money, 8, ParameterDirection.Output, (double) Bonus), new MSSQL.Parameter("Reward", SqlDbType.Money, 8, ParameterDirection.Output, (double) Reward), new MSSQL.Parameter("AlipayName", SqlDbType.VarChar, 50, ParameterDirection.Output, AlipayName), new MSSQL.Parameter("isAlipayNameValided", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isAlipayNameValided), new MSSQL.Parameter("ComeFrom", SqlDbType.Int, 4, ParameterDirection.Output, (int) ComeFrom), new MSSQL.Parameter("IsCrossLogin", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) IsCrossLogin), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 50, ParameterDirection.Output, Memo), new MSSQL.Parameter("BonusThisMonth", SqlDbType.Money, 8, ParameterDirection.Output, (double) BonusThisMonth), new MSSQL.Parameter("BonusAllow", SqlDbType.Money, 8, ParameterDirection.Output, (double) BonusAllow), 
                new MSSQL.Parameter("BonusUse", SqlDbType.Money, 8, ParameterDirection.Output, (double) BonusUse), new MSSQL.Parameter("PromotionMemberBonusScale", SqlDbType.Float, 8, ParameterDirection.Output, (double) PromotionMemberBonusScale), new MSSQL.Parameter("PromotionSiteBonusScale", SqlDbType.Float, 8, ParameterDirection.Output, (double) PromotionSiteBonusScale), new MSSQL.Parameter("VisitSource", SqlDbType.VarChar, 0xff, ParameterDirection.Output, VisitSource), new MSSQL.Parameter("HeadUrl", SqlDbType.VarChar, 500, ParameterDirection.Output, HeadUrl), new MSSQL.Parameter("SecurityQuestion", SqlDbType.VarChar, 100, ParameterDirection.Output, SecurityQuestion), new MSSQL.Parameter("SecurityAnswer", SqlDbType.VarChar, 50, ParameterDirection.Output, SecurityAnswer), new MSSQL.Parameter("FriendList", SqlDbType.VarChar, 0x3fffffff, ParameterDirection.Output, FriendList), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                UserID = Convert.ToInt64(outputs["UserID"]);
            }
            catch
            {
            }
            try
            {
                NickName = Convert.ToString(outputs["NickName"]);
            }
            catch
            {
            }
            try
            {
                RealityName = Convert.ToString(outputs["RealityName"]);
            }
            catch
            {
            }
            try
            {
                Password = Convert.ToString(outputs["Password"]);
            }
            catch
            {
            }
            try
            {
                PasswordAdv = Convert.ToString(outputs["PasswordAdv"]);
            }
            catch
            {
            }
            try
            {
                CityID = Convert.ToInt32(outputs["CityID"]);
            }
            catch
            {
            }
            try
            {
                Sex = Convert.ToString(outputs["Sex"]);
            }
            catch
            {
            }
            try
            {
                BirthDay = Convert.ToDateTime(outputs["BirthDay"]);
            }
            catch
            {
            }
            try
            {
                IDCardNumber = Convert.ToString(outputs["IDCardNumber"]);
            }
            catch
            {
            }
            try
            {
                Address = Convert.ToString(outputs["Address"]);
            }
            catch
            {
            }
            try
            {
                Email = Convert.ToString(outputs["Email"]);
            }
            catch
            {
            }
            try
            {
                isEmailValided = Convert.ToBoolean(outputs["isEmailValided"]);
            }
            catch
            {
            }
            try
            {
                QQ = Convert.ToString(outputs["QQ"]);
            }
            catch
            {
            }
            try
            {
                isQQValided = Convert.ToBoolean(outputs["isQQValided"]);
            }
            catch
            {
            }
            try
            {
                Telephone = Convert.ToString(outputs["Telephone"]);
            }
            catch
            {
            }
            try
            {
                Mobile = Convert.ToString(outputs["Mobile"]);
            }
            catch
            {
            }
            try
            {
                isMobileValided = Convert.ToBoolean(outputs["isMobileValided"]);
            }
            catch
            {
            }
            try
            {
                isPrivacy = Convert.ToBoolean(outputs["isPrivacy"]);
            }
            catch
            {
            }
            try
            {
                isCanLogin = Convert.ToBoolean(outputs["isCanLogin"]);
            }
            catch
            {
            }
            try
            {
                RegisterTime = Convert.ToDateTime(outputs["RegisterTime"]);
            }
            catch
            {
            }
            try
            {
                LastLoginTime = Convert.ToDateTime(outputs["LastLoginTime"]);
            }
            catch
            {
            }
            try
            {
                LastLoginIP = Convert.ToString(outputs["LastLoginIP"]);
            }
            catch
            {
            }
            try
            {
                LoginCount = Convert.ToInt32(outputs["LoginCount"]);
            }
            catch
            {
            }
            try
            {
                UserType = Convert.ToInt16(outputs["UserType"]);
            }
            catch
            {
            }
            try
            {
                BankType = Convert.ToInt16(outputs["BankType"]);
            }
            catch
            {
            }
            try
            {
                BankName = Convert.ToString(outputs["BankName"]);
            }
            catch
            {
            }
            try
            {
                BankCardNumber = Convert.ToString(outputs["BankCardNumber"]);
            }
            catch
            {
            }
            try
            {
                Balance = Convert.ToDouble(outputs["Balance"]);
            }
            catch
            {
            }
            try
            {
                Freeze = Convert.ToDouble(outputs["Freeze"]);
            }
            catch
            {
            }
            try
            {
                ScoringOfSelfBuy = Convert.ToDouble(outputs["ScoringOfSelfBuy"]);
            }
            catch
            {
            }
            try
            {
                ScoringOfCommendBuy = Convert.ToDouble(outputs["ScoringOfCommendBuy"]);
            }
            catch
            {
            }
            try
            {
                Scoring = Convert.ToDouble(outputs["Scoring"]);
            }
            catch
            {
            }
            try
            {
                Level = Convert.ToInt16(outputs["Level"]);
            }
            catch
            {
            }
            try
            {
                CommenderID = Convert.ToInt64(outputs["CommenderID"]);
            }
            catch
            {
            }
            try
            {
                CpsID = Convert.ToInt64(outputs["CpsID"]);
            }
            catch
            {
            }
            try
            {
                OwnerSites = Convert.ToString(outputs["OwnerSites"]);
            }
            catch
            {
            }
            try
            {
                AlipayID = Convert.ToString(outputs["AlipayID"]);
            }
            catch
            {
            }
            try
            {
                Bonus = Convert.ToDouble(outputs["Bonus"]);
            }
            catch
            {
            }
            try
            {
                Reward = Convert.ToDouble(outputs["Reward"]);
            }
            catch
            {
            }
            try
            {
                AlipayName = Convert.ToString(outputs["AlipayName"]);
            }
            catch
            {
            }
            try
            {
                isAlipayNameValided = Convert.ToBoolean(outputs["isAlipayNameValided"]);
            }
            catch
            {
            }
            try
            {
                ComeFrom = Convert.ToInt32(outputs["ComeFrom"]);
            }
            catch
            {
            }
            try
            {
                IsCrossLogin = Convert.ToBoolean(outputs["IsCrossLogin"]);
            }
            catch
            {
            }
            try
            {
                Memo = Convert.ToString(outputs["Memo"]);
            }
            catch
            {
            }
            try
            {
                BonusThisMonth = Convert.ToDouble(outputs["BonusThisMonth"]);
            }
            catch
            {
            }
            try
            {
                BonusAllow = Convert.ToDouble(outputs["BonusAllow"]);
            }
            catch
            {
            }
            try
            {
                BonusUse = Convert.ToDouble(outputs["BonusUse"]);
            }
            catch
            {
            }
            try
            {
                PromotionMemberBonusScale = Convert.ToDouble(outputs["PromotionMemberBonusScale"]);
            }
            catch
            {
            }
            try
            {
                PromotionSiteBonusScale = Convert.ToDouble(outputs["PromotionSiteBonusScale"]);
            }
            catch
            {
            }
            try
            {
                VisitSource = Convert.ToString(outputs["VisitSource"]);
            }
            catch
            {
            }
            try
            {
                HeadUrl = Convert.ToString(outputs["HeadUrl"]);
            }
            catch
            {
            }
            try
            {
                SecurityQuestion = Convert.ToString(outputs["SecurityQuestion"]);
            }
            catch
            {
            }
            try
            {
                SecurityAnswer = Convert.ToString(outputs["SecurityAnswer"]);
            }
            catch
            {
            }
            try
            {
                FriendList = Convert.ToString(outputs["FriendList"]);
            }
            catch
            {
            }
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetUserIsAwardwinning(string AlipayName, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetUserIsAwardwinning(ref ds, AlipayName, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetUserIsAwardwinning(ref DataSet ds, string AlipayName, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetUserIsAwardwinning", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("AlipayName", SqlDbType.VarChar, 0, ParameterDirection.Input, AlipayName), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetUserScoringDetail(long SiteID, long UserID, int Year, int Month, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetUserScoringDetail(ref ds, SiteID, UserID, Year, Month, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetUserScoringDetail(ref DataSet ds, long SiteID, long UserID, int Year, int Month, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetUserScoringDetail", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Year", SqlDbType.Int, 0, ParameterDirection.Input, Year), new MSSQL.Parameter("Month", SqlDbType.Int, 0, ParameterDirection.Input, Month), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetUserSMSDetail(long SiteID, long UserID, int Year, int Month, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetUserSMSDetail(ref ds, SiteID, UserID, Year, Month, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetUserSMSDetail(ref DataSet ds, long SiteID, long UserID, int Year, int Month, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetUserSMSDetail", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Year", SqlDbType.Int, 0, ParameterDirection.Input, Year), new MSSQL.Parameter("Month", SqlDbType.Int, 0, ParameterDirection.Input, Month), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetWinLotteryNumber(long SiteID, int LotteryID, int IsuseCount, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetWinLotteryNumber(ref ds, SiteID, LotteryID, IsuseCount, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetWinLotteryNumber(ref DataSet ds, long SiteID, int LotteryID, int IsuseCount, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetWinLotteryNumber", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID), new MSSQL.Parameter("IsuseCount", SqlDbType.Int, 0, ParameterDirection.Input, IsuseCount), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_GetZCDCSPFMessage(string IsuseName, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_GetZCDCSPFMessage(ref ds, IsuseName, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_GetZCDCSPFMessage(ref DataSet ds, string IsuseName, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_GetZCDCSPFMessage", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseName", SqlDbType.VarChar, 0, ParameterDirection.Input, IsuseName), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_InitializationData(string CallPassword, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_InitializationData(ref ds, CallPassword, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_InitializationData(ref DataSet ds, string CallPassword, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_InitializationData", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("CallPassword", SqlDbType.VarChar, 0, ParameterDirection.Input, CallPassword), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_InitializationSiteTemplates(long SiteID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_InitializationSiteTemplates(ref ds, SiteID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_InitializationSiteTemplates(ref DataSet ds, long SiteID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_InitializationSiteTemplates", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_InitiateChaseTask(long SiteID, long UserID, string Title, string Description, int LotteryID, double StopWhenWinMoney, string DetailXML, string LotteryNumber, double SchemeBonusScale, ref long ChaseTaskID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_InitiateChaseTask(ref ds, SiteID, UserID, Title, Description, LotteryID, StopWhenWinMoney, DetailXML, LotteryNumber, SchemeBonusScale, ref ChaseTaskID, ref ReturnDescription);
        }

        public static int P_InitiateChaseTask(ref DataSet ds, long SiteID, long UserID, string Title, string Description, int LotteryID, double StopWhenWinMoney, string DetailXML, string LotteryNumber, double SchemeBonusScale, ref long ChaseTaskID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_InitiateChaseTask", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Description", SqlDbType.VarChar, 0, ParameterDirection.Input, Description), new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID), new MSSQL.Parameter("StopWhenWinMoney", SqlDbType.Money, 0, ParameterDirection.Input, StopWhenWinMoney), new MSSQL.Parameter("DetailXML", SqlDbType.NText, 0, ParameterDirection.Input, DetailXML), new MSSQL.Parameter("LotteryNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, LotteryNumber), new MSSQL.Parameter("SchemeBonusScale", SqlDbType.Float, 0, ParameterDirection.Input, SchemeBonusScale), new MSSQL.Parameter("ChaseTaskID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) ChaseTaskID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ChaseTaskID = Convert.ToInt64(outputs["ChaseTaskID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_InitiateScheme(long SiteID, long UserID, long IsuseID, int PlayTypeID, string Title, string Description, string LotteryNumber, string UploadFileContent, int Multiple, double Money, double AssureMoney, int Share, int BuyShare, string OpenUsers, short SecrecyLevel, double SchemeBonusScale, ref long SchemeID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_InitiateScheme(ref ds, SiteID, UserID, IsuseID, PlayTypeID, Title, Description, LotteryNumber, UploadFileContent, Multiple, Money, AssureMoney, Share, BuyShare, OpenUsers, SecrecyLevel, SchemeBonusScale, ref SchemeID, ref ReturnDescription);
        }

        public static int P_InitiateScheme(ref DataSet ds, long SiteID, long UserID, long IsuseID, int PlayTypeID, string Title, string Description, string LotteryNumber, string UploadFileContent, int Multiple, double Money, double AssureMoney, int Share, int BuyShare, string OpenUsers, short SecrecyLevel, double SchemeBonusScale, ref long SchemeID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_InitiateScheme", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID), new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, PlayTypeID), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Description", SqlDbType.VarChar, 0, ParameterDirection.Input, Description), new MSSQL.Parameter("LotteryNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, LotteryNumber), new MSSQL.Parameter("UploadFileContent", SqlDbType.VarChar, 0, ParameterDirection.Input, UploadFileContent), new MSSQL.Parameter("Multiple", SqlDbType.Int, 0, ParameterDirection.Input, Multiple), new MSSQL.Parameter("Money", SqlDbType.Money, 0, ParameterDirection.Input, Money), new MSSQL.Parameter("AssureMoney", SqlDbType.Money, 0, ParameterDirection.Input, AssureMoney), new MSSQL.Parameter("Share", SqlDbType.Int, 0, ParameterDirection.Input, Share), new MSSQL.Parameter("BuyShare", SqlDbType.Int, 0, ParameterDirection.Input, BuyShare), new MSSQL.Parameter("OpenUsers", SqlDbType.VarChar, 0, ParameterDirection.Input, OpenUsers), new MSSQL.Parameter("SecrecyLevel", SqlDbType.SmallInt, 0, ParameterDirection.Input, SecrecyLevel), new MSSQL.Parameter("SchemeBonusScale", SqlDbType.Float, 0, ParameterDirection.Input, SchemeBonusScale), 
                new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) SchemeID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                SchemeID = Convert.ToInt64(outputs["SchemeID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_InquirySchemesHandle(string CounterAnteId, string DealTime, short HandleResult, string HandleDescription, short PrintOutType, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_InquirySchemesHandle(ref ds, CounterAnteId, DealTime, HandleResult, HandleDescription, PrintOutType, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_InquirySchemesHandle(ref DataSet ds, string CounterAnteId, string DealTime, short HandleResult, string HandleDescription, short PrintOutType, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_InquirySchemesHandle", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("CounterAnteId", SqlDbType.VarChar, 0, ParameterDirection.Input, CounterAnteId), new MSSQL.Parameter("DealTime", SqlDbType.VarChar, 0, ParameterDirection.Input, DealTime), new MSSQL.Parameter("HandleResult", SqlDbType.SmallInt, 0, ParameterDirection.Input, HandleResult), new MSSQL.Parameter("HandleDescription", SqlDbType.VarChar, 0, ParameterDirection.Input, HandleDescription), new MSSQL.Parameter("PrintOutType", SqlDbType.SmallInt, 0, ParameterDirection.Input, PrintOutType), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_IsuseAdd(int LotteryID, string Name, DateTime StartTime, DateTime EndTime, string AdditionalXML, ref long IsuseID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_IsuseAdd(ref ds, LotteryID, Name, StartTime, EndTime, AdditionalXML, ref IsuseID, ref ReturnDescription);
        }

        public static int P_IsuseAdd(ref DataSet ds, int LotteryID, string Name, DateTime StartTime, DateTime EndTime, string AdditionalXML, ref long IsuseID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_IsuseAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, Name), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("AdditionalXML", SqlDbType.NText, 0, ParameterDirection.Input, AdditionalXML), new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) IsuseID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                IsuseID = Convert.ToInt64(outputs["IsuseID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_IsuseBonusesAdd(long IsuseId, long UserID, string WinListXML, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_IsuseBonusesAdd(ref ds, IsuseId, UserID, WinListXML, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_IsuseBonusesAdd(ref DataSet ds, long IsuseId, long UserID, string WinListXML, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_IsuseBonusesAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseId", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseId), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("WinListXML", SqlDbType.NText, 0, ParameterDirection.Input, WinListXML), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_IsuseEdit(long IsuseID, string Name, DateTime StartTime, DateTime EndTime, string AdditionalXML, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_IsuseEdit(ref ds, IsuseID, Name, StartTime, EndTime, AdditionalXML, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_IsuseEdit(ref DataSet ds, long IsuseID, string Name, DateTime StartTime, DateTime EndTime, string AdditionalXML, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_IsuseEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, Name), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("AdditionalXML", SqlDbType.NText, 0, ParameterDirection.Input, AdditionalXML), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_IsuseEndTime(ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_IsuseEndTime(ref ds, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_IsuseEndTime(ref DataSet ds, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_IsuseEndTime", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_IsuseInsertOneResultForZCDC(long ID, string HalftimeResult, string Result, string LetBall, string SPFResult, double SPF_Sp, string ZJQResult, double ZJQ_Sp, string SXDSResult, double SXDS_Sp, string ZQBFResult, double ZQBF_Sp, string BQCSPFResult, double BQCSPF_Sp, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_IsuseInsertOneResultForZCDC(ref ds, ID, HalftimeResult, Result, LetBall, SPFResult, SPF_Sp, ZJQResult, ZJQ_Sp, SXDSResult, SXDS_Sp, ZQBFResult, ZQBF_Sp, BQCSPFResult, BQCSPF_Sp, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_IsuseInsertOneResultForZCDC(ref DataSet ds, long ID, string HalftimeResult, string Result, string LetBall, string SPFResult, double SPF_Sp, string ZJQResult, double ZJQ_Sp, string SXDSResult, double SXDS_Sp, string ZQBFResult, double ZQBF_Sp, string BQCSPFResult, double BQCSPF_Sp, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_IsuseInsertOneResultForZCDC", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("HalftimeResult", SqlDbType.VarChar, 0, ParameterDirection.Input, HalftimeResult), new MSSQL.Parameter("Result", SqlDbType.VarChar, 0, ParameterDirection.Input, Result), new MSSQL.Parameter("LetBall", SqlDbType.VarChar, 0, ParameterDirection.Input, LetBall), new MSSQL.Parameter("SPFResult", SqlDbType.VarChar, 0, ParameterDirection.Input, SPFResult), new MSSQL.Parameter("SPF_Sp", SqlDbType.Float, 0, ParameterDirection.Input, SPF_Sp), new MSSQL.Parameter("ZJQResult", SqlDbType.VarChar, 0, ParameterDirection.Input, ZJQResult), new MSSQL.Parameter("ZJQ_Sp", SqlDbType.Float, 0, ParameterDirection.Input, ZJQ_Sp), new MSSQL.Parameter("SXDSResult", SqlDbType.VarChar, 0, ParameterDirection.Input, SXDSResult), new MSSQL.Parameter("SXDS_Sp", SqlDbType.Float, 0, ParameterDirection.Input, SXDS_Sp), new MSSQL.Parameter("ZQBFResult", SqlDbType.VarChar, 0, ParameterDirection.Input, ZQBFResult), new MSSQL.Parameter("ZQBF_Sp", SqlDbType.Float, 0, ParameterDirection.Input, ZQBF_Sp), new MSSQL.Parameter("BQCSPFResult", SqlDbType.VarChar, 0, ParameterDirection.Input, BQCSPFResult), new MSSQL.Parameter("BQCSPF_Sp", SqlDbType.Float, 0, ParameterDirection.Input, BQCSPF_Sp), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_IsuseUpdate(int LotteryID, string IsuseName, short State, DateTime StartTime, DateTime EndTime, DateTime StateUpdateTime, string WinLotteryNumber, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_IsuseUpdate(ref ds, LotteryID, IsuseName, State, StartTime, EndTime, StateUpdateTime, WinLotteryNumber, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_IsuseUpdate(ref DataSet ds, int LotteryID, string IsuseName, short State, DateTime StartTime, DateTime EndTime, DateTime StateUpdateTime, string WinLotteryNumber, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_IsuseUpdate", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID), new MSSQL.Parameter("IsuseName", SqlDbType.VarChar, 0, ParameterDirection.Input, IsuseName), new MSSQL.Parameter("State", SqlDbType.SmallInt, 0, ParameterDirection.Input, State), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("StateUpdateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StateUpdateTime), new MSSQL.Parameter("WinLotteryNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, WinLotteryNumber), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_JoinScheme(long SiteID, long UserID, long SchemeID, int Share, bool isAutoFollowScheme, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_JoinScheme(ref ds, SiteID, UserID, SchemeID, Share, isAutoFollowScheme, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_JoinScheme(ref DataSet ds, long SiteID, long UserID, long SchemeID, int Share, bool isAutoFollowScheme, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_JoinScheme", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("Share", SqlDbType.Int, 0, ParameterDirection.Input, Share), new MSSQL.Parameter("isAutoFollowScheme", SqlDbType.Bit, 0, ParameterDirection.Input, isAutoFollowScheme), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_LeaveSchemeChatRoom(long SiteID, long UserID, long SchemeID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_LeaveSchemeChatRoom(ref ds, SiteID, UserID, SchemeID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_LeaveSchemeChatRoom(ref DataSet ds, long SiteID, long UserID, long SchemeID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_LeaveSchemeChatRoom", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_Login(long SiteID, string Name, string InputPassword, string LoginIP, ref long UserID, ref string PasswordAdv, ref string RealityName, ref int CityID, ref string Sex, ref DateTime BirthDay, ref string IDCardNumber, ref string Address, ref string Email, ref bool isEmailValided, ref string QQ, ref bool isQQValided, ref string Telephone, ref string Mobile, ref bool isMobileValided, ref bool isPrivacy, ref bool isCanLogin, ref DateTime RegisterTime, ref DateTime LastLoginTime, ref string LastLoginIP, ref int LoginCount, ref short UserType, ref short BankType, ref string BankName, ref string BankCardNumber, ref double Balance,ref double CarPasswordM, ref double Freeze, ref double ScoringOfSelfBuy, ref double ScoringOfCommendBuy, ref double Scoring, ref short Level, ref long CommenderID, ref long CpsID, ref string AlipayID, ref string AlipayName, ref bool isAlipayNameValided, ref double Bonus, ref double Reward, ref string Memo, ref double BonusThisMonth, ref double BonusAllow, ref double BonusUse, ref double PromotionMemberBonusScale, ref double PromotionSiteBonusScale, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_Login(ref ds, SiteID, Name, InputPassword, LoginIP, ref UserID, ref PasswordAdv, ref RealityName, ref CityID, ref Sex, ref BirthDay, ref IDCardNumber, ref Address, ref Email, ref isEmailValided, ref QQ, ref isQQValided, ref Telephone, ref Mobile, ref isMobileValided, ref isPrivacy, ref isCanLogin, ref RegisterTime, ref LastLoginTime, ref LastLoginIP, ref LoginCount, ref UserType, ref BankType, ref BankName, ref BankCardNumber, ref Balance,ref CarPasswordM, ref Freeze, ref ScoringOfSelfBuy, ref ScoringOfCommendBuy, ref Scoring, ref Level, ref CommenderID, ref CpsID, ref AlipayID, ref AlipayName, ref isAlipayNameValided, ref Bonus, ref Reward, ref Memo, ref BonusThisMonth, ref BonusAllow, ref BonusUse, ref PromotionMemberBonusScale, ref PromotionSiteBonusScale, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_Login(ref DataSet ds, long SiteID, string Name, string InputPassword, string LoginIP, ref long UserID, ref string PasswordAdv, ref string RealityName, ref int CityID, ref string Sex, ref DateTime BirthDay, ref string IDCardNumber, ref string Address, ref string Email, ref bool isEmailValided, ref string QQ, ref bool isQQValided, ref string Telephone, ref string Mobile, ref bool isMobileValided, ref bool isPrivacy, ref bool isCanLogin, ref DateTime RegisterTime, ref DateTime LastLoginTime, ref string LastLoginIP, ref int LoginCount, ref short UserType, ref short BankType, ref string BankName, ref string BankCardNumber, ref double Balance, ref double CardPasswordM,ref double Freeze, ref double ScoringOfSelfBuy, ref double ScoringOfCommendBuy, ref double Scoring, ref short Level, ref long CommenderID, ref long CpsID, ref string AlipayID, ref string AlipayName, ref bool isAlipayNameValided, ref double Bonus, ref double Reward, ref string Memo, ref double BonusThisMonth, ref double BonusAllow, ref double BonusUse, ref double PromotionMemberBonusScale, ref double PromotionSiteBonusScale, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();

            MSSQL.Parameter[] paras=new MSSQL.Parameter[] { 
                new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, Name), new MSSQL.Parameter("InputPassword", SqlDbType.VarChar, 0, ParameterDirection.Input, InputPassword), new MSSQL.Parameter("LoginIP", SqlDbType.VarChar, 0, ParameterDirection.Input, LoginIP), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) UserID), new MSSQL.Parameter("PasswordAdv", SqlDbType.VarChar, 0x20, ParameterDirection.Output, PasswordAdv), new MSSQL.Parameter("RealityName", SqlDbType.VarChar, 50, ParameterDirection.Output, RealityName), new MSSQL.Parameter("CityID", SqlDbType.Int, 4, ParameterDirection.Output, (int) CityID), new MSSQL.Parameter("Sex", SqlDbType.VarChar, 2, ParameterDirection.Output, Sex), new MSSQL.Parameter("BirthDay", SqlDbType.DateTime, 8, ParameterDirection.Output, (DateTime) BirthDay), new MSSQL.Parameter("IDCardNumber", SqlDbType.VarChar, 50, ParameterDirection.Output, IDCardNumber), new MSSQL.Parameter("Address", SqlDbType.VarChar, 50, ParameterDirection.Output, Address), new MSSQL.Parameter("Email", SqlDbType.VarChar, 50, ParameterDirection.Output, Email), new MSSQL.Parameter("isEmailValided", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isEmailValided), new MSSQL.Parameter("QQ", SqlDbType.VarChar, 50, ParameterDirection.Output, QQ), new MSSQL.Parameter("isQQValided", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isQQValided), 
                new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 50, ParameterDirection.Output, Telephone), new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 50, ParameterDirection.Output, Mobile), new MSSQL.Parameter("isMobileValided", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isMobileValided), new MSSQL.Parameter("isPrivacy", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isPrivacy), new MSSQL.Parameter("isCanLogin", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isCanLogin), new MSSQL.Parameter("RegisterTime", SqlDbType.DateTime, 8, ParameterDirection.Output, (DateTime) RegisterTime), new MSSQL.Parameter("LastLoginTime", SqlDbType.DateTime, 8, ParameterDirection.Output, (DateTime) LastLoginTime), new MSSQL.Parameter("LastLoginIP", SqlDbType.VarChar, 50, ParameterDirection.Output, LastLoginIP), new MSSQL.Parameter("LoginCount", SqlDbType.Int, 4, ParameterDirection.Output, (int) LoginCount), new MSSQL.Parameter("UserType", SqlDbType.SmallInt, 2, ParameterDirection.Output, (short) UserType), new MSSQL.Parameter("BankType", SqlDbType.SmallInt, 2, ParameterDirection.Output, (short) BankType), new MSSQL.Parameter("BankName", SqlDbType.VarChar, 50, ParameterDirection.Output, BankName), new MSSQL.Parameter("BankCardNumber", SqlDbType.VarChar, 50, ParameterDirection.Output, BankCardNumber), new MSSQL.Parameter("Balance", SqlDbType.Money, 8, ParameterDirection.Output, (double) Balance),new MSSQL.Parameter("CardPassword", SqlDbType.Money, 8, ParameterDirection.Output, (double)CardPasswordM), new MSSQL.Parameter("Freeze", SqlDbType.Money, 8, ParameterDirection.Output, (double) Freeze), new MSSQL.Parameter("ScoringOfSelfBuy", SqlDbType.Float, 8, ParameterDirection.Output, (double) ScoringOfSelfBuy), 
                new MSSQL.Parameter("ScoringOfCommendBuy", SqlDbType.Float, 8, ParameterDirection.Output, (double) ScoringOfCommendBuy), new MSSQL.Parameter("Scoring", SqlDbType.Float, 8, ParameterDirection.Output, (double) Scoring), new MSSQL.Parameter("Level", SqlDbType.SmallInt, 2, ParameterDirection.Output, (short) Level), new MSSQL.Parameter("CommenderID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) CommenderID), new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) CpsID), new MSSQL.Parameter("AlipayID", SqlDbType.VarChar, 0x20, ParameterDirection.Output, AlipayID), new MSSQL.Parameter("AlipayName", SqlDbType.VarChar, 50, ParameterDirection.Output, AlipayName), new MSSQL.Parameter("isAlipayNameValided", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isAlipayNameValided), new MSSQL.Parameter("Bonus", SqlDbType.Money, 8, ParameterDirection.Output, (double) Bonus), new MSSQL.Parameter("Reward", SqlDbType.Money, 8, ParameterDirection.Output, (double) Reward), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 50, ParameterDirection.Output, Memo), new MSSQL.Parameter("BonusThisMonth", SqlDbType.Money, 8, ParameterDirection.Output, (double) BonusThisMonth), new MSSQL.Parameter("BonusAllow", SqlDbType.Money, 8, ParameterDirection.Output, (double) BonusAllow), new MSSQL.Parameter("BonusUse", SqlDbType.Money, 8, ParameterDirection.Output, (double) BonusUse), new MSSQL.Parameter("PromotionMemberBonusScale", SqlDbType.Float, 8, ParameterDirection.Output, (double) PromotionMemberBonusScale), new MSSQL.Parameter("PromotionSiteBonusScale", SqlDbType.Float, 8, ParameterDirection.Output, (double) PromotionSiteBonusScale), 
                new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             };

            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_Login", ref ds, ref outputs,paras );
            try
            {
                UserID = Convert.ToInt64(outputs["UserID"]);
            }
            catch
            {
            }
            try
            {
                PasswordAdv = Convert.ToString(outputs["PasswordAdv"]);
            }
            catch
            {
            }
            try
            {
                RealityName = Convert.ToString(outputs["RealityName"]);
            }
            catch
            {
            }
            try
            {
                CityID = Convert.ToInt32(outputs["CityID"]);
            }
            catch
            {
            }
            try
            {
                Sex = Convert.ToString(outputs["Sex"]);
            }
            catch
            {
            }
            try
            {
                BirthDay = Convert.ToDateTime(outputs["BirthDay"]);
            }
            catch
            {
            }
            try
            {
                IDCardNumber = Convert.ToString(outputs["IDCardNumber"]);
            }
            catch
            {
            }
            try
            {
                Address = Convert.ToString(outputs["Address"]);
            }
            catch
            {
            }
            try
            {
                Email = Convert.ToString(outputs["Email"]);
            }
            catch
            {
            }
            try
            {
                isEmailValided = Convert.ToBoolean(outputs["isEmailValided"]);
            }
            catch
            {
            }
            try
            {
                QQ = Convert.ToString(outputs["QQ"]);
            }
            catch
            {
            }
            try
            {
                isQQValided = Convert.ToBoolean(outputs["isQQValided"]);
            }
            catch
            {
            }
            try
            {
                Telephone = Convert.ToString(outputs["Telephone"]);
            }
            catch
            {
            }
            try
            {
                Mobile = Convert.ToString(outputs["Mobile"]);
            }
            catch
            {
            }
            try
            {
                isMobileValided = Convert.ToBoolean(outputs["isMobileValided"]);
            }
            catch
            {
            }
            try
            {
                isPrivacy = Convert.ToBoolean(outputs["isPrivacy"]);
            }
            catch
            {
            }
            try
            {
                isCanLogin = Convert.ToBoolean(outputs["isCanLogin"]);
            }
            catch
            {
            }
            try
            {
                RegisterTime = Convert.ToDateTime(outputs["RegisterTime"]);
            }
            catch
            {
            }
            try
            {
                LastLoginTime = Convert.ToDateTime(outputs["LastLoginTime"]);
            }
            catch
            {
            }
            try
            {
                LastLoginIP = Convert.ToString(outputs["LastLoginIP"]);
            }
            catch
            {
            }
            try
            {
                LoginCount = Convert.ToInt32(outputs["LoginCount"]);
            }
            catch
            {
            }
            try
            {
                UserType = Convert.ToInt16(outputs["UserType"]);
            }
            catch
            {
            }
            try
            {
                BankType = Convert.ToInt16(outputs["BankType"]);
            }
            catch
            {
            }
            try
            {
                BankName = Convert.ToString(outputs["BankName"]);
            }
            catch
            {
            }
            try
            {
                BankCardNumber = Convert.ToString(outputs["BankCardNumber"]);
            }
            catch
            {
            }
            try
            {
                Balance = Convert.ToDouble(outputs["Balance"]);
            }
            catch
            {
            }
            try
            {
                Freeze = Convert.ToDouble(outputs["Freeze"]);
            }
            catch
            {
            }
            try
            {
                ScoringOfSelfBuy = Convert.ToDouble(outputs["ScoringOfSelfBuy"]);
            }
            catch
            {
            }
            try
            {
                ScoringOfCommendBuy = Convert.ToDouble(outputs["ScoringOfCommendBuy"]);
            }
            catch
            {
            }
            try
            {
                Scoring = Convert.ToDouble(outputs["Scoring"]);
            }
            catch
            {
            }
            try
            {
                Level = Convert.ToInt16(outputs["Level"]);
            }
            catch
            {
            }
            try
            {
                CommenderID = Convert.ToInt64(outputs["CommenderID"]);
            }
            catch
            {
            }
            try
            {
                CpsID = Convert.ToInt64(outputs["CpsID"]);
            }
            catch
            {
            }
            try
            {
                AlipayID = Convert.ToString(outputs["AlipayID"]);
            }
            catch
            {
            }
            try
            {
                AlipayName = Convert.ToString(outputs["AlipayName"]);
            }
            catch
            {
            }
            try
            {
                isAlipayNameValided = Convert.ToBoolean(outputs["isAlipayNameValided"]);
            }
            catch
            {
            }
            try
            {
                Bonus = Convert.ToDouble(outputs["Bonus"]);
            }
            catch
            {
            }
            try
            {
                Reward = Convert.ToDouble(outputs["Reward"]);
            }
            catch
            {
            }
            try
            {
                Memo = Convert.ToString(outputs["Memo"]);
            }
            catch
            {
            }
            try
            {
                BonusThisMonth = Convert.ToDouble(outputs["BonusThisMonth"]);
            }
            catch
            {
            }
            try
            {
                BonusAllow = Convert.ToDouble(outputs["BonusAllow"]);
            }
            catch
            {
            }
            try
            {
                BonusUse = Convert.ToDouble(outputs["BonusUse"]);
            }
            catch
            {
            }
            try
            {
                PromotionMemberBonusScale = Convert.ToDouble(outputs["PromotionMemberBonusScale"]);
            }
            catch
            {
            }
            try
            {
                PromotionSiteBonusScale = Convert.ToDouble(outputs["PromotionSiteBonusScale"]);
            }
            catch
            {
            }
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_LotteryToolLinkAdd(long SiteID, int LotteryID, string LinkName, string LogoUrl, string Url, int Order, bool isShow, ref long NewLotteryToolLinkID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_LotteryToolLinkAdd(ref ds, SiteID, LotteryID, LinkName, LogoUrl, Url, Order, isShow, ref NewLotteryToolLinkID, ref ReturnDescription);
        }

        public static int P_LotteryToolLinkAdd(ref DataSet ds, long SiteID, int LotteryID, string LinkName, string LogoUrl, string Url, int Order, bool isShow, ref long NewLotteryToolLinkID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_LotteryToolLinkAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID), new MSSQL.Parameter("LinkName", SqlDbType.VarChar, 0, ParameterDirection.Input, LinkName), new MSSQL.Parameter("LogoUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, LogoUrl), new MSSQL.Parameter("Url", SqlDbType.VarChar, 0, ParameterDirection.Input, Url), new MSSQL.Parameter("Order", SqlDbType.Int, 0, ParameterDirection.Input, Order), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("NewLotteryToolLinkID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewLotteryToolLinkID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                NewLotteryToolLinkID = Convert.ToInt64(outputs["NewLotteryToolLinkID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_LotteryToolLinkDelete(long SiteID, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_LotteryToolLinkDelete(ref ds, SiteID, ID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_LotteryToolLinkDelete(ref DataSet ds, long SiteID, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_LotteryToolLinkDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_LotteryToolLinkEdit(long SiteID, long ID, int LotteryID, string LinkName, string LogoUrl, string Url, int Order, bool isShow, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_LotteryToolLinkEdit(ref ds, SiteID, ID, LotteryID, LinkName, LogoUrl, Url, Order, isShow, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_LotteryToolLinkEdit(ref DataSet ds, long SiteID, long ID, int LotteryID, string LinkName, string LogoUrl, string Url, int Order, bool isShow, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_LotteryToolLinkEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID), new MSSQL.Parameter("LinkName", SqlDbType.VarChar, 0, ParameterDirection.Input, LinkName), new MSSQL.Parameter("LogoUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, LogoUrl), new MSSQL.Parameter("Url", SqlDbType.VarChar, 0, ParameterDirection.Input, Url), new MSSQL.Parameter("Order", SqlDbType.Int, 0, ParameterDirection.Input, Order), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_MarketOutlookAdd(DateTime DateTime, string Title, string Content, bool isShow, ref long NewMarketOutlookID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_MarketOutlookAdd(ref ds, DateTime, Title, Content, isShow, ref NewMarketOutlookID, ref ReturnDescription);
        }

        public static int P_MarketOutlookAdd(ref DataSet ds, DateTime DateTime, string Title, string Content, bool isShow, ref long NewMarketOutlookID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_MarketOutlookAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("NewMarketOutlookID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewMarketOutlookID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                NewMarketOutlookID = Convert.ToInt64(outputs["NewMarketOutlookID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_MarketOutlookDelete(long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_MarketOutlookDelete(ref ds, ID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_MarketOutlookDelete(ref DataSet ds, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_MarketOutlookDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_MarketOutlookEdit(long ID, DateTime DateTime, string Title, string Content, bool isShow, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_MarketOutlookEdit(ref ds, ID, DateTime, Title, Content, isShow, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_MarketOutlookEdit(ref DataSet ds, long ID, DateTime DateTime, string Title, string Content, bool isShow, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_MarketOutlookEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_MergeUserDetails(string CallPassword, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_MergeUserDetails(ref ds, CallPassword, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_MergeUserDetails(ref DataSet ds, string CallPassword, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_MergeUserDetails", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("CallPassword", SqlDbType.VarChar, 0, ParameterDirection.Input, CallPassword), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_NewsAdd(long SiteID, int TypeID, DateTime DateTime, string Title, string Content, string ImageUrl, bool isShow, bool isHasImage, bool isCanComments, bool isCommend, bool isHot, long ReadCount, ref long NewsID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_NewsAdd(ref ds, SiteID, TypeID, DateTime, Title, Content, ImageUrl, isShow, isHasImage, isCanComments, isCommend, isHot, ReadCount, ref NewsID, ref ReturnDescription);
        }

        public static int P_NewsAdd(ref DataSet ds, long SiteID, int TypeID, DateTime DateTime, string Title, string Content, string ImageUrl, bool isShow, bool isHasImage, bool isCanComments, bool isCommend, bool isHot, long ReadCount, ref long NewsID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_NewsAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("TypeID", SqlDbType.Int, 0, ParameterDirection.Input, TypeID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("ImageUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, ImageUrl), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("isHasImage", SqlDbType.Bit, 0, ParameterDirection.Input, isHasImage), new MSSQL.Parameter("isCanComments", SqlDbType.Bit, 0, ParameterDirection.Input, isCanComments), new MSSQL.Parameter("isCommend", SqlDbType.Bit, 0, ParameterDirection.Input, isCommend), new MSSQL.Parameter("isHot", SqlDbType.Bit, 0, ParameterDirection.Input, isHot), new MSSQL.Parameter("ReadCount", SqlDbType.BigInt, 0, ParameterDirection.Input, ReadCount), new MSSQL.Parameter("NewsID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewsID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                NewsID = Convert.ToInt64(outputs["NewsID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_NewsAddComments(long SiteID, long NewsID, DateTime DateTime, long CommentserID, string CommentserName, string Content, bool isShow, ref long NewNewsCommentsID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_NewsAddComments(ref ds, SiteID, NewsID, DateTime, CommentserID, CommentserName, Content, isShow, ref NewNewsCommentsID, ref ReturnDescription);
        }

        public static int P_NewsAddComments(ref DataSet ds, long SiteID, long NewsID, DateTime DateTime, long CommentserID, string CommentserName, string Content, bool isShow, ref long NewNewsCommentsID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_NewsAddComments", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("NewsID", SqlDbType.BigInt, 0, ParameterDirection.Input, NewsID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("CommentserID", SqlDbType.BigInt, 0, ParameterDirection.Input, CommentserID), new MSSQL.Parameter("CommentserName", SqlDbType.VarChar, 0, ParameterDirection.Input, CommentserName), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("NewNewsCommentsID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewNewsCommentsID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                NewNewsCommentsID = Convert.ToInt64(outputs["NewNewsCommentsID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_NewsDelete(long SiteID, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_NewsDelete(ref ds, SiteID, ID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_NewsDelete(ref DataSet ds, long SiteID, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_NewsDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_NewsDeleteComments(long SiteID, long NewsCommentsID, ref long ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_NewsDeleteComments(ref ds, SiteID, NewsCommentsID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_NewsDeleteComments(ref DataSet ds, long SiteID, long NewsCommentsID, ref long ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_NewsDeleteComments", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("NewsCommentsID", SqlDbType.BigInt, 0, ParameterDirection.Input, NewsCommentsID), new MSSQL.Parameter("ReturnValue", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt64(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_NewsEdit(long SiteID, long ID, int TypeID, DateTime DateTime, string Title, string Content, string ImageUrl, bool isShow, bool isHasImage, bool isCanComments, bool isCommend, bool isHot, long ReadCount, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_NewsEdit(ref ds, SiteID, ID, TypeID, DateTime, Title, Content, ImageUrl, isShow, isHasImage, isCanComments, isCommend, isHot, ReadCount, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_NewsEdit(ref DataSet ds, long SiteID, long ID, int TypeID, DateTime DateTime, string Title, string Content, string ImageUrl, bool isShow, bool isHasImage, bool isCanComments, bool isCommend, bool isHot, long ReadCount, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_NewsEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("TypeID", SqlDbType.Int, 0, ParameterDirection.Input, TypeID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("ImageUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, ImageUrl), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("isHasImage", SqlDbType.Bit, 0, ParameterDirection.Input, isHasImage), new MSSQL.Parameter("isCanComments", SqlDbType.Bit, 0, ParameterDirection.Input, isCanComments), new MSSQL.Parameter("isCommend", SqlDbType.Bit, 0, ParameterDirection.Input, isCommend), new MSSQL.Parameter("isHot", SqlDbType.Bit, 0, ParameterDirection.Input, isHot), new MSSQL.Parameter("ReadCount", SqlDbType.BigInt, 0, ParameterDirection.Input, ReadCount), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_NewsEditComments(long SiteID, long NewsCommentsID, DateTime DateTime, long CommentserID, string CommentserName, string Content, bool isShow, ref long ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_NewsEditComments(ref ds, SiteID, NewsCommentsID, DateTime, CommentserID, CommentserName, Content, isShow, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_NewsEditComments(ref DataSet ds, long SiteID, long NewsCommentsID, DateTime DateTime, long CommentserID, string CommentserName, string Content, bool isShow, ref long ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_NewsEditComments", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("NewsCommentsID", SqlDbType.BigInt, 0, ParameterDirection.Input, NewsCommentsID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("CommentserID", SqlDbType.BigInt, 0, ParameterDirection.Input, CommentserID), new MSSQL.Parameter("CommentserName", SqlDbType.VarChar, 0, ParameterDirection.Input, CommentserName), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("ReturnValue", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt64(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_NewsRead(long SiteID, long NewsID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_NewsRead(ref ds, SiteID, NewsID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_NewsRead(ref DataSet ds, long SiteID, long NewsID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_NewsRead", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("NewsID", SqlDbType.BigInt, 0, ParameterDirection.Input, NewsID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_PoliciesAndRegulationAdd(DateTime DateTime, string Title, string Content, bool isShow, ref long NewPoliciesAndRegulationID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_PoliciesAndRegulationAdd(ref ds, DateTime, Title, Content, isShow, ref NewPoliciesAndRegulationID, ref ReturnDescription);
        }

        public static int P_PoliciesAndRegulationAdd(ref DataSet ds, DateTime DateTime, string Title, string Content, bool isShow, ref long NewPoliciesAndRegulationID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_PoliciesAndRegulationAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("NewPoliciesAndRegulationID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewPoliciesAndRegulationID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                NewPoliciesAndRegulationID = Convert.ToInt64(outputs["NewPoliciesAndRegulationID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_PoliciesAndRegulationDelete(long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_PoliciesAndRegulationDelete(ref ds, ID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_PoliciesAndRegulationDelete(ref DataSet ds, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_PoliciesAndRegulationDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_PoliciesAndRegulationEdit(long ID, DateTime DateTime, string Title, string Content, bool isShow, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_PoliciesAndRegulationEdit(ref ds, ID, DateTime, Title, Content, isShow, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_PoliciesAndRegulationEdit(ref DataSet ds, long ID, DateTime DateTime, string Title, string Content, bool isShow, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_PoliciesAndRegulationEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_PopUserBonus(long Id, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_PopUserBonus(ref ds, Id, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_PopUserBonus(ref DataSet ds, long Id, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_PopUserBonus", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("Id", SqlDbType.BigInt, 0, ParameterDirection.Input, Id), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_Quash(long SiteID, long BuyDetailID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_Quash(ref ds, SiteID, BuyDetailID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_Quash(ref DataSet ds, long SiteID, long BuyDetailID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_Quash", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("BuyDetailID", SqlDbType.BigInt, 0, ParameterDirection.Input, BuyDetailID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_QuashChaseTask(long SiteID, long ChaseTaskID, bool isSystemQuash, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_QuashChaseTask(ref ds, SiteID, ChaseTaskID, isSystemQuash, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_QuashChaseTask(ref DataSet ds, long SiteID, long ChaseTaskID, bool isSystemQuash, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_QuashChaseTask", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ChaseTaskID", SqlDbType.BigInt, 0, ParameterDirection.Input, ChaseTaskID), new MSSQL.Parameter("isSystemQuash", SqlDbType.Bit, 0, ParameterDirection.Input, isSystemQuash), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_QuashChaseTaskDetail(long SiteID, long ChaseTaskDetailID, bool isSystemQuash, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_QuashChaseTaskDetail(ref ds, SiteID, ChaseTaskDetailID, isSystemQuash, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_QuashChaseTaskDetail(ref DataSet ds, long SiteID, long ChaseTaskDetailID, bool isSystemQuash, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_QuashChaseTaskDetail", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ChaseTaskDetailID", SqlDbType.BigInt, 0, ParameterDirection.Input, ChaseTaskDetailID), new MSSQL.Parameter("isSystemQuash", SqlDbType.Bit, 0, ParameterDirection.Input, isSystemQuash), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_QuashScheme(long SiteID, long SchemeID, bool isSystemQuash, bool isRelation, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_QuashScheme(ref ds, SiteID, SchemeID, isSystemQuash, isRelation, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_QuashScheme(ref DataSet ds, long SiteID, long SchemeID, bool isSystemQuash, bool isRelation, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_QuashScheme", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("isSystemQuash", SqlDbType.Bit, 0, ParameterDirection.Input, isSystemQuash), new MSSQL.Parameter("isRelation", SqlDbType.Bit, 0, ParameterDirection.Input, isRelation), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_QuashSchemeNoLotteryNumber(ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_QuashSchemeNoLotteryNumber(ref ds, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_QuashSchemeNoLotteryNumber(ref DataSet ds, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_QuashSchemeNoLotteryNumber", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_QuashTemp12345(long SiteID, long BuyDetailID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_QuashTemp12345(ref ds, SiteID, BuyDetailID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_QuashTemp12345(ref DataSet ds, long SiteID, long BuyDetailID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_QuashTemp12345", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("BuyDetailID", SqlDbType.BigInt, 0, ParameterDirection.Input, BuyDetailID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_QuestionsAdd(long SiteID, long UserID, short TypeID, string Telephone, string Content, ref long NewQuestionID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_QuestionsAdd(ref ds, SiteID, UserID, TypeID, Telephone, Content, ref NewQuestionID, ref ReturnDescription);
        }

        public static int P_QuestionsAdd(ref DataSet ds, long SiteID, long UserID, short TypeID, string Telephone, string Content, ref long NewQuestionID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_QuestionsAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("TypeID", SqlDbType.SmallInt, 0, ParameterDirection.Input, TypeID), new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 0, ParameterDirection.Input, Telephone), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("NewQuestionID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewQuestionID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                NewQuestionID = Convert.ToInt64(outputs["NewQuestionID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_QuestionsAnswer(long SiteID, long QuestionID, string Answer, long AnswerOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_QuestionsAnswer(ref ds, SiteID, QuestionID, Answer, AnswerOperatorID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_QuestionsAnswer(ref DataSet ds, long SiteID, long QuestionID, string Answer, long AnswerOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_QuestionsAnswer", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("QuestionID", SqlDbType.BigInt, 0, ParameterDirection.Input, QuestionID), new MSSQL.Parameter("Answer", SqlDbType.VarChar, 0, ParameterDirection.Input, Answer), new MSSQL.Parameter("AnswerOperatorID", SqlDbType.BigInt, 0, ParameterDirection.Input, AnswerOperatorID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_QuestionsDelete(long SiteID, long QuestionID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_QuestionsDelete(ref ds, SiteID, QuestionID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_QuestionsDelete(ref DataSet ds, long SiteID, long QuestionID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_QuestionsDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("QuestionID", SqlDbType.BigInt, 0, ParameterDirection.Input, QuestionID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_QuestionsHandling(long SiteID, long QuestionID, long HandleOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_QuestionsHandling(ref ds, SiteID, QuestionID, HandleOperatorID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_QuestionsHandling(ref DataSet ds, long SiteID, long QuestionID, long HandleOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_QuestionsHandling", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("QuestionID", SqlDbType.BigInt, 0, ParameterDirection.Input, QuestionID), new MSSQL.Parameter("HandleOperatorID", SqlDbType.BigInt, 0, ParameterDirection.Input, HandleOperatorID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_RebonusShares(ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_RebonusShares(ref ds, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_RebonusShares(ref DataSet ds, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_RebonusShares", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SchemeAssure(ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SchemeAssure(ref ds, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SchemeAssure(ref DataSet ds, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SchemeAssure", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SchemeCalculatedBonus(ref bool ReturnBool, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SchemeCalculatedBonus(ref ds, ref ReturnBool, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SchemeCalculatedBonus(ref DataSet ds, ref bool ReturnBool, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SchemeCalculatedBonus", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnBool", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) ReturnBool), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnBool = Convert.ToBoolean(outputs["ReturnBool"]);
            }
            catch
            {
            }
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SchemeCalculatedScore(long UserID, double DetailMoney, long SchemeID)
        {
            DataSet ds = null;
            return P_SchemeCalculatedScore(ref ds, UserID, DetailMoney, SchemeID);
        }

        public static int P_SchemeCalculatedScore(ref DataSet ds, long UserID, double DetailMoney, long SchemeID)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_SchemeCalculatedScore", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("DetailMoney", SqlDbType.Money, 0, ParameterDirection.Input, DetailMoney), new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID) });
        }

        public static int P_SchemePost(int posterid, string poster, int fid, string title, string ip, string message, long schemeid, int typeid, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SchemePost(ref ds, posterid, poster, fid, title, ip, message, schemeid, typeid, ref ReturnDescription);
        }

        public static int P_SchemePost(ref DataSet ds, int posterid, string poster, int fid, string title, string ip, string message, long schemeid, int typeid, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SchemePost", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("posterid", SqlDbType.Int, 0, ParameterDirection.Input, posterid), new MSSQL.Parameter("poster", SqlDbType.VarChar, 0, ParameterDirection.Input, poster), new MSSQL.Parameter("fid", SqlDbType.Int, 0, ParameterDirection.Input, fid), new MSSQL.Parameter("title", SqlDbType.VarChar, 0, ParameterDirection.Input, title), new MSSQL.Parameter("ip", SqlDbType.VarChar, 0, ParameterDirection.Input, ip), new MSSQL.Parameter("message", SqlDbType.VarChar, 0, ParameterDirection.Input, message), new MSSQL.Parameter("schemeid", SqlDbType.BigInt, 0, ParameterDirection.Input, schemeid), new MSSQL.Parameter("typeid", SqlDbType.Int, 0, ParameterDirection.Input, typeid), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SchemePrintOut(long SiteID, long SchemeID, long BuyOperatorID, short PrintOutType, string Identifiers, bool isOt, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SchemePrintOut(ref ds, SiteID, SchemeID, BuyOperatorID, PrintOutType, Identifiers, isOt, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SchemePrintOut(ref DataSet ds, long SiteID, long SchemeID, long BuyOperatorID, short PrintOutType, string Identifiers, bool isOt, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SchemePrintOut", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("BuyOperatorID", SqlDbType.BigInt, 0, ParameterDirection.Input, BuyOperatorID), new MSSQL.Parameter("PrintOutType", SqlDbType.SmallInt, 0, ParameterDirection.Input, PrintOutType), new MSSQL.Parameter("Identifiers", SqlDbType.VarChar, 0, ParameterDirection.Input, Identifiers), new MSSQL.Parameter("isOt", SqlDbType.Bit, 0, ParameterDirection.Input, isOt), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SchemesSendToCenterAdd(long SchemeID, int PlayTypeID, string TicketXML, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SchemesSendToCenterAdd(ref ds, SchemeID, PlayTypeID, TicketXML, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SchemesSendToCenterAdd(ref DataSet ds, long SchemeID, int PlayTypeID, string TicketXML, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SchemesSendToCenterAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, PlayTypeID), new MSSQL.Parameter("TicketXML", SqlDbType.NText, 0, ParameterDirection.Input, TicketXML), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SchemesSendToCenterAdd_Single(long SchemeID, int PlayTypeID, double Money, int Multiple, string Ticket, bool isFirstWrite, ref long ID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SchemesSendToCenterAdd_Single(ref ds, SchemeID, PlayTypeID, Money, Multiple, Ticket, isFirstWrite, ref ID, ref ReturnDescription);
        }

        public static int P_SchemesSendToCenterAdd_Single(ref DataSet ds, long SchemeID, int PlayTypeID, double Money, int Multiple, string Ticket, bool isFirstWrite, ref long ID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SchemesSendToCenterAdd_Single", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, PlayTypeID), new MSSQL.Parameter("Money", SqlDbType.Money, 0, ParameterDirection.Input, Money), new MSSQL.Parameter("Multiple", SqlDbType.Int, 0, ParameterDirection.Input, Multiple), new MSSQL.Parameter("Ticket", SqlDbType.VarChar, 0, ParameterDirection.Input, Ticket), new MSSQL.Parameter("isFirstWrite", SqlDbType.Bit, 0, ParameterDirection.Input, isFirstWrite), new MSSQL.Parameter("ID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) ID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ID = Convert.ToInt64(outputs["ID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SchemesSendToCenterHandle(string Identifiers, DateTime DealTime, bool IsSuccess, string Status, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SchemesSendToCenterHandle(ref ds, Identifiers, DealTime, IsSuccess, Status, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SchemesSendToCenterHandle(ref DataSet ds, string Identifiers, DateTime DealTime, bool IsSuccess, string Status, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SchemesSendToCenterHandle", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("Identifiers", SqlDbType.VarChar, 0, ParameterDirection.Input, Identifiers), new MSSQL.Parameter("DealTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DealTime), new MSSQL.Parameter("IsSuccess", SqlDbType.Bit, 0, ParameterDirection.Input, IsSuccess), new MSSQL.Parameter("Status", SqlDbType.VarChar, 0, ParameterDirection.Input, Status), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SchemesSendToCenterHandleUniteAnte(long SchemeID, DateTime DealTime, bool isOt, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SchemesSendToCenterHandleUniteAnte(ref ds, SchemeID, DealTime, isOt, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SchemesSendToCenterHandleUniteAnte(ref DataSet ds, long SchemeID, DateTime DealTime, bool isOt, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SchemesSendToCenterHandleUniteAnte", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("DealTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DealTime), new MSSQL.Parameter("isOt", SqlDbType.Bit, 0, ParameterDirection.Input, isOt), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ScoreChange(long UserID, long CommoditityID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ScoreChange(ref ds, UserID, CommoditityID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ScoreChange(ref DataSet ds, long UserID, long CommoditityID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ScoreChange", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("CommoditityID", SqlDbType.BigInt, 0, ParameterDirection.Input, CommoditityID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 50, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ScoringExchange(long SiteID, long UserID, double Scoring, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ScoringExchange(ref ds, SiteID, UserID, Scoring, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ScoringExchange(ref DataSet ds, long SiteID, long UserID, double Scoring, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ScoringExchange", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Scoring", SqlDbType.Float, 0, ParameterDirection.Input, Scoring), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SelectPaging(string TableOrViewName, string FieldList, string OrderFieldList, string Condition, int PageSize, int PageIndex, ref long RowCount, ref int PageCount, ref int CurrentPageIndex, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SelectPaging(ref ds, TableOrViewName, FieldList, OrderFieldList, Condition, PageSize, PageIndex, ref RowCount, ref PageCount, ref CurrentPageIndex, ref ReturnDescription);
        }

        public static int P_SelectPaging(ref DataSet ds, string TableOrViewName, string FieldList, string OrderFieldList, string Condition, int PageSize, int PageIndex, ref long RowCount, ref int PageCount, ref int CurrentPageIndex, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SelectPaging", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("TableOrViewName", SqlDbType.VarChar, 0, ParameterDirection.Input, TableOrViewName), new MSSQL.Parameter("FieldList", SqlDbType.VarChar, 0, ParameterDirection.Input, FieldList), new MSSQL.Parameter("OrderFieldList", SqlDbType.VarChar, 0, ParameterDirection.Input, OrderFieldList), new MSSQL.Parameter("Condition", SqlDbType.VarChar, 0, ParameterDirection.Input, Condition), new MSSQL.Parameter("PageSize", SqlDbType.Int, 0, ParameterDirection.Input, PageSize), new MSSQL.Parameter("PageIndex", SqlDbType.Int, 0, ParameterDirection.Input, PageIndex), new MSSQL.Parameter("RowCount", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) RowCount), new MSSQL.Parameter("PageCount", SqlDbType.Int, 4, ParameterDirection.Output, (int) PageCount), new MSSQL.Parameter("CurrentPageIndex", SqlDbType.Int, 4, ParameterDirection.Output, (int) CurrentPageIndex), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                RowCount = Convert.ToInt64(outputs["RowCount"]);
            }
            catch
            {
            }
            try
            {
                PageCount = Convert.ToInt32(outputs["PageCount"]);
            }
            catch
            {
            }
            try
            {
                CurrentPageIndex = Convert.ToInt32(outputs["CurrentPageIndex"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SetFriendsWinInfo(string SnsName, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SetFriendsWinInfo(ref ds, SnsName, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SetFriendsWinInfo(ref DataSet ds, string SnsName, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SetFriendsWinInfo", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SnsName", SqlDbType.VarChar, 0, ParameterDirection.Input, SnsName), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SetMaxMultiple(long IsuseID, int PlayTypeID, int MaxMultiple, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SetMaxMultiple(ref ds, IsuseID, PlayTypeID, MaxMultiple, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SetMaxMultiple(ref DataSet ds, long IsuseID, int PlayTypeID, int MaxMultiple, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SetMaxMultiple", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID), new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, PlayTypeID), new MSSQL.Parameter("MaxMultiple", SqlDbType.Int, 0, ParameterDirection.Input, MaxMultiple), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SetOptions(string Key, string Value)
        {
            DataSet ds = null;
            return P_SetOptions(ref ds, Key, Value);
        }

        public static int P_SetOptions(ref DataSet ds, string Key, string Value)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_SetOptions", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("Key", SqlDbType.VarChar, 0, ParameterDirection.Input, Key), new MSSQL.Parameter("Value", SqlDbType.VarChar, 0, ParameterDirection.Input, Value) });
        }

        public static int P_SetSchemeOpenUsers(long SiteID, long SchemeID, string UserList, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SetSchemeOpenUsers(ref ds, SiteID, SchemeID, UserList, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SetSchemeOpenUsers(ref DataSet ds, long SiteID, long SchemeID, string UserList, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SetSchemeOpenUsers", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("UserList", SqlDbType.VarChar, 0, ParameterDirection.Input, UserList), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SetSiteNotificationTemplate(long SiteID, short Manner, string NotificationType, string Value)
        {
            DataSet ds = null;
            return P_SetSiteNotificationTemplate(ref ds, SiteID, Manner, NotificationType, Value);
        }

        public static int P_SetSiteNotificationTemplate(ref DataSet ds, long SiteID, short Manner, string NotificationType, string Value)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_SetSiteNotificationTemplate", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("Manner", SqlDbType.SmallInt, 0, ParameterDirection.Input, Manner), new MSSQL.Parameter("NotificationType", SqlDbType.VarChar, 0, ParameterDirection.Input, NotificationType), new MSSQL.Parameter("Value", SqlDbType.VarChar, 0, ParameterDirection.Input, Value) });
        }

        public static int P_SetSiteONState(long SiteID, bool ON)
        {
            DataSet ds = null;
            return P_SetSiteONState(ref ds, SiteID, ON);
        }

        public static int P_SetSiteONState(ref DataSet ds, long SiteID, bool ON)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_SetSiteONState", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ON", SqlDbType.Bit, 0, ParameterDirection.Input, ON) });
        }

        public static int P_SetSiteSendNotificationTypes(long SiteID, short Manner, string SendNotificationTypeList, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SetSiteSendNotificationTypes(ref ds, SiteID, Manner, SendNotificationTypeList, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SetSiteSendNotificationTypes(ref DataSet ds, long SiteID, short Manner, string SendNotificationTypeList, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SetSiteSendNotificationTypes", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("Manner", SqlDbType.SmallInt, 0, ParameterDirection.Input, Manner), new MSSQL.Parameter("SendNotificationTypeList", SqlDbType.VarChar, 0, ParameterDirection.Input, SendNotificationTypeList), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SetSiteUrls(long SiteID, string Urls, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SetSiteUrls(ref ds, SiteID, Urls, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SetSiteUrls(ref DataSet ds, long SiteID, string Urls, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SetSiteUrls", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("Urls", SqlDbType.VarChar, 0, ParameterDirection.Input, Urls), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SetUserAcceptNotificationTypes(long SiteID, long UserID, short Manner, string AcceptNotificationTypeList, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SetUserAcceptNotificationTypes(ref ds, SiteID, UserID, Manner, AcceptNotificationTypeList, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SetUserAcceptNotificationTypes(ref DataSet ds, long SiteID, long UserID, short Manner, string AcceptNotificationTypeList, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SetUserAcceptNotificationTypes", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Manner", SqlDbType.SmallInt, 0, ParameterDirection.Input, Manner), new MSSQL.Parameter("AcceptNotificationTypeList", SqlDbType.VarChar, 0, ParameterDirection.Input, AcceptNotificationTypeList), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SetUserCompetences(long SiteID, long UserID, string CompetencesList, string GroupsList, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SetUserCompetences(ref ds, SiteID, UserID, CompetencesList, GroupsList, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SetUserCompetences(ref DataSet ds, long SiteID, long UserID, string CompetencesList, string GroupsList, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SetUserCompetences", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("CompetencesList", SqlDbType.VarChar, 0, ParameterDirection.Input, CompetencesList), new MSSQL.Parameter("GroupsList", SqlDbType.VarChar, 0, ParameterDirection.Input, GroupsList), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SiteAdd(long SiteParentID, long OwnerUserID, string Name, string LogoUrl, string Company, string Address, string PostCode, string ResponsiblePerson, string ContactPerson, string Telephone, string Fax, string Mobile, string Email, string QQ, string ServiceTelephone, string ICPCert, short Level, bool ON, double BonusScale, int MaxSubSites, string UseLotteryListRestrictions, string UseLotteryList, string UseLotteryListQuickBuy, string Urls, ref long AdministratorID, ref long SiteID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SiteAdd(ref ds, SiteParentID, OwnerUserID, Name, LogoUrl, Company, Address, PostCode, ResponsiblePerson, ContactPerson, Telephone, Fax, Mobile, Email, QQ, ServiceTelephone, ICPCert, Level, ON, BonusScale, MaxSubSites, UseLotteryListRestrictions, UseLotteryList, UseLotteryListQuickBuy, Urls, ref AdministratorID, ref SiteID, ref ReturnDescription);
        }

        public static int P_SiteAdd(ref DataSet ds, long SiteParentID, long OwnerUserID, string Name, string LogoUrl, string Company, string Address, string PostCode, string ResponsiblePerson, string ContactPerson, string Telephone, string Fax, string Mobile, string Email, string QQ, string ServiceTelephone, string ICPCert, short Level, bool ON, double BonusScale, int MaxSubSites, string UseLotteryListRestrictions, string UseLotteryList, string UseLotteryListQuickBuy, string Urls, ref long AdministratorID, ref long SiteID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SiteAdd", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("SiteParentID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteParentID), new MSSQL.Parameter("OwnerUserID", SqlDbType.BigInt, 0, ParameterDirection.Input, OwnerUserID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, Name), new MSSQL.Parameter("LogoUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, LogoUrl), new MSSQL.Parameter("Company", SqlDbType.VarChar, 0, ParameterDirection.Input, Company), new MSSQL.Parameter("Address", SqlDbType.VarChar, 0, ParameterDirection.Input, Address), new MSSQL.Parameter("PostCode", SqlDbType.VarChar, 0, ParameterDirection.Input, PostCode), new MSSQL.Parameter("ResponsiblePerson", SqlDbType.VarChar, 0, ParameterDirection.Input, ResponsiblePerson), new MSSQL.Parameter("ContactPerson", SqlDbType.VarChar, 0, ParameterDirection.Input, ContactPerson), new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 0, ParameterDirection.Input, Telephone), new MSSQL.Parameter("Fax", SqlDbType.VarChar, 0, ParameterDirection.Input, Fax), new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 0, ParameterDirection.Input, Mobile), new MSSQL.Parameter("Email", SqlDbType.VarChar, 0, ParameterDirection.Input, Email), new MSSQL.Parameter("QQ", SqlDbType.VarChar, 0, ParameterDirection.Input, QQ), new MSSQL.Parameter("ServiceTelephone", SqlDbType.VarChar, 0, ParameterDirection.Input, ServiceTelephone), new MSSQL.Parameter("ICPCert", SqlDbType.VarChar, 0, ParameterDirection.Input, ICPCert), 
                new MSSQL.Parameter("Level", SqlDbType.SmallInt, 0, ParameterDirection.Input, Level), new MSSQL.Parameter("ON", SqlDbType.Bit, 0, ParameterDirection.Input, ON), new MSSQL.Parameter("BonusScale", SqlDbType.Float, 0, ParameterDirection.Input, BonusScale), new MSSQL.Parameter("MaxSubSites", SqlDbType.Int, 0, ParameterDirection.Input, MaxSubSites), new MSSQL.Parameter("UseLotteryListRestrictions", SqlDbType.VarChar, 0, ParameterDirection.Input, UseLotteryListRestrictions), new MSSQL.Parameter("UseLotteryList", SqlDbType.VarChar, 0, ParameterDirection.Input, UseLotteryList), new MSSQL.Parameter("UseLotteryListQuickBuy", SqlDbType.VarChar, 0, ParameterDirection.Input, UseLotteryListQuickBuy), new MSSQL.Parameter("Urls", SqlDbType.VarChar, 0, ParameterDirection.Input, Urls), new MSSQL.Parameter("AdministratorID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) AdministratorID), new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) SiteID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                AdministratorID = Convert.ToInt64(outputs["AdministratorID"]);
            }
            catch
            {
            }
            try
            {
                SiteID = Convert.ToInt64(outputs["SiteID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SiteAfficheAdd(long SiteID, DateTime DateTime, string Title, string Content, bool isShow, bool isCommend, ref long NewAfficheID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SiteAfficheAdd(ref ds, SiteID, DateTime, Title, Content, isShow, isCommend, ref NewAfficheID, ref ReturnDescription);
        }

        public static int P_SiteAfficheAdd(ref DataSet ds, long SiteID, DateTime DateTime, string Title, string Content, bool isShow, bool isCommend, ref long NewAfficheID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SiteAfficheAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("isCommend", SqlDbType.Bit, 0, ParameterDirection.Input, isCommend), new MSSQL.Parameter("NewAfficheID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewAfficheID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                NewAfficheID = Convert.ToInt64(outputs["NewAfficheID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SiteAfficheDelete(long SiteID, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SiteAfficheDelete(ref ds, SiteID, ID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SiteAfficheDelete(ref DataSet ds, long SiteID, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SiteAfficheDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SiteAfficheEdit(long SiteID, long ID, DateTime DateTime, string Title, string Content, bool isShow, bool isCommend, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SiteAfficheEdit(ref ds, SiteID, ID, DateTime, Title, Content, isShow, isCommend, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SiteAfficheEdit(ref DataSet ds, long SiteID, long ID, DateTime DateTime, string Title, string Content, bool isShow, bool isCommend, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SiteAfficheEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("isCommend", SqlDbType.Bit, 0, ParameterDirection.Input, isCommend), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SiteEdit(long SiteID, string Name, string LogoUrl, string Company, string Address, string PostCode, string ResponsiblePerson, string ContactPerson, string Telephone, string Fax, string Mobile, string Email, string QQ, string ServiceTelephone, string ICPCert, bool ON, double BonusScale, int MaxSubSites, string UseLotteryListRestrictions, string UseLotteryList, string UseLotteryListQuickBuy, string Urls, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SiteEdit(ref ds, SiteID, Name, LogoUrl, Company, Address, PostCode, ResponsiblePerson, ContactPerson, Telephone, Fax, Mobile, Email, QQ, ServiceTelephone, ICPCert, ON, BonusScale, MaxSubSites, UseLotteryListRestrictions, UseLotteryList, UseLotteryListQuickBuy, Urls, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SiteEdit(ref DataSet ds, long SiteID, string Name, string LogoUrl, string Company, string Address, string PostCode, string ResponsiblePerson, string ContactPerson, string Telephone, string Fax, string Mobile, string Email, string QQ, string ServiceTelephone, string ICPCert, bool ON, double BonusScale, int MaxSubSites, string UseLotteryListRestrictions, string UseLotteryList, string UseLotteryListQuickBuy, string Urls, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SiteEdit", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, Name), new MSSQL.Parameter("LogoUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, LogoUrl), new MSSQL.Parameter("Company", SqlDbType.VarChar, 0, ParameterDirection.Input, Company), new MSSQL.Parameter("Address", SqlDbType.VarChar, 0, ParameterDirection.Input, Address), new MSSQL.Parameter("PostCode", SqlDbType.VarChar, 0, ParameterDirection.Input, PostCode), new MSSQL.Parameter("ResponsiblePerson", SqlDbType.VarChar, 0, ParameterDirection.Input, ResponsiblePerson), new MSSQL.Parameter("ContactPerson", SqlDbType.VarChar, 0, ParameterDirection.Input, ContactPerson), new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 0, ParameterDirection.Input, Telephone), new MSSQL.Parameter("Fax", SqlDbType.VarChar, 0, ParameterDirection.Input, Fax), new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 0, ParameterDirection.Input, Mobile), new MSSQL.Parameter("Email", SqlDbType.VarChar, 0, ParameterDirection.Input, Email), new MSSQL.Parameter("QQ", SqlDbType.VarChar, 0, ParameterDirection.Input, QQ), new MSSQL.Parameter("ServiceTelephone", SqlDbType.VarChar, 0, ParameterDirection.Input, ServiceTelephone), new MSSQL.Parameter("ICPCert", SqlDbType.VarChar, 0, ParameterDirection.Input, ICPCert), new MSSQL.Parameter("ON", SqlDbType.Bit, 0, ParameterDirection.Input, ON), 
                new MSSQL.Parameter("BonusScale", SqlDbType.Float, 0, ParameterDirection.Input, BonusScale), new MSSQL.Parameter("MaxSubSites", SqlDbType.Int, 0, ParameterDirection.Input, MaxSubSites), new MSSQL.Parameter("UseLotteryListRestrictions", SqlDbType.VarChar, 0, ParameterDirection.Input, UseLotteryListRestrictions), new MSSQL.Parameter("UseLotteryList", SqlDbType.VarChar, 0, ParameterDirection.Input, UseLotteryList), new MSSQL.Parameter("UseLotteryListQuickBuy", SqlDbType.VarChar, 0, ParameterDirection.Input, UseLotteryListQuickBuy), new MSSQL.Parameter("Urls", SqlDbType.VarChar, 0, ParameterDirection.Input, Urls), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SoftDownloadAdd(long SiteID, int LotteryID, DateTime DateTime, string Title, string FileUrl, string ImageUrl, string Content, bool isHot, bool isCommend, bool isShow, int ReadCount, ref long NewSoftDownloadID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SoftDownloadAdd(ref ds, SiteID, LotteryID, DateTime, Title, FileUrl, ImageUrl, Content, isHot, isCommend, isShow, ReadCount, ref NewSoftDownloadID, ref ReturnDescription);
        }

        public static int P_SoftDownloadAdd(ref DataSet ds, long SiteID, int LotteryID, DateTime DateTime, string Title, string FileUrl, string ImageUrl, string Content, bool isHot, bool isCommend, bool isShow, int ReadCount, ref long NewSoftDownloadID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SoftDownloadAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("FileUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, FileUrl), new MSSQL.Parameter("ImageUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, ImageUrl), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("isHot", SqlDbType.Bit, 0, ParameterDirection.Input, isHot), new MSSQL.Parameter("isCommend", SqlDbType.Bit, 0, ParameterDirection.Input, isCommend), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("ReadCount", SqlDbType.Int, 0, ParameterDirection.Input, ReadCount), new MSSQL.Parameter("NewSoftDownloadID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewSoftDownloadID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                NewSoftDownloadID = Convert.ToInt64(outputs["NewSoftDownloadID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SoftDownloadDelete(long SiteID, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SoftDownloadDelete(ref ds, SiteID, ID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SoftDownloadDelete(ref DataSet ds, long SiteID, long ID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SoftDownloadDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SoftDownloadEdit(long SiteID, long ID, int LotteryID, DateTime DateTime, string Title, string FileUrl, string ImageUrl, string Content, bool isHot, bool isCommend, bool isShow, int ReadCount, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SoftDownloadEdit(ref ds, SiteID, ID, LotteryID, DateTime, Title, FileUrl, ImageUrl, Content, isHot, isCommend, isShow, ReadCount, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SoftDownloadEdit(ref DataSet ds, long SiteID, long ID, int LotteryID, DateTime DateTime, string Title, string FileUrl, string ImageUrl, string Content, bool isHot, bool isCommend, bool isShow, int ReadCount, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SoftDownloadEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID), new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID), new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("FileUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, FileUrl), new MSSQL.Parameter("ImageUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, ImageUrl), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("isHot", SqlDbType.Bit, 0, ParameterDirection.Input, isHot), new MSSQL.Parameter("isCommend", SqlDbType.Bit, 0, ParameterDirection.Input, isCommend), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("ReadCount", SqlDbType.Int, 0, ParameterDirection.Input, ReadCount), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SurrogateNotificationAdd(long SiteID, string Title, string Content, bool isShow, ref long SurrogateNotificationID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SurrogateNotificationAdd(ref ds, SiteID, Title, Content, isShow, ref SurrogateNotificationID, ref ReturnDescription);
        }

        public static int P_SurrogateNotificationAdd(ref DataSet ds, long SiteID, string Title, string Content, bool isShow, ref long SurrogateNotificationID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SurrogateNotificationAdd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("SurrogateNotificationID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) SurrogateNotificationID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                SurrogateNotificationID = Convert.ToInt64(outputs["SurrogateNotificationID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SurrogateNotificationDelete(long SiteID, long SurrogateNotificationID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SurrogateNotificationDelete(ref ds, SiteID, SurrogateNotificationID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SurrogateNotificationDelete(ref DataSet ds, long SiteID, long SurrogateNotificationID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SurrogateNotificationDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("SurrogateNotificationID", SqlDbType.BigInt, 0, ParameterDirection.Input, SurrogateNotificationID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SurrogateNotificationEdit(long SiteID, long SurrogateNotificationID, string Title, string Content, bool isShow, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SurrogateNotificationEdit(ref ds, SiteID, SurrogateNotificationID, Title, Content, isShow, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SurrogateNotificationEdit(ref DataSet ds, long SiteID, long SurrogateNotificationID, string Title, string Content, bool isShow, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SurrogateNotificationEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("SurrogateNotificationID", SqlDbType.BigInt, 0, ParameterDirection.Input, SurrogateNotificationID), new MSSQL.Parameter("Title", SqlDbType.VarChar, 0, ParameterDirection.Input, Title), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("isShow", SqlDbType.Bit, 0, ParameterDirection.Input, isShow), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SurrogateTry(long SiteID, long UserID, string Content, string Name, string LogoUrl, string Company, string Address, string PostCode, string ResponsiblePerson, string ContactPerson, string Telephone, string Fax, string Mobile, string Email, string QQ, string ServiceTelephone, string UseLotteryList, string Urls, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SurrogateTry(ref ds, SiteID, UserID, Content, Name, LogoUrl, Company, Address, PostCode, ResponsiblePerson, ContactPerson, Telephone, Fax, Mobile, Email, QQ, ServiceTelephone, UseLotteryList, Urls, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SurrogateTry(ref DataSet ds, long SiteID, long UserID, string Content, string Name, string LogoUrl, string Company, string Address, string PostCode, string ResponsiblePerson, string ContactPerson, string Telephone, string Fax, string Mobile, string Email, string QQ, string ServiceTelephone, string UseLotteryList, string Urls, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SurrogateTry", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, Name), new MSSQL.Parameter("LogoUrl", SqlDbType.VarChar, 0, ParameterDirection.Input, LogoUrl), new MSSQL.Parameter("Company", SqlDbType.VarChar, 0, ParameterDirection.Input, Company), new MSSQL.Parameter("Address", SqlDbType.VarChar, 0, ParameterDirection.Input, Address), new MSSQL.Parameter("PostCode", SqlDbType.VarChar, 0, ParameterDirection.Input, PostCode), new MSSQL.Parameter("ResponsiblePerson", SqlDbType.VarChar, 0, ParameterDirection.Input, ResponsiblePerson), new MSSQL.Parameter("ContactPerson", SqlDbType.VarChar, 0, ParameterDirection.Input, ContactPerson), new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 0, ParameterDirection.Input, Telephone), new MSSQL.Parameter("Fax", SqlDbType.VarChar, 0, ParameterDirection.Input, Fax), new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 0, ParameterDirection.Input, Mobile), new MSSQL.Parameter("Email", SqlDbType.VarChar, 0, ParameterDirection.Input, Email), new MSSQL.Parameter("QQ", SqlDbType.VarChar, 0, ParameterDirection.Input, QQ), new MSSQL.Parameter("ServiceTelephone", SqlDbType.VarChar, 0, ParameterDirection.Input, ServiceTelephone), 
                new MSSQL.Parameter("UseLotteryList", SqlDbType.VarChar, 0, ParameterDirection.Input, UseLotteryList), new MSSQL.Parameter("Urls", SqlDbType.VarChar, 0, ParameterDirection.Input, Urls), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SurrogateTryHandle(long SiteID, long TryID, short HandleResult, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SurrogateTryHandle(ref ds, SiteID, TryID, HandleResult, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SurrogateTryHandle(ref DataSet ds, long SiteID, long TryID, short HandleResult, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SurrogateTryHandle", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("TryID", SqlDbType.BigInt, 0, ParameterDirection.Input, TryID), new MSSQL.Parameter("HandleResult", SqlDbType.SmallInt, 0, ParameterDirection.Input, HandleResult), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SystemEnd(ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SystemEnd(ref ds, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SystemEnd(ref DataSet ds, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SystemEnd", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_SystemEndSchemePrintOut(ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_SystemEndSchemePrintOut(ref ds, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_SystemEndSchemePrintOut(ref DataSet ds, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_SystemEndSchemePrintOut", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_TrendChart_11YDJ_WINNUM(DateTime DateTime, long LotteryID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_TrendChart_11YDJ_WINNUM(ref ds, DateTime, LotteryID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_TrendChart_11YDJ_WINNUM(ref DataSet ds, DateTime DateTime, long LotteryID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_11YDJ_WINNUM", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("DateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime), new MSSQL.Parameter("LotteryID", SqlDbType.BigInt, 0, ParameterDirection.Input, LotteryID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_TrendChart_15X5_CGXMB()
        {
            DataSet ds = null;
            return P_TrendChart_15X5_CGXMB(ref ds);
        }

        public static int P_TrendChart_15X5_CGXMB(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_15X5_CGXMB", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_15X5_HMFB()
        {
            DataSet ds = null;
            return P_TrendChart_15X5_HMFB(ref ds);
        }

        public static int P_TrendChart_15X5_HMFB(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_15X5_HMFB", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_22X5_HMFB(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_22X5_HMFB(ref ds, IsuseNum);
        }

        public static int P_TrendChart_22X5_HMFB(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_22X5_HMFB", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_22X5_HMLR(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_22X5_HMLR(ref ds, IsuseNum);
        }

        public static int P_TrendChart_22X5_HMLR(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_22X5_HMLR", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_22X5_HMLRjj(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_22X5_HMLRjj(ref ds, IsuseNum);
        }

        public static int P_TrendChart_22X5_HMLRjj(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_22X5_HMLRjj", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_22X5_HZ_Heng()
        {
            DataSet ds = null;
            return P_TrendChart_22X5_HZ_Heng(ref ds);
        }

        public static int P_TrendChart_22X5_HZ_Heng(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_22X5_HZ_Heng", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_22X5_HZzong()
        {
            DataSet ds = null;
            return P_TrendChart_22X5_HZzong(ref ds);
        }

        public static int P_TrendChart_22X5_HZzong(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_22X5_HZzong", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_22X5_JO()
        {
            DataSet ds = null;
            return P_TrendChart_22X5_JO(ref ds);
        }

        public static int P_TrendChart_22X5_JO(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_22X5_JO", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_22X5_LH()
        {
            DataSet ds = null;
            return P_TrendChart_22X5_LH(ref ds);
        }

        public static int P_TrendChart_22X5_LH(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_22X5_LH", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_22X5_WeiHaoCF()
        {
            DataSet ds = null;
            return P_TrendChart_22X5_WeiHaoCF(ref ds);
        }

        public static int P_TrendChart_22X5_WeiHaoCF(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_22X5_WeiHaoCF", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_22X5_WH()
        {
            DataSet ds = null;
            return P_TrendChart_22X5_WH(ref ds);
        }

        public static int P_TrendChart_22X5_WH(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_22X5_WH", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_22X5_YS()
        {
            DataSet ds = null;
            return P_TrendChart_22X5_YS(ref ds);
        }

        public static int P_TrendChart_22X5_YS(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_22X5_YS", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_3D_C3YS()
        {
            DataSet ds = null;
            return P_TrendChart_3D_C3YS(ref ds);
        }

        public static int P_TrendChart_3D_C3YS(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_3D_C3YS", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_3D_DZX()
        {
            DataSet ds = null;
            return P_TrendChart_3D_DZX(ref ds);
        }

        public static int P_TrendChart_3D_DZX(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_3D_DZX", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_3D_HZ()
        {
            DataSet ds = null;
            return P_TrendChart_3D_HZ(ref ds);
        }

        public static int P_TrendChart_3D_HZ(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_3D_HZ", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_3D_KD()
        {
            DataSet ds = null;
            return P_TrendChart_3D_KD(ref ds);
        }

        public static int P_TrendChart_3D_KD(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_3D_KD", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_3D_XTZST()
        {
            DataSet ds = null;
            return P_TrendChart_3D_XTZST(ref ds);
        }

        public static int P_TrendChart_3D_XTZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_3D_XTZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_3D_ZHFB()
        {
            DataSet ds = null;
            return P_TrendChart_3D_ZHFB(ref ds);
        }

        public static int P_TrendChart_3D_ZHFB(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_3D_ZHFB", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_3D_ZHXT()
        {
            DataSet ds = null;
            return P_TrendChart_3D_ZHXT(ref ds);
        }

        public static int P_TrendChart_3D_ZHXT(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_3D_ZHXT", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_4D_CGXMB()
        {
            DataSet ds = null;
            return P_TrendChart_4D_CGXMB(ref ds);
        }

        public static int P_TrendChart_4D_CGXMB(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_4D_CGXMB", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_4D_ZHFB()
        {
            DataSet ds = null;
            return P_TrendChart_4D_ZHFB(ref ds);
        }

        public static int P_TrendChart_4D_ZHFB(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_4D_ZHFB", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_7CL_HMFB()
        {
            DataSet ds = null;
            return P_TrendChart_7CL_HMFB(ref ds);
        }

        public static int P_TrendChart_7CL_HMFB(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_7CL_HMFB", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_7LC_CGXMB()
        {
            DataSet ds = null;
            return P_TrendChart_7LC_CGXMB(ref ds);
        }

        public static int P_TrendChart_7LC_CGXMB(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_7LC_CGXMB", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_7X_012()
        {
            DataSet ds = null;
            return P_TrendChart_7X_012(ref ds);
        }

        public static int P_TrendChart_7X_012(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_7X_012", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_7X_CF()
        {
            DataSet ds = null;
            return P_TrendChart_7X_CF(ref ds);
        }

        public static int P_TrendChart_7X_CF(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_7X_CF", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_7X_DX()
        {
            DataSet ds = null;
            return P_TrendChart_7X_DX(ref ds);
        }

        public static int P_TrendChart_7X_DX(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_7X_DX", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_7X_DZX()
        {
            DataSet ds = null;
            return P_TrendChart_7X_DZX(ref ds);
        }

        public static int P_TrendChart_7X_DZX(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_7X_DZX", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_7X_HMFB()
        {
            DataSet ds = null;
            return P_TrendChart_7X_HMFB(ref ds);
        }

        public static int P_TrendChart_7X_HMFB(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_7X_HMFB", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_7X_HZHeng()
        {
            DataSet ds = null;
            return P_TrendChart_7X_HZHeng(ref ds);
        }

        public static int P_TrendChart_7X_HZHeng(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_7X_HZHeng", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_7X_HZzhong()
        {
            DataSet ds = null;
            return P_TrendChart_7X_HZzhong(ref ds);
        }

        public static int P_TrendChart_7X_HZzhong(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_7X_HZzhong", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_7X_JO()
        {
            DataSet ds = null;
            return P_TrendChart_7X_JO(ref ds);
        }

        public static int P_TrendChart_7X_JO(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_7X_JO", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_7X_LH()
        {
            DataSet ds = null;
            return P_TrendChart_7X_LH(ref ds);
        }

        public static int P_TrendChart_7X_LH(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_7X_LH", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_7X_YS()
        {
            DataSet ds = null;
            return P_TrendChart_7X_YS(ref ds);
        }

        public static int P_TrendChart_7X_YS(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_7X_YS", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_7X_ZH()
        {
            DataSet ds = null;
            return P_TrendChart_7X_ZH(ref ds);
        }

        public static int P_TrendChart_7X_ZH(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_7X_ZH", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_7XC_CGXMB()
        {
            DataSet ds = null;
            return P_TrendChart_7XC_CGXMB(ref ds);
        }

        public static int P_TrendChart_7XC_CGXMB(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_7XC_CGXMB", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_CJDLT_HMFB(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_HMFB(ref ds, IsuseNum);
        }

        public static int P_TrendChart_CJDLT_HMFB(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_HMFB", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_CJDLT_HMLR_JiMa(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_HMLR_JiMa(ref ds, IsuseNum);
        }

        public static int P_TrendChart_CJDLT_HMLR_JiMa(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_HMLR_JiMa", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_CJDLT_HMLR_JiMajj(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_HMLR_JiMajj(ref ds, IsuseNum);
        }

        public static int P_TrendChart_CJDLT_HMLR_JiMajj(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_HMLR_JiMajj", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_CJDLT_HMLR_Tema(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_HMLR_Tema(ref ds, IsuseNum);
        }

        public static int P_TrendChart_CJDLT_HMLR_Tema(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_HMLR_Tema", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_CJDLT_HMLR_Temajj(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_HMLR_Temajj(ref ds, IsuseNum);
        }

        public static int P_TrendChart_CJDLT_HMLR_Temajj(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_HMLR_Temajj", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_CJDLT_HZ_Heng()
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_HZ_Heng(ref ds);
        }

        public static int P_TrendChart_CJDLT_HZ_Heng(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_HZ_Heng", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_CJDLT_HZzong()
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_HZzong(ref ds);
        }

        public static int P_TrendChart_CJDLT_HZzong(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_HZzong", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_CJDLT_jima()
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_jima(ref ds);
        }

        public static int P_TrendChart_CJDLT_jima(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_jima", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_CJDLT_jimaYL(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_jimaYL(ref ds, IsuseNum);
        }

        public static int P_TrendChart_CJDLT_jimaYL(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_jimaYL", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_CJDLT_Jiou()
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_Jiou(ref ds);
        }

        public static int P_TrendChart_CJDLT_Jiou(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_Jiou", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_CJDLT_LH()
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_LH(ref ds);
        }

        public static int P_TrendChart_CJDLT_LH(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_LH", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_CJDLT_tema()
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_tema(ref ds);
        }

        public static int P_TrendChart_CJDLT_tema(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_tema", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_CJDLT_TeMa_WH()
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_TeMa_WH(ref ds);
        }

        public static int P_TrendChart_CJDLT_TeMa_WH(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_TeMa_WH", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_CJDLT_TemaYL(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_TemaYL(ref ds, IsuseNum);
        }

        public static int P_TrendChart_CJDLT_TemaYL(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_TemaYL", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_CJDLT_WH()
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_WH(ref ds);
        }

        public static int P_TrendChart_CJDLT_WH(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_WH", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_CJDLT_YS()
        {
            DataSet ds = null;
            return P_TrendChart_CJDLT_YS(ref ds);
        }

        public static int P_TrendChart_CJDLT_YS(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_CJDLT_YS", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_DF6J1_ZHFB()
        {
            DataSet ds = null;
            return P_TrendChart_DF6J1_ZHFB(ref ds);
        }

        public static int P_TrendChart_DF6J1_ZHFB(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_DF6J1_ZHFB", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_FC3D(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_FC3D(ref ds, IsuseNum);
        }

        public static int P_TrendChart_FC3D(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_FC3D", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_KLPK_012()
        {
            DataSet ds = null;
            return P_TrendChart_KLPK_012(ref ds);
        }

        public static int P_TrendChart_KLPK_012(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_KLPK_012", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_KLPK_DX()
        {
            DataSet ds = null;
            return P_TrendChart_KLPK_DX(ref ds);
        }

        public static int P_TrendChart_KLPK_DX(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_KLPK_DX", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_KLPK_DZX()
        {
            DataSet ds = null;
            return P_TrendChart_KLPK_DZX(ref ds);
        }

        public static int P_TrendChart_KLPK_DZX(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_KLPK_DZX", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_KLPK_KJFB()
        {
            DataSet ds = null;
            return P_TrendChart_KLPK_KJFB(ref ds);
        }

        public static int P_TrendChart_KLPK_KJFB(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_KLPK_KJFB", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_KLPK_ZH()
        {
            DataSet ds = null;
            return P_TrendChart_KLPK_ZH(ref ds);
        }

        public static int P_TrendChart_KLPK_ZH(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_KLPK_ZH", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_PL3()
        {
            DataSet ds = null;
            return P_TrendChart_PL3(ref ds);
        }

        public static int P_TrendChart_PL3(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL3", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_PL3_012(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_PL3_012(ref ds, IsuseNum);
        }

        public static int P_TrendChart_PL3_012(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL3_012", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_PL3_DX(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_PL3_DX(ref ds, IsuseNum);
        }

        public static int P_TrendChart_PL3_DX(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL3_DX", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_PL3_DZX(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_PL3_DZX(ref ds, IsuseNum);
        }

        public static int P_TrendChart_PL3_DZX(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL3_DZX", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_PL3_HMFB(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_PL3_HMFB(ref ds, IsuseNum);
        }

        public static int P_TrendChart_PL3_HMFB(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL3_HMFB", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_PL3_HZ(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_PL3_HZ(ref ds, IsuseNum);
        }

        public static int P_TrendChart_PL3_HZ(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL3_HZ", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_PL3_JO(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_PL3_JO(ref ds, IsuseNum);
        }

        public static int P_TrendChart_PL3_JO(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL3_JO", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_PL3_KD(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_PL3_KD(ref ds, IsuseNum);
        }

        public static int P_TrendChart_PL3_KD(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL3_KD", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_PL3_LH()
        {
            DataSet ds = null;
            return P_TrendChart_PL3_LH(ref ds);
        }

        public static int P_TrendChart_PL3_LH(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL3_LH", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_PL3_WH(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_PL3_WH(ref ds, IsuseNum);
        }

        public static int P_TrendChart_PL3_WH(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL3_WH", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_PL3_YS()
        {
            DataSet ds = null;
            return P_TrendChart_PL3_YS(ref ds);
        }

        public static int P_TrendChart_PL3_YS(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL3_YS", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_PL3_ZH(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_PL3_ZH(ref ds, IsuseNum);
        }

        public static int P_TrendChart_PL3_ZH(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL3_ZH", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_PL3_ZX(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_PL3_ZX(ref ds, IsuseNum);
        }

        public static int P_TrendChart_PL3_ZX(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL3_ZX", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_PL5_012()
        {
            DataSet ds = null;
            return P_TrendChart_PL5_012(ref ds);
        }

        public static int P_TrendChart_PL5_012(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL5_012", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_PL5_CF()
        {
            DataSet ds = null;
            return P_TrendChart_PL5_CF(ref ds);
        }

        public static int P_TrendChart_PL5_CF(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL5_CF", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_PL5_DX()
        {
            DataSet ds = null;
            return P_TrendChart_PL5_DX(ref ds);
        }

        public static int P_TrendChart_PL5_DX(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL5_DX", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_PL5_DZX()
        {
            DataSet ds = null;
            return P_TrendChart_PL5_DZX(ref ds);
        }

        public static int P_TrendChart_PL5_DZX(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL5_DZX", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_PL5_HMFB(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_PL5_HMFB(ref ds, IsuseNum);
        }

        public static int P_TrendChart_PL5_HMFB(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL5_HMFB", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_PL5_HZ(int IsuseNum)
        {
            DataSet ds = null;
            return P_TrendChart_PL5_HZ(ref ds, IsuseNum);
        }

        public static int P_TrendChart_PL5_HZ(ref DataSet ds, int IsuseNum)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL5_HZ", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseNum", SqlDbType.Int, 0, ParameterDirection.Input, IsuseNum) });
        }

        public static int P_TrendChart_PL5_JO()
        {
            DataSet ds = null;
            return P_TrendChart_PL5_JO(ref ds);
        }

        public static int P_TrendChart_PL5_JO(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL5_JO", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_PL5_LH()
        {
            DataSet ds = null;
            return P_TrendChart_PL5_LH(ref ds);
        }

        public static int P_TrendChart_PL5_LH(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL5_LH", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_PL5_YS()
        {
            DataSet ds = null;
            return P_TrendChart_PL5_YS(ref ds);
        }

        public static int P_TrendChart_PL5_YS(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL5_YS", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_PL5_ZH()
        {
            DataSet ds = null;
            return P_TrendChart_PL5_ZH(ref ds);
        }

        public static int P_TrendChart_PL5_ZH(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_PL5_ZH", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SHSSL_012()
        {
            DataSet ds = null;
            return P_TrendChart_SHSSL_012(ref ds);
        }

        public static int P_TrendChart_SHSSL_012(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SHSSL_012", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SHSSL_DX()
        {
            DataSet ds = null;
            return P_TrendChart_SHSSL_DX(ref ds);
        }

        public static int P_TrendChart_SHSSL_DX(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SHSSL_DX", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SHSSL_HZ()
        {
            DataSet ds = null;
            return P_TrendChart_SHSSL_HZ(ref ds);
        }

        public static int P_TrendChart_SHSSL_HZ(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SHSSL_HZ", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SHSSL_JO()
        {
            DataSet ds = null;
            return P_TrendChart_SHSSL_JO(ref ds);
        }

        public static int P_TrendChart_SHSSL_JO(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SHSSL_JO", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SHSSL_ZH()
        {
            DataSet ds = null;
            return P_TrendChart_SHSSL_ZH(ref ds);
        }

        public static int P_TrendChart_SHSSL_ZH(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SHSSL_ZH", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SHSSL_ZHFB()
        {
            DataSet ds = null;
            return P_TrendChart_SHSSL_ZHFB(ref ds);
        }

        public static int P_TrendChart_SHSSL_ZHFB(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SHSSL_ZHFB", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_2X_012_ZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_2X_012_ZST(ref ds);
        }

        public static int P_TrendChart_SSC_2X_012_ZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_2X_012_ZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_2XDXDSZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_2XDXDSZST(ref ds);
        }

        public static int P_TrendChart_SSC_2XDXDSZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_2XDXDSZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_2XHZWZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_2XHZWZST(ref ds);
        }

        public static int P_TrendChart_SSC_2XHZWZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_2XHZWZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_2XHZZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_2XHZZST(ref ds);
        }

        public static int P_TrendChart_SSC_2XHZZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_2XHZZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_2XKDZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_2XKDZST(ref ds);
        }

        public static int P_TrendChart_SSC_2XKDZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_2XKDZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_2XMaxZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_2XMaxZST(ref ds);
        }

        public static int P_TrendChart_SSC_2XMaxZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_2XMaxZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_2XMINZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_2XMINZST(ref ds);
        }

        public static int P_TrendChart_SSC_2XMINZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_2XMINZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_2XPJZZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_2XPJZZST(ref ds);
        }

        public static int P_TrendChart_SSC_2XPJZZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_2XPJZZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_2XZHFBZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_2XZHFBZST(ref ds);
        }

        public static int P_TrendChart_SSC_2XZHFBZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_2XZHFBZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_3X_DX012_ZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_3X_DX012_ZST(ref ds);
        }

        public static int P_TrendChart_SSC_3X_DX012_ZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_3X_DX012_ZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_3X_ZX012_ZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_3X_ZX012_ZST(ref ds);
        }

        public static int P_TrendChart_SSC_3X_ZX012_ZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_3X_ZX012_ZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_3XDXZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_3XDXZST(ref ds);
        }

        public static int P_TrendChart_SSC_3XDXZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_3XDXZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_3XHZWZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_3XHZWZST(ref ds);
        }

        public static int P_TrendChart_SSC_3XHZWZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_3XHZWZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_3XHZZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_3XHZZST(ref ds);
        }

        public static int P_TrendChart_SSC_3XHZZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_3XHZZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_3XJOZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_3XJOZST(ref ds);
        }

        public static int P_TrendChart_SSC_3XJOZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_3XJOZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_3XKDZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_3XKDZST(ref ds);
        }

        public static int P_TrendChart_SSC_3XKDZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_3XKDZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_3XPJZZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_3XPJZZST(ref ds);
        }

        public static int P_TrendChart_SSC_3XPJZZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_3XPJZZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_3XZHFBZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_3XZHFBZST(ref ds);
        }

        public static int P_TrendChart_SSC_3XZHFBZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_3XZHFBZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_3XZHZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_3XZHZST(ref ds);
        }

        public static int P_TrendChart_SSC_3XZHZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_3XZHZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_3XZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_3XZST(ref ds);
        }

        public static int P_TrendChart_SSC_3XZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_3XZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_4XDXZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_4XDXZST(ref ds);
        }

        public static int P_TrendChart_SSC_4XDXZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_4XDXZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_4XHZZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_4XHZZST(ref ds);
        }

        public static int P_TrendChart_SSC_4XHZZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_4XHZZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_4XJOZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_4XJOZST(ref ds);
        }

        public static int P_TrendChart_SSC_4XJOZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_4XJOZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_4XKDZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_4XKDZST(ref ds);
        }

        public static int P_TrendChart_SSC_4XKDZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_4XKDZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_4XPJZZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_4XPJZZST(ref ds);
        }

        public static int P_TrendChart_SSC_4XPJZZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_4XPJZZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_4XZHFBZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_4XZHFBZST(ref ds);
        }

        public static int P_TrendChart_SSC_4XZHFBZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_4XZHFBZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_4XZHZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_4XZHZST(ref ds);
        }

        public static int P_TrendChart_SSC_4XZHZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_4XZHZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_4XZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_4XZST(ref ds);
        }

        public static int P_TrendChart_SSC_4XZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_4XZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_5XDXZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_5XDXZST(ref ds);
        }

        public static int P_TrendChart_SSC_5XDXZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_5XDXZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_5XHZZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_5XHZZST(ref ds);
        }

        public static int P_TrendChart_SSC_5XHZZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_5XHZZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_5XJOZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_5XJOZST(ref ds);
        }

        public static int P_TrendChart_SSC_5XJOZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_5XJOZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_5XKDZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_5XKDZST(ref ds);
        }

        public static int P_TrendChart_SSC_5XKDZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_5XKDZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_5XPJZZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_5XPJZZST(ref ds);
        }

        public static int P_TrendChart_SSC_5XPJZZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_5XPJZZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_5XZHFBZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_5XZHFBZST(ref ds);
        }

        public static int P_TrendChart_SSC_5XZHFBZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_5XZHFBZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_5XZHZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_5XZHZST(ref ds);
        }

        public static int P_TrendChart_SSC_5XZHZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_5XZHZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSC_5XZST()
        {
            DataSet ds = null;
            return P_TrendChart_SSC_5XZST(ref ds);
        }

        public static int P_TrendChart_SSC_5XZST(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSC_5XZST", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSQ_3FQ()
        {
            DataSet ds = null;
            return P_TrendChart_SSQ_3FQ(ref ds);
        }

        public static int P_TrendChart_SSQ_3FQ(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSQ_3FQ", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSQ_BQZH()
        {
            DataSet ds = null;
            return P_TrendChart_SSQ_BQZH(ref ds);
        }

        public static int P_TrendChart_SSQ_BQZH(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSQ_BQZH", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSQ_CGXMB()
        {
            DataSet ds = null;
            return P_TrendChart_SSQ_CGXMB(ref ds);
        }

        public static int P_TrendChart_SSQ_CGXMB(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSQ_CGXMB", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSQ_DX()
        {
            DataSet ds = null;
            return P_TrendChart_SSQ_DX(ref ds);
        }

        public static int P_TrendChart_SSQ_DX(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSQ_DX", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSQ_HL()
        {
            DataSet ds = null;
            return P_TrendChart_SSQ_HL(ref ds);
        }

        public static int P_TrendChart_SSQ_HL(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSQ_HL", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSQ_HMFB()
        {
            DataSet ds = null;
            return P_TrendChart_SSQ_HMFB(ref ds);
        }

        public static int P_TrendChart_SSQ_HMFB(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSQ_HMFB", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSQ_JO()
        {
            DataSet ds = null;
            return P_TrendChart_SSQ_JO(ref ds);
        }

        public static int P_TrendChart_SSQ_JO(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSQ_JO", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_TrendChart_SSQ_ZH()
        {
            DataSet ds = null;
            return P_TrendChart_SSQ_ZH(ref ds);
        }

        public static int P_TrendChart_SSQ_ZH(ref DataSet ds)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_TrendChart_SSQ_ZH", ref ds, ref outputs, new MSSQL.Parameter[0]);
        }

        public static int P_UserAdd(long SiteID, string Name, string RealityName, string Password, string PasswordAdv, int CityID, string Sex, DateTime BirthDay, string IDCardNumber, string Address, string Email, bool isEmailValided, string QQ, bool isQQValided, string Telephone, string Mobile, bool isMobileValided, bool isPrivacy, short UserType, short BankType, string BankName, string BankCardNumber, long CommenderID, long CpsID, string AlipayName, string Memo, string VisitSource, ref long UserID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserAdd(ref ds, SiteID, Name, RealityName, Password, PasswordAdv, CityID, Sex, BirthDay, IDCardNumber, Address, Email, isEmailValided, QQ, isQQValided, Telephone, Mobile, isMobileValided, isPrivacy, UserType, BankType, BankName, BankCardNumber, CommenderID, CpsID, AlipayName, Memo, VisitSource, ref UserID, ref ReturnDescription);
        }

        public static int P_UserAdd(ref DataSet ds, long SiteID, string Name, string RealityName, string Password, string PasswordAdv, int CityID, string Sex, DateTime BirthDay, string IDCardNumber, string Address, string Email, bool isEmailValided, string QQ, bool isQQValided, string Telephone, string Mobile, bool isMobileValided, bool isPrivacy, short UserType, short BankType, string BankName, string BankCardNumber, long CommenderID, long CpsID, string AlipayName, string Memo, string VisitSource, ref long UserID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            MSSQL.Parameter[] paras = new MSSQL.Parameter[] { 
                new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, Name), new MSSQL.Parameter("RealityName", SqlDbType.VarChar, 0, ParameterDirection.Input, RealityName), new MSSQL.Parameter("Password", SqlDbType.VarChar, 0, ParameterDirection.Input, Password), new MSSQL.Parameter("PasswordAdv", SqlDbType.VarChar, 0, ParameterDirection.Input, PasswordAdv), new MSSQL.Parameter("CityID", SqlDbType.Int, 0, ParameterDirection.Input, CityID), new MSSQL.Parameter("Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, Sex), new MSSQL.Parameter("BirthDay", SqlDbType.DateTime, 0, ParameterDirection.Input, BirthDay), new MSSQL.Parameter("IDCardNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, IDCardNumber), new MSSQL.Parameter("Address", SqlDbType.VarChar, 0, ParameterDirection.Input, Address), new MSSQL.Parameter("Email", SqlDbType.VarChar, 0, ParameterDirection.Input, Email), new MSSQL.Parameter("isEmailValided", SqlDbType.Bit, 0, ParameterDirection.Input, isEmailValided), new MSSQL.Parameter("QQ", SqlDbType.VarChar, 0, ParameterDirection.Input, QQ), new MSSQL.Parameter("isQQValided", SqlDbType.Bit, 0, ParameterDirection.Input, isQQValided), new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 0, ParameterDirection.Input, Telephone), new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 0, ParameterDirection.Input, Mobile), 
                new MSSQL.Parameter("isMobileValided", SqlDbType.Bit, 0, ParameterDirection.Input, isMobileValided), new MSSQL.Parameter("isPrivacy", SqlDbType.Bit, 0, ParameterDirection.Input, isPrivacy), new MSSQL.Parameter("UserType", SqlDbType.SmallInt, 0, ParameterDirection.Input, UserType), new MSSQL.Parameter("BankType", SqlDbType.SmallInt, 0, ParameterDirection.Input, BankType), new MSSQL.Parameter("BankName", SqlDbType.VarChar, 0, ParameterDirection.Input, BankName), new MSSQL.Parameter("BankCardNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, BankCardNumber), new MSSQL.Parameter("CommenderID", SqlDbType.BigInt, 0, ParameterDirection.Input, CommenderID), new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 0, ParameterDirection.Input, CpsID), new MSSQL.Parameter("AlipayName", SqlDbType.VarChar, 0, ParameterDirection.Input, AlipayName), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 0, ParameterDirection.Input, Memo), new MSSQL.Parameter("VisitSource", SqlDbType.VarChar, 0, ParameterDirection.Input, VisitSource), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) UserID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             };
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserAdd", ref ds, ref outputs, paras);
            try
            {
                UserID = Convert.ToInt64(outputs["UserID"]);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return num;
        }

        public static int P_UserAddMoney(long SiteID, long UserID, double Money, double FormalitiesFees, string PayNumber, string PayBank, string Memo, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserAddMoney(ref ds, SiteID, UserID, Money, FormalitiesFees, PayNumber, PayBank, Memo, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_UserAddMoney(ref DataSet ds, long SiteID, long UserID, double Money, double FormalitiesFees, string PayNumber, string PayBank, string Memo, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserAddMoney", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Money", SqlDbType.Money, 0, ParameterDirection.Input, Money), new MSSQL.Parameter("FormalitiesFees", SqlDbType.Money, 0, ParameterDirection.Input, FormalitiesFees), new MSSQL.Parameter("PayNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, PayNumber), new MSSQL.Parameter("PayBank", SqlDbType.VarChar, 0, ParameterDirection.Input, PayBank), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 0, ParameterDirection.Input, Memo), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_UserAddMoneyManual(long SiteID, long UserID, double Money, string Memo, long OperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserAddMoneyManual(ref ds, SiteID, UserID, Money, Memo, OperatorID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_UserAddMoneyManual(ref DataSet ds, long SiteID, long UserID, double Money, string Memo, long OperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserAddMoneyManual", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Money", SqlDbType.Money, 0, ParameterDirection.Input, Money), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 0, ParameterDirection.Input, Memo), new MSSQL.Parameter("OperatorID", SqlDbType.BigInt, 0, ParameterDirection.Input, OperatorID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_UserBankDetailEdit(long SiteID, long UserID, string BankTypeName, string BankName, string BankCardNumber, string BankInProvinceName, string BankInCityName, string BankUserName, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserBankDetailEdit(ref ds, SiteID, UserID, BankTypeName, BankName, BankCardNumber, BankInProvinceName, BankInCityName, BankUserName, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_UserBankDetailEdit(ref DataSet ds, long SiteID, long UserID, string BankTypeName, string BankName, string BankCardNumber, string BankInProvinceName, string BankInCityName, string BankUserName, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserBankDetailEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("BankTypeName", SqlDbType.VarChar, 0, ParameterDirection.Input, BankTypeName), new MSSQL.Parameter("BankName", SqlDbType.VarChar, 0, ParameterDirection.Input, BankName), new MSSQL.Parameter("BankCardNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, BankCardNumber), new MSSQL.Parameter("BankInProvinceName", SqlDbType.VarChar, 0, ParameterDirection.Input, BankInProvinceName), new MSSQL.Parameter("BankInCityName", SqlDbType.VarChar, 0, ParameterDirection.Input, BankInCityName), new MSSQL.Parameter("BankUserName", SqlDbType.VarChar, 0, ParameterDirection.Input, BankUserName), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_UserDistillPayByAlipay(long HandleOperatorID, string FileName, string IDs, int PaymentType, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserDistillPayByAlipay(ref ds, HandleOperatorID, FileName, IDs, PaymentType, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_UserDistillPayByAlipay(ref DataSet ds, long HandleOperatorID, string FileName, string IDs, int PaymentType, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserDistillPayByAlipay", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("HandleOperatorID", SqlDbType.BigInt, 0, ParameterDirection.Input, HandleOperatorID), new MSSQL.Parameter("FileName", SqlDbType.VarChar, 0, ParameterDirection.Input, FileName), new MSSQL.Parameter("IDs", SqlDbType.VarChar, 0, ParameterDirection.Input, IDs), new MSSQL.Parameter("PaymentType", SqlDbType.Int, 0, ParameterDirection.Input, PaymentType), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_UserDistillPayByAlipaySuccess(long SiteID, long DistillID, long HandleOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserDistillPayByAlipaySuccess(ref ds, SiteID, DistillID, HandleOperatorID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_UserDistillPayByAlipaySuccess(ref DataSet ds, long SiteID, long DistillID, long HandleOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserDistillPayByAlipaySuccess", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("DistillID", SqlDbType.BigInt, 0, ParameterDirection.Input, DistillID), new MSSQL.Parameter("HandleOperatorID", SqlDbType.BigInt, 0, ParameterDirection.Input, HandleOperatorID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_UserDistillPayByAlipayUnsuccess(long SiteID, long DistillID, string Memo, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserDistillPayByAlipayUnsuccess(ref ds, SiteID, DistillID, Memo, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_UserDistillPayByAlipayUnsuccess(ref DataSet ds, long SiteID, long DistillID, string Memo, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserDistillPayByAlipayUnsuccess", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("DistillID", SqlDbType.BigInt, 0, ParameterDirection.Input, DistillID), new MSSQL.Parameter("Memo", SqlDbType.VarChar, 0, ParameterDirection.Input, Memo), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_UserDistillPayByAlipayWriteLog(string Content)
        {
            DataSet ds = null;
            return P_UserDistillPayByAlipayWriteLog(ref ds, Content);
        }

        public static int P_UserDistillPayByAlipayWriteLog(ref DataSet ds, string Content)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_UserDistillPayByAlipayWriteLog", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content) });
        }

        public static int P_UserEditByID(long SiteID, long UserID, string Name, string RealityName, string Password, string PasswordAdv, int CityID, string Sex, DateTime BirthDay, string IDCardNumber, string Address, string Email, bool isEmailValided, string QQ, bool isQQValided, string Telephone, string Mobile, bool isMobileValided, bool isPrivacy, bool isCanLogin, short UserType, short BankType, string BankName, string BankCardNumber, double ScoringOfSelfBuy, double ScoringOfCommendBuy, short Level, string AlipayID, string AlipayName, bool isAlipayNameValided, double PromotionMemberBonusScale, double PromotionSiteBonusScale, bool isCrossLogin, string Reason, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserEditByID(ref ds, SiteID, UserID, Name, RealityName, Password, PasswordAdv, CityID, Sex, BirthDay, IDCardNumber, Address, Email, isEmailValided, QQ, isQQValided, Telephone, Mobile, isMobileValided, isPrivacy, isCanLogin, UserType, BankType, BankName, BankCardNumber, ScoringOfSelfBuy, ScoringOfCommendBuy, Level, AlipayID, AlipayName, isAlipayNameValided, PromotionMemberBonusScale, PromotionSiteBonusScale, isCrossLogin, Reason, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_UserEditByID(ref DataSet ds, long SiteID, long UserID, string Name, string RealityName, string Password, string PasswordAdv, int CityID, string Sex, DateTime BirthDay, string IDCardNumber, string Address, string Email, bool isEmailValided, string QQ, bool isQQValided, string Telephone, string Mobile, bool isMobileValided, bool isPrivacy, bool isCanLogin, short UserType, short BankType, string BankName, string BankCardNumber, double ScoringOfSelfBuy, double ScoringOfCommendBuy, short Level, string AlipayID, string AlipayName, bool isAlipayNameValided, double PromotionMemberBonusScale, double PromotionSiteBonusScale, bool isCrossLogin, string Reason, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserEditByID", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, Name), new MSSQL.Parameter("RealityName", SqlDbType.VarChar, 0, ParameterDirection.Input, RealityName), new MSSQL.Parameter("Password", SqlDbType.VarChar, 0, ParameterDirection.Input, Password), new MSSQL.Parameter("PasswordAdv", SqlDbType.VarChar, 0, ParameterDirection.Input, PasswordAdv), new MSSQL.Parameter("CityID", SqlDbType.Int, 0, ParameterDirection.Input, CityID), new MSSQL.Parameter("Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, Sex), new MSSQL.Parameter("BirthDay", SqlDbType.DateTime, 0, ParameterDirection.Input, BirthDay), new MSSQL.Parameter("IDCardNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, IDCardNumber), new MSSQL.Parameter("Address", SqlDbType.VarChar, 0, ParameterDirection.Input, Address), new MSSQL.Parameter("Email", SqlDbType.VarChar, 0, ParameterDirection.Input, Email), new MSSQL.Parameter("isEmailValided", SqlDbType.Bit, 0, ParameterDirection.Input, isEmailValided), new MSSQL.Parameter("QQ", SqlDbType.VarChar, 0, ParameterDirection.Input, QQ), new MSSQL.Parameter("isQQValided", SqlDbType.Bit, 0, ParameterDirection.Input, isQQValided), new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 0, ParameterDirection.Input, Telephone), 
                new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 0, ParameterDirection.Input, Mobile), new MSSQL.Parameter("isMobileValided", SqlDbType.Bit, 0, ParameterDirection.Input, isMobileValided), new MSSQL.Parameter("isPrivacy", SqlDbType.Bit, 0, ParameterDirection.Input, isPrivacy), new MSSQL.Parameter("isCanLogin", SqlDbType.Bit, 0, ParameterDirection.Input, isCanLogin), new MSSQL.Parameter("UserType", SqlDbType.SmallInt, 0, ParameterDirection.Input, UserType), new MSSQL.Parameter("BankType", SqlDbType.SmallInt, 0, ParameterDirection.Input, BankType), new MSSQL.Parameter("BankName", SqlDbType.VarChar, 0, ParameterDirection.Input, BankName), new MSSQL.Parameter("BankCardNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, BankCardNumber), new MSSQL.Parameter("ScoringOfSelfBuy", SqlDbType.Float, 0, ParameterDirection.Input, ScoringOfSelfBuy), new MSSQL.Parameter("ScoringOfCommendBuy", SqlDbType.Float, 0, ParameterDirection.Input, ScoringOfCommendBuy), new MSSQL.Parameter("Level", SqlDbType.SmallInt, 0, ParameterDirection.Input, Level), new MSSQL.Parameter("AlipayID", SqlDbType.VarChar, 0, ParameterDirection.Input, AlipayID), new MSSQL.Parameter("AlipayName", SqlDbType.VarChar, 0, ParameterDirection.Input, AlipayName), new MSSQL.Parameter("isAlipayNameValided", SqlDbType.Bit, 0, ParameterDirection.Input, isAlipayNameValided), new MSSQL.Parameter("PromotionMemberBonusScale", SqlDbType.Float, 0, ParameterDirection.Input, PromotionMemberBonusScale), new MSSQL.Parameter("PromotionSiteBonusScale", SqlDbType.Float, 0, ParameterDirection.Input, PromotionSiteBonusScale), 
                new MSSQL.Parameter("isCrossLogin", SqlDbType.Bit, 0, ParameterDirection.Input, isCrossLogin), new MSSQL.Parameter("Reason", SqlDbType.VarChar, 0, ParameterDirection.Input, Reason), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_UserEditByName(long SiteID, long UserID, string Name, string RealityName, string Password, string PasswordAdv, int CityID, string Sex, DateTime BirthDay, string IDCardNumber, string Address, string Email, bool isEmailValided, string QQ, bool isQQValided, string Telephone, string Mobile, bool isMobileValided, bool isPrivacy, bool isCanLogin, short UserType, short BankType, string BankName, string BankCardNumber, double ScoringOfSelfBuy, double ScoringOfCommendBuy, short Level, string AlipayID, string AlipayName, bool isAlipayNameValided, double PromotionMemberBonusScale, double PromotionSiteBonusScale, bool IsCrossLogin, string Reason, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserEditByName(ref ds, SiteID, UserID, Name, RealityName, Password, PasswordAdv, CityID, Sex, BirthDay, IDCardNumber, Address, Email, isEmailValided, QQ, isQQValided, Telephone, Mobile, isMobileValided, isPrivacy, isCanLogin, UserType, BankType, BankName, BankCardNumber, ScoringOfSelfBuy, ScoringOfCommendBuy, Level, AlipayID, AlipayName, isAlipayNameValided, PromotionMemberBonusScale, PromotionSiteBonusScale, IsCrossLogin, Reason, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_UserEditByName(ref DataSet ds, long SiteID, long UserID, string Name, string RealityName, string Password, string PasswordAdv, int CityID, string Sex, DateTime BirthDay, string IDCardNumber, string Address, string Email, bool isEmailValided, string QQ, bool isQQValided, string Telephone, string Mobile, bool isMobileValided, bool isPrivacy, bool isCanLogin, short UserType, short BankType, string BankName, string BankCardNumber, double ScoringOfSelfBuy, double ScoringOfCommendBuy, short Level, string AlipayID, string AlipayName, bool isAlipayNameValided, double PromotionMemberBonusScale, double PromotionSiteBonusScale, bool IsCrossLogin, string Reason, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserEditByName", ref ds, ref outputs, new MSSQL.Parameter[] { 
                new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, Name), new MSSQL.Parameter("RealityName", SqlDbType.VarChar, 0, ParameterDirection.Input, RealityName), new MSSQL.Parameter("Password", SqlDbType.VarChar, 0, ParameterDirection.Input, Password), new MSSQL.Parameter("PasswordAdv", SqlDbType.VarChar, 0, ParameterDirection.Input, PasswordAdv), new MSSQL.Parameter("CityID", SqlDbType.Int, 0, ParameterDirection.Input, CityID), new MSSQL.Parameter("Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, Sex), new MSSQL.Parameter("BirthDay", SqlDbType.DateTime, 0, ParameterDirection.Input, BirthDay), new MSSQL.Parameter("IDCardNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, IDCardNumber), new MSSQL.Parameter("Address", SqlDbType.VarChar, 0, ParameterDirection.Input, Address), new MSSQL.Parameter("Email", SqlDbType.VarChar, 0, ParameterDirection.Input, Email), new MSSQL.Parameter("isEmailValided", SqlDbType.Bit, 0, ParameterDirection.Input, isEmailValided), new MSSQL.Parameter("QQ", SqlDbType.VarChar, 0, ParameterDirection.Input, QQ), new MSSQL.Parameter("isQQValided", SqlDbType.Bit, 0, ParameterDirection.Input, isQQValided), new MSSQL.Parameter("Telephone", SqlDbType.VarChar, 0, ParameterDirection.Input, Telephone), 
                new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 0, ParameterDirection.Input, Mobile), new MSSQL.Parameter("isMobileValided", SqlDbType.Bit, 0, ParameterDirection.Input, isMobileValided), new MSSQL.Parameter("isPrivacy", SqlDbType.Bit, 0, ParameterDirection.Input, isPrivacy), new MSSQL.Parameter("isCanLogin", SqlDbType.Bit, 0, ParameterDirection.Input, isCanLogin), new MSSQL.Parameter("UserType", SqlDbType.SmallInt, 0, ParameterDirection.Input, UserType), new MSSQL.Parameter("BankType", SqlDbType.SmallInt, 0, ParameterDirection.Input, BankType), new MSSQL.Parameter("BankName", SqlDbType.VarChar, 0, ParameterDirection.Input, BankName), new MSSQL.Parameter("BankCardNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, BankCardNumber), new MSSQL.Parameter("ScoringOfSelfBuy", SqlDbType.Float, 0, ParameterDirection.Input, ScoringOfSelfBuy), new MSSQL.Parameter("ScoringOfCommendBuy", SqlDbType.Float, 0, ParameterDirection.Input, ScoringOfCommendBuy), new MSSQL.Parameter("Level", SqlDbType.SmallInt, 0, ParameterDirection.Input, Level), new MSSQL.Parameter("AlipayID", SqlDbType.VarChar, 0, ParameterDirection.Input, AlipayID), new MSSQL.Parameter("AlipayName", SqlDbType.VarChar, 0, ParameterDirection.Input, AlipayName), new MSSQL.Parameter("isAlipayNameValided", SqlDbType.Bit, 0, ParameterDirection.Input, isAlipayNameValided), new MSSQL.Parameter("PromotionMemberBonusScale", SqlDbType.Float, 0, ParameterDirection.Input, PromotionMemberBonusScale), new MSSQL.Parameter("PromotionSiteBonusScale", SqlDbType.Float, 0, ParameterDirection.Input, PromotionSiteBonusScale), 
                new MSSQL.Parameter("IsCrossLogin", SqlDbType.Bit, 0, ParameterDirection.Input, IsCrossLogin), new MSSQL.Parameter("Reason", SqlDbType.VarChar, 0, ParameterDirection.Input, Reason), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription)
             });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_UserForInitiateFollowSchemeDelete(long SiteID, long UsersForInitiateFollowSchemeID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserForInitiateFollowSchemeDelete(ref ds, SiteID, UsersForInitiateFollowSchemeID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_UserForInitiateFollowSchemeDelete(ref DataSet ds, long SiteID, long UsersForInitiateFollowSchemeID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserForInitiateFollowSchemeDelete", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UsersForInitiateFollowSchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, UsersForInitiateFollowSchemeID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_UserForInitiateFollowSchemeEdit(long SiteID, long UsersForInitiateFollowSchemeID, string Description, int MaxNumberOf, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserForInitiateFollowSchemeEdit(ref ds, SiteID, UsersForInitiateFollowSchemeID, Description, MaxNumberOf, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_UserForInitiateFollowSchemeEdit(ref DataSet ds, long SiteID, long UsersForInitiateFollowSchemeID, string Description, int MaxNumberOf, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserForInitiateFollowSchemeEdit", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UsersForInitiateFollowSchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, UsersForInitiateFollowSchemeID), new MSSQL.Parameter("Description", SqlDbType.VarChar, 0, ParameterDirection.Input, Description), new MSSQL.Parameter("MaxNumberOf", SqlDbType.Int, 0, ParameterDirection.Input, MaxNumberOf), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_UserForInitiateFollowSchemeTry(long SiteID, long UserID, int PlayTypeID, string Description, ref long NewUserForInitiateFollowSchemeTryID, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserForInitiateFollowSchemeTry(ref ds, SiteID, UserID, PlayTypeID, Description, ref NewUserForInitiateFollowSchemeTryID, ref ReturnDescription);
        }

        public static int P_UserForInitiateFollowSchemeTry(ref DataSet ds, long SiteID, long UserID, int PlayTypeID, string Description, ref long NewUserForInitiateFollowSchemeTryID, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserForInitiateFollowSchemeTry", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, PlayTypeID), new MSSQL.Parameter("Description", SqlDbType.VarChar, 0, ParameterDirection.Input, Description), new MSSQL.Parameter("NewUserForInitiateFollowSchemeTryID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewUserForInitiateFollowSchemeTryID), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                NewUserForInitiateFollowSchemeTryID = Convert.ToInt64(outputs["NewUserForInitiateFollowSchemeTryID"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_UserForInitiateFollowSchemeTryHandle(long SiteID, long UserForInitiateFollowSchemeTryID, short HandleResult, string Description, int MaxNumberOf, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserForInitiateFollowSchemeTryHandle(ref ds, SiteID, UserForInitiateFollowSchemeTryID, HandleResult, Description, MaxNumberOf, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_UserForInitiateFollowSchemeTryHandle(ref DataSet ds, long SiteID, long UserForInitiateFollowSchemeTryID, short HandleResult, string Description, int MaxNumberOf, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserForInitiateFollowSchemeTryHandle", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserForInitiateFollowSchemeTryID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserForInitiateFollowSchemeTryID), new MSSQL.Parameter("HandleResult", SqlDbType.SmallInt, 0, ParameterDirection.Input, HandleResult), new MSSQL.Parameter("Description", SqlDbType.VarChar, 0, ParameterDirection.Input, Description), new MSSQL.Parameter("MaxNumberOf", SqlDbType.Int, 0, ParameterDirection.Input, MaxNumberOf), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_UserLogOut(long SiteID, long UserID, string Reason, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserLogOut(ref ds, SiteID, UserID, Reason, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_UserLogOut(ref DataSet ds, long SiteID, long UserID, string Reason, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserLogOut", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Reason", SqlDbType.VarChar, 0, ParameterDirection.Input, Reason), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_UserPaySMSCost(long SiteID, long UserID, string Mobile, int Num, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserPaySMSCost(ref ds, SiteID, UserID, Mobile, Num, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_UserPaySMSCost(ref DataSet ds, long SiteID, long UserID, string Mobile, int Num, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserPaySMSCost", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Mobile", SqlDbType.VarChar, 0, ParameterDirection.Input, Mobile), new MSSQL.Parameter("Num", SqlDbType.Int, 0, ParameterDirection.Input, Num), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_UserQQBind(long UserID, string QQ, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_UserQQBind(ref ds, UserID, QQ, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_UserQQBind(ref DataSet ds, long UserID, string QQ, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_UserQQBind", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("QQ", SqlDbType.VarChar, 0, ParameterDirection.Input, QQ), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 50, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_ViewUserBonus(long userid, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_ViewUserBonus(ref ds, userid, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_ViewUserBonus(ref DataSet ds, long userid, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_ViewUserBonus", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("userid", SqlDbType.BigInt, 0, ParameterDirection.Input, userid), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_Win(long IsuseID, string WinLotteryNumber, string OpenAffiche, long OpenOperatorID, bool isEndTheIsuse, ref int SchemeCount, ref int QuashCount, ref int WinCount, ref int WinNoBuyCount, ref bool isEndOpen, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_Win(ref ds, IsuseID, WinLotteryNumber, OpenAffiche, OpenOperatorID, isEndTheIsuse, ref SchemeCount, ref QuashCount, ref WinCount, ref WinNoBuyCount, ref isEndOpen, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_Win(ref DataSet ds, long IsuseID, string WinLotteryNumber, string OpenAffiche, long OpenOperatorID, bool isEndTheIsuse, ref int SchemeCount, ref int QuashCount, ref int WinCount, ref int WinNoBuyCount, ref bool isEndOpen, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_Win", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID), new MSSQL.Parameter("WinLotteryNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, WinLotteryNumber), new MSSQL.Parameter("OpenAffiche", SqlDbType.VarChar, 0, ParameterDirection.Input, OpenAffiche), new MSSQL.Parameter("OpenOperatorID", SqlDbType.BigInt, 0, ParameterDirection.Input, OpenOperatorID), new MSSQL.Parameter("isEndTheIsuse", SqlDbType.Bit, 0, ParameterDirection.Input, isEndTheIsuse), new MSSQL.Parameter("SchemeCount", SqlDbType.Int, 4, ParameterDirection.Output, (int) SchemeCount), new MSSQL.Parameter("QuashCount", SqlDbType.Int, 4, ParameterDirection.Output, (int) QuashCount), new MSSQL.Parameter("WinCount", SqlDbType.Int, 4, ParameterDirection.Output, (int) WinCount), new MSSQL.Parameter("WinNoBuyCount", SqlDbType.Int, 4, ParameterDirection.Output, (int) WinNoBuyCount), new MSSQL.Parameter("isEndOpen", SqlDbType.Bit, 1, ParameterDirection.Output, (bool) isEndOpen), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                SchemeCount = Convert.ToInt32(outputs["SchemeCount"]);
            }
            catch
            {
            }
            try
            {
                QuashCount = Convert.ToInt32(outputs["QuashCount"]);
            }
            catch
            {
            }
            try
            {
                WinCount = Convert.ToInt32(outputs["WinCount"]);
            }
            catch
            {
            }
            try
            {
                WinNoBuyCount = Convert.ToInt32(outputs["WinNoBuyCount"]);
            }
            catch
            {
            }
            try
            {
                isEndOpen = Convert.ToBoolean(outputs["isEndOpen"]);
            }
            catch
            {
            }
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_WinByOpenManual(long SiteID, long SchemeID, double WinMoney, double WinMoneyNoWithTax, string WinDescription, long OpenOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_WinByOpenManual(ref ds, SiteID, SchemeID, WinMoney, WinMoneyNoWithTax, WinDescription, OpenOperatorID, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_WinByOpenManual(ref DataSet ds, long SiteID, long SchemeID, double WinMoney, double WinMoneyNoWithTax, string WinDescription, long OpenOperatorID, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_WinByOpenManual", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("WinMoney", SqlDbType.Money, 0, ParameterDirection.Input, WinMoney), new MSSQL.Parameter("WinMoneyNoWithTax", SqlDbType.Money, 0, ParameterDirection.Input, WinMoneyNoWithTax), new MSSQL.Parameter("WinDescription", SqlDbType.VarChar, 0, ParameterDirection.Input, WinDescription), new MSSQL.Parameter("OpenOperatorID", SqlDbType.BigInt, 0, ParameterDirection.Input, OpenOperatorID), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_WriteSchemeChatContents(long SiteID, long SchemeID, long FromUserID, long ToUserID, short Type, string Content, ref int ReturnValue, ref string ReturnDescription)
        {
            DataSet ds = null;
            return P_WriteSchemeChatContents(ref ds, SiteID, SchemeID, FromUserID, ToUserID, Type, Content, ref ReturnValue, ref ReturnDescription);
        }

        public static int P_WriteSchemeChatContents(ref DataSet ds, long SiteID, long SchemeID, long FromUserID, long ToUserID, short Type, string Content, ref int ReturnValue, ref string ReturnDescription)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_WriteSchemeChatContents", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID), new MSSQL.Parameter("FromUserID", SqlDbType.BigInt, 0, ParameterDirection.Input, FromUserID), new MSSQL.Parameter("ToUserID", SqlDbType.BigInt, 0, ParameterDirection.Input, ToUserID), new MSSQL.Parameter("Type", SqlDbType.SmallInt, 0, ParameterDirection.Input, Type), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.Output, (int) ReturnValue), new MSSQL.Parameter("ReturnDescription", SqlDbType.VarChar, 100, ParameterDirection.Output, ReturnDescription) });
            try
            {
                ReturnValue = Convert.ToInt32(outputs["ReturnValue"]);
            }
            catch
            {
            }
            try
            {
                ReturnDescription = Convert.ToString(outputs["ReturnDescription"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_WriteSMS(long SiteID, long SMSID, string From, string To, string Content, ref long NewSMSID)
        {
            DataSet ds = null;
            return P_WriteSMS(ref ds, SiteID, SMSID, From, To, Content, ref NewSMSID);
        }

        public static int P_WriteSMS(ref DataSet ds, long SiteID, long SMSID, string From, string To, string Content, ref long NewSMSID)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_WriteSMS", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("SMSID", SqlDbType.BigInt, 0, ParameterDirection.Input, SMSID), new MSSQL.Parameter("From", SqlDbType.VarChar, 0, ParameterDirection.Input, From), new MSSQL.Parameter("To", SqlDbType.VarChar, 0, ParameterDirection.Input, To), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("NewSMSID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewSMSID) });
            try
            {
                NewSMSID = Convert.ToInt64(outputs["NewSMSID"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_WriteStationSMS(long SiteID, long SourceID, long AimID, short Type, string Content, ref long NewSMSID)
        {
            DataSet ds = null;
            return P_WriteStationSMS(ref ds, SiteID, SourceID, AimID, Type, Content, ref NewSMSID);
        }

        public static int P_WriteStationSMS(ref DataSet ds, long SiteID, long SourceID, long AimID, short Type, string Content, ref long NewSMSID)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            int num = MSSQL.ExecuteStoredProcedureWithQuery("P_WriteStationSMS", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("SourceID", SqlDbType.BigInt, 0, ParameterDirection.Input, SourceID), new MSSQL.Parameter("AimID", SqlDbType.BigInt, 0, ParameterDirection.Input, AimID), new MSSQL.Parameter("Type", SqlDbType.SmallInt, 0, ParameterDirection.Input, Type), new MSSQL.Parameter("Content", SqlDbType.VarChar, 0, ParameterDirection.Input, Content), new MSSQL.Parameter("NewSMSID", SqlDbType.BigInt, 8, ParameterDirection.Output, (long) NewSMSID) });
            try
            {
                NewSMSID = Convert.ToInt64(outputs["NewSMSID"]);
            }
            catch
            {
            }
            return num;
        }

        public static int P_WriteSystemLog(long SiteID, long UserID, string IPAddress, short Description)
        {
            DataSet ds = null;
            return P_WriteSystemLog(ref ds, SiteID, UserID, IPAddress, Description);
        }

        public static int P_WriteSystemLog(ref DataSet ds, long SiteID, long UserID, string IPAddress, short Description)
        {
            MSSQL.OutputParameter outputs = new MSSQL.OutputParameter();
            return MSSQL.ExecuteStoredProcedureWithQuery("P_WriteSystemLog", ref ds, ref outputs, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("IPAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, IPAddress), new MSSQL.Parameter("Description", SqlDbType.SmallInt, 0, ParameterDirection.Input, Description) });
        }
    }
}

