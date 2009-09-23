﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaManager.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.Management.AreaManager" %>

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
            <asp:Button ID="btnUpdate" runat="server" Text="更新区域信息" OnClick="btnUpdate_Click" />
            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <div>
                <ComponentArt:TreeView ID="tvArea" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
                    HoverNodeCssClass="HoverTreeNode" SelectedNodeCssClass="SelectedTreeNode" ShowLines="True"
                    LineImagesFolderUrl="~/Images/Lines/" ImagesBaseUrl="~/Images/Icos/" LineImageWidth="19"
                    LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
                    ExpandNodeOnSelect="true" CollapseNodeOnSelect="false" MultipleSelectEnabled="False"
                    OnNodeExpanded="tvCategory_NodeExpanded" ClientTarget="Auto">
                </ComponentArt:TreeView>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
