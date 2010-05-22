<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/ResetPassword.aspx.cs" inherits="Home_Room_ResetPassword" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>重置密码-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <meta name="keywords" content="重置密码" />
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
<link rel="shortcut icon" href="../../favicon.ico" /></head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
     <div style="margin-top: 10px; text-align: center;">
    <table width="1002" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="15" height="27">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td width="202" align="right" class="blue12" style="padding-right: 10px;">
                            免费咨询电话：<span class="red14"><%= _Site.ServiceTelephone %></span>
                        </td>
                        <td width="77">
                            <a href="#">
                                <img src="images/head_zixun.jpg" width="77" height="20" border="0" /></a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="2" bgcolor="#6699CC">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pSetp1" runat="server">
                    <table width="900" border="0" cellpadding="0" cellspacing="0" bgcolor="#9BBFCA">
                        <tr>
                            <td valign="top" bgcolor="#FFFFFF" class="bg_x" style="padding: 12px 20px 12px 20px;">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <img src="../Web/images/user_title_4.gif" width="248" height="33" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="12">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="1" bgcolor="#CCCCCC">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="12">
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="36" colspan="2" class="td14_2">
                                            会员重置密码
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="18%" height="28" align="right" class="black_menu">
                                            新密码：
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="tbUserPassword" runat="server" TextMode="Password" class="in_text"
                                                size="35" />
                                            <span class="red142">*</span> <span class="red">请输入一个新密码，密码长度必须为 6-16 位。 </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="18%" height="28" align="right" class="black_menu">
                                            确认密码：
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="tbUserPassword2" runat="server" TextMode="Password" class="in_text"
                                                size="35" />
                                            <span class="red142">*</span> <span class="red">请再输入一遍您上面填写的密码。 </span>
                                        </td>
                                    </tr>
                                    <tr id="CheckCode" runat="server">
                                        <td height="28" align="right" class="black_menu">
                                            验证码：
                                        </td>
                                        <td style="vertical-align: middle;" align="left">
                                            <asp:TextBox ID="tbCheckCode" runat="server" MaxLength="6" class="in_text" Width="50px"></asp:TextBox>
                                            <ShoveWebUI:ShoveCheckCode ID="ShoveCheckCode1" runat="server" ForeColor="CornflowerBlue"
                                                BackColor="SeaShell" Charset="All" Height="20px" SupportDir="~/ShoveWebUI_client"
                                                Style="vertical-align: top; padding-top: 3px;"></ShoveWebUI:ShoveCheckCode>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10" align="right" class="black_menu">
                                        </td>
                                        <td class="hui">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25" align="right" class="black_menu">
                                            &nbsp;
                                        </td>
                                        <td class="hui" align="left">
                                            <ShoveWebUI:ShoveConfirmButton ID="btnLogin" Style="cursor: pointer;" runat="server"
                                                CausesValidation="False" BorderStyle="None" Text="重置密码" OnClick="btnResetPassword_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pStep2" runat="server">
                    <asp:Label ID="lbError" runat="server"></asp:Label>
                </asp:Panel>
            </td>
        </tr>
    </table>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>

<script src="JavaScript/Public.js" type="text/javascript"></script>

