<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/SYYDJ/SYDJ_Q2HZ.aspx.cs" inherits="Default2HZ" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries"
    TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>十一运夺金前二和值图-十一运夺金走势图-彩票走势图表和数据分析－<%=_Site.Name %></title>
    <meta name="keywords" content="十一运夺金走势图-前二和值" />
    <meta name="description" content="十一运夺金走势图-前二和值、彩票走势图表和数据分析。" />
    <link href="../CSS/datachart.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
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
        <div class="wrap_datachart">
            <div class="tubiao_box">
                <div class="tubiao_box_t">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td style="text-align: left; font-size: 12px; width: 300px;">
                                <a href="<%= _Site.Url %>" target="_blank" style="text-decoration: none; font-size: 14px;
                                    padding-left: 10px;"><%=_Site.Name %>首页</a> <a href="<%= ResolveUrl("~/Lottery/Buy_SYYDJ.aspx") %>"
                                        target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">十一运投注/合买</a>
                                <a href="<%= ResolveUrl("~/WinQuery/62-0-0.aspx") %>" target="_blank" style="padding-left: 10px;
                                    text-decoration: none; color: Red;">十一运中奖查询</a>
                            </td>
                            <td>
                                <h1 class="td" style="font-weight: bold; font-size: 18px;display:inline;">
                                    前二和值走势图</h1>
                            </td>
                            <td align="right">
                                <asp:LinkButton ID="lbtnToday" runat="server" Style="text-decoration: none;" OnClick="lbtnToday_Click">今日数据</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtnLast" runat="server" Style="text-decoration: none;" OnClick="lbtnLast_Click">昨日数据</asp:LinkButton>
                                &nbsp;最近
                                <label>
                                    <asp:DropDownList ID="ddlSelect" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSelect_SelectedIndexChanged">
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:DropDownList>
                                </label>
                                天
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="width: 950px; height: 0px; clear: both; line-height: 0px; font-size: 0px;">
                </div>
            </div>
            <div class="chart">
                <asp:GridView ID="gvtable" runat="server" class="zs_table" OnRowCreated="gvtable_RowCreated"
                    ShowFooter="True" border="0" CellPadding="0" CellSpacing="1" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Name" />
                        <asp:BoundField DataField="ball_1" ItemStyle-Width="28" />
                        <asp:BoundField DataField="ball_2" ItemStyle-Width="28" />
                        <asp:BoundField DataField="b3" />
                        <asp:BoundField DataField="b4" />
                        <asp:BoundField DataField="b5" />
                        <asp:BoundField DataField="b6" />
                        <asp:BoundField DataField="b7" />
                        <asp:BoundField DataField="b8" />
                        <asp:BoundField DataField="b9" />
                        <asp:BoundField DataField="b10" />
                        <asp:BoundField DataField="b11" />
                        <asp:BoundField DataField="b12" />
                        <asp:BoundField DataField="b13" />
                        <asp:BoundField DataField="b14" />
                        <asp:BoundField DataField="b15" />
                        <asp:BoundField DataField="b16" />
                        <asp:BoundField DataField="b17" />
                        <asp:BoundField DataField="b18" />
                        <asp:BoundField DataField="b19" />
                        <asp:BoundField DataField="b20" />
                        <asp:BoundField DataField="b21" />
                        <asp:BoundField DataField="bb0" />
                        <asp:BoundField DataField="bb1" />
                        <asp:BoundField DataField="bb2" />
                        <asp:BoundField DataField="bb3" />
                        <asp:BoundField DataField="bb4" />
                        <asp:BoundField DataField="bb5" />
                        <asp:BoundField DataField="bb6" />
                        <asp:BoundField DataField="bb7" />
                        <asp:BoundField DataField="bb8" />
                        <asp:BoundField DataField="bb9" />
                        <asp:BoundField DataField="bc30" />
                        <asp:BoundField DataField="bc31" />
                        <asp:BoundField DataField="bc32" />
                        <asp:BoundField DataField="bc40" />
                        <asp:BoundField DataField="bc41" />
                        <asp:BoundField DataField="bc42" />
                        <asp:BoundField DataField="bc43" />
                        <asp:BoundField DataField="bc50" />
                        <asp:BoundField DataField="bc51" />
                        <asp:BoundField DataField="bc52" />
                        <asp:BoundField DataField="bc53" />
                        <asp:BoundField DataField="bc54" />
                        <asp:BoundField DataField="bd1" />
                        <asp:BoundField DataField="bd2" />
                        <asp:BoundField DataField="bj1" />
                        <asp:BoundField DataField="bj2" />
                    </Columns>
                </asp:GridView>
                <div class="chartIntro">
                    <br>
                    <strong>参数说明：</strong><br />
                    <span class="cfont4">[和值] 各个中奖号码数值之和<br />
                        [和尾] 和值的个位<br />
                    </span>
                    <br />
                </div>
            </div>
        </div>
        <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>

        <script language="javascript" type="text/javascript">
            function ShowImg(k, i, type) {
                if (k.innerHTML == "&nbsp;") {
                    if (type == 4) {
                        k.className = "chartBall04";
                        k.innerHTML = i.toString();
                    }
                    if (type == 2) {
                        k.className = "cbg4";
                        k.innerHTML = i.toString();
                    }
                    if (type == 3) {
                        k.className = "cbg8";
                        k.innerHTML = i.toString();
                    }
                    if (type == 6) {
                        k.className = "cbg8";
                        k.innerHTML = i.toString();
                    }
                    if (type == 5) {
                        k.className = "cbg4";
                        k.innerHTML = i.toString();
                    }

                }
                else {
                    k.className = "";
                    k.innerHTML = "&nbsp;";
                }
            }
        </script>
    </form>
</body>
</html>
