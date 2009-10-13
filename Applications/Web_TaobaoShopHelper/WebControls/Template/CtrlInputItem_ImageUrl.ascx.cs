using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Template.Facade;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Template
{
    public partial class CtrlInputItem_ImageUrl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DisplayImagePreview_Script", "function DisplayImagePreview(imgId, objId) {document.getElementById(imgId).src = document.getElementById(objId).value;}", true);
            txtContent.Attributes["onchange"] = "DisplayImagePreview('" + imgPreview.ClientID + "', '" + txtContent.ClientID + "');";
            // imgPreview.Attributes["onerror"] = "javascript:this.src = '/TaobaoShopHelper/Images/Icos/warning.png';";
        }

        public TemplateInfo TemplateInfo
        {
            get
            {
                return (TemplateInfo)ViewState["CtrlInputItem_ImageUrl.TemplateInfo"];
            }
            set
            {
                ViewState["CtrlInputItem_ImageUrl.TemplateInfo"] = value;

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
                imgPreview.ImageUrl = value;
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