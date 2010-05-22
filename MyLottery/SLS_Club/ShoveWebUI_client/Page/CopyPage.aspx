<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shove.Web.UI.CopyPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>复制页面</title>
    <link href="../Style/css.css" type="text/css" rel="Stylesheet" />
    <base target="_self" />
</head>
<body style="background-color: buttonface;" onunload='window.returnValue = document.getElementById("tbResult").value;'>
    <form id="form1" runat="server">
    <div>
        <br />
        <table border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" style="text-align: center; width: 300px;">
            <tr>
                <td width="124" height="35" valign="middle" bgcolor="White">
                    您要从哪个页面复制：
                </td>
                <td width="91" height="35" valign="middle" bgcolor="White" style="padding-left: 10px">
                    <asp:DropDownList runat="server" Height="30" ID="ddlPages" Width="100">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td height="30" colspan="2" align="left" valign="middle" bgcolor="#f7f7f7" style="padding-left: 43px;">
                    <asp:Button runat="server" ID="btnCopy" Text="复  制" OnClick="btnCopy_Click" Width="94px" UseSubmitBehavior="false" />&nbsp;
                    <asp:Label runat="server" ID="lblMsg" ForeColor="Red"></asp:Label>
                    <input type="hidden" id="tbResult" runat="server" value="" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
