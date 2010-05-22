<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ page language="c#" inherits="Discuz.Web.Admin.searchpost, SLS.Club" %>
<%@ Register TagPrefix="cc4" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc1" TagName="DropDownPost" Src="../UserControls/DropDownPost.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title>searchpost</title>		
		<link href="../styles/calendar.css" type="text/css" rel="stylesheet" />
		<script type="text/javascript" src="../js/common.js"></script>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../js/modalpopup.js"></script>
    </head>

	<body>
		<form id="Form1" method="post" runat="server">
		<div class="ManagerForm">
		<fieldset>
		<legend style="background:url(../images/icons/icon19.jpg) no-repeat 6px 50%;">搜索帖子</legend>
		<table cellspacing="0" cellpadding="4" width="100%" align="center">
		    <tr>
                <td  class="panelbox" align="left" width="50%">
                    <table width="100%">
                        <tr>
					        <td style="width: 80px">所在论坛:</td>
					        <td><cc1:dropdowntreelist id="forumid" runat="server"></cc1:dropdowntreelist></td>
                        </tr>
                        <tr>
					        <td>发表时间范围:</td>
					        <td>
						        开始日期:<cc4:Calendar id="postdatetimeStart" runat="server" ReadOnly="True" ScriptPath="../js/calendar.js"></cc4:Calendar><br />
						        结束日期:<cc4:Calendar id="postdatetimeEnd" runat="server" ReadOnly="True" ScriptPath="../js/calendar.js"></cc4:Calendar>
				            </td>
                        </tr>
                        <tr>
					        <td>发帖 IP:</td>
					        <td>
				                <cc1:TextBox id="Ip" runat="server" HintTitle="提示" HintInfo="通配符 &amp;quot;*&amp;quot; 如 &amp;quot;127.0.*.*&amp;quot;, 慎用!" 
				                RequiredFieldType="暂无校验" Width="150"></cc1:TextBox>
				            </td>
                        </tr>
                    </table>
                </td>
                <td  class="panelbox" align="right" width="50%">
                    <table width="100%">
				        <tr>
					        <td style="width: 80px">当前帖子表:</td>
					        <td><uc1:DropDownPost id="postlist" runat="server" controlname="postlist"></uc1:DropDownPost></td>
				        </tr>				
				        <tr>
					        <td>发帖用户名:</td>
					        <td>
						        <cc1:TextBox id="poster" runat="server" HintTitle="提示" HintInfo="多用户名中间请用半角逗号 &amp;quot;,&amp;quot; 分割" RequiredFieldType="暂无校验" width="200"></cc1:TextBox> 
						        &nbsp;<input id="lowerupper" type="checkbox" CHECKED value="1" name="lowerupper" runat="server">  不区分大小写
				            </td>
				        </tr>
				        <tr>
				            <td>内容关键字:</td>
					        <td>
				                <cc1:TextBox id="message" runat="server" HintTitle="提示" HintInfo="多关键字中间请用半角逗号 &amp;quot;,&amp;quot; 分割" 
				                RequiredFieldType="暂无校验"  width="200"></cc1:TextBox>
				            </td>
				        </tr>
                    </table>
                </td>
            </tr>
        </table>
		</fieldset>
		<cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
		<div class="Navbutton"><cc1:Button id="SaveConditionInf" runat="server" Text="搜索符合条件的帖子" ButtonImgUrl="../images/search.gif"></cc1:Button></div>
		</div>	
		</form>
		
	</body>
</html>
