<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlFooter.ascx.cs" Inherits="Controls_CtrlFooter" %>
<div class="Spliter">
    <asp:Label ID="lblAddress" runat="server"></asp:Label>
    <asp:Label ID="lblPhone" runat="server"></asp:Label>
    <asp:Label ID="lblFax" runat="server"></asp:Label>
    <asp:HyperLink ID="hlnkQQ" Target="_blank" runat="server">
        <asp:Image ID="imgQQ" runat="server" /><span>QQ在线联系</span></asp:HyperLink>
</div>
