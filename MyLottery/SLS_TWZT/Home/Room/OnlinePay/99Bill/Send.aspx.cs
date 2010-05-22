using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_99Bill_Send : RoomPageBase, IRequiresSessionState
{


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
        base.isRequestLogin = true;
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isAllowPageCache = false;
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            double num = _Convert.StrToDouble(Utility.GetRequest("PayMoney"), 0.0);
            string request = Utility.GetRequest("bankPay");
            string str2 = Utility.GetRequest("BuyID");
            SystemOptions options = new SystemOptions();
            if (base._User.Competences.CompetencesList.IndexOf("Administrator") > 0)
            {
                if (num < 0.01)
                {
                    base.Response.Write("<script type=\"text/javascript\">alert(\"请输入正确的充值金额！再提交，谢谢！\"); window.close();</script>");
                    return;
                }
            }
            else if (num < 0.01)
            {
                base.Response.Write("<script type=\"text/javascript\">alert(\"请输入正确的充值金额！再提交，谢谢！\"); window.close();</script>");
                return;
            }
            double num2 = options["OnlinePay_99Bill_PayFormalitiesFeesScale"].ToDouble(0.0) / 100.0;
            double formalitiesFees = Math.Round((double)(num * num2), 2);
            if (num2 > 0.09)
            {
                PF.GoError(4, "手续费比例有误", base.GetType().BaseType.FullName);
            }
            else
            {
                num += formalitiesFees;
                long newPayNumber = -1L;
                string returnDescription = "";
                if (Procedures.P_GetNewPayNumber(base._Site.ID, base._User.ID, "99Bill_" + request, num - formalitiesFees, formalitiesFees, ref newPayNumber, ref returnDescription) < 0)
                {
                    PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                }
                else if ((newPayNumber < 0L) || (returnDescription != ""))
                {
                    PF.GoError(1, returnDescription, base.GetType().BaseType.FullName);
                }
                else
                {
                    string paramValue = "";
                    string str5 = "";
                    string str6 = "";
                    string str7 = "";
                    string str8 = "";
                    string str9 = "";
                    string str10 = "";
                    string name = "";
                    string str12 = "";
                    string str13 = "";
                    string str14 = "";
                    string str15 = "";
                    string str16 = "";
                    string str17 = "";
                    string str18 = "";
                    string str19 = "";
                    string str20 = "";
                    string str21 = "";
                    string str22 = "";
                    string str23 = "";
                    string str24 = "";
                    string str25 = "";
                    string str26 = "";
                    string str27 = "";
                    string str28 = options["OnlinePay_99Bill_MD5Key"].Value.ToString();
                    paramValue = "1";
                    str5 = "";
                    str6 = Utility.GetUrl() + "/Home/Room/OnlinePay/99Bill/Receive.aspx";
                    str7 = "v2.0";
                    str8 = "1";
                    str9 = "1";
                    str10 = options["OnlinePay_99Bill_UserNumber"].Value.ToString();
                    name = base._User.Name;
                    str12 = "1";
                    str13 = "";
                    str14 = newPayNumber.ToString();
                    double num5 = num * 100.0;
                    str15 = long.Parse(num5.ToString()).ToString();
                    str16 = DateTime.Now.ToString("yyyyMMddHHmmss");
                    str17 = "购彩预付款";
                    str18 = "1";
                    str19 = "200599";
                    str20 = "";
                    str21 = Encrypt.EncryptString(PF.GetCallCert(), base._User.ID.ToString() + "|" + request + "|" + str2);
                    str22 = "";
                    str23 = "00";
                    str24 = "";
                    if (request != "KQ")
                    {
                        str23 = "10";
                        str24 = request;
                    }
                    str25 = "1";
                    str26 = "";
                    if ((string.IsNullOrEmpty(str10) || string.IsNullOrEmpty(str21)) || string.IsNullOrEmpty(str14))
                    {
                        base.Response.Write("<script type=\"text/javascript\">alert(\"参数不齐全，无法充值！\"); window.close();</script>");
                    }
                    else
                    {
                        string returnStr = "";
                        returnStr = this.appendParam(returnStr, "inputCharset", paramValue);
                        returnStr = this.appendParam(returnStr, "pageUrl", str5);
                        returnStr = this.appendParam(returnStr, "bgUrl", str6);
                        returnStr = this.appendParam(returnStr, "version", str7);
                        returnStr = this.appendParam(returnStr, "language", str8);
                        returnStr = this.appendParam(returnStr, "signType", str9);
                        returnStr = this.appendParam(returnStr, "merchantAcctId", str10);
                        returnStr = this.appendParam(returnStr, "payerName", name);
                        returnStr = this.appendParam(returnStr, "payerContactType", str12);
                        returnStr = this.appendParam(returnStr, "payerContact", str13);
                        returnStr = this.appendParam(returnStr, "orderId", str14);
                        returnStr = this.appendParam(returnStr, "orderAmount", str15);
                        returnStr = this.appendParam(returnStr, "orderTime", str16);
                        returnStr = this.appendParam(returnStr, "productName", str17);
                        returnStr = this.appendParam(returnStr, "productNum", str18);
                        returnStr = this.appendParam(returnStr, "productId", str19);
                        returnStr = this.appendParam(returnStr, "productDesc", str20);
                        returnStr = this.appendParam(returnStr, "ext1", str21);
                        returnStr = this.appendParam(returnStr, "ext2", str22);
                        returnStr = this.appendParam(returnStr, "payType", str23);
                        returnStr = this.appendParam(returnStr, "bankId", str24);
                        returnStr = this.appendParam(returnStr, "redoFlag", str25);
                        returnStr = this.appendParam(returnStr, "pid", str26);
                        str27 = GetMD5(this.appendParam(returnStr, "key", str28), "utf-8").ToUpper();
                        string str31 = "";
                        str31 = this.appendParam(str31, "inputCharset", paramValue);
                        str31 = this.appendParam(str31, "pageUrl", str5);
                        str31 = this.appendParam(str31, "bgUrl", str6);
                        str31 = this.appendParam(str31, "version", str7);
                        str31 = this.appendParam(str31, "language", str8);
                        str31 = this.appendParam(str31, "signType", str9);
                        str31 = this.appendParam(str31, "merchantAcctId", str10);
                        str31 = this.appendParam(str31, "payerName", HttpUtility.UrlEncode(name));
                        str31 = this.appendParam(str31, "payerContactType", str12);
                        str31 = this.appendParam(str31, "payerContact", str13);
                        str31 = this.appendParam(str31, "orderId", str14);
                        str31 = this.appendParam(str31, "orderAmount", str15);
                        str31 = this.appendParam(str31, "orderTime", str16);
                        str31 = this.appendParam(str31, "productName", HttpUtility.UrlEncode(str17));
                        str31 = this.appendParam(str31, "productNum", str18);
                        str31 = this.appendParam(str31, "productId", str19);
                        str31 = this.appendParam(str31, "productDesc", str20);
                        str31 = this.appendParam(str31, "ext1", str21);
                        str31 = this.appendParam(str31, "ext2", str22);
                        str31 = this.appendParam(str31, "payType", str23);
                        str31 = this.appendParam(str31, "bankId", str24);
                        str31 = this.appendParam(str31, "redoFlag", str25);
                        str31 = this.appendParam(str31, "pid", str26);
                        str31 = "https://www.99bill.com/gateway/recvMerchantInfoAction.htm?" + str31 + "&signMsg=" + str27;
                        new Log("OnlinePay").Write("快钱冲值请求：" + str31);
                        base.Response.Write("<script language='javascript'>window.top.location.href='" + str31 + "'</script>");
                    }
                }
            }
        }
    }

  
}

