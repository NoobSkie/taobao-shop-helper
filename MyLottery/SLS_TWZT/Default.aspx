<%@ page language="C#" autoeventwireup="true" CodeFile="~/Default.aspx.cs" inherits="Default" enableviewstate="false" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<%@ Register Src="Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="Home/Room/UserControls/Index_banner.ascx" TagName="Index_banner"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=_Site.Name %>－双色球开奖/双色球走势图查询-手机买彩票，就上<%=_Site.Name %></title>
    <meta name="description" content="<%=_Site.Name %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。" />
    <meta name="keywords" content="双色球开奖，双色球走势图，3d走势图，福彩3d，时时彩" />
    <link href="Home/Room/style/css.css" rel="stylesheet" type="text/css" />
    <link href="Style/Default.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="Home/Room/JavaScript/ExplorerCheck.js"></script>

    <script src="Home/Room/JavaScript/floatAD.js" type="text/javascript"></script>

    <script type="text/javascript">
        checkExplorerAndTip();
    </script>

    <link rel="shortcut icon" href="favicon.ico" />
</head>
<body onload="openAds()">
    <form id="form1" runat="server">
    <asp:HiddenField ID="hUserID" runat="server" />
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <div id="content">
        <uc1:Lotteries ID="Lotteries1" runat="server" />
        <div style="position: relative;">
            <div style="position: absolute; left: 1002px; top: 0px;">
                <a href="javascript:openAds()">
                    <img src="Home/Room/Images/jt.bmp" border="0" alt="显示" /></a>
            </div>
            <div id="ads" style="overflow: hidden; top: 0px; text-align: center; display: none">
                   <a href="http://mhb.shovesoft.com/bbs/showtopic-249.aspx" target="_blank"><img src="Home/Room/Images/ad_index_gg.jpg" border="0" alt="新用户注册，买2元送2元" /></a>
            </div>
            <div id="close" style="position: absolute; left: 943px; top: 0px; display: none">
                <a href="javascript:noneAds();">
                    <img src="Home/Room/images/ad_index_close.jpg" border="0" alt="双色球开奖|双色球走势图" /></a>
            </div>
            <table width="1002" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="762"  valign="top">
                        <table width="762" border="0" cellpadding="0" cellspacing="1" bgcolor="#BCD2E9">
                            <tr>
                                <td height="350" align="center" valign="top" background="images/index_top.jpg" bgcolor="#FFFFFF">
                                    <table width="388" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="34" class="red12" align="center" valign="middle" style="padding-top: 5px;"
                                                id="tdFocusNews" runat="server">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="left" class="blue12_4" id="tbFocusNews" runat="server">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <img src="images/x_x.jpg" width="388" height="2" alt="买彩票|双色球合买" />
                                                <table width="98%" border="0" style="margin-bottom: 3px;" align="center" cellpadding="0"
                                                    cellspacing="0">
                                                    <tbody id="tbSiteAffiches" runat="server">
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="362" valign="top" bgcolor="#FFFFFF" style="padding-top: 5px;">
                                    <table width="350" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <uc2:Index_banner ID="Index_banner1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 8px;">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#BCD2E9">
                                                    <tr>
                                                        <td height="108" valign="bottom" bgcolor="#FFFFFF" style="padding-top: 5px; padding-bottom: 5px;">
                                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" id="tbImageNews"
                                                                runat="server" visible="false">
                                                                <tr>
                                                                    <td width="50%" align="center">
                                                                        <a id="ImageHref1" runat="server" target="_blank">
                                                                            <img id="Image1" width="120" height="80" border="0" runat="server" alt="彩票专家"/></a>
                                                                    </td>
                                                                    <td width="50%" align="center" id="tdImage2" runat="server" visible="false">
                                                                        <a id="ImageHref2" runat="server" target="_blank">
                                                                            <img id="Image2" width="120" height="80" border="0" runat="server" alt="彩票专家"/></a>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="24" align="center" class="hui12" id="tdTitle1" runat="server">
                                                                    </td>
                                                                    <td align="center" id="tdTitle2" runat="server" visible="false">
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
                        <table width="762" border="0" cellpadding="0" cellspacing="1" bgcolor="#BCD2E9" style="margin-top: 10px;">
                            <tr>
                                <td height="47" bgcolor="#FFFFFF" style="padding-top: 10px; padding-bottom: 10px">
                                    <table width="738" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="4">
                                                <img src="images/center_r1_c1.jpg" width="4" height="110" alt="双色球投注|双色球合买"/>
                                            </td>
                                            <td width="532" background="images/center_r1_c28.jpg">
                                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="19%">
                                                            <a href="<%=ResolveUrl("~/Lottery/Buy_SSQ.aspx") %>">
                                                                <img src="images/logo5.jpg" width="92" height="92" border="0" alt="双色球投注|双色球合买" /></a>
                                                        </td>
                                                        <td width="81%">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td height="24" colspan="2" id="tbSSQ" runat="server">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="58%" height="24" class="blue142">
                                                                        <strong>双色球：2元赢取￥1500万</strong>
                                                                    </td>
                                                                    <td width="42%" rowspan="2" valign="bottom" class="blue142">
                                                                        <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="30%">
                                                                                    <a href="Lottery/Buy_SSQ.aspx?CoBuy=1" title="双色球投注|双色球合买">
                                                                                        <img src="Home/Room/images/bt_hemai.jpg" width="64" height="24" border="0" alt="双色球投注|双色球合买"/></a>
                                                                                </td>
                                                                                <td width="5%">&nbsp;
                                                                                    
                                                                              </td>
                                                                                <td width="30%">
                                                                                    <a href="LotteryPackage.aspx?LotteryID=5" title="双色球投注|双色球合买">
                                                                                        <img src="Home/Room/images/bt_taocan.jpg" width="64" height="24" border="0" alt="双色球投注|双色球合买"/></a>
                                                                                </td>
                                                                                <td width="5%">&nbsp;
                                                                                    
                                                                              </td>
                                                                                <td width="30%">
                                                                                    <a href="Lottery/Buy_SSQ.aspx" title="双色球投注|双色球合买">
                                                                                        <img src="Home/Room/images/bt_touzhu.jpg" width="64" height="24" border="0" alt="双色球投注|双色球合买"/></a>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="24" class="hui12">
                                                                        每周二、四、日20:30开奖
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="202" background="images/center_r1_c30.jpg" id="tdSSQWinList" runat="server">
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="738" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 5px;">
                                        <tr>
                                            <td width="4">
                                                <img src="images/center_r1_c1.jpg" width="4" height="110" title="超级大乐透投注|超级大乐透合买"/>
                                            </td>
                                            <td width="532" background="images/center_r1_c28.jpg">
                                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="19%">
                                                            <a href="<%=ResolveUrl("~/Lottery/Buy_CJDLT.aspx") %>">
                                                                <img src="images/logo39.jpg" width="92" height="92" border="0" alt="超级大乐透投注/合买" /></a>
                                                        </td>
                                                        <td width="81%">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td height="24" colspan="2" id="tbDLT" runat="server">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="58%" height="24" class="style1">
                                                                        <strong>大乐透：3元可中￥2400万 </strong>
                                                                    </td>
                                                                    <td width="42%" rowspan="2" valign="bottom" class="blue142">
                                                                        <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <a href="Lottery/Buy_CJDLT.aspx?CoBuy=1" title="超级大乐透投注|超级大乐透合买">
                                                                                        <img src="Home/Room/images/bt_hemai.jpg" width="64" height="24" border="0" alt="超级大乐透投注|超级大乐透合买"/></a>
                                                                                </td>
                                                                                <td width="5%">&nbsp;
                                                                                    
                                                                              </td>
                                                                                <td width="30%">
                                                                                    <a href="LotteryPackage.aspx?LotteryID=39" title="超级大乐透投注|超级大乐透合买">
                                                                                        <img src="Home/Room/images/bt_taocan.jpg" width="64" height="24" border="0" alt="超级大乐透投注|超级大乐透合买"/></a>
                                                                                </td>
                                                                                <td width="5%">&nbsp;
                                                                                    
                                                                              </td>
                                                                                <td>
                                                                                    <a href="Lottery/Buy_CJDLT.aspx" title="超级大乐透投注|超级大乐透合买">
                                                                                        <img src="Home/Room/images/bt_touzhu.jpg" width="64" height="24" border="0" alt="超级大乐透投注|超级大乐透合买"/></a>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="24" class="style2">
                                                                        每周一、三、六开奖
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="199" background="images/center_r1_c30.jpg" id="tdDLTWinList" runat="server">
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="738" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 5px;">
                                        <tr>
                                            <td width="4">
                                                <img src="images/center_r1_c1.jpg" width="4" height="110" title="时时乐投注|时时乐合买"/>
                                            </td>
                                            <td width="535" background="images/center_r1_c28.jpg">
                                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="19%">
                                                            <a href="<%=ResolveUrl("~/Lottery/Buy_SSL.aspx") %>" title="时时乐投注|时时乐合买">
                                                                <img src="images/logo29.jpg" width="92" height="92" border="0" alt="时时乐投注/合买" /></a>
                                                        </td>
                                                        <td width="81%">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td height="24" colspan="2" id="tbSSL" runat="server">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="58%" height="24" class="blue142">
                                                                        <strong>时时乐：2元赢取￥980元 </strong>
                                                                    </td>
                                                                    <td width="42%" rowspan="2" valign="bottom" class="blue14">
                                                                        <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <a href="Lottery/Buy_SSL.aspx?CoBuy=1" title="时时乐投注|时时乐合买">
                                                                                        <img src="Home/Room/images/bt_hemai.jpg" width="64" height="24" border="0" 
