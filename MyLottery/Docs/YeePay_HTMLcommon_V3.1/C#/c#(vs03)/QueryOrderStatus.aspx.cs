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
using com.yeepay.bean;

namespace YeePay_HTMLcommon_V3._1
{
	/// <summary>
	/// QueryOrderStatus 的摘要说明。
	/// </summary>
	public class QueryOrderStatus : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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
