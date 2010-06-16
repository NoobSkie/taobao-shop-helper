using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SLS.Facade;
using Shove._Web;
using J.SLS.Common.Exceptions;
using System.Web.Security;

public partial class Users_Login : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["Message"]))
        {
            lblMessage.Text = Request["Message"];
        }
        else
        {
            lblMessage.Visible = false;
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string userId = txtUserId.Text.Trim();
        string password = txtPassword.Text;
        try
        {
            UserFacade facade = new UserFacade();
            UserInfo user = facade.Login(userId, password);
            if (user == null)
            {
                throw new LoginException("登录失败 - 未知原因");
            }
            CurrentUser = user;
            lblMessage.Visible = false;
            if (!string.IsNullOrEmpty(Request["ReturnUrl"]))
            {
                RedirectToUrl(Request["ReturnUrl"]);
            }
            else
            {
                RedirectToDefault();
            }
        }
        catch (Exception ex)
        {
            CurrentUser = null;
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;
        }
    }
}
