using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Core.Facade;

namespace TestTOP.WebControls.ItemList
{
    public partial class CtrlItemListBlock : System.Web.UI.UserControl
    {
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
            }
        }
    }
}