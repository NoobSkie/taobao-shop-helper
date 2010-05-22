<%@ page language="c#" autoeventwireup="true" inherits="Discuz.Web.Admin.global_passportsetting, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc1" TagName="TextareaResize" Src="../UserControls/TextareaResize.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>整合程序设置</title>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/common.js"></script>
    <script type="text/javascript">
        function validate(theform)
        {
            if(document.getElementById("appname").value == "")
            {
                resetpage();
                alert("整合程序名称没有填写!");
                document.getElementById("appname").focus();
                return false;
            }
            if(document.getElementById("appurl").value == "")
            {
                resetpage();
                alert("整合程序Url地址没有填写!");
                document.getElementById("appurl").focus();
                return false;
            }
            if(document.getElementById("callbackurl").value == "")
            {
                resetpage();
                alert("登录完成后返回地址没有填写!");
                document.getElementById("callbackurl").focus();
                return false;
            }
            return true;
        }
        
        function resetpage()
        {
            document.getElementById("success").style.display = "none";
            document.getElementById("savepassportinfo").disabled = false;            
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="ManagerForm">
		<fieldset>
		<legend style="background:url(../images/icons/legendimg.jpg) no-repeat 6px 50%;">整合程序设置</legend>
		<table cellspacing="0" cellpadding="4" width="100%" align="center">
            <tr>
                <td class="panelbox" width="50%" align="left">
                    <table width="100%">
                        <tr>
		                    <td style="width: 120px">整合程序名称:</td>
		                    <td><cc1:TextBox id="appname" runat="server"  CanBeNull="必填" Width="250"></cc1:TextBox></td>
                        </tr>
                        <tr>
		                    <td style="width: 120px">登录完成后返回地址:</td>
		                    <td><cc1:TextBox id="callbackurl" runat="server" HintInfo="通过通行证登录以后返回整合程序的地址(Callback URL)" CanBeNull="必填" Width="250"></cc1:TextBox></td>
                        </tr>
                    </table>
                </td>
                <td class="panelbox" width="50%" align="right">
                    <table width="100%">
                        <tr>
		                    <td style="width: 120px">整合程序 Url 地址:</td>
		                    <td><cc1:TextBox id="appurl" runat="server" HintInfo="整合程序的首页地址"  CanBeNull="必填" Width="250"></cc1:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="panelbox" colspan="2">
                    <table width="100%">
                        <tr>
                            <td style="width: 120px">允许的服务器IP地址:<br />(以&quot;,&quot;分隔)</td>
                            <td>
                                <uc1:TextareaResize id="ipaddresses" runat="server" controlname="ipaddresses" HintTitle="提示" 
                                HintInfo="如果你提交的是例如&amp;quot; 10.1.20.1, 10.1.20.3 &amp;quot;,其它地址将被拒绝" HintPosOffSet="160" >
                                </uc1:TextareaResize>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="panelbox" colspan="2">
                    <table width="100%">
                        <tr>
		                    <td align="center">
		                    </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>	
		</fieldset>
		<div class="Navbutton">
            <input type="hidden" id="apikeyhidd" runat="server" />
            <cc1:Button id="savepassportinfo" runat="server" Text=" 提 交 " OnClick="savepassportinfo_Click" ValidateForm="true"></cc1:Button>&nbsp;&nbsp;
            <button type="button" class="ManagerButton" id="Button3" onclick="window.history.back()"><img src="../images/arrow_undo.gif"/> 返 回 </button>
		</div>
		<cc1:Hint ID="hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
	</div>
    </form>
    
</body>
</html>
