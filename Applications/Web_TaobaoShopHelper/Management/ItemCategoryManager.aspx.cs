using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Management.Facade;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Core.Facade;
using TOP.Core.Domain;
using ComponentArt.Web.UI;

namespace TOP.Applications.TaobaoShopHelper.Management
{
    public partial class ItemCategoryManager : System.Web.UI.Page
    {
        private ConstVariables varHelper = new ConstVariables();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitTreeNode(nodeRoot);
            }
        }

        private TreeViewNode GetNodeByItemCategory(string name, string categoryId, bool isParent)
        {
            TreeViewNode node = new TreeViewNode();
            node.Text = name;
            node.Value = categoryId;
            if (isParent)
            {
                node.ImageUrl = "folder.gif";
                node.ExpandedImageUrl = "folder_open.gif";

                AddLoadingNode(node);
            }
            else
            {
                node.ImageUrl = "config.gif";
            }
            return node;
        }

        private TreeViewNode GetNodeByItemCategory(ItemCategoryInfo category)
        {
            return GetNodeByItemCategory(category.Name, category.CategoryId, category.IsParent);
        }

        private void AddLoadingNode(TreeViewNode node)
        {
            TreeViewNode empty = new TreeViewNode();
            empty.Text = "加载中...";
            empty.Value = "loading";
            empty.ImageUrl = "folder.gif";
            node.Nodes.Add(empty);

            node.AutoPostBackOnExpand = true;
        }

        private void AddNoneNode(TreeViewNode node)
        {
            TreeViewNode empty = new TreeViewNode();
            empty.Text = "更新中...";
            empty.Value = "none";
            empty.ImageUrl = "journal.gif";
            node.Nodes.Add(empty);

            node.AutoPostBackOnExpand = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string parentId = tvCategory.SelectedNode.Value;
            int count = UpdateSubItemCategories(parentId);
            InitTreeNode(tvCategory.SelectedNode);

            lblMessage.Text = string.Format("更新完成，{0}个类目。", count);
        }

        protected void tvCategory_NodeExpanded(object sender, TreeViewNodeEventArgs e)
        {
            if (e.Node != null && e.Node.Nodes.Count == 1)
            {
                if (e.Node.Nodes[0].Value == "loading")
                {
                    InitTreeNode(e.Node);
                }
                if (e.Node.Nodes[0].Value == "none")
                {
                    string parentId = e.Node.Value;
                    int count = UpdateSubItemCategories(parentId);
                    InitTreeNode(e.Node);

                    lblMessage.Text = string.Format("更新完成，{0}个类目。", count);
                }
                else
                {
                    lblMessage.Text = "";
                }
            }
        }

        private void InitTreeNode(TreeViewNode node)
        {
            ItemCategoryFacade localFacade = new ItemCategoryFacade();
            List<ItemCategoryInfo> list = localFacade.GetItemCategoryListByParent(node.Value);
            node.Nodes.Clear();
            foreach (ItemCategoryInfo item in list)
            {
                TreeViewNode sub = GetNodeByItemCategory(item);
                node.Nodes.Add(sub);
            }
            if (node.Nodes.Count == 0)
            {
                AddNoneNode(node);
            }
            else
            {
                node.AutoPostBackOnExpand = false;
            }
        }

        private int UpdateSubItemCategories(string parentId)
        {
            ItemCategoryFacade localFacade = new ItemCategoryFacade();
            localFacade.DeleteItemCategoryByParentId(parentId);

            CategoryFacade topFacade = new CategoryFacade(varHelper.TOP_AppKey, varHelper.TOP_AppSecret);
            TOPDataList<ItemCategory> list = topFacade.GetItemCategories(parentId, string.Empty);
            foreach (ItemCategory category in list)
            {
                if (!localFacade.IsItemCategoryExist(category.Id))
                {
                    localFacade.AddItemCategory(string.Empty, category.Id, category.ParentId, category.Name, category.IsParent, category.Status, category.SortOrder);
                }
            }
            return list.Count;
        }
    }
}
