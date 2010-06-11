<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="ShowList.aspx.cs" Inherits="ShowList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="Styles/ListLayout.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div class="ListLayout">
        <asp:Label ID="lblTitle" runat="server"></asp:Label>
        <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
            <ItemTemplate>
                <div class="Row">
                    <asp:HyperLink ID="hlnkName" CssClass="Name" runat="server"></asp:HyperLink>
                    <asp:Label ID="lblUpdateTime" CssClass="UpdateTime" runat="server"></asp:Label>
                    <asp:Image ID="imgNew" CssClass="New" runat="server" />
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="Row Alternating">
                    <asp:HyperLink ID="hlnkName" CssClass="Name" runat="server"></asp:HyperLink>
                    <asp:Label ID="lblUpdateTime" CssClass="UpdateTime" runat="server"></asp:Label>
                    <asp:Image ID="imgNew" CssClass="New" runat="server" />
                </div>
            </AlternatingItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
