<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Web/ShowAffiches.aspx.cs" inherits="Home_Web_ShowAffiches" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=_Site.Name %>－双色球开奖/双色球走势图查询-手机买彩票，就上<%=_Site.Name %></title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。" />
    <meta name="keywords" content="双色球开奖，双色球走势图，3d走势图，福彩3d，时时彩" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <link href="Style/div.css" rel="stylesheet" type="text/css" />
    <link href="../Room/Style/css.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../../favicon.ico"/>
</head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <div id="box">
        
        <div>
            <table width="980" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <a href="../../Lottery/Buy_SSQ.aspx">
                            <img src="images/ad_980_2.jpg" width="980" height="70" style="vertical-align: top;
                                border: 0px;" /></a>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
            <div class="content">
                <div class="content1_l">
                        <table width="230" border="0" cellpadding="0" cellspacing="1" bgcolor="#9BBFCA">
                            <tr>
                                <td height="26" background="images/bg_title_blue_26.jpg" bgcolor="#FFFFFF">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="27" align="center" class="blue">
                                                <img src="images/icon_red_line.gif" width="3" height="12" />
                                            </td>
                                            <td width="251" class="td14" style="padding-top: 2px;">
                                                <strong>推荐分析</strong>
                                            </td>
                                            <td width="50" class="blue12" style="padding-top: 2px;">
                                                <%--<a id="RecommendAnalysis" runat="server" target="_blank">更多&gt;&gt;</a>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="bg_x" style="padding: 8px 0px 8px 0px;">
                                    <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <asp:Repeater ID="rptRecommendAnalysis" runat="server" OnItemDataBound="rptRecommendAnalysis_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td width="4%" height="25" class="red14">
                                                        ·
                                                    </td>
                                                    <td width="96%" class="blue">
                                                        <asp:HyperLink ID="hlAnalysisTitle" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table width="230" border="0" cellpadding="0" cellspacing="1" bgcolor="#9BBFCA">
                            <tr>
                                <td height="26" background="images/bg_title_blue_26.jpg" bgcolor="#FFFFFF">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="27" align="center" class="blue">
                                                <img src="images/icon_red_line.gif" width="3" height="12" />
                                            </td>
                                            <td width="251" class="td14" style="padding-top: 2px;">
                                                <strong>购彩技巧</strong>
                                            </td>
                                            <td width="50" class="blue12" style="padding-top: 2px;">
                                                <%--<a id="Skills" runat="server" target="_blank">更多&gt;&gt;</a>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="bg_x" style="padding: 8px 0px 8px 0px;">
                                    <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <asp:Repeater ID="rptSkills" runat="server" OnItemDataBound="rptSkills_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td width="4%" height="25" class="red14">
                                                        ·
                                                    </td>
                                                    <td width="96%" class="blue">
                                                        <asp:HyperLink ID="hlSkills" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table width="230" border="0" cellpadding="0" cellspacing="1" bgcolor="#9BBFCA">
                            <tr>
                                <td height="26" background="images/bg_title_blue_26.jpg" bgcolor="#FFFFFF">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="27" align="center" class="blue">
                                                <img src="images/icon_red_line.gif" width="3" height="12" />
                                            </td>
                                            <td width="251" class="td14" style="padding-top: 2px;">
                                                <strong>热点导航</strong>
                                            </td>
                                            <td width="50" class="blue12" style="padding-top: 2px;">
                                                <%--<a id="Skills" runat="server" target="_blank">更多&gt;&gt;</a>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="bg_x" style="padding: 8px 0px 8px 0px;">
                                    <table width="95%" border="0" cellpadding="0" cellspacing="0" style="padding:0px 0px 0px 10px;">
                                        <tr>
                                            <td class="red14">
                                                高频
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="blue12" style="padding:0px 0px 0px 20px;">
                                                <a href="../../Lottery/Buy_SYYDJ.aspx">十一运夺金</a>&nbsp; <a href="../../Lottery/Buy_SSL.aspx">时时乐</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="red14">
                                                福彩
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="blue12" style="padding:0px 0px 0px 20px;">
                                                <a href="../../Lottery/Buy_SSQ.aspx">双色球</a>&nbsp; 
                                                <a href="../../Lottery/Buy_15X5.aspx">15选5</a> &nbsp; 
                                                <a href="../../Lottery/Buy_DF6J1.aspx">东方6+1</a>&nbsp;
                                                <a href="../../Lottery/Buy_3D.aspx">福彩3D</a>
                                                <a href="../../Lottery/Buy_QLC.aspx">七乐彩</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="red14">
                                                体彩
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="blue12" style="padding:0px 0px 0px 20px;">
                                                <a href="../../Lottery/Buy_CJDLT.aspx">超级大乐透</a>&nbsp; 
                                                <a href="../../Lottery/Buy_QXC.aspx">七星彩</a>&nbsp; 
                                                <a href="../../Lottery/Buy_22X5.aspx">22选5</a>&nbsp; 
                                                <a href="../../Lottery/Buy_31X7.aspx">31选7</a>&nbsp; 
                                                <a href="../../Lottery/Buy_PL3.aspx">排列3</a>&nbsp; 
                                                <a href="../../Lottery/Buy_PL5.aspx">排列5</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="red14">
                                                足彩
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="blue12" style="padding:0px 0px 0px 20px;">
                                                <a href="../../Lottery/Buy_SFC.aspx">胜负彩</a>&nbsp;
                                                <a href="../../Lottery/Buy_LCBQC.aspx">六场半</a>&nbsp;
                                                <a href="../../Lottery/Buy_SFC_9_D.aspx">任选九</a>&nbsp;
                                                <a href="../../Lottery/Buy_JQC.aspx">四场进球</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                </div>
                <div class="content1_740">
                    <table width="740" border="0" cellpadding="0" cellspacing="1" bgcolor="#9BBFCA">
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" background="images/bg_title_27.jpg">
                                    <tr>
                                        <td width="28" height="26" align="center" class="blue">
                                            <img src="images/icon_red_line.gif" width="3" height="12" />
                                        </td>
                                        <td width="712" class="hui" style="padding-top: 2px;">
                                            当前位置：<a href="../../Default.aspx">首页</a> &gt; 站点公告 &gt; 正文
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#F6F9FE" style="padding: 15px 20px 15px 20px;">
                                <!--startprint-->
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="36" align="center" class="red20">
                                            <asp:Label ID="lbTitle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="1" bgcolor="#E1E1E1">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="right" class="hui" style="padding-right: 20px;">
                                            日期：<asp:Label ID="lbDateTime" runat="server"></asp:Label>
                                            [<a onclick="window.close();" href="#">关闭本页</a>] [<a onclick="doPrint()" href="javascript:;">打印</a>]
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="1" bgcolor="#E1E1E1">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="black12">
                                            <asp:Label ID="lbContent" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
      
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>

<script type="text/javascript" language="javascript">
    function doPrint() {
        bdhtml = window.document.body.innerHTML;
        sprnstr = "<!--startprint-->";
        eprnstr = "<!--endprint-->";
        prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
        prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
        window.document.body.innerHTML = prnhtml;
        window.print();
        window.document.body.innerHTML = bdhtml;
        window.document.location.reload();
    }

</script>

