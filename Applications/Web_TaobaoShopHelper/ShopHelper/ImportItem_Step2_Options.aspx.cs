using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;

namespace TOP.Applications.TaobaoShopHelper.ShopHelper
{
    public partial class ImportItem_Step2_Options : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string items = Request["SelectedItem"];
                string[] itemList = items.Split(',');
                lblItemNumber.Text = "要导入商品数量：" + itemList.Length.ToString();
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {

        }

        protected void lbtnImport_Click(object sender, EventArgs e)
        {

        }
    }
}
