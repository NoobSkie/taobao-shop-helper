using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using System.IO;
using TOP.Common.StringTool;
using System.Net;

namespace TOP.Applications.TaobaoShopHelper
{
    public partial class TestPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdateSellerCat_Click(object sender, EventArgs e)
        {
            //CategoryFacade categoryFacade = new CategoryFacade(AppKey, AppSecret);
            //TOPDataList<SellerCategory> categories = categoryFacade.GetSellerCategories("zhongjy001");
            //categories[1].SortOrder = 5;
            //SellerCategoryResult result = categoryFacade.UpdateSellerCategory(categories[1], CurrentSessionKey);
            //Response.Write(result.CategoryId);
            //Response.Write("<BR />");
        }

        protected void btnGetShop_Click(object sender, EventArgs e)
        {
            //ShopFacade shopFacade = new ShopFacade(AppKey, AppSecret);
            //try
            //{
            //    Shop shop = shopFacade.GetShopByNick(txtShopNick.Text);
            //    Response.Write("sid:" + shop.Id);
            //    Response.Write("<BR />");
            //    Response.Write("cid:" + shop.CategoryId);
            //    Response.Write("<BR />");
            //    Response.Write("nick:" + shop.Nick);
            //    Response.Write("<BR />");
            //    Response.Write("title:" + shop.Title);
            //    Response.Write("<BR />");
            //    Response.Write("desc:" + shop.Description);
            //    Response.Write("<BR />");
            //    Response.Write("bulletin:" + shop.Bulletin);
            //    Response.Write("<BR />");
            //    Response.Write("picPath:" + shop.PicturePath);
            //    Response.Write("<BR />");
            //    Response.Write("created:" + shop.CreatedTime);
            //    Response.Write("<BR />");
            //    Response.Write("modified:" + shop.ModifiedTime);
            //    Response.Write("<BR />");
            //}
            //catch (ResponseException ex)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "show_msg", "alert('" + ex.ErrorCode + "." + ex.ErrorDescription + "');", true);
            //}
        }

        protected void btnGetItemDetail_Click(object sender, EventArgs e)
        {
            //string nick = txtNick_GetItemDetail.Text;
            //string iid = txtIid_GetItemDetail.Text;

            //ItemFacade areaFacade = new ItemFacade(AppKey, AppSecret);
            //ItemDetail itemDetail = areaFacade.GetItem(iid, nick);
            //if (itemDetail != null)
            //{
            //    Response.Write(itemDetail.Title + "，" + itemDetail.CategoryId + "，" + itemDetail.ProductId);
            //    Response.Write("<BR />");
            //    Response.Write(itemDetail.Properties);
            //    Response.Write("<BR />");
            //}
        }

        protected void btnGetProps_Click(object sender, EventArgs e)
        {
            //string cid = txtCid.Text;
            //string porps = txtProps.Text;
            //Response.Write("属性数量：" + porps.Split(';').Length.ToString());
            //Response.Write("<BR />");
            //ItemFacade itemFacade = new ItemFacade(AppKey, AppSecret);
            //TOPDataList<ItemPropValue> propList = itemFacade.GetItemPropValues(cid, porps);
            //Response.Write("结果数量：" + propList.Count.ToString());
            //Response.Write("<BR />");
            //foreach (ItemPropValue prop in propList)
            //{
            //    Response.Write(prop.PropertyId + "," + prop.PropertyName);
            //    Response.Write("<BR />");
            //    Response.Write(prop.ValueId + "," + prop.Name + "," + prop.NameAlias);
            //    Response.Write("<BR />");
            //    Response.Write("<BR />");
            //}
        }
        protected void btnAddNikeShoe_Click(object sender, EventArgs e)
        {
            string iid = "24053874a657b42778044f7c0617252a";
            string nick = "bryantgasol";
            ImportItem(nick, iid);
        }

        protected void btnAddNoteBook_Click(object sender, EventArgs e)
        {
            string iid = "d67dda3331e09275f623eaca0fddec1b";
            string nick = "hzwdf";
            ImportItem(nick, iid);
        }

