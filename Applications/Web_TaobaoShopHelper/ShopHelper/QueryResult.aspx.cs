using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using Taobao.Top.Api;
using Taobao.Top.Api.Request;
using Taobao.Top.Api.Parser;
using Taobao.Top.Api.Domain;

namespace TOP.Applications.TaobaoShopHelper.ShopHelper
{
    public partial class QueryResult : BasePage
    { 
        public ResponseList<ItemSearch> DataSource_Item { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ITopClient client = GetProductTopClient();
            string key = Decode(Request["q"]);
            string type = Decode(Request["t"]);
            int? page_no = null;
            int? page_size = null;
            if (!string.IsNullOrEmpty(Request["page_no"]))
            {
                page_no = int.Parse(Request["page_no"]);
            }
            if (!string.IsNullOrEmpty(Request["page_size"]))
            {
                page_size = int.Parse(Request["page_size"]);
            }
            switch (type.ToLower())
            {
                case "item":
                    ItemsSearchRequest req = new ItemsSearchRequest();
                    req.Fields = TopFieldsHelper.GetItemFields_InList();
                    req.Query = key;
                    req.PageNo = page_no;
                    req.PageSize = page_size;
                    DataSource_Item = client.Execute(req, new ItemSearchListJsonParser());
                    Server.Transfer("QueryResult_Item.aspx");
                    break;
                //case "shop":
                //    ShopFacade shopFacade = new ShopFacade(varHelper.TOP_AppKey, varHelper.TOP_AppSecret);
                //    DataSource_Shop = shopFacade.GetShopByNick(key);
                //    Server.Transfer("QueryResult_Shop.aspx");
                //    break;
                default:
                    throw new ArgumentException("参数类型不支持 - " + type);
            }
        }
    }
}
