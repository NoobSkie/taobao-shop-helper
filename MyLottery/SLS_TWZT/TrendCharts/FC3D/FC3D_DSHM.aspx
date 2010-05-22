<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/FC3D/FC3D_DSHM.aspx.cs" inherits="Home_TrendCharts_FC3D_FC3D_DSHM" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>福彩3D 游戏单双点号码分区表-彩票走势图表和数据分析－<%=_Site.Name %></title>
<meta name="keywords" content="福彩3D 游戏单双点号码分区表" />
<meta name="description" content="福彩3D 游戏单双点号码分区表、彩票走势图表和数据分析。" />

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
                    <h1 class="td" style="font-weight: bold; font-size: 18px;display:inline;">3D游戏单双点号码分区表走势图</h1>
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
                        <a href="<%= _Site.Url %>" target="_blank" style="text-decoration: none; font-size: 14px;">
                            <%=_Site.Name %>首页</a><a href="../../Home/Room/Buy.aspx?LotteryID=6&CoBuy=1" target="_blank" style="padding-left: 5px;
                                text-decoration: none; color: Red;">3D合买</a><a href="../../Home/Room/Buy.aspx?LotteryID=6"
                                    target="_blank" style="padding-left: 5px; text-decoration: none; color: Red;">3D代购</a>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin: 1px;">
        </div>
        <table cellspacing="0" cellpadding="0" width="750" align="center">
            <tr>
                <td align="center" valign="top">
                    <table cellspacing="1" cellpadding="1" width="750" bgcolor="#000000" border="0">
                        <tbody>
                            <tr align="center" bgcolor="#ffffff">
                                <td width="70" height="32" align="center" bgcolor="#ffcc66">
                                    号码类型
                                </td>
                                <td width="25" align="center" bgcolor="#ffcc66">
                                    直选
                                </td>
                                <td colspan="9" align="center" bgcolor="#ffcc66">
                                    组 选 3
                                </td>
                                <td colspan="12" align="center" bgcolor="#ffcc66">
                                    组 选 6
                                </td>
                                <td width="70" align="center" bgcolor="#ffcc66">
                                    备注
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td width="70" height="22" align="center" bgcolor="#fdfcdf">
                                    单点号码
                                </td>
                                <td width="25" align="center">
                                    111
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    1
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    113
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    223
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    335
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    445
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    557
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    667
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    779
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    889
                                </td>
                                <td width="25" align="center">
                                    12
                                </td>
                                <td width="25" align="center">
                                    25
                                </td>
                                <td width="25" align="center">
                                    38
                                </td>
                                <td width="25" align="center">
                                    58
                                </td>
                                <td width="25" align="center">
                                    124
                                </td>
                                <td width="25" align="center">
                                    139
                                </td>
                                <td width="25" align="center">
                                    168
                                </td>
                                <td width="25" align="center">
                                    245
                                </td>
                                <td width="25" align="center">
                                    267
                                </td>
                                <td width="25" align="center">
                                    348
                                </td>
                                <td width="25" align="center">
                                    456
                                </td>
                                <td width="25" align="center">
                                    489
                                </td>
                                <td width="70" rowspan="5" align="center" bgcolor="#fdfcdf">
                                    单点号码共有 120 注，其中直选形式 5 注，组选 3 形式有 45 注，组选 6 形式有 60 注
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td width="70" height="22" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center">
                                    333
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    3
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    115
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    225
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    337
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    447
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    559
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    669
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    881
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    991
                                </td>
                                <td width="25" align="center">
                                    14
                                </td>
                                <td width="25" align="center">
                                    27
                                </td>
                                <td width="25" align="center">
                                    45
                                </td>
                                <td width="25" align="center">
                                    67
                                </td>
                                <td width="25" align="center">
                                    126
                                </td>
                                <td width="25" align="center">
                                    146
                                </td>
                                <td width="25" align="center">
                                    179
                                </td>
                                <td width="25" align="center">
                                    247
                                </td>
                                <td width="25" align="center">
                                    269
                                </td>
                                <td width="25" align="center">
                                    357
                                </td>
                                <td width="25" align="center">
                                    458
                                </td>
                                <td width="25" align="center">
                                    568
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td width="70" height="22" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center">
                                    555
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    5
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    117
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    227
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    339
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    449
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    661
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    771
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    883
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    993
                                </td>
                                <td width="25" align="center">
                                    16
                                </td>
                                <td width="25" align="center">
                                    29
                                </td>
                                <td width="25" align="center">
                                    47
                                </td>
                                <td width="25" align="center">
                                    69
                                </td>
                                <td width="25" align="center">
                                    128
                                </td>
                                <td width="25" align="center">
                                    148
                                </td>
                                <td width="25" align="center">
                                    234
                                </td>
                                <td width="25" align="center">
                                    249
                                </td>
                                <td width="25" align="center">
                                    278
                                </td>
                                <td width="25" align="center">
                                    359
                                </td>
                                <td width="25" align="center">
                                    467
                                </td>
                                <td width="25" align="center">
                                    579
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td width="70" height="22" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center">
                                    777
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    7
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    119
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    229
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    441
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    551
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    663
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    773
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    885
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    995
                                </td>
                                <td width="25" align="center">
                                    18
                                </td>
                                <td width="25" align="center">
                                    34
                                </td>
                                <td width="25" align="center">
                                    49
                                </td>
                                <td width="25" align="center">
                                    78
                                </td>
                                <td width="25" align="center">
                                    135
                                </td>
                                <td width="25" align="center">
                                    157
                                </td>
                                <td width="25" align="center">
                                    236
                                </td>
                                <td width="25" align="center">
                                    256
                                </td>
                                <td width="25" align="center">
                                    289
                                </td>
                                <td width="25" align="center">
                                    368
                                </td>
                                <td width="25" align="center">
                                    469
                                </td>
                                <td width="25" align="center">
                                    678
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td width="70" height="22" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center">
                                    999
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    9
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    221
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    331
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    443
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    553
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    665
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    775
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    887
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    997
                                </td>
                                <td width="25" align="center">
                                    23
                                </td>
                                <td width="25" align="center">
                                    36
                                </td>
                                <td width="25" align="center">
                                    56
                                </td>
                                <td width="25" align="center">
                                    89
                                </td>
                                <td width="25" align="center">
                                    137
                                </td>
                                <td width="25" align="center">
                                    159
                                </td>
                                <td width="25" align="center">
                                    238
                                </td>
                                <td width="25" align="center">
                                    258
                                </td>
                                <td width="25" align="center">
                                    346
                                </td>
                                <td width="25" align="center">
                                    379
                                </td>
                                <td width="25" align="center">
                                    478
                                </td>
                                <td width="25" align="center">
                                    689
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td width="70" height="22" align="center" bgcolor="#fdfcdf">
                                    双点号码
                                </td>
                                <td width="25" align="center">
                                    5
                                </td>
                                <td colspan="9" align="center" bgcolor="#fdfcdf">
                                    45
                                </td>
                                <td colspan="12" align="center">
                                    60
                                </td>
                                <td width="70" align="center" bgcolor="#fdfcdf">
                                    120
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td width="70" height="22" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center">
                                    0
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    2
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    112
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    224
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    334
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    446
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    556
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    668
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    778
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    990
                                </td>
                                <td width="25" align="center">
                                    13
                                </td>
                                <td width="25" align="center">
                                    26
                                </td>
                                <td width="25" align="center">
                                    46
                                </td>
                                <td width="25" align="center">
                                    79
                                </td>
                                <td width="25" align="center">
                                    134
                                </td>
                                <td width="25" align="center">
                                    149
                                </td>
                                <td width="25" align="center">
                                    178
                                </td>
                                <td width="25" align="center">
                                    246
                                </td>
                                <td width="25" align="center">
                                    279
                                </td>
                                <td width="25" align="center">
                                    358
                                </td>
                                <td width="25" align="center">
                                    457
                                </td>
                                <td width="25" align="center">
                                    569
                                </td>
                                <td width="70" rowspan="5" align="center" bgcolor="#fdfcdf">
                                    双点号码共有 120 注，其中直选形式 5 注，组选 3 形式有 45 注，组选 6 形式有 60 注
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td width="70" height="22" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center">
                                    222
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    4
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    114
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    226
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    336
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    448
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    558
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    770
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    880
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    992
                                </td>
                                <td width="25" align="center">
                                    15
                                </td>
                                <td width="25" align="center">
                                    28
                                </td>
                                <td width="25" align="center">
                                    48
                                </td>
                                <td width="25" align="center">
                                    123
                                </td>
                                <td width="25" align="center">
                                    136
                                </td>
                                <td width="25" align="center">
                                    156
                                </td>
                                <td width="25" align="center">
                                    189
                                </td>
                                <td width="25" align="center">
                                    248
                                </td>
                                <td width="25" align="center">
                                    345
                                </td>
                                <td width="25" align="center">
                                    367
                                </td>
                                <td width="25" align="center">
                                    459
                                </td>
                                <td width="25" align="center">
                                    578
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td width="70" height="22" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center">
                                    444
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    6
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    116
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    228
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    338
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    550
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    660
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    772
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    882
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    994
                                </td>
                                <td width="25" align="center">
                                    17
                                </td>
                                <td width="25" align="center">
                                    35
                                </td>
                                <td width="25" align="center">
                                    57
                                </td>
                                <td width="25" align="center">
                                    125
                                </td>
                                <td width="25" align="center">
                                    138
                                </td>
                                <td width="25" align="center">
                                    158
                                </td>
                                <td width="25" align="center">
                                    235
                                </td>
                                <td width="25" align="center">
                                    257
                                </td>
                                <td width="25" align="center">
                                    347
                                </td>
                                <td width="25" align="center">
                                    369
                                </td>
                                <td width="25" align="center">
                                    468
                                </td>
                                <td width="25" align="center">
                                    589
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td width="70" height="22" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center">
                                    666
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    8
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    118
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    330
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    440
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    552
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    662
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    774
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    884
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    996
                                </td>
                                <td width="25" align="center">
                                    19
                                </td>
                                <td width="25" align="center">
                                    37
                                </td>
                                <td width="25" align="center">
                                    59
                                </td>
                                <td width="25" align="center">
                                    127
                                </td>
                                <td width="25" align="center">
                                    145
                                </td>
                                <td width="25" align="center">
                                    167
                                </td>
                                <td width="25" align="center">
                                    237
                                </td>
                                <td width="25" align="center">
                                    259
                                </td>
                                <td width="25" align="center">
                                    349
                                </td>
                                <td width="25" align="center">
                                    378
                                </td>
                                <td width="25" align="center">
                                    479
                                </td>
                                <td width="25" align="center">
                                    679
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td width="70" height="22" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center">
                                    888
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    110
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    220
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    332
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    442
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    554
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    664
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    776
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    886
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    998
                                </td>
                                <td width="25" align="center">
                                    24
                                </td>
                                <td width="25" align="center">
                                    39
                                </td>
                                <td width="25" align="center">
                                    68
                                </td>
                                <td width="25" align="center">
                                    129
                                </td>
                                <td width="25" align="center">
                                    147
                                </td>
                                <td width="25" align="center">
                                    169
                                </td>
                                <td width="25" align="center">
                                    239
                                </td>
                                <td width="25" align="center">
                                    268
                                </td>
                                <td width="25" align="center">
                                    356
                                </td>
                                <td width="25" align="center">
                                    389
                                </td>
                                <td width="25" align="center">
                                    567
                                </td>
                                <td width="25" align="center">
                                    789
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td width="70" height="22" align="center" bgcolor="#fdfcdf">
                                    双点注数
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    45
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center">
                                    60
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="70" align="center" bgcolor="#fdfcdf">
                                    120
                                </td>
                            </tr>
                            <tr align="center" bgcolor="#ffffff">
                                <td width="70" height="22" align="center" bgcolor="#fdfcdf">
                                    总注数
                                </td>
                                <td width="25" align="center">
                                    10
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                    90
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center" bgcolor="#fdfcdf">
                                </td>
                                <td width="25" align="center">
                                    120
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="25" align="center">
                                </td>
                                <td width="70" align="center" bgcolor="#fdfcdf">
                                    220
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" height="19" bgcolor="#FFCC00">
                    <br />
                    &nbsp;&nbsp;&nbsp; 在220注不同组合的号码中，单点和双点各占一半，并且10注直选的“豹子”中有5注单点和5注双点，90注“组选3” 中有45注双点号码，120注"组选6"号码也同样是单双点各占60注。单点的号码中包括全奇和两偶一奇两种形式，双点号码含有全偶和两奇一偶。<br>
                    根据对单点，双点，以及四种奇偶搭配形式的出号跟踪，当判断单点或双点出号可能性较大时，即可在相应的组合中进行选号了。<br>
                    </p>
                </td>
            </tr>
        </table>
        <div style="margin: 1px; text-align: left; font-size: 12px;">
            <table cellspacing="0" cellpadding="1" border="0" style="background-color: #cccccc;
                width: 100%; text-align: left;">
                <tr>
                    <td style="background-color: #EFEFEF; text-align: left;">
                        <a href="<%= _Site.Url %>" target="_blank"
                            style="text-decoration: none; padding-left: 10px;"><%=_Site.Name %>首页</a><a href="../../Home/Room/Buy.aspx?LotteryID=6&CoBuy=1"
                                target="_blank" style="padding-left: 5px; text-decoration: none; color: Red;">3D合买</a><a
                                    href="../../Home/Room/Buy.aspx?LotteryID=6" target="_blank" style="padding-left: 5px;
                                    text-decoration: none; color: Red;">3D代购</a> <a href='FC3D_ZHXT.aspx' target='mainFrame'>综合分布遗漏走势图</a> | <a href='FC3D_C3YS.aspx'
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
