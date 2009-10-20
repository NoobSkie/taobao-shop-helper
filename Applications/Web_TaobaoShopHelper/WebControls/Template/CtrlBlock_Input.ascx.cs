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

        public TemplateObject TemplateInfo
        {
            get
            {
                return (TemplateObject)ViewState["CtrlBlock_Input.TemplateInfo"];
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
                        ucCtrlInputItemText.Visible = true;
                        ucCtrlInputItemText.TemplateInfo = value;
                        break;
                    case "imageurl":
                        ucCtrlInputItemImageUrl.Visible = true;
                        ucCtrlInputItemImageUrl.TemplateInfo = value;
                        break;
                }
            }
        }

        public void SaveCurrentValue()
        {
            switch (TemplateInfo.DataType.ToLower())
            {
                case "text":
                    ucCtrlInputItemText.SaveCurrentValue();
                    TemplateInfo = ucCtrlInputItemText.TemplateInfo;
                    break;
                case "imageurl":
                    ucCtrlInputItemImageUrl.SaveCurrentValue();
                    TemplateInfo = ucCtrlInputItemImageUrl.TemplateInfo;
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
                    return ucCtrlInputItemText.GetInputHTML();
                case "imageurl":
                    return ucCtrlInputItemImageUrl.GetInputHTML();
            }
            return string.Empty;
        }
    }
}