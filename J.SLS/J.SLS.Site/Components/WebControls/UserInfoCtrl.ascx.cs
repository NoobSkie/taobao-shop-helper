using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shove._Web;
using J.SLS.Common.Exceptions;
using J.SLS.Facade;

public partial class Components_WebControls_UserInfoCtrl : BaseControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (CurrentUser != null)
        {
            lblUserName.Text = CurrentUser.UserName;
        }
    }
}
