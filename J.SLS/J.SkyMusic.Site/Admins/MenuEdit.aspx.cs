using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;

public partial class Admins_MenuEdit : BaseAdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindParentMenuList();
            BindInnerLinkList();
        }
    }

    protected void lbtnSave_Click(object sender, EventArgs e)
    {

    }

    private void BindParentMenuList()
    {
        PageFacade facade = PageHelper.GetPageFacade(this.Page);
        IList<J.SkyMusic.Facade.MenuItem> menuList = facade.GetTopMenuList();
        ddlTopMenu.DataSource = menuList;
        ddlTopMenu.DataBind();

        ddlTopMenu.Items.Insert(0, new System.Web.UI.WebControls.ListItem("< 无 >", ""));
    }

    private void BindInnerLinkList()
    {
        PageFacade facade = PageHelper.GetPageFacade(this.Page);
        IList<J.SkyMusic.Facade.ListItem> lists = facade.GetListItems();
        foreach (J.SkyMusic.Facade.ListItem list in lists)
        {
            System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem();
            item.Text = list.Name;
            item.Value = "0#" + list.Id;
            facade.GetHtmlItemsByParent(list.SubDbFileName, 0, 10);
        }
    }
}
