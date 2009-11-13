<%@ Page Title="" Language="C#" MasterPageFile="~/ShopHelper/_ShopHelper.master"
    AutoEventWireup="true" CodeBehind="ImportShop4.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.ShopHelper.ImportShop4" %>

<%@ Register Src="~/WebControls/Common/CtrlCredit.ascx" TagName="CtrlCredit" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeaderHolder" runat="server">
    <span>导入店铺 - 查看导入结果</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContentHolder" runat="server">
    <div class="DisplayBlock">
        <div class="BlockHeader">
            <span>导入结果情况</span></div>
        <div class="BlockShopImage">
            <asp:Image ID="imgShop" runat="server" /></div>
        <div class="BlockList">
            <ul>
                <li><span class="Caption">卖家昵称：</span><asp:Label ID="lblNick" runat="server"></asp:Label></li>
                <li><span class="Caption">店铺标题：</span><asp:Label ID="lblShopTitle" runat="server"></asp:Label></li>
                <li><span class="Caption">导入宝贝总数：</span><asp:Label ID="lblImportCount" runat="server"></asp:Label></li>
                <li><span class="Caption">当前状态：</span><asp:Label ID="lblState" runat="server"></asp:Label></li>
                <li><span class="Caption">已导入情况：</span><asp:Label ID="lblSummary" runat="server"></asp:Label></li>
            </ul>
        </div>
    </div>
    <div class="DisplayBlock">
        <div class="BlockHeader">
            <span>导入明细记录</span></div>
        <div class="BlockQuery">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageFooterHolder" runat="server">
    <ul>
        <li>
            <asp:HyperLink ID="hlnkRefresh" runat="server"><span>刷新导入结果</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="hlnkBack" NavigateUrl="Default.aspx" runat="server"><span>返回店铺中心</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="hlnkImport" NavigateUrl="ImportShop1.aspx" runat="server"><span>继续导入其他店铺</span></asp:HyperLink></li>
    </ul>
</asp:Content>
