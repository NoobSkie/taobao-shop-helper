using ASP;
using DAL;
using Shove;
using Shove.Alipay;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using Shove._IO;

public partial class Admin_OnlinePayment_Alipay_AlipayNotify : Page, IRequiresSessionState
{
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

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string charset = "utf-8";
        string str2 = "http://notify.alipay.com/trade/notify_query.do?";
        SystemOptions options = new SystemOptions();
        string str3 = options["OnlinePay_Alipay_ForUserDistill_UserNumber"].ToString("");
        string str4 = options["OnlinePay_Alipay_ForUserDistill_MD5Key_ForPayOut"].ToString("");
        str2 = str2 + "partner=" + str3 + "&notify_id=" + base.Request.Form["notify_id"];
        string str5 = this.Get_Http(str2, 0x1d4c0);
        string[] strArray3 = Shove.Alipay.Alipay.BubbleSort(base.Request.Form.AllKeys);
        new Log(@"Admin\AlipayPayment").Write("查询URL:" + str2);
        string str6 = "";
        for (int i = 0; i < strArray3.Length; i++)
        {
            if (((base.Request.Form[strArray3[i]] != "") && (strArray3[i] != "sign")) && (strArray3[i] != "sign_type"))
            {
                if (i == (strArray3.Length - 1))
                {
                    str6 = str6 + strArray3[i] + "=" + base.Request.Form[strArray3[i]];
                }
                else
                {
                    str6 = str6 + strArray3[i] + "=" + base.Request.Form[strArray3[i]] + "&";
                }
            }
        }
        string str7 = Shove.Alipay.Alipay.GetMD5(str6 + str4, charset);
        string str8 = base.Request.Form["sign"];
        string str9 = base.Request.Form["success_details"];
        string str10 = base.Request.Form["fail_details"];
        string str11 = base.Request.Form["batch_no"];
        string str12 = base.Request.Form["pay_account_no"];
        new Log(@"Admin\AlipayPayment").Write("签名验证:mysign=" + str7 + " sign=" + str8 + " responseTxt=" + str5 + " batch_no=" + str11 + "  pay_account_no=" + str12);
        if ((str7 == str8) && (str5 == "true"))
        {
            if ((str9 != null) && (str9 != ""))
            {
                new Log(@"Admin\AlipayPayment").Write("success_details:" + str9);
                string[] strArray6 = str9.Substring(0, str9.Length - 1).Split(new char[] { '|' });
                for (int j = 0; j < strArray6.Length; j++)
                {
                    long distillID = _Convert.StrToLong(strArray6[j].Split(new char[] { '^' })[0], -1L);
                    int returnValue = 0;
                    string returnDescription = "";
                    if (Procedures.P_UserDistillPayByAlipaySuccess(1L, distillID, 1L, ref returnValue, ref returnDescription) < 0)
                    {
                        Procedures.P_UserDistillPayByAlipayWriteLog("出错!提款ID:" + distillID + "派款成功,但状态更新失败");
                    }
                    else if (returnValue < 0)
                    {
                        Procedures.P_UserDistillPayByAlipayWriteLog(string.Concat(new object[] { "出错!提款ID:", distillID, "派款成功，但状态更新失败:", returnDescription }));
                    }
                }
            }
            if ((str10 != null) && (str10 != ""))
            {
                new Log(@"Admin\AlipayPayment").Write("fail_details:" + str10);
                string[] strArray8 = str10.Substring(0, str10.Length - 1).Split(new char[] { '|' });
                for (int k = 0; k < strArray8.Length; k++)
                {
                    long num6 = _Convert.StrToLong(strArray8[k].Split(new char[] { '^' })[0], -1L);
                    int num7 = 0;
                    string str14 = "";
                    if (Procedures.P_UserDistillPayByAlipayUnsuccess(1L, num6, "批量付款到支付宝失败,请财务人员确认,并另作付款.", ref num7, ref str14) < 0)
                    {
                        Procedures.P_UserDistillPayByAlipayWriteLog("出错!提款ID:" + num6 + "派款失败，状态更新失败。");
                    }
                    else if (num7 < 0)
                    {
                        Procedures.P_UserDistillPayByAlipayWriteLog(string.Concat(new object[] { "出错!提款ID:", num6, "派款失败，状态更新失败:", str14 }));
                    }
                }
            }
            base.Response.Write("success");
        }
        else
        {
            base.Response.Write("fail");
        }
    }
}

