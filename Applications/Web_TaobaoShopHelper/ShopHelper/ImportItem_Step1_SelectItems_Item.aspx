<%@ Page Title="" Language="C#" MasterPageFile="~/ShopHelper/NestedImportItemStep.master"
    AutoEventWireup="true" CodeBehind="ImportItem_Step1_SelectItems_Item.aspx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.ShopHelper.ImportItem_Step1_SelectItems_Item" %>

<%@ Register Src="../WebControls/Search/CtrlSearchItems_Multi.ascx" TagName="CtrlSearchItems_Multi"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StepHeaderHolder" runat="server">
    <div class="HeaderTitle">
        <span>第 1/3 步</span>
    </div>
    <div class="HeaderSummary">
        <span>查询并选择要导入的商品或店铺</span>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="StepSearchHolder" runat="server">
    <form action="ImportItem_Step1_SelectItems.aspx" method="get">
    <div>
        <select name="t" id="ddlType">
            <option selected="selected" value="item">宝贝</option>
            <option value="shop">店铺</option>
        </select>
        <input type="text" name="v" id="txtKey" />
    </div>
    <div>
        <input type="submit" value="搜索" />
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="StepDisplayHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="StepContentHolder" runat="server">
    <div class="ResultView">
        <div class="CheckItemList ItemList">
            <uc1:CtrlSearchItems_Multi ID="ucCtrlSearchItemsMulti" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="StepFooterHolder" runat="server">
    <asp:LinkButton ID="lbtnNext" runat="server" OnClick="lbtnNext_Click">下一步</asp:LinkButton>
</asp:Content>
