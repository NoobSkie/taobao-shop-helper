<%@ Page Language="C#" MasterPageFile="~/FrontWebPage/FrontMainMasterPage.master"
    AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="FrontWebPage_Login"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="center">
        <div class="login_title">
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
                        <input type="text" /></span></div>
                <div class="in">
                    <span>
                        <input type="text" /></span></div>
                <div class="sb">
                    <input type="submit" class="submit" value="" /><input type="reset" value="" class="reset" /></div>
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
