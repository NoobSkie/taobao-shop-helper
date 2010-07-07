using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using System.Text;
using J.SkyMusic.DbFacade.Services;

public partial class Admins_MenuEdit : BaseAdminPage
{
    protected string SplitChar0 = ((char)23).ToString();
    protected string SplitChar1 = ((char)24).ToString();
    protected string SplitChar2 = ((char)25).ToString();
    protected string SplitChar3 = ((char)26).ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Admins_MenuEdit));
        if (!IsPostBack)
        {
            BindParentMenuList();
            BindInnerLinkList();
            if (!IsAdd)
            {
                hiddCurrentId.Value = Request["id"];
                // BindMenuInfo(Request["id"]);
            }
        }
    }

    public string CurrentId
    {
        get
        {
            return Request["id"];
        }
    }

    public bool IsAdd
    {
        get
        {
            return string.IsNullOrEmpty(Request["id"]);
        }
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string SaveMenu(string id, string name, string index, string topMenuId, bool isInner, string innerId, bool isNewWindow, string outerUrl)
    {
        PageFacade facade = PageHelper.GetPageFacade(this.Page);
        MenuItemInfo menu = new MenuItemInfo();
        if (!string.IsNullOrEmpty(id))
        {
            menu = facade.GetMenuById(id);
        }
        menu.Index = int.Parse(index);
        menu.InnerId = innerId;
        menu.IsInner = isInner;
        menu.IsOpenNewWindow = isNewWindow;
        menu.IsListType = string.IsNullOrEmpty(innerId);
        menu.Level = string.IsNullOrEmpty(topMenuId) ? 0 : 1;
        menu.Name = name;
        menu.OuterUrl = outerUrl;
        menu.ParentId = topMenuId;
        string msg;
        if (string.IsNullOrEmpty(id))
        {
            facade.AddMenu(menu);
            msg = "新增菜单成功";
        }
        else
        {
            facade.ModifyMenu(menu);
            msg = "修改菜单成功";
        }
        return msg;
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetMenuInfo(string menuId)
    {
        PageFacade facade = PageHelper.GetPageFacade(this.Page);
        MenuItemInfo menuItem = facade.GetMenuById(menuId);
        if (menuItem == null)
        {
            return "";
        }
        string[] menuInfos = new string[9];
        menuInfos[0] = menuItem.Name;
        menuInfos[1] = menuItem.Index.ToString();
        menuInfos[2] = menuItem.ParentId;
        menuInfos[3] = menuItem.IsInner ? "1" : "0";
        menuInfos[4] = menuItem.IsListType ? "1" : "0";
        menuInfos[5] = menuItem.InnerId;
        menuInfos[6] = "";  // parent list id
        menuInfos[7] = menuItem.OuterUrl;
        menuInfos[8] = menuItem.IsOpenNewWindow ? "1" : "0";
        if (!string.IsNullOrEmpty(menuItem.ParentId))
        {
            if (menuItem.IsInner)
            {
                if (!menuItem.IsListType && !string.IsNullOrEmpty(menuItem.InnerId))
                {
                    HtmlItemInfo htmlItem = facade.GetHtmlItemById(menuItem.InnerId);
                    if (!string.IsNullOrEmpty(htmlItem.ItsListId))
                    {
                        menuInfos[6] = htmlItem.ItsListId;
                    }
                }
            }
        }
        return string.Join(SplitChar3, menuInfos);
        //txtName.Text = menuItem.Name;
        //txtIndex.Text = menuItem.Index.ToString();
        //if (string.IsNullOrEmpty(menuItem.ParentId))
        //{
        //    ddlTopMenu.SelectedValue = "";
        //}
        //else
        //{
        //    ddlTopMenu.SelectedValue = menuItem.ParentId;
        //    if (menuItem.IsInner)
        //    {
        //        rbtnInner.Checked = true;
        //        if (menuItem.IsListType)
        //        {
        //            if (!string.IsNullOrEmpty(menuItem.InnerId))
        //            {
        //                ddlLinkList.SelectedValue = menuItem.InnerId;
        //            }
        //        }
        //        else
        //        {
        //            if (!string.IsNullOrEmpty(menuItem.InnerId))
        //            {
        //                HtmlItemInfo htmlItem = facade.GetHtmlItemById(menuItem.InnerId);
        //                if (!string.IsNullOrEmpty(htmlItem.ItsListId))
        //                {
        //                    ddlLinkList.SelectedValue = htmlItem.ItsListId;
        //                    ddlLinkHtml.SelectedValue = htmlItem.Id;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        rbtnOuter.Checked = true;
        //        txtOuterUrl.Text = menuItem.OuterUrl;
        //    }
        //}
        //cbOpenNewWindow.Checked = menuItem.IsOpenNewWindow;
    }

    private void BindParentMenuList()
    {
        PageFacade facade = PageHelper.GetPageFacade(this.Page);
        IList<MenuItemInfo> menuList = facade.GetTopMenuList();
        ddlTopMenu.DataSource = menuList;
        ddlTopMenu.DataBind();

        ddlTopMenu.Items.Insert(0, new System.Web.UI.WebControls.ListItem("<无>", ""));
    }

    private void BindInnerLinkList()
    {
        PageFacade facade = PageHelper.GetPageFacade(this.Page);
        IList<ListItemInfo> lists = facade.GetListItems();
        ddlLinkList.DataSource = lists;
        ddlLinkList.DataBind();

        ddlLinkList.Items.Add(new System.Web.UI.WebControls.ListItem("<其他>", ""));
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetHtmlItemsById(string listId)
    {
        PageFacade facade = PageHelper.GetPageFacade(this.Page);
        IList<HtmlItemInfo> subList = facade.GetHtmlItemsByParent(listId);
        StringBuilder sb = new StringBuilder();
        foreach (HtmlItemInfo item in subList)
        {
            sb.Append((char)24 + item.Id + (char)25 + item.Name + (char)25 + item.LastUpdateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        return sb.ToString().TrimStart((char)24);
    }
}
