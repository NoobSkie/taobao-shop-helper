<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/PL3/PL3_GD.aspx.cs" inherits="View_PL3_GD" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>和值号码分布图</title>
    <style type="text/css">
        body
        {
            font-family: tahoma;
            margin: 0px;
            margin-left: 10px;
            margin-right: 10px;
            text-align: center;
        }
        .font11
        {
            font-family: "宋体";
            font-size: 14px;
            font-weight: bold;
            color: #FF0000;
        }
        td
        {
            font-family: "宋体";
            font-size: 9pt;
        }
    </style>

    <script type="text/javascript" language="JavaScript">

        var jsstr = ""
+ "<img src=\"about:blank\" id=\"leftright\" style=\"width:expression(document.body.clientWidth);height:1px;position:absolute;left:0;top:0;background-color:#6699cc;z-index:100;\" \/>\n"
+ "<img src=\"about:blank\" id=\"topdown\" style=\"height:expression(document.body.clientHeight);width:1px;position:absolute;left:0;top:0;background-color:#6699cc;z-index:100;\" \/>\n"
        document.writeln(jsstr);

        function followmouse() {
            leftright.style.top = window.event.y - 1 + document.body.scrollTop
            topdown.style.left = window.event.x - 1 + document.body.scrollLeft
            topdown.style.height = document.getElementById("div_end").offsetTop;
            leftright.style.width = document.body.clientWidth
        }
        document.onmousemove = followmouse

    </script>
