<%@ page language="C#" autoeventwireup="true" CodeFile="ISPAccount.aspx.cs" inherits="Admin_ISPAccount" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="Table1" cellspacing="0" cellpadding="0" width="573" align="center" border="0" style="width: 573px; height: 171px">
                <tr>
                    <td colspan="2" height="30">
                    </td>
                </tr>
                <tr>
                    <td style="width: 72px">
                        <font face="宋体">账户余额</font></td>
                    <td>
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Height="16px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 72px">
                        <font face="宋体">短信单价</font></td>
                    <td>
                        <asp:Label ID="Label2" runat="server" ForeColor="Red" Height="16px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 72px">
                        <font face="宋体">注册时间</font></td>
                    <td>
                        <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 72px">
                        <font face="宋体">过期时间</font></td>
                    <td>
                        <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 72px">
                        <font face="宋体">用户类型</font></td>
                    <td>
                        <asp:Label ID="Label5" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 72px" height="20">
                    </td>
                    <td height="20">
                    </td>
                </tr>
                <tr>
                    <td style="width: 72px" valign="top">
                        <font face="宋体">发送统计</font></td>
                    <td>
                        <asp:Label ID="Label6" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
