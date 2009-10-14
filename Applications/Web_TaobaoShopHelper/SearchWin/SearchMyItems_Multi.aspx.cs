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

namespace TOP.Applications.TaobaoShopHelper.SearchWin
{
    public partial class SearchMyItems_Multi : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(TOP_SessionKey))
            //{
            //    ucCtrlSessionGetter.Parameters.Add("ReturnUrl", Request.Url.AbsolutePath);
            //    ucCtrlSessionGetter.Visible = true;
            //    ucCtrlSearchItemsMulti.Visible = false;
            //    ucCtrlShopCategoryTree.Visible = false;

            //    hlnkOk.Enabled = false;
            //    hlnkCancel.Enabled = false;
            //}
            //else
            //{
            //    ucCtrlSessionGetter.Visible = false;
            //    ucCtrlSearchItemsMulti.Visible = true;
            //    ucCtrlShopCategoryTree.Visible = true;

            //    hlnkOk.Enabled = true;
            //    hlnkCancel.Enabled = true;

            //    ucCtrlShopCategoryTree.Nick = SellerNick;

            //    ITopClient client = GetProductTopClient();
            //    ItemsOnsaleGetRequest req = new ItemsOnsaleGetRequest();
            //    req.Fields = TopFieldsHelper.GetItemFields_InList();// "iid,title,nick,type,cid,num,props,price";
            //    req.PageNo = ucCtrlPager.PageIndex + 1;
            //    req.PageSize = ucCtrlPager.PageSize;
            //    ITopRequest proxy = new TopSessionRequestProxy(req, TOP_SessionKey);
            //    ResponseList<Item> rsp = client.Execute(proxy, new ItemListJsonParser());
            //    ucCtrlPager.TotalCount = (int)rsp.TotalResults;
            //    ucCtrlSearchItemsMulti.ItemSource = rsp.Content;
            //}
            ITopClient client = GetProductTopClient();
            ItemsGetRequest req = new ItemsGetRequest();
            req.Fields = TopFieldsHelper.GetItemFields_InList();// "iid,title,nick,type,cid,num,props,price";
            req.Nicks = "zhongjy001";
            req.PageNo = ucCtrlPager.PageIndex + 1;
            req.PageSize = ucCtrlPager.PageSize;
            ResponseList<Item> rsp = client.Execute(req, new ItemListJsonParser());
            ucCtrlPager.TotalCount = (int)rsp.TotalResults;
            ucCtrlSearchItemsMulti.ItemSource = rsp.Content;
        }
    }
}
