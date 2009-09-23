<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.TestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnUpdateSellerCat" runat="server" OnClick="btnUpdateSellerCat_Click"
            Text="修改卖家自定义类目" />
    </div>
    <div>
        <asp:TextBox ID="txtShopNick" runat="server"></asp:TextBox>
        <asp:Button ID="btnGetShop" runat="server" Text="获取店铺基本信息" OnClick="btnGetShop_Click" />
    </div>
    <div>
        <span>昵称</span><asp:TextBox ID="txtNick_GetItemDetail" Width="120" runat="server"></asp:TextBox>
        <br />
        <span>商品编号</span><asp:TextBox ID="txtIid_GetItemDetail" Width="300" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnGetItemDetail" runat="server" Text="获取商品明细信息" OnClick="btnGetItemDetail_Click" />
    </div>
    <div>
        <span>类目Id</span><asp:TextBox ID="txtCid" Width="120" runat="server"></asp:TextBox>
        <br />
        <span>属性编号</span><asp:TextBox ID="txtProps" Width="300" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnGetProps" runat="server" Text="获取属性值对" OnClick="btnGetProps_Click" />
    </div>
    <div>
        <asp:Button ID="btnAddNoteBook" runat="server" Text="测试添加笔记本" OnClick="btnAddNoteBook_Click" />
        <asp:Button ID="btnAddNikeShoe" runat="server" Text="测试耐克运动鞋" OnClick="btnAddNikeShoe_Click" />
    </div>
    <div>
        <span>关键字</span><asp:TextBox ID="txtKey_Query_Product" Width="300" runat="server"></asp:TextBox>
        <br />
        <span>类目Id</span><asp:TextBox ID="txtCid_Query_Product" Width="120" runat="server"></asp:TextBox>
        <br />
        <span>属性组合</span><asp:TextBox ID="txtProps_Query_Product" Width="300" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnQueryProduct" runat="server" Text="查询产品列表" OnClick="btnQueryProduct_Click" />
        <asp:Button ID="btnGetProductById" runat="server" Text="根据Id获取产品" OnClick="btnGetProductById_Click" />
        <asp:Button ID="btnGetProductByProps" runat="server" Text="根据类目和属性获取产品" OnClick="btnGetProductByProps_Click" />
    </div>
    </form>
</body>
</html>
