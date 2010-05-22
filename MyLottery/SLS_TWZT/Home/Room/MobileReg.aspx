<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/MobileReg.aspx.cs" inherits="Home_Room_MobileReg" enableEventValidation="false" %>
<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register src="UserControls/UserMyIcaile.ascx" tagname="UserMyIcaile" tagprefix="uc2" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我的手机号码验证-用户资料-用户中心-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
<link rel="shortcut icon" href="../../favicon.ico" /></head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
    <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 3px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9FC8EA">
            <tr>
                <td valign="top" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="images/bg_blue_30.jpg">
                        <tr>
                            <td height="30">
                                <table width="738" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="40" height="30" align="center">
                                            <img src="images/jiantou_5.gif" width="12" height="8" />
                                        </td>
                                        <td class="blue_num">
                                            我的资料 &gt; 手机号码验证<input id="tbLotteryID" runat="server" name="tbLotteryID" style="width: 50px"
                                                type="hidden" /><input id="tbPlayTypeID" runat="server" name="tbPlayTypeID" style="width: 50px"
                                                    type="hidden" /><input id="tbBuyFileName" runat="server" name="tbBuyFileName" style="width: 50px"
                                                        type="hidden" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="5">
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" bgcolor="#9Fc8EA">
                                    <tr style="background-color: White;">
                                        <td class="td6" valign="middle" style="width: 184px" align="right">
                                            <asp:Label ID="Label2" runat="server">　用户名：</asp:Label>&nbsp;
                                        </td>
                                        <td>
                                            &nbsp;<asp:TextBox ID="tbUserName" runat="server" Width="150px" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="background-color: White;">
                                        <td style="width: 184px" align="right">
                                            &nbsp;<asp:Label ID="Label10" runat="server">手机号码：</asp:Label>&nbsp;
                                        </td>
                                        <td>
                                            &nbsp;<asp:TextBox ID="tbUserMobile" runat="server" MaxLength="11" Width="150px"></asp:TextBox>
                                            <ShoveWebUI:ShoveConfirmButton ID="btnMobileValid" runat="server" Text="立即验证" AlertText="确信要立即验证您的手机吗？" OnClick="btnMobileValid_Click" />
                                        </td>
                                    </tr>
                                    <asp:Panel ID="panelValid" runat="server" Visible="false">
                                        <tr style="background-color: White;">
                                            <td style="height: 25px; width: 184px;" align="right">
                                                <asp:Label ID="Label15" runat="server">验证密码：</asp:Label>&nbsp;
                                            </td>
                                            <td style="height: 25px">
                                                &nbsp;<asp:TextBox ID="tbValidPassword" runat="server" Width="150px"></asp:TextBox>
                                                <ShoveWebUI:ShoveConfirmButton ID="btnGO" runat="server" Text=" 确定 " OnClick="btnGO_Click" />
                                            </td>
                                        </tr>
                                        <tr style="background-color: White;">
                                            <td align="right" class="style1">
                                            </td>
                                            <td class="style2">
                                                <asp:Label ID="Label3" Style="left: 322px; top: 203px;" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </div>
        </div>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
