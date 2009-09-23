using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Management.Facade;
using ComponentArt.Web.UI;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Core.Facade;
using TOP.Core.Domain;

namespace TOP.Applications.TaobaoShopHelper.Management
{
    public partial class AreaManager : System.Web.UI.Page
    {
        private ConstVariables varHelper = new ConstVariables();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitRootArea();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int total, added, updated;
            UpdateAreas(out total, out added, out updated);
            lblMessage.Text = string.Format("更新完成，总共{0}个区域，新增{1}个区域，更新{2}个区域。", total, added, updated);
            InitRootArea();
        }

        protected void tvCategory_NodeExpanded(object sender, TreeViewNodeEventArgs e)
        {
            if (e.Node != null && e.Node.Nodes.Count == 1)
            {
                if (e.Node.Nodes[0].Value == "loading")
                {
                    InitTreeNode(e.Node);
                }
            }
        }

        private void UpdateAreas(out int total, out int added, out int updated)
        {
            added = 0;
            updated = 0;

            TOP.Management.Facade.AreaFacade areaFacade = new TOP.Management.Facade.AreaFacade();

            TOP.Core.Facade.AreaFacade topFacade = new TOP.Core.Facade.AreaFacade(varHelper.TOP_AppKey, varHelper.TOP_AppSecret);
            TOPDataList<Area> list = topFacade.GetAllAreas();
            total = list.Count;
            foreach (Area area in list)
            {
                if (areaFacade.IsAreaExist(area.AreaId))
                {
                    areaFacade.UpdateArea(area.AreaId, area.AreaType, area.AreaName, area.ParentId, area.Zip);
                    updated++;
                }
                else
                {
                    areaFacade.AddArea(string.Empty, area.AreaId, area.AreaType, area.AreaName, area.ParentId, area.Zip);
                    added++;
                }
            }
        }

        private void InitTreeNode(TreeViewNode node)
        {
            TOP.Management.Facade.AreaFacade areaFacade = new TOP.Management.Facade.AreaFacade();
            List<AreaInfo> list = areaFacade.GetAreaListByParentId(node.Value);
            node.Nodes.Clear();
            foreach (AreaInfo item in list)
            {
                TreeViewNode sub = GetNodeByArea(item);
                node.Nodes.Add(sub);
            }
            node.AutoPostBackOnExpand = false;
        }

        private TreeViewNode GetNodeByArea(string name, string areaId)
        {
            TreeViewNode node = new TreeViewNode();
            node.Text = name;
            node.Value = areaId;

            TOP.Management.Facade.AreaFacade areaFacade = new TOP.Management.Facade.AreaFacade();
            if (areaFacade.IsHasChildren(areaId))
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

        private TreeViewNode GetNodeByArea(AreaInfo area)
        {
            return GetNodeByArea(area.AreaName, area.AreaId);
        }

        private void InitRootArea()
        {
            TOP.Management.Facade.AreaFacade areaFacade = new TOP.Management.Facade.AreaFacade();
            List<AreaInfo> list = areaFacade.GetAllRootAreaList();
            foreach (AreaInfo area in list)
            {
                TreeViewNode node = GetNodeByArea(area);
                tvArea.Nodes.Add(node);
            }
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
    }
}
