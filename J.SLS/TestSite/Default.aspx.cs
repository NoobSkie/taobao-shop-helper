using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(this.GetType(), this);
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string TestMethod(string a, string b)
    {
        return a + " and " + b;
    }
}
