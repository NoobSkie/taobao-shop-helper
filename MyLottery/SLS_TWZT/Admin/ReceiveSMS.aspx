<%@ page language="C#" autoeventwireup="true" CodeFile="ReceiveSMS.aspx.cs" inherits="Admin_ReceiveSMS" enableEventValidation="false" %>

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
            <table id="Table1" cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
                <tr>
                    <td style="height: 8px">
                        <asp:DropDownList ID="ddlDateTime" runat="server" Width="152px" AutoPostBack="True" OnSelectedIndexChanged="ddlDateTime_SelectedIndexChanged">
                            <asp:ListItem Value="1">近 1 天</asp:ListItem>
                            <asp:ListItem Value="2">近 2 天</asp:ListItem>
                            <asp:ListItem Value="3">近 3 天</asp:ListItem>
                            <asp:ListItem Value="7">近 1 周</asp:ListItem>
                            <asp:ListItem Value="14">近 2 周</asp:ListItem>
                            <asp:ListItem Value="30">近 1 月</asp:ListItem>
                            <asp:ListItem Value="61">近 2 月</asp:ListItem>
                            <asp:ListItem Value="365">近 1 年</asp:ListItem>
                            <asp:ListItem Value="-1">全部</asp:ListItem>
                        </asp:DropDownList><font face="宋体">&nbsp; </font>
                        <asp:Label ID="labTip" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:DataGrid ID="g" runat="server" Width="100%" BorderColor="#CC9966" BorderStyle="None" BorderWidth="2px" BackColor="White" CellPadding="0" AutoGenerateColumns="False" PageSize="30" AllowPaging="True">
                            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                            <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle" BackColor="Silver"></HeaderStyle>
                            <Columns>
                                <asp:BoundColumn DataField="DateTime" HeaderText="时间">
                                    <HeaderStyle HorizontalAlign="Center" Width="18%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="From" HeaderText="来自">
                                    <HeaderStyle HorizontalAlign="Center" Width="12%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Content" HeaderText="短信内容">
                                    <HeaderStyle HorizontalAlign="Center" Width="70%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                        </asp:DataGrid>
                        <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" HotColor="MistyRose" GridColor="#E0E0E0" AlternatingRowColor="Linen" DataGrid="g" ShowSelectColumn="False" PageSize="30" Visible="False" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
