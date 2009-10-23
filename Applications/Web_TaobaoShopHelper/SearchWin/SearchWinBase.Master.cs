using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TOP.Applications.TaobaoShopHelper.SearchWin
{
    public partial class SearchWinBase : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ctrlId = Request["CtrlId"];
                string type = Request["Type"];
                bool isInTest = false;
                if (!string.IsNullOrEmpty(Request["IsInTest"]))
                {
                    isInTest = bool.Parse(Request["IsInTest"]);
                }
                if (isInTest)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SetInTest", "SetInTest();", true);
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SetCtrlId", "SetCtrlId('" + ctrlId + "');", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SetType", "SetType('" + type + "');", true);
            }
        }
    }
}
