using AjaxPro;
using ASP;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_OnlinePay_Alipay02_Send1 : RoomPageBase, IRequiresSessionState
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
            else if (this.radCFT.Checked)
            {
                this.BankName = "cft";
                this.hdBankCode.Value = "0";
            }
            else if (this.radICBCB2C.Checked)
            {
                this.BankName = "hsyh";
                this.hdBankCode.Value = "1002";
            }
            else if (this.radGDB.Checked)
            {
                this.BankName = "gdfzyh";
                this.hdBankCode.Value = "GDB";
            }
            else if (this.radGDYH.Checked)
            {
                this.BankName = "gdyh";
                this.hdBankCode.Value = "1022";
            }
            else if (this.radCCB.Checked)
            {
                this.BankName = "jsyh";
                this.hdBankCode.Value = "1003";
            }
            else if (this.radCOMM.Checked)
            {
                this.BankName = "jtyh";
                this.hdBankCode.Value = "1020";
            }
            else if (this.radABC.Checked)
            {
                this.BankName = "nyyh";
                this.hdBankCode.Value = "1005";
            }
            else if (this.radSPDB.Checked)
            {
                this.BankName = "shpd";
                this.hdBankCode.Value = "1004";
            }
            else if (this.radSDB.Checked)
            {
                this.BankName = "szfzyh";
                this.hdBankCode.Value = "1008";
            }
            else if (this.radCIB.Checked)
            {
                this.BankName = "xyyh";
                this.hdBankCode.Value = "1009";
            }
            else if (this.radCMBC.Checked)
            {
                this.BankName = "zgms";
                this.hdBankCode.Value = "1006";
            }
            else if (this.radBOCB2C.Checked)
            {
                this.BankName = "zgyh";
                this.hdBankCode.Value = "BOCB2C";
            }
            else if (this.radCMB.Checked)
            {
                this.BankName = "zsyhj";
                this.hdBankCode.Value = "1001";
            }
            else if (this.radBCCBEB.Checked)
            {
                this.BankName = "bjyh";
                this.hdBankCode.Value = "1032";
            }
            else
            {
                if (this.radszx.Checked)
                {
                    base.Response.Redirect("../ZhiFuKa/default.aspx?cardno=szx&BuyID=" + this.BuyID.ToString());
                    return;
                }
                if (this.radzfk.Checked)
                {
                    base.Response.Redirect("../ZhiFuKa/default.aspx?cardno=zfk&BuyID=" + this.BuyID.ToString());
                    return;
                }
                if (this.rad007Ka.Checked)
                {
                    base.Response.Redirect("../007ka/default.aspx?cardno=007Ka&BuyID=" + this.BuyID.ToString());
                    return;
                }
            }
            if (this.hdBankCode.Value == "")
            {
                JavaScript.Alert(this.Page, "请选择银行，谢谢！");
            }
            else
            {
                if (_Convert.StrToInt(this.hdBankCode.Value, -1) == -1)
                {
                    this.hlOK.NavigateUrl = "Send2.aspx?PayMoney=" + text + "&bankPay=" + this.hdBankCode.Value + "&BuyID=" + this.BuyID.ToString();
                }
                else
                {
                    this.hlOK.NavigateUrl = "../Tenpay/Send.aspx?PayMoney=" + text + "&bankPay=" + this.hdBankCode.Value + "&BuyID=" + this.BuyID.ToString();
                }
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
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Home_Room_OnlinePay_Alipay02_Send1), this.Page);
        if (base._User != null)
        {
            this.Balance = base._User.Balance.ToString();
            this.UserName = base._User.Name.ToString();
        }
        if (WebConfig.GetAppSettingsInt("OnlinePayType", 2) == 1)
        {
            base.Response.Redirect("../Alipay01/Default.aspx", true);
        }
        else
        {
            this.BuyID = _Convert.StrToLong(Shove._Web.Utility.GetRequest("BuyID"), 0L);
        }
    }

  
}

