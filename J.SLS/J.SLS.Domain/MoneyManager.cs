using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using J.SLS.Common;
using J.SLS.Database.ORM;
using J.SLS.Database.DBAccess;

namespace J.SLS.Domain
{
    public class MoneyManager
    {
        private readonly ObjectPersistence persistence = null;
        public MoneyManager(IDBAccess dbAccess)
        {
            persistence = new ObjectPersistence(dbAccess);
        }

        public void AddMoneyGetRequest(MoneyGetDetailEntity entity)
        {
            entity.RequestTime = DateTime.Now;
            persistence.Add(entity);
        }

        public MoneyGetDetailEntity GetMoneyGetDetailEntity(long id)
        {
            return persistence.GetByKey<MoneyGetDetailEntity>(id);
        }

        public void ModifyMoneyGetResponseStatus(MoneyGetDetailEntity entity)
        {
            entity.ResponseTime = DateTime.Now;
            persistence.Modify(entity);
        }
    }
}
