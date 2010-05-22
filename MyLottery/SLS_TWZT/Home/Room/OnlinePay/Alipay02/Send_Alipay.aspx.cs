using ASP;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_OnlinePay_Alipay02_Send_Alipay : RoomPageBase, IRequiresSessionState
{
    public string Balance;
    public string BankName;

    public long BuyID;

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
            if (this.radZFB.Checked)
            {
                this.BankName = "zfb";
                this.hdBankCode.Value = "alipay";
            }
            else if (this.radICBCB2C.Checked)
            {
                this.BankName = "hsyh";
                this.hdBankCode.Value = "ICBCB2C";
            }
            else if (this.radGDB.Checked)
            {
                this.BankName = "gdfzyh";
                this.hdBankCode.Value = "GDB";
            }
            else if (this.radGDYH.Checked)
            {
                this.BankName = "gdyh";
                this.hdBankCode.Value = "CEBBANK";
            }
            else if (this.radCCB.Checked)
            {
                this.BankName = "jsyh";
                this.hdBankCode.Value = "CCB";
            }
            else if (this.radCOMM.Checked)
            {
                this.BankName = "jtyh";
                this.hdBankCode.Value = "COMM";
            }
            else if (this.radABC.Checked)
            {
                this.BankName = "nyyh";
                this.hdBankCode.Value = "ABC";
            }
            else if (this.radSPDB.Checked)
            {
                this.BankName = "shpd";
                this.hdBankCode.Value = "SPDB";
            }
            else if (this.radSDB.Checked)
            {
                this.BankName = "szfzyh";
                this.hdBankCode.Value = "SDB";
            }
            else if (this.radCIB.Checked)
            {
                this.BankName = "xyyh";
                this.hdBankCode.Value = "CIB";
            }
            else if (this.radHZCBB2C.Checked)
            {
                this.BankName = "hzyh";
                this.hdBankCode.Value = "HZCBB2C";
            }
            else if (this.radCMBC.Checked)
            {
                this.BankName = "zgms";
                this.hdBankCode.Value = "CMBC";
            }
            else if (this.radBOCB2C.Checked)
            {
                this.BankName = "zgyh";
                this.hdBankCode.Value = "BOCB2C";
            }
            else if (this.radCMB.Checked)
            {
                this.BankName = "zsyhj";
                this.hdBankCode.Value = "CMB";
            }
            else if (this.radCITIC.Checked)
            {
                this.BankName = "zxyh";
                this.hdBankCode.Value = "CITIC";
            }
            if (this.hdBankCode.Value == "")
            {
                JavaScript.Alert(this.Page, "请选择银行，谢谢！");
            }
            else
            {
                this.hlOK.NavigateUrl = "Send2.aspx?PayMoney=" + text + "&bankPay=" + this.hdBankCode.Value + "&BuyID=" + this.BuyID.ToString();
                this.pnlFirst.Visible = false;
                this.pnlSecond.Visible = true;
            }
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
        if (base._User != null)
        {
            this.Balance = base._User.Balance.ToString();
            this.UserName = base._User.Name.ToString();
        }
        if (WebConfig.GetAppSettingsInt("OnlinePayType", 2) == 1)
        {
            base.Response.Redirect("../Alipay01/Default.aspx", true);
        }
    }

 
}

