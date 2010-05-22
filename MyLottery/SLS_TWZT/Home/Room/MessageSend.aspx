<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/MessageSend.aspx.cs" inherits="Home_Room_MessageSend" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <link href="Style/div.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" background="images/bg_blue_30.jpg">
            <tr>
                <td height="30">
                    <table width="738" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="40" height="30" align="center">
                                <img src="images/jiantou_5.gif" width="12" height="8" />
                            </td>
                            <td class="blue_num">
                                在线提问 &gt; 发送短信
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div style="padding: 5px;">
            <table border="0" align="center" cellpadding="0" cellspacing="1" width="98%" style="background-color: #9FC8EA;">
                <tr style="background-color: White;">
                    <td align="center">
                        <br />
                        <table cellspacing="0" cellpadding="0" width="626" border="0">
                            <tr>
                                <td class="td2" style="width: 67px" valign="top" height="25">
                                    发送给：
                                </td>
                                <td class="td2" height="25" align="left">
                                        <asp:TextBox ID="tbAim" runat="server" BorderWidth="1px" Width="549px" Enabled="False">admin</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td2" style="width: 67px" valign="top" height="25">
                                    发送内容：
                                </td>
                                <td class="td2" height="25" align="left">
                                        <asp:TextBox ID="tbContent" runat="server" BorderWidth="1px" Width="550px" MaxLength="50" Height="153px"></asp:TextBox><br />
                                        请不要发送黄色、反动、泄露国家机密、违反相关法律、进行人身攻击、广告等内容。长度不超过 50 个汉字。
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" height="10" align="left">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" height="40">
                                    <font color="#999999">
                                        <ShoveWebUI:ShoveConfirmButton ID="btnSend" runat="server" AlertText="确定填写无误并发送短消息吗？" Text=" 发 送 " OnClick="btnSend_Click" /></font>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <font face="Tahoma">
                                        <asp:Label ID="labSendResult" runat="server" ForeColor="Red"></asp:Label></font>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="background-color: White;">
                    <td valign="middle" align="right" height="40">
                        <font face="Tahoma">
                            <asp:HyperLink ID="btnMessage" runat="server" NavigateUrl="Message.aspx">查看我的短消息</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; </font>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
