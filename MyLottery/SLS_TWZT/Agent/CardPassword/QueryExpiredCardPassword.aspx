<%@ page language="C#" autoeventwireup="true" CodeFile="QueryExpiredCardPassword.aspx.cs" inherits="Agent_CardPassword_QueryExpiredCardPassword" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
<link href="../../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../../Style/main.css" type="text/css" rel="stylesheet" />
</head><link rel="shortcut icon" href="../favicon.ico" />
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
                <td style="height: 30px">
                    <font face="宋体">&nbsp;卡号：
                        <asp:TextBox ID="tbCardPasswordID" runat="server"></asp:TextBox>&nbsp; &nbsp;时间：
                        <asp:TextBox ID="tbDateTime" runat="server"></asp:TextBox>&nbsp;</font>
                        <ShoveWebUI:ShoveConfirmButton ID="btnRead" runat="server" Text="查找" Width="78px" OnClick="btnQuery_Click" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:DataGrid ID="g" runat="server" CellPadding="0" BackColor="White" BorderWidth="2px"
                        BorderStyle="None" BorderColor="#E0E0E0" Font-Names="宋体" PageSize="20" AllowSorting="True"
                        AutoGenerateColumns="False" AllowPaging="True" OnItemDataBound="g_ItemDataBound"
                        Width="100%">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                            BackColor="LightGray"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn HeaderText="卡密号">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Money" SortExpression="Money" HeaderText="卡密金额">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DateTime" SortExpression="DateTime" HeaderText="过期时间">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                        </PagerStyle>
                    </asp:DataGrid>
                    <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" ShowSelectColumn="False"
                        DataGrid="g" AlternatingRowColor="Linen" GridColor="#E0E0E0" HotColor="MistyRose"
                        Visible="False" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore">
                    </ShoveWebUI:ShoveGridPager>
                </td>
            </tr>
            <tr>
                <td>
                <br />
                    <asp:Button ID="btnExcel" runat="server" Text="导出Excel" Height="22px" Width="90px"
                        OnClick="btnExcel_Click" />
                </td>
            </tr>
        </table>
        <br />
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
