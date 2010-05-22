<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/FC3D/FC3D_KDZH.aspx.cs" inherits="Home_TrendCharts_FC3D_FC3D_KDZH" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<title>福彩3D 游戏首尾边距组合分区表-彩票走势图表和数据分析－<%=_Site.Name %></title>
<meta name="keywords" content="福彩3D 游戏首尾边距组合分区表" />
<meta name="description" content="福彩3D 游戏首尾边距组合分区表、彩票走势图表和数据分析。" />

    <style type="text/css">
        .td
        {
            color: Red;
            font-size: 16px;
        }
        td
        {
            font-size: 12px;
            font-family: 宋体;
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
        <table width="778" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td class="td">
                    <h1 class="td" style="font-weight: bold; font-size: 18px;display:inline;">3D游戏首尾边距组合分区表走势图</h1>
                </td>
                <td style="background-color: White">
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
        <table width="778" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table cellspacing="1" cellpadding="1" align="center" bgcolor="#000000" border="0">
                        <tbody>
                            <tr align="center" bgcolor="#ffffff">
                                <td height="20" colspan="2" rowspan="2" align="center" bgcolor="#ffcc66">
                                    &nbsp;
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffcc66">
                                    0
                                </td>
                                <td width="58" height="20" colspan="2" align="center" bgcolor="#ffcc66">
                                    1
                                </td>
                                <td width="87" height="20" colspan="3" align="center" bgcolor="#ffcc66">
                                    2
                                </td>
                                <td width="58" height="20" colspan="2" align="center" bgcolor="#ffcc66">
                                    3
                                </td>
                                <td width="87" height="20" colspan="3" align="center" bgcolor="#ffcc66">
                                    4
                                </td>
                                <td width="87" height="20" colspan="3" align="center" bgcolor="#ffcc66">
                                    5
                                </td>
                                <td width="87" height="20" colspan="3" align="center" bgcolor="#ffcc66">
                                    6
                                </td>
                                <td width="87" height="20" colspan="3" align="center" bgcolor="#ffcc66">
                                    7
                                </td>
                                <td width="87" height="20" colspan="2" align="center" bgcolor="#ffcc66">
                                    8
                                </td>
                                <td width="87" height="20" colspan="2" align="center" bgcolor="#ffcc66">
                                    9
                                </td>
                            </tr>
                            <tr>
                                <td width="30" height="20" align="center" bgcolor="#ffcc66">
                                    直选
                                </td>
                                <td height="20" colspan="2" align="center" bgcolor="#ffcc66">
                                    组选3
                                </td>
                                <td height="20" colspan="2" align="center" bgcolor="#ffcc66">
                                    组选3
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffcc66">
                                    组选6
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffcc66">
                                    组选3
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffcc66">
                                    组选6
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffcc66">
                                    组选3
                                </td>
                                <td height="20" colspan="2" align="center" bgcolor="#ffcc66">
                                    组选6
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffcc66">
                                    组选3
                                </td>
                                <td height="20" colspan="2" align="center" bgcolor="#ffcc66">
                                    组选6
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffcc66">
                                    组选3
                                </td>
                                <td height="20" colspan="2" align="center" bgcolor="#ffcc66">
                                    组选6
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffcc66">
                                    组选3
                                </td>
                                <td height="20" colspan="2" align="center" bgcolor="#ffcc66">
                                    组选6
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffcc66">
                                    组选3
                                </td>
                                <td height="20" colspan="1" align="center" bgcolor="#ffcc66">
                                    组选6
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffcc66">
                                    组选3
                                </td>
                                <td height="20" colspan="1" align="center" bgcolor="#ffcc66">
                                    组选6
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td height="20" colspan="2" rowspan="7" align="center">
                                    单点号码
                                </td>
                                <td width="30" height="20" align="center">
                                    111
                                </td>
                                <td width="30" height="20" align="center">
                                    001
                                </td>
                                <td width="30" height="20" align="center">
                                    665
                                </td>
                                <td width="30" height="20" align="center">
                                    113
                                </td>
                                <td width="30" height="20" align="center">
                                    553
                                </td>
                                <td width="30" height="20" align="center">
                                    012
                                </td>
                                <td width="30" height="20" align="center">
                                    003
                                </td>
                                <td width="30" height="20" align="center">
                                    023
                                </td>
                                <td width="30" height="20" align="center">
                                    115
                                </td>
                                <td width="30" height="20" align="center">
                                    014
                                </td>
                                <td width="30" height="20" align="center">
                                    357
                                </td>
                                <td width="30" height="20" align="center">
                                    005
                                </td>
                                <td width="30" height="20" align="center">
                                    025
                                </td>
                                <td width="30" height="20" align="center">
                                    267
                                </td>
                                <td width="30" height="20" align="center">
                                    117
                                </td>
                                <td width="30" height="20" align="center">
                                    016
                                </td>
                                <td width="30" height="20" align="center">
                                    238
                                </td>
                                <td width="30" height="20" align="center">
                                    007
                                </td>
                                <td width="30" height="20" align="center">
                                    027
                                </td>
                                <td width="30" height="20" align="center">
                                    148
                                </td>
                                <td width="30" height="20" align="center">
                                    119
                                </td>
                                <td width="30" height="20" align="center">
                                    018
                                </td>
                                <td width="30" height="20" align="center">
                                    009
                                </td>
                                <td width="30" height="20" align="center">
                                    029
                                </td>
                            </tr>
                            <tr>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    333
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    221
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    667
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    331
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    557
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    234
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    225
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    124
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    337
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    034
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    458
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    227
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    045
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    348
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    339
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    036
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    258
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    229
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    047
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    168
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    991
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    038
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    049
                                </td>
                            </tr>
                            <tr>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    555
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    223
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    887
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    335
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    775
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    456
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    441
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    245
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    551
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    135
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    478
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    449
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    126
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    368
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    771
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    056
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    278
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    881
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    067
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    249
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    058
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    069
                                </td>
                            </tr>
                            <tr>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    777
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    443
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    889
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    779
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    678
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    447
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    346
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    559
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    236
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    579
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    661
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    146
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    469
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    993
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    137
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    359
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    128
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    269
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    078
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    089
                                </td>
                            </tr>
                            <tr>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    999
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    445
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    997
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    663
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    467
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    773
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    256
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    883
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    247
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    489
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    157
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    379
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    289
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    139
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                            </tr>
                            <tr>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    669
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    568
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    995
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    159
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                            </tr>
                            <tr>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    885
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    689
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    179
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td height="20" colspan="2" align="center">
                                    单点注数
                                </td>
                                <td width="30" height="20" align="center">
                                    5
                                </td>
                                <td height="20" colspan="2" align="center">
                                    9
                                </td>
                                <td height="20" colspan="2" align="center">
                                    8
                                </td>
                                <td width="30" height="20" align="center">
                                    4
                                </td>
                                <td width="30" height="20" align="center">
                                    7
                                </td>
                                <td width="30" height="20" align="center">
                                    7
                                </td>
                                <td width="30" height="20" align="center">
                                    6
                                </td>
                                <td height="20" colspan="2" align="center">
                                    9
                                </td>
                                <td width="30" height="20" align="center">
                                    5
                                </td>
                                <td height="20" colspan="2" align="center">
                                    10
                                </td>
                                <td width="30" height="20" align="center">
                                    4
                                </td>
                                <td height="20" colspan="2" align="center">
                                    10
                                </td>
                                <td width="30" height="20" align="center">
                                    3
                                </td>
                                <td height="20" colspan="2" align="center">
                                    9
                                </td>
                                <td width="30" height="20" align="center">
                                    2
                                </td>
                                <td width="30" height="20" align="center">
                                    7
                                </td>
                                <td width="30" height="20" align="center">
                                    1
                                </td>
                                <td width="30" height="20" align="center">
                                    4
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td height="20" colspan="2" rowspan="7" align="center">
                                    双点号码
                                </td>
                                <td width="30" height="20" align="center">
                                </td>
                                <td height="20" colspan="2" align="center">
                                </td>
                                <td height="20" colspan="2" align="center">
                                </td>
                                <td width="30" height="20" align="center">
                                </td>
                                <td width="30" height="20" align="center">
                                    114
                                </td>
                                <td width="30" height="20" align="center">
                                    013
                                </td>
                                <td width="30" height="20" align="center">
                                </td>
                                <td height="20" colspan="2" align="center">
                                </td>
                                <td width="30" height="20" align="center">
                                </td>
                                <td height="20" colspan="2" align="center">
                                </td>
                                <td width="30" height="20" align="center">
                                </td>
                                <td height="20" colspan="2" align="center">
                                </td>
                                <td width="30" height="20" align="center">
                                </td>
                                <td height="20" colspan="2" align="center">
                                </td>
                                <td width="30" height="20" align="center">
                                </td>
                                <td width="30" height="20" align="center">
                                    028
                                </td>
                                <td width="30" height="20" align="center">
                                </td>
                                <td width="30" height="20" align="center">
                                </td>
                            </tr>
                            <tr>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td height="20" colspan="2" align="center" bgcolor="#ffffff">
                                </td>
                                <td height="20" colspan="2" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    330
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    134
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    004
                                </td>
                                <td height="20" colspan="2" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td height="20" colspan="2" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td height="20" colspan="2" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td height="20" colspan="2" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    048
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                            </tr>
                            <tr>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    000
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    110
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    442
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    336
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    235
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    226
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    024
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    116
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    015
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    257
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    026
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    248
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    158
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    068
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                            </tr>
                            <tr>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    222
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    112
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    556
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    446
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    123
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    552
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    356
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    440
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    125
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    367
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    338
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    035
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    358
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    006
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    046
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    268
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    017
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    178
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    129
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    019
                                </td>
                            </tr>
                            <tr>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    444
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    332
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    776
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    002
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    664
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    345
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    558
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    457
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    448
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    145
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    468
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    550
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    136
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    378
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    228
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    127
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    349
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    118
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    037
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    239
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    149
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    039
                                </td>
                            </tr>
                            <tr>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    666
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    334
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    778
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    220
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    668
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    567
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    774
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    578
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    662
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    246
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    569
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    772
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    156
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    459
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    660
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    147
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    369
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    770
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    057
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    259
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    008
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    169
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    059
                                </td>
                            </tr>
                            <tr>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    888
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    554
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    998
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    224
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    886
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    789
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    996
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    679
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    884
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    347
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    589
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    994
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    237
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    479
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    882
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    167
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    389
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    992
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    138
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    279
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    880
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    189
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    990
                                </td>
                                <td width="30" height="20" align="center" bgcolor="#ffffff">
                                    079
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td height="20" colspan="2" align="center">
                                    双点注数
                                </td>
                                <td width="30" height="20" align="center">
                                    5
                                </td>
                                <td height="20" colspan="2" align="center">
                                    9
                                </td>
                                <td height="20" colspan="2" align="center">
                                    8
                                </td>
                                <td width="30" height="20" align="center">
                                    4
                                </td>
                                <td width="30" height="20" align="center">
                                    7
                                </td>
                                <td width="30" height="20" align="center">
                                    7
                                </td>
                                <td width="30" height="20" align="center">
                                    6
                                </td>
                                <td height="20" colspan="2" align="center">
                                    9
                                </td>
                                <td width="30" height="20" align="center">
                                    5
                                </td>
                                <td height="20" colspan="2" align="center">
                                    10
                                </td>
                                <td width="30" height="20" align="center">
                                    4
                                </td>
                                <td height="20" colspan="2" align="center">
                                    10
                                </td>
                                <td width="30" height="20" align="center">
                                    3
                                </td>
                                <td height="20" colspan="2" align="center">
                                    9
                                </td>
                                <td width="30" height="20" align="center">
                                    2
                                </td>
                                <td width="30" height="20" align="center">
                                    7
                                </td>
                                <td width="30" height="20" align="center">
                                    1
                                </td>
                                <td width="30" height="20" align="center">
                                    4
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td height="20" colspan="2" align="center">
                                    类型注数
                                </td>
                                <td width="30" height="20" align="center">
                                    10
                                </td>
                                <td height="20" colspan="2" align="center">
                                    18
                                </td>
                                <td height="20" colspan="2" align="center">
                                    16
                                </td>
                                <td width="30" height="20" align="center">
                                    8
                                </td>
                                <td width="30" height="20" align="center">
                                    14
                                </td>
                                <td width="30" height="20" align="center">
                                    14
                                </td>
                                <td width="30" height="20" align="center">
                                    12
                                </td>
                                <td height="20" colspan="2" align="center">
                                    18
                                </td>
                                <td width="30" height="20" align="center">
                                    10
                                </td>
                                <td height="20" colspan="2" align="center">
                                    20
                                </td>
                                <td width="30" height="20" align="center">
                                    8
                                </td>
                                <td height="20" colspan="2" align="center">
                                    20
                                </td>
                                <td width="30" height="20" align="center">
                                    6
                                </td>
                                <td height="20" colspan="2" align="center">
                                    18
                                </td>
                                <td width="30" height="20" align="center">
                                    4
                                </td>
                                <td width="30" height="20" align="center">
                                    14
                                </td>
                                <td width="30" height="20" align="center">
                                    2
                                </td>
                                <td width="30" height="20" align="center">
                                    8
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td height="20" colspan="2" align="center">
                                    总注数
                                </td>
                                <td width="30" height="20" align="center">
                                    10
                                </td>
                                <td height="20" colspan="2" align="center">
                                    18
                                </td>
                                <td height="20" colspan="3" align="center">
                                    24
                                </td>
                                <td height="20" colspan="2" align="center">
                                    28
                                </td>
                                <td height="20" colspan="3" align="center">
                                    30
                                </td>
                                <td height="20" colspan="3" align="center">
                                    30
                                </td>
                                <td height="20" colspan="3" align="center">
                                    28
                                </td>
                                <td height="20" colspan="3" align="center">
                                    24
                                </td>
                                <td height="20" colspan="2" align="center">
                                    18
                                </td>
                                <td height="20" colspan="2" align="center">
                                    10
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" height="19" bgcolor="#FFCC00">
                    <br>
                    &nbsp;&nbsp;&nbsp; 中奖号码的最大号与最小号的差值，被称为“首尾边距”，有0-9共有十个不同的数值。边距为0的是10注直选“豹子”。1则为18注“组选3”号码，2-9都由不同的“组选3”和“组选6”组成。
                    根据对每种边距的出号跟踪及所包含的“组选3”与“组选6”中出情况的分析，即可在判断某些边距数值号码不具备中出可能时，放弃该组合中的相应号码。
                </td>
            </tr>
        </table>
        <div style="margin: 1px; text-align: left; font-size: 12px;">
            <table cellspacing="0" cellpadding="1" border="0" style="background-color: #cccccc;
                width: 100%; text-align: left;">
                <tr>
                    <td style="background-color: #EFEFEF; text-align: left;">
                        <a href="<%= _Site.Url %>" target="_blank" style="text-decoration: none; font-size: 14px;
                            padding-left: 10px;"><%=_Site.Name %>首页</a> <a href="<%= ResolveUrl("~/Lottery/Buy_3D.aspx") %>"
                                target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">福彩3D投注/合买</a>
                        <a href="<%= ResolveUrl("~/WinQuery/6-0-0.aspx") %>" target="_blank" style="padding-left: 10px;
                            text-decoration: none; color: Red;">福彩3D中奖查询</a> <a href='FC3D_ZHXT.aspx' target='mainFrame'>综合分布遗漏走势图</a> | <a href='FC3D_C3YS.aspx'
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
