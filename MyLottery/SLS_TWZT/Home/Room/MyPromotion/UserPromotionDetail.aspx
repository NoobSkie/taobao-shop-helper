<%@ page language="C#" autoeventwireup="true" CodeFile="UserPromotionDetail.aspx.cs" inherits="Home_Room_MyPromotion_UserPromotionDetail" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:DataGrid ID="g" runat="server" Width="842" BorderStyle="None" AllowPaging="True"
            PageSize="30" AutoGenerateColumns="False" CellPadding="0" BackColor="#DDDDDD"
             Font-Names="Tahoma" 
            CellSpacing="1" GridLines="None">
            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
            <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
                CssClass="blue12_2"></HeaderStyle>
            <AlternatingItemStyle BackColor="#F8F8F8" />
            <ItemStyle BackColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center"
                CssClass="black12" />
            <Columns>
                <asp:BoundColumn DataField="IsuseName" HeaderText="期号">
                    <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:HyperLinkColumn DataNavigateUrlField="SchemeID" DataTextField="SchemeNumber" Target="_blank" 
                    HeaderText="方案号" DataNavigateUrlFormatString="../Scheme.aspx?id={0}">
                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                    <ItemStyle HorizontalAlign="Center"   CssClass="red12_2"/>
                </asp:HyperLinkColumn>
                <asp:BoundColumn DataField="LotteryName" HeaderText="彩种">
                    <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="PlayTypeName" HeaderText="方案类型">
                    <HeaderStyle HorizontalAlign="Center" Width="140px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Money" HeaderText="方案金额" DataFormatString="{0:N2}">
                    <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="right"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="DetailMoney" HeaderText="购买金额" DataFormatString="{0:N2}">
                    <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="right"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="DateTime" HeaderText="购买时间">
                    <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                
            </Columns>
            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
            </PagerStyle>
        </asp:DataGrid>
        <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="798" PageSize="30" ShowSelectColumn="False"
                    DataGrid="g" AlternatingRowColor="#F8F8F8" GridColor="#E0E0E0" HotColor="MistyRose"
                    Visible="False" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore"
                    RowCursorStyle="" AllowShorting="true" />
    </div>
   
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>

