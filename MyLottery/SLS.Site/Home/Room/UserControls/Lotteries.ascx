<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Lotteries.ascx.cs" Inherits="SLS.Site.Home.Room.UserControls.Lotteries" %>
<link href="~/Home/Style/css.css" rel="stylesheet" type="text/css" />
<link href="~/Home/Style/LotteriesStyle.css" rel="stylesheet" type="text/css" />
<table width="1002" border="0" cellspacing="0" cellpadding="0" align="center">
    <tr>
        <td style="background-color: White;">
            <table width="1002" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="35" bgcolor="#408EC7" style="padding-left: 10px;">
                        <table width="95%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="50" align="center" class="bai12">
                                    <a href="<%=  ResolveUrl("~/") %>">首页</a>
                                </td>
                                <td width="1" align="center" class="bai12">
                                    |
                                </td>
                                <td width="66" align="center" class="bai12">
                                    <a href="<%=  ResolveUrl("~/Lottery/Buy_SYYDJ.aspx") %>">购买彩票</a>
                                </td>
                                <td width="1" align="center" class="bai12">
                                    |
                                </td>
                                <td width="66" align="center" class="bai12">
                                    <a href="<%=  ResolveUrl("~/LotteryPackage.aspx") %>" target="_blank">包月套餐</a>
                                </td>
                                <td width="1" align="center" class="bai12">
                                    |
                                </td>
                                <td width="66" align="center" class="bai12">
                                    <a href="<%=ResolveUrl("~/JoinAllBuy.aspx") %>" target="_blank">专家合买</a>
                                </td>
                                <td width="1" align="center" class="bai12">
                                    |
                                </td>
                                <td width="66" align="center" class="bai12">
                                    <a href="<%=  ResolveUrl("~/ForeCast.aspx") %>">专家热号 </a>
                                </td>
                                <td width="1" align="center" class="bai12">
                                    |
                                </td>
                                <td width="66" align="center" class="bai12">
                                    <a href="<%= ResolveUrl("~/TrendCharts") %>" target="_blank">图表走势</a>
                                </td>
                                <td width="1" align="center" class="bai12">
                                    |
                                </td>
                                <td width="66" align="center" class="bai12">
                                    <a href="<%=ResolveUrl("~/WinQuery")%>">全国开奖</a>
                                </td>
                                <td width="1" align="center" class="bai12">
                                    |
                                </td>
                                <td width="66" align="center" class="bai12">
                                    <a href="<%=ResolveUrl("~/WinQuery/5-0-0.aspx")%>" target="_blank">中奖查询</a>
                                </td>
                                <td width="1" align="center" class="bai12">
                                    |
                                </td>
                                <td width="66" align="center" class="bai12">
                                    <a href="<%= ResolveUrl("~/Help/Help_Default.aspx") %>" target="_blank">帮助中心</a>
                                </td>
                                <td width="1" align="center" class="bai12">
                                    |
                                </td>
                                <td width="66" align="center" class="bai12">
                                    <a href="<%= ResolveUrl("~/bbs/index.aspx") %>" target="_blank">专家社区</a>
                                </td>
                                <td align="right" class="hui12_3" style="width: 200px;">
                                    <div id="tdDateTimeNow" style="width: 190px;">
                                    </div>
                                </td>
                            </tr>
                        </table>
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
                                <td width="182" height="42">
                                    <table width="192" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="45" rowspan="2">
                                                <a id="aHref29a" href="Javascript:;" runat="server" disabled="true">
                                                    <img src="<%=ResolveUrl("~/Home/Room/images/cz_gp_logo.gif") %>" width="32" height="36"
                                                        border="0" alt="高频：时时乐，时时彩，十一运……" /></a>
                                            </td>
                                            <td width="60" height="21" class="blue12" style="position: relative">
                                                <a id="aHref29" href="Javascript:;" runat="server" disabled="true">时时乐</a>
                                            </td>
                                            <td class="blue12">
                                                <a id="aHref62" href="Javascript:;" runat="server" disabled="true">十一运夺金</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="60" height="21" class="blue12" style="position: relative;">
                                                <a id="aHref61" href="Javascript:;" runat="server" disabled="true">时时彩</a> <sup>
                                                    <div class="hot_SSQ">
                                                        <img src="<%=ResolveUrl("~/Home/Room/images/1672_hot-dserewr23.gif") %>" /></div>
                                                </sup>
                                            </td>
                                            <td class="blue12">
                                                <a id="aHref70" href="Javascript:;" runat="server" disabled="true">11选5</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3" background="<%=ResolveUrl("~/Home/Room/images/cz_line.gif") %>">
                                </td>
                                <td width="220" style="padding-left: 10px;">
                                    <table width="220" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="45" rowspan="2">
                                                <a id="aHref5a" href="Javascript:;" runat="server" disabled="true">
                                                    <img src="<%=ResolveUrl("~/Home/Room/images/cz_fc_logo.gif") %>" width="32" height="32"
                                                        alt="福彩：双色球，福彩3D，15选5……" /></a>
                                            </td>
                                            <td width="60" height="21" class="blue12" style="position: relative;">
                                                <a id="aHref5" href="Javascript:;" runat="server" disabled="true">双色球</a>
                                                <div class="hot_SSQ">
                                                    <img src="<%=ResolveUrl("~/Home/Room/images/jiajiang.gif") %>" /></div>
                                            </td>
                                            <td width="60" class="blue12">
                                                <a id="aHref59" href="Javascript:;" runat="server" disabled="true">15选5</a>
                                            </td>
                                            <td class="blue12">
                                                <a id="aHref58" href="Javascript:;" runat="server" disabled="true">东方6+1</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="21" class="blue12">
                                                <a id="aHref6" href="Javascript:;" runat="server" disabled="true">福彩3D</a>
                                            </td>
                                            <td class="blue12">
                                                <a id="aHref13" href="Javascript:;" runat="server" disabled="true">七乐彩</a>
                                            </td>
                                            <%--<td class="blue12">
                                                        <a href="Play.aspx?LotteryID=60">天天彩选4</a>
                                                    </td>--%>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3" background="<%=ResolveUrl("~/Home/Room/images/cz_line.gif") %>">
                                </td>
                                <td width="340" style="padding-left: 10px;">
                                    <table width="320" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="45" rowspan="2">
                                                <a id="aHref39a" href="Javascript:;" runat="server" disabled="true">
                                                    <img src="<%=ResolveUrl("~/Home/Room/images/cz_tc_logo.gif") %>" width="35" height="33"
                                                        alt="体彩：超级大乐透，七星彩，22选5……" /></a>
                                            </td>
                                            <td width="80" height="21" class="blue12" style="position: relative;">
                                                <a id="aHref39" href="Javascript:;" runat="server" disabled="true">超级大乐透</a>
                                                <div class="hot_CJDLT">
                                                    <img src="<%=ResolveUrl("~/Home/Room/images/jiajiang.gif") %>" /></div>
                                            </td>
                                            <td width="50" class="blue12">
                                                <a id="aHref3" href="Javascript:;" runat="server" disabled="true">七星彩</a>
                                            </td>
                                            <td width="50" class="blue12">
                                                <a id="aHref9" href="Javascript:;" runat="server" disabled="true">22选5</a>
                                            </td>
                                            <td width="80" class="blue12">
                                                <a id="aHref41" href="Javascript:;" runat="server" disabled="true">浙江体彩6+1</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <%--<td class="blue12">
                                                        <a href="Buy.aspx?LotteryID=14">29选7</a>
                                                    </td>--%>
                                            <td height="21" class="blue12">
                                                <a id="aHref63" href="Javascript:;" runat="server" disabled="true">排列3</a>
                                            </td>
                                            <td class="blue12">
                                                <a id="aHref64" href="Javascript:;" runat="server" disabled="true">排列5</a>
                                            </td>
                                            <td class="blue12">
                                                <a id="aHref65" href="Javascript:;" runat="server" disabled="true">31选7</a>
                                            </td>
                                            <td width="50" class="blue12">
                                                &nbsp;
                                            </td>
                                            <%--<td class="blue12">
                                                        <a href="Buy.aspx?LotteryID=19">篮彩</a>
                                                    </td>--%>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3" background="<%=ResolveUrl("~/Home/Room/images/cz_line.gif") %>">
                                </td>
                                <td style="padding-left: 10px;" align="right">
                                    <table width="178" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="45" rowspan="2">
                                                <a id="aHref1a" href="Javascript:;" runat="server" disabled="true">
                                                    <img src="<%=ResolveUrl("~/Home/Room/images/cz_zc_logo.gif") %>" width="34" height="34"
                                                        alt="体彩：胜负彩，六场半全场，四场进球彩……" /></a>
                                            </td>
                                            <td width="50" height="21" class="blue12" align="right">
                                                <a id="aHref1" href="Javascript:;" runat="server" disabled="true">胜负彩</a>
                                            </td>
                                            <td class="blue12" style="padding-right: 10px">
                                                <a id="aHref15" href="Javascript:;" runat="server" disabled="true">六场半全场</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="21" class="blue12" style="padding-left: 10px;">
                                                <a id="aHref1_9" href="Javascript:;" runat="server" disabled="true">任九场</a>
                                            </td>
                                            <td class="blue12" style="padding-right: 10px">
                                                <a id="aHref2" href="Javascript:;" runat="server" disabled="true">四场进球彩</a>
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
    <tr id="trNoticeValid" runat="server" visible="false">
        <td align="center" style="border-left: 1px solid #BCD2E9; border-right: 1px solid #BCD2E9;
            border-bottom: 1px solid #BCD2E9;" class="blue12">
            <span class="red12_2">亲爱的<asp:Label ID="lblUserNameLottery" runat="server"></asp:Label>，您好！请您尽快完成<a
                href="<%=ResolveUrl("~/Home/Room/UserMobileBind.aspx") %>">手机安全验证</a>或<a href="<%=ResolveUrl("~/Home/Room/UserEmailBind.aspx") %>">邮箱激活</a>的操作。未通过验证的会员于2009年12月18日后将无法正常投注！</span><a
                    href="<%=ResolveUrl("~/Home/Room/UserMobileBind.aspx") %>">【手机验证】</a>&nbsp;&nbsp;<a
                        href="<%=ResolveUrl("~/Home/Room/UserEmailBind.aspx") %>">【邮箱激活】</a>
        </td>
    </tr>
    <tr id="trNotice">
        <td style="width: 1002px;">
            <iframe id="iframeTotalWinNotice" name="iframeTotalWinNotice" width="100%" height="48px"
                frameborder="0" scrolling="no" src="<%=ResolveUrl("~/Home/Room/WinNotice.aspx") %>">
            </iframe>
        </td>
        <%--<td>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 214px; vertical-align:top" >
                        <table cellpadding="0" cellspacing="0">
                            <tr style="background-color: #F7F7F7; height:33px">
                                <td width="20px">
                                </td>
                                <td>
                                    <div style="width: 100%; margin-top: 4px;">
                                        <asp:Label ID="lbCurDate" runat="server" CssClass="hui12"></asp:Label>&nbsp;&nbsp;
                                        <asp:Label ID="lbWeekly" runat="server" CssClass="blue12"></asp:Label>&nbsp;&nbsp;
                                        <span class="blue12" style="font-weight: bolder;">最新中奖：</span>
                                    </div>
                                </td>
                            </tr>
                            <tr style="background-color: #DDDDDD;">
                                <td height="1px" colspan="2">
                                </td>
                            </tr>
                        </table>
                       
                    </td>
                    <td style="width: 850px;">
                        <iframe id="iframeTotalWinNotice" name="iframeTotalWinNotice" width="100%" height="48px"
                            frameborder="0" scrolling="no" src="<%=ResolveUrl("~/Home/Room/WinNotice.aspx") %>">
                        </iframe>
                    </td>
                </tr>
            </table>
        </td>--%>
    </tr>
