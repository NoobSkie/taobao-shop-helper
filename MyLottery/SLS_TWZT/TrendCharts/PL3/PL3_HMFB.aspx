<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/PL3/PL3_HMFB.aspx.cs" inherits="View_PL3_HMFB" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>排列三开奖号码大小分布图</title>
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

function Style(obj,statcolor,color)
{

 if(obj.style.backgroundColor=="")
 {
	obj.style.backgroundColor=statcolor;
	obj.style.color="#FFFFFF";
  }
	else
	{
	obj.style.backgroundColor="";
	obj.style.color=color;
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
                    排列三&nbsp;&nbsp;综合分布图
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
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td align="center" style="background-color: #FFFFFF;">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr style="background-color: #EEEEEE">
                                <td align="center" style="height: 24">
                                    <b>排列三开奖号码大小分布图</b>
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
                                    ShowFooter="True" Width="100%" bordercolorlight="#808080" bordercolordark="#FFFFFF"
                                    OnRowCreated="GridView1_RowCreated" align="center" CellPadding="0">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="序号" SortExpression="desc">
                                            <ItemStyle Width='25px' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Isuse" HeaderText="期数">
                                            <ItemStyle Width='60px' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LotteryNumber" HeaderText="开奖号">
                                            <ItemStyle Width='40px' BackColor='#CAD9E8' ForeColor='#EE0000' Font-Bold='True' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_0" HeaderText="B_0">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_1" HeaderText="B_1">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_2" HeaderText="B_2">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_3" HeaderText="B_3">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_4" HeaderText="B_4">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_5" HeaderText="B_5">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_6" HeaderText="B_6">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_7" HeaderText="B_7">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_8" HeaderText="B_8">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_9" HeaderText="B_9">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_0" HeaderText="S_0">
                                            <ItemStyle Width='13px' BackColor='#D0E6F7' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_1" HeaderText="S_1">
                                            <ItemStyle Width='13px' BackColor='#D0E6F7' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_2" HeaderText="S_2">
                                            <ItemStyle Width='13px' BackColor='#D0E6F7' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_3" HeaderText="S_3">
                                            <ItemStyle Width='13px' BackColor='#D0E6F7' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_4" HeaderText="S_4">
                                            <ItemStyle Width='13px' BackColor='#D0E6F7' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_5" HeaderText="S_5">
                                            <ItemStyle Width='13px' BackColor='#D0E6F7' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_6" HeaderText="S_6">
                                            <ItemStyle Width='13px' BackColor='#D0E6F7' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_7" HeaderText="S_7">
                                            <ItemStyle Width='13px' BackColor='#D0E6F7' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_8" HeaderText="S_8">
                                            <ItemStyle Width='13px' BackColor='#D0E6F7' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_9" HeaderText="S_9">
                                            <ItemStyle Width='13px' BackColor='#D0E6F7' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="G_0" HeaderText="G_0">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="G_1" HeaderText="G_1">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="G_2" HeaderText="G_2">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="G_3" HeaderText="G_3">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="G_4" HeaderText="G_4">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="G_5" HeaderText="G_5">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="G_6" HeaderText="G_6">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="G_7" HeaderText="G_7">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="G_8" HeaderText="G_8">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="G_9" HeaderText="G_9">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_Z" HeaderText="H_Z">
                                            <ItemStyle Width='15px' BackColor='#FFD7EB' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="J_O" HeaderText="J_O">
                                            <ItemStyle Width='20px' BackColor='#DFF0F0' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="D_X" HeaderText="D_X">
                                            <ItemStyle Width='20px' BackColor='#FFF1D9' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="K_0" HeaderText="K_0">
                                            <ItemStyle Width='13px' BackColor='#E6F2FB' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="K_1" HeaderText="K_1">
                                            <ItemStyle Width='13px' BackColor='#E6F2FB' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="K_2" HeaderText="K_2">
                                            <ItemStyle Width='13px' BackColor='#E6F2FB' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="K_3" HeaderText="K_3">
                                            <ItemStyle Width='13px' BackColor='#E6F2FB' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="K_4" HeaderText="K_4">
                                            <ItemStyle Width='13px' BackColor='#E6F2FB' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="K_5" HeaderText="K_5">
                                            <ItemStyle Width='13px' BackColor='#E6F2FB' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="K_6" HeaderText="K_6">
                                            <ItemStyle Width='13px' BackColor='#E6F2FB' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="K_7" HeaderText="K_7">
                                            <ItemStyle Width='13px' BackColor='#E6F2FB' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="K_8" HeaderText="K_8">
                                            <ItemStyle Width='13px' BackColor='#E6F2FB' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="K_9" HeaderText="K_9">
                                            <ItemStyle Width='13px' BackColor='#E6F2FB' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_0" HeaderText="H_0">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_1" HeaderText="H_1">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_2" HeaderText="H_2">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_3" HeaderText="H_3">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_4" HeaderText="H_4">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_5" HeaderText="H_5">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_6" HeaderText="H_6">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_7" HeaderText="H_7">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_8" HeaderText="H_8">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_9" HeaderText="H_9">
                                            <ItemStyle Width='13px' ForeColor='Silver' />
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
