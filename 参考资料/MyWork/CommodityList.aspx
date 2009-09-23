<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommodityList.aspx.cs" Inherits="CommodityList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店铺商品列表</title>
    <link href="App_Themes/Default/Styles/FindListStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="ComminuteLine">
            <div class="Photo">
                <asp:Image ID="Image1" runat="server" ImageUrl="App_Themes/Default/Images/T1u0BjXcYBqtPoLgYa_120952_jpg_sum.jpg" />
            </div>
            <div class="Summary">
                <div class="SummaryTop">
                    <asp:Label ID="Label1" runat="server">【三件包邮】夏季韩版新品抢先报夹脚楔型毛巾凉鞋[XA010S] </asp:Label>
                </div>
            </div>
            <div class="Attribute_Commodity">
                <div class="Text_Commodity">
                    <asp:Label ID="Label5" runat="server">￥43.00 </asp:Label>
                </div>
                <div class="Text_Commodity">
                    <asp:Label ID="Label6" runat="server">已销售300件</asp:Label>
                </div>
                <div class="Text_Commodity">
                    <asp:Label ID="Label2" runat="server">★★★★★(已有100人评论)</asp:Label>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
