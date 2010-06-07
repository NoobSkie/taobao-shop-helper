<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/AdminMaster.master" AutoEventWireup="true"
    CodeFile="FileManagement.aspx.cs" Inherits="Admins_FileManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="filemanagement.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        function DoUploadFile() {
            document.getElementById("<%= fuFile.ClientID %>").click();
            __doPostBack('<%= lbtnUpload.UniqueID %>', '');
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
            <asp:LinkButton ID="lbtnUpload" runat="server"></asp:LinkButton>
        </div>
        <div class="TipDiv">
            <span id="lblJsErrorMsg">提示：文件大小已超过 1M</span>
        </div>
        <div class="FileList">
            <asp:Repeater ID="rptFileList" runat="server">
                <HeaderTemplate>
                    <div class="THeader">
                        <span class="Name">文件名</span><span class="Type">文件类型</span><span class="Size">大小</span><span
                            class="Date">上传时间</span><span class="Link"></span>
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

        var allowTypes = '<%= AllowFileExtensions %>';

        document.getElementById("<%= fuFile.ClientID %>").onchange = function() {
            var allowTypeList = allowTypes.split(",");
            if (!CheckFileType(allowTypeList, this.value)) {
                ShowMessage("此文件类型不允许上传 - \"" + this.value + "\"！", "");
                return false;
            }
            return true;
        }

        function CheckFileType(allowList, fileName) {
            var seat = fileName.lastIndexOf(".");
            //返回位于String对象中指定位置的子字符串并转换为小写.
            var extension = fileName.substring(seat).toLowerCase();
            for (var i = 0; i < allowList.length; i++) {
                if (allowList[i] == extension) {
                    return true;
                }
            }
            return false;
        }

        function ShowMessage(msg, type) {
            document.getElementById("lblJsErrorMsg").innerText = msg;
            document.getElementById("lblJsErrorMsg").className = type;
        }
    
    </script>

</asp:Content>
