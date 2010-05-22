<%@ page language="C#" autoeventwireup="false" inherits="Discuz.Web.Admin.addhelpclass, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <link href="../styles/default.css" rel="stylesheet" type="text/css" id="css" />
		<link href="../styles/editor.css" rel="stylesheet" type="text/css" id="Link1" />
		<script type="text/javascript" src="../js/common.js"></script>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet">        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet">
        <script type="text/javascript" src="../js/modalpopup.js"></script>
    </head>
    <body>
    <div class="ManagerForm">
       <form id="Form1" runat="server" >
       <fieldset>
		    <legend style="background:url(../images/icons/legendimg.jpg) no-repeat 6px 50%;">添加类别</legend>
			    <table class="table1" cellspacing="0" cellPadding="4" width="100%"  height="15%" align="center" >				
				    <tr>
					    <td style="width: 80px">帮助标题:</td>
					    <td style="width: 300px"><cc1:TextBox id="tbtitle" runat="server" CanBeNull="必填" RequiredFieldType="暂无校验"  maxlength="249" size="50"></cc1:TextBox></td>
					    <td align="left">
					        <cc1:Button id="add" runat="server" Text=" 提 交 " OnClick="add_Click" ValidateForm="false"></cc1:Button>&nbsp;&nbsp;
					        <button type="button" class="ManagerButton" id="Button3" onclick="window.history.back();"><img src="../images/arrow_undo.gif"/> 返 回 </button>
					    </td>
				    </tr>
			    </table>    			
		       <div style="display:none">
			    <tr>
				    <td>发布者用户名</td>
				    <td>
						<cc1:TextBox id="poster" runat="server" RequiredFieldType="暂无校验" CanBeNull="必填" MaxLength="20" Enabled="false"></cc1:TextBox>
					</td>
			    </tr>
			    </div>
	    </fieldset>
		</form>
    </div>
    
    </body>
</html>
