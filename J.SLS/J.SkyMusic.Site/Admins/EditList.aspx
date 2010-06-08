<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    CodeFile="EditList.aspx.cs" Inherits="Admins_EditList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="editlist.css" rel="stylesheet" type="text/css" />
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
        <div class="TipDiv">
            <span id="lblJsErrorMsg"></span>
        </div>
        <div class="ContentLayout">
            <div>
                <asp:Label ID="lblNameTag" runat="server" Text="列表名称"></asp:Label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox><asp:Button ID="btnSave" runat="server"
                    Text="修改名称" />
            </div>
        </div>
        <div class="ListDiv">
            <asp:Repeater ID="rptHtmlList" runat="server">
                <HeaderTemplate>
                    <div class="THeader">
                        <span class="Name">子页面名称</span><span class="CreateTime">创建时间</span><span class="LastUpdateTime">最后更新</span><span
                            class="Link"></span>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="TRow">
                        <asp:Label ID="lblFileName" CssClass="Name" runat="server"><%# Eval("Name")%></asp:Label>
                        <asp:Label ID="lblFileType" CssClass="CreateTime" runat="server"><%# Eval("CreateTime", "{0:yyyy-MM-dd HH:mm:ss}")%></asp:Label>
                        <asp:Label ID="lblFileSize" CssClass="LastUpdateTime" runat="server"><%# Eval("LastUpdateTime", "{0:yyyy-MM-dd HH:mm:ss}")%></asp:Label>
                        <span class="Link">
                            <asp:HyperLink ID="hlnkEdit" runat="server" NavigateUrl='<%# Eval("Id", "EditContent.aspx?Id={0}") %>'>编辑</asp:HyperLink>
                            <asp:LinkButton ID="lbtnDelete" runat="server">删除</asp:LinkButton></span>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="TRow Alternating">
                        <asp:Label ID="lblFileName" CssClass="Name" runat="server"><%# Eval("Name")%></asp:Label>
                        <asp:Label ID="lblFileType" CssClass="CreateTime" runat="server"><%# Eval("CreateTime", "{0:yyyy-MM-dd HH:mm:ss}")%></asp:Label>
                        <asp:Label ID="lblFileSize" CssClass="LastUpdateTime" runat="server"><%# Eval("LastUpdateTime", "{0:yyyy-MM-dd HH:mm:ss}")%></asp:Label>
                        <span class="Link">
                            <asp:HyperLink ID="hlnkEdit" runat="server" NavigateUrl='<%# Eval("Id", "EditContent.aspx?Id={0}") %>'>编辑</asp:HyperLink>
                            <asp:LinkButton ID="lbtnDelete" runat="server">删除</asp:LinkButton></span>
                    </div>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
