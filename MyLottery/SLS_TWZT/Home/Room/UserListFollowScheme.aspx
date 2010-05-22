<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/UserListFollowScheme.aspx.cs" inherits="Home_Room_UserListFollowScheme" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
     
    <link href="../../Style/css.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .STYLE1
        {
            font-size: 12px;
            font-weight: bold;
        }
        .STYLE2
        {
            font-size: 12px;
        }
        .STYLE4
        {
            font-size: 12px;
            color: #E93111;
        }
    </style>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <input id="tbUserID" runat="server" type="hidden" />
    <input id="tbLotteryID" runat="server" name="tbLotteryID" type="hidden" />
    <input id="tbPlayTypeID" runat="server" name="tbPlayTypeID" type="hidden" />
    <div>
        <table width="100%" border="0" cellspacing="1" cellpadding="0" style="background-color: #9FC8EA;">
            <tr>
                <td height="31">
                    &nbsp;<span class="STYLE1"><%=Name %>
                        的自动跟单人</span>
                </td>
            </tr>
            <tbody style="background-color: White;">
                <tr>
                    <td height="31">
                        &nbsp; <span class="STYLE4">
                            <%= LotteryName%>
                            <%= PlayTypeName%>
                            定制总人数：<asp:Label ID="lbCountUser" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="padding: 5px;">
                        <asp:DataGrid ID="g" runat="server" Width="100%" BorderStyle="None" AllowSorting="True"
                            AllowPaging="True" PageSize="30" AutoGenerateColumns="False" OnItemDataBound="g_ItemDataBound"
                            CellPadding="2" BackColor="#9FC8EA" Font-Names="Tahoma" CellSpacing="1" GridLines="None">
                            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                            <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                                BackColor="#E9F1F8" Height="25px"></HeaderStyle>
                            <AlternatingItemStyle BackColor="#F7FEFA" />
                            <ItemStyle BackColor="White" Height="21px"></ItemStyle>
                            <Columns>
                                <asp:BoundColumn DataField="DateTime" SortExpression="DateTime" HeaderText="定制时间"
                                    DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="UserName" SortExpression="UserName" HeaderText="认购人">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="每次认购金额">
                                    <HeaderStyle HorizontalAlign="Center" Width="16%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="TypeName" SortExpression="TypeName" HeaderText="类型">
                                    <HeaderStyle HorizontalAlign="Center" Width="12%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="Silver"
                                Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>
                        <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" PageSize="20"
                            ShowSelectColumn="False" DataGrid="g" AlternatingRowColor="#F7FEFA" GridColor="#E0E0E0"
                            HotColor="MistyRose" Visible="False" OnPageWillChange="gPager_PageWillChange"
                            OnSortBefore="gPager_SortBefore" RowCursorStyle="" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
