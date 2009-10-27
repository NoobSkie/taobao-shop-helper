using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Taobao.Top.Api;
using TOP.Authorize.Facade;
using System.Configuration;

namespace TOP.Applications.TaobaoShopHelper._Common
{
    public class PageObject
    {
        #region 页面Url处理

        public string GetRootURI(HttpRequest request)
        {
            string UrlAuthority = request.Url.GetLeftPart(UriPartial.Authority);
            if (request.ApplicationPath == null || request.ApplicationPath == "/")
            {
                //直接安装在Web站点
                return UrlAuthority;
            }
            else
            {
                //安装在虚拟子目录下
                return UrlAuthority + request.ApplicationPath;
            }
        }

        public Dictionary<string, string> GetParameterListByQuery(HttpRequest request)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            foreach (string key in request.QueryString.AllKeys)
            {
                if (!key.Equals("IsSuccess", StringComparison.OrdinalIgnoreCase)
                    && !key.Equals("Message", StringComparison.OrdinalIgnoreCase))
                {
                    list.Add(key, request.QueryString[key]);
                }
            }
            return list;
        }

        public string GetQueryByParameterList(Dictionary<string, string> parameters, HttpServerUtility server)
        {
            string query = string.Empty;
            foreach (KeyValuePair<string, string> item in parameters)
            {
                query += "&" + server.UrlEncode(item.Key) + "=" + server.UrlEncode(item.Value);
            }
            return query.TrimStart('&');
        }

        #endregion

        #region 全局Session操作

        public void SetSessionValue<T>(string sessionKey, T sessionValue, HttpSessionState sessionContainer)
        {
            sessionContainer[sessionKey] = sessionValue;
        }

        public T GetSessionValue<T>(string sessionKey, HttpSessionState sessionContainer)
        {
            return (T)sessionContainer[sessionKey];
        }

        #endregion

        #region Top相关全局信息

        public ITopClient GetProductTopClient()
        {
            return new TopRestClient(ContainerApi, AppKey, AppSecret, ConstVariables.TopDataTransferType);
        }

        private string defaultAppKey = "12006575";
        public string AppKey
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["AppKey"]))
                {
                    return defaultAppKey;
                }
                return ConfigurationManager.AppSettings["AppKey"];
            }
        }

        private string defaultAppSecret = "9d0a6fb5453e9b51877f9ed28b5569a9";
        public string AppSecret
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["AppSecret"]))
                {
                    return defaultAppSecret;
                }
                return ConfigurationManager.AppSettings["AppSecret"];
            }
        }

        private string authKeyContainerUrl = "http://auth.open.taobao.com/?appkey={0}";
        public string ContainerAuthKey
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["ContainerAuthKey"]))
                {
                    return authKeyContainerUrl;
                }
                return ConfigurationManager.AppSettings["ContainerAuthKey"];
            }
        }

        private string sessionKeyContainerUrl = "http://container.open.taobao.com/container?authcode={0}";
        public string ContainerSessionKey
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["ContainerSessionKey"]))
                {
                    return sessionKeyContainerUrl;
                }
                return ConfigurationManager.AppSettings["ContainerSessionKey"];
            }
        }

        private string apiContainerUrl = "http://gw.api.taobao.com/router/rest";
        public string ContainerApi
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["ContainerApi"]))
                {
                    return apiContainerUrl;
                }
                return ConfigurationManager.AppSettings["ContainerApi"];
            }
        }

        #endregion
    }
}
