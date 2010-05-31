using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI;
using J.SLS.Common.Logs;
using System.Text;

public class BaseHelper
{
    private readonly Page _page = null;
    public BaseHelper(Page page)
    {
        _page = page;
    }

    public string SiteName
    {
        get
        {
            string name = "天之歌音乐教育";
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["SiteName"]))
            {
                name = ConfigurationManager.AppSettings["SiteName"];
            }
            return name;
        }
    }

    public string SiteRoot
    {
        get
        {
            string UrlAuthority = _page.Request.Url.GetLeftPart(UriPartial.Authority);
            if (_page.Request.ApplicationPath == null || _page.Request.ApplicationPath == "/")
            {
                //直接安装在Web站点
                return UrlAuthority;
            }
            else
            {
                //安装在虚拟子目录下
                return UrlAuthority + _page.Request.ApplicationPath;
            }
        }
    }

    public bool AdminLogined
    {
        get
        {
            if (_page.Session["AdminLogined"] == null)
            {
                return false;
            }
            return (bool)_page.Session["AdminLogined"];
        }
        set
        {
            _page.Session["AdminLogined"] = value;
        }
    }

    public ILogWriter LogWriter
    {
        get
        {
            return LogWriterGetter.GetLogWriter();
        }
    }

    public void RedirectToUrl(string url)
    {
        _page.Response.Redirect(url, false);
    }

    public void RedirectToLogin(Page basePage, string message)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        if (basePage != null)
        {
            parameters.Add("ReturnUrl", basePage.Request.Url.AbsolutePath);
        }
        if (!string.IsNullOrEmpty(message))
        {
            parameters.Add("Message", message);
        }
        string url = GetParamsUrl("~/Admin/AdminLogin.aspx", parameters);
        _page.Response.Redirect(url);
    }

    public void RedirectToError(int errorCode, string message, string className)
    {
        _page.Response.Redirect("~/Error.aspx", false);
    }

    public string GetParamsUrl(string url, Dictionary<string, string> parameters)
    {
        string mainUrl = url;
        int i = url.IndexOf('?');
        if (i > 0)
        {
            mainUrl = url.Substring(0, i);
            string query = url.Substring(i + 1);
            foreach (string item in query.Split('&'))
            {
                string[] keyValue = item.Split('=');
                if (keyValue.Length >= 2)
                {
                    if (!parameters.ContainsKey(keyValue[0]))
                    {
                        parameters.Add(keyValue[0], keyValue[1]);
                    }
                }
            }
        }
        if (parameters.Count > 0)
        {
            StringBuilder queryBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> item in parameters)
            {
                queryBuilder.AppendFormat("&{0}={1}", item.Key, item.Value);
            }
            mainUrl += "?" + queryBuilder.ToString().TrimStart('&');
        }
        return mainUrl;
    }
}
