<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/PL5/PL5_HZ.aspx.cs" inherits="PL5_PL5_HZ" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>排列五开奖号码和值分布图</title>
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
                <td align="center" valign="middle" style="width: 300px; font-weight: bold; font-size: 18px;
                    color: #CC0000">
                    排列五&nbsp;&nbsp;和值分布图
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
                                    <b>排列五开奖号码和值分布图</b>
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
                                        <asp:BoundField DataField="Isuse" HeaderText="期  数">
                                            <ItemStyle Width="50" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LotteryNumber" HeaderText=" 开奖号码">
                                            <ItemStyle Width="50" Font-Bold="true" ForeColor="#0000FF" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="H_Z" HeaderText="和值">
                                            <ItemStyle Width="20" Font-Bold="true" ForeColor="#000000" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_10" HeaderText="B_10">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_11" HeaderText="B_11">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_12" HeaderText="B_12">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_13" HeaderText="B_13">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_14" HeaderText="B_14">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_15" HeaderText="B_15">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_16" HeaderText="B_16">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_17" HeaderText="B_17">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_18" HeaderText="B_18">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_19" HeaderText="B_19">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_20" HeaderText="B_20">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_21" HeaderText="B_21">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_22" HeaderText="B_22">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_23" HeaderText="B_23">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_24" HeaderText="B_24">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_25" HeaderText="B_25">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_26" HeaderText="B_26">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_27" HeaderText="B_27">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_28" HeaderText="B_28">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_29" HeaderText="B_29">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_30" HeaderText="B_30">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_31" HeaderText="B_31">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_32" HeaderText="B_32">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_33" HeaderText="B_33">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_34" HeaderText="B_34">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_35" HeaderText="B_35">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_36" HeaderText="B_36">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="B_37" HeaderText="B_37">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_0" HeaderText="S_0">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" BackColor="#E3F4E3" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_1" HeaderText="S_1">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" BackColor="#E3F4E3" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_2" HeaderText="S_2">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" BackColor="#E3F4E3" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_3" HeaderText="S_3">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" BackColor="#E3F4E3" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_4" HeaderText="S_4">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" BackColor="#E3F4E3" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_5" HeaderText="S_5">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" BackColor="#E3F4E3" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_6" HeaderText="S_6">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" BackColor="#E3F4E3" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_7" HeaderText="S_7">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" BackColor="#E3F4E3" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_8" HeaderText="S_8">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" BackColor="#E3F4E3" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="S_9" HeaderText="S_9">
                                            <ItemStyle Width="14" ForeColor="#C0C0C0" BackColor="#E3F4E3" />
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
