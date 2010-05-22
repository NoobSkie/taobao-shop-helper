<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/JXSSC/SSC_2X_KDZST.aspx.cs" inherits="Home_TrendCharts_JXSSC_SSC_2X_KDZST" enableEventValidation="false" %>

<%@ Register Src="../../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries"
    TagPrefix="uc1" %>
<%@ Register Src="../../Home/Room/UserControls/TrendChartHead.ascx" TagName="TrendChartHead"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ʱʱ�ʶ��ǿ������ͼ-ʱʱ������ͼ-��Ʊ����ͼ������ݷ�����<%=_Site.Name %></title>
    <meta name="keywords" content="ʱʱ������ͼ-ʱʱ�ʶ��ǿ������ͼ" />
    <meta name="description" content="ʱʱ������ͼ-ʱʱ�ʶ��ǿ������ͼ����Ʊ����ͼ������ݷ�����" />
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
            text-align: center;
            font-family: tahoma;
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
            width: 100px;
        }
        .itemstyle1
        {
            background-color: #FFE8EB;
            color: #999999;
            width: 18px;
        }
        .itemstyle2
        {
            background-color: #FFFFFF;
            color: #999999;
            width: 18px;
        }
        .itemstyle3
        {
            background-color: #ffffff;
            color: #ff0000;
            height: 16px;
            width: 25px;
        }
        .itemstyle4
        {
            background-color: #FFE8EB;
            color: #0000ff;
            height: 16px;
            width: 25px;
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

    <script src="../../JavaScript/TrendChart/wz_jsgraphics.js" type="text/javascript"></script>

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

        window.onresize = function RedrawLine() {
            _removeDiv();

            DrawLines();
        }
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
                            ʱʱ��&nbsp;&nbsp;���ǿ������ͼ</h1>
                    </td>
                    <td align="right" class="black12">
                        ��ʼ������<asp:TextBox ID="tb1" runat="server" Height="20px" Width="100px" CssClass="in_text_hui"></asp:TextBox>&nbsp;��&nbsp;<asp:TextBox
                            ID="tb2" runat="server" Height="20px" Width="100px" CssClass="in_text_hui"></asp:TextBox>
                    </td>
                    <td align="center" width="100" valign="middle">
                        <asp:Button ID="btnSearch" runat="server" Text="����" OnClick="btnSearch_Click" />
                    </td>
                    <td align="center" valign="middle">
                        <asp:Button ID="btnTop30" runat="server" Text="��ʾ30��" OnClick="btnTop30_Click" />
                        <asp:Button ID="btnTop50" runat="server" Text="��ʾ50��" OnClick="btnTop50_Click" />
                        <asp:Button ID="btnTop100" runat="server" Text="��ʾ100��" OnClick="btnTop100_Click" />
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
                            padding-left: 10px;"><%=_Site.Name %>��ҳ</a> <a href="<%= ResolveUrl("~/Lottery/Buy_SSC.aspx") %>"
                                target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">ʱʱ��Ͷע/����</a>
                        <a href="<%= ResolveUrl("~/WinQuery/61-0-0.aspx") %>" target="_blank" style="padding-left: 10px;
                            text-decoration: none; color: Red;">ʱʱ���н���ѯ</a>
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
        <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="false"
            FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" align="center"
            bordercolorlight="#808080" bordercolordark="#FFFFFF" RowStyle-HorizontalAlign="Center"
            CellPadding="0" ShowHeader="true" OnRowCreated="GridView1_RowCreated" ShowFooter="true">
            <RowStyle HorizontalAlign="Center"></RowStyle>
            <Columns>
                <asp:BoundField DataField="Isuse" HeaderText="�ں�">
                    <ItemStyle CssClass="Isuse" />
                </asp:BoundField>
                <asp:BoundField DataField="LotteryNumber" HeaderText="����">
                    <ItemStyle Font-Bold="true" Width="60" />
                </asp:BoundField>
                <asp:BoundField DataField="P_0" HeaderText="0">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="P_1" HeaderText="1">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="P_2" HeaderText="2">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="P_3" HeaderText="3">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="P_4" HeaderText="4">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="P_5" HeaderText="5">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="P_6" HeaderText="6">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="P_7" HeaderText="7">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="P_8" HeaderText="8">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="P_9" HeaderText="9">
                    <ItemStyle CssClass="itemstyle1" />
                </asp:BoundField>
                <asp:BoundField DataField="P_Z" HeaderText="ֵ">
                    <ItemStyle Width="50" ForeColor="Blue" Font-Bold="true" BackColor="#F7F7F7" />
                </asp:BoundField>
                <asp:BoundField DataField="J" HeaderText="��">
                    <ItemStyle CssClass="itemstyle3" />
                </asp:BoundField>
                <asp:BoundField DataField="O" HeaderText="ż">
                    <ItemStyle CssClass="itemstyle4" />
                </asp:BoundField>
                <asp:BoundField DataField="D" HeaderText="��">
                    <ItemStyle CssClass="itemstyle3" />
                </asp:BoundField>
                <asp:BoundField DataField="X" HeaderText="С">
                    <ItemStyle CssClass="itemstyle4" />
                </asp:BoundField>
                <asp:BoundField DataField="Z" HeaderText="��">
                    <ItemStyle CssClass="itemstyle3" />
                </asp:BoundField>
                <asp:BoundField DataField="H" HeaderText="��">
                    <ItemStyle CssClass="itemstyle4" />
                </asp:BoundField>
                <asp:BoundField DataField="L_0" HeaderText="0 ·">
                    <ItemStyle CssClass="itemstyle3" />
                </asp:BoundField>
                <asp:BoundField DataField="L_1" HeaderText="1 ·">
                    <ItemStyle CssClass="itemstyle4" />
                </asp:BoundField>
                <asp:BoundField DataField="L_2" HeaderText="2 ·">
                    <ItemStyle CssClass="itemstyle3" />
                </asp:BoundField>
                <asp:BoundField DataField="D_0" HeaderText="��">
                    <ItemStyle CssClass="itemstyle4" />
                </asp:BoundField>
                <asp:BoundField DataField="Z_0" HeaderText="��">
                    <ItemStyle CssClass="itemstyle3" />
                </asp:BoundField>
                <asp:BoundField DataField="X_0" HeaderText="С">
                    <ItemStyle CssClass="itemstyle4" />
                </asp:BoundField>
                <asp:BoundField DataField="F_0" HeaderText="0">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="F_1" HeaderText="1">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="F_2" HeaderText="2">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="F_3" HeaderText="3">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="F_4" HeaderText="4">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="F_5" HeaderText="5">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="F_6" HeaderText="6">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="F_7" HeaderText="7">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="F_8" HeaderText="8">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
                <asp:BoundField DataField="F_9" HeaderText="9">
                    <ItemStyle CssClass="itemstyle2" />
                </asp:BoundField>
            </Columns>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </asp:GridView>
        <asp:Label ID="lbline" runat="server"></asp:Label>

        <script type="text/javascript">
            DrawLines();
        </script>

        <div style="margin: 1px; text-align: left; font-size: 12px;">
            <table cellspacing="0" cellpadding="1" border="0" style="background-color: #cccccc;
                width: 100%; text-align: left;">
                <tr>
                    <td style="background-color: #EFEFEF; text-align: left;">
                        <a href="<%= _Site.Url %>" target="_blank"
                            style="text-decoration: none; font-size: 14px; padding-left: 10px;"><%=_Site.Name %>��ҳ</a>
                        <a href="<%= ResolveUrl("~/Lottery/Buy_SSC.aspx") %>" target="_blank" style="padding-left: 10px;
                            text-decoration: none; color: Red;">ʱʱ��Ͷע/����</a> <a href="<%= ResolveUrl("~/WinQuery/61-0-0.aspx") %>"
                                target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">ʱʱ���н���ѯ</a><span
                                    class='blue14' style='padding-right: 8px;'>ʱʱ��:</span><a href='SSC_5X_ZHFB.aspx'
                            target='mainFrame'>��׼�����ۺ�����ͼ</a> | <a href='SSC_5X_ZST.aspx' target='mainFrame'>��׼��������ͼ</a>
                        | <a href='SSC_5X_HZZST.aspx' target='mainFrame'>���Ǻ�ֵ����ͼ</a> | <a href='SSC_5X_KDZST.aspx'
                            target='mainFrame'>���ǿ������ͼ</a> | <a href='SSC_5X_PJZZST.aspx' target='mainFrame'>����ƽ��ֵ����ͼ</a>
                        | <a href='SSC_5X_DXZST.aspx' target='mainFrame'>���Ǵ�С����ͼ</a> | <a href='SSC_5X_JOZST.aspx'
                            target='mainFrame'>������ż����ͼ</a> | <a href='SSC_5X_ZHZST.aspx' target='mainFrame'>�����ʺ�����ͼ</a>
                        | <a href='SSC_4X_ZHFB.aspx' target='mainFrame'>��׼�����ۺ�����ͼ</a> |<a href='SSC_4X_ZST.aspx'
                            target='mainFrame'>��׼��������ͼ</a> | <a href='SSC_4X_HZZST.aspx' target='mainFrame'>���Ǻ�ֵ����ͼ</a>
                        | <a href='SSC_4X_KDZST.aspx' target='mainFrame'>���ǿ������ͼ</a> | <a href='SSC_4X_PJZZST.aspx'
                            target='mainFrame'>����ƽ��ֵ����ͼ</a> | <a href='SSC_4X_DXZST.aspx' target='mainFrame'>���Ǵ�С����ͼ</a>
                        | <a href='SSC_4X_JOZST.aspx' target='mainFrame'>������ż����ͼ</a> | <a href='SSC_4X_ZHZST.aspx'
                            target='mainFrame'>�����ʺ�����ͼ</a> | <a href='SSC_3X_ZHZST.aspx' target='mainFrame'>��׼�����ۺ�����ͼ</a>
                        | <a href='SSC_3X_ZST.aspx' target='mainFrame'>��׼��������ͼ</a> | <a href='SSC_3X_HZZST.aspx'
                            target='mainFrame'>���Ǻ�ֵ����ͼ</a> | <a href='SSC_3X_HZWZST.aspx' target='mainFrame'>���Ǻ�ֵβ����ͼ</a>
                        | <a href='SSC_3X_KDZST.aspx' target='mainFrame'>���ǿ������ͼ</a> | <a href='SSC_3X_DXZST.aspx'
                            target='mainFrame'>���Ǵ�С����ͼ</a> | <a href='SSC_3X_JOZST.aspx' target='mainFrame'>������ż����ͼ</a>
                        <a href='SSC_3X_ZhiHeZST.aspx' target='mainFrame'>�����ʺ�����ͼ</a> | <a href='SSC_3X_DX_012_ZST.aspx'
                            target='mainFrame'>��ѡ012·����ͼ</a> | <a href='SSC_3X_ZX_012_ZST.aspx' target='mainFrame'>
                                ��ѡ012·����ͼ</a> | <a href='SSC_2X_ZHFBZST.aspx' target='mainFrame'>��׼�����ۺ�����ͼ</a>
                        | <a href='SSC_2X_HZZST.aspx' target='mainFrame'>���Ǻ�ֵ����ͼ</a> | <a href='SSC_2X_HZWZST.aspx'
                            target='mainFrame'>���Ǻ�β����ͼ</a> | <a href='SSC_2XPJZZST.aspx' target='mainFrame'>���Ǿ�ֵ����ͼ</a>
                        | <a href='SSC_2X_KDZST.aspx' target='mainFrame'>���ǿ������ͼ</a> | <a href='SSC_2X_012ZST.aspx'
                            target='mainFrame'>����012·����ͼ</a> | <a href='SSC_2X_MaxZST.aspx' target='mainFrame'>�������ֵ����ͼ</a>
                        | <a href='SSC_2X_MinZST.aspx' target='mainFrame'>������Сֵ����ͼ</a> | <a href='SSC_2X_DXDSZST.aspx'
                            target='mainFrame'>��С��˫����ͼ</a>
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
