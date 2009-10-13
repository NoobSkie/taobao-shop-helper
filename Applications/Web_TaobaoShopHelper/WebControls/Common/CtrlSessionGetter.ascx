<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSessionGetter.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Common.CtrlSessionGetter" %>
<div>
    <div>
        <asp:HyperLink ID="hlnkGetAppKey" Target="_blank" runat="server">获取淘宝授权码</asp:HyperLink>
    </div>
    <div>
        <asp:TextBox ID="txtAuthCode" runat="server"></asp:TextBox>
        <asp:LinkButton ID="lbtnGetSessionKey" runat="server" OnClick="lbtnGetSessionKey_Click">授权并进入系统</asp:LinkButton>
    </div>
</div>
