<%@ page language="c#" inherits="Discuz.Web.Admin.searchsm, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title>searchsm</title>		
	    <script type="text/javascript" src="../js/common.js"></script>
	    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../js/modalpopup.js"></script>
    </head>

	<body>
		<form id="Form1" method="post" runat="server">
		<div class="ManagerForm">
		<fieldset>
		    <legend style="background:url(../images/icons/icon51.jpg) no-repeat 6px 50%;">清理短消息</legend>
		    <table cellspacing="0" cellpadding="4" width="100%" align="center">
		    <tr>
                <td class="panelbox" colspan="2">
                    <table width="100%">
                        <tr><td><input type="checkbox" name="isnew" value="1" id="isnew" checked runat="server" /> 不删除未读信息</td></tr>
                    </table>
                </td>
            </tr>
		    <tr>
                <td  class="panelbox" align="left" width="50%">
                    <table width="100%">
                        <tr>
					        <td style="width: 100px">删除多少天以<br />前的短消息:</td>
					        <td>
				                <cc1:TextBox id="postdatetime" runat="server" HintTitle="提示" HintInfo="不限制时间请输入" RequiredFieldType="数据校验" Width="40"></cc1:TextBox>
				            </td>
                        </tr>
                        <tr>
					        <td>按关键字搜索主题:</td>
					        <td>
				                <cc1:TextBox id="subject" runat="server" HintTitle="提示" HintInfo="关键字中间用&amp;quot;,&amp;quot;分割" RequiredFieldType="暂无校验" Width="200"></cc1:TextBox>
				            </td>
                        </tr>
                    </table>
                </td>
                <td  class="panelbox" align="right" width="50%">
                    <table width="100%">
				        <tr>
					        <td style="width: 100px">按发信用户名清理:</td>
					        <td>
					            <cc1:TextBox id="msgfromlist" runat="server" HintTitle="提示" HintInfo="多用户名中间请用半角逗号 &amp;quot;,&amp;quot; 分割" 
					            RequiredFieldType="暂无校验" Width="200"></cc1:TextBox> &nbsp; 
					            &nbsp;<input type="checkbox" name="lowerupper" value="1" id="lowerupper" runat="server"> 不区分大小写
					        </td>
				        </tr>
				        <tr>
					        <td>按关键字搜索全文:</td>
					        <td>
				                <cc1:TextBox id="message" runat="server" HintTitle="提示" HintInfo="关键字中间用&amp;quot;,&amp;quot;分割" RequiredFieldType="暂无校验" Width="200"></cc1:TextBox>
				            </td>
				        </tr>
                    </table>
                </td>
            </tr>
            </table>
		</fieldset>
		<cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
		<div class="Navbutton">
		<cc1:Button id="SaveSearchInfo" runat="server" Text=" 删除短消息 " ButtonImgUrl="../images/del.gif"></cc1:Button> &nbsp;&nbsp;  
		<input type="checkbox" name="isupdateusernewpm" value="1" id="isupdateusernewpm" checked runat="server" />同时更新收件人新短消息数</div>
		</div>	
		</form>		
		
	</body>
</html>
