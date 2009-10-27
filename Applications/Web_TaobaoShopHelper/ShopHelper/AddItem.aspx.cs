using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Common.StringTool;
using System.Net;
using System.IO;

namespace TOP.Applications.TaobaoShopHelper.ShopHelper
{
    public partial class AddItem : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LocalFacade.AreaFacade areaFacade = new LocalFacade.AreaFacade();
                //ddlProvince.DataSource = areaFacade.GetAllProvinceAreaList();
                //ddlProvince.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //TOPFacade.ItemDetail item = new TOPFacade.ItemDetail();
            //item.Title = txtTitle.Text;
            //item.StuffStatus = txtStatus.Text;
            //item.Number = txtNum.Text;
            //item.Price = txtPrice.Text;

            //TOPFacade.ItemFacade itemFacade = new TOPFacade.ItemFacade(AppKey, AppSecret);

            //string nick = "zhongjy001"; // lengyongli168
            //string iid = "d73161a86043f0740310949016ef60b4"; // d09cc0a5712adc0786e8514110f82dac
            //try
            //{
            //    TOPFacade.ItemDetail itemDetail = itemFacade.GetItem(iid, nick);
            //    string province = EncodeHelper.GB2312ToUTF8(itemDetail.Location.State);// "浙江"ddlProvince.SelectedValue;
            //    string city = EncodeHelper.GB2312ToUTF8(itemDetail.Location.City);// "杭州"ddlCity.SelectedValue;
            //    string description = EncodeHelper.GB2312ToUTF8(itemDetail.Description);
            //    string imgPath = string.Empty;
            //    if (itemDetail.ItemImgList != null && itemDetail.ItemImgList.Count > 0)
            //    {
            //        string imgUrl = itemDetail.ItemImgList[0].ImgUrl;
            //        string dirPath = Server.MapPath("~/Images/Shops") + @"\" + nick;
            //        if (!Directory.Exists(dirPath))
            //        {
            //            Directory.CreateDirectory(dirPath);
            //        }
            //        string filePath = string.Empty;
            //        using (WebClient client = new WebClient())
            //        {
            //            filePath = SaveItem(itemDetail.ItemImgList[0], dirPath, client);
            //        }
            //        if (!string.IsNullOrEmpty(filePath))
            //        {
            //            if (File.Exists(filePath))
            //            {
            //                imgPath = filePath;
            //            }
            //        }
            //    }
            //    string response = itemFacade.AddItem(itemDetail.Number
            //        , itemDetail.Price
            //        , itemDetail.ItemType
            //        , itemDetail.StuffStatus
            //        , itemDetail.Title
            //        , description
            //        , province
            //        , city
            //        , itemDetail.CategoryId
            //        , itemDetail.Properties
            //        , itemDetail.ApproveStatus
            //        , itemDetail.FreightPayer
            //        , itemDetail.ValidateDate
            //        , itemDetail.HasInvoice
            //        , itemDetail.HasWarranty
            //        , itemDetail.AutoRepost
            //        , string.Empty              // 橱窗推荐。可选值:true,false;默认值:false(不推荐) 
            //        , string.Empty              // 商品所属的店铺类目列表。按逗号分隔。结构:",cid1,cid2,...,"，如果店铺类目存在二级类目，必须传入子类目cids。 
            //        , itemDetail.HasDiscount
            //        , itemDetail.FeePost
            //        , itemDetail.FeeExpress
            //        , itemDetail.FeeEms
            //        , itemDetail.ListTime
            //        , itemDetail.Increment
            //        , string.Empty              // 宝贝所属的运费模板ID。模板可以通过taobao.postages.get获得 
            //        , imgPath
            //        , itemDetail.AuctionPoint
            //        , itemDetail.PropertyAlias
            //        , itemDetail.InputPids
            //        , itemDetail.InputStr
            //        , "", "", "", "", ""
            //        , string.Empty, string.Empty
            //        , CurrentSessionKey);
            //    Response.Write(province + "." + city + ".");
            //}
            //catch (TOPFacade.ResponseException ex)
            //{
            //    Response.Write(ex.ErrorCode + ": " + ex.ErrorMessageCh + ": " + ex.ErrorDescription);
            //}
        }

        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string parentId = ddlProvince.SelectedValue;

            //LocalFacade.AreaFacade areaFacade = new LocalFacade.AreaFacade();
            //ddlCity.DataSource = areaFacade.GetAreaListByParentId(parentId);
            //ddlCity.DataBind();
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
    }
}
