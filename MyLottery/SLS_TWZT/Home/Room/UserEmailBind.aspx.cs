using ASP;
using Shove;
using Shove._Security;
using Shove._Web;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_UserEmailBind : RoomPageBase, IRequiresSessionState
{

    private void BindData()
    {
        this.lblQuestion.Text = base._User.SecurityQuestion;
        this.labName.Text = base._User.Name;
        this.labUserType.Text = (base._User.UserType == 1) ? "普通用户" : ((base._User.UserType == 3) ? "VIP用户" : "高级用户");
        this.labLevel.Text = base._User.Level.ToString();
        this.tbRealityName.Text = base._User.RealityName;
        this.tbEmail.Text = base._User.Email;
        this.labIsEmailVailded.Text = base._User.isEmailValided ? "<font color='red'>已激活</font>" : "未激活";
        this.btnBind.Enabled = !base._User.isEmailValided;
        this.btnReBind.Enabled = base._User.isEmailValided;
    }

    protected void btnBind_Click(object sender, EventArgs e)
    {
        string email = Utility.FilteSqlInfusion(_Convert.ToDBC(this.tbEmail.Text.Trim()));
        string str2 = Utility.FilteSqlInfusion(_Convert.ToDBC(this.tbAnswer.Text.Trim()));
        if ((base._User.SecurityAnswer == "") || (base._User.SecurityQuestion == ""))
        {
            JavaScript.Alert(this.Page, "您尚未设置安全问题不能进行邮箱绑定。", "SafeSet.aspx?FromUrl=UserEmailBind.aspx");
        }
        else if (str2 == "")
        {
            JavaScript.Alert(this.Page, "问题答案输入有误。");
        }
        else if (str2 != base._User.SecurityAnswer)
        {
            JavaScript.Alert(this.Page, "问题答案输入有误。");
        }
        else if (email == "")
        {
            JavaScript.Alert(this.Page, "请输入 Email 地址。");
        }
        else if (!_String.Valid.isEmail(email))
        {
            JavaScript.Alert(this.Page, "输入 Email 格式不正确。");
        }
        else if ((email == base._User.Email) && base._User.isEmailValided)
        {
            this.Label1.Visible = true;
            this.Label1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;你的 Email 已经激活了，不需要再次激活。";
        }
        else
        {
            string returnDescription = "";
            base._User.Email = email;
            base._User.isEmailValided = false;
            if (base._User.EditByID(ref returnDescription) < 0)
            {
                PF.GoError(-1, "数据库读写错误", base.GetType().FullName);
            }
            else
            {
                string s = Encrypt.EncryptString(PF.GetCallCert(), base._User.ID.ToString() + "," + DateTime.Now.ToString() + "," + email);
                MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
                string str5 = BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", "");
                s = str5.Substring(0, 0x10) + s + str5.Substring(0x10, 0x10);
                string str6 = Utility.GetUrl() + "/Home/Room/EmailReg.aspx?emailvalidkey=" + s;
                StringBuilder builder = new StringBuilder();
                builder.Append("<div style='font-weight:bold;'>尊敬的" + base._Site.Name + "客户(").Append(base._User.Name).Append("):</div>").Append("<div>您好!</div>").Append("<div>系统已收到您的邮箱激活申请，请点击链接<a href='").Append(str6).Append("' target='_top'>").Append(str6).Append("</a>校验您的身份。</div>").Append("<div>为了您的安全，该邮件通知地址将在 24 小时后失效，谢谢合作。</div>").Append("<div>此邮件由系统发出，请勿直接回复!</div>").Append("<div>免费客服电话：400-811-8686</div>").Append("<div>意见收集与提交：BD@handtouchworld.com</div>").Append("<div>").Append(Utility.GetUrlWithoutHttp()).Append(" 版权所有(C) 2008-2009</div>");
                if (PF.SendEmail(base._Site, email, base._Site.Name + "邮箱激活验证", builder.ToString()) == 0)
                {
                    this.tbEmail.Enabled = false;
                    this.Label1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;您好，系统已经发送一封验证邮件您的邮箱，请到您的信箱点击链接完成激活。";
                }
                else
                {
                    new Log("System").Write(base.GetType().FullName + "发送邮件失败");
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
        }
    }
}

