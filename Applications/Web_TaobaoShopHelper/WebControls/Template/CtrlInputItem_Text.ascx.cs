using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Template.Facade;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Template
{
    public partial class CtrlInputItem_Text : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public TemplateObject TemplateInfo
        {
            get
            {
                return (TemplateObject)ViewState["CtrlInputItem_Text.TemplateInfo"];
            }
            set
            {
                ViewState["CtrlInputItem_Text.TemplateInfo"] = value;

                Title = value.DisplayName;
                ShowTitle = value.ShowTitle;
                if (!string.IsNullOrEmpty(value.CurrentValue))
                {
                    Content = value.CurrentValue;
                }
                else
                {
                    Content = value.DefaultValue;
                }
                if (value.TitleWidth > 0)
                {
                    TitleWidth = Unit.Parse(value.TitleWidth.ToString() + "px");
                }
                if (value.InputWidth > 0)
                {
                    InputWidth = Unit.Parse(value.InputWidth.ToString() + "px");
                }
            }
        }

        public void SaveCurrentValue()
        {
            TemplateInfo.CurrentValue = txtContent.Text;
        }

        public string Title
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }

        public string Content
        {
            get
            {
                return txtContent.Text;
            }
            set
            {
                txtContent.Text = value;
            }
        }

        public bool ShowTitle
        {
            get
            {
                return lblTitle.Visible;
            }
            set
            {
                lblTitle.Visible = value;
            }
        }

        public Unit TitleWidth
        {
            get
            {
                return lblTitle.Width;
            }
            set
            {
                lblTitle.Width = value;
            }
        }

        public Unit InputWidth
        {
            get
            {
                return txtContent.Width;
            }
            set
            {
                txtContent.Width = value;
            }
        }

        public string GetInputHTML()
        {
            return txtContent.Text;
        }
    }
}