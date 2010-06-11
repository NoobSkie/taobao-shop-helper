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
            <asp:HyperLink ID="hlnkAdd" NavigateUrl="EditList.aspx" runat="server"><span>新增列表</span></asp:HyperLink>
        </div>
        <div class="ListDiv">
            <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                <HeaderTemplate>
                    <div class="THeader">
                        <span class="Name">列表名称</span><span class="Code">创建时间</span><span class="Link"></span>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="TRow">
                        <asp:Label ID="lblFileName" CssClass="Name" runat="server"><%# Eval("Name")%></asp:Label>
                        <asp:Label ID="lblFileType" CssClass="Code" runat="server"><%# Eval("CreateTime")%></asp:Label>
                        <span class="Link">
                            <asp:HyperLink ID="hlnkEdit" runat="server" NavigateUrl='<%# Eval("Id", "EditList.aspx?Id={0}") %>'>编辑</asp:HyperLink>
                            <asp:LinkButton ID="lbtnDelete" CommandName="Delete" CommandArgument='<%# Eval("Id") %>'
                                OnClientClick=<%# Eval("Name", "return confirm('确定删除此列表吗？ - {0}');") %> runat="server">删除</asp:LinkButton></span>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="TRow Alternating">
                        <asp:Label ID="lblFileName" CssClass="Name" runat="server"><%# Eval("Name")%></asp:Label>
                        <asp:Label ID="lblFileType" CssClass="Code" runat="server"><%# Eval("CreateTime")%></asp:Label>
                        <span class="Link">
                            <asp:HyperLink ID="hlnkEdit" runat="server" NavigateUrl='<%# Eval("Id", "EditList.aspx?Id={0}") %>'>编辑</asp:HyperLink>
                            <asp:LinkButton ID="lbtnDelete" OnClientClick=<%# Eval("Name", "return confirm('确定删除此列表吗？ - {0}');") %>
                                runat="server">删除</asp:LinkButton></span>
                    </div>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
