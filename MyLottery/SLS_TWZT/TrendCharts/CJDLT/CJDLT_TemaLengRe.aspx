<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/CJDLT/CJDLT_JimaLengRe.aspx.cs" inherits="CJDLT_CJDLT_JimaLengRe" enableEventValidation="false" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>超级大乐透后区全部号码全历史冷热图</title>
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            margin-left: 0px;
        }
        body, td, th
        {
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
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
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
        <table border="1" cellpadding="1" cellspacing="1" style="border-color: #FFFFFF">
            <tr>
                <td align="center" colspan="3" valign="middle" style="height: 10px; background-color: #F3F3F3;
                    border-bottom-style: outset; bordercolorlight: #808080; bordercolordark: #FFFFFF">
                    <b><font color="#0000FF" style="font-size: 18px">后区全部号码全历史冷热图</font></b>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0">
                        <tr>
                            <td style="width: 100px; background-color: #FFFFFF" rowspan="5">
                                &nbsp;
                            </td>
                            <td style="height: 3px;">
                            </td>
                            <td style="width: 100px; background-color: #FFFFFF" rowspan="5">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #FFFFFF">
                            <td valign="top" style="border-color: #FFFFFF;">
                                <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr align="center" valign="middle">
                                        <td valign="top">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" UseAccessibleHeader="False"
                                                OnRowCreated="GridView1_RowCreated" ShowFooter="True" Width="100%" bordercolorlight="#808080"
                                                FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ShowHeader="false"
                                                bordercolordark="#FFFFFF" align="center" CellPadding="0" Font-Size="12px">
                                             <RowStyle HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:BoundField DataField="LotteryNumber" HeaderText="出现次数" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle BackColor="#F7F7F7" Width='78px' />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="B_1" HeaderText="B_1" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle Width="28px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="B_2" HeaderText="B_2" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle Width="28px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="B_3" HeaderText="B_3" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle Width="28px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="B_4" HeaderText="B_4" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle Width="28px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="B_5" HeaderText="B_5" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle Width="28px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="B_6" HeaderText="B_6" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle Width="28px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="B_7" HeaderText="B_7" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle Width="28px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="B_8" HeaderText="B_8" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle Width="28px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="B_9" HeaderText="B_9" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle Width="28px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="B_10" HeaderText="B_10" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle Width="28px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="B_11" HeaderText="B_11" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle Width="28px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="B_12" HeaderText="B_12" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle Width="28px" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 1px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView2" runat="server" ShowHeader="false" OnRowCreated="GridView2_RowCreate"
                                                bordercolordark="#FFFFFF" align="center" CellPadding="0" bordercolorlight="#808080"
                                                CellSpacing="0" AutoGenerateColumns="False" Font-Size="12px">
                                                <Columns>
                                                    <asp:BoundField>
                                                        <ItemStyle Height="0px" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <RowStyle Height="0px" Width="0px" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
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
                            <td align="left" valign="top" style="font-size: 13px">
                                <font color="#FF0000">说明：</font>超级大乐透后区开奖号码冷热图是反映往期开奖号码01-12间每位号码出现次数展现图。从图表可以直观看出那些号码和一定期数内出现频率，依据此图可以大略估算那些号码为热码那些为冷码，对于长期投注的彩民可以考虑选择热码和冷码。<br>
                                本图上面部分显示以开奖号为序排列的，底图是以出现次数进行排列的。
                            </td>
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
        </div>
    </form>
</body>
</html>
