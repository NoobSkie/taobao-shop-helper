﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using J.SkyMusic.Facade;
using System.Web.UI;

public static class PageHelper
{
    public static PageFacade GetPageFacade(Page _page)
    {
        string dbUrl = "~/App_Data";
        string dirPath = _page.Server.MapPath(dbUrl);
        return new PageFacade(dirPath);
    }
}