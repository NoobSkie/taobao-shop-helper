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
            try
            {
                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                return persistence.GetAll<ListItemInfo>(new SortInfo("CreateTime", SortDirection.Desc));
            }
            catch (Exception ex)
            {
                throw HandleException("Page", "GetListItems", ex);
            }
        }

        public IList<HtmlItemInfo> GetHtmlItemsByParent(string listId)
        {
            try
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
            catch (Exception ex)
            {
                throw HandleException("Page", "GetHtmlItemsByParent - " + listId, ex);
            }
        }

        public HtmlItemFullInfo GetHtmlItemById(string htmlId)
        {
            try
            {
                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                return persistence.GetByKey<HtmlItemFullInfo>(htmlId);
            }
            catch (Exception ex)
            {
                throw HandleException("Page", "GetHtmlItemById - " + htmlId, ex);
            }
        }

        public MenuItemInfo GetMenuById(string menuId)
        {
            try
            {
                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                return persistence.GetByKey<MenuItemInfo>(menuId);
            }
            catch (Exception ex)
            {
                throw HandleException("Page", "GetMenuById - " + menuId, ex);
            }
        }

        public IList<MenuItemInfo> GetTopMenuList()
        {
            try
            {
                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                Criteria cri = new Criteria();
                cri.Add(Expression.Or(
                    Expression.IsNull("ParentId"),
                    Expression.Equal("ParentId", "")));
                return persistence.GetList<MenuItemInfo>(cri, new SortInfo("Index"));
            }
            catch (Exception ex)
            {
                throw HandleException("Page", "GetTopMenuList", ex);
            }
        }

        public IList<MenuItemInfo> GetChildrenMenuList(string parentId)
        {
            try
            {
                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                Criteria cri = new Criteria();
                cri.Add(Expression.Equal("ParentId", parentId));
                return persistence.GetList<MenuItemInfo>(cri, new SortInfo("Index"));
            }
            catch (Exception ex)
            {
                throw HandleException("Page", "GetChildrenMenuList - " + parentId, ex);
            }
        }

        public void AddList(ListItemInfo list)
        {
            try
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
            catch (Exception ex)
            {
                throw HandleException("Page", "AddList - " + list.Name, ex);
            }
        }

        public void ModifyListName(string listId, string newName)
        {
            try
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
            catch (Exception ex)
            {
                throw HandleException("Page", "ModifyListName - " + listId + " : " + newName, ex);
            }
        }

        public void AddHtml(HtmlItemFullInfo item)
        {
            try
            {
                HtmlItemEntity entity = new HtmlItemEntity();
                entity.Content = item.Content;
                entity.ItsListId = item.ItsListId;
                entity.Name = item.Name;
                entity.Title = item.Title;

                PageManager manager = new PageManager(DbAccess);
                manager.AddEntity<HtmlItemEntity>(entity);
                item.Id = entity.Id;
            }
            catch (Exception ex)
            {
                throw HandleException("Page", "AddHtml - " + item.Name, ex);
            }
        }

        public void ModifyHtml(HtmlItemFullInfo item)
        {
            try
            {
                HtmlItemEntity entity = new HtmlItemEntity();
                entity.Id = item.Id;
                entity.Content = item.Content;
                entity.Name = item.Name;
                entity.Title = item.Title;

                PageManager manager = new PageManager(DbAccess);
                manager.ModifyEntity<HtmlItemEntity>(entity);
            }
            catch (Exception ex)
            {
                throw HandleException("Page", "ModifyHtml - " + item.Name, ex);
            }
        }

        public void AddMenu(MenuItemInfo menu)
        {
            try
            {
                MenuItemEntity entity = new MenuItemEntity();
                entity.Index = menu.Index;
                entity.InnerId = menu.InnerId;
                entity.IsInner = menu.IsInner;
                entity.IsListType = menu.IsListType;
                entity.IsOpenNewWindow = menu.IsOpenNewWindow;
                entity.Level = menu.Level;
                entity.Name = menu.Name;
                entity.OuterUrl = menu.OuterUrl;
                entity.ParentId = menu.ParentId;

                PageManager manager = new PageManager(DbAccess);
                manager.AddEntity<MenuItemEntity>(entity);
                menu.Id = entity.Id;
            }
            catch (Exception ex)
            {
                throw HandleException("Page", "AddMenu - " + menu.Name, ex);
            }
        }

        public void DeleteHtml(string htmlId)
        {
            try
            {
                HtmlItemEntity entity = new HtmlItemEntity();
                entity.Id = htmlId;
                PageManager manager = new PageManager(DbAccess);
                manager.DeleteEntity<HtmlItemEntity>(entity);
            }
            catch (Exception ex)
            {
                throw HandleException("Page", "DeleteHtml - " + htmlId, ex);
            }
        }

        public void DeleteList(string listId)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("ItsListId", listId));
            IList<HtmlItemInfo> list = persistence.GetList<HtmlItemInfo>(cri);
            if (list.Count > 0)
            {
                throw new FacadeException("此列表包含有子页面，请先删除列表下的全部子页面。");
            }
            try
            {
                ListItemEntity entity = new ListItemEntity();
                entity.Id = listId;
                PageManager manager = new PageManager(DbAccess);
                manager.DeleteEntity<ListItemEntity>(entity);
            }
            catch (Exception ex)
            {
                throw HandleException("Page", "DeleteList - " + listId, ex);
            }
        }

        public ListItemInfo GetListItemById(string id)
        {
            try
            {
                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                return persistence.GetByKey<ListItemInfo>(id);
            }
            catch (Exception ex)
            {
                throw HandleException("Page", "GetListItemById - " + id, ex);
            }
        }

        public ListItemInfo GetListItemByMenu(string menuId)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw HandleException("Page", "GetListItemByMenu - " + menuId, ex);
            }
        }

        public HtmlItemInfo GetHtmlItemByMenu(string menuId)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw HandleException("Page", "GetHtmlItemByMenu - " + menuId, ex);
            }
        }
    }
}
