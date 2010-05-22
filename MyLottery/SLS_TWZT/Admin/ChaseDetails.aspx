<%@ page language="C#" autoeventwireup="true" CodeFile="ChaseDetails.aspx.cs" inherits="Admin_ChaseDetails" enableEventValidation="false" %>

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
        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td style="border-bottom: #990000 1px dashed" valign="top" align="center">
                    <font face="宋体">
                        <br />
                        追<font color="#999999">号标题：</font>
                        <asp:Label ID="labTitle" runat="server" ForeColor="#804000" Font-Bold="True"></asp:Label></font>
                </td>
            </tr>
            <tr>
                <td valign="top" align="center">
                    <font face="宋体">
                        <br />
                    </font>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td class="td2" style="width: 66px" height="25">
                                <font color="#999999">任务类型：</font>
                            </td>
                            <td class="td2" height="25" align="left">
                                <font face="宋体">
                                    <asp:Label ID="lbLotteryName" runat="server" Font-Bold="True"></asp:Label>&nbsp;
                                    <asp:Label ID="lbPlayTypeName" runat="server" Font-Bold="True"></asp:Label></font>
                            </td>
                        </tr>
                        <tr>
                            <td class="td2" style="width: 66px" height="25">
                                <font color="#999999">终止条件：</font>
                            </td>
                            <td class="td2" height="25" align="left">
                                <font face="宋体">
                                    <asp:Label ID="lbStopCondition" runat="server"></asp:Label>&nbsp;</font>
                            </td>
                        </tr>
                        <tr>
                            <td class="td2" style="width: 66px" valign="top" height="25">
                                <font color="#999999">所追期号：</font>
                            </td>
                            <td class="td2" valign="top" height="25" align="left">
                                <font face="宋体">
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
                            <td class="td2" style="width: 66px" height="25">
                                <font face="宋体" color="#999999">任务执行：</font>
                            </td>
                            <td class="td2" height="25" align="left">
                                <font face="宋体">
                                    <asp:Label ID="lbDescription" runat="server"></asp:Label></font>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="middle" align="center" height="50">
                    <font face="宋体">【<a class="li3" href="ChaseList.aspx">返回</a>】</font>
                    <input id="tbInitiateUserID" type="hidden" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>