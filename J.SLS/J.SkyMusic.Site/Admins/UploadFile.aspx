<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    CodeFile="UploadFile.aspx.cs" Inherits="Admins_UploadFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div>
        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <span>选择文件</span><asp:FileUpload ID="fuFile" CssClass="FileUpdateControl" runat="server" />
        <asp:HyperLink ID="hlnkAddFile" runat="server">添加</asp:HyperLink>
    </div>
    <div>
    </div>
    <div>
        <span>* 只能上传图片文件，样式表文件及JS脚本文件。</span>
    </div>
    <div>
        <asp:LinkButton ID="lbtnUpload" runat="server">上传文件</asp:LinkButton>
    </div>
</asp:Content>
