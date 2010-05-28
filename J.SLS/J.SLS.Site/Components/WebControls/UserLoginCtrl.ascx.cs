using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shove._Web;
using J.SLS.Common.Exceptions;
using J.SLS.Facade;

public partial class Components_WebControls_UserLoginCtrl : BaseControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string userId = txtUserId.Text.Trim();
        string password = txtPassword.Text;
        try
        {
            UserFacade facade = new UserFacade();
            LoginInfo user = facade.Login(userId, password);
            if (user == null)
            {
                throw new LoginException("登录失败 - 未知原因");
            }
            CurrentUser = user;
        }
        catch (Exception ex)
        {
            CurrentUser = null;
            RedirectToLogin(Page, ex.Message);
        }
    }
}
