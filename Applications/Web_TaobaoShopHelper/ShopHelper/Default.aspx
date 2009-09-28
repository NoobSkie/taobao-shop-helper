<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMainMenu.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.ShopHelper.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HolderContent" runat="server">
    <div class="MenuDivLevelTwo">
        <ul class="MenuItemList">
            <li><a href="ItemQuery.aspx"><span>导入宝贝</span></a></li>
            <li><a href="ItemQuery.aspx"><span>批量增加宝贝</span></a></li>
            <li class="Selected"><a href="ItemQuery.aspx"><span>店铺宝贝管理</span></a></li>
            <li><a href="ItemQuery.aspx"><span>库存</span></a></li>
        </ul>
    </div>
</asp:Content>
