using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;

public partial class Masters_MainMasterPage : BaseMaster
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
}
