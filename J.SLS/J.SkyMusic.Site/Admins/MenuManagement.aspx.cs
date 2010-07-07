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
    protected void rptMenu1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            string menuId = e.CommandArgument.ToString();
            PageFacade facade = PageHelper.GetPageFacade(this.Page);
            IList<MenuItemInfo> subList = facade.GetChildrenMenuList(menuId);
            string url = string.Format("MenuManagement.aspx");
            if (subList.Count > 0)
            {
                JavascriptAlertAndRedirect("请先删除此菜单下的所有子菜单，再删除此菜单！", url);
            }
            else
            {
                facade.DeleteMenu(menuId);
                JavascriptAlertAndRedirect("删除菜单成功", url);
            }
        }
    }
    protected void rptMenu1_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptMenu2 = e.Item.FindControl("rptMenu2") as Repeater;
            rptMenu2.ItemCommand += rptMenu1_ItemCommand;
        }
    }
}
