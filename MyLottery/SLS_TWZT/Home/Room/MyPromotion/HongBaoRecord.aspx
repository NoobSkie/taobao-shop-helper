<%@ page language="C#" autoeventwireup="true" CodeFile="HongBaoRecord.aspx.cs" inherits="Home_Room_MyPromotion_HongBaoRecord" enableEventValidation="false" %>


<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function copy(url) {
            window.clipboardData.setData('Text', url);   
            alert("已复制到剪粘板上");
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#9FC8EA">
        <tr>
            <td height="31" colspan="9" align="right" background="../images/bg_blue_31.jpg" bgcolor="#FFFFFF"
                style="padding-right: 10px;">
                <table width="600" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="left">
                            <asp:RadioButtonList ID="rblType" runat="server" RepeatDirection="Horizontal" 
                                AutoPostBack="True" onselectedindexchanged="rblType_SelectedIndexChanged">
                                <asp:ListItem Value="1" Selected="True">所有</asp:ListItem>
                                <asp:ListItem Value="2">已使用</asp:ListItem>
                                <asp:ListItem Value="3">未使用未过期</asp:ListItem>
                                <asp:ListItem Value="4">未使用已过期</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:DataGrid ID="g" runat="server" Width="100%" BorderStyle="None" AllowSorting="True"
                    AllowPaging="True" PageSize="16" AutoGenerateColumns="False" CellPadding="2"
                    BackColor="#9FC8EA" Font-Names="Tahoma" CellSpacing="1" GridLines="None" 
                    onitemcommand="g_ItemCommand" onitemdatabound="g_ItemDataBound" >
                    <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#3D5B96"
                        CssClass="blue" BackColor="#E9F1F8" Height="30px"></HeaderStyle>
                    <ItemStyle Height="30px"></ItemStyle>
                    <Columns>
                        <asp:BoundColumn HeaderText="序号" DataField="ID">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" CssClass="blue12"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="创建日期" DataField="CreateDate" DataFormatString ="{0:yyyy-MM-dd HH:mm:ss}">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" CssClass="blue"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="红包金额" DataField="Money" DataFormatString="{0:N}">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" CssClass="blue"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="使用人" DataField="UserName">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" CssClass="black12"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="过期日期" DataField="ExpiryDate" DataFormatString ="{0:yyyy-MM-dd HH:mm:ss}">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" CssClass="black12"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="红包链接地址" DataField="URL">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" CssClass="black12"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="操作" Visible="false">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" CssClass="blue"></ItemStyle>
                            <ItemTemplate>
                                <ShoveWebUI:ShoveLinkButton ID="btnCopy" runat="server" CommandName="Copy">
                                    复制URL</ShoveWebUI:ShoveLinkButton>
                                <ShoveWebUI:ShoveLinkButton ID="btnDelete" runat="server" CommandName="Deletes" AlertText="真的要删除吗？">
                                    删除</ShoveWebUI:ShoveLinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn HeaderText="ID" DataField="ID" Visible ="false" />
                          <asp:BoundColumn HeaderText="AcceptUserID" DataField="AcceptUserID" Visible ="false" >  
                        </asp:BoundColumn>
                    </Columns>
                    <PagerStyle Visible="False"></PagerStyle>
                </asp:DataGrid>
            </td>
        </tr>
        <tr bgcolor="#ffffff">
            <td>
                <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" PageSize="10" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore"
                    ShowSelectColumn="False" DataGrid="g" AlternatingRowColor="#F7FEFA" GridColor="#FFFFFF"
                    HotColor="MistyRose" RowCursorStyle="" />
            </td>
        </tr>
    </table>
    
    </form>
</body>
</html>