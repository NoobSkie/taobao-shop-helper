using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;
using J.SLS.Common;

public partial class Admin_AdminLogin : BaseAdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ParamFacade facade = new ParamFacade();
            if (facade.GetParam("AdministratorPassword") == null)
            {

            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string password = EncryptTool.MD5(txtPassword.Text);
        ParamFacade facade = new ParamFacade();
        facade.GetParam("AdministratorPassword");
    }
}
