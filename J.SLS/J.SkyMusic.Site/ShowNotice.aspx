<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.master" AutoEventWireup="true"
    CodeFile="ShowNotice.aspx.cs" Inherits="ShowNotice" %>

<%@ Register Src="Controls/CtrlBackground.ascx" TagName="CtrlBackground" TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/ContentLayout.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <uc5:CtrlBackground ID="CtrlBackground1" runat="server" />
    <div class="ContentLayout">
        <div class="HTML">
            <asp:Label ID="lblContent" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
