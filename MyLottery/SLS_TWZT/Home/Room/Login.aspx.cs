using ASP;
using Shove._Web;
using Shove.Alipay;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class Home_Room_Login : Page, IRequiresSessionState
{

    protected void Page_Load(object sender, EventArgs e)
    {
        SystemOptions options = new SystemOptions();
        string key = options["MemberSharing_Alipay_MD5"].ToString("");
        string str2 = Utility.GetUrl() + "/Home/Room/Receive.aspx?" + HttpUtility.UrlEncode("BuyID=" + base.Request["BuyID"]);
        string gateway = options["MemberSharing_Alipay_Gateway"].ToString("");
        string str4 = "utf-8";
        string service = "user_authentication";
        string str6 = "MD5";
        string partner = options["MemberSharing_Alipay_UserNumber"].ToString("");
        string returnUrl = str2;
        string url = new Shove.Alipay.Alipay().CreatUrl(gateway, service, partner, str6, key, str2, str4, returnUrl);
        base.Response.Redirect(url, true);
    }
}

