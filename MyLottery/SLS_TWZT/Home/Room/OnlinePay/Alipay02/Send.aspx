<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/OnlinePay/Alipay02/Send.aspx.cs" inherits="Home_Room_OnlinePay_Alipay02_Send" enableEventValidation="false" %>

<%@ Register Src="../../UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网上支付，手机卡充值-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。" />
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

    <script type="text/javascript" language="javascript">
        function Choose(obj) {
                document.getElementById("tdmeshwork").style.backgroundImage = "url('../../Images/admin_qh_100_1.jpg')";
                document.getElementById("divrad007Ka").style.display = "none";
                document.getElementById("tbrow1").style.display = "block";
                document.getElementById("divbank").style.display = "block"
                document.getElementById("tdtell").style.display = "none";
                document.getElementById("tdname").style.display = "block";
                document.getElementById("radZFB").checked = true;
        }
    </script>

</head>
<link rel="shortcut icon" href="../../../../favicon.ico" />
<body onload=" scrollTo(0, 147);">
    <form id="Form1" name="Form1" method="post" runat="server">
    <asp:HiddenField ID="hdBankCode" runat="server" />
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc3:Lotteries ID="Lotteries1" runat="server" />
    <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 3px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
            <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                <tr>
                    <td width="40" height="30" align="right" valign="middle" class="red14">
                        <img src="../../Images/icon_5.gif" width="19" height="16" />
                    </td>
                    <td valign="middle" class="red14" style="padding-left: 10px;">
                        我的帐户
                    </td>
                </tr>
            </table>
            <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                <tr>
                    <td width="20" height="29">
                        &nbsp;
                    </td>
                    <td width="100" align="center" onclick="Choose(this)" background="../../Images/admin_qh_100_1.jpg"
                        class="blue12" id="tdmeshwork">
                        <a href="javascript:;"><strong>网上支付</strong></a>
                    </td>
                    <td width="4">
                        &nbsp;
                    </td>
                    <td width="6">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="1" colspan="11" bgcolor="#FFFFFF">
                    </td>
                </tr>
                <tr>
                    <td height="2" colspan="11" bgcolor="#6699CC">
                    </td>
                </tr>
            </table>
            <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#DDDDDD">
                <tr>
                    <td height="30" colspan="2" align="left" bgcolor="#E9F1F8" class="black12" style="padding-left: 20px;">
                        您好，<span class="blue12" style="font-weight: bold;"><%=UserName%></span>！您当前帐户余额为：￥<span
                            class="red12" style="font-weight: bold;"><%= Balance%>
                        </span>元
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlFirst" runat="server" Visible="true">
                <table width="810" border="0" cellpadding="0" cellspacing="0" bgcolor="#C0DBF9">
                    <tr>
                        <td height="10" colspan="2" align="right" bgcolor="#FFFFFF" class="black12">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tdname">
                        <td width="93" height="30" align="right" bgcolor="#FFFFFF" class="black12">
                            <span class="red12">*</span>充值金额：
                        </td>
                        <td width="685" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr bgcolor="#C0DBF9">
                                    <td width="23%" align="left" bgcolor="#FFFFFF" class="black12">
                                        <label>
                                            <asp:TextBox ID="PayMoney" runat="server" MaxLength="8" CssClass="in_text" onblur="CheckMultiple(this);"
                                                Text="5"></asp:TextBox>
                                        </label>
                                    </td>
                                    <td width="77%" align="left" bgcolor="#FFFFFF" class="black12">
                                        元，（<span class="red12">网上充值免手续费</span>，存入金额最少5元）
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
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tbrow1">
                                <tr>
                                    <td width="176">
                                        <table width="150" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="26">
                                                    <label>
                                                        <asp:RadioButton ID="rad99Bill" Checked="true" GroupName="payWay" runat="server" />
                                                    </label>
                                                </td>
                                                <td width="124" height="28">
                                                    <img src="images/bank_logo/logo_99Bill.gif" width="121" height="27" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table width="150" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="26">
                                                    <label>
                                                        <asp:RadioButton ID="radZFB" GroupName="payWay" runat="server" />
                                                    </label>
                                                </td>
                                                <td width="124" height="28">
                                                    <img src="images/bank_logo/logo_zfb.gif" width="121" height="27" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table width="150" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="26">
                                                    <label>
                                                        <asp:RadioButton ID="radCFT" GroupName="payWay" runat="server" />
                                                    </label>
                                                </td>
                                                <td width="124" height="28">
                                                    <img src="images/bank_logo/logo_cft.gif" width="121" height="27" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <%--   <td>
                                        <table width="150" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="26">
                                                    <label>
                                                        <asp:RadioButton ID="radCCB" GroupName="payWay" runat="server" />
                                                    </label>
                                                </td>
                                                <td width="124" height="28">
                                                    <img src="images/bank_logo/logo_jsyh.gif" width="121" height="27" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>--%>
                                    <td>
                                        <table width="150" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="26">
                                                </td>
                                                <td width="124" height="28">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div style="" id="divbank">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="26">
                                                        <label>
                                                            <asp:RadioButton ID="radICBCB2C" GroupName="payWay" runat="server" />
                                                        </label>
                                                    </td>
                                                    <td width="124" height="28">
                                                        <img src="images/bank_logo/logo_hsyh.gif" width="121" height="27" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td height="40">
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="26">
                                                        <label>
                                                            <asp:RadioButton ID="radCMB" GroupName="payWay" runat="server" />
                                                        </label>
                                                    </td>
                                                    <td width="124" height="28">
                                                        <img src="images/bank_logo/logo_zsyhj.gif" width="121" height="27" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="26">
                                                        <label>
                                                            <asp:RadioButton ID="radBOCB2C" GroupName="payWay" runat="server" />
                                                        </label>
                                                    </td>
                                                    <td width="124" height="28">
                                                        <img src="images/bank_logo/logo_zgyh.gif" height="27" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="26">
                                                        <label>
                                                            <asp:RadioButton ID="radABC" GroupName="payWay" runat="server" />
                                                        </label>
                                                    </td>
                                                    <td width="124" height="28">
                                                        <img src="images/bank_logo/logo_nyyh.gif" width="121" height="27" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="40">
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="26">
                                                        <label>
                                                            <asp:RadioButton ID="radCOMM" GroupName="payWay" runat="server" />
                                                        </label>
                                                    </td>
                                                    <td width="124" height="28">
                                                        <img src="images/bank_logo/logo_jtyh.gif" width="121" height="27" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="26">
                                                        <label>
                                                            <asp:RadioButton ID="radSPDB" GroupName="payWay" runat="server" />
                                                        </label>
                                                    </td>
                                                    <td width="124" height="28">
                                                        <img src="images/bank_logo/logo_shpd.gif" width="121" height="27" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="26">
                                                        <label>
                                                            <asp:RadioButton ID="radGDB" GroupName="payWay" runat="server" />
                                                        </label>
                                                    </td>
                                                    <td width="124" height="28">
                                                        <img src="images/bank_logo/logo_gdfzyh.gif" width="121" height="27" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="26">
                                                        <label>
                                                            <asp:RadioButton ID="radGDYH" GroupName="payWay" runat="server" />
                                                        </label>
                                                    </td>
                                                    <td width="124" height="28">
                                                        <img src="images/bank_logo/logo_gdyh.gif" width="121" height="27" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="40">
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="26">
                                                        <label>
                                                            <asp:RadioButton ID="radCIB" GroupName="payWay" runat="server" />
                                                        </label>
                                                    </td>
                                                    <td width="124" height="28">
                                                        <img src="images/bank_logo/logo_xyyh.gif" width="121" height="27" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="26">
                                                        <label>
                                                            <asp:RadioButton ID="radSDB" GroupName="payWay" runat="server" />
                                                        </label>
                                                    </td>
                                                    <td width="124" height="28">
                                                        <img src="images/bank_logo/logo_szfzyh.gif" width="121" height="27" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="26">
                                                        <label>
                                                            <asp:RadioButton ID="radCMBC" runat="server" GroupName="PayWay" />
                                                        </label>
                                                    </td>
                                                    <td width="124" height="28">
                                                        <img src="images/bank_logo/logo_zgms.gif" width="121" height="27" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="26">
                                                        <label>
                                                            <asp:RadioButton ID="radBCCBEB" GroupName="payWay" runat="server" />
                                                        </label>
                                                    </td>
                                                    <td width="124" height="28">
                                                        <img src="images/bank_logo/logo_bjyh.gif" width="121" height="27" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <!-- <td>
                                            中信银行
                                <table width="150" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="26">
                                            <label>
                                                <asp:RadioButton ID="radCITIC" GroupName="payWay" runat="server" 
                                                Enabled="False" />
                                            </label>
                                        </td>
                                        <td width="124" height="28">
                                            <img src="images/bank_logo/logo_zxyh.gif" width="121" height="27" />
                                        </td>
                                    </tr>
                                </table>
                                
                                        </td>-->
                                        <!--  <td>
                                           
                                <table width="150" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="26">
                                            <label>
                                                <asp:RadioButton ID="radHZCBB2C" GroupName="payWay" runat="server" 
                                                Enabled="False" />
                                            </label>
                                        </td>
                                        <td width="124" height="28">
                                            <img src="images/bank_logo/logo_hzyh.gif" width="121" height="27" />
                                        </td>
                                    </tr>
                                </table>
                            
                                        </td>    -->
                                        <td>
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="26">
                                                        <label>
                                                            <asp:RadioButton ID="radCCB" GroupName="payWay" runat="server" />
                                                        </label>
                                                    </td>
                                                    <td width="124" height="28">
                                                        <img src="images/bank_logo/logo_jsyh.gif" width="121" height="27" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="divrad007Ka" style="width: 150px; margin-bottom: 10px; display: none;">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="40" valign="top">
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="26" valign="top">
                                                        <label>
                                                            <asp:RadioButton ID="rad007Ka" GroupName="payWay" runat="server" />
                                                        </label>
                                                    </td>
                                                    <td width="124" height="28" valign="top">
                                                        <img alt="" src="images/bank_logo/logo_mobile.gif" width="121" height="27" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 15px;">
                                <tr>
                                    <td>
                                        <ShoveWebUI:ShoveConfirmButton ID="btnNext" Style="cursor: pointer;" runat="server"
                                            Width="109px" Height="33px" CausesValidation="False" BackgroupImage="images/bt_next.jpg"
                                            BorderStyle="None" OnClick="btnNext_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" id="tdtell" style="display: none;">
                    <tr>
                        <div id="hr" style="margin-bottom: 3px;">
                        </div>
                        <td colspan="2" rowspan="3" height="30" align="left" valign="top" bgcolor="#FFFFFF"
                            class="black12" style="padding: 10px 0px 10px 0px;">
                            <table width="100%" border="0" cellspacing="1" cellpadding="0" bgcolor="#FFCD33">
                                <tr>
                                    <td bgcolor="#FFFFE1" class="red12" style="padding: 15px;">
                                        <span style="color: Red;">！</span> 注意： 充值卡内金额将一次全额扣除，请务必选择与您的充值卡面额相同的消费金额，否则会给您造成损失。我们无法给您退还差额或损失部分。(例如：你的充值卡面值为300而您选择的是100，你的充值卡金额将被全额扣除，而您在本站的充值只有100。)
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlSecond" runat="server" Visible="false">
                <table width="805" border="0" cellpadding="0" cellspacing="0" bgcolor="#C0DBF9" style="margin-top: 15px;">
                    <tr>
                        <td height="10" colspan="2" align="right" bgcolor="#FFFFFF" class="black12">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="105" height="30" align="right" bgcolor="#FFFFFF" class="black12">
                            <span class="red12">*</span>您的充值金额：
                        </td>
                        <td width="700" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr bgcolor="#C0DBF9">
                                    <td width="23%" align="left" bgcolor="#FFFFFF" class="black12">
                                        <span class="red12">
                                            <asp:Label ID="lbPayMoney" runat="server"></asp:Label>
                                        </span>元
                                    </td>
                                    <td width="77%" align="left" bgcolor="#FFFFFF" class="black12">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" align="right" valign="top" bgcolor="#FFFFFF" class="black12" style="padding-top: 10px;">
                            <span class="red12">*</span>选择支付方式：
                        </td>
                        <td height="30" align="left" valign="top" bgcolor="#FFFFFF" style="padding: 10px 0px 10px 10px;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="24%">
                                        <img id="BankImg" src="Images/bank_logo/logo_<%= BankName%>.gif" width="121" height="27" />
                                    </td>
                                    <td width="76%" class="blue12">
                                        <asp:LinkButton ID="lbReturn" runat="server" Text="返回重新选择支付方式" OnClick="lbReturn_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 15px;">
                                <tr>
                                    <td class="red12">
                                        <asp:HyperLink ID="hlOK" runat="server" Target="_blank"><img src="images/bt_wy.jpg" border="0" /></asp:HyperLink>
                                        &nbsp;&nbsp;&nbsp;&nbsp;将会在新窗口中打开支付页面。
                                    </td>
                                </tr>
                                <tr>
                                    <td class="red13">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="red99">
                                        <span style="color: #000000; font-weight: normal">注：为了及时到帐，充值完成后【</span>请不要关闭网银或支付窗口<span
                                            style="color: #000000; font-weight: normal">】 ，系统会自动跳转回本网站！！！</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>

<script type="text/javascript">
		<!--
    function CheckMultiple(sender) {
        var money = StrToFloat(sender.value);
        sender.value = money;

        if (money < 5) {
            if (window.location.href.indexOf(".wzwbw.") > 0)//测试:可以冲小于2元
            {
                return;
            }

            if (confirm("充值金额不正确，按“确定”重新输入，按“取消”自动更正为 5 元，请选择。")) {
                sender.focus();
                return;
            }
            else {
                sender.value = 5;
            }
        }
    }

    function StrToFloat(str) {
        var NewStr = "";
        for (var i = 0; i < str.length; i++) {
            if (str.charAt(i) != "," && str.charAt(i) != " ")
                NewStr += str.charAt(i);
        }

        if (NewStr == "")
            return 0;

        var f = parseFloat(NewStr);
        if (isNaN(f))
            return 0;

        return f;
    }
		-->
</script>

