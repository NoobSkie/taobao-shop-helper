using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_99Bill_Receive : RoomPageBase, IRequiresSessionState
{

    public int rtnOk;
    public string rtnUrl = "";
    private SystemOptions so = new SystemOptions();

    private string appendParam(string returnStr, string paramId, string paramValue)
    {
        if (returnStr != "")
        {
            if (paramValue != "")
            {
                string str = returnStr;
                returnStr = str + "&" + paramId + "=" + paramValue;
            }
            return returnStr;
        }
        if (paramValue != "")
        {
            returnStr = paramId + "=" + paramValue;
        }
        return returnStr;
    }

    private static string GetMD5(string dataStr, string codeType)
    {
        byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding(codeType).GetBytes(dataStr));
        StringBuilder builder = new StringBuilder(0x20);
        for (int i = 0; i < buffer.Length; i++)
        {
            builder.Append(buffer[i].ToString("x").PadLeft(2, '0'));
        }
        return builder.ToString();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.isRequestLogin = false;
        base.isAllowPageCache = false;
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            try
            {
                new Log("OnlinePay").Write("快钱在线支付收到通知：" + base.Request.RawUrl);
            }
            catch
            {
            }
            string paramValue = this.so["OnlinePay_99Bill_MD5Key"].Value.ToString();
            string str2 = base.Request["merchantAcctId"].ToString().Trim();
            string str3 = base.Request["version"].ToString().Trim();
            string str4 = base.Request["language"].ToString().Trim();
            string str5 = base.Request["signType"].ToString().Trim();
            string str6 = base.Request["payType"].ToString().Trim();
            string str7 = base.Request["bankId"].ToString().Trim();
            string str8 = base.Request["orderId"].ToString().Trim();
            string str9 = base.Request["orderTime"].ToString().Trim();
            string str10 = base.Request["orderAmount"].ToString().Trim();
            string str11 = base.Request["dealId"].ToString().Trim();
            string str12 = base.Request["bankDealId"].ToString().Trim();
            string str13 = base.Request["dealTime"].ToString().Trim();
            string str14 = base.Request["payAmount"].ToString().Trim();
            string str15 = base.Request["fee"].ToString().Trim();
            string str16 = base.Request["ext1"].ToString().Trim();
            string str17 = base.Request["ext2"].ToString().Trim();
            string str18 = base.Request["payResult"].ToString().Trim();
            string str19 = base.Request["errCode"].ToString().Trim();
            string str20 = base.Request["signMsg"].ToString().Trim();
            string returnStr = "";
            returnStr = this.appendParam(returnStr, "merchantAcctId", str2);
            returnStr = this.appendParam(returnStr, "version", str3);
            returnStr = this.appendParam(returnStr, "language", str4);
            returnStr = this.appendParam(returnStr, "signType", str5);
            returnStr = this.appendParam(returnStr, "payType", str6);
            returnStr = this.appendParam(returnStr, "bankId", str7);
            returnStr = this.appendParam(returnStr, "orderId", str8);
            returnStr = this.appendParam(returnStr, "orderTime", str9);
            returnStr = this.appendParam(returnStr, "orderAmount", str10);
            returnStr = this.appendParam(returnStr, "dealId", str11);
            returnStr = this.appendParam(returnStr, "bankDealId", str12);
            returnStr = this.appendParam(returnStr, "dealTime", str13);
            returnStr = this.appendParam(returnStr, "payAmount", str14);
            returnStr = this.appendParam(returnStr, "fee", str15);
            returnStr = this.appendParam(returnStr, "ext1", str16);
            returnStr = this.appendParam(returnStr, "ext2", str17);
            returnStr = this.appendParam(returnStr, "payResult", str18);
            returnStr = this.appendParam(returnStr, "errCode", str19);
            returnStr = this.appendParam(returnStr, "key", paramValue);
            string str22 = GetMD5(returnStr, "utf-8");
            if (str20.ToUpper() != str22.ToUpper())
            {
                try
                {
                    new Log("OnlinePay").Write("快钱在线支付：校验出错！快钱支付返回时请求信息：" + returnStr + "  生成校验码：" + str22 + "返回校验码：" + str20 + " 支付号：" + str8);
                    base.Response.Write("<script language='javascript'>window.top.location.href='" + Utility.GetUrl() + "/Home/Room/OnlinePay/Fail.aspx'</script>");
                }
                catch
                {
                }
            }
            else if ((str18 != "11") && (str18 == "10"))
            {
                string[] strArray2 = Encrypt.UnEncryptString(PF.GetCallCert(), str16).Split(new char[] { '|' });
                long num = _Convert.StrToLong(strArray2[0], -1L);
                string text1 = strArray2[1];
                _Convert.StrToLong(strArray2[2], -1L);
                double payMoney = _Convert.StrToDouble(str14, 0.0) / 100.0;
                Users thisUser = new Users(base._Site.ID)[base._Site.ID, num];
                if (thisUser == null)
                {
                    try
                    {
                        new Log("OnlinePay").Write("快钱在线支付：异常用户数据！ 支付号：" + str8);
                    }
                    catch
                    {
                    }
                    this.rtnOk = 0;
                    this.rtnUrl = Utility.GetUrl() + "/Home/Room/OnlinePay/Fail.aspx";
                }
                else if (this.WriteUserAccount(thisUser, str8, payMoney, "系统交易号：" + str8 + " 快钱的交易号：" + str11))
                {
                    long num3 = 0L;
                    if ((base.Request.Url.AbsoluteUri.IndexOf("?BuyID") > 0) && (base.Request.Url.AbsoluteUri.IndexOf("&") > 0))
                    {
                        num3 = _Convert.StrToLong(HttpUtility.UrlDecode(base.Request.Url.AbsoluteUri).Split(new char[] { '?' })[1].Split(new char[] { '&' })[0].Replace("BuyID=", ""), -1L);
                    }
                    this.rtnOk = 1;
                    this.rtnUrl = Utility.GetUrl() + "/Home/Room/OnlinePay/OK.aspx?BuyID=" + num3.ToString();
                }
                else
                {
                    new Log("OnlinePay").Write("在线支付：写入返回数据出错！ 支付号：" + str8);
                    this.rtnOk = 0;
                    this.rtnUrl = Utility.GetUrl() + "/Home/Room/OnlinePay/Fail.aspx";
                }
            }
        }
        catch (Exception exception)
        {
            new Log("OnlinePay").Write("[快钱]在线支付：" + exception.Message + " -- 接收数据异常！");
        }
    }

    private bool WriteUserAccount(Users thisUser, string PayNumber, double PayMoney, string Memo)
    {
        if (PayMoney > 0.0)
        {
            double num = this.so["OnlinePay_99Bill_PayFormalitiesFeesScale"].ToDouble(0.0) / 100.0;
            double formalitiesFees = PayMoney - Math.Round((double)(PayMoney / (num + 1.0)), 2);
            double money = PayMoney - formalitiesFees;
            string returnDescription = "";
            bool flag = thisUser.AddUserBalance(money, formalitiesFees, PayNumber, "快钱", Memo, ref returnDescription) == 0;
            if (flag)
            {
                return flag;
            }
            DataTable table = new Tables.T_UserPayDetails().Open("Result", "[id] = " + _Convert.StrToLong(PayNumber, 0L).ToString(), "");
            if ((table == null) || (table.Rows.Count == 0))
            {
                new Log("OnlinePay").Write("[快钱]在线支付：返回的交易号找不到对应的数据");
                return false;
            }
            if (_Convert.StrToInt(table.Rows[0][0].ToString(), 0) == 1)
            {
                return true;
            }
            new Log("OnlinePay").Write("[快钱]在线支付：对应的数据未处理");
        }
        return false;
    }

   
}

