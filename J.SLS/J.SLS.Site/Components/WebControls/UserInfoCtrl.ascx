<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfoCtrl.ascx.cs"
    Inherits="Components_WebControls_UserInfoCtrl" %>
<div class="login fl" style="margin-top: 15px;">
    <div class="input mt">
        <span class="cl">欢迎您，</span><b><asp:Label ID="lblUserName" runat="server" Font-Bold="True"></asp:Label></b></div>
    <div class="input mt">
        <asp:HyperLink ID="hlnkFillMoney" runat="server" NavigateUrl="javascript:alert('暂未实现');">充值</asp:HyperLink>
        <asp:HyperLink ID="hlnkWithdraw" runat="server" NavigateUrl="~/Users/Withdraw.aspx">提款</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Users/WithdrawView.aspx">提款记录</asp:HyperLink></div>
</div>
