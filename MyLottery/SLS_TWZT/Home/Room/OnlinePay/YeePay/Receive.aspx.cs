using ASP;
using com.yeepay.bank;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_YeePay_Receive : RoomPageBase, IRequiresSessionState
{
    private string hmac;
    private static string keyValue;
    private static string p1_MerId;
    private string r0_Cmd;
    private string r1_Code;
    private string r2_TrxId;
    private string r3_Amt;
    private string r4_Cur;
    private string r5_Pid;
    private string r6_Order;
    private string r7_Uid;
    private string r8_MP;
    private string r9_BType;
    private string rp_PayDate;
    private SystemOptions so = new SystemOptions();

    protected override void OnLoad(EventArgs e)
    {
        base.isRequestLogin = false;
        base.isAllowPageCache = false;
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Buy.LogFileName = "c:/YeePay_HTML.txt";
        if (!base.IsPostBack)
        {
            p1_MerId = this.so["OnlinePay_YeePay_UserNumber"].Value.ToString();
            keyValue = this.so["OnlinePay_YeePay_MD5Key"].Value.ToString();
            Buy.NodeAuthorizationURL = Utility.GetUrl() + "/Home/Room/OnlinePay/YeePay/Receive.aspx";
            try
            {
                this.r0_Cmd = base.Request["r0_Cmd"].ToString().Trim();
                this.r1_Code = base.Request["r1_Code"].ToString().Trim();
                this.r2_TrxId = base.Request["r2_TrxId"].ToString().Trim();
                this.r3_Amt = base.Request["r3_Amt"].ToString().Trim();
                this.r4_Cur = base.Request["r4_Cur"].ToString().Trim();
                this.r5_Pid = base.Request["r5_Pid"].ToString().Trim();
                this.r6_Order = base.Request["r6_Order"].ToString().Trim();
                this.r7_Uid = base.Request["r7_Uid"].ToString().Trim();
                this.r8_MP = base.Request["r8_MP"].ToString().Trim();
                this.r9_BType = base.Request["r9_BType"].ToString().Trim();
                this.rp_PayDate = base.Request["rp_PayDate"].ToString().Trim();
                this.hmac = base.Request["hmac"].ToString().Trim();
            }
            catch
            {
                PF.GoError("YeePay_Receive", 0x65, "支付参数获取错误", "Home_Room_OnlinePay_YeePay_Receive");
                return;
            }
            Users thisUser = new Users(base._Site.ID)[base._Site.ID, _Convert.StrToLong(Encrypt.UnEncryptString(PF.GetCallCert(), this.r8_MP), 0L)];
            if ((thisUser != null) && (thisUser.ID == base._User.ID))
            {
                BuyCallbackResult result = Buy.VerifyCallback(p1_MerId, keyValue, this.r0_Cmd, this.r1_Code, this.r2_TrxId, this.r3_Amt, this.r4_Cur, this.r5_Pid, this.r6_Order, this.r7_Uid, this.r8_MP, this.r9_BType, this.rp_PayDate, this.hmac);
                if (string.IsNullOrEmpty(result.ErrMsg))
                {
                    if (result.R1_Code != "1")
                    {
                        new Log("OnlinePay").Write("易宝支付失败!");
                    }
                    else
                    {
                        bool flag = this.WriteUserAccount(thisUser, this.r6_Order, _Convert.StrToDouble(result.R3_Amt, 0.0), "易宝支付：订单号：" + result.R6_Order + "，支付金额：" + result.R3_Amt);
                        if (result.R9_BType == "1")
                        {
                            if (flag)
                            {
                                base.Response.Redirect(Utility.GetUrl() + "/Home/Room/OnlinePay/OK.aspx");
                            }
                            else
                            {
                                base.Response.Redirect(Utility.GetUrl() + "/Home/Room/OnlinePay/Fail.aspx");
                            }
                        }
                        else if (result.R9_BType == "2")
                        {
                            base.Response.Write("SUCCESS");
                            if (flag)
                            {
                                base.Response.Redirect(Utility.GetUrl() + "/Home/Room/OnlinePay/OK.aspx");
                            }
                            else
                            {
                                base.Response.Redirect(Utility.GetUrl() + "/Home/Room/OnlinePay/Fail.aspx");
                            }
                        }
                    }
                }
                else
                {
                    new Log("OnlinePay").Write("交易签名无效" + result.ErrMsg);
                }
            }
            else
            {
                new Log("OnlinePay").Write("用户帐号信息不匹配！");
            }
        }
    }

    private bool WriteUserAccount(Users thisUser, string PayNumber, double PayMoney, string Memo)
    {
        if (PayMoney > 0.0)
        {
            double num = this.so["OnlinePay_YeePay_PayFormalitiesFeesScale"].ToDouble(0.0) / 100.0;
            double formalitiesFees = PayMoney - Math.Round((double)(PayMoney / (num + 1.0)), 2);
            double money = PayMoney - formalitiesFees;
            string returnDescription = "";
            bool flag = thisUser.AddUserBalance(money, formalitiesFees, PayNumber, "易宝", Memo, ref returnDescription) == 0;
            if (flag)
            {
                return flag;
            }
            DataTable table = new Tables.T_UserPayDetails().Open("Result", "[id] = " + _Convert.StrToLong(PayNumber, 0L).ToString(), "");
            if ((table == null) || (table.Rows.Count == 0))
            {
                new Log("OnlinePay").Write("[易宝]在线支付：返回的交易号找不到对应的数据");
                return false;
            }
            if (_Convert.StrToInt(table.Rows[0][0].ToString(), 0) == 1)
            {
                return true;
            }
            new Log("OnlinePay").Write("[易宝]在线支付：对应的数据未处理");
        }
        return false;
    }

 
}

