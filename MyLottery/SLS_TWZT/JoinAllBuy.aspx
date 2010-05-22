<%@ page language="C#" autoeventwireup="true" CodeFile="~/JoinAllBuy.aspx.cs" inherits="JoinAllBuy" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Src="Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="Home/Room/UserControls/Index_banner.ascx" TagName="Index_banner" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>一起买彩票、彩票合买代购交易平台－<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %></title>
    <meta name="keywords" content="买彩票,彩票合买"/>
    <meta name="description" content="<%=_Site.Name %>为广大彩民提供互联网彩票合买代购交易平台。"/>
    <link href="Home/Room/Style/css.css" rel="stylesheet" type="text/css" />
   
    <script src="Home/Room/JavaScript/Marquee.js" type="text/javascript"></script>
    <link rel="shortcut icon" href="favicon.ico"/> 
</head>
   
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <table width="1002" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;"
        align="center" background="Home/Room/images/hm_bg.jpg">
        <tr>
            <td colspan="3" style="padding-bottom: 10px">
                <img src="Home/Room/images/hm.gif" width="1002" height="112" border="0" title="中奖其实就是这么简单" alt="买彩票,彩票合买,彩票合买俱乐部-中奖其实就是这么简单" />
            </td>
        </tr>
        <tr>
            <td width="28">
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;</p>
            </td>
            <td width="946" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="73%" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="5" height="29">
                                        &nbsp;
                                    </td>
                                    <td width="100" align="center" bgcolor="#FF6600">
                                        <h1 class='bai14' style="display:inline; ">方案合买</h1>
                                    </td>
                                    <td width="3">
                                    </td>
                                    <td width="100" align="center" bgcolor="#FFCC33">
                                        <h1 class='black14' style="display:inline; "><a href="Lottery/Buy_SSQ.aspx" target="_blank">发起合买</a></h1>
                                    </td>
                                    <td width="3">
                                    </td>
                                    <td width="100" align="center" class="black14" style="padding-top: 3px;">
                                        &nbsp;
                                    </td>
                                    <td width="3">
                                    </td>
                                    <td width="100" align="center" class="black14" style="padding-top: 3px;">
                                        &nbsp;
                                    </td>
                                    <td width="3">
                                    </td>
                                    <td align="center" background="Home/Room/images/cz_qh_72_3.jpg" class="black14" style="padding-top: 3px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="2" colspan="10" bgcolor="#ff6600">
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-bottom: 10px">
                                <tr>
                                    <td width="24%" height="33" bgcolor="#FFFFE8" class="black12" style="padding-left: 10px;">
                                        发起人：<asp:TextBox ID="tbName" CssClass="hm_text" size="15" runat="server"></asp:TextBox>
                                    </td>
                                    <td width="9%" bgcolor="#FFFFE8" class="hui12">
                                        <asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" />
                                    </td>
                                    <td width="64%" align="right" bgcolor="#FFFFE8" class="hui12">
                                        <asp:DropDownList ID="ddlLottery" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLottery_SelectedIndexChanged">
                                            <asp:ListItem Value="-1">全部方案</asp:ListItem>
                                            <asp:ListItem Value="5">双色球</asp:ListItem>
                                            <asp:ListItem Value="6">3D</asp:ListItem>
                                            <asp:ListItem Value="1">胜负彩</asp:ListItem>
                                            <asp:ListItem Value="19">任九场</asp:ListItem>
                                            <asp:ListItem Value="39">超级大乐透</asp:ListItem>
                                            <asp:ListItem Value="63">排列三</asp:ListItem>
                                            <asp:ListItem Value="29">时时乐</asp:ListItem>
                                            <asp:ListItem Value="0">其他彩种</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlMoney" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMoney_SelectedIndexChanged">
                                            <asp:ListItem Value="-1">方案金额</asp:ListItem>
                                            <asp:ListItem Value="Money<100">100元以下</asp:ListItem>
                                            <asp:ListItem Value="Money>=100 and Money<=500">100-500元</asp:ListItem>
                                            <asp:ListItem Value="Money>=500 and Money<=1000">500-1000元</asp:ListItem>
                                            <asp:ListItem Value="Money>1000">1000元以上</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlBonus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBonus_SelectedIndexChanged">
                                            <asp:ListItem Value="-1">佣金</asp:ListItem>
                                            <asp:ListItem Value="0.01">&lt;=1</asp:ListItem>
                                            <asp:ListItem Value="0.02">&lt;=2</asp:ListItem>
                                            <asp:ListItem Value="0.03">&lt;=3</asp:ListItem>
                                            <asp:ListItem Value="0.04">&lt;=4</asp:ListItem>
                                            <asp:ListItem Value="0.05">&lt;=5</asp:ListItem>
                                            <asp:ListItem Value="0.06">&lt;=6</asp:ListItem>
                                            <asp:ListItem Value="0.07">&lt;=7</asp:ListItem>
                                            <asp:ListItem Value="0.08">&lt;=8</asp:ListItem>
                                            <asp:ListItem Value="0.09">&lt;=9</asp:ListItem>
                                        </asp:DropDownList>
                                        %&nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlCondition" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCondition_SelectedIndexChanged">
                                            <asp:ListItem Value="-1">全部</asp:ListItem>
                                            <asp:ListItem Value="QuashStatus=0 and ResShare>0">未满员</asp:ListItem>
                                            <asp:ListItem Value="QuashStatus=0 and ResShare<=0">已满员</asp:ListItem>
                                            <asp:ListItem Value="QuashStatus<>0">已撤单</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="3%" bgcolor="#FFFFE8" class="hui12">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <asp:DataGrid ID="g" runat="server" Width="100%" BorderStyle="None" AllowSorting="True"
                                AllowPaging="True" AutoGenerateColumns="False" BackColor="#CCCCCC" OnItemDataBound="g_ItemDataBound"
                                CellSpacing="1" GridLines="None" OnItemCommand="g_ItemCommand">
                                <HeaderStyle HorizontalAlign="Center" Height="28px" CssClass="black12" BackColor="#EFEFEF">
                                </HeaderStyle>
                                <ItemStyle Height="28px" HorizontalAlign="Center"></ItemStyle>
                                <Columns>
                                    <asp:BoundColumn DataField="Count" HeaderText="NO">
                                        <HeaderStyle HorizontalAlign="Center" Width="4%"></HeaderStyle>
                                        <ItemStyle Width="4%" CssClass="black12"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="LotteryName" HeaderText="彩种">
                                        <HeaderStyle Width="13%"></HeaderStyle>
                                        <ItemStyle Width="13%" CssClass="blue12"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="InitiateName" HeaderText="发起人">
                                        <HeaderStyle Width="13%"></HeaderStyle>
                                        <ItemStyle Width="13%" CssClass="black12"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Level" HeaderText="战绩" SortExpression="Level">
                                        <HeaderStyle Width="10%"></HeaderStyle>
                                        <ItemStyle Width="10%"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Title" HeaderText="方案标题" SortExpression="Title">
                                        <HeaderStyle Width="21%"></HeaderStyle>
                                        <ItemStyle Width="21%" CssClass="blue12_2"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Money" HeaderText="方案金额" SortExpression="Money" DataFormatString="{0:N}">
                                        <HeaderStyle Width="10%"></HeaderStyle>
                                        <ItemStyle Width="10%" CssClass="red12"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="每份" DataField="ShareMoney" SortExpression="ShareMoney"
                                        DataFormatString="{0:N}">
                                        <HeaderStyle Width="7%"></HeaderStyle>
                                        <ItemStyle Width="7%" CssClass="black12"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Schedule" HeaderText="进度" SortExpression="Schedule">
                                        <HeaderStyle Width="7%"></HeaderStyle>
                                        <ItemStyle Width="7%" CssClass="blue12"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ResShare" HeaderText="剩余份数" SortExpression="ResShare"
                                        Visible="false"></asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="认购(份)">
                                        <HeaderStyle Width="8%"></HeaderStyle>
                                        <ItemStyle Width="8%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="tbShare" runat="server" Style="text-align: center;" Width="40" Text="1"
                                                onkeypress="return InputMask_Number();"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="入伙">
                                        <HeaderStyle Width="7%"></HeaderStyle>
                                        <ItemStyle Width="7%" CssClass="red12_2"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnBuy" runat="server" Text="购买" CommandName="Buy" OnClientClick="return CreateLogin();"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn Visible="False" DataField="AssureMoney"></asp:BoundColumn>
                                    <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                                    <asp:BoundColumn Visible="False" DataField="QuashStatus"></asp:BoundColumn>
                                    <asp:BoundColumn Visible="False" DataField="EndTime"></asp:BoundColumn>
                                    <asp:BoundColumn Visible="False" DataField="IsuseID"></asp:BoundColumn>
                                    <asp:BoundColumn Visible="False" DataField="PlayTypeID"></asp:BoundColumn>
                                </Columns>
                            </asp:DataGrid>
                            <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" PageSize="16"
                                ShowSelectColumn="False" DataGrid="g" AlternatingRowColor="#FFFFE6" HotColor="MistyRose"
                                OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore" RowCursorStyle=""
                                RowColor="#FFFFFF" />
                        </td>
                        <td width="27%" align="right" valign="top">
                            <table width="243" border="0" cellspacing="1" cellpadding="0" bgcolor="#CCCCCC">
                                <tr>
                                    <td height="28" align="left" bgcolor="#FF6600" class="bai14" style="padding-left: 15px;">
                                        <strong>最新跟单</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF" style="padding: 5px;">
                                        <div runat="server"  id="divUserList">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <table width="243" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                                <tr>
                                    <td>
                                        
                                            <img src="Home/Room/images/hm_banner.gif" width="243" height="90" border="0" title="2元可中1000万" alt="买彩票,彩票合买,彩票合买俱乐部-2元可中1000万"/>
                                    </td>
                                </tr>
                            </table>
                            <table width="243" border="0" cellspacing="1" cellpadding="0" bgcolor="#CCCCCC" style="margin-top: 10px;">
                                <tr>
                                    <td height="28" align="left" bgcolor="#FF6600" class="bai14" style="padding-left: 15px;">
                                        <strong>热门人物追踪</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF" style="padding: 5px;" id="tdNews" runat="server">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                    <tr>
                        <td>
                            <img src="Home/Room/images/hm_mh.gif" width="945" height="175" title="彩票合买好处多" alt="买彩票,彩票合买,彩票合买俱乐部-彩票合买好处多"/>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                    <tr>
                        <td width="73%" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="5" height="29">
                                        &nbsp;
                                    </td>
                                    <td width="160" align="center" bgcolor="#FF6600" class="bai14" style="padding-top: 3px;">
                                        <strong>合买明星战绩回顾</strong>
                                    </td>
                                    <td width="3">
                                    </td>
                                    <td width="3">
                                    </td>
                                    <td width="100" align="center" class="black14" style="padding-top: 3px;">
                                        <asp:DropDownList ID="ddlLottery1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLottery1_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="3">
                                    </td>
                                    <td width="100" align="center" class="black14" style="padding-top: 3px;">
                                        &nbsp;
                                    </td>
                                    <td width="3">
                                    </td>
                                    <td align="center" background="Home/Room/images/cz_qh_72_3.jpg" class="black14" style="padding-top: 3px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="2" colspan="9" bgcolor="#ff6600">
                                    </td>
                                </tr>
                            </table>
                            <asp:DataGrid ID="g1" runat="server" Width="100%" BorderStyle="None" AllowSorting="True"
                                AllowPaging="True" AutoGenerateColumns="False" BackColor="#CCCCCC" OnItemDataBound="g1_ItemDataBound"
                                CellSpacing="1" GridLines="None" OnItemCommand="g1_ItemCommand">
                                <HeaderStyle HorizontalAlign="Center" Height="28px" CssClass="black12" BackColor="#EFEFEF">
                                </HeaderStyle>
                                <ItemStyle Height="28px" HorizontalAlign="Center"></ItemStyle>
                                <Columns>
                                    <asp:BoundColumn DataField="Count" HeaderText="NO">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%"></HeaderStyle>
                                        <ItemStyle Width="3%" CssClass="black12"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="LotteryName" HeaderText="彩种">
                                        <HeaderStyle Width="16%"></HeaderStyle>
                                        <ItemStyle Width="16%" CssClass="blue12_2"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="InitiateName" HeaderText="发起人">
                                        <HeaderStyle Width="16%"></HeaderStyle>
                                        <ItemStyle Width="16%" CssClass="black12"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Level" HeaderText="战绩" SortExpression="Level">
                                        <HeaderStyle Width="12%"></HeaderStyle>
                                        <ItemStyle Width="12%"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Money" HeaderText="方案金额" SortExpression="Money" DataFormatString="{0:N}">
                                        <HeaderStyle Width="14%"></HeaderStyle>
                                        <ItemStyle Width="14%" CssClass="blue12"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="WinMoney" HeaderText="中奖金额" SortExpression="WinMoney"
                                        DataFormatString="{0:N}">
                                        <HeaderStyle Width="17%"></HeaderStyle>
                                        <ItemStyle Width="17%" CssClass="red12"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Win" HeaderText="盈利指数" SortExpression="Win" DataFormatString="{0:N}">
                                        <HeaderStyle Width="11%"></HeaderStyle>
                                        <ItemStyle Width="11%" CssClass="blue12"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="定制跟单">
                                        <HeaderStyle Width="11%"></HeaderStyle>
                                        <ItemStyle Width="11%" CssClass="red12_2"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnOK" runat="server" Text="定制" CommandName="DZ" OnClientClick="return CreateLogin();"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn Visible="False" DataField="LotteryID"></asp:BoundColumn>
                                    <asp:BoundColumn Visible="False" DataField="InitiateUserID"></asp:BoundColumn>
                                    <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                                    <asp:BoundColumn Visible="False" DataField="State"></asp:BoundColumn>
                                </Columns>
                            </asp:DataGrid>
                            <ShoveWebUI:ShoveGridPager ID="gPager1" runat="server" Width="100%" PageSize="6"
                                ShowSelectColumn="False" DataGrid="g1" AlternatingRowColor="#FFFFE6" HotColor="MistyRose"
                                OnPageWillChange="gPager1_PageWillChange" OnSortBefore="gPager1_SortBefore" RowCursorStyle=""
                                RowColor="#FFFFFF" />
                        </td>
                        <td width="27%" align="right" valign="top">
                            <table width="243" border="0" cellspacing="1" cellpadding="0" bgcolor="#CCCCCC">
                                <tr>
                                    <td height="28" align="left" bgcolor="#FF6600" class="bai14" style="padding-left: 15px;">
                                        <strong>活跃合买明星</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF" style="padding: 5px;" id="tdActiveMembers" runat="server">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="28">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <img src="Home/Room/images/hm_foot_bg.jpg" width="1002" height="25" title="" alt="买彩票,彩票合买,彩票合买俱乐部"/>
            </td>
        </tr>
    </table>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="Html/TrafficStatistics/1.htm"-->
</body>
</html>

<script type="text/javascript">
    function InputMask_Number() {
        if (window.event.keyCode < 48 || window.event.keyCode > 57)
            return false;
        return true;
    }
    
    var up = new scrolls("scrollWinUsers","up");
    up.addNodes();
    up.scrollPro();

    <%=script %>
</script>

