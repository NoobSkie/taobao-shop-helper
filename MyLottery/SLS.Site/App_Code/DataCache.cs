using SLS.Site.App_Code.DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Shove._IO;

namespace SLS.Site.App_Code
{
    public class DataCache
    {
        public static readonly string AccountFreezeDetail = "DataCache_AccountFreezeDetail";
        public static readonly string AcountDistill = "DataCache_AcountDistill";
        public static Dictionary<short, string> Banks = new Dictionary<short, string>();
        public static Dictionary<string, int> Citys = new Dictionary<string, int>();
        public static readonly string IsusesInfo = "DataCache_IsusesInfo";
        public static Dictionary<int, string> Lotteries = new Dictionary<int, string>();
        public static Dictionary<int, int> LotteryEndAheadMinute = new Dictionary<int, int>();
        public static readonly string LotteryNews = "DataCache_LotteryNews";
        public static Dictionary<int, Dictionary<int, string>> PlayTypes = new Dictionary<int, Dictionary<int, string>>();
        public static readonly string ProfitInfo = "DataCache_ProfitInfo";
        public static string[] SecurityQuestions = new string[8];
        public static readonly string WinInfo = "DataCache_WinInfo";
        public static readonly string WinNews = "DataCache_WinNews";
        public static readonly string WinNumber = "DataCache_WinNumber";
        public static readonly string ZCExpert = "DataCache_ZCExpert";

