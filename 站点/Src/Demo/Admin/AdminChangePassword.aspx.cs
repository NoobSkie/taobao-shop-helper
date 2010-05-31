using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;
using J.SLS.Common;

public partial class Admin_AdminChangePassword : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ParamFacade facade = new ParamFacade();
            ParamInfo param = facade.GetParam("AdministratorPassword");
            if (param == null || string.IsNullOrEmpty(param.Value))
            {
                txtOldPassword.Enabled = false;
                lblMessage.Text = "管理员密码尚未设置，请直接输入新密码。";
            }
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        ParamFacade facade = new ParamFacade();
        ParamInfo param = facade.GetParam("AdministratorPassword");
        string oldPassword = EncryptTool.MD5(txtOldPassword.Text);
        string newPassword = EncryptTool.MD5(txtNewPassword.Text);
        string confirmPassword = EncryptTool.MD5(txtConfirmPassword.Text);
        if (newPassword != confirmPassword)
        {
            lblMessage.Text = "两次输入的密码不相同。";
            return;
        }
        if (param == null || string.IsNullOrEmpty(param.Value) || param.Value == oldPassword)
        {
            param = new ParamInfo();
            param.Key = "AdministratorPassword";
            param.Value = newPassword;
            facade.SaveParam(param);

            string url = "Default.aspx";
            if (!string.IsNullOrEmpty(Request["ReturnUrl"]))
            {
                url = Request["ReturnUrl"];
            }
            string msg = "修改密码成功！";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "AlertChangePassword", "AlertAndRedirect('" + msg + "', '" + url + "');", true);
        }
        else
        {
            lblMessage.Text = "旧密码输入不正确。";
            return;
        }
    }
}
