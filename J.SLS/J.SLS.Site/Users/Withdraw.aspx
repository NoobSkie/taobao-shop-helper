<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WithMenuPage.master" AutoEventWireup="true"
    CodeFile="Withdraw.aspx.cs" Inherits="Users_Withdraw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div style="clear: both;">
        <div>
            <span>银行：</span><asp:TextBox ID="txtBankName" runat="server"></asp:TextBox></div>
        <div>
            <span>账号：</span><asp:TextBox ID="txtAccount" runat="server"></asp:TextBox></div>
        <div>
            <span>提款金额：</span><asp:TextBox ID="txtMoney" runat="server"></asp:TextBox></div>
        <div>
            <span>可提款金额：</span><asp:Label ID="lblMoneyDesc" runat="server" Text=""></asp:Label></div>
        <div>
            <asp:Button ID="btnOk" runat="server" Text="确定提款" OnClick="btnOk_Click" /></div>
    </div>
</asp:Content>
