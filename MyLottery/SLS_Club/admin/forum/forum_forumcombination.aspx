<%@ page language="c#" inherits="Discuz.Web.Admin.forumcombination, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc1" TagName="PageInfo" Src="../UserControls/PageInfo.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title>forumcombination</title>		
		<script type="text/javascript" src="../js/common.js"></script>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    </head>

	<body>
		<form id="Form1" method="post" runat="server">
        <uc1:PageInfo id="info1" runat="server" Icon="Information"
        Text="合并论坛后, 源论坛的帖子全部转入目标论坛, 同时删除源论坛"></uc1:PageInfo>
        <uc1:PageInfo id="PageInfo1" runat="server" Icon="Warning"
        Text="目前的功能要求进行合并的论坛不能有子论坛"></uc1:PageInfo>
        <div class="ManagerForm">
            <fieldset>
		    <legend style="background:url(../images/icons/icon44.jpg) no-repeat 6px 50%;">合并版块</legend>
		    <table cellspacing="0" cellpadding="4" width="100%" align="center">
                <tr>
                    <td  class="panelbox" align="left" width="50%">
                        <table width="100%">
                            <tr>
					            <td style="width: 90px">源论坛:</td>
					            <td><cc1:DropDownTreeList id="sourceforumid" runat="server"></cc1:DropDownTreeList>
					            </td>
				            </tr>
				        </table>
				    </td>
				    <td  class="panelbox" align="left" width="50%">
                        <table width="100%">
                            <tr>
					            <td style="width: 90px">目标论坛:</td>
					            <td><cc1:DropDownTreeList id="targetforumid" runat="server"></cc1:DropDownTreeList></td>
				            </tr>
				        </table>
				    </td>
			    </tr>
			</table>			
            </fieldset>
            <div class="Navbutton">
			    <cc1:Button id="SaveCombinationInfo" runat="server" Text=" 提 交 "></cc1:Button>
			</div>
        </div>
		</form>		
		
	</body>
</html>
