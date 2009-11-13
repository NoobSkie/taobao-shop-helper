using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper.WebControls.Common;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Common.CompressionTool;
using Taobao.Top.Api.Domain;
using System.Web.Script.Serialization;
using Taobao.Top.Api;
using Taobao.Top.Api.Request;
using Taobao.Top.Api.Parser;

namespace TOP.Applications.TaobaoShopHelper.ShopHelper
{
    public partial class ImportShop3 : BasePage, IMenuPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentUser == null)
            {
                string msg = CompressionHelper.Compress("必须登录系统，才能执行导入店铺的操作！");
                string url = "~/Authorizes/UnLogin.aspx?ReturnUrl=" + Server.UrlEncode(Request.Url.AbsoluteUri) + "&Msg=" + Server.UrlEncode(msg);
                Response.Redirect(url);
            }
            if (string.IsNullOrEmpty(CurrentSessionKey) || string.IsNullOrEmpty(CurrentSellerNick))
            {
                CurrentSellerNick = "zhandt";
                //string msg = CompressionHelper.Compress("必须先获取淘宝授权，才能执行导入店铺的操作！");
                //string url = "~/Authorizes/UnAuthorize.aspx?ReturnUrl=" + Server.UrlEncode(Request.Url.AbsoluteUri) + "&Msg=" + Server.UrlEncode(msg);
                //Response.Redirect(url);
            }
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["Shop"]))
                {
                    string json = CompressionHelper.Decompress(Request["Shop"]);
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    Shop shop = ser.Deserialize<Shop>(json);
                    DisplayShop(shop);
                    string url = "ImportShop2.aspx?Nick=" + Request["Nick"] + "&Shop=" + Request["Shop"];
                    hlnkPrev.NavigateUrl = url;
                }
                else
                {
                    Response.Redirect("ImportShop1.aspx");
                }
            }
        }

        private List<string> ignoreList;
        private List<string> IgnoreList
        {
            get
            {
                if (ignoreList == null)
                {
                    if (string.IsNullOrEmpty(Request["IgnoreList"]))
                    {
                        ignoreList = new List<string>();
                    }
                    else
                    {
                        string json = CompressionHelper.Decompress(Request["IgnoreList"]);
                        JavaScriptSerializer ser = new JavaScriptSerializer();
                        ignoreList = ser.Deserialize<List<string>>(json);
                    }
                }
                return ignoreList;
            }
        }

        private void DisplayShop(Shop shop)
        {
            if (!string.IsNullOrEmpty(shop.LogoUrl))
            {
                imgShop.Visible = true;
                imgShop.ImageUrl = string.Format(ShopLogUrlFormat, shop.LogoUrl);
            }
            else
            {
                imgShop.Visible = false;
            }
            lblNick.Text = shop.SellerNick;
            lblShopTitle.Text = shop.Title;

            ITopClient client = GetProductTopClient();
            ItemsGetRequest reqItems = new ItemsGetRequest();
            reqItems.Fields = TopFieldsHelper.GetItemFields_OnlyId();
            reqItems.Nicks = shop.SellerNick;
            reqItems.PageNo = 1;
            reqItems.PageSize = 1;
            ResponseList<Item> rsp = client.Execute(reqItems, new ItemListJsonParser());
            lblItemCount.Text = rsp.TotalResults.ToString();
            lblImportCount.Text = (rsp.TotalResults - IgnoreList.Count).ToString();
        }

        protected void lbtnImport_Click(object sender, EventArgs e)
        {
            string url = "ImportShop4.aspx?Nick=" + Server.UrlEncode(Request["Nick"]) + "&Shop=" + Server.UrlEncode(Request["Shop"]) + "&IgnoreList=";
            if (!string.IsNullOrEmpty(Request["IgnoreList"]))
            {
                url += Request["IgnoreList"];
            }
            Response.Redirect(url);
        }

        #region IMenuPage Members

        public string GetTopMenuId()
        {
            return "MyShop";
        }

        public string GetSecondMenuId()
        {
            return "ImportShop";
        }

        #endregion
    }
}
