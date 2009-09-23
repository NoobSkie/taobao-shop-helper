using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TOP.Applications.TaobaoShopHelper.TestPages
{
    public partial class TestStyles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(this.AppRelativeTemplateSourceDirectory);
            Response.Write("<BR />");
            Response.Write(this.AppRelativeVirtualPath);
            Uri url = Request.Url;
            
            //Response.Write(url.ToString());
            //url = url.MakeRelativeUri(url);
            //Response.Write("<BR />");
            //Response.Write(url.ToString());
        }
    }
}
