<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/TTCX4/4D_ZHFB.aspx.cs" inherits="Home_TrendCharts_4D_4D_ZHFB" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>天天彩选4-福彩4D综合分布图</title>
    <meta content="福彩天天彩选4,天天彩选4开奖号码" name="keywords" />
    <meta content="<%=_Site.Name %>，手机投注，电话投注，短信投注，网上购彩，合买代购，中国最大的彩标投注平台。时时乐，双色球，3D购彩。"
        name="description" />
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
        	font-family: tahoma;
        	text-align:center;
            margin:0px;
            margin-left:10px;
            margin-right:10px;
        }
        form
        {
            display:inline;
        }
         .in_text_hui
        {
            height: 18px;
            border: 1px solid #cccccc;
            background-color: #FFFFFF;
            color: #666666;
            font-size: 12px;
            
        }
         .Isuse
        {
            background-color: #DCDCDC;
            color: #676767;
            width: 60px;
        }
        .itemstyle1
        {
            background-color: #ffe8eb;
            width: 20px;
            height: 18px;
            color: #cccccc;
        }
        .itemstyle2
        {
            background-color: #ffffff;
            width: 20px;
            color: #cccccc;
        }
        .itemstyle3
        {
            background-color: #CBE5FE;
            width: 70px;
            color: #ff0000;
        }
    </style>

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

    <script src="../../../../JavaScript/TrendChart/wz_jsgraphics.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function DrawLine(ojbCurrnetTd, ojbPrevTd, color) {
            var ax = getCPX(document.getElementById(ojbCurrnetTd));
            var ay = getCPY(document.getElementById(ojbCurrnetTd));
            var bx = getCPX(document.getElementById(ojbPrevTd));
            var by = getCPY(document.getElementById(ojbPrevTd));

            var jgdiv1 = new jsGraphics("div2");

            jgdiv1.setColor(color);
            jgdiv1.setStroke(1);
            jgdiv1.drawLine(ax, ay, bx, by);
            jgdiv1.paint();
        }

        function getTop(obj) {
            var _offset = obj.offsetTop;
            if (obj.offsetParent != null) _offset += getTop(obj.offsetParent);
            return _offset;
        }

        function getLeft(obj) {
            var _offset = obj.offsetLeft;
            if (obj.offsetParent != null) _offset += getLeft(obj.offsetParent);
            return _offset;
        }

        function getCPX(obj) {
            return getLeft(obj) + obj.offsetWidth / 2;
        }
        
        function getCPY(obj) {
            return getTop(obj) + obj.offsetHeight / 2;
        }
       window.onresize = function RedrawLine()
         {
            _removeDiv();
             
            DrawLines();
         }
    </script>

 <link rel="shortcut icon" href="../../favicon.ico" /></head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%; height: 40px; background-image: url(../Images/bg11111.jpg);"
            cellspacing="0" cellpadding="0">
            <tbody>
                <tr>
                    <td style="width: 280px" align="center" valign="middle">
                        <span class="td" style="font-weight: bold; font-size: 18px">福彩4D&nbsp;&nbsp;综合分布图</span>
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
                        <a href="http://www.icaile.com" style="text-decoration: none; font-size: 14px;">上海福彩官网</a><a
                            href="../../../Home/Room/Buy.aspx?LotteryID=60" target="_blank"
                            style="padding-left: 5px; text-decoration: none; color: Red;">天天彩选4合买</a><a href="../../../Home/Room/Buy.aspx?LotteryID=60"
                                target="_blank" style="padding-left: 5px; text-decoration: none; color: Red;">天天彩选4代购</a>
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
        <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="false" FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" align="center" bordercolorlight="#808080" bordercolordark="#FFFFFF" RowStyle-HorizontalAlign="Center" CellPadding="0" ShowHeader="true" OnRowCreated="GridView1_RowCreated" ShowFooter="true">
            <FooterStyle HorizontalAlign="Center"></FooterStyle>
            <RowStyle HorizontalAlign="Center"></RowStyle>
            <Columns>
                <asp:BoundField DataField="Isuse" HeaderText="期号">
                    <ItemStyle  CssClass="Isuse" Font-Bold="true" />
                </asp:BoundField>
                <asp:BoundField DataField="LotteryNumber" HeaderText="开奖号码">
                    <ItemStyle CssClass="itemstyle3" />
                </asp:BoundField>
                <asp:BoundField DataField="H_Z" HeaderText="和值">
                    <ItemStyle Width="50" />
                </asp:BoundField>
                <asp:BoundField DataField="D1_0" HeaderText="01">
                    <ItemStyle CssClass="itemstyle1" Height="18px" />
                </asp:BoundField>
                <asp:BoundField DataField="D1_1" HeaderText="02">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D1_2" HeaderText="03">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D1_3" HeaderText="04">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D1_4" HeaderText="05">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D1_5" HeaderText="06">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D1_6" HeaderText="07">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D1_7" HeaderText="08">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D1_8" HeaderText="09">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D1_9" HeaderText="10">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D2_0" HeaderText="11">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D2_1" HeaderText="12">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D2_2" HeaderText="13">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D2_3" HeaderText="14">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D2_4" HeaderText="15">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D2_5" HeaderText="16">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D2_6" HeaderText="17">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D2_7" HeaderText="18">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D2_8" HeaderText="19">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D2_9" HeaderText="20">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D3_0" HeaderText="21">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D3_1" HeaderText="22">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D3_2" HeaderText="23">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D3_3" HeaderText="24">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D3_4" HeaderText="25">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D3_5" HeaderText="26">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D3_6" HeaderText="27">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D3_7" HeaderText="28">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D3_8" HeaderText="29">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D3_9" HeaderText="30">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="D4_0" HeaderText="21">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D4_1" HeaderText="22">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D4_2" HeaderText="23">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D4_3" HeaderText="24">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D4_4" HeaderText="25">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D4_5" HeaderText="26">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D4_6" HeaderText="27">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D4_7" HeaderText="28">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D4_8" HeaderText="29">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="D4_9" HeaderText="30">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
            </Columns>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </asp:GridView>
       <asp:Label ID="lbline" runat="server"></asp:Label>
    </div>
    <script type="text/javascript">
       DrawLines();
    </script>
    <div style="margin: 1px; text-align: left; font-size: 12px;">
        <table cellspacing="0" cellpadding="1" border="0" style="background-color: #cccccc;
            width: 100%; text-align: left;">
            <tr>
                <td style="background-color: #EFEFEF; text-align: left;">
                    <span style="font-size: 14px;">热门链接</span><a href="http://www.icaile.com" style="text-decoration: none;
                        padding-left: 10px;">上海福彩官网</a><a href="../../../Home/Room/Buy.aspx?LotteryID=60"
                            target="_blank" style="padding-left: 5px; text-decoration: none; color: Red;">天天彩选4合买</a><a
                                href="../../../Home/Room/Buy.aspx?LotteryID=60" target="_blank"
                                style="padding-left: 5px; text-decoration: none; color: Red;">天天彩选4代购</a>
            </td>
            </tr>
        </table>
    </div>
    </form>
    
<!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
