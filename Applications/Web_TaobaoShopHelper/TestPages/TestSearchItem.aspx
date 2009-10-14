<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSearchItem.aspx.cs"
    EnableEventValidation="false" Inherits="TOP.Applications.TaobaoShopHelper.TestPages.TestSearchItem" %>

<%@ Register Src="~/WebControls/Search/CtrlSearchButton_Multi.ascx" TagName="CtrlSearchButton_Multi"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:CtrlSearchButton_Multi ID="CtrlSearchButton_Multi1" SearchWinType="Multi_MyItems"
            Text="多选我的商品" runat="server" />
    </div>
    </form>
</body>
</html>
