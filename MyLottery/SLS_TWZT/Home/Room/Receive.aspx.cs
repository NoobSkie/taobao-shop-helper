using AjaxPro;
using Alipay.Gateway;
using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Alipay;
using Shove.Web.UI;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_Receive : SitePageBase, IRequiresSessionState
{
    private SystemOptions so = new SystemOptions();
    public string Script = "";

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (this.tbName.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入用户名。");
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
                long num = -1L;
                string str = new FirstUrl().Get();
                if (!str.StartsWith("http://"))
                {
                    char ch = '?';
                    str = ("http://" + str).Split(ch.ToString().ToCharArray())[0];
                }
                DataTable table = new Tables.T_Cps().Open("id, [ON], [Name]", "SiteID = " + base._Site.ID.ToString() + " and DomainName = '" + str + "' or DomainName='" + Shove._Web.Utility.GetUrl() + "'", "");
                if (((table != null) && (table.Rows.Count > 0)) && _Convert.StrToBool(table.Rows[0]["ON"].ToString(), false))
                {
                    num = _Convert.StrToLong(table.Rows[0]["ID"].ToString(), -1L);
                }
                string str2 = Shove._Web.Utility.GetRequest("real_name").Trim();
                Users users = new Users(sites.ID)
                {
                    Name = this.tbName.Text.Trim(),
                    RealityName = str2,
                    Password = this.tbPassword.Text.Trim(),
                    PasswordAdv = this.tbPassword.Text.Trim(),
                    CityID = 1,
                    Email = this.labAccount.Text.Trim(),
                    ComeFrom = 4,
                    UserType = 2,
                    CpsID = num,
                    CommenderID = -1L
                };
                string returnDescription = "";
                if (users.Add(ref returnDescription) < 0)
                {
                    JavaScript.Alert(this.Page, returnDescription + "用户添加失败");
                }
                else
                {
                    Member member = new Member();
                    string realityName = "";
                    long num2 = member.Query(this.labAccount.Text, ref realityName);
                    if (num2 < 0L)
                    {
                        JavaScript.Alert(this.Page, "输入的账号在支付宝网站验证失败(不存在账号或者网络通讯故障，" + num2.ToString() + ")，请重新填写一个账号名称。");
                    }
                    else
                    {
                        new Tables.T_Users { AlipayID = { Value = this.tbAlipayID.Text }, AlipayName = { Value = this.labAccount.Text }, isAlipayNameValided = { Value = true } }.Update("[ID] = " + users.ID.ToString());
                        users.LoginDirect(ref returnDescription);
                        long buyID = -1L;
                        if ((base.Request.Url.AbsoluteUri.IndexOf("?BuyID") > 0) && (base.Request.Url.AbsoluteUri.IndexOf("&") > 0))
                        {
                            buyID = _Convert.StrToLong(HttpUtility.UrlDecode(base.Request.Url.AbsoluteUri).Split(new char[] { '?' })[1].Split(new char[] { '&' })[0].Replace("BuyID=", ""), -1L);
                        }
                        if (buyID > 0L)
                        {
                            this.GoBuy(buyID);
                        }
                        else
                        {
                            base.Response.Redirect("UserRegSuccess.aspx", true);
                        }
                    }
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
                    Users users = new Users(sites.ID)[sites.ID, num];
                    if (users == null)
                    {
                        base.Response.Write("接口调用失败，原因：系统错误(1007)。");
                        base.Response.End();
                    }
                    else
                    {
                        string returnDescription = "";
                        if (users.LoginDirect(ref returnDescription) < 0)
                        {
                            base.Response.Write(returnDescription);
                        }
                        else
                        {
                            long buyID = -1L;
                            if ((base.Request.Url.AbsoluteUri.IndexOf("?BuyID") > 0) && (base.Request.Url.AbsoluteUri.IndexOf("&") > 0))
                            {
                                buyID = _Convert.StrToLong(HttpUtility.UrlDecode(base.Request.Url.AbsoluteUri).Split(new char[] { '?' })[1].Split(new char[] { '&' })[0].Replace("BuyID=", ""), -1L);
                            }
                            if (buyID > 0L)
                            {
                                this.GoBuy(buyID);
                            }
                            else
                            {
                                base.Response.Redirect("../../Default.aspx", true);
                            }
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

    private string Get_Http(string a_strUrl, int timeout)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(a_strUrl);
            request.Timeout = timeout;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            StringBuilder builder = new StringBuilder();
            while (-1 != reader.Peek())
            {
                builder.Append(reader.ReadLine());
            }
            return builder.ToString();
        }
        catch (Exception exception)
        {
            return ("错误：" + exception.Message);
        }
    }

    private void GoBuy(long BuyID)
    {
        DataTable table = new Tables.T_AlipayBuyTemp().Open("", "ID=" + BuyID.ToString(), "");
        if ((table == null) || (table.Rows.Count != 1))
        {
            base.Response.Redirect("../../Default.aspx", true);
            return;
        }
        string str = table.Rows[0]["LotteryID"].ToString();
        string url = "";
        string str3 = str;
        if (str3 != null)
        {
            if (!(str3 == "5"))
            {
                if (str3 == "6")
                {
                    url = "Buy3D.aspx?BuyID=" + BuyID.ToString();
                    goto Label_011A;
                }
                if (str3 == "29")
                {
                    url = "BuyShssl.aspx?BuyID=" + BuyID.ToString();
                    goto Label_011A;
                }
                if (str3 == "39")
                {
                    url = "BuyDlt.aspx?BuyID=" + BuyID.ToString();
                    goto Label_011A;
                }
            }
            else
            {
                url = "BuySsq.aspx?BuyID=" + BuyID.ToString();
                goto Label_011A;
            }
        }
        url = "../../Default.aspx?BuyID=" + BuyID.ToString();
    Label_011A:
        base.Response.Redirect(url, true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Home_Room_Receive), this.Page);
        if (base.Request.QueryString.Count < 1)
        {
            JavaScript.Alert(this.Page, "接口调用失败，请重新登录。", "../../Default.aspx");
        }
        else
        {
            string str = "http://notify.alipay.com/trade/notify_query.do?";
            string str2 = this.so["MemberSharing_Alipay_UserNumber"].ToString("");
            str = str + "partner=" + str2 + "&notify_id=" + base.Request.QueryString["notify_id"];
            if (this.Get_Http(str, 0x1d4c0) == "false")
            {
                JavaScript.Alert(this.Page, "接口调用失败，请重新登录。", "../../Default.aspx");
            }
            else
            {
                bool flag = base._Site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true);
                this.CheckCode.Visible = flag;
                new Login().SetCheckCode(base._Site, this.ShoveCheckCode1);
                if (WebConfig.GetAppSettingsBool("DebugUserControl", false))
                {
                    this.tbName.Text = "为了设计页面而进入调试状态，本控件的功能并不运行";
                }
                else
                {
                    string str4 = this.so["MemberSharing_Alipay_MD5"].ToString("");
                    string charset = "utf-8";
                    string[] strArray3 = Shove.Alipay.Alipay.BubbleSort(base.Request.QueryString.AllKeys);
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < strArray3.Length; i++)
                    {
                        if (((!string.IsNullOrEmpty(strArray3[i]) && (base.Request.QueryString[strArray3[i]] != "")) && ((strArray3[i] != "sign") && (strArray3[i] != "sign_type"))) && (strArray3[i].ToLower() != "pn"))
                        {
                            if (i == (strArray3.Length - 1))
                            {
                                builder.Append(strArray3[i] + "=" + base.Request.QueryString[strArray3[i]]);
                            }
                            else
                            {
                                builder.Append(strArray3[i] + "=" + base.Request.QueryString[strArray3[i]] + "&");
                            }
                        }
                    }
                    builder.Append(str4);
                    string str6 = Shove.Alipay.Alipay.GetMD5(builder.ToString(), charset);
                    string str7 = (base.Request.QueryString["sign"] == null) ? "" : base.Request.QueryString["sign"].ToString();
                    string str8 = (base.Request.QueryString["is_success"] == null) ? "" : base.Request.QueryString["is_success"].ToString().ToUpper();
                    string str9 = (base.Request.QueryString["user_id"] == null) ? "" : base.Request.QueryString["user_id"].ToString();
                    string str10 = (base.Request.QueryString["email"] == null) ? "" : base.Request.QueryString["email"].ToString();
                    if (base.Request.QueryString["user_type"] != null)
                    {
                        base.Request.QueryString["user_type"].ToString();
                    }
                    if (base.Request.QueryString["user_status"] != null)
                    {
                        base.Request.QueryString["user_status"].ToString();
                    }
                    if (base.Request.QueryString["firm_name"] != null)
                    {
                        base.Request.QueryString["firm_name"].ToString();
                    }
                    string str11 = (base.Request.QueryString["real_name"] == null) ? "" : base.Request.QueryString["real_name"].ToString();
                    if (base.Request.QueryString["cert_no"] != null)
                    {
                        base.Request.QueryString["cert_no"].ToString();
                    }
                    if (base.Request.QueryString["cert_type"] != null)
                    {
                        base.Request.QueryString["cert_type"].ToString();
                    }
                    if (base.Request.QueryString["gender"] != null)
                    {
                        base.Request.QueryString["gender"].ToString();
                    }
                    if (base.Request.QueryString["province"] != null)
                    {
                        base.Request.QueryString["province"].ToString();
                    }
                    if (base.Request.QueryString["city"] != null)
                    {
                        base.Request.QueryString["city"].ToString();
                    }
                    if (base.Request.QueryString["address"] != null)
                    {
                        base.Request.QueryString["address"].ToString();
                    }
                    if (base.Request.QueryString["zip"] != null)
                    {
                        base.Request.QueryString["zip"].ToString();
                    }
                    if (base.Request.QueryString["phone"] != null)
                    {
                        base.Request.QueryString["phone"].ToString();
                    }
                    if (base.Request.QueryString["mobile"] != null)
                    {
                        base.Request.QueryString["mobile"].ToString();
                    }
                    if (base.Request.QueryString["is_bank_auth"] != null)
                    {
                        base.Request.QueryString["is_bank_auth"].ToString();
                    }
                    if (base.Request.QueryString["is_mobile_auth"] != null)
                    {
                        base.Request.QueryString["is_mobile_auth"].ToString();
                    }
                    if (base.Request.QueryString["is_id_auth"] != null)
                    {
                        base.Request.QueryString["is_id_auth"].ToString();
                    }
                    if ((str6 != str7) || (str10 == ""))
                    {
                        PF.GoError(1, "您不是有效的支付宝会员不能登录本站，请您注册成为本站会员，再登录，谢谢！(-1001)", base.GetType().FullName);
                    }
                    else if (str8 != "T")
                    {
                        PF.GoError(1, "您不是有效的支付宝会员不能登录本站，请您注册成为本站会员，再登录，谢谢！(-1002)", base.GetType().FullName);
                    }
                    else if (string.IsNullOrEmpty(str9))
                    {
                        PF.GoError(1, "您不是有效的支付宝会员不能登录本站，请您注册成为本站会员，再登录，谢谢！(-1003)", base.GetType().FullName);
                    }
                    else if (string.IsNullOrEmpty(str10))
                    {
                        PF.GoError(1, "您不是有效的支付宝会员不能登录本站，请您注册成为本站会员，再登录，谢谢！(-1004)", base.GetType().FullName);
                    }
                    else
                    {
                        Sites sites = new Sites()[Shove._Web.Utility.GetUrlWithoutHttp()];
                        if (sites == null)
                        {
                            PF.GoError(1, "会员数据校验错误。", base.GetType().FullName);
                        }
                        else
                        {
                            if ((base._User != null) && (Shove._Web.Cache.GetCache("BindAlipay_" + base._User.ID.ToString()) != null))
                            {
                                string realityName = "";
                                long num3 = new Member().Query(str10, ref realityName);
                                if (num3 < 0L)
                                {
                                    JavaScript.Alert(this.Page, "输入的账号在支付宝网站验证失败(不存在账号或者网络通讯故障，" + num3.ToString() + ")，请重新填写一个账号名称。");
                                    return;
                                }
                                if (((str11 != base._User.RealityName) && (realityName != base._User.RealityName)) && (base._User.RealityName != ""))
                                {
                                    JavaScript.Alert(this.Page, "您输入的支付宝账号的真实姓名与您在本站注册时提供的真实姓名不一致，请更换新的支付宝帐号进行绑定，谢谢！", "Login.aspx");
                                    return;
                                }
                                Shove._Web.Cache.ClearCache("BindAlipay_" + base._User.ID.ToString());
                                Thread.Sleep(500);
                                Users user = new Users(base._Site.ID);
                                base._User.Clone(user);
                                base._User.AlipayID = num3.ToString();
                                base._User.AlipayName = str10;
                                base._User.RealityName = realityName;
                                base._User.isAlipayNameValided = true;
                                string returnDescription = "";
                                if (base._User.EditByID(ref returnDescription) < 0)
                                {
                                    user.Clone(base._User);
                                    JavaScript.Alert(this.Page, returnDescription);
                                    return;
                                }
                                JavaScript.Alert(this.Page, "支付宝绑定成功！", "BindAlipay.aspx");
                            }
                            DataTable dt = new Tables.T_Users().Open("[ID], [Name]", "SiteID = " + sites.ID.ToString() + " and AlipayID = '" + Shove._Web.Utility.FilteSqlInfusion(str9) + "'", "[ID]");
                            if (dt == null)
                            {
                                PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
                            }
                            else if (!base.IsPostBack)
                            {
                                this.labAccount.Text = str10;
                                this.labAccount2.Text = str10;
                                if (dt.Rows.Count < 1)
                                {
                                    this.tbAlipayID.Text = str9;
                                    this.tbName.Text = str10.Split(new char[] { '@' })[0];
                                    this.Script = "btn_CheckUserName('" + this.tbName.Text + "')";
                                    this.btnSelect.Enabled = false;
                                    this.tableSelect.Visible = false;
                                }
                                else if (dt.Rows.Count == 1)
                                {
                                    long num5 = _Convert.StrToLong(dt.Rows[0]["ID"].ToString(), -1L);
                                    if (num5 < 0L)
                                    {
                                        PF.GoError(1, "会员数据校验错误。", base.GetType().FullName);
                                    }
                                    else
                                    {
                                        Users users3 = new Users(sites.ID)[sites.ID, num5];
                                        if (users3 == null)
                                        {
                                            PF.GoError(1, "会员数据校验错误。", base.GetType().FullName);
                                        }
                                        else
                                        {
                                            string str14 = "";
                                            if (users3.LoginDirect(ref str14) < 0)
                                            {
                                                PF.GoError(1, str14, base.GetType().FullName);
                                            }
                                            else
                                            {
                                                long buyID = -1L;
                                                if ((base.Request.Url.AbsoluteUri.IndexOf("?BuyID") > 0) && (base.Request.Url.AbsoluteUri.IndexOf("&") > 0))
                                                {
                                                    buyID = _Convert.StrToLong(HttpUtility.UrlDecode(base.Request.Url.AbsoluteUri).Split(new char[] { '?' })[1].Split(new char[] { '&' })[0].Replace("BuyID=", ""), -1L);
                                                }
                                                if (buyID > 0L)
                                                {
                                                    this.GoBuy(buyID);
                                                }
                                                else
                                                {
                                                    base.Response.Redirect("../../Default.aspx", true);
                                                }
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
            }
        }
    }
}

