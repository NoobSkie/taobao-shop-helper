<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChartTest.aspx.cs" Inherits="Tests_ChartTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">

        function LoadHtml(ifr) {
            var str = ifr.toString();
            alert(str);
        }
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtUrl" runat="server" Width="800px"></asp:TextBox>
        <asp:Button ID="btnView" runat="server" Text="查看" OnClick="btnView_Click" />
    </div>
    <div>
        <asp:Label ID="lblInnerHtml" runat="server" Text="Label"></asp:Label>
        <iframe id="ifr" runat="server" src="http://zst.cpdyj.com/ssc/wxjb.html" onload="LoadHtml(this);"
            onunload="alert('onunload');"></iframe>
    </div>
    </form>
</body>
</html>
