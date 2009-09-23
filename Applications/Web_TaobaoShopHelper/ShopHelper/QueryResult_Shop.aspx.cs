using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TOP.Applications.TaobaoShopHelper.ShopHelper
{
    public partial class QueryResult_Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QueryResult resultPage = Context.Handler as QueryResult;
            if (resultPage != null)
            {
                Response.Write(resultPage.DataSource_Shop.Title);
            }
        }
    }
}
