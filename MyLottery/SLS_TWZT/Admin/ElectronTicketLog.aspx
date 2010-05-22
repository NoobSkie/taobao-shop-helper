<%@ page language="C#" autoeventwireup="true" CodeFile="ElectronTicketLog.aspx.cs" inherits="Admin_ElectronTicketLog" validaterequest="false" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    From:&nbsp;<asp:TextBox ID="tbFrom" runat="server"></asp:TextBox>
    To:&nbsp;<asp:TextBox ID="tbTo" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="btnOK" runat="server" Text="查询" onclick="btnOK_Click" />
        <br />
        <br />
        <asp:DataList ID="dlList" runat="server" Width="100%" onitemcommand="dlList_ItemCommand">
            <ItemTemplate>
                <%#Eval("id") %>&nbsp;&nbsp;<%#Eval("DateTime") %>&nbsp;&nbsp;<%#Eval("Send") %>&nbsp;&nbsp;<%#Eval("TransType") %>
                <asp:Button ID="btnLook" CommandName="btnLook" runat="server" Text="详细" /><input type="hidden" id="tbID" runat="server" value='<%#Eval("id") %>' />
            </ItemTemplate>
        </asp:DataList>
        <br />
        <br />
        <asp:TextBox ID="tbDetail" runat="server" Height="308px" ReadOnly="True" TextMode="MultiLine" Width="100%"></asp:TextBox>
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