alt="时时乐投注|时时乐合买"/></a>
                                                                                </td>
                                                                                <td align="right">
                                                                                    <a href="Lottery/Buy_SSL.aspx" title="时时乐投注|时时乐合买">
                                                                                        <img src="Home/Room/images/bt_touzhu.jpg" width="64" height="24" border="0" 
alt="时时乐投注|时时乐合买"/></a>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="24" class="hui12">
                                                                        更多中奖机会,每30分钟开奖,每天23期
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="199" background="images/center_r1_c30.jpg" id="tdSSLWinList" runat="server">
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="738" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 5px">
                                        <tr>
                                            <td width="4">
                                                <img src="images/center_r1_c1.jpg" width="4" height="110" alt="十一运夺金投注|十一运夺金合买" />
                                            </td>
                                            <td width="535" background="images/center_r1_c28.jpg">
                                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="19%">
                                                            <a href="<%=ResolveUrl("~/Lottery/Buy_SYYDJ.aspx") %>" title="十一运夺金投注|十一运夺金合买">
                                                                <img src="images/logo62.jpg" width="92" height="92" border="0" alt="十一运夺金投注/合买" /></a>
                                                        </td>
                                                        <td width="81%">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td height="24" colspan="2" id="tbSYYDJ" runat="server">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="58%" height="24" class="blue142">
                                                                        <strong>十一运夺金：2元赢取￥1170元 </strong>
                                                                    </td>
                                                                    <td width="42%" rowspan="2" valign="bottom" class="blue142">
                                                                        <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <a href="Lottery/Buy_SYYDJ.aspx?CoBuy=1" title="十一运夺金投注|十一运夺金合买">
                                                                                        <img src="Home/Room/images/bt_hemai.jpg" width="64" height="24" border="0" alt="十一运夺金投注|十一运夺金合买"/></a>
                                                                                </td>
                                                                                <td align="right">
                                                                                    <a href="Lottery/Buy_SYYDJ.aspx" title="十一运夺金投注|十一运夺金合买">
                                                                                        <img src="Home/Room/images/bt_touzhu.jpg" width="64" height="24" border="0" alt="十一运夺金投注|十一运夺金合买"/></a>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="24" class="hui12">
                                                                        每12分钟开奖,返奖率高达59%
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="199" background="images/center_r1_c30.jpg" id="tdSYYDJWinList" runat="server">
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="738" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 5px;">
                                        <tr>
                                            <td width="4">
                                                <img src="images/center_r1_c1.jpg" width="4" height="110" alt="福彩3D投注|福彩3D合买"/>
                                            </td>
                                            <td width="535" background="images/center_r1_c28.jpg">
                                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="19%">
                                                            <a href="<%=ResolveUrl("~/Lottery/Buy_3D.aspx") %>">
                                                                <img src="images/logo6.jpg" width="92" height="92" border="0" alt="福彩3D投注/合买" /></a>
                                                        </td>
                                                        <td width="81%">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td height="24" colspan="2" id="tbFC3D" runat="server">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="58%" height="24" class="blue142">
                                                                        <strong>福彩3D：2元赢取￥1000元</strong>
                                                                    </td>
                                                                    <td width="42%" rowspan="2" valign="bottom" class="blue142">
                                                                        <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="30%">
                                                                                    <a href="Lottery/Buy_3D.aspx?CoBuy=1" title="福彩3D投注|福彩3D合买">
                                                                                        <img src="Home/Room/images/bt_hemai.jpg" width="64" height="24" border="0" alt="福彩3D投注|福彩3D合买"/></a>
                                                                                </td>
                                                                                <td width="5%">&nbsp;
                                                                                    
                                                                              </td>
                                                                                <td width="30%">
                                                                                    <a href="LotteryPackage.aspx?LotteryID=6" title="福彩3D投注|福彩3D合买">
                                                                                        <img src="Home/Room/images/bt_taocan.jpg" width="64" height="24" border="0" alt="福彩3D投注|福彩3D合买"/></a>
                                                                                </td>
                                                                                <td width="5%">&nbsp;
                                                                                    
                                                                              </td>
                                                                                <td width="30%">
                                                                                    <a href="Lottery/Buy_3D.aspx" title="福彩3D投注|福彩3D合买">
                                                                                        <img src="Home/Room/images/bt_touzhu.jpg" width="64" height="24" border="0" alt="福彩3D投注|福彩3D合买"/></a>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="24" class="hui12">
                                                                        多种玩法,更多中奖机会,每日20:30开奖
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="199" background="images/center_r1_c30.jpg" id="tdFC3DWinList" runat="server">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="240" valign="top">
						<a name="Login"></a>
                        <table width="232" border="0" align="right" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table width="232" border="0" align="right" cellpadding="0" cellspacing="1" bgcolor="#BCD2E9">
                                        <tr>
                                            <td height="31" background="images/hy_tit.jpg">
                                                <table width="70%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="17%" align="center">
                                                            <img src="images/dian_r16_c5.jpg" width="4" height="12" alt="会员登录"/>
                                                        </td>
                                                        <td width="83%" class="blue12">
                                                            <strong>会员登录</strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" background="images/hy_bg.jpg" bgcolor="#FFFFFF" style="padding-top: 10px;">
                                                <asp:Panel ID="pNoLogin" runat="server" Visible="false">
                                                    <table width="207" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                           
                                                            <td  height="28">
                                                               <span class="blue12">用户名：</span> <asp:TextBox ID="tbFormUserName" runat="server" Width="135"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                           
                                                            <td height="28">
                                                                <span class="blue12">密&nbsp; &nbsp;码：</span> <asp:TextBox ID="tbFormUserPassword" runat="server" TextMode="Password" Width="135" />
                                                            </td>
                                                        </tr>
                                                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                                                            <tr id="CheckCode" runat="server">
                                                                <td height="28" colspan="2">
                                                                <span class="blue12">验证码：</span>
                                                                    <asp:TextBox ID="tbFormCheckCode" runat="server" MaxLength="6" size="6"></asp:TextBox>
                                                                    <ShoveWebUI:ShoveCheckCode ID="ShoveCheckCode1" runat="server" ForeColor="CornflowerBlue"
                                                                        BackColor="SeaShell" Charset="OnlyNumeric" Height="20px" SupportDir="~/ShoveWebUI_client"
                                                                        Style="vertical-align: top; padding-top: 3px;"></ShoveWebUI:ShoveCheckCode>
                                                                </td>
                                                            </tr>
                                                        </asp:Panel>
                                                        <tr>
                                                            <td height="24" align="center" style="padding-top: 5px; padding-bottom: 8px;">
                                                                <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="63%" align="center" class="blue12">
                                                                            <a href="UserReg.aspx" target="_blank" title="免费注册">免费注册 </a>| <a href="Home/Room/ForgetPassword.aspx"
                                                                                target="_blank" title="忘记密码">忘记密码</a>
                                                                        </td>
                                                                        <td width="37%">
                                                                            <ShoveWebUI:ShoveConfirmButton ID="btnLogin" Style="cursor: pointer;" runat="server"
                                                                                Width="76px" Height="26px" CausesValidation="False" BackgroupImage="images/dl_bt.gif"
                                                                                BorderStyle="None" OnClick="btnLogin_Click" />
                                                                            <asp:Button ID="btnLogin2" runat="server" Text="登录" OnClick="btnLogin_Click" Style="display: none" />
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-bottom: 5px;">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="51%" align="center" bgcolor="#E3F2FD" class="red12" ><%=_Site.Name %>支持3亿QQ会员直接登录</td>
                                                                        <td align="right">
                                                                            <a href="Home/Room/TencentLogin.aspx" target="_blank" title="QQ会员登录">
                                                                                <img src="images/index_top_r10_c51.jpg" width="98" height="35" border="0" alt="QQ会员登录"/></a>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pLoginning" runat="server" Visible="false">
                                                    <table width="207" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="center" height="28" class="blue12">
                                                                <asp:Label ID="lbUserName" runat="server" CssClass="red12"></asp:Label>,您好！ 级别：<asp:Label
                                                                    ID="lbUserType" runat="server" CssClass="red12"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 207px; text-align: center;" class="blue12">
                                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td height="28">
                                                                            <a href="Home/Room/OnlinePay/Default.aspx" title="用户充值">用户充值</a>
                                                                        </td>
                                                                        <td>
                                                                            <a href="Home/Room/AccountDetail.aspx" title="用户中心">用户中心</a>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="28">
                                                                            <a href="Home/Room/UserEdit.aspx" title="我的资料">我的资料</a>
                                                                        </td>
                                                                        <td>
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="trAdmin" runat="server">
                                                                        <td colspan="2" height="28">
                                                                            <asp:HyperLink ID="hlAdmin" runat="server">超级管理</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" id="tdOut" runat="server" style="padding: 8px; padding-bottom: 10px;">
                                                                <ShoveWebUI:ShoveConfirmButton ID="imgbtnLogout" Style="cursor: hand; color: #000000;"
                                                                    BackgroupImage="images/exit.gif" runat="server" Height="34px" Width="160px" CausesValidation="False"
                                                                    BorderStyle="None" OnClick="imgbtnLogout_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <table width="207" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td height="6" colspan="2">
                                                            <table width="207" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                </tr>
                                                                <tr>
                                                                    <td height="12" colspan="2">
                                                                        <img src="images/dl_x.jpg" width="205" height="1" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="6" colspan="2" align="right"  style="padding-bottom: 5px">
                                                           <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="33%" height="24" align="center" class="blue12_3">
                                                                    <a href="Help/help_Buy.aspx" target="_blank" title="如何购彩">如何购彩</a>
                                                                </td>
                                                                <td height="24" align="center" class="blue12_3">
                                                                    <a href="Help/help_Cobuy1.aspx" target="_blank" title="如何合买">如何合买</a>
                                                                </td>
                                                                <td height="24" align="center" class="blue12_3">
                                                                    <a href="Help/help_Chase.aspx" target="_blank" title="如何追号">如何追号</a>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="24" align="center" class="blue12_3">
                                                                    <a href="Help/help_Draw_Money.aspx" target="_blank" title="如何提款">如何提款</a>
                                                                </td>
                                                                <td height="24" align="center" class="blue12_3" colspan="2">
                                                                    如何领取1000万大奖！
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
                                <td style="padding-top: 8px;">
                                    <table width="232" border="0" align="right" cellpadding="0" cellspacing="0" class="table">
                                        <tr>
                                            <td width="89" height="29" background="images/tc_r1_c1.jpg">
                                                <table width="92%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="28" align="center">
                                                            <img src="images/dian_r16_c5.jpg" width="4" height="12" alt="包月套餐"/>
                                                        </td>
                                                        <td width="57" class="blue12">
                                                            <strong>追号套餐</strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="141" background="images/tc_r1_c1.jpg">
                                                <table width="140" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="70" height="29" valign="bottom" background="images/tc_r1_c3.jpg" id="tdSSQChase">
                                                            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td height="22" align="center" class="blue12">
                                                                        <a href="javascript:;" onclick="return clickChaseLottery('tdSSQChase')" title="双色球套餐">双色球</a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="bottom" id="tdFC3DChase">
                                                            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td height="22" align="center" class="blue12">
                                                                        <a href="javascript:;" onclick="return clickChaseLottery('tdFC3DChase')" title="福彩3D">福彩3D</a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="228" colspan="2" valign="top" background="images/tc.jpg" style="padding-top: 5px;">
                                                <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="61%" class="gray12">
                                                            <a href="javascript:;" onclick="CustomChase(1,this)" target="_blank"><span class="red12_3">
                                                                吉祥</span> <span class="hui12">每期1注 共<span id="spanIsuse1">14</span>期<br />
                                                                    （包月）金额：<span id="spanMoney1">28</span>元</span></a>
                                                        </td>
                                                        <td width="39%" align="center">
                                                            <a href="javascript:;" onclick="CustomChase(1,this)" target="_blank">
                                                                <img src="images/tc_r3_c4.jpg" width="76" height="30" border="0" style="cursor: pointer" alt="包月"/></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <img src="images/dl_x.jpg" alt="" width="205" height="1" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="gray12">
                                                            <a href="javascript:;" onclick="CustomChase(2,this)" target="_blank"><span class="red12_3">
                                                                如意</span> <span class="hui12">每期1注 共<span id="spanIsuse2">42</span>期<br />
                                                                    （包季）金额：<span id="spanMoney2">84</span>元</span></a>
                                                        </td>
                                                        <td align="center">
                                                            <a href="javascript:;" onclick="CustomChase(2,this)" target="_blank">
                                                                <img src="images/tc_r3_c4.jpg" width="76" height="30" border="0" style="cursor: pointer" alt="包季"/></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <img src="images/dl_x.jpg" alt="" width="205" height="1" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="gray12">
                                                            <a href="javascript:;" onclick="CustomChase(3,this)" target="_blank"><span style="">
                                                                <span class="red12_3">幸福</span> <span class="hui12">每期1注 共<span id="spanIsuse3">84</span>期<br />
                                                                    （半年）金额：<span id="spanMoney3">168</span>元</span></span></a>
                                                        </td>
                                                        <td align="center">
                                                            <a href="javascript:;" onclick="CustomChase(3,this)" target="_blank">
                                                                <img src="images/tc_r3_c4.jpg" width="76" height="30" border="0" style="cursor: pointer" alt="半年"/></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <img src="images/dl_x.jpg" alt="" width="205" height="1" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="gray12">
                                                            <a href="javascript:;" onclick="CustomChase(4,this)" target="_blank"><span class="red12_3">
                                                                安康</span> <span class="hui12">每期1注 共<span id="spanIsuse4">168</span>期<br />
                                                                    （包年）金额：<span id="spanMoney4">336</span>元</span></a>
                                                        </td>
                                                        <td align="center">
                                                            <a href="javascript:;" onclick="CustomChase(4,this)" target="_blank">
                                                                <img src="images/tc_r3_c4.jpg" width="76" height="30" border="0" style="cursor: pointer" alt="包年"/></a>
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
                                    <table width="232" border="0" cellspacing="0" cellpadding="0" style="margin-bottom: 8px;
                                        margin-top: 8px;">
                                        <tr>
                                            <td>
                                                <a href="Lottery/Buy_CJDLT.aspx" target="_blank" title="超级大乐透">
                                                    <img src="images/guanggao.gif" width="233" height="90" alt="超级大乐透" /></a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="232" border="0" cellpadding="0" cellspacing="1" bgcolor="#BCD2E9">
                                        <tr>
                                            <td height="28" colspan="4" background="images/tit_bg.jpg">
                                                <table width="70%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="17%" align="center">
                                                            <img src="images/dian_r16_c5.jpg" width="4" height="12" />
                                                        </td>
                                                        <td width="83%" class="blue12">
                                                            <strong>中奖排行榜</strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%" height="30" bgcolor="#F2F6FB">&nbsp;
                                                
                                          </td>
                                            <td width="31%" height="30" align="center" bgcolor="#F2F6FB" class="blue12">
                                                用户名
                                            </td>
                                            <td width="35%" height="30" align="center" bgcolor="#F2F6FB" class="blue12">
                                                金额
                                            </td>
                                            <td width="24%" height="30" align="center" bgcolor="#F2F6FB" class="blue12">
                                                跟单
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" valign="top" background="images/zjphb.jpg" bgcolor="#FFFFFF"
                                                style="padding-top: 7px;padding-bottom:7px">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tbody id="tbWin" runat="server">
                                                    </tbody>
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
            <table width="1002" border="0" cellspacing="0" cellpadding="0" style="margin-bottom: 8px;
                margin-top: 6px;">
                <tr>
                    <td><a href="Lottery/Buy_SSQ.aspx" target="_blank" title="双色球|中奖">
                            <img src="images/banner1.gif" width="1002" height="80" alt="双色球|中奖" /></a>
                    </td>
                </tr>
            </table>
         
            <table width="1002" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                <tr>
                    <td width="31%" valign="top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#BCD2E9">
                            <tr>
                                <td height="28" background="images/tit_bg.jpg" bgcolor="#FFFFFF">
                                    <table width="50%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="17%" align="center">
                                                <img src="images/dian_r16_c5.jpg" width="4" height="12" alt="福彩资讯"/>
                                            </td>
                                            <td width="83%" class="blue12">
                                                <strong>福彩资讯</strong>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" bgcolor="#FFFFFF" style="padding-top: 5px; padding-left: 5px;">
                                    <table width="96%" border="0" cellspacing="0" cellpadding="0">
                                        <tbody id="tbFCZX" runat="server">
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="31%" style="padding-left: 5px" valign="top">
                        <table width="100%" border="0" align="left" cellpadding="0" cellspacing="1" bgcolor="#BCD2E9">
                            <tr>
                                <td height="28" background="images/tit_bg.jpg" bgcolor="#FFFFFF">
                                    <table width="50%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="17%" align="center">
                                                <img src="images/dian_r16_c5.jpg" width="4" height="12" alt="体彩资讯"/>
                                            </td>
                                            <td width="83%" class="blue12">
                                                <strong>体彩资讯</strong>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFFF" style="padding-top: 5px; padding-left: 5px;">
                                    <table width="96%" border="0" cellspacing="0" cellpadding="0">
                                        <tbody id="tbTCZX" runat="server">
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="31%" style="padding-left: 5px" valign="top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#BCD2E9">
                            <tr>
                                <td height="28" background="images/tit_bg.jpg" bgcolor="#FFFFFF">
                                    <table width="50%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="17%" align="center">
                                                <img src="images/dian_r16_c5.jpg" width="4" height="12" alt="足彩资讯"/>
                                            </td>
                                            <td width="83%" class="blue12">
                                                <strong>足彩资讯</strong>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFFF" style="padding-top: 5px; padding-left: 5px;">
                                    <table width="96%" border="0" cellspacing="0" cellpadding="0">
                                        <tbody id="tbZCZX" runat="server">
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="1002" border="0" cellpadding="0" cellspacing="0" class="table1" style="margin-top: 10px;">
                <tr>
                    <td width="272" height="349" align="center" bgcolor="#FFFFFF" valign="top" style="padding-top: 10px">
                        <img src="images/index_r20_c7.jpg" width="261" height="337" usemap="#Map" />                    </td>
                    <td width="727" valign="top" bgcolor="#FFFFFF" style="padding: 8px;">
                        <table width="717" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="9" height="29" style="background-image: url(images/xsbz_tit_r1_c1.jpg);">&nbsp;
                                    
                              </td>
                                <td width="708" background="images/xsbz_tit_r1_c6.jpg">
                                    <table width="15%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="17%" align="center">
                                                <img src="images/dian_r16_c5.jpg" width="4" height="12" alt="新手指南"/>
                                            </td>
                                            <td width="83%" class="blue12">
                                                <strong>新手指南</strong>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="10" style="background-image: url(images/xsbz_tit_r1_c19.jpg);">&nbsp;
                                    
                              </td>
                            </tr>
                            <tr>
                                <td height="148" colspan="3" valign="top" bgcolor="#FFFFFF">
                                    <table width="717" border="0" cellpadding="0" cellspacing="1" bgcolor="#BCD2E9">
                                        <tr>
                                            <td height="73" colspan="2" bgcolor="#FFFFFF">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="23" background="images/xsbz_r1_c5.jpg">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="12%" style=" border-bottom-style:solid; border-bottom-color:#BCD2E9; border-bottom-width:1px" >
                                                                        <img src="images/xsbz_r1_c1.jpg" width="85" height="22" border="0"/>
                                                                    </td>
                                                                    <td width="88%">
                                                                        <table width="630" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="70" height="23" align="center" valign="middle" background="images/index_r24_c42.jpg"
                                                                                    class="blue12_4_2" id="tdSSQ">
                                                                                    <a href="javascript:;" onclick="return clickLottery(3,5,this,0,'SSQ','5-0-0');" title="双色球">双色球</a>
                                                                                </td>
                                                                                <td width="70" align="center" valign="middle" class="blue12_4_2">
                                                                                    <a href="javascript:;" onclick="return clickLottery(3,6,this,1,'3D','6-0-0');" title="福彩3D">福彩3D</a>
                                                                                </td>
                                                                                <td width="70" align="center" valign="middle" class="blue12_4_2">
                                                                                    <a href="javascript:;" onclick="return clickLottery(3,13,this,2,'QLC','13-0-0');" title="七乐彩">七乐彩</a>
                                                                                </td>
                                                                                <td width="70" align="center" valign="middle" class="blue12_4_2">
                                                                                    <a href="javascript:;" onclick="return clickLottery(3,58,this,3,'DF6J1','58-0-0');" title="东方6+1">东方6+1</a>
                                                                                </td>
                                                                                <td width="70" align="center" valign="middle" class="blue12_4_2">
                                                                                    <a href="javascript:;" onclick="return clickLottery(3,59,this,4,'15X5','59-0-0');" title="15选5">15选5</a>
                                                                                </td>
                                                                                <td width="70" align="center" valign="middle" class="blue12_4_2">
                                                                                    <a href="javascript:;" onclick="return clickLottery(3,39,this,5,'CJDLT','39-0-0');" title="大乐透">大乐透</a>
                                                                                </td>
                                                                                <td width="70" align="center" valign="middle" class="blue12_4_2">
                                                                                    <a href="javascript:;" onclick="return clickLottery(3,63,this,6,'PL3','63-0-0');" title="排列三">排列三</a>
                                                                                </td>
                                                                                <td width="70" align="center" valign="middle" class="blue12_4_2">
                                                                                    <a href="javascript:;" onclick="return clickLottery(3,64,this,7,'PL5','64-0-0');" title="排列五">排列五</a>
                                                                                </td>
                                                                                <td width="70" align="center" valign="middle" class="blue12_4_2">
                                                                                    <a href="javascript:;" onclick="return clickLottery(3,3,this,8,'QXC','3-0-0');" title="七星彩">七星彩</a>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="50" colspan="2" align="center" class="hui12">
                                                            <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td align="left" style="text-indent: 25px; padding-top: 5px; padding-bottom: 5px"
                                                                        id="tdIntro3">
                                                                        双色球投注分为红球和蓝球，红球号码范围为01～33，蓝球号码范围为01～16，每期开出6个红球和1个蓝球作为中奖号码。根据所选号码与开奖号码命中个数确定中奖奖级与中奖金额。
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="23" colspan="2" align="left" background="images/xsbz_r4_c3.jpg" bgcolor="#FFFFFF">
                                                <table width="60%" border="0" align="left" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="clickHref(3,1,this)" target="_blank">快速入门</a>
                                                        </td>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(3,2,this)" target="_blank">代购</a>
                                                        </td>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(3,3,this)" target="_blank">合买</a>
                                                        </td>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(3,4,this)" target="_blank">查询</a>
                                                        </td>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(3,5,this)" target="_blank">开奖</a>
                                                        </td>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(3,6,this)" target="_blank">中奖</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="309" valign="top" bgcolor="#FFFFFF">
                                                <table width="307" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="23" background="images/xsbz_r1_c5.jpg">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="25%" style=" border-bottom-style:solid; border-bottom-color:#BCD2E9; border-bottom-width:1px">
                                                                        <img src="images/xsbz_r1_c7.jpg" width="83" height="22" />
                                                                    </td>
                                                                    <td width="75%">
                                                                        <table width="210" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="70" height="23" align="center" valign="middle" background="images/index_r24_c42.jpg"
                                                                                    class="blue12_4_2" id="tdSSL">
                                                                                    <a href="javascript:;" onclick="return clickLottery(2,29,this,9,'SSL','29-0-0');">时时乐</a>
                                                                                </td>
                                                                                <td width="70" align="center" valign="middle" class="blue12_4_2">
                                                                                    <a href="javascript:;" onclick="return clickLottery(2,61,this,10,'SSC','61-0-0');">时时彩</a>
                                                                                </td>
                                                                                <td width="70" align="center" valign="middle" class="blue12_4_2">
                                                                                    <a href="javascript:;" onclick="return clickLottery(2,62,this,11,'SYYDJ','62-0-0');">
                                                                                        十一运夺金</a>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="55" colspan="2" align="center" class="hui12">
                                                            <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td align="left" style="text-indent: 25px; padding-top: 5px; padding-bottom: 5px"
                                                                        id="tdIntro2">
                                                                        时时乐对三位数字进行投注，所选号码与开奖号码对应一致，即可获得相应的中奖奖金。每天发行23期，从10:30～21:30每半小时开奖一次。
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="411" height="73" bgcolor="#FFFFFF" valign="top">
                                                <table width="411" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="23" background="images/xsbz_r1_c5.jpg">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="21%" style=" border-bottom-style:solid; border-bottom-color:#BCD2E9; border-bottom-width:1px">
                                                                        <img src="images/xsbz_r6_c1.jpg" width="85" height="22" />
                                                                    </td>
                                                                    <td>
                                                                        <table width="327" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="70" height="23" class="blue12_4_2" align="center" valign="middle" background="images/index_r24_c42.jpg"
                                                                                    id="tdSFC">
                                                                                    <a href="javascript:;" onclick="return clickLottery(1,1,this,12,'SFC','1-0-0');">胜负彩</a>
                                                                                </td>
                                                                                <td width="70" align="center" valign="middle" class="blue12_4_2">
                                                                                    <a href="javascript:;" onclick="return clickLottery(1,1,this,13,'SFC_9_D','1-0-0');">任选九场</a>
                                                                                </td>
                                                                                <td width="70" align="center" valign="middle" class="blue12_4_2">
                                                                                    <a href="javascript:;" onclick="return clickLottery(1,15,this,14,'LCBQC','15-0-0');">
                                                                                        6场半全场</a>
                                                                                </td>
                                                                                <td width="70" align="center" valign="middle" class="blue12_4_2">
                                                                                    <a href="javascript:;" onclick="return clickLottery(1,2,this,15,'JQC','2-0-0');">四场进球</a>
                                                                                </td>
                                                                                <td width="47" align="left" valign="middle">&nbsp;
                                                                                    
                                                                              </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="55" colspan="2" align="center" class="hui12">
                                                            <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td style="text-indent: 25px; padding-top: 5px; padding-bottom: 5px" class="hui12"
                                                                        align="left" id="tdIntro1">
                                                                        胜负彩每期竞猜14场比赛，竞猜内容为主队在90分钟内的比赛结果，主队获胜则正确的竞猜结果为3；主队打平则竞猜结果为1；主队输则竞猜结果为0。
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td background="images/xsbz_r4_c3.jpg" bgcolor="#FFFFFF">
                                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="clickHref(2,1,this)" target="_blank">快速入门</a>
                                                        </td>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(2,2,this)" target="_blank">代购</a>
                                                        </td>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(2,3,this)" target="_blank">合买</a>
                                                        </td>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(2,4,this)" target="_blank">查询</a>
                                                        </td>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(2,5,this)" target="_blank">开奖</a>
                                                        </td>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(2,6,this)" target="_blank">中奖</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td height="23" background="images/xsbz_r4_c3.jpg" bgcolor="#FFFFFF">
                                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(1,1,this)" target="_blank">快速入门</a>
                                                        </td>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(1,2,this)" target="_blank">代购</a>
                                                        </td>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(1,3,this)" target="_blank">合买</a>
                                                        </td>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(1,4,this)" target="_blank">查询</a>
                                                        </td>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(1,5,this)" target="_blank">开奖</a>
                                                        </td>
                                                        <td height="22" align="center" class="red12_3">
                                                            <a href="javascript:;" onclick="return clickHref(1,6,this)" target="_blank">中奖</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="717" border="0" cellspacing="0" cellpadding="0" style="padding-top: 10px;">
                            <tr>
                                <td>
                                   <a href="Lottery/Buy_3D.aspx" target="_blank" title="福彩3D|中奖|恋上你的床">
                                        <img src="images/banner.gif" width="722" height="80" alt="福彩3D|中奖|恋上你的床" /></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="content" style="border: 1px solid #DDDDDD; margin-top: 10px; padding-left: 12px;
        padding-top: 10px; padding-bottom: 10px; width: 990px;">
        <table>
            <tr>
                <td valign="top" width="60px">
                    <div class="hui12">
                        合作伙伴：</div>
                </td>
                <td>
                    <div class="hui12" id="divFriendLinks" style="padding-left: 10px;" runat="server">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    <input type="hidden" id="hLotteryID" value="5" />
    <input type="hidden" id="hLotteryID1" value="1" />
    <input type="hidden" id="hLotteryID2" value="29" />
    <input type="hidden" id="hLotteryID3" value="5" />
    <input type="hidden" id="hBuy1" value="SFC" />
    <input type="hidden" id="hBuy2" value="SSL" />
    <input type="hidden" id="hBuy3" value="SSQ" />
    <input type="hidden" id="hWin1" value="1-0-0" />
    <input type="hidden" id="hWin2" value="29-0-0" />
    <input type="hidden" id="hWin3" value="5-0-0" />
    <%-- <script src="JavaScript/floatAD.js" type="text/javascript"></script>
    <script src="JavaScript/funcs.js" type="text/javascript"></script>--%>
    <%--
    <div id="BigAd" style="display: none; z-index: 1; visibility: visible; width: 600px;
        position: absolute; height: 300px">
        <div id="floatbig">
        </div>
        <div style="left: 530px; width: 59px; position: relative; top: -238px; height: 28px;"
            onclick="hiddenFloatAd();return false;">
            <a href="javascript://" target="_self">
                <img src="images/ad_index_close.jpg" alt="点击关闭" style="border: 0px;" />
            </a>
        </div>
    </div>
    <div id="FloatCtrl" style="display: none; z-index: 1; visibility: visible; width: 98px;
        position: absolute; background-color: #000">
        <div id="floatsmall">
        </div>
    </div>
