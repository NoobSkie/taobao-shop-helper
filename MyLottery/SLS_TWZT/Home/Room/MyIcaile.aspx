<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/MyIcaile.aspx.cs" inherits="Home_Room_MyIcaile" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register src="UserControls/UserMyIcaile.ascx" tagname="UserMyIcaile" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>中奖查询-我的账户-用户中心-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
     
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            min-width: 1003px;
            margin-top: 0px;
            margin-left: 0px;
            margin-bottom: 0px;
            margin-right: 0px;
            background-color: #FFF;
            background-repeat: repeat-x;
            background-position: center top;
        }
        .mOver
        {
            border: none;
            background-color: #FFF5D0;
            color: #FF9900;
        }
        .mOut
        {
            font-weight: normal;
        }
        .mClick
        {
            font-weight: bold;
        }
        .in_text
        {
            height: 18px;
            border: 1px solid #9BBDD3;
            background-color: #FFFFFF;
            color: #666666;
            font-size: 12px;
            font-family: "tahoma";
        }
        .blue14
        {
            font-size: 14px;
            color: #216699;
            font-family: "tahoma";
            line-height: 20px;
        }
    </style>

    <script type="text/javascript">
       
        function clickTabMenu(obj, backgroundImage, tabId) {
            var tabMenu = obj.offsetParent.cells;
            var tabContent = document.getElementById(tabId).cells;
            for (var i = 0; i < tabMenu.length; i++) {
                if (obj == tabMenu[i]) {
                    obj.style.backgroundImage = backgroundImage;
                    tabContent[i].style.display = "";
                }
                else {
                    tabMenu[i].style.backgroundImage = "";
                    tabContent[i].style.display = "none";
                }
            }
        }

        function showSameHeight() {
            if (document.getElementById("menu_left").clientHeight < document.getElementById("menu_right").clientHeight) {
                document.getElementById("menu_left").style.height = document.getElementById("menu_right").offsetHeight + "px";
            }
            else {
                if (document.getElementById("menu_right").offsetHeight >= 960) {
                    document.getElementById("menu_left").style.height = document.getElementById("menu_right").offsetHeight + "px";
                }
                else {
                    document.getElementById("menu_left").style.height = "960px";
                }
            }
        }
        
        function ShowOrHiddenDiv(id) {
            var arrCells = new Array('tdInvestHistory', 'tdReward', 'tdMyScore');
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
                case 'divInvestHistory':
                    divInvestHistory.display = "block";
                    divReward.display = "none";
                    divMyScore.display = "none";
                    document.getElementById("hdCurDiv").value = "divInvestHistory";
                    break;
                case 'divReward':
                    divReward.display = "block";
                    divInvestHistory.display = "none";
                    divMyScore.display = "none";
                    document.getElementById("hdCurDiv").value = "divReward";
                    break;
                case 'divMyScore':
                    divMyScore.display = "block";
                    divInvestHistory.display = "none";
                    divReward.display = "none";
                    document.getElementById("hdCurDiv").value = "divMyScore";
                    break;
            }
        }
    </script>

