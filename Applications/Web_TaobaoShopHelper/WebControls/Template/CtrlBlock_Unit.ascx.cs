using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Template.Facade;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Template
{
    public partial class CtrlBlock_Unit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                switch (value.Category.ToLower())
                {
                    case "input":
                        ucCtrlBlockInput.Visible = true;
                        ucCtrlBlockInput.TemplateInfo = value;
                        break;
                    case "display":
                        ucCtrlBlockDisplay.Visible = true;
                        ucCtrlBlockDisplay.TemplateInfo = value;
                        break;
                }
            }
        }

        public void SaveCurrentValue()
        {
            switch (TemplateInfo.Category.ToLower())
            {
                case "input":
                    ucCtrlBlockInput.SaveCurrentValue();
                    break;
            }
        }

        public string GetOuterHTML()
        {
            return TemplateInfo.OuterHTML;
        }

        public string GetInputHTML()
        {
            switch (TemplateInfo.Category.ToLower())
            {
                case "input":
                    return ucCtrlBlockInput.GetInputHTML();
                case "display":
                    return ucCtrlBlockDisplay.GetInputHTML();
            }
            return string.Empty;
        }
    }
}