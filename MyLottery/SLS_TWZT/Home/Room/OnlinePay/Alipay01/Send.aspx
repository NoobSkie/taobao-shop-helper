<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/OnlinePay/Alipay01/Send.aspx.cs"inherits="Home_Room_OnlinePay_Alipay01_Send" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网上支付，手机卡充值-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
   <meta name="keywords" content="<%=_Site.Name %>提供网银充值，卡密充值，支付宝支付，财付通支付" />
    <link href="../../Style/css.css" type="text/css" rel="stylesheet" />
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
        .STYLE12
        {
            color: #FF0000;
        }
    </style>

    <script type="text/javascript">
		<!--
        function PayMoneyOnPress() {
            if (window.event.keyCode < 48 || window.event.keyCode > 57)
                return false;
            return true;
        }
        
        function SetMoneyValue(e) {
            document.getElementById("RealPayMoneyValue").value = e.value;
            document.getElementById("btnHiddenClick").click();
        }
		-->
    </script>
    <link rel="shortcut icon" href="../../../../favicon.ico"/>
</head>
<body>
    <form id="Form1" name="Form1" method="post" runat="server">
        <asp:HiddenField runat="server" ID="RealPayMoneyValue" />
        <asp:Button ID="btnHiddenClick" runat="server" onclick="btnHiddenClick_Click" style="display:none;"/>
         <div id="user">
            <div id="user_r">
                <table width="778" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table width="500" border="0" align="right" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="77" height="22" background="../../images/user_bt_bg_1.jpg" class="blue12"
                                        style="text-indent: 22px;">
                                        <a href="../../MyIcaile.aspx" onclick="if(this.href == location.href){this.target = '_self';}else{this.target = '_top'}">
                                            用户中心</a>
                                    </td>
                                    <td width="5">
                                        &nbsp;
                                    </td>
                                    <td width="77" height="22" background="../../images/user_bt_bg_1.jpg" class="blue12"
                                        style="text-indent: 22px;">
                                        <a href="../../../../Default.aspx" onclick="if(this.href == location.href){this.target = '_self';}else{this.target = '_top'}">购买彩票</a>
                                    </td>
                                    <td width="5">
                                        &nbsp;
                                    </td>
                                    <td width="77" align="center" background="../../images/user_bt_bg_2.jpg" class="blue12">
                                        <a href="http://club.alipay.com/list_forum-460-.htm?src=yy_wow_finance_daohang2_dhcp" target="_blank">彩票社区</a>
                                    </td>
                                    <td width="5">
                                        &nbsp;
                                    </td>
                                    <td width="77" align="center" background="../../images/user_bt_bg_2.jpg" class="blue12">
                                        <a href="http://wow.alipay.com/finance/activity/caipiao/index.html" target="_blank">
                                            开奖查询</a>
                                    </td>
                                    <td width="5">
                                        &nbsp;
                                    </td>
                                    <td width="77" align="center" background="../../images/user_bt_bg_2.jpg" class="blue12">
                                        <a href="http://www.icaile.com/Home/Room/TrendChart.aspx" target="_blank">图表走势</a>
                                    </td>
                                    <td width="5">
                                        &nbsp;
                                    </td>
                                    <td width="77" align="center" background="../../images/user_bt_bg_2.jpg" class="blue12">
                                        <a href="../../Help/index.htm" target="_blank">帮助中心</a>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                            <hr color="#CCCCCC" style="height: 1px;" />
                        </td>
                    </tr>
                </table>
                <table width="778" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="25" height="25" align="left" class="black12" style="padding-left: 10px;">
                            <img src="../../images/user_icon_man.gif" width="19" height="15" /></span>
                        </td>
                        <td align="left" class="black12">
                            <a href="../../MyIcaile.aspx" onclick="if(this.href == location.href){this.target = '_self';}else{this.target = '_top'}"> 用户中心</a> &gt;
                            <a href="../Default.aspx" target="_self">我的账户</a> &gt; 我要存款
                        </td>
                        <td width="11">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="2" colspan="3" bgcolor="#cc0000">
                        </td>
                    </tr>
                </table>
                <table width="778" border="0" cellspacing="0" cellpadding="0" background="../../images/zfb_left_bg_2.jpg"
                    style="margin-top: 10px;">
                    <tr>
                        <td width="10" height="33" align="left">
                            &nbsp;
                        </td>
                        <td width="85" align="center" background="../../images/zfb_left_qh_1.jpg" class="white14">
                            我要存款
                        </td>
                        <td width="6">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table width="778" border="0" cellpadding="0" cellspacing="0" bgcolor="#C0DBF9">
                    <tr>
                        <td height="30" colspan="2" align="left" bgcolor="#E9F1F8" class="black12" style="padding-left: 20px;">
                            您好，<span class="red12"><%=UserName%></span>！您当前帐户余额为：￥<span class="red12"><%= Balance%> </span>元
                        </td>
                    </tr>
                    <tr>
                        <td height="10" colspan="2" align="right" bgcolor="#FFFFFF" class="black12">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="93" height="30" align="right" bgcolor="#FFFFFF" class="black12">
                            <span class="red12">*</span>充值金额：
                        </td>
                        <td width="685" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr bgcolor="#C0DBF9">
                                    <td width="23%" align="left" bgcolor="#FFFFFF" class="black12">
                                        <label>
                                            
                                            <asp:TextBox ID="PayMoney" runat="server" MaxLength="8" CssClass="in_text" onkeypress="return PayMoneyOnPress();" onblur="SetMoneyValue(this)" ></asp:TextBox>
                    
                                        </label>
                                    </td>
                                    <td width="77%" align="left" bgcolor="#FFFFFF" class="black12">
                                        元，（<span class="red12">网上充值免手续费</span>，存入金额最少2元）
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" align="right" valign="top" bgcolor="#FFFFFF" class="black12" style="padding-top: 10px;">
                            <span class="red12">*</span>充值方式：
                        </td>
                        <td height="30" align="left" valign="top" bgcolor="#FFFFFF" class="black12" style="padding: 10px 0px 10px 10px;">
                            <table width="675" border="0" align="left" cellpadding="0" cellspacing="1" bgcolor="#C0DBF9">
                                <tr>
                                    <td width="121" bgcolor="#FFFFFF" style="padding: 10px;">
                                        <asp:HyperLink ID="hl1" runat="server" Target="_blank"><img src="images/logo.jpg" border="0" /></asp:HyperLink>
                                    </td>
                                    <td width="340" bgcolor="#FFFFFF" class="gray12" style="padding: 10px;">
                                        <span class="STYLE2">
                                       
                                阿里巴巴旗下支付宝在线支付，支持国内16家银行卡及<span class="STYLE12">信用卡充值</span>，支付宝帐户余额充值。快捷方便，安全性高。</span>
                                    </td>
                                    <td width="190" align="center" bgcolor="#FFFFFF" class="blue12" style="padding: 8px 0px 8px 0px;">
                                        <asp:HyperLink ID="hl2" runat="server" Target="_blank">
                                            <img src="../../images/bank_logo/bt_bank_zfb.jpg" width="170" height="28" border="0" />
                                        </asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF" style="padding: 10px;">
                                        <img src="Images/img_11.gif" border="0" alt="本支付通过支付宝接口支付" />
                                    </td>
                                    <td bgcolor="#FFFFFF" class="gray12" style="padding: 10px;">
                                        <span class="STYLE2">
                                       
                                如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。 </span>
                                    </td>
                                    <td width="190" align="center" bgcolor="#FFFFFF" class="blue12" style="padding: 8px 0px 8px 0px;">
                                        <asp:HyperLink ID="hl3" runat="server" Target="_blank">
                                            <img src="../../images/bank_logo/bt_bank_gsyh.jpg" width="170" height="28" border="0" />
                                        </asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF" style="padding: 10px;">
                                        <img src="Images/img_13.gif" border="0" alt="本支付通过支付宝接口支付" />
                                    </td>
                                    <td bgcolor="#FFFFFF" class="gray12" style="padding: 10px;">
                                        <span class="STYLE2">
                                        
                                如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。 </span>
                                    </td>
                                    <td width="190" align="center" bgcolor="#FFFFFF" class="blue12" style="padding: 8px 0px 8px 0px;">
                                        <asp:HyperLink ID="hl4" runat="server" Target="_blank">
                                            <img src="../../images/bank_logo/bt_bank_zsyh.jpg" width="170" height="28" border="0" />
                                         </asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF" style="padding: 10px;">
                                        <img src="Images/img_18.gif" border="0" alt="本支付通过支付宝接口支付" />
                                    </td>
                                    <td bgcolor="#FFFFFF" class="gray12" style="padding: 10px;">
                                        <span class="STYLE2">
                                
                                如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。 </span>
                                    </td>
                                    <td width="190" align="center" bgcolor="#FFFFFF" class="blue12" style="padding: 8px 0px 8px 0px;">
                                        <asp:HyperLink ID="hl5" runat="server" Target="_blank">
                                            <img src="../../images/bank_logo/bt_bank_jsyh.jpg" width="170" height="28" border="0" />
                                        </asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF" style="padding: 10px;">
                                        <img src="Images/img_19.gif" border="0" alt="本支付通过支付宝接口支付" />
                                    </td>
                                    <td bgcolor="#FFFFFF" class="gray12" style="padding: 10px;">
                                        <span class="STYLE2">
                                如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。 </span>
                                    </td>
                                    <td width="190" align="center" bgcolor="#FFFFFF" class="blue12" style="padding: 8px 0px 8px 0px;">
                                        <asp:HyperLink ID="hl6" runat="server" Target="_blank">
                                            <img src="../../images/bank_logo/bt_bank_nyyh.jpg" width="170" height="28" border="0" />
                                        </asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF" style="padding: 10px;">
                                        <img src="Images/img_18f.gif" border="0" alt="本支付通过支付宝接口支付" />
                                    </td>
                                    <td bgcolor="#FFFFFF" class="gray12" style="padding: 10px;">
                                        <span class="STYLE2">
                                
                                如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。 </span>
                                    </td>
                                    <td width="190" align="center" bgcolor="#FFFFFF" class="blue12" style="padding: 8px 0px 8px 0px;">
                                        <asp:HyperLink ID="hl7" runat="server" Target="_blank">
                                            <img src="../../images/bank_logo/bt_bank_pfyh.jpg" width="170" height="28" border="0" />
                                        </asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF" style="padding: 10px;">
                                        <img src="Images/img_18x.gif" border="0" alt="本支付通过支付宝接口支付" />
                                    </td>
                                    <td bgcolor="#FFFFFF" class="gray12" style="padding: 10px;">
                                         <span class="STYLE2">
                                如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。 </span>
                                    </td>
                                    <td width="190" align="center" bgcolor="#FFFFFF" class="blue12" style="padding: 8px 0px 8px 0px;">
                                        <asp:HyperLink ID="hl8" runat="server" Target="_blank">
                                            <img src="../../images/bank_logo/bt_bank_xyyh.jpg" width="170" height="28" border="0" />
                                        </asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF" style="padding: 10px;">
                                        <img src="Images/img_18g.gif" border="0" alt="本支付通过支付宝接口支付" />
                                    </td>
                                    <td bgcolor="#FFFFFF" class="gray12" style="padding: 10px;">
                                        <span class="STYLE2">
                                如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。 </span>
                                    </td>
                                    <td width="190" align="center" bgcolor="#FFFFFF" class="blue12" style="padding: 8px 0px 8px 0px;">
                                        <asp:HyperLink ID="hl9" runat="server" Target="_blank">
                                            <img src="../../images/bank_logo/bt_bank_fzyh.jpg" width="170" height="28" border="0" />
                                        </asp:HyperLink>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF" style="padding: 10px;">
                                        <img src="Images/img_18s.gif" border="0" alt="本支付通过支付宝接口支付" />
                                    </td>
                                    <td bgcolor="#FFFFFF" class="gray12" style="padding: 10px;">
                                        <span class="STYLE2">
                                如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。 </span>
                                    </td>
                                    <td width="190" align="center" bgcolor="#FFFFFF" class="blue12" style="padding: 8px 0px 8px 0px;">
                                        <asp:HyperLink ID="hl10" runat="server" Target="_blank">
                                            <img src="../../images/bank_logo/bt_bank_szfzyh.jpg" width="170" height="28" border="0" />
                                        </asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF" style="padding: 10px;">
                                        <img src="Images/img_18ms.gif" border="0" alt="本支付通过支付宝接口支付" />
                                    </td>
                                    <td bgcolor="#FFFFFF" class="gray12" style="padding: 10px;">
                                        <span class="STYLE2">
                                如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。 </span>
                                    </td>
                                    <td width="190" align="center" bgcolor="#FFFFFF" class="blue12" style="padding: 8px 0px 8px 0px;">
                                        <asp:HyperLink ID="hl11" runat="server" Target="_blank">
                                            <img src="../../images/bank_logo/bt_bank_msyh.jpg" width="170" height="28" border="0" />
                                        </asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF" style="padding: 10px;">
                                        <img src="Images/img_18j.gif" border="0" alt="本支付通过支付宝接口支付" />
                                    </td>
                                    <td bgcolor="#FFFFFF" class="gray12" style="padding: 10px;">
                                        <span class="STYLE2">
                                如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。 </span>
                                    </td>
                                    <td width="190" align="center" bgcolor="#FFFFFF" class="blue12" style="padding: 8px 0px 8px 0px;">
                                        <asp:HyperLink ID="hl12" runat="server" Target="_blank">
                                            <img src="../../images/bank_logo/bt_bank_jtyh.jpg" width="170" height="28" border="0" />
                                        </asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF" style="padding: 10px;">
                                        <img src="Images/img_18yz.gif" border="0" alt="本支付通过支付宝接口支付" />
                                    </td>
                                    <td bgcolor="#FFFFFF" class="gray12" style="padding: 10px;">
                                        <span class="STYLE2">
                                如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。 </span>
                                    </td>
                                    <td width="190" align="center" bgcolor="#FFFFFF" class="blue12" style="padding: 8px 0px 8px 0px;">
                                        <asp:HyperLink ID="hl13" runat="server" Target="_blank">
                                            <img src="../../images/bank_logo/bt_bank_yzcbyh.jpg" width="170" height="28" border="0" />
                                        </asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF" style="padding: 10px;">
                                        <img src="Images/img_18zx.gif" border="0" alt="本支付通过支付宝接口支付" />
                                    </td>
                                    <td bgcolor="#FFFFFF" class="gray12" style="padding: 10px;">
                                        <span class="STYLE2">
                                如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。 </span>
                                    </td>
                                    <td width="190" align="center" bgcolor="#FFFFFF" class="blue12" style="padding: 8px 0px 8px 0px;">
                                        <asp:HyperLink ID="hl14" runat="server" Target="_blank">
                                            <img src="../../images/bank_logo/bt_bank_zxyh.jpg" width="170" height="28" border="0" />
                                         </asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    <br />
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
