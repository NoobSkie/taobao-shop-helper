<%@ page language="C#" autoeventwireup="true" CodeFile="help_buy_distill.aspx.cs" inherits="Help_help_buy_distill" enableEventValidation="false" %>

<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/HelpCenter.ascx" TagName="Help" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>如何购彩与提现-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="keywords" content="<%=_Site.Name %>帮助中心- 购彩与提现" />
    <meta name="description" content="<%=_Site.Name %>提供：用户登录-账户充值-选择彩种、选择玩法、选号投注-点击“立即投注”按钮---投注成功-中大奖了，我要提款！的帮助" />
    <link href="../Home/Room/style/css.css" rel="stylesheet" type="text/css" />
   <link rel="shortcut icon" href="../favicon.ico" />
</head>

<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    
    <uc1:Lotteries ID="Lotteries" runat="server" />
    <div id="user">
        <div id="user_l">
            <uc2:Help ID="Help" runat="server" />
        </div>
        <div id="user_r">
            <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 10px;" width="842">
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
                        购彩与提现
                    </td>
                </tr>
                <tr>
                    <td height="0">
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#C0DBF9">
                <tr bgcolor="#CCCCCC">
                    <td bgcolor="#ffffff" class="black12" style="padding: 20px 25px 20px 25px; background-image: url(../images/zfb_bg_blue.jpg);
                        background-repeat: repeat-x; background-position: center top;">
                        <p>
                            <span class="blue14">一、购彩</span><br />
                            购买彩票的时候需要对账户进行充值（不是支付宝余额），充值完毕方可购彩。中奖后奖金自动派发到本站的用户账号内。</p>
                        <p>
                            <span class="blue14">二、提现</span><br />
                            提现有两种方式：1、提现到支付宝。2、提现到银行卡。<br />
                            提现时需要填写真实姓名与安全保护问题，以保证账户的安全性。</p>
                        <p>
                            <br />
                            提现流程：进入“用户中心” &gt; “我的账户” &gt; “我要提款” &gt; 选择支付宝提款或银行卡提款<br />
                            <span class="red12">（支付宝提款：奖金打到绑定的支付宝账户；银行卡提款：奖金打到绑定的银行卡）</span></p>
                        <p style="font-weight: bold">
                            1、提现到支付宝
                        </p>
                        <p>
                            <img src="../Images/Alipay.jpg" /></p>
                        <p style="font-weight: bold">
                            2、提现到银行卡
                        </p>
                        <p>
                            <img src="../Images/bind.jpg" /></p>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
<!--#includefile="../Html/TrafficStatistics/1.htm"--></body>
</html>
