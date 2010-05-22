<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Web/Live800UserInfo.aspx.cs" inherits="Home_Web_Live800UserInfo" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        body
        {
            font-size: 12px;
            font-family: Tahoma;
            margin: 5px;
            line-height: 2;
        }
        td
        {
            padding-left: 4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="HiddenUserID" runat="server" />
    <div>
        <table cellpadding="0" cellspacing="1" style="background-color: #c0c9ea; width: 100%;">
            <tbody style="background-color: White; vertical-align: top;">
                <tr>
                    <td style="width: 35%">
                        <table cellpadding="0" cellspacing="0" style="width: 100%;">
                            <tr>
                                <td style="text-align: right; width: 60px;">
                                    会员ID：<br />
                                    注册时间：<br />
                                    真实姓名：<br />
                                    账户余额：<br />
                                    联系电话：<br />
                                    手机号码：<br />
                                    QQ：<br />
                                    电子邮箱：<br />
                                    支付宝：
                                </td>
                                <td>
                                    <asp:Label ID="lbName" runat="server"></asp:Label><br />
                                    <asp:Label ID="lbRegTime" runat="server"></asp:Label><br />
                                    <asp:Label ID="lbRealityName" runat="server"></asp:Label><br />
                                    <asp:Label ID="lbBalance" runat="server"></asp:Label><br />
                                    <asp:Label ID="lbTel" runat="server"></asp:Label><br />
                                    <asp:Label ID="lbMobile" runat="server"></asp:Label><br />
                                    <asp:Label ID="lbQQ" runat="server"></asp:Label><br />
                                    <asp:Label ID="lbEmail" runat="server"></asp:Label><br />
                                    <asp:Label ID="lbAlipayName" runat="server"></asp:Label><br />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        投注记录：
                        <asp:DataGrid ID="gInvest" runat="server" Width="100%" BorderStyle="None" AllowSorting="True"
                            AllowPaging="True" PageSize="30" AutoGenerateColumns="False" CellPadding="2"
                            BackColor="#9FC8EA" Font-Names="Tahoma" OnItemDataBound="g_ItemDataBoundInvest"
                            CellSpacing="1" GridLines="None">
                            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                            <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                                BackColor="#E9F1F8" Height="25px"></HeaderStyle>
                            <AlternatingItemStyle BackColor="#F7FEFA" />
                            <ItemStyle BackColor="White" Height="21px"></ItemStyle>
                            <Columns>
                                <asp:BoundColumn DataField="DateTime" SortExpression="DateTime" HeaderText="时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="LotteryName" SortExpression="LotteryName" HeaderText="彩种">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="InitiateName" SortExpression="InitiateName" HeaderText="发起人">
                                    <HeaderStyle HorizontalAlign="Center" Width="12%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IsuseName" SortExpression="IsuseName" HeaderText="期号">
                                    <HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="PlayTypeName" SortExpression="PlayTypeName" HeaderText="类别">
                                    <HeaderStyle HorizontalAlign="Center" Width="14%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Money" SortExpression="Money" HeaderText="金额" DataFormatString="{0:N2}">
                                    <HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="Silver"
                                Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>
                        <ShoveWebUI:ShoveGridPager ID="gPagerInvest" runat="server" Width="100%" PageSize="2"
                            ShowSelectColumn="False" DataGrid="gInvest" AlternatingRowColor="#F7FEFA" GridColor="#E0E0E0"
                            HotColor="MistyRose" Visible="False" OnPageWillChange="gPagerInvest_PageWillChange"
                            OnSortBefore="gPagerInvest_SortBefore" RowCursorStyle="" />
                        中奖信息：
                        <asp:DataGrid ID="gWin" runat="server" Width="100%" BorderStyle="None" AllowSorting="True"
                            AllowPaging="True" PageSize="30" AutoGenerateColumns="False" CellPadding="2"
                            BackColor="#9FC8EA" Font-Names="Tahoma" OnItemDataBound="g_ItemDataBoundInvest"
                            CellSpacing="1" GridLines="None">
                            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                            <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                                BackColor="#E9F1F8" Height="25px"></HeaderStyle>
                            <AlternatingItemStyle BackColor="#F7FEFA" />
                            <ItemStyle BackColor="White" Height="21px"></ItemStyle>
                            <Columns>
                                <asp:BoundColumn DataField="DateTime" SortExpression="DateTime" HeaderText="时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="LotteryName" SortExpression="LotteryName" HeaderText="彩种">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="InitiateName" SortExpression="InitiateName" HeaderText="发起人">
                                    <HeaderStyle HorizontalAlign="Center" Width="12%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IsuseName" SortExpression="IsuseName" HeaderText="期号">
                                    <HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="PlayTypeName" SortExpression="PlayTypeName" HeaderText="类别">
                                    <HeaderStyle HorizontalAlign="Center" Width="14%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="WinMoneyNoWithTax" SortExpression="WinMoneyNoWithTax" HeaderText="奖金" DataFormatString="{0:N2}">
                                    <HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="Silver"
                                Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>
                        <ShoveWebUI:ShoveGridPager ID="gPagerWin" runat="server" Width="100%" PageSize="2"
                            ShowSelectColumn="False" DataGrid="gWin" AlternatingRowColor="#F7FEFA" GridColor="#E0E0E0"
                            HotColor="MistyRose" Visible="False" OnPageWillChange="gPagerWin_PageWillChange"
                            OnSortBefore="gPagerWin_SortBefore" RowCursorStyle="" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
        <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
