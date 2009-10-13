using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taobao.Top.Api.Domain;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Search
{
    public partial class CtrlItem_Check_List : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Item Item { get; set; }
    }
}