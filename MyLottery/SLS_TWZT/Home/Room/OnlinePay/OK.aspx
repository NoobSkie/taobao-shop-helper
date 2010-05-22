<%@ page language="c#" CodeFile="~/Home/Room/OnlinePay/OK.aspx.cs" inherits="Home_Room_OnlinePay_OK" enableEventValidation="false" %>
<%@ Register Src="../UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="../UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网上充值-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <meta name="keywords" content="<%=_Site.Name %>提供网银充值，支付宝支付，财付通支付" />
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link rel="shortcut icon" href="../../../favicon.ico"/>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc3:Lotteries ID="Lotteries1" runat="server" />
    <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 3px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
             <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF">
        <tr>
            <td valign="top" bgcolor="#FFFFFF">
                
                
                <table id="myIcaileTab" runat="server" width="842" border="0" cellpadding="0" cellspacing="0" style="margin-top:10px;">
                    <tr>
                        <td>
                            <table width="840" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                <tr>
                                    <td height="30" colspan="2" align="align" bgcolor="#FFFFDD" class="black12" style="padding: 5px 10px 5px 10px;font-size :14px;">
                                        <img src="../Images/icon_cg2.jpg" />&nbsp&nbsp<span id="time" style="color:Red; ">5</span>秒后自动跳转！
                                    </td>
                                </tr>
                                <tr>
                                    <td height="30" colspan="2" align="center" bgcolor="#ffffff" class="black12">
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td colspan="2" align="left" style="padding :15px  25px  15px  25px;">
                                                <br />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="lab1" runat="server"></asp:Label><br /><br />
                                                    &nbsp;&nbsp;&nbsp; <font color="red">温馨提示：充值成功。请点击“查看我的账户”查看投注卡账户余额情况。如果有问题，请记录下您的支付银行、支付金额等信息后，并与我们联系，我们将在第一时间进行处理，保证您的资金安全。&nbsp;&nbsp;<!--如果您选择的是支付宝支付，请您稍候再查询您的账户余额--></font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" height="20">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="left"  style="padding-left :25px; padding-top :15px; border-top:1px solid #cccccc; ">
                                                    <a class="li3" href="../AccountDetail.aspx">【查看我的账户】</a> <a class="li3" href="../Invest.aspx">
                                                       【查看我的投注记录】</a> <a class="li3" href="../Service.aspx" target="_blank">【我要反映问题】</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" height="50">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </div>
    </div> 
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    
   <asp:HiddenField ID="HidScript" runat="server" />
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
<script language="javascript" type="text/javascript">
    function DisplayTimer() {
        var seconds = parseInt(time.innerHTML)-1;
        time.innerHTML = seconds.toString();
            if (seconds == 0) {
            window.top.location.href ="<%=Url %>";
        }
    }
</script>