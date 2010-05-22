<%@ page language="C#" autoeventwireup="true" CodeFile="NotificationTemplates.aspx.cs" inherits="Admin_NotificationTemplates" validaterequest="false" enableEventValidation="false" %>

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
            <table id="Table1" style="width: 90%; height: 496px" cellspacing="0" cellpadding="0" width="956" align="center" border="0">
                <tr>
                    <td style="width: 160px; height: 24px">
                        <asp:DropDownList ID="ddlTemplateType" runat="server" Width="168px" AutoPostBack="True" OnSelectedIndexChanged="ddlTemplateType_SelectedIndexChanged">
                            <asp:ListItem Value="1" Selected="True">手机短信</asp:ListItem>
                            <asp:ListItem Value="2">电子邮件</asp:ListItem>
                            <asp:ListItem Value="3">站内信</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="height: 450px" valign="top" rowspan="2">
                        <asp:TextBox ID="tbContent" runat="server" Width="99%" Height="448px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 426px" valign="top">
                        <asp:ListBox ID="listTemplateFile" runat="server" Width="100%" Height="435px" AutoPostBack="True" OnSelectedIndexChanged="listTemplateFile_SelectedIndexChanged"></asp:ListBox></td>
                </tr>
                <tr>
                    <td style="height: 40px" align="center" colspan="2">
                        <ShoveWebUI:ShoveConfirmButton ID="btnOK" BackgroupImage="../Images/Admin/buttbg.gif" runat="server" Width="60px" Height="20px" Text="保存" AlertText="确认书写无误吗？" OnClick="btnOK_Click" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
