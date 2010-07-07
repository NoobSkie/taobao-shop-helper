<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    CodeFile="EditList.aspx.cs" Inherits="Admins_EditList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="editlist.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        function CheckSave() {
            var name = document.getElementById("<%= txtName.ClientID %>").value;
            if (name == "") {
                alert("请填入列表名称！");
                return false;
            }
            return true;
        }
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div class="Summary">
        <asp:Label ID="lblTitle" runat="server"></asp:Label>
    </div>
    <div class="Content">
        <div class="TipDiv">
            <asp:Label ID="lblInformation" Visible="false" runat="server"></asp:Label></div>
        <div class="ContentLayout">
            <div class="LayoutRow">
                <asp:Label ID="lblNameTag" CssClass="Title" runat="server" Text="列表名称"></asp:Label>
                <asp:TextBox ID="txtName" runat="server" Width="350"></asp:TextBox>
            </div>
        </div>
        <div class="Operator">
            <asp:HyperLink ID="hlnkAddSub" runat="server"><span>添加子页面</span></asp:HyperLink>
            <asp:LinkButton ID="lbtnSave" runat="server" OnClientClick="return CheckSave();"
                OnClick="lbtnSave_Click"><span>保存</span></asp:LinkButton><asp:HyperLink ID="hlnkCancel"
                    NavigateUrl="ListManagement.aspx" runat="server"><span>返回列表管理</span></asp:HyperLink>
        </div>
        <div class="ListDiv">
            <asp:Repeater ID="rptHtmlList" runat="server" OnItemCommand="rptHtmlList_ItemCommand">
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
                            <asp:HyperLink ID="hlnkEdit" runat="server" NavigateUrl='<%# "EditContent.aspx?id=" + Eval("Id") + "&lid=" + Eval("ItsListId") %>'>编辑</asp:HyperLink>
                            <asp:LinkButton ID="lbtnDelete" CommandName="Delete" CommandArgument='<%# Eval("Id") %>'
                                OnClientClick=<%# Eval("Name", "return confirm('确定删除此列表吗？ - {0}');") %> runat="server">删除</asp:LinkButton></span>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="TRow Alternating">
                        <asp:Label ID="lblFileName" CssClass="Name" runat="server"><%# Eval("Name")%></asp:Label>
                        <asp:Label ID="lblFileType" CssClass="CreateTime" runat="server"><%# Eval("CreateTime", "{0:yyyy-MM-dd HH:mm:ss}")%></asp:Label>
                        <asp:Label ID="lblFileSize" CssClass="LastUpdateTime" runat="server"><%# Eval("LastUpdateTime", "{0:yyyy-MM-dd HH:mm:ss}")%></asp:Label>
                        <span class="Link">
                            <asp:HyperLink ID="hlnkEdit" runat="server" NavigateUrl='<%# "EditContent.aspx?id=" + Eval("Id") + "&lid=" + Eval("ItsListId") %>'>编辑</asp:HyperLink>
                            <asp:LinkButton ID="lbtnDelete" CommandName="Delete" CommandArgument='<%# Eval("Id") %>'
                                OnClientClick=<%# Eval("Name", "return confirm('确定删除此列表吗？ - {0}');") %> runat="server">删除</asp:LinkButton></span>
                    </div>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
