using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Template.Facade;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Template
{
    public partial class CtrlBlock_Display : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (TemplateInfo != null && !TemplateInfo.ShowThis)
            {
                this.Visible = false;
            }
        }

        private TemplateObject templateInfo;
        public TemplateObject TemplateInfo
        {
            get
            {
                return templateInfo;
            }
            set
            {
                templateInfo = value;

                foreach (Control ctrl in this.Controls)
                {
                    ctrl.Visible = false;
                }
                switch (value.DataType.ToLower())
                {
                    case "text":
                        ucCtrlDisplayItemText.Visible = true;
                        ucCtrlDisplayItemText.TemplateInfo = value;
                        break;
                    case "image":
                        ucCtrlDisplayItemImage.Visible = true;
                        ucCtrlDisplayItemImage.TemplateInfo = value;
                        break;
                }
            }
        }
    }
}