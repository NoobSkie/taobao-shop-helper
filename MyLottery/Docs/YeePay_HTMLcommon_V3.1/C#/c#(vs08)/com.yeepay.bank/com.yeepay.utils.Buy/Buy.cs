using System;
using System.Web;
using System.Configuration;


namespace com.yeepay.bank
{
	/// <summary>
	/// B2C在线支付类(银行卡支付,电话支付标准版,神州行支付标准版)
	/// </summary>
	public abstract class Buy
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Buy()
		{
		
		}
      // 交易的请求地址
      private static string nodeAuthorizationURL = ConfigurationManager.AppSettings["authorizationURL"];

      // 交易的请求地址
      private static string queryRefundReqURL = ConfigurationManager.AppSettings["queryRefundReqURL"];

      // 商户编号
      private static string merchantId = ConfigurationManager.AppSettings["merhantId"];

      // 商户密钥
      private static string keyValue = ConfigurationManager.AppSettings["keyValue"];

		#region 创建支付请求 Url
		
		/// 创建Get方式提交的支付请求串
		public static string CreateBuyUrl(string p2_Order, string p3_Amt, string p4_Cur, string p5_Pid, string p6_Pcat, string p7_Pdesc, string p8_Url, string p9_SAF, string pa_MP, string pd_FrpId,string pr_NeedRespone)
		{
			string sbOld = "";
			
			sbOld += "Buy";
           sbOld += merchantId;
			sbOld += p2_Order;
			sbOld += p3_Amt;
			sbOld += p4_Cur;

           sbOld += p5_Pid;
           sbOld += p6_Pcat;
           sbOld += p7_Pdesc;
           sbOld += p8_Url;
			sbOld += p9_SAF;

			sbOld += pa_MP;
			sbOld += pd_FrpId;
           sbOld += pr_NeedRespone;

            string hmac = Digest.HmacSign(sbOld, keyValue);
            logstr(p2_Order, sbOld, hmac);

			string result = "";

           result += nodeAuthorizationURL;
			result += "?p0_Cmd=Buy";
           result += "&p1_MerId=" + merchantId;
			result += "&p2_Order=" + HttpUtility.UrlEncode(p2_Order, System.Text.Encoding.GetEncoding("gb2312"));
			result += "&p3_Amt=" + p3_Amt;

			result += "&p4_Cur=" + p4_Cur;
			result += "&p5_Pid=" + HttpUtility.UrlEncode(p5_Pid, System.Text.Encoding.GetEncoding("gb2312"));
			result += "&p6_Pcat=" + HttpUtility.UrlEncode(p6_Pcat, System.Text.Encoding.GetEncoding("gb2312"));
			result += "&p7_Pdesc=" + HttpUtility.UrlEncode(p7_Pdesc, System.Text.Encoding.GetEncoding("gb2312"));
			result += "&p8_Url=" + HttpUtility.UrlEncode(p8_Url, System.Text.Encoding.GetEncoding("gb2312"));

           result += "&p9_SAF=" + p9_SAF;
			result += "&pa_MP=" + HttpUtility.UrlEncode(pa_MP, System.Text.Encoding.GetEncoding("gb2312"));
			result += "&pd_FrpId=" + pd_FrpId;
			result += "&pr_NeedResponse=" + pr_NeedRespone;
           result += "&hmac=" + hmac;

			return result;
		}

		#endregion
		

		/// <summary>
		/// 验证返回结果
		/// </summary>
		/// <param name="p1_MerId"></param>
		/// <param name="keyValue"></param>
		/// <param name="r0_Cmd"></param>
		/// <param name="r1_Code"></param>
		/// <param name="r2_TrxId"></param>
		/// <param name="r3_Amt"></param>
		/// <param name="r4_Cur"></param>
		/// <param name="r5_Pid"></param>
		/// <param name="r6_Order"></param>
		/// <param name="r7_Uid"></param>
		/// <param name="r8_MP"></param>
		/// <param name="r9_BType"></param>
		/// <param name="rp_PayDate"></param>
		/// <param name="hmac"></param>
		/// <returns>BuyCallbackResult</returns>
		public static BuyCallbackResult VerifyCallback(string p1_MerId,string r0_Cmd, string r1_Code, string r2_TrxId, string r3_Amt, string r4_Cur, string r5_Pid, string r6_Order, string r7_Uid, string r8_MP, string r9_BType, string rp_PayDate, string hmac)
		{
			string sbOld="";

			sbOld += p1_MerId;
			sbOld += r0_Cmd;
			sbOld += r1_Code;
			sbOld += r2_TrxId;
			sbOld += r3_Amt;

			sbOld += r4_Cur;
			sbOld += r5_Pid;
			sbOld += r6_Order;
			sbOld += r7_Uid;
			sbOld += r8_MP;

			sbOld += r9_BType;

            string nhmac = Digest.HmacSign(sbOld, keyValue);
            logstr(r6_Order, sbOld, nhmac);
            if (nhmac == hmac)
			{
				return new BuyCallbackResult(p1_MerId, r0_Cmd, r1_Code, r2_TrxId, r3_Amt, r4_Cur, r5_Pid, r6_Order, r7_Uid, r8_MP, r9_BType, rp_PayDate, hmac, "");
			}
			else
			{
				return new BuyCallbackResult(p1_MerId, r0_Cmd, r1_Code, r2_TrxId, r3_Amt, r4_Cur, r5_Pid, r6_Order, r7_Uid, r8_MP, r9_BType, rp_PayDate, hmac, "交易签名被篡改");
			}
		}


