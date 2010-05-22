using Shove._Web;
using Shove.Web.UI;
using System;
using System.Threading;
using System.Web;
using System.Web.UI;

public class Login
{
    public void GoToRequestLoginPage(string DefaultPage)
    {
        string request = Utility.GetRequest("RequestLoginPage");
        if (request == null)
        {
            request = "";
        }
        if (((request == "") && (DefaultPage.Trim() == "")) && WebConfig.GetAppSettingsBool("GotoRoomWhenLogin", false))
        {
            request = "~/Default.aspx";
        }
        if (request != "")
        {
            if (request.StartsWith("Home/Room/"))
            {
                request = request.Substring(5, request.Length - 5);
                if (!request.StartsWith("MyIcaile.aspx?SubPage="))
                {
                    HttpContext.Current.Response.Write("<script language='javascript'>window.top.location.href='Home/Room/MyIcaile.aspx?SubPage=" + HttpUtility.UrlEncode(request) + "'</script>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<script language='javascript'>window.top.location.href='Home/Room/" + request + "'</script>");
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect(request, true);
            }
        }
        else if (DefaultPage.Trim() != "")
        {
            HttpContext.Current.Response.Redirect(DefaultPage, true);
        }
    }

    public int LoginSubmit(Page page, Sites site, string Name, string Password, ref string ReturnDescription)
    {
        ReturnDescription = "";
        Name = Name.Trim();
        Password = Password.Trim();
        if ((Name == "") || (Password == ""))
        {
            ReturnDescription = "用户名和密码都不能为空";
            return -1;
        }
        Thread.Sleep(500);
        return new Users(site.ID) { Name = Name, Password = Password }.Login(ref ReturnDescription);
    }

    public int LoginSubmit(Page page, Sites site, string Name, string Password, string InputCheckCode, ShoveCheckCode sccCheckCode, ref string ReturnDescription)
    {
        ReturnDescription = "";
        bool flag = site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true);
        Name = Name.Trim();
        Password = Password.Trim();
        if ((Name == "") || (Password == ""))
        {
            ReturnDescription = "用户名和密码都不能为空";
            return -1;
        }
        if (flag)
        {
            if (sccCheckCode == null)
            {
                ReturnDescription = "验证码内部错误";
                return -2;
            }
            if (!sccCheckCode.Valid(InputCheckCode))
            {
                ReturnDescription = "验证码输入错误";
                return -3;
            }
        }
        Thread.Sleep(500);
        return new Users(site.ID) { Name = Name, Password = Password }.Login(ref ReturnDescription);
    }

    public int LoginSubmit(Page page, Sites site, string Name, string Password, string InputCheckCode, string CheckCode, ref string ReturnDescription)
    {
        ReturnDescription = "";
        bool flag = site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true);
        Name = Name.Trim();
        Password = Password.Trim();
        if ((Name == "") || (Password == ""))
        {
            ReturnDescription = "用户名和密码都不能为空";
            return -1;
        }
        if (flag)
        {
            ShoveCheckCode code = new ShoveCheckCode();
            if (!code.Valid(InputCheckCode, CheckCode))
            {
                ReturnDescription = "验证码输入错误";
                return -2;
            }
        }
        Thread.Sleep(500);
        return new Users(site.ID) { Name = Name, Password = Password }.Login(ref ReturnDescription);
    }

    public void SetCheckCode(Sites site, ShoveCheckCode sccCheckCode)
    {
        switch (site.SiteOptions["Opt_CheckCodeCharset"].ToShort(0))
        {
            case 0:
                sccCheckCode.Charset = ShoveCheckCode.CharSet.All;
                return;

            case 1:
                sccCheckCode.Charset = ShoveCheckCode.CharSet.OnlyLetter;
                return;

            case 2:
                sccCheckCode.Charset = ShoveCheckCode.CharSet.OnlyLetterLower;
                return;

            case 3:
                sccCheckCode.Charset = ShoveCheckCode.CharSet.OnlyLetterUpper;
                return;

            case 4:
                sccCheckCode.Charset = ShoveCheckCode.CharSet.OnlyNumeric;
                return;
        }
        sccCheckCode.Charset = ShoveCheckCode.CharSet.All;
    }
}

