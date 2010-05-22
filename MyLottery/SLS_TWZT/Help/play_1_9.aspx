<%@ page language="C#" autoeventwireup="true" CodeFile="play_1_9.aspx.cs" inherits="Help_help_1_9" enableEventValidation="false" %>

<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/PlayType.ascx" TagName="Help" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>任选九彩票玩法介绍-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！ </title>
    <meta name="keywords" content="任选九彩票玩法介绍" />
    <meta name="description" content="<%=_Site.Name %>提供任选九彩票玩法介绍"/>
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
                        任选九玩法介绍
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
                            <strong><span class="blue14">一．关于投注</span></strong><br />
                            从胜负彩每期竞猜的14场比赛中任选9场进行投注，竞猜内容为主队在90分钟内比赛的结果，主队胜则正确竞猜结果为3；主队打平则竞猜结果为1；主队输则竞猜结果为0。</p>
                        <p>
                            <strong><span class="blue14">二．设奖</span></strong><br />
                            <br />
                            “胜负任选9场”只设1个浮动奖级，即一等奖。<br />
                            <br />
                            <strong><span class="blue14">三．中奖</span></strong><br />
                            <br />
                            选中9场的胜平负结果</p>
                        <p>
                            <strong><span class="blue14">四．奖金</span></strong><br />
                            <br />
                            一等奖为当期奖金额的100%，及奖池和调节基金转入部分；（最高限额封顶500万）</p>
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
