<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InitDbSchema.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.TestPages.InitDbSchema" %>

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
                <asp:TreeView ID="tvSchema" runat="server" ImageSet="XPFileExplorer" 
                    NodeIndent="15" NodeStyle-Height="22">
                    <ParentNodeStyle Font-Bold="False" />
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" 
                        HorizontalPadding="0px" VerticalPadding="0px" />
                    <Nodes>
                        <asp:TreeNode Text="表对象" Value="Table"></asp:TreeNode>
                        <asp:TreeNode Text="视图对象" Value="View"></asp:TreeNode>
                    </Nodes>
                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" 
                        HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                </asp:TreeView>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
