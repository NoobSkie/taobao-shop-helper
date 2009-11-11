<%@ Page Title="" Language="C#" MasterPageFile="~/ShopHelper/_ShopHelper.master"
    AutoEventWireup="true" CodeBehind="ImportShop1.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.ShopHelper.ImportShop1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeaderHolder" runat="server">
    <span>导入店铺 - 查找卖家</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContentHolder" runat="server">
    <span>卖家昵称</span><asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
    <asp:LinkButton ID="lbtnSearch" runat="server" OnClick="lbtnSearch_Click">查找</asp:LinkButton>
    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageFooterHolder" runat="server">
    <ul>
        <li>
            <asp:LinkButton ID="lbtnNext" runat="server">下一步</asp:LinkButton>
        </li>
    </ul>
</asp:Content>
