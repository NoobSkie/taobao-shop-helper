<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shove.Web.UI.ShoveWebPartLicense" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShoveWebPart 许可</title>
    <link href="../Style/css.css" type="text/css" rel="Stylesheet" />
</head>
<body style="background-color: buttonface;">
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        网卡地址：<asp:TextBox ID="tbMac" runat="server" Width="160px" ReadOnly="true" />
        <br />
        授权证书：<asp:TextBox ID="tbLicens" runat="server" Width="608px" Height="75px" TextMode="MultiLine" />
        <br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="btnOK" runat="server" Text="确定" OnClick="btnOK_Click" Width="78px" />
    </div>
    </form>
</body>
</html>
