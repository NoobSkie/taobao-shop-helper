using ASP;
using DAL;
using Shove;
using Shove._Web;
using System;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_007ka_Send : RoomPageBase, IRequiresSessionState
{
    public string amount = "";
    public string backUrl = "";
    public long BuyID;
    public string curId = "";
    public string hmac = "";
    private string key = "";
    public string meraccount = "";
    public string merchantId = "";
    public string merName = "";
    public string orderDate = "";
    public string orderId = "";
    public string payInterfaceId = "";
    public string productDesc = "";
    public string productName = "";
    public string reserved = "";
    private SystemOptions so = new SystemOptions();
    public string type = "";
    public string version = "";

    private string GetMD5(string encypStr)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(encypStr, "MD5").ToUpper();
    }

    private string GetSignString()
    {
        return (this.type + "|" + this.version + "|" + this.merchantId + "|" + this.meraccount + "|" + this.orderId + "|" + this.orderDate + "|" + this.amount + "|" + this.curId + "|" + this.payInterfaceId + "|" + this.productName + "|" + this.productDesc + "|" + this.reserved + "|" + this.merName + "|" + this.backUrl + "|" + this.key);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string request = Utility.GetRequest("cardno");
        this.amount = Utility.GetRequest("ordermoney");
        if (!base.IsPostBack)
        {
            this.BuyID = _Convert.StrToLong(Utility.GetRequest("BuyID"), 0L);
            long newPayNumber = -1L;
            string returnDescription = "";
            try
            {
                if (Procedures.P_GetNewPayNumber(base._Site.ID, base._User.ID, "007Ka_" + request, _Convert.StrToDouble(this.amount, 0.0), (this.so["OnlinePay_007Ka_FormalitiesFees"].ToDouble(0.0) / 100.0) * _Convert.StrToDouble(this.amount, 0.0), ref newPayNumber, ref returnDescription) < 0)
                {
                    PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                    return;
                }
                if ((newPayNumber < 0L) || (returnDescription != ""))
                {
                    PF.GoError(1, returnDescription, base.GetType().BaseType.FullName);
                    return;
                }
                this.orderId = newPayNumber.ToString();
            }
            catch
            {
                new Log("OnlinePay").Write("007在线充值：充值未完成。错误描述：生成订单号出现错误.");
                PF.GoError(4, "数据库繁忙，生成订单号出错，请重试", base.GetType().BaseType.FullName);
                return;
            }
            this.SettingParam();
            this.SettingURLEncode();
        }
    }

    private void SettingParam()
    {
        this.type = "PAY";
        this.version = "1.0.0";
        this.merchantId = this.so["OnlinePay_007Ka_MerchantId"].ToString("").Trim();
        this.meraccount = this.so["OnlinePay_007Ka_MerAccount"].ToString("").Trim();
        this.orderDate = DateTime.Now.ToString("yyyyMMddHHmmss");
        this.curId = "CNY";
        this.payInterfaceId = "SZXPAY";
        this.productName = HttpUtility.UrlEncode("<%=_Site.Name %>充值", Encoding.GetEncoding("GB2312"));
        this.productDesc = HttpUtility.UrlEncode("<%=_Site.Name %>上短信代投注系统充值", Encoding.GetEncoding("GB2312"));
        this.reserved = Utility.GetRequest("BuyID");
        this.merName = HttpUtility.UrlEncode("<%=_Site.Url %>", Encoding.GetEncoding("GB2312"));
        this.backUrl = Utility.GetUrl() + "/Home/Room/OnlinePay/007ka/Receive1.aspx";
        this.key = this.so["OnlinePay_007Ka_Key"].ToString("").Trim();
        this.hmac = this.GetMD5(this.GetSignString());
    }

    private void SettingURLEncode()
    {
        this.type = base.Server.UrlEncode(this.type);
        this.version = base.Server.UrlEncode(this.version);
        this.merchantId = base.Server.UrlEncode(this.merchantId);
        this.meraccount = base.Server.UrlEncode(this.meraccount);
        this.orderId = base.Server.UrlEncode(this.orderId);
        this.orderDate = base.Server.UrlEncode(this.orderDate);
        this.amount = base.Server.UrlEncode(this.amount);
        this.curId = base.Server.UrlEncode(this.curId);
        this.payInterfaceId = base.Server.UrlEncode(this.payInterfaceId);
        this.productName = base.Server.UrlEncode(this.productName);
        this.productDesc = base.Server.UrlEncode(this.productDesc);
        this.reserved = base.Server.UrlEncode(this.reserved);
        this.merName = base.Server.UrlEncode(this.merName);
        this.backUrl = base.Server.UrlEncode(this.backUrl);
        this.hmac = base.Server.UrlEncode(this.hmac);
    }

  
}

