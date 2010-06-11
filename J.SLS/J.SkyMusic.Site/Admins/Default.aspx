<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Admins_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div class="ContentLayout">
        <div class="LayoutRow">
            <asp:HyperLink ID="hlnk" runat="server" NavigateUrl="ListManagement.aspx">列表管理</asp:HyperLink>
        </div>
    </div>
</asp:Content>
