<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/PL3/PL3_KD.aspx.cs" inherits="View_PL3_KD" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>排列三跨度分布图</title>
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

    <script type="text/javascript" language="javascript">

        function Style(obj, statcolor, color) {

            if (obj.style.backgroundColor == "") {
                obj.style.backgroundColor = statcolor;
                obj.style.color = "#FFFFFF";
            }
            else {
                obj.style.backgroundColor = "";
                obj.style.color = color;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 100%; height: 40px; background-image: url(../Images/bg11111.jpg);"
        cellspacing="0" cellpadding="0">
        <tbody>
            <tr>
                <td style="background-color: #EFEFEF; text-align: left; font-size: 12px; width: 500px;">
                    <a href="<%= _Site.Url %>" target="_blank" style="text-decoration: none; font-size: 14px;
                        padding-left: 10px;"><%=_Site.Name %>首页</a> <a href="<%= ResolveUrl("~/Lottery/Buy_PL3.aspx") %>"
                            target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">排列三投注/合买</a>
                    <a href="<%= ResolveUrl("~/WinQuery/63-0-0.aspx") %>" target="_blank" style="padding-left: 10px;
                        text-decoration: none; color: Red;">排列三中奖查询</a>
                </td>
                <td align="center" valign="middle" style="width: 300px; font-weight: bold; font-size: 18px;
                    color: #CC0000">
                    排列三&nbsp;&nbsp;跨度分布图
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
    <table border="0" cellpadding="1" cellspacing="1" style="background-color: #CCCCCC;
        width: 100%;">
        <tbody>
            <tr style="background-color: #EEEEEE">
                <td align="center">
                    <table cellspacing="0 " cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr style="background-color: #EEEEEE">
                                <td height="24" align="center">
                                    <b>排列三跨度分布图</b>
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
                                    ShowFooter="True" Width="100%" bordercolorlight="#808080" OnRowCreated="GridView1_RowCreated"
                                    bordercolordark="#FFFFFF" align="center" CellPadding="0">
                                    <Columns>
                                        <asp:BoundField DataField="Isuse" HeaderText="期数">
                                            <ItemStyle Width="60" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="开奖号码" DataField="LotteryNumber">
                                            <ItemStyle Width="60" Font-Bold="true" ForeColor="#0000FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="K" HeaderText="跨度">
                                            <ItemStyle Width="25" Font-Bold="true" ForeColor="#000000" BackColor="#E4F1D8" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_0" HeaderText="0">
                                            <ItemStyle Width="15" ForeColor="#C0C0C0" BackColor="#E1EFFF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_1" HeaderText="1">
                                            <ItemStyle Width="15" ForeColor="#C0C0C0" BackColor="#E1EFFF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_2" HeaderText="2">
                                            <ItemStyle Width="15" ForeColor="#C0C0C0" BackColor="#E1EFFF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_3" HeaderText="3">
                                            <ItemStyle Width="15" ForeColor="#C0C0C0" BackColor="#E1EFFF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_4" HeaderText="4">
                                            <ItemStyle Width="15" ForeColor="#C0C0C0" BackColor="#E1EFFF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_5" HeaderText="5">
                                            <ItemStyle Width="15" ForeColor="#C0C0C0" BackColor="#E1EFFF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_6" HeaderText="6">
                                            <ItemStyle Width="15" ForeColor="#C0C0C0" BackColor="#E1EFFF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_7" HeaderText="7">
                                            <ItemStyle Width="15" ForeColor="#C0C0C0" BackColor="#E1EFFF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_8" HeaderText="8">
                                            <ItemStyle Width="15" ForeColor="#C0C0C0" BackColor="#E1EFFF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="C_9" HeaderText="9">
                                            <ItemStyle Width="15" ForeColor="#C0C0C0" BackColor="#E1EFFF" />
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
    </form>
</body>
</html>
