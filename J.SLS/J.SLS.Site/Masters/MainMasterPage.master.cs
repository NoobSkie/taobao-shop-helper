using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using Shove.Web.UI;
using System.Threading;
using J.SLS.Facade;

public partial class Masters_MainMasterPage : BaseMaster
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Masters_MainMasterPage));
        if (IsPostBack && HidUserID.Value != "" && CurrentUser == null)
        {
            SetCurrentUser(HidUserID.Value);
        }
    }

    public string AlipayLoginSrcUrl { get { return base.ResolveUrl("~/Images/zfb_button2.jpg"); } }
    public string LoginTopSrcUrl { get { return base.ResolveUrl("~/Images/login_top.jpg"); } }
    public string LoginBackSrcUrl { get { return base.ResolveUrl("~/Images/login_back.jpg"); } }
    public string RegisterUrl { get { return base.ResolveUrl("~/UserReg.aspx"); } }
    public string ForgetPwdUrl { get { return base.ResolveUrl("~/Home/Room/ForgetPassword.aspx"); } }
    public string AlipayLoginUrl { get { return base.ResolveUrl("~/Home/Room/Login.aspx"); } }
    public string LoginIframeUrl { get { return base.ResolveUrl("~/Users/ValidateCode.aspx?Type=4"); } }

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public void SetLoginedUserId(string userId)
    {
        SetCurrentUser(userId);
    }

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public string Login(string UserName, string Password, string InputCheckCode, string CheckCode)
    {
        if ((UserName == "") || (Password == ""))
        {
            return "用户名和密码都不能为空";
        }
        ShoveCheckCode code = new ShoveCheckCode();
        if (!code.Valid(InputCheckCode, CheckCode))
        {
            return "验证码输入错误";
        }
        Thread.Sleep(500);
        try
        {
            UserFacade facade = new UserFacade();
            UserInfo user = facade.Login(UserName, Password);
            if (user == null)
            {
                return "登录失败 - 未知原因";
            }
            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
