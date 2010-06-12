<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="ShowContent.aspx.cs" Inherits="ShowContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="Styles/ContentLayout.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div class="ContentLayout">
        <div class="Title">
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </div>
        <div class="Time">
            <div class="CreateTime">
                <span>创建时间：</span><asp:Label ID="lblCreateTime" runat="server"></asp:Label>
            </div>
            <div class="UpdateTime">
                <span>更新时间：</span><asp:Label ID="lblUpdateTime" runat="server"></asp:Label>
            </div>
        </div>
        <div class="HTML">
            <asp:Label ID="lblContent" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
