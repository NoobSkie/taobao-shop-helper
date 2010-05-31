using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Database.DBAccess;

namespace J.SkyMusic.Domain
{
    public class PageBlockManager
    {
        private readonly ObjectPersistence persistence = null;
        public PageBlockManager(IDBAccess dbAccess)
        {
            persistence = new ObjectPersistence(dbAccess);
        }

        public IList<PageBlockEntity> GetAllBlockList()
        {
            return persistence.GetAll<PageBlockEntity>(new SortInfo("XIndex"), new SortInfo("YIndex"));
        }

        public void AddPageBlock(PageBlockEntity entity)
        {
            persistence.Add(entity);
        }

        public void DeletePageBlock(PageBlockEntity entity)
        {
            persistence.Delete(entity);
        }
    }
}
