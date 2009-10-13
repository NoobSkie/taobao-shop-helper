using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taobao.Top.Api.Domain;
using TOP.Applications.TaobaoShopHelper._Common;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Search
{
    public partial class CtrlItem_Check : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                switch (DisplayType)
                {
                    case ItemDisplayType.Image:
                        ucCtrlItemCheckImage.Visible = true;
                        ucCtrlItemCheckList.Visible = false;

                        ucCtrlItemCheckImage.Item = Item;
                        break;
                    case ItemDisplayType.List:
                        ucCtrlItemCheckImage.Visible = false;
                        ucCtrlItemCheckList.Visible = true;

                        ucCtrlItemCheckList.Item = Item;
                        break;
                    default:
                        ucCtrlItemCheckImage.Visible = false;
                        ucCtrlItemCheckList.Visible = false;
                        break;
                }
            }
        }

        public Item Item { get; set; }

        public ItemDisplayType DisplayType { get; set; }
    }
}