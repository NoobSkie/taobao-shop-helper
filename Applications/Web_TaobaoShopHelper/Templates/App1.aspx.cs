using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Applications.TaobaoShopHelper.WebControls.Common;
using Taobao.Top.Api;
using Taobao.Top.Api.Request;
using Taobao.Top.Api.Domain;
using Taobao.Top.Api.Parser;
using TOP.Common.CompressionTool;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TOP.Applications.TaobaoShopHelper.Templates
{
    public partial class App1 : BasePage, IMenuPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<InformationObject> infoList = new List<InformationObject>();
            if (CurrentUser == null)
            {
                infoList.Add(GetUnLoginInformation());
            }
            if (string.IsNullOrEmpty(CurrentSessionKey) || string.IsNullOrEmpty(CurrentSellerNick))
            {
                infoList.Add(GetUnAuthorizeInformation());
            }
            else if (!IsPostBack)
            {
                BindCategories();
                BindCurrentSource();
                InitTreeLink();
            }
            if (infoList.Count > 0)
            {
                DisplayInformations(infoList);
            }
        }

        private void InitTreeLink()
        {
            Dictionary<string, string> parameters = GetParameterListByQuery();
            TreeNode onsaleNode = tvCategory.FindNode("onsale");
            if (onsaleNode != null)
            {
                if (parameters.ContainsKey("type"))
                {
                    parameters["type"] = "onsale";
                }
                else
                {
                    parameters.Add("type", "onsale");
                }
                foreach (TreeNode child in onsaleNode.ChildNodes)
                {
                    if (parameters.ContainsKey("filter"))
                    {
                        parameters["filter"] = child.Value;
                    }
                    else
                    {
                        parameters.Add("filter", child.Value);
                    }
                    child.NavigateUrl = Request.Url.AbsolutePath + "?" + GetQueryByParameterList(parameters);
                }
            }
            TreeNode node = tvCategory.FindNode("inventory");
            if (node != null)
            {
                if (parameters.ContainsKey("type"))
                {
                    parameters["type"] = "inventory";
                }
                else
                {
                    parameters.Add("type", "inventory");
                }
                foreach (TreeNode child in node.ChildNodes)
                {
                    if (parameters.ContainsKey("filter"))
                    {
                        parameters["filter"] = child.Value;
                    }
                    else
                    {
                        parameters.Add("filter", child.Value);
                    }
                    child.NavigateUrl = Request.Url.AbsolutePath + "?" + GetQueryByParameterList(parameters);
                }
            }
        }

        private void BindCategories()
        {
            ITopClient client = GetProductTopClient();
            SellerCatsGetRequest req = new SellerCatsGetRequest();
            req.Nick = CurrentSellerNick;
            ResponseList<SellerCat> rsp = client.Execute(req, new SellerCatListJsonParser());
            if (rsp.Content != null)
            {
                TreeNode node = tvCategory.FindNode("onsale");
                List<SellerCat> currentList = GetCatListByParent(rsp.Content, "0");
                foreach (SellerCat children in currentList)
                {
                    AddCategory(rsp.Content, children, node);
                }
            }
        }

        private void AddCategory(List<SellerCat> categoryList, SellerCat category, TreeNode parentNode)
        {
            TreeNode node = GetNodeByCategory(category);
            parentNode.ChildNodes.Add(node);
            List<SellerCat> currentList = GetCatListByParent(categoryList, category == null ? "0" : category.Cid);
            foreach (SellerCat children in currentList)
            {
                AddCategory(categoryList, children, node);
            }
        }

        private List<SellerCat> GetCatListByParent(List<SellerCat> categoryList, string parentId)
        {
            List<SellerCat> rtn = new List<SellerCat>();
            foreach (SellerCat cat in categoryList)
            {
                if (cat.ParentCid == parentId)
                {
                    rtn.Add(cat);
                }
            }
            return rtn;
        }

        private TreeNode GetNodeByCategory(SellerCat category)
        {
            TreeNode node = new TreeNode();
            node.Text = category.Name;
            node.Value = category.Cid;
            return node;
        }

        private void BindCurrentSource()
        {
            #region 关键字
            string query = Request["query"];
            txtQuery.Text = query;
            #endregion

            #region 参与打折
            bool? discount = null;
            if (!string.IsNullOrEmpty(Request["discount"]))
            {
                discount = bool.Parse(Request["discount"]);
            }
            cbDiscount.Checked = discount.HasValue && discount.Value;
            #endregion

            #region 橱窗推荐
            bool? showCase = null;
            if (!string.IsNullOrEmpty(Request["showCase"]))
            {
                showCase = bool.Parse(Request["showCase"]);
            }
            cbShowCase.Checked = showCase.HasValue && showCase.Value;
            #endregion

            #region 类型
            string type = "onsale";
            if (!string.IsNullOrEmpty(Request["type"]))
            {
                type = Request["type"];
            }
            if (type.Equals("onsale", StringComparison.OrdinalIgnoreCase))
            {
                cbDiscount.Enabled = true;
                cbShowCase.Enabled = true;
            }
            else
            {
                cbDiscount.Enabled = false;
                cbShowCase.Enabled = false;
            }
            #endregion

            #region 过滤子类
            string filter = "all";
            if (!string.IsNullOrEmpty(Request["filter"]))
            {
                filter = Request["filter"];
            }
            TreeNode node = tvCategory.FindNode(type + "/" + filter);
            if (node != null)
            {
                node.Selected = true;
            }
            #endregion

            #region 分页
            int pageIndex = ucCtrlPager.PageIndex + 1;
            int pageSize = ucCtrlPager.PageSize;
            #endregion

            ITopClient client = GetProductTopClient();
            ITopRequest req = GetTopRequest(query, discount, showCase, type, filter, pageIndex, pageSize);
            if (req != null)
            {
                ResponseList<Item> rsp = client.Execute(req, new ItemListJsonParser(), CurrentSessionKey);

                ucCtrlPager.TotalCount = (int)rsp.TotalResults;
                rptItemList.DataSource = rsp.Content;
                rptItemList.DataBind();
            }
        }

        private ITopRequest GetTopRequest(string query, bool? discount, bool? showCase, string type, string filter, int pageIndex, int pageSize)
        {
            if (type.Equals("onsale", StringComparison.OrdinalIgnoreCase))
            {
                ItemsOnsaleGetRequest req = new ItemsOnsaleGetRequest();
                req.Fields = TopFieldsHelper.GetItemFields_InList();// "iid,title,nick,type,cid,num,props,price";
                req.Query = query;
                req.HasDiscount = discount;
                req.HasShowcase = showCase;
                req.PageNo = pageIndex;
                req.PageSize = pageSize;
                if (!string.IsNullOrEmpty(filter) && !filter.Trim().Equals("all", StringComparison.OrdinalIgnoreCase))
                {
                    req.SellerCids = filter;
                }
                return req;
            }
            else if (type.Equals("inventory", StringComparison.OrdinalIgnoreCase))
            {
                ItemsInventoryGetRequest req = new ItemsInventoryGetRequest();
                req.Fields = TopFieldsHelper.GetItemFields_InList();// "iid,title,nick,type,cid,num,props,price";
                req.Query = query;
                if (!string.IsNullOrEmpty(filter) && !filter.Trim().Equals("all", StringComparison.OrdinalIgnoreCase))
                {
                    req.Banner = filter;
                }
                req.PageNo = pageIndex;
                req.PageSize = pageSize;
                return req;
            }
            else
            {
                return null;
            }
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = GetParameterListByQuery();
            string query = txtQuery.Text.Trim();
            if (!string.IsNullOrEmpty(query))
            {
                if (parameters.ContainsKey("query"))
                {
                    parameters["query"] = query;
                }
                else
                {
                    parameters.Add("query", query);
                }
            }
            else
            {
                if (parameters.ContainsKey("query"))
                {
                    parameters.Remove("query");
                }
            }
            if (cbDiscount.Checked)
            {
                string discount = cbDiscount.Checked.ToString().ToLower();
                if (parameters.ContainsKey("discount"))
                {
                    parameters["discount"] = discount;
                }
                else
                {
                    parameters.Add("discount", discount);
                }
            }
            else
            {
                if (parameters.ContainsKey("discount"))
                {
                    parameters.Remove("discount");
                }
            }
            if (cbShowCase.Checked)
            {
                string showCase = cbShowCase.Checked.ToString().ToLower();
                if (parameters.ContainsKey("showCase"))
                {
                    parameters["showCase"] = showCase;
                }
                else
                {
                    parameters.Add("showCase", showCase);
                }
            }
            else
            {
                if (parameters.ContainsKey("showCase"))
                {
                    parameters.Remove("showCase");
                }
            }
            string url = Request.Url.AbsolutePath + "?" + GetQueryByParameterList(parameters);
            Response.Redirect(url, true);
        }

        protected void lblNext_Click(object sender, EventArgs e)
        {
            string iid = string.Empty;
            int count = 0;
            foreach (RepeaterItem row in rptItemList.Items)
            {
                CheckBox cbCheck = row.FindControl("cbCheck") as CheckBox;
                if (cbCheck != null && cbCheck.Checked)
                {
                    HiddenField hiddIid = row.FindControl("hiddIid") as HiddenField;
                    Label lblTitle = row.FindControl("lblTitle") as Label;
                    if (hiddIid != null && lblTitle != null)
                    {
                        if (count > 0)
                        {
                            iid += "_-p-_";
                        }
                        iid += hiddIid.Value + "_-c-_" + lblTitle.Text;
                        count++;
                    }
                }
            }
            string arg = CompressionHelper.Compress(iid);
            string url = "App2.aspx?Count=" + count.ToString() + "&List=" + Server.UrlEncode(arg);
            Response.Redirect(url, true);
        }

        #region IMenuPage Members

        public string GetTopMenuId()
        {
            return "Template";
        }

        public string GetSecondMenuId()
        {
            return "App";
        }

        #endregion
    }
}
