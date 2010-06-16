using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Database.DBAccess;

namespace J.SLS.Domain
{
    public class BonusManager
    {
        private readonly ObjectPersistence persistence = null;
        public BonusManager(IDBAccess dbAccess)
        {
            persistence = new ObjectPersistence(dbAccess);
        }

        public void AddBonus(BonusEntity entity)
        {
            entity.BonusTime = DateTime.Now;
            persistence.Add(entity);
        }

        public void ModifyBonusDistrbite(BonusEntity entity)
        {
            entity.DistributeTime = DateTime.Now;
            persistence.Modify(entity);
        }

        public void AddBonusDetail(BonusDetailEntity entity)
        {
            persistence.Add(entity);
        }

        public BonusEntity GetBonus(string gameName, string issueNumber)
        {
            BonusEntity bonus = new BonusEntity();
            bonus.GameName = gameName;
            bonus.IssuseNumber = issueNumber;
            return persistence.GetByKeys<BonusEntity>(bonus);
        }

        public IList<BonusDetailEntity> GetBonusDetailList(string gameName, string issueNumber)
        {
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("GameName", gameName));
            cri.Add(Expression.Equal("IssueNumber", issueNumber));
            return persistence.GetList<BonusDetailEntity>(cri, new SortInfo("TicketId"), new SortInfo("BonusLevel"));
        }

        public void AddBonusDistribute(BonusDistributeEntity entity)
        {
            entity.DistributeTime = DateTime.Now;
            persistence.Add(entity);
        }
    }
}
