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
                string path = Server.MapPath("~/Templates/test.txt");
                using (StreamReader reader = new StreamReader(path))
                {
                    template = reader.ReadToEnd();
                    reader.Close();
                }
                HTML = template;
                List<TemplateInfo> templateList = TemplateAnalyser.AnalyseTemplateList(template);
                rptBlocks.DataSource = templateList;
                rptBlocks.DataBind();
            }
        }

        private string HTML
        {
            get
            {
                return (string)ViewState["WebForm2.HTML"];
            }
            set
            {
                ViewState["WebForm2.HTML"] = value;
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            string html = HTML;
            foreach (RepeaterItem item in rptBlocks.Items)
            {
                CtrlBlock_Container block = (CtrlBlock_Container)item.FindControl("ucCtrlBlockContainer");
                string outerHtml = block.GetOuterHTML();
                string itemHtml = block.GetInputHTML();
                html = html.Replace(outerHtml, itemHtml);
            }
            lblPreview.Text = Server.HtmlEncode(html);
        }
    }
}
