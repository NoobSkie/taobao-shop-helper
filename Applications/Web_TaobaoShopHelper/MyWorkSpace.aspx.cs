using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;

namespace TOP.Applications.TaobaoShopHelper
{
    public partial class MyWorkSpace : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(this.AppRelativeTemplateSourceDirectory);
            Response.Write("<BR />");
            Response.Write(this.AppRelativeVirtualPath);

        }
    }
}
