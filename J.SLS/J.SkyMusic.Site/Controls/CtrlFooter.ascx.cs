using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_CtrlFooter : BaseControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblAddress.Text = string.Format("总公司地址：{0}", Address);
            lblPhone.Text = string.Format("电话：{0}", PhoneNumber);
            lblFax.Text = string.Format("传真：{0}", FaxNumber);
            hlnkQQ.NavigateUrl = string.Format("http://wpa.qq.com/msgrd?v=1&uin={0}&site={1}&menu=yes", QQNumber, SiteRoot);
            imgQQ.ImageUrl = string.Format("http://wpa.qq.com/pa?p=1:{0}:4", QQNumber);
        }
    }
}