        private void ImportItem(string nick, string iid)
        {
            //try
            //{
            //    ItemFacade itemFacade = new ItemFacade(AppKey, AppSecret);
            //    ItemDetail itemDetail = itemFacade.GetItem(iid, nick);
            //    if (itemDetail != null)
            //    {
            //        string province = EncodeHelper.GB2312ToUTF8(itemDetail.Location.State);// "浙江"ddlProvince.SelectedValue;
            //        string city = EncodeHelper.GB2312ToUTF8(itemDetail.Location.City);// "杭州"ddlCity.SelectedValue;
            //        string description = EncodeHelper.GB2312ToUTF8(itemDetail.Description);
            //        string imgPath = null;
            //        string title = itemDetail.Title;// "联想ThinkPad R400 7445-A63";// itemDetail.Title;
            //        string props = itemDetail.Properties;
            //        string propAlias = itemDetail.PropertyAlias;

            //        if (itemDetail.ItemImgList != null && itemDetail.ItemImgList.Count > 0)
            //        {
            //            string imgUrl = itemDetail.ItemImgList[0].ImgUrl;
            //            string dirPath = Server.MapPath("~/Images/Shops") + @"\" + nick;
            //            if (!Directory.Exists(dirPath))
            //            {
            //                Directory.CreateDirectory(dirPath);
            //            }
            //            string filePath = string.Empty;
            //            using (WebClient client = new WebClient())
            //            {
            //                filePath = SaveItem(itemDetail.ItemImgList[0], dirPath, client);
            //            }
            //            if (!string.IsNullOrEmpty(filePath))
            //            {
            //                if (File.Exists(filePath))
            //                {
            //                    imgPath = filePath;
            //                }
            //            }
            //        }
            //        List<string> sku_properties = new List<string>();
            //        List<string> sku_quantities = new List<string>();
            //        List<string> sku_prices = new List<string>();
            //        List<string> sku_outer_ids = new List<string>();

            //        if (itemDetail.SkuList != null)
            //        {
            //            foreach (Sku sku in itemDetail.SkuList)
            //            {
            //                // Sku s = itemFacade.GetSku(sku.Id, nick);
            //                foreach (string propItem in sku.Properties.Split(';', ','))
            //                {
            //                    sku_properties.Add(propItem);
            //                    sku_quantities.Add(sku.Quantity.ToString());
            //                    sku_prices.Add(sku.Price);
            //                    sku_outer_ids.Add(sku.OuterId);
            //                }
            //            }
            //        }
            //        Response.Write("<BR />");
            //        string sessionKey = CurrentSessionKey;
            //        string response = itemFacade.AddItem(itemDetail.Number
            //            , itemDetail.Price
            //            , itemDetail.ItemType
            //            , itemDetail.StuffStatus
            //            , title
            //            , description
            //            , province
            //            , city
            //            , itemDetail.CategoryId
            //            , props
            //            , itemDetail.ApproveStatus
            //            , itemDetail.FreightPayer
            //            , itemDetail.ValidateDate
            //            , itemDetail.HasInvoice
            //            , itemDetail.HasWarranty
            //            , itemDetail.AutoRepost
            //            , string.Empty              // 橱窗推荐。可选值:true,false;默认值:false(不推荐) 
            //            , string.Empty              // 商品所属的店铺类目列表。按逗号分隔。结构:",cid1,cid2,...,"，如果店铺类目存在二级类目，必须传入子类目cids。 
            //            , itemDetail.HasDiscount
            //            , itemDetail.FeePost
            //            , itemDetail.FeeExpress
            //            , itemDetail.FeeEms
            //            , itemDetail.ListTime
            //            , itemDetail.Increment
            //            , string.Empty              // 宝贝所属的运费模板ID。模板可以通过taobao.postages.get获得 
            //            , imgPath
            //            , itemDetail.AuctionPoint
            //            , propAlias
            //            , itemDetail.InputPids
            //            , itemDetail.InputStr
            //            , string.Join(";", sku_properties.ToArray())
            //            , string.Join(",", sku_quantities.ToArray())
            //            , string.Join(",", sku_prices.ToArray())
            //            , string.Join(",", sku_outer_ids.ToArray())
            //            //, string.Empty  
            //            //, string.Empty  
            //            //, string.Empty  
            //            //, string.Empty  
            //            , string.Empty, itemDetail.OuterId, itemDetail.ProductId
            //            , CurrentSessionKey);
            //        Response.Write("从店铺\"" + itemDetail.Nick + "\"导入\"" + itemDetail.Title + "\"成功！");
            //    }
            //}
            //catch (ResponseException ex)
            //{
            //    Response.Write(ex.ErrorCode + ": " + ex.ErrorMessageCh + ": " + ex.ErrorDescription);
            //}
        }

