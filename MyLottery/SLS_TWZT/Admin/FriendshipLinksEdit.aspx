<%@ page language="C#" autoeventwireup="true" CodeFile="FriendshipLinksEdit.aspx.cs" inherits="Admin_FriendshipLinksEdit" enableEventValidation="false" %>

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
            <table cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
                <tr>
                    <td>
                        <font face="宋体">名称
                            <asp:TextBox ID="tbName" runat="server" Width="400px" MaxLength="50"></asp:TextBox>&nbsp;<asp:CheckBox ID="cbisShow" runat="server" Text="是否在首页显示" />
                            <asp:TextBox ID="tbID" runat="server" Visible="False"></asp:TextBox></font></td>
                </tr>
                <tr>
                    <td>
                        <font face="宋体">网址
                            <asp:TextBox ID="tbUrl" runat="server" MaxLength="255" Width="400px"></asp:TextBox></font></td>
                </tr>
                <tr>
                    <td>
                        顺序
                        <asp:TextBox ID="tbOrder" runat="server" MaxLength="10" Width="100px">1</asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <font face="宋体">Logo
                            <input id="tbImage" style="width: 600px; height: 21px" type="file" size="80" name="tbImage" runat="server">&nbsp;</font></td>
                </tr>
                <tr>
                <td>
                    <font face="宋体">使用已存在的图片
                        <asp:DropDownList ID="ddlImage" runat="server" Width="250px">
                        </asp:DropDownList>
                    </font>
                    <asp:CheckBox ID="cbNoEditImage" runat="server" Checked="True" Text="不修改图片" />
                </td>
            </tr>
                <tr>
                    <td style="height: 49px" align="center">
                        <ShoveWebUI:ShoveConfirmButton ID="btnSave" runat="server" Width="60px" Height="20px" BackgroupImage="../Images/Admin/buttbg.gif" Text="保存" AlertText="确信输入无误，并立即保存此友情链接吗？" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
