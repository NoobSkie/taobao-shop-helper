using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taobao.Top.Api.Domain;

namespace TOP.Applications.TaobaoShopHelper.ShopHelper
{
    public partial class QueryResult_Item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QueryResult resultPage = Context.Handler as QueryResult;
            if (resultPage != null)
            {
                Response.Write("查询结果：" + resultPage.DataSource_Item.TotalResults.ToString());
                Response.Write("<BR />");
                Response.Write("<BR />");
                foreach (ItemSearch itemSearch in resultPage.DataSource_Item.Content)
                {
                    foreach (Item item in itemSearch.ItemList)
                    {
                        Response.Write(item.Title + "（" + item.Price + "）");
                        Response.Write("<BR />");
                    }
                }
            }
        }
    }
}
