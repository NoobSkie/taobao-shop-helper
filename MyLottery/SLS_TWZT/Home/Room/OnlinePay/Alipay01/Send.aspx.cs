using ASP;
using Shove;
using Shove._Web;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_OnlinePay_Alipay01_Send : RoomPageBase, IRequiresSessionState
{
    public string Balance;
    public double Money;
    public string OnlinePay_99Bill_HomePage = "";
    public string OnlinePay_99Bill_Status = "";
    public string OnlinePay_99Bill_Target = "_self";
    public string OnlinePay_Alipay_HomePage = "";
    public string OnlinePay_Alipay_Status = "";
    public string OnlinePay_Alipay_Target = "_self";
    public string OnlinePay_CBPayMent_HomePage = "";
    public string OnlinePay_CBPayMent_Status = "";
    public string OnlinePay_CBPayMent_Target = "_self";
    public string OnlinePay_CMBChina_HomePage = "";
    public string OnlinePay_CMBChina_Status = "";
    public string OnlinePay_CMBChina_Target = "_self";
    public string OnlinePay_CnCard_HomePage = "";
    public string OnlinePay_CnCard_Status = "";
    public string OnlinePay_CnCard_Target = "_self";
    public string OnlinePay_ICBC_HomePage = "";
    public string OnlinePay_ICBC_Status = "";
    public string OnlinePay_ICBC_Target = "_self";
    public string OnlinePay_Tenpay_HomePage = "";
    public string OnlinePay_Tenpay_Status = "";
    public string OnlinePay_Tenpay_Target = "_self";

    public double RealPayMoney;

    private SystemOptions so = new SystemOptions();
    public string UserName;

    private void BindDataForPayList(double Money)
    {
        Money.ToString();
        this.hl1.NavigateUrl = "Send2.aspx?PayMoney=" + Money.ToString() + "&BankCode=Alipay";
        this.hl2.NavigateUrl = "Send2.aspx?PayMoney=" + Money.ToString() + "&BankCode=Alipay";
        this.hl3.NavigateUrl = "Send2.aspx?PayMoney=" + Money.ToString() + "&BankCode=ICBCB2C";
        this.hl4.NavigateUrl = "Send2.aspx?PayMoney=" + Money.ToString() + "&BankCode=CMB";
        this.hl5.NavigateUrl = "Send2.aspx?PayMoney=" + Money.ToString() + "&BankCode=CCB";
        this.hl6.NavigateUrl = "Send2.aspx?PayMoney=" + Money.ToString() + "&BankCode=ABC";
        this.hl7.NavigateUrl = "Send2.aspx?PayMoney=" + Money.ToString() + "&BankCode=SPDB";
        this.hl8.NavigateUrl = "Send2.aspx?PayMoney=" + Money.ToString() + "&BankCode=CIB";
        this.hl9.NavigateUrl = "Send2.aspx?PayMoney=" + Money.ToString() + "&BankCode=GDB";
        this.hl10.NavigateUrl = "Send2.aspx?PayMoney=" + Money.ToString() + "&BankCode=SDB";
        this.hl11.NavigateUrl = "Send2.aspx?PayMoney=" + Money.ToString() + "&BankCode=CMBC";
        this.hl12.NavigateUrl = "Send2.aspx?PayMoney=" + Money.ToString() + "&BankCode=COMM";
        this.hl13.NavigateUrl = "Send2.aspx?PayMoney=" + Money.ToString() + "&BankCode=POSTGC";
        this.hl14.NavigateUrl = "Send2.aspx?PayMoney=" + Money.ToString() + "&BankCode=CITIC";
    }

    protected void btnHiddenClick_Click(object sender, EventArgs e)
    {
        this.BindDataForPayList(double.Parse(this.RealPayMoneyValue.Value));
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
        if (base._User != null)
        {
            this.Balance = base._User.Balance.ToString();
            this.UserName = base._User.Name.ToString();
        }
        this.so["OnlinePay_Alipay_Status_ON"].ToBoolean(false);
        if (WebConfig.GetAppSettingsInt("OnlinePayType", 2) == 2)
        {
            base.Response.Redirect("../Alipay02/Default.aspx", true);
        }
        else
        {
            this.Money = _Convert.StrToDouble(this.PayMoney.Text, 0.0);
            this.RealPayMoney = this.Money;
            double num2 = this.so["OnlinePay_Alipay_PayFormalitiesFeesScale"].ToDouble(0.0) / 100.0;
            double num3 = Math.Round((double)(this.Money * num2), 2);
            this.Money += num3;
            this.PayMoney.Text = this.Money.ToString();
            this.BindDataForPayList(this.RealPayMoney);
            string text1 = "金额：" + ((this.Money - num3)).ToString() + " ";
        }
    }

  
}

