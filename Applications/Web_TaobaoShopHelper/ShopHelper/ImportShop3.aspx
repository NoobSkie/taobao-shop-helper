<%@ Page Title="" Language="C#" MasterPageFile="~/ShopHelper/_ShopHelper.master"
    AutoEventWireup="true" CodeBehind="ImportShop3.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.ShopHelper.ImportShop3" %>

<%@ Register Src="~/WebControls/Common/CtrlCredit.ascx" TagName="CtrlCredit" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeaderHolder" runat="server">
    <span>导入店铺 - 预览</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContentHolder" runat="server">
    <div class="DisplayBlock">
        <div class="BlockHeader">
            <span>导入信息预览</span></div>
        <div class="BlockShopImage">
            <asp:Image ID="imgShop" runat="server" /></div>
        <div class="BlockList">
            <ul>
                <li><span class="Caption">卖家昵称</span><asp:Label ID="lblNick" runat="server"></asp:Label></li>
                <li><span class="Caption">店铺标题</span><asp:Label ID="lblShopTitle" runat="server"></asp:Label></li>
                <li><span class="Caption">店铺宝贝总数</span><asp:Label ID="lblItemCount" runat="server"></asp:Label></li>
                <li><span class="Caption">即将导入的宝贝总数</span><asp:Label ID="lblImportCount" runat="server"></asp:Label></li>
            </ul>
        </div>
    </div>
    <div class="DisplayBlock">
        <span class="BlockHeader">导入宝贝信息调整</span>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageFooterHolder" runat="server">
    <ul>
        <li>
            <asp:HyperLink ID="hlnkPrev" runat="server"><span>上一步</span></asp:HyperLink></li>
        <li>
            <asp:LinkButton ID="lbtnImport" runat="server" OnClick="lbtnImport_Click"><span>导入店铺</span></asp:LinkButton></li>
    </ul>
</asp:Content>
