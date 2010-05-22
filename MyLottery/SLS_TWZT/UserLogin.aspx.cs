using AjaxPro;
using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Threading;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class UserLogin : SitePageBase, IRequiresSessionState
{
    public string LoginIframeUrl = "";


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        switch (Shove._Web.Utility.GetUrl())
        {
            case "http://caipiao.tpy100.com":
            case "http://caipiao.58.com":
                this.LoginForSpecialCpsUser();
                return;
        }
        string returnDescription = "";
        int num = -1;
        if (this.Panel1.Visible)
        {
            num = new Login().LoginSubmit(this.Page, base._Site, this.tbFormUserName.Text, this.tbFormUserPassword.Text, this.tbFormCheckCode.Text, this.ShoveCheckCode1, ref returnDescription);
        }
        else
        {
            num = new Login().LoginSubmit(this.Page, base._Site, this.tbFormUserName.Text, this.tbFormUserPassword.Text, ref returnDescription);
        }
        object cache = Shove._Web.Cache.GetCache("OnGotoLoginUrl");
        if (num < 0)
        {
            this.Panel1.Visible = true;
            JavaScript.Alert(this.Page, returnDescription);
        }
        else if (cache != null)
        {
            Shove._Web.Cache.ClearCache("OnGotoLoginUrl");
            base.Response.Redirect(cache.ToString());
        }
        else if ((Shove._Web.Utility.GetRequest("Rollback") != null) || (Shove._Web.Utility.GetRequest("Rollback") != ""))
        {
            string request = Shove._Web.Utility.GetRequest("Rollback");
            if (Encrypt.UnEncryptString(PF.GetCallCert(), request) == "MyIcaile.aspx")
            {
                new Login().GoToRequestLoginPage("~/Home/Room/AccountDetail.aspx");
            }
            else
            {
                new Login().GoToRequestLoginPage("~/Default.aspx");
            }
        }
        else
        {
            new Login().GoToRequestLoginPage("~/Default.aspx");
        }
    }

    protected void btnReg_Click(object sender, EventArgs e)
    {
        if (this.CheckCodeReg.Visible && (this.tbRegCheckCode.Text.Trim() == ""))
        {
            JavaScript.Alert(this.Page, "请输入验证码！");
        }
        //else if (!PF.IsSystemRegister())
        //{
        //    PF.GoError(4, "请联系网站管理员输入软件序列号", base.GetType().BaseType.FullName);
        //}
        else
        {
            long num = -1L;
            long num2 = -1L;
            string pID = "";
            FirstUrl url = new FirstUrl();
            string str2 = url.Get();
            if (!str2.StartsWith("http://"))
            {
                char ch = '?';
                str2 = ("http://" + str2).Split(ch.ToString().ToCharArray())[0];
            }
            DataTable table = new Tables.T_Cps().Open("id, [ON], [Name]", "SiteID = " + base._Site.ID.ToString() + " and( DomainName = '" + str2 + "' or DomainName='" + Shove._Web.Utility.GetUrl() + "')", "");
            if (_Convert.StrToLong(url.CpsID, -1L) > 0L)
            {
                num = _Convert.StrToLong(url.CpsID, -1L);
            }
            else if ((table != null) && (table.Rows.Count > 0))
            {
                num = _Convert.StrToLong(table.Rows[0]["ID"].ToString(), -1L);
                pID = url.PID;
            }
            Thread.Sleep(500);
            string str3 = this.tbRegUserName.Text.Trim();
            string str4 = this.tbFormPassword.Text.Trim();
            this.tbPassword2.Text.Trim();
            string str5 = this.tbEmail.Text.Trim();
            string str6 = this.tbRealityName.Text.Trim();
            Users users = new Users(base._Site.ID)
            {
                Name = str3,
                Password = str4,
                Email = str5,
                RealityName = str6,
                UserType = 2,
                CommenderID = num2,
                CpsID = num,
                Memo = pID
            };
            string returnDescription = "";
            if (users.Add(ref returnDescription) < 0)
            {
                new Log("Users").Write("会员注册不成功：" + returnDescription);
                JavaScript.Alert(this, returnDescription);
            }
            else if (users.Login(ref returnDescription) < 0)
            {
                new Log("Users").Write("注册成功后登录失败：" + returnDescription);
                JavaScript.Alert(this, returnDescription);
            }
            else
            {
                base.Response.Redirect("Home/Room/UserRegSuccess.aspx");
            }
        }
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string CheckReg(string name, string password, string password2, string email, string realityName, string inputCheckCode, string CheckCode, string IDCardNumber)
    {
        name = name.Trim();
        password = password.Trim();
        password2 = password2.Trim();
        email = email.Trim();
        realityName = realityName.Trim();
        IDCardNumber = IDCardNumber.Trim();
        if (!PF.CheckUserName(name))
        {
            return "对不起用户名中含有禁止使用的字符";
        }
        if ((_String.GetLength(name) < 5) || (_String.GetLength(name) > 0x10))
        {
            return "用户名长度在 5-16 个英文字符或数字、中文 3-8 之间。";
        }
        if (password != password2)
        {
            return "两次密码输入不一致，请仔细检查。";
        }
        if ((password.Length < 6) || (password.Length > 0x10))
        {
            return "密码长度必须在 6-16 位之间。";
        }
        if (!_String.Valid.isEmail(email))
        {
            return "电子邮件地址格式不正确。";
        }
        if ((((IDCardNumber.Trim() != "") && !_String.Valid.isIDCardNumber(IDCardNumber.Trim())) && (!_String.Valid.isIDCardNumber_Hongkong(IDCardNumber.Trim()) && !_String.Valid.isIDCardNumber_Macau(IDCardNumber.Trim()))) && (!_String.Valid.isIDCardNumber_Singapore(IDCardNumber.Trim()) && !_String.Valid.isIDCardNumber_Taiwan(IDCardNumber.Trim())))
        {
            return "身份证号码格式不正确。";
        }
        ShoveCheckCode code = new ShoveCheckCode();
        if (!code.Valid(CheckCode, inputCheckCode))
        {
            return "验证码输入错误";
        }
        return "";
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public int CheckUserName(string name)
    {
        if (!PF.CheckUserName(name))
        {
            return -1;
        }
        DataTable table = new Tables.T_Users().Open("ID", "Name = '" + Shove._Web.Utility.FilteSqlInfusion(name) + "'", "");
        if ((table != null) && (table.Rows.Count > 0))
        {
            return -2;
        }
        if ((_String.GetLength(name) >= 5) && (_String.GetLength(name) <= 0x10))
        {
            return 0;
        }
        return -3;
    }

    private void LoginForSpecialCpsUser()
    {
        string url = Shove._Web.Utility.GetUrl();
        string returnDescription = "";
        int num = -1;
        string str3 = "";
        switch (url)
        {
            case "http://caipiao.tpy100.com":
                str3 = "typ_";
                break;

            case "http://caipiao.58.com":
                str3 = "58_";
                break;
        }
        if (this.Panel1.Visible)
        {
            num = new Login().LoginSubmit(this.Page, base._Site, this.tbFormUserName.Text, this.tbFormUserPassword.Text, this.tbFormCheckCode.Text, this.ShoveCheckCode1, ref returnDescription);
        }
        else
        {
            num = new Login().LoginSubmit(this.Page, base._Site, this.tbFormUserName.Text, this.tbFormUserPassword.Text, ref returnDescription);
        }
        if (num < 0)
        {
            if (this.Panel1.Visible)
            {
                num = new Login().LoginSubmit(this.Page, base._Site, str3 + this.tbFormUserName.Text, this.tbFormUserPassword.Text, this.tbFormCheckCode.Text, this.ShoveCheckCode1, ref returnDescription);
            }
            else
            {
                num = new Login().LoginSubmit(this.Page, base._Site, str3 + this.tbFormUserName.Text, this.tbFormUserPassword.Text, ref returnDescription);
            }
        }
        if (num < 0)
        {
            this.Panel1.Visible = true;
            JavaScript.Alert(this.Page, returnDescription);
        }
        else
        {
            object cache = Shove._Web.Cache.GetCache("OnGotoLoginUrl");
            if (cache != null)
            {
                Shove._Web.Cache.ClearCache("OnGotoLoginUrl");
                base.Response.Redirect(cache.ToString());
            }
            else if ((Shove._Web.Utility.GetRequest("Rollback") != null) || (Shove._Web.Utility.GetRequest("Rollback") != ""))
            {
                string request = Shove._Web.Utility.GetRequest("Rollback");
                if (Encrypt.UnEncryptString(PF.GetCallCert(), request) == "MyIcaile.aspx")
                {
                    new Login().GoToRequestLoginPage("~/Home/Room/AccountDetail.aspx");
                }
                else
                {
                    new Login().GoToRequestLoginPage("~/Default.aspx");
                }
            }
            else
            {
                new Login().GoToRequestLoginPage("~/Default.aspx");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.HomePage.Value = Shove._Web.Utility.GetUrl();
        AjaxPro.Utility.RegisterTypeForAjax(typeof(UserLogin), this.Page);
        this.LoginIframeUrl = base.ResolveUrl("~/Home/Room/UserLoginDialog.aspx");
        if (!base.IsPostBack)
        {
            bool flag = base._Site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true);
            this.CheckCode.Visible = flag;
            this.CheckCodeReg.Visible = flag;
            new Login().SetCheckCode(base._Site, this.ShoveCheckCode1);
            new Login().SetCheckCode(base._Site, this.ShoveCheckCode2);
            if (base._User != null)
            {
                base.Response.Redirect("Default.aspx");
            }
            if (Shove._Web.Cache.GetCache("IsLoginFirst") != null)
            {
                this.Panel1.Visible = true;
                Shove._Web.Cache.ClearCache("IsLoginFirst");
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = "xxx";
        s = s + "??";
        Response.Write(s);
    }
}

