<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/OnlinePay/CardPassword/Default.aspx.cs" inherits="Home_Room_OnlinePay_CardPassword_Default" enableEventValidation="false" %>

<%@ Register Src="../../UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>卡密充值-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <meta name="keywords" content="<%=_Site.Name %>提供网银充值，卡密充值，支付宝支付，财付通支付" />
    <link href="../../Style/css.css" rel="stylesheet" type="text/css" />
</head><link rel="shortcut icon" href="../../../../favicon.ico"/>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    
    <uc3:Lotteries ID="Lotteries1" runat="server" />
    
    <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 3px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
            <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                <tr>
                    <td width="40" height="30" align="right" valign="middle" class="red14">
                        <img src="../../Images/icon_5.gif" width="19" height="16" />
                    </td>
                    <td valign="middle" class="red14" style="padding-left: 10px;">
                        我的帐户
                    </td>
                </tr>
            </table>
            <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                <tr>
                    <td width="20" height="29">
                        &nbsp;
                    </td>
                    <td width="100" align="center" background="../../images/admin_qh_100_1.jpg" class="blue12">
                        <a href="Default.aspx"><strong>卡密充值</strong></a>
                    </td>
                    <td width="4">
                        &nbsp;
                    </td>
                    <td width="6">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="1" colspan="11" bgcolor="#FFFFFF">
                    </td>
                </tr>
                <tr>
                    <td height="2" colspan="11" bgcolor="#6699CC">
                    </td>
                </tr>
            </table>
            <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#DDDDDD">
                <tr>
                    <td height="30" colspan="2" align="left" bgcolor="#E9F1F8" class="black12" style="padding-left: 20px;">
                        您好，<span class="red12"><%=UserName%></span>！您当前帐户余额为：￥<span class="red12"><%= Balance%>
                        </span>元
                    </td>
                </tr>
            </table>
            <br />
            <table width="842" border="0" cellpadding="0" cellspacing="0" bgcolor="#C0DBF9" style="padding-left: 10px;"
                align="center">
                <tr>
                    <td width="93" height="30" align="right" bgcolor="#FFFFFF" class="black12">
                        <span class="red12">*</span>输入卡密：
                    </td>
                    <td width="685" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr bgcolor="#C0DBF9">
                                <td width="43%" align="left" bgcolor="#FFFFFF" class="black12">
                                    <label>
                                        <asp:TextBox ID="tbCardPassword" runat="server" Width="260px" MaxLength="20" CssClass="in_text"></asp:TextBox>
                                    </label>
                                </td>
                                <td width="57%" align="left" bgcolor="#FFFFFF" class="blue12_2">
                                    <a href="../../../../Html/9wee/index.html" target="_blank">我还没有卡密，如何获得卡密？</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right" valign="top" bgcolor="#FFFFFF" class="black12" style="padding-top: 10px;">
                        &nbsp;
                    </td>
                    <td height="30" align="left" valign="top" bgcolor="#FFFFFF" class="black12" style="padding: 10px 0px 10px 10px;">
                        <ShoveWebUI:ShoveConfirmButton ID="btnOK" runat="server" AlertText="确信输入的卡密无误，并立即充值吗？"
                            OnClick="btnOK_Click" Style="border: 0px; background-color: #D6E9F5; background-image: url('../../images/zfb_bt_chongzhi.jpg');
                            width: 91px; height: 28px;" />
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right" valign="top" bgcolor="#FFFFFF" class="black12" style="padding-top: 10px;">
                        &nbsp;
                    </td>
                    <td height="30" align="left" valign="top" bgcolor="#FFFFFF" class="black12" style="padding: 10px 0px 10px 10px;">
                        <table width="98%" border="0" cellspacing="1" cellpadding="0" bgcolor="#FFCD33">
                            <tr>
                                <td bgcolor="#FFFFE1" class="red12" style="padding: 15px;">
                                    温馨提示：请小心输入您的卡密号码！3次输入错误的卡密号码，系统将会自动暂时锁定您的卡密充值功能30分钟！
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
