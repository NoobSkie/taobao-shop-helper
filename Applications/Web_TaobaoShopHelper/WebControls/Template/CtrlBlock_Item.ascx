<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBlock_Item.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Template.CtrlBlock_Item" %>
<div class="TemplateBlock BlockItem">
    <div class="BlockHeader">
        <asp:Label ID="lblHeader" runat="server"></asp:Label>
    </div>
    <div class="BlockContent">
        <asp:Repeater ID="rtpInputItems" runat="server">
        </asp:Repeater>
    </div>
</div>
