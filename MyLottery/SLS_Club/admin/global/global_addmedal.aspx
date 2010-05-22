<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ page language="c#" inherits="Discuz.Web.Admin.addmedal, SLS.Club" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
    <head>
		<title>勋章添加</title>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" /> 
		<script type="text/javascript" src="../js/common.js"></script>
    </head>
	<body>
		<form id="Form1" method="post" runat="server">
		<div class="ManagerForm">
		<fieldset>
		<legend style="background:url(../images/icons/legendimg.jpg) no-repeat 6px 50%;">勋章添加</legend>
		<table cellspacing="0" cellpadding="4" width="100%" align="center">
            <tr>
                <td  class="panelbox" align="left" width="50%">
                    <table width="100%">
                        <tr>
					        <td style="width:90px;">名称:</td>
					        <td><cc1:TextBox id="name" runat="server" RequiredFieldType="暂无校验" CanBeNull="必填" Width="80%"></cc1:TextBox></td>
                        </tr>
                    </table>
                </td>
                <td  class="panelbox" align="right" width="50%">
                    <table width="100%">
				        <tr>
					        <td style="width: 90px;">是否有效:</td>
					        <td>
						        <cc1:RadioButtonList id="available" runat="server">
							        <asp:ListItem Value="1" Selected="True">有效</asp:ListItem>
							        <asp:ListItem Value="0">无效</asp:ListItem>
						        </cc1:RadioButtonList>
					        </td>
				        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="panelbox" colspan="2">
                    <table width="100%">
                        <tr>
					        <td style="width: 90px;">勋章图片上传:</td>
					        <td><cc1:UpFile id="image" runat="server" UpFilePath="../../images/medals" FileType=".jpg|.gif|.png" ShowPostDiv="false"></cc1:UpFile></td>                            
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
		</fieldset>
		<div align="center"><cc1:Button id="AddMedalInfo" runat="server" Text=" 提 交 " OnClick="AddMedalInfo_Click"></cc1:Button></div>
		</div>
		</form>
		
	</body>
</html>