        //private string SaveItem(ItemImg img, string dirPath, WebClient client)
        //{
        //    string fileUrl = img.ImgUrl;
        //    fileUrl = fileUrl.Substring(fileUrl.LastIndexOf('/')).TrimStart('/');
        //    string imgName = fileUrl.Substring(0, fileUrl.LastIndexOf('.'));

        //    string ext = fileUrl.Substring(fileUrl.LastIndexOf('.'));
        //    string fileName = img.ItemImgId + "_" + imgName + ext;
        //    string filePath = string.Format(@"{0}\{1}", dirPath, fileName);

        //    if (Directory.GetFiles(dirPath, fileName, SearchOption.TopDirectoryOnly).Length == 0)
        //    {
        //        client.DownloadFile(img.ImgUrl, filePath);
        //    }
        //    return filePath;
        //}

        protected void btnQueryProduct_Click(object sender, EventArgs e)
        {
            //ProductFacade productFacade = new ProductFacade(AppKey, AppSecret);
            //string key = EncodeHelper.GB2312ToUTF8(txtKey_Query_Product.Text);
            //string cid = txtCid_Query_Product.Text;
            //string props = txtProps_Query_Product.Text;
            //TOPDataList<ProductListItem> productList = productFacade.QueryProducts(key, cid, props, 5, 1);
            //foreach (ProductListItem product in productList)
            //{
            //    Response.Write(product.ProductId + "，" + product.Tsc + "，" + product.CategoryId + "，" + product.ProductName + "，" + product.Price);
            //    Response.Write("<BR />");
            //    Response.Write("图片路径：" + product.PicturePath);
            //    Response.Write("<BR />");
            //    Response.Write("属性：" + product.Properties);
            //    Response.Write("<BR />");
            //    Response.Write("<BR />");
            //}
        }

        protected void btnGetProductById_Click(object sender, EventArgs e)
        {
            //ProductFacade productFacade = new ProductFacade(AppKey, AppSecret);
            //TOPDataList<Product> productList = productFacade.GetProduct(txtKey_Query_Product.Text);
            //foreach (Product product in productList)
            //{
            //    DisplayProduct(product);
            //}
        }

        protected void btnGetProductByProps_Click(object sender, EventArgs e)
        {
            //ProductFacade productFacade = new ProductFacade(AppKey, AppSecret);
            //TOPDataList<Product> productList = productFacade.GetProduct(txtCid_Query_Product.Text, txtProps_Query_Product.Text);
            //foreach (Product product in productList)
            //{
            //    DisplayProduct(product);
            //}
        }

        //private void DisplayProduct(Product product)
        //{
        //    Response.Write(product.ProductId + "，" + product.Tsc + "，" + product.CategoryId + "，" + product.ProductName + "，" + product.Price);
        //    Response.Write("<BR />");
        //    Response.Write("图片路径：" + product.PicturePath);
        //    Response.Write("<BR />");
        //    Response.Write("属性：" + product.Properties);
        //    Response.Write("<BR />");
        //    Response.Write("<BR />");
        //}
    }
}
