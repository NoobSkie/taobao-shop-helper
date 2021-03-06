﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using J.SLS.Facade;
using System.Configuration;
using J.SLS.Common.Logs;
using System.Web.UI;

public abstract class BasePage : System.Web.UI.Page
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

    public string GetAgenceAccountUserName()
    {
        if (ConfigurationManager.AppSettings["AgenceAccount"] == null)
        {
            throw new ArgumentNullException("未配置代理商账号！");
        }
        return ConfigurationManager.AppSettings["AgenceAccount"];
    }

    public string GetAgenceAccountPassword()
    {
        if (ConfigurationManager.AppSettings["AgencePassword"] == null)
        {
            throw new ArgumentNullException("未配置代理商账号！");
        }
        return ConfigurationManager.AppSettings["AgencePassword"];
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

    public void RedirectToError(int errorCode, string message, string className)
    {
        helper.RedirectToError(errorCode, message, className);
    }

    protected string GetParamsUrl(string url, Dictionary<string, string> parameters)
    {
        return helper.GetParamsUrl(url, parameters);
    }
}