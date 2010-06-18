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
using com.yeepay.bank;

namespace YeePay_HTMLcommon_V3._1
{
	/// <summary>
	/// Req 的摘要说明。
	/// </summary>
	public class Req : System.Web.UI.Page
	{
		private string p2_Order;
		private string p3_Amt;
		private string p4_Cur;
		private string p5_Pid;
		private string p6_Pcat;
		private string p7_Pdesc;
		private string p8_Url;
		private string p9_SAF;
		private string pa_MP;
		private string pd_FrpId;
		private string pr_NeedResponse;

		private void Page_Load(object sender, System.EventArgs e)
		{
				// 设置 Response编码格式为GB2312
				Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");

				// 商户订单号,选填.
				//若不为""，提交的订单号必须在自身账户交易中唯一;为""时，易宝支付会自动生成随机的商户订单号.
				p2_Order = Request.Form["p2_Order"];

				// 支付金额,必填.
				//单位:元，精确到分.                   
				p3_Amt = Request.Form["p3_Amt"];

				//交易币种,固定值"CNY".
				p4_Cur = "CNY";

				//商品名称
				//用于支付时显示在易宝支付网关左侧的订单产品信息.
				p5_Pid = Request.Form["p5_Pid"];

				//商品种类
				p6_Pcat = Request.Form["p6_Pcat"];

				//商品描述
				p7_Pdesc = Request.Form["p7_Pdesc"];

				//商户接收支付成功数据的地址,支付成功后易宝支付会向该地址发送两次成功通知.
				p8_Url = Request.Form["p8_Url"];

				//送货地址
				//为“1”: 需要用户将送货地址留在易宝支付系统;为“0”: 不需要，默认为 ”0”.
				p9_SAF = "0";

				//商户扩展信息
				//商户可以任意填写1K 的字符串,支付成功时将原样返回.	
				pa_MP = Request.Form["pa_MP"];

				//银行编码
				//默认为""，到易宝支付网关.若不需显示易宝支付的页面，直接跳转到各银行、神州行支付、骏网一卡通等支付页面，该字段可依照附录:银行列表设置参数值.
				pd_FrpId = Request.Form["pd_FrpId"];

				//应答机制
				//默认为"1": 需要应答机制;
				pr_NeedResponse = "1";

				string url = Buy.CreateBuyUrl(p2_Order, p3_Amt, p4_Cur, p5_Pid, p6_Pcat, p7_Pdesc, p8_Url, p9_SAF, pa_MP, pd_FrpId, pr_NeedResponse);

				Response.Redirect(url);
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
