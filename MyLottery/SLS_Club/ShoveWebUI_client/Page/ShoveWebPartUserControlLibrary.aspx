<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shove.Web.UI.ShoveWebPartUserControlLibrary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShoveWebPart用户控件库</title>
    <style type="text/css">
        body
        {
            scrollbar-face-color: #CECBCE;
            scrollbar-highlight-color: WHITE;
            scrollbar-shadow-color: #848284;
            scrollbar-3dlight-color: #848284;
            scrollbar-arrow-color: WHITE;
            scrollbar-track-color: #EAEAEA;
            scrollbar-darkshadow-color: WHITE;
            font-family: "宋体";
            color: #3C3C3C;
            font-size: 10pt;
            line-height: 14pt;
            margin-left: 0px;
            margin-right: 0px;
            margin-top: 0px;
        }
        .a:link
        {
            color: #000000;
            text-decoration: none;
        }
        .a:active
        {
            color: #000000;
            text-decoration: none;
        }
        .a:visited
        {
            color: #000000;
            text-decoration: none;
        }
        .a:hover
        {
            color: #000000;
            text-decoration: underline;
        }
        .black12
        {
            font-size: 12px;
            color: #333333;
            font-family: "tahoma";
            line-height: 18px;
        }
        .black12 A:link
        {
            color: #333333;
            text-decoration: none;
        }
        .black12 A:active
        {
            color: #333333;
            text-decoration: none;
        }
        .black12 A:visited
        {
            color: #333333;
            text-decoration: none;
        }
        .black12 A:hover
        {
            color: #333333;
            text-decoration: underline;
        }
        .orange12
        {
            font-size: 12px;
            color: #ff6600;
            font-family: "tahoma";
            line-height: 18px;
            font-weight: bold;
        }
        .orange12 A:link
        {
            color: #ff6600;
            text-decoration: none;
        }
        .orange12 A:active
        {
            color: #ff6600;
            text-decoration: none;
        }
        .orange12 A:visited
        {
            color: #ff6600;
            text-decoration: none;
        }
        .orange12 A:hover
        {
            color: #ff6600;
            text-decoration: underline;
        }
        .blue12
        {
            font-size: 12px;
            color: #003399;
            font-family: "宋体";
            line-height: 18px;
        }
        .blue12 A:link
        {
            color: #003399;
            text-decoration: underline;
        }
        .blue12 A:active
        {
            color: #003399;
            text-decoration: none;
        }
        .blue12 A:visited
        {
            color: #003399;
            text-decoration: none;
        }
        .blue12 A:hover
        {
            color: #ff6600;
            text-decoration: none;
        }
        .photo
        {
            padding: 2px;
            border: 1px solid #CCCCCC;
            background-color: #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
            <tr>
                <td height="25" style="background-image: url(../Images/pic_bg_25.jpg)" bgcolor="#f7f7f7" class="black12">
                    &nbsp;&nbsp;&nbsp;控件库 &gt;
                    <asp:Label runat="server" ID="lblUserControlType"></asp:Label>
                    &nbsp;&gt;
                    <asp:Label runat="server" ID="lblNav"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#f7f7f7">
                    <table width="800" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="170" valign="top">
                                <table width="150" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="8">
                                        </td>
                                    </tr>
                                </table>
                                <table width="150" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                    <tr>
                                        <td height="25" style="background-image: url(../Images/pic_bg_25.jpg)" bgcolor="#FFFFFF">
                                            <asp:TreeView ID="tvUserControlsDir" ExpandDepth="0" Font-Size="10pt" Font-Bold="true" ForeColor="#003366" runat="server" OnSelectedNodeChanged="tvUserControlsDir_SelectedNodeChanged">
                                            </asp:TreeView>
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" cellspacing="0" cellpadding="0" style="width: 152px">
                                    <tr>
                                        <td height="8">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="649" valign="top">
                                <table width="150" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="8">
                                        </td>
                                    </tr>
                                </table>
                                <table width="630" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="center" class="orange12">
                                            请选控件类型：
                                            <asp:DropDownList runat="server" ID="ddlControlTypes" AutoPostBack="true" OnSelectedIndexChanged="ddlControlTypes_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <table width="630" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                    <tr>
                                        <td bgcolor="#FFFFFF">
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="610" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:GridView HorizontalAlign="Center" PagerStyle-CssClass="blue12" PagerStyle-HorizontalAlign="Center" PagerStyle-BackColor="#FFFFFF" AutoGenerateColumns="False" HeaderStyle-CssClass="black12" BorderWidth="0" CellSpacing="1" CellPadding="0" Width="100%" BackColor="#6CA4E4" HeaderStyle-Height="25" HeaderStyle-BackColor="#E3EEFB" DataKeyNames="ID" AllowPaging="True" OnPageIndexChanging="gvShoveWebPartUserControls_PageIndexChanging" runat="server" ID="gvShoveWebPartUserControls">
                                                            <PagerSettings FirstPageText="[首页]" LastPageText=" [尾页]" Mode="NextPreviousFirstLast" NextPageText="[下一页]" PreviousPageText="[上页]" />
                                                            <Columns>
                                                                <asp:BoundField DataField="Name" HeaderText="控件名称">
                                                                    <ItemStyle HorizontalAlign="Center" Width="240px" Height="25" CssClass="black12" BackColor="#FFFFFF" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="240px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="TypeName" HeaderText="控件类别">
                                                                    <ItemStyle HorizontalAlign="Center" Width="240px" CssClass="black12" BackColor="#FFFFFF" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                                </asp:BoundField>
                                                                <%--<asp:BoundField DataField="Description " HeaderText="备注">
                                                                    <ItemStyle HorizontalAlign="Center" Width="100px" CssClass="black12" BackColor="#FFFFFF" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                                </asp:BoundField>--%>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="30" ItemStyle-CssClass="blue12">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox runat="server" ID="cbSelect" ToolTip='<%#Eval("FileUrl") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="8">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table width="630" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td colspan="3" align="center">
                                            <asp:ImageButton runat="server" ID="ibUserCotrol" OnClick="ibUserCotrol_Click" ImageUrl="../Images/pic_botton_1.jpg"/>
                                            &nbsp;&nbsp;
                                            <asp:Label runat="server" ID="lblMsg" ForeColor="Red"></asp:Label>
                                        </td>
                                        <td width="39">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table width="150" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="8">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
