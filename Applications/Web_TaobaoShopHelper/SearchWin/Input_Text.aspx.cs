using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TOP.Applications.TaobaoShopHelper.SearchWin
{
    public partial class Input_Text : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ctrlId = Request["CtrlId"];
                string type = Request["Type"];
                string title = Request["Title"];
                string info = Request["Info"];
                string demo = Request["Demo"];

                if (!string.IsNullOrEmpty(title))
                {
                    lblTitle.Text = title;
                }
                if (!string.IsNullOrEmpty(info))
                {
                    lblInfo.Text = info;
                }
                else
                {
                    lblInfo.Visible = false;
                }
            }
        }
    }
}
