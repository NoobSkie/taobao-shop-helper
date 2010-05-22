namespace URLRewriter
{
    using System;
    using System.Runtime.InteropServices;
    using System.Web;

    internal class RewriterUtils
    {
        internal static string ResolveUrl(string appPath, string url)
        {
            if ((url.Length == 0) || (url[0] != '~'))
            {
                return url;
            }
            if (url.Length == 1)
            {
                return appPath;
            }
            if ((url[1] == '/') || (url[1] == '\\'))
            {
                if (appPath.Length > 1)
                {
                    return (appPath + "/" + url.Substring(2));
                }
                return ("/" + url.Substring(2));
            }
            if (appPath.Length > 1)
            {
                return (appPath + "/" + url.Substring(1));
            }
            return (appPath + url.Substring(1));
        }

        internal static void RewriteUrl(HttpContext context, string sendToUrl)
        {
            string str;
            string str2;
            RewriteUrl(context, sendToUrl, out str, out str2);
        }

        internal static void RewriteUrl(HttpContext context, string sendToUrl, out string sendToUrlLessQString, out string filePath)
        {
            if (context.Request.QueryString.Count > 0)
            {
                if (sendToUrl.IndexOf('?') != -1)
                {
                    sendToUrl = sendToUrl + "&" + context.Request.QueryString.ToString();
                }
                else
                {
                    sendToUrl = sendToUrl + "?" + context.Request.QueryString.ToString();
                }
            }
            string queryString = string.Empty;
            sendToUrlLessQString = sendToUrl;
            if (sendToUrl.IndexOf('?') > 0)
            {
                sendToUrlLessQString = sendToUrl.Substring(0, sendToUrl.IndexOf('?'));
                queryString = sendToUrl.Substring(sendToUrl.IndexOf('?') + 1);
            }
            filePath = string.Empty;
            filePath = context.Server.MapPath(sendToUrlLessQString);
            context.RewritePath(sendToUrlLessQString, string.Empty, queryString);
        }
    }
}

