using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Template
{
    public partial class CtrlInputItem_Text : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        public bool IsInline { get; set; }

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
    }
}