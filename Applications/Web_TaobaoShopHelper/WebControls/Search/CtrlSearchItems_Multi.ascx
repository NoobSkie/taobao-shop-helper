<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSearchItems_Multi.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Search.CtrlSearchItems_Multi" %>
<%@ Register Src="CtrlItem_Check.ascx" TagName="CtrlItem_Check" TagPrefix="uc1" %>
<div class="ItemList CheckItemList">
    <asp:Repeater ID="rptItems" runat="server">
        <ItemTemplate>
            <uc1:CtrlItem_Check ID="ucCtrlItemCheck" DisplayType="<%# DisplayType %>" Item="<%# Container.DataItem %>"
                runat="server" />
        </ItemTemplate>
    </asp:Repeater>
</div>
