using ASP;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_OnlinePay_Alipay02_Send_007Ka : RoomPageBase, IRequiresSessionState
{
    public string BankName;
 
    public long BuyID;

    public double Money;

    public double RealPayMoney;
    private SystemOptions so = new SystemOptions();

    protected void btnNext_Click(object sender, EventArgs e)
    {
        string text = this.PayMoney.Text;
        if (_Convert.StrToDouble(text, 0.0) <= 0.0)
        {
            JavaScript.Alert(this.Page, "请输入正确的充值金额！再提交，谢谢！");
        }
        else if (_Convert.StrToDouble(text, 0.0) < 2.0)
        {
            JavaScript.Alert(this.Page, "存入金额最少2元, 请输入正确的充值金额！再提交，谢谢！");
        }
        else
        {
            this.lbPayMoney.Text = this.PayMoney.Text;
            this.BankName = "007Ka";
            base.Response.Redirect("../007ka/default.aspx?cardno=007Ka&BuyID=" + this.BuyID.ToString());
            this.pnlFirst.Visible = false;
            this.pnlSecond.Visible = true;
        }
    }

    protected void lbReturn_Click(object sender, EventArgs e)
    {
        this.pnlFirst.Visible = true;
        this.pnlSecond.Visible = false;
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
        this.BuyID = _Convert.StrToLong(Utility.GetRequest("BuyID"), 0L);
        if (WebConfig.GetAppSettingsInt("OnlinePayType", 2) == 1)
        {
            base.Response.Redirect("../Alipay01/Default.aspx", true);
        }
    }

 
}

