using System;

namespace com.yeepay.bean
{
	/// <summary>
	/// BuyBankDirectConnectResult 的实体类
	/// </summary>
	[Serializable]
	public class BuyBankDirectConnectResult
	{
		// 定义内部变量
		private string r0_Cmd;
		private string r1_Code;
		private string r2_TrxId;
		private string r3_Amt;
		private string r4_Cur;

		private string r6_Order;
		private string ro_BankOrderId;
		private string r8_MP;
		private string hmac;

		private string reqUrl;
		private string reqResult;

		/// <summary>
		/// 骏网支付请求返回序列
		/// </summary>
		/// <param name="r0_Cmd"></param>
		/// <param name="r1_Code"></param>
		/// <param name="r2_TrxId"></param>
		/// <param name="r3_Amt"></param>
		/// <param name="r4_Cur"></param>
		/// <param name="r6_Order"></param>
		/// <param name="ro_BankOrderId"></param>
		/// <param name="r8_MP"></param>
		/// <param name="hmac"></param>
		public BuyBankDirectConnectResult(string r0_Cmd, string r1_Code, string r2_TrxId, string r3_Amt, string r4_Cur,
			string r6_Order, string ro_BankOrderId, string r8_MP, string hmac, string reqUrl,
			string reqResult)
		{
			this.r0_Cmd = r0_Cmd;
			this.r1_Code = r1_Code;
			this.r2_TrxId = r2_TrxId;
			this.r3_Amt = r3_Amt;
			this.r4_Cur = r4_Cur;

			this.r6_Order = r6_Order;
			this.ro_BankOrderId = ro_BankOrderId;
			this.r8_MP = r8_MP;
			this.hmac = hmac;

			this.reqUrl			= reqUrl;
			this.reqResult		= reqResult;
		}

		// 公共属性
		public string R0_Cmd
		{
			get{return r0_Cmd;}
		}
		public string R1_Code
		{
			get{return r1_Code;}
		}
		public string R2_TrxId
		{
			get{return r2_TrxId;}
		}
		public string R3_Amt
		{
			get{return r3_Amt;}
		}
		public string R4_Cur
		{
			get{return r4_Cur;}
		}
		///--
		public string R6_Order
		{
			get{return r6_Order;}
		}
		public string Ro_BankOrderId
		{
			get{return ro_BankOrderId;}
		}
		public string R8_MP
		{
			get{return r8_MP;}
		}
		public string Hmac
		{
			get{return hmac;}
		}
		//--
		public string ReqUrl
		{
			get{return reqUrl;}
		}
		public string ReqResult
		{
			get{return reqResult;}
		}
	}
}
