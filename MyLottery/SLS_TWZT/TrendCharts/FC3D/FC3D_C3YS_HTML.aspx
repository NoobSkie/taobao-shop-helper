<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/FC3D/FC3D_C3YS_HTML.aspx.cs" inherits="Home_TrendCharts_FC3D_FC3D_C3YS_HTML" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries"
    TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>福彩3D 游戏除三余数号码分区表-彩票走势图表和数据分析－<%=_Site.Name %></title>
    <meta name="keywords" content="福彩3D 游戏除三余数号码分区表" />
    <meta name="description" content="福彩3D 游戏除三余数号码分区表、彩票走势图表和数据分析。" />
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
                        3D游戏除三余数号码分区表走势图</h1>
                </td>
                <td height="10" style="background-color: White">
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
        <table cellspacing="0" cellpadding="0" width="750" align="center" border="0">
            <tbody>
                <tr>
                    <td valign="top">
                        <table cellspacing="1" cellpadding="1" width="750" align="center" bgcolor="#000000"
                            border="0">
                            <tbody>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="25" height="22" rowspan="2" align="center" bgcolor="#ffcc66">
                                        &nbsp;
                                    </td>
                                    <td height="22" colspan="5" align="center" bgcolor="#ffcc66">
                                        <div align="center">
                                            除三余数 --A
                                        </div>
                                    </td>
                                    <td height="22" colspan="15" align="center" bgcolor="#ffcc66">
                                        <div align="center">
                                            除三余数 --B
                                        </div>
                                    </td>
                                    <td width="116" height="22" colspan="4" align="center" bgcolor="#ffcc66">
                                        <div align="center">
                                            除三余数 --C
                                        </div>
                                    </td>
                                </tr>
                                <tr bgcolor="#ffffff">
                                    <td width="25" height="22" align="center" bgcolor="#ffcc66">
                                        <div align="center">
                                            单选
                                        </div>
                                    </td>
                                    <td height="22" colspan="3" align="center" bgcolor="#ffcc66">
                                        <div align="center">
                                            组选 3
                                        </div>
                                    </td>
                                    <td width="25" height="22" align="center" bgcolor="#ffcc66">
                                        <div align="center">
                                            组<br>
                                            选<br>
                                            6
                                        </div>
                                    </td>
                                    <td height="22" colspan="7" align="center" bgcolor="#ffcc66">
                                        <div align="center">
                                            组选 3
                                        </div>
                                    </td>
                                    <td height="22" colspan="8" align="center" bgcolor="#ffcc66">
                                        <div align="center">
                                            组选 6
                                        </div>
                                    </td>
                                    <td height="22" colspan="4" align="center" bgcolor="#ffcc66">
                                        <div align="center">
                                            组选 6
                                        </div>
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="25" height="22" align="center">
                                        单点号码
                                    </td>
                                    <td width="25" height="22" align="center">
                                        111
                                    </td>
                                    <td width="25" height="22" align="center">
                                        3
                                    </td>
                                    <td width="25" height="22" align="center">
                                        339
                                    </td>
                                    <td width="25" height="22" align="center">
                                        669
                                    </td>
                                    <td width="25" height="22" align="center">
                                        36
                                    </td>
                                    <td width="25" height="22" align="center">
                                        1
                                    </td>
                                    <td width="25" height="22" align="center">
                                        113
                                    </td>
                                    <td width="25" height="22" align="center">
                                        227
                                    </td>
                                    <td width="25" height="22" align="center">
                                        443
                                    </td>
                                    <td width="25" height="22" align="center">
                                        557
                                    </td>
                                    <td width="25" height="22" align="center">
                                        773
                                    </td>
                                    <td width="25" height="22" align="center">
                                        887
                                    </td>
                                    <td width="25" height="22" align="center">
                                        14
                                    </td>
                                    <td width="25" height="22" align="center">
                                        34
                                    </td>
                                    <td width="25" height="22" align="center">
                                        58
                                    </td>
                                    <td width="25" height="22" align="center">
                                        137
                                    </td>
                                    <td width="25" height="22" align="center">
                                        179
                                    </td>
                                    <td width="25" height="22" align="center">
                                        256
                                    </td>
                                    <td width="25" height="22" align="center">
                                        359
                                    </td>
                                    <td width="25" height="22" align="center">
                                        469
                                    </td>
                                    <td width="25" height="22" align="center">
                                        12
                                    </td>
                                    <td width="25" height="22" align="center">
                                        45
                                    </td>
                                    <td width="25" height="22" align="center">
                                        168
                                    </td>
                                    <td width="25" height="22" align="center">
                                        257
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        333
                                    </td>
                                    <td width="25" height="22" align="center">
                                        9
                                    </td>
                                    <td width="25" height="22" align="center">
                                        441
                                    </td>
                                    <td width="25" height="22" align="center">
                                        771
                                    </td>
                                    <td width="25" height="22" align="center">
                                        69
                                    </td>
                                    <td width="25" height="22" align="center">
                                        5
                                    </td>
                                    <td width="25" height="22" align="center">
                                        115
                                    </td>
                                    <td width="25" height="22" align="center">
                                        229
                                    </td>
                                    <td width="25" height="22" align="center">
                                        445
                                    </td>
                                    <td width="25" height="22" align="center">
                                        559
                                    </td>
                                    <td width="25" height="22" align="center">
                                        775
                                    </td>
                                    <td width="25" height="22" align="center">
                                        889
                                    </td>
                                    <td width="25" height="22" align="center">
                                        16
                                    </td>
                                    <td width="25" height="22" align="center">
                                        38
                                    </td>
                                    <td width="25" height="22" align="center">
                                        67
                                    </td>
                                    <td width="25" height="22" align="center">
                                        139
                                    </td>
                                    <td width="25" height="22" align="center">
                                        236
                                    </td>
                                    <td width="25" height="22" align="center">
                                        269
                                    </td>
                                    <td width="25" height="22" align="center">
                                        368
                                    </td>
                                    <td width="25" height="22" align="center">
                                        478
                                    </td>
                                    <td width="25" height="22" align="center">
                                        18
                                    </td>
                                    <td width="25" height="22" align="center">
                                        78
                                    </td>
                                    <td width="25" height="22" align="center">
                                        234
                                    </td>
                                    <td width="25" height="22" align="center">
                                        456
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        555
                                    </td>
                                    <td width="25" height="22" align="center">
                                        117
                                    </td>
                                    <td width="25" height="22" align="center">
                                        447
                                    </td>
                                    <td width="25" height="22" align="center">
                                        885
                                    </td>
                                    <td width="25" height="22" align="center">
                                        258
                                    </td>
                                    <td width="25" height="22" align="center">
                                        7
                                    </td>
                                    <td width="25" height="22" align="center">
                                        119
                                    </td>
                                    <td width="25" height="22" align="center">
                                        331
                                    </td>
                                    <td width="25" height="22" align="center">
                                        449
                                    </td>
                                    <td width="25" height="22" align="center">
                                        661
                                    </td>
                                    <td width="25" height="22" align="center">
                                        779
                                    </td>
                                    <td width="25" height="22" align="center">
                                        991
                                    </td>
                                    <td width="25" height="22" align="center">
                                        23
                                    </td>
                                    <td width="25" height="22" align="center">
                                        47
                                    </td>
                                    <td width="25" height="22" align="center">
                                        89
                                    </td>
                                    <td width="25" height="22" align="center">
                                        146
                                    </td>
                                    <td width="25" height="22" align="center">
                                        238
                                    </td>
                                    <td width="25" height="22" align="center">
                                        278
                                    </td>
                                    <td width="25" height="22" align="center">
                                        379
                                    </td>
                                    <td width="25" height="22" align="center">
                                        568
                                    </td>
                                    <td width="25" height="22" align="center">
                                        27
                                    </td>
                                    <td width="25" height="22" align="center">
                                        126
                                    </td>
                                    <td width="25" height="22" align="center">
                                        249
                                    </td>
                                    <td width="25" height="22" align="center">
                                        489
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        777
                                    </td>
                                    <td width="25" height="22" align="center">
                                        225
                                    </td>
                                    <td width="25" height="22" align="center">
                                        663
                                    </td>
                                    <td width="25" height="22" align="center">
                                        993
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        221
                                    </td>
                                    <td width="25" height="22" align="center">
                                        335
                                    </td>
                                    <td width="25" height="22" align="center">
                                        551
                                    </td>
                                    <td width="25" height="22" align="center">
                                        665
                                    </td>
                                    <td width="25" height="22" align="center">
                                        881
                                    </td>
                                    <td width="25" height="22" align="center">
                                        995
                                    </td>
                                    <td width="25" height="22" align="center">
                                        25
                                    </td>
                                    <td width="25" height="22" align="center">
                                        49
                                    </td>
                                    <td width="25" height="22" align="center">
                                        124
                                    </td>
                                    <td width="25" height="22" align="center">
                                        148
                                    </td>
                                    <td width="25" height="22" align="center">
                                        245
                                    </td>
                                    <td width="25" height="22" align="center">
                                        289
                                    </td>
                                    <td width="25" height="22" align="center">
                                        458
                                    </td>
                                    <td width="25" height="22" align="center">
                                        689
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        135
                                    </td>
                                    <td width="25" height="22" align="center">
                                        267
                                    </td>
                                    <td width="25" height="22" align="center">
                                        579
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        999
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        223
                                    </td>
                                    <td width="25" height="22" align="center">
                                        337
                                    </td>
                                    <td width="25" height="22" align="center">
                                        553
                                    </td>
                                    <td width="25" height="22" align="center">
                                        667
                                    </td>
                                    <td width="25" height="22" align="center">
                                        883
                                    </td>
                                    <td width="25" height="22" align="center">
                                        997
                                    </td>
                                    <td width="25" height="22" align="center">
                                        29
                                    </td>
                                    <td width="25" height="22" align="center">
                                        56
                                    </td>
                                    <td width="25" height="22" align="center">
                                        128
                                    </td>
                                    <td width="25" height="22" align="center">
                                        157
                                    </td>
                                    <td width="25" height="22" align="center">
                                        247
                                    </td>
                                    <td width="25" height="22" align="center">
                                        346
                                    </td>
                                    <td width="25" height="22" align="center">
                                        467
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        159
                                    </td>
                                    <td width="25" height="22" align="center">
                                        348
                                    </td>
                                    <td width="25" height="22" align="center">
                                        678
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="25" height="22" align="center">
                                        单点注数
                                    </td>
                                    <td width="25" height="22" align="center">
                                        5
                                    </td>
                                    <td width="25" height="22" align="center">
                                        12
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        3
                                    </td>
                                    <td width="25" height="22" align="center">
                                        33
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        39
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        18
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="25" height="22" align="center">
                                        双点号码
                                    </td>
                                    <td width="25" height="22" align="center">
                                        0
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        110
                                    </td>
                                    <td width="25" height="22" align="center">
                                        224
                                    </td>
                                    <td width="25" height="22" align="center">
                                        440
                                    </td>
                                    <td width="25" height="22" align="center">
                                        554
                                    </td>
                                    <td width="25" height="22" align="center">
                                        770
                                    </td>
                                    <td width="25" height="22" align="center">
                                        884
                                    </td>
                                    <td width="25" height="22" align="center">
                                        13
                                    </td>
                                    <td width="25" height="22" align="center">
                                        35
                                    </td>
                                    <td width="25" height="22" align="center">
                                        79
                                    </td>
                                    <td width="25" height="22" align="center">
                                        145
                                    </td>
                                    <td width="25" height="22" align="center">
                                        178
                                    </td>
                                    <td width="25" height="22" align="center">
                                        259
                                    </td>
                                    <td width="25" height="22" align="center">
                                        358
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        57
                                    </td>
                                    <td width="25" height="22" align="center">
                                        189
                                    </td>
                                    <td width="25" height="22" align="center">
                                        378
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        222
                                    </td>
                                    <td width="25" height="22" align="center">
                                        6
                                    </td>
                                    <td width="25" height="22" align="center">
                                        336
                                    </td>
                                    <td width="25" height="22" align="center">
                                        774
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        112
                                    </td>
                                    <td width="25" height="22" align="center">
                                        226
                                    </td>
                                    <td width="25" height="22" align="center">
                                        442
                                    </td>
                                    <td width="25" height="22" align="center">
                                        556
                                    </td>
                                    <td width="25" height="22" align="center">
                                        772
                                    </td>
                                    <td width="25" height="22" align="center">
                                        886
                                    </td>
                                    <td width="25" height="22" align="center">
                                        17
                                    </td>
                                    <td width="25" height="22" align="center">
                                        37
                                    </td>
                                    <td width="25" height="22" align="center">
                                        125
                                    </td>
                                    <td width="25" height="22" align="center">
                                        149
                                    </td>
                                    <td width="25" height="22" align="center">
                                        235
                                    </td>
                                    <td width="25" height="22" align="center">
                                        268
                                    </td>
                                    <td width="25" height="22" align="center">
                                        367
                                    </td>
                                    <td width="25" height="22" align="center">
                                        569
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        123
                                    </td>
                                    <td width="25" height="22" align="center">
                                        237
                                    </td>
                                    <td width="25" height="22" align="center">
                                        459
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        444
                                    </td>
                                    <td width="25" height="22" align="center">
                                        114
                                    </td>
                                    <td width="25" height="22" align="center">
                                        552
                                    </td>
                                    <td width="25" height="22" align="center">
                                        882
                                    </td>
                                    <td width="25" height="22" align="center">
                                        39
                                    </td>
                                    <td width="25" height="22" align="center">
                                        2
                                    </td>
                                    <td width="25" height="22" align="center">
                                        116
                                    </td>
                                    <td width="25" height="22" align="center">
                                        332
                                    </td>
                                    <td width="25" height="22" align="center">
                                        446
                                    </td>
                                    <td width="25" height="22" align="center">
                                        662
                                    </td>
                                    <td width="25" height="22" align="center">
                                        776
                                    </td>
                                    <td width="25" height="22" align="center">
                                        992
                                    </td>
                                    <td width="25" height="22" align="center">
                                        19
                                    </td>
                                    <td width="25" height="22" align="center">
                                        46
                                    </td>
                                    <td width="25" height="22" align="center">
                                        127
                                    </td>
                                    <td width="25" height="22" align="center">
                                        158
                                    </td>
                                    <td width="25" height="22" align="center">
                                        239
                                    </td>
                                    <td width="25" height="22" align="center">
                                        347
                                    </td>
                                    <td width="25" height="22" align="center">
                                        389
                                    </td>
                                    <td width="25" height="22" align="center">
                                        578
                                    </td>
                                    <td width="25" height="22" align="center">
                                        15
                                    </td>
                                    <td width="25" height="22" align="center">
                                        129
                                    </td>
                                    <td width="25" height="22" align="center">
                                        246
                                    </td>
                                    <td width="25" height="22" align="center">
                                        468
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        666
                                    </td>
                                    <td width="25" height="22" align="center">
                                        228
                                    </td>
                                    <td width="25" height="22" align="center">
                                        558
                                    </td>
                                    <td width="25" height="22" align="center">
                                        990
                                    </td>
                                    <td width="25" height="22" align="center">
                                        147
                                    </td>
                                    <td width="25" height="22" align="center">
                                        4
                                    </td>
                                    <td width="25" height="22" align="center">
                                        118
                                    </td>
                                    <td width="25" height="22" align="center">
                                        334
                                    </td>
                                    <td width="25" height="22" align="center">
                                        448
                                    </td>
                                    <td width="25" height="22" align="center">
                                        664
                                    </td>
                                    <td width="25" height="22" align="center">
                                        778
                                    </td>
                                    <td width="25" height="22" align="center">
                                        994
                                    </td>
                                    <td width="25" height="22" align="center">
                                        26
                                    </td>
                                    <td width="25" height="22" align="center">
                                        59
                                    </td>
                                    <td width="25" height="22" align="center">
                                        134
                                    </td>
                                    <td width="25" height="22" align="center">
                                        167
                                    </td>
                                    <td width="25" height="22" align="center">
                                        248
                                    </td>
                                    <td width="25" height="22" align="center">
                                        349
                                    </td>
                                    <td width="25" height="22" align="center">
                                        457
                                    </td>
                                    <td width="25" height="22" align="center">
                                        589
                                    </td>
                                    <td width="25" height="22" align="center">
                                        24
                                    </td>
                                    <td width="25" height="22" align="center">
                                        138
                                    </td>
                                    <td width="25" height="22" align="center">
                                        279
                                    </td>
                                    <td width="25" height="22" align="center">
                                        567
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        888
                                    </td>
                                    <td width="25" height="22" align="center">
                                        330
                                    </td>
                                    <td width="25" height="22" align="center">
                                        660
                                    </td>
                                    <td width="25" height="22" align="center">
                                        996
                                    </td>
                                    <td width="25" height="22" align="center">
                                        369
                                    </td>
                                    <td width="25" height="22" align="center">
                                        8
                                    </td>
                                    <td width="25" height="22" align="center">
                                        220
                                    </td>
                                    <td width="25" height="22" align="center">
                                        338
                                    </td>
                                    <td width="25" height="22" align="center">
                                        550
                                    </td>
                                    <td width="25" height="22" align="center">
                                        668
                                    </td>
                                    <td width="25" height="22" align="center">
                                        880
                                    </td>
                                    <td width="25" height="22" align="center">
                                        998
                                    </td>
                                    <td width="25" height="22" align="center">
                                        28
                                    </td>
                                    <td width="25" height="22" align="center">
                                        68
                                    </td>
                                    <td width="25" height="22" align="center">
                                        136
                                    </td>
                                    <td width="25" height="22" align="center">
                                        169
                                    </td>
                                    <td width="25" height="22" align="center">
                                        257
                                    </td>
                                    <td width="25" height="22" align="center">
                                        356
                                    </td>
                                    <td width="25" height="22" align="center">
                                        479
                                    </td>
                                    <td width="25" height="22" align="center">
                                        679
                                    </td>
                                    <td width="25" height="22" align="center">
                                        48
                                    </td>
                                    <td width="25" height="22" align="center">
                                        156
                                    </td>
                                    <td width="25" height="22" align="center">
                                        345
                                    </td>
                                    <td width="25" height="22" align="center">
                                        789
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="25" height="22" align="center">
                                        双点注数
                                    </td>
                                    <td width="25" height="22" align="center">
                                        5
                                    </td>
                                    <td width="25" height="22" align="center">
                                        12
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        3
                                    </td>
                                    <td width="25" height="22" align="center">
                                        33
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        39
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        18
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="25" height="22" align="center">
                                        类型注数
                                    </td>
                                    <td width="25" height="22" align="center">
                                        10
                                    </td>
                                    <td width="25" height="22" align="center">
                                        24
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        6
                                    </td>
                                    <td width="25" height="22" align="center">
                                        66
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        78
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        36
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="25" height="22" align="center">
                                        总注数
                                    </td>
                                    <td width="25" height="22" align="center">
                                        40
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        144
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                        36
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                    <td width="25" height="22" align="center">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="19" bgcolor="#FFCC00">
                        <p>
                            &nbsp;&nbsp;&nbsp; 将任一数字除以3，其余数被称为“除三余数”，共有三个不同的"余数":余0，余1和余2数。在0-9十个数字当中除3余0数有3，6，9，除3余1数及余2数分别为1，4，7和2，5，8。当三个中奖号码均为同一余数组成时，被称为除三余数的“A型”，比如333，228，369等;当三个号码中有两个数字为同一余数时，被成称为除三余数的"B型"，如226，236等;而当三个号码分属三个不同余数时，就被称为除三余数的"C型"。<br>
                            根据对除三余数A，B，C型的出号跟踪及相连中出情况的分析，当判断某一形式中出希望较大时，即可在相应组合中进行选号了。</p>
                    </td>
                </tr>
            </tbody>
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
