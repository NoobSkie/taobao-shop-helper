<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlBlock_List.ascx.cs"
    Inherits="Controls_CtrlBlock_List" %>
<asp:Repeater ID="rptList" runat="server">
    <ItemTemplate>
        <div>
            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
            <asp:Label ID="lblDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "LastUpdateDate")).ToString("yyyy-MM-dd hh:mm:ss") %>'></asp:Label>
        </div>
    </ItemTemplate>
</asp:Repeater>
