<%@ page language="C#" autoeventwireup="true" CodeFile="~/WinQuery/Default.aspx.cs" inherits="WinQuery_Default" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=_Site.Name %>开奖查询列表－<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %>！ </title>
    <meta name="keywords" content="双色球开奖查询、双色球开奖结果、福彩开奖查询" />
    <meta name="description" content="<%=_Site.Name %>提供福彩双色球、福彩3D、时时彩、时时乐、十一运夺金、超级大乐透开奖号码及开奖公告详情信息。" />
    <link href="../Home/Room/Style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /*布局样式*/#box
        {
            overflow: hidden;
            width: 1002px;
            margin-right: auto;
            margin-left: auto;
            padding: 0px;
        }
        #head
        {
            width: 980px;
            padding: 0px;
            overflow: hidden;
        }
        .content
        {
            width: 1002px;
            padding: 0px;
            overflow: hidden;
            margin-top: 10px;
        }
        .content1_l
        {
            float: left;
            width: 220px;
            padding: 0px;
            overflow: hidden;
        }
        .content1_770
        {
            float: left;
            width: 770px;
            padding: 0px 10px 0px 0px;
            overflow: hidden;
        }
    </style>
    <link rel="shortcut icon" href="../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
    <div id="box">
        <!-- 头部导航列表开始-->
            <div>
                <table width="1002" border="0" cellpadding="0" cellspacing="0" class="table">
                    <tr>
                        <td width="135" height="28">
                            <img src="../TrendCharts/Image/bt_3.gif" width="135" height="28" alt="走势图工具" />
                        </td>
                        <td width="867" align="left" background="../TrendCharts/Image/tit_bg.jpg" class="blue12">
                            <table width="98%" border="0" cellspacing="0" cellpadding="0" style="margin-left: 5px;
                                height: 20px;">
                                <tr>
                                    <td width="60" align="center">
                                        &nbsp;<a href="5-0-0.aspx">双色球</a>&nbsp;
                                    </td>
                                    <td width="5">
                                        |
                                    </td>
                                    <td width="79" align="center">
                                        &nbsp;<a href="39-0-0.aspx">超级大乐透</a>&nbsp;
                                    </td>
                                    <td width="5">
                                        |
                                    </td>
                                    <td width="81" align="center">
                                        &nbsp;<a href="62-0-0.aspx">十一运夺金</a>&nbsp;
                                    </td>
                                    <td width="5">
                                        |
                                    </td>
                                    <td width="60" align="center">
                                        &nbsp;<a href="29-0-0.aspx">时时乐</a>&nbsp;
                                    </td>
                                    <td width="5">
                                        |
                                    </td>
                                    <td width="56" align="center">
                                        &nbsp;<a href="6-0-0.aspx">福彩3D</a>&nbsp;
                                    </td>
                                    <td width="5">
                                        |
                                    </td>
                                    <td width="60" align="center">
                                        &nbsp;<a href="13-0-0.aspx">七乐彩</a>&nbsp;
                                    </td>
                                    <td width="5">
                                        |
                                    </td>
                                    <td width="60" align="center">
                                        &nbsp;<a href="61-0-0.aspx">时时彩</a>&nbsp;
                                    </td>
                                    <td width="5">
                                        |
                                    </td>
                                    <td width="60" align="center">
                                        &nbsp;<a href="63-0-0.aspx">排列3</a>
                                    </td>
                                    <td width="5">
                                        |
                                    </td>
                                    <td width="60" align="center">
                                        &nbsp;<a href="64-0-0.aspx">排列5</a>
                                    </td>
                                    <td width="5">
                                        |
                                    </td>
                                    <td width="60" align="center">
                                        &nbsp;<a href="3-0-0.aspx">七星彩</a>&nbsp;
                                    </td>
                                    <td width="5">
                                        |
                                    </td>
                                    <td width="60" align="center">
                                        &nbsp;<a href="9-0-0.aspx">22选5</a>&nbsp;
                                    </td>
                                    <td width="5">
                                        |
                                    </td>
                                    <td width="60" align="center">
                                        &nbsp;<a href="58-0-0.aspx">东方6+1</a>&nbsp;
                                    </td>
                                    <td width="5">
                                        |
                                    </td>
                                    <td width="80" align="center">
                                        &nbsp;<a href="59-0-0.aspx">华东15选5</a>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <!-- 头部导航列表结束-->
        <div class="content">

            <!-- 中奖查询列表主题内容开始-->
            <div class="content1_770">
                <table width="100%" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
                    <tr>
                        <td height="29" background="../TrendCharts/Image/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12"
                            style="padding-left: 10PX;">
                            <h1 class="blue12" style="display: inline;">
                                <a href="5-0-0.aspx" target="_blank">双色球开奖查询</a></h1>  
                                <span class="hui122" style="padding-left:380px;"><a href="../Lottery/Buy_SSQ.aspx" target="_blank">双色球投注/合买</a>&nbsp;|&nbsp;
                                                    <a href="../TrendCharts/SSQ/SSQ_CGXMB.aspx" target="_blank">双色球走势图</a>&nbsp;|&nbsp;
                                                    </span>                              
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="20%" align="center" valign="middle">
                                        <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <a href="Default.aspx">
                                                        <img src="../TrendCharts/Image/ssqLOGO.gif" width="91" height="92" alt="双色球中奖查询" /></a>
                                                </td>
                                            </tr>
                                            </table>
                                    </td>
                                    <td width="68%" valign="top" id="ssqInfo" runat="server" class="blue12">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
                    <tr>
                        <td height="29" background="../TrendCharts/Image/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12"
                            style="padding-left: 10PX;">
                            <h1 class="blue12" style="display: inline;">
                                <a href="39-0-0.aspx" target="_blank">超级大乐透开奖查询</a></h1>  
                                <span class="hui122" style="padding-left:280px;"><a href="../Lottery/Buy_CJDLT.aspx" target="_blank">超级大乐透投注/合买</a>&nbsp;|&nbsp;
                                    <a href="../TrendCharts/CJDLT/Default.aspx" target="_blank">超级大乐透走势图</a>&nbsp;|&nbsp;
                                    </span>                              
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="blue12">
                                <tr>
                                    <td width="20%" align="center" valign="middle">
                                        <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <a href="Default.aspx">
                                                        <img src="../TrendCharts/Image/dltLOGO.gif" width="91" height="92" alt="超级大乐透中奖查询" /></a>
                                                </td>
                                            </tr>
                                            </table>
                                    </td>
                                    <td width="68%" valign="top" id="cjdltInfo" runat="server">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
                    <tr>
                        <td height="29" background="../TrendCharts/Image/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12"
                            style="padding-left: 10PX;">
                            <h1 class="blue12" style="display: inline;">
                                <a href="62-0-0.aspx" target="_blank">十一运夺金开奖查询</a></h1> 
                                <span class="hui122" style="padding-left:280px;"> <a href="../Lottery/Buy_SYYDJ.aspx" target="_blank">十一运夺金投注/合买</a>&nbsp;|&nbsp;
                                                    <a href="../TrendCharts/SYYDJ/SYDJ_FBZS.aspx" target="_blank">十一运夺金走势图</a>&nbsp;|&nbsp;
                                                    </span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="20%" align="center" valign="middle">
                                        <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <a href="Default.aspx">
                                                        <img src="../TrendCharts/Image/syyLOGO.gif" width="91" height="92" alt="十一运夺金中奖查询" /></a>
                                                </td>
                                            </tr>
                                            </table>
                                    </td>
                                    <td width="68%" valign="top" id="syydjInfo" runat="server" class="blue12">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
                    <tr>
                        <td height="29" background="../TrendCharts/Image/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12"
                            style="padding-left: 10PX;">
                            <h1 class="blue12" style="display: inline;">
                                <a href="29-0-0.aspx" target="_blank">时时乐开奖查询</a></h1>  
                                <span class="hui122" style="padding-left:380px;"><a href="../Lottery/Buy_SSL.aspx" target="_blank">时时乐投注/合买</a>&nbsp;|&nbsp;
                                    <a href="../TrendCharts/SHSSL/SHSSL_ZHFB.aspx" target="_blank">时时乐走势图</a>&nbsp;|&nbsp;
                                    </span>                              
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="20%" align="center" valign="middle">
                                        <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <a href="Default.aspx">
                                                        <img src="../TrendCharts/Image/sslLOGO.gif" width="91" height="92" alt="时时乐中奖查询" /></a>
                                                </td>
                                            </tr>
                                            </table>
                                    </td>
                                    <td width="68%" valign="top" id="sslInfo" runat="server" class="blue12">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
                    <tr>
                        <td height="29" background="../TrendCharts/Image/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12"
                            style="padding-left: 10PX;">
                            <h1 class="blue12" style="display: inline;">
                                <a href="6-0-0.aspx" target="_blank">福彩3D开奖查询</a></h1>  
                                <span class="hui122" style="padding-left:380px;"><a href="../Lottery/Buy_3D.aspx" target="_blank">福彩3D投注/合买</a>&nbsp;|&nbsp;
                                    <a href="../TrendCharts/FC3D/FC3D_ZHXT.aspx" target="_blank">福彩3D走势图</a>&nbsp;|&nbsp;
                                    </span>                              
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="20%" align="center" valign="middle">
                                        <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <a href="Default.aspx">
                                                        <img src="../TrendCharts/Image/3DLOGO.gif" width="91" height="92" alt="福彩3D中奖查询" /></a>
                                                </td>
                                            </tr>
                                            </table>
                                    </td>
                                    <td width="68%" valign="top" id="fc3dInfo" runat="server" class="blue12">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
                    <tr>
                        <td height="29" background="../TrendCharts/Image/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12"
                            style="padding-left: 10PX;">
                            <h1 class="blue12" style="display: inline;">
                                <a href="61-0-0.aspx" target="_blank">时时彩开奖查询</a></h1>  
                                <span class="hui122" style="padding-left:380px;"><a href="../Lottery/Buy_SSC.aspx" target="_blank">时时彩投注/合买</a>&nbsp;|&nbsp;
                                    <a href="../TrendCharts/JXSSC/SSC_5X_ZHFB.aspx" target="_blank">时时彩走势图</a>&nbsp;|&nbsp;
                                    </span>                              
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="20%" align="center" valign="middle">
                                        <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <a href="Default.aspx">
                                                        <img src="../TrendCharts/Image/sscLOGO.gif" width="91" height="91" alt="时时彩中奖查询" /></a>
                                                </td>
                                            </tr>
                                            </table>
                                    </td>
                                    <td width="68%" valign="top" id="sscInfo" runat="server" class="blue12">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
                    <tr>
                        <td height="29" background="../TrendCharts/Image/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12"
                            style="padding-left: 10PX;">
                            <h1 class="blue12" style="display: inline;">
                                <a href="13-0-0.aspx" target="_blank">七乐彩开奖查询</a></h1>  
                                <span class="hui122" style="padding-left:380px;"><a href="../Lottery/Buy_QLC.aspx" target="_blank">七乐彩投注/合买</a>&nbsp;|&nbsp;
                                    <a href="../TrendCharts/QLC/7LC_CGXMB.aspx" target="_blank">七乐彩走势图</a>&nbsp;|&nbsp;
                                    </span>                              
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="20%" align="center" valign="middle">
                                        <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <a href="Default.aspx">
                                                        <img src="../TrendCharts/Image/qlcLOGO.gif" width="91" height="92" alt="七乐彩中奖查询" /></a>
                                                </td>
                                            </tr>
                                            </table>
                                    </td>
                                    <td width="68%" valign="top" id="qlcInfo" runat="server" class="blue12">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <!-- 中奖查询列表主题内容结束-->
            <!-- 中奖排行榜开始-->
            <div class="content1_l" style="padding-left: 0px; margin-left: 0px;">
                <table width="220" border="0" cellpadding="0" cellspacing="1" bgcolor="#BCD2E9">
                    <tr>
                        <td height="28" colspan="4" background="../images/tit_bg.jpg">
                            <table width="70%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="17%" align="center">
                                        <img src="../images/dian_r16_c5.jpg" width="4" height="12" />
                                    </td>
                                    <td width="83%" class="blue12">
                                        <strong>中奖排行榜</strong>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" height="30" bgcolor="#F2F6FB">
                            &nbsp;
                        </td>
                        <td width="33%" height="30" align="center" bgcolor="#F2F6FB" class="blue12">
                            用户名
                        </td>
                        <td width="33%" height="30" align="center" bgcolor="#F2F6FB" class="blue12">
                            奖金
                        </td>
                        <td width="24%" height="30" align="center" bgcolor="#F2F6FB" class="blue12">
                            跟单
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center" valign="top" background="images/zjphb.jpg" bgcolor="#FFFFFF"
                            style="padding-top: 7px; padding-bottom: 7px">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tbody id="tbWin" runat="server">
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <table width="220" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
                    <tr>
                        <td height="28" colspan="4" background="../images/tit_bg.jpg">
                            <table width="70%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="17%" align="center">
                                        <img src="../images/dian_r16_c5.jpg" width="4" height="12" />
                                    </td>
                                    <td width="83%" class="blue12">
                                        <strong>专家预测</strong>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#FFFFFF" style="padding: 5px;" id="ExpertsPredict"
                            runat="server" valign="top">
                        </td>
                    </tr>
                </table>
            </div>
            <!-- 中奖排行榜结束-->
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="../Html/TrafficStatistics/1.htm"-->
</body>
</html>
