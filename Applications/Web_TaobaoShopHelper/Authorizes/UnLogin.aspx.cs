using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Authorize.Facade;
using TOP.Common.EncryptionTool;
using TOP.Applications.TaobaoShopHelper._Common;

namespace TOP.Applications.TaobaoShopHelper.Authorizes
{
    public partial class UnLogin : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["Logout"]))
                {
                    bool logout = bool.Parse(Request["Logout"]);
                    if (logout)
                    {
                        CurrentUser = null;
                    }
                }
            }
        }

        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            string loginName = txtUserName.Text;
            string password = Encryption_Md5.Encryption(txtPassword.Text);
            UserFacade facade = new UserFacade();
            UserInfo currentUser = facade.Login(loginName, password);
            if (currentUser == null)
            {
                lblMessage.Text = "登录名或密码错误。";
            }
            else
            {
                CurrentUser = currentUser;
                string returnUrl = "~/Default.aspx";
                if (!string.IsNullOrEmpty(Request["ReturnUrl"]))
                {
                    returnUrl = Request["ReturnUrl"];
                }
                Response.Redirect(returnUrl);
            }
        }
    }
}
