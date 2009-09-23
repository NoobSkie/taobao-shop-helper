using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Core.Facade;
using TOP.Core.Domain;
using TOP.Applications.TaobaoShopHelper._Common;

namespace TOP.Applications.TaobaoShopHelper
{
    public partial class ItemView : System.Web.UI.Page
    {
        private ConstVariables varHelper = new ConstVariables();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["iid"]) && !string.IsNullOrEmpty(Request["nick"]))
                {
                    string iid = Request["iid"];
                    string nick = Request["nick"];

                    ItemFacade itemFacade = new ItemFacade(varHelper.TOP_AppKey, varHelper.TOP_AppSecret);
                    ItemDetail item = itemFacade.GetItem(iid, nick);
                    if (item != null)
                    {
                        BindItem(item);
                    }
                }
            }
        }

        private void BindItem(ItemDetail item)
        {
            ItemFacade itemFacade = new ItemFacade(varHelper.TOP_AppKey, varHelper.TOP_AppSecret);
            lblName.Text = item.Title;
            imgItemPic.ImageUrl = item.PicPath;
            if (item.ItemType.Equals("fixed", StringComparison.OrdinalIgnoreCase))
            {
                lblPriceTitle.Text = "一口价";
            }
            else
            {
                lblPriceTitle.Text = "拍卖";
            }
            lblPrice.Text = double.Parse(item.Price).ToString("N2");
            if (item.FreightPayer.Equals("seller", StringComparison.OrdinalIgnoreCase))
            {
                lblFee.Text = "卖家承担运费";
            }
            else
            {
                lblFee.Text = string.Format("平邮: {0}; 快递: {1}; EMS: {2}"
                    , double.Parse(item.FeePost).ToString("N2")
                    , double.Parse(item.FeeExpress).ToString("N2")
                    , double.Parse(item.FeeEms).ToString("N2"));
            }
            lblLocation.Text = item.Location.ToString();
            if (item.StuffStatus.Equals("new", StringComparison.OrdinalIgnoreCase))
            {
                lblType.Text = "全新";
            }
            else if (item.StuffStatus.Equals("unused", StringComparison.OrdinalIgnoreCase))
            {
                lblType.Text = "全新";
            }
            else if (item.StuffStatus.Equals("second", StringComparison.OrdinalIgnoreCase))
            {
                lblType.Text = "二手";
            }
            else
            {
                lblType.Text = "错误";
            }

            TOPDataList<ItemPropValue> mainProps = itemFacade.GetItemPropValues(item.CategoryId, item.Properties);
            rptProperties.DataSource = mainProps;
            rptProperties.DataBind();

            lblDescription.Text = item.Description;
        }
    }
}
