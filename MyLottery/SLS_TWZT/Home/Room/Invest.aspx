<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/Invest.aspx.cs" inherits="Home_Room_Invest" enableEventValidation="false" %>

<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register src="UserControls/UserMyIcaile.ascx" tagname="UserMyIcaile" tagprefix="uc2" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=_Site.Name %>中奖查询-我的购彩纪录-用户中心-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="JavaScript/Common.js" charset="GBK"></script>

    <script type="text/javascript" language="javascript">
        function ShowOrHiddenDiv(id) {
            var arrCells = new Array('tdHistory', 'tdReward');
            var divName = id.substring(3);
            for (var i = 0; i < arrCells.length; i++) {
                if (i == 0) {
                    divName = 'td' + divName;
                }
                if (arrCells[i] == divName) {
                    document.getElementById(arrCells[i]).style.fontWeight = "bold";
                }
                else {
                    document.getElementById(arrCells[i]).style.fontWeight = "normal";
                }
            }
            switch (id) {
                case 'divHistory':
                    divHistory.display = "block";
                    document.getElementById("hdCurDiv").value = "divHistory";
                    break;
                case 'divReward':
                    divReward.display = "none";
                    document.getElementById("hdCurDiv").value = "divReward";
            }
//            parent.document.getElementById("mainFrame").style.height = document.getElementById(id).scrollHeight + 120;
        }

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


        function showSameHeight() {
            if (document.getElementById("menu_left").clientHeight < document.getElementById("menu_right").clientHeight) {
                document.getElementById("menu_left").style.height = document.getElementById("menu_right").offsetHeight + "px";
            }
            else {
                if (document.getElementById("menu_right").offsetHeight >=960) {
                    document.getElementById("menu_left").style.height = document.getElementById("menu_right").offsetHeight + "px";
                }
                else {
                    document.getElementById("menu_left").style.height = "960px";
                }
            }
        }
    </script>
    <link rel="shortcut icon" href="../../favicon.ico" />
