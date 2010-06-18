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
	/// Refund 的摘要说明。
	/// </summary>
	public class Refund : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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
