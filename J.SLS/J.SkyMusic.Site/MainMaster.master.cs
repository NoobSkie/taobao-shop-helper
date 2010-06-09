using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;

public partial class MainMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string selectedMenu1 = Request["m1"];
            IList<MenuItemInfo> menu1List = DataCache.GetTopMenuList(this.Page);
            if (string.IsNullOrEmpty(selectedMenu1) && menu1List.Count > 0)
            {
                selectedMenu1 = menu1List[0].Id;
            }
            ctrlMenu1.SelectedMenuId = selectedMenu1;
            ctrlMenu1.MenuList = menu1List;

            string selectedMenu2 = Request["m2"];
            IList<MenuItemInfo> menu2List = DataCache.GetSecondMenuList(this.Page, selectedMenu1);
            if (string.IsNullOrEmpty(selectedMenu2) && menu2List.Count > 0)
            {
                selectedMenu2 = menu2List[0].Id;
            }
            ctrlMenu2.ParentId = selectedMenu1;
            ctrlMenu2.SelectedMenuId = selectedMenu2;
            ctrlMenu2.MenuList = menu2List;
        }
    }
}
