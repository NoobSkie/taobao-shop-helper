using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Components_WebControls_CtrlInnerLogin : BaseControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HyperLink1.NavigateUrl = string.Format("~/Users/Login.aspx?ReturnUrl={0}", Request.Url.AbsolutePath);
        }
    }
}
