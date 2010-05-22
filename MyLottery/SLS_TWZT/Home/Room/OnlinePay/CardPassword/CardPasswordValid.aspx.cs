using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_OnlinePay_CardPassword_CardPasswordValid : RoomPageBase, IRequiresSessionState
{


    protected void btnOK_Click(object sender, EventArgs e)
    {
        string input = "LtnyeFVjxGloveshove19791130ea8g502shove!@#$%^&*()__";
        try
        {
            input = this.ViewState["CardPasswordValidNumber_" + base._User.ID.ToString()].ToString();
            input = Encrypt.UnEncryptString(PF.GetCallCert(), Encrypt.Decrypt3DES(PF.GetCallCert(), input, PF.DesKey));
        }
        catch
        {
        }
        if (input != this.tbCode.Text.Trim())
        {
            JavaScript.Alert(this.Page, "验证串错误。");
        }
        else
        {
            string returnDescription = "";
            if (new CardPassword().Use(input, base._Site.ID, base._User.ID, ref returnDescription) < 0)
            {
                JavaScript.Alert(this.Page, returnDescription);
            }
            else
            {
                new Tables.T_CardPasswordsValid { UserID = { Value = base._User.ID }, Mobile = { Value = this.tbMobile.Text.Trim() }, CardPasswordsNum = { Value = this.tbCardPassword.Text.Trim() } }.Insert();
                JavaScript.Alert(this.Page, "卡密充值成功, 请点击“查看我的账户”查看投注卡账户余额情况。");
            }
        }
    }

    protected void btnValid_Click(object sender, EventArgs e)
    {
        int freeze = 0;
        int returnValue = 0;
        string returnDescription = "";
        if ((Procedures.P_CardPasswordTryErrorFreeze(base._Site.ID, base._User.ID, ref freeze, ref returnValue, ref returnDescription) < 0) || (returnValue < 0))
        {
            PF.GoError(4, "数据库繁忙，请重试", "Room_ViewChase");
        }
        else if (freeze > 0)
        {
            JavaScript.Alert(this.Page, "您输入错误的卡密号码次数过多，系统已经暂时锁定您的卡密支付功能。");
        }
        else
        {
            string str2 = Utility.FilteSqlInfusion(_Convert.ToDBC(this.tbCardPassword.Text.Trim()));
            if (string.IsNullOrEmpty(str2))
            {
                JavaScript.Alert(this.Page, "请输入充值卡密。");
            }
            else
            {
                Thread.Sleep(0x3e8);
                if (!Regex.IsMatch(str2, @"^[\d]{20}$", RegexOptions.Compiled | RegexOptions.IgnoreCase))
                {
                    JavaScript.Alert(this.Page, "您输入的卡密号码错误!");
                }
                else
                {
                    string mobileNumber = Utility.FilteSqlInfusion(_Convert.ToDBC(this.tbMobile.Text.Trim()));
                    if (mobileNumber == "")
                    {
                        JavaScript.Alert(this.Page, "请输入手机号码。");
                    }
                    else if (!_String.Valid.isMobile(mobileNumber))
                    {
                        JavaScript.Alert(this.Page, "输入手机号码格式不正确。");
                    }
                    else if (new Tables.T_CardPasswordsValid().GetCount("Mobile = '" + mobileNumber + "'") > 0L)
                    {
                        JavaScript.Alert(this.Page, "此手机号码已经被验证，请重新输入一个手机号码。");
                    }
                    else
                    {
                        string validNumber = this.GetValidNumber();
                        this.ViewState["CardPasswordValidNumber_" + base._User.ID.ToString()] = Encrypt.Encrypt3DES(PF.GetCallCert(), Encrypt.EncryptString(PF.GetCallCert(), validNumber), PF.DesKey);
                        string content = "尊敬的" + base._User.Name + "的会员您好！您在<%=_Site.Name %>的卡密充值较验码是：" + validNumber + "，请回网页输入较验码以完成卡密充值的过程！";
                        if (PF.SendSMS(base._Site, base._User.ID, mobileNumber, content) == 0)
                        {
                            this.trInfo.Visible = true;
                            this.trValid.Visible = true;
                            this.tbCardPassword.ReadOnly = true;
                            this.tbMobile.ReadOnly = true;
                            this.btnValid.Enabled = false;
                        }
                    }
                }
            }
        }
    }

    private string GetValidNumber()
    {
        string str;
        int num = base._Site.SiteOptions["Opt_MobileCheckCharset"].ToInt(1);
        int num2 = base._Site.SiteOptions["Opt_MobileCheckStringLength"].ToInt(6);
        if ((num < 1) || (num > 4))
        {
            num = 1;
        }
        if ((num2 < 1) || (num2 > 20))
        {
            num2 = 6;
        }
        switch (num)
        {
            case 1:
                str = "0123456789";
                break;

            case 2:
                str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                break;

            case 3:
                str = "abcdefghijklmnopqrstuvwxyz";
                break;

            default:
                str = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                break;
        }
        Random random = new Random();
        string str2 = "";
        for (int i = 0; i < num2; i++)
        {
            str2 = str2 + str[random.Next(str.Length - 1)].ToString();
        }
        return str2;
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
            this.tbCardPassword.Text = Utility.GetRequest("Num");
        }
    }
}

