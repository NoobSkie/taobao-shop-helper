<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommodityDiagram.aspx.cs"
    Inherits="CommodityDiagram" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店铺商品图表</title>
    <link href="App_Themes/Default/Styles/FindListStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="ComminuteLine_Diagram">
        <div class="Photo_Diagram">
            <asp:Image ID="Image1" runat="server" ImageUrl="App_Themes/Default/Images/T1u0BjXcYBqtPoLgYa_120952_jpg_sum.jpg" />
        </div>
        <div class="Summary_Diagram">
            <div class="SummaryTop_Diagram">
                <asp:Label ID="Label3" runat="server">【三件包邮】09韩版日系淑女款花朵休闲凉拖[X2828] </asp:Label>
            </div>
        </div>
        <div class="Price__Diagram">
            <div class="Text_Diagram">
                <asp:Label ID="Label1" runat="server" Text="Label">￥</asp:Label>
            </div>
            <div class="Number_Diagram">
                <asp:Label ID="Label2" runat="server" Text="Label">28.00元</asp:Label>
            </div>
        </div>
        <div class="Text_CommodityDiagram">
            <asp:Label ID="Label4" runat="server" Text="Label">已销售100件</asp:Label>
        </div>
        <div class="Text_CommodityDiagram">
            <asp:Label ID="Label5" runat="server" Text="Label">★★★★★(已有1000人评论)</asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
