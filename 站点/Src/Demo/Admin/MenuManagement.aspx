<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="MenuManagement.aspx.cs" Inherits="Admin_MenuManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div>
        <asp:Button ID="btnView" runat="server" Text="浏览" onclick="btnView_Click" />
        <asp:Button ID="btnAdd" runat="server" Text="新增" onclick="btnAdd_Click" />
    </div>
    <div style="float: left; min-width: 200px; display: block;">
        <asp:TreeView ID="tvMenus" runat="server" OnSelectedNodeChanged="tvMenus_SelectedNodeChanged">
        </asp:TreeView>
    </div>
    <div style="display: block; overflow: hidden;">
        <div>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div>
            <span>名称：</span>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </div>
        <div>
            <span>序号：</span>
            <asp:TextBox ID="txtIndex" runat="server"></asp:TextBox>
        </div>
        <div>
            <span>上级栏目：</span>
            <asp:DropDownList ID="ddlParentList" runat="server">
            </asp:DropDownList>
        </div>
        <div>
            <span>是否在新窗口打开</span>
            <asp:CheckBox ID="ckbIsOpenNewWindow" runat="server" Text="是" />
        </div>
        <div>
            <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
