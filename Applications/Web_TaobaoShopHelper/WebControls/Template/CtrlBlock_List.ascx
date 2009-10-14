<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBlock_List.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Template.CtrlBlock_List" %>
<%@ Register Src="CtrlBlock_Item.ascx" TagName="CtrlBlock_Item" TagPrefix="uc1" %>
<%@ Register Src="../Search/CtrlSearchButton_Multi.ascx" TagName="CtrlSearchButton_Multi"
    TagPrefix="uc2" %>
<div class="TemplateBlock BlockList">
    <div class="BlockHeader">
        <asp:Label ID="lblHeader" runat="server" CssClass="Title"></asp:Label>
        <asp:LinkButton ID="lbtnAddNew" runat="server" CssClass="AddNew" OnClick="lbtnAddNew_Click">添加</asp:LinkButton>
        <uc2:CtrlSearchButton_Multi ID="ucCtrlSearchButtonMulti" SearchWinType="Multi_MyItems"
            Text="添加" runat="server" />
    </div>
    <div class="BlockContent">
        <asp:Repeater ID="rtpBlockItems" runat="server">
            <ItemTemplate>
                <uc1:CtrlBlock_Item ID="ucCtrlBlockItem" TemplateInfo="<%# Container.DataItem %>"
                    runat="server" />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
