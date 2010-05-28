using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Components_WebControls_UserDisplayArea : BaseControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (CurrentUser == null)
        {
            UserLoginCtrl1.Visible = true;
            UserInfoCtrl1.Visible = false;
        }
        else
        {
            UserLoginCtrl1.Visible = false;
            UserInfoCtrl1.Visible = true;
        }
    }
}
