<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/ViewAccount.aspx.cs" inherits="Home_Room_ViewAccount" enableEventValidation="false" %>

<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>账户全览-我的账号-用户中心-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
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
            <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                <tr>
                    <td width="40" height="30" align="right" valign="middle" class="red14">
                        <img src="images/icon_5.gif" width="19" height="20" />
                    </td>
                    <td valign="middle" class="red14" style="padding-left: 10px;">
                        我的账户
                    </td>
                </tr>
            </table>
            <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                <tr>
                    <td width="20" height="29">
                        &nbsp;
                    </td>
                    <td width="100" align="center" background="images/admin_qh_100_1.jpg" class="blue12">
                        <a href="ViewAccount.aspx"><strong>帐户全览</strong></a>
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
            <table width="842" border="0" cellpadding="0" cellspacing="1" bgcolor="#DDDDDD" style="margin-top: 10px;">
                <tr>
                    <td width="17%" height="30" align="right" bgcolor="#F8F8F8" class="black12">
                        用户类型：<span class="red12"></span>
                    </td>
                    <td colspan="2" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                        <asp:Label ID="labUserType" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right" bgcolor="#F8F8F8" class="black12">
                        账户余额：
                    </td>
                    <td width="22%" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                        <span class="red12">
                            <asp:Label ID="labBalance" runat="server"></asp:Label></span> 元
                    </td>
                    <td width="61%" align="left" bgcolor="#FFFFFF" class="blue12" style="padding-left: 10px;">
                        <a href="Distill.aspx" target="_self">【我要提款】</a>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right" bgcolor="#F8F8F8" class="black12">
                        已冻结金额：
                    </td>
                    <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                        <span class="red12">
                            <asp:Label ID="labFreeze" runat="server" CssClass="zw9"></asp:Label></span>
                        元
                    </td>
                    <td align="left" bgcolor="#FFFFFF" style="padding-left: 10px;">
                        <a href="AccountFreezeDetail.aspx" style="text-decoration: none" target="_self" class="blue12"
                            runat="server" id="lbFreezDetail" visible="false">【冻结明细】</a>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right" bgcolor="#F8F8F8" class="black12">
                        可投注金额：
                    </td>
                    <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                        <span class="red12">
                            <asp:Label ID="labBalanceDo" runat="server"></asp:Label></span> 元
                    </td>
                    <td align="left" bgcolor="#FFFFFF" class="blue12" style="padding-left: 10px;">
                        <a href="../../Default.aspx" target="_blank">【我要购彩】</a> <a href="Buy.aspx??LotteryID=5&CoBuy=1"
                            target="_blank">【我要合买】</a>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right" bgcolor="#F8F8F8" class="black12">
                        我的积分：
                    </td>
                    <td align="left" bgcolor="#FFFFFF" class="blue12" style="padding-left: 10px;" colspan="2">
                        <asp:Label ID="labScoring" runat="server"></asp:Label><span class="black12">&nbsp;分</span>
                    </td>
                    <!--
                            <td align="left" bgcolor="#FFFFFF" class="blue12" style="padding-left: 10px;">
                                <a href="#">【积分兑换礼品】</a> <a href="#">【积分抽奖】</a> <a href="#">【积分换金币】</a>
                            </td>
                            -->
                </tr>
                <tr>
                    <td height="30" align="right" bgcolor="#F8F8F8" class="black12">
                        &nbsp;
                    </td>
                    <td colspan="2" align="left" bgcolor="#FFFFFF" class="black12" style="padding: 10px;">
                        如果你已经充值，银行账户钱扣了，而您的账户还没有加上，请点击<span class="blue12_2">在线客服</span> 告诉我们，我们将第一时间为您处理！<br />
                        <table width="100%" border="0" cellspacing="1" cellpadding="0" bgcolor="#FFCD33"
                            style="margin-top: 10px;">
                            <tr>
                                <td bgcolor="#FFFFE1" class="red12" style="padding: 10px;">
                                    资金冻结的原因：<span class="black12"><br />
                                        1、方案发起人保底<br />
                                        2、用户取款<br />
                                        3、追号冻结<br />
                                        4、自动跟单冻结 </span>
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
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
