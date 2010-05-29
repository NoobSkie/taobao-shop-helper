using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_Logout : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CurrentUser = null;
        string returnUrl = "~/Default.aspx";
        if (!string.IsNullOrEmpty(Request["ReturnUrl"]))
        {
            returnUrl = Request["ReturnUrl"];
        }
        RedirectToUrl(returnUrl);
    }
}
