<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/7Xing/7X_YS.aspx.cs" inherits="_7Xing_7X_YS" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>七星彩余数走试图</title>
    <style type="text/css">
        body
        {
            font-family: tahoma;
            margin: 0px;
            margin-left: 10px;
            margin-right: 10px;
            text-align: center;
        }
        body, td, th
        {
            font-size: 12px;
            font-name: 宋体;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 100%; height: 40px; background-image: url(../Images/bg11111.jpg);"
        cellspacing="0" cellpadding="0">
        <tbody>
            <tr>
                <td align="center" valign="middle" style="width: 300px; font-weight: bold; font-size: 18px;
                    color: #CC0000">
                    七星彩&nbsp;&nbsp;余数分布图
                </td>
                <td style="width: 700px; color: blue; font-style: normal; height: 6px;" align="left">
                    选择最近期数
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="100期" AutoPostBack="True"
                        GroupName="group" OnCheckedChanged="RadioButton1_CheckedChanged1" />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="50期" AutoPostBack="True"
                        OnCheckedChanged="RadioButton2_CheckedChanged" GroupName="group" />
                    <asp:RadioButton ID="RadioButton3" runat="server" Text="30期" AutoPostBack="True"
                        Checked="true" OnCheckedChanged="RadioButton3_CheckedChanged" GroupName="group" />
                    <asp:RadioButton ID="RadioButton4" runat="server" Text="20期" AutoPostBack="True"
                        GroupName="group" OnCheckedChanged="RadioButton4_CheckedChanged1" />
                    <asp:RadioButton ID="RadioButton5" runat="server" Text="10期" AutoPostBack="True"
                        GroupName="group" OnCheckedChanged="RadioButton5_CheckedChanged1" />
                </td>
            </tr>
        </tbody>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
        <tbody>
            <tr>
                <td align="center" style="background-color: #FFFFFF;">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr style="background-color: #EEEEEE">
                                <td style="background-color: #EFEFEF; text-align: left; font-size: 12px; width: 500px;">
                                    <a href="<%= _Site.Url %>" target="_blank" style="text-decoration: none; font-size: 14px;
                                        padding-left: 10px;"><%=_Site.Name %>首页</a> <a href="<%= ResolveUrl("~/Lottery/Buy_QXC.aspx") %>"
                                            target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">七星彩投注/合买</a>
                                    <a href="<%= ResolveUrl("~/WinQuery/3-0-0.aspx") %>" target="_blank" style="padding-left: 10px;
                                        text-decoration: none; color: Red;">七星彩中奖查询</a>
                                </td>
                                <td align="center" style="height: 24PX">
                                    <b>七星彩开奖号码余数分布图</b>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr style="background-color: #FFFFFF">
                <td valign="top" style="border-color: #FFFFFF">
                    <table style="width: 100%" border="1" align="center" cellpadding="0" cellspacing="0"
                        bordercolorlight="#CCCCCC" bordercolordark="#FFFFFF">
                        <tr align="center" valign="middle">
                            <td valign="top">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" UseAccessibleHeader="False"
                                    OnRowCreated="GridView1_RowCreated" ShowFooter="True" Width="100%" bordercolorlight="#808080"
                                    bordercolordark="#FFFFFF" align="center" CellPadding="0" CellSpacing="0">
                                    <Columns>
                                        <asp:BoundField DataField="Isuse" HeaderText="期 数">
                                            <ItemStyle Width="60px" Font-Names="宋体" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LotteryNumber" HeaderText="开奖号码">
                                            <ItemStyle Width="100px" Font-Bold="True" Font-Names="宋体" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_7_0" HeaderText="0">
                                            <ItemStyle Width="16px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_7_1" HeaderText="1">
                                            <ItemStyle Width="16px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_7_2" HeaderText="2">
                                            <ItemStyle Width="16px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_7_3" HeaderText="3">
                                            <ItemStyle Width="16px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_7_4" HeaderText="4">
                                            <ItemStyle Width="16px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_7_5" HeaderText="5">
                                            <ItemStyle Width="16px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_7_6" HeaderText="6">
                                            <ItemStyle Width="16px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_5_0" HeaderText="0">
                                            <ItemStyle Width="16px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_5_1" HeaderText="1">
                                            <ItemStyle Width="16px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_5_2" HeaderText="2">
                                            <ItemStyle Width="16px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_5_3" HeaderText="3">
                                            <ItemStyle Width="16px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_5_4" HeaderText="4">
                                            <ItemStyle Width="16px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_3_0" HeaderText="0">
                                            <ItemStyle Width="16px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_3_1" HeaderText="1">
                                            <ItemStyle Width="16px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_3_2" HeaderText="2">
                                            <ItemStyle Width="16px" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </div>
    </form>
</body>
</html>
