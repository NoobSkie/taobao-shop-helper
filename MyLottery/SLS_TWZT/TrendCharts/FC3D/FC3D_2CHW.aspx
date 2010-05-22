<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/FC3D/FC3D_2CHW.aspx.cs" inherits="Home_TrendCharts_FC3D_FC3D_2CHW" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries"
    TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>福彩3D 二次和尾差尾查询表-彩票走势图表和数据分析－<%=_Site.Name %></title>
    <meta name="keywords" content="福彩3D 二次和尾差尾查询表" />
    <meta name="description" content="福彩3D 二次和尾差尾查询表、彩票走势图表和数据分析。" />
    <style type="text/css">
        .td
        {
            color: #cc0000;
            font-size: 16px;
        }
        td
        {
            font-size: 12px;
            font-family: tahoma;
            text-align: center;
        }
        body
        {
            margin: 0px;
            margin-left: 10px;
            margin-right: 10px;
        }
        form
        {
            display: inline;
        }
        #box1
        {
            overflow: hidden;
            width: 1002px;
            margin-right: auto;
            margin-left: auto;
            padding: 0px;
        }
    </style>
    <link href="../../Home/Room/style/css.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
    <uc2:TrendChartHead ID="TrendChartHead1" runat="server" />
    <div id="box1">
        <table width="987" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td class="td">
                    <h1 class="td" style="font-weight: bold; font-size: 18px;display:inline;">
                        福彩3D&nbsp;&nbsp;二次和尾差尾查询表走势图</h1>
                </td>
                <td height="10px" style="background-color: White">
                    &nbsp;
                </td>
            </tr>
        </table>
        <div style="margin: 1px;">
        </div>
        <div id="div3" align="center">
            <table cellspacing="0" cellpadding="1" border="0" style="background-color: #cccccc;
                width: 987px; text-align: left; font-size: 12px;">
                <tr>
                    <td style="background-color: #EFEFEF; text-align: left; font-size: 12px;">
                        <a href="<%= _Site.Url %>" target="_blank" style="text-decoration: none; font-size: 14px;
                            padding-left: 10px;"><%=_Site.Name %>首页</a> <a href="<%= ResolveUrl("~/Lottery/Buy_3D.aspx") %>"
                                target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">福彩3D投注/合买</a>
                        <a href="<%= ResolveUrl("~/WinQuery/6-0-0.aspx") %>" target="_blank" style="padding-left: 10px;
                            text-decoration: none; color: Red;">福彩3D中奖查询</a>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin: 1px;">
        </div>
        <table width="987" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#ffffff">
            <tr>
                <td>
                    <table align="center">
                        <tr>
                            <td>
                                <table width="987" border="0" bgcolor="#000000" cellspacing="1" cellpadding="1">
                                    <tr bgcolor="#ffffff">
                                        <th style="background: url(http://www.zhcw.com/images/hwj.gif) no-repeat 0 0; width: 65px;
                                            height: 46px; background-color: #ffcc00">
                                            &nbsp;
                                        </th>
                                        <th width="120" bgcolor="#ffcc00">
                                            0
                                        </th>
                                        <th width="120" bgcolor="#ffcc00">
                                            2
                                        </th>
                                        <th width="120" bgcolor="#ffcc00">
                                            4
                                        </th>
                                        <th width="120" bgcolor="#ffcc00">
                                            6
                                        </th>
                                        <th width="120" bgcolor="#ffcc00">
                                            8
                                        </th>
                                    </tr>
                                    <tr bgcolor="#ffffff">
                                        <td class="left">
                                            0
                                        </td>
                                        <td class="sdcw_d" height="70">
                                            <span class="o2">000 555</span>
                                            <br />
                                            <span class="o2">005 055</span>
                                            <br />
                                            <span class="r2">136 267 348 479</span>
                                        </td>
                                        <td class="sdcw_s">
                                            <span class="o2">222 777<br />
                                                227 277</span>
                                            <br />
                                            <span class="r2">015 146 358 489</span>
                                        </td>
                                        <td class="sdcw_d">
                                            <span class="o2">444 999
                                                <br />
                                                449 499 </span>
                                            <br />
                                            <span class="r2">025 156 237 368</span>
                                        </td>
                                        <td class="sdcw_s">
                                            <span class="o2">111 666<br />
                                                116 166</span>
                                            <br />
                                            <span class="r2">035 247 378 459</span>
                                        </td>
                                        <td class="sdcw_d">
                                            <span class="o2">333 888
                                                <br />
                                                338 388</span>
                                            <br />
                                            <span class="r2">045 126 257 469</span>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#ffffff">
                                        <td class="left">
                                            2
                                        </td>
                                        <td class="sdcw_s" height="70">
                                            <span class="o2">122 177<br />
                                                334 339 677 889</span>
                                            <br />
                                            <span class="r2">046 127 258 389</span>
                                        </td>
                                        <td class="sdcw_d">
                                            <span class="o2">001 006<br />
                                                344 399 556 899</span>
                                            <br />
                                            <span class="r2">056 137 268 349</span>
                                        </td>
                                        <td class="sdcw_s">
                                            <span class="o2">011 066<br />
                                                223 228 566 778</span>
                                            <br />
                                            <span class="r2">016 147 278 359</span>
                                        </td>
                                        <td class="sdcw_d">
                                            <span class="o2">233 288 445 788</span>
                                            <br />
                                            <span class="r2">026 157 238 369</span>
                                        </td>
                                        <td class="sdcw_s">
                                            <span class="o2">112 117 455 667</span>
                                            <br />
                                            <span class="r2">036 167 248 379</span>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#ffffff">
                                        <td class="left">
                                            4
                                        </td>
                                        <td class="sdcw_d" height="70">
                                            <span class="o2">113 118<br />
                                                244 299 668 799</span>
                                            <br />
                                            <span class="r2">037 168 249 456</span>
                                        </td>
                                        <td class="sdcw_s">
                                            <span class="o2">335 466</span>
                                            <br />
                                            <span class="r2">047 128 178 259</span>
                                            <br />
                                            <span class="tdtit2">123 678</span>
                                        </td>
                                        <td class="sdcw_d">
                                            <span class="o2">002 007<br />
                                                133 188 557 688</span>
                                            <br />
                                            <span class="r2">057 138 269 345</span>
                                        </td>
                                        <td class="sdcw_s">
                                            <span class="o2">224 229 355 779</span>
                                            <br />
                                            <span class="r2">017 067 148 279</span>
                                            <br />
                                            <span class="tdtit2">012 567</span>
                                        </td>
                                        <td class="sdcw_d">
                                            <span class="o2">022 077 446 577</span>
                                            <br />
                                            <span class="r2">027 158 239 289</span>
                                            <br />
                                            <span class="tdtit2">234 789</span>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#ffffff">
                                        <td class="left">
                                            6
                                        </td>
                                        <td class="sdcw_s" height="70">
                                            <span class="o2">366 447</span>
                                            <br />
                                            <span class="r2">028 078 159 235</span>
                                            <br />
                                            <span class="tdtit2">023 578</span>
                                        </td>
                                        <td class="sdcw_d">
                                            <span class="o2">033 088<br />
                                                114 119 588 669</span>
                                            <br />
                                            <span class="r2">038 169 245 457</span>
                                        </td>
                                        <td class="sdcw_s">
                                            <span class="o2">255 336</span>
                                            <br />
                                            <span class="r2">048 129 179 467</span>
                                            <br />
                                            <span class="tdtit2">124 679</span>
                                        </td>
                                        <td class="sdcw_d">
                                            <span class="o2">003 008 477 558</span>
                                            <br />
                                            <span class="r2">058 139 189 346</span>
                                            <br />
                                            <span class="tdtit2">134 689</span>
                                        </td>
                                        <td class="sdcw_s">
                                            <span class="o2">144 199 225 699</span>
                                            <br />
                                            <span class="r2">018 068 149 356</span>
                                            <br />
                                            <span class="tdtit2">568 013</span>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#ffffff">
                                        <td class="left">
                                            8
                                        </td>
                                        <td class="sdcw_d" height="70">
                                            <span class="o2">226 488</span>
                                            <br />
                                            <span class="r2">019 069 145 357</span>
                                            <br />
                                            <span class="tdtit2">014 569</span>
                                        </td>
                                        <td class="sdcw_s">
                                            <span class="o2">155 448</span>
                                            <br />
                                            <span class="r2">029 079 236 367</span>
                                            <br />
                                            <span class="tdtit2">024 579</span>
                                        </td>
                                        <td class="sdcw_d">
                                            <span class="o2">115 377</span>
                                            <br />
                                            <span class="r2">039 089 246 458</span>
                                            <br />
                                            <span class="tdtit2">034 589</span>
                                        </td>
                                        <td class="sdcw_s">
                                            <span class="o2">044 099 337 599</span>
                                            <br />
                                            <span class="r2">049 125 256 468</span>
                                        </td>
                                        <td class="sdcw_d">
                                            <span class="o2">004 009 266 559</span>
                                            <br />
                                            <span class="r2">059 135 347 478</span>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#ffffff">
                                        <td colspan="6" height="19" bgcolor="#FFCC00">
                                            <br />
                                            <span style="color: #ff0000; font-weight: bold">注:</span> 2次和尾:(百+十)+(百+个)+(十+个)÷10的余数.分为0
                                            2 4 6 8 5个区
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;2次差尾:|百-十|+|百-个|+|十-个|÷10的余数.分为0 2 4 6 8 5个区
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div style="margin: 1px; text-align: left; font-size: 12px;">
            <table cellspacing="0" cellpadding="1" border="0" style="background-color: #cccccc;
                width: 100%; text-align: left;">
                <tr>
                    <td style="background-color: #EFEFEF; text-align: left;">
                         <a href="<%= _Site.Url %>" target="_blank"
                            style="text-decoration: none; font-size: 14px; padding-left: 10px;"><%=_Site.Name %>首页</a>
                        <a href="<%= ResolveUrl("~/Lottery/Buy_3D.aspx") %>" target="_blank" style="padding-left: 10px;
                            text-decoration: none; color: Red;">福彩3D投注/合买</a> <a href="<%= ResolveUrl("~/WinQuery/6-0-0.aspx") %>"
                                target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">福彩3D中奖查询</a>
                        <a href='FC3D_ZHXT.aspx' target='mainFrame'>综合分布遗漏走势图</a> | <a href='FC3D_C3YS.aspx'
                            target='mainFrame'>除三余数形态遗漏走势图</a> | <a href='FC3D_ZHZST.aspx' target='mainFrame'>质合形态遗漏走势图</a>
                        | <a href='FC3D_XTZST.aspx' target='mainFrame'>形态遗漏走势图</a> | <a href='FC3D_KDZST.aspx'
                            target='mainFrame'>跨度遗漏走势图</a> | <a href='FC3D_HZZST.aspx' target='mainFrame'>和值遗漏走势图</a>
                        | <a href='FC3D_DZXZST.aspx' target='mainFrame'>大中小形态遗漏走势图</a> | <a href='FC3D_C3YS_HTML.aspx'
                            target='mainFrame'>除三余数号码分区表走势图</a> |</br> <a href='FC3D_2CHW.aspx' target='mainFrame'>
                                二次和尾差尾查询表走势图</a> | <a href='FC3D_DSHM.aspx' target='mainFrame'>单双点号码分区表走势图</a>
                        <a href='FC3D_DTHM.aspx' target='mainFrame'>胆托号码分区表走势图</a> | <a href='FC3D_DX_JO.aspx'
                            target='mainFrame'>大小—奇偶号码分区表走势图</a> | <a href='FC3D_HSWH.aspx' target='mainFrame'>和数尾号码分区表走势图</a>
                        | <a href='FC3D_HSZ.aspx' target='mainFrame'>和数值号码分区表走势图</a> | <a href='FC3D_KDZH.aspx'
                            target='mainFrame'>跨度组合分区表走势图</a> | <a href='FC3D_JO_DX.aspx' target='mainFrame'>奇偶—大小号码分区表走势图</a>
                        | <a href='FC3D_LHZH.aspx' target='mainFrame'>连号组合分区表走势图</a> | <a href='FC3D_ZS.aspx'
                            target='mainFrame'>质数号码分区表走势图</a>
                    </td>
                </tr>
            </table>
        </div>
        <div style="display: none;">

            <script type="text/javascript" src="http://js.tongji.linezing.com/1135959/tongji.js"></script>

            <noscript>
                <a href="http://www.linezing.com">
                    <img src="http://img.tongji.linezing.com/1135959/tongji.gif" /></a></noscript>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>
