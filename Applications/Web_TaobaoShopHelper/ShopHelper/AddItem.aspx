<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.ShopHelper.AddItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <span>宝贝名称</span><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        </div>
        <div>
            <span>新旧程度</span><asp:TextBox ID="txtStatus" runat="server">new</asp:TextBox>
        </div>
        <div>
            <span>商品数量</span><asp:TextBox ID="txtNum" runat="server">1</asp:TextBox>
        </div>
        <div>
            <span>价格</span><asp:TextBox ID="txtPrice" runat="server">1</asp:TextBox>
        </div>
        <div>
            <span>出价方式</span><asp:TextBox ID="txtType" runat="server">fixed</asp:TextBox>
        </div>
        <div>
            <span>省份</span>
            <asp:DropDownList ID="ddlProvince" runat="server" DataTextField="AreaName" DataValueField="AreaId" AutoPostBack="true"
                OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div>
            <span>城市</span>
            <asp:DropDownList ID="ddlCity" runat="server" DataTextField="AreaName" DataValueField="AreaId">
            </asp:DropDownList>
        </div>
        <div>
            <span>类目</span><asp:TextBox ID="txtCid" runat="server"></asp:TextBox>
        </div>
        <div>
            <span>描述</span><asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        </div>
    </div>
    <div>
        <asp:Button ID="btnSave" runat="server" Text="添加宝贝" OnClick="btnSave_Click" />
    </div>
    </form>
</body>
</html>
