using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Alipay;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_Alipay01_Send2 : RoomPageBase, IRequiresSessionState
{
    private string _input_charset = "";
    private string body = "";
    private string buyer_email = "";

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
        string str = new Shove.Alipay.Alipay().CreatUrl(this.gateway, this.service, this.partner, this.return_url, this.notify_url, this.out_trade_no, this.subject, this.payment_type, this.total_fee, this.seller_email, this.key, this._input_charset, this.sign_type, new string[] { "body", this.body, "show_url", this.show_url, "paymethod", this.paymethod });
        if (str == "")
        {
            JavaScript.Alert(this.Page, "地址构建出现错误");
        }
        else
        {
            base.Response.Write("<script language='javascript'>window.top.location.href='" + str + "'</script>");
        }
    }

    protected void BankClick(string BankCode)
    {
        string str = new Shove.Alipay.Alipay().CreatUrl(this.gateway, this.service, this.partner, this.return_url, this.notify_url, this.out_trade_no, this.subject, this.payment_type, this.total_fee, this.seller_email, this.key, this._input_charset, this.sign_type, new string[] { "body", this.body, "defaultbank", BankCode, "paymethod", this.paymethod });
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
        if (WebConfig.GetAppSettingsInt("OnlinePayType", 2) == 2)
        {
            base.Response.Redirect("../Alipay02/Default.aspx", true);
        }
        else
        {
            double num2 = _Convert.StrToDouble(Utility.GetRequest("PayMoney"), 0.0);
            string request = Utility.GetRequest("BankCode");
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
                this.return_url = Utility.GetUrl() + "/Home/Room/OnlinePay/Alipay01/Receive.aspx";
                this.notify_url = Utility.GetUrl() + "/Home/Room/OnlinePay/Alipay01/AlipayNotify.aspx";
                this.partner = this.so["OnlinePay_Alipay_UserNumber"].ToString("");
                this.show_url = "http://www.alipay.com";
                this.seller_email = this.so["OnlinePay_Alipay_UserName"].ToString("");
                this.key = this.so["OnlinePay_Alipay_MD5Key"].ToString("");
                this.paymethod = "bankPay";
                this.buyer_email = base._User.Email;
                this.subject = Encrypt.EncryptString(PF.GetCallCert(), base._User.ID.ToString());
                this.body = "TicketMoney";
                double num6 = Convert.ToDouble(num2.ToString());
                this.total_fee = num6.ToString();
                long newPayNumber = -1L;
                string returnDescription = "";
                if (Procedures.P_GetNewPayNumber(base._Site.ID, base._User.ID, "Alipay", num6 - formalitiesFees, formalitiesFees, ref newPayNumber, ref returnDescription) < 0)
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
                        this.AlipayPay();
                    }
                    else
                    {
                        this.BankClick(request);
                    }
                }
            }
        }
    }

 
}

