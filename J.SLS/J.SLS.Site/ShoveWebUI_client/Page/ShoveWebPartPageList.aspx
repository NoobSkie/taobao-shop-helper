<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shove.Web.UI.ShoveWebPartPageList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>页面列表</title>
    <link href="../Style/css.css" type="text/css" rel="Stylesheet" />
    <base target="_self" />
</head>
<body style="background-color: buttonface;">
    <form id="form1" runat="server">
    <div>
        <br />
        <table border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" style="text-align: center; width: 300px;">
            <tr>
                <td width="124" height="35" valign="middle" bgcolor="White">
                    页面列表：
                </td>
                <td width="91" height="35" valign="middle" bgcolor="White" style="padding-left: 10px">
                    <asp:DropDownList runat="server" Height="30" ID="ddlPages" Width="120" />
                </td>
            </tr>
            <tr>
                <td height="30" colspan="2" align="center" valign="middle" bgcolor="#f7f7f7">
                    <asp:Button runat="server" ID="btnGoto" Text="打开页面" OnClick="btnGoto_Click" Width="94px" UseSubmitBehavior="false" />&nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
