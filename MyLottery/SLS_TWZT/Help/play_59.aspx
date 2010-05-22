<%@ page language="C#" autoeventwireup="true" CodeFile="play_59.aspx.cs" inherits="Help_help_59" enableEventValidation="false" %>

<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/PlayType.ascx" TagName="Help" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>15选5彩票玩法介绍-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！ </title>
    <meta name="keywords" content="15选5彩票玩法介绍" />
    <meta name="description" content="<%=_Site.Name %>提供15选5彩票玩法介绍">
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
                    <td align="center" width="90" id="tdHelpCenter" style="cursor: hand; background-color: #E4E4E4;"
                        class="hui14">
                        <a href="Help_Default.aspx">帮助中心</a>
                    </td>
                    <td width="5">
                        &nbsp;
                    </td>
                    <td align="center" width="90" id="tdPlayType" style="cursor: hand; background-color: #FF6600;"
                        class="bai14">
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
                        15选5玩法介绍
                    </td>
                </tr>
                <tr>
                    <td height="0">
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#C0DBF9">
                <tr bgcolor="#CCCCCC">
                    <td bgcolor="#ffffff" class="hei12" style="padding: 20px 25px 20px 25px; background-image: url(../images/zfb_bg_blue.jpg);
                        background-repeat: repeat-x; background-position: center top;">
                        <p>
                            <span class="blue14">一、发行周期和开奖时间 </span>
                            <br />
                            15选5每日发行1期，当日18:27截止销售，官方开奖时间为19:45。<br />
                            <br />
                            <span class="blue14">二、怎么玩 </span>
                        </p>
                        <p>
                            15选5的投注方式为从01~15中选择5个数字作为投注号码，竞猜每期开出的5个数字中奖号码：</p>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                            <tr>
                                <td width="84" height="25" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        奖级
                                    </p>
                                </td>
                                <td width="108" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        中奖条件
                                    </p>
                                </td>
                                <td width="189" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        中奖说明
                                    </p>
                                </td>
                                <td width="193" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        单注奖金
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="84" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        特别奖
                                    </p>
                                </td>
                                <td width="108" align="center" valign="center" bgcolor="#FAFAFA" class="red14">
                                    <p>
                                        &#9679;&#9679;&#9679;&#9679;&#9679;
                                    </p>
                                </td>
                                <td width="189" valign="center" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        5个数字全中，且至少包含4个连续自然数号码。
                                    </p>
                                </td>
                                <td width="193" valign="center" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        高等奖奖金的10%与奖池奖金之和除以中奖注数。
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="84" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        一等奖
                                    </p>
                                </td>
                                <td width="108" align="center" valign="center" bgcolor="#FAFAFA" class="red14">
                                    <p>
                                        &#9679;&#9679;&#9679;&#9679;&#9679;
                                    </p>
                                </td>
                                <td width="189" valign="center" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        5个数字全中，顺序不限。
                                    </p>
                                </td>
                                <td width="193" valign="center" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        高等奖奖金的90%除以中奖注数。
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="84" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        二等奖
                                    </p>
                                </td>
                                <td width="108" align="center" valign="center" bgcolor="#FAFAFA" class="red14">
                                    <p>
                                        &#9679;&#9679;&#9679;&#9679;
                                    </p>
                                </td>
                                <td width="189" valign="center" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        任意中4个数字。
                                    </p>
                                </td>
                                <td width="193" valign="center" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        10元。
                                    </p>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <p class="blue14">
                            三、术语解释
                        </p>
                        <p>
                            高等奖奖金：每期投注总额的49%为当期奖金，高等奖奖金=当期奖金-当期二等奖奖金总和
                        </p>
                        <p>
                            奖池：高等奖奖金的90%用以平分给当期所有中一等奖的彩民，10%累积进入奖池，奖池奖金用于开出特别奖号码时派奖
                        </p>
                        <br />
                        <p class="blue14">
                            &nbsp;四、奖金概念和基本计算方式
                        </p>
                        <p>
                            15选5设奖为特别奖、一等奖、二等奖，奖金的算法比较特别。二等奖奖金固定10元，一等奖奖金受销量和中奖注数影响浮动，特别奖满足&#8220;开出号码包括四个连续数字&#8221;的条件会进行派发。
                        </p>
                        <p>
                            15选5的奖金计算中，涉及&#8220;当期销量&#8221;、&#8220;中奖注数&#8221;、&#8220;高等奖奖金&#8221;、&#8220;奖池&#8221;等概念：
                        </p>
                        <p>
                            当期销量：即当期销售的投注总额，其中的49%为当期奖金。
                        </p>
                        <p>
                            中奖注数：即一等奖和二等奖的中奖注数，影响一等奖和特别奖的奖金分配（一等奖和特别奖&#8220;兼中兼得&#8221;，中特别奖的彩民必定中一等奖）。
                        </p>
                        <p>
                            高等奖奖金：当期奖金扣除二等奖奖金后剩下的金额。高等奖奖金的90%为一等奖奖金，由中奖者平分。
                        </p>
                        <p>
                            奖池：用于派发特别奖，如果当期号码没有开出特别奖，则当期高等奖奖金的10%将累积进入奖池，直到开出特别奖、中奖者平分奖池金额为止。</p>
                        <p class="blue14">
                            五、举例说明奖金分配
                        </p>
                        <p class="red">
                            1、特别奖号码开出的情况（即开奖号码包括四个连续数字）
                        </p>
                        <p>
                            假设：开奖号码为&nbsp;02&nbsp;03&nbsp;04&nbsp;05&nbsp;13，当期销量5000000元，一等奖中奖注数300，二等奖中奖注数10000，开奖前奖池金额3000000元：<br />
                        </p>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                            <tr>
                                <td width="65" height="25" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        奖项
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        到手
                                    </p>
                                </td>
                                <td width="90" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        奖金
                                    </p>
                                </td>
                                <td width="109" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        投注号码
                                    </p>
                                </td>
                                <td width="130" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        中奖注数
                                    </p>
                                </td>
                                <td width="83" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        开奖后奖池
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="65" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        特别奖
                                    </p>
                                </td>
                                <td width="96" rowspan="2" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        18167元
                                    </p>
                                </td>
                                <td width="90" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        10817元
                                    </p>
                                </td>
                                <td width="109" rowspan="2" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        02&nbsp;03&nbsp;04&nbsp;05&nbsp;13
                                    </p>
                                </td>
                                <td width="130" rowspan="2" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        300
                                    </p>
                                </td>
                                <td width="83" rowspan="3" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        0元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="65" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        一等奖
                                    </p>
                                </td>
                                <td width="90" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        7350元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="65" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        二等奖
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        10元
                                    </p>
                                </td>
                                <td width="90" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        10元
                                    </p>
                                </td>
                                <td width="109" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        02&nbsp;04&nbsp;05&nbsp;13&nbsp;14
                                    </p>
                                </td>
                                <td width="130" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        10000
                                    </p>
                                </td>
                            </tr>
                        </table>
                        <p>
                            一等奖奖金：5000000*49%*90%/300=7350
                        </p>
                        <p>
                            特别奖奖金：(3000000+5000000*49%*10%)/300=10817
                        </p>
                        <p>
                            （一等奖和特别奖&#8220;兼中兼得&#8221;，中特别奖的彩民必定中一等奖）
                        </p>
                        <p class="red">
                            2、没有开出特别奖号码的情况
                        </p>
                        <p>
                            假设：开奖号码为&nbsp;02&nbsp;04&nbsp;06&nbsp;08&nbsp;14，当期销量5000000元，一等奖中奖注数300，二等奖中奖注数10000，开奖前奖池金额3000000元：</p>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                            <tr>
                                <td width="65" height="25" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        奖项
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        到手
                                    </p>
                                </td>
                                <td width="90" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        奖金
                                    </p>
                                </td>
                                <td width="109" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        投注号码
                                    </p>
                                </td>
                                <td width="130" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        中奖注数
                                    </p>
                                </td>
                                <td width="83" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        开奖后奖池
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="65" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        一等奖
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        7350元
                                    </p>
                                </td>
                                <td width="90" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        7350元
                                    </p>
                                </td>
                                <td width="109" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        02&nbsp;04&nbsp;06&nbsp;08&nbsp;14
                                    </p>
                                </td>
                                <td width="130" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        300
                                    </p>
                                </td>
                                <td width="83" rowspan="2" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        3245000元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="65" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        二等奖
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        10元
                                    </p>
                                </td>
                                <td width="90" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        10元
                                    </p>
                                </td>
                                <td width="109" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        02&nbsp;04&nbsp;06&nbsp;12&nbsp;14
                                    </p>
                                </td>
                                <td width="130" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        10000
                                    </p>
                                </td>
                            </tr>
                        </table>
                        <p>
                            一等奖奖金：5000000*49%*90%/300=7350
                        </p>
                        <p>
                            奖池金额：3000000+5000000*49%*10%=3245000
                        </p>
                        <!-- <p>
                                <br />
                                <a href="javascript:;" onclick="window.top.location.href='../../../Home/Web/ShowExplain.aspx?LotteryID=59'"
                                    class="blue12" target="_blank">查看详细的玩法介绍</a> | <a href="../Win.htm">我中大奖了，我要领奖</a></p>-->
                        <p>
                            &nbsp;
                        </p>
                </tr>
            </table>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
<!--#includefile="../Html/TrafficStatistics/1.htm"--></body>
</html>
