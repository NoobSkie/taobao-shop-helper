<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" EnableEventValidation="false"
    Inherits="TestTOP._Default" ValidateRequest="false" Buffer="false" %>

<%@ Register Src="~/WebControls/ItemList/CtrlItemListBlock.ascx" TagName="CtrlItemListBlock"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-family: 宋体; font-size: 12px;">
    <form id="form1" runat="server">
    <div style="margin-bottom: 20px;">
        <span>搜索商品</span>
        <asp:DropDownList ID="ddlQueryType" runat="server" Font-Size="12px" Font-Names="宋体">
            <asp:ListItem Text="按关键字" Value="key" Selected="True"></asp:ListItem>
            <asp:ListItem Text="按卖家昵称" Value="nick"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtQ" runat="server" Width="300" Font-Size="12px" Font-Names="宋体"></asp:TextBox>
        <asp:Button ID="btnTest" runat="server" Font-Size="12px" Font-Names="宋体" OnClick="btnTest_Click"
            Text="搜索商品" />
    </div>
    <div style="margin-bottom: 20px;">
        <asp:Label ID="lblResult" runat="server" Text="搜索结果"></asp:Label>
        <asp:Label ID="lblItemCount" runat="server" Text="0条记录"></asp:Label></div>
    <asp:Repeater ID="repeater" runat="server">
        <ItemTemplate>
            <uc1:CtrlItemListBlock ID="ctrlItem" CurrentItem="<%# Container.DataItem %>" runat="server" />
        </ItemTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
