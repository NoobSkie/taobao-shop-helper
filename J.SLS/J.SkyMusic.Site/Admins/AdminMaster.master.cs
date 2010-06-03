using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Admins_AdminMaster : BaseMaster
{
    protected string CheckOpenerScript = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bool autoCheckParent;
            if (bool.TryParse(ConfigurationManager.AppSettings["AutoCheckParent"], out autoCheckParent) && autoCheckParent)
            {
                CheckOpenerScript = "CheckOpener();";
            }
        }
    }
}
