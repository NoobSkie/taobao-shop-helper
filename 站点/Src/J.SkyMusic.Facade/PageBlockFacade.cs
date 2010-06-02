using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Database.DBAccess;

namespace J.SkyMusic.Facade
{
    public class PageBlockFacade : BaseFacade
    {
        public IList<PageBlockInfo> GetColumnBlockList(int xIndex)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("XIndex", xIndex));
            return persistence.GetList<PageBlockInfo>(cri, new SortInfo("YIndex"));
        }

        public IList<PageBlockInfo> GetRowBlockList(int yIndex)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("YIndex", yIndex));
            return persistence.GetList<PageBlockInfo>(cri, new SortInfo("XIndex"));
        }

        public void GetBlockContent(PageBlockInfo blockInfo)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            ItemInfo item = persistence.GetByKey<ItemInfo>(blockInfo.ContentId);
            switch (item.TypeCode)
            {
                case 0:     // HTML页面
                    blockInfo.ContentItem = new ItemHtmlFacade().GetItemById(blockInfo.ContentId);
                    break;
                case 1:     // 列表
                    blockInfo.ContentItem = new ItemCollectionFacade().GetItemById(blockInfo.ContentId);
                    break;
                case 2:     // 子页面
                    blockInfo.ContentItem = new ItemDetailFacade().GetItemById(blockInfo.ContentId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("\"" + item.ItemName + "\"的类型不支持：" + item.TypeCode + "" + item.TypeName);
            }
        }
    }
}
