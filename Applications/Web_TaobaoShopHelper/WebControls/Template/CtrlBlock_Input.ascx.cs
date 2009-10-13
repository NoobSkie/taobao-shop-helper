using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Template.Facade;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Template
{
    public partial class CtrlBlock_Input : System.Web.UI.UserControl
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
                switch (value.DataType.ToLower())
                {
                    case "text":
                        ucCtrlInputItem_Text.Visible = true;
                        ucCtrlInputItem_Text.TemplateInfo = value;
                        break;
                    case "imageurl":
                        ucCtrlInputItem_ImageUrl.Visible = true;
                        ucCtrlInputItem_ImageUrl.TemplateInfo = value;
                        break;
                }
            }
        }

        public void SaveCurrentValue()
        {
            switch (TemplateInfo.DataType.ToLower())
            {
                case "text":
                    ucCtrlInputItem_Text.SaveCurrentValue();
                    TemplateInfo = ucCtrlInputItem_Text.TemplateInfo;
                    break;
                case "imageurl":
                    ucCtrlInputItem_ImageUrl.SaveCurrentValue();
                    TemplateInfo = ucCtrlInputItem_ImageUrl.TemplateInfo;
                    break;
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
                    return ucCtrlInputItem_Text.GetInputHTML();
                case "imageurl":
                    return ucCtrlInputItem_ImageUrl.GetInputHTML();
            }
            return string.Empty;
        }
    }
}