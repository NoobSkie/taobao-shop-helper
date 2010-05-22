<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/UserRegSuccess.aspx.cs" inherits="Home_Room_UserRegSuccess" enableEventValidation="false" %>

<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户注册成功-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <meta name="keywords" content="用户注册成功" />
     
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-size: 12px;
            color: #226699;
            font-family: "tahoma";
            line-height: 20px;
            height: 28px;
        }
        A
        {
            text-decoration: none;
        }
        A:hover
        {
            color: #CC0000;
            text-decoration: underline;
        }
    </style>
<link rel="shortcut icon" href="../../favicon.ico" /></head>
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
            <table width="832" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 20px;">
                <tr>
                    <td align="left" bgcolor="#FFFFDD" class="black12" style="padding: 5px 10px 5px 10px;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="9%">
                                    <img src="images/icon_cg222.jpg" width="73" height="52" />
                                </td>
                                <td width="91%" class="red14_2">
                                    <%=_User.Name%>，祝贺您注册成功！
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="832" border="0" cellspacing="0" cellpadding="0" style="margin-top: 15px;">
                <tr>
                    <td width="61%" height="36" class="black12" style="padding-left: 20px;">
                        <span class="red12">★</span> <span class="red12">重要提示：请您及时完成手机安全验证或保密邮箱激活，上海市福彩中心、江西省福彩中心、山东省体彩中心才能受理您的委托投注单。</span>
                    </td>
                    <%--<td width="39%">
                        <a href="BindBankCard.aspx">
                            <img src="images/bt_bangding.jpg" width="133" height="28" border="0" /></a>
                    </td>--%>
                </tr>
                <tr>
                    <td height="36" colspan="2" class="blue12_line">
                        <div id="hr">
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td width="61%" height="36" class="black12" align="left" style="padding-left: 20px;">
                         <a href="SafeSet.aspx?FromUrl=UserRegSuccess.aspx">
                            <img src="images/set_QA.jpg" width="127" height="36" border="0" /></a>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        <a href="UserMobileBind.aspx">
                            <img src="images/sjyz_bt.jpg" width="127" height="36" border="0" /></a>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="UserEmailBind.aspx">
                            <img src="images/jh_bt.jpg" width="127" height="36" border="0" /></a>
                    </td>
                </tr>
                <tr>
                    <td height="36" colspan="2" class="blue12_line">
                        <div id="hr">
                        </div>
                    </td>
                </tr>
                <%--<tr>
                    <td height="36" class="blue12_line" style="padding-left: 20px;">
                        <span class="red12">★</span><span class="black12"> 为了能够为您提供更优质的服务，请及时完善您的</span>
                        <a href="UserEdit.aspx" target="_parent">注册信息</a><a href="UserMobileBind.aspx" target="_parent" style="padding-left:10px">手机验证</a><a href="UserEmailBind.aspx" target="_parent" style="padding-left:10px">邮箱验证</a>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="36" colspan="2" class="blue12_line">
                        <div id="hr">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td height="36" colspan="2" class="blue12_line" style="padding-left: 20px;">
                        <a href="OnlinePay/Default.aspx">
                            <img src="images/bt_chongzhi_2.jpg" width="103" height="28" border="0" /></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a
                                style="cursor: hand;" onclick="window.location='../../Default.aspx'"><img src="images/bt_goumai_2.jpg"
                                    width="103" height="28" border="0" /></a>
                    </td>
                </tr>
                <tr>
                    <td height="36" colspan="2" class="blue12_line">
                        <div id="hr">
                        </div>
                    </td>
                </tr>--%>
            </table>
            <br />
            <table width="680" border="0" align="left" cellpadding="0" cellspacing="0" style="margin-left: 30px;">
                <tr>
                    <td width="72" height="48" align="center"><a href="Buy.aspx?LotteryID=39"><img src="images/jiajang.jpg" width="41" height="41" /></a></td>
                    <td height="48" align="left" class="red14_2" style="padding-left: 10px;">
                        <a href="<%=ResolveUrl("~/") %>" style="color: #CC0000;">三大彩种集体加奖  大奖PK时不我待</a>
                    </td>
                    <td width="243" rowspan="4">
                        <img src="images/cg_pic_1.jpg" width="210" height="175" />
                    </td>
                </tr>
                <tr>
                    <td width="72" height="48" align="center">
                        <img src="images/ssq.jpg" width="28" height="28" />
                    </td>
                    <td width="490" align="left" style="color: #1E78C3; font-size: 14px; font-weight: bold;padding-left: 10px;">
                        <a href="<%=ResolveUrl("~/Lottery/Buy_SSQ.aspx") %>" style="color: #1E78C3;">双色球加奖2亿，2元可中1500万</a>
                    </td>
                </tr>
                <tr>
                    <td height="48" align="center">
                        <img src="images/dlt.jpg" width="28" height="28" />
                    </td>
                    <td align="left" style="color: #1E78C3; font-size: 14px; font-weight: bold;padding-left: 10px;">
                        <a href="<%=ResolveUrl("~/Lottery/Buy_CJDLT.aspx") %>" style="color: #1E78C3;">超级大乐透加奖1.2亿，3元冲击2400万</a>
                    </td>
                </tr>
                <tr>
                    <td height="48" align="center">
                        <img src="images/zc.jpg" width="28" height="28" />
                    </td>
                    <td align="left" style="color: #1E78C3; font-size: 14px; font-weight: bold;padding-left: 10px;">
                       <a href="<%=ResolveUrl("~/Lottery/Buy_SFC.aspx") %>" style="color: #1E78C3;">足彩胜负加奖1.4亿，分享足球大奖盛宴</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
