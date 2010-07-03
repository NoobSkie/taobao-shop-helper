using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using J.SLS.Common.Logs;
using System.Web.UI;
using J.SkyMusic.DbFacade.Services;

public class BaseControl : System.Web.UI.UserControl
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

    public string AutoPlayMusic
    {
        get
        {
            if (this.Application["AutoPlayMusic"] == null)
            {
                return GetParamValue("AutoPlayMusic", "0");
            }
            return (string)this.Application["AutoPlayMusic"];
        }
    }

    public string NoticeDelay
    {
        get
        {
            if (this.Application["NoticeDelay"] == null)
            {
                return GetParamValue("NoticeDelay", "3000");
            }
            return (string)this.Application["NoticeDelay"];
        }
    }

    public string LogoFileName
    {
        get
        {
            if (this.Application["LogoFileName"] == null)
            {
                return GetParamValue("LogoFileName", "logo.png");
            }
            return (string)this.Application["LogoFileName"];
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
}
