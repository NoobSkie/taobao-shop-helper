<%@ Page Title="" Language="C#" MasterPageFile="~/ShopHelper/_ShopHelper.master"
    AutoEventWireup="true" CodeBehind="ImportShop2.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.ShopHelper.ImportShop2" %>

<%@ Register Src="~/WebControls/Common/CtrlCredit.ascx" TagName="CtrlCredit" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/Common/CtrlPager.ascx" TagName="CtrlPager" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeaderHolder" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="导入店铺"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContentHolder" runat="server">
    <div>
    </div>
    <div>
        <div class="DisplayBlock">
            <div class="BlockHeader">
                <span>店铺信息</span></div>
            <div class="BlockShopImage">
                <asp:Image ID="imgShop" runat="server" /></div>
            <div class="BlockList">
                <ul>
                    <li><span class="Caption">卖家昵称：</span><asp:Label ID="lblNick" runat="server"></asp:Label></li>
                    <li><span class="Caption">店铺标题：</span><asp:Label ID="lblShopTitle" runat="server"></asp:Label></li>
                    <li><span class="Caption">买家信用：</span><uc1:CtrlCredit ID="ucCtrlCreditBuyer" UserType="Buyer"
                        runat="server" />
                    </li>
                    <li><span class="Caption">卖家信用：</span><uc1:CtrlCredit ID="ucCtrlCreditSeller" UserType="Seller"
                        runat="server" />
                    </li>
                    <li><span class="Caption">商品总数：</span><asp:Label ID="lblItemCount" runat="server"></asp:Label></li>
                </ul>
            </div>
        </div>
        <div class="DisplayBlock">
            <div class="BlockHeader">
                <span>店铺拥有的宝贝</span> <span class="Tip">* 请勾选不需要导入的宝贝</span></div>
            <div class="ItemList">
                <asp:Repeater ID="rptItems" runat="server" 
                    onitemdatabound="rptItems_ItemDataBound">
                    <ItemTemplate>
                        <div class="Item_Block">
                            <div class="Partten ImagePartten">
                                <asp:HyperLink ID="hlnkItemPic" runat="server" Target="_blank">
                                    <asp:Image ID="imgItemPic" runat="server" ImageUrl='<%# Eval("PicPath") %>' /></asp:HyperLink></div>
                            <div class="Partten TitlePartten">
                                <asp:HyperLink ID="hlnkName" runat="server" Target="_blank" ToolTip='<%# Eval("Title") %>' Text='<%# Eval("Title") %>'></asp:HyperLink></div>
                            <div class="Partten PricePartten">
                                <asp:Label ID="lblPriceTitle" runat="server" Text="价格:"></asp:Label>
                                <asp:Label ID="lblPrice" CssClass="Price_List" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                            </div>
                            <div class="Partten CheckPartten">
                                <asp:CheckBox ID="cbCheck" runat="server" Text="不导入此宝贝" ToolTip="如果选中，则此宝贝不被导入。" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <uc2:CtrlPager ID="ucCtrlPager" PageSize="40" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageFooterHolder" runat="server">
    <ul>
        <li>
            <asp:LinkButton ID="lbtnPrev" runat="server" onclick="lbtnPrev_Click"><span>上一步</span></asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="lbtnNext" runat="server" onclick="lbtnNext_Click"><span>下一步</span></asp:LinkButton></li>
    </ul>
</asp:Content>
