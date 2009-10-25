using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Template.Facade;
using Newtonsoft.Json.Linq;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Template
{
    public partial class CtrlDisplayItem_Text : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && TemplateInfo != null)
            {
                string json = TemplateInfo.DefaultValue;
                if (!string.IsNullOrEmpty(json) && !string.IsNullOrEmpty(TemplateInfo.DataSource))
                {
                    int index;
                    if (int.TryParse(TemplateInfo.DataSource, out index))
                    {
                        lblText.Text = json.Split(',')[index];
                    }
                    else
                    {
                        JObject obj = JObject.Parse(json);
                        if (obj[TemplateInfo.DataSource] != null)
                        {
                            lblText.Text = obj[TemplateInfo.DataSource].Value<string>();
                        }
                    }
                    if (!string.IsNullOrEmpty(TemplateInfo.CssName))
                    {
                        lblText.CssClass = TemplateInfo.CssName;
                    }
                    lblTitle.Visible = TemplateInfo.ShowTitle;
                    if (TemplateInfo.ShowTitle)
                    {
                        lblTitle.Text = TemplateInfo.DisplayName;
                    }
                }
            }
        }

        public TemplateObject TemplateInfo { get; set; }
    }
}