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

                string selectedId = "";
                if (!string.IsNullOrEmpty(Request.QueryString["m"]))
                {
                    selectedId = Request.QueryString["m"];
                }
                else if (MenuList.Count > 0)
                {
                    selectedId = MenuList[0].Id;
                }
                if (selectedId != "" && !IsLinkToDefault)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowFirstTopMenuJs", "ShowSubMenu('" + selectedId + "');", true);
                }
            }
        }
    }

    public IList<MenuItemInfo> MenuList { get; set; }
    public bool IsLinkToDefault { get; set; }
    protected void rptMenuList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            MenuItemInfo menuInfo = e.Item.DataItem as MenuItemInfo;
            HyperLink hlnkMenu = e.Item.FindControl("hlnkMenu") as HyperLink;
            hlnkMenu.Text = menuInfo.Name;
            if (IsLinkToDefault)
            {
                hlnkMenu.NavigateUrl = string.Format("~/Default.aspx?m={0}", menuInfo.Id);
            }
            else
            {
                hlnkMenu.NavigateUrl = "javascript:void(0);";
                hlnkMenu.Attributes["onclick"] = string.Format("ShowSubMenu('{0}');", menuInfo.Id);
            }
        }
    }
}
