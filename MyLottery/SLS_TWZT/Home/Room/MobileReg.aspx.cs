using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_MobileReg : RoomPageBase, IRequiresSessionState
{

    protected void btnGO_Click(object sender, EventArgs e)
    {
        string input = "LtnyeFVjxGloveshove19791130ea8g502shove!@#$%^&*()__";
        try
        {
            input = this.ViewState["MobileValidNumber_" + base._User.ID.ToString()].ToString();
            input = Encrypt.UnEncryptString(PF.GetCallCert(), Encrypt.Decrypt3DES(PF.GetCallCert(), input, PF.DesKey));
        }
        catch
        {
        }
        if (input != this.tbValidPassword.Text.Trim())
        {
            JavaScript.Alert(this.Page, "验证串错误。");
        }
        else
        {
            Users user = new Users(base._Site.ID);
            base._User.Clone(user);
            base._User.Mobile = this.tbUserMobile.Text;
            base._User.isMobileValided = true;
            string returnDescription = "";
            if (base._User.EditByID(ref returnDescription) < 0)
            {
                user.Clone(base._User);
                JavaScript.Alert(this.Page, returnDescription);
            }
            else
            {
                JavaScript.Alert(this.Page, "手机绑定成功。", "UserMobileBind.aspx");
            }
        }
    }

    protected void btnMobileValid_Click(object sender, EventArgs e)
    {
        string mobileNumber = Utility.FilteSqlInfusion(_Convert.ToDBC(this.tbUserMobile.Text.Trim()));
        if (mobileNumber == "")
        {
            JavaScript.Alert(this.Page, "请输入手机号码。");
        }
        else if (!_String.Valid.isMobile(mobileNumber))
        {
            JavaScript.Alert(this.Page, "输入手机号码格式不正确。");
        }
        else if ((mobileNumber == base._User.Mobile) && base._User.isMobileValided)
        {
            this.Label3.Visible = true;
            this.Label3.Text = "&nbsp;&nbsp;&nbsp;&nbsp;你的手机已经通过验证了，不需要再次验证。";
            JavaScript.Alert(this.Page, "输入手机号码已经被校验通过，不需要重复校验。");
        }
        else if (new Tables.T_Users().GetCount("Mobile = '" + mobileNumber + "' and isMobileValided = 1 and [ID] <> " + base._User.ID.ToString()) > 0L)
        {
            this.Label3.Visible = true;
            this.Label3.Text = "&nbsp;&nbsp;&nbsp;&nbsp;此手机号码已经被其他用户验证，请重新输入一个手机号码。";
            JavaScript.Alert(this.Page, "此手机号码已经被其他用户验证，请重新输入一个手机号码。");
        }
        else
        {
            string validNumber = this.GetValidNumber();
            this.ViewState["MobileValidNumber_" + base._User.ID.ToString()] = Encrypt.Encrypt3DES(PF.GetCallCert(), Encrypt.EncryptString(PF.GetCallCert(), validNumber), PF.DesKey);
            string content = base._Site.SiteNotificationTemplates[1, "MobileValid"];
            if (content != "")
            {
                content = content.Replace("[晓风彩票软件门户版]", "[" + base._Site.Name + "客服中心]").Replace("[UserName]", base._User.Name).Replace("[ValidNumber]", validNumber);
            }
            this.btnGO.Visible = PF.SendSMS(base._Site, base._User.ID, this.tbUserMobile.Text.Trim(), content) == 0;
            base._User.Mobile = mobileNumber;
            base._User.isMobileValided = false;
            string returnDescription = "";
            if (base._User.EditByID(ref returnDescription) < 0)
            {
                PF.GoError(-1, "数据库读写错误", base.GetType().FullName);
            }
            else
            {
                this.tbUserMobile.Enabled = false;
                this.btnMobileValid.Enabled = false;
                this.Label3.Text = "&nbsp;&nbsp;&nbsp;&nbsp;您好，系统已经发送一串验证密码到你的手机，请将接收到的字串输入到验证密码框内，再点击确定按钮完成验证。";
                this.panelValid.Visible = true;
                this.Label3.Visible = true;
                this.tbValidPassword.Enabled = true;
                this.tbValidPassword.ReadOnly = false;
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
            this.tbUserName.Text = base._User.Name;
            this.tbUserMobile.Text = base._User.Mobile;
        }
    }
}

