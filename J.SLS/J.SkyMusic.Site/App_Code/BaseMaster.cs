using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using J.SLS.Common.Logs;
using System.Web.UI;
using System.Text;
using J.SkyMusic.DbFacade.Services;

public class BaseMaster : System.Web.UI.MasterPage
{
    public string SiteName
    {
        get
        {
            if (this.Application["SiteName"] == null)
            {
                return GetParamValue("SiteName", "天之歌音乐教育");
            }
            return (string)this.Application["SiteName"];
        }
    }

    public string Address
    {
        get
        {
            if (this.Application["Address"] == null)
            {
                return GetParamValue("Address", "未定义");
            }
            return (string)this.Application["Address"];
        }
    }

    public string PhoneNumber
    {
        get
        {
            if (this.Application["PhoneNumber"] == null)
            {
                return GetParamValue("PhoneNumber", "未定义");
            }
            return (string)this.Application["PhoneNumber"];
        }
    }

    public string FaxNumber
    {
        get
        {
            if (this.Application["FaxNumber"] == null)
            {
                return GetParamValue("FaxNumber", "未定义");
            }
            return (string)this.Application["FaxNumber"];
        }
    }

    public string QQNumber
    {
        get
        {
            if (this.Application["QQNumber"] == null)
            {
                return GetParamValue("QQNumber", "47954507");
            }
            return (string)this.Application["QQNumber"];
        }
    }

    private string GetParamValue(string key, string defaultValue)
    {
        ParamFacade facade = new ParamFacade();
        ParamInfo paraAddress = facade.GetParam(key);
        string name = defaultValue;
        if (paraAddress != null)
        {
            name = paraAddress.Value;
            this.Application[key] = name;
        }
        return name;
    }

    public string SiteRoot
    {
        get
        {
            string UrlAuthority = this.Request.Url.GetLeftPart(UriPartial.Authority);
            if (this.Request.ApplicationPath == null || this.Request.ApplicationPath == "/")
            {
                //直接安装在Web站点
                return UrlAuthority;
            }
            else
            {
                //安装在虚拟子目录下
                return UrlAuthority + this.Request.ApplicationPath;
            }
        }
    }

    public bool IsAdminLogined
    {
        get
        {
            if (this.Session["AdminLogined"] == null)
            {
                return false;
            }
            return (bool)this.Session["AdminLogined"];
        }
        set
        {
            this.Session["AdminLogined"] = value;
        }
    }

    public ILogWriter LogWriter
    {
        get
        {
            return LogWriterGetter.GetLogWriter();
        }
    }

    public void JavascriptAlert(string msg)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "AlertMsg", "alert('" + msg.Replace("'", "''") + "');", true);
    }

    public void JavascriptAlertAndRedirect(string msg, string url)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "AlertAndRedirect", "AlertAndRedirect('" + msg + "', '" + url + "');", true);
    }

    public void JavascriptAlertAndRedirectAndRefreshParent(string msg, string url)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "AlertAndRedirectAndRefreshParent", "AlertAndRedirectAndRefreshParent('" + msg + "', '" + url + "');", true);
    }

    public void RedirectToUrl(string url)
    {
        this.Response.Redirect(url, false);
    }

    public void RedirectToLogin(Page basePage, string message)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        if (basePage != null)
        {
            parameters.Add("ReturnUrl", basePage.Request.Url.AbsoluteUri);
        }
        if (!string.IsNullOrEmpty(message))
        {
            parameters.Add("Message", message);
        }
        string url = GetParamsUrl("~/Admins/AdminLogin.aspx", parameters);
        url = this.ResolveClientUrl(url);
        this.Response.Redirect(url);
    }

    public void RedirectToError(int errorCode, string message, string className)
    {
        this.Response.Redirect("~/Error.aspx", false);
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
                queryBuilder.AppendFormat("&{0}={1}", item.Key, this.Server.UrlEncode(item.Value));
            }
            mainUrl += "?" + queryBuilder.ToString().TrimStart('&');
        }
        return mainUrl;
    }
}
