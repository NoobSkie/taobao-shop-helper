<!-- #include file="yeepayCommon.asp" -->
<%
'**************************************************
'* @Description �ױ�֧����Ʒͨ��֧���ӿڷ���  
'* @V3.0
'* @Author rui.xin
'**************************************************

	'	ֻ��֧���ɹ�ʱ�ױ�֧���Ż�֪ͨ�̻�.
	''֧���ɹ��ص������Σ�����֪ͨ������֧����������е�p8_Url �ϣ�������ض���;��������Ե�ͨѶ.
	
	Dim r0_Cmd
	Dim r1_Code
	Dim r2_TrxId
	Dim r3_Amt
	Dim r4_Cur
	Dim r5_Pid
	Dim r6_Order
	Dim r7_Uid
	Dim r8_MP
	Dim r9_BType
	Dim hmac
	
	Dim bRet
	Dim returnMsg
	
	'�������ز���
	Call getCallBackValue(r0_Cmd,r1_Code,r2_TrxId,r3_Amt,r4_Cur,r5_Pid,r6_Order,r7_Uid,r8_MP,r9_BType,hmac)
	Call createLog(logName)
	'�жϷ���ǩ���Ƿ���ȷ��True/False��
	bRet = CheckHmac(r0_Cmd,r1_Code,r2_TrxId,r3_Amt,r4_Cur,r5_Pid,r6_Order,r7_Uid,r8_MP,r9_BType,hmac)
	'���ϴ���ͱ�������Ҫ�޸�.
	
	
	'У������ȷ
	returnMsg	= ""
	If bRet = True Then
	  If(r1_Code="1") Then
	  	
		'��Ҫ�ȽϷ��صĽ�����̼����ݿ��ж����Ľ���Ƿ���ȣ�ֻ����ȵ�����²���Ϊ�ǽ��׳ɹ�.
		'������Ҫ�Է��صĴ������������ƣ����м�¼�������Դ�����ֹ��ͬһ�������ظ��������������.	  	      	  
		
			If(r9_BType="1") Then
				'	����֧��ҳ�淵��	
				returnMsg	= returnMsg	&	r3_Amt & "Ԫ ֧���ɹ���"				
			ElseIf(r9_BType="2") Then				
	  		'	�����ҪӦ�����������д��"success"��ͷ��stream,��Сд������.
	  		''�ױ�֧���յ���stream������Ϊ�̻����յ������򽫼�������֪ͨ��ֱ���̻��յ�Ϊֹ��
		 		Response.write("success")
				'Call createLog(logName)
				returnMsg	= returnMsg	& "����֧������������"
			End IF  
	  End IF
	Else
		returnMsg	= returnMsg	&	"������Ϣ���۸�"
	End If


%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>�ױ�֧�� - ���Ͽ��� | ����������ѡ�����̣�֧�����ױ��������ֿɿ���</title>
<meta name="description" content="�ױ�֧����Ϊ���������ڷ����ṩ�̣��빤�����С��������С��������С�ũҵ���С��������еȶ�ҹ� �����м�VISA��MasterCard�⿨��֯���ܺ�����Ϊ���˿ͻ��ṩ����֧�����绰֧���������˻���Ʒ��� Ϊ��ҵ�̻��ṩ��������֧�������մ�����ί�н����Լ�B2Bת��ȶ�����ֵҵ��">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="css/yeepaytest.css" type="text/css" rel="stylesheet" />
</head>
	<body>
		<table width="50%" border="0" align="center" cellpadding="0" cellspacing="0" style="border:solid 1px #107929">
		  <tr>
		    <td><table width="100%" border="0" align="center" cellpadding="5" cellspacing="1">
		  </tr>
		  <tr>
		    <td height="30" align="left"><a href="http://www.yeepay.com/"><img src="http://www.yeepay.com/new-indeximages/yeepay-indexlogo.gif" alt="YeePay�ױ�֧�� ���µĶ�Ԫ��֧��ƽ̨ ��ȫ �ɿ� ��� ��������" width="141" height="47" border="0" /></a></td>
		  </tr>
		  <tr>
		  	<td height="30" colspan="2" bgcolor="#6BBE18"><span style="color: #FFFFFF">��л��ʹ���ױ�֧��ƽ̨</span></td>
		  </tr>
		  <tr>
		  	<td colspan="2" bgcolor="#CEE7BD">�ױ�֧��ͨ�ýӿ���ʾ��</td>
		  </tr>
		  <tr>
		  	<td align="left" width="30%">&nbsp;&nbsp;�̻�������</td>
		  	<td align="left">&nbsp;&nbsp;<%= r6_Order %></td>
      </tr>
		  <tr>
		  	<td align="left">&nbsp;&nbsp;֧�����</td>
		  	<td align="left">&nbsp;&nbsp;<%= returnMsg %></td>
      </tr>
      <tr>
      	<td height="5" bgcolor="#6BBE18" colspan="2"></td>
      </tr>
      </table></td>
        </tr>
      </table>
	</body>
</html>