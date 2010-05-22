using ASP;
using DAL;
using Shove;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_007ka_Receive : Page, IRequiresSessionState
{
    private string Attach = "";
    private string CardType = "";
    private string Command = "";
    private string Datetime = "";
    private string errorMessage = "";

    private string InterfaceName = "";
    private string InterfaceNumber = "";
    private string key = "";
    private string MerAccount = "";
    private string MerID = "";
    private string OrderID = "";
    private string Orderinfo = "";
    private string Sign = "";
    private SystemOptions so = new SystemOptions();
    private string TranInfo = "";
    private string TranOrder = "";
    private string TranStat = "";
    private string Value = "";

    private string GetMD5(string encypStr)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(encypStr + "|" + this.key, "MD5").ToUpper();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.SettingParams();
        }
        catch (Exception exception)
        {
            this.errorMessage = "通知错误：错误错误描述：007Ka回调页面参数列表！";
            new Log("OnlinePay").Write(this.errorMessage + "      错误信息:" + exception.Message);
            base.Response.End();
            return;
        }
        base.Response.Write("OK");
        this.key = this.so["OnlinePay_007Ka_Key"].ToString("").Trim();
        if (!(this.Sign != this.GetMD5(this.Orderinfo)))
        {
            if (this.MerID != this.so["OnlinePay_007Ka_MerchantId"].ToString("").Trim())
            {
                this.errorMessage = "通知错误：充值未完成。错误描述：商户号错误，数据非法！";
                new Log("OnlinePay").Write(this.errorMessage);
                base.Response.End();
            }
            else if (this.MerAccount != this.so["OnlinePay_007Ka_MerAccount"].ToString("").Trim())
            {
                this.errorMessage = "通知错误：充值未完成。错误描述：银行账号错误，数据非法！";
                new Log("OnlinePay").Write(this.errorMessage);
                base.Response.End();
            }
            else if ((this.TranStat.ToString().Trim() != "1") && (this.TranStat.ToString().Trim() != "29"))
            {
                this.errorMessage = "通知错误：充值未完成。错误号：" + this.TranStat + "错误描述：" + this.TranInfo;
                new Log("OnlinePay").Write(this.errorMessage);
                base.Response.End();
            }
            else
            {
                DataTable table = new Tables.T_UserPayDetails().Open("Result,UserID", "ID=" + this.OrderID, "");
                if ((table == null) || (table.Rows.Count < 1))
                {
                    this.errorMessage = "通知错误：充值未完成。错误描述：数据库错误。关联错误：获取支付流水号未成功。";
                    new Log("OnlinePay").Write(this.errorMessage);
                    base.Response.End();
                }
                else if (_Convert.StrToLong(table.Rows[0][0].ToString(), 0L) == 0L)
                {
                    string returnDescription = "";
                    int returnValue = 1;
                    double num2 = this.so["OnlinePay_007Ka_FormalitiesFees"].ToDouble(0.0) / 100.0;
                    double formalitiesFees = Math.Round((double)((_Convert.StrToDouble(this.Value, 0.0) / 100.0) * num2), 2);
                    Procedures.P_UserAddMoney(1L, _Convert.StrToLong(table.Rows[0][1].ToString(), 0L), (_Convert.StrToDouble(this.Value, 0.0) / 100.0) - formalitiesFees, formalitiesFees, this.OrderID, "007Ka", "系统交易号：" + this.OrderID + "007Ka支付", ref returnValue, ref returnDescription);
                    if (returnValue < 0)
                    {
                        this.errorMessage = "通知错误：充值未完成。错误描述：增加电子货币错误。错误原因：" + returnDescription;
                        new Log("OnlinePay").Write(this.errorMessage);
                        base.Response.End();
                    }
                    else
                    {
                        this.errorMessage = "007在线充值：充值完成";
                        new Log("OnlinePay").Write(this.errorMessage);
                        base.Response.End();
                    }
                }
                else
                {
                    this.errorMessage = "007在线充值：充值完成";
                    new Log("OnlinePay").Write(this.errorMessage);
                    base.Response.End();
                }
            }
        }
        else
        {
            this.errorMessage = "通知错误：充值未完成。错误描述：认证签名失败！";
            new Log("OnlinePay").Write(this.errorMessage);
            base.Response.End();
        }
    }

    private void SettingParams()
    {
        this.Orderinfo = base.Request.Params["Orderinfo"];
        this.Sign = base.Request.Form["Sign"];
        string[] strArray = this.Orderinfo.Split(new char[] { '|' });
        this.MerID = strArray[0];
        this.MerAccount = strArray[1];
        this.OrderID = strArray[2];
        this.TranStat = strArray[3];
        this.TranInfo = strArray[4];
        this.CardType = strArray[5];
        this.Value = strArray[6];
        this.Command = strArray[7];
        this.InterfaceName = strArray[8];
        this.InterfaceNumber = strArray[9];
        this.Datetime = strArray[10];
        this.TranOrder = strArray[11];
        this.Attach = strArray[12];
    }

  
}

