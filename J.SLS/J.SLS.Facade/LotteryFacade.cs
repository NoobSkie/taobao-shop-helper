using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using System.Data;

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

        public IList<IsuseInfo> GetCommonIsuseList(int lotteryId)
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
            return ORMHelper.DataTableToList<IsuseInfo>(table);
        }

        public IsuseInfo GetCurrentIsuse(int lotteryId)
        {
            string sql = "SELECT * FROM [T_Lottery_Isuses] WHERE [LotteryId] = {0} AND [StartTime] < GETDATE() AND [EndTime] > GETDATE() ORDER BY [EndTime] DESC";
            DataTable table = DbAccess.GetDataTableBySQL(sql, lotteryId);
            if (table.Rows.Count == 0)
            {
                return null;
            }
            return ORMHelper.ConvertDataRowToEntity<IsuseInfo>(table.Rows[0]);
        }

        public IList<EndAheadMinuteInfo> GetEndAheadMinuteList()
        {
            string sql = "SELECT DISTINCT [LotteryID],[SystemEndAheadMinute] FROM [T_Lottery_PlayTypes]";
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
