<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="ResponseGetMoneyView.aspx.cs" Inherits="Admin_ResponseGetMoneyView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div>
            <span>用户：</span><asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <span>提款金额：</span><asp:Label ID="lblMoney" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <span>申请时间：</span><asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <span>银行：</span><asp:Label ID="lblBankName" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <span>卡号：</span><asp:Label ID="lblCardNumber" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Height="140px" Width="628px"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnAccept" runat="server" Text="接受，并已转账" OnClientClick="return confirm('请确定是否已经转账？');"
                OnClick="btnAccept_Click" />
            <asp:Button ID="btnReject" runat="server" Text="拒绝提款" OnClientClick="return confirm('确定要拒绝用户的提款申请吗？');"
                OnClick="btnReject_Click" /></div>
    </div>
</asp:Content>
