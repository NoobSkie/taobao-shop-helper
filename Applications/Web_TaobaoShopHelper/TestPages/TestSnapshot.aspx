<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" EnableEventValidation="false" CodeBehind="TestSnapshot.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.TestPages.TestSnapshot" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnSnapshot" runat="server" Text="抓取图片" OnClick="btnSnapshot_Click" />
    </div>
    <div>
        <asp:TextBox ID="txtUrl" runat="server" Width="735px"></asp:TextBox>
        <asp:TextBox ID="txtHtml" TextMode="MultiLine" runat="server" Height="239px" Width="735px"></asp:TextBox>
    </div>
    <div>
        <asp:Image ID="imgPrevew" Width="500" Height="300" runat="server" />
    </div>
    </form>
</body>
</html>
