<%@ page language="C#" autoeventwireup="true" CodeFile="play_65.aspx.cs" inherits="Help_play_65" enableEventValidation="false" %>

<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/PlayType.ascx" TagName="Help" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>31选7彩票玩法介绍-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！ </title>
    <meta name="keywords" content="31选7彩票玩法介绍" />
    <meta name="description" content="<%=_Site.Name %>提供31选7彩票玩法介绍">
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
                31选7玩法介绍
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
                    31选7每周发行三期，分别在每周一、四、六开奖。央视体育频道(CCTV-5)21：55-22：00《天天体彩》栏目播放当日全国联网玩法开奖结果。
                    <br />
                    <br />
                    <span class="blue14">二、怎么中奖</span></p>
                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                    <tr>
                        <td width="52" rowspan="2" align="center" valign="center" bgcolor="#eaeaea">
                            <p>
                                奖&nbsp;级</p>
                        </td>
                        <td width="190" colspan="2" align="center" valign="center" bgcolor="#eaeaea">
                            <p>
                                中奖条件
                            </p>
                        </td>
                        <td width="207" rowspan="2" align="center" valign="center" bgcolor="#eaeaea">
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
                        <td width="89" align="center" valign="center" bgcolor="#eaeaea">
                            <p>
                                特别号码
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td width="52" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                一等奖
                            </p>
                        </td>
                        <td width="101" align="center" valign="center" bgcolor="#FAFAFA" class="red14">
                            <p>
                                &#9679;&#9679;&#9679;&#9679;&#9679;&#9679;&#9679;
                            </p>
                        </td>
                        <td width="89" valign="center" bgcolor="#FAFAFA" class="blue14">
                            <p>
                                &nbsp;
                            </p>
                        </td>
                        <td width="207" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                奖金总额为当期奖金额减去固定奖总额后的88%，以及奖池和调节基金转入部分；
                            </p>
                        </td>
                        <td width="111" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                选中7+0
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td width="52" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                二等奖
                            </p>
                        </td>
                        <td width="101" align="center" valign="center" bgcolor="#FAFAFA" class="red14">
                            <p>
                                &#9679;&#9679;&#9679;&#9679;&#9679;&#9679;
                            </p>
                        </td>
                        <td width="89" align="center" valign="center" bgcolor="#FAFAFA" class="blue14">
                            <p>
                                &#160;&#9679;
                            </p>
                        </td>
                        <td width="207" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                奖金总额为当期奖金额减去固定奖总额后的12% 
                            </p>
                        </td>
                        <td width="111" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                选中6+1
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td width="52" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                三等奖
                            </p>
                        </td>
                        <td width="101" align="center" valign="center" bgcolor="#FAFAFA" class="red14">
                            <p>
                                &#9679;&#9679;&#9679;&#9679;&#9679;&#9679;
                            </p>
                        </td>
                        <td width="89" align="center" valign="center" bgcolor="#FAFAFA" class="blue14">
                            <p>
                                &nbsp;
                            </p>
                        </td>
                        <td width="207" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                单注奖金额固定为1500元
                            </p>
                        </td>
                        <td width="111" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                选6+0
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td width="52" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                四等奖
                            </p>
                        </td>
                        <td width="101" align="center" valign="center" bgcolor="#FAFAFA" class="red14">
                        
                            <p>
                                &#9679;&#9679;&#9679;&#9679;&#9679;
                            </p>
                          
                        </td>
                        <td width="89" align="center" valign="center" bgcolor="#FAFAFA" class="blue14">
                            <p>
                                &#9679;</p>
                            <p>
                            </p>
                        </td>
                        <td width="207" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                               单注奖金额固定为500元
                            </p>
                        </td>
                        <td width="111" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                选中5+1
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td width="52" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                五等奖
                            </p>
                        </td>
                        <td width="101" align="center" valign="center" bgcolor="#FAFAFA" class="red14">
                            <p>
                                &#9679;&#9679;&#9679;&#9679;&#9679;
                            </p>
                        </td>
                        <td width="89" align="center" valign="center" bgcolor="#FAFAFA" class="blue14">
                            <p>
                                &#160;
                            </p>
                        </td>
                        <td width="207" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                单注奖金额固定为50元 
                            </p>
                        </td>
                        <td width="111" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                选中5+0
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td width="52" height="25" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                六等奖
                            </p>
                        </td>
                        <td width="101" align="center" valign="center" bgcolor="#FAFAFA" class="red14">
                            <p>
                            </p>
                            <p>
                                &#9679;&#9679;&#9679;&#9679;
                            </p>
                            <p>
                            </p>
                        </td>
                        <td width="89" align="center" valign="center" bgcolor="#FAFAFA" class="blue14">
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                                &#9679;</p>
                        </td>
                        <td width="207" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                               单注奖金额固定为20元 
                            </p>
                        </td>
                        <td width="111" align="center" valign="center" bgcolor="#FAFAFA">
                            <p>
                                选中4+1
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td width="52" height="25" align="center" valign="top" bgcolor="#FAFAFA">
                            <p>
                                七等奖
                            </p>
                        </td>
                        <td width="101" align="center" valign="top" bgcolor="#FAFAFA" class="red14">
                            <p>
                                &#9679;&#9679;&#9679;&#9679;
                            </p>
                        </td>
                        <td width="89" align="center" valign="top" bgcolor="#FAFAFA" class="blue14">
                            <p>
                            </p>
                        </td>
                        <td width="207" align="center" valign="top" bgcolor="#FAFAFA">
                            <p>
                                单注奖金额固定为5元
                            </p>
                        </td>
                        <td width="111" align="center" valign="top" bgcolor="#FAFAFA">
                            <p>
                                选中4＋0
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

