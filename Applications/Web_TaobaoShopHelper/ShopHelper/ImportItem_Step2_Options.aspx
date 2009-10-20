<%@ Page Title="" Language="C#" MasterPageFile="~/ShopHelper/NestedImportItemStep.master"
    AutoEventWireup="true" CodeBehind="ImportItem_Step2_Options.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.ShopHelper.ImportItem_Step2_Options" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StepHeaderHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="StepSearchHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="StepDisplayHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="StepContentHolder" runat="server">
    <div>
        <asp:Label ID="lblItemNumber" runat="server"></asp:Label>
    </div>
    <div>
        <span>宝贝名称修饰</span>
    </div>
    <div>
        <span>价格调整</span>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="StepFooterHolder" runat="server">
    <asp:LinkButton ID="lbtnBack" runat="server" onclick="lbtnBack_Click">返回重新选择宝贝</asp:LinkButton>
    <asp:LinkButton ID="lbtnImport" runat="server" onclick="lbtnImport_Click">导入宝贝</asp:LinkButton>
</asp:Content>
