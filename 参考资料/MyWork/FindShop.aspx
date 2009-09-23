<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FindShop.aspx.cs" Inherits="FindShop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询店铺</title>
    <link href="App_Themes/Default/Styles/FindListStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="ComminuteLine">
        <div class="Photo_Shop">
            <asp:Image ID="Image1" runat="server" ImageUrl="App_Themes/Default/Images/bc_shop_icon.png" />
        </div>
        <div class="Summary">
            <div class="SummaryTop">
                <asp:Label ID="Label1" runat="server">优衣库官方旗舰店</asp:Label>
            </div>
            <div class="SummaryBottom">
                <asp:Label ID="Label8" runat="server">主营宝贝：</asp:Label>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#">优衣库 uniqlo 女装 短袖 印花t恤 分袖</asp:HyperLink>
            </div>
        </div>
        <div class="Attribute">
            <div class="Legend_Shop">
                <div>
                    <asp:Label ID="Label4" runat="server">700</asp:Label>
                </div>
            </div>
            <div class="Price_Shop">
                <div class="Text_Shop">
                    <asp:Label ID="Label2" runat="server">优衣库官方旗舰店 </asp:Label>
                </div>
                <div class="Number_Shop">
                    <asp:Label ID="Label3" runat="server">和我联系</asp:Label>
                </div>
            </div>
            <div class="Place">
                <asp:Label ID="Label7" runat="server">重庆</asp:Label>
            </div>
            <div class="Price_Shop">
                <div class="Text_Shop">
                    <asp:Label ID="Label5" runat="server">旗舰店 </asp:Label>
                </div>
                <div class="Number_Shop">
                    <asp:Label ID="Label6" runat="server">店铺动态评分</asp:Label>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
