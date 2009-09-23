using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Core.Facade;
using TOP.Core.Domain;
using TOP.Applications.TaobaoShopHelper._Common;

namespace TOP.Applications.TaobaoShopHelper.ShopHelper
{
    public partial class QueryResult : BasePage
    {
        private ConstVariables varHelper = new ConstVariables();
        public TOPDataList<ItemListItem> DataSource_Item { get; private set; }
        public Shop DataSource_Shop { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string key = Decode(Request["q"]);
            string type = Decode(Request["t"]);
            switch (type.ToLower())
            {
                case "item":
                    ItemFacade itemFacade = new ItemFacade(varHelper.TOP_AppKey, varHelper.TOP_AppSecret);
                    DataSource_Item = itemFacade.QueryItemListByKey(key);
                    Server.Transfer("QueryResult_Item.aspx");
                    break;
                case "shop":
                    ShopFacade shopFacade = new ShopFacade(varHelper.TOP_AppKey, varHelper.TOP_AppSecret);
                    DataSource_Shop = shopFacade.GetShopByNick(key);
                    Server.Transfer("QueryResult_Shop.aspx");
                    break;
                default:
                    throw new ArgumentException("参数类型不支持 - " + type);
            }
        }
    }
}