        static DataCache()
        {
            DataTable table = new Tables.T_Banks().Open("ID,Name", "", "");
            if (table == null)
            {
                new Log("SNS").Write("PublicFunction 读取 T_Banks 出错");
            }
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    Banks[short.Parse(row["ID"].ToString())] = row["Name"].ToString();
                }
            }
            table = new Tables.T_Citys().Open("ID,Name", "", "");
            if (table == null)
            {
                new Log("SNS").Write("PublicFunction 读取 T_Citys 出错");
            }
            if (table != null)
            {
                foreach (DataRow row2 in table.Rows)
                {
                    Citys[row2["Name"].ToString()] = int.Parse(row2["ID"].ToString());
                }
            }
            SecurityQuestions[0] = "我婆婆或岳母的名字叫什么？";
            SecurityQuestions[1] = "我爸爸的出生地在哪里？";
            SecurityQuestions[2] = "我妈妈的出生地在哪里？";
            SecurityQuestions[3] = "我的小学校名是什么？";
            SecurityQuestions[4] = "我的中学校名是什么？";
            SecurityQuestions[5] = "我的一个好朋友的手机号码是什么？";
            SecurityQuestions[6] = "我的一个好朋友的爸爸名字是什么？";
            SecurityQuestions[7] = "自定义问题";
            Lotteries[3] = "七星彩";
            Lotteries[5] = "双色球";
            Lotteries[6] = "福彩3D";
            Lotteries[0x1c] = "重庆时时彩";
            Lotteries[0x1d] = "时时乐";
            Lotteries[0x27] = "大乐透";
            Lotteries[0x3a] = "东方6+1";
            Lotteries[0x3b] = "15选5";
            Lotteries[13] = "七乐彩";
            Lotteries[9] = "22选5";
            Lotteries[14] = "29选7";
            Lotteries[0x3f] = "排列3";
            Lotteries[0x40] = "排列5";
            Lotteries[0x13] = "篮彩";
            Lotteries[1] = "胜负彩";
            Lotteries[2] = "四场进球彩";
            Lotteries[15] = "六场半全场";
            Lotteries[0x3d] = "江西时时彩";
            Lotteries[0x3e] = "十一运夺金";
            Lotteries[0x41] = "31选7";
            Lotteries[0x29] = "浙江体彩6+1";
            Lotteries[70] = "11选5";
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary[0x12d] = "单式";
            dictionary[0x12e] = "复式";
            PlayTypes[3] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x1f5] = "单式";
            dictionary[0x1f6] = "复式";
            dictionary[0x1f7] = "胆拖";
            PlayTypes[5] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x259] = "直选单式";
            dictionary[0x25a] = "直选复式";
            dictionary[0x25b] = "组选单式";
            dictionary[0x25c] = "组6复式";
            dictionary[0x25d] = "组3复式";
            dictionary[0x25e] = "直选包点";
            dictionary[0x25f] = "复选包点";
            PlayTypes[6] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0xaf1] = "单式";
            dictionary[0xaf2] = "复式";
            dictionary[0xaf3] = "组选";
            dictionary[0xaf4] = "猜大小";
            dictionary[0xaf5] = "五星通选单式";
            dictionary[0xaf6] = "五星通选复式";
            dictionary[0xaf7] = "二星组选单式";
            dictionary[0xaf8] = "二星组选复式";
            dictionary[0xaf9] = "二星组选分位";
            dictionary[0xafa] = "二星组选包点";
            dictionary[0xafb] = "二星组选包胆";
            dictionary[0xafc] = "三星包点";
            dictionary[0xafd] = "三星组3单式";
            dictionary[0xafe] = "三星组3复式";
            dictionary[0xaff] = "三星组6单式";
            dictionary[0xb00] = "三星组6复式";
            dictionary[0xb01] = "三星直选组合复式";
            dictionary[0xb02] = "三星组选包胆";
            dictionary[0xb03] = "三星组选包点";
            PlayTypes[0x3d] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0xb55] = "直选单式";
            dictionary[0xb56] = "直选复式";
            dictionary[0xb57] = "组选单式";
            dictionary[0xb58] = "组选6";
            dictionary[0xb59] = "组选3";
            dictionary[0xb5a] = "直选";
            dictionary[0xb5b] = "组选";
            dictionary[0xb5c] = "前二单式";
            dictionary[0xb5d] = "前二复式";
            dictionary[0xb5e] = "后二单式";
            dictionary[0xb5f] = "后二复式";
            dictionary[0xb60] = "前一单式";
            dictionary[0xb61] = "前一复式";
            dictionary[0xb62] = "后一单式";
            dictionary[0xb63] = "后一复式";
            PlayTypes[0x1d] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0xf3d] = "单式";
            dictionary[0xf3e] = "复式";
            dictionary[0xf3f] = "追加单式";
            dictionary[0xf40] = "追加复式";
            dictionary[0xf41] = "12选2单式";
            dictionary[0xf42] = "12选2复式";
            PlayTypes[0x27] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x16a9] = "单式";
            dictionary[0x16aa] = "复式";
            PlayTypes[0x3a] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x515] = "单式";
            dictionary[0x516] = "复式";
            PlayTypes[13] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x170d] = "单式";
            dictionary[0x170e] = "复式";
            PlayTypes[0x3b] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x385] = "单式";
            dictionary[0x386] = "复式";
            PlayTypes[9] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x579] = "单式";
            dictionary[0x57a] = "复式";
            PlayTypes[14] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x189d] = "排列3直选单式";
            dictionary[0x189e] = "排列3直选复式";
            dictionary[0x189f] = "排列3组选单式";
            dictionary[0x18a0] = "排列3组选6复式";
            dictionary[0x18a1] = "排列3组选3复式";
            dictionary[0x18a2] = "排列3直选和值";
            dictionary[0x18a3] = "排列3组选和值";
            PlayTypes[0x3f] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x1901] = "排列5单式";
            dictionary[0x1902] = "排列5复式";
            PlayTypes[0x40] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x76d] = "单式";
            dictionary[0x76e] = "复式";
            PlayTypes[0x13] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x65] = "单式";
            dictionary[0x66] = "复式";
            dictionary[0x67] = "任九场单式";
            dictionary[0x68] = "任九场复式";
            PlayTypes[1] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0xc9] = "单式";
            dictionary[0xca] = "复式";
            PlayTypes[2] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x5dd] = "单式";
            dictionary[0x5de] = "复式";
            PlayTypes[15] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x1839] = "任选一";
            dictionary[0x183a] = "任选二";
            dictionary[0x183b] = "任选三";
            dictionary[0x183c] = "任选四";
            dictionary[0x183d] = "任选五";
            dictionary[0x183e] = "任选六";
            dictionary[0x183f] = "任选七";
            dictionary[0x1840] = "任选八";
            dictionary[0x1841] = "前二直选";
            dictionary[0x1842] = "前三直选";
            dictionary[0x1843] = "前二组选";
            dictionary[0x1844] = "前三组选";
            PlayTypes[0x3e] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x1965] = "单式";
            dictionary[0xdae] = "复式";
            PlayTypes[0x41] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x1965] = "单式";
            dictionary[0xdae] = "复式";
            PlayTypes[0x41] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x17d5] = "单式";
            dictionary[0x17d6] = "复式";
            dictionary[0x17d7] = "组选";
            dictionary[0x17d8] = "猜大小";
            dictionary[0x17d9] = "五星通选单式";
            dictionary[0x17da] = "五星通选复式";
            dictionary[0x17db] = "二星组选单式";
            dictionary[0x17dc] = "二星组选复式";
            dictionary[0x17dd] = "二星组选分位";
            dictionary[0x17de] = "二星组选包点";
            dictionary[0x17df] = "二星组选包胆";
            dictionary[0x17e0] = "二星直选包点";
            PlayTypes[0x3d] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x1b59] = "任选一";
            dictionary[0x1b5a] = "任选二";
            dictionary[0x1b5b] = "任选三";
            dictionary[0x1b5c] = "任选四";
            dictionary[0x1b5d] = "任选五";
            dictionary[0x1b5e] = "任选六";
            dictionary[0x1b5f] = "任选七";
            dictionary[0x1b60] = "任选八";
            dictionary[0x1b61] = "前二直选";
            dictionary[0x1b62] = "前三直选";
            dictionary[0x1b63] = "前二组选";
            dictionary[0x1b64] = "前三组选";
            PlayTypes[70] = dictionary;
            dictionary = new Dictionary<int, string>();
            dictionary[0x1005] = "单式";
            dictionary[0x1006] = "复式";
            PlayTypes[0x29] = dictionary;
            string str = "";
            foreach (KeyValuePair<int, string> pair in Lotteries)
            {
                str = str + pair.Key + ",";
            }
            str = str.Remove(str.Length - 1, 1);
            foreach (DataRow row3 in new Tables.T_PlayTypes().Open("LotteryID,SystemEndAheadMinute", "LotteryID in (" + str + ")", "").Rows)
            {
                LotteryEndAheadMinute[int.Parse(row3["LotteryID"].ToString())] = int.Parse(row3["SystemEndAheadMinute"].ToString());
            }
        }

        public static void ClearCache(string CaheKey)
        {
            Cache.ClearCache(CaheKey);
        }

        private static string FormatWinNumber(string WinNumber, int LotteryID)
        {
            string str = "";
            if (((LotteryID == 6) || (LotteryID == 0x3f)) || (((LotteryID == 0x40) || (LotteryID == 3)) || (LotteryID == 0x1d)))
            {
                for (int i = 0; i < WinNumber.Length; i++)
                {
                    str = str + "<span style='padding-left:5px'>" + WinNumber.Substring(i, 1) + "</span>";
                }
                return str;
            }
            if ((LotteryID == 5) || (LotteryID == 13))
            {
                string[] strArray = WinNumber.Replace(" + ", " ").Split(new char[] { ' ' });
                str = "";
                for (int j = 0; j < strArray.Length; j++)
                {
                    if (j < (strArray.Length - 1))
                    {
                        str = str + strArray[j] + " ";
                    }
                    else
                    {
                        str = str + "<span class=\"blue12\">" + strArray[j] + "</span>";
                    }
                }
                return str;
            }
            if (LotteryID == 0x3a)
            {
                string str3 = WinNumber.Replace("+", " ");
                for (int k = 0; k < (str3.Length - 1); k++)
                {
                    str = str + "<span style='padding-left:5px'>" + str3.Substring(k, 1) + "</span>";
                }
                return (str + "<span class=\"blue12\">" + str3.Substring(str3.Length - 1, 1) + "</span>");
            }
            if (LotteryID == 0x27)
            {
                string[] strArray2 = WinNumber.Replace("+", "").Split(new char[] { ' ' });
                str = "";
                for (int m = 0; m < strArray2.Length; m++)
                {
                    if (m < (strArray2.Length - 2))
                    {
                        str = str + strArray2[m] + " ";
                    }
                    else
                    {
                        str = str + "<span style='padding-left:5px' class=\"blue12\">" + strArray2[m] + "</span>";
                    }
                }
                return str;
            }
            if (LotteryID == 0x41)
            {
                str = WinNumber.Replace("+", "");
                return (str.Substring(0, str.Length - 2) + "<span class=\"blue12\">" + str.Substring(str.Length - 2, 2) + "</span>");
            }
            return WinNumber;
        }

        public static DataTable GetIsusesInfo(int LotteryID)
        {
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(IsusesInfo + LotteryID.ToString());
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("SELECT * FROM (SELECT TOP 1 ID,Name,WinLotteryNumber,StartTime,EndTime,IsOpened FROM dbo.T_Isuses WHERE LotteryID=" + LotteryID + " AND   ISNULL(WinLotteryNumber, '')<>'' ORDER BY EndTime DESC)a").Append(" UNION ").Append("SELECT * FROM (SELECT TOP 1 ID,Name,WinLotteryNumber,StartTime,EndTime,IsOpened FROM dbo.T_Isuses WHERE LotteryID=" + LotteryID + " AND GETDATE()>EndTime  ORDER BY EndTime DESC)a").Append(" UNION ").Append("SELECT TOP 1 ID,Name,WinLotteryNumber,StartTime,EndTime,IsOpened FROM dbo.T_Isuses WHERE LotteryID=" + LotteryID + " and IsOpened = 0 AND GETDATE() BETWEEN StartTime AND EndTime").Append(" UNION ").Append("SELECT * FROM (SELECT TOP 49 ID,Name,WinLotteryNumber,StartTime,EndTime,IsOpened FROM dbo.T_Isuses WHERE LotteryID=" + LotteryID + " AND getdate()<StartTime ORDER BY StartTime)a");
                cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[0]);
                if (cacheAsDataTable != null)
                {
                    Cache.SetCache(IsusesInfo + LotteryID.ToString(), cacheAsDataTable, (((LotteryID == 0x3e) || (LotteryID == 0x1d)) || (LotteryID == 70)) ? 60 : 600);
                }
            }
            return cacheAsDataTable;
        }

        public static string GetLotteryNews(int LotteryID)
        {
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(LotteryNews + LotteryID.ToString());
            StringBuilder builder = new StringBuilder();
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                string str = "";
                if (LotteryID == 0x1c)
                {
                    str = "重庆时时彩资讯";
                }
                if (LotteryID == 0x1d)
                {
                    str = "时时乐资讯";
                }
                if (LotteryID == 0x3e)
                {
                    str = "十一运夺金资讯";
                }
                if (LotteryID == 5)
                {
                    str = "双色球资讯";
                }
                if (LotteryID == 6)
                {
                    str = "3D资讯";
                }
                if (LotteryID == 0x27)
                {
                    str = "超级大乐透资讯";
                }
                if (LotteryID == 0x3d)
                {
                    str = "时时彩咨询";
                }
                if ((LotteryID == 0x3f) || (LotteryID == 0x40))
                {
                    str = "排列3/5资讯";
                }
                if (((LotteryID == 1) || (LotteryID == 15)) || (LotteryID == 2))
                {
                    str = "足彩资讯";
                }
                if (LotteryID == 70)
                {
                    str = "11选5资讯";
                }
                if (LotteryID == 0x29)
                {
                    str = "浙江体彩6+1资讯";
                }
                cacheAsDataTable = new Views.V_News().Open("top 8 Title,Content", "isShow = 1  and [TypeName] = '" + str + "'", "isCommend,DateTime desc");
                if ((cacheAsDataTable != null) && (cacheAsDataTable.Rows.Count > 0))
                {
                    Cache.SetCache(LotteryNews + LotteryID.ToString(), cacheAsDataTable, 0xe10);
                }
            }
            string input = "";
            foreach (DataRow row in cacheAsDataTable.Rows)
            {
                if ((row["Title"].ToString().IndexOf("</font>") > -1) && (row["Title"].ToString().IndexOf("</font>") > -1))
                {
                    input = row["Title"].ToString();
                    if (input.IndexOf("class=red12") > 0)
                    {
                        input = input.Substring(input.IndexOf(">") + 1, (input.IndexOf("</font>") - input.IndexOf(">")) - 1);
                        builder.Append("<tr>").Append("<td width=\"5%\" height=\"24\" align=\"center\" class=\"hui14\">").Append("&#9642;&nbsp;").Append("</td>").Append("<td width=\"95%\" height=\"22\" class=\"blue12\">").Append("<a href='").Append(row["Content"].ToString()).Append("' target='_blank'>").Append("<font class = 'red12'>").Append(_String.Cut(input, 15)).Append("</font>").Append("</a>").Append("</td>").Append("</tr>");
                    }
                    else
                    {
                        input = input.Substring(input.IndexOf(">") + 1, (input.IndexOf("</font>") - input.IndexOf(">")) - 1);
                        builder.Append("<tr>").Append("<td width=\"5%\" height=\"24\" align=\"center\" class=\"hui14\">").Append("&#9642;&nbsp;").Append("</td>").Append("<td width=\"95%\" height=\"22\" class=\"blue12\">").Append("<a href='").Append(row["Content"].ToString()).Append("' target='_blank'>").Append("<font class = 'black12'>").Append(_String.Cut(input, 0x11)).Append("</font>").Append("</a>").Append("</td>").Append("</tr>");
                    }
                    continue;
                }
                builder.Append("<tr>").Append("<td width=\"5%\" height=\"24\" align=\"center\" class=\"hui14\">").Append("&#9642;&nbsp;").Append("</td>").Append("<td width=\"95%\" height=\"22\" class=\"blue12\">").Append("<a href='").Append(row["Content"].ToString()).Append("' target='_blank'>").Append(_String.Cut(row["Title"].ToString(), 15)).Append("</a>").Append("</td>").Append("</tr>");
            }
            return builder.ToString();
        }

        public static DataTable GetWinInfo(int LotteryID)
        {
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(WinInfo + LotteryID.ToString());
            StringBuilder builder = new StringBuilder();
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                builder.Append("select b.InitiateUserID, c.Name as InitiateName, Win,LotteryID,NickName from ").Append("( select top 9  InitiateUserID, SUM(WinMoney) as Win,LotteryID from  ").Append("( select InitiateUserID, WinMoney,LotteryID from T_Schemes a WITH (nolock)  ");
                builder.Append("inner join T_PlayTypes b WITH (nolock) on a.PlayTypeID = b.ID ").Append("where WinMoney > 0 and LotteryID = @LotteryID)d group by InitiateUserID,LotteryID order by Win desc )as b  ").Append("inner join T_Users c WITH (nolock) on b.InitiateUserID = c.ID order by Win desc");
                cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, LotteryID) });
                if ((cacheAsDataTable != null) && (cacheAsDataTable.Rows.Count > 0))
                {
                    Cache.SetCache(WinInfo + LotteryID.ToString(), cacheAsDataTable, (((LotteryID == 0x3e) || (LotteryID == 0x1d)) || (LotteryID == 0x3d)) ? 300 : 0xe10);
                }
            }
            return cacheAsDataTable;
        }

        public static DataTable GetWinNews()
        {
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(WinNews);
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = new Views.V_Schemes().Open("top 9 ID,InitiateName,NickName,WinMoney,WinDescription,LotteryName,PlayTypeName,IsuseName", "Buyed=1 and QuashStatus=0 and WinMoney>0 and LotteryID in(5,6,29,39)", "ID desc");
                if ((cacheAsDataTable != null) && (cacheAsDataTable.Rows.Count > 0))
                {
                    Cache.SetCache(WinNews, cacheAsDataTable, 600);
                }
            }
            return cacheAsDataTable;
        }

        public static DataTable GetWinNumber(int LotteryID)
        {
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(WinNumber + LotteryID.ToString());
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                cacheAsDataTable = new Tables.T_Isuses().Open("top 100 Name, WinLotteryNumber, EndTime", "LotteryID=" + LotteryID + " and IsOpened = 1 and IsNull(WinLotteryNumber,'')<>''", "EndTime Desc");
                if (cacheAsDataTable == null)
                {
                    return cacheAsDataTable;
                }
                cacheAsDataTable.Columns.Add("ID", typeof(int));
                int num = 1;
                foreach (DataRow row in cacheAsDataTable.Rows)
                {
                    row["ID"] = num;
                    num++;
                    row["WinLotteryNumber"] = FormatWinNumber(row["WinLotteryNumber"].ToString(), LotteryID);
                }
                Cache.SetCache(WinNumber + LotteryID.ToString(), cacheAsDataTable, ((LotteryID == 0x3e) || (LotteryID == 0x1d)) ? 120 : 0xe10);
            }
            return cacheAsDataTable;
        }

        public static DataTable GetZCExpertList(int LotteryID)
        {
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(ZCExpert + LotteryID.ToString());
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                cacheAsDataTable = new Views.V_Experts().Open("UserName,UserID,LotteryName", "[ON]=1 and [isCommend]=1 and LotteryID=" + LotteryID, "");
                if (cacheAsDataTable == null)
                {
                    return cacheAsDataTable;
                }
                cacheAsDataTable.Columns.Add("ID", typeof(int));
                int num = 1;
                foreach (DataRow row in cacheAsDataTable.Rows)
                {
                    row["ID"] = num;
                    num++;
                }
                Cache.SetCache(ZCExpert + LotteryID.ToString(), cacheAsDataTable, 180);
            }
            return cacheAsDataTable;
        }
    }
}
