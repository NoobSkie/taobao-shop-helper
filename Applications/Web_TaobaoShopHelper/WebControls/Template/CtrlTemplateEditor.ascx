<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlTemplateEditor.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Template.CtrlTemplateEditor" %>
<%@ Register Src="~/WebControls/Template/CtrlBlock_Container.ascx" TagName="CtrlBlock_Container"
    TagPrefix="uc1" %>
<asp:Repeater ID="rptBlocks" runat="server">
    <ItemTemplate>
        <uc1:CtrlBlock_Container ID="ucCtrlBlockContainer" TemplateInfo="<%# Container.DataItem %>"
            runat="server" />
    </ItemTemplate>
</asp:Repeater>
