<%@ page language="C#" autoeventwireup="true" CodeFile="WinList.aspx.cs" inherits="Admin_WinList" enableEventValidation="false" %>

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
                        &nbsp;彩种：
                            <asp:DropDownList ID="ddlLottery" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLottery_SelectedIndexChanged"
                                Width="140px">
                            </asp:DropDownList>&nbsp;
                            <asp:DropDownList ID="ddlIsuse" runat="server" Width="120px">
                            </asp:DropDownList>&nbsp;
                            <asp:Button ID="btnGo" runat="server" BorderStyle="None" Height="20px"
                                OnClick="btnGo_Click" Style="background-image: url(../Images/btnBack02.gif);
                                cursor: hand" Text="查询" Width="84px" /></td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:DataGrid ID="g" runat="server" Width="99%" AutoGenerateColumns="False" CellPadding="1"
                            BackColor="White" BorderWidth="2px" BorderStyle="None" BorderColor="#E0E0E0"
                            Font-Names="宋体" PageSize="30" AllowPaging="True" OnItemDataBound="g_ItemDataBound">
                            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                            <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                                BackColor="LightGray"></HeaderStyle>
                            <Columns>
                                <asp:BoundColumn DataField="InitiateName" HeaderText="发起人">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:HyperLinkColumn DataNavigateUrlField="id" DataNavigateUrlFormatString="../Home/Room/Scheme.aspx?id={0}"
                                    DataTextField="SchemeNumber" HeaderText="方案号">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:HyperLinkColumn>
                                <asp:BoundColumn DataField="Money" HeaderText="方案金额">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                        Font-Strikeout="False" Font-Underline="False"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="中奖情况" DataField="WinDescription">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="WinMoney" HeaderText="中奖金额">
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Right" />
                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="WinMoneyNoWithTax" HeaderText="税后奖金">
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Right" />
                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Multiple" HeaderText="倍数">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                        Font-Strikeout="False" Font-Underline="False"></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                            </PagerStyle>
                        </asp:DataGrid>
                        <ShoveWebUI:ShoveGridPager id="gPager" runat="server" width="100%" pagesize="30" showselectcolumn="False"
                            datagrid="g" allowshorting="False" alternatingrowcolor="Linen" gridcolor="#E0E0E0"
                            hotcolor="MistyRose" visible="False" onpagewillchange="gPager_PageWillChange" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
