<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/NestedTemplatePage.master"
    AutoEventWireup="true" CodeBehind="TemplateApp_Step3_Edit.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.Templates.TemplateApp_Step3_Edit" %>

<%@ Register Src="~/WebControls/Template/CtrlBlock_Container.ascx" TagName="CtrlBlock_Container"
    TagPrefix="uc1" %>
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
            <asp:DropDownList ID="ddlTemplates" runat="server" DataTextField="Name" AutoPostBack="true"
                DataValueField="Id" OnSelectedIndexChanged="ddlTemplates_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="TemplateContainer">
            <asp:Repeater ID="rptBlocks" runat="server">
                <ItemTemplate>
                    <uc1:CtrlBlock_Container ID="ucCtrlBlockContainer" TemplateInfo="<%# Container.DataItem %>"
                        runat="server" />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageFooterHolder" runat="server">
</asp:Content>
