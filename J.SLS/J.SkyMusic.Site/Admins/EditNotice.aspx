<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    CodeFile="EditNotice.aspx.cs" Inherits="Admins_EditNotice" ValidateRequest="false" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="editcontent.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div class="Summary">
        <asp:Label ID="lblTitle" runat="server" Text="编辑标题"></asp:Label>
    </div>
    <div class="Content">
        <div class="Operator">
            <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click"><span>保存</span></asp:LinkButton><asp:HyperLink
                ID="hlnkCancel" runat="server" NavigateUrl="NoticeManagement.aspx"><span>返回</span></asp:HyperLink>
        </div>
        <div class="ContentLayout">
            <div class="LayoutRow">
                <span class="Title">名称</span><asp:TextBox ID="txtName" CssClass="Input" runat="server"></asp:TextBox>
                <span class="Tip">* 必填！列表中将显示此名称。</span>
            </div>
            <div class="LayoutRow">
                <span class="Title">标题</span><asp:TextBox ID="txtTitle" CssClass="Input" runat="server"></asp:TextBox>
                <span class="Tip">* 必填！首页上会显示此标题。</span>
            </div>
            <div class="LayoutRow">
                <span class="Title">开始时间</span><asp:TextBox ID="txtStartTime" CssClass="Input" runat="server"></asp:TextBox>
                <span class="Tip">* 格式：<%= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>！如果不填写此项，则立即开始。</span>
            </div>
            <div class="LayoutRow">
                <span class="Title">结束时间</span><asp:TextBox ID="txtEndTime" CssClass="Input" runat="server"></asp:TextBox>
                <span class="Tip">* 格式：<%= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>！如果不填写此项，则为手动结束开始。</span>
            </div>
            <div class="LayoutRow">
                <span class="Title">选项</span>
                <asp:CheckBox ID="cbHasDetail" CssClass="CheckOption" runat="server" Text="有详细内容" /><asp:CheckBox
                    ID="cbIsForeRed" CssClass="CheckOption" Text="标题显红" runat="server" /><asp:CheckBox
                        ID="cbIsForeBold" CssClass="CheckOption" Text="标题加粗" runat="server" /><asp:CheckBox
                            ID="cbIsEnd" CssClass="CheckOption" runat="server" Text="是否结束" />
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
