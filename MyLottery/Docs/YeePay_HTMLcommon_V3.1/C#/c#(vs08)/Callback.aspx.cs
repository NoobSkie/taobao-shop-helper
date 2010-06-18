using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using com.yeepay.bank;

public partial class Callback : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 校验返回数据包
            BuyCallbackResult result = Buy.VerifyCallback(FormatQueryString.GetQueryString("p1_MerId"),FormatQueryString.GetQueryString("r0_Cmd"), FormatQueryString.GetQueryString("r1_Code"), FormatQueryString.GetQueryString("r2_TrxId"),
                FormatQueryString.GetQueryString("r3_Amt"), FormatQueryString.GetQueryString("r4_Cur"), FormatQueryString.GetQueryString("r5_Pid"), FormatQueryString.GetQueryString("r6_Order"), FormatQueryString.GetQueryString("r7_Uid"),
                FormatQueryString.GetQueryString("r8_MP"), FormatQueryString.GetQueryString("r9_BType"), FormatQueryString.GetQueryString("rp_PayDate"), FormatQueryString.GetQueryString("hmac"));

            if (string.IsNullOrEmpty(result.ErrMsg))
            {
                if (result.R1_Code == "1")
                {
                    if (result.R9_BType == "1")
                    {
                        //  callback方式:浏览器重定向
                        Response.Write("支付成功!<br>商品ID:" + result.R5_Pid + "<br>商户订单号:" + result.R6_Order + "<br>支付金额:" + result.R3_Amt + "<br>易宝支付交易流水号:" + result.R2_TrxId + "<BR>");
                    }
                    else if (result.R9_BType == "2")
                    {
                        // * 如果是服务器返回则需要回应一个特定字符串'SUCCESS',且在'SUCCESS'之前不可以有任何其他字符输出,保证首先输出的是'SUCCESS'字符串
                        Response.Write("SUCCESS");
                    }
                }
                else
                {
                    Response.Write("支付失败!");
                }
            }
            else
            {
                Response.Write("交易签名无效!");
            }
        }
    }
}
