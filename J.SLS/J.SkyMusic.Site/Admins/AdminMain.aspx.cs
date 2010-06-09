using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;

public partial class Admins_AdminMain : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageFacade facade = PageHelper.GetPageFacade(this.Page);
            IList<MenuItemInfo> topMenus = facade.GetTopMenuList();
            rptMenus.DataSource = topMenus;
            rptMenus.DataBind();
        }
    }

    protected void rptMenus_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
        }
    }
}
