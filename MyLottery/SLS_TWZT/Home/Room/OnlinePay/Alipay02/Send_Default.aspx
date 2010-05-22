<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/OnlinePay/Alipay02/Send_Default.aspx.cs" inherits="Home_Room_OnlinePay_Alipay02_Send_Default" enableEventValidation="false" %>

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
                    <td runat="server" width="100" id="td_Alipay" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)"
                        onclick="SetPayPage('Alipay')" align="center" background="../../images/admin_qh_100_2.jpg"
                        class="blue12" style="cursor: pointer;">
                        支付宝
                    </td>
                    <td runat="server" width="4" id="td_Alipay1">
                        &nbsp;
                    </td>
                    <td runat="server" width="100" id="td_99Bill" align="center" background="../../images/admin_qh_100_2.jpg"
                        onclick="SetPayPage('99Bill')" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)"
                        class="blue12" style="cursor: pointer;">
                        快钱
                    </td>
                    <td runat="server" width="4" id="td_99Bill1">
                        &nbsp;
                    </td>
                    <td runat="server" width="100" id="td_Yeepay" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)"
                        align="center" onclick="SetPayPage('Yeepay')" background="../../images/admin_qh_100_2.jpg"
                        class="blue12" style="cursor: pointer;">
                        易宝
                    </td>
                    <td runat="server" width="4" id="td_Yeepay1">
                        &nbsp;
                    </td>
                    <td runat="server" width="100" id="td_SZX" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)"
                        align="center" onclick="SetPayPage('SZX')" background="../../images/admin_qh_100_2.jpg"
                        class="blue12" style="cursor: pointer;">
                        神州行充值卡
                    </td>
                    <td runat="server" width="4" id="td_SZX1">
                        &nbsp;
                    </td>
                    <td runat="server" width="100" id="td_CFT" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)"
                        align="center" onclick="SetPayPage('CFT')" background="../../images/admin_qh_100_2.jpg"
                        class="blue12" style="cursor: pointer;">
                        财付通
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
            </table>
            <table width="100%" style="padding-top: 0px;" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="1" bgcolor="#FFFFFF">
                    </td>
                </tr>
                <tr>
                    <td height="2" bgcolor="#6699CC">
                    </td>
                </tr>
            </table>
            <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#DDDDDD">
                <tr>
                    <td height="30" colspan="2" align="left" bgcolor="#E9F1F8" class="black12" style="padding-left: 20px;">
                        您好，<span class="red12"><%=UserName%></span>！您当前帐户余额为：￥<span class="red12"><%= Balance%>
                        </span>元
                    </td>
                </tr>
            </table>
            <div id="divSend">
                <iframe id="iframeSend" name="iframeSend" width="100%" frameborder="0" scrolling="no" src="<%=DefaultSendPage %>"
                    onload="document.getElementById('iframeSend').style.height=iframeSend.document.body.scrollHeight;">
                </iframe>
            </div>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>

<script type="text/javascript">
    function SetPayPage(id) {
        var arr = new Array('Alipay', '99Bill', 'Yeepay',  'SZX', 'CFT');
        for (var i = 0; i < arr.length; i++) {
            if (id == arr[i]) {
                switch (id) {
                    case 'Alipay':
                        document.getElementById("iframeSend").src = 'Send_Alipay.aspx';
                        break;
                    case '99Bill':
                        document.getElementById("iframeSend").src = 'Send_99Bill.aspx';
                        break;
                    case 'Yeepay':
                        document.getElementById("iframeSend").src = 'Send_YeePay.aspx';
                        break;
                    case 'SZX':
                        document.getElementById("iframeSend").src = '../007ka/Default.aspx';
                        break;
                    case 'CFT':
                        document.getElementById("iframeSend").src = 'Send_CFT.aspx';
                        break;
                }
            }
        }
    }
</script>

