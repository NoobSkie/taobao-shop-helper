<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemView.aspx.cs" EnableEventValidation="false"
    Inherits="TestTOP.ItemView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-family: 宋体; font-size: 12px;">
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblName" runat="server" Text="名称" Font-Size="X-Large" Font-Bold="true"></asp:Label>
        <hr />
        <div>
            <div style="float: left; margin-right: 12px;">
                <asp:Image ID="imgItemPic" runat="server" Width="311" Height="311" />
            </div>
            <div>
                <div style="margin-bottom: 8px;">
                    <asp:Label ID="lblPriceTitle" runat="server" Text="一口价" Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblPrice" runat="server" Text="230.00" ForeColor="#FF5500" Font-Size="Large"
                        Font-Bold="true"></asp:Label>
                    <span>元</span>
                </div>
                <div style="margin-bottom: 8px;">
                    <span style="font-weight: bold; width: 80px;">运费</span>
                    <asp:Label ID="lblFee" runat="server" Text="卖家承担运费"></asp:Label>
                </div>
                <div style="margin-bottom: 8px;">
                    <span style="font-weight: bold;">所在地区</span>
                    <asp:Label ID="lblLocation" runat="server" Text="重庆"></asp:Label>
                </div>
                <div style="margin-bottom: 8px;">
                    <span style="font-weight: bold;">宝贝类型</span>
                    <asp:Label ID="lblType" runat="server" Text="二手"></asp:Label>
                </div>
            </div>
        </div>
        <div style="clear: both;">
            <span style="font-weight: bold;">宝贝详情</span>
        </div>
        <div style="border: solid 1px gray; display: block; padding: 10px 10px 10px 10px;
            clear: both; height: 80px;">
            <asp:Repeater ID="rptProperties" runat="server">
                <ItemTemplate>
                    <div style="width: 200px; float: left; margin: 10px 10px 10px 10px;">
                        <span>
                            <%# Eval("PropertyName")%></span><span>:&nbsp;</span><span><%# Eval("Name")%></span>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div style="clear: both;">
            <asp:Label ID="lblDescription" runat="server" Text="描述"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