</head>
<body style="overflow-x: hidden" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0"
    oncontextmenu="return false" onselectstart="return false">
    <form id="form6" runat="server">
    <div style="text-align: center">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
            <tr>
                <td height="28" background="../images/logobg2.gif">
                    <table width="60%" height="100%" border="0" align="center" cellpadding="1" cellspacing="0">
                        <tr>
                            <td height="4" colspan="10" align="center" valign="middle">
                            </td>
                        </tr>
                        <tr>
                            <td width="10" height="24" align="center" valign="middle">
                                &nbsp;
                            </td>
                            <td width="12%" align="center">
                                <a href="PL3_GD.aspx">和值号码</a>
                            </td>
                            <td width="12%" align="center">
                                <a href="HZHM.htm">合值号码</a>
                            </td>
                            <td width="12%" align="center">
                                <a href="DXJO.htm">大小-奇偶</a>
                            </td>
                            <td width="12%" align="center">
                                <a href="JODX.htm">奇偶-大小</a>
                            </td>
                            <td width="12%" align="center" background="../images/tuibiao_topbg.gif" bgcolor="#FFFFFF">
                                <a href="Dantuo.htm">胆拖号码</a>
                            </td>
                            <td width="12%" align="center">
                                <a href="Chu3.htm">除3余数</a>
                            </td>
                            <td width="12%" align="center">
                                <a href="Lianhao.htm">连号组合</a>
                            </td>
                            <td width="12%" align="center">
                                <a href="SouWei.htm">首尾边距组合</a>
                            </td>
                            <td width="10">
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="background-color: #EFEFEF; text-align: left; font-size: 12px; width: 500px;">
                <a href="<%= _Site.Url %>" target="_blank" style="text-decoration: none; font-size: 14px;
                    padding-left: 10px;"><%=_Site.Name %>首页</a> <a href="<%= ResolveUrl("~/Lottery/Buy_PL3.aspx") %>"
                        target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">排列三投注/合买</a>
                <a href="<%= ResolveUrl("~/WinQuery/63-0-0.aspx") %>" target="_blank" style="padding-left: 10px;
                    text-decoration: none; color: Red;">排列三中奖查询</a>
            </td>
            <td height="30" align="center" valign="top" class="font11">
                和数值号码分布表
            </td>
        </tr>
    </table>
    <table border="1" align="center" cellpadding="0" cellspacing="0" bordercolorlight="#999999"
        bordercolordark="#FFFFFF">
        <tr align="center" valign="middle" bgcolor="#CCCCCC">
            <td>
                <font color="#FF0000">和数值</font>
            </td>
            <td width="25">
                <font color="#FF0000">0</font>
            </td>
            <td width="25">
                <font color="#FF0000">1</font>
            </td>
            <td width="25">
                <font color="#FF0000">2</font>
            </td>
            <td width="25">
                <font color="#FF0000">3</font>
            </td>
            <td width="25">
                <font color="#FF0000">4</font>
            </td>
            <td width="25">
                <font color="#FF0000">5</font>
            </td>
            <td width="25">
                <font color="#FF0000">6</font>
            </td>
            <td width="25">
                <font color="#FF0000">7</font>
            </td>
            <td width="25">
                <font color="#FF0000">8</font>
            </td>
            <td width="25">
                <font color="#FF0000">9</font>
            </td>
            <td width="25">
                <font color="#FF0000">10</font>
            </td>
            <td width="25">
                <font color="#FF0000">11</font>
            </td>
            <td width="25">
                <font color="#FF0000">12</font>
            </td>
            <td width="25">
                <font color="#FF0000">13</font>
            </td>
            <td width="25">
                <font color="#FF0000">14</font>
            </td>
            <td width="25">
                <font color="#FF0000">15</font>
            </td>
            <td width="25">
                <font color="#FF0000">16</font>
            </td>
            <td width="25">
                <font color="#FF0000">17</font>
            </td>
            <td width="25">
                <font color="#FF0000">18</font>
            </td>
            <td width="25">
                <font color="#FF0000">19</font>
            </td>
            <td width="25">
                <font color="#FF0000">20</font>
            </td>
            <td width="25">
                <font color="#FF0000">21</font>
            </td>
            <td width="25">
                <font color="#FF0000">22</font>
            </td>
            <td width="25">
                <font color="#FF0000">23</font>
            </td>
            <td width="25">
                <font color="#FF0000">24</font>
            </td>
            <td width="25">
                <font color="#FF0000">25</font>
            </td>
            <td width="25">
                <font color="#FF0000">26</font>
            </td>
            <td width="25">
                <font color="#FF0000">27</font>
            </td>
        </tr>
        <tr align="center" valign="middle" bgcolor="#D5F4E0">
            <td>
                单选
            </td>
            <td>
                000
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                111
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                222
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                333
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                444
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                555
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                666
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                777
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                888
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                999
            </td>
        </tr>
        <tr align="center" valign="middle" bgcolor="#336699">
            <td rowspan="5" bgcolor="#D1ECFC">
                组选三
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                001
            </td>
            <td bgcolor="#D1ECFC">
                002
            </td>
            <td bgcolor="#D1ECFC">
                003
            </td>
            <td bgcolor="#D1ECFC">
                004
            </td>
            <td bgcolor="#D1ECFC">
                005
            </td>
            <td bgcolor="#D1ECFC">
                006
            </td>
            <td bgcolor="#D1ECFC">
                007
            </td>
            <td bgcolor="#D1ECFC">
                008
            </td>
            <td bgcolor="#D1ECFC">
                009
            </td>
            <td bgcolor="#D1ECFC">
                118
            </td>
            <td bgcolor="#D1ECFC">
                119
            </td>
            <td bgcolor="#D1ECFC">
                228
            </td>
            <td bgcolor="#D1ECFC">
                229
            </td>
            <td bgcolor="#D1ECFC">
                338
            </td>
            <td bgcolor="#D1ECFC">
                339
            </td>
            <td bgcolor="#D1ECFC">
                448
            </td>
            <td bgcolor="#D1ECFC">
                449
            </td>
            <td bgcolor="#D1ECFC">
                558
            </td>
            <td bgcolor="#D1ECFC">
                559
            </td>
            <td bgcolor="#D1ECFC">
                668
            </td>
            <td bgcolor="#D1ECFC">
                669
            </td>
            <td bgcolor="#D1ECFC">
                778
            </td>
            <td bgcolor="#D1ECFC">
                779
            </td>
            <td bgcolor="#D1ECFC">
                996
            </td>
            <td bgcolor="#D1ECFC">
                889
            </td>
            <td bgcolor="#D1ECFC">
                998
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                110
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                112
            </td>
            <td bgcolor="#D1ECFC">
                113
            </td>
            <td bgcolor="#D1ECFC">
                114
            </td>
            <td bgcolor="#D1ECFC">
                115
            </td>
            <td bgcolor="#D1ECFC">
                116
            </td>
            <td bgcolor="#D1ECFC">
                117
            </td>
            <td bgcolor="#D1ECFC">
                226
            </td>
            <td bgcolor="#D1ECFC">
                227
            </td>
            <td bgcolor="#D1ECFC">
                336
            </td>
            <td bgcolor="#D1ECFC">
                337
            </td>
            <td bgcolor="#D1ECFC">
                446
            </td>
            <td bgcolor="#D1ECFC">
                447
            </td>
            <td bgcolor="#D1ECFC">
                556
            </td>
            <td bgcolor="#D1ECFC">
                557
            </td>
            <td bgcolor="#D1ECFC">
                774
            </td>
            <td bgcolor="#D1ECFC">
                667
            </td>
            <td bgcolor="#D1ECFC">
                776
            </td>
            <td bgcolor="#D1ECFC">
                885
            </td>
            <td bgcolor="#D1ECFC">
                886
            </td>
            <td bgcolor="#D1ECFC">
                887
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                997
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                220
            </td>
            <td bgcolor="#D1ECFC">
                221
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                223
            </td>
            <td bgcolor="#D1ECFC">
                224
            </td>
            <td bgcolor="#D1ECFC">
                225
            </td>
            <td bgcolor="#D1ECFC">
                334
            </td>
            <td bgcolor="#D1ECFC">
                335
            </td>
            <td bgcolor="#D1ECFC">
                552
            </td>
            <td bgcolor="#D1ECFC">
                445
            </td>
            <td bgcolor="#D1ECFC">
                554
            </td>
            <td bgcolor="#D1ECFC">
                663
            </td>
            <td bgcolor="#D1ECFC">
                664
            </td>
            <td bgcolor="#D1ECFC">
                665
            </td>
            <td bgcolor="#D1ECFC">
                882
            </td>
            <td bgcolor="#D1ECFC">
                775
            </td>
            <td bgcolor="#D1ECFC">
                884
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                994
            </td>
            <td bgcolor="#D1ECFC">
                995
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                330
            </td>
            <td bgcolor="#D1ECFC">
                331
            </td>
            <td bgcolor="#D1ECFC">
                332
            </td>
            <td bgcolor="#D1ECFC">
                441
            </td>
            <td bgcolor="#D1ECFC">
                442
            </td>
            <td bgcolor="#D1ECFC">
                443
            </td>
            <td bgcolor="#D1ECFC">
                660
            </td>
            <td bgcolor="#D1ECFC">
                553
            </td>
            <td bgcolor="#D1ECFC">
                662
            </td>
            <td bgcolor="#D1ECFC">
                771
            </td>
            <td bgcolor="#D1ECFC">
                772
            </td>
            <td bgcolor="#D1ECFC">
                773
            </td>
            <td bgcolor="#D1ECFC">
                990
            </td>
            <td bgcolor="#D1ECFC">
                883
            </td>
            <td bgcolor="#D1ECFC">
                992
            </td>
            <td bgcolor="#D1ECFC">
                993
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                440
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                550
            </td>
            <td bgcolor="#D1ECFC">
                551
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                661
            </td>
            <td bgcolor="#D1ECFC">
                770
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                880
            </td>
            <td bgcolor="#D1ECFC">
                881
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                991
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
            <td bgcolor="#D1ECFC">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td rowspan="10" bgcolor="#FFF2E6">
                组选六
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                012
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                013
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                014
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                015
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                016
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                017
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                018
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                019
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                029
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                039
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                049
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                059
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                069
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                079
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                089
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                189
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                289
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                389
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                489
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                589
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                689
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                789
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                023
            </td>
            <td bgcolor="#FFF2E6">
                024
            </td>
            <td bgcolor="#FFF2E6">
                025
            </td>
            <td bgcolor="#FFF2E6">
                026
            </td>
            <td bgcolor="#FFF2E6">
                027
            </td>
            <td bgcolor="#FFF2E6">
                028
            </td>
            <td bgcolor="#FFF2E6">
                038
            </td>
            <td bgcolor="#FFF2E6">
                048
            </td>
            <td bgcolor="#FFF2E6">
                058
            </td>
            <td bgcolor="#FFF2E6">
                068
            </td>
            <td bgcolor="#FFF2E6">
                078
            </td>
            <td bgcolor="#FFF2E6">
                169
            </td>
            <td bgcolor="#FFF2E6">
                179
            </td>
            <td bgcolor="#FFF2E6">
                279
            </td>
            <td bgcolor="#FFF2E6">
                379
            </td>
            <td bgcolor="#FFF2E6">
                479
            </td>
            <td bgcolor="#FFF2E6">
                579
            </td>
            <td bgcolor="#FFF2E6">
                679
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                123
            </td>
            <td bgcolor="#FFF2E6">
                034
            </td>
            <td bgcolor="#FFF2E6">
                035
            </td>
            <td bgcolor="#FFF2E6">
                036
            </td>
            <td bgcolor="#FFF2E6">
                037
            </td>
            <td bgcolor="#FFF2E6">
                047
            </td>
            <td bgcolor="#FFF2E6">
                057
            </td>
            <td bgcolor="#FFF2E6">
                067
            </td>
            <td bgcolor="#FFF2E6">
                149
            </td>
            <td bgcolor="#FFF2E6">
                159
            </td>
            <td bgcolor="#FFF2E6">
                178
            </td>
            <td bgcolor="#FFF2E6">
                269
            </td>
            <td bgcolor="#FFF2E6">
                369
            </td>
            <td bgcolor="#FFF2E6">
                469
            </td>
            <td bgcolor="#FFF2E6">
                569
            </td>
            <td bgcolor="#FFF2E6">
                678
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                124
            </td>
            <td bgcolor="#FFF2E6">
                125
            </td>
            <td bgcolor="#FFF2E6">
                045
            </td>
            <td bgcolor="#FFF2E6">
                046
            </td>
            <td bgcolor="#FFF2E6">
                056
            </td>
            <td bgcolor="#FFF2E6">
                129
            </td>
            <td bgcolor="#FFF2E6">
                139
            </td>
            <td bgcolor="#FFF2E6">
                158
            </td>
            <td bgcolor="#FFF2E6">
                168
            </td>
            <td bgcolor="#FFF2E6">
                259
            </td>
            <td bgcolor="#FFF2E6">
                278
            </td>
            <td bgcolor="#FFF2E6">
                378
            </td>
            <td bgcolor="#FFF2E6">
                478
            </td>
            <td bgcolor="#FFF2E6">
                578
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                134
            </td>
            <td bgcolor="#FFF2E6">
                126
            </td>
            <td bgcolor="#FFF2E6">
                127
            </td>
            <td bgcolor="#FFF2E6">
                128
            </td>
            <td bgcolor="#FFF2E6">
                138
            </td>
            <td bgcolor="#FFF2E6">
                148
            </td>
            <td bgcolor="#FFF2E6">
                167
            </td>
            <td bgcolor="#FFF2E6">
                249
            </td>
            <td bgcolor="#FFF2E6">
                268
            </td>
            <td bgcolor="#FFF2E6">
                359
            </td>
            <td bgcolor="#FFF2E6">
                459
            </td>
            <td bgcolor="#FFF2E6">
                568
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                135
            </td>
            <td bgcolor="#FFF2E6">
                136
            </td>
            <td bgcolor="#FFF2E6">
                137
            </td>
            <td bgcolor="#FFF2E6">
                147
            </td>
            <td bgcolor="#FFF2E6">
                157
            </td>
            <td bgcolor="#FFF2E6">
                239
            </td>
            <td bgcolor="#FFF2E6">
                258
            </td>
            <td bgcolor="#FFF2E6">
                349
            </td>
            <td bgcolor="#FFF2E6">
                368
            </td>
            <td bgcolor="#FFF2E6">
                468
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                234
            </td>
            <td bgcolor="#FFF2E6">
                145
            </td>
            <td bgcolor="#FFF2E6">
                146
            </td>
            <td bgcolor="#FFF2E6">
                156
            </td>
            <td bgcolor="#FFF2E6">
                238
            </td>
            <td bgcolor="#FFF2E6">
                248
            </td>
            <td bgcolor="#FFF2E6">
                267
            </td>
            <td bgcolor="#FFF2E6">
                358
            </td>
            <td bgcolor="#FFF2E6">
                458
            </td>
            <td bgcolor="#FFF2E6">
                567
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                235
            </td>
            <td bgcolor="#FFF2E6">
                236
            </td>
            <td bgcolor="#FFF2E6">
                237
            </td>
            <td bgcolor="#FFF2E6">
                247
            </td>
            <td bgcolor="#FFF2E6">
                257
            </td>
            <td bgcolor="#FFF2E6">
                348
            </td>
            <td bgcolor="#FFF2E6">
                367
            </td>
            <td bgcolor="#FFF2E6">
                467
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                245
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                246
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                256
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                347
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                357
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                457
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6" style="height: 16px">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle">
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                345
            </td>
            <td bgcolor="#FFF2E6">
                346
            </td>
            <td bgcolor="#FFF2E6">
                356
            </td>
            <td bgcolor="#FFF2E6">
                456
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
            <td bgcolor="#FFF2E6">
                &nbsp;
            </td>
        </tr>
        <tr align="center" valign="middle" bgcolor="#33CC33">
            <td nowrap>
                组选注数
            </td>
            <td>
                1
            </td>
            <td>
                1
            </td>
            <td>
                2
            </td>
            <td>
                3
            </td>
            <td>
                4
            </td>
            <td>
                5
            </td>
            <td>
                7
            </td>
            <td>
                8
            </td>
            <td>
                10
            </td>
            <td>
                12
            </td>
            <td>
                13
            </td>
            <td>
                14
            </td>
            <td>
                15
            </td>
            <td>
                15
            </td>
            <td>
                15
            </td>
            <td>
                15
            </td>
            <td>
                14
            </td>
            <td>
                13
            </td>
            <td>
                12
            </td>
            <td>
                10
            </td>
            <td>
                8
            </td>
            <td>
                7
            </td>
            <td>
                5
            </td>
            <td>
                4
            </td>
            <td>
                3
            </td>
            <td>
                2
            </td>
            <td>
                1
            </td>
            <td>
                1
            </td>
        </tr>
        <tr align="center" valign="middle" bgcolor="#CCCC66">
            <td>
                单选注数
            </td>
            <td>
                1
            </td>
            <td>
                3
            </td>
            <td>
                6
            </td>
            <td>
                10
            </td>
            <td>
                15
            </td>
            <td>
                21
            </td>
            <td>
                28
            </td>
            <td>
                36
            </td>
            <td>
                45
            </td>
            <td>
                55
            </td>
            <td>
                63
            </td>
            <td>
                69
            </td>
            <td>
                73
            </td>
            <td>
                75
            </td>
            <td>
                75
            </td>
            <td>
                73
            </td>
            <td>
                69
            </td>
            <td>
                63
            </td>
            <td>
                55
            </td>
            <td>
                45
            </td>
            <td>
                36
            </td>
            <td>
                28
            </td>
            <td>
                21
            </td>
            <td>
                15
            </td>
            <td>
                10
            </td>
            <td>
                6
            </td>
            <td>
                3
            </td>
            <td>
                1
            </td>
        </tr>
        <tr align="center" valign="middle" bgcolor="#FFCE9D">
            <td>
                分配比率
            </td>
            <td>
                0.1%
            </td>
            <td>
                0.3%
            </td>
            <td>
                0.6%
            </td>
            <td>
                1.0%
            </td>
            <td>
                1.5%
            </td>
            <td>
                2.1%
            </td>
            <td>
                2.8%
            </td>
            <td>
                3.6%
            </td>
            <td>
                4.5%
            </td>
            <td>
                5.5%
            </td>
            <td>
                6.3%
            </td>
            <td>
                6.9%
            </td>
            <td>
                7.3%
            </td>
            <td>
                7.5%
            </td>
            <td>
                7.5%
            </td>
            <td>
                7.3%
            </td>
            <td>
                6.9%
            </td>
            <td>
                6.3%
            </td>
            <td>
                5.5%
            </td>
            <td>
                4.5%
            </td>
            <td>
                3.6%
            </td>
            <td>
                2.8%
            </td>
            <td>
                2.1%
            </td>
            <td>
                1.5%
            </td>
            <td>
                1.0%
            </td>
            <td>
                0.6%
            </td>
            <td>
                0.3%
            </td>
            <td>
                0.1%
            </td>
        </tr>
    </table>
    <div id="div_end">
    </div>
    </form>
</body>
</html>
