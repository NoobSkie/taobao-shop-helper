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
	/// Req ��ժҪ˵����
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
				// ���� Response�����ʽΪGB2312
				Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");

				// �̻�������,ѡ��.
				//����Ϊ""���ύ�Ķ����ű����������˻�������Ψһ;Ϊ""ʱ���ױ�֧�����Զ�����������̻�������.
				p2_Order = Request.Form["p2_Order"];

				// ֧�����,����.
				//��λ:Ԫ����ȷ����.                   
				p3_Amt = Request.Form["p3_Amt"];

				//���ױ���,�̶�ֵ"CNY".
				p4_Cur = "CNY";

				//��Ʒ����
				//����֧��ʱ��ʾ���ױ�֧���������Ķ�����Ʒ��Ϣ.
				p5_Pid = Request.Form["p5_Pid"];

				//��Ʒ����
				p6_Pcat = Request.Form["p6_Pcat"];

				//��Ʒ����
				p7_Pdesc = Request.Form["p7_Pdesc"];

				//�̻�����֧���ɹ����ݵĵ�ַ,֧���ɹ����ױ�֧������õ�ַ�������γɹ�֪ͨ.
				p8_Url = Request.Form["p8_Url"];

				//�ͻ���ַ
				//Ϊ��1��: ��Ҫ�û����ͻ���ַ�����ױ�֧��ϵͳ;Ϊ��0��: ����Ҫ��Ĭ��Ϊ ��0��.
				p9_SAF = "0";

				//�̻���չ��Ϣ
				//�̻�����������д1K ���ַ���,֧���ɹ�ʱ��ԭ������.	
				pa_MP = Request.Form["pa_MP"];

				//���б���
				//Ĭ��Ϊ""�����ױ�֧������.��������ʾ�ױ�֧����ҳ�棬ֱ����ת�������С�������֧��������һ��ͨ��֧��ҳ�棬���ֶο����ո�¼:�����б����ò���ֵ.
				pd_FrpId = Request.Form["pd_FrpId"];

				//Ӧ�����
				//Ĭ��Ϊ"1": ��ҪӦ�����;
				pr_NeedResponse = "1";

				string url = Buy.CreateBuyUrl(p2_Order, p3_Amt, p4_Cur, p5_Pid, p6_Pcat, p7_Pdesc, p8_Url, p9_SAF, pa_MP, pd_FrpId, pr_NeedResponse);

				Response.Redirect(url);
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
