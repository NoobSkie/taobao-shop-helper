<%@ page language="C#" autoeventwireup="true" CodeFile="~/TrendCharts/CJDLT/CJDLT_HZHeng.aspx.cs" inherits="CJDLT_CJDLT_HZHeng" enableEventValidation="false" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>超级大乐透和值走势图</title>
    <style type="text/css">

body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	margin-left: 0px;
	cursor: crosshair;
}
body,td,th {
	font-size: 14px;
	Font-family: 宋体;
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
	leftright.style.width=document.body.clientWidth;// + 2080
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

function autoSetIframeSize(){
  var id = "new_date";
  var height=document.getElementById("div_end").offsetTop;
  var width=document.body.scrollWidth;
  var obj= parent.document.getElementById(id);
  if (document.all){
	   window.resizeTo(width,height);
	   }
  else{
	obj.style.height=height+"px";
	obj.style.width=width+"px";}
}
//-->
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <table cellspacing="0" cellpadding="0" width="100%"  border="0">
                <tr align ="center">
                    <td style= "color: white; font-style: normal; background-color: #FF5122;
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
        <div style="text-align:left">
            &nbsp;&nbsp;&nbsp;
            <table border="0" cellpadding="0" cellspacing="0"  width="100%">
                <tbody>
                <tr>
                    <td align="left" style="background-color:#FFFFFF;">
                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                            <tbody>
                                <tr style="background-color: #EEEEEE">
                                    <td align="left" style ="height : 24px">
                                        <b>超级大乐透开奖号码和值[横向]分布图    [<a href="CJDLT_HZZong.aspx"><font color="#FF0000">点击切换到纵向分布图]</font></a></b> </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr style="background-color:#FFFFFF">
                    <td valign="top" style="border-color:#FFFFFF">
                        <table border="1" align="center" cellpadding="0" cellspacing="0" bordercolorlight="#CCCCCC" width="100%"
                             bordercolordark="#FFFFFF">
                           <tr align="center" valign="middle">
                                <td valign="top">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   Width="100%"
                                        UseAccessibleHeader="False" OnRowCreated="GridView1_RowCreated"
                                      FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  ShowFooter="True" Wbordercolorlight="#808080" bordercolordark="#FFFFFF" align="center" cellpadding="0" OnRowDataBound="GridView1_RowDataBound" >                                        
                                             <RowStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:BoundField DataField="Isuse" HeaderText="期 数"  ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="40px" BackColor="#F2F2F2" Font-Names="宋体"/>
                                             </asp:BoundField>   
                                            <asp:BoundField  DataField="LotteryNumber" HeaderText="开奖号码" ItemStyle-HorizontalAlign="Center" >
                                              <ItemStyle Width="120px" BackColor="#F2F2F2" ForeColor="#FF0000" Font-Bold="true" />
                                             </asp:BoundField>
<%--                                             <asp:TemplateField HeaderText="开奖号码">
                                             <ItemStyle Width="120px" BackColor="#F2F2F2" ForeColor="#FF0000" />
                                             <ItemTemplate>
                                                 <asp:Label ID="LotteryNumber" runat="server" Text='<%# Eval("LotteryNumber")%>'></asp:Label>
                                             </ItemTemplate>
                                             </asp:TemplateField>--%>
                                              <asp:BoundField DataField="A_15" HeaderText="A_15" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                                <asp:BoundField DataField="A_16" HeaderText="A_16" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                                <asp:BoundField DataField="A_17" HeaderText="A_17" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                                <asp:BoundField DataField="A_18" HeaderText="A_18" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                                <asp:BoundField DataField="A_19" HeaderText="A_19" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                                <asp:BoundField DataField="A_20" HeaderText="A_20" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_21" HeaderText="A_21" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_22" HeaderText="A_22" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_23" HeaderText="A_23" ItemStyle-HorizontalAlign="Center"> 
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_24" HeaderText="A_24" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_25" HeaderText="A_25" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2" />
                                             </asp:BoundField>
                                                <asp:BoundField DataField="A_26" HeaderText="A_26" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                                <asp:BoundField DataField="A_27" HeaderText="A_27" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                                <asp:BoundField DataField="A_28" HeaderText="A_28" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                                <asp:BoundField DataField="A_29" HeaderText="A_29" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                                <asp:BoundField DataField="A_30" HeaderText="A_30" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_31" HeaderText="A_31" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_32" HeaderText="A_32" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_33" HeaderText="A_33" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_34" HeaderText="A_34" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>                                           
                                                <asp:BoundField DataField="A_35" HeaderText="A_35" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                                <asp:BoundField DataField="A_36" HeaderText="A_36" ItemStyle-HorizontalAlign="Center">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                                <asp:BoundField DataField="A_37" HeaderText="A_37">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                                <asp:BoundField DataField="A_38" HeaderText="A_38">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                                <asp:BoundField DataField="A_39" HeaderText="A_39">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                                <asp:BoundField DataField="A_40" HeaderText="A_40">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2" />
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_41" HeaderText="A_41">
                                             <ItemStyle Width="10px"  BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_42" HeaderText="A_42">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2" />
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_43" HeaderText="A_43">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_44" HeaderText="A_44">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_45" HeaderText="A_45">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_46" HeaderText="A_46">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_47" HeaderText="A_47">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_48" HeaderText="A_48">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_49" HeaderText="A_49">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                             <asp:BoundField DataField="A_50" HeaderText="A_50">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_51" HeaderText="A_51">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                              <asp:BoundField DataField="A_52" HeaderText="A_52">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_53" HeaderText="A_53">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_54" HeaderText="A_54">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_55" HeaderText="A_55">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_56" HeaderText="A_56">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_57" HeaderText="A_57">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_58" HeaderText="A_58">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_59" HeaderText="A_59">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_60" HeaderText="A_60">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_61" HeaderText="A_61">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>                                     
                                             <asp:BoundField DataField="A_62" HeaderText="A_62">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_63" HeaderText="A_63">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_64" HeaderText="A_64">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_65" HeaderText="A_65">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_66" HeaderText="A_66">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_67" HeaderText="A_67">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_68" HeaderText="A_68">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_69" HeaderText="A_69">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_70" HeaderText="A_70">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_71" HeaderText="A_71">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                              <asp:BoundField DataField="A_72" HeaderText="A_72">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_73" HeaderText="A_73">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_74" HeaderText="A_74">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_75" HeaderText="A_75">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_76" HeaderText="A_76">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_77" HeaderText="A_77">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_78" HeaderText="A_78">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_79" HeaderText="A_79">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_80" HeaderText="A_80">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_81" HeaderText="A_81">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_82" HeaderText="A_82">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_83" HeaderText="A_83">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_84" HeaderText="A_84">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_85" HeaderText="A_85">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                              <asp:BoundField DataField="A_86" HeaderText="A_86">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_87" HeaderText="A_87">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_88" HeaderText="A_88">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_89" HeaderText="A_89">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_90" HeaderText="A_90">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_91" HeaderText="A_91">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_92" HeaderText="A_92">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_93" HeaderText="A_93">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_94" HeaderText="A_94">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_95" HeaderText="A_95">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>                
                                              <asp:BoundField DataField="A_96" HeaderText="A_96">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_97" HeaderText="A_97">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_98" HeaderText="A_98">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_99" HeaderText="A_99">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_100" HeaderText="A_100">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_101" HeaderText="A_101">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_102" HeaderText="A_102">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_103" HeaderText="A_103">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_104" HeaderText="A_104">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_105" HeaderText="A_105">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>   
                                              <asp:BoundField DataField="A_106" HeaderText="A_106">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_107" HeaderText="A_107">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_108" HeaderText="A_108">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_109" HeaderText="A_109">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_110" HeaderText="A_110">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_111" HeaderText="A_111">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_112" HeaderText="A_112">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_113" HeaderText="A_113">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_114" HeaderText="A_114">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_115" HeaderText="A_115">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>          
                                              <asp:BoundField DataField="A_116" HeaderText="A_116">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_117" HeaderText="A_117">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_118" HeaderText="A_118">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_119" HeaderText="A_119">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_120" HeaderText="A_120">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_121" HeaderText="A_121">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_122" HeaderText="A_122">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_123" HeaderText="A_123">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_124" HeaderText="A_124">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_125" HeaderText="A_125">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>   
                                              <asp:BoundField DataField="A_126" HeaderText="A_126">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_127" HeaderText="A_127">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_128" HeaderText="A_128">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_129" HeaderText="A_129">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_130" HeaderText="A_130">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_131" HeaderText="A_131">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_132" HeaderText="A_132">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_133" HeaderText="A_133">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_134" HeaderText="A_134">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_135" HeaderText="A_135">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>      
                                              <asp:BoundField DataField="A_136" HeaderText="A_136">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_137" HeaderText="A_137">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_138" HeaderText="A_138">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_139" HeaderText="A_139">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_140" HeaderText="A_140">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_141" HeaderText="A_141">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_142" HeaderText="A_142">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_143" HeaderText="A_143">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_144" HeaderText="A_144">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_145" HeaderText="A_145">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>  
                                              <asp:BoundField DataField="A_146" HeaderText="A_146">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_147" HeaderText="A_147">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_148" HeaderText="A_148">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_149" HeaderText="A_149">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2" />
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_150" HeaderText="A_150">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_151" HeaderText="A_151">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_152" HeaderText="A_152">
                                             <ItemStyle Width="10px"  BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_153" HeaderText="A_153">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_154" HeaderText="A_154">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_155" HeaderText="A_155">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>        
                                              <asp:BoundField DataField="A_156" HeaderText="A_156">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_157" HeaderText="A_157">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_158" HeaderText="A_158">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_159" HeaderText="A_159">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_160" HeaderText="A_160">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_161" HeaderText="A_161">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_162" HeaderText="A_162">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_163" HeaderText="A_163">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField> 
                                               <asp:BoundField DataField="A_164" HeaderText="A_164">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>
                                              <asp:BoundField DataField="A_165" HeaderText="A_165">
                                             <ItemStyle Width="10px" BackColor="#F2F2F2"/>
                                             </asp:BoundField>                                          
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>                         
                        </table>
                    </td>
                </tr>
                </tbody>
            </table>   <div id="div_end">       
        </div>
    </form>
</body>
</html>
                
                
                
                
                
                
   