<link rel="shortcut icon" href="../../favicon.ico" /></head>
<body onload="showSameHeight();">
    <form id="form1" runat="server">
    <asp:Label ID="label1" runat="server" ></asp:Label>
    <asp:HiddenField ID="HidUserID" runat="server" Value="-1" />
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
     <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 10px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
           <table width="842" border="0" cellspacing="0" cellpadding="0" background="images/zfb_left_bg_2.jpg">
        <tr>
            <td width="500" height="29" align="left">
                <span class="black12" style="padding-left: 10px;"><span class="red12">
                    <%=UserName%></span>，您好！余额：<span class="red12"><%=Balance %></span>元 <span class="blue12"
                        runat="server" id="sp_isGoLogin"></span>
            </td>
           
            <td id="tdInvestHistory" width="100" align="center" background="images/admin_qh_100_2.jpg"
                 onclick="clickTabMenu(this,'url(images/admin_qh_100_1.jpg)','myIcaileTab');ShowOrHiddenDiv('divInvestHistory');"
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
            <td width="100" id="tdMyScore" align="center" background="images/admin_qh_100_2.jpg"
                onclick="clickTabMenu(this,'url(images/admin_qh_100_1.jpg)','myIcaileTab');ShowOrHiddenDiv('divMyScore');"
                style="cursor: pointer;" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)">
                我的积分
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
    <table id="myIcaileTab" runat="server" width="842" border="0" cellpadding="0" cellspacing="0"
        style="margin-top: 10px;">
        <tr>
            <td>
                &nbsp;
            </td>
            <td valign="top">
                <div id="divInvestHistory">
                    <div style="background-color: White; width: 100%;">
                        <asp:DropDownList ID="ddlLottery" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLottery_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <asp:DataGrid ID="gInvestHistory" runat="server" Width="842" BorderStyle="None" AllowPaging="True"
                        PageSize="30" AutoGenerateColumns="False" CellPadding="0" BackColor="#DDDDDD"
                        CellSpacing="1" GridLines="None" OnItemDataBound="gInvestHistory_ItemDataBound"
                        Font-Names="Tahoma" OnSortCommand="gInvestHistory_SortCommand">
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
                            <%--<asp:BoundColumn DataField="DateTime" SortExpression="DateTime" HeaderText="发起时间"
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
                        </Columns>                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="Silver"
                            Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>

                    <ShoveWebUI:ShoveGridPager ID="gPagerHistory" runat="server" Width="842" PageSize="10"
                        ShowSelectColumn="False" DataGrid="gInvestHistory" AlternatingRowColor="#F8F8F8"
                        GridColor="#E0E0E0" HotColor="MistyRose" Visible="False" OnPageWillChange="gPager_PageWillChange"
                        RowCursorStyle="" AllowShorting="true" />
                    <div style="padding: 9px; background-color: White;">
                        <asp:Label ID="lbgInvestHistoryMessage" runat="server"></asp:Label>
                    </div>
                    <table id="Table1" width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8"
                        style="margin-top: 0px;" runat="server">
                        <tr>
                            <td width="407" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                认购金额总计： <span class="red12">
                                    <asp:Label ID="lblBuySum" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                方案奖金总计： <span class="red12">
                                    <asp:Label ID="lblSumWinMoney" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                我的奖金总计： <span class="red12">
                                    <asp:Label ID="lblMySumWinMoney" runat="server" Text=""></asp:Label>
                                </span>
                            </td>
                            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                                盈利指数总计： <span class="red12">
                                    <asp:Label ID="lblSumWinProfitPoints" runat="server" Text=""></asp:Label>
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
            <td id="Td1" valign="top" runat="server">
                <div id="divReward">
                    <asp:DataGrid ID="gReward" runat="server" Width="842" BorderStyle="None" AllowPaging="True"
                        PageSize="30" AutoGenerateColumns="False" CellPadding="0" BackColor="#DDDDDD"
                        CellSpacing="1" GridLines="None" OnItemDataBound="gReward_ItemDataBound" Font-Names="Tahoma">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" Height="30px" CssClass="blue12_2">
                        </HeaderStyle>
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
            <td valign="top">
                <div id="divMyScore">
                    <table width="842" border="0" cellpadding="0" cellspacing="1" bgcolor="#DDDDDD">
                        <tr>
                            <td width="27%" height="30" align="right" bgcolor="#F8F8F8" class="black12">
                                用户类型：<span class="red12"></span>
                            </td>
                            <td width="73%" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                <asp:Label ID="labUserType" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right" bgcolor="#F8F8F8" class="black12">
                                账户余额：
                            </td>
                            <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                <span class="red12">
                                    <asp:Label ID="labBalance" runat="server"></asp:Label></span> 元 <a href="Distill.aspx"
                                        target="_self"><span class="blue12">【我要提款】</span></a>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right" bgcolor="#F8F8F8" class="black12">
                                已冻结金额：
                            </td>
                            <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                <span class="red12">
                                    <asp:Label ID="labFreeze" runat="server"></asp:Label></span> 元
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right" bgcolor="#F8F8F8" class="black12">
                                可投注金额：
                            </td>
                            <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                <span class="red12">
                                    <asp:Label ID="labBalanceDo" runat="server"></asp:Label></span> 元
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right" bgcolor="#F8F8F8" class="black12">
                                我的积分：
                            </td>
                            <td align="left" bgcolor="#FFFFFF" class="blue12" style="padding-left: 10px;">
                                <asp:Label ID="labScoring" runat="server"></asp:Label>分
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
    <input type="hidden" id="hdCurDiv" runat="server" value="divReward" />
        </div>
    </div>
    
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
  
    <div style="display: none;">

        <script src="JavaScript/Public.js" type="text/javascript"></script>

        <script type="text/javascript" language="javascript">
            document.body.style.height = window.screen.availHeight - window.screenTop - 26;
        </script>

    </div>
    </form>
    <script type="text/javascript">
        var curDiv = document.getElementById("hdCurDiv").value;
        switch (curDiv) {
            case 'divInvestHistory':
                clickTabMenu(document.getElementById("tdInvestHistory"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
            case 'divReward':
                clickTabMenu(document.getElementById("tdReward"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
            case 'divMyScore':
                clickTabMenu(document.getElementById("tdMyScore"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
            default:
                clickTabMenu(document.getElementById("tdInvestHistory"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;

        }
        ShowOrHiddenDiv(curDiv);
    </script>
    </body>
</html>
