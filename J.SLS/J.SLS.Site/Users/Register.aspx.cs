using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SLS.Facade;

public partial class Users_Register : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (txtUserId.Text.Trim() == "")
        {
            lblMessage.Text = "请填写您的用户名，用于以后登录系统！";
            return;
        }
        if (txtRealName.Text.Trim() == "")
        {
            lblMessage.Text = "请填写您的真实名称！";
            return;
        }
        if (txtPassword.Text.Trim() == "")
        {
            lblMessage.Text = "请填写您的登录密码！";
            return;
        }
        if (txtConfirmPassword.Text.Trim() == "")
        {
            lblMessage.Text = "请再一次填写您的登录密码！";
            return;
        }
        if (txtPassword.Text != txtConfirmPassword.Text)
        {
            lblMessage.Text = "两次输入的密码不一样！";
            return;
        }
        UserFacade facade = new UserFacade();
        if (!facade.CheckUserIdCanRegister(txtUserId.Text.Trim()))
        {
            lblMessage.Text = "此用户名已被注册，请重新填写！";
            return;
        }

        UserInfo userInfo = new UserInfo();
        userInfo.UserId = txtUserId.Text.Trim();
        userInfo.UserName = txtRealName.Text.Trim();
        userInfo.RealName = txtRealName.Text.Trim();
        userInfo.Email = txtEmail.Text;
        try
        {
            facade.Register(userInfo, txtPassword.Text);
            SetCurrentUser(txtUserId.Text.Trim());
            RedirectToDefault();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;
        }
    }
}
