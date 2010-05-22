<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/NewsLogin.aspx.cs" inherits="Home_Room_NewsLogin" enableEventValidation="false" %>
<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <link href="../Web/Style/css.css" rel="stylesheet" type="text/css" />
    <link href="../Web/Style/div.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9BBFCA">
            <tr>
                <td valign="top" class="bg_s" style="height:210px;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-image:url('images/user_left_bg2.jpg')">
                        <tr>
                            <td width="101" background="images/user_left_bg1.jpg" class="blue" style="padding-left: 30px;
                                padding-top: 4px; background-repeat:no-repeat; height:23px;">
                                <strong>会员登录</strong>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                <asp:Panel ID="NoLogin" runat="server" >
                    
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:8px;">
                        <tr>
                            <td width="34%" height="32" align="right" class="blue">
                                用户名：
                            </td>
                            <td width="66%">
                                <asp:TextBox ID="tbUserName" runat="server" size="20" class="in_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="32" align="right" class="blue">
                                密&nbsp;&nbsp;&nbsp;码：
                            </td>
                            <td>
                                <asp:TextBox ID="tbUserPassword" runat="server" TextMode="Password" class="in_text"
                                    size="20" />
                            </td>
                        </tr>
                        <tr id="CheckCode" runat="server">
                            <td height="32" align="right" class="blue">
                                验证码：
                            </td>
                            <td class="black14" style="vertical-align:middle;">
                                <asp:TextBox ID="tbCheckCode" runat="server" MaxLength="6" class="in_text" Width="50px"></asp:TextBox>
                                <ShoveWebUI:ShoveCheckCode ID="ShoveCheckCode1" runat="server" ForeColor="CornflowerBlue"
                                    BackColor="SeaShell" Charset="All" Height="20px" SupportDir="~/ShoveWebUI_client" style="vertical-align:top; padding-top:3px;">
                                </ShoveWebUI:ShoveCheckCode>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" colspan="2" align="center" class="blue" style="padding-top: 9px;">
                                <ShoveWebUI:ShoveConfirmButton ID="btnLogin" Style="cursor:pointer;"
                                    runat="server" Width="74px" Height="29px" CausesValidation="False" BackgroupImage="../Web/images/bt_denglu.gif"
                                    BorderStyle="None" OnClick="btnLogin_Click" />
                                    <span style="margin-left:10px;"></span>
                                    <a href="../../MemberSharing/Alipay/Login.aspx" target="_top">
                                    <img src="../Web/images/bt_zfb.gif" width="124" height="29" border="0" style="vertical-align: top;" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td height="36" colspan="2" align="left" class="blue" style="padding-left: 18px;">
                                <a href="../Web/UserReg.aspx" target="_blank">新会员注册</a> | <a href="../Web/ForgetPassword.aspx"
                                    target="_blank">忘记密码</a>
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>
                    <asp:Panel ID="Longining" runat="server">
                        <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" style="color: #000000; padding-top:10px;">
                                    <asp:Label ID="lbUserName" runat="server">XXX,您好！</asp:Label>
                                    <asp:Label ID="lbUserType" runat="server">级别：XX</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 207px; height:101px; text-align:center;" class="blue">
                                    <table width="88%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="color: #000000" id="tdRoom" runat="server">
                                                <a id="aroom" runat="server">购彩大厅</a>
                                            </td>
                                            <td id="tdAccount" runat="server">
                                                <a id="aAccount" runat="server">个人账户</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdUserInfo" runat="server">
                                                <a id="aUserInfo" runat="server">我的资料</a>
                                            </td>
                                            <td id="tdtouzhu" runat="server">
                                                <a id="atouzhu" runat="server">我的投注</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <%--<td id="tdSurrogate" runat="server">
                                                <asp:HyperLink ID="hlSurrogate" runat="server">代理平台</asp:HyperLink>
                                            </td>--%>
                                            <td id="tdAdmin" runat="server">
                                                <asp:HyperLink ID="hlAdmin" runat="server">超级管理</asp:HyperLink>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td id="td1" style="color: red; padding-left: 20px;" colspan="2" align="left">
                                                <asp:Label ID="lbAlipay" runat="server" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="td2" style="color: red; padding-left: 20px; padding-top: 5px; text-decoration: none;"
                                                colspan="2" align="left">
                                                <asp:HyperLink ID="hyReg" runat="server" NavigateUrl="~/UserLogin.aspx" Target="_parent"><span style="color:Red; font-size:14px;">我要验证</span></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td id="tdPro" runat="server">
                                                <asp:HyperLink ID="hlCps" runat="server">联盟管理</asp:HyperLink>
                                            </td>
                                            <td class="white_a" style="color: #000000">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" id="tdOut" runat="server" style="padding:8px; padding-bottom:10px;">
                                    <ShoveWebUI:ShoveConfirmButton ID="imgbtnLogout" Style="cursor: hand; color: #000000;"
                                        BackgroupImage="images/exit.gif" runat="server" Height="34px" Width="160px"
                                        CausesValidation="False" BorderStyle="None" OnClick="imgbtnLogout_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
