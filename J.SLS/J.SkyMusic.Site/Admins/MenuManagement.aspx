<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    CodeFile="MenuManagement.aspx.cs" Inherits="Admins_MenuManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="menumanagement.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        function ConfirmDelete(menuName) {
            return confirm("确定删除菜单吗？ - " + menuName);
        }
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div class="ListDiv">
        <div class="THeader">
            <span class="Name">菜单名称</span><span class="Index">顺序号</span><span class="Link"></span>
        </div>
        <asp:Repeater ID="rptMenu1" runat="server" OnItemDataBound="rptMenu1_ItemDataBound"
            OnItemCommand="rptMenu1_ItemCommand" onitemcreated="rptMenu1_ItemCreated">
            <ItemTemplate>
                <div class="TRow Menu1">
                    <asp:Label ID="lblName" CssClass="Name" runat="server"><%# Eval("Name")%></asp:Label>
                    <asp:Label ID="lblIndex" CssClass="Index" runat="server"><%# Eval("Index")%></asp:Label>
                    <span class="Link">
                        <asp:HyperLink ID="hlnkEdit" runat="server" NavigateUrl='<%# Eval("Id", "MenuEdit.aspx?id={0}") %>'>编辑</asp:HyperLink>
                        <asp:LinkButton ID="lbtnDelete" OnClientClick=<%# Eval("Name", "return ConfirmDelete('{0}')") %>
                            CommandName="Delete" CommandArgument='<%# Eval("Id") %>' runat="server">删除</asp:LinkButton></span>
                </div>
                <asp:Repeater ID="rptMenu2" runat="server">
                    <ItemTemplate>
                        <div class="TRow Menu2">
                            <asp:Label ID="lblName" CssClass="Name" runat="server"><%# Eval("Name")%></asp:Label>
                            <asp:Label ID="lblIndex" CssClass="Index" runat="server"><%# Eval("Index")%></asp:Label>
                            <span class="Link">
                                <asp:HyperLink ID="hlnkEdit" runat="server" NavigateUrl='<%# Eval("Id", "MenuEdit.aspx?id={0}") %>'>编辑</asp:HyperLink>
                                <asp:LinkButton ID="lbtnDelete" OnClientClick=<%# Eval("Name", "return ConfirmDelete('{0}')") %>
                                    CommandName="Delete" CommandArgument='<%# Eval("Id") %>' runat="server">删除</asp:LinkButton></span>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
