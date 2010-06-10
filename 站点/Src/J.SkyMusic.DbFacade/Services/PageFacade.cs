using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Common.Exceptions;
using J.SkyMusic.DbFacade.Domains;

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
            list.Name = list.Name.Trim();

            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("Name", list.Name));
            if (!string.IsNullOrEmpty(list.Id))
            {
                cri.Add(Expression.NotEqual("Id", list.Id));
            }
            IList<ListItemInfo> tmpList = persistence.GetList<ListItemInfo>(cri);
            if (tmpList.Count > 0)
            {
                throw new FacadeException("列表名称已经存在，请重新输入！");
            }
            ListItemEntity entity = new ListItemEntity();
            entity.Name = list.Name;
            PageManager manager = new PageManager(DbAccess);
            manager.AddEntity<ListItemEntity>(entity);
            list.Id = entity.Id;
        }

        public void ModifyListName(string listId, string newName)
        {
            newName = newName.Trim();

            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("Name", newName));
            cri.Add(Expression.NotEqual("Id", listId));
            IList<ListItemInfo> tmpList = persistence.GetList<ListItemInfo>(cri);
            if (tmpList.Count > 0)
            {
                throw new FacadeException("列表名称已经存在，请重新输入！");
            }
            ListItemEntity entity = new ListItemEntity();
            entity.Id = listId;
            entity.Name = newName;
            PageManager manager = new PageManager(DbAccess);
            manager.ModifyEntity<ListItemEntity>(entity);
        }

        public void AddHtml(HtmlItemFullInfo item)
        {
        }

        public void AddMenu(MenuItemInfo menu)
        {
        }

        public ListItemInfo GetListItemById(string id)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            return persistence.GetByKey<ListItemInfo>(id);
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
