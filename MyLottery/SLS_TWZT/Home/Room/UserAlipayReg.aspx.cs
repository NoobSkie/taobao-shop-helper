using Alipay.Gateway;
using ASP;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_UserAlipayReg : RoomPageBase, IRequiresSessionState
{

    protected void btn_AppAliapy_OK_Click(object sender, EventArgs e)
    {
        if (this.tb_2_AlipayName.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入您的支付宝账号。");
        }
        else if (!_String.Valid.isEmail(this.tb_2_AlipayName.Text.Trim()) && !_String.Valid.isMobile(this.tb_2_AlipayName.Text.Trim()))
        {
            JavaScript.Alert(this.Page, "支付宝账号格式不正确(要求使用有效的 Email 账号、手机号码)。");
        }
        else
        {
            Thread.Sleep(500);
            Member member = new Member();
            string realityName = "";
            if (member.Query(this.tb_2_AlipayName.Text.Trim(), ref realityName) >= 0L)
            {
                JavaScript.Alert(this.Page, "此支付宝账号已经被占用，请重新输入一个支付宝账户名称。");
            }
            else
            {
                string str2 = "BindAlipay_";
                HttpCookie cookie = new HttpCookie(str2 + this.tb_2_AlipayName.Text.Trim());
                cookie.Values["AlipayMember"] = this.tb_2_AlipayName.Text.Trim();
                cookie.Values["ID"] = Encrypt.EncryptString(PF.GetCallCert(), base._User.ID.ToString());
                cookie.Expires = DateTime.Now.AddDays(1.0);
                base.Response.AppendCookie(cookie);
                if ((cookie.Values["AlipayMember"] == null) || (cookie.Values["AlipayMember"] == ""))
                {
                    JavaScript.Alert(this.Page, "您的浏览器禁用了 Cookies 请你到大厅绑定您的支付宝账号", Shove._Web.Utility.GetUrl() + "/Default.aspx");
                }
                else
                {
                    string str3 = member.BuildRegisterUrl(this.tb_2_AlipayName.Text.Trim(), base._User.ID);
                    base.Response.Write("<script language='javascript'>window.top.location.href='" + str3 + "'</script>");
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isRequestLogin = true;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        base.Response.Cookies["WebSite"].Value = Shove._Web.Utility.GetUrl();
        base.Response.Cookies["WebSite"].Expires = DateTime.Now.AddDays(1.0);
        if (base.Request.Cookies["WebSite"] == null)
        {
            JavaScript.Alert(this.Page, "您的浏览器不支持 Cookies 不能注册", "../../Default.aspx");
        }
        else
        {
            base.Response.Cookies["WebSite"].Expires = DateTime.Now.AddYears(-20);
        }
    }
}

