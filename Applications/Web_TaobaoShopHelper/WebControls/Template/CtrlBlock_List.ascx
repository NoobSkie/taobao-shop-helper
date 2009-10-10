<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBlock_List.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Template.CtrlBlock_List" %>
<div class="TemplateBlock BlockList">
    <div class="BlockHeader">
        <asp:Label ID="lblHeader" runat="server"></asp:Label>
    </div>
    <div class="BlockContent">
        <asp:Repeater ID="rtpBlockItems" runat="server">
        </asp:Repeater>
    </div>
</div>