		#region BuyQueryOrdDetailResult 查询订单明细(通讯)
		/// <summary>
		/// 查询订单明细
		/// </summary>
		/// <param name="p1_MerId">商户编号</param>
		/// <param name="keyValue">商户密钥</param>
		/// <param name="p2_Order">商户订单号</param>
		/// <returns>BuyQueryOrdDetailResult</returns>
		public static BuyQueryOrdDetailResult QueryOrdDetail(string p2_Order)
		{
			string sbOld = "";

			sbOld += "QueryOrdDetail";
			sbOld += merchantId;
			sbOld += p2_Order;

           string hmac = Digest.HmacSign(sbOld, keyValue);
           logstr(p2_Order, sbOld, hmac);
			string para = "";

			para += "?p0_Cmd=QueryOrdDetail";
			para += "&p1_MerId=" + merchantId;	    	//加入商家ID
			para += "&p2_Order=" + p2_Order;				//加入购买订单号码
           para += "&hmac=" + hmac;      	    //加入校验码

           string reqResult = HttpUtils.SendRequest(queryRefundReqURL, para);

			string r0_Cmd		= FormatQueryString.GetQueryString("r0_Cmd", reqResult, '\n');
			string r1_Code		= FormatQueryString.GetQueryString("r1_Code", reqResult, '\n');
			string r2_TrxId		= FormatQueryString.GetQueryString("r2_TrxId", reqResult, '\n');
			string r3_Amt		= FormatQueryString.GetQueryString("r3_Amt", reqResult, '\n');
			string r4_Cur		= FormatQueryString.GetQueryString("r4_Cur", reqResult, '\n');

			string r5_Pid		= FormatQueryString.GetQueryString("r5_Pid", reqResult, '\n');
			string r6_Order		= FormatQueryString.GetQueryString("r6_Order", reqResult, '\n');
			string r8_MP		= FormatQueryString.GetQueryString("r8_MP", reqResult, '\n');
			string rb_PayStatus	= FormatQueryString.GetQueryString("rb_PayStatus", reqResult, '\n');
			string rc_RefundCount= FormatQueryString.GetQueryString("rc_RefundCount", reqResult, '\n');

			string rd_RefundAmt	= FormatQueryString.GetQueryString("rd_RefundAmt", reqResult, '\n');
            hmac = FormatQueryString.GetQueryString("hmac", reqResult, '\n');
			//string hmac			= FormatQueryString.GetQueryString("hmac", reqResult, '\n');

			BuyQueryOrdDetailResult result = new BuyQueryOrdDetailResult(r0_Cmd, r1_Code, r2_TrxId, r3_Amt, r4_Cur, r5_Pid, r6_Order, r8_MP, rb_PayStatus, rc_RefundCount, rd_RefundAmt, hmac);

			return result;
		}
		#endregion

		#region BuyRefundOrdResult 退款(通讯)
		/// <summary>
		/// 退款
		/// </summary>
		/// <param name="p1_MerId">商户编号</param>
		/// <param name="keyValue">商户密钥</param>
		/// <param name="pb_TrxId">yeepay流水号</param>
		/// <param name="p3_Amt">退款金额</param>
		/// <param name="p4_Cur">币种</param>
		/// <param name="p5_Desc">退款说明</param>
		/// <returns></returns>
		public static BuyRefundOrdResult RefundOrd(string pb_TrxId, string p3_Amt, string p4_Cur, string p5_Desc)
		{
			string sbOld = "";

			sbOld += "RefundOrd";
			sbOld += merchantId;
			sbOld += pb_TrxId;
			sbOld += p3_Amt;
			sbOld += p4_Cur;

			sbOld += p5_Desc;

            string hmac = Digest.HmacSign(sbOld, keyValue);
            logstr(pb_TrxId, sbOld, hmac);
			string para = "";

			para += "?p0_Cmd=RefundOrd";
			para += "&p1_MerId=" + merchantId;	    	//加入商家ID
			para += "&pb_TrxId=" + pb_TrxId;
			para += "&p3_Amt=" + p3_Amt;				//加入购买订单号码
			para += "&p4_Cur=" + p4_Cur;

			para += "&p5_Desc=" + HttpUtility.UrlEncode(p5_Desc, System.Text.Encoding.GetEncoding("gb2312"));
            para += "&hmac=" + hmac;      	    //加入校验码

            string reqResult = HttpUtils.SendRequest(queryRefundReqURL, para);

			string r0_Cmd	= FormatQueryString.GetQueryString("r0_Cmd", reqResult, '\n');	
			string r1_Code	= FormatQueryString.GetQueryString("r1_Code", reqResult, '\n');
			string r2_TrxId	= FormatQueryString.GetQueryString("r2_TrxId", reqResult, '\n');
			string r3_Amt	= FormatQueryString.GetQueryString("r3_Amt", reqResult, '\n');
			string r4_Cur	= FormatQueryString.GetQueryString("r4_Cur", reqResult, '\n');

            hmac = FormatQueryString.GetQueryString("hmac", reqResult, '\n');
			//string hmac		= FormatQueryString.GetQueryString("hmac", reqResult, '\n');

			BuyRefundOrdResult result = new BuyRefundOrdResult(r0_Cmd, r1_Code, r2_TrxId, r3_Amt, r4_Cur, hmac);

			return result;
		}
		#endregion



        //日志
        public static void logstr(string orderid, string str,string hmac)
        {
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Web.HttpContext.Current.Server.MapPath("YeePay_HTMLCommon.log"), true);
                sw.BaseStream.Seek(0, System.IO.SeekOrigin.End);
                sw.WriteLine(DateTime.Now.ToString() + "[" + orderid + "]" + "[" + str + "]" + "[" + hmac + "]");
                sw.Flush();
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
	}
}