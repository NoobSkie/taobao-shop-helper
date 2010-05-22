<%@ page language="c#" inherits="Discuz.Web.Admin.adduser, SLS.Club" autoeventwireup="false" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>添加用户</title>				
		<script type="text/javascript" src="../js/common.js"></script>	
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
   	    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
		<script type="text/javascript" src="../js/modalpopup.js"></script>	
        <script type="text/javascript">
             function IsValidPost()
             {  
                 var admingroup="";
                
                 var groupid = document.getElementById("groupid");
        				
                 if((groupid.value=="1")||(groupid.value=="2")||(groupid.value=="3")) 
                 {
                     admingroup=groupid.options[groupid.value].innerHTML;
                 }
                 
                 if(groupid.value=="0")
                 {   
                     alert('您未选择所属用户组');
                     return false;
                 }
                    
                 
                 if(admingroup!="")
                    if(confirm('您是要添加 "'+admingroup+'" 组的用户吗?'))
                    {
                       return true;
                    }
                    else
                    {
                       return false;
                    }
                    
                return true;
             }
        </script>		
    </head>
	<body>
	<div class="ManagerForm">
		<form id="Form1" method="post" runat="server">
		<fieldset>
		    <legend style="background:url(../images/icons/icon9.jpg) no-repeat 6px 50%;">添加用户</legend>
		    <table cellspacing="0" cellpadding="4" width="100%" align="center">
                <tr>
                    <td  class="panelbox" width="50%" align="left">
                        <table width="100%">
                            <tr>
					            <td style="width: 90px">用户名:</td>
					            <td><cc1:textbox id="userName" runat="server" CanBeNull="必填" RequiredFieldType="暂无校验"  MaxLength="20" Size="30"></cc1:textbox></td>
                            </tr>
                            <tr>
					            <td>E-mail:</td>
					            <td><cc1:textbox id="email" runat="server" CanBeNull="必填" RequiredFieldType="电子邮箱"  Width="200" MaxLength="50" Size="60"></cc1:textbox></td>
                            </tr>
                            <tr>
					            <td>金币设置:</td>
					            <td><cc1:textbox id="credits" runat="server" CanBeNull="必填" RequiredFieldType="数据校验" MaxLength="8" Size="10" HintInfo="设置用户的初始金币"></cc1:textbox></td>
                            </tr>
                            <tr>
					            <td>身份证号:</td>
					            <td><cc1:textbox id="idcard" RequiredFieldType="身份证号码" runat="server" MaxLength="20" Size="20"></cc1:textbox></td>
                            </tr>
                            <tr>
					            <td>固定电话号码:</td>
					            <td><cc1:textbox id="phone" runat="server" CanBeNull="可为空" MaxLength="20" Size="20"></cc1:textbox></td>
                            </tr>
                        </table>
                    </td>
                    <td  class="panelbox" width="50%" align="right">
                        <table width="100%">
				            <tr>
					            <td style="width: 90px">密码:</td>
					            <td><cc1:TextBox ID="password" runat="server" CanBeNull="必填" MaxLength="32" RequiredFieldType="暂无校验" Size="30"></cc1:TextBox></td>
				            </tr>
				            <tr>
					            <td>所属用户组:</td>
					            <td><cc1:DropDownList id="groupid" runat="server"></cc1:DropDownList></td>
				            </tr>
				            <tr>
					            <td>真实姓名:</td>
					            <td><cc1:textbox id="realname" runat="server" RequiredFieldType="暂无校验" MaxLength="10" Size="10" ></cc1:textbox></td>
				            </tr>
				            <tr>
					            <td>移动电话号码:</td>
					            <td><cc1:textbox id="mobile" runat="server" MaxLength="20" Size="20"></cc1:textbox></td>
				            </tr>
				            <tr>
					            <td>发送邮件到<br />上述邮箱中:</td>
					            <td><input id="sendemail" type="checkbox" runat="server" checked="checked" /></td>
				            </tr>
                        </table>
                    </td>
                </tr>
            </table>
		</fieldset>
		<cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
		<div class="Navbutton">
		    <cc1:Button id="AddUserInfo" runat="server" Text=" 提 交 "></cc1:Button>
		</div>
		</form>
	</div>
	
	</body>
</html>
