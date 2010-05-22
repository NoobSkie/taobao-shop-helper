<%@ page language="c#" validaterequest="false" inherits="Discuz.Web.Admin.timespan, SLS.Club" enableviewstate="false" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc1" TagName="TextareaResize" Src="../UserControls/TextareaResize.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
	<title>baseset</title>
	<script type="text/javascript" src="../js/common.js"></script>
	<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="../js/modalpopup.js"></script>
</head>
<body>
	<div class="ManagerForm">
	<form id="Form1" method="post" runat="server">
		<fieldset>
		    <legend style="background:url(../images/icons/icon2.jpg) no-repeat 6px 50%;">时间段设置</legend>
		        <table cellspacing="0" cellpadding="4" width="100%" align="center">
		            <tr>
		                <td  class="panelbox" width="50%" align="left">
		                    <table width="100%">
		                        <tr>
					                <td style="width: 120px">禁止访问时间段:</td>
					                <td>                        
					                    <uc1:TextareaResize id="visitbanperiods" runat="server" HintShowType="down" cols="35" controlname="visitbanperiods" 
					                        HintInfo="每天该时间段内用户不能访问论坛, 请使用 24 小时时段格式, 每个时间段一行, 如需要也可跨越零点, 留空为不限制. 例如:每日晚 11:25 到次日早 5:05 可设置为: 23:25-5:05, 每日早 9:00 到当日下午 2:30 可设置为: 9:00-14:30.注意: 格式不正确将可能导致意想不到的问题. 所有时间段设置均以论坛系统默认时区为准, 不受用户自定义时区的影响" HintTitle="提示" HintHeight="0"></uc1:TextareaResize>
					                </td>
		                        </tr>
		                        <tr>
					                <td>发帖审核时间段:</td>
                                    <td>
					                    <uc1:TextareaResize id="postmodperiods" runat="server" cols="35"  controlname="postmodperiods" 
					                        HintInfo="每天该时间段内用户发帖不直接显示, 需经版主或管理员人工审核才能发表, 格式和用法同上" HintTitle="提示"></uc1:TextareaResize>
					                </td>
		                        </tr>
		                        <tr>
					                <td>禁止全文搜索时间段:</td>
                                    <td>
					                    <uc1:TextareaResize id="searchbanperiods" runat="server"  cols="35" controlname="searchbanperiods" 
					                    HintInfo="每天该时间段内用户不能使用全文搜索, 格式和用法同上" HintTitle="提示"></uc1:TextareaResize>
					                </td>
		                        </tr>
		                    </table>
		                </td>
		                <td  class="panelbox" width="50%" align="right">
		                    <table width="100%">
				                <tr>
					                <td style="width: 120px">禁止发帖时间段:</td>
                                    <td>
                                        <uc1:TextareaResize id="postbanperiods" runat="server"  cols="35" controlname="postbanperiods" 
                                            HintInfo="每天该时间段内用户不能发帖, 格式和用法同上" HintTitle="提示"></uc1:TextareaResize>
					                </td>
				                </tr>
				                <tr>
					                <td>禁止下载附件时间段:</td>
                                    <td>
					                    <uc1:TextareaResize id="attachbanperiods" runat="server"  cols="35" controlname="attachbanperiods" 
					                        HintInfo="每天该时间段内用户不能下载附件, 格式和用法同上" HintTitle="提示"></uc1:TextareaResize>
					                </td>
				                </tr>
		                    </table>
		                </td>
		            </tr>
		        </table>
		    
		    
		    
			<table class="table1" cellspacing="0" cellpadding="4" width="100%" align="center">
			</table>
		</fieldset>	
		<cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
		<div align="center">
		    <cc1:Button id="SaveInfo" runat="server" Text=" 提 交 "></cc1:Button>
		</div>		
	</form>
	</div>		
	
</body>
</html>
