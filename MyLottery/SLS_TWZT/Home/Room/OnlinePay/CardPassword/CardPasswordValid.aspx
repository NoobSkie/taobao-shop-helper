<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/OnlinePay/CardPassword/CardPasswordValid.aspx.cs" inherits="Home_Room_OnlinePay_CardPassword_CardPasswordValid" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>卡密充值-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %></title>
    <meta name="keywords" content="卡密充值" />
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <link href="../../Style/css.css" rel="stylesheet" type="text/css" />
</head><link rel="shortcut icon" href="../../../../favicon.ico"/>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9FC8EA">
            <tr>
                <td valign="top" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="../../images/bg_blue_30.jpg">
                        <tr>
                            <td height="30">
                                <table width="738" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="40" height="30" align="center">
                                            <img src="../../images/jiantou_5.gif" width="12" height="8" />
                                        </td>
                                        <td class="blue_num">
                                            我的资料 &gt; 卡密充值
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div style="padding: 5px;">
                        <table width="100%" align="center" cellpadding="5" cellspacing="1" bgcolor="#9FC8EA">
                            <tr>
                                <td width="104" bgcolor="#f5f5f5">
                                    <div align="right">
                                        输入卡密：</div>
                                </td>
                                <td bgcolor="#ffffff" class="blue">
                                    <asp:TextBox ID="tbCardPassword" runat="server" Width="220px" MaxLength="20" CssClass="in_text"></asp:TextBox>
                                    &nbsp;<a href="../../../../Html/9wee/index.html" target="_blank">我还没有卡密，如何获得卡密？</a>
                                </td>
                            </tr>
                             <tr>
                                <td width="104" bgcolor="#f5f5f5">
                                    <div align="right">
                                        输入手机号码：</div>
                                </td>
                                <td bgcolor="#ffffff" class="blue">
                                    <asp:TextBox ID="tbMobile" runat="server" Width="220px" MaxLength="11" CssClass="in_text"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <ShoveWebUI:ShoveConfirmButton ID="btnValid" runat="server"
                                            Text="确定"  Style="border: #9FC8EA 1px solid; background-color: #D6E9F5;
                                            padding-top: 4px;" onclick="btnValid_Click" />
                                </td>
                            </tr>
                            <tr id="trValid" runat="server" visible="false">
                                <td width="104" bgcolor="#f5f5f5">
                                    <div align="right">
                                        输入较验码：</div>
                                </td>
                                <td bgcolor="#ffffff" class="blue">
                                    <asp:TextBox ID="tbCode" runat="server" Width="220px" MaxLength="6" CssClass="in_text"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <ShoveWebUI:ShoveConfirmButton ID="btnOK" runat="server"
                                            Text="立即充值"  Style="border: #9FC8EA 1px solid; background-color: #D6E9F5;
                                            padding-top: 4px;" onclick="btnOK_Click" />
                                </td>
                            </tr>
                            <tr id="trInfo" runat="server"  visible="false">
                                <td width="104" bgcolor="#f5f5f5">
                                </td>
                                <td bgcolor="#ffffff">
                                    <asp:Label ID="lbInfo" runat="server" ForeColor="Red" Text="您好，系统已经发送一串校验码到你的手机，请将接收到的字串输入到校验码框内，再点击立即充值按钮完成卡密充值。"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#ffffff" colspan="2" style="height:48px;">
                                    &nbsp;&nbsp;&nbsp;&nbsp;<span style="color:Red;">温馨提示：请小心输入您的卡密号码！多次输入错误的卡密号码，系统将会自动暂时锁定您的卡密充值功能！</span>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" class="blue" style="background-color: White;">
                                    &nbsp;&nbsp;&nbsp; -- <a class="li3" href="../../AccountDetail.aspx">查看我的账户</a>
                                    &nbsp;&nbsp;&nbsp; -- <a class="li3" href="../Default.aspx">添加电话投注卡</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>

