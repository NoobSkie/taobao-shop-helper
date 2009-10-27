using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Taobao.Top.Api;

namespace TOP.Applications.TaobaoShopHelper._Common
{
    public class ConstVariables
    {
        public const string TopDataTransferType = "json";

        public static string GetUnAuthorizeUrl()
        {
            return "~/Authorizes/UnAuthorize.aspx";
        }

        public static string GetUnLoginUrl()
        {
            return "~/Authorizes/UnLogin.aspx";
        }
    }
}
