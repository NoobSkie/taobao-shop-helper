using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;

namespace TOP.Applications.TaobaoShopHelper
{
    public partial class MyItems : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ShopFacade facade = new ShopFacade(AppKey, AppSecret);
            //TOPDataList<SampleListItem> items = facade.GetAllShopItems(1, 20, TOP_SessionKey);

            //foreach (SampleListItem item in items)
            //{
            //    Response.Write(item.Title);
            //    Response.Write("<BR />");
            //}

            //Response.Write("<BR />");

            //CategoryFacade categoryFacade = new CategoryFacade(AppKey, AppSecret);
            //TOPDataList<ItemCategory> categories = categoryFacade.GetItemCategories(string.Empty, string.Empty);
            //foreach (ItemCategory categroy in categories)
            //{
            //    Response.Write("Id: " + categroy.Id + "; ");
            //    Response.Write("Name: " + categroy.Name + "; ");
            //    Response.Write("ParentId: " + categroy.ParentId + "; ");
            //    Response.Write("IsParent: " + categroy.IsParent + "; ");
            //    Response.Write("Status: " + categroy.Status + "; ");
            //    Response.Write("SortOrder: " + categroy.SortOrder);
            //    Response.Write("<BR />");
            //}

            //ItemFacade itemFacade = new ItemFacade(AppKey, AppSecret);
            //string iid = "ff5877fe8e9fa838043b43d7f20f7dfd";
            //try
            //{
            //    ItemDetail itemDetail = itemFacade.GetItem(iid, "zhongjy001");
            //    string response = itemFacade.AddItem(itemDetail, TOP_SessionKey);
            //}
            //catch (ResponseException ex)
            //{
            //    Response.Write(ex.ErrorCode + ": " + ex.ErrorMessageCh);
            //}

            //CategoryFacade categoryFacade = new CategoryFacade(AppKey, AppSecret);
            //TOPDataList<SellerCategory> categories = categoryFacade.GetSellerCategories("zhongjy001");
            //foreach (SellerCategory categroy in categories)
            //{
            //    Response.Write(categroy.Name);
            //    Response.Write("<BR />");
            //}

            //CategoryFacade categoryFacade = new CategoryFacade(AppKey, AppSecret);
            //TOPDataList<ShopCategory> categories = categoryFacade.GetShopCategories();
            //foreach (ShopCategory categroy in categories)
            //{
            //    Response.Write(categroy.Name);
            //    Response.Write("<BR />");
            //}

            //CategoryFacade categoryFacade = new CategoryFacade(AppKey, AppSecret);
            //TOPDataList<SellerCategory> categories = categoryFacade.GetSellerCategories("zhongjy001");
            //categories[1].SortOrder = 5;
            //SellerCategoryResult result = categoryFacade.UpdateSellerCategory(categories[1], TOP_SessionKey);
            //Response.Write(result.CategoryId);
            //Response.Write("<BR />");
        }
    }
}
