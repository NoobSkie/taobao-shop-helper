﻿<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/OnlinePay/Alipay02/Send_YeePay.aspx.cs" inherits="Home_Room_OnlinePay_Alipay02_Send_YeePay" enableEventValidation="false" %>

<%@ Register Src="../../UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
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
</head>
<link rel="shortcut icon" href="../../../../favicon.ico" />
<body>
    <form id="Form1" name="Form1" method="post" runat="server">
    <asp:HiddenField ID="hdBankCode" runat="server" />
    <div id="content">
        <div id="menu_right">
            <asp:Panel ID="pnlFirst" runat="server" Visible="true">
                <table width="810" border="0" cellpadding="0" cellspacing="0" bgcolor="#C0DBF9">
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
                                            <asp:TextBox ID="PayMoney" runat="server" MaxLength="8" CssClass="in_text" onblur="CheckMultiple(this);"
                                                Text="2"></asp:TextBox>
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
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" >
                                <tr style="padding-bottom:3px;">
                                    <td>
                                        <table width="150" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                     <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="26">
                                                                <label>
                                                                    <asp:RadioButton ID="radYeePay" GroupName="payWay" runat="server" Checked="true" />
                                                                </label>
                                                            </td>
                                                            <td width="124" height="28">
                                                                <img src="images/bank_logo/logo_yeepay.gif" width="121" height="27" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
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
                                        <span style="color: #000000; font-weight: normal">注：为了及时到帐，充值完成后【</span>请不要关闭网银或支付宝窗口<span
                                            style="color: #000000; font-weight: normal">】 ，系统会自动跳转回本网站！！！</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <%--   </div>
    </div>--%>
            <br />
        </div>
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>

<script type="text/javascript">
		<!--
    function CheckMultiple(sender) {
        var money = StrToFloat(sender.value);
        sender.value = money;

        if (money < 2) {
            if (confirm("充值金额不正确，按“确定”重新输入，按“取消”自动更正为 2 元，请选择。")) {
                sender.focus();
                return;
            }
            else {
                sender.value = 2;
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

