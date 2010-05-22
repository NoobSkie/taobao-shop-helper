<%@ control language="C#" autoeventwireup="true" CodeFile="ZCDCHead.ascx.cs" inherits="Home_Room_UserControls_ZCDCHead" %>
<link href="../style/css.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .hot_QXC
    {
        position: absolute;
        left: 37px;
        top: -5px;
    }
     .hot_ZC
    {
        position: absolute;
        left: 50px;
        top: -5px;
    }
    .hot_SYYDJ
    {
        position: absolute;
        left: 60px;
        top: -3px;
    }
     .hot_SSC
    {
        position: absolute;
        left: 38px;
        top: -5px;
    }
</style>
<table width="1002" border="0" cellspacing="0" cellpadding="0" align="center">
    <tr>
        <td>
            <table width="1002" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="15" height="27">
                        &nbsp;
                    </td>
                    <td width="80" align="center" bgcolor="#6699CC" class="bai14">
                        <a href="<%=ResolveUrl("~/Default.aspx") %>" target="_self">��Ʊ��ҳ</a>
                    </td>
                    <td width="2" id="tdTreadChart1">
                    </td>
                    <td id="tdTreadChart" width="80" align="center" background="<%=ResolveUrl("~/Home/Room/images/menu_bg_80_1.jpg") %>"
                        class="blue12">
                        <a href="<%= ResolveUrl("~/TrendCharts/Index.htm") %>" target="_self">ͼ������</a>
                    </td>
                    <td width="2" id="tdHelp1">
                    </td>
                    <td id="tdHelp" width="80" align="center" background="<%=ResolveUrl("~/Home/Room/images/menu_bg_80_1.jpg") %>"
                        class="blue12">
                        <a href="<%= ResolveUrl("~/Help/Help_Default.aspx") %>">��������</a>
                    </td>
                    <td width="2" id="tdIsuseOpenInfo1">
                    </td>
                    <td id="tdIsuseOpenInfo" width="80" align="center" background="<%=ResolveUrl("~/Home/Room/images/menu_bg_80_1.jpg") %>"
                        class="blue12">
                        <a href="<%=ResolveUrl("~/WinQuery/Default.aspx")%>" target="_blank">�н���ѯ</a>
                    </td>
                    
                    <td width="2">
                    </td>
                    <td id="tdNewsPaper" width="80" align="center" background="<%=ResolveUrl("~/Home/Room/images/menu_bg_80_1.jpg") %>"
                        class="blue12">
                        <a href="<%=  ResolveUrl("~/NewsPapers") %>" target="_blank">���ѱ�</a>
                    </td>
                    <td width="2" id="tdJoinAllBuy1">
                    </td>
                    <td id="tdJoinAllBuy" width="80" align="center" background="<%=ResolveUrl("~/Home/Room/images/menu_bg_80_1.jpg") %>"
                        class="blue12">
                        <a href="<%=  ResolveUrl("~/JoinAllBuy.aspx") %>" target="_self">�������</a>
                    </td>
                    <td width="2">
                    </td>
                     <td id="td1" width="80" align="center" background="<%=ResolveUrl("~/Home/Room/images/menu_bg_80_1.jpg") %>"
                        class="blue12">
                        <a href="<%=  ResolveUrl("../ZQDCData/Default.aspx") %>" target="_blank">������Ѷ</a>
                    </td>
                    <td width="2">
                    </td>
                    <td align="right" class="blue12" style="padding-right: 10px;">
                        �����ѯ�绰��<span class="red14"><%= _Site.ServiceTelephone %></span>
                    </td>
                    <td width="77">
                        <a href="javascript:;">
                            <img src="<%=ResolveUrl("~/Home/Room/images/head_zixun.jpg") %>" width="77" height="20"
                                border="0" /></a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td height="2" bgcolor="#6699CC">
        </td>
    </tr>
    <tr>
        <td>
            <table border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
                <tr>
                    <td background="<%=ResolveUrl("~/Home/Room/images/cz_blue_bg.jpg") %>" bgcolor="#FFFFFF"
                        style="padding: 8px 20px 8px 20px;">
                        <table border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="200" height="42">
                                    <table width="192" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="45" rowspan="2">
                                                <img src="<%=ResolveUrl("~/Home/Room/images/cz_gp_logo.gif") %>" width="32" height="36" />
                                            </td>
                                            <td width="60" height="21" class="blue12">
                                                <a href="<%=ResolveUrl("../Buy_SSL.aspx") %>">ʱʱ��</a>
                                            </td>
                                            <td class="blue12" style="position: relative">
                                                <a href="<%=ResolveUrl("../Buy_SYYDJ.aspx") %>">ʮһ�˶��</a><div class="hot_SYYDJ">
                                                    <img src="<%=ResolveUrl("~/Home/Room/images/1672_hot-dserewr23.gif") %>" width="22"
                                                        height="10" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" width="60" height="21" class="blue12" style="position: relative">
                                                <a href="<%=ResolveUrl("../Buy_SSC.aspx") %>">ʱʱ��</a>
                                                <div class="hot_SSC">
                                                    <img src="<%=ResolveUrl("~/Home/Room/images/new2.gif") %>" width="28"
                                                        height="11" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3" background="<%=ResolveUrl("~/Home/Room/images/cz_line.gif") %>">
                                </td>
                                <td width="210" style="padding-left: 10px;">
                                    <table width="210" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="45" rowspan="2">
                                                <img src="<%=ResolveUrl("~/Home/Room/images/cz_fc_logo.gif") %>" width="32" height="32" />
                                            </td>
                                            <td width="50" height="21" class="blue12">
                                                <a href="<%=ResolveUrl("../Buy.aspx?LotteryID=5") %>">˫ɫ��</a>
                                            </td>
                                            <td width="50" class="blue12">
                                                <a href="<%=ResolveUrl("../Buy.aspx?LotteryID=59") %>">15ѡ5</a>
                                            </td>
                                            <td class="blue12">
                                                <a href="<%=ResolveUrl("../Buy.aspx?LotteryID=58") %>">����6+1</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="21" class="blue12">
                                                <a href="<%=ResolveUrl("../Buy.aspx?LotteryID=6") %>">����3D</a>
                                            </td>
                                            <td class="blue12">
                                                <a href="Buy.aspx?LotteryID=13">���ֲ�</a>
                                            </td>
                                            <%--<td class="blue12">
                                                        <a href="Play.aspx?LotteryID=60">�����ѡ4</a>
                                                    </td>--%>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3" background="<%=ResolveUrl("~/Home/Room/images/cz_line.gif") %>">
                                    &nbsp;
                                </td>
                                <td width="240" style="padding-left: 10px;">
                                    <table width="240" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="45" rowspan="2">
                                                <img src="<%=ResolveUrl("~/Home/Room/images/cz_tc_logo.gif") %>" width="35" height="33" />
                                            </td>
                                            <td width="65" height="21" class="blue12">
                                                <a href="<%=ResolveUrl("../Buy.aspx?LotteryID=39") %>">��������͸</a>
                                            </td>
                                            <td width="65" class="blue12" style="position: relative">
                                                <a href="<%=ResolveUrl("../Buy.aspx?LotteryID=3") %>">���ǲ�</a>
                                                <div class="hot_QXC">
                                                    <img src="<%=ResolveUrl("~/Home/Room/images/jiajiang.gif") %>" /></div>
                                            </td>
                                            <td width="50" class="blue12">
                                                <a href="<%=ResolveUrl("../Buy.aspx?LotteryID=9") %>">22ѡ5</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <%--<td class="blue12">
                                                        <a href="Buy.aspx?LotteryID=14">29ѡ7</a>
                                                    </td>--%>
                                            <td height="21" class="blue12">
                                                <a href="<%=ResolveUrl("../Buy.aspx?LotteryID=63") %>">����3</a>
                                            </td>
                                            <td class="blue12">
                                                <a href="<%=ResolveUrl("../Buy.aspx?LotteryID=64") %>">����5</a>
                                            </td>
                                            <td class="blue12">
                                                <a href="<%=ResolveUrl("../Buy.aspx?LotteryID=65") %>">31ѡ7</a>
                                            </td>
                                            <%--<td class="blue12">
                                                        <a href="Buy.aspx?LotteryID=19">����</a>
                                                    </td>--%>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3" background="<%=ResolveUrl("~/Home/Room/images/cz_line.gif") %>">
                                    &nbsp;
                                </td>
                                <td width="277" style="padding-left: 10px;" align="right">
                                    <table width="270" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="45" rowspan="2">
                                                <img src="<%=ResolveUrl("~/Home/Room/images/cz_zc_logo.gif") %>" width="34" height="34" />
                                            </td>
                                            <td width="75" height="21" class="blue12" align="center" style="position: relative;">
                                                <a href="<%=ResolveUrl("../Buy_ZC.aspx?LotteryID=1") %>">ʤ����</a>
                                                <div class="hot_ZC">
                                                    <img src="<%=ResolveUrl("~/Home/Room/images/jiajiang.gif") %>" /></div>
                                            </td>
                                            <td class="blue12" width="65">
                                                <a href="<%=ResolveUrl("../Buy_ZC.aspx?LotteryID=15") %>">������ȫ��</a>
                                            </td>
                                            <td class="blue12" style="padding-right: 10px" width="60">
                                                <a href="<%=ResolveUrl("~/Home/Room/ZQDC/Default.aspx") %>">���򵥳�</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="75" height="21" class="blue12" align="center" style="position: relative;">
                                                <a href="<%=ResolveUrl("../Buy_ZC.aspx?LotteryID=1&Number=9") %>">�ξų�</a>
                                                <div class="hot_ZC">
                                                    <img src="<%=ResolveUrl("~/Home/Room/images/jiajiang.gif") %>" /></div>
                                            </td>
                                            <td class="blue12" width="65">
                                                <a href="<%=ResolveUrl("../Buy_ZC.aspx?LotteryID=2") %>">�ĳ������</a>
                                            </td>
                                            <td></td>
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

<div id="content" style="margin-top:10px;">
    <img src="<%=ResolveUrl("~/Home/Room/ZQDC/Images/test_banner.jpg") %>" width="1002" height="48" />
</div>
