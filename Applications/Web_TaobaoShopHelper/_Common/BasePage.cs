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
    public abstract class BasePage : Page
    {
        private PageObject pageHelper = new PageObject();

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            LastAsseccPageUrl = Request.Url.AbsoluteUri;
        }

        public InformationObject GetUnLoginInformation()
        {
            InformationObject obj = new InformationObject();
            obj.CssName = "Information";
            obj.Message = "您目前没有登录系统，或者登录已经过期。";
            obj.AddLink("点击这里登录系统", "~/Authorizes/UnLogin.aspx?ReturnUrl=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            return obj;
        }

        public InformationObject GetUnAuthorizeInformation()
        {
            InformationObject obj = new InformationObject();
            obj.CssName = "Information";
            obj.Message = "我们没有接收到您对我们网站的淘宝网操作授权，或者授权码已经过期。";
            obj.AddLink("点击这里获取淘宝授权", "~/Authorizes/UnAuthorize.aspx?ReturnUrl=" + Server.UrlEncode(Request.Url.AbsoluteUri));
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

        #region 页面Url处理

        public string GetRootURI()
        {
            return pageHelper.GetRootURI(Request);
        }

        public Dictionary<string, string> GetParameterListByQuery()
        {
            return pageHelper.GetParameterListByQuery(Request);
        }

        public string GetQueryByParameterList(Dictionary<string, string> parameters)
        {
            return pageHelper.GetQueryByParameterList(parameters, Server);
        }

        #endregion

        #region 全局Session操作

        public string CurrentSessionKey
        {
            get
            {
                return pageHelper.GetSessionValue<string>("Global.CurrentSessionKey", Session);
            }
            set
            {
                pageHelper.SetSessionValue<string>("Global.CurrentSessionKey", value, Session);
            }
        }

        public string CurrentSellerNick
        {
            get
            {
                return pageHelper.GetSessionValue<string>("Global.CurrentSellerNick", Session);
            }
            set
            {
                pageHelper.SetSessionValue<string>("Global.CurrentSellerNick", value, Session);
            }
        }

        public UserInfo CurrentUser
        {
            get
            {
                return pageHelper.GetSessionValue<UserInfo>("Global.CurrentUser", Session);
            }
            set
            {
                pageHelper.SetSessionValue<UserInfo>("Global.CurrentUser", value, Session);
            }
        }

        public string LastAsseccPageUrl
        {
            get
            {
                return pageHelper.GetSessionValue<string>("Global.LastAsseccPageUrl", Session);
            }
            set
            {
                pageHelper.SetSessionValue<string>("Global.LastAsseccPageUrl", value, Session);
            }
        }

        #endregion

        #region Top相关全局信息

        public ITopClient GetProductTopClient()
        {
            return pageHelper.GetProductTopClient();
        }

        public string AppKey { get { return pageHelper.AppKey; } }

        public string AppSecret { get { return pageHelper.AppSecret; } }

        public string ContainerAuthKey { get { return pageHelper.ContainerAuthKey; } }

        public string ContainerSessionKey { get { return pageHelper.ContainerSessionKey; } }

        public string ContainerApi { get { return pageHelper.ContainerApi; } }

        public string ShopLogUrlFormat { get { return pageHelper.ShopLogUrlFormat; } }

        #endregion
    }
}
