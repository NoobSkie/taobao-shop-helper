<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/OnlinePay/Alipay02/Default.aspx.cs" inherits="Home_Room_OnlinePay_Alipay02_Default" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>支付宝在线充值-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %></title>
    <meta name="keywords" content="支付宝在线充值" />
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <link href="../../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../../Style/main.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        A
        {
            text-transform: none;
            text-decoration: none;
        }
        A:hover
        {
            text-decoration: underline;
        }
    </style>
</head><link rel="shortcut icon" href="../../../../favicon.ico"/>
<body>
    <form id="Form1" name="form1" runat="server">
    </form>
    <form id="Form2" name="form2" action="Send.aspx" method="post">
    <div>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9FC8EA">
               <tr>
                 <td valign="top" bgcolor="#FFFFFF"><table width="100%" border="0" cellpadding="0" cellspacing="0" background="../../images/bg_blue_30.jpg">
                     <tr>
                       <td height="30"><table width="738" border="0" cellspacing="0" cellpadding="0">
                           <tr>
                             <td width="40" height="30" align="center"><img src="../../images/jiantou_5.gif" width="12" height="8" /></td>
                             <td class="blue_num">我的资料 &gt; 购买电话投注卡</td>
                           </tr>
                       </table></td>
                     </tr>
                   </table>
                     <table width="100%" border="0" cellspacing="0" cellpadding="5">
                       <tr>
                         <td valign="top"><div style="height:10px;"></div>
                             <table width="100%" border="0" cellspacing="0" cellpadding="0">
                               <tr>
                                 <td height="30" bgcolor="#f5f5f5" class="red14" style="padding-left:20px;">1、请选择充值金额</td>
                               </tr>
                               <tr>
                                 <td height="1" bgcolor="#CCCCCC"></td>
                               </tr>
                             </table>
                           <div style="height:10px;"></div>
                           <table width="690" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center">
                                        <img src="images/zhifu_pic_50.jpg" width="212" height="121" />
                                    </td>
                                    <td align="center">
                                        <img src="images/zhifu_pic_100.jpg" width="212" height="121" />
                                    </td>
                                    <td align="center">
                                        <img src="images/zhifu_pic_300.jpg" width="212" height="121" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" height="25">
                                        <input type="radio" name="CardType" value="50" checked="checked" />
                                    </td>
                                    <td align="center">
                                        <input type="radio" name="CardType" value="100" />
                                    </td>
                                    <td align="center">
                                        <input type="radio" name="CardType" value="300" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <img src="images/zhifu_pic_500.jpg" width="212" height="121" />
                                    </td>
                                    <td align="center">
                                        <img src="images/zhifu_pic_20.jpg" width="212" height="121" />
                                    </td>
                                    <td align="center">
                                        <img src="images/zhifu_pic_2.jpg" width="212" height="121" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" height="25">
                                        <input type="radio" name="CardType" value="500" />
                                    </td>
                                    <td align="center">
                                        <input type="radio" name="CardType" value="10" />
                                    </td>
                                    <td align="center">
                                        <input type="radio" name="CardType" value="2" />
                                    </td>
                                </tr>
                            </table>
                           <div style="height:10px;"></div>
                           <table width="100%" border="0" cellspacing="0" cellpadding="0">
                               <tr>
                                 <td width="30%" height="30" bgcolor="#f5f5f5" class="red14" style="padding-left:20px;">2、请输入购买电话卡的张数：</td>
                                 <td width="8%" bgcolor="#f5f5f5" class="red14" ><label>
                                   <input type="text" name="Num" id="Num" class="in_text_hui" value="1"  size="5" maxlength="4" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" />
                                 </label></td>
                                 <td width="62%" bgcolor="#f5f5f5" class="hui" >注：如果需充值10000,则选择500面值，输入张数20张。</td>
                               </tr>
                               <tr>
                                 <td height="1" colspan="3" bgcolor="#CCCCCC"></td>
                               </tr>
                             </table>
                           <table width="100%" border="0" cellspacing="0" cellpadding="0">
                               <tr>
                                 <td height="36" align="center" style="padding:20px ;">
                                 <input type="image" name="imageField" src="images/zhifu_button.jpg" />
                                 </td>
                               </tr>
                             </table>
                           <div style="height:1px; background-color:#CCCCCC;"></div>
                           <div style="height:10px;"></div>
                           <table width="700" border="0" cellspacing="0" cellpadding="0">
                               <tr>
                                 <td width="75" align="center"><img src="images/icon_12.gif" width="34" height="34" /></td>
                                 <td width="625" height="25" valign="middle" class="red">提醒：“电话投注卡”一经购买，不支持退款，提款。 中奖金额上海福彩中心直接返奖到会员支付宝帐户。</td>
                               </tr>
                             </table>
                           <div style="height:20px;"></div></td>
                       </tr>
                   </table></td>
               </tr>
             </table>
     </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
