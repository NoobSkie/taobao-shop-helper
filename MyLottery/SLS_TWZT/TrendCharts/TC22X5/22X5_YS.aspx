<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/TC22X5/22X5_YS.aspx.cs" inherits="TC22X5_22X5_YS" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>22选5余数走势图</title>
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
            font-family: 宋体;
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
                    22选5&nbsp;&nbsp;余数分布图
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
    <table border="0" cellpadding="1" cellspacing="1" style="background-color: #CCCCCC; width:100%">
        <tr style="background-color: #EEEEEE">
            <td align="center" valign="middle" colspan="3" style="height: 24">
                <b>22选5余数分布图</b>
            </td>
        </tr>
        <tr style="background-color: #FFFFFF">
            <td valign="top" style="border-color: #ffffff">
                <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
                    <tr align="center" valign="middle">
                        <td valign="top">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" UseAccessibleHeader="False"
                                OnRowCreated="GridView1_RowCreated" ShowFooter="True" Width="100%" bordercolorlight="#808080"
                                bordercolordark="#FFFFFF" CellPadding="0">
                                <Columns>
                                    <asp:BoundField DataField="Isuse" HeaderText="期数">
                                        <ItemStyle Width="28" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LotteryNumber" HeaderText="开奖号码">
                                        <ItemStyle Width="100" ForeColor="#FF0000" Font-Bold="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_11_0" HeaderText="B_11_0">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_11_1" HeaderText="B_11_1">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_11_2" HeaderText="B_11_2">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_11_3" HeaderText="B_11_3">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_11_4" HeaderText="B_11_4">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_11_5" HeaderText="B_11_5">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_11_6" HeaderText="B_11_6">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_11_7" HeaderText="B_11_7">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_11_8" HeaderText="B_11_8">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_11_9" HeaderText="B_11_9">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_11_10" HeaderText="B_11_10">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_9_0" HeaderText="B_9_0">
                                        <ItemStyle Width="16" BackColor="#EDFFD7" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_9_1" HeaderText="B_9_1">
                                        <ItemStyle Width="16" BackColor="#EDFFD7" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_9_2" HeaderText="B_9_2">
                                        <ItemStyle Width="16" BackColor="#EDFFD7" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_9_3" HeaderText="B_9_3">
                                        <ItemStyle Width="16" BackColor="#EDFFD7" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_9_4" HeaderText="B_9_4">
                                        <ItemStyle Width="16" BackColor="#EDFFD7" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_9_5" HeaderText="B_9_5">
                                        <ItemStyle Width="16" BackColor="#EDFFD7" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_9_6" HeaderText="B_9_6">
                                        <ItemStyle Width="16" BackColor="#EDFFD7" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_9_7" HeaderText="B_9_7">
                                        <ItemStyle Width="16" BackColor="#EDFFD7" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_9_8" HeaderText="B_9_8">
                                        <ItemStyle Width="16" BackColor="#EDFFD7" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_5_0" HeaderText="B_5_0">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_5_1" HeaderText="B_5_1">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_5_2" HeaderText="B_5_2">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_5_3" HeaderText="B_5_3">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_5_4" HeaderText="B_5_4">
                                        <ItemStyle Width="16" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_3_0" HeaderText="B_3_0">
                                        <ItemStyle Width="16" BackColor="#D2E1F0" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_3_1" HeaderText="B_3_1">
                                        <ItemStyle Width="16" BackColor="#D2E1F0" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="B_3_2" HeaderText="B_3_2">
                                        <ItemStyle Width="16" BackColor="#D2E1F0" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>

        </tr>
    </table>
    </form>
</body>
</html>
