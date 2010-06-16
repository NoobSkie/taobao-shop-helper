<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlInnerUserInfo.ascx.cs"
    Inherits="Components_WebControls_CtrlInnerUserInfo" %>
<div style="margin: 15px auto;">
    <span>您好！</span><asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    <span style="width: 10px;"></span><span>您的余额：</span><strong class="red"><asp:Label
        ID="lblMoney" runat="server" Text=""></asp:Label></strong> <span style="width: 10px;">
        </span>
    <asp:HyperLink ID="hlnkFillMoney" runat="server" NavigateUrl="javascript:alert('暂未实现');">充值</asp:HyperLink>
    <span style="width: 10px;"></span>
    <asp:HyperLink ID="hlnkWithdraw" runat="server" NavigateUrl="~/Users/Withdraw.aspx">提款</asp:HyperLink>
    <span style="width: 10px;"></span>
    <asp:HyperLink ID="hlnkLogout" NavigateUrl="~/Users/Logout.aspx" runat="server">安全退出</asp:HyperLink></div>
