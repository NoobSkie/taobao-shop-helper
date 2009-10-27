using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Taobao.Top.Api;
using TOP.Authorize.Facade;

namespace TOP.Applications.TaobaoShopHelper._Common
{
    public class BaseControl : UserControl
    {
        private PageObject pageHelper = new PageObject();

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

        #endregion
    }
}
