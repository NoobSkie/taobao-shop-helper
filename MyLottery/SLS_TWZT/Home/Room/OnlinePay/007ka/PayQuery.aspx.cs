using ASP;
using Shove._Web;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_007ka_PayQuery : RoomPageBase, IRequiresSessionState
{
    private string Attach = "";
    private string Command = "1";

    private string InterfaceName = "007KA_SRH";
    private string InterfaceNumber = "1.0.0.1";
    private string key = "";
    private string MerAccount = "";
    private string MerID = "";
    private string MerURL = "";
    private string OrderID = "";
    public string Orderinfo = "";
    private string ReplyFormat = "xml";
    public string Sign = "";

    private string GetMD5(string encypStr)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(encypStr, "MD5").ToUpper();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SystemOptions options = new SystemOptions();
        this.MerID = options["OnlinePay_007Ka_MerchantId"].ToString("").Trim();
        this.MerAccount = options["OnlinePay_007Ka_MerAccount"].ToString("").Trim();
        this.OrderID = Utility.GetRequest("OrderID");
        this.key = options["OnlinePay_007Ka_Key"].ToString("").Trim();
        this.MerURL = Utility.GetUrl() + "/Home/Room/OnlinePay/007ka/QueryResult.aspx";
        this.Attach = this.MerURL;
        this.SettingOrderInfo();
        this.Sign = this.GetMD5(this.Orderinfo + "|" + this.key);
        string str = HttpUtility.UrlEncode(PF.GetHtml("http://www.007ka.cn/interface/cardpay/query.php?Orderinfo=" + this.Orderinfo + "&Sign=" + this.Sign, "GBK", 1));
        base.Response.Redirect("QueryResult.aspx?Orderinfo=" + str, true);
    }

    private void SettingOrderInfo()
    {
        this.Orderinfo = this.MerID + "|" + this.MerAccount + "|" + this.OrderID + "|" + this.ReplyFormat + "|" + this.Command + "|" + this.InterfaceName + "|" + this.InterfaceNumber + "|" + this.MerURL + "|" + this.Attach;
    }

 
}

