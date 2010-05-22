<%@ page language="C#" autoeventwireup="true" CodeFile="Questions.aspx.cs" inherits="Admin_Questions" enableEventValidation="false" %>

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
            <table cellspacing="0" cellpadding="0" width="90%" border="0" align="center">
                <tr>
                    <td style="height: 16px">
                        &nbsp;<asp:RadioButton ID="rb1" runat="server" Text="全部问题" GroupName="Q" AutoPostBack="True" OnCheckedChanged="rb1_CheckedChanged"></asp:RadioButton>
                        <asp:RadioButton ID="rb2" runat="server" Text="已处理问题" GroupName="Q" AutoPostBack="True" OnCheckedChanged="rb1_CheckedChanged"></asp:RadioButton>
                        <asp:RadioButton ID="rb3" runat="server" Text="未处理问题" Checked="True" GroupName="Q" AutoPostBack="True" OnCheckedChanged="rb1_CheckedChanged"></asp:RadioButton><font face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 问题类型：</font>
                        <asp:DropDownList ID="ddlType" runat="server" Width="168px" AutoPostBack="True" OnSelectedIndexChanged="rb1_CheckedChanged">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:DataGrid ID="g" runat="server" Width="99%" AutoGenerateColumns="False" CellPadding="1" BackColor="White" BorderWidth="2px" BorderStyle="None" BorderColor="#E0E0E0" Font-Names="宋体" PageSize="30" AllowPaging="True" AllowSorting="True" OnItemDataBound="g_ItemDataBound" OnItemCommand="g_ItemCommand">
                            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                            <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle" BackColor="Silver"></HeaderStyle>
                            <Columns>
                                <asp:BoundColumn DataField="DateTime" SortExpression="DateTime" HeaderText="时间">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="用户名">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="QuestionType" SortExpression="QuestionType" HeaderText="类型">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Content" SortExpression="Content" HeaderText="问题描述">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn SortExpression="AnswerStatus" HeaderText="回复">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbAnswered" runat="server" Enabled="False"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="处理">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnAnswer" runat="server" CommandName="Answer">答复</asp:LinkButton>&nbsp;
                                        <asp:LinkButton ID="btnDel" runat="server" CommandName="Del">删除</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn Visible="False" DataField="ID" SortExpression="ID"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="UserID" SortExpression="UserID"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="AnswerStatus" SortExpression="AnswerStatus"></asp:BoundColumn>
                            </Columns>
                            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                        </asp:DataGrid>
                        <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" PageSize="30" ShowSelectColumn="False" DataGrid="g" AlternatingRowColor="Linen" GridColor="#E0E0E0" HotColor="MistyRose" Visible="False" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