--%>
    <%--<script src="JavaScript/ptype.js" type="text/javascript"></script>

    <script src="JavaScript/eff.js" type="text/javascript"></script>

    <script type="text/javascript">
        if (location.toString().indexOf("www.caiyou.net") != -1) {
            var imgheight_close;
            document.ns = navigator.appName == "Microsoft Internet Explorer";
            var bdy = (document.documentElement && document.documentElement.clientWidth) ? document.documentElement : document.body;
            window.screen.width > 800 ? imgheight_close = 110 : imgheight_close = 110;
            BigAdStartTimer = null;
            BigAdEndTimer = null;
            floatAdMove();
            FloatCtrlMove();
            window.onload = showFloatAd;
        }
    
    </script>

    <script src="JavaScript/floatbig.js" type="text/javascript"></script>--%>
    </form>
    
    <map name="Map" id="Map">
        <area shape="rect" coords="67, 204, 173, 233" href="Lottery/Buy_SSQ.aspx" title="祝君中大奖!" />
        <area shape="rect" coords="105, 142, 233, 184" href="Home/Room/OnlinePay/Default.aspx" title="冲啊...买彩票中大奖!" />
		<area shape="rect" coords="84,3,172,28" href="#Login" title="快速登录"/>
		<area shape="rect" coords="82,48,173,75" href="UserReg.aspx"  title="快速免费注册"/>
        <area shape="rect" coords="131, 306, 230, 337" href="Home/Room/Distill.aspx" title="我的钱,我做主" />
        <area shape="rect" coords="18, 306, 114, 337" href="Lottery/Buy_SSQ.aspx" title="继续购买中大奖!" />
        <area shape="rect" coords="63, 256, 175, 286" href="Home/Room/AccountDetail.aspx" title="中奖查询!" />
