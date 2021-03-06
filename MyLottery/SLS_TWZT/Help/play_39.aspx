﻿<%@ page language="C#" autoeventwireup="true" CodeFile="play_39.aspx.cs" inherits="Help_play_39" enableEventValidation="false" %>

<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/PlayType.ascx" TagName="Help" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>超级大乐透彩票玩法介绍-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！ </title>
    <meta name="keywords" content="超级大乐透彩票玩法介绍" />
    <meta name="description" content="<%=_Site.Name %>提供超级大乐透彩票玩法介绍"/>
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
                        超级大乐透玩法介绍
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
                            <span class="blue14">一、发行周期和开奖时间：</span><br />
                            &nbsp;&nbsp;&nbsp;&nbsp;体彩超级大乐透每周发行三期，每周一、三、六晚开奖，央视体育频道(CCTV-5)21：55-22：00《天天体彩》栏目播放当日全国联网玩法开奖结果。
                            <br />
                            <br />
                            <span class="blue14">二、玩法和奖金</span><br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;超级大乐透投注分为前区和后区（类似双色球的红球和蓝球），前区号码范围为01～35，后区号码范围为01～12，每期开出5个前区号码和2个后区号码作为中奖号码。<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;超级大乐透玩法即是竞猜开奖号码的5个前区号码和2个后区号码，顺序不限（即35选5+12选2标准玩法）；或者只针对后区的2个号码竞猜，顺序不限（即12选2玩法）：
                        </p>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                            <tr>
                                <td width="114" rowspan="2" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        奖级
                                    </p>
                                </td>
                                <td height="25" colspan="2" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        中奖条件
                                    </p>
                                </td>
                                <td width="70" rowspan="2" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        说明
                                    </p>
                                </td>
                                <td width="189" rowspan="2" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        单注奖金（基本）
                                    </p>
                                </td>
                                <td width="94" rowspan="2" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        追加投注奖金
                                    </p>
                                </td>
                                <td width="97" rowspan="2" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        费用（追加投注）
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="85" height="25" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        前区
                                    </p>
                                </td>
                                <td width="69" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        后区
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td height="25" colspan="8" valign="center" bgcolor="#FFFFFF" class="red12" style="padding-left: 20px;">
                                    <p>
                                        35选5+12选2玩法（前区选5个号，后区选2个号，最高奖金800万）
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="114" height="25" align="center" valign="center" bgcolor="#FFFFFF" class="blue12">
                                    <p>
                                        一等奖
                                    </p>
                                </td>
                                <td width="85" align="center" valign="center" bgcolor="#FFFFFF" class="red14">
                                    <p>
                                        &#9679;&#9679;&#9679;&#9679;&#9679;
                                    </p>
                                </td>
                                <td width="69" align="center" valign="center" bgcolor="#FFFFFF" class="blue14">
                                    <p>
                                        &#9679;&#9679;
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        5+2
                                    </p>
                                </td>
                                <td width="189" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        高等奖奖金的75%与奖池奖金之和除以中奖注数，500万封顶
                                    </p>
                                </td>
                                <td width="94" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        一等奖奖金的60%，300万封顶
                                    </p>
                                </td>
                                <td width="97" rowspan="13" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        2(+1)元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="114" height="25" align="center" valign="center" bgcolor="#FFFFFF" class="blue12">
                                    <p>
                                        二等奖
                                    </p>
                                </td>
                                <td width="85" align="center" valign="center" bgcolor="#FFFFFF" class="red14">
                                    <p>
                                        &#9679;&#9679;&#9679;&#9679;&#9679;
                                    </p>
                                </td>
                                <td width="69" align="center" valign="center" bgcolor="#FFFFFF" class="blue14">
                                    <p>
                                        &#9679;
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        5+1
                                    </p>
                                </td>
                                <td width="189" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        高等奖奖金的20%除以中奖注数，500万封顶
                                    </p>
                                </td>
                                <td width="94" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        二等奖奖金的60%，300万封顶
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="114" height="25" align="center" valign="center" bgcolor="#FFFFFF" class="blue12">
                                    <p>
                                        三等奖
                                    </p>
                                </td>
                                <td width="85" align="center" valign="center" bgcolor="#FFFFFF" class="red14">
                                    <p>
                                        &#9679;&#9679;&#9679;&#9679;&#9679;
                                    </p>
                                </td>
                                <td width="69" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        无
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        5+0
                                    </p>
                                </td>
                                <td width="189" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        高等奖奖金的5%除以中奖注数
                                    </p>
                                </td>
                                <td width="94" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        三等奖奖金的60%
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="114" height="25" align="center" valign="center" bgcolor="#FFFFFF" class="blue12">
                                    <p>
                                        四等奖
                                    </p>
                                </td>
                                <td width="85" align="center" valign="center" bgcolor="#FFFFFF" class="red14">
                                    <p>
                                        &#9679;&#9679;&#9679;&#9679;
                                    </p>
                                </td>
                                <td width="69" align="center" valign="center" bgcolor="#FFFFFF" class="blue14">
                                    <p>
                                        &#9679;&#9679;
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        4+2
                                    </p>
                                </td>
                                <td width="189" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        3000元
                                    </p>
                                </td>
                                <td width="94" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        1500元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="114" height="25" align="center" valign="center" bgcolor="#FFFFFF" class="blue12">
                                    <p>
                                        五等奖
                                    </p>
                                </td>
                                <td width="85" align="center" valign="center" bgcolor="#FFFFFF" class="red14">
                                    <p>
                                        &#9679;&#9679;&#9679;&#9679;
                                    </p>
                                </td>
                                <td width="69" align="center" valign="center" bgcolor="#FFFFFF" class="blue14">
                                    <p>
                                        &#9679;
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        4+1
                                    </p>
                                </td>
                                <td width="189" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        600元
                                    </p>
                                </td>
                                <td width="94" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        300元</p>
                                </td>
                            </tr>
                            <tr>
                                <td width="114" height="25" rowspan="2" align="center" valign="center" bgcolor="#FFFFFF"
                                    class="blue12">
                                    <p>
                                        六等奖
                                    </p>
                                </td>
                                <td width="85" align="center" valign="center" bgcolor="#FFFFFF" class="red14">
                                    <p>
                                        &#9679;&#9679;&#9679;&#9679;
                                    </p>
                                </td>
                                <td width="69" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        无
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        4+0
                                    </p>
                                </td>
                                <td width="189" rowspan="2" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        100元
                                    </p>
                                </td>
                                <td width="94" rowspan="2" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        50元</p>
                                </td>
                            </tr>
                            <tr>
                                <td width="85" align="center" valign="center" bgcolor="#FFFFFF" class="red14">
                                    <p>
                                        &#9679;&#9679;&#9679;
                                    </p>
                                </td>
                                <td width="69" align="center" valign="center" bgcolor="#FFFFFF" class="blue14">
                                    <p>
                                        &#9679;&#9679;
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        3+2
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="114" height="25" rowspan="2" align="center" valign="center" bgcolor="#FFFFFF"
                                    class="blue12">
                                    <p>
                                        七等奖
                                    </p>
                                </td>
                                <td width="85" align="center" valign="center" bgcolor="#FFFFFF" class="red14">
                                    <p>
                                        &#9679;&#9679;&#9679;
                                    </p>
                                </td>
                                <td width="69" align="center" valign="center" bgcolor="#FFFFFF" class="blue14">
                                    <p>
                                        &#9679;
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        3+1
                                    </p>
                                </td>
                                <td width="189" rowspan="2" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        10元
                                    </p>
                                </td>
                                <td width="94" rowspan="2" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        5元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="85" align="center" valign="center" bgcolor="#FFFFFF" class="red14">
                                    <p>
                                        &#9679;&#9679;
                                    </p>
                                </td>
                                <td width="69" align="center" valign="center" bgcolor="#FFFFFF" class="blue14">
                                    <p>
                                        &#9679;&#9679;
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        2+2
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="114" height="25" rowspan="4" align="center" valign="center" bgcolor="#FFFFFF"
                                    class="blue12">
                                    <p>
                                        八等奖
                                    </p>
                                </td>
                                <td width="85" align="center" valign="center" bgcolor="#FFFFFF" class="red14">
                                    <p>
                                        &#9679;&#9679;&#9679;
                                    </p>
                                </td>
                                <td width="69" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        无
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        3+0
                                    </p>
                                </td>
                                <td width="189" rowspan="4" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        5元
                                    </p>
                                </td>
                                <td width="94" rowspan="4" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        无
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="85" align="center" valign="center" bgcolor="#FFFFFF" class="red14">
                                    <p>
                                        &#9679;
                                    </p>
                                </td>
                                <td width="69" align="center" valign="center" bgcolor="#FFFFFF" class="blue14">
                                    <p>
                                        &#9679;&#9679;
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        1+2
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="85" align="center" valign="center" bgcolor="#FFFFFF" class="red14">
                                    <p>
                                        &#9679;&#9679;
                                    </p>
                                </td>
                                <td width="69" align="center" valign="center" bgcolor="#FFFFFF" class="blue14">
                                    <p>
                                        &#9679;
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        2+1
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="85" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        无
                                    </p>
                                </td>
                                <td width="69" align="center" valign="center" bgcolor="#FFFFFF" class="blue14">
                                    <p>
                                        &#9679;&#9679;
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        0+2
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td height="25" colspan="8" valign="center" bgcolor="#FFFFFF" class="red12" style="padding-left: 20px;">
                                    <p>
                                        12选2玩法（只在后区选2个号，固定奖金60元）
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="114" height="25" align="center" valign="center" bgcolor="#FFFFFF" class="blue12">
                                    <p>
                                        12选2
                                    </p>
                                </td>
                                <td width="85" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        不投注
                                    </p>
                                </td>
                                <td width="69" align="center" valign="center" bgcolor="#FFFFFF" class="blue14">
                                    <p>
                                        &#9679;&#9679;
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        2
                                    </p>
                                </td>
                                <td width="189" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        60元
                                    </p>
                                </td>
                                <td width="94" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        无
                                    </p>
                                </td>
                                <td width="97" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        2元
                                    </p>
                                </td>
                            </tr>
                        </table>
                        <p class="blue14">
                            三、说明：
                        </p>
                        <p>
                            1、高奖等奖金＝奖金总额－固定奖奖金。<br>
                            <br />
                            2、当奖池奖金累积超过1亿元(含)时，下期一、二等奖奖金分配比例倒置。<br />
                            一等奖奖金总额由两部分组成，一部分为奖池奖金&nbsp;(基本投注单注奖金封顶500万元，追加投注单注奖金封顶300万元)，另一部分为高等奖奖金的20%；二等奖奖金总额为高等奖奖金的75%&nbsp;(基本投注单注奖金封顶500万元，追加投注单注奖金封顶300万元)。<br>
                            <br />
                            3、在一、二等奖奖金分配比例不倒置的情况下，基本投注单注奖金封顶500万元。</p>
                        <p>
                            &nbsp;
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
