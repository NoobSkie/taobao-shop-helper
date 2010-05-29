<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WithMenuPage.master"
    AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Users_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="center">
        <div class="reg_title">
            <div class="login_message">
                <asp:Label ID="lblMessage" runat="server"></asp:Label></div>
        </div>
        <div class="reg_height get_list">
            <div class="rl gl fl">
                <div>
                    用&nbsp;户&nbsp;名:</div>
                <div>
                    登录密码:</div>
                <div>
                    确认密码:</div>
                <div>
                    电子邮箱:</div>
                <div>
                    真实姓名:</div>
            </div>
            <div class="fl">
                <div class="in">
                    <span>
                        <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox></span><font>*</font>&nbsp;&nbsp;长度为2~6个汉字，或4~12个字母、也可由数字组成。</div>
                <div class="in">
                    <span>
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox></span><font>*</font>&nbsp;&nbsp;长度为6～15位，由字母和数字组成。</div>
                <div class="in">
                    <span>
                        <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server"></asp:TextBox></span><font>*</font>&nbsp;&nbsp;请再次输入您的登录密码。</div>
                <div class="in">
                    <span>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></span><font>*&nbsp;&nbsp;重要！用于找回密码。</font></div>
                <div class="in">
                    <span>
                        <asp:TextBox ID="txtRealName" runat="server"></asp:TextBox></span><font>*&nbsp;&nbsp;重要！用于领取奖金。</font></div>
                <div>
                    <input type="checkbox" checked="checked" />我已经同意<a href="#"> 《服务协议》</a> 和 <a href="#">
                        《电话投注服务协议》</a>
                </div>
                <div class="sb">
                    <asp:Button ID="btnRegister" runat="server" CssClass="csubmit" OnClick="btnRegister_Click" />
                    <input type="reset" value="" class="creset" /></div>
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
