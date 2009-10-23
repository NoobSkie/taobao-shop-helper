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
    public partial class CtrlTemplateEditor : TemplateEditCtrlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !string.IsNullOrEmpty(TemplateHtml))
            {
                List<TemplateObject> templateList = TemplateAnalyser.AnalyseTemplateList(TemplateHtml);
                rptBlocks.DataSource = templateList;
                rptBlocks.DataBind();

                foreach (TemplateSetItem flow in CurrentTemplateSetFlow.CurrentFlow)
                {
                    foreach (RepeaterItem row in rptBlocks.Items)
                    {
                        CtrlBlock_Container container = (CtrlBlock_Container)row.FindControl("ucCtrlBlockContainer");
                        if (container.TemplateInfo.Id == flow.ContainerId)
                        {
                            container.CreateChild(flow.Value);
                        }
                    }
                }
            }
        }

        public string TemplateHtml
        {
            get
            {
                return (string)ViewState["CtrlTemplateEditor.TemplateHtml"];
            }
            set
            {
                ViewState["CtrlTemplateEditor.TemplateHtml"] = value;
            }
        }

        public string GetHtml()
        {
            string html = TemplateHtml;
            foreach (RepeaterItem item in rptBlocks.Items)
            {
                CtrlBlock_Container block = (CtrlBlock_Container)item.FindControl("ucCtrlBlockContainer");
                string outerHtml = block.GetOuterHTML();
                string itemHtml = block.GetInputHTML();
                html = html.Replace(outerHtml, itemHtml);
            }
            return html;
        }
    }
}