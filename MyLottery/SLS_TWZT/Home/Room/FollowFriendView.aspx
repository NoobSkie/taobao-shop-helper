<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/FollowFriendView.aspx.cs" inherits="Home_Room_FollowFriendView" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <base target="_self" /></head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9FC8EA">
            <tr>
                <td valign="top" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="images/bg_blue_30.jpg">
                        <tr>
                            <td height="30">
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="40" height="30" align="center">
                                            <img src="images/jiantou_5.gif" width="12" height="8" />
                                        </td>
                                        <td class="blue_num">
                                            <asp:Label ID="lbUserName" runat="server" Text=""></asp:Label> 的自动跟单用户列表
                                        </td>
                                        <td style="padding-left:20px;">
                                            定制人数：<asp:Label ID="lbFollowCount" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:DataGrid ID="g" runat="server" Width="100%" BorderStyle="None" AllowSorting="True"
            AllowPaging="True" PageSize="22" AutoGenerateColumns="False" CellPadding="2"
            BackColor="#9FC8EA" Font-Names="Tahoma" OnItemDataBound="g_ItemDataBound" CellSpacing="1"
            GridLines="None" BorderColor="#E0E0E0" BorderWidth="2px">
            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
            <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                BackColor="#E9F1F8" Height="25px"></HeaderStyle>
            <ItemStyle Height="21px"></ItemStyle>
            <Columns>
                <asp:BoundColumn DataField="DateTime" HeaderText="定制时间">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Name" HeaderText="定制人">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="LotteryID" HeaderText="彩种">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="PlayTypeID" HeaderText="玩法">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="每次认购金额">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" ForeColor="Black"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Type" HeaderText="类型">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
            </Columns>
            <PagerStyle Visible="False"></PagerStyle>
        </asp:DataGrid>
        <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" PageSize="20"
            ShowSelectColumn="False" DataGrid="g" AlternatingRowColor="#F7FEFA" GridColor="#E0E0E0"
            HotColor="MistyRose" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore" RowCursorStyle="" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="HidID" runat="server" />
    </form>
        <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
