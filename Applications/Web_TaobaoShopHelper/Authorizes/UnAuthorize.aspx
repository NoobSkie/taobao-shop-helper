<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnAuthorize.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.Authorizes.UnAuthorize" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:HyperLink ID="hlnkGetAppKey" Target="_blank" runat="server">获取淘宝授权码</asp:HyperLink>
        </div>
        <div>
            <asp:TextBox ID="txtAuthCode" runat="server"></asp:TextBox>
            <asp:LinkButton ID="lbtnGetSessionKey" runat="server" 
                onclick="lbtnGetSessionKey_Click">授权并进入系统</asp:LinkButton>
        </div>
    </div>
    </form>
</body>
</html>
