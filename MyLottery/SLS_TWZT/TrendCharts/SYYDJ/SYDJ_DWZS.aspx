<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/SYYDJ/SYDJ_DWZS.aspx.cs" inherits="_Default" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries"
    TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>十一运夺金定位走势图-十一运夺金走势图-彩票走势图表和数据分析－<%=_Site.Name %></title>
    <meta name="keywords" content="十一运夺金走势图-定位走势" />
    <meta name="description" content="十一运夺金走势图-定位走势、彩票走势图表和数据分析。" />
    <link href="../CSS/datachart.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/main.css" rel="stylesheet" type="text/css" />
    <style>
        esun\:*
        {
            behavior: url(#default#VML);
        }
        a
        {
            text-decoration: none;
        }
        .style1
        {
            width: 102px;
        }
        #box1
        {
            overflow: hidden;
            width: 1002px;
            margin-right: auto;
            margin-left: auto;
            padding: 0px;
        }
        .style2
        {
            width: 339px;
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
                            <td class="style1">
                                <h1 class="td" style="font-weight: bold; font-size: 18px;display:inline;">
                                    定位走势图</h1>
                            </td>
                            <td class="style2">
                                <span class="cfont1"></span>
                                <asp:LinkButton ID="lbtn1" runat="server" OnClick="lbtn1_Click">第一位</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtn2" runat="server" OnClick="lbtn2_Click">第二位</asp:LinkButton>
                                &nbsp; <span class=""></span>
                                <asp:LinkButton ID="lbtn3" runat="server" OnClick="lbtn3_Click">第三位</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtn4" runat="server" OnClick="lbtn4_Click">第四位</asp:LinkButton>&nbsp;
                                <asp:LinkButton ID="lbtn5" runat="server" OnClick="lbtn5_Click">第五位</asp:LinkButton>
                            </td>
                            <td align="right">
                                <asp:LinkButton ID="lbtnToday" runat="server" OnClick="lbtnToday_Click">今日数据</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lbtnLast" runat="server" OnClick="lbtnLast_Click">昨日数据</asp:LinkButton>
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
                    <div style="width: 950px; height: 0px; clear: both; line-height: 0px; font-size: 0px;">
                    </div>
                </div>
            </div>
            <div class="chart">
                <asp:GridView ID="gvtable" runat="server" class="zs_table" OnRowCreated="gvtable_RowCreated"
                    ShowFooter="True" border="0" CellPadding="0" CellSpacing="1" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Name" />
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
                        <asp:BoundField DataField="sb0" />
                        <asp:BoundField DataField="sb1" />
                        <asp:BoundField DataField="sb2" />
                        <asp:BoundField DataField="sb3" />
                        <asp:BoundField DataField="sb4" />
                        <asp:BoundField DataField="sb5" />
                        <asp:BoundField DataField="yb0" />
                        <asp:BoundField DataField="yb1" />
                        <asp:BoundField DataField="yb2" />
                        <asp:BoundField DataField="cb0" />
                        <asp:BoundField DataField="cb1" />
                        <asp:BoundField DataField="cb2" />
                        <asp:BoundField DataField="cb3" />
                    </Columns>
                </asp:GridView>
                <div class="chartIntro">
                    <br>
                    <strong>参数说明：</strong><br />
                    <span class="cfont4">[小奇质] 01 03 05<br />
                        [小偶质] 02<br />
                        [小偶合] 04<br />
                        [大奇质] 07 11
                        <br />
                        [大奇合] 09<br />
                        [大偶合] 06 08 10
                        <br />
                        [除3余0] 03 06 09<br />
                        [除3余1] 01 04 07 10<br />
                        [除3余2] 02 05 08 11<br />
                    </span>
                </div>
            </div>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>

    <script language="javascript" type="text/javascript">
        function ShowImg(k, i, type) {
            if (k.innerHTML == "&nbsp;") {
                if (type == 1) {
                    k.className = "chartBall01";
                    k.innerHTML = i.toString();
                }
                if (type == 2) {
                    k.className = "cbg4";
                    k.innerHTML = i.toString();
                }
                if (type == 3) {
                    k.className = "cbg5";
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
