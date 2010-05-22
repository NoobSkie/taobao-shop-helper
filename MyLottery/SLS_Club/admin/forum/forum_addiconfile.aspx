<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ page language="c#" inherits="Discuz.Web.Admin.addiconfile, SLS.Club" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title>添加表情</title>		
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" /> 
		<script type="text/javascript" src="../js/common.js"></script>
    </head>
	<body>
		<form id="Form1" method="post" runat="server">
		<div class="ManagerForm">
            <fieldset>
	            <legend style="background:url(../images/icons/legendimg.jpg) no-repeat 6px 50%;">文件添加</legend>
	            <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td  class="panelbox" align="left" width="50%">
                            <table width="100%">
                                <tr>
				                    <td style="width:90px;">显示顺序:</td>
				                    <td>
					                    <cc1:TextBox id="displayorder" runat="server" RequiredFieldType="数据校验" CanBeNull="必填" Text="0"></cc1:TextBox>
			                        </td>
                                </tr>
                                <tr>
				                    <td>名称:</td>
				                    <td>
					                    <cc1:UpFile id="url" runat="server" UpFilePath="../../images/posticons/" FileType=".jpg|.gif|.png"></cc1:UpFile>
				                    </td>                                
                                </tr>
                            </table>
                        </td>
                        <td class="panelbox" align="right" width="50%">
                            <table width="100%">
			                    <tr>
				                    <td style="width:90px;">代码:</td>
				                    <td>
					                    <cc1:TextBox id="code" runat="server" RequiredFieldType="暂无校验"></cc1:TextBox>
				                    </td>
		                        </tr>
                            </table>
                        </td>
                    </tr>
                </table>
	        </fieldset>
		<div class="Navbutton"><cc1:Button id="AddIncoInfo" runat="server" Text=" 提 交 "></cc1:Button></div>
		</div>
		</form>
		
	</body>
</html>
