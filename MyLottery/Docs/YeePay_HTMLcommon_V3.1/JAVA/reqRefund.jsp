<%@page language="java" contentType="text/html;charset=gbk"%>
<%@page import="com.yeepay.PaymentForOnlineService,com.yeepay.RefundResult;"%>
<%!	String formatString(String text){ 
			if(text == null) {
				return ""; 
			}
			return text;
		}
%>
<%
	request.setCharacterEncoding("GBK");
	String pb_TrxId     	= formatString(request.getParameter("pb_TrxId"));   	//�ױ�������ˮ��
	String p3_Amt     		= formatString(request.getParameter("p3_Amt"));		//�˿���
	String p4_Cur     		= formatString(request.getParameter("p4_Cur"));		//���ױ���
	String p5_Desc     		= formatString(request.getParameter("p5_Desc"));		//�˿�˵��
	//new String(formatString(request.getParameter("p5_Desc")).getBytes("iso-8859-1"),"gbk");//����ת�������
	try {
		RefundResult rr = PaymentForOnlineService.refundByTrxId(pb_TrxId,p3_Amt,p4_Cur,p5_Desc);	// ���ú�̨�����ѯ����
		out.println("ҵ������ [r0_Cmd:" + rr.getR0_Cmd() + "]<br>");
		out.println("��ѯ��� [r1_Code:" + rr.getR1_Code() + "]<br>");
		out.println("�ױ�֧��������ˮ�� [r2_TrxId:" + rr.getR2_TrxId() + "]<br>");
		out.println("֧����� [r3_Amt:" + rr.getR3_Amt() + "]<br>");
		out.println("���ױ��� [r4_Cur:" + rr.getR4_Cur() + "]<br>");
	} catch(Exception e) {
		//byte[] by = e.getMessage().getBytes("UTF-8");
		
		//String errMsg = new String(by,"GBK");
		out.println("Refund fail:" + e.getMessage());
	}
%>

