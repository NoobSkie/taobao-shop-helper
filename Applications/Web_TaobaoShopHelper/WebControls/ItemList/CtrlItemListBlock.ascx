<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlItemListBlock.ascx.cs"
    Inherits="TestTOP.WebControls.ItemList.CtrlItemListBlock" %>
<div class="block" style="float: left;" style="clear: both; margin-right: 20px; margin-bottom: 20px;">
    <div>
        <asp:HyperLink ID="hlnkItemPic" runat="server" Target="_blank">
            <asp:Image ID="imgItemPic" runat="server" Width="90" Height="90" /></asp:HyperLink></div>
    <div>
        <asp:Button ID="btnImport" runat="server" Text="导入到我的店铺" 
            onclick="btnImport_Click" />
    </div>
    <div>
        <asp:Label ID="lblPriceTitle" runat="server" Text="一口价:"></asp:Label>
        <asp:Label ID="lblPrice" runat="server" Text="100.00"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblNickTitle" runat="server" Text="卖家:"></asp:Label>
        <asp:Label ID="lblNick" runat="server" Text="卖家"></asp:Label>
    </div>
    <div>
        <asp:HyperLink ID="hlnkName" runat="server" Target="_blank">名称</asp:HyperLink></div>
</div>
