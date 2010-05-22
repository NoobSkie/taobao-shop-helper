<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/CJDLT/CJDLT_LH.aspx.cs" inherits="CJDLT_CJDLT_LH" enableEventValidation="false" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>超级大乐透连号分布图</title>
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
	Font-Name: 宋体;
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
	leftright.style.width=document.body.clientWidth
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
        &nbsp;&nbsp;&nbsp;&nbsp;
        <table border="0" cellpadding="1" cellspacing="1" align="center">
            <tr align="center" valign="middle">
                <td>
                    <table border="0" cellpadding="1" cellspacing="1" style="background-color: #CCCCCC;">
                        <tbody>
                            <tr style="background-color: #EEEEEE">
                                <td align="center">
                                    <table cellspacing="0 " cellpadding="0" width="100%" border="0">
                                        <tbody>
                                            <tr style="background-color: #EEEEEE">
                                                <td height="24" align="center">
                                                    <b>超级大乐透连号分布图</b></td>
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
                                                    ShowFooter="True" Width="100%" bordercolorlight="#808080" bordercolordark="#FFFFFF" FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                    OnRowCreated="GridView1_RowCreated" align="center" CellPadding="0">
                                             <RowStyle HorizontalAlign="Center" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Isuse" HeaderText="期 数" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle Width="60px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="LotteryNumber" HeaderText="超级大乐透开奖号码" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle ForeColor="Red" Font-Bold="True" Width="145px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="L_0" HeaderText="连号数" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle Width="100px" ForeColor="Red" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="G_0" HeaderText="G_0">
                                                            <ItemStyle Width="15px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="G_1" HeaderText="G_1">
                                                            <ItemStyle Width="15px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="G_2" HeaderText="G_2">
                                                            <ItemStyle Width="15px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="G_3" HeaderText="G_3">
                                                            <ItemStyle Width="15px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="G_4" HeaderText="G_4">
                                                            <ItemStyle Width="15px" />
                                                        </asp:BoundField> 
                                                        <asp:BoundField DataField="G_5" HeaderText="G_5">
                                                            <ItemStyle Width="15px" />
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
                <td style ="width :30px">&nbsp;
                </td>          
                <td valign="bottom">
                    <table border="0" align="center" cellpadding="2" cellspacing="0" bordercolorlight="#999999"
                        bordercolordark="#FFFFFF">
                        <tr>
                            <td colspan="2" align="left">
                                <font color="#FF0000">近<%=tem %>期结果分析</font></td>
                        </tr>
                        <tr>
                            <td align="left">
                                <font color="#FF9900">连号出现统计</font>&nbsp
                                <table width="100%" border="1" cellpadding="1" cellspacing="0" bordercolorlight="#FF9900"
                                    bordercolordark="#FFFFFF" bgcolor="#FF9900">
                                    <tr align="center" valign="middle" bgcolor="#FFFFFF">
                                        <td style="height: 15px; width:45px;">
                                            连 号</td>
                                        <td style="width:45px">
                                            次   数</td>
                                        <td style="width:45px">
                                            百分比</td>
                                    </tr>
                                    <tr align="center" valign="middle" bgcolor="#FFFFFF">
                                        <td style="height: 15px">
                                            0</td>
                                        <td>
                                            <%=sum[0] %>
                                        </td>
                                        <td>
                                            <%=tr[0] %>
                                        </td>
                                    </tr>
                                    <tr align="center" valign="middle" bgcolor="#FFFFFF">
                                        <td style="height: 15px">
                                            1</td>
                                        <td>
                                            <%=sum[1] %>
                                        </td>
                                        <td>
                                            <%=tr[1] %>
                                        </td>
                                    </tr>
                                    <tr align="center" valign="middle" bgcolor="#FFFFFF">
                                        <td style="height: 15px">
                                            2</td>
                                        <td>
                                            <%=sum[2] %>
                                        </td>
                                        <td>
                                            <%=tr[2]%>
                                        </td>
                                    </tr>
                                    <tr align="center" valign="middle" bgcolor="#FFFFFF">
                                        <td style="height: 15px">
                                            3</td>
                                        <td>
                                            <%=sum[3] %>
                                        </td>
                                        <td>
                                            <%=tr[3]%>
                                        </td>
                                    </tr>
                                    <tr align="center" valign="middle" bgcolor="#FFFFFF">
                                        <td style="height: 15px">
                                            4</td>
                                        <td>
                                            <%=sum[4] %>
                                        </td>
                                        <td>
                                            <%=tr[4]%>
                                        </td>
                                    </tr>
                                    <tr align="center" valign="middle" bgcolor="#FFFFFF">
                                        <td style="height: 15px">
                                            5</td>
                                        <td>
                                            <%=sum[5] %>
                                        </td>
                                        <td>
                                            <%=tr[5]%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table> <div id="div_end"></div>
    </form>
</body>
</html>
