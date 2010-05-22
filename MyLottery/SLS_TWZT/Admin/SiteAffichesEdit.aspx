<%@ page language="C#" autoeventwireup="true" CodeFile="SiteAffichesEdit.aspx.cs" inherits="Admin_SiteAffichesEdit" validaterequest="false" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
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
                        <font face="宋体">时间
                            <asp:TextBox ID="tbDateTime" runat="server" Width="200px"></asp:TextBox>&nbsp;
                            <asp:CheckBox ID="cbisShow" runat="server" Text="是否显示"></asp:CheckBox>&nbsp;<asp:TextBox ID="tbID" runat="server" Visible="False"></asp:TextBox>&nbsp;<asp:CheckBox ID="cbisCommend" runat="server" Text="是否推荐"></asp:CheckBox>&nbsp;<asp:CheckBox ID="cbTitleRed" runat="server" Text="标题加红" Checked="False"></asp:CheckBox></font></td>
                </tr>
                <tr>
                    <td>
                        <font face="宋体">标题
                            <asp:TextBox ID="tbTitle" runat="server" Width="648px"></asp:TextBox></font></td>
                </tr>
              
                <tr>
                    <td>
                        <font face="宋体">地址
                            <asp:TextBox ID="tbContent" runat="server" Width="520px" MaxLength="50"></asp:TextBox></font></td>
                </tr>
              
                <tr>
                    <td style="height: 49px" align="center">
                        <ShoveWebUI:ShoveConfirmButton ID="btnSave" runat="server" Width="60px" Height="20px" BackgroupImage="../Images/Admin/buttbg.gif" Text="保存" AlertText="确信输入无误，并立即保存此公告吗？" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
