using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Common;
using J.SLS.Common.Exceptions;
using J.SLS.Common.Logs;
using J.SLS.Database.DBAccess;
using J.SkyMusic.Domain;

namespace J.SkyMusic.Facade
{
    public abstract class ItemBaseFacade : BaseFacade
    {
        public abstract ItemBase GetItemById(Guid id);
    }

    public class ItemCollectionFacade : ItemBaseFacade
    {
        public override ItemBase GetItemById(Guid id)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            return persistence.GetByKey<ItemCollectionInfo>(id);
        }

        public IList<ItemDetailInfo> GetChildrenItemList(Guid collectionId, int pageIndex, int pageSize, out int totalCount, string orderBy, SortDirection direction)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("ItsCollectionId", collectionId));
            return persistence.GetList<ItemDetailInfo>(cri, pageIndex, pageSize, out totalCount, new SortInfo(orderBy, direction));
        }
    }

    public class ItemDetailFacade : ItemBaseFacade
    {
        public override ItemBase GetItemById(Guid id)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            return persistence.GetByKey<ItemDetailInfo>(id);
        }
    }

    public class ItemHtmlFacade : ItemBaseFacade
    {
        public override ItemBase GetItemById(Guid id)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            return persistence.GetByKey<ItemHtmlInfo>(id);
        }
    }
}
