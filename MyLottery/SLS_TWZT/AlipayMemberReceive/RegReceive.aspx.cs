using Alipay.Gateway;
using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using System;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class AlipayMemberReceive_RegReceive : SitePageBase, IRequiresSessionState
{
    private SystemOptions so = new SystemOptions();

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.so["MemberRegister_Alipay_UserNumber"].ToString("");
        string str = this.so["MemberRegister_Alipay_MD5"].ToString("");
        string str2 = "utf-8";
        string[] strArray2 = Alipay.Gateway.Utility.BubbleSort(base.Request.QueryString.AllKeys);
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < strArray2.Length; i++)
        {
            if ((!string.IsNullOrEmpty(strArray2[i]) && (base.Request.QueryString[strArray2[i]] != "")) && ((strArray2[i] != "sign") && (strArray2[i] != "sign_type")))
            {
                if (i == (strArray2.Length - 1))
                {
                    builder.Append(strArray2[i] + "=" + base.Request.QueryString[strArray2[i]]);
                }
                else
                {
                    builder.Append(strArray2[i] + "=" + base.Request.QueryString[strArray2[i]] + "&");
                }
            }
        }
        builder.Append(str);
        string str3 = Alipay.Gateway.Utility.GetMD5(builder.ToString(), str2);
        string str4 = base.Request.QueryString["sign"];
        string str5 = base.Request.QueryString["user_id"];
        string str6 = base.Request.QueryString["email"];
        if (str3 != str4)
        {
            new Log("System").Write("校验出错！生成校验码：" + str3.ToString() + "返回校验码：" + str4.ToString());
            base.Response.Write("<script language='javascript'>window.top.location.href='" + Shove._Web.Utility.GetUrl() + "/Error.aspx'</script>");
        }
        else
        {
            string str7 = "";
            long num2 = 0L;
            string str8 = "BindAlipay_";
            HttpCookie cookie = base.Request.Cookies[str8 + str6];
            if (cookie == null)
            {
                PF.GoError(1, "异常用户数据", base.GetType().BaseType.FullName);
            }
            else
            {
                str7 = cookie.Values["AlipayMember"];
                num2 = _Convert.StrToLong(Encrypt.UnEncryptString(PF.GetCallCert(), cookie.Values["ID"]), -1L);
                cookie.Expires = DateTime.Now.AddYears(-20);
                if ((num2 <= 0L) || (str6 != str7))
                {
                    PF.GoError(1, "异常用户数据", base.GetType().BaseType.FullName);
                }
                else if ((base._User != null) && (base._User.ID != num2))
                {
                    PF.GoError(1, "异常用户数据", base.GetType().BaseType.FullName);
                }
                else
                {
                    string returnDescription = "";
                    if (base._User == null)
                    {
                        base._User = new Users(base._Site.ID)[base._Site.ID, num2];
                        if (base._User == null)
                        {
                            PF.GoError(1, "异常用户数据", base.GetType().BaseType.FullName);
                            return;
                        }
                        returnDescription = "";
                        base._User.LoginDirect(ref returnDescription);
                    }
                    bool flag = false;
                    base._User.AlipayID = str5;
                    base._User.isAlipayNameValided = true;
                    if (base._User.AlipayName == "")
                    {
                        flag = true;
                    }
                    base._User.AlipayName = str7;
                    returnDescription = "";
                    if (base._User.EditByID(ref returnDescription) < 0)
                    {
                        JavaScript.Alert(this.Page, returnDescription);
                    }
                    else
                    {
                        if (((PF.AlipayAccountRegisterPid != "") && flag) && (new Tables.T_AlipayRegDonate { UserID = { Value = base._User.ID }, AlipayName = { Value = str7 } }.Insert() < 0L))
                        {
                            new Log("Page").Write("写入 T_AlipayRegDonate 失败" + base.GetType().FullName + "(152)");
                        }
                        base._User.GetUserInformationByID(ref returnDescription);
                        base.Response.Redirect(Shove._Web.Utility.GetUrl() + "/UserReg.aspx?t=" + new Random(DateTime.Now.Millisecond).Next().ToString(), true);
                    }
                }
            }
        }
    }


}

