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
	/// Callback ��ժҪ˵����
	/// </summary>
	public class Callback : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (!IsPostBack)
			{
				// У�鷵�����ݰ�
				BuyCallbackResult result = Buy.VerifyCallback(FormatQueryString.GetQueryString("p1_MerId"),FormatQueryString.GetQueryString("r0_Cmd"), FormatQueryString.GetQueryString("r1_Code"), FormatQueryString.GetQueryString("r2_TrxId"),
					FormatQueryString.GetQueryString("r3_Amt"), FormatQueryString.GetQueryString("r4_Cur"), FormatQueryString.GetQueryString("r5_Pid"), FormatQueryString.GetQueryString("r6_Order"), FormatQueryString.GetQueryString("r7_Uid"),
					FormatQueryString.GetQueryString("r8_MP"), FormatQueryString.GetQueryString("r9_BType"), FormatQueryString.GetQueryString("rp_PayDate"), FormatQueryString.GetQueryString("hmac"));

				if ((result.ErrMsg)=="" || result.ErrMsg==null)
				{
					if (result.R1_Code == "1")
					{
						if (result.R9_BType == "1")
						{
							//  callback��ʽ:������ض���
							Response.Write("֧���ɹ�!<br>��ƷID:" + result.R5_Pid + "<br>�̻�������:" + result.R6_Order + "<br>֧�����:" + result.R3_Amt + "<br>�ױ�֧��������ˮ��:" + result.R2_TrxId + "<BR>");
						}
						else if (result.R9_BType == "2")
						{
							// * ����Ƿ�������������Ҫ��Ӧһ���ض��ַ���'SUCCESS',����'SUCCESS'֮ǰ���������κ������ַ����,��֤�����������'SUCCESS'�ַ���
							Response.Write("SUCCESS");
						}
					}
					else
					{
						Response.Write("֧��ʧ��!");
					}
				}
				else
				{
					Response.Write("����ǩ����Ч!");
				}
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
