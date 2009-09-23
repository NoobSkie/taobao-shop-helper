using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml;
using TOP.Core.Facade;
using TOP.Core.Domain;

namespace TestTOP
{
    public partial class ItemView : System.Web.UI.Page
    {
        private const string defaultAppKey = "12006575";
        private const string defaultAppSecret = "9d0a6fb5453e9b51877f9ed28b5569a9";
        private ItemFacade facade = new ItemFacade(defaultAppKey, defaultAppSecret);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["iid"]) && !string.IsNullOrEmpty(Request["nick"]))
                {
                    string iid = Request["iid"];
                    string nick = Request["nick"];

                    ItemDetail item = facade.GetItem(iid, nick);
                    if (item != null)
                    {
                        BindItem(item);
                    }
                }
            }
        }

        private void BindItem(ItemDetail item)
        {
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
            lblLocation.Text = item.Location;
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

            TOPDataList<ItemPropValue> mainProps = facade.GetItemPropValues(item.CategoryId, item.Properties);
            rptProperties.DataSource = mainProps;
            rptProperties.DataBind();

            lblDescription.Text = item.Description;
        }
    }
}
