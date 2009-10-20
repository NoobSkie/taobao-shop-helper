<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/NestedTemplatePage.master"
    AutoEventWireup="true" CodeBehind="TemplateApp.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.Templates.TemplateApp" %>

<%@ Register Src="~/WebControls/Common/CtrlInformationBox.ascx" TagName="CtrlInformationBox"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HolderContent" runat="server">
    <form id="form1" runat="server">
    <uc1:CtrlInformationBox ID="ucCtrlInformationBox" Visible="false" runat="server" />
    </form>
</asp:Content>
