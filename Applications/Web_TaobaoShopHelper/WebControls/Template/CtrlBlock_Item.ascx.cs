using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Template.Facade;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Template
{
    public partial class CtrlBlock_Item : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public TemplateInfo TemplateInfo
        {
            get
            {
                return (TemplateInfo)ViewState["CtrlBlock_Item.TemplateInfo"];
            }
            set
            {
                ViewState["CtrlBlock_Item.TemplateInfo"] = value;

                SortChildren(value);
                if (value.ShowTitle)
                {
                    this.lblHeader.Text = value.DisplayName;
                }
                if (!string.IsNullOrEmpty(TemplateInfo.DefaultValue))
                {
                    if (!string.IsNullOrEmpty(value.DataType) && value.DataType.Equals("display", StringComparison.OrdinalIgnoreCase))
                    {
                        for (int i = 0; i < value.Children.Count; i++)
                        {
                            value.Children[i].DefaultValue = TemplateInfo.DefaultValue;
                        }
                    }
                    else
                    {
                        string[] values = TemplateInfo.DefaultValue.Split('#');
                        if (values.Length == value.Children.Count)
                        {
                            for (int i = 0; i < values.Length; i++)
                            {
                                value.Children[i].DefaultValue = values[i];
                            }
                        }
                    }
                }                
                this.rtpInputItems.DataSource = value.Children;
                this.rtpInputItems.DataBind();
            }
        }

        private void SortChildren(TemplateInfo value)
        {
            value.Children.Sort(new TemplateComparer());
        }

        public void SaveCurrentValue()
        {
            for (int i = 0; i < rtpInputItems.Items.Count; i++)
            {
                RepeaterItem item = rtpInputItems.Items[i];

                CtrlBlock_Unit input = (CtrlBlock_Unit)item.FindControl("ucCtrlBlockUnit");
                input.SaveCurrentValue();
                TemplateInfo.Children[i] = input.TemplateInfo;
            }
        }

        public string GetOuterHTML()
        {
            return TemplateInfo.OuterHTML;
        }

        public string GetInputHTML()
        {
            string html = TemplateInfo.InnerHTML;
            foreach (RepeaterItem item in rtpInputItems.Items)
            {
                CtrlBlock_Unit input = (CtrlBlock_Unit)item.FindControl("ucCtrlBlockUnit");
                string outerHtml = input.GetOuterHTML();
                string itemHtml = input.GetInputHTML();
                html = html.Replace(outerHtml, itemHtml);
            }
            return html;
        }
    }
}