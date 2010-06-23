using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;

public partial class Controls_CtrlSubMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (TopMenuList != null)
            {
                rptTopMenu.DataSource = TopMenuList;
                rptTopMenu.DataBind();
            }
        }
    }

    public IList<MenuItemInfo> TopMenuList { get; set; }

    protected void rptTopMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            MenuItemInfo menuItem = e.Item.DataItem as MenuItemInfo;
            Repeater rptSub = e.Item.FindControl("rptMenuList") as Repeater;
            IList<MenuItemInfo> menu2List = DataCache.GetSecondMenuList(this.Page, menuItem.Id);
            rptSub.DataSource = menu2List;
            rptSub.DataBind();
        }
    }

    protected void rptMenuList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            MenuItemInfo item = e.Item.DataItem as MenuItemInfo;
            HyperLink hlnkUrl = e.Item.FindControl("hlnkUrl") as HyperLink;
            hlnkUrl.Text = item.Name;
            if (item.IsOpenNewWindow)
            {
                hlnkUrl.Target = "_blank";
            }
            else
            {
                hlnkUrl.Attributes["onclick"] = "SelectMenu('" + hlnkUrl.ClientID + "');";
            }
            if (item.IsInner)
            {
                hlnkUrl.NavigateUrl = string.Format("~/{0}.aspx?id={1}", item.IsListType ? "ShowList" : "ShowContent", item.InnerId);
            }
            else
            {
                hlnkUrl.NavigateUrl = item.OuterUrl;
            }
        }
    }
}
