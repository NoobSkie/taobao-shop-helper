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
	/// QueryOrderStatus ��ժҪ˵����
	/// </summary>
	public class QueryOrderStatus : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			// �̼ҵĽ��׶�����
			string p2_Order = Request.Form["p2_Order"];
			try
			{
				// ��ѯ����
				BuyQueryOrdDetailResult result = Buy.QueryOrdDetail(p2_Order);

				if (result.R1_Code == "1")
				{
					Response.Write("��ѯ�ɹ�!");
					Response.Write("<br>�̻�������:" + result.R6_Order);
					Response.Write("<br>��Ʒ����:" + result.R5_Pid);
					Response.Write("<br>֧�����:" + result.R3_Amt);
					Response.Write("<br>����״̬:" + result.Rb_PayStatus);
				}
				else
				{
					Response.Write("<br>��ѯʧ��!" + result.R1_Code);
				}
			}

			catch (Exception ex)
			{
				Response.Write(ex.Message);
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
