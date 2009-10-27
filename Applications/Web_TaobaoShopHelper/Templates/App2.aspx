<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/_Template.master"
    EnableEventValidation="false" AutoEventWireup="true" CodeBehind="App2.aspx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.Templates.App2" %>

<%@ Register Src="~/WebControls/Template/CtrlTemplateEditor.ascx" TagName="CtrlTemplateEditor"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeaderHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContentHolder" runat="server">
    <div class="WaittingList">
        <ul>
            <asp:Repeater ID="rptItemList" runat="server">
                <ItemTemplate>
                    <li class='<%# Eval("CssName") %>'>
                        <asp:HyperLink ID="hlnk" runat="server" Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("Url") %>'></asp:HyperLink></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div class="TemplateArea">
        <div class="ItemInformation">
            <div>
                <asp:Image ID="imgPreview" runat="server" />
            </div>
            <div>
                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlTemplates" runat="server" DataTextField="Name" AutoPostBack="true"
                    DataValueField="Id" OnSelectedIndexChanged="ddlTemplates_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div class="TemplateContainer">
            <uc2:CtrlTemplateEditor ID="ucTemplateEditor" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageFooterHolder" runat="server">
    <asp:LinkButton ID="lbtnPreview" runat="server" OnClick="lbtnPreview_Click">效果预览及对比</asp:LinkButton>
    <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click">保存并继续下一个</asp:LinkButton>
</asp:Content>
