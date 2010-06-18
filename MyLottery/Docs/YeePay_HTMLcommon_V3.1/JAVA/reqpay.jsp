<%@page language="java" contentType="text/html;charset=gbk"%>
<%@page import="com.yeepay.*"%>
<%!	String formatString(String text){ 
			if(text == null) {
				return ""; 
			}
			return text;
		}
%>
<%
	request.setCharacterEncoding("GBK");
	String keyValue   		     		= formatString(Configuration.getInstance().getValue("keyValue"));   					// �̼���Կ
	String nodeAuthorizationURL  	= formatString(Configuration.getInstance().getValue("yeepayCommonReqURL"));  	// ���������ַ
	// �̼������û�������Ʒ��֧����Ϣ
	String    p0_Cmd 		     			= formatString("Buy");                               									// ����֧�����󣬹̶�ֵ ��Buy��
	String    p1_MerId 		    		= formatString(Configuration.getInstance().getValue("p1_MerId")); 		// �̻����
	String    p2_Order           	= formatString(request.getParameter("p2_Order"));           					// �̻�������
	String	  p3_Amt           	 	= formatString(request.getParameter("p3_Amt"));      	   							// ֧�����
	String	  p4_Cur    		 			= formatString("CNY");	   		   							// ���ױ���
	String	  p5_Pid 		     			= formatString(request.getParameter("p5_Pid"));	       	   						// ��Ʒ����
	String	  p6_Pcat  		     		= formatString(request.getParameter("p6_Pcat"));	       	   					// ��Ʒ����
	String 	  p7_Pdesc   		 			= formatString(request.getParameter("p7_Pdesc"));		   								// ��Ʒ����
	String 	  p8_Url 	         		= formatString(request.getParameter("p8_Url")); 		       						// �̻�����֧���ɹ����ݵĵ�ַ
	String 	  p9_SAF 		     			= formatString(request.getParameter("p9_SAF")); 			   							// ��Ҫ��д�ͻ���Ϣ 0������Ҫ  1:��Ҫ
	String 	  pa_MP 			 				= formatString(request.getParameter("pa_MP"));         	   						// �̻���չ��Ϣ
	String    pd_FrpId           	= formatString(request.getParameter("pd_FrpId"));       	   					// ֧��ͨ������
	// ���б�ű����д
	pd_FrpId = pd_FrpId.toUpperCase();
	String 	  pr_NeedResponse    	= formatString("1");    // Ĭ��Ϊ"1"����ҪӦ�����
  String 	  hmac 			     			= formatString("");							               							// ����ǩ����
    
    // ���MD5-HMACǩ��
    hmac = PaymentForOnlineService.getReqMd5HmacForOnlinePayment(p0_Cmd,
			p1_MerId,p2_Order,p3_Amt,p4_Cur,p5_Pid,p6_Pcat,p7_Pdesc,
			p8_Url,p9_SAF,pa_MP,pd_FrpId,pr_NeedResponse,keyValue);
%>
<html>
	<head>
		<title>To YeePay Page
		</title>
	</head>
	<body>
		<form name="yeepay" action='<%=nodeAuthorizationURL%>' method='POST' target="_blank">
			<input type='hidden' name='p0_Cmd'   value='<%=p0_Cmd%>'>
			<input type='hidden' name='p1_MerId' value='<%=p1_MerId%>'>
			<input type='hidden' name='p2_Order' value='<%=p2_Order%>'>
			<input type='hidden' name='p3_Amt'   value='<%=p3_Amt%>'>
			<input type='hidden' name='p4_Cur'   value='<%=p4_Cur%>'>
			<input type='hidden' name='p5_Pid'   value='<%=p5_Pid%>'>
			<input type='hidden' name='p6_Pcat'  value='<%=p6_Pcat%>'>
			<input type='hidden' name='p7_Pdesc' value='<%=p7_Pdesc%>'>
			<input type='hidden' name='p8_Url'   value='<%=p8_Url%>'>
			<input type='hidden' name='p9_SAF'   value='<%=p9_SAF%>'>
			<input type='hidden' name='pa_MP'    value='<%=pa_MP%>'>
			<input type='hidden' name='pd_FrpId' value='<%=pd_FrpId%>'>
			<input type="hidden" name="pr_NeedResponse"  value="<%=pr_NeedResponse%>">
			<input type='hidden' name='hmac'     value='<%=hmac%>'>
			<input type='submit' />
		</form>
	</body>
</html>
