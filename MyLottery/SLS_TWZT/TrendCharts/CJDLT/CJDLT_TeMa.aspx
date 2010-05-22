<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/CJDLT/CJDLT_TeMa.aspx.cs" inherits="CJDLT_CJDLT_TeMa" enableEventValidation="false" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>超级大乐透后区号码分布图</title>
    <style type="text/css">

body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	margin-left: 0px;
}
body,td,th {
	font-size: 14px;
	font-family: 宋体;
}
</style>
   <script type="text/javascript" language="javascript">
<!--
var jsstr = ""
+ "<img src=\"about:blank\" id=\"leftright\" style=\"width:expression(document.body.clientWidth);height:1px;position:absolute;left:0;top:0;background-color:#6699cc;z-index:100;\" \/>\n"
+ "<img src=\"about:blank\" id=\"topdown\" style=\"height:expression(document.body.clientHeight);width:1px;position:absolute;left:0;top:0;background-color:#6699cc;z-index:100;\" \/>\n"
document.writeln(jsstr);

function followmouse(){
	leftright.style.top = window.event.y-1+document.body.scrollTop
	topdown.style.left = window.event.x-1+document.body.scrollLeft
	topdown.style.height= document.getElementById("div_end").offsetTop;// + 800;
	leftright.style.width=document.body.clientWidth;// + 100
}
document.onmousemove=followmouse

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
//-->
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <table cellspacing="0" cellpadding="0" width="100%"  border="0">
                <tr align="center">
                    <td style="width: 100%; color: white; font-style: normal; background-color: #FF5122;
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
            <table border="0" cellpadding="1" cellspacing="1" style="background-color: #CCCCCC;">
                <tr style="background-color: #EEEEEE">
                    <td align="center" valign="middle" colspan="3" style="height: 30px">
                        <b>超级大乐透后区号码分布图</b></td>
                </tr>
                <tr style="background-color: #FFFFFF">
                    <td style="width: 18px; background-color: #F2F2F2">
                        &nbsp</td>
                    <td valign="top" style="border-color: #FFFFFF">
                        <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
                            <tr align="center" valign="middle">
                                <td valign="top" colspan="11" style="height: 160px">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" UseAccessibleHeader="False"
                                        OnRowCreated="GridView1_RowCreated" ShowFooter="True" Width="100%" bordercolorlight="#808080" FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        bordercolordark="#FFFFFF" align="center" CellPadding="0">
                                             <RowStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:BoundField HeaderText="序号" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="28" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Isuse" HeaderText="期数" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="28" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_1" HeaderText="B_1">
                                                <ItemStyle Width="16" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_2" HeaderText="B_2">
                                                <ItemStyle Width="16" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_3" HeaderText="B_3">
                                                <ItemStyle Width="16" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_4" HeaderText="B_4">
                                                <ItemStyle Width="16" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_5" HeaderText="B_5">
                                                <ItemStyle Width="16" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_6" HeaderText="B_6">
                                                <ItemStyle Width="16" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_7" HeaderText="B_7">
                                                <ItemStyle Width="16" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_8" HeaderText="B_8">
                                                <ItemStyle Width="16" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_9" HeaderText="B_9">
                                                <ItemStyle Width="16" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_10" HeaderText="B_10">
                                                <ItemStyle Width="16" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_11" HeaderText="B_11">
                                                <ItemStyle Width="16" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B_12" HeaderText="B_12">
                                                <ItemStyle Width="16" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="J" HeaderText="J" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="26" BackColor="#FFF9E1" ForeColor="red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="O" HeaderText="O" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="26" BackColor="#FFF7D2"  ForeColor="red"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Q_1" HeaderText="Q_1" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="30" BackColor="#ECFEE2" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Q_2" HeaderText="Q_2" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="30" BackColor="#ECFEE2" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Q_3" HeaderText="Q_3" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="30" BackColor="#ECFEE2" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Q_4" HeaderText="Q_4" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="30" BackColor="#ECFEE2" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 18px; background-color: #F2F2F2">
                        &nbsp</td>
                </tr>
                <tr>
                    <td style="background-color: #F2F2F2">
                        &nbsp;</td>
                    <td style="height: 28px; background-color: #F2F2F2">
                        &nbsp;&nbsp;&nbsp <font color="#FF0000" font-bold="true">注</font>:区域分布一区为开奖数字的01~03，二区为：04~06，三区为：07~09，四区为：10~12。
                    </td>
                    <td style="background-color: #F2F2F2">
                        &nbsp;</td>
                </tr>
            </table> <div id="div_end">
        </div>
    </form>
</body>
</html>
