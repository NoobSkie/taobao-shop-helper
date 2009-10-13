using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taobao.Top.Api;
using TOP.Applications.TaobaoShopHelper._Common;
using Taobao.Top.Api.Request;
using Taobao.Top.Api.Domain;
using Taobao.Top.Api.Parser;
using ComponentArt.Web.UI;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Category
{
    public partial class CtrlShopCategoryTree : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string Nick
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    ITopClient client = GetProductTopClient();
                    SellerItemCatsGetRequest req = new SellerItemCatsGetRequest();
                    req.Nick = value;
                    ResponseList<SellerItemCat> rsp = client.Execute(req, new SellerItemCatListJsonParser());
                    if (rsp.Content != null)
                    {
                        BindTree(rsp.Content);
                    }
                }
            }
        }

        private void BindTree(List<SellerItemCat> catList)
        {
            List<SellerItemCat> roots = GetCatListByParent(catList, "0");
            foreach (SellerItemCat cat in roots)
            {
                TreeViewNode node = GetNodeByCat(cat);
                tvCategory.Nodes.Add(node);
                BindTree(catList, node);
            }
        }

        private void BindTree(List<SellerItemCat> catList, TreeViewNode parentNode)
        {
            List<SellerItemCat> chilren = GetCatListByParent(catList, parentNode.Value);
            foreach (SellerItemCat cat in chilren)
            {
                TreeViewNode node = GetNodeByCat(cat);
                parentNode.Nodes.Add(node);
                BindTree(catList, node);
            }
        }

        private List<SellerItemCat> GetCatListByParent(List<SellerItemCat> catList, string parentId)
        {
            List<SellerItemCat> rtn = new List<SellerItemCat>();
            foreach (SellerItemCat cat in catList)
            {
                if (cat.ParentCid == parentId)
                {
                    rtn.Add(cat);
                }
            }
            return rtn;
        }

        private TreeViewNode GetNodeByCat(SellerItemCat cat)
        {
            TreeViewNode node = new TreeViewNode();
            node.Value = cat.Cid;
            node.Text = cat.Name;
            return node;
        }
    }
}