<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBlock_List.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Template.CtrlBlock_List" %>
<%@ Register Src="CtrlBlock_Item.ascx" TagName="CtrlBlock_Item" TagPrefix="uc1" %>
<div class="TemplateBlock BlockList">
    <div class="BlockHeader">
        <asp:Label ID="lblHeader" runat="server" CssClass="Title"></asp:Label>
        <asp:LinkButton ID="lbtnAddNew" runat="server" CssClass="AddNew" 
            onclick="lbtnAddNew_Click">添加</asp:LinkButton>
    </div>
    <div class="BlockContent">
        <asp:Repeater ID="rtpBlockItems" runat="server">
            <ItemTemplate>
                <uc1:CtrlBlock_Item ID="ucCtrlBlockItem" TemplateInfo="<%# Container.DataItem %>" runat="server" />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
