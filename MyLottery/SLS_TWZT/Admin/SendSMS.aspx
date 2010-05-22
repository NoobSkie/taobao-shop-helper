<%@ page language="C#" autoeventwireup="true" CodeFile="SendSMS.aspx.cs" inherits="Admin_SendSMS" enableEventValidation="false" %>

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
            <table id="Table1" cellspacing="0" cellpadding="0" width="654" align="center" border="0">
                <tr>
                    <td style="border-bottom: #990000 1px dashed" align="center">
                        <font face="宋体">
                            <br />
                            <strong><font color="#996633">发送手机短信</font></strong></font></td>
                </tr>
                <tr>
                    <td align="center">
                        <br />
                        <table id="Table4" cellspacing="0" cellpadding="0" width="626" border="0">
                            <tr>
                                <td class="td2" style="width: 67px" valign="top" height="25" align="right">
                                    <font color="#999999">发送给：</font></td>
                                <td class="td2" height="25" align="left">
                                    <font face="宋体">
                                        <asp:TextBox ID="tbAim" runat="server" BorderWidth="1px" BorderColor="Silver" Width="560px"></asp:TextBox><br />
                                        <font color="#999999">多个用户可以用,隔开。如：shove,3km,dudu,我爱500W。<font face="宋体">最多同时只能发送 50 个用户，超过的部分系统将不发送。</font></font></font></td>
                            </tr>
                            <tr>
                                <td colspan="2" height="10">
                                </td>
                            </tr>
                            <tr>
                                <td class="td2" style="width: 67px" valign="top" height="25">
                                    <font face="宋体" color="#999999">短信内容：</font></td>
                                <td class="td2" height="25" align="left">
                                    <font face="宋体">
                                        <asp:TextBox ID="tbContent" runat="server" BorderWidth="1px" BorderColor="Silver" Width="560px" MaxLength="140" Height="100px" TextMode="MultiLine"></asp:TextBox><br />
                                        <font color="#999999">长度不超过 70 个汉字或 140 个英文字符&nbsp;。</font></font></td>
                            </tr>
                            <tr>
                                <td colspan="2" height="10">
                                </td>
                            </tr>
                            <tr style="display:none;">
                                <td class="td2" style="width: 67px" valign="top" height="25">
                                    <font face="宋体" color="#999999">系统功能：</font></td>
                                <td class="td2" height="25" align="left">
                                    <font face="宋体">
                                        <asp:CheckBox ID="cbSystemMessage" runat="server" Text="系统消息"></asp:CheckBox>&nbsp;<font color="#999999">(发送系统消息将发送给全部用户,上面输入的用户不起作用)</font></font></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" height="40">
                                    <ShoveWebUI:ShoveConfirmButton ID="btnSend" BackgroupImage="../Images/Admin/buttbg.gif" runat="server" Width="60px" Height="20px" Text="发送" AlertText="确定填写无误并发送手机短信吗？" OnClick="btnSend_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left">
                                    <font face="宋体">
                                        <asp:Label ID="labSendResult" runat="server" ForeColor="Red"></asp:Label></font></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
