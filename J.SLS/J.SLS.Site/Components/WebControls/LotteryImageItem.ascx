<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LotteryImageItem.ascx.cs"
    Inherits="Components_WebControls_LotteryImageItem" %>
<asp:Image ID="imgMain" runat="server" ImageUrl="~/Images/game_01.jpg" />
<span class="cb">
    <asp:HyperLink ID="hlnkDrawa" runat="server" class="fl">
        <asp:Image ID="imgDrawa" ImageUrl="~/Images/jiqiao.jpg" runat="server" /></asp:HyperLink>
    <asp:HyperLink ID="hlnkBehavior" runat="server" class="fl">
        <asp:Image ID="imgBehavior" ImageUrl="~/Images/zhoushi.jpg" runat="server" /></asp:HyperLink>
</span>
<asp:HyperLink ID="hlnkBuy" runat="server">
    <asp:Image ID="imgBuy" ImageUrl="~/Images/startgame.jpg" runat="server" /></asp:HyperLink>