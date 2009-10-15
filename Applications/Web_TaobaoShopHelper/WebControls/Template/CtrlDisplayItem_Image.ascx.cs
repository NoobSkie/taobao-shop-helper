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
    public partial class CtrlDisplayItem_Image : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public TemplateInfo TemplateInfo
        {
            get
            {
                return (TemplateInfo)ViewState["CtrlInputItem_ImageUrl.TemplateInfo"];
            }
            set
            {
                ViewState["CtrlInputItem_ImageUrl.TemplateInfo"] = value;

                string json = value.DefaultValue;
                if (!string.IsNullOrEmpty(json) && !string.IsNullOrEmpty(value.DataSource))
                {
                    JObject obj = JObject.Parse(json);
                    if (obj[value.DataSource] != null)
                    {
                        imgImage.ImageUrl = obj[value.DataSource].Value<string>();
                    }
                }
            }
        }

        public string GetInputHTML()
        {
            return imgImage.ImageUrl;
        }
    }
}