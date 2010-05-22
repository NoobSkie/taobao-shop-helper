<%@ page language="C#" autoeventwireup="true" CodeFile="StationSMSList.aspx.cs" inherits="Admin_StationSMSList" enableEventValidation="false" %>

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
                    <td align="center">
                        <asp:DataGrid ID="g" runat="server" Width="99%" AutoGenerateColumns="False" CellPadding="0" BackColor="White" BorderWidth="2px" BorderStyle="None" BorderColor="#E0E0E0" PageSize="30" AllowPaging="True" AllowSorting="True" OnItemCommand="g_ItemCommand" OnItemCreated="g_ItemCreated" OnItemDataBound="g_ItemDataBound">
                            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                            <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle" BackColor="Silver"></HeaderStyle>
                            <Columns>
                                <asp:HyperLinkColumn DataNavigateUrlField="SourceID" DataNavigateUrlFormatString="UserDetail.aspx?id={0}" DataTextField="SourceUserName" SortExpression="SourceUserName" HeaderText="发言人">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:HyperLinkColumn>
                                <asp:HyperLinkColumn DataNavigateUrlField="AimID" DataNavigateUrlFormatString="UserDetail.aspx?id={0}" DataTextField="AimUserName" SortExpression="AimUserName" HeaderText="接收人">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:HyperLinkColumn>
                                <asp:BoundColumn DataField="Content" SortExpression="Content" HeaderText="内容">
                                    <HeaderStyle HorizontalAlign="Center" Width="50%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DateTime" SortExpression="DateTime" HeaderText="发言时间">
                                    <HeaderStyle HorizontalAlign="Center" Width="18%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="删除">
                                    <HeaderStyle HorizontalAlign="Center" Width="6%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <ShoveWebUI:ShoveConfirmButton ID="btnDel" BackgroupImage="../Images/Admin/buttbg.gif" runat="server" Width="60px" CommandName="Del" Height="20px" Text="删除" AlertText="确定要删除此条短消息吗？" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn SortExpression="isShow" HeaderText="显示">
                                    <HeaderStyle HorizontalAlign="Center" Width="6%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbisShow" runat="server" AutoPostBack="True"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn Visible="False" DataField="ID" SortExpression="ID"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="isShow" SortExpression="isShow"></asp:BoundColumn>
                            </Columns>
                            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                        </asp:DataGrid>
                        <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" PageSize="30" ShowSelectColumn="False" DataGrid="g" AlternatingRowColor="Linen" GridColor="#E0E0E0" HotColor="MistyRose" Visible="False" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
