<%@ page language="C#" autoeventwireup="true" CodeFile="play_62.aspx.cs" inherits="Help_play_62" enableEventValidation="false" %>

<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/PlayType.ascx" TagName="Help" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>十一运夺金彩票玩法介绍-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！ </title>
    <meta name="keywords" content="十一运夺金彩票玩法介绍" />
    <meta name="description" content="<%=_Site.Name %>提供十一运夺金彩票玩法介绍">
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
                            十一运夺金玩法介绍
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
                            <strong><span class="blue14">一、发行周期和开奖时间</span></strong><br />
                            十一运夺金每日发行65期，9:05~21:53每12分钟开奖一次。<br />
                        </p>
                        <p class="blue14">
                            <strong>二、怎么玩 </strong>
                        </p>
                        <p>
                            十一运夺金开奖范围为11个数字，由01~11组成，每期将从中随机开出5个号码作为开奖结果。十一运夺金玩法众多，具体说明如下：
                        </p>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#DDDDDD">
                            <tr>
                                <td height="25" colspan="2" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        玩法
                                    </p>
                                </td>
                                <td width="345" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        规则
                                    </p>
                                </td>
                                <td width="97" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        奖金
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="47" rowspan="8" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        任选
                                    </p>
                                </td>
                                <td width="78" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选一
                                    </p>
                                </td>
                                <td width="345" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        选1个号码，猜开奖号码第1个数字
                                    </p>
                                </td>
                                <td width="97" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        13元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="78" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选二
                                    </p>
                                </td>
                                <td width="345" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        选2个号码，猜开奖号码任意2个数字
                                    </p>
                                </td>
                                <td width="97" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        6元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="78" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选三
                                    </p>
                                </td>
                                <td width="345" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        选3个号码，猜开奖号码任意3个数字
                                    </p>
                                </td>
                                <td width="97" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        19元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="78" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选四
                                    </p>
                                </td>
                                <td width="345" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        选4个号码，猜开奖号码任意4个数字
                                    </p>
                                </td>
                                <td width="97" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        78元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="78" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选五
                                    </p>
                                </td>
                                <td width="345" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        选5个号码，猜开奖号码的5个数字
                                    </p>
                                </td>
                                <td width="97" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        540元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="78" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选六
                                    </p>
                                </td>
                                <td width="345" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        选6个号码，猜开奖号码的5个数字
                                    </p>
                                </td>
                                <td width="97" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        90元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="78" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选七
                                    </p>
                                </td>
                                <td width="345" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        选7个号码，猜开奖号码的5个数字
                                    </p>
                                </td>
                                <td width="97" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        26元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="78" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选八
                                    </p>
                                </td>
                                <td width="345" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        选8个号码，猜开奖号码的5个数字
                                    </p>
                                </td>
                                <td width="97" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        9元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="47" rowspan="2" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        前二
                                    </p>
                                </td>
                                <td width="78" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        直选
                                    </p>
                                </td>
                                <td width="345" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        选2个号码顺序唯一，猜开奖号码的前2个数字
                                    </p>
                                </td>
                                <td width="97" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        130元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="78" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        组选
                                    </p>
                                </td>
                                <td width="345" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        选2个号码顺序不限，猜开奖号码的前2个数字
                                    </p>
                                </td>
                                <td width="97" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        65元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="47" rowspan="2" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        前三
                                    </p>
                                </td>
                                <td width="78" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        直选
                                    </p>
                                </td>
                                <td width="345" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        选3个号码顺序唯一，猜开奖号码的前3个数字
                                    </p>
                                </td>
                                <td width="97" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        1170元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="78" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        组选
                                    </p>
                                </td>
                                <td width="345" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        选3个号码顺序不限，猜开奖号码的前3个数字
                                    </p>
                                </td>
                                <td width="97" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        195元
                                    </p>
                                </td>
                            </tr>
                        </table>
                        <p>
                            &#160;&nbsp;
                        </p>
                        <p class="blue14">
                            <strong>三、怎么中奖 </strong>
                        </p>
                        <p>
                            十一运夺金的各种玩法中奖概率和难度各不相同，中奖奖金也不同，明细如下：
                        </p>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#DDDDDD">
                            <tr>
                                <td height="25" colspan="2" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        玩法
                                    </p>
                                </td>
                                <td width="124" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        开奖号码
                                    </p>
                                </td>
                                <td width="182" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        投注号码举例
                                    </p>
                                </td>
                                <td width="65" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        投注金额
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#EBEBEB">
                                    <p>
                                        中奖金额
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="40" rowspan="8" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        任选
                                    </p>
                                </td>
                                <td width="58" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选一
                                    </p>
                                </td>
                                <td width="124" rowspan="12" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        01&nbsp;02&nbsp;03&nbsp;04&nbsp;05
                                    </p>
                                </td>
                                <td width="182" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        01
                                    </p>
                                </td>
                                <td width="65" rowspan="12" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        2元
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        13元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="58" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选二
                                    </p>
                                </td>
                                <td width="182" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        01&nbsp;05
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        6元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="58" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选三
                                    </p>
                                </td>
                                <td width="182" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        01&nbsp;02&nbsp;04
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        19元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="58" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选四
                                    </p>
                                </td>
                                <td width="182" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        01&nbsp;02&nbsp;04&nbsp;05
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        78元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="58" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选五
                                    </p>
                                </td>
                                <td width="182" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        01&nbsp;02&nbsp;03&nbsp;04&nbsp;05
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        540元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="58" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选六
                                    </p>
                                </td>
                                <td width="182" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        01&nbsp;02&nbsp;03&nbsp;04&nbsp;05&nbsp;06
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        90元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="58" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选七
                                    </p>
                                </td>
                                <td width="182" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        01&nbsp;02&nbsp;03&nbsp;04&nbsp;05&nbsp;06&nbsp;07
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        26元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="58" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        任选八
                                    </p>
                                </td>
                                <td width="182" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        01&nbsp;02&nbsp;03&nbsp;04&nbsp;05&nbsp;06&nbsp;07&nbsp;08
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        9元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="40" rowspan="2" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        前二
                                    </p>
                                </td>
                                <td width="58" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        直选
                                    </p>
                                </td>
                                <td width="182" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        01&nbsp;02
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        130元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="58" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        组选
                                    </p>
                                </td>
                                <td width="182" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        02&nbsp;01
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        65元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="40" rowspan="2" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        前三
                                    </p>
                                </td>
                                <td width="58" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        直选
                                    </p>
                                </td>
                                <td width="182" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        01&nbsp;02&nbsp;03
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        1170元
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="58" height="25" align="center" valign="center" bgcolor="#F4F9FF">
                                    <p>
                                        组选
                                    </p>
                                </td>
                                <td width="182" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        02&nbsp;01&nbsp;03
                                    </p>
                                </td>
                                <td width="96" align="center" valign="center" bgcolor="#FFFFFF">
                                    <p>
                                        195元
                                    </p>
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