</head>
<body onload="showSameHeight();">
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
            <td width="100" id="tdHistory" align="center" background="images/admin_qh_100_2.jpg"
                onclick="clickTabMenu(this,'url(images/admin_qh_100_1.jpg)','myIcaileTab');ShowOrHiddenDiv('divHistory');"
                style="cursor: pointer;" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)">
                投注记录
            </td>
            <td width="6">
                &nbsp;
            </td>
            <td width="100" id="tdReward" align="center" background="images/admin_qh_100_2.jpg"
                onclick="clickTabMenu(this,'url(images/admin_qh_100_1.jpg)','myIcaileTab');ShowOrHiddenDiv('divReward');"
                style="cursor: pointer;" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)">
                中奖查询
            </td>
            <td width="6">
                &nbsp;
            </td>
            <td width="307" align="center" class="blue14">
                &nbsp;
            </td>
            <td width="307" class="black12">
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
            <td>
                &nbsp;
            </td>
            <td valign="top" style="background-color: White;">
                <div id="divHistory">
                    <table width="842" border="0" cellpadding="0" cellspacing="0" bgcolor="#DDDDDD" style="border-left: 1px solid #DDDDDD;
                        border-right: 1px solid #DDDDDD;">
                        <tr>
                            <td height="30" colspan="8" align="left" bgcolor="#F3F3F3" style="padding: 5px 10px 5px 2px;">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="100%" class="black12">
                                            <asp:DropDownList ID="ddlLottery" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLottery_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlPlayType" runat="server">
                                            </asp:DropDownList>
                                            <ShoveWebUI:ShoveConfirmButton ID="btnGo" BackgroupImage="../Room/images/button_chaxun.jpg"
                                                Style="cursor: hand" runat="server" Width="50px" BorderStyle="None" Height="22px"
                                                Font-Size="Smaller" OnClick="btnGo_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <asp:DataGrid ID="gHistory" runat="server" Width="842" BorderStyle="None" AllowPaging="True"
                        PageSize="30" AutoGenerateColumns="False" CellPadding="0" BackColor="#DDDDDD"
                        OnSortCommand="g_SortCommand" Font-Names="Tahoma" OnItemDataBound="gHistory_ItemDataBound"
                        CellSpacing="1" GridLines="None">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
                            CssClass="blue12_2"></HeaderStyle>
                        <AlternatingItemStyle BackColor="#F8F8F8" />
                        <ItemStyle BackColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center"
                            CssClass="black12" />
                        <Columns>
                            <asp:BoundColumn DataField="InitiateName" SortExpression="InitiateName" HeaderText="发起人">
                            </asp:BoundColumn>
                             <asp:BoundColumn DataField="LotteryName" SortExpression="LotteryName" HeaderText="彩种">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="PlayTypeName" SortExpression="PlayTypeName" HeaderText="玩法">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="SchemeShare" SortExpression="SchemeShare" HeaderText="方案份数">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Money" SortExpression="Money" HeaderText="方案金额"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Share" SortExpression="Share" HeaderText="认购份数"></asp:BoundColumn>
                            <asp:BoundColumn DataField="DetailMoney" SortExpression="DetailMoney" HeaderText="认购金额">
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="所占股份"></asp:BoundColumn>
                            <asp:BoundColumn DataField="SchemeWinMoney" SortExpression="WinMoney" HeaderText="方案奖金">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="WinMoneyNoWithTax" SortExpression="WinMoneyNoWithTax"
                                HeaderText="您的奖金"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="是否中奖"></asp:BoundColumn>
                           <%-- <asp:BoundColumn DataField="DateTime" SortExpression="DateTime" HeaderText="发起时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundColumn>--%>
                                 <asp:HyperLinkColumn DataNavigateUrlField="SchemeID" DataTextField="DateTime" 
                                DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="发起时间"  DataNavigateUrlFormatString="Scheme.aspx?id={0}"
                                 SortExpression="DateTime" Target="_blank" 
                                Visible="true"></asp:HyperLinkColumn>
                            <asp:BoundColumn HeaderText="状态"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="SchemeID" SortExpression="SchemeID" HeaderText="SchemeID">
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="QuashStatus" SortExpression="QuashStatus"
                                HeaderText="QuashedStatus"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="Buyed" SortExpression="Buyed" HeaderText="Buyed">
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="AssureMoney" SortExpression="AssureMoney"
                                HeaderText="AssureMoney"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="BuyedShare" SortExpression="BuyedShare"
                                HeaderText="BuyedShare"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="Memo" HeaderText="Memo">
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                        </PagerStyle>
                    </asp:DataGrid>
                    <ShoveWebUI:ShoveGridPager ID="gPagerHistory" runat="server" Width="842" PageSize="30"
                        ShowSelectColumn="False" DataGrid="gHistory" AlternatingRowColor="#F8F8F8" GridColor="#E0E0E0"
                        HotColor="MistyRose" Visible="False" OnPageWillChange="gPager_PageWillChange"
                        RowCursorStyle="" AllowShorting="true" />
                    <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 10px;">
                        <tr>
                            <td width="368" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                本页认购金额总计： <span class="red12">
                                    <asp:Label ID="lblPageBuySum" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                            <td width="407" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                认购金额总计： <span class="red12">
                                    <asp:Label ID="lblBuySum" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                本页方案奖金总计： <span class="red12">
                                    <asp:Label ID="lblPageSumWinMoney" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                方案奖金总计： <span class="red12">
                                    <asp:Label ID="lblSumWinMoney" runat="server" Text=""></asp:Label>
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
                </div>
            </td>
            <td>
                &nbsp;
            </td>
            <td valign="top" id="id1" style="background-color: White;">
                <div id="divReward">
                    <asp:DataGrid ID="gReward" runat="server" Width="842" BorderStyle="None" AllowPaging="True"
                        PageSize="30" AutoGenerateColumns="False" CellPadding="0" BackColor="#DDDDDD"
                        OnSortCommand="g_SortCommand" Font-Names="Tahoma" OnItemDataBound="gReward_ItemDataBound"
                        CellSpacing="1" GridLines="None">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
                            CssClass="blue12_2"></HeaderStyle>
                        <AlternatingItemStyle BackColor="#F8F8F8" />
                        <ItemStyle BackColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center"
                            CssClass="black12" />
                        <Columns>
                            <asp:BoundColumn DataField="LotteryName" SortExpression="LotteryName" HeaderText="彩种">
                                <HeaderStyle HorizontalAlign="Center" Width="14%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IsuseName" SortExpression="IsuseName" HeaderText="期号">
                                <HeaderStyle HorizontalAlign="Center" Width="14%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="LotteryNumber" SortExpression="LotteryNumber" HeaderText="投注内容">
                                <HeaderStyle HorizontalAlign="Center" Width="14%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DetailMoney" SortExpression="DetailMoney" HeaderText="投注金额">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="SchemeWinMoney" SortExpression="SchemeWinMoney" HeaderText="方案奖金">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="WinMoneyNoWithTax" SortExpression="WinMoneyNoWithTax"
                                HeaderText="我的奖金">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="WinMoneyNoWithTax" SortExpression="WinMoneyNoWithTax"
                                HeaderText="盈利指数">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="是否中奖">
                                <HeaderStyle HorizontalAlign="Center" Width="11%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="SchemeID" SortExpression="SchemeID" HeaderText="SchemeID">
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="Silver"
                            Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                    <ShoveWebUI:ShoveGridPager ID="gPager_Reward" runat="server" Width="842" PageSize="30"
                        ShowSelectColumn="False" DataGrid="gReward" AlternatingRowColor="#F8F8F8" GridColor="#E0E0E0"
                        HotColor="MistyRose" Visible="False" OnPageWillChange="gPager_PageWillChange"
                        RowCursorStyle="" AllowShorting="true" />
                    <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 10px;">
                        <tr>
                            <td width="385" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                奖金派发笔数： <span class="red12">
                                    <asp:Label ID="lblRewardCount" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                奖金派发收入合计： <span class="red12">
                                    <asp:Label ID="lblRewardMoney" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#FFFEDF" class="black12" style="padding: 5px 10px 5px 10px;">
                                <span class="blue12">说明：</span><br />
                                1、您可以查询您的帐户在一段时间内的所有交易流水。<br />
                                2、如果你已经充值，银行账户钱扣了，而您的账户还没有加上，请点击<span class="blue12_2">在线客服</span>告诉我们，我们将第一时间为您处理！<br />
                                3、如有其他问题，请联系网站客服：<%= _Site.ServiceTelephone %>。
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td width="6">
                &nbsp;
            </td>
            <td width="338" align="center" class="blue14">
                &nbsp;
            </td>
            <td width="168" class="black12">
                &nbsp;
            </td>
        </tr>
    </table>
    <%--<div>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9FC8EA">
            <tr>
                <td valign="top" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="images/bg_blue_30.jpg">
                        <tr>
                            <td height="30">
                                <table width="738" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="40" height="30" align="center">
                                            <img src="images/jiantou_5.gif" width="12" height="8" />
                                        </td>
                                        <td class="blue_num">
                                            本期彩票投注记录
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="5">
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9FC8EA">
                                    <tr>
                                        <td width="100%" height="31" colspan="10" background="images/bg_blue_31.jpg" bgcolor="#FFFFFF"
                                            style="padding-right: 10px; padding-left: 10px;">
                                            彩种：
                                            <asp:DropDownList ID="ddlLottery" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLottery_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlPlayType" runat="server">
                                            </asp:DropDownList>
                                            <ShoveWebUI:ShoveConfirmButton ID="btnGo" BackgroupImage="images/button_chaxun.jpg"
                                                Style="cursor: hand" runat="server" Width="50px" BorderStyle="None" Height="22px"
                                                Font-Size="Smaller" OnClick="btnGo_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <div style="padding-top: 10px; padding-bottom: 10px;">
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>--%>
    <input type="hidden" id="hdCurDiv" runat="server" value="divReward" />
      </div>
    </div> 
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>

    <script type="text/javascript">
        var curDiv = document.getElementById("hdCurDiv").value;
        switch (curDiv) {
            case 'divHistory':
                clickTabMenu(document.getElementById("tdHistory"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
            case 'divReward':
                clickTabMenu(document.getElementById("tdReward"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
            default:
                clickTabMenu(document.getElementById("tdHistory"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
        }
        ShowOrHiddenDiv(curDiv);
    </script>

    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
