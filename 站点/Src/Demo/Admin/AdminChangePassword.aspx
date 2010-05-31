<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AdminChangePassword.aspx.cs" Inherits="Admin_AdminChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div>
        <span>修改管理员密码</span>
    </div>
    <div>
        <span>请输入旧密码：</span><asp:TextBox ID="txtOldPassword" TextMode="Password" runat="server"></asp:TextBox>
    </div>
    <div>
        <span>请输入新密码：</span><asp:TextBox ID="txtNewPassword" TextMode="Password" runat="server"></asp:TextBox>
    </div>
    <div>
        <span>请再次输入新密码：</span><asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Button ID="btnOk" runat="server" Text="修改密码" OnClick="btnOk_Click" />
    </div>
</asp:Content>
