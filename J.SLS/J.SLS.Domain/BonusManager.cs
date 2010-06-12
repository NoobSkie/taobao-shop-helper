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
            BonusEntity tmp = persistence.GetByKeys<BonusEntity>(entity);
            if (tmp == null)
            {
                persistence.Add(entity);
            }
        }

        public void AddBonusDetail(BonusDetailEntity entity)
        {
            BonusDetailEntity tmp = persistence.GetByKeys<BonusDetailEntity>(entity);
            if (tmp == null)
            {
                persistence.Add(entity);
            }
        }
    }
}
