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

        public TemplateInfo TemplateInfo
        {
            get
            {
                return (TemplateInfo)ViewState["CtrlBlock_Input.TemplateInfo"];
            }
            set
            {
                ViewState["CtrlBlock_Input.TemplateInfo"] = value;

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

        public string GetOuterHTML()
        {
            return TemplateInfo.OuterHTML;
        }

        public string GetInputHTML()
        {
            switch (TemplateInfo.DataType.ToLower())
            {
                case "text":
                    return ucCtrlDisplayItemText.GetInputHTML();
                case "image":
                    return ucCtrlDisplayItemImage.GetInputHTML();
            }
            return string.Empty;
        }
    }
}