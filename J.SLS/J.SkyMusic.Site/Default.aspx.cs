﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;

public partial class _Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IList<MenuItemInfo> menu1List = DataCache.GetTopMenuList(this.Page);
            ctrlSubMenu4.TopMenuList = menu1List;
        }
    }
}
