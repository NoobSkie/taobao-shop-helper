using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Taobao.Top.Api;
using TOP.Authorize.Facade;
using TOP.Applications.TaobaoShopHelper.WebControls.Common;

namespace TOP.Applications.TaobaoShopHelper._Common
{
    public class BasePage : Page
    {
        private ConstVariables varHelper = new ConstVariables();

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            LastAsseccPageUrl = Request.Url.AbsolutePath;
        }

        public InformationObject GetUnLoginInformation()
        {
            InformationObject obj = new InformationObject();
            obj.CssName = "Information";
            obj.Message = "您目前没有登录系统，或者登录已经过期。";
            obj.AddLink("点击这里登录系统", "~/Authorizes/UnLogin.aspx?ReturnUrl=" + Server.UrlEncode(Request.Url.AbsolutePath));
            return obj;
        }

        public InformationObject GetUnAuthorizeInformation()
        {
            InformationObject obj = new InformationObject();
            obj.CssName = "Information";
            obj.Message = "我们没有接收到您对我们网站的淘宝网操作授权，或者授权码已经过期。";
            obj.AddLink("点击这里获取淘宝授权", "~/Authorizes/UnAuthorize.aspx?ReturnUrl=" + Server.UrlEncode(Request.Url.AbsolutePath));
            string a = "<img src='" + GetRootURI() + "/Images/Icos/contacts.gif' title='什么是淘宝网授权码' />";
            obj.AddLink(a, "~/Authorizes/UnLogin.aspx");
            return obj;
        }

        public void SetSuccessInformation(string message)
        {
            List<InformationObject> list = new List<InformationObject>();
            InformationObject obj = new InformationObject();
            obj.CssName = "Information";
            obj.Message = message;
            list.Add(obj);
            DisplayInformations(list, InformationIcoType.Information);
        }

        public void DisplayInformations(params InformationObject[] infoList)
        {
            List<InformationObject> list = new List<InformationObject>(infoList);
            DisplayInformations(list, InformationIcoType.Default);
        }

        public void DisplayInformations(List<InformationObject> infoList)
        {
            DisplayInformations(infoList, InformationIcoType.Default);
        }

        public void DisplayInformations(List<InformationObject> infoList, InformationIcoType icoType)
        {
            IInformationPage master = GetInformationMaster();
            if (master != null)
            {
                master.SetInformationBoxVisible(true);
                master.SetInformation(infoList);
                master.SetInformationIco(icoType);
            }
        }

        private IInformationPage GetInformationMaster()
        {
            MasterPage master = this.Master;
            while (master != null)
            {
                if (master is IInformationPage)
                {
                    return master as IInformationPage;
                }
                else
                {
                    master = master.Master;
                }
            }
            return null;
        }

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
