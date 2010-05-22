<%@ page language="C#" autoeventwireup="true" CodeFile="ExpertsTrys.aspx.cs" inherits="Admin_ExpertsTrys" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 26px">
                        &nbsp;彩种：<asp:DropDownList ID="ddlLottery" runat="server" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="ddlLottery_SelectedIndexChanged">
                        </asp:DropDownList></td>
                </tr>
            </table>
            <table width="90%" height="34" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#85BDE2">
                <tr>
                    <td height="32" bgcolor="#B0D5EC" class="STYLE14">
                        <div align="left" class="STYLE4">
                            <div align="center">
                                处理专家申请</div>
                        </div>
                    </td>
                </tr>
            </table>
            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <asp:DataGrid ID="g" runat="server" CellPadding="0" BackColor="White" BorderWidth="2px" BorderStyle="None" BorderColor="#E0E0E0" Font-Names="宋体" PageSize="20" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" OnItemDataBound="g_ItemDataBound" Width="100%" OnItemCommand="g_ItemCommand">
                            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                            <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle" BackColor="LightGray"></HeaderStyle>
                            <Columns>
                                <asp:BoundColumn DataField="LotteryName" SortExpression="LotteryName" HeaderText="彩种">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:HyperLinkColumn DataNavigateUrlField="UserID" DataTextField="UserName" HeaderText="用户名" DataNavigateUrlFormatString="UserDetail.aspx?id={0}" SortExpression="Name"></asp:HyperLinkColumn>
                                <asp:BoundColumn DataField="DateTime" SortExpression="DateTime" HeaderText="申请时间">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Level" SortExpression="Level" HeaderText="星级">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="描述">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbDescription" runat="server" Width="336px" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="最大单价">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbMaxPrice" runat="server" Width="60px" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="所得佣金比例">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbBonusScale" runat="server" Width="60px" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="推荐">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbisCommend" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="操作">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <ShoveWebUI:ShoveLinkButton ID="btnAccept" runat="server" CommandName="Accept" AlertText="您确信输入无误，并立即同意此专家申请吗？">同意</ShoveWebUI:ShoveLinkButton>&nbsp;
                                        <ShoveWebUI:ShoveLinkButton ID="btnNoAccept" runat="server" CommandName="NoAccept" AlertText="您确信要拒绝此专家申请吗？">拒绝</ShoveWebUI:ShoveLinkButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn Visible="False" DataField="SiteID"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="Description"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="MaxPrice"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="BonusScale"></asp:BoundColumn>
                            </Columns>
                            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                        </asp:DataGrid>
                        <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" ShowSelectColumn="False" DataGrid="g" AlternatingRowColor="Linen" GridColor="#E0E0E0" HotColor="MistyRose" Visible="False" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore"></ShoveWebUI:ShoveGridPager>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
