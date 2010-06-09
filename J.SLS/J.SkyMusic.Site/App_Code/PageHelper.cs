using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using J.SkyMusic.DbFacade.Services;

public static class PageHelper
{
    public static PageFacade GetPageFacade(Page _page)
    {
        return new PageFacade();
    }

    public static ParamFacade GetParamFacade(Page _page)
    {
        return new ParamFacade();
    }

    //public static ResFileFacade GetResFileFacade(Page _page)
    //{
    //    string dbUrl = "~/UploadFiles/Inner";
    //    string dirPath = _page.Server.MapPath(dbUrl);
    //    return new ResFileFacade(dirPath);
    //}
}
