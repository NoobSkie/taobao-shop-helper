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
        <span class="BlockHeader">预览导入信息</span>
        <asp:Image ID="imgShop" runat="server" />
        <ul class="BlockList">
            <li><span class="Caption">卖家昵称</span><asp:Label ID="lblNick" runat="server"></asp:Label></li>
            <li><span class="Caption">店铺标题</span><asp:Label ID="lblShopTitle" runat="server"></asp:Label></li>
            <li><span class="Caption">买家信用</span><uc1:CtrlCredit ID="ucCtrlCreditBuyer" UserType="Buyer"
                runat="server" />
            </li>
            <li><span class="Caption">卖家信用</span><uc1:CtrlCredit ID="ucCtrlCreditSeller" UserType="Seller"
                runat="server" />
            </li>
            <li><span class="Caption">店铺宝贝总数</span><asp:Label ID="lblItemCount" runat="server"></asp:Label></li>
            <li><span class="Caption">即将导入的宝贝总数</span><asp:Label ID="lblImportCount" runat="server"></asp:Label></li>
        </ul>
    </div>
    <div class="DisplayBlock">
        <span class="BlockHeader">导入宝贝信息调整</span>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageFooterHolder" runat="server">
    <asp:LinkButton ID="lbtnPrev" runat="server">上一步</asp:LinkButton>
    <asp:LinkButton ID="lbtnImport" runat="server">导入店铺</asp:LinkButton>
</asp:Content>
