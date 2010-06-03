<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AdminLogin.aspx.cs" Inherits="Admins_AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div>
        <span>登陆管理员身份</span></div>
    <div>
        <span>请输入管理员密码：</span><asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Button ID="btnLogin" runat="server" Text="进入后台管理" OnClick="btnLogin_Click" />
    </div>
</asp:Content>
