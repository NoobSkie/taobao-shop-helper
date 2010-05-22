<%@ page language="C#" autoeventwireup="true" CodeFile="FinanceBalance.aspx.cs" inherits="Admin_FinanceBalance" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <table cellspacing="0" cellpadding="0" width="90%" border="0" align="center">
                <tr>
                    <td style="height: 30px">
                        <font face="宋体">&nbsp;<asp:DropDownList ID="ddlYear" runat="server" Width="88px" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                            </asp:DropDownList>&nbsp;
                            <asp:DropDownList ID="ddlMonth" runat="server" Width="80px" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                <asp:ListItem Value="1">1 月</asp:ListItem>
                                <asp:ListItem Value="2">2 月</asp:ListItem>
                                <asp:ListItem Value="3">3 月</asp:ListItem>
                                <asp:ListItem Value="4">4 月</asp:ListItem>
                                <asp:ListItem Value="5">5 月</asp:ListItem>
                                <asp:ListItem Value="6">6 月</asp:ListItem>
                                <asp:ListItem Value="7">7 月</asp:ListItem>
                                <asp:ListItem Value="8">8 月</asp:ListItem>
                                <asp:ListItem Value="9">9 月</asp:ListItem>
                                <asp:ListItem Value="10">10月</asp:ListItem>
                                <asp:ListItem Value="11">11月</asp:ListItem>
                                <asp:ListItem Value="12">12月</asp:ListItem>
                            </asp:DropDownList></font></td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:DataGrid ID="g" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1" BackColor="White" BorderWidth="2px" BorderStyle="None" BorderColor="#CC9966" Font-Names="宋体" PageSize="30" AllowPaging="True" OnItemDataBound="g_ItemDataBound">
                            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                            <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle" BackColor="LightGray"></HeaderStyle>
                            <Columns>
                                <asp:BoundColumn DataField="Year" HeaderText="年">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Month" HeaderText="月">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Day" HeaderText="日">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Buy" HeaderText="购彩交易额">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="SurrogateIn" HeaderText="收入代理佣金">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ExpertsIn" HeaderText="收入荐号佣金">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="SurrogateOut" HeaderText="支出代理佣金">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ScoringExchangeOut" HeaderText="支出积分兑换">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CpsOut" HeaderText="支出联盟推广佣金">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Earning" HeaderText="收入">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                        </asp:DataGrid>
                        <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" PageSize="30" ShowSelectColumn="False" DataGrid="g" AllowShorting="False" AlternatingRowColor="Linen" GridColor="#E0E0E0" HotColor="MistyRose" Visible="False" OnPageWillChange="gPager_PageWillChange" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
