using ASP;
using DAL;
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

public partial class Home_Room_QuestionReg : RoomPageBase, IRequiresSessionState
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
            string s = Utility.GetRequest("Qkey").Trim();
            if ((s == "") || (s.Length <= 0x20))
            {
                JavaScript.Alert(this.Page, "非法访问1", "../../UserLogin.aspx");
            }
            else
            {
                string str2 = s.Substring(0, 0x10) + s.Substring(s.Length - 0x10, 0x10);
                s = s.Substring(0x10, s.Length - 0x20);
                try
                {
                    if (str2 != BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", ""))
                    {
                        JavaScript.Alert(this.Page, "非法访问2", "../../UserLogin.aspx");
                    }
                    else
                    {
                        s = Encrypt.UnEncryptString(PF.GetCallCert(), s);
                        long num = -1L;
                        DateTime time2 = DateTime.Now.AddYears(-1);
                        string str3 = "";
                        string str4 = "";
                        string str5 = "";
                        try
                        {
                            num = _Convert.StrToLong(s.Split(new char[] { ',' })[0], 0L);
                            time2 = Convert.ToDateTime(s.Split(new char[] { ',' })[1]);
                            str3 = s.Split(new char[] { ',' })[2];
                            str4 = s.Split(new char[] { ',' })[3];
                            str5 = s.Split(new char[] { ',' })[4];
                        }
                        catch
                        {
                        }
                        if (time2.AddDays(1.0).CompareTo(DateTime.Now) < 0)
                        {
                            JavaScript.Alert(this.Page, "该地址已过期", "../../UserLogin.aspx");
                        }
                        else if (num <= 0L)
                        {
                            JavaScript.Alert(this.Page, "非法访问3", "../../UserLogin.aspx");
                        }
                        else
                        {
                            string returnDescription = "";
                            Users users = new Users(1L)
                            {
                                ID = num
                            };
                            users.Login(ref returnDescription);
                            if (users.Name != str5)
                            {
                                JavaScript.Alert(this.Page, "非法用户.", "../../UserLogin.aspx");
                            }
                            else if (users.SecurityQuestion != str3)
                            {
                                JavaScript.Alert(this.Page, "安全问题设置无效或已过期", "../../UserLogin.aspx");
                            }
                            else if (users.SecurityQuestion == "")
                            {
                                JavaScript.Alert(this.Page, "安全问题设置无效或已过期", "../../UserLogin.aspx");
                            }
                            else if ((str4 == users.SecurityAnswer) && (str3 == users.SecurityQuestion))
                            {
                                JavaScript.Alert(this.Page, "安全问题已经绑定", "../../UserLogin.aspx");
                            }
                            else if (new Tables.T_Users { SecurityAnswer = { Value = str4 }, SecurityQuestion = { Value = str3 } }.Update("Name = '" + str5 + "'") < 0L)
                            {
                                PF.GoError(-1, returnDescription, base.GetType().FullName);
                            }
                            else
                            {
                                JavaScript.Alert(this.Page, "安全问题绑定成功,请登录后核实.", "../../UserLogin.aspx");
                            }
                        }
                    }
                }
                catch
                {
                    JavaScript.Alert(this.Page, "非法访问4", "../../UserLogin.aspx");
                }
            }
        }
    }
}

