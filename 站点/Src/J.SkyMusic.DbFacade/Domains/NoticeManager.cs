using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.DBAccess;
using J.SLS.Database.ORM;

namespace J.SkyMusic.DbFacade.Domains
{
    public class NoticeManager
    {
        private readonly ObjectPersistence persistence = null;
        public NoticeManager(IDBAccess dbAccess)
        {
            persistence = new ObjectPersistence(dbAccess);
        }

        public void AddNotice(NoticeEntity entity)
        {
            entity.CreateTime = DateTime.Now;
            entity.UpdateTime = DateTime.Now;
            persistence.Add(entity);
        }

        public void ModifyNotice(NoticeEntity entity)
        {
            entity.UpdateTime = DateTime.Now;
            persistence.Modify(entity);
        }

        public void DeleteNotice(long id)
        {
            persistence.Delete(new NoticeEntity { Id = id });
        }
    }
}
