<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InitDbSchema.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.TestPages.InitDbSchema" %>

<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="padding-left: 9px; margin-bottom: 5px;">
            <asp:Button ID="btnUpdate" runat="server" Text="更新数据库对象" OnClick="btnUpdate_Click" />
            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <div>
                <ComponentArt:TreeView ID="tvSchema" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
                    HoverNodeCssClass="HoverTreeNode" SelectedNodeCssClass="SelectedTreeNode" ShowLines="True"
                    LineImagesFolderUrl="~/Images/Lines/" ImagesBaseUrl="~/Images/Icos/" LineImageWidth="19"
                    LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
                    ExpandNodeOnSelect="true" CollapseNodeOnSelect="false" MultipleSelectEnabled="true"
                    ClientTarget="Auto">
                    <Nodes>
                        <ComponentArt:TreeViewNode ID="nodeTable" runat="server" ImageHeight="16" ImageWidth="16"
                            LabelPadding="3" Text="表对象" Value="table" ImageUrl="folder.gif" ExpandedImageUrl="folder_open.gif" Expanded="true">
                        </ComponentArt:TreeViewNode>
                        <ComponentArt:TreeViewNode ID="nodeView" runat="server" ImageHeight="16" ImageWidth="16"
                            LabelPadding="3" Text="视图对象" Value="view" ImageUrl="folder.gif" ExpandedImageUrl="folder_open.gif" Expanded="true">
                        </ComponentArt:TreeViewNode>
                    </Nodes>
                </ComponentArt:TreeView>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
