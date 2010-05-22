<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/FC3D/FC3D_ZS.aspx.cs" inherits="Home_TrendCharts_FC3D_FC3D_ZS" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries"
    TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>福彩3D 质数分区号码组合表-彩票走势图表和数据分析－<%=_Site.Name %></title>
    <meta name="keywords" content="福彩3D 质数分区号码组合表" />
    <meta name="description" content="福彩3D 质数分区号码组合表、彩票走势图表和数据分析。" />
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
        <table width="987" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td class="td">
                    <h1 class="td" style="font-weight: bold; font-size: 18px;display:inline;">
                        福彩3D&nbsp;&nbsp;3D质数分区号码组合表走势图</h1>
                </td>
                <td style="background-color: White">
                    &nbsp;
                </td>
            </tr>
        </table>
        <div id="div2" style="margin: 2px">
        </div>
        <div id="div3">
            <table cellspacing="0" cellpadding="1" border="0" style="background-color: #cccccc;
                width: 100%; text-align: left; font-size: 12px;">
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
        <div style="margin: 2px">
        </div>
        <table width="987" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#666666">
            <tr>
                <td width="100%" align="center">
                    <table width="987" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="10" colspan="2" style="background-color: White">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                                <table cellspacing="1" cellpadding="1" bgcolor="#000000" border="0" align="center"
                                    width="987">
                                    <tbody>
                                        <tr align="center" bgcolor="#FFCC00">
                                            <td rowspan="2">
                                                <img height="71" src="http://www.zhcw.com/lottery/images/t2.jpg" style="background-color: #FFCC00">
                                            </td>
                                            <td colspan="8">
                                                不含质数的号码
                                            </td>
                                            <td colspan="19">
                                                含质数的号码
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#FFCC00">
                                            <td width="25">
                                                单选
                                            </td>
                                            <td colspan="4">
                                                组 选 3
                                            </td>
                                            <td colspan="3">
                                                组 选 6
                                            </td>
                                            <td width="25">
                                                直选
                                            </td>
                                            <td colspan="7">
                                                组 选 3
                                            </td>
                                            <td colspan="9">
                                                组 选 6
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td width="70">
                                                单点号码
                                            </td>
                                            <td width="25">
                                                111
                                            </td>
                                            <td width="25">
                                                1
                                            </td>
                                            <td width="25">
                                                119
                                            </td>
                                            <td width="25">
                                                661
                                            </td>
                                            <td width="25">
                                                889
                                            </td>
                                            <td width="25">
                                                14
                                            </td>
                                            <td width="25">
                                                69
                                            </td>
                                            <td width="25">
                                                168
                                            </td>
                                            <td width="25">
                                                333
                                            </td>
                                            <td width="25">
                                                3
                                            </td>
                                            <td width="25">
                                                117
                                            </td>
                                            <td width="25">
                                                229
                                            </td>
                                            <td width="25">
                                                443
                                            </td>
                                            <td width="25">
                                                557
                                            </td>
                                            <td width="25">
                                                771
                                            </td>
                                            <td width="25">
                                                885
                                            </td>
                                            <td width="25">
                                                12
                                            </td>
                                            <td width="25">
                                                34
                                            </td>
                                            <td width="25">
                                                56
                                            </td>
                                            <td width="25">
                                                126
                                            </td>
                                            <td width="25">
                                                157
                                            </td>
                                            <td width="25">
                                                238
                                            </td>
                                            <td width="25">
                                                258
                                            </td>
                                            <td width="25">
                                                346
                                            </td>
                                            <td width="25">
                                                368
                                            </td>
                                            <td width="25">
                                                458
                                            </td>
                                            <td width="25">
                                                568
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td width="70">
                                            </td>
                                            <td width="25">
                                                999
                                            </td>
                                            <td width="25">
                                                9
                                            </td>
                                            <td width="25">
                                                441
                                            </td>
                                            <td width="25">
                                                669
                                            </td>
                                            <td width="25">
                                                991
                                            </td>
                                            <td width="25">
                                                16
                                            </td>
                                            <td width="25">
                                                89
                                            </td>
                                            <td width="25">
                                                469
                                            </td>
                                            <td width="25">
                                                555
                                            </td>
                                            <td width="25">
                                                5
                                            </td>
                                            <td width="25">
                                                221
                                            </td>
                                            <td width="25">
                                                331
                                            </td>
                                            <td width="25">
                                                445
                                            </td>
                                            <td width="25">
                                                559
                                            </td>
                                            <td width="25">
                                                773
                                            </td>
                                            <td width="25">
                                                887
                                            </td>
                                            <td width="25">
                                                23
                                            </td>
                                            <td width="25">
                                                36
                                            </td>
                                            <td width="25">
                                                58
                                            </td>
                                            <td width="25">
                                                128
                                            </td>
                                            <td width="25">
                                                159
                                            </td>
                                            <td width="25">
                                                245
                                            </td>
                                            <td width="25">
                                                267
                                            </td>
                                            <td width="25">
                                                348
                                            </td>
                                            <td width="25">
                                                379
                                            </td>
                                            <td width="25">
                                                467
                                            </td>
                                            <td width="25">
                                                579
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td width="70">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                449
                                            </td>
                                            <td width="25">
                                                881
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                18
                                            </td>
                                            <td width="25">
                                                146
                                            </td>
                                            <td width="25">
                                                489
                                            </td>
                                            <td width="25">
                                                777
                                            </td>
                                            <td width="25">
                                                7
                                            </td>
                                            <td width="25">
                                                223
                                            </td>
                                            <td width="25">
                                                335
                                            </td>
                                            <td width="25">
                                                447
                                            </td>
                                            <td width="25">
                                                663
                                            </td>
                                            <td width="25">
                                                778
                                            </td>
                                            <td width="25">
                                                993
                                            </td>
                                            <td width="25">
                                                25
                                            </td>
                                            <td width="25">
                                                38
                                            </td>
                                            <td width="25">
                                                67
                                            </td>
                                            <td width="25">
                                                135
                                            </td>
                                            <td width="25">
                                                179
                                            </td>
                                            <td width="25">
                                                247
                                            </td>
                                            <td width="25">
                                                269
                                            </td>
                                            <td width="25">
                                                357
                                            </td>
                                            <td width="25">
                                                456
                                            </td>
                                            <td width="25">
                                                478
                                            </td>
                                            <td width="25">
                                                678
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td width="70">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                49
                                            </td>
                                            <td width="25">
                                                148
                                            </td>
                                            <td width="25">
                                                689
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                113
                                            </td>
                                            <td width="25">
                                                225
                                            </td>
                                            <td width="25">
                                                337
                                            </td>
                                            <td width="25">
                                                551
                                            </td>
                                            <td width="25">
                                                665
                                            </td>
                                            <td width="25">
                                                779
                                            </td>
                                            <td width="25">
                                                995
                                            </td>
                                            <td width="25">
                                                27
                                            </td>
                                            <td width="25">
                                                45
                                            </td>
                                            <td width="25">
                                                78
                                            </td>
                                            <td width="25">
                                                137
                                            </td>
                                            <td width="25">
                                                234
                                            </td>
                                            <td width="25">
                                                249
                                            </td>
                                            <td width="25">
                                                278
                                            </td>
                                            <td width="25">
                                                359
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td width="70">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                115
                                            </td>
                                            <td width="25">
                                                227
                                            </td>
                                            <td width="25">
                                                339
                                            </td>
                                            <td width="25">
                                                553
                                            </td>
                                            <td width="25">
                                                667
                                            </td>
                                            <td width="25">
                                                883
                                            </td>
                                            <td width="25">
                                                997
                                            </td>
                                            <td width="25">
                                                29
                                            </td>
                                            <td width="25">
                                                47
                                            </td>
                                            <td width="25">
                                                124
                                            </td>
                                            <td width="25">
                                                139
                                            </td>
                                            <td width="25">
                                                236
                                            </td>
                                            <td width="25">
                                                256
                                            </td>
                                            <td width="25">
                                                289
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td align="center" width="70">
                                                单注点数
                                            </td>
                                            <td width="25">
                                                2
                                            </td>
                                            <td width="25">
                                                10
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                12
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                3
                                            </td>
                                            <td width="25">
                                                35
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                48
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td width="70" rowspan="5">
                                                双点号码
                                            </td>
                                            <td width="25">
                                                &nbsp;
                                            </td>
                                            <td width="25">
                                                4
                                            </td>
                                            <td width="25">
                                                116
                                            </td>
                                            <td width="25">
                                                660
                                            </td>
                                            <td width="25">
                                                886
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                13
                                            </td>
                                            <td width="25">
                                                28
                                            </td>
                                            <td width="25">
                                                59
                                            </td>
                                            <td width="25">
                                                129
                                            </td>
                                            <td width="25">
                                                147
                                            </td>
                                            <td width="25">
                                                235
                                            </td>
                                            <td width="25">
                                                257
                                            </td>
                                            <td width="25">
                                                347
                                            </td>
                                            <td width="25">
                                                369
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td width="25">
                                                000
                                            </td>
                                            <td width="25">
                                                6
                                            </td>
                                            <td width="25">
                                                118
                                            </td>
                                            <td width="25">
                                                664
                                            </td>
                                            <td width="25">
                                                990
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                2
                                            </td>
                                            <td width="25">
                                                226
                                            </td>
                                            <td width="25">
                                                334
                                            </td>
                                            <td width="25">
                                                550
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                15
                                            </td>
                                            <td width="25">
                                                35
                                            </td>
                                            <td width="25">
                                                79
                                            </td>
                                            <td width="25">
                                                134
                                            </td>
                                            <td width="25">
                                                156
                                            </td>
                                            <td width="25">
                                                237
                                            </td>
                                            <td width="25">
                                                259
                                            </td>
                                            <td width="25">
                                                349
                                            </td>
                                            <td width="25">
                                                378
                                            </td>
                                            <td width="25">
                                                479
                                            </td>
                                            <td width="25">
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td width="25">
                                                444
                                            </td>
                                            <td width="25">
                                                8
                                            </td>
                                            <td width="25">
                                                440
                                            </td>
                                            <td width="25">
                                                668
                                            </td>
                                            <td width="25">
                                                994
                                            </td>
                                            <td width="25">
                                                19
                                            </td>
                                            <td width="25">
                                                68
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                112
                                            </td>
                                            <td width="25">
                                                228
                                            </td>
                                            <td width="25">
                                                336
                                            </td>
                                            <td width="25">
                                                552
                                            </td>
                                            <td width="25">
                                                558
                                            </td>
                                            <td width="25">
                                                772
                                            </td>
                                            <td width="25">
                                                778
                                            </td>
                                            <td width="25">
                                                17
                                            </td>
                                            <td width="25">
                                                37
                                            </td>
                                            <td width="25">
                                                123
                                            </td>
                                            <td width="25">
                                                136
                                            </td>
                                            <td width="25">
                                                158
                                            </td>
                                            <td width="25">
                                                239
                                            </td>
                                            <td width="25">
                                                268
                                            </td>
                                            <td width="25">
                                                356
                                            </td>
                                            <td width="25">
                                                389
                                            </td>
                                            <td width="25">
                                                567
                                            </td>
                                            <td width="25">
                                                589
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td width="25">
                                                666
                                            </td>
                                            <td width="25">
                                                110
                                            </td>
                                            <td width="25">
                                                446
                                            </td>
                                            <td width="25">
                                                880
                                            </td>
                                            <td width="25">
                                                996
                                            </td>
                                            <td width="25">
                                                46
                                            </td>
                                            <td width="25">
                                                149
                                            </td>
                                            <td width="25">
                                                189
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                220
                                            </td>
                                            <td width="25">
                                                330
                                            </td>
                                            <td width="25">
                                                338
                                            </td>
                                            <td width="25">
                                                554
                                            </td>
                                            <td width="25">
                                                662
                                            </td>
                                            <td width="25">
                                                774
                                            </td>
                                            <td width="25">
                                                882
                                            </td>
                                            <td width="25">
                                                24
                                            </td>
                                            <td width="25">
                                                39
                                            </td>
                                            <td width="25">
                                                125
                                            </td>
                                            <td width="25">
                                                138
                                            </td>
                                            <td width="25">
                                                167
                                            </td>
                                            <td width="25">
                                                246
                                            </td>
                                            <td width="25">
                                                279
                                            </td>
                                            <td width="25">
                                                358
                                            </td>
                                            <td width="25">
                                                457
                                            </td>
                                            <td width="25">
                                                569
                                            </td>
                                            <td width="25">
                                                679
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td width="25">
                                                888
                                            </td>
                                            <td width="25">
                                                114
                                            </td>
                                            <td width="25">
                                                448
                                            </td>
                                            <td width="25">
                                                884
                                            </td>
                                            <td width="25">
                                                998
                                            </td>
                                            <td width="25">
                                                48
                                            </td>
                                            <td width="25">
                                                169
                                            </td>
                                            <td width="25">
                                                468
                                            </td>
                                            <td width="25">
                                                222
                                            </td>
                                            <td width="25">
                                                224
                                            </td>
                                            <td width="25">
                                                332
                                            </td>
                                            <td width="25">
                                                442
                                            </td>
                                            <td width="25">
                                                556
                                            </td>
                                            <td width="25">
                                                770
                                            </td>
                                            <td width="25">
                                                776
                                            </td>
                                            <td width="25">
                                                992
                                            </td>
                                            <td width="25">
                                                26
                                            </td>
                                            <td width="25">
                                                57
                                            </td>
                                            <td width="25">
                                                127
                                            </td>
                                            <td width="25">
                                                145
                                            </td>
                                            <td width="25">
                                                178
                                            </td>
                                            <td width="25">
                                                248
                                            </td>
                                            <td width="25">
                                                345
                                            </td>
                                            <td width="25">
                                                367
                                            </td>
                                            <td width="25">
                                                459
                                            </td>
                                            <td width="25">
                                                578
                                            </td>
                                            <td width="25">
                                                789
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td width="70">
                                                双点注数
                                            </td>
                                            <td width="25">
                                                4
                                            </td>
                                            <td width="25">
                                                20
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                8
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                1
                                            </td>
                                            <td width="25">
                                                25
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                52
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td width="70">
                                                类型注数
                                            </td>
                                            <td width="25">
                                                6
                                            </td>
                                            <td width="25">
                                                30
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                20
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                4
                                            </td>
                                            <td width="25">
                                                60
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                100
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td width="70">
                                                总注数
                                            </td>
                                            <td width="25">
                                                56
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                                164
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
                                            </td>
                                            <td width="25">
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
                                    <span class="bai">只能被1和自身而不能被其他自然数整除的数字，称为“质数”。在0-9十个数字当中，有2，3，5，7四个质数。3d游戏有10注直选的“豹子”，90注“组选3”和120注“组选6”号码，其包含质数与不含质数的占有注数为：直选为4：6；“组选3”为60：30；“组选6”为100：20。由于含有质数的号码在总体中占有绝大部分，所以在中奖号码中，含质数号码中出的频率很高。<br>
                                        根据对不含质数中奖号码中出状况的跟踪与分布，当判断包含质数的号码中出希望较大时，即可在164注含质数号码中进行选择。</span>
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
