<%@ page language="C#" autoeventwireup="true" CodeFile="play_3.aspx.cs" inherits="Help_help_3" enableEventValidation="false" %>

<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/PlayType.ascx" TagName="Help" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>七星彩彩票玩法介绍-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！ </title>
    <meta name="keywords" content="七星彩彩票玩法介绍" />
    <meta name="description" content="<%=_Site.Name %>提供七星彩彩票玩法介绍"/>
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
                        七星彩玩法介绍
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
                            <strong><span class="blue14">一、&nbsp;发行周期和开奖时间</span></strong><br />
                            七星彩每周发行三期，分别在每周二、五、日开奖，央视体育频道(CCTV-5)21：55-22：00《天天体彩》栏目播放当日全国联网玩法开奖结果。<br />
                        </p>
                        <p class="blue14">
                            <strong>二、怎么中奖&nbsp; </strong>
                        </p>
                        “七星彩”共设六个奖级，一、二等奖为浮动奖，三、四、五、六等奖为固定奖。单注彩票中奖奖金最高限额500万元。
                        <br />
                        <br />
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#DDDDDD" style="text-align:center">
                            <tr>
                                <td width="555" height="25" colspan="3" valign="top" bgcolor="#EBEBEB">
                                    <p>
                                        假设当期的开奖号码为：1234567
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="57" rowspan="2" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        奖&#160;级&nbsp;
                                    </p>
                                </td>
                                <td width="170" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        中奖条件&nbsp;
                                    </p>
                                </td>
                                <td width="328" rowspan="2" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        奖金分配&nbsp;
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="170" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        基本号码&nbsp;
                                    </p>
                                    <p>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="57" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        一等奖&nbsp;
                                    </p>
                                </td>
                                <td width="170" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        1234567（顺序必须一致）&nbsp;
                                    </p>
                                </td>
                                <td width="328" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        奖金总额为当期奖金额减去固定奖总额后的90%，以及奖池资金和调节基金转入部分；
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="57" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        二等奖&nbsp;
                                    </p>
                                </td>
                                <td width="170" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        123456X或X234567&#160;&nbsp;
                                    </p>
                                </td>
                                <td width="328" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        奖金总额为当期奖金额减去固定奖总额后的10%&nbsp;
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="57" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        三等奖&nbsp;
                                    </p>
                                </td>
                                <td width="170" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        12345XX、X23456X或XX34567
                                    </p>
                                </td>
                                <td width="328" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        单注奖金固定为1800元&nbsp;
                                    </p>
                                    <p>
                                        &#160;&nbsp;
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="57" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        四等奖&nbsp;
                                    </p>
                                </td>
                                <td width="170" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        1234XXX、X2345XX、XX3456X或XXX4567&nbsp;
                                    </p>
                                </td>
                                <td width="328" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        单注奖金固定为300元&nbsp;
                                    </p>
                                    <p>
                                        &#160;&nbsp;
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="57" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        五等奖&nbsp;
                                    </p>
                                </td>
                                <td width="170" valign="top" bgcolor="#FFFFFF">
                                    <p>
                                        123XXXX、X234XXX、XX345XX、XXX456X或XXXX567
                                    </p>
                                </td>
                                <td width="328" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        单注奖金固定为20元&nbsp;
                                    </p>
                                    <p>
                                        &#160;&nbsp;
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="57" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        六等奖&nbsp;
                                    </p>
                                </td>
                                <td width="170" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        12XXXXX、X23XXXX、XX34XXX、XXX45XX、XXXX56X或XXXXX67&nbsp;
                                    </p>
                                </td>
                                <td width="328" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        单注奖金固定为5元。&nbsp;
                                    </p>
                                    <p>
                                        &#160;&nbsp;
                                    </p>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
<!--#includefile="../Html/TrafficStatistics/1.htm"--></body>
</html>
