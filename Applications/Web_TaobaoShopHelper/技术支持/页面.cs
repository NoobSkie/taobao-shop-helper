using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOP.Applications.TaobaoShopHelper.技术支持
{
    public class 页面
    {
        protected void btnAddNoteBook_Click(object sender, EventArgs e)
        {
            ItemFacade itemFacade = new ItemFacade(varHelper.TOP_AppKey, varHelper.TOP_AppSecret);
            string iid = "d67dda3331e09275f623eaca0fddec1b";
            string nick = "hzwdf";
            try
            {
                string sessionKey = TOP_SessionKey;
                ItemDetail itemDetail = itemFacade.GetItem(iid, nick);
                if (itemDetail != null)
                {
                    string province = EncodeHelper.GB2312ToUTF8(itemDetail.Location.State);// "浙江"ddlProvince.SelectedValue;
                    string city = EncodeHelper.GB2312ToUTF8(itemDetail.Location.City);// "杭州"ddlCity.SelectedValue;
                    string description = EncodeHelper.GB2312ToUTF8(itemDetail.Description);
                    string imgPath = null;
                    string title = "ThinkPad SL400 2743P9C";// itemDetail.Title;
                    string props = "20879:21456;1627207:28341;20000:21642;20155:3218646;1626045:13243855;31356:100692;20100:21373;20143:45566;31359:3218681;22572:37064;20121:21482;22623:47286;20122:685;20137:21487;20145:21588;21530:42376;20183:21968;31357:3220749;20930:32998;31696:107066;1626817:3227612;1626975:3229217";// itemDetail.Properties;
                    string propAlias = "";// itemDetail.PropertyAlias;

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

                    foreach (Sku sku in itemDetail.SkuList)
                    {
                        // Sku s = itemFacade.GetSku(sku.Id, nick);
                        sku_properties.Add(sku.Properties);
                        sku_quantities.Add(sku.Quantity.ToString());
                        sku_prices.Add(sku.Price);
                        sku_outer_ids.Add(sku.OuterId);
                    }
                    Response.Write("<BR />");
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
                        , string.Empty, itemDetail.OuterId, itemDetail.ProductId
                        , TOP_SessionKey);
                    Response.Write("从店铺\"" + itemDetail.Nick + "\"导入\"" + itemDetail.Title + "\"成功！");
                }
            }
            catch (ResponseException ex)
            {
                Response.Write(ex.ErrorCode + ": " + ex.ErrorMessageCh + ": " + ex.ErrorDescription);
            }
        }
    }
}
