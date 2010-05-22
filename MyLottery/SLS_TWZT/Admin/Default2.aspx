<%@ page language="C#" autoeventwireup="true" CodeFile="Default2.aspx.cs" inherits="Admin_Default2" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="查询所有支付记录" 
            onclick="Button1_Click" />
        <br /> <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br /><br />
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
