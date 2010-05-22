<%@ page language="C#" autoeventwireup="true" CodeFile="RecallingRecord.aspx.cs" inherits="Admin_RecallingRecord" enableEventValidation="false" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Home/Room/Style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    请输入中奖方案地址：<asp:TextBox ID="tbScheme" runat="server" Width="600px"></asp:TextBox>
    <asp:Button ID="btnOK" runat="server" Text="确定" onclick="btnOK_Click" />
    <asp:DataGrid ID="g" runat="server" Width="99%" AutoGenerateColumns="False" 
        CellPadding="1" BackColor="White" BorderWidth="2px" BorderStyle="None" 
        BorderColor="#E0E0E0" Font-Names="宋体" PageSize="20" AllowPaging="True" 
        AllowSorting="True" OnItemCommand="g_ItemCommand">
                            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                            <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle" BackColor="Silver"></HeaderStyle>
                            <Columns>
                                <asp:BoundColumn DataField="LotteryName" SortExpression="LotteryName" HeaderText="彩种名称">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="InitiateName" SortExpression="InitiateName" HeaderText="发起人">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Money" SortExpression="Money" HeaderText="方案金额">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="WinMoney" SortExpression="WinMoney" HeaderText="中奖金额">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Win" SortExpression="Win" HeaderText="盈利指数" DataFormatString="{0:N}">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="编辑">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <ShoveWebUI:ShoveLinkButton ID="btnDel" runat="server" CommandName="Del" AlertText="您确信要删除此条新闻资料吗？">删除</ShoveWebUI:ShoveLinkButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                            </Columns>
                            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                        </asp:DataGrid>
     <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" ShowSelectColumn="False" DataGrid="g" AlternatingRowColor="Linen" GridColor="#E0E0E0" HotColor="MistyRose" Visible="False" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore" />
    </form>
</body>
</html>
