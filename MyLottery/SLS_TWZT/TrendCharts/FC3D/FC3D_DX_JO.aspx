<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/FC3D/FC3D_DX_JO.aspx.cs" inherits="Home_TrendCharts_FC3D_FC3D_DX_JO" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries"
    TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>福彩3D 游戏大小分区- 奇偶分区表-彩票走势图表和数据分析－<%=_Site.Name %></title>
    <meta name="keywords" content="福彩3D 游戏大小分区 - 奇偶分区表" />
    <meta name="description" content="福彩3D 游戏大小分区 - 奇偶分区表、彩票走势图表和数据分析。" />
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
                <td class="td" align="left">
                    <h1 class="td" style="font-weight: bold; font-size: 18px;display:inline;">
                        3D游戏大小分区 — 奇偶分区表走势图</h1>
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
        <table width="987" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#666666">
            <tr>
                <td width="100%" align="center" valign="top">
                    <table width="769" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="10" colspan="2" bgcolor="#FFFFFF">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                                <table cellspacing="1" cellpadding="1" bgcolor="#000000" width="987" align="center">
                                    <tbody>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td width="100" bgcolor="#FFCC00" height="30">
                                                大小类型
                                            </td>
                                            <td colspan="4" bgcolor="#FFCC00">
                                                全大
                                            </td>
                                            <td colspan="8" bgcolor="#FFCC00">
                                                两大一小
                                            </td>
                                            <td colspan="8" bgcolor="#FFCC00">
                                                两小一大
                                            </td>
                                            <td colspan="4" bgcolor="#FFCC00">
                                                全小
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td>
                                                形式
                                            </td>
                                            <td width="44" bgcolor="#fffde1">
                                                直选
                                            </td>
                                            <td bgcolor="#fffde1" colspan="2">
                                                组选 3
                                            </td>
                                            <td width="63" bgcolor="#fffde1">
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
                                            <td width="44">
                                                直选
                                            </td>
                                            <td colspan="2">
                                                组选 3
                                            </td>
                                            <td width="52">
                                                组 6
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td rowspan="10">
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
                                            <td align="center" width="30" bgcolor="#fffde1">
                                                555
                                            </td>
                                            <td align="center" width="30" bgcolor="#fffde1">
                                                556
                                            </td>
                                            <td align="center" width="30" bgcolor="#fffde1">
                                                778
                                            </td>
                                            <td align="center" width="30" bgcolor="#fffde1">
                                                567
                                            </td>
                                            <td width="30" bgcolor="#fde6ff">
                                                550
                                            </td>
                                            <td width="30" bgcolor="#fde6ff">
                                                770
                                            </td>
                                            <td width="30" bgcolor="#fde6ff">
                                                990
                                            </td>
                                            <td width="30" bgcolor="#fde6ff">
                                                056
                                            </td>
                                            <td width="30" bgcolor="#fde6ff">
                                                156
                                            </td>
                                            <td width="30" bgcolor="#fde6ff">
                                                256
                                            </td>
                                            <td width="30" bgcolor="#fde6ff">
                                                356
                                            </td>
                                            <td width="30" bgcolor="#fde6ff">
                                                456
                                            </td>
                                            <td width="30" bgcolor="#e8ffe8">
                                                005
                                            </td>
                                            <td width="30" bgcolor="#e8ffe8">
                                                225
                                            </td>
                                            <td width="30" bgcolor="#e8ffe8">
                                                445
                                            </td>
                                            <td width="30" bgcolor="#e8ffe8">
                                                015
                                            </td>
                                            <td width="30" bgcolor="#e8ffe8">
                                                035
                                            </td>
                                            <td width="30" bgcolor="#e8ffe8">
                                                125
                                            </td>
                                            <td width="30" bgcolor="#e8ffe8">
                                                145
                                            </td>
                                            <td width="30" bgcolor="#e8ffe8">
                                                245
                                            </td>
                                            <td width="30" bgcolor="#fffdec">
                                                000
                                            </td>
                                            <td width="30" bgcolor="#fffdec">
                                                001
                                            </td>
                                            <td width="30" bgcolor="#fffdec">
                                                223
                                            </td>
                                            <td width="30" bgcolor="#fffdec">
                                                012
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td align="center" bgcolor="#fffde1">
                                                666
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                557
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                779
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                568
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                551
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                771
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                991
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                057
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                157
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                257
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                357
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                457
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                006
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                226
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                446
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                016
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                036
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                126
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                146
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                246
                                            </td>
                                            <td bgcolor="#fffdec">
                                                111
                                            </td>
                                            <td bgcolor="#fffdec">
                                                002
                                            </td>
                                            <td bgcolor="#fffdec">
                                                224
                                            </td>
                                            <td bgcolor="#fffdec">
                                                013
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td align="center" bgcolor="#fffde1">
                                                777
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                558
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                885
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                569
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                552
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                772
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                992
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                058
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                158
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                258
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                358
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                458
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                007
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                227
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                447
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                017
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                037
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                127
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                147
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                247
                                            </td>
                                            <td bgcolor="#fffdec">
                                                222
                                            </td>
                                            <td bgcolor="#fffdec">
                                                003
                                            </td>
                                            <td bgcolor="#fffdec">
                                                330
                                            </td>
                                            <td bgcolor="#fffdec">
                                                014
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td align="center" bgcolor="#fffde1">
                                                888
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                559
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                886
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                578
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                553
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                773
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                993
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                059
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                159
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                259
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                359
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                459
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                008
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                228
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                448
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                018
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                038
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                128
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                148
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                248
                                            </td>
                                            <td bgcolor="#fffdec">
                                                333
                                            </td>
                                            <td bgcolor="#fffdec">
                                                004
                                            </td>
                                            <td bgcolor="#fffdec">
                                                331
                                            </td>
                                            <td bgcolor="#fffdec">
                                                023
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td align="center" bgcolor="#fffde1">
                                                999
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                665
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                887
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                579
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                554
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                774
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                994
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                067
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                167
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                267
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                367
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                467
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                009
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                229
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                449
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                019
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                039
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                129
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                149
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                249
                                            </td>
                                            <td bgcolor="#fffdec">
                                                444
                                            </td>
                                            <td bgcolor="#fffdec">
                                                110
                                            </td>
                                            <td bgcolor="#fffdec">
                                                332
                                            </td>
                                            <td bgcolor="#fffdec">
                                                024
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td align="center" bgcolor="#fffde1">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                667
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                889
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                589
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                660
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                880
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                &nbsp;
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                068
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                168
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                268
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                368
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                468
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                115
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                335
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                025
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                045
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                135
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                235
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                345
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                            <td bgcolor="#fffdec">
                                                112
                                            </td>
                                            <td bgcolor="#fffdec">
                                                334
                                            </td>
                                            <td bgcolor="#fffdec">
                                                034
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td align="center" bgcolor="#fffde1">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                668
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                995
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                678
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                661
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                881
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                &nbsp;
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                069
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                169
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                269
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                369
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                469
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                116
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                336
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                026
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                046
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                136
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                236
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                346
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                            <td bgcolor="#fffdec">
                                                113
                                            </td>
                                            <td bgcolor="#fffdec">
                                                440
                                            </td>
                                            <td bgcolor="#fffdec">
                                                123
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td align="center" bgcolor="#fffde1">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                669
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                996
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                679
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                662
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                882
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                &nbsp;
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                078
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                178
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                278
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                378
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                478
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                117
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                337
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                027
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                047
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                137
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                237
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                347
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                            <td bgcolor="#fffdec">
                                                114
                                            </td>
                                            <td bgcolor="#fffdec">
                                                441
                                            </td>
                                            <td bgcolor="#fffdec">
                                                124
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td align="center" bgcolor="#fffde1">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                775
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                997
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                689
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                663
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                883
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                &nbsp;
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                079
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                179
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                279
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                379
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                479
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                118
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                338
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                028
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                048
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                138
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                238
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                348
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                            <td bgcolor="#fffdec">
                                                220
                                            </td>
                                            <td bgcolor="#fffdec">
                                                442
                                            </td>
                                            <td bgcolor="#fffdec">
                                                134
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td align="center" bgcolor="#fffde1">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                776
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                998
                                            </td>
                                            <td align="center" bgcolor="#fffde1">
                                                789
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                664
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                884
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                &nbsp;
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                089
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                189
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                289
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                389
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                489
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                119
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                339
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                029
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                049
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                139
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                239
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                349
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                            <td bgcolor="#fffdec">
                                                221
                                            </td>
                                            <td bgcolor="#fffdec">
                                                443
                                            </td>
                                            <td bgcolor="#fffdec">
                                                234
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td>
                                                奇偶
                                            </td>
                                            <td bgcolor="#ffffff">
                                                全奇
                                            </td>
                                            <td bgcolor="#ffffff">
                                                两奇
                                                <br>
                                                一偶
                                            </td>
                                            <td bgcolor="#ffffff">
                                                两偶
                                                <br>
                                                一奇
                                            </td>
                                            <td bgcolor="#ffffff">
                                                全偶
                                            </td>
                                            <td bgcolor="#ffffff">
                                                全奇
                                            </td>
                                            <td bgcolor="#ffffff" colspan="3">
                                                两奇一偶
                                            </td>
                                            <td bgcolor="#ffffff" colspan="3">
                                                两偶一奇
                                            </td>
                                            <td bgcolor="#ffffff">
                                                全偶
                                            </td>
                                            <td bgcolor="#ffffff">
                                                全奇
                                            </td>
                                            <td bgcolor="#ffffff" colspan="3">
                                                两奇一偶
                                            </td>
                                            <td bgcolor="#ffffff" colspan="3">
                                                两偶一奇
                                            </td>
                                            <td bgcolor="#ffffff">
                                                全偶
                                            </td>
                                            <td bgcolor="#ffffff">
                                                全奇
                                            </td>
                                            <td bgcolor="#ffffff">
                                                两奇
                                                <br>
                                                一偶
                                            </td>
                                            <td bgcolor="#ffffff">
                                                两偶
                                                <br>
                                                一奇
                                            </td>
                                            <td bgcolor="#ffffff">
                                                全偶
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
                                            <td bgcolor="#fffde1">
                                                555
                                            </td>
                                            <td bgcolor="#fffde1">
                                                556
                                            </td>
                                            <td bgcolor="#fffde1">
                                                665
                                            </td>
                                            <td bgcolor="#fffde1">
                                                666
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                551
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                550
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                059
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                279
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                661
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                168
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                467
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                660
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                115
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                116
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                125
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                239
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                005
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                018
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                128
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                006
                                            </td>
                                            <td bgcolor="#fffdec">
                                                111
                                            </td>
                                            <td bgcolor="#fffdec">
                                                110
                                            </td>
                                            <td bgcolor="#fffdec">
                                                001
                                            </td>
                                            <td bgcolor="#fffdec">
                                                000
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td bgcolor="#fffde1">
                                                777
                                            </td>
                                            <td bgcolor="#fffde1">
                                                558
                                            </td>
                                            <td bgcolor="#fffde1">
                                                667
                                            </td>
                                            <td bgcolor="#fffde1">
                                                888
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                553
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                552
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                079
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                356
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                663
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                256
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                469
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                662
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                117
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                118
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                127
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                345
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                007
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                025
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                146
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                008
                                            </td>
                                            <td bgcolor="#fffdec">
                                                333
                                            </td>
                                            <td bgcolor="#fffdec">
                                                112
                                            </td>
                                            <td bgcolor="#fffdec">
                                                003
                                            </td>
                                            <td bgcolor="#fffdec">
                                                222
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td bgcolor="#fffde1">
                                                999
                                            </td>
                                            <td bgcolor="#fffde1">
                                                776
                                            </td>
                                            <td bgcolor="#fffde1">
                                                669
                                            </td>
                                            <td bgcolor="#fffde1">
                                                668
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                771
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                554
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                156
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                358
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                881
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                258
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                478
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                664
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                119
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                336
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                129
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                347
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                009
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                027
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                148
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                226
                                            </td>
                                            <td bgcolor="#fffdec">
                                                113
                                            </td>
                                            <td bgcolor="#fffdec">
                                                114
                                            </td>
                                            <td bgcolor="#fffdec">
                                                221
                                            </td>
                                            <td bgcolor="#fffdec">
                                                444
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td bgcolor="#fffde1">
                                                557
                                            </td>
                                            <td bgcolor="#fffde1">
                                                778
                                            </td>
                                            <td bgcolor="#fffde1">
                                                885
                                            </td>
                                            <td bgcolor="#fffde1">
                                                886
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                773
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                770
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                158
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                367
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                883
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                267
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                489
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                880
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                335
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                338
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                136
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                349
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                225
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                029
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                236
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                228
                                            </td>
                                            <td bgcolor="#fffdec">
                                                331
                                            </td>
                                            <td bgcolor="#fffdec">
                                                330
                                            </td>
                                            <td bgcolor="#fffdec">
                                                223
                                            </td>
                                            <td bgcolor="#fffdec">
                                                002
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td bgcolor="#fffde1">
                                                559
                                            </td>
                                            <td bgcolor="#fffde1">
                                                996
                                            </td>
                                            <td bgcolor="#fffde1">
                                                887
                                            </td>
                                            <td bgcolor="#fffde1">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                991
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                772
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                167
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                369
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                056
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                269
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                882
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                337
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                015
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                138
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                227
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                036
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                238
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                446
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                            <td bgcolor="#fffdec">
                                                332
                                            </td>
                                            <td bgcolor="#fffdec">
                                                441
                                            </td>
                                            <td bgcolor="#fffdec">
                                                004
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td bgcolor="#fffde1">
                                                775
                                            </td>
                                            <td bgcolor="#fffde1">
                                                998
                                            </td>
                                            <td bgcolor="#fffde1">
                                                889
                                            </td>
                                            <td bgcolor="#fffde1">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                993
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                774
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                169
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                378
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                058
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                278
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                884
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                339
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                017
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                145
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                229
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                038
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                245
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                448
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                            <td bgcolor="#fffdec">
                                                334
                                            </td>
                                            <td bgcolor="#fffdec">
                                                443
                                            </td>
                                            <td bgcolor="#fffdec">
                                                220
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td bgcolor="#fffde1">
                                                779
                                            </td>
                                            <td bgcolor="#fffde1">
                                                567
                                            </td>
                                            <td bgcolor="#fffde1">
                                                568
                                            </td>
                                            <td bgcolor="#fffde1">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                157
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                990
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                178
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                389
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                067
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                289
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                068
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                135
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                019
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                147
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                445
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                045
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                247
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                026
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                            <td bgcolor="#fffdec">
                                                013
                                            </td>
                                            <td bgcolor="#fffdec">
                                                012
                                            </td>
                                            <td bgcolor="#fffdec">
                                                224
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td bgcolor="#fffde1">
                                                995
                                            </td>
                                            <td bgcolor="#fffde1">
                                                568
                                            </td>
                                            <td bgcolor="#fffde1">
                                                678
                                            </td>
                                            <td bgcolor="#fffde1">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                159
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                992
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                189
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                457
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                069
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                368
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                268
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                137
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                035
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                149
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                447
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                047
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                249
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                028
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                            <td bgcolor="#fffdec">
                                                123
                                            </td>
                                            <td bgcolor="#fffdec">
                                                014
                                            </td>
                                            <td bgcolor="#fffdec">
                                                440
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td bgcolor="#fffde1">
                                                997
                                            </td>
                                            <td bgcolor="#fffde1">
                                                569
                                            </td>
                                            <td bgcolor="#fffde1">
                                                689
                                            </td>
                                            <td bgcolor="#fffde1">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                179
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                994
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                257
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                459
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                078
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                456
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                468
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                139
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                037
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                235
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                449
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                049
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                346
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                046
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                            <td bgcolor="#fffdec">
                                                134
                                            </td>
                                            <td bgcolor="#fffdec">
                                                023
                                            </td>
                                            <td bgcolor="#fffdec">
                                                442
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td bgcolor="#fffde1" height="18">
                                                579
                                            </td>
                                            <td bgcolor="#fffde1" height="18">
                                                578
                                            </td>
                                            <td bgcolor="#fffde1" height="18">
                                            </td>
                                            <td bgcolor="#fffde1" height="18">
                                            </td>
                                            <td bgcolor="#fde6ff" height="18">
                                                357
                                            </td>
                                            <td bgcolor="#fde6ff" height="18">
                                                057
                                            </td>
                                            <td bgcolor="#fde6ff" height="18">
                                                259
                                            </td>
                                            <td bgcolor="#fde6ff" height="18">
                                                479
                                            </td>
                                            <td bgcolor="#fde6ff" height="18">
                                                089
                                            </td>
                                            <td bgcolor="#fde6ff" height="18">
                                                458
                                            </td>
                                            <td bgcolor="#fde6ff" height="18">
                                            </td>
                                            <td bgcolor="#fde6ff" height="18">
                                            </td>
                                            <td bgcolor="#e8ffe8" height="18">
                                            </td>
                                            <td bgcolor="#e8ffe8" height="18">
                                                039
                                            </td>
                                            <td bgcolor="#e8ffe8" height="18">
                                                237
                                            </td>
                                            <td bgcolor="#e8ffe8" height="18">
                                            </td>
                                            <td bgcolor="#e8ffe8" height="18">
                                                016
                                            </td>
                                            <td bgcolor="#e8ffe8" height="18">
                                                126
                                            </td>
                                            <td bgcolor="#e8ffe8" height="18">
                                                348
                                            </td>
                                            <td bgcolor="#e8ffe8" height="18">
                                                048
                                            </td>
                                            <td bgcolor="#fffdec" height="18">
                                            </td>
                                            <td bgcolor="#fffdec" height="18">
                                            </td>
                                            <td bgcolor="#fffdec" height="18">
                                                034
                                            </td>
                                            <td bgcolor="#fffdec" height="18">
                                                024
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td bgcolor="#fffde1">
                                            </td>
                                            <td bgcolor="#fffde1">
                                                589
                                            </td>
                                            <td bgcolor="#fffde1">
                                            </td>
                                            <td bgcolor="#fffde1">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                359
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                246
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                            <td bgcolor="#fffdec">
                                                124
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td height="35" bgcolor="#fffde1">
                                            </td>
                                            <td bgcolor="#fffde1">
                                                679
                                            </td>
                                            <td bgcolor="#fffde1">
                                            </td>
                                            <td bgcolor="#fffde1">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                                379
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#fde6ff">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                            </td>
                                            <td bgcolor="#e8ffe8">
                                                248
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                            <td bgcolor="#fffdec">
                                                234
                                            </td>
                                            <td bgcolor="#fffdec">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" height="19" bgcolor="#FFCC00">
                                <p>
                                    <br />
                                    <span class="bai12"></span><span class="bai">根据数学分类：1、3、5、7、9、为奇数，0、2、4、6、8为偶数，0、1、2、3、4是小数，5、6、7、8、9是大数，那么由0—9十个数字组成的三位数号码就可分为全奇、全偶、两奇一偶、两偶一奇、全大、全小、两大一小、两小一大共八种不同的基本形式。以任何一种形式为条件，又可分为四种不同的大小形式，反之亦然。<br>
                                        <br>
                                        根据对各种形式的出号跟踪，当判断某一大小形式中出希望较大时，即可在相对应的奇偶形式中进行选号。<br>
                                        <br>
                                    </span><font color="#FFFFFF">
                                        <br />
                                    </font>
                                </p>
                            </td>
                        </tr>
                        <tbody>
                        </tbody>
                    </table>
                    <p>
                        <br />
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
                            style="text-decoration: none; font-size: 14px; padding-left: 10px;"><%=_Site.Name %>首页</a>
                        <a href="<%= ResolveUrl("~/Lottery/Buy_3D.aspx") %>" target="_blank" style="padding-left: 10px;
                            text-decoration: none; color: Red;">福彩3D投注/合买</a> <a href="<%= ResolveUrl("~/WinQuery/6-0-0.aspx") %>"
                                target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">福彩3D中奖查询</a><a href='FC3D_ZHXT.aspx' target='mainFrame'>综合分布遗漏走势图</a> | <a href='FC3D_C3YS.aspx'
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
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>
