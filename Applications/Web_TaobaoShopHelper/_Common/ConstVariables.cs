using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TOP.Applications.TaobaoShopHelper._Common
{
    public class ConstVariables
    {
        private string defaultAppKey = "12006575";
        public string TOP_AppKey
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["TOP_AppKey"]))
                {
                    return defaultAppKey;
                }
                return ConfigurationManager.AppSettings["TOP_AppKey"];
            }
        }

        private string defaultAppSecret = "9d0a6fb5453e9b51877f9ed28b5569a9";
        public string TOP_AppSecret
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["TOP_AppSecret"]))
                {
                    return defaultAppSecret;
                }
                return ConfigurationManager.AppSettings["TOP_AppSecret"];
            }
        }

        private string authKeyContainerUrl = "http://open.taobao.com/authorize/?appkey={0}";
        public string TOP_Url_AuthKeyContainer
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["TOP_Url_AuthKeyContainer"]))
                {
                    return authKeyContainerUrl;
                }
                return ConfigurationManager.AppSettings["TOP_Url_AuthKeyContainer"];
            }
        }

        private string sessionKeyContainerUrl = "http://container.open.taobao.com/container?authcode={0}";
        public string TOP_Url_SessionKeyContainer
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["TOP_Url_SessionKeyContainer"]))
                {
                    return sessionKeyContainerUrl;
                }
                return ConfigurationManager.AppSettings["TOP_Url_SessionKeyContainer"];
            }
        }
    }
}
