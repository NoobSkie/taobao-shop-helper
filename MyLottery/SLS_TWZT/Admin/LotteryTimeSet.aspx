<%@ page language="C#" autoeventwireup="true" CodeFile="LotteryTimeSet.aspx.cs" inherits="Admin_LotteryTimeSet" enableEventValidation="false" %>

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
            <table id="Table1" cellspacing="0" cellpadding="0" width="70%" align="center" border="0">
                <tr>
                    <td align="center">
                        <asp:DataGrid ID="g" runat="server" Width="100%" BorderColor="#E0E0E0" BorderStyle="None" BorderWidth="2px" BackColor="White" CellPadding="0" AutoGenerateColumns="False" OnItemCommand="g_ItemCommand" OnItemDataBound="g_ItemDataBound">
                            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                            <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle" BackColor="Silver"></HeaderStyle>
                            <Columns>
                                <asp:BoundColumn DataField="LotteryName" HeaderText="彩种">
                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Name" HeaderText="玩法">
                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="用户截止提前分钟">
                                    <HeaderStyle Width="25%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbSystemEndAheadMinute" runat="server" Width="60"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="追号任务执行开始分数">
                                    <HeaderStyle Width="25%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbChaseExecuteDeferMinute" runat="server" Width="60"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="修改">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <ShoveWebUI:ShoveConfirmButton ID="btnOK" runat="server" Width="60px" Text="保存" CommandName="btnOK" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="LotteryID"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="MaxChaseIsuse"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="SystemEndAheadMinute"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="ChaseExecuteDeferMinute"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="Order"></asp:BoundColumn>
                            </Columns>
                            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                        </asp:DataGrid>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
