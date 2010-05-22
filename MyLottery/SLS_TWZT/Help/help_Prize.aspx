<%@ page language="C#" autoeventwireup="true" CodeFile="help_Prize.aspx.cs" inherits="Help_help_Prize" enableEventValidation="false" %>

<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/HelpCenter.ascx" TagName="Help" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我中奖了，如何领奖-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="keywords" content="<%=_Site.Name %>帮助中心-我中奖了，如何领奖" />
    <meta name="description" content="<%=_Site.Name %>提供：用户登录-账户充值-选择彩种、选择玩法、选号投注-点击“立即投注”按钮---投注成功-中大奖了，我要提款！的帮助" />
    <link href="../Home/Room/style/css.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../favicon.ico" />
</head>

<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    
    <uc1:Lotteries ID="Lotteries" runat="server" />
    <div id="content">
        <div id="help_left">
            <uc2:Help ID="Help" runat="server" />
        </div>
        <div id="help_right">
            <table border="0" cellpadding="0" cellspacing="0"  width="842">
                <tr>
                    <td height="30" width="20">
                        &nbsp;
                    </td>
                    <td align="center" width="90" id="tdHelpCenter" style="cursor: hand; background-color: #FF6600;"
                        class="bai14">
                        <a href="Help_Default.aspx">帮助中心</a>
                    </td>
                    <td width="5">
                        &nbsp;
                    </td>
                    <td align="center" width="90" id="tdPlayType" style="cursor: hand; background-color: #E4E4E4;"
                        class="hui14">
                        <a href="Play_Default.aspx">玩法介绍</a>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#FF6600" colspan="5" height="2">
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding-top: 20px;">
                <tr>
                    <td height="36" align="center" class="red20">
                        我中奖了，如何领奖
                    </td>
                </tr>
                <tr>
                    <td height="0">
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#C0DBF9">
                <tr bgcolor="#CCCCCC">
                    <td bgcolor="#ffffff" class="blue14" style="padding: 20px 25px 20px 25px; background-image: url(../images/zfb_bg_blue.jpg);
                        background-repeat: repeat-x; background-position: center top;">
                        <p style="font-weight: normal;">
                            &nbsp &nbsp &nbsp &nbsp 在<%=_Site.Name %>中了奖（无论奖金多少），奖金均由福彩中心在12个小时之内派发到您的账户中，您可自行申请提款。如有更多疑问，请联系在线客服或者致电全国统一客服热线：<span
                                class="red14">4006--751118</span><br />
                        </p>
                        <p>
                            第一步：登录您的帐户<br />
                            <img src="images/help_25.gif" />
                        </p>
                        <p>
                            第二步：选择用户中心<br />
                            <img src="images/help_5_1.gif" />
                        </p>
                        <p>
                            第三步：中奖查询<br />
                            <img src="images/help_25_2.gif" />
                        </p>
                        <table style="margin-top: 20px" border="0" cellspacing="1" cellpadding="0" width="100%"
                            bgcolor="#d8d8d8">
                            <tr>
                                <td style="padding-bottom: 5px; padding-left: 10px; padding-right: 10px; padding-top: 5px"
                                    class="black12" bgcolor="#ffffdd" align="left">
                                    <img src="../Home/Room/images/icon_cg222.jpg" width="73" height="52">
                                </td>
                                <td class="red14_2" width="91%">
                                    祝贺您中奖了！
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
<!--#includefile="../Html/TrafficStatistics/1.htm"--></body>
</html>
