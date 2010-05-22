<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/PL5/PL5_ZH.aspx.cs" inherits="PL5_PL5_ZH" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>排列五质合分布图</title>
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 20px;
            margin-right: 0px;
            margin-bottom: 0px;
            margin-left: 0px;
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
    <div>
        <table cellspacing="1" cellpadding="1" width="100%" border="0">
            <tr align="center">
                <td style="width: 120px; background-color: #0000ff; color: white; height: 6px;">
                    打开/关闭左栏
                </td>
                <td style="width: 410px; color: white; font-style: normal; background-color: #0000ff;
                    height: 6px;">
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
        </table>
    </div>
    <div style="text-align: center">
        &nbsp;&nbsp;&nbsp;
        <table border="0" cellpadding="0" cellspacing="0">
            <tbody>
                <tr>
                    <td align="center" style="background-color: #FFFFFF;">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr style="background-color: #EEEEEE">
                                    <td style="background-color: #EFEFEF; text-align: left; font-size: 12px; width: 500px;">
                                        <a href="<%= _Site.Url %>" target="_blank" style="text-decoration: none; font-size: 14px;
                                            padding-left: 10px;"><%=_Site.Name %>首页</a> <a href="<%= ResolveUrl("~/Lottery/Buy_PL5.aspx") %>"
                                                target="_blank" style="padding-left: 10px; text-decoration: none; color: Red;">排列五投注/合买</a>
                                        <a href="<%= ResolveUrl("~/WinQuery/64-0-0.aspx") %>" target="_blank" style="padding-left: 10px;
                                            text-decoration: none; color: Red;">排列五中奖查询</a>
                                    </td>
                                    <td align="center" style="height: 24PX">
                                        <b>排列五开奖号码质合分布图</b>
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
                                        ShowHeader="true" ShowFooter="True" Width="100%" bordercolorlight="#808080" bordercolordark="#FFFFFF"
                                        OnRowCreated="GridView1_RowCreated" align="center" CellPadding="0">
                                        <Columns>
                                            <asp:BoundField DataField="Isuse" HeaderText="期数">
                                                <ItemStyle Width="50" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LotteryNumber" HeaderText="开奖号码">
                                                <ItemStyle Width="50" Font-Bold="true" ForeColor="#0000FF" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="W_0" HeaderText="W_0">
                                                <ItemStyle Width="16" BackColor="#FCDFC5" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="W_1" HeaderText="W_1">
                                                <ItemStyle Width="16" BackColor="#FCDFC5" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="W_2" HeaderText="W_2">
                                                <ItemStyle Width="16" BackColor="#FCDFC5" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="W_3" HeaderText="W_3">
                                                <ItemStyle Width="16" BackColor="#FCDFC5" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="W_4" HeaderText="W_4">
                                                <ItemStyle Width="16" BackColor="#FCDFC5" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Q_0" HeaderText="Q_0">
                                                <ItemStyle Width="16" BackColor="#DDFFE6" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Q_1" HeaderText="Q_1">
                                                <ItemStyle Width="16" BackColor="#DDFFE6" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Q_2" HeaderText="Q_2">
                                                <ItemStyle Width="16" BackColor="#DDFFE6" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Q_3" HeaderText="Q_3">
                                                <ItemStyle Width="16" BackColor="#DDFFE6" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Q_4" HeaderText="Q_4">
                                                <ItemStyle Width="16" BackColor="#DDFFE6" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_0" HeaderText="B_0">
                                                <ItemStyle Width="16" BackColor="#C1E7FF" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_1" HeaderText="B_1">
                                                <ItemStyle Width="16" BackColor="#C1E7FF" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_2" HeaderText="B_2">
                                                <ItemStyle Width="16" BackColor="#C1E7FF" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_3" HeaderText="B_3">
                                                <ItemStyle Width="16" BackColor="#C1E7FF" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_4" HeaderText="B_4">
                                                <ItemStyle Width="16" BackColor="#C1E7FF" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="S_0" HeaderText="S_0">
                                                <ItemStyle Width="16" BackColor="#DDFFE6" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="S_1" HeaderText="S_1">
                                                <ItemStyle Width="16" BackColor="#DDFFE6" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="S_2" HeaderText="S_2">
                                                <ItemStyle Width="16" BackColor="#DDFFE6" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="S_3" HeaderText="S_3">
                                                <ItemStyle Width="16" BackColor="#DDFFE6" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="S_4" HeaderText="S_4">
                                                <ItemStyle Width="16" BackColor="#DDFFE6" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="G_0" HeaderText="G_0">
                                                <ItemStyle Width="16" BackColor="#C1E7FF" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="G_1" HeaderText="G_1">
                                                <ItemStyle Width="16" BackColor="#C1E7FF" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="G_2" HeaderText="G_2">
                                                <ItemStyle Width="16" BackColor="#C1E7FF" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="G_3" HeaderText="G_3">
                                                <ItemStyle Width="16" BackColor="#C1E7FF" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="G_4" HeaderText="G_4">
                                                <ItemStyle Width="16" BackColor="#C1E7FF" />
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
