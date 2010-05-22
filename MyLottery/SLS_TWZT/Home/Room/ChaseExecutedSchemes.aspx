<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/ChaseExecutedSchemes.aspx.cs" inherits="Home_Room_ChaseExecutedSchemes" enableEventValidation="false" %>
<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title><%=_Site.Name %>个人资料完善-用户中心-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
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
            <table width="842" border="0" cellpadding="0" cellspacing="1" bgcolor="#9FC8EA">
                <tr>
                    <td valign="top" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="5">
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="black12" style="padding: 10px;">
                                                <span class="red">注：为了减轻服务器的压力，此数据被缓存几分钟。即：你的最后操作的购买电话投注卡、冻结、解冻、投注等信息，如果没有完全显示出来，几分钟后重新打开本页都将会被正确显示。</span>
                                                如果您买了电话投注卡，银行账户钱扣了，而您的账户还没有加上，请点击<span
                                                        class="blue12_2">在线客服</span>告诉我们，我们将第一时间为您处理！
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="padding-bottom: 10px;">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td valign="top" align="center">
                                                    <table width="842" border="0" cellpadding="0" cellspacing="1" bgcolor="#C0DBF9">
                                                        <tr>
                                                            <td width="17%" height="30" align="right" bgcolor="#F8F8F8" class="black12">
                                                                <font color="#999999">任务类型：</font>
                                                            </td>
                                                            <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                                                <font face="Tahoma">
                                                                    <asp:Label ID="lbLotteryName" runat="server" Font-Bold="True"></asp:Label>
                                                                    <asp:Label ID="lbPlayTypeName" runat="server" Font-Bold="True"></asp:Label></font>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="17%" height="30" align="right" bgcolor="#F8F8F8" class="black12">
                                                                <font color="#999999">追号标题：</font>
                                                            </td>
                                                            <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                                                <font face="Tahoma">
                                                                    <asp:Label ID="lbTitle" runat="server"></asp:Label>&nbsp;</font>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="17%" height="30" align="right" bgcolor="#F8F8F8" class="black12">
                                                                <font color="#999999">所追期号：</font>
                                                            </td>
                                                            <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                                                <font face="Tahoma">
                                                                    <asp:DataGrid ID="g" runat="server" Width="100%" AutoGenerateColumns="False" ShowHeader="False"
                                                                        GridLines="None"  OnItemDataBound="g_ItemDataBound">
                                                                        <Columns>
                                                                            <asp:BoundColumn DataField="IsuseName">
                                                                                <HeaderStyle Width="85px"></HeaderStyle>
                                                                                <ItemStyle Font-Bold="True"></ItemStyle>
                                                                            </asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="LotteryNumber">
                                                                                <HeaderStyle Width="85px"></HeaderStyle>
                                                                                <ItemStyle Font-Bold="True"></ItemStyle>
                                                                            </asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="Multiple">
                                                                                <HeaderStyle Width="45px"></HeaderStyle>
                                                                            </asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="Money">
                                                                                <HeaderStyle Width="60px"></HeaderStyle>
                                                                            </asp:BoundColumn>
                                                                            <asp:BoundColumn>
                                                                                <HeaderStyle Width="80px"></HeaderStyle>
                                                                            </asp:BoundColumn>
                                                                            <asp:BoundColumn>
                                                                                <HeaderStyle Width="80px"></HeaderStyle>
                                                                            </asp:BoundColumn>
                                                                           
                                                                            <asp:BoundColumn Visible="False" DataField="QuashStatus">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:BoundColumn>
                                                                            <asp:BoundColumn Visible="False" DataField="Buyed">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:BoundColumn>
                                                                           
                                                                            <asp:BoundColumn Visible="False" DataField="ID">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:BoundColumn>
                                                                        </Columns>
                                                                    </asp:DataGrid>&nbsp;</font>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="17%" height="30" align="right" bgcolor="#F8F8F8" class="black12">
                                                                <font face="Tahoma" color="#999999">任务执行：</font>
                                                            </td>
                                                            <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                                                <font face="Tahoma">
                                                                    <asp:Label ID="lbDescription" runat="server"></asp:Label></font>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="17%" height="30" align="right" bgcolor="#F8F8F8" class="black12">
                                                                <font face="Tahoma" color="#999999">终止条件：</font>
                                                            </td>
                                                            <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                                                <font face="Tahoma">
                                                                    <asp:Label ID="lbStopCondition" runat="server"></asp:Label></font>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" align="center" style="padding: 15px;">
                                                    <font face="Tahoma">【<a class="blue12_line" href="ViewChase.aspx">返回</a>】</font>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <input id="tbLotteryID" runat="server" name="tbLotteryID" style="width: 50px" type="hidden" /><input
                id="tbPlayTypeID" runat="server" name="tbPlayTypeID" style="width: 50px" type="hidden" /><input
                    id="tbBuyFileName" runat="server" name="tbBuyFileName" style="width: 50px" type="hidden" />
        </div>
        </div>
        <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>