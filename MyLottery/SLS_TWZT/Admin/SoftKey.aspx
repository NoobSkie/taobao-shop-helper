<%@ page language="C#" autoeventwireup="true" CodeFile="SoftKey.aspx.cs" inherits="Admin_SoftKey" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Style/Admin.css" type="text/css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" 
            style="margin-top:100px; width: 395px; margin-right: 135px;">
            <tr>
                <td>
                    机器码：
                </td>
                <td>
                    <asp:TextBox ID="tbKey" runat="server" Enabled="false" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    序列号：
                </td>
                <td>
                    <asp:TextBox ID="tbKeyOK" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnOK" runat="server" onclick="btnOK_Click" Text="注册" width="62px"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
