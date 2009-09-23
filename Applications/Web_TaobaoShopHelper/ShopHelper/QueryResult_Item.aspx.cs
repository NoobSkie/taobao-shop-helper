using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Core.Facade;

namespace TOP.Applications.TaobaoShopHelper.ShopHelper
{
    public partial class QueryResult_Item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QueryResult resultPage = Context.Handler as QueryResult;
            if (resultPage != null)
            {
                foreach (ItemListItem item in resultPage.DataSource_Item)
                {
                    Response.Write(item.Title);
                    Response.Write("<BR />");
                }
            }
        }
    }
}
