using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using com.yeepay.common;
using com.yeepay.bean;
using com.yeepay.bank;




namespace YeePay_HTMLcommon_V3._3
{
	/// <summary>
	/// Callback 的摘要说明。
	/// </summary>
	public class Callback : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (!IsPostBack)
			{
				// 校验返回数据包
				BuyCallbackResult result = Buy.VerifyCallback(FormatQueryString.GetQueryString("p1_MerId"),FormatQueryString.GetQueryString("r0_Cmd"), FormatQueryString.GetQueryString("r1_Code"), FormatQueryString.GetQueryString("r2_TrxId"),
					FormatQueryString.GetQueryString("r3_Amt"), FormatQueryString.GetQueryString("r4_Cur"), FormatQueryString.GetQueryString("r5_Pid"), FormatQueryString.GetQueryString("r6_Order"), FormatQueryString.GetQueryString("r7_Uid"),
					FormatQueryString.GetQueryString("r8_MP"), FormatQueryString.GetQueryString("r9_BType"), FormatQueryString.GetQueryString("rp_PayDate"), FormatQueryString.GetQueryString("hmac"));

				if ((result.ErrMsg)=="" || result.ErrMsg==null)
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

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
