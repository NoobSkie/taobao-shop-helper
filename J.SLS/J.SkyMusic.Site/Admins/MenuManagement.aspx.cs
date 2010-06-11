using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;

public partial class Admins_MenuManagement : BaseAdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageFacade facade = PageHelper.GetPageFacade(this.Page);
            IList<MenuItemInfo> topMenus = facade.GetTopMenuList();
            rptMenu1.DataSource = topMenus;
            rptMenu1.DataBind();
        }
    }

    protected void rptMenu1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            MenuItemInfo menu = e.Item.DataItem as MenuItemInfo;
            PageFacade facade = PageHelper.GetPageFacade(this.Page);
            IList<MenuItemInfo> subMenus = facade.GetChildrenMenuList(menu.Id);
            Repeater rptMenu2 = e.Item.FindControl("rptMenu2") as Repeater;
            rptMenu2.DataSource = subMenus;
            rptMenu2.DataBind();
        }
    }
}
