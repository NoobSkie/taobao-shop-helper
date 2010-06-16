using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using J.SLS.Facade;
using System.Configuration;
using J.SLS.Common.Logs;
using System.Web.UI;

public abstract class BaseAdminPage : BasePage
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (CurrentUser == null)
        {
            RedirectToLogin(this.Page, "请先登录系统！");
        }
        if (CurrentUser.UserRole == J.SLS.Common.UserRoleType.OuterUser)
        {
            RedirectToLogin(this.Page, "您没有足够的权限！");
        }
    }
}