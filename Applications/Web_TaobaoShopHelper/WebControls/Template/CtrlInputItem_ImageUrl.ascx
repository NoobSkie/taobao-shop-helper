<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInputItem_ImageUrl.ascx.cs"
    EnableViewState="true" Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Template.CtrlInputItem_ImageUrl" %>
<div class="InputUnit Type_ImageUrl">
    <div class="ImageInput">
        <asp:Label ID="lblTitle" runat="server"></asp:Label>
        <asp:TextBox ID="txtContent" runat="server"></asp:TextBox>
    </div>
    <div class="ImagePreview">
        <asp:Image ID="imgPreview" BorderWidth="1" runat="server" />
    </div>
</div>
