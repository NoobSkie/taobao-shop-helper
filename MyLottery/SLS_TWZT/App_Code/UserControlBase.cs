using System;
using System.Web.UI;

public class UserControlBase : UserControl
{
    public Sites _Site;
    public Users _User;
    public string AlipayLoginSrcUrl = "";
    public string AlipayLoginUrl = "";
    public string ForgetPwdUrl = "";
    public string LoginBackSrcUrl = "";
    public string LoginIframeUrl = "";
    public string LoginTopSrcUrl = "";
    public string RegisterUrl = "";

    protected override void OnLoad(EventArgs e)
    {
        this.AlipayLoginSrcUrl = base.ResolveUrl("~/Home/Room/images/zfb_button2.jpg");
        this.LoginTopSrcUrl = base.ResolveUrl("~/Home/Room/images/login_top.jpg");
        this.LoginBackSrcUrl = base.ResolveUrl("~/Home/Room/images/login_back.jpg");
        this.RegisterUrl = base.ResolveUrl("~/UserReg.aspx");
        this.ForgetPwdUrl = base.ResolveUrl("~/Home/Room/ForgetPassword.aspx");
        this.AlipayLoginUrl = base.ResolveUrl("~/Home/Room/Login.aspx");
        this.LoginIframeUrl = base.ResolveUrl("~/Home/Room/UserLoginDialog.aspx");
        this._Site = new Sites()[1L];
        this._User = Users.GetCurrentUser(this._Site.ID);
        base.OnLoad(e);
    }
}

