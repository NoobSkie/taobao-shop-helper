using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestPage1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(TestPage1));
    }

    [AjaxPro.AjaxMethod]
    public string TestMethod(string a, string b)
    {
        return a + " and " + b;
    }
}
