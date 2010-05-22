<%@ page language="C#" autoeventwireup="true" CodeFile="play_58.aspx.cs" inherits="Help_help_58" enableEventValidation="false" %>

<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/PlayType.ascx" TagName="Help" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>东方6+1彩票玩法介绍-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！ </title>
    <meta name="keywords" content="东方6+1彩票玩法介绍" />
    <meta name="description" content="<%=_Site.Name %>提供东方6+1彩票玩法介绍">
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
                        东方6+1玩法介绍
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
                            <span class="blue14">一、发行周期和开奖时间</span><br />
                            东方6+1每周发行三期，每周一、三、六开奖，开奖日的18：12分截止投注，官方开奖时间18：55分。<br />
                            <br />
                            <span class="blue14">二、怎么中奖 </span>
                        </p>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                            <tr>
                                <td width="561" colspan="5" valign="top" bgcolor="#DDDDDD">
                                    <p>
                                        假设当期的开奖号码为：345658&nbsp;+&nbsp;鼠
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="56" rowspan="2" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        奖&nbsp;级
                                    </p>
                                </td>
                                <td width="172" colspan="2" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        中奖条件
                                    </p>
                                </td>
                                <td width="221" rowspan="2" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        奖金分配
                                    </p>
                                </td>
                                <td width="111" rowspan="2" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        说明
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="101" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        基本号码
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#eaeaea">
                                    <p>
                                        生肖号码
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="56" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        一等奖
                                    </p>
                                </td>
                                <td width="101" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        345658（顺序必须一致）
                                    </p>
                                </td>
                                <td width="70" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        鼠
                                    </p>
                                </td>
                                <td width="221" valign="center" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        当奖池资金低于5000万元时，奖金总额为当期高等奖奖金的90%与奖池奖金之和，单注奖金按注均分，单注最高限额封顶500万元；当奖池资金高于5000万元时，一等奖奖金分为两部分，一部分奖金为当期高等奖奖金的40%与奖池奖金之和按注均分，单注最高限额封顶500万元；另一部分奖金为当期高等奖奖金的50%按注均分，当期未中出奖金全部滚入奖池。
                                    </p>
                                </td>
                                <td width="111" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        选6+1中6+1
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="56" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        二等奖
                                    </p>
                                </td>
                                <td width="101" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        345658
                                    </p>
                                </td>
                                <td width="70" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        &#160;
                                    </p>
                                </td>
                                <td width="221" valign="center" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        奖金总额为当期高等奖奖金的10%；单注奖金按注均分，单注最高限额封顶500万元；
                                    </p>
                                </td>
                                <td width="111" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        选6+1中6+0
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="56" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        三等奖
                                    </p>
                                </td>
                                <td width="172" colspan="2" valign="center" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        投注号码的连续5位基本号码与开奖号码的连续5位基本号码按位相符，生肖码不限，即中奖；
                                    </p>
                                </td>
                                <td width="221" valign="center" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        单注奖金额固定为1000元
                                    </p>
                                </td>
                                <td width="111" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        &nbsp;
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="56" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        四等奖
                                    </p>
                                </td>
                                <td width="172" colspan="2" valign="center" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        投注号码的连续4位基本号码与开奖号码的连续4位基本号码按位相符，生肖码不限，即中奖；
                                    </p>
                                </td>
                                <td width="221" valign="center" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        单注奖金额固定为100元
                                    </p>
                                </td>
                                <td width="111" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        &nbsp;
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="56" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        五等奖
                                    </p>
                                </td>
                                <td width="172" colspan="2" valign="top" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        投注号码的连续3位基本号码与开奖号码的连续3位基本号码按位相符，生肖码不限，即中奖
                                    </p>
                                </td>
                                <td width="221" valign="center" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        单注奖金额固定为10元
                                    </p>
                                </td>
                                <td width="111" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        &nbsp;
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td width="56" align="center" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        六等奖
                                    </p>
                                </td>
                                <td width="172" colspan="2" valign="center" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        投注号码的生肖码与中奖号码的生肖码相符，即中奖。
                                    </p>
                                </td>
                                <td width="221" valign="center" bgcolor="#FAFAFA" style="padding-left: 10px;">
                                    <p>
                                        单注奖金额固定为5元
                                    </p>
                                </td>
                                <td width="111" valign="center" bgcolor="#FAFAFA">
                                    <p>
                                        &nbsp;
                                    </p>
                                </td>
                            </tr>
                        </table>
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
