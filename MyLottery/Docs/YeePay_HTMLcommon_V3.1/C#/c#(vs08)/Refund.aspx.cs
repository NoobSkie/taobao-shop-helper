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
    public partial class Refund1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 设置 Response编码格式为GB2312
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");

            string pb_TrxId = Request.Form["pb_TrxId"];
            string p3_Amt = Request.Form["p3_Amt"];
            string p4_Cur = Request.Form["p4_Cur"];
            string p5_Desc = Request.Form["p5_Desc"];
            
            try
            {
                BuyRefundOrdResult result = Buy.RefundOrd(pb_TrxId, p3_Amt, p4_Cur, p5_Desc);

                if (result.R1_Code == "1")
                {
                    Response.Write("退款成功");
                    Response.Write("<br>退款金额:" + result.R3_Amt);
                }
                else
                {
                    Response.Write("退款失败 " + result.R1_Code);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
