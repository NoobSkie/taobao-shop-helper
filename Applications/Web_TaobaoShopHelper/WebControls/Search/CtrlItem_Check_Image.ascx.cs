using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taobao.Top.Api.Domain;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Search
{
    public partial class CtrlItem_Check_Image : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string script = "function SelectItem(ctrlObj, type, iid, title, imgUrl, price){ }";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Script_SelectItem_Image", script, true);
                if (this.Item != null)
                {
                    cbCheck.Attributes["onclick"] =
                        string.Format("SelectItem(this, 'image', '{0}', '{1}', '{2}', '{3}', '{4}', '{5}')"
                        , this.Item.Iid
                        , this.Item.Nick
                        , this.Item.Title
                        , this.item.DetailUrl
                        , this.Item.PicPath
                        , this.Item.Price);
                }
            }
        }

        private Item item;
        public Item Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;

                // imgImage.ImageUrl = value.PicPath;
                cbCheck.Text = value.Title;
                lblPrice.Text = value.Price;
            }
        }

        public bool IsChecked
        {
            get
            {
                return cbCheck.Checked;
            }
            set
            {
                cbCheck.Checked = value;
            }
        }
    }
}