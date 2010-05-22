<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/AccountFreezeDetail.aspx.cs" inherits="Home_Room_AccountFreezeDetail" enableEventValidation="false" %>

<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register src="UserControls/UserMyIcaile.ascx" tagname="UserMyIcaile" tagprefix="uc2" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我的购彩账户冻结明细-我的账户-用户中心-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
      <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
     <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 3px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
        <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
            <tr>
                <td width="40" height="30" align="right" valign="middle" class="red14">
                    <img src="images/icon_5.gif" width="19" height="20" />
                </td>
                <td valign="middle" class="red14" style="padding-left: 10px;">
                    我的账户
                </td>
            </tr>
        </table>
        <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
            <tr>
                <td width="20" height="29">
                    &nbsp;
                </td>
                <td width="100" align="center" background="images/admin_qh_100_1.jpg" class="blue12">
                    <a href="AccountFreezeDetail.aspx"><strong>冻结明细</strong></a>
                </td>
                <td width="4">
                    &nbsp;
                </td>
                <td width="6">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td height="1" colspan="11" bgcolor="#FFFFFF">
                </td>
            </tr>
            <tr>
                <td height="2" colspan="11" bgcolor="#6699CC">
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#9FC8EA">
            <tr>
                <td valign="top" bgcolor="#FFFFFF">
                    <asp:DataGrid ID="g" runat="server" Width="100%" BorderStyle="None" AllowSorting="True"
                        AllowPaging="True" PageSize="30" AutoGenerateColumns="False" CellPadding="2"
                        BackColor="#DDDDDD" Font-Names="Tahoma" CellSpacing="1" GridLines="None" OnSortCommand="g_SortCommand">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
                            CssClass="blue12_2"></HeaderStyle>
                        <AlternatingItemStyle BackColor="#F8F8F8" />
                        <ItemStyle BackColor="White" Height="21px" HorizontalAlign="Center"></ItemStyle>
                        <Columns>
                            <asp:BoundColumn DataField="DateTime" HeaderText="时间">
                                <HeaderStyle Width="20%"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Money" HeaderText="金额(元)">
                                <HeaderStyle Width="12%"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Memo" HeaderText="冻结原因">
                                <HeaderStyle Width="68%"></HeaderStyle>
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC" />
                    </asp:DataGrid>
                    <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="842" PageSize="10" ShowSelectColumn="False"
                        DataGrid="g" AlternatingRowColor="#F8F8F8" GridColor="#E0E0E0" HotColor="MistyRose"
                        OnPageWillChange="gPager_PageWillChange" RowCursorStyle="" AllowShorting="true" />
                    <table width="100%" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8"
                        style="margin-top: 10px;">
                        <tr>
                            <td width="368" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                本页冻结笔数： <span class="red12">
                                    <asp:Label ID="lblPageFreezeCount" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                            <td width="407" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                总冻结笔数： <span class="red12">
                                    <asp:Label ID="lblTotalFreezeCount" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                本页冻结资金： <span class="red12">
                                    <asp:Label ID="lblPageFreezeSum" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                总冻结资金： <span class="red12">
                                    <asp:Label ID="lblTotalFreezeSum" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" bgcolor="#FFFEDF" class="black12" style="padding: 5px 10px 5px 10px;">
                                <span class="blue12">说明：</span><br />
                                1、您可以查询您的帐户在一段时间内的所有交易流水。<br />
                                2、如有其他问题，请联系网站客服：<%= _Site.ServiceTelephone %>。
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
      </div> 
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
