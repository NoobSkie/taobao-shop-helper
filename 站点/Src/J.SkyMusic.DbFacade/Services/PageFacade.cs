using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;

namespace J.SkyMusic.DbFacade.Services
{
    public class PageFacade : BaseFacade
    {
        public IList<ListItemInfo> GetListItems()
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            return persistence.GetAll<ListItemInfo>(new SortInfo("CreateTime", SortDirection.Desc));
        }

        public IList<HtmlItemInfo> GetHtmlItemsByParent(string listId)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            Criteria cri = new Criteria();
            if (string.IsNullOrEmpty(listId))
            {
                cri.Add(Expression.Or(
                    Expression.IsNull("ItsListId"),
                    Expression.Equal("ItsListId", "")));
            }
            else
            {
                cri.Add(Expression.Equal("ItsListId", listId));
            }
            return persistence.GetList<HtmlItemInfo>(cri, new SortInfo("LastUpdateTime", SortDirection.Desc));
        }

        public HtmlItemFullInfo GetHtmlItemById(string htmlId)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            return persistence.GetByKey<HtmlItemFullInfo>(htmlId);
        }

        public IList<MenuItemInfo> GetTopMenuList()
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            Criteria cri = new Criteria();
            cri.Add(Expression.Or(
                Expression.IsNull("ParentId"),
                Expression.Equal("ParentId", "")));
            return persistence.GetList<MenuItemInfo>(cri, new SortInfo("Index"));
        }

        public IList<MenuItemInfo> GetChildrenMenuList(string parentId)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("ParentId", parentId));
            return persistence.GetList<MenuItemInfo>(cri, new SortInfo("Index"));
        }

        public void AddList(ListItemInfo list)
        {
        }

        public void ModifyListName(string listId, string newName)
        {
        }

        public void AddHtml(HtmlItemFullInfo item)
        {
        }

        public void AddMenu(MenuItemInfo menu)
        {
        }

        public ListItemInfo GetListItemById(string id)
        {
            return null;
        }

        public ListItemInfo GetListItemByMenu(string menuId)
        {
            return null;
        }

        public HtmlItemInfo GetHtmlItemByMenu(string menuId)
        {
            return null;
        }
    }
}
