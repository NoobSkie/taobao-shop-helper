<%@ page language="C#" autoeventwireup="true" CodeFile="SchemeQuash.aspx.cs" inherits="Admin_SchemeQuash" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table id="Table1" cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
            <tr>
                <td style="height: 21px">
                    <font face="宋体">选择彩票类型
                        <asp:DropDownList ID="ddlLottery" runat="server" AutoPostBack="True" Width="144px" OnSelectedIndexChanged="ddlLottery_SelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp;<asp:RadioButton ID="rb1" runat="server" Checked="True" GroupName="rb" Text="方案编号" />
                        <asp:RadioButton ID="rb2" runat="server" GroupName="rb" Text="用户名" />
                        &nbsp;&nbsp;
                        <asp:TextBox ID="tbQuash" runat="server" Width="208px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <ShoveWebUI:ShoveConfirmButton ID="btnRefresh" BackgroupImage="../Images/Admin/buttbg.gif" runat="server" Width="60px" Height="20px" Text=" 搜   索 " OnClick="btnRefresh_Click" />
                    </font>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:DataList ID="g" runat="server" Width="100%" OnItemCommand="g_ItemCommand" 
                        onitemdatabound="g_ItemDataBound">
                        <HeaderTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td class="td4" width="6%">
                                        <strong>发起人</strong>
                                    </td>
                                    <td class="td4" width="16%">
                                        <strong>方案编号</strong>
                                    </td>
                                    <td class="td4" width="8%">
                                        <strong>玩法</strong>
                                    </td>
                                    <td class="td4" width="42%">
                                        <strong>购买内容</strong>
                                    </td>
                                    <td class="td4" width="4%">
                                        <strong>倍数</strong>
                                    </td>
                                    <td class="td4" width="8%">
                                        <strong>金额</strong>
                                    </td>
                                    <td class="td4" width="6%">
                                        <strong>进度</strong>
                                    </td>
                                    <td class="td4" width="10%">
                                        <strong>撤单</strong>
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td width="6%">
                                        <%# DataBinder.Eval(Container.DataItem,"InitiateName")%>
                                        <input id="tbSiteID" style="width: 37px; height: 21px" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"SiteID")%>' runat="server" />
                                        <input id="tbInitiateUserID" style="width: 37px; height: 21px" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"InitiateUserID")%>' runat="server" />
                                        <input id="tbSchemeID" style="width: 37px; height: 21px" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"ID")%>' name="tbSchemeID" runat="server" />
                                    </td>
                                    <td width="16%">
                                        <a class="li3" href='../Home/Room/Scheme.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>' target="_blank">
                                            <%# DataBinder.Eval(Container.DataItem,"SchemeNumber")%>
                                        </a>
                                    </td>
                                    <td width="8%">
                                        <%# DataBinder.Eval(Container.DataItem,"PlayTypeName")%>
                                    </td>
                                    <td width="42%">
                                        <%# DataBinder.Eval(Container.DataItem,"LotteryNumber")%>
                                    </td>
                                    <td width="4%">
                                        <%# int.Parse(Eval("Multiple").ToString()) == 0 ? (Eval("LocateWaysAndMultiples")) : (Eval("Multiple"))%>
                                    </td>
                                    <td width="8%">
                                        <font color="#ff0000">
                                            <%# DataBinder.Eval(Container.DataItem,"Money")%>
                                        </font>
                                    </td>
                                    <td width="6%">
                                        <%# DataBinder.Eval(Container.DataItem,"Schedule")%>
                                        %
                                    </td>
                                    <td width="10%">
                                        <ShoveWebUI:ShoveConfirmButton ID="btnQuash" BackgroupImage="../Images/Admin/buttbg.gif" runat="server" Width="60px" Height="20px" Text="撤单" AlertText="确信要撤消此单吗？" CommandName="btnQuash" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
        </table>
        <br />
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
