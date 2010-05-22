using ASP;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_ResetPassword : SitePageBase, IRequiresSessionState
{

    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        Thread.Sleep(500);
        string s = Utility.GetRequest("key").Trim();
        if ((s == "") || (s.Length <= 0x20))
        {
            this.pSetp1.Visible = false;
            this.pStep2.Visible = true;
            this.lbError.Text = "非法访问。";
        }
        else
        {
            string str2 = s.Substring(0, 0x10) + s.Substring(s.Length - 0x10, 0x10);
            s = s.Substring(0x10, s.Length - 0x20);
            try
            {
                if (str2 != BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", ""))
                {
                    this.pSetp1.Visible = false;
                    this.pStep2.Visible = true;
                    this.lbError.Text = "非法访问。";
                }
                else
                {
                    s = Encrypt.UnEncryptString(PF.GetCallCert(), s);
                    long num = _Convert.StrToLong(s.Split(new char[] { ',' })[0], 0L);
                    if (Convert.ToDateTime(s.Split(new char[] { ',' })[1]).AddDays(1.0).CompareTo(DateTime.Now) < 0)
                    {
                        this.pSetp1.Visible = false;
                        this.pStep2.Visible = true;
                        this.lbError.Text = "该地址已过期。";
                    }
                    else if (num <= 0L)
                    {
                        this.pSetp1.Visible = false;
                        this.pStep2.Visible = true;
                        this.lbError.Text = "非法访问。";
                    }
                    else
                    {
                        string str3 = this.tbUserPassword.Text.Trim();
                        string str4 = this.tbUserPassword2.Text.Trim();
                        if (str3 == "")
                        {
                            JavaScript.Alert(this, "新密码不能为空。");
                        }
                        else if (str3 != str4)
                        {
                            JavaScript.Alert(this, "两次密码输入不一致，请重新输入。");
                        }
                        else if ((str3.Length < 6) || (str3.Length > 0x10))
                        {
                            JavaScript.Alert(this, "密码长度必须为 6-16 位，请重新输入。");
                        }
                        else if (base._Site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true) && !this.ShoveCheckCode1.Valid(this.tbCheckCode.Text.Trim()))
                        {
                            JavaScript.Alert(this, "验证码输入错误。");
                        }
                        else
                        {
                            Users users = new Users(base._Site.ID)
                            {
                                ID = num,
                                Password = str3
                            };
                            string returnDescription = "";
                            if (users.EditByID(ref returnDescription) < 0)
                            {
                                PF.GoError(-1, returnDescription, base.GetType().FullName);
                            }
                            else
                            {
                                users.Login(ref returnDescription);
                                this.pSetp1.Visible = false;
                                this.pStep2.Visible = true;
                                this.lbError.Text = "密码修改成功。<div class='blue' style='margin-top:10px;'>您现在可以前往 <a href='../../Default.aspx'>【购彩大厅】</a> <a href='Default.aspx'>【官网首页】</a></div>";
                            }
                        }
                    }
                }
            }
            catch
            {
                this.pSetp1.Visible = false;
                this.pStep2.Visible = true;
                this.lbError.Text = "非法访问。";
            }
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            string s = Utility.GetRequest("key").Trim();
            if ((s == "") || (s.Length <= 0x20))
            {
                this.pSetp1.Visible = false;
                this.pStep2.Visible = true;
                this.lbError.Text = "非法访问。";
            }
            else
            {
                string str2 = s.Substring(0, 0x10) + s.Substring(s.Length - 0x10, 0x10);
                s = s.Substring(0x10, s.Length - 0x20);
                try
                {
                    if (str2 != BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", ""))
                    {
                        this.pSetp1.Visible = false;
                        this.pStep2.Visible = true;
                        this.lbError.Text = "非法访问。";
                    }
                    else
                    {
                        s = Encrypt.UnEncryptString(PF.GetCallCert(), s);
                        long num = _Convert.StrToLong(s.Split(new char[] { ',' })[0], 0L);
                        if (Convert.ToDateTime(s.Split(new char[] { ',' })[1]).AddDays(1.0).CompareTo(DateTime.Now) < 0)
                        {
                            this.pSetp1.Visible = false;
                            this.pStep2.Visible = true;
                            this.lbError.Text = "该地址已过期。";
                        }
                        else if (num <= 0L)
                        {
                            this.pSetp1.Visible = false;
                            this.pStep2.Visible = true;
                            this.lbError.Text = "非法访问。";
                        }
                        else
                        {
                            this.pSetp1.Visible = true;
                            this.pStep2.Visible = false;
                            bool flag = base._Site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true);
                            this.CheckCode.Visible = flag;
                            new Login().SetCheckCode(base._Site, this.ShoveCheckCode1);
                        }
                    }
                }
                catch
                {
                    this.pSetp1.Visible = false;
                    this.pStep2.Visible = true;
                    this.lbError.Text = "非法访问。";
                }
            }
        }
    }
}

