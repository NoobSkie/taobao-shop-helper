using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using TOP.Template.Facade;
using TOP.Applications.TaobaoShopHelper.WebControls.Template;

namespace TOP.Applications.TaobaoShopHelper.Templates
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string template;
                string path = Server.MapPath("~/Templates/test1.txt");
                using (StreamReader reader = new StreamReader(path))
                {
                    template = reader.ReadToEnd();
                    reader.Close();
                }
                ucTemplateEditor.TemplateHtml = template;
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            lblPreview.Text = Server.HtmlEncode(ucTemplateEditor.GetHtml());
        }
    }
}
