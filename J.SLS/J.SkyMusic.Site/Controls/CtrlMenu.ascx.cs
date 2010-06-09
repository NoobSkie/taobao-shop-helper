using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;

public partial class Controls_CtrlMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (MenuList != null)
            {
                rptMenuList.DataSource = MenuList;
                rptMenuList.DataBind();
            }
        }
    }

    public string ParentId { get; set; }

    public string SelectedMenuId { get; set; }

    public IList<MenuItemInfo> MenuList { get; set; }

    protected void rptMenuList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            MenuItemInfo item = e.Item.DataItem as MenuItemInfo;
            HyperLink hlnkUrl = e.Item.FindControl("hlnkUrl") as HyperLink;
            hlnkUrl.Text = item.Name;
            if (!string.IsNullOrEmpty(SelectedMenuId) && item.Id.Equals(SelectedMenuId, StringComparison.OrdinalIgnoreCase))
            {
                hlnkUrl.CssClass += " Selected";
            }
            else
            {
                if (item.Level == 1)
                {
                    hlnkUrl.NavigateUrl = string.Format("~/ShowMenu.aspx?m1={0}", item.Id);
                }
                else
                {
                    if (item.IsOpenNewWindow)
                    {
                        hlnkUrl.Target = "_blank";
                    }
                    //switch (item.Type)
                    //{
                    //    case MenuType.OutUrl:
                    //        hlnkUrl.NavigateUrl = item.OutUrl;
                    //        break;
                    //    case MenuType.ListPage:
                    //        hlnkUrl.NavigateUrl = string.Format("~/ShowList.aspx?id={0}&m1={1}&m2={2}", item.InnerId, ParentId ?? "", item.Id);
                    //        break;
                    //    case MenuType.HtmlPage:
                    //        hlnkUrl.NavigateUrl = string.Format("~/ShowContent.aspx?id={0}&m1={1}&m2={2}", item.InnerId, ParentId ?? "", item.Id);
                    //        break;
                    //}
                }
            }
        }
    }
}
