using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Template.Facade;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Template
{
    public partial class CtrlBlock_Container : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public TemplateObject TemplateInfo
        {
            get
            {
                return (TemplateObject)ViewState["CtrlBlock_Container.TemplateInfo"];
            }
            set
            {
                ViewState["CtrlBlock_Container.TemplateInfo"] = value;

                switch (value.Category.ToLower())
                {
                    case "list":
                        ucCtrlBlockItem.Visible = false;
                        ucCtrlBlockList.Visible = true;

                        ucCtrlBlockList.TemplateInfo = value;
                        break;
                    case "item":
                        ucCtrlBlockItem.Visible = true;
                        ucCtrlBlockList.Visible = false;

                        ucCtrlBlockItem.TemplateInfo = value;
                        break;
                    default:
                        ucCtrlBlockItem.Visible = false;
                        ucCtrlBlockList.Visible = false;
                        break;
                }
            }
        }

        public void CreateChild(string defaultValue)
        {
            if (ucCtrlBlockList.Visible)
            {
                ucCtrlBlockList.CreateChild(defaultValue);
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
                case "list":
                    return ucCtrlBlockList.GetInputHTML();
                case "item":
                    return ucCtrlBlockItem.GetInputHTML();
            }
            return string.Empty;
        }
    }
}