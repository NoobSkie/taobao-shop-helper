<%@ page language="C#" autoeventwireup="true" CodeFile="Login.aspx.cs" inherits="Agent_CardPassword_Login" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../../Style/Surrogate.css" type="text/css" rel="stylesheet" />
</head><link rel="shortcut icon" href="../favicon.ico" />
<body>
    <form id="form1" runat="server">
    <div style="vertical-align: middle; text-align: center;">
        <br />
        <table width="442" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="background-image: url(../../Images/Login/sd_user_top.jpg); height: 30px;">
                </td>
            </tr>
            <tr>
                <td height="260px" align="center" valign="middle" background="../../Images/Login/chucuodenlu_16.jpg">
                    <table width="96%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="36%" style="height: 24px">
                                <div align="right">
                                    管理帐号：</div>
                            </td>
                            <td width="64%" style="height: 24px" align="left">
                                <asp:TextBox ID="tbID" runat="server" Width="148px" onkeypress="if (window.event.keyCode == 13) {tbPassword.focus();}"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 29px">
                                <div align="right">
                                    管理密码：
                                </div>
                            </td>
                            <td align="left" style="height: 29px">
                                <ShoveWebUI:ShovePasswordTextBox ID="tbPassword" runat="server" Width="148px" onkeypress="if (window.event.keyCode == 13) {tbCheckCode.focus();}"></ShoveWebUI:ShovePasswordTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table width="96%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="33" style="width: 36%">
                                            <div align="right">
                                                验证码：</div>
                                        </td>
                                        <td align="left" style="width: 29%">
                                            <asp:TextBox ID="tbCheckCode" runat="server" Width="64px" onkeypress="if (window.event.keyCode == 13) {__doPostBack('btnLogin','');}"></asp:TextBox>
                                        </td>
                                        <td width="40%" align="left">
                                            &nbsp;<ShoveWebUI:ShoveCheckCode ID="CheckCode" runat="server" 
                                                BackColor="SeaShell" Charset="All" ForeColor="CornflowerBlue" Height="22px" 
                                                Width="64px" 
                                                SupportDir="../../ShoveWebUI_client" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="41" colspan="2">
                                <div align="center">
                                    <table width="187" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="center">
                                                <ShoveWebUI:ShoveConfirmButton ID="btnLogin" runat="server" BackgroupImage="../../Images/Login/den1.jpg" BorderStyle="None" Height="25px" Width="75px" OnClick="btnLogin_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td height="13" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        
                        <tr>
                            <td height="13" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
