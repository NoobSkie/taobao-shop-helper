<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="CollectionEdit.aspx.cs" Inherits="Admin_CollectionEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div>
        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <span>名称</span><asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <span>* 必填！名称将显示在列表或模块的标题中。</span>
    </div>
    <div>
        <span>标题（HTML）</span><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        <span>标题将显示为内容页中的标题。如不填写此项，则会用名称代替。</span>
    </div>
    <div>
        <span>摘要（HTML）</span><asp:TextBox ID="txtSummary" runat="server"></asp:TextBox>
        <span>如果此文章需要作为单独模块显示，摘要将会显示在模块内容中。如不填写此项，则会用内容代替。</span>
    </div>
    <div>
        <span>内容（HTML）</span><asp:TextBox ID="txtContent" runat="server"></asp:TextBox>
        <span>* 必填！详细内容将会显示在内容页中。</span>
    </div>
    <div>
        <asp:LinkButton ID="lbtnSave" runat="server" onclick="lbtnSave_Click">保存</asp:LinkButton><asp:HyperLink ID="hlnkCancel"
            runat="server">返回</asp:HyperLink>
    </div>
</asp:Content>
