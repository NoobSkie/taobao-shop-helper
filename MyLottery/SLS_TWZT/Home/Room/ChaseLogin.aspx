<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/ChaseLogin.aspx.cs" inherits="Home_Room_ChaseLogin" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="36" align="left" class="blue14">
                <strong>如果您已是本中心会员请登录：</strong>
            </td>
        </tr>
        <tr>
            <td height="36" align="left">
                <table width="260" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="74" height="36" align="right" class="blue12">
                            用户名：
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="tbFormUserName" runat="server" size="20" class="in_text"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="36" align="right" class="blue12">
                            密&nbsp;&nbsp;&nbsp;码：
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="tbFormUserPassword" runat="server" TextMode="Password" class="in_text"
                                size="20" />
                        </td>
                    </tr>
                    <tr id="CheckCode" runat="server">
                        <td height="36" align="right" class="blue12">
                            验证码：
                        </td>
                        <td width="80">
                            <asp:TextBox ID="tbFormCheckCode" runat="server" MaxLength="6" class="in_text" size="6"></asp:TextBox>
                        </td>
                        <td width="52">
                            <shovewebui:shovecheckcode id="ShoveCheckCode1" runat="server" forecolor="CornflowerBlue"
                                backcolor="SeaShell" charset="All" height="22px" supportdir="~/ShoveWebUI_client"
                                width="49px" style="vertical-align: top; padding-top: 3px;"></shovewebui:shovecheckcode>
                        </td>
                        <td width="54" class="blue12_line">
                            <a href="ChaseLogin.aspx">刷新</a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="36" align="left">
                <table width="260" border="0" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
                    <tr>
                        <td width="109" height="36" align="right" class="hui12">
                            <shovewebui:shoveconfirmbutton id="btnLogin" style="cursor: pointer;" runat="server"
                                width="83px" height="29px" causesvalidation="False" backgroupimage="images/bt_denglu.jpg"
                                borderstyle="None" onclick="btnLogin_Click" />
                        </td>
                        <td width="151" class="blue12_line" style="padding-left: 10px;">
                            <a href="ForgetPassword.aspx" target="_blank">忘记密码？</a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="20" align="left" class="red14">
                <div id="hr">
                </div>
            </td>
        </tr>
        <tr>
            <td height="36" align="left" class="red14">
                <span class="blue14">如果还不是<%=_Site.Name %>会员，点击这里</span><a href="../../UserLogin.aspx" target="_blank">快速完成注册</a>
            </td>
        </tr>
    </table>
    </form>
   <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
