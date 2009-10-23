using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper.WebControls.Common;
using TOP.Applications.TaobaoShopHelper._Common;

namespace TOP.Applications.TaobaoShopHelper.Templates
{
    public partial class TemplateApp : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<InformationObject> list = new List<InformationObject>();
            if (CurrentUser == null)
            {
                InformationObject obj = new InformationObject();
                obj.CssName = "Information";
                obj.Message = "您目前没有登录系统，或者登录已经过期。";
                obj.AddLink("点击这里登录系统", "~/Authorizes/UnLogin.aspx?ReturnUrl=" + Server.UrlEncode(Request.Url.AbsolutePath));
                list.Add(obj);
            }
            if (string.IsNullOrEmpty(CurrentSessionKey))
            {
                InformationObject obj = new InformationObject();
                obj.CssName = "Information";
                obj.Message = "我们没有接收到您对我们网站的淘宝网操作授权，或者授权码已经过期。";
                obj.AddLink("点击这里获取淘宝授权", "~/Authorizes/UnAuthorize.aspx?ReturnUrl=" + Server.UrlEncode(Request.Url.AbsolutePath));
                string a = "<img src='" + GetRootURI() + "/Images/Icos/contacts.gif' title='什么是淘宝网授权码' />";
                obj.AddLink(a, "~/Authorizes/UnLogin.aspx");
                list.Add(obj);
            }

            if (list.Count > 0)
            {
                ucCtrlInformationBox.Visible = true;
                ucCtrlInformationBox.SetInformationList(list);
            }
            else
            {
                ucCtrlInformationBox.Visible = false;
            }
        }
    }
}
