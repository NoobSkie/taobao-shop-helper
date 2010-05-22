<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/SYYDJ/SYDJ_Q3FWT.aspx.cs" inherits="Default3FW" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries"
    TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>十一运夺金前三分位图-十一运夺金走势图-彩票走势图表和数据分析－<%=_Site.Name %></title>
    <meta name="keywords" content="十一运夺金走势图-前三分位图" />
    <meta name="description" content="十一运夺金走势图-前三分位图、彩票走势图表和数据分析。" />
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
                                    前三分位走势图</h1>
                            </td>
                            <td align="right">
                                <asp:LinkButton ID="lbtnToday" runat="server" Style="text-decoration: none;" OnClick="lbtnToday_Click">今日数据</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtnLast" runat="server" Style="text-decoration: none;" OnClick="lbtnLast_Click">昨日数据</asp:LinkButton>
                                &nbsp;最近
                                <label>
                                    <asp:DropDownList ID="ddlSelect" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSelect_SelectedIndexChanged"
                                        Style="height: 22px">
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
                        <asp:BoundField DataField="ball_3" ItemStyle-Width="28" />
                        <asp:BoundField DataField="b1" />
                        <asp:BoundField DataField="b2" />
                        <asp:BoundField DataField="b3" />
                        <asp:BoundField DataField="b4" />
                        <asp:BoundField DataField="b5" />
                        <asp:BoundField DataField="b6" />
                        <asp:BoundField DataField="b7" />
                        <asp:BoundField DataField="b8" />
                        <asp:BoundField DataField="b9" />
                        <asp:BoundField DataField="b10" />
                        <asp:BoundField DataField="b11" />
                        <asp:BoundField DataField="bb1" />
                        <asp:BoundField DataField="bb2" />
                        <asp:BoundField DataField="bb3" />
                        <asp:BoundField DataField="bb4" />
                        <asp:BoundField DataField="bb5" />
                        <asp:BoundField DataField="bb6" />
                        <asp:BoundField DataField="bb7" />
                        <asp:BoundField DataField="bb8" />
                        <asp:BoundField DataField="bb9" />
                        <asp:BoundField DataField="bb10" />
                        <asp:BoundField DataField="bb11" />
                        <asp:BoundField DataField="bc1" />
                        <asp:BoundField DataField="bc2" />
                        <asp:BoundField DataField="bc3" />
                        <asp:BoundField DataField="bc4" />
                        <asp:BoundField DataField="bc5" />
                        <asp:BoundField DataField="bc6" />
                        <asp:BoundField DataField="bc7" />
                        <asp:BoundField DataField="bc8" />
                        <asp:BoundField DataField="bc9" />
                        <asp:BoundField DataField="bc10" />
                        <asp:BoundField DataField="bc11" />
                        <asp:BoundField DataField="bd0" />
                        <asp:BoundField DataField="bd1" />
                        <asp:BoundField DataField="bd2" />
                        <asp:BoundField DataField="bd3" />
                        <asp:BoundField DataField="be0" />
                        <asp:BoundField DataField="be1" />
                        <asp:BoundField DataField="be2" />
                        <asp:BoundField DataField="be3" />
                    </Columns>
                </asp:GridView>
                <div class="chartIntro">
                    <br>
                    <strong>参数说明：</strong><br />
                    <span class="cfont4">[奇数] 01 03 05 07 09 11<br />
                        [偶数] 02 04 06 08 10<br />
                        [大数] 06 07 08 09 10 11<br />
                        [小数] 01 02 03 04 05<br />
                    </span>
                    <br />
                </div>
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
                    k.className = "chartBall02";
                    k.innerHTML = i.toString();
                }
                if (type == 3) {
                    k.className = "chartBall03";
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
