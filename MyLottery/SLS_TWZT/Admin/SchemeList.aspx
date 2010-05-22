<%@ page language="C#" autoeventwireup="true" CodeFile="SchemeList.aspx.cs" inherits="Admin_SchemeList" enableEventValidation="false" %>

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
            <table cellpadding="0" cellspacing="0" style="width: 96%; height: 500px" align="center">
                <tr>
                    <td style="width: 140px; height: 528px" valign="top">
                        <table cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                            <tr style="height: 50%">
                                <td valign="top">
                                    <asp:ListBox ID="listLottery" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlLottery_SelectedIndexChanged" Height="100%"></asp:ListBox>
                                </td>
                            </tr>
                            <tr style="height: 50%">
                                <td valign="top">
                                    <asp:ListBox ID="listIsuse" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="listIsuse_SelectedIndexChanged" Height="100%"></asp:ListBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top" align="center">
                        <table border="0" style="width: 98%; height: 100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td bgcolor="#96DDFC" align="left" width="30%">
                                    &nbsp;出票操作员：<asp:DropDownList ID="ddlUser" runat="server" Width="118px" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                                <td bgcolor="#96DDFC" align="right" width="70%">
                                    <asp:RadioButton ID="radType_1" runat="server" GroupName="Randio_Select" Text="全部" OnCheckedChanged="RadTypeClick" AutoPostBack="true" Checked="true" />
                                    <asp:RadioButton ID="radType_2" runat="server" GroupName="Randio_Select" Text="已出票" OnCheckedChanged="RadTypeClick" AutoPostBack="true" />
                                    <asp:RadioButton ID="radType_3" runat="server" GroupName="Randio_Select" Text="未出票" OnCheckedChanged="RadTypeClick" AutoPostBack="true" />
                                    <asp:RadioButton ID="radType_4" runat="server" GroupName="Randio_Select" Text="已撤单" OnCheckedChanged="RadTypeClick" AutoPostBack="true" />
                                    <asp:RadioButton ID="radType_5" runat="server" GroupName="Randio_Select" Text="系统撤单" OnCheckedChanged="RadTypeClick" AutoPostBack="true" />
                                    <asp:RadioButton ID="radType_6" runat="server" GroupName="Randio_Select" Text="已中奖" OnCheckedChanged="RadTypeClick" AutoPostBack="true" />
                                    <asp:RadioButton ID="radType_7" runat="server" GroupName="Randio_Select" Text="未成功但中奖" OnCheckedChanged="RadTypeClick" AutoPostBack="true" />
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:DataGrid ID="g" runat="server" Width="100%" BorderWidth="0px" BackColor="White" Font-Names="宋体" AutoGenerateColumns="False" CellPadding="0" PageSize="20" AllowPaging="True" CellSpacing="1" GridLines="Horizontal" OnItemDataBound="g_ItemDataBound">
                                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                                        <AlternatingItemStyle BackColor="#E0F5FE"></AlternatingItemStyle>
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="MidnightBlue" VerticalAlign="Middle" BackColor="#96DDFC"></HeaderStyle>
                                        <Columns>
                                            <asp:BoundColumn DataField="LotteryName" HeaderText="彩种">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" CssClass="dotLineStyle"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="SchemeNumber" HeaderText="方案号">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" CssClass="dotLineStyle"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="InitiateName" HeaderText="发起人">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" CssClass="dotLineStyle"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="PlayTypeName" HeaderText="玩法">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" CssClass="dotLineStyle"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Money" HeaderText="总金额">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Right" CssClass="dotLineStyle"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="LotteryNumber" HeaderText="投注内容">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left" CssClass="dotLineStyle"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Share" HeaderText="份数">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" CssClass="dotLineStyle"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="每份">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Right" CssClass="dotLineStyle"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Schedule" HeaderText="进度">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" CssClass="dotLineStyle"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="状态">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" CssClass="dotLineStyle"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn Visible="False" DataField="AssureMoney"></asp:BoundColumn>
                                            <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                                            <asp:BoundColumn Visible="False" DataField="InitiateUserID"></asp:BoundColumn>
                                            <asp:BoundColumn Visible="False" DataField="QuashStatus"></asp:BoundColumn>
                                            <asp:BoundColumn Visible="False" DataField="PlayTypeID"></asp:BoundColumn>
                                            <asp:BoundColumn Visible="False" DataField="PlayTypeName"></asp:BoundColumn>
                                            <asp:BoundColumn Visible="False" DataField="Buyed"></asp:BoundColumn>
                                        </Columns>
                                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                                    </asp:DataGrid>
                                    <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" ShowSelectColumn="False" DataGrid="g" AlternatingRowColor="#E0F5FE" GridColor="Window" HotColor="MistyRose" GuiseColor="False" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>