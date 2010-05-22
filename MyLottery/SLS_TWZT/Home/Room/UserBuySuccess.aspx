<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserBuySuccess.aspx.cs" Inherits="Home_Room_UserBuySuccess" %>

<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>祝贺购彩成功！-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
     
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-size: 12px;
            color: #226699;
            font-family: "tahoma";
            line-height: 20px;
            height: 28px;
        }
        A
        {
            text-decoration: none;
        }
        A:hover
        {
            color: #CC0000;
            text-decoration: underline;
        }
    </style>
<link rel="shortcut icon" href="../../favicon.ico" /></head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc3:Lotteries ID="Lotteries1" runat="server" />
    <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 3px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
            <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 5px;">
                <tr>
                    <td align="left" bgcolor="#FFFFDD" class="black12" style="padding: 5px 10px 5px 10px;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="9%">
                                    <img src="images/icon_cg222.jpg" width="73" height="52" />
                                </td>
                                <td width="91%" class="red14_2">
                                    <asp:Label runat="server" ID="lbName" />，祝贺您<asp:Label runat="server" ID="lbType"
                                        Text="投注"></asp:Label>成功！ <span id="time" style="color: Red; padding-left: 20px">5</span><font
                                            color="black"> 秒后自动跳转！</font>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="36" bgcolor="#F5F5F5" class="black12" style="padding: 5px 10px 5px 10px;">
                        <div style="padding-bottom: 10px">
                            本次获得积分：<asp:Label runat="server" ID="lbScore" CssClass="red12" />分</div>
                        您好！
                        <asp:Label runat="server" ID="lbName1" CssClass="red12" />
                        您的账户余额：<asp:Label runat="server" ID="lbBalance" CssClass="red12" />
                        元&nbsp;&nbsp;&nbsp; <a href="" runat="server" id="Buy">
                            <asp:Label runat="server" ID="lbType1" CssClass="blue12" Text="[继续投注]" /></a><a href=""
                                runat="server" id="Look" style="padding-left: 10px" target="_blank"><span class="blue12">[查看方案]</span></a>
                    </td>
                </tr>
            </table>
            <table width="805" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="25" bgcolor="#FFFFFF" class="red14" style="padding-left: 20px;">
                        热门彩种&gt;&gt;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="842" border="0" align="left" cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="top">
                                    <table width="100" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="center">
                                                <a href="../../Lottery/Buy_SSQ.aspx"><img src="images/cz_logo_ssq.jpg" width="105" height="108" border="0"/></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="center" bgcolor="#EAEAEA" class="hui14">
                                                <a href="../../Lottery/Buy_SSQ.aspx">双色球</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="center" bgcolor="#F5F5F5" class="blue12">
                                               <a href="../../Lottery/Buy_SSQ.aspx">2元赢取1000万</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" valign="top" class="red12">
                                                <a href="../../Lottery/Buy_SSQ.aspx">[购买彩票]</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="center" valign="top">
                                    <table width="100" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="center">
                                                <a href="../../Lottery/Buy_SSL.aspx"><img src="images/cz_logo_ssl.jpg" width="105" height="108" border="0"/></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="center" bgcolor="#EAEAEA" class="hui14">
                                                <a href="../../Lottery/Buy_SSL.aspx">时时乐</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="center" bgcolor="#F5F5F5" class="blue12">
                                                <a href="../../Lottery/Buy_SSL.aspx">30分钟开奖</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" valign="top" class="red12">
                                                <a href="../../Lottery/Buy_SSL.aspx">[购买彩票]</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="center" valign="top">
                                    <table width="100" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="center">
                                                <a href="../../Lottery/Buy_SSC.aspx"><img src="images/cz_logo_ssc.jpg" width="105" height="108" border="0"/></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="center" bgcolor="#EAEAEA" class="hui14">
                                                <a href="../../Lottery/Buy_SSC.aspx">时时彩</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="center" bgcolor="#F5F5F5" class="blue12">
                                                <a href="../../Lottery/Buy_SSC.aspx">十分钟开一次</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" valign="top" class="red12">
                                                <a href="../../Lottery/Buy_SSC.aspx">[购买彩票]</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="center" valign="top">
                                    <table width="100" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="center">
                                                <span class="blue">
                                                    <a href="../../Lottery/Buy_SYYDJ.aspx"><img src="images/cz_logo_11yun.jpg" width="105" height="108" border/></a></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="center" bgcolor="#EAEAEA" class="hui14">
                                                <a href="../../Lottery/Buy_SYYDJ.aspx">十一运夺金</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="center" bgcolor="#F5F5F5" class="blue12">
                                                <a href="../../Lottery/Buy_SYYDJ.aspx">2元赢取10万</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" valign="top" class="red12">
                                                <a href="../../Lottery/Buy_SYYDJ.aspx">[购买彩票]</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="center" valign="top">
                                    <table width="100" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="center">
                                                <a href="../../Lottery/Buy_CJDLT.aspx"><img src="images/cz_logo_dlt.jpg" width="105" height="108" border="0"/></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="center" bgcolor="#EAEAEA" class="hui14">
                                                <a href="../../Lottery/Buy_CJDLT.aspx">大乐透</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="center" bgcolor="#F5F5F5" class="blue12">
                                                <a href="../../Lottery/Buy_CJDLT.aspx">2元赢取800万</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" valign="top" class="red12">
                                                <a href="../../Lottery/Buy_CJDLT.aspx">[购买彩票]</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="center" valign="top">
                                    <table width="100" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="center">
                                                <a href="../../Lottery/Buy_SFC.aspx"><img src="images/cz_logo_zc.jpg" width="105" height="108" border="0"/></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="center" bgcolor="#EAEAEA" class="hui14">
                                                <a href="../../Lottery/Buy_SFC.aspx">足彩胜负</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="center" bgcolor="#F5F5F5" class="blue12">
                                                <a href="../../Lottery/Buy_SFC.aspx">2元赢取500万</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" valign="top" class="red12">
                                                <a href="../../Lottery/Buy_SFC.aspx">[购买彩票]</a>
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
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>

<script language="javascript" type="text/javascript">
    function DisplayTimer() {
        var seconds = parseInt(time.innerHTML)>0 ? parseInt(time.innerHTML)-1:0;
        time.innerHTML = seconds.toString();
            if (seconds == 0) {
            window.top.location.href ="<%=URL %>";
        }
    }
    <%=script %>
</script>

