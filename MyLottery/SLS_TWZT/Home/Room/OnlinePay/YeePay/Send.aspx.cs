using ASP;
using com.yeepay.bank;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using System;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_YeePay_Send : RoomPageBase, IRequiresSessionState
{
    public string htmlCodeGet;
    public string htmlCodePost;
    private static string keyValue;
    private static string p1_MerId;
    private string p2_Order;
    private string p3_Amt;
    private string p4_Cur;
    private string p5_Pid;
    private string p6_Pcat;
    private string p7_Pdesc;
    private string p8_Url;
    private string p9_SAF;
    private string pa_MP;
    private string pd_FrpId;
    private string pr_NeedResponse;
    private SystemOptions so = new SystemOptions();

    protected void Page_Load(object sender, EventArgs e)
    {
        Buy.LogFileName = "c:/YeePay_HTML.txt";
        base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
        p1_MerId = this.so["OnlinePay_YeePay_UserNumber"].Value.ToString();
        keyValue = this.so["OnlinePay_YeePay_MD5Key"].Value.ToString();
        Buy.NodeAuthorizationURL = "https://www.yeepay.com/app-merchant-proxy/node";
        this.p3_Amt = Utility.GetRequest("PayMoney");
        long newPayNumber = -1L;
        string returnDescription = "";
        if (Procedures.P_GetNewPayNumber(base._Site.ID, base._User.ID, "yeepay", (double)_Convert.StrToLong(this.p3_Amt, 0L), 0.0, ref newPayNumber, ref returnDescription) < 0)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else if ((newPayNumber < 0L) || (returnDescription != ""))
        {
            PF.GoError(1, returnDescription, base.GetType().BaseType.FullName);
        }
        else
        {
            this.p2_Order = newPayNumber.ToString();
            this.p4_Cur = "CNY";
            this.p5_Pid = "";
            this.p6_Pcat = "";
            this.p7_Pdesc = "";
            this.p8_Url = Utility.GetUrl() + "/Home/Room/OnlinePay/YeePay/Receive.aspx";
            this.p9_SAF = "0";
            this.pa_MP = Encrypt.EncryptString(PF.GetCallCert(), base._User.ID.ToString());
            this.pd_FrpId = "";
            this.pr_NeedResponse = "0";
            this.htmlCodeGet = Buy.CreateBuyUrl(p1_MerId, keyValue, this.p2_Order, this.p3_Amt, this.p4_Cur, this.p5_Pid, this.p6_Pcat, this.p7_Pdesc, this.p8_Url, this.p9_SAF, this.pa_MP, this.pd_FrpId, this.pr_NeedResponse);
            base.Response.Redirect(this.htmlCodeGet);
        }
    }
}

