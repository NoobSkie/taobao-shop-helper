<%@ page language="C#" autoeventwireup="true" CodeFile="Default.aspx.cs" inherits="Home_Room_OnlinePay_007ka_Default" enableEventValidation="false" %>

<%@ Register Src="../../UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>手机充值卡充值-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %></title>
    <meta name="keywords" content="手机充值卡充值" />
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <link href="../../Style/css.css" type="text/css" rel="stylesheet" />

    <script src="../../JavaScript/Public.js" type="text/javascript"></script>

 

    <style type="text/css">
        .sp_money
        {
            color: Red;
            font-weight: bold;
        }
    </style>
</head><link rel="shortcut icon" href="../../../../favicon.ico"/>
<body>
    <form id="Form1" name="Form1" method="post" runat="server">
    <asp:HiddenField ID="hdBankCode" runat="server" />
    <div id="content">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#C0DBF9">
                <tr>
                    <td height="10" colspan="2" align="right" bgcolor="#FFFFFF" class="black12">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td width="100" height="36" align="left" bgcolor="#FFFFFF" class="black12">
                        <span class="red12">*</span> 支付方式：
                    </td>
                    <td width="685" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                        <label style="display: none;">
                                                      <asp:RadioButton ID="radSZX" GroupName="payWay" Visible="false" runat="server"
                                onclick="showOrHidArae(this)" />神州行充值卡
                        </label>
                        <label style="display: none;">
                            <asp:RadioButton ID="rad51ZFK" GroupName="payWay" Visible="false" runat="server"
                                onclick="showOrHidArae(this)" />
                            51支付卡
                        </label>
                      <asp:Image ImageUrl="../Alipay02/images/bank_logo/logo_mobile.gif" ID="imageCardType" runat="server" Width="121px" Height="27px" />
                      &nbsp;&nbsp;
                       <asp:Image ImageUrl="../Alipay02/images/bank_logo/logo_007ka.gif" ID="imageCardType007Ka" runat="server" Width="121px" Height="27px" />
                        <font class="blue12"><font class="blue12">
                    </td>
                </tr>
                <tbody id="tb_szx" runat="server">
                    <tr>
                        <td width="100" height="40" align="left" bgcolor="#FFFFFF" class="black12">
                            <span class="red12">*</span> 您的充值金额：
                        </td>
                        <td width="685" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <table>
                            <tr>
                            <td>
                            <asp:RadioButtonList ID="rblist" runat="server" 
                                RepeatDirection="Horizontal" 
                                onselectedindexchanged="rblist_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="30">30 元</asp:ListItem>
                                <asp:ListItem Value="50">50 元</asp:ListItem>
                                <asp:ListItem Value="100">100 元</asp:ListItem>
                                <asp:ListItem Value="300" Selected="True">300 元</asp:ListItem>
                            </asp:RadioButtonList>
                            </td>
                            <td width="10"/>
                            <td>
			                    <div class="red12">*手续费率：&nbsp;<asp:Label ID="labFeesScale" runat="server" Font-Bold="True"  ForeColor="#FF3300"></asp:Label></div> 
			                </td>
			                </tr>
			                </table>
                        </td>
                    </tr>
 
                    <tr>
                    <td align="right" valign="top" bgcolor="#FFFFFF" class="black12">
                    </td>
                    <td align="left" valign="top" bgcolor="#FFFFFF" class="black12" 
                        style="padding: 10px 0px 10px 10px;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 5px;margin-bottom: 15px;">
                            <tr>
                                <td>
                                    <asp:HyperLink Target="_blank" ID="imgbtn_OK" runat="server" ImageUrl="../Alipay02/images/bt_wy.jpg"/>
                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                <td colspan="2" style="width:100%; height:5px; background-color:#FFFFFF">
                <div id="hr">
                         </div>
                </td>
                
                </tr>
                    <tr>
                        <td bgcolor="#FFFEDF" colspan="2" class="black12" style="padding: 5px 10px 5px 10px;">
                            <span class="blue12">注意说明：</span><br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1. 支付卡类:由中国移动发行的全国通用的神州充值卡,序列号17位、密码18位；<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2. 支持30、50、100、300元面值的神州行充值卡支付；<br/>
			    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:Red">(如：选择50元面额但使用100元卡支付，则系统认为实际支付金额为50元，高于50元部分不予退还；<br/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;选择50元面额但使用30元卡支付则系统认为支付失败，30元不予退还)</span>；<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3. 面值--实充：30元--28.5元、50元--47.5元、100元--95元、300元--285元。<br />   
                            
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4. 由于神州行支付网关的验证比较严格，所以充值处理时间比较长,请耐心等待。<br/>
       			    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;在充值结果出来前不要关闭窗口以免出错。<br />
                        </td>
                    </tr>
                </tbody>
                </table>
            <br />
        </div>
    </div>
    
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
