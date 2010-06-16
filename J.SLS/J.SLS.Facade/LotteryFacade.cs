using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using System.Data;
using J.SLS.Common;

namespace J.SLS.Facade
{
    public class LotteryFacade : BaseFacade
    {
        public T GetLotteryInfoById<T>(int lotteryId)
            where T : LotteryInfoBase, new()
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            return persistence.GetByKey<T>(lotteryId);
        }

        public T GetLotteryInfoByCode<T>(string code)
            where T : LotteryInfoBase, new()
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("Code", code));
            IList<T> list = persistence.GetList<T>(cri);
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        public IList<IssuseInfo> GetCommonIsuseList(int lotteryId)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.AppendLine("SELECT * FROM (");
            sqlBuilder.AppendLine("SELECT * FROM (");
            sqlBuilder.AppendLine("	SELECT TOP 1 ID,Name,WinLotteryNumber,StartTime,EndTime,IsOpened ");
            sqlBuilder.AppendLine("	FROM T_Lottery_Isuses ");
            sqlBuilder.AppendLine("	WHERE LotteryID={0} AND   ISNULL(WinLotteryNumber, '')<>'' ");
            sqlBuilder.AppendLine("	ORDER BY EndTime DESC");
            sqlBuilder.AppendLine(")a UNION ");
            sqlBuilder.AppendLine("SELECT * FROM (");
            sqlBuilder.AppendLine("	SELECT TOP 1 ID,Name,WinLotteryNumber,StartTime,EndTime,IsOpened ");
            sqlBuilder.AppendLine("	FROM T_Lottery_Isuses ");
            sqlBuilder.AppendLine("	WHERE LotteryID={0} AND GETDATE()>EndTime  ");
            sqlBuilder.AppendLine("	ORDER BY EndTime DESC");
            sqlBuilder.AppendLine(")a UNION ");
            sqlBuilder.AppendLine("SELECT TOP 1 ID,Name,WinLotteryNumber,StartTime,EndTime,IsOpened ");
            sqlBuilder.AppendLine("FROM T_Lottery_Isuses ");
            sqlBuilder.AppendLine("WHERE LotteryID={0} and IsOpened = 0 AND GETDATE() BETWEEN StartTime AND EndTime ");
            sqlBuilder.AppendLine("UNION SELECT * FROM (	");
            sqlBuilder.AppendLine("	SELECT TOP 49 ID,Name,WinLotteryNumber,StartTime,EndTime,IsOpened ");
            sqlBuilder.AppendLine("	FROM T_Lottery_Isuses ");
            sqlBuilder.AppendLine("	WHERE LotteryID={0} AND GETDATE()<StartTime ");
            sqlBuilder.AppendLine("	ORDER BY StartTime");
            sqlBuilder.AppendLine(")a)b ORDER BY EndTime");
            DataTable table = DbAccess.GetDataTableBySQL(sqlBuilder.ToString(), lotteryId);
            return ORMHelper.DataTableToList<IssuseInfo>(table);
        }

        public IssuseInfo GetCurrentIsuse(string gameName)
        {
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("GameName", gameName));
            cri.Add(Expression.Equal("Status", IssueStatus.Started));
            cri.Add(Expression.GreaterThan("StopTime", DateTime.Now));

            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            IList<IssuseInfo> list = persistence.GetList<IssuseInfo>(cri, new SortInfo("StopTime", SortDirection.Desc));
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        public IssuseInfo GetPrevIsuse(string gameName)
        {
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("GameName", gameName));
            cri.Add(Expression.GreaterThanEqual("Status", IssueStatus.Finished));

            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            int totalCount;
            IList<IssuseInfo> list = persistence.GetList<IssuseInfo>(cri, 0, 1, out totalCount, new SortInfo("StopTime", SortDirection.Desc));
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        public IList<EndAheadMinuteInfo> GetEndAheadMinuteList()
        {
            string sql = "SELECT DISTINCT [GameName],[SystemEndAheadMinute] FROM [T_Lottery_PlayTypes]";
            DataTable table = DbAccess.GetDataTableBySQL(sql);
            return ORMHelper.DataTableToList<EndAheadMinuteInfo>(table);
        }

        public DateTime GetIsuseSystemEndTime(long isuseID, int playTypeID)
        {
            string sql = "SELECT [dbo].[F_GetIsuseSystemEndTime]({0}, {1})";
            object obj = DbAccess.GetRC1BySQL(sql, isuseID, playTypeID);
            return (DateTime)obj;
        }
    }
}
