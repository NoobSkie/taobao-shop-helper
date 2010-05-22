<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/Default.aspx.cs" inherits="TrendCharts_Default" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>彩票走势图-彩票走势图表和数据分析[双色球，福彩3D，时时乐、时时彩、十一运夺金]－<%=_Site.Name %></title>
    <meta name="description" content="<%=_Site.Name %>为广大彩民提供双色球，福彩3D，时时乐、时时彩、十一运夺金等彩票开奖号码预测分析。" />
    <meta name="keywords" content="彩票走势图,彩票走势图表,数据分析" />
    <link href="../Home/Room/Style/css.css" rel="stylesheet" type="text/css" />
    <link href="css.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
    <div id="box">
        <table width="1002" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <img src="Image/222.jpg" width="1002" height="66" />
                </td>
            </tr>
            <tr>
                <td>
                    <table width="1002" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                        <tr>
                            <td>
                                <table width="1002" border="0" cellpadding="0" cellspacing="0" class="table">
                                    <tr>
                                        <td width="135" height="28">
                                            <img src="Image/bt.jpg" width="135" height="28" alt="走势图工具" />
                                        </td>
                                        <td width="867" align="left" background="Image/tit_bg.jpg">
                                            <table width="98%" border="0" cellspacing="0" cellpadding="0" style="margin-left: 5px;">
                                                <tr>
                                                    <td width="60" align="center">
                                                        <span class=" blue12_3">&nbsp;<a href="SSQ/SSQ_CGXMB.aspx">双色球</a></span>&nbsp;
                                                    </td>
                                                    <td width="5" align="center" class="blue12">
                                                        |
                                                    </td>
                                                    <td width="79" align="center" class="blue12_3">
                                                        &nbsp;<a href="CJDLT/Default.aspx">超级大乐透</a>&nbsp;
                                                    </td>
                                                    <td width="5" align="center" class="blue12">
                                                        |
                                                    </td>
                                                    <td width="81" align="center" class="blue12_3">
                                                        &nbsp;<a href="SYYDJ/SYDJ_FBZS.aspx">十一运夺金</a>&nbsp;
                                                    </td>
                                                    <td width="5" align="center" class="blue12">
                                                        |
                                                    </td>
                                                    <td width="60" align="center" class="blue12_3">
                                                        &nbsp;<a href="SHSSL/SHSSL_ZHFB.aspx">时时乐</a>&nbsp;
                                                    </td>
                                                    <td width="5" align="center" class="blue12">
                                                        |
                                                    </td>
                                                    <td width="56" align="center" class="blue12_3">
                                                        &nbsp;<a href="FC3D/FC3D_ZHXT.aspx">福彩3D</a>&nbsp;
                                                    </td>
                                                    <td width="5" align="center" class="blue12">
                                                        |
                                                    </td>
                                                    <td width="60" align="center" class="blue12_3">
                                                        &nbsp;<a href="QLC/7LC_CGXMB.aspx">七乐彩</a>&nbsp;
                                                    </td>
                                                    <td width="5" align="center" class="blue12">
                                                        |
                                                    </td>
                                                    <td width="60" align="center" class="blue12_3">
                                                        &nbsp;<a href="JXSSC/SSC_5X_ZHFB.aspx">时时彩</a>&nbsp;
                                                    </td>
                                                    <td width="5" align="center" class="blue12">
                                                        |
                                                    </td>
                                                    <td width="60" align="center" class="blue12_3">
                                                        &nbsp;<a href="PL3/Default.aspx">排列3</a>
                                                    </td>
                                                    <td width="5" align="center" class="blue12">
                                                        |
                                                    </td>
                                                    <td width="60" align="center" class="blue12_3">
                                                        &nbsp;<a href="PL5/Default.aspx">排列5</a>
                                                    </td>
                                                    <td width="5" align="center" class="blue12">
                                                        |
                                                    </td>
                                                    <td width="60" align="center" class="blue12_3">
                                                        &nbsp;<a href="7Xing/Default.aspx">七星彩</a>&nbsp;
                                                    </td>
                                                    <td width="5" align="center" class="blue12">
                                                        |
                                                    </td>
                                                    <td width="60" align="center" class="blue12_3">
                                                        &nbsp;<a href="TC22X5/Default.aspx">22选5</a>&nbsp;
                                                    </td>
                                                    <td width="5" align="center" class="blue12">
                                                        |
                                                    </td>
                                                    <td width="60" align="center" class="blue12_3">
                                                        &nbsp;<a href="DF6J1/DF61_ZHFB.aspx">东方6+1</a>&nbsp;
                                                    </td>
                                                    <td width="5" align="center" class="blue12">
                                                        |
                                                    </td>
                                                    <td width="80" align="center" class="blue12_3">
                                                        &nbsp;<a href="HD15X5/C15X5_CGXMB.aspx">华东15选5</a>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="1002" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                                    <tr>
                                        <td height="611">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="49%">
                                                        <table width="370" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
                                                            <tr>
                                                                <td height="28" background="Image/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12" style="padding-left: 10PX;">
                                                                    <h1 class="blue12" style="display:inline;">双色球走势图</h1>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="161" align="left" valign="top" bgcolor="#FFFFFF">
                                                                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="32%" height="147" align="center" valign="middle">
                                                                                <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <a href="SSQ/SSQ_CGXMB.aspx"><img src="Image/ssqLOGO.gif" width="91" height="91" alt="双色球走势图" /></a>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" class="blue12">
                                                                                            <strong>双色球</strong>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td width="68%" valign="top">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="43%" height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="SSQ/SSQ_CGXMB.aspx" style="font-weight:normal;">常规项目表</a></span>
                                                                                        </td>
                                                                                        <td width="57%" height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="SSQ/SSQ_ZHFB.aspx" style="font-weight:normal;">综合分布图</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="SSQ/SSQ_3FQ.aspx" style="font-weight:normal;">3分区分布图
                                                                                            </a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="SSQ/SSQ_DX.aspx" style="font-weight:normal;">大小分析
                                                                                            </a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="SSQ/SSQ_JO.aspx" style="font-weight:normal;">奇偶分析
                                                                                            </a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="SSQ/SSQ_ZH.aspx" style="font-weight:normal;">质合分析</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="SSQ/SSQ_HL.aspx" style="font-weight:normal;">红蓝走势图</a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="SSQ/SSQ_BQZST.aspx" style="font-weight:normal;">篮球综合走势图</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="51%">
                                                        <table width="370" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9" style="margin-left: 10px;">
                                                            <tr>
                                                                <td height="28" background="Image/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12" style="padding-left: 10PX;">
                                                                    <h1 class="blue12" style="display:inline;">十一运夺金走势图</h1>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="161" align="left" valign="top" bgcolor="#FFFFFF">
                                                                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="32%" height="147" align="center" valign="middle">
                                                                                <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <a href="SYYDJ/SYDJ_FBZS.aspx"><img src="Image/syyLOGO.gif" width="91" height="91" alt="十一运夺金走势图" /></a>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" class="blue12">
                                                                                            <strong>十一运夺金</strong>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td width="68%" valign="top">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="50%" height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="SYYDJ/SYDJ_FBZS.aspx" style="font-weight:normal;">分布走势</a></span>
                                                                                        </td>
                                                                                        <td width="50%" height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="SYYDJ/SYDJ_DWZS.aspx" style="font-weight:normal;">定位走势</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="SYYDJ/SYDJ_HZFB.aspx" style="font-weight:normal;">和值分布
                                                                                            </a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="SYYDJ/SYDJ_Q2FBT.aspx" style="font-weight:normal;">前二分布图
                                                                                            </a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="SYYDJ/SYDJ_Q2ZXDYB.aspx" style="font-weight:normal;">前二组选对应表
                                                                                            </a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="SYYDJ/SYDJ_Q2HZ.aspx" style="font-weight:normal;">前二和值</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="SYYDJ/SYDJ_Q3FWT.aspx" style="font-weight:normal;">前三分位图</a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="SYYDJ/SYDJ_Q3FBT.aspx" style="font-weight:normal;">
                                                                                                前三分布图</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="SYYDJ/SYDJ_Q3HZT.aspx" style="font-weight:normal;">前三和值图</a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="370" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9" style="margin-top: 10px;">
                                                            <tr>
                                                                <td height="28" background="Image/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12" style="padding-left: 10PX;">
                                                                    <h1 class="blue12" style="display:inline;">时时乐走势图</h1>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="161" align="left" valign="top" bgcolor="#FFFFFF">
                                                                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="32%" height="147" align="center" valign="middle">
                                                                                <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <a href="SHSSL/SHSSL_ZHFB.aspx"><img src="Image/sslLOGO.gif" width="91" height="91" alt="时时乐走势图" /></a>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" class="blue12">
                                                                                            <strong>时时乐</strong>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td width="68%" valign="top">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="43%" height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="SHSSL/SHSSL_ZHFB.aspx" style="font-weight:normal;">综合分布图</a></span>
                                                                                        </td>
                                                                                        <td width="57%" height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="SHSSL/SHSSL_012.aspx" style="font-weight:normal;">012路（除3余数）</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="SHSSL/SHSSL_DX.aspx" style="font-weight:normal;">大小分析
                                                                                            </a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="SHSSL/SHSSL_JO.aspx" style="font-weight:normal;">奇偶分析
                                                                                            </a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="SHSSL/SHSSL_ZH.aspx" style="font-weight:normal;">质合分析
                                                                                            </a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="SHSSL/SHSSL_HZ.aspx" style="font-weight:normal;">和值走势</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        
                                                    </td>
                                                    <td>
                                                        <table width="370" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9" style="margin-top: 10px;
                                                            margin-left: 10px;">
                                                            <tr>
                                                                <td height="28" background="Image/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12" style="padding-left: 10PX;">
                                                                    <h1 class="blue12" style="display:inline;">时时彩走势图</h1>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="161" align="left" valign="top" bgcolor="#FFFFFF">
                                                                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="32%" height="147" align="center" valign="middle">
                                                                                <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <a href="JXSSC/SSC_5X_ZHFB.aspx"><img src="Image/sscLOGO.gif" width="91" height="91" alt="时时彩走势图" /></a>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" class="blue12">
                                                                                            <strong>时时彩</strong>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td width="68%" valign="top">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="50%" height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="JXSSC/SSC_5X_ZHFB.aspx" style="font-weight:normal;">标准五星综合</a></span>
                                                                                        </td>
                                                                                        <td width="50%" height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="JXSSC/SSC_5X_ZST.aspx" style="font-weight:normal;">标准五星 </a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="JXSSC/SSC_5X_HZZST.aspx" style="font-weight:normal;">五星和值走势图</a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="JXSSC/SSC_5X_KDZST.aspx" style="font-weight:normal;">五星跨度走势图</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                     <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="JXSSC/SSC_5X_PJZZST.aspx" style="font-weight:normal;">五星平均值走势图</a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="JXSSC/SSC_5X_KDZST.aspx" style="font-weight:normal;">五星跨度走势图</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                     <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="JXSSC/SSC_5X_HZZST.aspx" style="font-weight:normal;">五星和值走势图</a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="JXSSC/SSC_5X_DXZST.aspx" style="font-weight:normal;">五星大小走势图</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                     <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="JXSSC/SSC_5X_JOZST.aspx" style="font-weight:normal;">五星奇偶走势图</a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="JXSSC/SSC_5X_ZHZST.aspx" style="font-weight:normal;">五星质合走势图</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="370" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9" style="margin-top: 10px;">
                                                            <tr>
                                                                <td height="28" background="Image/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12" style="padding-left: 10PX;">
                                                                    <h1 class="blue12" style="display:inline;">福彩3D走势图</h1>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="161" align="left" valign="top" bgcolor="#FFFFFF">
                                                                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="32%" height="147" align="center" valign="middle">
                                                                                <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                             <a href="FC3D/FC3D_ZHXT.aspx"><img src="Image/3DLOGO.gif" width="91" height="91" alt="3D走势图" /></a>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" class="blue12">
                                                                                            <strong>福彩3D</strong>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td width="68%" valign="top">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="50%" height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="FC3D/FC3D_ZHXT.aspx" style="font-weight:normal;">综合分布图遗漏图</a></span>
                                                                                        </td>
                                                                                        <td width="50%" height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="FC3D/FC3D_HSWH.aspx" style="font-weight:normal;">和数尾号码分区表</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="FC3D/FC3D_ZHZST.aspx" style="font-weight:normal;">质合形态遗漏图 </a>
                                                                                            </span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="FC3D/FC3D_XTZST.aspx" style="font-weight:normal;">形态走势遗漏图 </a>
                                                                                            </span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="FC3D/FC3D_KDZST.aspx" style="font-weight:normal;">跨度走势遗漏图 </a>
                                                                                            </span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="FC3D/FC3D_HZZST.aspx" style="font-weight:normal;">和值走势遗漏图</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="FC3D/FC3D_DZXZST.aspx" style="font-weight:normal;">大中小形态遗漏图</a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="FC3D/FC3D_ZS.aspx" style="font-weight:normal;">质数号码分区表</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="FC3D/FC3D_LHZH.aspx" style="font-weight:normal;">连号组合分区表</a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="FC3D/FC3D_DSHM.aspx" style="font-weight:normal;">单双点号码分区表</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table width="370" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9" style="margin-top: 10px;margin-left: 10px;">
                                                            <tr>
                                                                <td height="28" background="Image/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12" style="padding-left: 10PX;">
                                                                    <h1 class="blue12" style="display:inline;">超级大乐透走势图</h1>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="161" align="left" valign="top" bgcolor="#FFFFFF">
                                                                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="32%" height="147" align="center" valign="middle">
                                                                                <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <a href="CJDLT/Default.aspx"><img src="Image/dltLOGO.gif" width="91" height="91" alt="超级大乐透走势图" /></a>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" class="blue12">
                                                                                            <strong>大乐透</strong>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td width="68%" valign="top">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="50%" height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="CJDLT/Default.aspx" style="font-weight:normal;">分布图</a></span>
                                                                                        </td>
                                                                                        <td width="50%" height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="CJDLT/Default.aspx" style="font-weight:normal;">
                                                                                                前区尾号分布图 </a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="CJDLT/Default.aspx" style="font-weight:normal;">前区走势图</a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="CJDLT/Default.aspx" style="font-weight:normal;">后区走势图
                                                                                            </a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="CJDLT/Default.aspx" style="font-weight:normal;">前区冷热图
                                                                                            </a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="CJDLT/Default.aspx" style="font-weight:normal;">后区冷热图
                                                                                            </a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="CJDLT/Default.aspx" style="font-weight:normal;">奇偶走势图</a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;&nbsp;</span><a href="CJDLT/Default.aspx" style="font-weight:normal;">
                                                                                                余数走势图</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="CJDLT/Default.aspx" style="font-weight:normal;">和值分析图
                                                                                            </a></span>
                                                                                        </td>
                                                                                        <td height="28">
                                                                                            <span class="blue14"><span class="hui14">&#9642;</span>&nbsp;<a href="CJDLT/Default.aspx"
                                                                                                class="blue14" style="font-weight:normal;">连号分析图</a></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="252" align="right" valign="top">
                                            <table width="243" border="0" cellpadding="0" cellspacing="0" bgcolor="#BCD2E9" class="table">
                                                <tr>
                                                    <td height="29" align="left" valign="bottom" background="Image/tc_r1_c1.jpg" style="padding-left: 5px;">
                                                        <table width="178" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="112" align="center" background="Image/tit.jpg" class="blue12">
                                                                    <strong>双色球专家预测</strong>
                                                                </td>
                                                                <td width="89" height="25" align="center" class="blue12">
                                                                    <strong>&nbsp;</strong>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="252" align="center" bgcolor="#FCFDFE" style="padding: 5px;" id="tdSSQ" runat="server" valign="top">
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="243" border="0" cellpadding="0" cellspacing="0" bgcolor="#BCD2E9" class="table"
                                                style="margin-top: 10px;">
                                                <tr>
                                                    <td height="29" align="left" valign="bottom" background="Image/tc_r1_c1.jpg" style="padding-left: 5px;">
                                                        <table width="178" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="112" align="center" background="Image/tit.jpg" class="blue12">
                                                                    <strong>3D专家预测</strong>
                                                                </td>
                                                                <td width="89" height="25" align="center" class="blue12">
                                                                    <strong>&nbsp;</strong>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="252" align="center" bgcolor="#FCFDFE" style="padding: 5px;" id="td3D" runat="server" valign="top">
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>
