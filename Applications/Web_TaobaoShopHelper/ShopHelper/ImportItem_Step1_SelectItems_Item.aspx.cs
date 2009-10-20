using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taobao.Top.Api.Domain;
using TOP.Applications.TaobaoShopHelper._Common;

namespace TOP.Applications.TaobaoShopHelper.ShopHelper
{
    public partial class ImportItem_Step1_SelectItems_Item : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImportItem_Step1_SelectItems resultPage = Context.Handler as ImportItem_Step1_SelectItems;
            if (resultPage != null)
            {
                ucCtrlSearchItemsMulti.ItemSource = resultPage.DataSource_Item.Content[0].ItemList;
            }
        }

        protected void lbtnNext_Click(object sender, EventArgs e)
        {
            List<string> selectedItems = ucCtrlSearchItemsMulti.SelectedItemIds;
            string query = "ImportType=item";
            foreach (string item in selectedItems)
            {
                query += "&SelectedItem=" + item;
            }
            string url = "ImportItem_Step2_Options.aspx?" + query;
            Response.Redirect(url);
        }
    }
}
