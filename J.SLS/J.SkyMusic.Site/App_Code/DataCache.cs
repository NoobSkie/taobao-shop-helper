using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using J.SkyMusic.DbFacade.Services;

public static class DataCache
{
    public static IList<MenuItemInfo> GetTopMenuList(Page _page)
    {
        PageFacade facade = PageHelper.GetPageFacade(_page);
        IList<MenuItemInfo> list = facade.GetTopMenuList();
        return list;
        //object cache = _page.Cache.Get("TopMenuList");
        //if (cache == null)
        //{
        //    PageFacade facade = PageHelper.GetPageFacade(_page);
        //    IList<MenuItem> list = facade.GetTopMenuList();
        //    _page.Cache.Add("TopMenuList", list, new CacheDependency(""), DateTime.Now, new TimeSpan(), CacheItemPriority.High, null);
        //    return list;
        //}
        //else
        //{
        //    return cache as IList<MenuItem>;
        //}
    }

    public static IList<MenuItemInfo> GetSecondMenuList(Page _page, string parentId)
    {
        PageFacade facade = PageHelper.GetPageFacade(_page);
        IList<MenuItemInfo> list = facade.GetChildrenMenuList(parentId);
        return list;
    }

    public static ParamInfo GetParam(Page _page, string key)
    {
        ParamFacade facade = PageHelper.GetParamFacade(_page);
        return facade.GetParam(key);
    }
}
