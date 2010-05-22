using Alipay.Gateway;
using ASP;
using DAL;
using Shove;
using Shove._Security;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Room_OnlinePay_Alipay02_AlipayNotify : RoomPageBase, IRequiresSessionState
{
    private string bankPay = "";
    private SystemOptions so = new SystemOptions();

    public string Get_Http(string a_strUrl, int timeout)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(a_strUrl);
            request.Timeout = timeout;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            StringBuilder builder = new StringBuilder();
            while (-1 != reader.Peek())
            {
                builder.Append(reader.ReadLine());
            }
            return builder.ToString();
        }
        catch (Exception exception)
        {
            return ("错误：" + exception.Message);
        }
    }

    private string getBankName(string bankCode)
    {
        switch (bankCode.ToUpper())
        {
            case "ALIPAY":
                return "支付宝";

            case "ICBCB2C":
                return "中国工商银行";

            case "GDB":
                return "广东发展银行";

            case "CEBBANK":
                return "中国光大银行";

            case "CCB":
                return "中国建设银行";

            case "COMM":
                return "中国交通银行";

            case "ABC":
                return "中国农业银行";

            case "SPDB":
                return "上海浦发银行";

            case "SDB":
                return "深圳发展银行";

            case "CIB":
                return "兴业银行";

            case "HZCBB2C":
                return "杭州银行";

            case "CMBC":
                return "杭州银行";

            case "BOCB2C":
                return "中国银行";

            case "CMB":
                return "中国招商银行";

            case "CITIC":
                return "中信银行";
        }
        return "支付宝";
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
            new Log("System").Write("支付宝支付：AlipayNotify.aspx:接收到了通知！支付编号为：" + base.Request.Form["out_trade_no"]);
            string d = base.Request.Form["subject"];
            d = Encrypt.UnEncryptString(PF.GetCallCert(), d);
            string str2 = "";
            string str3 = "";
            if ((d.IndexOf("_alipay") < 0) && (this.so["OnlinePay_Alipay_UserNumber1"].ToString("") != ""))
            {
                str2 = this.so["OnlinePay_Alipay_UserNumber1"].ToString("");
                str3 = this.so["OnlinePay_Alipay_MD5Key1"].ToString("");
            }
            else
            {
                str2 = this.so["OnlinePay_Alipay_UserNumber"].ToString("");
                str3 = this.so["OnlinePay_Alipay_MD5Key"].ToString("");
            }
            string str4 = "utf-8";
            string str5 = "http://notify.alipay.com/trade/notify_query.do?";
            str5 = str5 + "service=notify_verify&partner=" + str2 + "&notify_id=" + base.Request.Form["notify_id"];
            string str6 = this.Get_Http(str5, 0x1d4c0);
            string[] strArray3 = Utility.BubbleSort(base.Request.Form.AllKeys);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < strArray3.Length; i++)
            {
                if (((base.Request.Form[strArray3[i]] != "") && (strArray3[i] != "sign")) && (strArray3[i] != "sign_type"))
                {
                    if (i == (strArray3.Length - 1))
                    {
                        builder.Append(strArray3[i] + "=" + base.Request.Form[strArray3[i]]);
                    }
                    else
                    {
                        builder.Append(strArray3[i] + "=" + base.Request.Form[strArray3[i]] + "&");
                    }
                }
            }
            builder.Append(str3);
            string str7 = Utility.GetMD5(builder.ToString(), str4);
            string str8 = base.Request.Form["sign"];
            string str9 = base.Request.Form["trade_status"];
            string str10 = base.Request.Form["trade_no"];
            string str11 = base.Request.Form["out_trade_no"];
            string str12 = base.Request.Form["subject"];
            string str = Encrypt.UnEncryptString(PF.GetCallCert(), str12).Split(new char[] { '_' })[0];
            this.bankPay = Encrypt.UnEncryptString(PF.GetCallCert(), str12).Split(new char[] { '_' })[2];
            double num2 = double.Parse(base.Request.Form["total_fee"].ToString());
            string str14 = base.Request.Form["seller_email"];
            if ((str14 != this.so["OnlinePay_Alipay_UserName"].ToString("")) && (str14 != this.so["OnlinePay_Alipay_UserName_Email"].ToString("")))
            {
                new Log("System").Write("在线支付：支付用户信息验证失败！(Notify)");
                base.Response.Write("fail");
                base.Response.End();
            }
            else if (((str7 == str8) && (str6 == "true")) && (str9 == "TRADE_FINISHED"))
            {
                Users users;
                if (base._User == null)
                {
                    users = new Users(base._Site.ID)[base._Site.ID, _Convert.StrToLong(str, -1L)];
                }
                else
                {
                    users = new Users(base._Site.ID)[base._Site.ID, base._User.ID];
                }
                if (users == null)
                {
                    new Log("System").Write("在线支付：写入返回数据出错！(Notify)支付号：" + str11);
                    base.Response.Write("fail");
                    base.Response.End();
                }
                else
                {
                    if (base._User == null)
                    {
                        base._User = new Users(base._Site.ID)[base._Site.ID, users.ID];
                    }
                    if (this.WriteUserAccount(base._User, str11.ToString(), num2.ToString(), "系统交易号：" + str11.ToString() + ",支付宝交易号：" + str10.ToString()))
                    {
                        new Log("System").Write("在线支付：充值成功！(Notify)支付号：" + str11);
                        base.Response.Write("success");
                        base.Response.End();
                    }
                    else
                    {
                        new Log("System").Write("在线支付：写入返回数据出错！(Notify)支付号：" + str11);
                        base.Response.Write("fail");
                        base.Response.End();
                    }
                }
            }
            else
            {
                new Log("System").Write("在线支付：签名不正确！(Notify)支付号：" + str11 + "responseTxt:" + str6);
                base.Response.Write("fail");
                base.Response.End();
            }
        }
        catch (Exception exception)
        {
            new Log("System").Write(exception.Message);
            base.Response.Write("fail");
            base.Response.End();
        }
    }

    private bool WriteUserAccount(Users _User, string orderid, string amount, string Memo)
    {
        double money = _Convert.StrToDouble(amount, 0.0);
        if (money != 0.0)
        {
            double num2 = this.so["OnlinePay_Alipay_PayFormalitiesFeesScale"].ToDouble(0.0) / 100.0;
            double formalitiesFees = money - Math.Round((double)(money / (num2 + 1.0)), 2);
            money -= formalitiesFees;
            string returnDescription = "";
            bool flag = _User.AddUserBalance(money, formalitiesFees, orderid, this.getBankName(this.bankPay), Memo, ref returnDescription) == 0;
            if (flag)
            {
                return flag;
            }
            DataTable table = new Tables.T_UserPayDetails().Open("Result", "[id] = " + _Convert.StrToLong(orderid, 0L).ToString(), "");
            if ((table == null) || (table.Rows.Count == 0))
            {
                new Log("System").Write("在线支付：返回的交易号找不到对应的数据" + Memo);
                return false;
            }
            if (_Convert.StrToInt(table.Rows[0][0].ToString(), 0) == 1)
            {
                return true;
            }
            new Log("System").Write("在线支付：对应的数据未处理" + Memo);
        }
        return false;
    }
}

