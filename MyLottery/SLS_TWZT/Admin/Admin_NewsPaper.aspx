<%@ page language="C#" autoeventwireup="true" CodeFile="Admin_NewsPaper.aspx.cs" inherits="Admin_Admin_NewsPaper" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
                <td rowspan="2" align="left" valign="top">
                   <%-- <ShoveWebUI:ShoveTreeView ID="tv" runat="server" Width="140px" IDFieldName="ID" ImageSet="BulletedList3"
                        OnSelectedNodeChanged="tv_SelectedNodeChanged" ParentIDFieldName="ParentID" ShowExpandCollapse="False"
                        ShowLines="True" TextFieldName="Name" ValueFieldName="ID">
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                        <ParentNodeStyle Font-Bold="False" />
                    </ShoveWebUI:ShoveTreeView>--%>
                    <td  valign="top">
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="../Admin/Admin_NPIsusesAdd.aspx">添加期号</asp:LinkButton>
                        </td> 
                        <td>
                        <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" >修改期号</asp:LinkButton></td>
                        <td> <asp:LinkButton ID="lbDelete" runat="server" onclick="lbDelete_Click" OnClientClick="return confirm('你确定要删除吗？')" >删除期号</asp:LinkButton></td>
                        <td valign="top">
                    <asp:DropDownList ID="ddlNewsTypes" runat="server" 
                           >
                    </asp:DropDownList>
                    </td>
                </td>
             <%--   <td align="right" valign="top">
                    <asp:DataGrid ID="g" runat="server" Width="99%" AutoGenerateColumns="False" CellPadding="1"
                        BackColor="White" BorderWidth="2px" BorderStyle="None" BorderColor="#E0E0E0"
                        Font-Names="宋体" PageSize="20" AllowPaging="True" AllowSorting="True" OnItemCommand="g_ItemCommand"
                        OnItemDataBound="g_ItemDataBound">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                            BackColor="Silver"></HeaderStyle>
                        <Columns>
                          <asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="期号">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="DateTime" SortExpression="DateTime" HeaderText="时间">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Title" SortExpression="Title" HeaderText="标题">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn SortExpression="isShow" HeaderText="显示">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbisShow" runat="server" Enabled="False"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn SortExpression="isHasImage" HeaderText="有图">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbisHasImage" runat="server" Enabled="False"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn SortExpression="isCommend" HeaderText="推荐">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbisCommend" runat="server" Enabled="False"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn SortExpression="isHot" HeaderText="热点">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbisHot" runat="server" Enabled="False"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="ReadCount" SortExpression="ReadCount" HeaderText="阅读">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="编辑">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <ShoveWebUI:ShoveLinkButton ID="btnEdit" runat="server" CommandName="Edit">修改</ShoveWebUI:ShoveLinkButton>&nbsp;
                                    <ShoveWebUI:ShoveLinkButton ID="btnDel" runat="server" CommandName="Del" AlertText="您确信要删除此条新闻资料吗？">删除</ShoveWebUI:ShoveLinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="isShow"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="isHasImage"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="isCommend"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="isHot"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                        </PagerStyle>
                    </asp:DataGrid>
                </td>--%>
            </tr>
            <%--<tr>
                <td align="right" valign="top">
                    <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" ShowSelectColumn="False"
                        DataGrid="g" AlternatingRowColor="Linen" GridColor="#E0E0E0" HotColor="MistyRose"
                        Visible="False" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore" />
                </td>
            </tr>--%>
           <%-- <tr>
                <td align="center" style="height: 46px" colspan="3">
                    <ShoveWebUI:ShoveConfirmButton ID="btnAdd" runat="server" Text="增加" Width="90px"
                        OnClick="btnAdd_Click" />
                </td>
            </tr>--%>
        </table>
    </div>
    </form>
</body>
</html>
