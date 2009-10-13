using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Template.Facade;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Template
{
    public partial class CtrlBlock_List : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private List<TemplateInfo> currentDataSource
        {
            get
            {
                return (List<TemplateInfo>)ViewState["CtrlBlock_List.currentDataSource"];
            }
            set
            {
                ViewState["CtrlBlock_List.currentDataSource"] = value;
            }
        }

        private TemplateInfo currentModule
        {
            get
            {
                return (TemplateInfo)ViewState["CtrlBlock_List.currentModule"];
            }
            set
            {
                ViewState["CtrlBlock_List.currentModule"] = value;
            }
        }

        public TemplateInfo TemplateInfo
        {
            get
            {
                return (TemplateInfo)ViewState["CtrlBlock_List.TemplateInfo"];
            }
            set
            {
                ViewState["CtrlBlock_List.TemplateInfo"] = value;

                if (value.ShowTitle)
                {
                    this.lblHeader.Text = value.DisplayName;
                }
                if (value.Children.Count > 0)
                {
                    currentModule = value.Children[0];
                }
                currentDataSource = new List<TemplateInfo>();
                if (string.IsNullOrEmpty(TemplateInfo.DefaultValue))
                {
                    CreateChild(string.Empty);
                }
                else
                {
                    string[] values = TemplateInfo.DefaultValue.Split(',');
                    foreach (string v in values)
                    {
                        CreateChild(v);
                    }
                }
            }
        }

        protected void lbtnAddNew_Click(object sender, EventArgs e)
        {
            SaveCurrentValue();
            CreateChild(string.Empty);
        }

        private void SaveCurrentValue()
        {
            for (int i = 0; i < rtpBlockItems.Items.Count; i++)
            {
                RepeaterItem item = rtpBlockItems.Items[i];

                CtrlBlock_Item block = (CtrlBlock_Item)item.FindControl("ucCtrlBlockItem");
                block.SaveCurrentValue();
                currentDataSource[i] = block.TemplateInfo;
            }
        }

        private void CreateChild(string defaultValue)
        {
            if (currentModule != null)
            {
                TemplateInfo clone = currentModule.Clone();
                clone.DefaultValue = defaultValue;
                currentDataSource.Add(clone);
                this.rtpBlockItems.DataSource = currentDataSource;
                this.rtpBlockItems.DataBind();
            }
        }

        public string GetOuterHTML()
        {
            return TemplateInfo.OuterHTML;
        }

        public string GetInputHTML()
        {
            string html = TemplateInfo.InnerHTML;
            string newHtml = string.Empty;
            foreach (RepeaterItem item in rtpBlockItems.Items)
            {
                CtrlBlock_Item block = (CtrlBlock_Item)item.FindControl("ucCtrlBlockItem");
                string itemHtml = html.Replace(currentModule.OuterHTML, block.GetInputHTML());
                newHtml += itemHtml;
            }
            return TemplateInfo.OuterHTML.Replace(TemplateInfo.OuterHTML, newHtml);
        }
    }
}