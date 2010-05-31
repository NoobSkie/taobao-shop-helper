using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using J.SLS.Facade;
using System.Configuration;
using System.Web.UI;
using Shove.WordSplit;
using System.Text;
using J.SLS.Common.Logs;

public abstract class BaseControl : System.Web.UI.UserControl
{
    private BaseHelper helper = null;

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

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

    public string UserId
    {
        get { return helper.UserId; }
    }

    public void SetCurrentUser(string userId)
    {
        helper.SetCurrentUser(userId);
    }

    public UserInfo CurrentUser
    {
        get { return helper.CurrentUser; }
        set { helper.CurrentUser = value; }
    }

    public ILogWriter LogWriter
    {
        get { return helper.LogWriter; }
    }

    public void RedirectToUrl(string url)
    {
        helper.RedirectToUrl(url);
    }

    public void RedirectToDefault()
    {
        helper.RedirectToUrl("~/Default.aspx");
    }

    public void RedirectToLogin(Page basePage, string message)
    {
        helper.RedirectToLogin(basePage, message);
    }

    protected string GetParamsUrl(string url, Dictionary<string, string> parameters)
    {
        return helper.GetParamsUrl(url, parameters);
    }
}