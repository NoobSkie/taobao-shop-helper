using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Taobao.Top.Api;

namespace TOP.Applications.TaobaoShopHelper._Common
{
    public class BasePage : Page
    {
        private ConstVariables varHelper = new ConstVariables();

        public string TOP_SessionKey
        {
            get
            {
                if (Session["TOP_SessionKey"] == null)
                {
                    LastAsseccPageUrl = Request.Url.AbsolutePath;
                    // "~/Authorizes/UnAuthorize.aspx"
                    Response.Redirect(AppUrlHelper.Url_UnAuthorize, true);
                }
                return (string)Session["TOP_SessionKey"];
            }
            set
            {
                Session["TOP_SessionKey"] = value;
            }
        }

        public string CurrentUserId
        {
            get
            {
                if (Session["CurrentUserId"] == null)
                {
                    LastAsseccPageUrl = Request.Url.AbsolutePath;
                    // "~/Authorizes/UnLogin.aspx"
                    Response.Redirect(AppUrlHelper.Url_UnLogin, true);
                }
                return (string)Session["CurrentUserId"];
            }
            set
            {
                Session["CurrentUserId"] = value;
            }
        }

        public string CurrentUserName
        {
            get
            {
                if (Session["CurrentUserName"] == null)
                {
                    return string.Empty;
                }
                return (string)Session["CurrentUserName"];
            }
            set
            {
                Session["CurrentUserName"] = value;
            }
        }

        public string CurrentLoginName
        {
            get
            {
                if (Session["CurrentLoginName"] == null)
                {
                    return string.Empty;
                }
                return (string)Session["CurrentLoginName"];
            }
            set
            {
                Session["CurrentLoginName"] = value;
            }
        }

        public string LastAsseccPageUrl
        {
            get
            {
                if (Session["LastAsseccPageUrl"] == null)
                {
                    return string.Empty;
                }
                return (string)Session["LastAsseccPageUrl"];
            }
            set
            {
                Session["LastAsseccPageUrl"] = value;
            }
        }

        public ITopClient GetProductTopClient()
        {
            return new TopRestClient("http://gw.api.taobao.com/router/rest", varHelper.TOP_AppKey, varHelper.TOP_AppSecret, "json");
        }

        public string Encode(string content)
        {
            return content;
        }

        public string Decode(string content)
        {
            return content;
        }
    }
}
