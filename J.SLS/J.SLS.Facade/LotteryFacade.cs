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

        public IList<IsuseInfo> GetChaseIsuseList(int lotteryId, int chaseMinute)
        {
            string sql = "SELECT * FROM [T_Lottery_Isuses] WHERE [LotteryId] = {0} AND ([StartTime] > GETDATE() OR ([StartTime] < GETDATE() AND [EndTime] > DATEADD(MINUTE, {1}, GETDATE()))) ORDER BY [EndTime]";
            DataTable table = DbAccess.GetDataTableBySQL(sql, lotteryId, chaseMinute);
            return ORMHelper.DataTableToList<IsuseInfo>(table);
        }

        public IList<EndAheadMinuteInfo> GetEndAheadMinuteList()
        {
            string sql = "SELECT DISTINCT [LotteryID],[SystemEndAheadMinute] FROM [T_Lottery_PlayTypes]";
            DataTable table = DbAccess.GetDataTableBySQL(sql);
            return ORMHelper.DataTableToList<EndAheadMinuteInfo>(table);
        }
    }
}
