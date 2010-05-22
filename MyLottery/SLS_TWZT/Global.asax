<%@ Application Language="C#" %>

<script runat="server">
    
    void Application_Start(object sender, EventArgs e)
    {
        string mID = PF.GetMID();
        SystemOptions options = new SystemOptions();
        if (options["SerialNumberForShoveSoft_MHB"].Value.ToString() != Shove._Security.Encrypt.NoUnEncryptString(PF.GetCallCert(), mID, "SLS-", 5, 5, 0))
        {
            base.Application["IsSystemRegister"] = false;
        }
        else
        {
            base.Application["IsSystemRegister"] = true;
        }
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码
        base.Application["IsSystemRegister"] = false;
    }

    void Application_Error(object sender, EventArgs e)
    {
        Exception baseException = base.Server.GetLastError().GetBaseException();
        if (baseException == null)
        {
            base.Server.ClearError();
        }
        else
        {
            string str = "空";
            try
            {
                str = HttpContext.Current.Request.Url.ToString();
            }
            catch
            {
            }
            string message = "Error, PageName: " + str + "。 ErrorMsg: " + baseException.Message + " Source:" + baseException.Source + " StackTrace:" + baseException.StackTrace + "。";
            new Shove._IO.Log("System").Write(message);
        }
    }

    public override string GetVaryByCustomString(HttpContext context, string custom)
    {
        if (custom == "SitePage")
        {
            return Shove._Web.Utility.GetUrlWithoutHttp();
        }
        return base.GetVaryByCustomString(context, custom);
    }
    
    void Session_Start(object sender, EventArgs e) 
    {
        //在新会话启动时运行的代码
        base.Session["SessionStart"] = 1;
    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }
       
</script>
