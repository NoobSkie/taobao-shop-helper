using ASP;
using DAL;
using Shove;
using Shove._Web;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_007ka_Receive1 : RoomPageBase, IRequiresSessionState
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
    private string SignCounterpart = "";
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
        string str = Utility.GetUrl() + "/Home/Room/OnlinePay/";
        try
        {
            this.SettingParams();
        }
        catch (Exception exception)
        {
            this.errorMessage = "007在线充值：充值未完成。错误描述：参数有误 详细：" + exception.Message;
            new Log("OnlinePay").Write(this.errorMessage);
            base.Response.Redirect(str + "Fail.aspx?errMsg=" + this.errorMessage);
            return;
        }
        this.key = this.so["OnlinePay_007Ka_Key"].ToString("");
        if (base.Request.QueryString.AllKeys.Length >= 1)
        {
            if (this.SignCounterpart != this.GetMD5(this.Orderinfo))
            {
                this.errorMessage = "007在线充值：充值未完成。错误描述：认证签名失败！";
                new Log("OnlinePay").Write(this.errorMessage);
                base.Response.Redirect(str + "Fail.aspx?errMsg=" + this.errorMessage);
            }
            else if (this.MerID != this.so["OnlinePay_007Ka_MerchantId"].ToString("").Trim())
            {
                this.errorMessage = "007在线充值：充值未完成。错误描述：商户号错误，数据非法！";
                new Log("OnlinePay").Write(this.errorMessage);
                base.Response.Redirect(str + "Fail.aspx?errMsg=" + this.errorMessage);
            }
            else if (this.MerAccount != this.so["OnlinePay_007Ka_MerAccount"].ToString("").Trim())
            {
                this.errorMessage = "007在线充值：充值未完成。错误描述：商户银行账号错误，数据非法！";
                new Log("OnlinePay").Write(this.errorMessage);
                base.Response.Redirect(str + "Fail.aspx?errMsg=" + this.errorMessage);
            }
            else if ((this.TranStat.ToString().Trim() != "1") && (this.TranStat.ToString().Trim() != "29"))
            {
                this.errorMessage = "007充值失败。";
                new Log("OnlinePay").Write(this.errorMessage + " 错误号：" + this.TranStat.ToString() + " 错误描述:" + this.TranInfo);
                base.Response.Redirect(str + "Fail.aspx?errMsg=" + this.errorMessage);
            }
            else
            {
                DataTable table = new Tables.T_UserPayDetails().Open("Result,UserID", "ID=" + this.OrderID, "");
                if ((table == null) || (table.Rows.Count < 1))
                {
                    this.errorMessage = "007在线充值：充值未完成。错误描述：生成支付流水号未成功。";
                    new Log("OnlinePay").Write(this.errorMessage);
                    base.Response.Redirect(str + "Fail.aspx?errMsg=" + this.errorMessage);
                }
                else if (_Convert.StrToLong(table.Rows[0][1].ToString(), 0L) != 0L)
                {
                    if (_Convert.StrToInt(table.Rows[0][0].ToString(), 0) == 1)
                    {
                        this.errorMessage = this.OrderID + "订单充值已经成功!";
                        base.Response.Write("OK");
                        new Log("OnlinePay").Write(this.errorMessage);
                        JavaScript.Alert(this.Page, this.errorMessage);
                    }
                    else
                    {
                        string returnDescription = "";
                        double num = this.so["OnlinePay_007Ka_FormalitiesFees"].ToDouble(0.0) / 100.0;
                        double formalitiesFees = Math.Round((double)((_Convert.StrToDouble(this.Value, 0.0) / 100.0) * num), 2);
                        Users users = new Users(base._Site.ID)[base._Site.ID, _Convert.StrToLong(table.Rows[0][1].ToString(), 0L)];
                        if (users.AddUserBalance((_Convert.StrToDouble(this.Value, 0.0) / 100.0) - formalitiesFees, formalitiesFees, this.OrderID, "007Ka", "系统交易号：" + this.OrderID + "007Ka支付", ref returnDescription) < 0)
                        {
                            this.errorMessage = "增加电子货币错误。错误原因：" + returnDescription;
                            new Log("OnlinePay").Write(this.errorMessage);
                            base.Response.Redirect(str + "Fail.aspx?errMsg=" + this.errorMessage);
                        }
                        else
                        {
                            base.Response.Write("OK");
                            this.errorMessage = "007在线充值：充值完成！";
                            new Log("OnlinePay").Write(this.errorMessage);
                            base.Response.Redirect(Utility.GetUrl() + "/Home/Room/OnlinePay/OK.aspx?BuyID=" + this.Attach);
                        }
                    }
                }
                else
                {
                    this.errorMessage = "007在线充值：充值未完成。错误描述：用户不存在！";
                    new Log("OnlinePay").Write(this.errorMessage);
                    base.Response.Redirect(Utility.GetUrl() + "/Home/Room/OnlinePay/OK.aspx?BuyID=" + this.Attach);
                }
            }
        }
        else
        {
            this.errorMessage = "007在线充值：充值未完成。错误描述：数据传输错误！";
            new Log("OnlinePay").Write(this.errorMessage);
            base.Response.Redirect(str + "Fail.aspx?errMsg=" + this.errorMessage);
        }
    }

    private void SettingParams()
    {
        this.Orderinfo = Utility.GetRequest("Orderinfo");
        this.SignCounterpart = Utility.GetRequest("Sign");
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

