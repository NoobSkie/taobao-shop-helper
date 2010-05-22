using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_Tenpay_Receive : RoomPageBase, IRequiresSessionState
{
    private string attach = "";
    private string bankPay = "0";
    private string bargainor_id = "";
    private long buyId;
    private const int cmdno = 1;
    private string date = "";
    private int fee_type;
    private string key = "";
    private double Money;
    private int pay_result;
    private string payerrmsg = "";
    public const int PAYERROR = 3;
    public const int PAYMD5ERROR = 2;
    public const int PAYOK = 0;
    public const int PAYSPERROR = 1;
    private SystemOptions so = new SystemOptions();
    private string sp_billno = "";
    private long total_fee;
    private string transaction_id = "";
    private long userId = -1L;

    private string getBankName(string bankCode)
    {
        switch (bankCode.ToLower())
        {
            case "0":
                return "财付通";

            case "1001":
                return "招商银行";

            case "1002":
                return "中国工商银行";

            case "1003":
                return "中国建设银行";

            case "1004":
                return "上海浦东发展银行";

            case "1005":
                return "中国农业银行";

            case "1006":
                return "中国民生银行";

            case "1008":
                return "深圳发展银行";

            case "1009":
                return "兴业银行";

            case "1028":
                return "广州银联";

            case "1032":
                return "   北京银行";

            case "1020":
                return "   中国交通银行";

            case "1022":
                return "   中国光大银行";
        }
        return "财付通";
    }

    private string GetMD5(string encypStr)
    {
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
        return BitConverter.ToString(provider.ComputeHash(bytes)).Replace("-", "").ToUpper();
    }

    private string GetPayResultSign()
    {
        string encypStr = string.Concat(new object[] { 
            "cmdno=", 1, "&pay_result=", this.pay_result, "&date=", this.date, "&transaction_id=", this.transaction_id, "&sp_billno=", this.sp_billno, "&total_fee=", this.total_fee, "&fee_type=", this.fee_type, "&attach=", this.UrlEncode(this.attach), 
            "&key=", this.key
         });
        return this.GetMD5(encypStr);
    }

    private bool GetPayValueFromUrl(NameValueCollection querystring, out string errmsg)
    {
        if ((querystring == null) || (querystring.Count == 0))
        {
            errmsg = "参数为空";
            return false;
        }
        if (querystring["cmdno"] != null)
        {
            int num = 1;
            if (!(querystring["cmdno"].ToString().Trim() != num.ToString()))
            {
                goto Label_005B;
            }
        }
        errmsg = "没有cmdno参数或cmdno参数不正确";
        return false;
    Label_005B:
        if (querystring["pay_result"] == null)
        {
            errmsg = "没有pay_result参数";
            return false;
        }
        if (querystring["date"] == null)
        {
            errmsg = "没有date参数";
            return false;
        }
        if (querystring["pay_info"] == null)
        {
            errmsg = "没有pay_info参数";
            return false;
        }
        if (querystring["bargainor_id"] == null)
        {
            errmsg = "没有bargainor_id参数";
            return false;
        }
        if (querystring["transaction_id"] == null)
        {
            errmsg = "没有transaction_id参数";
            return false;
        }
        if (querystring["sp_billno"] == null)
        {
            errmsg = "没有sp_billno参数";
            return false;
        }
        if (querystring["total_fee"] == null)
        {
            errmsg = "没有total_fee参数";
            return false;
        }
        if (querystring["fee_type"] == null)
        {
            errmsg = "没有fee_type参数";
            return false;
        }
        if (querystring["attach"] == null)
        {
            errmsg = "没有attach参数";
            return false;
        }
        if (querystring["sign"] == null)
        {
            errmsg = "没有sign参数";
            return false;
        }
        errmsg = "";
        try
        {
            this.pay_result = int.Parse(querystring["pay_result"].Trim());
            this.payerrmsg = UrlDecode(querystring["pay_info"].Trim());
            this.date = querystring["date"];
            this.transaction_id = querystring["transaction_id"];
            this.sp_billno = querystring["sp_billno"];
            this.total_fee = _Convert.StrToLong(querystring["total_fee"], 0L);
            this.fee_type = _Convert.StrToInt(querystring["fee_type"], 0);
            this.attach = UrlDecode(querystring["attach"]);
            this.userId = _Convert.StrToLong(Encrypt.UnEncryptString(PF.GetCallCert(), this.attach).Split(new char[] { '|' })[0], -1L);
            this.bankPay = Encrypt.UnEncryptString(PF.GetCallCert(), this.attach).Split(new char[] { '|' })[1];
            this.buyId = _Convert.StrToLong(Encrypt.UnEncryptString(PF.GetCallCert(), this.attach).Split(new char[] { '|' })[2], -1L);
            this.Money = _Convert.StrToDouble(querystring["total_fee"], 0.0) / 100.0;
            if (querystring["bargainor_id"] != this.bargainor_id)
            {
                this.pay_result = 1;
                return true;
            }
            string str = querystring["sign"];
            if (this.GetPayResultSign() != str)
            {
                this.pay_result = 2;
            }
            return true;
        }
        catch (Exception exception)
        {
            errmsg = "解析参数出错:" + exception.Message;
            return false;
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.isRequestLogin = false;
        base.isAllowPageCache = false;
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string errmsg = "";
            this.key = this.so["OnlinePay_Tenpay_MD5Key"].Value.ToString();
            this.bargainor_id = this.so["OnlinePay_Tenpay_UserNumber"].Value.ToString();
            if (this.GetPayValueFromUrl(base.Request.QueryString, out errmsg))
            {
                if (this.pay_result == 0)
                {
                    Users users = new Users(base._Site.ID)[base._Site.ID, this.userId];
                    if (users == null)
                    {
                        errmsg = "在线支付：异常用户数据！ 支付号：" + this.sp_billno;
                        base.Response.Write(errmsg + "<br/>");
                    }
                    else
                    {
                        if (base._User == null)
                        {
                            base._User = new Users(base._Site.ID)[base._Site.ID, users.ID];
                            string returnDescription = "";
                            base._User.LoginDirect(ref returnDescription);
                        }
                        if (this.WriteUserAccount("系统交易号：" + this.sp_billno + " 财付通交易号：" + this.transaction_id))
                        {
                            string s = "<meta content=\"China TENCENT\" name=\"TENCENT_ONLINE_PAYMENT\">\n<script language=\"javascript\">\nwindow.location.href='" + Utility.GetUrl() + "/Home/Room/OnlinePay/OK.aspx?BuyID=" + this.buyId.ToString() + "';\n</script>";
                            errmsg = "在线支付：获取通知并处理成功！ 支付号：" + this.sp_billno;
                            base.Response.Write(s);
                        }
                        else
                        {
                            errmsg = "在线支付：写入返回数据出错！ 支付号：" + this.sp_billno;
                            base.Response.Write(errmsg + "<br/>");
                        }
                    }
                }
                else
                {
                    errmsg = "在线支付：验证出错！商户或者密串有误，错误代码：" + this.pay_result.ToString() + " 支付号：" + this.sp_billno;
                    base.Response.Write(errmsg + "<br/>");
                }
            }
            else
            {
                errmsg = "认证签名失败";
                base.Response.Write("认证签名失败<br/>");
            }
        }
        catch
        {
            base.Response.Write("支付失败<br/>");
        }
    }

    private static string UrlDecode(string instr)
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

    private bool WriteUserAccount(string Memo)
    {
        if (this.Money == 0.0)
        {
            return false;
        }
        double num = this.so["OnlinePay_Tenpay_PayFormalitiesFeesScale"].ToDouble(0.0) / 100.0;
        double formalitiesFees = this.Money - Math.Round((double)(this.Money / (num + 1.0)), 2);
        this.Money -= formalitiesFees;
        string returnDescription = "";
        bool flag = base._User.AddUserBalance(this.Money, formalitiesFees, this.sp_billno, this.getBankName(this.bankPay), Memo, ref returnDescription) == 0;
        if (flag)
        {
            return flag;
        }
        DataTable table = new Tables.T_UserPayDetails().Open("Result", "[id] = " + _Convert.StrToLong(this.sp_billno, 0L).ToString(), "");
        if ((table == null) || (table.Rows.Count == 0))
        {
            return false;
        }
        return (_Convert.StrToInt(table.Rows[0][0].ToString(), 0) == 1);
    }
}

