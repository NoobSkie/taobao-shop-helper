using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOP.Applications.TaobaoShopHelper._Common;
using TOP.Applications.TaobaoShopHelper.Templates;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Template
{
    public class TemplateEditCtrlBase : BaseControl
    {
        public string ItemIid
        {
            get
            {
                return (string)ViewState["CtrlTemplateEditor.ItemIid"];
            }
            set
            {
                ViewState["CtrlTemplateEditor.ItemIid"] = value;
            }
        }

        public TemplateSetFlow CurrentTemplateSetFlow
        {
            get
            {
                if (Session["CtrlTemplateEditor." + this.ItemIid + ".CurrentTemplateSetFlow"] == null)
                {
                    Session["CtrlTemplateEditor." + this.ItemIid + ".CurrentTemplateSetFlow"] = new TemplateSetFlow();
                }
                return (TemplateSetFlow)Session["CtrlTemplateEditor." + this.ItemIid + ".CurrentTemplateSetFlow"];
            }
            set
            {
                Session["CtrlTemplateEditor." + this.ItemIid + ".CurrentTemplateSetFlow"] = value;
            }
        }
    }
}
