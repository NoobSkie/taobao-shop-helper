<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/AccountDetail.aspx.cs" inherits="Home_Room_AccountDetail" enableEventValidation="false" %>

<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register src="UserControls/UserMyIcaile.ascx" tagname="UserMyIcaile" tagprefix="uc2" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我的购彩账户交易明细-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
        function ShowOrHiddenDiv(id) {

            var arrCells = new Array('tdBuy', 'tdAccountDetail', 'tdReward', 'tdUserPay', 'tdUserDistills', 'tdScoring');
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
                case 'divAccountDetail':
                    divAccountDetail.display = "block";
                    divBuy.display = "none";
                    divReward.display = "none";
                    divUserPay.display = "none";
                    divUserDistills.display = "none";
                    divScoring.display = "none";
                    document.getElementById("hdCurDiv").value = "divAccountDetail";
                    break;
                case 'divBuy':
                    divBuy.display = "block";
                    divAccountDetail.display = "none";
                    divReward.display = "none";
                    divUserPay.display = "none";
                    divUserDistills.display = "none";
                    divScoring.display = "none";
                    document.getElementById("hdCurDiv").value = "divBuy";
                    break;
                case 'divReward':
                    divReward.display = "block";
                    divAccountDetail.display = "none";
                    divBuy.display = "none";
                    divUserPay.display = "none";
                    divUserDistills.display = "none";
                    divScoring.display = "none";
                    document.getElementById("hdCurDiv").value = "divReward";
                    break;
                case 'divUserPay':
                    divUserPay.display = "block";
                    divAccountDetail.display = "none";
                    divBuy.display = "none";
                    divReward.display = "none";
                    divUserDistills.display = "none";
                    divScoring.display = "none";
                    document.getElementById("hdCurDiv").value = "divUserPay";
                    break;
                case 'divUserDistills':
                    divUserDistills.display = "block";
                    divUserPay.display = "none";
                    divAccountDetail.display = "none";
                    divBuy.display = "none";
                    divReward.display = "none";
                    divScoring.display = "none";
                    document.getElementById("hdCurDiv").value = "divUserDistills";
                    break;
                case 'divScoring':
                    divScoring.display = "block";
                    divAccountDetail.display = "none";
                    divBuy.display = "none";
                    divReward.display = "none";
                    divUserPay.display = "none";
                    divUserDistills.display = "none";
                    document.getElementById("hdCurDiv").value = "divScoring";
                    break;
            }
        }

        //提款之后判断
        function AfterDistill() {
            var location = window.location.toString();
            if (location.indexOf("?isAfterDistill=") == -1) {

                return false;
            }
            clickTabMenu(document.getElementById("tdUserDistills"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
            ShowOrHiddenDiv('divUserDistills');

        }
        //隐藏tbody
        function HideDetail() {
            document.getElementById("isShowDistill").style.display = "none";
            document.getElementById("isShowUserPay").style.display = "none";
        }

        function showSameHeight() {
            if (document.getElementById("menu_left").clientHeight < document.getElementById("menu_right").clientHeight) {
                document.getElementById("menu_left").style.height = document.getElementById("menu_right").offsetHeight + "px";
            }
            else {
                if (document.getElementById("menu_right").offsetHeight >= 860) {
                    document.getElementById("menu_left").style.height = document.getElementById("menu_right").offsetHeight + "px";
                }
                else {
                    document.getElementById("menu_left").style.height = "860px";
                }
            }
        }
    </script>
    <link rel="shortcut icon" href="../../favicon.ico" />
</head>
<body onload="return AfterDistill();showSameHeight() ;">
    <form id="form1" runat="server">
    
     <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
     <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 3px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
    <table width="842" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="40" height="30" align="right" valign="middle" class="red14">
                <img src="images/icon_5.gif" width="19" height="20" />
            </td>
            <td valign="middle" class="red14" style="padding-left: 10px;">
                我的账户
            </td>
            <td width="11">
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="842" border="0" cellspacing="0" cellpadding="0" background="images/zfb_left_bg_2.jpg"
        style="margin-top: 10px;">
        <tr>
            <td width="20" height="29" align="left">
                &nbsp;
            </td>
             <td width="100" id="tdBuy" onclick="clickTabMenu(this,'url(images/admin_qh_100_1.jpg)','myIcaileTab');ShowOrHiddenDiv('divBuy');HideDetail();"
                onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" align="center" background="images/admin_qh_100_2.jpg"
                class="blue12" style="cursor: pointer;">
                购彩记录
            </td>
            
            <td width="6">
                &nbsp;
            </td>
           <td width="100" id="tdAccountDetail" align="center" background="images/admin_qh_100_2.jpg"
                onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="blue12" onclick="clickTabMenu(this,'url(images/admin_qh_100_1.jpg)','myIcaileTab');ShowOrHiddenDiv('divAccountDetail');HideDetail();"
                style="cursor: pointer;">
                账户明细
            </td>
            <td width="6">
                &nbsp;
            </td>
            <td width="100" id="tdReward" onclick="clickTabMenu(this,'url(images/admin_qh_100_1.jpg)','myIcaileTab');ShowOrHiddenDiv('divReward');HideDetail();"
                onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" align="center" background="images/admin_qh_100_2.jpg"
                class="blue12" style="cursor: pointer;">
                奖金派发
            </td>
            <td width="6">
                &nbsp;
            </td>
            <td width="100" id="tdUserPay" onclick="clickTabMenu(this,'url(images/admin_qh_100_1.jpg)','myIcaileTab');ShowOrHiddenDiv('divUserPay');HideDetail();"
                onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" align="center" background="images/admin_qh_100_2.jpg"
                class="blue12" style="cursor: pointer;">
                充值记录
            </td>
            <td width="5">
                &nbsp;
            </td>
            <td width="100" id="tdUserDistills" onclick="clickTabMenu(this,'url(images/admin_qh_100_1.jpg)','myIcaileTab');ShowOrHiddenDiv('divUserDistills');HideDetail();"
                onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" align="center" background="images/admin_qh_100_2.jpg"
                class="blue12" style="cursor: pointer;">
                提款记录
            </td>
            <td width="5">
                &nbsp;
            </td>
            <td width="100" id="tdScoring" onclick="clickTabMenu(this,'url(images/admin_qh_100_1.jpg)','myIcaileTab');ShowOrHiddenDiv('divScoring');HideDetail();"
                onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" align="center" background="images/admin_qh_100_2.jpg"
                class="blue12" style="cursor: pointer;">
                积分明细
            </td>
            <td>
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
    <table id="myIcaileTab" runat="server" width="776" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
            <td id="Td1" valign="top" runat="server" style="background-color: White;">
             <div id="divBuy">
                    <asp:DataGrid ID="gHistory" runat="server" Width="842px" BorderStyle="None" AllowPaging="True"
                        PageSize="30" AutoGenerateColumns="False" CellPadding="0" BackColor="#DDDDDD"
                        Font-Names="Tahoma" OnItemDataBound="gHistory_ItemDataBound" CellSpacing="1"
                        GridLines="None" AllowSorting="True" OnSortCommand="g_SortCommand" 
                        BorderColor="#E0E0E0" BorderWidth="2px">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
                            CssClass="blue12_2" VerticalAlign="Middle"></HeaderStyle>
                        <ItemStyle BorderStyle="None" Height="30px" HorizontalAlign="Center"
                            CssClass="black12" />
                        <Columns>
                            <asp:BoundColumn SortExpression="InitiateName" DataField="InitiateName" HeaderText="发起人">
                            </asp:BoundColumn>
                             <asp:BoundColumn SortExpression="LotteryName" DataField="LotteryName" HeaderText="彩种">
                            </asp:BoundColumn>
                            <asp:BoundColumn SortExpression="PlayTypeName" DataField="PlayTypeName" HeaderText="玩法">
                            </asp:BoundColumn>
                            <asp:BoundColumn SortExpression="SchemeShare" DataField="SchemeShare" HeaderText="方案份数">
                            </asp:BoundColumn>
                            <asp:BoundColumn SortExpression="Money" DataField="Money" HeaderText="方案金额"></asp:BoundColumn>
                            <asp:BoundColumn SortExpression="Share" DataField="Share" HeaderText="认购份数"></asp:BoundColumn>
                            <asp:BoundColumn SortExpression="DetailMoney" DataField="DetailMoney" HeaderText="认购金额">
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="所占股份"></asp:BoundColumn>
                            <asp:BoundColumn SortExpression="SchemeWinMoney" DataField="SchemeWinMoney" HeaderText="方案奖金">
                            </asp:BoundColumn>
                            <asp:BoundColumn SortExpression="WinMoneyNoWithTax" DataField="WinMoneyNoWithTax"
                                HeaderText="您的奖金"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="是否中奖"></asp:BoundColumn>
                        <%--    <asp:BoundColumn SortExpression="DateTime" DataField="DateTime" HeaderText="发起时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundColumn>--%>
                                
                                 <asp:HyperLinkColumn DataNavigateUrlField="SchemeID" DataTextField="DateTime" 
                                DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="发起时间"  DataNavigateUrlFormatString="Scheme.aspx?id={0}"
                                 SortExpression="DateTime" Target="_blank" 
                                Visible="true"></asp:HyperLinkColumn>
                            <asp:BoundColumn HeaderText="状态"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="SchemeID" HeaderText="SchemeID"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="QuashStatus" HeaderText="QuashedStatus">
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="Buyed" HeaderText="Buyed"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="AssureMoney" HeaderText="AssureMoney">
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="BuyedShare" HeaderText="BuyedShare">
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="Memo" HeaderText="Memo">
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                        </PagerStyle>
                    </asp:DataGrid>
                    <ShoveWebUI:ShoveGridPager ID="gPagerHistory" runat="server" Width="842" PageSize="30"
                        ShowSelectColumn="False" DataGrid="gHistory" AlternatingRowColor="#F8F8F8" GridColor="#E0E0E0"
                        HotColor="MistyRose" RowCursorStyle="" OnPageWillChange="gPager_PageWillChange"
                        AllowShorting="true" />
                    <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 10px;">
                        <tr>
                            <td width="385" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                支出交易笔数： <span class="red12">
                                    <asp:Label ID="lblBuyOutCount" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                支出金额合计： <span class="red12">
                                    <asp:Label ID="lblBuyOutMoney" runat="server" Text=""></asp:Label>
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
            <td>
                &nbsp;
            </td>
            <td id="Td2" valign="top" runat="server">
                  <div id="divAccountDetail">
                    <table width="842" border="0" cellpadding="0" cellspacing="0" style="border-left: 1px solid #C0DBF9;
                        border-right: 1px solid #C0DBF9;">
                        <tr>
                            <td height="30" colspan="8" align="left" bgcolor="#F3F3F3" style="padding: 5px 10px 5px 2px;">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="black12">
                                            开始时间：
                                            <asp:DropDownList ID="ddlYear" runat="server">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                                <asp:ListItem Value="1">1 月</asp:ListItem>
                                                <asp:ListItem Value="2">2 月</asp:ListItem>
                                                <asp:ListItem Value="3">3 月</asp:ListItem>
                                                <asp:ListItem Value="4">4 月</asp:ListItem>
                                                <asp:ListItem Value="5">5 月</asp:ListItem>
                                                <asp:ListItem Value="6">6 月</asp:ListItem>
                                                <asp:ListItem Value="7">7 月</asp:ListItem>
                                                <asp:ListItem Value="8">8 月</asp:ListItem>
                                                <asp:ListItem Value="9">9 月</asp:ListItem>
                                                <asp:ListItem Value="10">10月</asp:ListItem>
                                                <asp:ListItem Value="11">11月</asp:ListItem>
                                                <asp:ListItem Value="12">12月</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlDay" runat="server">
                                            </asp:DropDownList>
                                            结束时间：
                                            <asp:DropDownList ID="ddlYear1" runat="server">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlMonth1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                                <asp:ListItem Value="1">1 月</asp:ListItem>
                                                <asp:ListItem Value="2">2 月</asp:ListItem>
                                                <asp:ListItem Value="3">3 月</asp:ListItem>
                                                <asp:ListItem Value="4">4 月</asp:ListItem>
                                                <asp:ListItem Value="5">5 月</asp:ListItem>
                                                <asp:ListItem Value="6">6 月</asp:ListItem>
                                                <asp:ListItem Value="7">7 月</asp:ListItem>
                                                <asp:ListItem Value="8">8 月</asp:ListItem>
                                                <asp:ListItem Value="9">9 月</asp:ListItem>
                                                <asp:ListItem Value="10">10月</asp:ListItem>
                                                <asp:ListItem Value="11">11月</asp:ListItem>
                                                <asp:ListItem Value="12">12月</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlDay1" runat="server">
                                            </asp:DropDownList>
                                            <ShoveWebUI:ShoveConfirmButton ID="btnGO" runat="server" Width="50px" Height="22px"
                                                OnClick="btnGO_Click" Text="查询" Style="cursor: pointer;" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <asp:DataGrid ID="g" runat="server" Width="842" BorderStyle="None" AllowPaging="True"
                        PageSize="30" AutoGenerateColumns="False" CellPadding="0" BackColor="#DDDDDD"
                        Font-Names="Tahoma" OnItemDataBound="g_ItemDataBound" CellSpacing="1" GridLines="None"
                        OnSortCommand="g_SortCommand">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
                            CssClass="blue12_2"></HeaderStyle>
                        <ItemStyle BackColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center"
                            CssClass="black12" />
                        <Columns>
                            <asp:BoundColumn DataField="DateTime" SortExpression="DateTime" HeaderText="交易时间">
                                <ItemStyle Width="17%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Memo" SortExpression="Memo" HeaderText="摘要">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="MoneyAdd" SortExpression="MoneyAdd" HeaderText="收入(元)">
                                <ItemStyle Width="8%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="MoneySub" SortExpression="MoneySub" HeaderText="支出(元)">
                                <ItemStyle Width="8%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="FormalitiesFees" SortExpression="FormalitiesFees" HeaderText="(手续费)">
                                <ItemStyle Width="8%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Balance" SortExpression="Balance" HeaderText="余额">
                                <ItemStyle Width="8%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Reward" SortExpression="Reward" HeaderText="中奖金额">
                                <ItemStyle Width="8%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="SumReward" SortExpression="SumReward" HeaderText="中奖总金额">
                                <ItemStyle Width="8%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="SchemeID" HeaderText="SchemeID"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                        </PagerStyle>
                    </asp:DataGrid>
                    <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="842" PageSize="30" ShowSelectColumn="False"
                        DataGrid="g" AlternatingRowColor="#F8F8F8" HotColor="MistyRose" OnPageWillChange="gPager_PageWillChange"
                        Visible="False" RowCursorStyle="" />
                    <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 10px;">
                        <tr>
                            <td width="385" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                支出交易笔数： <span class="red12">
                                    <asp:Label ID="lblOutCount" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                            <td width="390" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                收入交易笔数： <span class="red12">
                                    <asp:Label ID="lblInCount" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                支出金额合计： <span class="red12">
                                    <asp:Label ID="lblOutMoney" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                收入金额合计： <span class="red12">
                                    <asp:Label ID="lblInMoney" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" bgcolor="#FFFEDF" class="black12" style="padding: 5px 10px 5px 10px;">
                                <span class="blue12">说明：</span><br />
                                1、您可以查询您的帐户在一段时间内的所有交易流水。<br />
                                2、如果你已经充值，银行账户钱扣了，而您的账户还没有加上，请点击<a style="color: Red;" href="javascript:;"><span
                                        class="blue12_2">在线客服</span></a>告诉我们，我们将第一时间为您处理！<br />
                                3、如有其他问题，请联系网站客服：<%= _Site.ServiceTelephone %>。
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                &nbsp;
            </td>
            <td id="Td3" valign="top" runat="server">
                <div id="divReward">
                    <asp:DataGrid ID="gReward" runat="server" Width="842" BorderStyle="None" AllowPaging="True"
                        PageSize="30" AutoGenerateColumns="False" CellPadding="0" BackColor="#dddddd"
                        Font-Names="Tahoma" OnItemDataBound="gReward_ItemDataBound" CellSpacing="1" GridLines="None"
                        OnSortCommand="g_SortCommand">
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
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="SchemeID" SortExpression="SchemeID" HeaderText="SchemeID">
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="Silver"
                            Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                    <ShoveWebUI:ShoveGridPager ID="gPagerReward" runat="server" Width="842" PageSize="30"
                        ShowSelectColumn="False" DataGrid="gReward" AlternatingRowColor="#F8F8F8" GridColor="#E0E0E0"
                        HotColor="MistyRose" OnPageWillChange="gPager_PageWillChange" AllowShorting="true"
                        RowCursorStyle="" />
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
            <td>
                &nbsp;
            </td>
            <td id="Td4" valign="top" runat="server">
                <div id="divUserPay">
                    <asp:DataGrid ID="gUserPay" runat="server" Width="842" BorderStyle="None" AllowSorting="True"
                        AllowPaging="True" PageSize="8" AutoGenerateColumns="False" CellPadding="0"
                        OnSortCommand="g_SortCommand" BackColor="#DDDDDD" Font-Names="Tahoma" OnItemDataBound="gUserPay_ItemDataBound"
                        CellSpacing="1" GridLines="None" OnItemCommand="gUserPay_ItemCommand">
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
                            CssClass="blue12_2"></HeaderStyle>
                        <AlternatingItemStyle BackColor="#F8F8F8" />
                        <ItemStyle BackColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center"
                            CssClass="black12" />
                        <Columns>
                            <asp:TemplateColumn HeaderText="订单号">
                                <ItemStyle Width="30%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnUserPayDetail" runat="server" CommandName="ShowUserPayDetail"
                                        ForeColor="#0066BA" Font-Underline="True"><%#Eval("ID").ToString()%></asp:LinkButton>
                                    <asp:HiddenField ID="tdUserPayDetail" runat="server" Value='<%#Eval("ID").ToString()%>' />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="Money" HeaderText="收入(元)">
                                <ItemStyle Width="20%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="FormalitiesFees" HeaderText="(手续费)">
                                <ItemStyle Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="PayType" HeaderText="交易类型">
                                <ItemStyle Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DateTime" HeaderText="交易时间">
                                <ItemStyle Width="30%" />
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                        </PagerStyle>
                    </asp:DataGrid>
                    <ShoveWebUI:ShoveGridPager ID="gPagerUserPay" runat="server" Width="842" PageSize="8"
                        ShowSelectColumn="False" DataGrid="gUserPay" AlternatingRowColor="#F8F8F8" GridColor="#E0E0E0"
                        HotColor="MistyRose" OnPageWillChange="gPager_PageWillChange" AllowShorting="true"
                        RowCursorStyle="" />
                    <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 10px;">
                         <tbody id="isShowUserPay" runat="server">
                            <tr>
                                <td width="385" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                    充值金额： <span class="red12">
                                        <asp:Label ID="lblUserPayMoneys" runat="server" Text=""></asp:Label>
                                    </span>
                                </td>
                                <td width="385" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                    充值时间： <span class="red12">
                                        <asp:Label ID="lblUserPayTime" runat="server" Text=""></asp:Label>
                                    </span>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;" colspan="2" >
                                    充值方式： <span class="red12">
                                        <asp:Label ID="lblUserPayBank" runat="server" Text=""></asp:Label>
                                    </span>
                                </td>
                            </tr>
                        </tbody>
                        <tr>
                            <td width="385" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;"
                                colspan="2">
                                充值次数： <span class="red12">
                                    <asp:Label ID="lblUserPayCount" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;" colspan="2">
                                充值金额合计： <span class="red12">
                                    <asp:Label ID="lblUserPayMoney" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#FFFEDF" class="black12" style="padding: 5px 10px 5px 10px;" colspan="2">
                                <span class="blue12">说明：</span><br />
                                1、您可以查询您的帐户在一段时间内的所有交易流水。<br />
                                2、如果你已经充值，银行账户钱扣了，而您的账户还没有加上，请点击<span class="blue12_2">在线客服</span>告诉我们，我们将第一时间为您处理！<br />
                                3、如有其他问题，请联系网站客服：<%= _Site.ServiceTelephone %>。
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                &nbsp;
            </td>
            <td id="Td5" valign="top" runat="server">
                <div id="divUserDistills">
                    <asp:DataGrid ID="gUserDistills" runat="server" Width="842" BorderStyle="None" AllowSorting="True"
                        AllowPaging="True" PageSize="8" AutoGenerateColumns="False" CellPadding="0"
                        OnSortCommand="g_SortCommand" BackColor="#DDDDDD" Font-Names="Tahoma" OnItemDataBound="gUserDistills_ItemDataBound"
                        CellSpacing="1" GridLines="None" OnItemCommand="gUserDistills_ItemCommand">
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
                            CssClass="blue12_2"></HeaderStyle>
                        <AlternatingItemStyle BackColor="#F8F8F8" />
                        <ItemStyle BackColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center"
                            CssClass="black12" />
                        <Columns>
                            <asp:TemplateColumn HeaderText="订单号">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDistillDetail" runat="server" CommandName="ShowDistillDetail"
                                        ForeColor="#0066BA" Font-Underline="True"><%#Eval("ID").ToString()%></asp:LinkButton>
                                    <asp:HiddenField ID="tdDistillID" runat="server" Value='<%#Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="Money" HeaderText="支出(元)">
                                <ItemStyle Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="FormalitiesFees" HeaderText="(手续费)">
                                <ItemStyle Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="交易类型">
                                <ItemStyle Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Result" HeaderText="状态">
                                <ItemStyle Width="10%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="操作">
                                <ItemStyle Width="10%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnModified" runat="server" ForeColor="#0066BA" Font-Underline="True"
                                        CommandName="QuashDistills" Visible='<%# Eval("Result").ToString() == "0" ? true : false %>'>撤销提款</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="Memo" HeaderText="备注">
                                <ItemStyle Width="25%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DateTime" HeaderText="交易时间">
                                <ItemStyle Width="15%" />
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                        </PagerStyle>
                    </asp:DataGrid>
                    <ShoveWebUI:ShoveGridPager ID="gPagergDistills" runat="server" Width="842" PageSize="8"
                        ShowSelectColumn="False" DataGrid="gUserDistills" AlternatingRowColor="#F8F8F8"
                        GridColor="#E0E0E0" HotColor="MistyRose" OnPageWillChange="gPager_PageWillChange"
                        AllowShorting="true" RowCursorStyle="" />
                    <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 10px;">
                        <tbody id="isShowDistill" runat="server">
                            <tr>
                                <td width="385" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                    提款类型： <span class="red12">
                                        <asp:Label ID="lblDistillBankType" runat="server" Text=""></asp:Label>
                                    </span>
                                </td>
                                <td width="385" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                    提款时间： <span class="red12">
                                        <asp:Label ID="lblDistillTime" runat="server" Text=""></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                    <asp:Label ID="lblDistillBanks" runat="server" Text=""></asp:Label>
                                    <span class="red12">
                                        <asp:Label ID="lblDistillBankDetail" runat="server" Text=""></asp:Label>
                                    </span>
                                </td>
                                <td width="385" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                    <asp:Label ID="lbAccountBankDetail" runat="server" Visible="false" Text="开户银行："></asp:Label>
                                    <span class="red12">
                                   <asp:Label ID="lbAccountBank" runat="server" Text="" Visible="false"></asp:Label>
                                   </span>
                                </td>
                            </tr>
                        </tbody>
                        <tr>
                            <td width="385" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;"
                                colspan="2">
                                提款交易笔数： <span class="red12">
                                    <asp:Label ID="lblDistillCount" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;" colspan="2">
                                提款金额合计： <span class="red12">
                                    <asp:Label ID="lblDistillMoney" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#FFFEDF" class="black12" style="padding: 5px 10px 5px 10px;" colspan="2">
                                <span class="blue12">说明：</span><br />
                                1、您可以查询您的帐户在一段时间内的所有交易流水。<br />
                                2、如果你已经充值，银行账户钱扣了，而您的账户还没有加上，请点击<span class="blue12_2">在线客服</span>告诉我们，我们将第一时间为您处理！<br />
                                3、如有其他问题，请联系网站客服：<%= _Site.ServiceTelephone %>。
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                &nbsp;
            </td>
            <td valign="top" id="td6" runat="server">
                <div id="divScoring">
                    <asp:DataGrid ID="gScoring" runat="server" Width="842" BorderStyle="None" AllowSorting="True"
                        AllowPaging="True" PageSize="30" AutoGenerateColumns="False" CellPadding="0"
                        OnSortCommand="g_SortCommand" BackColor="#DDDDDD" Font-Names="Tahoma" OnItemDataBound="gScoring_ItemDataBound"
                        CellSpacing="1" GridLines="None">
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
                            CssClass="blue12_2"></HeaderStyle>
                        <AlternatingItemStyle BackColor="#F8F8F8" />
                        <ItemStyle BackColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center"
                            CssClass="black12" />
                        <Columns>
                            <asp:BoundColumn DataField="ID" HeaderText="订单号">
                                <ItemStyle Width="17%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Scoring" HeaderText="收入">
                                <ItemStyle Width="9%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="支出">
                                <ItemStyle Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="OperatorType" HeaderText="交易类型">
                                <ItemStyle Width="11%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DateTime" HeaderText="交易时间">
                                <ItemStyle Width="17%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Scoring" HeaderText="积分">
                                <ItemStyle Width="17%" />
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                        </PagerStyle>
                    </asp:DataGrid>
                    <ShoveWebUI:ShoveGridPager ID="gPagerScoring" runat="server" Width="842" PageSize="30"
                        ShowSelectColumn="False" DataGrid="gScoring" AlternatingRowColor="#F8F8F8" GridColor="#E0E0E0"
                        HotColor="MistyRose" OnPageWillChange="gPager_PageWillChange" AllowShorting="true"
                        RowCursorStyle="" />
                    <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 10px;">
                        <tr>
                            <td width="368" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                支出交易笔数： <span class="red12">
                                    <asp:Label ID="lblScoreOutCount" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                            <td width="407" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                收入交易笔数： <span class="red12">
                                    <asp:Label ID="lblScoreInCount" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                支出积分合计： <span class="red12">
                                    <asp:Label ID="lblScoreOutMoney" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                收入积分总计： <span class="red12">
                                    <asp:Label ID="lblScoreInMoney" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" bgcolor="#FFFEDF" class="black12" style="padding: 5px 10px 5px 10px;">
                                <span class="blue12">说明：</span><br />
                                1、您可以查询您的帐户在一段时间内的所有交易流水。<br />
                                2、如果你已经充值，银行账户钱扣了，而您的账户还没有加上，请点击<span class="blue12_2">在线客服</span>告诉我们，我们将第一时间为您处理！<br />
                                3、如有其他问题，请联系网站客服：<%= _Site.ServiceTelephone %>。
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <input type="hidden" id="hdCurDiv" runat="server" value="divBuy" />
    </div>
    </div> 
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>

    <script type="text/javascript">
        var curDiv = document.getElementById("hdCurDiv").value;
        switch (curDiv) {
            case 'divBuy':
                clickTabMenu(document.getElementById("tdBuy"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
            case 'divAccountDetail':
                clickTabMenu(document.getElementById("tdAccountDetail"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
           
            case 'divReward':
                clickTabMenu(document.getElementById("tdReward"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
            case 'divUserPay':
                clickTabMenu(document.getElementById("tdUserPay"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
            case 'divUserDistills':
                clickTabMenu(document.getElementById("tdUserDistills"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
            case 'divScoring':
                clickTabMenu(document.getElementById("tdScoring"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
            default:
                clickTabMenu(document.getElementById("tdBuy"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
        }
        ShowOrHiddenDiv(curDiv);
    </script>

    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
