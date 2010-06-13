<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlMenu.ascx.cs" Inherits="Controls_CtrlMenu" %>
<ul>
    <asp:Repeater ID="rptMenuList" runat="server" OnItemDataBound="rptMenuList_ItemDataBound">
        <ItemTemplate>
            <li class='<%# (!string.IsNullOrEmpty(SelectedMenuId) && Eval("Id").ToString().Equals(SelectedMenuId, StringComparison.OrdinalIgnoreCase))?"Selected":"" %>'>
                <asp:HyperLink ID="hlnkUrl" runat="server"></asp:HyperLink></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
