<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidateCode.aspx.cs" Inherits="Users_ValidateCode" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ShoveWebUI:ShoveCheckCode ID="ShoveCheckCode1" runat="server" ForeColor="CornflowerBlue"
            BackColor="SeaShell" Charset="All" Height="20px" SupportDir="~/ShoveWebUI_client"
            name="ShoveCheckCode1"></ShoveWebUI:ShoveCheckCode>
    </div>
    </form>
</body>
</html>
