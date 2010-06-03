<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    CodeFile="FileManagement.aspx.cs" Inherits="Admins_FileManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="content.css" rel="stylesheet" type="text/css" />
    <link href="filemanagement.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        function DoUploadFile() {
            document.getElementById("<%= fuFile.ClientID %>").click();
        }
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div class="Summary">
        <span>管理站点资源文件</span> <span class="Description">这里可添加和删除必要的站点资源文件（限定图片，样式表及JS脚本三种文件类型）。</span>
    </div>
    <div class="Content">
        <div class="Operator">
            <asp:HyperLink ID="hlnkUpload" NavigateUrl="javascript:DoUploadFile();" runat="server"><span>上传文件</span></asp:HyperLink><span
                class="Description">* 只能上传图片文件，样式表文件及JS脚本文件。</span><asp:FileUpload ID="fuFile" CssClass="FileUpdateControl"
                    runat="server" />
        </div>
        <div class="FileList">
            <asp:Repeater ID="rptFileList" runat="server">
                <HeaderTemplate>
                    <div class="THeader">
                        <span class="Name">文件名</span><span class="Type">文件类型</span><span class="Size">大小
                        </span><span class="Date">上传时间</span><span class="Link"></span>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="TRow">
                        <asp:Label ID="lblFileName" CssClass="Name" runat="server"><%# Eval("FileName") %></asp:Label>
                        <asp:Label ID="lblFileType" CssClass="Type" runat="server"><%# Eval("TypeName") %></asp:Label>
                        <asp:Label ID="lblFileSize" CssClass="Size" runat="server"><%# Eval("Size") %></asp:Label>
                        <asp:Label ID="lblUploadDate" CssClass="Date" runat="server"><%# Eval("CreateTime", "{0:yyyy-MM-dd HH:mm:ss}")%></asp:Label>
                        <asp:LinkButton ID="lbtnDelete" CssClass="Link" runat="server">删除</asp:LinkButton>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="TRow Alternating">
                        <asp:Label ID="lblFileName" CssClass="Name" runat="server"><%# Eval("FileName") %></asp:Label>
                        <asp:Label ID="lblFileType" CssClass="Type" runat="server"><%# Eval("TypeName") %></asp:Label>
                        <asp:Label ID="lblFileSize" CssClass="Size" runat="server"><%# Eval("Size") %></asp:Label>
                        <asp:Label ID="lblUploadDate" CssClass="Date" runat="server"><%# Eval("CreateTime", "{0:yyyy-MM-dd HH:mm:ss}")%></asp:Label>
                        <asp:LinkButton ID="lbtnDelete" CssClass="Link" runat="server">删除</asp:LinkButton>
                    </div>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <script type="text/javascript">

        document.getElementById("<%= fuFile.ClientID %>").onchange = function() {
            alert(this.id);
        }
    
    </script>

</asp:Content>
