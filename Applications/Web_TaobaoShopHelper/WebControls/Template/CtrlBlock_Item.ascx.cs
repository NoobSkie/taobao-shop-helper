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
    public partial class CtrlBlock_Item : TemplateEditCtrlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public TemplateSetItem TemplateFlow
        {
            get
            {
                return (TemplateSetItem)ViewState["CtrlBlock_Item."+ClientID+".TemplateFlow"];
            }
            set
            {
                ViewState["CtrlBlock_Item." + ClientID + ".TemplateFlow"] = value;

                TemplateInfo = value.Template;
            }
        }

        public TemplateObject TemplateInfo
        {
            set
            {
                SortChildren(value);
                if (value.ShowTitle)
                {
                    this.lblHeader.Text = value.DisplayName;
                }
                if (!string.IsNullOrEmpty(value.DefaultValue))
                {
                    if (!string.IsNullOrEmpty(value.DataType) && value.DataType.Equals("display", StringComparison.OrdinalIgnoreCase))
                    {
                        for (int i = 0; i < value.Children.Count; i++)
                        {
                            value.Children[i].DefaultValue = value.DefaultValue;
                        }
                    }
                    else
                    {
                        string[] values = value.DefaultValue.Split('#');
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

        private void SortChildren(TemplateObject value)
        {
            value.Children.Sort(new TemplateComparer());
        }

        protected void lbtnMoveUp_Click(object sender, EventArgs e)
        {
            this.CurrentTemplateSetFlow.MoveUp(TemplateFlow);
            Response.Redirect(Request.Url.AbsolutePath);
        }

        protected void lbtnMoveDown_Click(object sender, EventArgs e)
        {
            this.CurrentTemplateSetFlow.MoveDown(TemplateFlow);
            Response.Redirect(Request.Url.AbsolutePath);
        }

        protected void lbtnRemove_Click(object sender, EventArgs e)
        {
            this.CurrentTemplateSetFlow.Remove(TemplateFlow);
            Response.Redirect(Request.Url.AbsolutePath);
        }
    }
}