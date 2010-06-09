using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Database.DBAccess;

namespace J.SkyMusic.DbFacade.Domains
{
    public class PageManager
    {
        private readonly ObjectPersistence persistence = null;
        public PageManager(IDBAccess dbAccess)
        {
            persistence = new ObjectPersistence(dbAccess);
        }

        public void AddEntity<T>(T entity)
            where T : PageEntityBase
        {
            entity.Id = Guid.NewGuid().ToString("N");
            entity.CreateTime = DateTime.Now;
            entity.LastUpdateTime = DateTime.Now;
            persistence.Add(entity);
        }

        public void ModifyEntity<T>(T entity)
            where T : PageEntityBase
        {
            entity.LastUpdateTime = DateTime.Now;
            persistence.Modify(entity);
        }

        public void DeleteEntity<T>(T entity)
        {
            persistence.Delete(entity);
        }
    }
}
