using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Applications.TaobaoShopHelper.WebControls.Common;
using TOP.Common.CompressionTool;
using Newtonsoft.Json.Linq;
using Taobao.Top.Api.Domain;
using System.Web.Script.Serialization;
using Taobao.Top.Api.Request;
using Taobao.Top.Api;
using Taobao.Top.Api.Parser;

namespace TOP.Applications.TaobaoShopHelper.ShopHelper
{
    public partial class ImportShop2 : BasePage, IMenuPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<InformationObject> infoList = new List<InformationObject>();
            if (CurrentUser == null)
            {
                infoList.Add(GetUnLoginInformation());
            }
            if (string.IsNullOrEmpty(CurrentSessionKey) || string.IsNullOrEmpty(CurrentSellerNick))
            {
                infoList.Add(GetUnAuthorizeInformation());
            }
            if (infoList.Count > 0)
            {
                DisplayInformations(infoList);
            }

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["Shop"]))
                {
                    string json = CompressionHelper.Decompress(Request["Shop"]);
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    Shop shop = ser.Deserialize<Shop>(json);
                    DisplayShop(shop);
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
            lblTitle.Text = "导入店铺 - " + shop.Title;
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
            UserGetRequest req = new UserGetRequest();
            req.Fields = TopFieldsHelper.GetUserFields_All();
            req.Nick = shop.SellerNick;
            User user = client.Execute(req, new UserJsonParser());
            if (user != null)
            {
                ucCtrlCreditBuyer.CreditNum = user.BuyerCredit.GoodNum;
                ucCtrlCreditSeller.CreditNum = user.SellerCredit.GoodNum;
            }

            ItemsGetRequest reqItems = new ItemsGetRequest();
            reqItems.Fields = TopFieldsHelper.GetItemFields_InList();
            reqItems.Nicks = shop.SellerNick;
            reqItems.PageNo = ucCtrlPager.PageIndex + 1;
            reqItems.PageSize = ucCtrlPager.PageSize;
            ResponseList<Item> rsp = client.Execute(reqItems, new ItemListJsonParser());
            ucCtrlPager.TotalCount = (int)rsp.TotalResults;
            rptItems.DataSource = rsp.Content;
            rptItems.DataBind();
        }

        protected void rptItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                Item item = e.Item.DataItem as Item;
                if (IgnoreList.Contains(item.Iid))
                {
                    CheckBox cbCheck = e.Item.FindControl("cbCheck") as CheckBox;
                    cbCheck.Checked = true;
                }
            }
        }

        protected void lbtnPrev_Click(object sender, EventArgs e)
        {

        }

        protected void lbtnNext_Click(object sender, EventArgs e)
        {

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
