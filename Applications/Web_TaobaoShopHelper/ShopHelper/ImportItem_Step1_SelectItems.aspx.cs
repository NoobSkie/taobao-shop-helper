using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using Taobao.Top.Api;
using Taobao.Top.Api.Request;
using Taobao.Top.Api.Domain;
using Taobao.Top.Api.Parser;

namespace TOP.Applications.TaobaoShopHelper.ShopHelper
{
    public partial class ImportItem_Step1_SelectItems : BasePage
    {
        public ResponseList<ItemSearch> DataSource_Item { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string key = Request["v"];
            string type = Request["t"];
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
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(type))
            {
                ITopClient client = GetProductTopClient();
                switch (type.ToLower())
                {
                    case "item":
                        ItemsSearchRequest req = new ItemsSearchRequest();
                        req.Fields = TopFieldsHelper.GetItemFields_InList();
                        req.Query = key;
                        req.PageNo = page_no;
                        req.PageSize = page_size;
                        DataSource_Item = client.Execute(req, new ItemSearchListJsonParser());
                        Server.Transfer("ImportItem_Step1_SelectItems_Item.aspx");
                        break;
                    //case "shop":
                    //    ShopFacade shopFacade = new ShopFacade(AppKey, AppSecret);
                    //    DataSource_Shop = shopFacade.GetShopByNick(key);
                    //    Server.Transfer("QueryResult_Shop.aspx");
                    //    break;
                    default:
                        throw new ArgumentException("参数类型不支持 - " + type);
                }
            }
        }
    }
}
