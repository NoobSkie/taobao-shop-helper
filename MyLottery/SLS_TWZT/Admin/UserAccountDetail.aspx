<%@ page language="C#" autoeventwireup="true" CodeFile="UserAccountDetail.aspx.cs" inherits="Admin_UserAccountDetail" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                    <font face="宋体">&nbsp;用户名：
                        <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>&nbsp;
                        <asp:DropDownList ID="ddlYear" runat="server" Width="88px">
                        </asp:DropDownList>
                        &nbsp;
                        <asp:DropDownList ID="ddlMonth" runat="server" Width="80px" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
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
                        &nbsp;
                        <asp:DropDownList ID="ddlDay" runat="server" Width="88px">
                        </asp:DropDownList>
                        &nbsp;</font>
                    <ShoveWebUI:ShoveConfirmButton ID="btnRead" runat="server" Text="读取数据" Width="78px" OnClick="btnRead_Click" />
                    <asp:TextBox ID="tbID" runat="server" Width="100px" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:DataGrid ID="g" runat="server" Width="100%"  AutoGenerateColumns="False" 
                        CellPadding="1" BackColor="White" BorderWidth="2px" BorderStyle="None" 
                        BorderColor="#E0E0E0" Font-Names="宋体" PageSize="30" AllowPaging="True" 
                        OnItemDataBound="g_ItemDataBound" ShowFooter="true">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle" BackColor="LightGray"></HeaderStyle>
                        <Columns>
                            <asp:TemplateColumn HeaderText="时间">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" 
                                        Text='<%# DataBinder.Eval(Container, "DataItem.DateTime") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="14%" />
                                <FooterStyle Width="14%" />
                                <FooterTemplate></FooterTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="摘要">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblMemo" 
                                        Text='<%# DataBinder.Eval(Container, "DataItem.Memo") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    
                                </FooterTemplate>
                                <HeaderStyle Width="40%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="收入(元)">
                                <ItemTemplate>
                                    <asp:Label ID="lblIn" runat="server" 
                                        Text='<%# DataBinder.Eval(Container, "DataItem.MoneyAdd") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    
                                </FooterTemplate>
                                <HeaderStyle Width="7%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="支出(元)">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" 
                                        Text='<%# DataBinder.Eval(Container, "DataItem.MoneySub") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="MoneySub" runat="server" Text=""></asp:Label>
                                </FooterTemplate>
                                <HeaderStyle Width="8ex" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="(手续费)">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FormalitiesFees") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="FormalitiesFees" runat="server" Text=""></asp:Label>
                                </FooterTemplate>
                                <HeaderStyle Width="8%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="余额">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Balance") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    
                                </FooterTemplate>
                                <HeaderStyle Width="8%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="中奖金额">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Reward") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="Reward" runat="server" Text=""></asp:Label>
                                </FooterTemplate>
                                <HeaderStyle Width="8%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="中奖总额">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="Label6" Text='<%# DataBinder.Eval(Container, "DataItem.SumReward") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="SumReward" runat="server" Text=""></asp:Label>
                                </FooterTemplate>
                                <HeaderStyle Width="8%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server"  ID="Label7"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.SchemeID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
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
