<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shove.Web.UI.ShoveWebPartAddNewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>请输入新网页名称</title>
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
                    请输入新网页名称：
                </td>
                <td height="35" valign="middle" bgcolor="White" style="padding-left: 10px">
                    <asp:TextBox runat="server" ID="tbPageName" Width="130px" />
                </td>
            </tr>
            <tr>
                <td height="30" colspan="2" align="center" valign="middle" bgcolor="#f7f7f7">
                    <asp:Button runat="server" ID="btnOK" Text="确定" OnClick="btnOK_Click" Width="94px" UseSubmitBehavior="false" />&nbsp;
                    <input type="hidden" id="tbResult" runat="server" value="" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
