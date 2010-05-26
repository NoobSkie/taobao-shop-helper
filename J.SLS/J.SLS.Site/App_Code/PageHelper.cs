using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using J.SLS.Facade;
using System.Configuration;
using System.Web.UI.WebControls;
using Shove.Web.UI;
using System.Data;
using Shove._Web;
using Shove._Security;
using Shove;

public class PageHelper
{
    #region GoError

    public static void GoError(int ErrorNumber, string Tip, string ClassName)
    {
        GoError("~/Error.aspx", ErrorNumber, Tip, ClassName);
    }

    public static void GoError(string ErrorPageUrl, int ErrorNumber, string Tip, string ClassName)
    {
        HttpContext.Current.Response.Redirect(ErrorPageUrl + "?ErrorNumber=" + ErrorNumber.ToString() + "&Tip=" + HttpUtility.UrlEncode(Tip) + "&ClassName=" + HttpUtility.UrlEncode(Encrypt.EncryptString(GetCallCert(), ClassName)), true);
    }

    public static string GetCallCert()
    {
        string sSourceStr = "";
        string str2 = _String.Reverse("ShoveSoft" + " " + "CO.,Ltd ");
        str2 = _String.Reverse(_String.Reverse(str2) + ("--" + " by Shove "));
        sSourceStr = "20050709";
        sSourceStr = _String.Reverse(sSourceStr + _String.Reverse("圳深 ") + _String.Reverse("安宝"));
        return (_String.Reverse(str2) + _String.Reverse(sSourceStr));
    }

    #endregion

    #region GoLogin

    public static void GoLogin()
    {
        GoLogin("UserLogin.aspx", "", true);
    }

    public static void GoLogin(bool isAtFramePageLogin)
    {
        GoLogin("UserLogin.aspx", "", isAtFramePageLogin);
    }

    public static void GoLogin(string RequestLoginPage)
    {
        GoLogin("UserLogin.aspx", RequestLoginPage, true);
    }

    public static void GoLogin(string RequestLoginPage, bool isAtFramePageLogin)
    {
        GoLogin("UserLogin.aspx", RequestLoginPage, isAtFramePageLogin);
    }

    public static void GoLogin(string LoginPageFileName, string RequestLoginPage)
    {
        GoLogin(LoginPageFileName, RequestLoginPage, true);
    }

    public static void GoLogin(string LoginPageFileName, string RequestLoginPage, bool isAtFramePageLogin)
    {
        if (RequestLoginPage.Contains("/Home/Alipay/"))
        {
            LoginPageFileName = Utility.GetUrl() + "/Home/Alipay/Login.aspx";
        }
        else if (RequestLoginPage.Contains("/Web/OnlinePay/") || (RequestLoginPage.Contains("/Web/") && !RequestLoginPage.Contains("/Home/Web/")))
        {
            LoginPageFileName = Utility.GetUrl() + "/Web/" + LoginPageFileName;
        }
        else
        {
            LoginPageFileName = Utility.GetUrl() + "/" + LoginPageFileName;
        }
        if (isAtFramePageLogin)
        {
            HttpContext.Current.Response.Redirect(LoginPageFileName + "?RequestLoginPage=" + HttpUtility.UrlEncode(RequestLoginPage), true);
        }
        else
        {
            HttpContext.Current.Response.Write("<script language=\"javascript\">window.top.location.href=\"" + LoginPageFileName + "?RequestLoginPage=" + HttpUtility.UrlEncode(RequestLoginPage) + "\";</script>");
        }
    }

    #endregion

    #region DataGridBindData

    public static void DataGridBindData(DataGrid g, DataTable dt)
    {
        g.DataSource = dt;
        try
        {
            g.DataBind();
        }
        catch
        {
            g.CurrentPageIndex = 0;
            g.DataBind();
        }
    }

    public static void DataGridBindData(DataGrid g, DataTable dt, ShoveGridPager gPager)
    {
        g.DataSource = dt;
        try
        {
            g.DataBind();
        }
        catch
        {
            g.CurrentPageIndex = 0;
            gPager.PageIndex = 0;
            g.DataBind();
        }
        gPager.Visible = dt.Rows.Count > 0;
    }

    public static void DataGridBindData(DataGrid g, DataView dv, ShoveGridPager gPager)
    {
        g.DataSource = dv;
        try
        {
            g.DataBind();
        }
        catch
        {
            g.CurrentPageIndex = 0;
            gPager.PageIndex = 0;
            g.DataBind();
        }
        gPager.Visible = dv.Count > 0;
    }

    #endregion
}
