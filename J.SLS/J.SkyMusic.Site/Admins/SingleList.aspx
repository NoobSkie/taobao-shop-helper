<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    CodeFile="SingleList.aspx.cs" Inherits="Admins_SingleList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="editlist.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div class="Summary">
        <span>未分类的独立页面列表</span>
    </div>
    <div class="Content">
        <div class="Operator">
            <asp:HyperLink ID="hlnkAddSub" runat="server"><span>添加页面</span></asp:HyperLink>
            <asp:HyperLink ID="hlnkCancel" NavigateUrl="ListManagement.aspx" runat="server"><span>返回列表管理</span></asp:HyperLink>
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
