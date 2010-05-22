<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/SSQ/SSQ_DX.aspx.cs" inherits="Home_TrendCharts_SSQ_SSQ_DX" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>双色球大小分析图-双色球走势图-彩票走势图表和数据分析－<%=_Site.Name %></title>
<meta name="keywords" content="双色球走势图-双色球大小分析图" />
<meta name="description" content="双色球走势图-双色球大小分析图、彩票走势图表和数据分析。" />
    <style type="text/css">
        .td
        {
            color: #cc0000;
        }
        td
        {
            font-size: 12px;
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
            width: 98px;
        }
        .itemstyle1
        {
            background-color: #ffe8eb;
            width: 22px;
            color: #0000ff;
            font-bold: true;
        }
        .itemstyle2
        {
            width: 22px;
            color: #ff0000;
            font-bold: true;
        }
        .itemstyle3
        {
            background-color: #FDFCDF;
            width: 70px;
        }
        .itemstyle4
        {
            background-color: #ffe8eb;
            width: 20px;
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
                        <h1 class="td" style="font-weight: bold; font-size: 18px;display:inline;">双色球&nbsp;&nbsp;大小分析图走势图</h1>
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
                                            <a href="<%= _Site.Url %>" target="_blank" style="text-decoration: none; font-size: 14px;padding-left: 10px;"><%=_Site.Name %>首页</a>
                    <a href="<%= ResolveUrl("~/Lottery/Buy_SSQ.aspx") %>" target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">双色球投注/合买</a>
                        <a href="<%= ResolveUrl("~/WinQuery/5-0-0.aspx") %>" target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">双色球中奖查询</a>
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
        <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False"
            FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" align="center"
            bordercolorlight="#808080" bordercolordark="#FFFFFF" RowStyle-HorizontalAlign="Center"
            CellPadding="0" OnRowCreated="GridView1_RowCreated" ShowFooter="True">
            <FooterStyle HorizontalAlign="Center"></FooterStyle>
            <RowStyle HorizontalAlign="Center"></RowStyle>
            <Columns>
                <asp:BoundField DataField="Isuse" HeaderText="期号">
                    <ItemStyle CssClass="Isuse" />
                </asp:BoundField>
                <asp:BoundField DataField="RQ_0" HeaderText="红球号码">
                    <ItemStyle CssClass="itemstyle2" Font-Bold="true" Width="150" />
                </asp:BoundField>
                <asp:BoundField DataField="BQ_0" HeaderText="蓝球号码">
                    <ItemStyle CssClass="itemstyle1" Width="70" />
                </asp:BoundField>
                <asp:BoundField DataField="H_Z" HeaderText="红球和值">
                    <ItemStyle Width="70" />
                </asp:BoundField>
                <asp:BoundField DataField="RZ_0" HeaderText="RZ_0">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="RZ_1" HeaderText="RZ_1">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="RZ_2" HeaderText="RZ_2">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="RZ_3" HeaderText="RZ_3">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="RZ_4" HeaderText="RZ_4">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="RZ_5" HeaderText="RZ_5">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="RZ_6" HeaderText="RZ_6">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="BZ_0" HeaderText="BZ_0">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="BH_0" HeaderText="BH_0">
                    <ItemStyle Width="22" ForeColor="#0000ff" />
                </asp:BoundField>
                <asp:BoundField DataField="R1Z_0" HeaderText="R1Z_0">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="R1H_0" HeaderText="R1H_0">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="R2Z_0" HeaderText="R2Z_0">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="R2H_0" HeaderText="R2H_0">
                    <ItemStyle Width="22" ForeColor="#0000ff" />
                </asp:BoundField>
                <asp:BoundField DataField="R3Z_0" HeaderText="R3Z_0">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="R3H_0" HeaderText="R3H_0">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="R4Z_0" HeaderText="R4Z_0">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="R4H_0" HeaderText="R4H_0">
                    <ItemStyle Width="22" ForeColor="#0000ff" />
                </asp:BoundField>
                <asp:BoundField DataField="R5Z_0" HeaderText="R5Z_0">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="R5H_0" HeaderText="R5H_0">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="R6Z_0" HeaderText="R6Z_0">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="R6H_0" HeaderText="R6H_0">
                    <ItemStyle Width="22" ForeColor="#0000ff" />
                </asp:BoundField>
                <asp:BoundField DataField="RHZ_0" HeaderText="RHZ_0">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="RHH_0" HeaderText="RHH_0">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="Z_H" HeaderText="Z_H">
                    <ItemStyle CssClass="itemstyle1" Width="40" />
                </asp:BoundField>
            </Columns>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </asp:GridView>
        <div style="margin: 1px; text-align: left; font-size: 12px;">
            <table cellspacing="0" cellpadding="1" border="0" style="background-color: #cccccc;
                width: 100%; text-align: left;">
                <tr>
                    <td style="background-color: #EFEFEF; text-align: left;">
                        
                                           <a href="<%= _Site.Url %>" target="_blank" style="text-decoration: none; font-size: 14px;padding-left: 10px;"><%=_Site.Name %>首页</a>
                    <a href="<%= ResolveUrl("~/Lottery/Buy_SSQ.aspx") %>" target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">双色球投注/合买</a>
                        <a href="<%= ResolveUrl("~/WinQuery/5-0-0.aspx") %>" target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">双色球中奖查询</a>
                                    <span class='blue14' style='padding-left: 30px;
                                        padding-right: 8px;'>双色球:</span><a href='SSQ_CGXMB.aspx' target='mainFrame'>常规项目表走势图</a>
                        | <a href='SSQ_ZHFB.aspx' target='mainFrame'>综合分布图走势图</a> | <a href='SSQ_3FQ.aspx' target='mainFrame'>
                            3分区分布图走势图</a> | <a href='SSQ_DX.aspx' target='mainFrame'>大小分析走势图</a> | <a href='SSQ_JO.aspx'
                                target='mainFrame'>奇偶分析走势图</a> | <a href='SSQ_ZH.aspx' target='mainFrame'>质合分析走势图</a>
                        | <a href='SSQ_HL.aspx' target='mainFrame'>红蓝球走势图</a> | <a href='SSQ_BQZST.aspx'
                            target='mainFrame'>蓝球综合走势图</a>
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
