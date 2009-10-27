using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using TOP.Applications.TaobaoShopHelper._Common;
using System.Text.RegularExpressions;

namespace TOP.Applications.TaobaoShopHelper.Authorizes
{
    public partial class UnAuthorize : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitUrls();
            }
        }

        private void InitUrls()
        {
            hlnkGetAppKey.NavigateUrl = string.Format(ContainerAuthKey, AppKey);
        }

        protected void lbtnGetSessionKey_Click(object sender, EventArgs e)
        {
            string authCode = txtAuthCode.Text;
            if (CheckAuthKey(authCode))
            {
                string url = string.Format(ContainerSessionKey, authCode);
                if (!string.IsNullOrEmpty(Request.Url.Query))
                {
                    url += "&" + Request.Url.Query.TrimStart('?');
                }
                Response.Redirect(url, true);
            }
            else
            {
                Response.Write("授权码格式不正确，请重新填写。");
            }
        }

        private bool CheckAuthKey(string authCode)
        {
            // 格式例如：
            // TOP-105c5df3862962d8b2641f2949bbcec48eNwKLU2QxGUfVqD8O9ZprIzQ9wntUei-END
            string reg = @"^TOP-[\w]+-END$";
            Regex regex = new Regex(reg, RegexOptions.IgnoreCase);
            return regex.Match(authCode).Success;
        }
    }
}
