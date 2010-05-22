<%@ page language="C#" autoeventwireup="true" CodeFile="play_9.aspx.cs" inherits="Help_play_9" enableEventValidation="false" %>

<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/PlayType.ascx" TagName="Help" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>22选5彩票玩法介绍-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！ </title>
    <meta name="keywords" content="22选5彩票玩法介绍" />
    <meta name="description" content="<%=_Site.Name %>提供22选5彩票玩法介绍">
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
                        22选5玩法介绍
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
                            22选5每天开奖，央视体育频道(CCTV-5)21：55-22：00《天天体彩》栏目播放当日全国联网玩法开奖结果。
                            <br />
                            <br />
                            <span class="blue14">二、怎么玩</span><br />
                            22选5的投注方式为从1~22中选择5个数字作为投注号码，竞猜每期开出的5个数字中奖号码：
                            <br />
                        </p>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#DDDDDD">
                            <tr>
                                <td width="81" height="25" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        奖级&nbsp;
                                    </p>
                                </td>
                                <td width="106" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        中奖条件&nbsp;
                                    </p>
                                </td>
                                <td width="181" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        中奖说明&nbsp;
                                    </p>
                                </td>
                                <td width="186" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        单注奖金&nbsp;
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="81" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        一等奖&nbsp;
                                    </p>
                                </td>
                                <td width="106" align="center" valign="center" bgcolor="#FAFAFA" class="red12_2">
                                    <p>
                                        &#9679;&#9679;&#9679;&#9679;&#9679;&nbsp;
                                    </p>
                                </td>
                                <td width="181" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        5个数字全中
                                    </p>
                                </td>
                                <td width="186" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        当期奖金额减去固定奖总额后的100%，及奖池和调节基金转入部分（最高限额500万）
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="81" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        二等奖&nbsp;
                                    </p>
                                </td>
                                <td width="106" align="center" valign="center" bgcolor="#FAFAFA" class="red12_2">
                                    <p>
                                        &#9679;&#9679;&#9679;&#9679;&nbsp;
                                    </p>
                                </td>
                                <td width="181" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        任意中4个数字。&nbsp;
                                    </p>
                                </td>
                                <td width="186" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        50元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="81" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        三等奖&nbsp;
                                    </p>
                                </td>
                                <td width="106" align="center" valign="center" bgcolor="#FAFAFA" class="red12_2">
                                    <p>
                                        &#9679;&#9679;&#9679;&nbsp;
                                    </p>
                                </td>
                                <td width="181" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        任意中3个数字。&nbsp;
                                    </p>
                                </td>
                                <td width="186" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        5元&nbsp;
                                    </p>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <p>
                            高等奖奖金：双色球一、二等奖为高等奖，三至六等奖为低等奖。高等奖奖金为当期奖金减去当期低等奖奖金。</p>
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
