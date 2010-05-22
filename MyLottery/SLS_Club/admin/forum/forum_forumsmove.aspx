<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ page language="c#" inherits="Discuz.Web.Admin.forumsmove, SLS.Club" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
  <head>
		<title>forumsmove</title>		
		<script type="text/javascript" src="../js/common.js"></script>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../js/modalpopup.js"></script>
    </head>
	<body>
	<div class="ManagerForm">
		<form id="Form1" method="post" runat="server">
		    <fieldset>
		    <legend style="background:url(../images/icons/legendimg.jpg) no-repeat 6px 50%;">移动版块</legend>
		    <table cellspacing="0" cellpadding="4" width="100%" align="center">
                <tr>
                    <td  class="panelbox" align="left" width="50%">
                        <table width="100%">
                            <tr>
					            <td style="width:90px;">源版块:</td>
					            <td>
						            <cc1:DropDownTreeList id="sourceforumid" runat="server"></cc1:DropDownTreeList>
					            </td>
                            </tr>
			                <tr>
					            <td style="width:90px;">移动方式:</td>
					            <td>
						            <cc1:RadioButtonList id="movetype" runat="server" RepeatColumns="1">
						                <asp:ListItem Value="0" >调整顺序到目标版块前</asp:ListItem>
						                <asp:ListItem Value="1" Selected="True">作为目标版块的子版块</asp:ListItem>
						            </cc1:RadioButtonList>  
					            </td>
				            </tr>
                        </table>
                    </td>
                    <td  class="panelbox" align="right" width="50%">
                        <table width="100%">
				            <tr>
					            <td style="width:90px;">目标版块:</td>
					            <td>
						            <cc1:ListBoxTreeList id="targetforumid" runat="server"></cc1:ListBoxTreeList>
					            </td>
				            </tr>
                        </table>
                    </td>
                </tr>
            </table>
			<div class="Navbutton">
	        	<cc1:Button id="SaveMoveInfo" runat="server" Text=" 提 交 "/>&nbsp;&nbsp;
	        	<button type="button" class="ManagerButton" onclick="javascript:window.location.href='forum_forumstree.aspx';"><img src="../images/arrow_undo.gif" /> 返 回 </button>
			</div>
			</fieldset>
		</form>
	</div>
	
	</body>
</html>
