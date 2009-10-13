<%@ Page Language="C#" MasterPageFile="~/SearchWin/SearchWinBase.Master" AutoEventWireup="true"
    CodeBehind="SearchMyItems_Multi.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.SearchWin.SearchMyItems_Multi" %>

<%@ Register Src="../WebControls/Common/CtrlSessionGetter.ascx" TagName="CtrlSessionGetter"
    TagPrefix="uc1" %>
<%@ Register Src="../WebControls/Common/CtrlPager.ascx" TagName="CtrlPager" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderHolder" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="选择我的商品"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <uc1:CtrlSessionGetter ID="ucCtrlSessionGetter" runat="server" Visible="false" />
    <asp:Repeater ID="rptItems" runat="server">
        <ItemTemplate>
            <asp:Label ID="lblItemTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>'></asp:Label>
        </ItemTemplate>
    </asp:Repeater>
    <uc2:CtrlPager ID="ucCtrlPager" PageSize="10" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterHolder" runat="server">
    <asp:HyperLink ID="hlnkOk" NavigateUrl="javascript:void(0);" runat="server">确定</asp:HyperLink>
    <asp:HyperLink ID="hlnkCancel" NavigateUrl="javascript:void(0);" runat="server">取消</asp:HyperLink>
</asp:Content>
