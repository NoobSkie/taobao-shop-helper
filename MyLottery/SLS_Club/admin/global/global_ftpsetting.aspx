<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ page language="C#" autoeventwireup="true" inherits="Discuz.Web.Admin.ftpsetting, SLS.Club" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>远程附件设置</title>
    <link href="../styles/tab.css" type="text/css" rel="stylesheet" />
    <link href="../styles/colorpicker.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/common.js"></script>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/AjaxHelper.js"></script>
    <script type="text/javascript" src="../js/modalpopup.js"></script>
    <script type="text/javascript">
        function ShowFtpLayout(ischecked)
        {
            document.getElementById("FtpLayout").style.display = ischecked ? "block" : "none";
        }
        function validate(thisform)
        {
            document.getElementById("success").style.display = "block";
            var remoteurl = document.getElementById("Remoteurl").value;
            var uploadpath = document.getElementById("Uploadpath").value;
            if(uploadpath.lastIndexOf("/") == uploadpath.length - 1)
            {
                resetpage();
                alert("附件保存路径非法，不能以“/”结尾");
                return false;
            }
            if(remoteurl.substring(0,7).toLowerCase() != "http://" ||
               remoteurl.lastIndexOf("/") == remoteurl.length - 1)
            {
                resetpage();
                alert("远程访问 URL 非法！不是以“http://”开头或是以“/”结尾");
                return false;
            }
//            if(remoteurl.indexOf(uploadpath) == -1)
//            {
//                resetpage();
//                alert("远程访问 URL 未以“附件保存路径”结尾");
//                return false;
//            }
            if(document.getElementById("Allowupload_0").checked)
            {
                var result = TestFtp();
                if(result != "ok")
                {
                    resetpage();
                    ShowFtpLayout(false);
                    document.getElementById("Allowupload_1").checked = true;
                    alert("无法链接FTP，不能保存设置！");
                    return false;
                }
            }
            return true;
        }
        function resetpage()
        {
            document.getElementById("success").style.display = "none";
            document.getElementById("SaveFtpInfo").disabled = false;
        }
        function TestFtp()
        {
            var serveraddress = document.getElementById("Serveraddress").value;
            var serverport = document.getElementById("Serverport").value;
            var username = document.getElementById("Username").value;
            var password = document.getElementById("Password").value;
            var timeout = document.getElementById("Timeout").value;
            var uploadpath = document.getElementById("Uploadpath").value;
            var url = "serveraddress="+serveraddress+"&serverport="+serverport+"&username="+username+"&password="+password.replace(/\+/g,"%2B");
            url += "&timeout="+timeout+"&uploadpath="+uploadpath;
            var result = getReturn('global_ajaxcall.aspx?opname=ftptest&' + url);
            return result;
        }
        function TestFtp_Click()
        {
            document.getElementById("TestFtpButton").disabled = true;
            var result = TestFtp();
            if(result == "ok")
            {
                alert("远程附件设置测试通过！");
            }
            else
            {
                alert(result);
            }
            document.getElementById("TestFtpButton").disabled = false;
        }
    </script>
