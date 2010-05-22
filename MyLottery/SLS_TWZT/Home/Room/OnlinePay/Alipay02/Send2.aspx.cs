using Alipay.Gateway;
using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_Alipay02_Send2 : RoomPageBase, IRequiresSessionState
{
    private string _input_charset = "";
    private string body = "";

    private string gateway = "";

    private string key = "";
    public double Money;
    private string notify_url = "";
    private string out_trade_no = "";
    private string partner = "";
    private string payment_type = "";
    private string paymethod = "";
    private string return_url = "";
    private string seller_email = "";
    private string service = "";
    private string show_url = "";
    private string sign_type = "";
    private SystemOptions so = new SystemOptions();
    private string subject = "";
    private string total_fee = "";

    protected void AlipayPay()
    {
        Alipay.Gateway.Utility utility = new Alipay.Gateway.Utility();
        string str = "";
        this.partner = this.so["OnlinePay_Alipay_UserNumber"].ToString("");
        this.key = this.so["OnlinePay_Alipay_MD5Key"].ToString("");
        str = utility.Createurl(this.gateway, this.service, this.partner, this.key, this.sign_type, this._input_charset, new string[] { 
            "return_url", this.return_url, "notify_url", this.notify_url, "out_trade_no", this.out_trade_no, "subject", this.subject, "payment_type", this.payment_type, "total_fee", this.total_fee, "seller_email", this.seller_email, "body", this.body, 
            "show_url", this.show_url, "paymethod", this.paymethod
         });
        if (str == "")
        {
            JavaScript.Alert(this.Page, "地址构建出现错误");
        }
        else
        {
            base.Response.Write("<script language='javascript'>window.top.location.href='" + str + "'</script>");
        }
    }

    protected void AlipayPay(string defaultbank)
    {
        Alipay.Gateway.Utility utility = new Alipay.Gateway.Utility();
        string str = "";
        this.partner = this.so["OnlinePay_Alipay_UserNumber"].ToString("");
        this.key = this.so["OnlinePay_Alipay_MD5Key"].ToString("");
        str = utility.Createurl(this.gateway, this.service, this.partner, this.key, this.sign_type, this._input_charset, new string[] { 
            "return_url", this.return_url, "notify_url", this.notify_url, "out_trade_no", this.out_trade_no, "subject", this.subject, "payment_type", this.payment_type, "total_fee", this.total_fee, "seller_email", this.seller_email, "body", this.body, 
            "show_url", this.show_url, "defaultbank", defaultbank, "paymethod", this.paymethod
         });
        if (str == "")
        {
            JavaScript.Alert(this.Page, "地址构建出现错误");
        }
        else
        {
            base.Response.Write("<script language='javascript'>window.top.location.href='" + str + "'</script>");
        }
    }

    protected void BankClick(string bankPay)
    {
        Alipay.Gateway.Utility utility = new Alipay.Gateway.Utility();
        string str = "";
        this.partner = this.so["OnlinePay_Alipay_UserNumber1"].ToString("");
        this.key = this.so["OnlinePay_Alipay_MD5Key1"].ToString("");
        str = utility.Createurl(this.gateway, this.service, this.partner, this.key, this.sign_type, this._input_charset, new string[] { 
            "return_url", this.return_url, "notify_url", this.notify_url, "out_trade_no", this.out_trade_no, "subject", this.subject, "payment_type", this.payment_type, "total_fee", this.total_fee, "seller_email", this.seller_email, "body", this.body, 
            "defaultbank", bankPay, "paymethod", this.paymethod
         });
        if (str == "")
        {
            JavaScript.Alert(this.Page, "地址构建出现错误");
        }
        else
        {
            base.Response.Write("<script language='javascript'>window.top.location.href='" + str + "'</script>");
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isAllowPageCache = false;
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.so["OnlinePay_Alipay_Status_ON"].ToBoolean(false);
        if (WebConfig.GetAppSettingsInt("OnlinePayType", 2) == 1)
        {
            base.Response.Redirect("../Alipay01/Default.aspx", true);
        }
        else
        {
            double num2 = _Convert.StrToDouble(Shove._Web.Utility.GetRequest("PayMoney"), 0.0);
            string request = Shove._Web.Utility.GetRequest("bankPay");
            if (!base.IsPostBack)
            {
                if (base._User.Competences.CompetencesList.IndexOf("Administrator") > 0)
                {
                    if (num2 < 0.01)
                    {
                        base.Response.Write("<script type=\"text/javascript\">alert(\"请输入正确的充值金额！再提交，谢谢！\"); window.close();</script>");
                        return;
                    }
                }
                else if (num2 < 1.0)
                {
                    base.Response.Write("<script type=\"text/javascript\">alert(\"请输入正确的充值金额！再提交，谢谢！\"); window.close();</script>");
                    return;
                }
                double num3 = this.so["OnlinePay_Alipay_PayFormalitiesFeesScale"].ToDouble(0.0) / 100.0;
                double formalitiesFees = Math.Round((double)(num2 * num3), 2);
                num2 += formalitiesFees;
                this.gateway = "https://www.alipay.com/cooperate/gateway.do?";
                this.service = "create_direct_pay_by_user";
                this.sign_type = "MD5";
                this.payment_type = "1";
                this._input_charset = "utf-8";
                this.return_url = Shove._Web.Utility.GetUrl() + "/Home/Room/OnlinePay/Alipay02/Receive.aspx?" + HttpUtility.UrlEncode("BuyID=" + Shove._Web.Utility.GetRequest("BuyID"));
                this.notify_url = Shove._Web.Utility.GetUrl() + "/Home/Room/OnlinePay/Alipay02/AlipayNotify.aspx";
                this.partner = this.so["OnlinePay_Alipay_UserNumber"].ToString("");
                this.show_url = "http://www.alipay.com";
                this.seller_email = this.so["OnlinePay_Alipay_UserName"].ToString("");
                this.key = this.so["OnlinePay_Alipay_MD5Key"].ToString("");
                this.paymethod = "bankPay";
                if ((request.ToLower() == "alipay") || (this.so["OnlinePay_Alipay_UserNumber1"].ToString("") == ""))
                {
                    this.subject = Encrypt.EncryptString(PF.GetCallCert(), base._User.ID.ToString() + "_alipay_" + request);
                }
                else
                {
                    this.subject = Encrypt.EncryptString(PF.GetCallCert(), base._User.ID.ToString() + "_bankpay_" + request);
                }
                this.body = "TicketMoney";
                double num7 = Convert.ToDouble(num2.ToString());
                this.total_fee = num7.ToString();
                long newPayNumber = -1L;
                string returnDescription = "";
                if (Procedures.P_GetNewPayNumber(base._Site.ID, base._User.ID, "ALIPAY_" + request, num7 - formalitiesFees, formalitiesFees, ref newPayNumber, ref returnDescription) < 0)
                {
                    PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                }
                else if ((newPayNumber < 0L) || (returnDescription != ""))
                {
                    PF.GoError(1, returnDescription, base.GetType().BaseType.FullName);
                }
                else
                {
                    this.out_trade_no = newPayNumber.ToString();
                    if (request.ToLower() == "alipay")
                    {
                        this.paymethod = "directPay";
                        this.AlipayPay();
                    }
                    else if (this.so["OnlinePay_Alipay_UserNumber1"].ToString("") == "")
                    {
                        this.paymethod = "bankPay";
                        this.AlipayPay(request);
                    }
                    else
                    {
                        this.paymethod = "bankPay";
                        this.BankClick(request);
                    }
                }
            }
        }
    }
}

