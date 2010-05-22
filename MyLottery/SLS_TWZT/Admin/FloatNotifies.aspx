<%@ page language="C#" autoeventwireup="true" CodeFile="FloatNotifies.aspx.cs" inherits="Admin_FloatNotifies" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center; margin-top: 10px;">
        <table cellspacing="0" cellpadding="0" width="90%" border="0" align="center">
            <tr>
                <td style="text-align: left;">
                    <asp:LinkButton ID="lbAdd" runat="server" Text="添加" PostBackUrl="FloatNotifiesAdd.aspx"></asp:LinkButton> 
                </td>
                <td align="right">
                    浮出广告时间
                </td>
                <td align="left">
                    <asp:RadioButtonList ID="rblTime" RepeatDirection="Horizontal" runat="server" 
                        AutoPostBack="True" onselectedindexchanged="rblTime_SelectedIndexChanged">
                        <asp:ListItem Value="1">登录浮出</asp:ListItem>
                        <asp:ListItem Value="2">整点浮出</asp:ListItem>
                        <asp:ListItem Value="3">马上浮出</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="3">
                    <asp:DataGrid ID="g" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
                        BackColor="White" BorderWidth="2px" BorderStyle="None" BorderColor="#E0E0E0"
                        Font-Names="宋体" PageSize="20" OnItemCommand="g_ItemCommand" OnItemDataBound="g_ItemDataBound">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                            BackColor="Silver"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn DataField="Title" SortExpression="Title" HeaderText="名称">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Url" SortExpression="Url" HeaderText="链接地址">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DateTime" SortExpression="DateTime" HeaderText="时间" DataFormatString="{0:yyyy-MM-dd}">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Order" SortExpression="Order" HeaderText="顺序">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn SortExpression="isShow" HeaderText="显示">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbisShow" runat="server" Enabled="False"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="操作">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <ShoveWebUI:ShoveLinkButton ID="btnEdit" runat="server" CommandName="Edit">修改</ShoveWebUI:ShoveLinkButton>
                                    <ShoveWebUI:ShoveLinkButton ID="btnDelete" runat="server" CommandName="Deletes" AlertText="真的要删除吗？">删除</ShoveWebUI:ShoveLinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn Visible="False" DataField="ID" SortExpression="ID"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="isShow" SortExpression="isShow"></asp:BoundColumn>
                        </Columns>
                    </asp:DataGrid>
                </td>
            </tr>
            <tr>
                <td style="height: 30px;" colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr id="adposition" style="display: none;">
                <td style="background-image: url(../Home/Web/images/room.gif); height: 550px; background-repeat: no-repeat;
                    background-position: top;" colspan="3">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
