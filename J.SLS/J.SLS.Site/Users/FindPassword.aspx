<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMasterPage.master" AutoEventWireup="true" CodeFile="FindPassword.aspx.cs" Inherits="Users_FindPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="center">
        <div class="get_title">
        </div>
        <div class="get_list">
            <div class="gl fl">
                <div class="s">
                    选择密码类型：</div>
                <div>
                    请输入您注册时填写的用户名：</div>
                <div>
                    请输入您注册时填写的电子邮箱：</div>
            </div>
            <div class="fl">
                <div class="s">
                    <input type="radio" name="type" checked />登陆密码&nbsp;&nbsp;<input type="radio" name="type" /><span>发彩网</span>资金密码</div>
                <div class="in">
                    <span>
                        <input type="text" /></span></div>
                <div class="in">
                    <span>
                        <input type="text" /></span></div>
                <div class="sb">
                    <input type="submit" class="submit" value="" /><input type="reset" value="" class="reset" /></div>
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

