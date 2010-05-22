<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/PL3/Default.aspx.cs" inherits="Home_TrendCharts_PL3_Default" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>排列3走势图-彩票走势图表和数据分析－<%=_Site.Name %></title>
<meta name="keywords" content="排列3走势图" />
<meta name="description" content="排列3走势图、彩票走势图表和数据分析。" />

    <style type="text/css">
        .td
        {
            color: #cc0000;
            font-size: 16px;
        }
        td
        {
            font-size: 12px;
            font-family: tahoma;
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
    <a href="<%= _Site.Url %>" target="_blank" style="text-decoration: none; font-size: 14px;
                        padding-left: 10px;"><%=_Site.Name %>首页</a> <a href="<%= ResolveUrl("~/Lottery/Buy_PL3.aspx") %>"
                            target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">排列三投注/合买</a>
                    <a href="<%= ResolveUrl("~/WinQuery/63-0-0.aspx") %>" target="_blank" style="padding-left: 10px;
                        text-decoration: none; color: Red;">排列三中奖查询</a>
         <iframe id="mainFrame" name="mainFrame" width="1002px" height="800px" frameborder="0" src="PL3_HMFB.aspx"
                style="overflow-x: auto; overflow-y: hidden;"></iframe>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>
