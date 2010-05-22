<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ page language="c#" inherits="Discuz.Web.Admin.emailconfig, SLS.Club" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>邮箱设置</title>
		<script type="text/javascript" src="../js/common.js"></script>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />  
	</head>
	<body>
	<div class="ManagerForm">
		<form id="Form1" method="post" runat="server">
		<fieldset>
		<legend style="background:url(../images/icons/icon41.jpg) no-repeat 6px 50%;">SMTP配置</legend>
		<table cellspacing="0" cellpadding="4" width="100%" align="center">
            <tr>
                <td  class="panelbox" align="left" width="50%">
                    <table width="100%">
                        <tr>
					        <td style="width: 80px">SMTP服务器:</td>
					        <td><cc1:TextBox id="smtp" runat="server" RequiredFieldType="暂无校验" CanBeNull="必填" Width="200" HintInfo="设置发送邮件的SMTP服务器地址"></cc1:TextBox></td>
                        </tr>
                        <tr>
					        <td>系统邮箱名称:</td>
					        <td><cc1:TextBox id="sysemail" runat="server" RequiredFieldType="电子邮箱" CanBeNull="必填" Width="200" HintInfo="设置发送邮件的邮箱地址"></cc1:TextBox></td>
                        </tr>
                        <tr>
					        <td>系统邮箱密码:</td>
					        <td><cc1:TextBox id="password" runat="server" RequiredFieldType="暂无校验" CanBeNull="必填" Width="200" HintInfo="设置邮箱的密码"></cc1:TextBox></td>
                        </tr>
                    </table>
                </td>
                <td  class="panelbox" align="right" width="50%">
                    <table width="100%">
				        <tr>
					        <td style="width: 80px">SMTP端口:</td>
					        <td><cc1:TextBox id="port" runat="server" RequiredFieldType="数据校验" CanBeNull="必填" size="7" maxlength="5" HintInfo="设置SMTP服务器的端口"></cc1:TextBox></td>
				        </tr>
				        <tr>
					        <td>用户名:</td>
					        <td><cc1:TextBox id="userName" runat="server" RequiredFieldType="暂无校验" CanBeNull="必填" Width="200" HintInfo="设置邮箱的用户名"></cc1:TextBox></td>
				        </tr>
				        <tr>
					        <td>发送邮件程序:</td>
					        <td><cc1:dropdownlist id="smtpemail" runat="server" HintInfo="设置发送邮件的程序"></cc1:dropdownlist></td>
				        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center"><cc1:Button id="SaveEmailInfo" runat="server" Text=" 提 交 "></cc1:Button></td>
            </tr>
        </table>
		</fieldset>
		<fieldset>
		<legend style="background:url(../images/icons/icon40.jpg) no-repeat 6px 50%;">测试邮件配置</legend>
			<table cellspacing="0" cellpadding="4" width="100%" align="center">
				<tr>
					<td style="width: 80px">EMAIL:</td>
					<td style="width: 350px"><cc1:TextBox id="testEmail" runat="server" RequiredFieldType="电子邮箱" CanBeNull="可为空" Width="300" HintInfo="设置要测试的邮箱地址,测试程序将发送一封邮件到测试邮箱中"></cc1:TextBox></td>
				    <td><cc1:Button id="sendTestEmail" runat="server" Text=" 发送测试邮件 "></cc1:Button></td></tr>
			</table>
		</fieldset>
		<cc1:Hint ID="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
		</form>
		</div>
	</body>
</html>
