using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

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
    }
}
