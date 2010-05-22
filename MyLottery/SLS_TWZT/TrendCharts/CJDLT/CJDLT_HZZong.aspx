<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/CJDLT/CJDLT_HZZong.aspx.cs" inherits="CJDLT_CJDLT_HZZong" enableEventValidation="false" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>超级大乐透和值走势图</title>
    <style type="text/css">
<!--
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
	text-align:center;
}
-->
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
                <tr align ="center">
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
        <div style="text-align: center" id="DIV1" runat="server">
            &nbsp;&nbsp;&nbsp;
            <table border="0" cellpadding="0" cellspacing="0" >
                <tbody>
                <tr>
                    <td align="center" style="background-color:#FFFFFF;">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr style="background-color: #EEEEEE">
                                    <td align="left" style ="height : 24PX">
                                        <b>超级大乐透开奖号码和值[纵向]分布图    [<a href="CJDLT_HZHeng.aspx"><font color="#FF0000">点击切换到横向分布图]</font></a></b> </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr style="background-color:#FFFFFF" align="center" valign="middle">
                    <td valign="top" style="border-color:#FFFFFF">
                        <table style="width:100%" border="1" align="center" cellpadding="0" cellspacing="0" bordercolorlight="#CCCCCC"
                             bordercolordark="#FFFFFF">
                           <tr align="center" valign="middle">
                                <td valign="top" align="center" >
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        UseAccessibleHeader="False" OnRowCreated="GridView1_RowCreated"
                                     FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"   ShowFooter="false" Width="100%" bordercolorlight="#808080" bordercolordark="#FFFFFF" align="center" cellpadding="0" cellspacing="0" HorizontalAlign="Center">                                        
                                             <RowStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:BoundField DataField="Isuse" HeaderText="期   数" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="45px" Font-Names="宋体" BackColor="#F2F2F2" HorizontalAlign="Center"/>
                                             </asp:BoundField>
                                            <asp:BoundField DataField="LotteryNumber" HeaderText="开奖号码" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="160px" Font-Bold="True" BackColor="#F2F2F2" Font-Names="宋体" ForeColor="Blue" HorizontalAlign="Center"/>
                                             </asp:BoundField>
                                            <asp:BoundField DataField="H_Z" HeaderText="H_Z" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle  BackColor="#E1EFFF" HorizontalAlign="Center"/>
                                             </asp:BoundField>
                                            <asp:BoundField DataField="J_Z" HeaderText="J_Z" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle BackColor="#E8F5FF"  HorizontalAlign="Center"/>
                                             </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>                         
                        </table>
                    </td>
                </tr>
                </tbody>
            </table>    <div id="div_end"></div>      
        </div>
    </form>
</body>
</html>
                
                
                
                
                
                
   