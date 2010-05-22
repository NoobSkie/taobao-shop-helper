using AjaxPro;
using ASP;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Database;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.UI.WebControls;

public partial class Home_Room_UserControls_WebHead : UserControlBase
{
    public string HomePage;
    private static string Admin;
    private static string ForgetPassword;
    private static string LoginUrl;
    private static string LogoOutPage;
    private static string Message;
    private static string MyIcaile;
    private static string NotifyImg;
    private static string RefreshImg;
    private static string Reg;

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public bool IsValid()
    {
        Users currentUser = Users.GetCurrentUser(1L);
        if ((currentUser == null) || (!currentUser.isEmailValided && !currentUser.isMobileValided))
        {
            return false;
        }
        return true;
    }

    protected void lbAlipay_Click(object sender, EventArgs e)
    {
        Shove._Web.Cache.SetCache("OnAlipayFromUrl", base.Request.Url.AbsoluteUri);
        base.Response.Write("<script>window.top.location.href='" + base.ResolveUrl("~/Home/Room/OnlinePay/Default.aspx") + "'</script>");
    }

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public string Login(string UserName, string Password, string InputCheckCode, string CheckCode, long SiteID)
    {
        if (SiteID < 0L)
        {
            return "0";
        }
        string returnDescription = "";
        Sites site = new Sites(SiteID);
        int num = 0;
        try
        {
            num = new Login().LoginSubmit(this.Page, site, UserName, Password, InputCheckCode, CheckCode, ref returnDescription);
        }
        catch
        {
            return "登录出现异常 ！";
        }
        if (num >= 0)
        {
            return Users.GetCurrentUser(SiteID).ID.ToString();
        }
        if (!(returnDescription == ""))
        {
            return returnDescription;
        }
        return "登录出现异常 ！";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Home_Room_UserControls_WebHead), this.Page);
        if (!base.IsPostBack)
        {
            this.HomePage = Shove._Web.Utility.GetUrl();
            Admin = base.ResolveUrl("~/Admin/Default.aspx");
            NotifyImg = base.ResolveUrl("~/Images/notify_bg.gif");
            Message = base.ResolveUrl("~/Home/Room/Message.aspx");
            RefreshImg = base.ResolveUrl("~/Home/Room/Images/icon_shuaxin.gif");
            ForgetPassword = base.ResolveUrl("~/Home/Room/ForgetPassword.aspx");
            Reg = base.ResolveUrl("~/UserReg.aspx");
            MyIcaile = base.ResolveUrl("~/Home/Room/AccountDetail.aspx");
            LogoOutPage = base.ResolveUrl("~/Default.aspx");
            LoginUrl = base.ResolveUrl("~/UserLogin.aspx?ReturnUrl=" + Encrypt.EncryptString(PF.GetCallCert(), base.Request.Url.AbsoluteUri));
            if (base._User != null)
            {
                this.HidUserID.Value = base._User.ID.ToString();
            }
        }
    }

    public static string SetNoCache(HttpContext context)
    {
        Users currentUser = Users.GetCurrentUser(1L);
        StringBuilder builder = new StringBuilder();
        if (currentUser != null)
        {
            builder.Append("<span style=\"padding-left:150px\">");
            if (currentUser.Competences.CompetencesList != "")
            {
                builder.Append("<a href='" + Admin + "' target='_blank'>【超级管理】</a>");
            }
            builder.Append("<span class=\"hui12\"><strong>" + currentUser.Name + "</strong></span>&nbsp;");
            string commandText = "select COUNT(*) from T_StationSMS where (AimID = @UserId or AimID = -1 ) and isRead = 0 and Type = 2 and isShow = 1";
            DataTable table = MSSQL.Select(commandText, new MSSQL.Parameter[] { new MSSQL.Parameter("UserId", SqlDbType.BigInt, 0, ParameterDirection.Input, currentUser.ID) });
            if (((table != null) && (table.Rows.Count > 0)) && (_Convert.StrToInt(table.Rows[0][0].ToString(), 0) > 0))
            {
                string str2 = "<img src=" + NotifyImg + "><a href='" + Message + "'>" + table.Rows[0][0].ToString() + "个提醒</a>&nbsp;&nbsp;";
                builder.Append(str2);
            }
            builder.Append("余额:<span id='lbUserBalance'>").Append(currentUser.Balance.ToString("N")).Append("</span>元&nbsp; <a href=\"javascript:;\" onclick=\"UpdateBindData();\" title=\"点击刷新余额\">").Append("<img src=" + RefreshImg + " border=\"0\" />").Append("</a><a href=" + MyIcaile + ">【用户中心】</a> &nbsp; &nbsp;").Append("<a href='" + LogoOutPage + "?Logout=1'>【安全退出】</asp:LinkButton></span>");
        }
        else
        {
            builder.Append("<span style=\"padding-left:150px\"> <a href=" + LoginUrl + ">登录</a>").Append("&nbsp; <a href=" + ForgetPassword + ">忘记密码</a>&nbsp;").Append(" <a href=" + Reg + ">注册</a>&nbsp;&nbsp;</span>");
        }
        return builder.ToString();
    }

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public string UpdateBindData()
    {
        return Users.GetCurrentUser(1L).Balance.ToString("N");
    }


}

