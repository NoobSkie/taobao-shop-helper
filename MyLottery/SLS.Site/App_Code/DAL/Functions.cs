using Shove.Database;
using System;
using System.Data;

namespace SLS.Site.App_Code.DAL
{
    public class Functions
    {
        public static int F_AccumulateMember(long SiteID, long UserID, DateTime StartTime, DateTime EndTime, int type)
        {
            return Convert.ToInt32(MSSQL.ExecuteFunction("F_AccumulateMember", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("type", SqlDbType.Int, 0, ParameterDirection.Input, type) }));
        }

        public static double F_CalculationFollowSchemesMoney(double RemainingMoney, int RemainingShare, double FollowSchemesMoney)
        {
            return Convert.ToDouble(MSSQL.ExecuteFunction("F_CalculationFollowSchemesMoney", new MSSQL.Parameter[] { new MSSQL.Parameter("RemainingMoney", SqlDbType.Money, 0, ParameterDirection.Input, RemainingMoney), new MSSQL.Parameter("RemainingShare", SqlDbType.Int, 0, ParameterDirection.Input, RemainingShare), new MSSQL.Parameter("FollowSchemesMoney", SqlDbType.Money, 0, ParameterDirection.Input, FollowSchemesMoney) }));
        }

        public static bool F_ComparisonLotteryList(string ParentLotteryList, string SubLotteryList)
        {
            return Convert.ToBoolean(MSSQL.ExecuteFunction("F_ComparisonLotteryList", new MSSQL.Parameter[] { new MSSQL.Parameter("ParentLotteryList", SqlDbType.VarChar, 0, ParameterDirection.Input, ParentLotteryList), new MSSQL.Parameter("SubLotteryList", SqlDbType.VarChar, 0, ParameterDirection.Input, SubLotteryList) }));
        }

        public static double F_CpsGetCpsBonusScale(long CpsID, long LotteryID)
        {
            return Convert.ToDouble(MSSQL.ExecuteFunction("F_CpsGetCpsBonusScale", new MSSQL.Parameter[] { new MSSQL.Parameter("CpsID", SqlDbType.BigInt, 0, ParameterDirection.Input, CpsID), new MSSQL.Parameter("LotteryID", SqlDbType.BigInt, 0, ParameterDirection.Input, LotteryID) }));
        }

