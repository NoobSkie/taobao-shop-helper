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

namespace YeePay_HTMLcommon
{
    public partial class QueryOrderStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 商家的交易定单号
            string p2_Order = Request.Form["p2_Order"];
            try
            {
                // 查询订单
                BuyQueryOrdDetailResult result = Buy.QueryOrdDetail(p2_Order);

                if (result.R1_Code == "1")
                {
                    Response.Write("查询成功!");
                    Response.Write("<br>商户订单号:" + result.R6_Order);
                    Response.Write("<br>商品名称:" + result.R5_Pid);
                    Response.Write("<br>支付金额:" + result.R3_Amt);
                    Response.Write("<br>订单状态:" + result.Rb_PayStatus);
                }
                else
                {
                    Response.Write("<br>查询失败!" + result.R1_Code);
                }
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}
