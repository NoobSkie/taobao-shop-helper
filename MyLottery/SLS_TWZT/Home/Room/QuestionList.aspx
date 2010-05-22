<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/QuestionList.aspx.cs" inherits="Home_Room_QuestionList" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <link href="Style/div.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9FC8EA">
            <tr>
                <td valign="top" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="images/bg_blue_30.jpg">
                        <tr>
                            <td height="30">
                                <table width="738" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="40" height="30" align="center">
                                            <img src="images/jiantou_5.gif" width="12" height="8" />
                                        </td>
                                        <td class="blue_num">
                                            在线提问 &gt; 我的提问列表
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="5">
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9FC8EA">
                                    <tr>
                                        <td height="30" colspan="2" align="left" bgcolor="#E9F1F8" class="black12" style="padding-left: 20px;">
                                            问题列表(详细问题与解答)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" colspan="2" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 20px;">
                                            <span class="red">
                                                <asp:Label ID="labUserName" runat="server"></asp:Label></span>，您好，欢迎您提问！<a href="Service.aspx">我要提问</a>
                                            | <a href="Message.aspx">我的短消息</a> |
                                            <asp:LinkButton ID="btnType_1" runat="server" OnClick="btnType_1_Click">全部问题</asp:LinkButton>
                                            |
                                            <asp:LinkButton ID="btnType_2" runat="server" OnClick="btnType_1_Click">未处理问题</asp:LinkButton>
                                            | <span class="blue">
                                                <asp:LinkButton ID="btnType_3" runat="server" OnClick="btnType_1_Click">已处理问题</asp:LinkButton></span>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellspacing="1" cellpadding="0" style="margin-top: 10px;
                                    margin-bottom: 10px;">
                                    <tr>
                                        <td height="30" bgcolor="#E9F1F8" class="blue14" style="padding-left: 10px; padding-right: 10px;">
                                            问题：<asp:Label ID="labContent" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" bgcolor="#f7f7f7" class="black12" style="padding-left: 10px; padding-right: 10px;">
                                            答复：<asp:Label ID="labAnswerDateTime" runat="server" ForeColor="DarkGray"></asp:Label><br />
                                            <asp:Label ID="labAnswer" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <asp:DataGrid ID="g" runat="server" Width="100%" BorderStyle="None" AllowPaging="True"
                                    PageSize="30" AutoGenerateColumns="False" CellPadding="4" BackColor="#9FC8EA"
                                    Font-Names="Tahoma" OnItemDataBound="g_ItemDataBound" CellSpacing="1" GridLines="None"
                                    BorderColor="#E0E0E0" BorderWidth="2px">
                                    <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                                    <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                                    <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                                        BackColor="#E9F1F8" Height="25px"></HeaderStyle>
                                    <ItemStyle Height="19px"></ItemStyle>
                                    <Columns>
                                        <asp:BoundColumn DataField="DateTime" HeaderText="提交时间">
                                            <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="QuestionType" HeaderText="问题类型">
                                            <HeaderStyle HorizontalAlign="Center" Width="18%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Content" HeaderText="问题描述">
                                            <HeaderStyle HorizontalAlign="Center" Width="54%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="状态">
                                            <HeaderStyle HorizontalAlign="Center" Width="54%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn Visible="False" DataField="id"></asp:BoundColumn>
                                        <asp:BoundColumn Visible="False" DataField="AnswerStatus"></asp:BoundColumn>
                                    </Columns>
                                    <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                                    </PagerStyle>
                                </asp:DataGrid>
                                <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" PageSize="10" ShowSelectColumn="False"
                                    DataGrid="g" AlternatingRowColor="#F7FEFA" GridColor="#E0E0E0" HotColor="MistyRose"
                                    Visible="False" OnPageWillChange="gPager_PageWillChange" AllowShorting="False" RowCursorStyle="" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
<!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
