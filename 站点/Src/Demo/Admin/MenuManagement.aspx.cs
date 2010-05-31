using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;

public partial class Admin_MenuManagement : BaseAdminPage
{
    private MenuFacade facade = new MenuFacade();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (!IsPostBack)
        {
            InitMenuTree();
        }
    }

    private void InitMenuTree()
    {
        tvMenus.Nodes.Clear();
        ddlParentList.Items.Clear();
        ddlParentList.Items.Add(new ListItem("<无>", ""));

        IList<MenuInfo> roots = facade.GetRootMenuList();
        foreach (MenuInfo menu in roots)
        {
            TreeNode node = new TreeNode();
            node.Value = menu.Id.ToString();
            node.Text = menu.Name;
            ddlParentList.Items.Add(new ListItem(menu.Name, menu.Id.ToString()));
            LoadChildrenMenu(node, menu, "    ");
            tvMenus.Nodes.Add(node);
        }
    }

    private void LoadChildrenMenu(TreeNode parentNode, MenuInfo parentMenu, string space)
    {
        facade.LoadChildrenMenuList(parentMenu);
        foreach (MenuInfo menu in parentMenu.Children)
        {
            TreeNode node = new TreeNode();
            node.Value = menu.Id.ToString();
            node.Text = menu.Name;
            ddlParentList.Items.Add(new ListItem(space + menu.Name, menu.Id.ToString()));
            LoadChildrenMenu(node, menu, space + "    ");
            parentNode.ChildNodes.Add(node);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        MenuInfo menu = new MenuInfo();
        menu.Name = txtName.Text;
        if (string.IsNullOrEmpty(ddlParentList.SelectedValue))
        {
            menu.ParentId = null;
        }
        else
        {
            menu.ParentId = new Guid(ddlParentList.SelectedValue);
        }
        menu.Index = int.Parse(txtIndex.Text);
        menu.IsNewWindow = ckbIsOpenNewWindow.Checked;
        facade.AddMenu(menu);

        InitMenuTree();
    }

    protected void tvMenus_SelectedNodeChanged(object sender, EventArgs e)
    {
        string id = tvMenus.SelectedValue;
        MenuInfo menu = facade.GetMenuById(new Guid(id));
        if (menu != null)
        {
            txtName.Text = menu.Name;
            txtIndex.Text = menu.Index.ToString();
            ckbIsOpenNewWindow.Checked = menu.IsNewWindow;
            if (menu.ParentId != null)
            {
                ddlParentList.SelectedValue = menu.ParentId.ToString();
            }
            else
            {
                ddlParentList.SelectedValue = "";
            }
        }
        else
        {
            lblMessage.Text = "错误 - 没找到对应栏目数据，可能已被删除，请刷新列表重试！";
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtIndex.Text = "0";
        ckbIsOpenNewWindow.Checked = false;
        if (tvMenus.SelectedNode != null)
        {
            ddlParentList.SelectedValue = tvMenus.SelectedValue;
        }
        else
        {
            ddlParentList.SelectedValue = "";
        }
    }

    protected void btnView_Click(object sender, EventArgs e)
    {

    }
}