</map>
    <!--#includefile="Html/TrafficStatistics/1.htm"-->
</body>
</html>
<!--弹出广告-->
<%--<script type="text/javascript">
    var seconds = 1;
    function DisplayTimer() {
        seconds = seconds - 1;
        if (seconds == 0) {
            showAds();
        }
    }
   
    function document.onreadystatechange() {
        if (document.readyState == "complete") {
             <%=script %>
        }
    }
</script>--%>
<%= script%>

<script language="javascript">
    function clickChaseLottery(selectTD) {

        if (selectTD == "tdSSQChase") {
            document.getElementById("hLotteryID").value = "5";
            document.getElementById(selectTD).background = "images/tc_r1_c3.jpg";
            document.getElementById("tdFC3DChase").background = "";
            document.getElementById("spanIsuse1").innerHTML = "14";
            document.getElementById("spanIsuse2").innerHTML = "42";
            document.getElementById("spanIsuse3").innerHTML = "84";
            document.getElementById("spanIsuse4").innerHTML = "168";
            document.getElementById("spanMoney1").innerHTML = "28";
            document.getElementById("spanMoney2").innerHTML = "84";
            document.getElementById("spanMoney3").innerHTML = "168";
            document.getElementById("spanMoney4").innerHTML = "336";
        } else {
            document.getElementById("hLotteryID").value = "6";
            document.getElementById(selectTD).background = "images/tc_r1_c3.jpg";
            document.getElementById("tdSSQChase").background = "";
            document.getElementById("spanIsuse1").innerHTML = "30";
            document.getElementById("spanIsuse2").innerHTML = "90";
            document.getElementById("spanIsuse3").innerHTML = "180";
            document.getElementById("spanIsuse4").innerHTML = "360";
            document.getElementById("spanMoney1").innerHTML = "60";
            document.getElementById("spanMoney2").innerHTML = "180";
            document.getElementById("spanMoney3").innerHTML = "360";
            document.getElementById("spanMoney4").innerHTML = "720";
        }
        return false;
    }

    function CustomChase(type, obj) {
        obj.href = "LotteryPackage.aspx?LotteryID=" + document.getElementById('hLotteryID').value + "&Type=" + type + "";
    }

    var lastID = null;
    var lastID1 = document.getElementById("tdSFC");
    var lastID2 = document.getElementById("tdSSL");
    var lastID3 = document.getElementById("tdSSQ");
    var intro = new Array("双色球投注分为红球和蓝球，红球号码范围为01～33，蓝球号码范围为01～16，每期开出6个红球和1个蓝球作为中奖号码。根据所选号码与开奖号码命中个数确定中奖奖级与中奖金额。", "对三位数字进行投注，分直选奖、组三奖、组六奖三个等级，所选号码与开奖号码对应一致，即可获得相应的中奖奖金。", "七乐彩的投注方式为从01～30中选择7个或7个以上的数字作为投注号码，每期开出的7个基本号码和1个特点号码作为中奖号码，根据所选号码与开奖号码命中个数确定中奖奖级与中奖金额。", "东方6+1的投注方式是选择一个6位数字加上一个生肖号码进行投注，根据所选号码与开奖号码命中位数和生肖符号确定中奖奖级与中奖金额。", "15选5的投注方式为从01～15中选择5个或5个以上数字作为投注号码，每期开出的5个数字中奖号码，根据所选号码与开奖号码命中个数确定中奖奖级与中奖金额。", "超级大乐透投注分为前区和后区，前区号码范围为01～35，蓝球号码范围为01～12，每期前区开出5个号码和后区开出2个号码作为中奖号码。根据所选号码与开奖号码命中个数确定中奖奖级与中奖金额。", "对三位数字进行投注，分直选奖、组三奖、组六奖三个等级，所选号码与开奖号码对应一致，即可获得相应的中奖奖金。", "对五位数字进行投注，分单式和复式两种投注方式，只设一个奖级，所选号码与开奖号码对应一致，即可获得中奖奖金10万元。", "对七位数字进行投注，分单式和复式两种投注方式，所选号码与开奖号码对应一致，即可获得相应的中奖奖金。", "时时乐对三位数字进行投注，所选号码与开奖号码对应一致，即可获得相应的中奖奖金。每天发行23期，从10:30～21:30每半小时开奖一次。", "对五位数字进行投注，所选号码与开奖号码对应一致，即可获得相应的中奖奖金。时时彩每天发行84期，9:00～23:00每10分钟开奖一次。", "十一运夺金开奖范围为11个数字，由01～11组成，每期将从中随机开出5个号码作为开奖结果，根据所选号码与开奖号码命中个数和玩法确定中奖奖级与中奖金额。十一运夺金每天发行65期，9:05～21:53每12分钟开奖一次。", "胜负彩每期竞猜14场比赛，竞猜内容为主队在90分钟内的比赛结果，主队获胜则正确的竞猜结果为3；主队打平则竞猜结果为1；主队输则竞猜结果为0。", "从胜负彩每期竞猜的14场比赛中任选9场进行投注，竞猜内容为主队在90分钟内比赛的结果，主队胜则正确竞猜结果为3；主队打平则竞猜结果为1；主队输则竞猜结果为0。", "六场半全场的投注场次为6场，由购买者对6场比赛中每场比赛上半场45分钟(含伤情补时)和全场90分钟(含伤情补时)的胜平负结果(3、1、0)进行投注。", "四场进球游戏的投注场次为4场比赛的比分，由购买者对4场比赛8支球队在全场90分钟(含伤情补时)的进球数量(0、1、2、3+)进行投注；投注内容为0、1、2、3+； 其中进球数为3个或3个以上都计为3+ 。", "22选5的投注方式为从01～22中选择5个或5个以上数字作为投注号码，每期开出的5个数字为中奖号码，根据所选号码与开奖号码命中个数确定中奖奖级与中奖金额。", "31选7的投注方式为从01～31中选择7个或7个以上的数字作为投注号码，每期开出的7个基本号码和1个特点号码作为中奖号码，根据所选号码与开奖号码命中个数确定中奖奖级与中奖金额。");
    function clickLottery(type, lotteryID, obj, index, buy, win) {
        if (type == 1) {
            lastID = lastID1;
        } else if (type == 2) {
            lastID = lastID2;
        } else {
            lastID = lastID3;
        }
        if (lastID != null) {
            lastID.background = "";
        }

        obj.parentNode.background = "images/index_r24_c42.jpg";

        if (type == 1) {
            lastID1 = obj.parentNode;
        } else if (type == 2) {
            lastID2 = obj.parentNode;
        } else {
            lastID3 = obj.parentNode;
        }

        document.getElementById("hLotteryID" + type.toString()).value = lotteryID;
        document.getElementById("hBuy" + type.toString()).value = buy;
        document.getElementById("hWin" + type.toString()).value = win;
        document.getElementById("tdIntro" + type.toString()).innerHTML = intro[index];
    }

    function clickHref(type, href, obj) {
        var lotteryID1 = document.getElementById("hLotteryID1").value;
        var lotteryID2 = document.getElementById("hLotteryID2").value;
        var lotteryID3 = document.getElementById("hLotteryID3").value;
        switch (href) {
            case 1:
                obj.href = "Help/play_" + document.getElementById("hLotteryID" + type.toString()).value + ".aspx";
                break;
            case 2:
                obj.href = "Lottery/Buy_" + document.getElementById("hBuy" + type.toString()).value + ".aspx";
                break;
            case 3:
                obj.href = "Lottery/Buy_" + document.getElementById("hBuy" + type.toString()).value + ".aspx?CoBuy=1";
                break;
            case 4:
                obj.href = "Home/Room/Invest.aspx?Type=1";
                break;
            case 5:
                obj.href = "WinQuery/" + document.getElementById("hWin" + type.toString()).value + ".aspx";
                break;
            case 6:
                obj.href = "Home/Room/Invest.aspx";
                break;
        }
    }

    function document.onkeydown() {
        if (event.keyCode == 13)//回车输入登录
        {
            event.returnValue = false;
            document.getElementById("<%=btnLogin2.ClientID%>").click();
        }
    }
   
</script>

