<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserLoginCtrl.ascx.cs"
    Inherits="Components_WebControls_UserLoginCtrl" %>
<div class="login fl" style="margin-top: 15px;">
    <div class="input mt">
        <span class="cl">账 号：</span><span class="text"><asp:TextBox ID="txtUserId" runat="server"></asp:TextBox></span></div>
    <div class="input">
        <span class="cl">密 码：</span><span class="text"><asp:TextBox ID="txtPassword" TextMode="Password"
            runat="server"></asp:TextBox></div>
    <div class="input" style="font-size: 14px; color: Red;">
        <a href="Register.aspx" style="font-size: 14px; color: Red;">免费注册</a> | <a href="FindPassword.aspx"
            style="font-size: 14px; color: Red;">忘记密码</a>
        <asp:Button ID="btnLogin" runat="server" CssClass="submit" OnClick="btnLogin_Click" /></div>
    <div class="input">
        <a href="UserCenter.aspx">
            <img src="Images/loginPAY.jpg" /></a> <a href="UserCenter.aspx">
                <img src="Images/loginQQ.jpg" /></a></div>
</div>