</head>
<body>
    <div class="ManagerForm">
		<form id="Form1" method="post" runat="server">
		<fieldset>
		<legend style="background:url(../images/icons/icon56.jpg) no-repeat 6px 50%;">远程附件设置</legend>
		<table cellspacing="0" cellpadding="4" width="100%" align="center">
		    <tr>
                <td class="panelbox" colspan="2">
                    <table width="100%">
                        <tr>
                            <td style="width: 110px">启用远程附件:</td>
                            <td>
                                <cc1:RadioButtonList ID="Allowupload" runat="server" RepeatColumns="2" Width="20%">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0" Selected="true">否</asp:ListItem>
                                </cc1:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>			    
		    <div id="FtpLayout" runat="server">
		    <table cellspacing="0" cellpadding="4" width="100%" align="center">
            <tr>
                <td class="panelbox" align="left" width="50%">
                    <table width="100%">
                        <tr>
					        <td style="width: 110px">FTP服务器:</td>
					        <td>
					            <cc1:TextBox id="Serveraddress" runat="server" HintInfo="可以是 FTP 服务器的 IP 地址或域名" 
					            RequiredFieldType="暂无校验" CanBeNull="必填" Width="170"></cc1:TextBox>
					        </td>
                        </tr>
                        <tr>
					        <td>用户名:</td>
					        <td>
				                <cc1:TextBox id="Username" runat="server" HintInfo="该帐号必需具有以下权限:读取文件 写入文件 删除文件 创建目录 子目录继承" 
				                CanBeNull="必填" Width="170"></cc1:TextBox>
				            </td>
                        </tr>
                        <tr>
					        <td>超时时间(秒):</td>
                            <td>
                                <cc1:TextBox ID="Timeout" runat="server" HintInfo="单位:秒,10 为服务器默认.0为不受超时时间限制." CanBeNull="必填" 
                                MinimumValue="0" Width="100" Text="10"></cc1:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td  class="panelbox" align="right" width="50%">
                    <table width="100%">
				        <tr>
					        <td style="width: 110px">FTP端口:</td>
					        <td>
					            <cc1:TextBox id="Serverport" runat="server" HintInfo="默认为 21" 
					            MinimumValue="1" CanBeNull="必填" size="7" maxlength="5" Text="21"></cc1:TextBox>
					        </td>
				        </tr>
				        <tr>
					        <td>密  码:</td>
					        <td>
					            <cc1:TextBox id="Password" TextMode="password" runat="server" RequiredFieldType="暂无校验" CanBeNull="必填" Width="170"></cc1:TextBox>
					            <input type="hidden" id="hiddpassword" runat="server" />
					        </td>
				        </tr>
				        <tr>
					        <td>附件保存路径:</td>
					        <td>
					            <cc1:TextBox ID="Uploadpath" runat="server" 
					            HintInfo="远程附件目录的绝对路径或相对于 FTP 主目录的相对路径,结尾不要加斜杠&amp;quot;/&amp;quot;,&amp;quot;.&amp;quot;表示 FTP 主目录" CanBeNull="必填" 
					            RequiredFieldType="暂无校验" Width="170" Text="forumattach/"></cc1:TextBox>
					        </td>
				        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="panelbox" colspan="2">
                    <table width="100%">
                        <tr>
                            <td style="width: 110px">远程访问 URL:</td>
                            <td>
                                <cc1:TextBox ID="Remoteurl" runat="server" HintInfo="仅支持 HTTP 协议，结尾不要加斜杠&amp;quot;/&amp;quot;;<br/>例如上传的文件是&amp;quot;1.jpg&amp;quot;, 则最终远程链接为<br/>&amp;quot;http://远程访问URL/1.jpg&amp;quot;" 
                                CanBeNull="必填" Width="400"></cc1:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;
	                            <span><button type="button" class="ManagerButton" id="TestFtpButton" onclick="TestFtp_Click()"><img src="../images/submit.gif" /> 测试远程附件设置 </button></span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="panelbox" colspan="2">
                    <table width="100%">
                        <tr>
                            <td style="width: 110px">是否保留本地附件:</td>
                            <td>
                                <cc1:RadioButtonList ID="Reservelocalattach" runat="server" RepeatColumns="2" Width="20%">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Selected="true" Value="0">否</asp:ListItem>
                                </cc1:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table>
		</div>			        
		</fieldset>
		<div class="Navbutton">
		    <cc1:Button id="SaveFtpInfo" runat="server" Text=" 提 交 " OnClick="SaveFtpInfo_Click" ValidateForm="true"></cc1:Button>
		</div>
		<cc1:Hint ID="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
		<div style="display:none">
		    <td>FTP模式:</td>
			<td>
		        <cc1:RadioButtonList ID="Mode" runat="server" RepeatColumns="2" Width="96%">
                    <asp:ListItem Value="1" Selected="true">被动模式</asp:ListItem>
                    <asp:ListItem Value="2">主动模式</asp:ListItem>
                </cc1:RadioButtonList>
            </td>
		</div>
		</form>
	</div>
	<script type="text/javascript">document.getElementById("Password").value = document.getElementById("hiddpassword").value;</script>
</body>
</html>