        public static int F_CpsMemberAccumulateBuyerMember(long SiteID, long UserID)
        {
            return Convert.ToInt32(MSSQL.ExecuteFunction("F_CpsMemberAccumulateBuyerMember", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID) }));
        }

        public static int F_CpsMemberAccumulateWebSite(long SiteID, long UserID)
        {
            return Convert.ToInt32(MSSQL.ExecuteFunction("F_CpsMemberAccumulateWebSite", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID) }));
        }

        public static int F_CurrentDateRegMember(long SiteID, long UserID, DateTime StartTime, DateTime EndTime, int type)
        {
            return Convert.ToInt32(MSSQL.ExecuteFunction("F_CurrentDateRegMember", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("type", SqlDbType.Int, 0, ParameterDirection.Input, type) }));
        }

        public static double F_CurrentDateRegMemberPayMoney(long SiteID, long UserID, DateTime CurrentDate, int type)
        {
            return Convert.ToDouble(MSSQL.ExecuteFunction("F_CurrentDateRegMemberPayMoney", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("CurrentDate", SqlDbType.DateTime, 0, ParameterDirection.Input, CurrentDate), new MSSQL.Parameter("type", SqlDbType.Int, 0, ParameterDirection.Input, type) }));
        }

        public static double F_CurrentDateRegMemberPayMoneyBonusScale(long SiteID, long UserID, DateTime CurrentDate, int type)
        {
            return Convert.ToDouble(MSSQL.ExecuteFunction("F_CurrentDateRegMemberPayMoneyBonusScale", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("CurrentDate", SqlDbType.DateTime, 0, ParameterDirection.Input, CurrentDate), new MSSQL.Parameter("type", SqlDbType.Int, 0, ParameterDirection.Input, type) }));
        }

        public static double F_CurrentDateRegMemberPayMoneyBonusScale_all(long SiteID, long UserID, DateTime CurrentDate)
        {
            return Convert.ToDouble(MSSQL.ExecuteFunction("F_CurrentDateRegMemberPayMoneyBonusScale_all", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("CurrentDate", SqlDbType.DateTime, 0, ParameterDirection.Input, CurrentDate) }));
        }

        public static double F_CurrentDateRegMemberPayMoneyBonusScale_today(long SiteID, long UserID, DateTime CurrentDate)
        {
            return Convert.ToDouble(MSSQL.ExecuteFunction("F_CurrentDateRegMemberPayMoneyBonusScale_today", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("CurrentDate", SqlDbType.DateTime, 0, ParameterDirection.Input, CurrentDate) }));
        }

        public static double F_CurrentDateRegMemberPayMoneyBonusScaleSite(long SiteID, long UserID, DateTime CurrentDate)
        {
            return Convert.ToDouble(MSSQL.ExecuteFunction("F_CurrentDateRegMemberPayMoneyBonusScaleSite", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("CurrentDate", SqlDbType.DateTime, 0, ParameterDirection.Input, CurrentDate) }));
        }

        public static double F_CurrentDateRegMemberPayMoneyBonusScaleSite_all(long SiteID, long UserID, DateTime CurrentDate)
        {
            return Convert.ToDouble(MSSQL.ExecuteFunction("F_CurrentDateRegMemberPayMoneyBonusScaleSite_all", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("CurrentDate", SqlDbType.DateTime, 0, ParameterDirection.Input, CurrentDate) }));
        }

        public static double F_CurrentDateRegMemberPayMoneyBonusScaleSite_today(long SiteID, long UserID, DateTime CurrentDate)
        {
            return Convert.ToDouble(MSSQL.ExecuteFunction("F_CurrentDateRegMemberPayMoneyBonusScaleSite_today", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("CurrentDate", SqlDbType.DateTime, 0, ParameterDirection.Input, CurrentDate) }));
        }

        public static int F_CurrentDateRegPayMember(long SiteID, long UserID, DateTime CurrentDate, int type)
        {
            return Convert.ToInt32(MSSQL.ExecuteFunction("F_CurrentDateRegPayMember", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("CurrentDate", SqlDbType.DateTime, 0, ParameterDirection.Input, CurrentDate), new MSSQL.Parameter("type", SqlDbType.Int, 0, ParameterDirection.Input, type) }));
        }

        public static double F_CurrentMonthMemberRecWebSitePayMoney(long SiteID, long UserID, DateTime CurrentDate, int type)
        {
            return Convert.ToDouble(MSSQL.ExecuteFunction("F_CurrentMonthMemberRecWebSitePayMoney", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("CurrentDate", SqlDbType.DateTime, 0, ParameterDirection.Input, CurrentDate), new MSSQL.Parameter("type", SqlDbType.Int, 0, ParameterDirection.Input, type) }));
        }

        public static string F_DateTimeToYYMMDD(DateTime Dt)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_DateTimeToYYMMDD", new MSSQL.Parameter[] { new MSSQL.Parameter("Dt", SqlDbType.DateTime, 0, ParameterDirection.Input, Dt) }));
        }

        public static string F_DateTimeToYYMMDDHHMMSS(DateTime Dt)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_DateTimeToYYMMDDHHMMSS", new MSSQL.Parameter[] { new MSSQL.Parameter("Dt", SqlDbType.DateTime, 0, ParameterDirection.Input, Dt) }));
        }

        public static string F_GetBankTypeName(short BankTypeID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetBankTypeName", new MSSQL.Parameter[] { new MSSQL.Parameter("BankTypeID", SqlDbType.SmallInt, 0, ParameterDirection.Input, BankTypeID) }));
        }

        public static short F_GetDetailsOperatorType(string OperatorType)
        {
            return Convert.ToInt16(MSSQL.ExecuteFunction("F_GetDetailsOperatorType", new MSSQL.Parameter[] { new MSSQL.Parameter("OperatorType", SqlDbType.VarChar, 0, ParameterDirection.Input, OperatorType) }));
        }

        public static string F_GetExpertsLotteryList(long SiteID, long UserID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetExpertsLotteryList", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID) }));
        }

        public static bool F_GetIsAdministrator(long SiteID, long UserID)
        {
            return Convert.ToBoolean(MSSQL.ExecuteFunction("F_GetIsAdministrator", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID) }));
        }

        public static bool F_GetIsSendNotification(long SiteID, short Manner, string NotificationCode, long UserID)
        {
            return Convert.ToBoolean(MSSQL.ExecuteFunction("F_GetIsSendNotification", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("Manner", SqlDbType.SmallInt, 0, ParameterDirection.Input, Manner), new MSSQL.Parameter("NotificationCode", SqlDbType.VarChar, 0, ParameterDirection.Input, NotificationCode), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID) }));
        }

        public static DateTime F_GetIsuseChaseExecuteTime(long IsuseID)
        {
            return Convert.ToDateTime(MSSQL.ExecuteFunction("F_GetIsuseChaseExecuteTime", new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID) }));
        }

        public static string F_GetIsuseCount(int LotteryID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetIsuseCount", new MSSQL.Parameter[] { new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID) }));
        }

        public static DateTime F_GetIsuseEndTime(long IsuseID)
        {
            return Convert.ToDateTime(MSSQL.ExecuteFunction("F_GetIsuseEndTime", new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID) }));
        }

        public static DateTime F_GetIsuseStartTime(long IsuseID)
        {
            return Convert.ToDateTime(MSSQL.ExecuteFunction("F_GetIsuseStartTime", new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID) }));
        }

        public static DateTime F_GetIsuseSystemEndTime(long IsuseID, int PlayTypeID)
        {
            return Convert.ToDateTime(MSSQL.ExecuteFunction("F_GetIsuseSystemEndTime", new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID), new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, PlayTypeID) }));
        }

        public static DataTable F_GetLotteryCanChaseIsuses(int LotteryID, int PlayType)
        {
            return MSSQL.Select("select * from F_GetLotteryCanChaseIsuses(@LotteryID, @PlayType)", new MSSQL.Parameter[] { new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID), new MSSQL.Parameter("PlayType", SqlDbType.Int, 0, ParameterDirection.Input, PlayType) });
        }

        public static string F_GetLotteryCode(int LotteryID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetLotteryCode", new MSSQL.Parameter[] { new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID) }));
        }

        public static string F_GetLotteryIntervalType(int LotteryID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetLotteryIntervalType", new MSSQL.Parameter[] { new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID) }));
        }

        public static bool F_GetLotteryIsUsed(long SiteID, int LotteryID)
        {
            return Convert.ToBoolean(MSSQL.ExecuteFunction("F_GetLotteryIsUsed", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID) }));
        }

        public static string F_GetLotteryName(int LotteryID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetLotteryName", new MSSQL.Parameter[] { new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID) }));
        }

        public static short F_GetLotteryPrintOutType(int LotteryID)
        {
            return Convert.ToInt16(MSSQL.ExecuteFunction("F_GetLotteryPrintOutType", new MSSQL.Parameter[] { new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID) }));
        }

        public static string F_GetLotteryType2Name(short Type2)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetLotteryType2Name", new MSSQL.Parameter[] { new MSSQL.Parameter("Type2", SqlDbType.SmallInt, 0, ParameterDirection.Input, Type2) }));
        }

        public static string F_GetLotteryWinNumberExemple(int LotteryID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetLotteryWinNumberExemple", new MSSQL.Parameter[] { new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID) }));
        }

        public static DataTable F_GetManagers(long SiteID)
        {
            return MSSQL.Select("select * from F_GetManagers(@SiteID)", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID) });
        }

        public static long F_GetMasterSiteID()
        {
            return Convert.ToInt64(MSSQL.ExecuteFunction("F_GetMasterSiteID", new MSSQL.Parameter[0]));
        }

        public static int F_GetMaxMultiple(long IsuseID, int PlayTypeID)
        {
            return Convert.ToInt32(MSSQL.ExecuteFunction("F_GetMaxMultiple", new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, IsuseID), new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, PlayTypeID) }));
        }

        public static string F_GetOptions(string Key)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetOptions", new MSSQL.Parameter[] { new MSSQL.Parameter("Key", SqlDbType.VarChar, 0, ParameterDirection.Input, Key) }));
        }

        public static string F_GetPlaceFromIPAddress(string IPAddress)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetPlaceFromIPAddress", new MSSQL.Parameter[] { new MSSQL.Parameter("IPAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, IPAddress) }));
        }

        public static string F_GetPlayTypeName(int PlayTypeID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetPlayTypeName", new MSSQL.Parameter[] { new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, PlayTypeID) }));
        }

        public static string F_GetProvinceCity(int CityID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetProvinceCity", new MSSQL.Parameter[] { new MSSQL.Parameter("CityID", SqlDbType.Int, 0, ParameterDirection.Input, CityID) }));
        }

        public static long F_GetSchemeInitiateUserID(long SiteID, long SchemeID)
        {
            return Convert.ToInt64(MSSQL.ExecuteFunction("F_GetSchemeInitiateUserID", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID) }));
        }

        public static string F_GetSchemeOpenUsers(long SchemeID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetSchemeOpenUsers", new MSSQL.Parameter[] { new MSSQL.Parameter("SchemeID", SqlDbType.BigInt, 0, ParameterDirection.Input, SchemeID) }));
        }

        public static short F_GetScoringDetailsOperatorType(string OperatorType)
        {
            return Convert.ToInt16(MSSQL.ExecuteFunction("F_GetScoringDetailsOperatorType", new MSSQL.Parameter[] { new MSSQL.Parameter("OperatorType", SqlDbType.VarChar, 0, ParameterDirection.Input, OperatorType) }));
        }

        public static DataTable F_GetSiteAdministrator(long SiteID)
        {
            return MSSQL.Select("select * from F_GetSiteAdministrator(@SiteID)", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID) });
        }

        public static DataTable F_GetSiteAdministrators(long SiteID)
        {
            return MSSQL.Select("select * from F_GetSiteAdministrators(@SiteID)", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID) });
        }

        public static long F_GetSiteOwnerUserID(long SiteID)
        {
            return Convert.ToInt64(MSSQL.ExecuteFunction("F_GetSiteOwnerUserID", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID) }));
        }

        public static long F_GetSiteParentID(long SiteID)
        {
            return Convert.ToInt64(MSSQL.ExecuteFunction("F_GetSiteParentID", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID) }));
        }

        public static string F_GetSiteSendNotificationTypes(long SiteID, short Manner)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetSiteSendNotificationTypes", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("Manner", SqlDbType.SmallInt, 0, ParameterDirection.Input, Manner) }));
        }

        public static string F_GetSiteUrls(long SiteID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetSiteUrls", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID) }));
        }

        public static int F_GetSystemEndAheadMinute(int PlayTypeID)
        {
            return Convert.ToInt32(MSSQL.ExecuteFunction("F_GetSystemEndAheadMinute", new MSSQL.Parameter[] { new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, PlayTypeID) }));
        }

        public static string F_GetUsedLotteryList(long SiteID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetUsedLotteryList", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID) }));
        }

        public static string F_GetUsedLotteryListQuickBuy(long SiteID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetUsedLotteryListQuickBuy", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID) }));
        }

        public static string F_GetUsedLotteryListRestrictions(long SiteID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetUsedLotteryListRestrictions", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID) }));
        }

        public static string F_GetUsedLotteryNameList(long SiteID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetUsedLotteryNameList", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID) }));
        }

        public static string F_GetUsedLotteryNameListQuickBuy(long SiteID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetUsedLotteryNameListQuickBuy", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID) }));
        }

        public static string F_GetUsedLotteryNameListRestrictions(long SiteID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetUsedLotteryNameListRestrictions", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID) }));
        }

        public static string F_GetUserAcceptNotificationTypes(long UserID, short Manner)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetUserAcceptNotificationTypes", new MSSQL.Parameter[] { new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("Manner", SqlDbType.SmallInt, 0, ParameterDirection.Input, Manner) }));
        }

        public static long F_GetUserCommenderID(long UserID)
        {
            return Convert.ToInt64(MSSQL.ExecuteFunction("F_GetUserCommenderID", new MSSQL.Parameter[] { new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID) }));
        }

        public static string F_GetUserCompetencesList(long UserID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetUserCompetencesList", new MSSQL.Parameter[] { new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID) }));
        }

        public static long F_GetUserIDByName(long SiteID, string Name)
        {
            return Convert.ToInt64(MSSQL.ExecuteFunction("F_GetUserIDByName", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, Name) }));
        }

        public static string F_GetUserNameByID(long SiteID, long ID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetUserNameByID", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, ID) }));
        }

        public static string F_GetUserOwnerSitesList(long UserID)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_GetUserOwnerSitesList", new MSSQL.Parameter[] { new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID) }));
        }

        public static DataTable F_GetWinLotteryNumber(long SiteID, int LotteryID)
        {
            return MSSQL.Select("select * from F_GetWinLotteryNumber(@SiteID, @LotteryID)", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID) });
        }

        public static long F_IPAddressToInt64(string IPAddress)
        {
            return Convert.ToInt64(MSSQL.ExecuteFunction("F_IPAddressToInt64", new MSSQL.Parameter[] { new MSSQL.Parameter("IPAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, IPAddress) }));
        }

        public static bool F_IsDivisibility(double Dividend, double Divisor)
        {
            return Convert.ToBoolean(MSSQL.ExecuteFunction("F_IsDivisibility", new MSSQL.Parameter[] { new MSSQL.Parameter("Dividend", SqlDbType.Float, 0, ParameterDirection.Input, Dividend), new MSSQL.Parameter("Divisor", SqlDbType.Float, 0, ParameterDirection.Input, Divisor) }));
        }

        public static double F_MonthPayMoneyShopBonusScale(long SiteID, long UserID, DateTime StartTime, DateTime EndTime, int type)
        {
            return Convert.ToDouble(MSSQL.ExecuteFunction("F_MonthPayMoneyShopBonusScale", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("type", SqlDbType.Int, 0, ParameterDirection.Input, type) }));
        }

        public static double F_MonthShopPayMoney(long SiteID, long UserID, DateTime StartTime, DateTime EndTime, int type)
        {
            return Convert.ToDouble(MSSQL.ExecuteFunction("F_MonthShopPayMoney", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime), new MSSQL.Parameter("type", SqlDbType.Int, 0, ParameterDirection.Input, type) }));
        }

        public static string F_PadLeft(string str, string FillChar, int Len)
        {
            return Convert.ToString(MSSQL.ExecuteFunction("F_PadLeft", new MSSQL.Parameter[] { new MSSQL.Parameter("str", SqlDbType.VarChar, 0, ParameterDirection.Input, str), new MSSQL.Parameter("FillChar", SqlDbType.Char, 0, ParameterDirection.Input, FillChar), new MSSQL.Parameter("Len", SqlDbType.Int, 0, ParameterDirection.Input, Len) }));
        }

        public static DataTable F_SplitString(string SplitString, string Separator)
        {
            return MSSQL.Select("select * from F_SplitString(@SplitString, @Separator)", new MSSQL.Parameter[] { new MSSQL.Parameter("SplitString", SqlDbType.VarChar, 0, ParameterDirection.Input, SplitString), new MSSQL.Parameter("Separator", SqlDbType.VarChar, 0, ParameterDirection.Input, Separator) });
        }

        public static double F_UnionSitePayMoney(long SiteID, long UserID, DateTime StartTime, DateTime EndTime)
        {
            return Convert.ToDouble(MSSQL.ExecuteFunction("F_UnionSitePayMoney", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, StartTime), new MSSQL.Parameter("EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, EndTime) }));
        }

        public static double F_WebSitePayMoney(long SiteID, long UserID, DateTime StartDate, DateTime EndDate, int type)
        {
            return Convert.ToDouble(MSSQL.ExecuteFunction("F_WebSitePayMoney", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.BigInt, 0, ParameterDirection.Input, SiteID), new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, UserID), new MSSQL.Parameter("StartDate", SqlDbType.DateTime, 0, ParameterDirection.Input, StartDate), new MSSQL.Parameter("EndDate", SqlDbType.DateTime, 0, ParameterDirection.Input, EndDate), new MSSQL.Parameter("type", SqlDbType.Int, 0, ParameterDirection.Input, type) }));
        }
    }
}

