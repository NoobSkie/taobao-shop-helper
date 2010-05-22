<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/ViewChase.aspx.cs" inherits="Home_Room_ViewChase" enableEventValidation="false" %>

<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我的购彩追号明细-我的购彩纪录-用户中心-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
    
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
       
        function mOver(obj, type) {
            if (type == 1) {
                obj.style.textDecoration = "underline";
                obj.style.color = "#FF0065";
            }
            else {
                obj.style.textDecoration = "none";
                obj.style.color = "#226699";


            }
        }
    </script>
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
         <div id="menu_right" style="margin-top:0px">
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
        <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
            <tr>
                <td width="20" height="29">
                    &nbsp;
                </td>
                <td width="100" align="center" background="images/admin_qh_100_2.jpg" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" style="cursor: pointer;" id="tdChase1" onclick="ClickMenu(1,2)">
                    我的追号
                </td>
               
                <td width="6">
                    &nbsp;
                </td>
                <td width="100" align="center" background="images/admin_qh_100_2.jpg" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" style="cursor: pointer;" id="tdChase2" onclick="ClickMenu(2,1)">
                    我的套餐
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td height="1" colspan="5" bgcolor="#FFFFFF">
                </td>
            </tr>
            <tr>
                <td height="2" colspan="5" bgcolor="#6699CC">
                </td>
            </tr>
        </table>
        <div id="divChase1" runat="server">
        <table id="myIcaileTab" runat="server" width="842" border="0" cellpadding="0" cellspacing="0"
            bgcolor="#DDDDDD" style="padding-left: 0px; padding-top: 0px; border-left: 1px solid #DDDDDD;
            border-right: 1px solid #DDDDDD;">
            <tr>
                <td height="30" colspan="10" align="left" bgcolor="#EEEEEE" style="padding: 5px 10px 5px 10px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="50%" class="black12">
                                起始日期：
                                <asp:TextBox ID="txtStartDate" runat="server" Text="" size="12"></asp:TextBox>
                                终止日期：
                                <asp:TextBox ID="txtEndDate" runat="server" Text="" size="12"></asp:TextBox>
                            </td>
                            <td width="50%">
                                <asp:Button runat="server" ID="btnGo" Text="查询" OnClick="btnGo_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:DataGrid ID="g1" runat="server" Width="842" BorderStyle="None" AllowPaging="True"
            PageSize="30" AutoGenerateColumns="False" CellPadding="0" BackColor="#DDDDDD"
            OnSortCommand="g1_SortCommand" Font-Names="Tahoma" OnItemDataBound="g1_ItemDataBound"
            CellSpacing="1" GridLines="None">
            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
            <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
                CssClass="blue12_2"></HeaderStyle>
            <AlternatingItemStyle BackColor="#F8F8F8" />
            <ItemStyle BackColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center"
                CssClass="black12" />
            <Columns>
                <asp:BoundColumn DataField="DateTime" HeaderText="发起时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                    <HeaderStyle HorizontalAlign="Center" Width="19%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="LotteryName" HeaderText="彩种">
                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Title" HeaderText="标题">
                    <HeaderStyle HorizontalAlign="Center" Width="14%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="SumMoney" HeaderText="总金额">
                    <HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="SumIsuseNum" HeaderText="总期数">
                    <HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="BuyedIsuseNum" HeaderText="完成期数">
                    <HeaderStyle HorizontalAlign="Center" Width="9%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="QuashedIsuseNum" HeaderText="取消期数">
                    <HeaderStyle HorizontalAlign="Center" Width="9%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="状态">
                    <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn Visible="False" DataField="id" HeaderText="id"></asp:BoundColumn>
            </Columns>
            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
            </PagerStyle>
        </asp:DataGrid>
        <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 15px;">
            <tr>
                <ShoveWebUI:ShoveGridPager ID="gPager1" runat="server" Width="798" PageSize="30" ShowSelectColumn="False"
                    DataGrid="g1" AlternatingRowColor="#F8F8F8" GridColor="#E0E0E0" HotColor="MistyRose"
                    Visible="False" OnPageWillChange="gPager1_PageWillChange" OnSortBefore="gPager1_SortBefore"
                    RowCursorStyle="" AllowShorting="true" />
            </tr>
        </table>
          <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 10px;">
            <tr>
                <td width="368" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    本页认购金额总计：
                    <asp:Label ID="lblPageBuyMoney" runat="server" Text="" CssClass="red12"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    认购金额总计：
                    <asp:Label ID="lblTotalBuyMoney" runat="server" Text="" CssClass="red12" />
                </td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="#FFFEDF" class="black12" style="padding: 5px 10px 5px 10px;">
                    <table>
                        <tr>
                            <td class="blue12">
                                说明：
                            </td>
                        </tr>
                        <tr>
                            <td>
                                1、您可以查询您的帐户在一段时间内的所有交易流水。
                            </td>
                        </tr>
                        <tr>
                            <td>
                                2、如有其他问题，请联系网站客服：<%= _Site.ServiceTelephone %>。
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </div>
        <div id="divChase2" runat="server" style="display:none">
             <table  width="842" border="0" cellpadding="0" cellspacing="0"
            bgcolor="#DDDDDD" style="padding-left: 0px; padding-top: 0px; border-left: 1px solid #DDDDDD;
            border-right: 1px solid #DDDDDD;">
            <tr>
                <td height="30" colspan="10" align="left" bgcolor="#EEEEEE" style="padding: 5px 10px 5px 10px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="black12" style="padding-left:50px">
                                追号标题：
                                <asp:TextBox ID="tbTitle" runat="server" Text="" size="12"></asp:TextBox>
                                
                             <asp:Button runat="server" ID="btnSearch" Text="查询"  OnClick="btnSearch_Click" />
                               
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
             <asp:DataGrid ID="g2" runat="server" Width="842" BorderStyle="None" AllowPaging="True"
            PageSize="30" AutoGenerateColumns="False" CellPadding="0" BackColor="#DDDDDD"
            OnSortCommand="g2_SortCommand" Font-Names="Tahoma" OnItemDataBound="g2_ItemDataBound"
            CellSpacing="1" GridLines="None">
            <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
            <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
            <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
                CssClass="blue12_2"></HeaderStyle>
            <AlternatingItemStyle BackColor="#F8F8F8" />
            <ItemStyle BackColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center"
                CssClass="black12" />
            <Columns>
                <asp:BoundColumn DataField="DateTime" HeaderText="发起时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                    <HeaderStyle HorizontalAlign="Center" Width="19%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Name" HeaderText="彩种">
                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                 <asp:BoundColumn DataField="Title" HeaderText="标题">
                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="SumMoney" HeaderText="总金额">
                    <HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="IsuseCount" HeaderText="总期数">
                    <HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ExecutedCount" HeaderText="已执行期数">
                    <HeaderStyle HorizontalAlign="Center" Width="9%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="NoExecutedCount" HeaderText="未执行期数">
                    <HeaderStyle HorizontalAlign="Center" Width="9%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="状态" DataField="QuashStatus">
                    <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn Visible="False" DataField="id" HeaderText="id"></asp:BoundColumn>
                <asp:BoundColumn Visible="False" DataField="Money"></asp:BoundColumn>
            </Columns>
            <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
            </PagerStyle>
        </asp:DataGrid>
        <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 15px;">
            <tr>
                <ShoveWebUI:ShoveGridPager ID="gPager2" runat="server" Width="798" PageSize="30" ShowSelectColumn="False"
                    DataGrid="g2" AlternatingRowColor="#F8F8F8" GridColor="#E0E0E0" HotColor="MistyRose"
                    Visible="False" OnPageWillChange="gPager2_PageWillChange" OnSortBefore="gPager2_SortBefore"
                    RowCursorStyle="" AllowShorting="true" />
            </tr>
        </table>
        <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 10px;">
            <tr>
                <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    套餐金额总计：
                    <asp:Label ID="lblTotalMoney" runat="server" Text="" CssClass="red12" />
                </td>
            </tr>
              <tr>
                <td colspan="2" bgcolor="#FFFEDF" class="black12" style="padding: 5px 10px 5px 10px;">
                    <table>
                        <tr>
                            <td class="blue12">
                                说明：
                            </td>
                        </tr>
                        <tr>
                            <td>
                                1、您可以查询您的帐户在一段时间内的所有交易流水。
                            </td>
                        </tr>
                        <tr>
                            <td>
                                2、如有其他问题，请联系网站客服：<%= _Site.ServiceTelephone %>。
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </div>
      
        </div> 
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    <asp:HiddenField ID="HidType" runat="server" Value="1" />
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
<script type="text/javascript">
    function ClickMenu(type1,type2) {
        document.getElementById("tdChase" + type1.toString()).background = "images/admin_qh_100_1.jpg";
        document.getElementById("tdChase" + type1.toString()).style.fontWeight = "bold";
        document.getElementById("divChase" + type1.toString()).style.display = "";
        
        document.getElementById("tdChase" + type2.toString()).background = "images/admin_qh_100_2.jpg";
        document.getElementById("tdChase" + type2.toString()).style.fontWeight = "normal";
        document.getElementById("divChase" + type2.toString()).style.display = "none";

        document.getElementById("HidType").value = type1;
    }

    var type = document.getElementById("HidType").value;
    if (type == "1") {
        ClickMenu(1, 2);
    } else {
    ClickMenu(2, 1);
    }
</script>
