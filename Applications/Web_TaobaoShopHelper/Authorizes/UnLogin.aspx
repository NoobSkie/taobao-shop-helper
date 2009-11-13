<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnLogin.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.Authorizes.UnLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label ID="lblTip" ForeColor="Red" runat="server"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div>
            <asp:LinkButton ID="lbtnLogin" runat="server" OnClick="lbtnLogin_Click">登录</asp:LinkButton>
        </div>
    </div>
    </form>
</body>
</html>
