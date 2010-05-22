<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/Welcome.aspx.cs" inherits="Home_Room_Welcome" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
        function ShowOrHiddenDiv(id) {
            var arrCells = new Array('tdInvest', 'tdInvestHistory', 'tdReward', 'tdMyScore');
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
                case 'divInvest':
                    divInvest.display = "block";
                    divInvestHistory.display = "none";
                    divReward.display = "none";
                    divMyScore.display = "none";
                    document.getElementById("hdCurDiv").value = "divInvest";
                    break;
                case 'divInvestHistory':
                    divInvestHistory.display = "block";
                    divInvest.display = "none";
                    divReward.display = "none";
                    divMyScore.display = "none";
                    document.getElementById("hdCurDiv").value = "divInvestHistory";
                    break;
                case 'divReward':
                    divReward.display = "block";
                    divInvest.display = "none";
                    divInvestHistory.display = "none";
                    divMyScore.display = "none";
                    document.getElementById("hdCurDiv").value = "divReward";
                    break;
                case 'divMyScore':
                    divMyScore.display = "block";
                    divInvest.display = "none";
                    divInvestHistory.display = "none";
                    divReward.display = "none";
                    document.getElementById("hdCurDiv").value = "divMyScore";
                    break;
            }
            parent.document.getElementById("mainFrame").style.height = document.getElementById(id).scrollHeight + 120;
        }
        //
        function CreateLogin() {
            return parent.CreateLogin('');
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
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="842" border="0" cellspacing="0" cellpadding="0" background="images/zfb_left_bg_2.jpg">
        <tr>
            <td width="400" height="29" align="left">
                <span class="black12" style="padding-left: 10px;"><span class="red12">
                    <%=UserName%></span>，您好！余额：<span class="red12"><%=Balance %></span>元 <span class="blue12"
                        runat="server" id="sp_isGoLogin"></span>
            </td>
            <td width="100" id="tdInvest" align="center" background="images/admin_qh_100_2.jpg"
                class="blue12" onclick="parent.clickTabMenu(this,'url(images/admin_qh_100_1.jpg)','myIcaileTab');ShowOrHiddenDiv('divInvest');"
                style="cursor: pointer;" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)">
                本期投注
            </td>
            <td width="6">
                &nbsp;
            </td>
            <td id="tdInvestHistory" width="100" align="center" background="images/admin_qh_100_2.jpg"
                 onclick="parent.clickTabMenu(this,'url(images/admin_qh_100_1.jpg)','myIcaileTab');ShowOrHiddenDiv('divInvestHistory');"
                style="cursor: pointer;" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)">
                历史投注
            </td>
            <td width="6">
                &nbsp;
            </td>
            <td width="100" id="tdReward" align="center" background="images/admin_qh_100_2.jpg"
                onclick="parent.clickTabMenu(this,'url(images/admin_qh_100_1.jpg)','myIcaileTab');ShowOrHiddenDiv('divReward');"
                style="cursor: pointer;" class="blue12" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)">
                中奖查询
            </td>
            <td width="6">
                &nbsp;
            </td>
            <td width="100" id="tdMyScore" align="center" background="images/admin_qh_100_2.jpg"
                onclick="parent.clickTabMenu(this,'url(images/admin_qh_100_1.jpg)','myIcaileTab');ShowOrHiddenDiv('divMyScore');"
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
                <div id="divInvest">
                    <asp:DataGrid ID="gInvest" runat="server" Width="842" BorderStyle="None" AllowPaging="True"
                        PageSize="30" AutoGenerateColumns="False" CellPadding="0" BackColor="#DDDDDD"
                        CellSpacing="1" GridLines="None" OnItemDataBound="gInvest_ItemDataBound" Font-Names="Tahoma">
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
                                <HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Money" SortExpression="Money" HeaderText="方案金额">
                                <HeaderStyle HorizontalAlign="Center" Width="12%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="InitiateName" SortExpression="InitiateName" HeaderText="发起人">
                                <HeaderStyle HorizontalAlign="Center" Width="12%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="状态">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="SchemeID" SortExpression="SchemeID" HeaderText="SchemeID">
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="QuashStatus" SortExpression="QuashStatus">
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="Buyed" SortExpression="Buyed"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="Schedule" SortExpression="Schedule">
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="Silver"
                            Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                    <div style="padding: 9px; background-color: White;">
                        <asp:Label ID="lbgInvestMessage" runat="server"></asp:Label>
                    </div>
                </div>
            </td>
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
                            <asp:BoundColumn DataField="LotteryName" SortExpression="LotteryName" HeaderText="彩种">
                                <HeaderStyle HorizontalAlign="Center" Width="14%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IsuseName" SortExpression="IsuseName" HeaderText="期号">
                                <HeaderStyle HorizontalAlign="Center" Width="14%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="LotteryNumber" SortExpression="LotteryNumber" HeaderText="投注内容">
                                <HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DetailMoney" SortExpression="DetailMoney" HeaderText="投注金额">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="SchemeWinMoney" SortExpression="SchemeWinMoney" HeaderText="方案奖金">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                            <asp:BoundColumn Visible="False" DataField="IsOpened" SortExpression="IsOpened" HeaderText="IsOpened">
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="Silver"
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
    </form>

    <script type="text/javascript">
        var curDiv = document.getElementById("hdCurDiv").value;
        switch (curDiv) {
            case 'divInvest':
                parent.clickTabMenu(document.getElementById("tdInvest"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
            case 'divInvestHistory':
                parent.clickTabMenu(document.getElementById("tdInvestHistory"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
            case 'divReward':
                parent.clickTabMenu(document.getElementById("tdReward"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
            case 'divMyScore':
                parent.clickTabMenu(document.getElementById("tdMyScore"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;
            default:
                parent.clickTabMenu(document.getElementById("tdInvestHistory"), "url(images/admin_qh_100_1.jpg)", "myIcaileTab");
                break;

        }
        ShowOrHiddenDiv(curDiv);
    </script>

    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
