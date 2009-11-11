using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper.WebControls.Common;
using TOP.Applications.TaobaoShopHelper._Common;
using Taobao.Top.Api;
using Taobao.Top.Api.Request;
using Taobao.Top.Api.Domain;
using Taobao.Top.Api.Parser;
using Newtonsoft.Json.Linq;
using TOP.Common.CompressionTool;
using System.Web.Script.Serialization;

namespace TOP.Applications.TaobaoShopHelper.ShopHelper
{
    public partial class ImportShop1 : BasePage, IMenuPage
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
            else if (!IsPostBack)
            {
            }
            if (!string.IsNullOrEmpty(Request["Nick"]) && !string.IsNullOrEmpty(Request["ErrorMsg"]))
            {
                string msg = "错误\"" + Request["Nick"] + "\" - " + CompressionHelper.Decompress(Request["ErrorMsg"]);
                InformationObject obj = new InformationObject();
                obj.CssName = "ErrorMsg";
                obj.Message = msg;
                infoList.Add(obj);
                DisplayInformations(infoList, InformationIcoType.Error);
            }
            else if (infoList.Count > 0)
            {
                DisplayInformations(infoList);
            }
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            ITopClient client = GetProductTopClient();
            ShopGetRequest req = new ShopGetRequest();
            req.Fields = TopFieldsHelper.GetShopFields_Common();
            req.Nick = txtKey.Text;
            try
            {
                Shop shop = client.Execute(req, new ShopJsonParser());
                JavaScriptSerializer ser = new JavaScriptSerializer();
                string json = ser.Serialize(shop); //JObject.FromObject(shop).ToString();
                string arg = CompressionHelper.Compress(json);
                string url = "ImportShop2.aspx?Shop=" + Server.UrlEncode(arg);
                Response.Redirect(url, false);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string arg = CompressionHelper.Compress(msg);
                string url = "ImportShop1.aspx?Nick=" + Server.UrlEncode(txtKey.Text) + "&ErrorMsg=" + Server.UrlEncode(arg);
                Response.Redirect(url, true);
            }
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
