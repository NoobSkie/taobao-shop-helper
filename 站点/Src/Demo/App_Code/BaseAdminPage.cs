using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

public class BaseAdminPage : BasePage
{
    protected override void OnInit(EventArgs e)
    {
        CheckIsAdminLogin();

        base.OnInit(e);
    }

    protected void CheckIsAdminLogin()
    {
        if (!IsAdminLogined)
        {
            RedirectToLogin(this.Page, "请先输入管理员密码以进入后台管理！");
        }
    }
}
