<%@ page language="C#" autoeventwireup="true" CodeFile="FinanceDistill.aspx.cs" inherits="Admin_FinanceDistill" enableEventValidation="false" %>

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
        <table cellspacing="0" cellpadding="0" width="97%" border="0" align="center">
            <tr>
                <td style="height: 30px">
                    <font face="宋体">&nbsp;用户名：
                        <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>&nbsp;
                        <asp:DropDownList ID="ddlYear" runat="server" Width="88px">
                        </asp:DropDownList>
                        &nbsp;
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
                        </asp:DropDownList>
                        &nbsp;</font>
                    <ShoveWebUI:ShoveConfirmButton ID="btnRead" runat="server" Text="读取数据" Width="78px"
                        OnClick="btnRead_Click" />
                    <span style="color: #ff0000">(不输入用户名表示全部用户)</span><asp:TextBox ID="tbID" runat="server"
                        Width="100px" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:DataGrid ID="g" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
                        BackColor="White" BorderWidth="2px" BorderStyle="None" BorderColor="#E0E0E0"
                        Font-Names="宋体" PageSize="20" AllowPaging="True" OnItemDataBound="g_ItemDataBound">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                            BackColor="LightGray"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn DataField="ID" HeaderText="提款流水号" SortExpression="ID">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Name" HeaderText="用户名称">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="RealityName" HeaderText="真实姓名" SortExpression="RealityName">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                             </asp:BoundColumn>
                            <asp:BoundColumn DataField="DateTime" HeaderText="申请时间">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Money" HeaderText="提取金额" DataFormatString="{0:N2}">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                    Font-Strikeout="False" Font-Underline="False" ForeColor="#FF0000"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="FormalitiesFees" HeaderText="手续费" DataFormatString="{0:N2}">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Result" HeaderText="状态">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="银行提款">
                                <ItemTemplate>
                                    <%# Eval("BankCardNumber").ToString() == "" ? "支付宝提款" : Eval("BankName")%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="银行卡号">
                                <ItemTemplate>
                                    <%# Eval("BankCardNumber").ToString() == "" ? "支付宝账号:" + Eval("AlipayName") : Eval("BankCardNumber")%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="Memo" HeaderText="备注">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="HandleDateTime" HeaderText="受理时间">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundColumn>
                            
                            <asp:BoundColumn Visible="False" DataField="UserID"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="SiteID"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                        </PagerStyle>
                    </asp:DataGrid>
                    <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" ShowSelectColumn="False"
                        DataGrid="g" AllowShorting="False" AlternatingRowColor="Linen" GridColor="#E0E0E0"
                        HotColor="MistyRose" Visible="False" OnPageWillChange="gPager_PageWillChange" />
                </td>
            </tr>
        </table>
        <br />
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
