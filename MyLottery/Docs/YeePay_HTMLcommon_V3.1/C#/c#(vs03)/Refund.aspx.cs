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
	/// Refund ��ժҪ˵����
	/// </summary>
	public class Refund : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			// ���� Response�����ʽΪGB2312
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
					Response.Write("�˿�ɹ�");
					Response.Write("<br>�˿���:" + result.R3_Amt);
				}
				else
				{
					Response.Write("�˿�ʧ�� " + result.R1_Code);
				}
			}
			catch (Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
