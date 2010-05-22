<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/FC3D/FC3D_HSWH.aspx.cs" inherits="Home_TrendCharts_FC3D_FC3D_HSWH" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries"
    TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>福彩3D 和数尾号码分区表-彩票走势图表和数据分析－<%=_Site.Name %></title>
    <meta name="keywords" content="福彩3D 和数尾号码分区表" />
    <meta name="description" content="福彩3D 和数尾号码分区表、彩票走势图表和数据分析。" />
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
                        3D和数尾号码分区表走势图</h1>
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
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                                <table cellspacing="1" cellpadding="0" bgcolor="#000000" border="0" width="987" align="center">
                                    <tbody>
                                        <tr align="center" bgcolor="#ffcc00">
                                            <td width="88" height="30">
                                                和数尾
                                            </td>
                                            <td width="88" colspan="3">
                                                0
                                            </td>
                                            <td width="88" colspan="3">
                                                1
                                            </td>
                                            <td width="88" colspan="3">
                                                2
                                            </td>
                                            <td width="88" colspan="3">
                                                3
                                            </td>
                                            <td width="88" colspan="3">
                                                4
                                            </td>
                                            <td width="88" colspan="3">
                                                5
                                            </td>
                                            <td width="88" colspan="3">
                                                6
                                            </td>
                                            <td width="88" colspan="3">
                                                7
                                            </td>
                                            <td width="88" colspan="2">
                                                8
                                            </td>
                                            <td width="88" colspan="2">
                                                9
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td>
                                                和数值
                                            </td>
                                            <td width="25">
                                                0
                                            </td>
                                            <td width="25">
                                                10
                                            </td>
                                            <td width="25">
                                                20
                                            </td>
                                            <td width="25">
                                                1
                                            </td>
                                            <td width="25">
                                                11
                                            </td>
                                            <td width="25">
                                                21
                                            </td>
                                            <td width="25">
                                                2
                                            </td>
                                            <td width="25">
                                                12
                                            </td>
                                            <td width="25">
                                                22
                                            </td>
                                            <td width="25">
                                                3
                                            </td>
                                            <td width="25">
                                                13
                                            </td>
                                            <td width="25">
                                                23
                                            </td>
                                            <td width="25">
                                                4
                                            </td>
                                            <td width="25">
                                                14
                                            </td>
                                            <td width="25">
                                                24
                                            </td>
                                            <td width="25">
                                                5
                                            </td>
                                            <td width="25">
                                                15
                                            </td>
                                            <td width="25">
                                                25
                                            </td>
                                            <td width="25">
                                                6
                                            </td>
                                            <td width="25">
                                                16
                                            </td>
                                            <td width="25">
                                                26
                                            </td>
                                            <td width="25">
                                                7
                                            </td>
                                            <td width="25">
                                                17
                                            </td>
                                            <td width="25">
                                                27
                                            </td>
                                            <td width="25">
                                                8
                                            </td>
                                            <td width="25">
                                                18
                                            </td>
                                            <td width="25">
                                                9
                                            </td>
                                            <td width="25">
                                                19
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td>
                                                直选
                                            </td>
                                            <td>
                                                000
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                777
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                444
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                111
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td class="xl29">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                888
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                555
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                222
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                999
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                666
                                            </td>
                                            <td>
                                                333
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td rowspan="5">
                                                组选 3
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                118
                                            </td>
                                            <td>
                                                668
                                            </td>
                                            <td>
                                                001
                                            </td>
                                            <td>
                                                119
                                            </td>
                                            <td>
                                                669
                                            </td>
                                            <td>
                                                002
                                            </td>
                                            <td>
                                                228
                                            </td>
                                            <td>
                                                778
                                            </td>
                                            <td>
                                                003
                                            </td>
                                            <td>
                                                229
                                            </td>
                                            <td>
                                                779
                                            </td>
                                            <td>
                                                004
                                            </td>
                                            <td>
                                                338
                                            </td>
                                            <td>
                                                996
                                            </td>
                                            <td>
                                                005
                                            </td>
                                            <td>
                                                339
                                            </td>
                                            <td>
                                                889
                                            </td>
                                            <td>
                                                006
                                            </td>
                                            <td>
                                                448
                                            </td>
                                            <td>
                                                998
                                            </td>
                                            <td>
                                                007
                                            </td>
                                            <td>
                                                449
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                008
                                            </td>
                                            <td>
                                                558
                                            </td>
                                            <td>
                                                009
                                            </td>
                                            <td>
                                                559
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                226
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                776
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                227
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                885
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                011
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                336
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                886
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                337
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                887
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                112
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                446
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                113
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                447
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                997
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                114
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                556
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                115
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                557
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                116
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                774
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                117
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                667
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                334
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                884
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                335
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                993
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                552
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                994
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                445
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                995
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                220
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                554
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                221
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                663
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                330
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                664
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                223
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                665
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                224
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                882
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                225
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                775
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                442
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                992
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                443
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                660
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                553
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                662
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                771
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                772
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                331
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                773
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                332
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                990
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                441
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                883
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                550
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                551
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                661
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                770
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                &nbsp;
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                880
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                881
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                440
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                991
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td rowspan="10">
                                                组选 6
                                            </td>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td bgcolor="#ffffff">
                                                019
                                            </td>
                                            <td bgcolor="#ffffff">
                                                389
                                            </td>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td bgcolor="#ffffff">
                                                029
                                            </td>
                                            <td bgcolor="#ffffff">
                                                489
                                            </td>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td bgcolor="#ffffff">
                                                039
                                            </td>
                                            <td bgcolor="#ffffff">
                                                589
                                            </td>
                                            <td bgcolor="#ffffff">
                                                012
                                            </td>
                                            <td bgcolor="#ffffff">
                                                049
                                            </td>
                                            <td bgcolor="#ffffff">
                                                689
                                            </td>
                                            <td bgcolor="#ffffff">
                                                013
                                            </td>
                                            <td bgcolor="#ffffff">
                                                059
                                            </td>
                                            <td bgcolor="#ffffff">
                                                789
                                            </td>
                                            <td bgcolor="#ffffff">
                                                014
                                            </td>
                                            <td bgcolor="#ffffff">
                                                069
                                            </td>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td bgcolor="#ffffff">
                                                015
                                            </td>
                                            <td bgcolor="#ffffff">
                                                079
                                            </td>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td bgcolor="#ffffff">
                                                016
                                            </td>
                                            <td bgcolor="#ffffff">
                                                089
                                            </td>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td bgcolor="#ffffff">
                                                017
                                            </td>
                                            <td bgcolor="#ffffff">
                                                189
                                            </td>
                                            <td bgcolor="#ffffff">
                                                018
                                            </td>
                                            <td bgcolor="#ffffff">
                                                289
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                028
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                479
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                038
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                579
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                048
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                679
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                058
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                068
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                023
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                078
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                024
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                169
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                025
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                179
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                026
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                279
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                027
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                379
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                037
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                569
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                047
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                678
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                057
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                067
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                149
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                159
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                123
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                178
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                034
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                269
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                035
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                369
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                036
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                469
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                046
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                578
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                056
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                129
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                139
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                158
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                168
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                259
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                124
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                278
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                125
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                378
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                045
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                478
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                127
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                128
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                138
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                148
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                167
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                249
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                268
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                359
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                134
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                459
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                126
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                568
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                136
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                137
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                147
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                157
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                239
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                258
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                349
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                368
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                468
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                135
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                145
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                146
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                156
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                238
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                248
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                267
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                358
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                458
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                567
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                234
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                235
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                236
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                237
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                247
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                257
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                348
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                367
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                467
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                245
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                246
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                256
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                347
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                357
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                457
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                345
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                346
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                356
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                                456
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                            <td align="center" bgcolor="#ffffff">
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td>
                                                组选注数
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                22
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                22
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                22
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                22
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                22
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                22
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                22
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                22
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                22
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                22
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ffffff">
                                            <td>
                                                单选注数
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                100
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                100
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                100
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                100
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                100
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                100
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                100
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                100
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                100
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                100
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
                                    <span class="bai">由 0-9 十个数字组成的三位数号码，三个数字相加之和的尾数称为“和数尾”。和数尾同样有 0-9 十个组合，每一个尾数里都包含 1
                                        注直选的“豹子”， 9 注“组选 3” 和 12 注“组选 6” 号码。和数尾可分为单点的 1 ， 3 ， 5 ， 7 ， 9 和双点的 0 ， 2 ， 4 ，
                                        6 ， 8 同时又可分为小点的 0 ， 1 ， 2 ， 3 ， 4 和大点的 5 ， 6 ， 7 ， 8 ， 9 。<br>
                                        根据对各个尾数，单双点，大小点，除三余数的出号跟踪，当判断某一尾数中出希望较大时，即可在相应尾数中进行选号。<br>
                                        <br>
                                    </span><font color="#FFFFFF">
                                        <br>
                                    </font>
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
                        <<a href="<%= _Site.Url %>" target="_blank"
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
                    <img src="http://img.tongji.linezing.com/1135959/tongji.gif" /></a></noscript>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>