</table>
<asp:HiddenField runat="server" ID="HidNowTime"></asp:HiddenField>
<asp:HiddenField runat="server" ID="HidUseLotteryList"></asp:HiddenField>

<script type="text/javascript">
    function refeshNowTime() {
        var nowTime = new Date(Date(document.getElementById("<%=HidNowTime.ClientID %>").value));

        var y = nowTime.getFullYear();
        var M = nowTime.getMonth() + 1;
        var d = nowTime.getDate();
        var h = nowTime.getHours();
        var m = nowTime.getMinutes();
        var s = nowTime.getSeconds();
        var w = ' 星期' + '日一二三四五六'.charAt(nowTime.getDay());

        document.getElementById("tdDateTimeNow").innerHTML = y + "年" + M + "月" + d + "日 " + w + " " + (h > 9 ? h : "0" + String(h)) + ":" + (m > 9 ? m : "0" + String(m)) + ":" + (s > 9 ? s : "0" + String(s));

        //时间差
        var TimePoor = nowTime.getTime() - new Date().getTime();
        document.getElementById("<%=HidNowTime.ClientID %>").value = new Date(new Date().getTime() + TimePoor + 1000);

        setTimeout("refeshNowTime();", 1000);
    }
    refeshNowTime();
    LoadLottery();

    function LoadLottery() {
        var UseLotteryList = document.getElementById("<%=HidUseLotteryList.ClientID %>").value;
        var arrUseLotteryList = UseLotteryList.split(',');  //在超级管理中选中开通的彩种列表
        var pageUseLotteryList = new Array(29,62,61,70,5,59,58,6,13,39,3,9,41,63,64,65,1,2,15);  //页面上现有的彩种列表
    }
</script>

