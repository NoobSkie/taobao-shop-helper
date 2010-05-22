﻿<%@ page language="C#" autoeventwireup="true" CodeFile="help_Chase.aspx.cs" inherits="Help_help_Chase" enableEventValidation="false" %>

<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/HelpCenter.ascx" TagName="Help" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>什么叫追号-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！</title>
    <meta name="keywords" content="<%=_Site.Name %>帮助中心-什么叫追号" />
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
                        什么叫追号
                    </td>
                </tr>
                <tr>
                    <td height="0">
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#C0DBF9">
                <tr bgcolor="#CCCCCC">
                    <td bgcolor="#ffffff" class="blue14" style="font-weight: normal; padding: 20px 25px 20px 25px;
                        background-image: url(../images/zfb_bg_blue.jpg); background-repeat: repeat-x;
                        background-position: center top;">
                        <p>
                            所谓追号就是在认准一注或者几注号码后，连续投注多期，直至号码开出的一种方法，在连续投注中往往为了保证一定的盈利率，会在不同期数逐步增加同一注号码的倍数，这样可以保证在最后一次中出时能收回前期不中而投入的成本。比较复杂的需要通过倍投计算器来辅助计算。<br />
                        </p>
                        <p>
                            <img src="images/help_7_1.gif" class="img" /></p>
                        <p>
                            在高频彩票中，追号是比较常用的操作方式。而在大盘乐透彩票中，守号也是一种追号方式，不过一般很少倍投。<br />
                        </p>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
<!--#includefile="../Html/TrafficStatistics/1.htm"--></body>
</html>
