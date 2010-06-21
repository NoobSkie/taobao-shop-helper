using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;

public partial class ShowMenu : System.Web.UI.Page
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
            string selectedMenu2 = Request["m2"];
            IList<MenuItemInfo> menu2List = DataCache.GetSecondMenuList(this.Page, selectedMenu1);
            if (menu2List != null && menu2List.Count > 0)
            {
                MenuItemInfo item = menu2List[0];
                string url = "";
                if (item.IsInner)
                {
                    if (item.IsListType)
                    {
                        url = string.Format("~/ShowList.aspx?m1={0}&m2={1}&id={2}", selectedMenu1 ?? "", item.Id, item.InnerId);
                    }
                    else
                    {
                        url = string.Format("~/ShowContent.aspx?m1={0}&m2={1}&id={2}", selectedMenu1 ?? "", item.Id, item.InnerId);
                    }
                }
                else
                {
                    url = item.OuterUrl;
                }
                if (url != "")
                {
                    Response.Redirect(url);
                }
            }
        }
    }
}
