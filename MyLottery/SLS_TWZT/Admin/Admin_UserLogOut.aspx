<%@ page language="C#" autoeventwireup="true" CodeFile="Admin_UserLogOut.aspx.cs" inherits="Admin_Admin_UserLogOut" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/Admin.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 26px">
                    <asp:RadioButton ID="rbUser" runat="server" Text="用户注销" GroupName="rbCompetences"
                        Checked="true" AutoPostBack="true" OnCheckedChanged="rbUser_CheckedChanged" />
                    <asp:RadioButton ID="rbAdmin" runat="server" Text="管理员限制" GroupName="rbCompetences"
                        AutoPostBack="true" OnCheckedChanged="rbAdmin_CheckedChanged" />
                </td>
            </tr>
        </table>
        <table width="96%" height="34" border="0" align="center" cellpadding="0" cellspacing="1"
            bgcolor="#85BDE2">
            <tr>
                <td height="32" bgcolor="#B0D5EC" class="STYLE14" id="tdDscrition" runat="server" align="center">
                    用户注销详细
                </td>
            </tr>
        </table>
        <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center">
                    <asp:DataGrid ID="g" runat="server" CellPadding="0" BackColor="White" BorderWidth="2px"
                        BorderStyle="None" BorderColor="#E0E0E0" Font-Names="宋体" PageSize="20" AllowSorting="True"
                        AutoGenerateColumns="False" AllowPaging="True" OnItemDataBound="g_ItemDataBound"
                        Width="100%">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                            BackColor="LightGray" Wrap="True"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="用户名">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="RealityName" SortExpression="RealityName" HeaderText="真实姓名">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IDCardNumber" SortExpression="IDCardNumber" HeaderText="身份证">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Email" SortExpression="Email" HeaderText="邮箱">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="QQ" SortExpression="QQ" HeaderText="QQ">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Mobile" SortExpression="Mobile" HeaderText="电话">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Telephone" SortExpression="Telephone" HeaderText="手机">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="允许登录">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.isCanLogin") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbisCanLogin" runat="server" Enabled="False"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="Reason" SortExpression="Reason" HeaderText="注销原因">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="isCanLogin"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="SiteID"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                        </PagerStyle>
                        <ItemStyle Wrap="True" />
                    </asp:DataGrid>
                    <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" ShowSelectColumn="False"
                        DataGrid="g" AlternatingRowColor="Linen" GridColor="#E0E0E0" HotColor="MistyRose"
                        Visible="False" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore">
                    </ShoveWebUI:ShoveGridPager>
                </td>
            </tr>
        </table>
        <br />
    </div>
    </form>
</body>
</html>
