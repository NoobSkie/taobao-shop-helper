<%@ page language="C#" autoeventwireup="true" CodeFile="LoginCount.aspx.cs" inherits="Admin_LoginCount" enableEventValidation="false" %>

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
            <table id="Table1" cellspacing="0" cellpadding="0" width="90%" border="0" align="center">
                <tr>
                    <td style="height: 30px">
                        <asp:DropDownList ID="ddlYear" runat="server" Width="88px">
                        </asp:DropDownList>&nbsp;
                        <asp:DropDownList ID="ddlMonth" runat="server" Width="80px">
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
                        </asp:DropDownList>&nbsp;
                        <ShoveWebUI:ShoveConfirmButton ID="btnGO" runat="server" Width="64px" Text="查询" OnClick="btnGO_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:DataGrid ID="g" runat="server" CellPadding="0" BackColor="White" BorderWidth="2px" BorderStyle="None" BorderColor="#CC9966" Font-Names="宋体" PageSize="30" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" Width="100%" OnItemDataBound="g_ItemDataBound">
                            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                            <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle" BackColor="Silver"></HeaderStyle>
                            <Columns>
                                <asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="用户名">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="RealityName" SortExpression="RealityName" HeaderText="真实姓名">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Province" SortExpression="Province" HeaderText="省份">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="City" SortExpression="City" HeaderText="城市">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d1" SortExpression="d1" HeaderText="1">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d2" SortExpression="d2" HeaderText="2">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d3" SortExpression="d3" HeaderText="3">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d4" SortExpression="d4" HeaderText="4">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d5" SortExpression="d5" HeaderText="5">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d6" SortExpression="d6" HeaderText="6">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d7" SortExpression="d7" HeaderText="7">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d8" SortExpression="d8" HeaderText="8">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d9" SortExpression="d9" HeaderText="9">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d10" SortExpression="d10" HeaderText="10">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d11" SortExpression="d11" HeaderText="11">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d12" SortExpression="d12" HeaderText="12">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d13" SortExpression="d13" HeaderText="13">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d14" SortExpression="d14" HeaderText="14">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d15" SortExpression="d15" HeaderText="15">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d16" SortExpression="d16" HeaderText="16">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d17" SortExpression="d17" HeaderText="17">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d18" SortExpression="d18" HeaderText="18">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d19" SortExpression="d19" HeaderText="19">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d20" SortExpression="d20" HeaderText="20">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d21" SortExpression="d21" HeaderText="21">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d22" SortExpression="d22" HeaderText="22">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d23" SortExpression="d23" HeaderText="23">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d24" SortExpression="d24" HeaderText="24">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d25" SortExpression="d25" HeaderText="25">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d26" SortExpression="d26" HeaderText="26">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d27" SortExpression="d27" HeaderText="27">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d28" SortExpression="d28" HeaderText="28">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d29" SortExpression="d29" HeaderText="29">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d30" SortExpression="d30" HeaderText="30">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="d31" SortExpression="d31" HeaderText="31">
                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="MonthTotal" SortExpression="MonthTotal" HeaderText="当月访问">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Total" SortExpression="Total" HeaderText="累计访问">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                        </asp:DataGrid>
                        <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" ShowSelectColumn="False" DataGrid="g" AlternatingRowColor="Linen" GridColor="#E0E0E0" HotColor="MistyRose" Visible="False" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
