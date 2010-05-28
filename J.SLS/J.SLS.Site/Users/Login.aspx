<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMasterPage.master"
    AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Users_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="center">
        <div class="login_title">
            <div class="login_message">
                <asp:Label ID="lblMessage" runat="server"></asp:Label></div>
        </div>
        <div class="login_height get_list">
            <div class="ll gl fl">
                <div>
                    用户名：</div>
                <div>
                    密码：</div>
            </div>
            <div class="fl">
                <div class="in">
                    <span>
                        <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox></span></div>
                <div class="in">
                    <span>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></span></div>
                <div class="sb">
                    <asp:Button ID="btnLogin" runat="server" CssClass="submit" OnClick="btnLogin_Click" /><input
                        type="reset" value="" class="reset" /></div>
                <div class="bt in">
                    <a href="FindPassword.aspx">找回密码</a><a href="HelpCenter.aspx">帮助中心</a></div>
            </div>
        </div>
        <div class="get_footer">
        </div>
        <div class="notice">
            <strong>健康游戏公告:</strong> 彩市有风险，投注须谨慎，注意自我保护，谨防受骗上当。未满18周岁严禁购买彩票。</div>
        <div class="cb">
        </div>
    </div>
</asp:Content>
