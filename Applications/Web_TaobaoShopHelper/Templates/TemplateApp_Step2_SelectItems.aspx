<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/NestedTemplatePage.master"
    AutoEventWireup="true" CodeBehind="TemplateApp_Step2_SelectItems.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.Templates.TemplateApp_Step2_SelectItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeaderHolder" runat="server">
    <span>应用模板 - 1.选择宝贝</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContentHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageFooterHolder" runat="server">
    <asp:LinkButton ID="lblNext" runat="server">下一步</asp:LinkButton>
</asp:Content>
