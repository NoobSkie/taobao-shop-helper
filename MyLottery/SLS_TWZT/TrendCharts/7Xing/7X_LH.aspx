<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/7Xing/7X_LH.aspx.cs" inherits="_7Xing_7X_LH" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>七星彩连号分析图</title>
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
                    七星彩&nbsp;&nbsp;连号分布图
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
    <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
        <tr align="center" valign="middle">
            <td>
                <table border="0" cellpadding="1" cellspacing="1" style="background-color: #CCCCCC;">
                    <tbody>
                        <tr style="background-color: #EEEEEE">
                            <td align="center">
                                <table cellspacing="0 " cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr style="background-color: #EEEEEE">
                                            <td style="background-color: #EFEFEF; text-align: left; font-size: 12px; width: 500px;">
                                                <a href="<%= _Site.Url %>" target="_blank" style="text-decoration: none; font-size: 14px;
                                                    padding-left: 10px;"><%=_Site.Name %>首页</a> <a href="<%= ResolveUrl("~/Lottery/Buy_QXC.aspx") %>"
                                                        target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">七星彩投注/合买</a>
                                                <a href="<%= ResolveUrl("~/WinQuery/3-0-0.aspx") %>" target="_blank" style="padding-left: 10px;
                                                    text-decoration: none; color: Red;">七星彩中奖查询</a>
                                            </td>
                                            <td height="24" align="center">
                                                <b>七星彩连号分布图</b>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr style="background-color: #FFFFFF">
                            <td valign="top" style="border-color: #ffffff">
                                <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr align="center" valign="middle">
                                        <td valign="top" colspan="11">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" UseAccessibleHeader="False"
                                                ShowFooter="True" Width="100%" bordercolorlight="#808080" bordercolordark="#FFFFFF"
                                                OnRowCreated="GridView1_RowCreated" align="center" CellPadding="0">
                                                <Columns>
                                                    <asp:BoundField DataField="Isuse" HeaderText="期 数">
                                                        <ItemStyle Width="45" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="LotteryNumber" HeaderText="七星彩开奖号码">
                                                        <ItemStyle ForeColor="#0000FF" Font-Bold="true" Width="100" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="L_0" HeaderText="连号数">
                                                        <ItemStyle Width="50" ForeColor="#FF0000" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="G_0" HeaderText="G_0">
                                                        <ItemStyle Width="15" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="G_1" HeaderText="G_1">
                                                        <ItemStyle Width="15" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="G_2" HeaderText="G_2">
                                                        <ItemStyle Width="15" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="G_3" HeaderText="G_3">
                                                        <ItemStyle Width="15" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="G_4" HeaderText="G_4">
                                                        <ItemStyle Width="15" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="G_5" HeaderText="G_5">
                                                        <ItemStyle Width="15" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="G_6" HeaderText="G_6">
                                                        <ItemStyle Width="15" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="P_0" HeaderText="P_0">
                                                        <ItemStyle Width="30" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="P_1" HeaderText="P_1">
                                                        <ItemStyle Width="30" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="P_2" HeaderText="P_2">
                                                        <ItemStyle Width="30" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="P_3" HeaderText="P_3">
                                                        <ItemStyle Width="30" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="P_4" HeaderText="P_4">
                                                        <ItemStyle Width="30" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="P_5" HeaderText="P_5">
                                                        <ItemStyle Width="30" />
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
            </td>
            <td style="width: 30px">
                &nbsp;
            </td>
            <td valign="bottom">
                <table width="300" border="0" align="center" cellpadding="2" cellspacing="0" bordercolorlight="#999999"
                    bordercolordark="#FFFFFF">
                    <tr>
                        <td colspan="2" align="left">
                            <font color="#FF0000">近<%=tem %>期结果分析</font>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 163; height: 60" align="left">
                            <font color="#FF9900">连号出现统计</font>&nbsp
                            <table width="100%" border="1" cellpadding="1" cellspacing="0" bordercolorlight="#FF9900"
                                bordercolordark="#FFFFFF" bgcolor="#FF9900">
                                <tr align="center" valign="middle" bgcolor="#FFFFFF">
                                    <td style="height: 15px">
                                        连 号
                                    </td>
                                    <td>
                                        次数
                                    </td>
                                    <td>
                                        百分比
                                    </td>
                                </tr>
                                <tr align="center" valign="middle" bgcolor="#FFFFFF">
                                    <td style="height: 15px">
                                        0
                                    </td>
                                    <td>
                                        <%=sum[0] %>
                                    </td>
                                    <td>
                                        <%=tr[0] %>
                                    </td>
                                </tr>
                                <tr align="center" valign="middle" bgcolor="#FFFFFF">
                                    <td style="height: 15px">
                                        1
                                    </td>
                                    <td>
                                        <%=sum[1] %>
                                    </td>
                                    <td>
                                        <%=tr[1] %>
                                    </td>
                                </tr>
                                <tr align="center" valign="middle" bgcolor="#FFFFFF">
                                    <td style="height: 15px">
                                        2
                                    </td>
                                    <td>
                                        <%=sum[2] %>
                                    </td>
                                    <td>
                                        <%=tr[2]%>
                                    </td>
                                </tr>
                                <tr align="center" valign="middle" bgcolor="#FFFFFF">
                                    <td style="height: 15px">
                                        3
                                    </td>
                                    <td>
                                        <%=sum[3] %>
                                    </td>
                                    <td>
                                        <%=tr[3]%>
                                    </td>
                                </tr>
                                <tr align="center" valign="middle" bgcolor="#FFFFFF">
                                    <td style="height: 15px">
                                        4
                                    </td>
                                    <td>
                                        <%=sum[4] %>
                                    </td>
                                    <td>
                                        <%=tr[4]%>
                                    </td>
                                </tr>
                                <tr align="center" valign="middle" bgcolor="#FFFFFF">
                                    <td style="height: 15px">
                                        4
                                    </td>
                                    <td>
                                        <%=sum[5] %>
                                    </td>
                                    <td>
                                        <%=tr[5]%>
                                    </td>
                                </tr>
                                <tr align="center" valign="middle" bgcolor="#FFFFFF">
                                    <td style="height: 15px">
                                        4
                                    </td>
                                    <td>
                                        <%=sum[6] %>
                                    </td>
                                    <td>
                                        <%=tr[6]%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 137px; height: 45px;" valign="top" align="left">
                            <asp:Label ID="Label4" runat="server" Text="排序规则统计" BorderStyle="None" ForeColor="#009900"></asp:Label>
                            &nbsp
                            <table border="1" cellpadding="1" cellspacing="0" bordercolorlight="#006600" bordercolordark="#FFFFFF">
                                <tr align="center" valign="middle">
                                    <td style="width: 43px; height: 15px;">
                                        排序
                                    </td>
                                    <td style="width: 50px; height: 15px;">
                                        次数
                                    </td>
                                    <td style="width: 43px; height: 15px;">
                                        百分比
                                    </td>
                                </tr>
                                <tr align="center" valign="middle">
                                    <td style="width: 43px; height: 15px;">
                                        升序
                                    </td>
                                    <td style="width: 50px; height: 15px;">
                                        <%=qq%>
                                    </td>
                                    <td style="width: 43px; height: 15px;">
                                        <%=bbb[1] %>
                                    </td>
                                </tr>
                                <tr align="center" valign="middle">
                                    <td style="width: 43px">
                                        降序
                                    </td>
                                    <td style="width: 50px">
                                        <%=temp %>
                                    </td>
                                    <td style="width: 43px">
                                        <%=bbb[0] %>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
