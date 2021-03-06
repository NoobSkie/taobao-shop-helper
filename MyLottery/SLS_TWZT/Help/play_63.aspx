﻿<%@ page language="C#" autoeventwireup="true" CodeFile="play_63.aspx.cs" inherits="Help_play_63" enableEventValidation="false" %>

<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/PlayType.ascx" TagName="Help" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>排列3彩票玩法介绍-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！ </title>
    <meta name="keywords" content="排列3彩票玩法介绍" />
    <meta name="description" content="<%=_Site.Name %>提供排列3彩票玩法介绍">
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
                    <tr>
                        <td height="36" align="center" class="red20">
                            排列3玩法介绍
                        </td>
                    </tr>
                    <tr>
                        <td height="0">
                        </td>
                    </tr>
            </table>
            <table width="100%">
                <tr bgcolor="#CCCCCC">
                    <td bgcolor="#ffffff" class="black12" style="padding: 20px 25px 20px 25px; background-image: url(../images/zfb_bg_blue.jpg);
                        background-repeat: repeat-x; background-position: center top;">
                        <p>
                            <span class="blue14">一、发行周期和开奖时间：</span><br />
                        </p>
                        排列三每天开奖，央视体育频道(CCTV-5)21：55-22：00《天天体彩》栏目播放当日全国联网玩法开奖结果。
                        <br />
                    </td>
                </tr>
                <tr bgcolor="#CCCCCC">
                    <td bgcolor="#ffffff" style="padding: 20px 25px 20px 25px; background-repeat: repeat-x;
                        background-position: center top;">
                        <p class="blue14">
                            <strong>二、怎么中奖&nbsp; </strong>
                        </p>
                        <p>
                            各种玩法的奖金计算方式如下：
                        </p>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#DDDDDD">
                            <tr>
                                <td width="70" height="25" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        玩法&nbsp;
                                    </p>
                                </td>
                                <td width="162" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        开奖号码示例&nbsp;
                                    </p>
                                </td>
                                <td width="194" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        投注号码示例&nbsp;
                                    </p>
                                </td>
                                <td width="128" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        中奖奖金&nbsp;
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="70" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        直选奖&nbsp;
                                    </p>
                                </td>
                                <td width="162" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        678
                                    </p>
                                </td>
                                <td width="194" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        678&nbsp;
                                    </p>
                                </td>
                                <td width="128" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        1000元&nbsp;
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="70" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        组选三奖&nbsp;
                                    </p>
                                </td>
                                <td width="162" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        668
                                    </p>
                                </td>
                                <td width="194" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        668、686、866&nbsp;
                                    </p>
                                </td>
                                <td width="128" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        320元&nbsp;
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="70" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        组选六奖&nbsp;
                                    </p>
                                </td>
                                <td width="162" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        678
                                    </p>
                                </td>
                                <td width="194" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        678、687、768、786、867、876&nbsp;
                                    </p>
                                </td>
                                <td width="128" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        160元&nbsp;
                                    </p>
                                </td>
                            </tr>
                        </table>
                        <p>
                        </p>
                        <p class="blue14">
                            <strong>三、怎么玩 </strong>
                        </p>
                        <p>
                            排列三开奖号码为3位数，玩法如下：
                        </p>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#DDDDDD">
                            <tr>
                                <td width="90" height="25" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        玩法&nbsp;
                                    </p>
                                </td>
                                <td width="213" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        规则&nbsp;
                                    </p>
                                </td>
                                <td width="251" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        备注&nbsp;
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="90" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        直选&nbsp;
                                    </p>
                                </td>
                                <td width="213" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        选择三个数字投注，顺序一致。&nbsp;
                                    </p>
                                </td>
                                <td width="251" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        将投注号码以唯一的排列方式进行投注。&nbsp;
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="90" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        组选三&nbsp;
                                    </p>
                                </td>
                                <td width="213" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        选择三个数字投注，顺序不限，但投注时三位号码有两位相同（对子）。&nbsp;
                                    </p>
                                </td>
                                <td width="251" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        有2个数字相同的3个数字有3种不同的排列方式，即1次投注有3个中奖机会，这种投注方式为组选三。<br />
                                        示例：112，排列方式有112、121、211。&nbsp;
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="90" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        组选六&nbsp;
                                    </p>
                                </td>
                                <td width="213" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        选择三个数字投注，顺序不限，且投注时三位号码各不相同。&nbsp;
                                    </p>
                                </td>
                                <td width="251" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        3个不同的数字有6种不同的排列方式，即1次投注有6个中奖机会，这种投注方式为组选六。<br />
                                        示例：123，排列方式有123、132、213、231、312、321。&nbsp;
                                    </p>
                                </td>
                            </tr>
                        </table>
                        <p>
                            <br />
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
