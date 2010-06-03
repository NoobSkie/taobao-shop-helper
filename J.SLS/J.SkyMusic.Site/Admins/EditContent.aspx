<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    CodeFile="EditContent.aspx.cs" Inherits="Admins_EditContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div>
        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <span>名称</span><asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <span>* 必填！如果此文章被添加到菜单中，菜单的名称将显示此名称。</span>
    </div>
    <div>
        <span>列表名称（HTML）</span><asp:TextBox ID="txtListName" runat="server"></asp:TextBox>
        <span>在列表中显示的文章标题，会显示此名称。如不填写此项，则会用内容代替。</span>
    </div>
    <div>
        <span>标题（HTML）</span><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        <span>标题将显示为内容页中的标题。如不填写此项，则会用名称代替。</span>
    </div>
    <div>
        <span>内容（HTML）</span><asp:TextBox ID="txtContent" runat="server"></asp:TextBox>
        <span>* 必填！详细内容将会显示在内容页中。</span>
    </div>
    <div>
        <asp:CheckBox ID="ckAdvance" runat="server" Text="高级选项" />
    </div>
    <div>
        <span>需引用到文章中的样式表文件</span>
        <asp:HyperLink ID="hlnkAddStyle" runat="server">添加</asp:HyperLink>
        <div>
        </div>
        <span>* 注：样式表文件必须先上传</span>
    </div>
    <div>
        <span>需引用到文章中的脚本文件</span>
        <asp:HyperLink ID="hlnkAddScript" runat="server">添加</asp:HyperLink>
        <div>
        </div>
        <span>* 注：脚本文件必须先上传</span>
    </div>
    <div>
        <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click">保存</asp:LinkButton><asp:HyperLink
            ID="hlnkCancel" runat="server">返回</asp:HyperLink>
    </div>
</asp:Content>
