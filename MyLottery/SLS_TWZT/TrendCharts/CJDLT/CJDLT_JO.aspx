<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/CJDLT/CJDLT_JO.aspx.cs" inherits="CJDLT_CJDLT_JO" enableEventValidation="false" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>超级大乐透奇偶分布图</title>
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
        <div style="text-align: center">
            &nbsp;&nbsp;&nbsp;
            <table border="0" cellpadding="1" cellspacing="1" style="background-color: #CCCCCC;">
                <tr style="background-color: #EEEEEE">
                    <td align="center" valign="middle" colspan="3" style="height: 30px">
                        <b>超级大乐透奇偶分布图</b></td>
                </tr>
                <tr style="background-color: #FFFFFF">
                    <td valign="top" style="border-color: #FFFFFF">
                        <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
                            <tr align="center" valign="middle">
                                <td valign="top" colspan="11" style="height: 160px">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" UseAccessibleHeader="False"
                                        OnRowCreated="GridView1_RowCreated" Width="100%" bordercolorlight="#808080" FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        bordercolordark="#FFFFFF" align="center" CellPadding="0">
                                             <RowStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:BoundField DataField="Isuse" HeaderText="期数" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="28" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LotteryNumber_J" HeaderText="LotteryNumber_J" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="100" ForeColor="#FF0033" Font-Bold="true" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LotteryNumber_T" HeaderText="LotteryNumber_T" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="50" ForeColor="#0000D5" Font-Bold="true" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="W_1" HeaderText="W_1" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="50" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="W_2" HeaderText="W_2" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="50" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="W_3" HeaderText="W_3" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="50" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="W_4" HeaderText="W_4" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="50" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="W_5" HeaderText="W_5" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="50" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="J" HeaderText="J" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="26" BackColor="#EDFFD7" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="O" HeaderText="O" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="26" BackColor="#EDFFD7" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="J_O" HeaderText="J_O" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="30" BackColor="#EDFFD7"  ForeColor="#FF0033"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="J_O_C" HeaderText="J_O_C" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="26" BackColor="#EDFFD7" ForeColor="#0000D5"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="J_T" HeaderText="J_T" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="26" BackColor="#EDFFD7" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="O_T" HeaderText="O_T" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="26" BackColor="#EDFFD7" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>  <br />
            <table width="660" border="0" align="center" cellpadding="0" cellspacing="0">                <tr>
                    <td height="6" style="width: 6px">
                        <img src="../../images/tree/jbg1[1].gif" width="6" height="6"></td>
                    <td background="../../images/tree/jbg2[1].gif">
                    </td>
                    <td width="6" height="6">
                        <img src="../../images/tree/jbg3[1].gif" width="6" height="6"></td>
                </tr>
                <tr>
                    <td height="87" background="../../images/tree/jbg4[1].gif" style="width: 6px">
                    </td>
<td background="../../images/bg009.gif">
                        <table width="100%" border="0" cellspacing="0" cellpadding="5">
                   <tr>
         <td align="left" valign="top"><font color="#FF0000">说明：</font>超级大乐透奇偶分布是对每一期开奖号码所区奇偶数的分析,依据往期开奖的奇偶关系,可以看出一定期数内所曾现出的S、K、X型图分布规律，对于有经验的老彩民可以根据往期奇偶比来决定下一期可能会出的偶然比来选择缩水方式。<br>
              　　本图是针对每一期开奖号码定位奇偶分析，奇偶出现次数统计，奇偶比、奇偶差值、和特码奇偶。</td>
       </tr>
                        </table>
                    </td>
                    <td background="../../images/tree/jbg5[1].gif">
                    </td>
                </tr>
                <tr>
                    <td style="width: 6px; height: 6px" background="../../images/tree/jbg6[1].gif"></td>
                    <td background="../../images/tree/jbg7[1].gif">
                    </td>
                    <td style="height: 6px" background="../../images/tree/jbg8[1].gif"></td>
                </tr>

            </table>
<div id="div_end">
        </div>
    </form>
</body>
</html>
