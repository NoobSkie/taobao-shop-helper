using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using TOP.Template.Facade;

namespace TOP.Applications.TaobaoShopHelper.Templates
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private int currentIndex = 0;

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
                DisplayTemplate(template);
            }
        }

        private void DisplayTemplate(string html)
        {
            List<TemplateInfo> templateList = TemplateAnalyser.AnalyseTemplateList(html);
            DisplayTemplate(templateList, -1);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FinishInitTemplateContainer", "FinishInit();", true);
        }

        private void DisplayTemplate(List<TemplateInfo> templateList, int parentId)
        {
            foreach (TemplateInfo template in templateList)
            {
                currentIndex++;
                string js = string.Format("InitContainer('{0}', '{1}', '{2}', '{3}', '{4}', {5}, {6}, {7}, {8}, {9}, {10});"
                    , currentIndex
                    , template.Category
                    , template.DisplayName
                    , template.DataType
                    , template.DefaultValue
                    , template.ShowTitle.ToString().ToLower()
                    , true
                    , template.TitleWidth
                    , template.InputWidth
                    , template.InputHeight
                    , parentId);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "AddTemplateBlock_" + currentIndex.ToString(), js, true);
                if (template.Category.ToLower() == "list" && template.Children != null && template.Children.Count > 0)
                {
                    DisplayTemplate(template.Children, currentIndex);
                }
            }
        }
    }
}
