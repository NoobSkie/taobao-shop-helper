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
            if (!IsPostBack && TemplateInfo != null)
            {
                string json = TemplateInfo.DefaultValue;
                if (!string.IsNullOrEmpty(json) && !string.IsNullOrEmpty(TemplateInfo.DataSource))
                {
                    int index;
                    if (int.TryParse(TemplateInfo.DataSource, out index))
                    {
                        imgImage.ImageUrl = json.Split(',')[index];
                    }
                    else
                    {
                        JObject obj = JObject.Parse(json);
                        if (obj[TemplateInfo.DataSource] != null)
                        {
                            imgImage.ImageUrl = obj[TemplateInfo.DataSource].Value<string>();
                        }
                    }
                }
            }
        }

        public TemplateObject TemplateInfo { get; set; }
    }
}