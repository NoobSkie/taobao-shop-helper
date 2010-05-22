<%@ page language="C#" autoeventwireup="true" CodeFile="FrameLeft.aspx.cs" inherits="Agent_ElectronTicket_FrameLeft" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../../Style/Admin.css" type="text/css" rel="stylesheet" />
</head><link rel="shortcut icon" href="../favicon.ico" />
<body style="background-image:url(../../Images/Admin/sqp_05.jpg)">
    <form id="form1" runat="server">
        <div>
            <table width="170px" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="166px" valign="top" background="../../Images/Admin/sqp_05.jpg" align="center">
                        <table width="166px" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <a href="../../Default.aspx" target="_top">
                                        <img src="../../Images/Admin/sqp_03.jpg" alt="" width="166" height="35" border="0" /></a></td>
                            </tr>
                            <tr>
                                <td height="3" valign="top">
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td valign="top">
                                    <table width="146" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="32">
                                                <table width="146" height="32" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td background="../../Images/Admin/b1bg.gif" class="bai2" align="left">
                                                            &nbsp;&nbsp;+&nbsp;&nbsp;代理商管理平台</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="MenuBar_1" runat="server">
                                            <td height="13" align="center" valign="top" bgcolor="C0E0FE">
                                                <table id="MenuBar_1_1" runat="server" width="136" height="28" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="center">
                                                            <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                                <tr>
                                                                    <td bgcolor="#C0E0FE">
                                                                        <a href="EditPassWord.aspx" target="mainFrame">修改密码</a></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="MenuBar_1_2" runat="server" width="136" height="28" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="center">
                                                            <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                                <tr>
                                                                    <td bgcolor="#C0E0FE">
                                                                        <a href="SelestSell.aspx" target="mainFrame">代理商余额查询</a></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="Table1" runat="server" width="136" height="28" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="center">
                                                            <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                                <tr>
                                                                    <td bgcolor="#C0E0FE">
                                                                        <a href="AgentQueryBet.aspx" target="mainFrame">代理商查询投注明细数据</a></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="Table2" runat="server" width="136" height="28" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="center">
                                                            <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                                <tr>
                                                                    <td bgcolor="#C0E0FE">
                                                                        <a href="AgentRewardBet.aspx" target="mainFrame">代理商查询中奖明细数据</a></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="Table3" runat="server" width="136" height="28" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="center">
                                                            <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                                <tr>
                                                                    <td bgcolor="#C0E0FE">
                                                                        <a href="AgentQueryTicket.aspx" target="mainFrame">代理商查询票信息数据</a></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
