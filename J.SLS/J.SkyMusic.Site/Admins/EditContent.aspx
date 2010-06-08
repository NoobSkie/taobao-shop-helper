<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    CodeFile="EditContent.aspx.cs" Inherits="Admins_EditContent" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="editcontent.css" rel="stylesheet" type="text/css" />
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
                <span>名称</span><asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <span>* 必填！如果此文章被添加到菜单中，菜单的名称将显示此名称。</span>
            </div>
            <div>
                <span>列表名称（HTML）</span>
                <FTB:FreeTextBox ID="ftxtListName" runat="server">
                </FTB:FreeTextBox>
                <span>在列表中显示的文章标题，会显示此名称。如不填写此项，则会用名称代替。</span>
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
                <span>请勾选需要引用到文章中的样式表文件</span>
                <div>
                </div>
                <span>* 注：样式表文件必须先上传</span>
            </div>
            <div>
                <span>请勾选需要引用到文章中的脚本文件</span>
                <div>
                </div>
                <span>* 注：脚本文件必须先上传</span>
            </div>
        </div>
    </div>
</asp:Content>
