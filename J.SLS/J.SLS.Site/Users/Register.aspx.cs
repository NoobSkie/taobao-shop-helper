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
        if (txtEmail.Text.Trim() == "")
        {
            lblMessage.Text = "请填写您的电子邮箱，用于以后找回密码！";
            return;
        }
        if (txtRealName.Text.Trim() == "")
        {
            lblMessage.Text = "请填写您的真实名称，用于投注和领取奖金！";
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
        if (txtCardNum.Text.Trim() == "")
        {
            lblMessage.Text = "请填写您的证件号码，将用于投注和领取奖金！";
            return;
        }
        if (txtMobile.Text.Trim() == "")
        {
            lblMessage.Text = "请填写您的手机号码，这是无纸化彩票中大奖的凭证之一！";
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
        int cardType = 0;
        if (rbtn1.Checked)
        {
            cardType = 1;
        }
        else if (rbtn2.Checked)
        {
            cardType = 2;
        }
        else if (rbtn3.Checked)
        {
            cardType = 3;
        }
        userInfo.CardType = cardType;
        userInfo.CardNumber = txtCardNum.Text.Trim();
        userInfo.Mobile = txtMobile.Text.Trim();
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
