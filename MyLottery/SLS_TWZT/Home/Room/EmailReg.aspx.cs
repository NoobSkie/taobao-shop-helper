using ASP;
using Shove;
using Shove._Security;
using Shove._Web;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_EmailReg : RoomPageBase, IRequiresSessionState
{

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isRequestLogin = false;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            Thread.Sleep(500);
            string s = Utility.GetRequest("emailvalidkey").Trim();
            if ((s == "") || (s.Length <= 0x20))
            {
                this.labValided.Text = "非法访问。";
                this.tbOk.Visible = false;
                this.tbFailure.Visible = true;
            }
            else
            {
                string str2 = s.Substring(0, 0x10) + s.Substring(s.Length - 0x10, 0x10);
                s = s.Substring(0x10, s.Length - 0x20);
                try
                {
                    if (str2 != BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", ""))
                    {
                        this.labValided.Text = "非法访问。1";
                        this.tbOk.Visible = false;
                        this.tbFailure.Visible = true;
                    }
                    else
                    {
                        s = Encrypt.UnEncryptString(PF.GetCallCert(), s);
                        long num = -1L;
                        DateTime time2 = DateTime.Now.AddYears(-1);
                        string str3 = "";
                        try
                        {
                            num = _Convert.StrToLong(s.Split(new char[] { ',' })[0], 0L);
                            time2 = Convert.ToDateTime(s.Split(new char[] { ',' })[1]);
                            str3 = s.Split(new char[] { ',' })[2];
                        }
                        catch
                        {
                        }
                        if (time2.AddDays(1.0).CompareTo(DateTime.Now) < 0)
                        {
                            this.labValided.Text = "该地址已过期。";
                            this.tbOk.Visible = false;
                            this.tbFailure.Visible = true;
                        }
                        else if (num <= 0L)
                        {
                            this.labValided.Text = "非法访问。2";
                            this.tbOk.Visible = false;
                            this.tbFailure.Visible = true;
                        }
                        else
                        {
                            string returnDescription = "";
                            Users users = new Users(1L)
                            {
                                ID = num
                            };
                            users.Login(ref returnDescription);
                            if (str3 != users.Email)
                            {
                                this.labValided.Text = "您的邮箱地址不符，请到大厅，我的资料中重新发起激活。<br/><div class='blue12' style='color:black'>前往 <a href=\"Buy.aspx\">购买彩票</a>&nbsp;&nbsp; <a href=\"AccountDetail.aspx\">用户中心</a></div>";
                                this.tbOk.Visible = false;
                                this.tbFailure.Visible = true;
                            }
                            else if (users.isEmailValided)
                            {
                                this.labValided.Text = "您的邮箱已激活，不需要再次激活。<br/><div class='blue12' style='color:black'>前往 <a href=\"Buy.aspx\">购买彩票</a>&nbsp;&nbsp; <a href=\"AccountDetail.aspx\">我的账户</a></div>";
                                this.tbOk.Visible = false;
                                this.tbFailure.Visible = true;
                            }
                            else
                            {
                                users.isEmailValided = true;
                                if (users.EditByID(ref returnDescription) < 0)
                                {
                                    PF.GoError(-1, returnDescription, base.GetType().FullName);
                                }
                                else
                                {
                                    this.tbOk.Visible = true;
                                    this.tbFailure.Visible = false;
                                    this.labValided.Text = "邮箱激活成功。<br/><div class='blue12' color:black'>前往 <a href=\"Buy.aspx\">购买彩票</a> &nbsp; &nbsp; <a href=\"AccountDetail.aspx\">我的账户</a></div>";
                                }
                            }
                        }
                    }
                }
                catch
                {
                    this.labValided.Text = "非法访问。3";
                    this.tbOk.Visible = false;
                    this.tbFailure.Visible = true;
                }
            }
        }
    }
}

