using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_ForgetPassword : SitePageBase, IRequiresSessionState
{
    public string script = "";

    protected void btnGetPassword_Click(object sender, EventArgs e)
    {
        Thread.Sleep(500);
        string str = Utility.FilteSqlInfusion(this.tbFormUserName.Text.Trim());
        string email = Utility.FilteSqlInfusion(this.tbEmail.Text.Trim());
        this.tbFormCheckCode.Text.Trim();
        if (str == "")
        {
            JavaScript.Alert(this, "用户名不能为空。");
        }
        else if (email == "")
        {
            JavaScript.Alert(this, "邮箱地址不能为空。");
        }
        else if (!_String.Valid.isEmail(email))
        {
            JavaScript.Alert(this, "邮箱地址格式不正确。");
        }
        else if (base._Site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true) && !this.ShoveCheckCode1.Valid(this.tbFormCheckCode.Text.Trim()))
        {
            JavaScript.Alert(this, "验证码输入错误。");
        }
        else
        {
            DataTable table = new Tables.T_Users().Open("", "Name = '" + str + "' and Email = '" + email + "'", "");
            if ((table == null) || (table.Rows.Count < 1))
            {
                JavaScript.Alert(this, "用户名或邮箱不正确。");
            }
            else if (!_Convert.StrToBool(table.Rows[0]["isEmailValided"].ToString(), false))
            {
                JavaScript.Alert(this, "您的邮箱当前还没有激活，不能使用密码找回功能，请联系客服人员帮你找回密码，谢谢合作。");
            }
            else
            {
                string s = Encrypt.EncryptString(PF.GetCallCert(), table.Rows[0]["ID"].ToString() + "," + DateTime.Now.ToString());
                MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
                string str4 = BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", "");
                s = str4.Substring(0, 0x10) + s + str4.Substring(0x10, 0x10);
                string str5 = Utility.GetUrl() + "/Home/Room/ResetPassword.aspx?key=" + s;
                StringBuilder builder = new StringBuilder();
                builder.Append("<div style='font-weight:bold;'>尊敬的" + base._Site.Name + "客户(").Append(str).Append("):</div>").Append("<div>您好!</div>").Append("<div>系统已收到您的密码找回申请，请点击链接<a href='").Append(str5).Append("' target='_top'>").Append(str5).Append("</a>重设您的密码。</div>").Append("<div>为了您的安全，该邮件通知地址将在 24 小时后失效，谢谢合作。</div>").Append("<div>此邮件由系统发出，请勿直接回复!</div>").Append("<div>上海福彩投诉电话：021-64175077</div>").Append("<div>意见收集与提交：BD@handtouchworld.com </div>").Append("<div>").Append(Utility.GetUrlWithoutHttp()).Append(" 版权所有(C) 2008-2009</div>");
                if (PF.SendEmail(base._Site, email, "密码找回通知信", builder.ToString()) < 0)
                {
                    new Log("System").Write(base.GetType().FullName + "发送邮件失败");
                }
                this.pSetp1.Visible = false;
                this.pStep2.Visible = true;
                this.script = "window.setInterval('DisplayTimer()', 1000);";
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            WebConfig.GetAppSettingsBool("IsUsePPS", true);
            bool flag = base._Site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true);
            this.CheckCode.Visible = flag;
            new Login().SetCheckCode(base._Site, this.ShoveCheckCode1);
            this.pStep2.Visible = false;
        }
    }
}

