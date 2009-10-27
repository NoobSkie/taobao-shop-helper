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

                if (CurrentTemplateSetFlow != null)
                {
                    foreach (TemplateSetItem flow in CurrentTemplateSetFlow.CurrentFlowList)
                    {
                        foreach (RepeaterItem row in rptBlocks.Items)
                        {
                            CtrlBlock_Container container = (CtrlBlock_Container)row.FindControl("ucCtrlBlockContainer");
                            if (container.TemplateId == flow.ContainerId)
                            {
                                container.CreateChild(flow);
                            }
                        }
                    }
                }
            }
        }

        public string GetHtml()
        {
            string html = TemplateHtml;
            List<TemplateObject> templateList = TemplateAnalyser.AnalyseTemplateList(html);
            if (CurrentTemplateSetFlow != null)
            {
                foreach (TemplateObject obj in templateList)
                {
                    string oldText = obj.OuterHTML;
                    string newText = string.Empty;
                    foreach (TemplateSetItem flow in CurrentTemplateSetFlow.CurrentFlowList)
                    {
                        if (obj.Id == flow.ContainerId)
                        {
                            newText += GetItemHtmlByFlow(flow, obj);
                        }
                    }
                    html = html.Replace(oldText, newText);
                }
            }
            return html;
        }

        private string GetItemHtmlByFlow(TemplateSetItem flow, TemplateObject obj)
        {
            string html = flow.Template.InnerHTML;
            if (obj.Category.Equals("List", StringComparison.OrdinalIgnoreCase))
            {
                TemplateObject item = obj.Children[0];
                if (item.Children != null && item.Children.Count > 0 && item.Children.Count == flow.ChildrenCount)
                {
                    for (int i = 0; i < item.Children.Count; i++)
                    {
                        TemplateObject sub = item.Children[i];
                        string oldText = sub.OuterHTML;
                        if (sub.NoUse)
                        {
                            html = html.Replace(oldText, "");
                        }
                        else
                        {
                            int index;
                            if (int.TryParse(sub.DataSource, out index))
                            {
                                string newText = flow.Value.Split(',')[index];
                                html = html.Replace(oldText, newText);
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            return html;
        }

        public string TemplateHtml
        {
            get
            {
                if (ViewState["CtrlTemplateEditor.TemplateHtml"] == null)
                {
                    if (!string.IsNullOrEmpty(ItemIid))
                    {
                        TemplateFacade facade = new TemplateFacade();
                        TemplateContentInfo content = facade.GetTemplateContentById(ItemIid);
                        if (content != null)
                        {
                            ViewState["CtrlTemplateEditor.TemplateHtml"] = content.Content;
                        }
                    }
                }
                return (string)ViewState["CtrlTemplateEditor.TemplateHtml"];
            }
            set
            {
                ViewState["CtrlTemplateEditor.TemplateHtml"] = value;
            }
        }
    }
}