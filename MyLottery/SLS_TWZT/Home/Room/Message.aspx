<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/Message.aspx.cs" inherits="Home_Room_Message" enableEventValidation="false" %>

<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的站内信-我的购彩纪录-用户中心-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc3:Lotteries ID="Lotteries1" runat="server" />
    <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 3px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
            <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                <tr>
                    <td width="40" height="30" align="right" valign="middle" class="red14">
                        <img src="images/icon_6.gif" width="19" height="16" />
                    </td>
                    <td valign="middle" class="red14" style="padding-left: 10px;">
                        我的彩票记录
                    </td>
                </tr>
            </table>
            <br />
            <table width="842" border="0" cellspacing="0" cellpadding="0" background="images/zfb_left_bg_2.jpg"
                style="margin-top: 10px;">
                <tr>
                    <td width="10" height="29" align="left">
                        &nbsp;
                    </td>
                    <td width="100" id="tdHistory" align="center" background="images/admin_qh_100_1.jpg"
                        style="cursor: pointer;font-weight:bold;" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)">
                        我的站内信
                    </td>
                    <td width="732">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <table width="842" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="1" colspan="9" bgcolor="#FFFFFF">
                    </td>
                </tr>
                <tr>
                    <td height="2" colspan="9" bgcolor="#6699CC">
                    </td>
                </tr>
            </table>
            <table id="myIcaileTab" runat="server" width="842" border="0" cellpadding="0" cellspacing="0"
                bgcolor="#DDDDDD">
                <tr>
                    <td valign="top" style="background-color: White;">
                        <asp:DataGrid ID="g1" runat="server" GridLines="None" CellPadding="2" BackColor="#DDDDDD"
                            BorderStyle="None" Width="100%" AutoGenerateColumns="False" 
                            CellSpacing="1" onitemcommand="g1_ItemCommand" 
                            onitemdatabound="g1_ItemDataBound">
                            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                            <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
                                CssClass="blue12_2"></HeaderStyle>
                            <AlternatingItemStyle BackColor="#F8F8F8" />
                            <ItemStyle BackColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center"
                                CssClass="black12" />
                            <Columns>
                                <asp:BoundColumn DataField="SourceUserName" HeaderText="发言人">
                                    <HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
                                    <ItemStyle Font-Bold="True" HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Content" HeaderText="内容">
                                    <HeaderStyle HorizontalAlign="Center" Width="40%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="是否已读取">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                    <asp:CheckBox ID="cbisRead" runat="server" Enabled="False" OnCheckedChanged="cbisRead_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                                </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="DateTime" HeaderText="发言时间">
                                    <HeaderStyle HorizontalAlign="Center" Width="18%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="删除">
                                    <HeaderStyle HorizontalAlign="Center" Width="17%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnDel" Text="删除" style="cursor: hand;" AlertText="确定要删除此条短消息吗？" Height="16px" CommandName="Del" ></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="btnView" Text="查看" style="cursor: hand;" Height="16px" CommandName="View" ></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="ID" Visible="false"></asp:BoundColumn>
                                <asp:BoundColumn DataField="isRead" Visible="false"></asp:BoundColumn>
                            </Columns>
                            <PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages">
                            </PagerStyle>
                        </asp:DataGrid>
                        <ShoveWebUI:ShoveGridPager ID="gPager1" runat="server" Width="100%" PageSize="20"
                            ShowSelectColumn="False" DataGrid="g1" AlternatingRowColor="#F8F8F8" GridColor="#E0E0E0"
                            HotColor="MistyRose" Visible="False" OnPageWillChange="gPager1_PageWillChange"
                            AllowShorting="False" RowCursorStyle="" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
