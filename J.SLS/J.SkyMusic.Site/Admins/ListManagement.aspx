<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ListManagement.aspx.cs" Inherits="Admins_ListManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="listmanagement.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div class="Summary">
        <asp:Label ID="lblTitle" runat="server" Text="列表管理"></asp:Label>
    </div>
    <div class="Content">
        <div class="Operator">
            <asp:HyperLink ID="hlnkAdd" runat="server"><span>新增列表</span></asp:HyperLink><asp:HyperLink
                ID="hlnkCancel" runat="server"><span>返回</span></asp:HyperLink>
        </div>
        <div class="TipDiv">
            <span id="lblJsErrorMsg"></span>
        </div>
        <div class="ListDiv">
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <div class="THeader">
                        <span class="Name">列表名称</span><span class="Code">编码</span><span class="Count">子页面数量</span><span
                            class="Link"></span>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="TRow">
                        <asp:Label ID="lblFileName" CssClass="Name" runat="server"><%# Eval("Name")%></asp:Label>
                        <asp:Label ID="lblFileType" CssClass="Code" runat="server"><%# Eval("Code")%></asp:Label>
                        <asp:Label ID="lblFileSize" CssClass="Count" runat="server"><%# Eval("ChildrenCount")%></asp:Label>
                        <span class="Link">
                            <asp:HyperLink ID="hlnkEdit" runat="server" NavigateUrl='<%# Eval("Id", "EditList.aspx?Id={0}") %>'>编辑</asp:HyperLink>
                            <asp:LinkButton ID="lbtnDelete" runat="server">删除</asp:LinkButton></span>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="TRow Alternating">
                        <asp:Label ID="lblFileName" CssClass="Name" runat="server"><%# Eval("Name")%></asp:Label>
                        <asp:Label ID="lblFileType" CssClass="Code" runat="server"><%# Eval("Code")%></asp:Label>
                        <asp:Label ID="lblFileSize" CssClass="Count" runat="server"><%# Eval("ChildrenCount")%></asp:Label>
                        <span class="Link">
                            <asp:HyperLink ID="hlnkEdit" runat="server" NavigateUrl='EditList.aspx?Id=<%# Eval("Id") %>'>编辑</asp:HyperLink>
                            <asp:LinkButton ID="lbtnDelete" runat="server">删除</asp:LinkButton></span>
                    </div>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
