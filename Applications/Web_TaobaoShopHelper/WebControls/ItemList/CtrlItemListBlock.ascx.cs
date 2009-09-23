using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Core.Facade;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Common.StringTool;
using System.IO;
using System.Net;

namespace TestTOP.WebControls.ItemList
{
    public partial class CtrlItemListBlock : BaseControl
    {
        private ConstVariables varHelper = new ConstVariables();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private ItemListItem currentItem;
        public ItemListItem CurrentItem
        {
            get
            {
                return currentItem;
            }
            set
            {
                currentItem = value;
                hlnkItemPic.NavigateUrl = string.Format("~/ItemView.aspx?iid={0}&nick={1}", currentItem.Id, Server.UrlEncode(currentItem.Nick));
                imgItemPic.ImageUrl = currentItem.PicPath;
                if (currentItem.ItemType.Equals("fixed", StringComparison.OrdinalIgnoreCase))
                {
                    lblPriceTitle.Text = "一口价";
                }
                else
                {
                    lblPriceTitle.Text = "拍卖";
                }
                lblPrice.Text = double.Parse(currentItem.Price).ToString("N2");
                hlnkName.Text = currentItem.Title;
                hlnkName.NavigateUrl = string.Format("~/ItemView.aspx?iid={0}&nick={1}", currentItem.Id, Server.UrlEncode(currentItem.Nick));
                lblNick.Text = currentItem.Nick;

                btnImport.Text = string.Format("{0}#{1}", currentItem.Nick, currentItem.Id);
            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            string iid = btnImport.Text.Split('#')[1];
            string nick = btnImport.Text.Split('#')[0];
            try
            {
                string sessionKey = TOP_SessionKey;
                ItemFacade itemFacade = new ItemFacade(varHelper.TOP_AppKey, varHelper.TOP_AppSecret);
                ItemDetail itemDetail = itemFacade.GetItem(iid, nick);
                if (itemDetail != null)
                {
                    string province = EncodeHelper.GB2312ToUTF8(itemDetail.Location.State);// "浙江"ddlProvince.SelectedValue;
                    string city = EncodeHelper.GB2312ToUTF8(itemDetail.Location.City);// "杭州"ddlCity.SelectedValue;
                    string description = EncodeHelper.GB2312ToUTF8(itemDetail.Description);
                    string imgPath = null;
                    string title = itemDetail.Title;// "联想ThinkPad R400 7445-A63";// itemDetail.Title;
                    string props = itemDetail.Properties;
                    string propAlias = itemDetail.PropertyAlias;

                    if (itemDetail.ItemImgList != null && itemDetail.ItemImgList.Count > 0)
                    {
                        string imgUrl = itemDetail.ItemImgList[0].ImgUrl;
                        string dirPath = Server.MapPath("~/Images/Shops") + @"\" + nick;
                        if (!Directory.Exists(dirPath))
                        {
                            Directory.CreateDirectory(dirPath);
                        }
                        string filePath = string.Empty;
                        using (WebClient client = new WebClient())
                        {
                            filePath = SaveItem(itemDetail.ItemImgList[0], dirPath, client);
                        }
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            if (File.Exists(filePath))
                            {
                                imgPath = filePath;
                            }
                        }
                    }
                    List<string> sku_properties = new List<string>();
                    List<string> sku_quantities = new List<string>();
                    List<string> sku_prices = new List<string>();
                    List<string> sku_outer_ids = new List<string>();

                    if (itemDetail.SkuList != null)
                    {
                        foreach (Sku sku in itemDetail.SkuList)
                        {
                            // Sku s = itemFacade.GetSku(sku.Id, nick);
                            foreach (string propItem in sku.Properties.Split(';', ','))
                            {
                                sku_properties.Add(propItem);
                                sku_quantities.Add(sku.Quantity.ToString());
                                sku_prices.Add(sku.Price);
                                sku_outer_ids.Add(sku.OuterId);
                            }
                        }
                    }
                    string response = itemFacade.AddItem(itemDetail.Number
                        , itemDetail.Price
                        , itemDetail.ItemType
                        , itemDetail.StuffStatus
                        , title
                        , description
                        , province
                        , city
                        , itemDetail.CategoryId
                        , props
                        , itemDetail.ApproveStatus
                        , itemDetail.FreightPayer
                        , itemDetail.ValidateDate
                        , itemDetail.HasInvoice
                        , itemDetail.HasWarranty
                        , itemDetail.AutoRepost
                        , string.Empty              // 橱窗推荐。可选值:true,false;默认值:false(不推荐) 
                        , string.Empty              // 商品所属的店铺类目列表。按逗号分隔。结构:",cid1,cid2,...,"，如果店铺类目存在二级类目，必须传入子类目cids。 
                        , itemDetail.HasDiscount
                        , itemDetail.FeePost
                        , itemDetail.FeeExpress
                        , itemDetail.FeeEms
                        , itemDetail.ListTime
                        , itemDetail.Increment
                        , string.Empty              // 宝贝所属的运费模板ID。模板可以通过taobao.postages.get获得 
                        , imgPath
                        , itemDetail.AuctionPoint
                        , propAlias
                        , itemDetail.InputPids
                        , itemDetail.InputStr
                        , string.Join(";", sku_properties.ToArray())
                        , string.Join(",", sku_quantities.ToArray())
                        , string.Join(",", sku_prices.ToArray())
                        , string.Join(",", sku_outer_ids.ToArray())
                        //, string.Empty  
                        //, string.Empty  
                        //, string.Empty  
                        //, string.Empty  
                        , string.Empty, itemDetail.OuterId, itemDetail.ProductId
                        , sessionKey);
                    Response.Write("从店铺\"" + itemDetail.Nick + "\"导入\"" + itemDetail.Title + "\"成功！");
                }
            }
            catch (ResponseException ex)
            {
                Response.Write(ex.ErrorCode + ": " + ex.ErrorMessageCh + ": " + ex.ErrorDescription);
            }
        }

        private string SaveItem(ItemImg img, string dirPath, WebClient client)
        {
            string fileUrl = img.ImgUrl;
            fileUrl = fileUrl.Substring(fileUrl.LastIndexOf('/')).TrimStart('/');
            string imgName = fileUrl.Substring(0, fileUrl.LastIndexOf('.'));

            string ext = fileUrl.Substring(fileUrl.LastIndexOf('.'));
            string fileName = img.ItemImgId + "_" + imgName + ext;
            string filePath = string.Format(@"{0}\{1}", dirPath, fileName);

            if (Directory.GetFiles(dirPath, fileName, SearchOption.TopDirectoryOnly).Length == 0)
            {
                client.DownloadFile(img.ImgUrl, filePath);
            }
            return filePath;
        }
    }
}