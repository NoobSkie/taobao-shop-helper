<%@page language="java" contentType="text/html;charset=gbk"%>
<%@page import="com.yeepay.PaymentForOnlineService,com.yeepay.QueryResult"%>
<%!	String formatString(String text){ if(text == null) return "";  return text;}%>
<%
	String p2_Order   = formatString(request.getParameter("p2_Order"));     			// �̼�Ҫ��ѯ�Ľ��׶�����
	try {
		QueryResult qr = PaymentForOnlineService.queryByOrder(p2_Order);	// ���ú�̨�����ѯ����
		out.println("ҵ������ [r0_Cmd:" + qr.getR0_Cmd() + "]<br>");
		out.println("��ѯ��� [r1_Code:" + qr.getR1_Code() + "]<br>");
		out.println("�ױ�֧��������ˮ�� [r2_TrxId:" + qr.getR2_TrxId() + "]<br>");
		out.println("֧����� [r3_Amt:" + qr.getR3_Amt() + "]<br>");
		out.println("���ױ��� [r4_Cur:" + qr.getR4_Cur() + "]<br>");
		out.println("��Ʒ���� [r5_Pid:" + qr.getR5_Pid() + "]<br>");
		out.println("�̻������� [r6_Order:" + qr.getR6_Order() + "]<br>");
		out.println("�̻���չ��Ϣ [r8_MP:" +  qr.getR8_MP() + "]<br>");
		out.println("֧��״̬ [rb_PayStatus:" +  qr.getRb_PayStatus() + "]<br>");
		out.println("���˿���� [rc_RefundCount:" + qr.getRc_RefundCount() + "]<br>");
		out.println("���˿��� [rd_RefundAmt:" + qr.getRd_RefundAmt() + "]<br>");
	} catch(Exception e) {
		out.println(e.getMessage());
	}
%>


