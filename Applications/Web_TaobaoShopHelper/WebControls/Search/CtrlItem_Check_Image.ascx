<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlItem_Check_Image.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Search.CtrlItem_Check_Image" %>
<div class="Item_Image">
    <div class="Image">
        <asp:Image ID="imgImage" runat="server" />
    </div>
    <div class="Check">
        <asp:CheckBox ID="cbCheck" runat="server" />
    </div>
    <div class="Price">
        <asp:Label ID="lblPrice" CssClass="Money" runat="server"></asp:Label><span class="Unit">元</span>
    </div>
</div>
