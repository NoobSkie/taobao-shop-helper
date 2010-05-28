using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using J.SLS.Facade;
using System.Configuration;
using System.Web.UI;
using Shove.WordSplit;
using System.Text;

public abstract class BaseControl : System.Web.UI.UserControl
{
    public string SiteName
    {
        get { return ConfigurationManager.AppSettings["SiteName"]; }
    }

    public string SiteRoot
    {
        get
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
    }

    public string UserId
    {
        get
        {
            if (CurrentUser == null)
            {
                return null;
            }
            return CurrentUser.UserId;
        }
    }

    public void SetCurrentUser(string userId)
    {
        UserFacade facade = new UserFacade();
        CurrentUser = facade.GetUserInfo<LoginInfo>(userId);
    }

    public LoginInfo CurrentUser
    {
        get
        {
            return Session["CurrentLoginUser"] as LoginInfo;
        }
        set
        {
            Session["CurrentLoginUser"] = value;
        }
    }

    public void RedirectToDefault()
    {
        Response.Redirect("~/Default.aspx");
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
        string url = GetParamsUrl("~/Users/Login.aspx", parameters);
        Response.Redirect(url);
    }

    protected string GetParamsUrl(string url, Dictionary<string, string> parameters)
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