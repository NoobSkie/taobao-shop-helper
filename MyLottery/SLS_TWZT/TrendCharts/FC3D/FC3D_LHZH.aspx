<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/FC3D/FC3D_LHZH.aspx.cs" inherits="Home_TrendCharts_FC3D_FC3D_LHZH" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>福彩3D 游戏连号组合分区表-彩票走势图表和数据分析－<%=_Site.Name %></title>
<meta name="keywords" content="福彩3D 游戏连号组合分区表" />
<meta name="description" content="福彩3D 游戏连号组合分区表、彩票走势图表和数据分析。" />

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
                    <h1 class="td" style="font-weight: bold; font-size: 18px;display:inline;">3D游戏连号组合分区表走势图</h1>
                </td>
                <td height="10px" style="background-color: White">
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
                    <td style="background-color: #EFEFEF; text-align: left;">
                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lbAd" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbAd1" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbAd2" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin: 2px">
        </div>
        <table cellspacing="0" cellpadding="0" width="750" align="center" border="0">
            <tbody>
                <tr>
                    <td valign="top">
                        <table cellspacing="1" cellpadding="1" width="750" align="center" bgcolor="#000000"
                            border="0">
                            <tbody>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="70" height="20" rowspan="2" bgcolor="#ffcc66">
                                        &nbsp;
                                    </td>
                                    <td height="20" colspan="9" align="center" bgcolor="#ffcc66">
                                        含 连 号
                                    </td>
                                    <td height="20" colspan="13" align="center" bgcolor="#ffcc66">
                                        不 含 连 号
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td height="20" colspan="2" align="center" bgcolor="#ffcc66">
                                        组选 3
                                    </td>
                                    <td height="20" colspan="7" align="center" bgcolor="#ffcc66">
                                        组 选 6
                                    </td>
                                    <td width="30" height="20" align="center" bgcolor="#ffcc66">
                                        直选
                                    </td>
                                    <td height="20" colspan="7" align="center" bgcolor="#ffcc66">
                                        组 选 3
                                    </td>
                                    <td height="20" colspan="5" align="center" bgcolor="#ffcc66">
                                        组 选 6
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="70">
                                        单点号码
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        001
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        445
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        012
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        029
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        067
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        126
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        245
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        346
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        478
                                    </td>
                                    <td width="30" align="center">
                                        111
                                    </td>
                                    <td width="30" align="center">
                                        003
                                    </td>
                                    <td width="30" align="center">
                                        117
                                    </td>
                                    <td width="30" align="center">
                                        331
                                    </td>
                                    <td width="30" align="center">
                                        447
                                    </td>
                                    <td width="30" align="center">
                                        559
                                    </td>
                                    <td width="30" align="center">
                                        773
                                    </td>
                                    <td width="30" align="center">
                                        885
                                    </td>
                                    <td width="30" align="center">
                                        025
                                    </td>
                                    <td width="30" align="center">
                                        058
                                    </td>
                                    <td width="30" align="center">
                                        148
                                    </td>
                                    <td width="30" align="center">
                                        247
                                    </td>
                                    <td width="30" align="center">
                                        359
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="70">
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        009
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        665
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        014
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        034
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        069
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        128
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        256
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        348
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        489
                                    </td>
                                    <td width="30" align="center">
                                        333
                                    </td>
                                    <td width="30" align="center">
                                        005
                                    </td>
                                    <td width="30" align="center">
                                        119
                                    </td>
                                    <td width="30" align="center">
                                        335
                                    </td>
                                    <td width="30" align="center">
                                        449
                                    </td>
                                    <td width="30" align="center">
                                        661
                                    </td>
                                    <td width="30" align="center">
                                        775
                                    </td>
                                    <td width="30" align="center">
                                        991
                                    </td>
                                    <td width="30" align="center">
                                        027
                                    </td>
                                    <td width="30" align="center">
                                        135
                                    </td>
                                    <td width="30" align="center">
                                        157
                                    </td>
                                    <td width="30" align="center">
                                        249
                                    </td>
                                    <td width="30" align="center">
                                        368
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="70">
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        221
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        667
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        016
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        045
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        078
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        234
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        267
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        456
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        568
                                    </td>
                                    <td width="30" align="center">
                                        555
                                    </td>
                                    <td width="30" align="center">
                                        007
                                    </td>
                                    <td width="30" align="center">
                                        225
                                    </td>
                                    <td width="30" align="center">
                                        337
                                    </td>
                                    <td width="30" align="center">
                                        551
                                    </td>
                                    <td width="30" align="center">
                                        663
                                    </td>
                                    <td width="30" align="center">
                                        779
                                    </td>
                                    <td width="30" align="center">
                                        993
                                    </td>
                                    <td width="30" align="center">
                                        036
                                    </td>
                                    <td width="30" align="center">
                                        137
                                    </td>
                                    <td width="30" align="center">
                                        159
                                    </td>
                                    <td width="30" align="center">
                                        258
                                    </td>
                                    <td width="30" align="center">
                                        379
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="70">
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        223
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        887
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        018
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        049
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        089
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        236
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        278
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        458
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        678
                                    </td>
                                    <td width="30" align="center">
                                        777
                                    </td>
                                    <td width="30" align="center">
                                        113
                                    </td>
                                    <td width="30" align="center">
                                        227
                                    </td>
                                    <td width="30" align="center">
                                        339
                                    </td>
                                    <td width="30" align="center">
                                        553
                                    </td>
                                    <td width="30" align="center">
                                        669
                                    </td>
                                    <td width="30" align="center">
                                        881
                                    </td>
                                    <td width="30" align="center">
                                        995
                                    </td>
                                    <td width="30" align="center">
                                        038
                                    </td>
                                    <td width="30" align="center">
                                        139
                                    </td>
                                    <td width="30" align="center">
                                        168
                                    </td>
                                    <td width="30" align="center">
                                        269
                                    </td>
                                    <td width="30" align="center">
                                        469
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="70">
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        443
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        889
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        023
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        056
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        124
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        238
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        289
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        467
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        689
                                    </td>
                                    <td width="30" align="center">
                                        999
                                    </td>
                                    <td width="30" align="center">
                                        115
                                    </td>
                                    <td width="30" align="center">
                                        229
                                    </td>
                                    <td width="30" align="center">
                                        441
                                    </td>
                                    <td width="30" align="center">
                                        557
                                    </td>
                                    <td width="30" align="center">
                                        771
                                    </td>
                                    <td width="30" align="center">
                                        883
                                    </td>
                                    <td width="30" align="center">
                                        997
                                    </td>
                                    <td width="30" align="center">
                                        047
                                    </td>
                                    <td width="30" align="center">
                                        146
                                    </td>
                                    <td width="30" align="center">
                                        179
                                    </td>
                                    <td width="30" align="center">
                                        357
                                    </td>
                                    <td width="30" align="center">
                                        579
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="70" height="16">
                                        单点注数
                                    </td>
                                    <td width="30" height="16" align="center" bgcolor="#fdfcdf">
                                        10
                                    </td>
                                    <td width="30" height="16" align="center" bgcolor="#fdfcdf">
                                    </td>
                                    <td height="16" colspan="7" align="center" bgcolor="#fdfcdf">
                                        <div align="center">
                                            35
                                        </div>
                                    </td>
                                    <td width="30" height="16" align="center">
                                        5
                                    </td>
                                    <td height="16" colspan="7" align="center">
                                        <div align="center">
                                            35
                                        </div>
                                    </td>
                                    <td height="16" colspan="5" align="center">
                                        <div align="center">
                                            25
                                        </div>
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="70">
                                        双点号码
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        110
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        556
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        013
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        059
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        129
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        178
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        345
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        378
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        569
                                    </td>
                                    <td width="30" align="center">
                                        000
                                    </td>
                                    <td width="30" align="center">
                                        002
                                    </td>
                                    <td width="30" align="center">
                                        116
                                    </td>
                                    <td width="30" align="center">
                                        228
                                    </td>
                                    <td width="30" align="center">
                                        442
                                    </td>
                                    <td width="30" align="center">
                                        558
                                    </td>
                                    <td width="30" align="center">
                                        770
                                    </td>
                                    <td width="30" align="center">
                                        884
                                    </td>
                                    <td width="30" align="center">
                                        024
                                    </td>
                                    <td width="30" align="center">
                                        046
                                    </td>
                                    <td width="30" align="center">
                                        138
                                    </td>
                                    <td width="30" align="center">
                                        246
                                    </td>
                                    <td width="30" align="center">
                                        279
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="70">
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        112
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        776
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        015
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        079
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        134
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        189
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        347
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        389
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        578
                                    </td>
                                    <td width="30" align="center">
                                        222
                                    </td>
                                    <td width="30" align="center">
                                        004
                                    </td>
                                    <td width="30" align="center">
                                        118
                                    </td>
                                    <td width="30" align="center">
                                        330
                                    </td>
                                    <td width="30" align="center">
                                        446
                                    </td>
                                    <td width="30" align="center">
                                        660
                                    </td>
                                    <td width="30" align="center">
                                        772
                                    </td>
                                    <td width="30" align="center">
                                        886
                                    </td>
                                    <td width="30" align="center">
                                        026
                                    </td>
                                    <td width="30" align="center">
                                        048
                                    </td>
                                    <td width="30" align="center">
                                        147
                                    </td>
                                    <td width="30" align="center">
                                        248
                                    </td>
                                    <td width="30" align="center">
                                        358
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="70">
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        332
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        778
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        017
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        123
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        145
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        235
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        349
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        457
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        589
                                    </td>
                                    <td width="30" align="center">
                                        444
                                    </td>
                                    <td width="30" align="center">
                                        006
                                    </td>
                                    <td width="30" align="center">
                                        220
                                    </td>
                                    <td width="30" align="center">
                                        336
                                    </td>
                                    <td width="30" align="center">
                                        448
                                    </td>
                                    <td width="30" align="center">
                                        662
                                    </td>
                                    <td width="30" align="center">
                                        774
                                    </td>
                                    <td width="30" align="center">
                                        992
                                    </td>
                                    <td width="30" align="center">
                                        028
                                    </td>
                                    <td width="30" align="center">
                                        057
                                    </td>
                                    <td width="30" align="center">
                                        149
                                    </td>
                                    <td width="30" align="center">
                                        257
                                    </td>
                                    <td width="30" align="center">
                                        369
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="70">
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        334
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        990
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        019
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        125
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        156
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        237
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        356
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        459
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        679
                                    </td>
                                    <td width="30" align="center">
                                        666
                                    </td>
                                    <td width="30" align="center">
                                        008
                                    </td>
                                    <td width="30" align="center">
                                        224
                                    </td>
                                    <td width="30" align="center">
                                        338
                                    </td>
                                    <td width="30" align="center">
                                        550
                                    </td>
                                    <td width="30" align="center">
                                        664
                                    </td>
                                    <td width="30" align="center">
                                        880
                                    </td>
                                    <td width="30" align="center">
                                        994
                                    </td>
                                    <td width="30" align="center">
                                        035
                                    </td>
                                    <td width="30" align="center">
                                        068
                                    </td>
                                    <td width="30" align="center">
                                        158
                                    </td>
                                    <td width="30" align="center">
                                        259
                                    </td>
                                    <td width="30" align="center">
                                        468
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="70">
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        554
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        998
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        039
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        127
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        167
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        239
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        367
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        567
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        789
                                    </td>
                                    <td width="30" align="center">
                                        888
                                    </td>
                                    <td width="30" align="center">
                                        114
                                    </td>
                                    <td width="30" align="center">
                                        226
                                    </td>
                                    <td width="30" align="center">
                                        440
                                    </td>
                                    <td width="30" align="center">
                                        552
                                    </td>
                                    <td width="30" align="center">
                                        668
                                    </td>
                                    <td width="30" align="center">
                                        882
                                    </td>
                                    <td width="30" align="center">
                                        996
                                    </td>
                                    <td width="30" align="center">
                                        037
                                    </td>
                                    <td width="30" align="center">
                                        136
                                    </td>
                                    <td width="30" align="center">
                                        169
                                    </td>
                                    <td width="30" align="center">
                                        268
                                    </td>
                                    <td width="30" align="center">
                                        479
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="70">
                                        双点注数
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                        10
                                    </td>
                                    <td width="30" align="center" bgcolor="#fdfcdf">
                                    </td>
                                    <td colspan="7" align="center" bgcolor="#fdfcdf">
                                        <div align="center">
                                            35
                                        </div>
                                    </td>
                                    <td width="30" align="center">
                                        5
                                    </td>
                                    <td colspan="7" align="center">
                                        <div align="center">
                                            35
                                        </div>
                                    </td>
                                    <td colspan="5" align="center">
                                        <div align="center">
                                            25
                                        </div>
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="70">
                                        类型注数
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                        20
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                        70
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                    </td>
                                    <td width="30">
                                        10
                                    </td>
                                    <td width="30">
                                        70
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                </tr>
                                <tr align="center" bgcolor="#ffffff">
                                    <td width="70">
                                        总注数
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                        90
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                    </td>
                                    <td width="30" bgcolor="#fdfcdf">
                                    </td>
                                    <td width="30">
                                        130
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                    <td width="30">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="19" bgcolor="#FFCC00">
                        <br />
                        <p>
                            &nbsp;&nbsp;&nbsp; 连号即中奖号码中有两个或三个相连的号码，比如256、345等等。三连号又俗称为“拖拉机”，如果将0-9十个号码由小到大首尾相连，就会出现十注三连的“拖拉机”号码：012、123、234、345、456、567、678、789、890、901。连号共有90注，其中包含有20注“组选3”和70注“组选6”号码，其单，双点的比率是相同的。而不含连号的130注号码的单，双点也是各占一半。<br>
                            根据得连号组合中奖情况的跟踪及连号组合的单，双点，“组选3”、“组选6”出号状况的分析，在判断是否有连号情况时，就可在相应组合中进行选号了。<br>
                        </p>
                    </td>
                </tr>
            </tbody>
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
