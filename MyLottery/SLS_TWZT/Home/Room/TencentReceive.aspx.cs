using AjaxPro;
using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Collections;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_TencentReceive : SitePageBase, IRequiresSessionState
{
    public string Script = "";
    private SystemOptions so = new SystemOptions();

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (this.tbName.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入用户名。");
        }
        else if (this.tbTrueName.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入真实姓名。");
        }
        else if (this.tbPassword.Text == "")
        {
            JavaScript.Alert(this.Page, "请输入用户密码。");
        }
        else if (this.tbPassword.Text.Length < 6)
        {
            JavaScript.Alert(this.Page, "用户密码长度不足 6 位。");
        }
        else if (this.tbPassword.Text != this.tbPassword2.Text)
        {
            JavaScript.Alert(this.Page, "输入的两次密码不一致。");
        }
        else if (this.tbEmail.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入您的邮箱。");
        }
        else if (!_String.Valid.isEmail(this.tbEmail.Text.Trim()))
        {
            JavaScript.Alert(this.Page, "请正确输入您的邮箱。");
        }
        else
        {
            if (this.CheckCode.Visible)
            {
                if (this.tbCheckCode.Text.Trim() == "")
                {
                    JavaScript.Alert(this.Page, "请输入验证码！");
                    return;
                }
                if (!this.ShoveCheckCode1.Valid(this.tbCheckCode.Text.Trim()))
                {
                    JavaScript.Alert(this.Page, "验证码输入有误！");
                    return;
                }
            }
            Thread.Sleep(500);
            Sites sites = new Sites()[Shove._Web.Utility.GetUrlWithoutHttp()];
            if (sites != null)
            {
                Users users = new Users(sites.ID)
                {
                    Name = Shove._Web.Utility.FilteSqlInfusion(this.tbName.Text.Trim()),
                    RealityName = Shove._Web.Utility.FilteSqlInfusion(this.tbTrueName.Text.Trim()),
                    Password = Shove._Web.Utility.FilteSqlInfusion(this.tbPassword.Text.Trim()),
                    PasswordAdv = Shove._Web.Utility.FilteSqlInfusion(this.tbPassword.Text.Trim()),
                    CityID = 1,
                    ComeFrom = 4,
                    Email = Shove._Web.Utility.FilteSqlInfusion(this.tbEmail.Text.Trim()),
                    isEmailValided = true,
                    QQ = this.tbQQID.Text.Trim(),
                    UserType = 2,
                    CommenderID = -1L,
                    isQQValided = true
                };
                string returnDescription = "";
                if (users.Add(ref returnDescription) < 0)
                {
                    JavaScript.Alert(this.Page, returnDescription + "用户添加失败");
                }
                else if (users.Login(ref returnDescription) < 0)
                {
                    new Log("Users").Write("注册成功后登录失败：" + returnDescription);
                    JavaScript.Alert(this, returnDescription);
                }
                else
                {
                    base.Response.Redirect("UserRegSuccess.aspx", true);
                }
            }
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        if (this.ddlName.Items.Count >= 1)
        {
            long num = _Convert.StrToLong(this.ddlName.SelectedValue, -1L);
            if (num < 0L)
            {
                base.Response.Write("接口调用失败，原因：系统错误(1005)。");
                base.Response.End();
            }
            else
            {
                Sites sites = new Sites()[Shove._Web.Utility.GetUrlWithoutHttp()];
                if (sites == null)
                {
                    base.Response.Write("接口调用失败，原因：系统错误(1006)。");
                    base.Response.End();
                }
                else
                {
                    Users user = new Users(sites.ID)[sites.ID, num];
                    if (user == null)
                    {
                        base.Response.Write("接口调用失败，原因：系统错误(1007)。");
                        base.Response.End();
                    }
                    else
                    {
                        string returnDescription = "";
                        if (user.LoginDirect(ref returnDescription) < 0)
                        {
                            base.Response.Write(returnDescription);
                        }
                        else
                        {
                            this.ResponseToDistination(user, "245108764");
                        }
                    }
                }
            }
        }
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public int CheckUserName(string userName)
    {
        if (!PF.CheckUserName(userName))
        {
            return -1;
        }
        DataTable table = new Tables.T_Users().Open("ID", "Name = '" + Shove._Web.Utility.FilteSqlInfusion(userName) + "'", "");
        if ((table != null) && (table.Rows.Count > 0))
        {
            return -2;
        }
        if ((_String.GetLength(userName) >= 5) && (_String.GetLength(userName) <= 0x10))
        {
            return 0;
        }
        return -3;
    }

    private string GetMD5(string encypStr, string charset)
    {
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] bytes = Encoding.GetEncoding(charset).GetBytes(encypStr);
        return BitConverter.ToString(provider.ComputeHash(bytes)).Replace("-", "").ToLower();
    }

    public string GetSign(string key, string input_charset, params string[] requestarr)
    {
        ArrayList list = new ArrayList(requestarr);
        list.Sort();
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < list.Count; i++)
        {
            if ((!string.IsNullOrEmpty(list[i].ToString()) && (base.Request.Form[list[i].ToString()] != "")) && !list[i].ToString().Equals("sign"))
            {
                builder.Append(list[i].ToString() + "=" + base.Request.Form[list[i].ToString()].ToString().Trim() + "&");
            }
        }
        builder.Append("key=" + key);
        return this.GetMD5(builder.ToString().Trim(), input_charset).ToLower();
    }

    public string GetTmstamp()
    {
        DateTime time = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(0x30193L));
        TimeSpan span = (TimeSpan)(DateTime.Parse(DateTime.Now.ToString()) - time);
        return span.TotalSeconds.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Home_Room_TencentReceive), this.Page);
        if (base.Request.Form.AllKeys.Length < 1)
        {
            JavaScript.Alert(this.Page, "接口调用失败，请重新登录。", "../../UserLogin.aspx");
        }
        else
        {
            new StringBuilder();
            string str = (base.Request.Form["charset"] == null) ? "" : base.Request.Form["charset"].ToString().Trim();
            string str2 = (base.Request.Form["tmstamp"] == null) ? "" : base.Request.Form["tmstamp"].ToString().Trim();
            string str3 = (base.Request.Form["sign"] == null) ? "" : base.Request.Form["sign"].ToString().Trim();
            string key = this.so["MemberSharing_Tencent_MD5"].ToString("").Trim();
            string str5 = (base.Request.Form["id"] == null) ? "" : base.Request.Form["id"].ToString().Trim();
            string str6 = "";
            if ((str5.IndexOf("@") > 0) && (str5.IndexOf(".") > 0))
            {
                str6 = str5;
            }
            else
            {
                str6 = str5 + "@qq.com";
            }
            if (!base.IsPostBack)
            {
                if ((_Convert.StrToLong(this.GetTmstamp(), 0L) - _Convert.StrToLong(str2, 0L)) > 120L)
                {
                    JavaScript.Alert(this.Page, "登陆超时，请重新登录。", "../../UserLogin.aspx");
                    return;
                }
                string[] allKeys = base.Request.Form.AllKeys;
                if (this.GetSign(key, str, allKeys) != str3)
                {
                    JavaScript.Alert(this.Page, "您不是有效的腾讯用户不能登录本站，请您注册成为本站会员，再登录，谢谢！(-1001)。", "../../UserLogin.aspx");
                    return;
                }
                if (string.IsNullOrEmpty(str5))
                {
                    JavaScript.Alert(this.Page, "您不是有效的腾讯用户不能登录本站，请您注册成为本站会员，再登录，谢谢！(-1002)。", "../../UserLogin.aspx");
                    return;
                }
            }
            bool flag = base._Site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true);
            this.CheckCode.Visible = flag;
            new Login().SetCheckCode(base._Site, this.ShoveCheckCode1);
            Sites sites = new Sites()[Shove._Web.Utility.GetUrlWithoutHttp()];
            if (sites == null)
            {
                JavaScript.Alert(this.Page, "站点信息不存在。", "../../UserLogin.aspx");
            }
            else
            {
                if ((base._User != null) && (Shove._Web.Cache.GetCache("UserQQBind_" + base._User.ID.ToString()) != null))
                {
                    if (_Convert.StrToLong(str5, 0L) < 1L)
                    {
                        JavaScript.Alert(this.Page, "您输入的 QQ 号码不合法！", "TencentLogin.aspx");
                        return;
                    }
                    Shove._Web.Cache.ClearCache("UserQQBind_" + base._User.ID.ToString());
                    Thread.Sleep(500);
                    string returnDescription = "";
                    base._User.QQ = str5;
                    base._User.isQQValided = true;
                    if (base._User.EditByID(ref returnDescription) < 0)
                    {
                        JavaScript.Alert(this.Page, returnDescription);
                        return;
                    }
                    JavaScript.Alert(this.Page, "QQ号码绑定成功！", "UserQQBind.aspx");
                }
                DataTable dt = new Tables.T_Users().Open("[ID], [Name]", "SiteID = " + sites.ID.ToString() + " and QQ = '" + Shove._Web.Utility.FilteSqlInfusion(str5) + "' and IsQQValided = 1", "[ID]");
                if (dt == null)
                {
                    JavaScript.Alert(this.Page, "数据库繁忙，请重试。", "../../UserLogin.aspx");
                }
                else if (!base.IsPostBack)
                {
                    this.labAccount.Text = str5;
                    this.labAccount2.Text = str5;
                    if (dt.Rows.Count < 1)
                    {
                        this.tbQQID.Text = str5;
                        this.tbName.Text = str5;
                        this.tbEmail.Text = str6;
                        this.btnSelect.Enabled = false;
                        this.tableSelect.Visible = false;
                        this.Script = "btn_CheckUserName('" + str5 + "')";
                    }
                    else if (dt.Rows.Count == 1)
                    {
                        long num4 = _Convert.StrToLong(dt.Rows[0]["ID"].ToString(), -1L);
                        if (num4 < 0L)
                        {
                            JavaScript.Alert(this.Page, "用户信息读取错误。", "../../UserLogin.aspx");
                        }
                        else
                        {
                            Users user = new Users(sites.ID)[sites.ID, num4];
                            if (user == null)
                            {
                                JavaScript.Alert(this.Page, "用户信息不存在。", "../../UserLogin.aspx");
                            }
                            else
                            {
                                string str9 = "";
                                if (user.LoginDirect(ref str9) < 0)
                                {
                                    PF.GoError(1, str9, base.GetType().FullName);
                                }
                                else
                                {
                                    this.ResponseToDistination(user, str5);
                                }
                            }
                        }
                    }
                    else
                    {
                        this.tableRegister.Visible = false;
                        this.btnOK.Enabled = false;
                        this.tableSelect.Visible = true;
                        this.btnSelect.Enabled = true;
                        ControlExt.FillDropDownList(this.ddlName, dt, "Name", "ID");
                        this.ddlName.SelectedIndex = 0;
                    }
                }
            }
        }
    }

    public void ResponseToDistination(Users user, string id)
    {
        if (Shove._Web.Cache.GetCache("UserQQBind_" + user.ID.ToString()) != null)
        {
            Shove._Web.Cache.ClearCache("UserQQBind_" + user.ID.ToString());
            if (_Convert.StrToLong(id, 0L) < 1L)
            {
                JavaScript.Alert(this.Page, "您输入的 QQ 号码不合法！");
            }
            else
            {
                Thread.Sleep(500);
                string returnDescription = "";
                user.isQQValided = true;
                user.QQ = id;
                if (user.EditByID(ref returnDescription) < 0)
                {
                    JavaScript.Alert(this.Page, returnDescription);
                }
                else
                {
                    JavaScript.Alert(this.Page, "QQ号码绑定成功。", "UserQQBind.aspx");
                }
            }
        }
        else
        {
            base.Response.Redirect("../../Default.aspx", true);
        }
    }
}

