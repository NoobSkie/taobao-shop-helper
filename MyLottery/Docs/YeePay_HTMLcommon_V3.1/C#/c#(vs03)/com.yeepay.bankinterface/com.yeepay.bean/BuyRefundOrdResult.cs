using System;

namespace com.yeepay.bean
{
	/// <summary>
	/// BuyRefundOrdResult��ʵ����
	/// </summary>
	[Serializable]
	public class BuyRefundOrdResult
	{
		private string r0_Cmd;
		private string r1_Code;
		private string r2_TrxId;
		private string r3_Amt;
		private string r4_Cur;

		private string hmac;

		/// <summary>
		/// B2C����֧���˿������
		/// </summary>
		/// <param name="r0_Cmd"></param>
		/// <param name="r1_Code"></param>
		/// <param name="r2_TrxId"></param>
		/// <param name="r3_Amt"></param>
		/// <param name="r4_Cur"></param>
		/// <param name="hmac"></param>
		public BuyRefundOrdResult(string r0_Cmd, string r1_Code, string r2_TrxId, string r3_Amt, string r4_Cur, string hmac)
		{
			this.r0_Cmd		= r0_Cmd;
			this.r1_Code	= r1_Code;
			this.r2_TrxId	= r2_TrxId;
			this.r3_Amt		= r3_Amt;
			this.r4_Cur		= r4_Cur;

			this.hmac		= hmac;
		}

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
//---
		public string Hmac
		{
			get{return hmac;}
		}
	}
}
