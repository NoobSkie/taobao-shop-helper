<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    EnableEventValidation="false" ValidateRequest="false" CodeFile="EditContent.aspx.cs"
    Inherits="Admins_EditContent" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="editcontent.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div class="Summary">
        <asp:Label ID="lblTitle" runat="server" Text="编辑文章内容"></asp:Label>
    </div>
    <div class="Content">
        <div class="Operator">
            <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click"><span>保存</span></asp:LinkButton><asp:HyperLink
                ID="hlnkCancel" runat="server"><span>返回</span></asp:HyperLink>
        </div>
        <div class="ContentLayout">
            <div class="LayoutRow">
                <span class="Title">名称</span><asp:TextBox ID="txtName" CssClass="Input" runat="server"></asp:TextBox>
                <span class="Tip">* 必填！如果此文章被添加到菜单中，菜单的名称将显示此名称。</span>
            </div>
            <div class="LayoutRow">
                <span class="Title">标题</span><asp:TextBox ID="txtTitle" CssClass="Input" runat="server"></asp:TextBox>
                <span class="Tip">标题将显示为内容页中的标题。如不填写此项，则会用名称代替。</span>
            </div>
            <div class="LayoutRow">
                <span class="Title">内容（HTML）</span>
                <FTB:FreeTextBox ID="txtContent" Width="700" runat="server">
                </FTB:FreeTextBox>
                <span class="Tip">* 必填！详细内容将会显示在内容页中。</span>
            </div>
        </div>
    </div>
</asp:Content>
