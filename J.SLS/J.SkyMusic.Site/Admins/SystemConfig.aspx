<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true" CodeFile="SystemConfig.aspx.cs" Inherits="Admins_SystemConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" Runat="Server">
    <link href="systemconfig.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" Runat="Server">
    <div class="Summary">
        <asp:Label ID="lblTitle" runat="server" Text="系统参数配置"></asp:Label>
    </div>
    <div class="Content">
        <div class="Operator">
            <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click"><span>保存</span></asp:LinkButton><asp:HyperLink
                ID="hlnkCancel" runat="server"><span>返回</span></asp:HyperLink>
        </div>
        <div class="ContentLayout">
            <div class="LayoutRow">
                <span class="Title">站点名称</span><asp:TextBox ID="txtSiteName" CssClass="Input" runat="server"></asp:TextBox>
            </div>
            <div class="LayoutRow">
                <span class="Title">总公司地址</span><asp:TextBox ID="txtAddress" CssClass="Input" runat="server"></asp:TextBox>
            </div>
            <div class="LayoutRow">
                <span class="Title">电话</span><asp:TextBox ID="txtPhone" CssClass="Input" runat="server"></asp:TextBox>
            </div>
            <div class="LayoutRow">
                <span class="Title">传真</span><asp:TextBox ID="txtFax" CssClass="Input" runat="server"></asp:TextBox>
            </div>
            <div class="LayoutRow">
                <span class="Title">QQ号码</span><asp:TextBox ID="txtQQ" CssClass="Input" runat="server"></asp:TextBox>
            </div>
            <div class="LayoutRow">
                <span class="Title">自动播放背景音乐</span><asp:CheckBox ID="cbAutoMusic" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>

