using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Taobao.Top.Api;
using TOP.Authorize.Facade;

namespace TOP.Applications.TaobaoShopHelper._Common
{
    public class BaseMaster : MasterPage
    {
        private ConstVariables varHelper = new ConstVariables();

        public string GetRootURI()
        {
            string UrlAuthority = Request.Url.GetLeftPart(UriPartial.Authority);
            if (Request.ApplicationPath == null || Request.ApplicationPath == "/")
            {
                //直接安装在Web站点
                return UrlAuthority;
            }
            else
            {
                //安装在虚拟子目录下
                return UrlAuthority + Request.ApplicationPath;
            }
        }

        public string TOP_SessionKey
        {
            get
            {
                return (string)Session["Global.TOP_SessionKey"];
            }
            set
            {
                Session["Global.TOP_SessionKey"] = value;
            }
        }

        public string SellerNick
        {
            get
            {
                if (Session["Seller.Nick"] == null)
                {
                    // TODO:
                    Session["Seller.Nick"] = "zhongjy001";
                }
                return (string)Session["Seller.Nick"];
            }
            set
            {
                Session["Seller.Nick"] = value;
            }
        }

        public UserInfo CurrentUser
        {
            get
            {
                return (UserInfo)Session["Global.CurrentUser"];
            }
            set
            {
                Session["Global.CurrentUser"] = value;
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
