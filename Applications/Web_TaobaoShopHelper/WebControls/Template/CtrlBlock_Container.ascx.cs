using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Template.Facade;
using TOP.Applications.TaobaoShopHelper.Templates;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Template
{
    public partial class CtrlBlock_Container : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string TemplateId
        {
            get
            {
                return (string)ViewState["CtrlBlock_Container.Template.Id"];
            }
            set
            {
                ViewState["CtrlBlock_Container.Template.Id"] = value;
            }
        }

        public TemplateObject TemplateInfo
        {
            set
            {
                TemplateId = value.Id;

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

        public void CreateChild(TemplateSetItem flow)
        {
            if (ucCtrlBlockList.Visible)
            {
                ucCtrlBlockList.AddTemplateItem(flow);
            }
        }
    }
}