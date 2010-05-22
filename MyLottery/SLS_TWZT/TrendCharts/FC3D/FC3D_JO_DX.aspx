<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/FC3D/FC3D_JO_DX.aspx.cs" inherits="Home_TrendCharts_FC3D_FC3D_JO_DX" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries"
    TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>福彩3D 游戏奇偶分区 - 大小分区表-彩票走势图表和数据分析－<%=_Site.Name %></title>
    <meta name="keywords" content="福彩3D 游戏奇偶分区-大小分区表" />
    <meta name="description" content="福彩3D 游戏奇偶分区 -大小分区表、彩票走势图表和数据分析。" />
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
                    <h1 class="td" style="font-weight: bold; font-size: 18px;display:inline;">
                        3D游戏奇偶分区 — 大小分区表走势图</h1>
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
        <table width="987" border="0" cellpadding="0" cellspacing="0" bgcolor="#666666" align="center">
            <tr>
                <td width="100%" align="center">
                    <table width="750" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="10" colspan="2" bgcolor="#ffffff">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                                <table cellspacing="1" cellpadding="1" bgcolor="#000000" align="center" width="987">
                                    <tbody>
                                        <tr align="center" bgcolor="#FFCC00">
                                            <td width="76" bgcolor="#FFCC00" height="30">
                                                奇偶类型
                                            </td>
                                            <td width="148" colspan="4">
                                                <div align="center" height="30">
                                                    全奇
                                                </div>
                                            </td>
                                            <td width="296" colspan="8">
                                                <div align="center">
                                                    两奇一偶
                                                </div>
                                            </td>
                                            <td width="296" colspan="8">
                                                <div align="center">
                                                    两偶一奇
                                                </div>
                                            </td>
                                            <td width="154" colspan="4">
                                                <div align="center">
                                                    全偶
                                                </div>
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td>
                                                选号
                                                <br>
                                                形式
                                            </td>
                                            <td>
                                                单选
                                            </td>
                                            <td colspan="2">
                                                组选 3
                                            </td>
                                            <td>
                                                组 6
                                            </td>
                                            <td colspan="3">
                                                组选 3
                                            </td>
                                            <td colspan="5">
                                                组选 6
                                            </td>
                                            <td colspan="3">
                                                组选 3
                                            </td>
                                            <td colspan="5">
                                                组选 6
                                            </td>
                                            <td width="30">
                                                单选
                                            </td>
                                            <td colspan="2">
                                                组选 3
                                            </td>
                                            <td>
                                                组 6
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td bgcolor="#ffffff" rowspan="10">
                                                具
                                                <br>
                                                <br>
                                                体
                                                <br>
                                                <br>
                                                号
                                                <br>
                                                <br>
                                                码
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                111
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                113
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                557
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                135
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                110
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                550
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                990
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                013
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                123
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                156
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                259
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                389
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                001
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                441
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                881
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                012
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                038
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                124
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                247
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                368
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                000
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                002
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                446
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                024
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                333
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                115
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                559
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                137
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                112
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                552
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                992
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                015
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                125
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                158
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                279
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                457
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                003
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                443
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                883
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                014
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                045
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                126
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                249
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                456
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                222
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                004
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                448
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                026
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                555
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                117
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                771
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                139
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                114
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                554
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                994
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                017
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                127
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                167
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                345
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                459
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                005
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                445
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                885
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                016
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                047
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                128
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                256
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                458
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                444
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                006
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                660
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                028
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                777
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                119
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                773
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                157
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                116
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                556
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                996
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                019
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                129
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                169
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                347
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                479
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                007
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                447
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                887
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                018
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                049
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                146
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                258
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                467
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                666
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                008
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                662
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                046
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                999
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                331
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                775
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                159
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                118
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                558
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                998
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                035
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                134
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                178
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                349
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                567
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                009
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                449
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                889
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                023
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                056
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                148
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                267
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                469
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                888
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                220
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                664
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                048
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                335
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                779
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                179
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                330
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                770
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                037
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                136
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                189
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                356
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                569
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                221
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                661
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                025
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                058
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                168
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                269
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                478
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                224
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                668
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                068
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                337
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                991
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                357
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                332
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                772
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                039
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                138
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                235
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                358
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                578
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                223
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                663
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                027
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                067
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                234
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                278
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                489
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                228
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                880
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                246
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                339
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                993
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                359
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                334
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                774
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                057
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                145
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                237
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                367
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                589
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                225
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                665
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                029
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                069
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                236
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                289
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                568
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                232
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                882
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                248
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                551
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                995
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                379
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                336
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                776
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                059
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                147
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                239
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                369
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                679
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                227
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                667
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                034
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                078
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                238
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                346
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                678
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                440
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                884
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                268
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                553
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                997
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                579
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                338
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                778
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                079
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                149
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                257
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                378
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                789
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                229
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                669
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                036
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                089
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                245
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                348
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                689
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                442
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                886
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                468
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td class="xl27">
                                                大小
                                                <br>
                                                类型
                                            </td>
                                            <td width="30">
                                                全大
                                            </td>
                                            <td>
                                                两大
                                                <br>
                                                一小
                                            </td>
                                            <td>
                                                两小
                                                <br>
                                                一大
                                            </td>
                                            <td>
                                                全小
                                            </td>
                                            <td width="30">
                                                全大
                                            </td>
                                            <td colspan="3">
                                                两大一小
                                            </td>
                                            <td colspan="3">
                                                两小一大
                                            </td>
                                            <td>
                                                全小
                                            </td>
                                            <td width="30">
                                                全大
                                            </td>
                                            <td colspan="3">
                                                两大一小
                                            </td>
                                            <td bgcolor="#ffffff" colspan="3">
                                                两小一大
                                            </td>
                                            <td bgcolor="#ffffff">
                                                全小
                                            </td>
                                            <td width="30">
                                                全大
                                            </td>
                                            <td>
                                                两大
                                                <br>
                                                一小
                                            </td>
                                            <td>
                                                两小
                                                <br>
                                                一大
                                            </td>
                                            <td>
                                                全小
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td rowspan="12">
                                                具
                                                <br>
                                                <br>
                                                体
                                                <br>
                                                <br>
                                                号
                                                <br>
                                                <br>
                                                码
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                555
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                551
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                115
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                111
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                556
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                550
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                059
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                279
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                116
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                125
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                239
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                110
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                665
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                661
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                168
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                467
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                005
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                018
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                128
                                            </td>
                                            <td bgcolor="#f9ffdd">
                                                001
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                666
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                660
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                006
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                000
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                777
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                553
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                117
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                333
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                558
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                552
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                079
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                356
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                118
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                127
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                345
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                112
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                667
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                663
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                256
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                469
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                007
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                025
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                146
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                003
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                888
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                662
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                008
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                222
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                999
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                771
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                119
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                113
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                776
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                554
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                156
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                358
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                336
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                129
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                347
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                114
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                669
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                881
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                258
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                478
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                009
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                027
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                148
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                221
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                668
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                664
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                226
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                444
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                557
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                773
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                335
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                331
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                778
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                770
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                158
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                367
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                338
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                136
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                349
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                330
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                885
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                883
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                267
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                489
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                225
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                029
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                236
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                223
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                                886
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                880
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                228
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                002
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                559
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                991
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                337
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                996
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                772
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                167
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                369
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                015
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                138
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                332
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                887
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                056
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                269
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                227
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                036
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                238
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                441
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                882
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                446
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                004
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                775
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                993
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                339
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                998
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                774
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                169
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                378
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                017
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                145
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                334
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                889
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                058
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                278
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                229
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                045
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                245
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                443
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                884
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                448
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                220
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                779
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                157
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                135
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                567
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                990
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                178
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                389
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                019
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                147
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                013
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                568
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                067
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                289
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                445
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                047
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                247
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                012
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                068
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                026
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                224
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                995
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                159
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                137
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                569
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                992
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                189
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                457
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                035
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                149
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                123
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                678
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                069
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                368
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                447
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                049
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                249
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                014
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                268
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                028
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                440
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                997
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                179
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                139
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                578
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                994
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                257
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                459
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                037
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                235
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                134
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                689
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                078
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                456
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                449
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                126
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                346
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                023
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                468
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                046
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                442
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                579
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                357
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                589
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                057
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                259
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                479
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                039
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                237
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                089
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                458
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                016
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                348
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                034
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                048
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                024
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                359
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                679
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                124
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                246
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                379
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                                789
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" width="30" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                            </td>
                                            <td align="center" bgcolor="#f9ffdd">
                                                234
                                            </td>
                                            <td align="center" width="30" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                                248
                                            </td>
                                            <td align="center" bgcolor="#ffe8e8">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" height="19" bgcolor="#FFCC00">
                                <p>
                                    <br>
                                    <span class="bai">根据数学分类：1，3，5，7，9为奇数，0，2，4，6，8为偶数，0，1，2，3，4是小数，5，6，7，8，9是大数，那么由0-9十个数字组成的三位数号码就可分为全奇，全偶，两奇一偶，两偶一奇，全大，全小，两大一小，两小一在共八种不同的基本形式。以任何一种奇偶形式为条件，又可分为四种不同的大小形式，反之亦然。<br>
                                        根据对各种形式的出号跟踪，当判断某一奇偶形式中出希望较大时，即可在相对应的大小形式中进行选号。<br>
                                        <br>
                                    </span>
                                    <br>
                                </p>
                            </td>
                        </tr>
                        <tbody>
                        </tbody>
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
                                target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">福彩3D中奖查询</a><<a href='FC3D_ZHXT.aspx' target='mainFrame'>综合分布遗漏走势图</a> | <a href='FC3D_C3YS.aspx'
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
