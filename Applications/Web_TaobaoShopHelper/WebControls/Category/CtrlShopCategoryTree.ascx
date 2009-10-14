<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlShopCategoryTree.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Category.CtrlShopCategoryTree" %>
<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<ComponentArt:TreeView ID="tvCategory" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
    HoverNodeCssClass="HoverTreeNode" SelectedNodeCssClass="SelectedTreeNode" ShowLines="True"
    LineImagesFolderUrl="~/Images/Lines" ImagesBaseUrl="~/Images/Icos" LineImageWidth="19"
    LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
    ExpandNodeOnSelect="true" CollapseNodeOnSelect="false" MultipleSelectEnabled="False"
    ClientTarget="Auto" Width="200" Height="100%">
</ComponentArt:TreeView>