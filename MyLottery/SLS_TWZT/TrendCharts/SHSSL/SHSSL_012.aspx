<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/SHSSL/SHSSL_012.aspx.cs" inherits="Home_TrendCharts_SHSSL_SHSSL_012" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries"
    TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上海时时乐012路-时时乐走势图-彩票走势图表和数据分析－<%=_Site.Name %></title>
    <meta name="keywords" content="时时乐走势图-上海时时乐012路" />
    <meta name="description" content="时时乐走势图-上海时时乐012路、彩票走势图表和数据分析。" />
    <style type="text/css">
        .td
        {
            color: #cc0000;
        }
        td
        {
            font-size: 12px;
            text-align: center;
        }
        body
        {
            margin: 0px;
            margin-left: 10px;
            margin-right: 10px;
            font-family: tahoma;
            text-align: center;
        }
        form
        {
            display: inline;
        }
        .in_text_hui
        {
            height: 18px;
            border: 1px solid #cccccc;
            background-color: #FFFFFF;
            color: #666666;
            font-size: 12px;
            font-family: tahoma;
        }
        .Isuse
        {
            background-color: #DCDCDC;
            color: #676767;
            width: 68px;
        }
        .itemstyle1
        {
            background-color: #ffe8eb;
            width: 16px;
            color: #cccccc;
        }
        .itemstyle2
        {
            width: 16px;
            color: #cccccc;
        }
        .itemstyle3
        {
            width: 50px;
            color: #ffe8eb;
        }
        .itemstyle4
        {
            width: 22px;
            color: #0000ff;
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

    <script type="text/javascript" language="javascript">
<!--
        function Style(obj, statcolor, color) {

            if (obj.style.backgroundColor == "") {
                obj.style.backgroundColor = "#FFFFFF";
                obj.style.color = statcolor;
            }
            else {
                obj.style.backgroundColor = "";
                obj.style.color = color;
            }
        }
//-->
    </script>

     <link rel="shortcut icon" href="../../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
    <uc2:TrendChartHead ID="TrendChartHead1" runat="server" />
    <div id="box1">
        <table style="width: 100%; height: 40px; background-image: url(../Images/bg11111.jpg);"
            cellspacing="0" cellpadding="0">
            <tbody>
                <tr>
                    <td style="width: 280px" align="center" valign="middle">
                        <h1 class="td" style="font-weight: bold; font-size: 18px;display:inline;">
                            上海时时乐&nbsp;&nbsp;012路走势图</h1>
                    </td>
                    <td align="right" class="black12">
                        起始期数：<asp:TextBox ID="tb1" runat="server" Height="20px" Width="100px" CssClass="in_text_hui"></asp:TextBox>&nbsp;至&nbsp;<asp:TextBox
                            ID="tb2" runat="server" Height="20px" Width="100px" CssClass="in_text_hui"></asp:TextBox>
                    </td>
                    <td align="center" width="100" valign="middle">
                        <asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" />
                    </td>
                    <td align="center" valign="middle">
                        <asp:Button ID="btnTop30" runat="server" Text="显示30期" OnClick="btnTop30_Click" />
                        <asp:Button ID="btnTop50" runat="server" Text="显示50期" OnClick="btnTop50_Click" />
                        <asp:Button ID="btnTop100" runat="server" Text="显示100期" OnClick="btnTop100_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
        <div id="div2" style="margin: 2px">
        </div>
        <div id="div3">
            <table cellspacing="0" cellpadding="1" border="0" style="background-color: #cccccc;
                width: 100%; text-align: left; font-size: 12px;">
                <tr>
                    <td style="background-color: #EFEFEF; text-align: left; font-size: 12px;">
                        <a href="<%= _Site.Url %>" target="_blank" style="text-decoration: none; font-size: 14px;
                            padding-left: 10px;"><%=_Site.Name %>首页</a> <a href="<%= ResolveUrl("~/Lottery/Buy_SSL.aspx") %>"
                                target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">时时乐投注/合买</a>
                        <a href="<%= ResolveUrl("~/WinQuery/29-0-0.aspx") %>" target="_blank" style="padding-left: 10px;
                            text-decoration: none; color: Red;">时时乐中奖查询</a>
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
        <div style="margin: 1px">
        </div>
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="false"
                        FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" align="center"
                        bordercolorlight="#808080" bordercolordark="#FFFFFF" RowStyle-HorizontalAlign="Center"
                        CellPadding="0" ShowHeader="true" OnRowCreated="GridView1_RowCreated" ShowFooter="true">
                        <Columns>
                            <asp:BoundField DataField="Isuse" HeaderText="期号">
                                <ItemStyle CssClass="Isuse" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LotteryNumber" HeaderText="开奖号码" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle Width="80" Font-Bold="true" ForeColor="#0000FF" />
                            </asp:BoundField>
                            <asp:BoundField DataField="B_0" HeaderText="B_0">
                                <ItemStyle CssClass="itemstyle1" />
                            </asp:BoundField>
                            <asp:BoundField DataField="B_1" HeaderText="B_1">
                                <ItemStyle CssClass="itemstyle1" />
                            </asp:BoundField>
                            <asp:BoundField DataField="B_2" HeaderText="B_2">
                                <ItemStyle CssClass="itemstyle1" />
                            </asp:BoundField>
                            <asp:BoundField DataField="B_3" HeaderText="B_3">
                                <ItemStyle CssClass="itemstyle1" />
                            </asp:BoundField>
                            <asp:BoundField DataField="B_4" HeaderText="B_4">
                                <ItemStyle CssClass="itemstyle1" />
                            </asp:BoundField>
                            <asp:BoundField DataField="S_0" HeaderText="S_0">
                                <ItemStyle CssClass="itemstyle2" />
                            </asp:BoundField>
                            <asp:BoundField DataField="S_1" HeaderText="S_1">
                                <ItemStyle CssClass="itemstyle2" />
                            </asp:BoundField>
                            <asp:BoundField DataField="S_2" HeaderText="S_2">
                                <ItemStyle CssClass="itemstyle2" />
                            </asp:BoundField>
                            <asp:BoundField DataField="S_3" HeaderText="S_3">
                                <ItemStyle CssClass="itemstyle2" />
                            </asp:BoundField>
                            <asp:BoundField DataField="S_4" HeaderText="S_4">
                                <ItemStyle CssClass="itemstyle2" />
                            </asp:BoundField>
                            <asp:BoundField DataField="G_0" HeaderText="G_0">
                                <ItemStyle CssClass="itemstyle1" />
                            </asp:BoundField>
                            <asp:BoundField DataField="G_1" HeaderText="G_1">
                                <ItemStyle CssClass="itemstyle1" />
                            </asp:BoundField>
                            <asp:BoundField DataField="G_2" HeaderText="G_2">
                                <ItemStyle CssClass="itemstyle1" />
                            </asp:BoundField>
                            <asp:BoundField DataField="G_3" HeaderText="G_3">
                                <ItemStyle CssClass="itemstyle1" />
                            </asp:BoundField>
                            <asp:BoundField DataField="G_4" HeaderText="G_4">
                                <ItemStyle CssClass="itemstyle1" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Z_0" HeaderText="Z_0">
                                <ItemStyle CssClass="itemstyle2" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Z_1" HeaderText="Z_1">
                                <ItemStyle CssClass="itemstyle2" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Z_2" HeaderText="Z_2">
                                <ItemStyle CssClass="itemstyle2" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Z_3" HeaderText="Z_3">
                                <ItemStyle CssClass="itemstyle2" />
                            </asp:BoundField>
                            <asp:BoundField DataField="D_0" HeaderText="D_0">
                                <ItemStyle CssClass="itemstyle1" />
                            </asp:BoundField>
                            <asp:BoundField DataField="D_1" HeaderText="D_1">
                                <ItemStyle CssClass="itemstyle1" />
                            </asp:BoundField>
                            <asp:BoundField DataField="D_2" HeaderText="D_2">
                                <ItemStyle CssClass="itemstyle1" />
                            </asp:BoundField>
                            <asp:BoundField DataField="D_3" HeaderText="D_3">
                                <ItemStyle CssClass="itemstyle1" />
                            </asp:BoundField>
                            <asp:BoundField DataField="L_0" HeaderText="L_0">
                                <ItemStyle CssClass="itemstyle2" />
                            </asp:BoundField>
                            <asp:BoundField DataField="L_1" HeaderText="L_1">
                                <ItemStyle CssClass="itemstyle2" />
                            </asp:BoundField>
                            <asp:BoundField DataField="L_2" HeaderText="L_2">
                                <ItemStyle CssClass="itemstyle2" />
                            </asp:BoundField>
                            <asp:BoundField DataField="L_3" HeaderText="L_3">
                                <ItemStyle CssClass="itemstyle2" />
                            </asp:BoundField>
                            <asp:BoundField DataField="A" HeaderText="A">
                                <ItemStyle CssClass="itemstyle1" Font-Bold="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="bb" HeaderText="B">
                                <ItemStyle CssClass="itemstyle1" Font-Bold="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C" HeaderText="C">
                                <ItemStyle CssClass="itemstyle1" Font-Bold="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="D" HeaderText="D">
                                <ItemStyle CssClass="itemstyle1" Font-Bold="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="E" HeaderText="E">
                                <ItemStyle CssClass="itemstyle1" Font-Bold="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="F" HeaderText="F">
                                <ItemStyle CssClass="itemstyle1" Font-Bold="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="gg" HeaderText="G">
                                <ItemStyle CssClass="itemstyle1" Font-Bold="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="H" HeaderText="H">
                                <ItemStyle CssClass="itemstyle1" Font-Bold="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="I" HeaderText="I">
                                <ItemStyle CssClass="itemstyle1" Font-Bold="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="J" HeaderText="J">
                                <ItemStyle CssClass="itemstyle1" Font-Bold="true" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left" valign="middle" style="background-color: #1576c7" height="60">
                    <font color="#FF0000">说明：</font>012路分析是将每位分别除以3所得到余数，0、3、6、9为0数，1、4、7为1数，2、5、8为2数。本站福彩3D彩票021路分析图中总体走势图中：<font
                        color="#0000FF"><strong>A</strong></font>-3个2路，<font color="#0000FF"><strong>B</strong></font>-1个1路2个2路，<font
                            color="#0000FF"><strong>C</strong></font>-2个1路1个2路，<font color="#0000FF"><strong>D</strong></font>-3个1路码，<font
                                color="#0000FF"><strong>E</strong></font>-1个0路2个2路，<font color="#0000FF"><strong>F</strong></font>-1个0路1个1路1个2路，<strong><font
                                    color="#0000FF">G</font></strong>-1个0路2个1路，<font color="#0000FF"><strong>H</strong></font>-2个0路1个2路，<font
                                        color="#0000FF"><strong>I</strong></font>-2个0路1个1路，<font color="#0000FF"><strong>J</strong></font>-3个0路。
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
                        <a href="<%= ResolveUrl("~/Lottery/Buy_SSL.aspx") %>" target="_blank" style="padding-left: 10px;
                            text-decoration: none; color: Red;">时时乐投注/合买</a> <a href="<%= ResolveUrl("~/WinQuery/29-0-0.aspx") %>"
                                target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">时时乐中奖查询</a><span
                                    class='blue14' style='padding-left: 30px; padding-right: 8px;'>时时乐:</span><a href='SHSSL_ZHFB.aspx'
                                        target='mainFrame'>综合分布图（基本走势图）</a> | <a href='SHSSL_012.aspx' target='mainFrame'>012路走势图（除3余数）</a>
                        | <a href='SHSSL_DX.aspx' target='mainFrame'>大小分析走势图</a> | <a href='SHSSL_JO.aspx' target='mainFrame'>
                            奇偶分析走势图</a> | <a href='SHSSL_ZH.aspx' target='mainFrame'>质合分析走势图</a> | <a href='SHSSL_HZ.aspx'
                                target='mainFrame'>和值走势图</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
