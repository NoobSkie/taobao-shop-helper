using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using J.SLS.Common.Logs;
using System.Web.UI;

public class BasePage : System.Web.UI.Page
{
    private BaseHelper helper = null;
    public BasePage()
    {
        helper = new BaseHelper(this.Page);
    }

    public string SiteName
    {
        get { return helper.SiteName; }
    }

    public string SiteRoot
    {
        get { return helper.SiteRoot; }
    }

    public bool IsAdminLogined
    {
        get { return helper.AdminLogined; }
        set { helper.AdminLogined = value; }
    }

    public ILogWriter LogWriter
    {
        get { return helper.LogWriter; }
    }

    public void RedirectToUrl(string url)
    {
        helper.RedirectToUrl(url);
    }

    public void RedirectToLogin(Page basePage, string message)
    {
        helper.RedirectToLogin(basePage, message);
    }

    public void RedirectToError(int errorCode, string message, string className)
    {
        helper.RedirectToError(errorCode, message, className);
    }

    protected string GetParamsUrl(string url, Dictionary<string, string> parameters)
    {
        return helper.GetParamsUrl(url, parameters);
    }
}
