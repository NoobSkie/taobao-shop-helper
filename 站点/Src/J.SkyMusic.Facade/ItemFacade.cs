﻿using System;
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
    public abstract class ItemBaseFacade<T> : BaseFacade
        where T : ItemBase, new()
    {
        public T GetItemById(Guid id)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            return persistence.GetByKey<T>(id);
        }
    }

    public class ItemCollectionFacade : ItemBaseFacade<ItemCollectionInfo>
    {
        public void AddItem(ItemBase item)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            persistence.Add(item);
        }

        public void UpdateItem(ItemBase item)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            persistence.Modify(item);
        }

        public IList<ItemDetailInfo> GetChildrenItemList(Guid collectionId, int pageIndex, int pageSize, out int totalCount, string orderBy, SortDirection direction)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("ItsCollectionId", collectionId));
            return persistence.GetList<ItemDetailInfo>(cri, pageIndex, pageSize, out totalCount, new SortInfo(orderBy, direction));
        }
    }

    public class ItemDetailFacade : ItemBaseFacade<ItemDetailInfo>
    {
        public void AddItem(ItemDetailInfo item)
        {
            item.PublishDate = DateTime.Now;
            item.LastUpdateDate = DateTime.Now;

            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            persistence.Add(item);
        }

        public void UpdateItem(ItemDetailInfo item)
        {
            item.LastUpdateDate = DateTime.Now;

            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            persistence.Modify(item);
        }
    }

    public class ItemHtmlFacade : ItemBaseFacade<ItemHtmlInfo>
    {
        public void AddItem(ItemBase item)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            persistence.Add(item);
        }

        public void UpdateItem(ItemBase item)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            persistence.Modify(item);
        }
    }
}
