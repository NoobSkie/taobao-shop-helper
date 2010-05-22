<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/PL3/PL3_HZ.aspx.cs" inherits="View_PL3_HZ" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>排列三开奖号码和值分布图</title>
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
                    排列三&nbsp;&nbsp;和值分布图
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
                                <td align="center" style="height: 24PX">
                                    <b>排列三开奖号码和值分布图</b>
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
                                    align="center" CellPadding="0" OnRowCreated="GridView1_RowCreated">
                                    <Columns>
                                        <asp:BoundField DataField="Isuse" HeaderText="期　数">
                                            <ItemStyle Width='50px' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LotteryNumber" HeaderText="开奖号">
                                            <ItemStyle Width='30px' Font-Bold="True" ForeColor='Blue' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_Z" HeaderText="H_Z">
                                            <ItemStyle Width='20px' Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_100" HeaderText="H_100">
                                            <ItemStyle Width='2px' BackColor='#CCCCCC' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_0" HeaderText="H_0">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_1" HeaderText="H_1">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_2" HeaderText="H_2">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_3" HeaderText="H_3">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_4" HeaderText="H_4">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_5" HeaderText="H_5">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="H_6" DataField="H_6">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_101" HeaderText="H_101">
                                            <ItemStyle Width='2px' BackColor='#CCCCCC' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_7" HeaderText="H_7">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_8" HeaderText="H_8">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_9" HeaderText="H_9">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_10" HeaderText="H_10">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_11" HeaderText="H_11">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_12" HeaderText="H_12">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_13" HeaderText="H_13">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_102" HeaderText="H_102">
                                            <ItemStyle Width='2px' BackColor='#CCCCCC' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_14" HeaderText="H_14">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_15" HeaderText="H_15">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_16" HeaderText="H_16">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_17" HeaderText="H_17">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_18" HeaderText="H_18">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_19" HeaderText="H_19">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_20" HeaderText="H_20">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_103" HeaderText="H_103">
                                            <ItemStyle Width='2px' BackColor='#CCCCCC' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_21" HeaderText="H_21">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_22" HeaderText="H_22">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_23" HeaderText="H_23">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_24" HeaderText="H_24">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_25" HeaderText="H_25">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_26" HeaderText="H_26">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_27" HeaderText="H_27">
                                            <ItemStyle Width='12px' ForeColor='#D7D7D7' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_104" HeaderText="H_1O4">
                                            <ItemStyle Width='2px' BackColor='#CCCCCC' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Z_0" HeaderText="Z_0">
                                            <ItemStyle Width='12px' BackColor='#E3F4E3' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Z_1" HeaderText="Z_1">
                                            <ItemStyle Width='12px' BackColor='#E3F4E3' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Z_2" HeaderText="Z_2">
                                            <ItemStyle Width='12px' BackColor='#E3F4E3' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Z_3" HeaderText="Z_3">
                                            <ItemStyle Width='12px' BackColor='#E3F4E3' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Z_4" HeaderText="Z_4">
                                            <ItemStyle Width='12px' BackColor='#E3F4E3' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Z_5" HeaderText="Z_5">
                                            <ItemStyle Width='12px' BackColor='#E3F4E3' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Z_6" HeaderText="Z_6">
                                            <ItemStyle Width='12px' BackColor='#E3F4E3' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Z_7" HeaderText="Z_7">
                                            <ItemStyle Width='12px' BackColor='#E3F4E3' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Z_8" HeaderText="Z_8">
                                            <ItemStyle Width='12px' BackColor='#E3F4E3' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Z_9" HeaderText="Z_9">
                                            <ItemStyle Width='12px' BackColor='#E3F4E3' ForeColor='Silver' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_105" HeaderText="H_105">
                                            <ItemStyle Width='2px' BackColor='#CCCCCC' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="J_0" HeaderText="J_0">
                                            <ItemStyle Width='12px' ForeColor='White' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="O_0" HeaderText="O_0">
                                            <ItemStyle Width='12px' ForeColor='White' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_106" HeaderText="H_106">
                                            <ItemStyle Width='2px' BackColor='#CCCCCC' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="D_0" HeaderText="D_0">
                                            <ItemStyle Width='12px' ForeColor='White' />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="X_0" HeaderText="X_0">
                                            <ItemStyle Width='12px' ForeColor='White' />
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
