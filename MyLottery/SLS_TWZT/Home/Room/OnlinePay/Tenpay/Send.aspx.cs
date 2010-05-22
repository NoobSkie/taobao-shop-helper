using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_Tenpay_Send : RoomPageBase, IRequiresSessionState
{
    private string attach = "";
    private string bankPay = "0";
    private string bargainor_id = "";
    private const int cmdno = 1;
    private string date = DateTime.Now.ToString("yyyyMMdd");
    private string desc = "";
    private int fee_type = 1;
    private string key = "";
    private double Money;
    private string paygateurl = "https://www.tenpay.com/cgi-bin/v1.0/pay_gate.cgi";
    private string purchaser_id = "";
    private string return_url = "";
    private SystemOptions so = new SystemOptions();
    private string sp_billno = "";
    private string spbill_create_ip = "";
    private long total_fee;
    private string transaction_id = "";

    private string CreatePayNumber(long Number)
    {
        string str = Number.ToString().PadLeft(10, '0');
        str = str.Substring(str.Length - 10);
        return (this.bargainor_id + this.date + str);
    }

    private string GetMD5(string encypStr)
    {
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
        return BitConverter.ToString(provider.ComputeHash(bytes)).Replace("-", "").ToUpper();
    }

    private string GetPaySign()
    {
        string encypStr = string.Concat(new object[] { 
            "cmdno=", 1, "&date=", this.date, "&bargainor_id=", this.bargainor_id, "&transaction_id=", this.transaction_id, "&sp_billno=", this.sp_billno, "&total_fee=", this.total_fee, "&fee_type=", this.fee_type, "&return_url=", this.return_url, 
            "&attach=", this.UrlEncode(this.attach)
         });
        if (this.spbill_create_ip != "")
        {
            encypStr = encypStr + "&spbill_create_ip=" + this.spbill_create_ip;
        }
        encypStr = encypStr + "&key=" + this.key;
        return this.GetMD5(encypStr);
    }

    private bool GetPayUrl(out string url)
    {
        try
        {
            string paySign = this.GetPaySign();
            url = string.Concat(new object[] { 
                this.paygateurl, "?cmdno=", 1, "&date=", this.date, "&bank_type=", this.bankPay, "&desc=", this.desc, "&purchaser_id=", this.purchaser_id, "&bargainor_id=", this.bargainor_id, "&transaction_id=", this.transaction_id, "&sp_billno=", 
                this.sp_billno, "&total_fee=", this.total_fee, "&fee_type=", this.fee_type, "&return_url=", this.return_url, "&attach=", this.UrlEncode(this.attach)
             });
            if (this.spbill_create_ip != "")
            {
                url = url + "&spbill_create_ip=" + this.spbill_create_ip;
            }
            url = url + "&sign=" + paySign;
            return true;
        }
        catch (Exception exception)
        {
            url = "创建URL时出错,错误信息:" + exception.Message;
            return false;
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
        this.so["OnlinePay_Tenpay_Status_ON"].ToBoolean(false);
        this.Money = _Convert.StrToDouble(Utility.GetRequest("PayMoney"), 0.0);
        this.bankPay = Utility.GetRequest("bankPay");
        if (!base.IsPostBack)
        {
            if (base._User.Competences.CompetencesList.IndexOf("Administrator") > 0)
            {
                if (this.Money < 0.01)
                {
                    base.Response.Write("<script type=\"text/javascript\">alert(\"请输入正确的充值金额！再提交，谢谢！\"); window.close();</script>");
                    return;
                }
            }
            else if (this.Money < 1.0)
            {
                base.Response.Write("<script type=\"text/javascript\">alert(\"请输入正确的充值金额！再提交，谢谢！\"); window.close();</script>");
                return;
            }
            double num = this.so["OnlinePay_Tenpay_PayFormalitiesFeesScale"].ToDouble(0.0) / 100.0;
            double formalitiesFees = Math.Round((double)(this.Money * num), 2);
            this.Money += formalitiesFees;
            this.bargainor_id = this.so["OnlinePay_Tenpay_UserNumber"].Value.ToString();
            this.key = this.so["OnlinePay_Tenpay_MD5Key"].Value.ToString();
            this.desc = HttpUtility.UrlEncode("预付款", Encoding.GetEncoding("GBK"));
            this.total_fee = long.Parse((this.Money * 100.0).ToString());
            this.purchaser_id = "";
            this.return_url = Utility.GetUrl() + "/Home/Room/OnlinePay/Tenpay/Receive.aspx";
            this.attach = Encrypt.EncryptString(PF.GetCallCert(), base._User.ID.ToString() + "|" + this.bankPay + "|" + Utility.GetRequest("BuyID"));
            double num5 = Convert.ToDouble(this.Money.ToString());
            long newPayNumber = -1L;
            string returnDescription = "";
            if (Procedures.P_GetNewPayNumber(base._Site.ID, base._User.ID, "TENPAY_" + this.bankPay, num5 - formalitiesFees, formalitiesFees, ref newPayNumber, ref returnDescription) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else if ((newPayNumber < 0L) || (returnDescription != ""))
            {
                PF.GoError(1, returnDescription, base.GetType().BaseType.FullName);
            }
            else
            {
                this.sp_billno = newPayNumber.ToString();
                this.transaction_id = this.CreatePayNumber(newPayNumber);
                this.spbill_create_ip = "";
                if (((string.IsNullOrEmpty(this.bankPay) || string.IsNullOrEmpty(this.desc)) || (string.IsNullOrEmpty(this.bargainor_id) || string.IsNullOrEmpty(this.transaction_id))) || ((string.IsNullOrEmpty(this.sp_billno) || string.IsNullOrEmpty(this.return_url)) || string.IsNullOrEmpty(this.attach)))
                {
                    base.Response.Write("<script type=\"text/javascript\">alert(\"参数不齐全，无法充值！\"); window.close();</script>");
                }
                else
                {
                    string url = "";
                    if (!this.GetPayUrl(out url))
                    {
                        base.Response.Write("<script type=\"text/javascript\">alert(\"" + url + "\"); window.close();</script>");
                    }
                    else
                    {
                        base.Response.Write("<script language='javascript'>window.top.location.href='" + url + "'</script>");
                    }
                }
            }
        }
    }

    private string UrlDecode(string instr)
    {
        if ((instr != null) && !(instr.Trim() == ""))
        {
            return instr.Replace("%3d", "=").Replace("%26", "&").Replace("%22", "\"").Replace("%3f", "?").Replace("%27", "'").Replace("%20", " ").Replace("%25", "%");
        }
        return "";
    }

    private string UrlEncode(string instr)
    {
        if ((instr != null) && !(instr.Trim() == ""))
        {
            return instr.Replace("%", "%25").Replace("=", "%3d").Replace("&", "%26").Replace("\"", "%22").Replace("?", "%3f").Replace("'", "%27").Replace(" ", "%20");
        }
        return "";
    }
}

