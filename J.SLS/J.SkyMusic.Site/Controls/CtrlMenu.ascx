<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlMenu.ascx.cs" Inherits="Controls_CtrlMenu" %>
<ul>
    <asp:Repeater ID="rptMenuList" runat="server" OnItemDataBound="rptMenuList_ItemDataBound">
        <ItemTemplate>
            <li>
                <asp:HyperLink ID="hlnkUrl" runat="server"></asp:HyperLink></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
