<%@ page language="C#" autoeventwireup="true" CodeFile="AgentRewardBet.aspx.cs" inherits="Agent_ElectronTicket_AgentRewardBet" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
 <link href="../../Style/Surrogate.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        tr
        {
            height: 28px;
        }
    </style>
    <script language="javascript" type="text/javascript" src="../../Components/My97DatePicker/WdatePicker.js"></script>
</head><link rel="shortcut icon" href="../favicon.ico" />
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table align="center" border="0" cellpadding="1" cellspacing="1" style="border-collapse: collapse;
            width: 90%; text-align: center;">
            <tr>
                <td>
                    <table align="center" border="0" cellpadding="1" cellspacing="1" style="border-collapse: collapse;
                        background-color: #E0E0E0; width: 100%; text-align: center;">
                        <tr>
                            <td style="width: 20%; background-color: #f5f5f5;">
                                方案号:
                            </td>
                            <td style="width: 30%; background-color: White;">
                                <asp:TextBox ID="tbSchemeNumber" runat="server" Width="180px"></asp:TextBox>
                            </td>
                            <td style="width: 20%; background-color: #f5f5f5;">
                                奖期名:
                            </td>
                            <td style="width: 30%; background-color: White;">
                                <asp:TextBox ID="tbIsuseName" runat="server" Width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; background-color: #f5f5f5;">
                                玩法:
                            </td>
                            <td style="width: 30%; background-color: White;">
                                <asp:DropDownList ID="ddlLottery" runat="server" Width="180px" AutoPostBack="false">
                                    <asp:ListItem Value="0">--------------请选择--------------</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 20%; background-color: #f5f5f5;">
                                投注类型:
                            </td>
                            <td style="width: 30%; background-color: White;">
                                <asp:DropDownList ID="ddlState" runat="server" Width="180px" AutoPostBack="false">
                                    <asp:ListItem Value="0">--------------请选择--------------</asp:ListItem>
                                    <asp:ListItem Value="1">投注成功</asp:ListItem>
                                    <asp:ListItem Value="2">投注失败</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; background-color: #f5f5f5;">
                                时间:
                            </td>
                            <td style="width: 80%; background-color: White;" colspan="3">
                                从:&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="tbStartTime" runat="server" onblur="if(this.value=='') this.value=document.getElementById('tbStartTime').value"
                    name="tbStartTime" onFocus="WdatePicker({el:'tbStartTime',dateFmt:'yyyy-MM-dd', maxDate:'%y-%M-%d'})"></asp:TextBox>
                                &nbsp; 到:&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="tbEndTime" runat="server" onblur="if(this.value=='') this.value=document.getElementById('tbEndTime').value"
                    onFocus="WdatePicker({el:'tbEndTime',dateFmt:'yyyy-MM-dd', maxDate:'%y-%M-%d'})"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_ok" runat="server" Text="查询" Width="100px" OnClick="btn_ok_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="g" runat="server" Width="100%" AllowPaging="True" PageSize="30"
                        BorderColor="#f5f5f5" BorderStyle="None" BorderWidth="2px" BackColor="White"
                        CellPadding="0" AutoGenerateColumns="False" AllowSorting="True" OnItemDataBound="g_ItemDataBound">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
                        <HeaderStyle HorizontalAlign="Center" ForeColor="RoyalBlue" VerticalAlign="Middle"
                            BackColor="#f5f5f5"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn DataField="DateTime" HeaderText="时间">
                                <HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:HyperLinkColumn Target="_self" DataNavigateUrlField="ID" DataNavigateUrlFormatString="Scheme.aspx?id={0}"
                                DataTextField="SchemeNumber" HeaderText="方案编号">
                                <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:HyperLinkColumn>
                            <asp:BoundColumn DataField="Amount" HeaderText="金额">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="LotteryName" HeaderText="彩种">
                                <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="PlayTypeName" HeaderText="玩法">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="WinMoney" HeaderText="中奖金额">
                                <HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Identifiers" SortExpression="Schedule" HeaderText="方案标识">
                                <HeaderStyle HorizontalAlign="Center" Width="30%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="ID" SortExpression="id"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
                        </PagerStyle>
                    </asp:DataGrid>
                    <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" PageSize="30"
                        HotColor="MistyRose" GridColor="#E0E0E0" AlternatingRowColor="Linen" DataGrid="g"
                        ShowSelectColumn="False" Visible="False" OnPageWillChange="gPager_PageWillChange"
                        OnSortBefore="gPager_SortBefore" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>