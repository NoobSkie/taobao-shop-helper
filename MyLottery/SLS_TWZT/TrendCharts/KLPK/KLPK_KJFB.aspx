<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/KLPK/KLPK_KJFB.aspx.cs" inherits="KLPK_KLPK_KJFB" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>快乐扑克开奖号码分布图</title>
    <style type="text/css">

body {
	margin-left: 0px;
	margin-top: 20px;
	margin-right: 0px;
	margin-bottom: 0px;
	margin-left: 0px;
}
body,td,th {
	font-size: 12px;
	Font-Name: 宋体;
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

 <link rel="shortcut icon" href="../../favicon.ico" /></head>
<body>
    <form id="form2" runat="server">
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
                                        <td align="center" style="height: 24PX">
                                            <b>快乐扑克开奖号码分布图</b></td>
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
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" UseAccessibleHeader="False" ShowFooter="True" Width="100%" bordercolorlight="#808080" bordercolordark="#FFFFFF"
                                            OnRowCreated="GridView1_RowCreated" align="center" CellPadding="0">
                                            <Columns>
                                                <asp:BoundField DataField="Isuse" HeaderText="期  数" >
                                                 <ItemStyle Width="40px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="LotteryNumber" HeaderText="开奖号码" >
                                                 <ItemStyle Width="60px" Font-Bold="True" ForeColor="Blue" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="H_Z" HeaderText="H_Z" >
                                                 <ItemStyle Width="16px" BackColor="#00FFFF" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="K_D" HeaderText="K_D" >
                                                 <ItemStyle Width="16px" BackColor="#FFFF00" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Q_0" HeaderText="Q_0" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Q_1" HeaderText="Q_1" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Q_2" HeaderText="Q_2" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Q_3" HeaderText="Q_3" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Q_4" HeaderText="Q_4" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="Q_5" HeaderText="Q_5" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Q_6" HeaderText="Q_6" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Q_7" HeaderText="Q_7" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Q_8" HeaderText="Q_8" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Q_9" HeaderText="Q_9" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="Q_10" HeaderText="Q_10" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Q_11" HeaderText="Q_11" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Q_12" HeaderText="Q_12" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="B_0" HeaderText="B_0" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="B_1" HeaderText="B_1" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="B_2" HeaderText="B_2" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="B_3" HeaderText="B_3" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="B_4" HeaderText="B_4" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="B_5" HeaderText="B_5" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="B_6" HeaderText="B_6" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="B_7" HeaderText="B_7" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="B_8" HeaderText="B_8" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="B_9" HeaderText="B_9" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="B_10" HeaderText="B_10" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="B_11" HeaderText="B_11" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="B_12" HeaderText="B_12" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                               
                                                <asp:BoundField DataField="S_0" HeaderText="S_0" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="S_1" HeaderText="S_1" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="S_2" HeaderText="S_2" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="S_3" HeaderText="S_3" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="S_4" HeaderText="S_4" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="S_5" HeaderText="S_5" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="S_6" HeaderText="S_6" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="S_7" HeaderText="S_7" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="S_8" HeaderText="S_8" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="S_9" HeaderText="S_9" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="S_10" HeaderText="S_10" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="S_11" HeaderText="S_11" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="S_12" HeaderText="S_12" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="G_0" HeaderText="G_0" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="G_1" HeaderText="G_1" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="G_2" HeaderText="G_2" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="G_3" HeaderText="G_3" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="G_4" HeaderText="G_4" >
                                                  <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="G_5" HeaderText="G_5" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="G_6" HeaderText="G_6" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="G_7" HeaderText="G_7" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="G_8" HeaderText="G_8" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="G_9" HeaderText="G_9" >
                                                  <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="G_10" HeaderText="G_10" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="G_11" HeaderText="G_11" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="G_12" HeaderText="G_12" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="A" HeaderText="A" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BB" HeaderText="B" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="C" HeaderText="C" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="D" HeaderText="D" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="E" HeaderText="E" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="F" HeaderText="F" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="GG" HeaderText="G" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="H" HeaderText="H" >
                                                 <ItemStyle Width="15px" BackColor="#DDFFE6" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="D_N" HeaderText="D_N" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="D_0" HeaderText="D_0" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="D_1" HeaderText="D_1" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="D_2" HeaderText="D_2" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="D_3" HeaderText="D_3" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="D_4" HeaderText="D_4" >
                                                 <ItemStyle Width="15px" BackColor="#C1E7FF" ForeColor="#FFFFFF"/>
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
