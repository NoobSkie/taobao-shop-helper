using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;

public partial class Admins_AdminLogin : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ParamInfo param = DataCache.GetParam(this.Page, "AdministratorPassword");
            //ParamFacade facade = new ParamFacade();
            //ParamInfo param = facade.GetParam("AdministratorPassword");
            if (param == null || string.IsNullOrEmpty(param.Value))
            {
                string msg = "管理员密码尚未设置，请先设置管理员密码。";
                string url = this.ResolveUrl("AdminChangePassword.aspx?ReturnUrl=AdminLogin.aspx");
                JavascriptAlertAndRedirect(msg, url);
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //string password = EncryptTool.MD5(txtPassword.Text);
        //ParamFacade facade = new ParamFacade();
        //ParamInfo param = facade.GetParam("AdministratorPassword");
        //if (param != null && param.Value == password)
        //{
        //    IsAdminLogined = true;
        //    string url = "Default.aspx";
        //    if (!string.IsNullOrEmpty(Request["ReturnUrl"]))
        //    {
        //        url = Request["ReturnUrl"];
        //    }
        //    RedirectToUrl(url);
        //}
        //else
        //{
        //    lblMessage.Text = "密码错误！";
        //}
    }
}
