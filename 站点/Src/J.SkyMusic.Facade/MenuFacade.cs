using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SkyMusic.Domain;

namespace J.SkyMusic.Facade
{
    public class MenuFacade : BaseFacade
    {
        public void AddMenu(MenuInfo menu)
        {
            MenuEntity entity = new MenuEntity();
            entity.Id = Guid.NewGuid();
            entity.Index = menu.Index;
            entity.IsNewWindow = menu.IsNewWindow;
            entity.Name = menu.Name;
            entity.ParentId = menu.ParentId;
            MenuManager manager = new MenuManager(DbAccess);
            manager.AddMenu(entity);
        }

        public MenuInfo GetMenuById(Guid id)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            return persistence.GetByKey<MenuInfo>(id);
        }

        public IList<MenuInfo> GetRootMenuList()
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            Criteria cri = new Criteria();
            cri.Add(Expression.IsNull("ParentId"));
            return persistence.GetList<MenuInfo>(cri, new SortInfo("Index"));
        }

        public void LoadParentMenu(MenuInfo menu)
        {
            LoadParentMenu(menu, false);
        }

        public void LoadParentMenu(MenuInfo menu, bool isEnforce)
        {
            if (menu.Parent == null || isEnforce)
            {
                if (menu.ParentId != null)
                {
                    ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                    menu.Parent = persistence.GetByKey<MenuInfo>(menu.ParentId);
                }
            }
        }

        public void LoadChildrenMenuList(MenuInfo menu)
        {
            LoadChildrenMenuList(menu, false);
        }

        public void LoadChildrenMenuList(MenuInfo menu, bool isEnforce)
        {
            if (menu.Children == null || isEnforce)
            {
                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                Criteria cri = new Criteria();
                cri.Add(Expression.Equal("ParentId", menu.Id));
                menu.Children = persistence.GetList<MenuInfo>(cri, new SortInfo("Index"));
            }
        }
    }
}
