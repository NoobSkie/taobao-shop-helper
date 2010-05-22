<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/ViewMessage.aspx.cs" inherits="Home_Room_ViewMessage" enableEventValidation="false" %>

<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
     <title>查看我的站内信息-用户中心-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-size: 12px;
            color: #000000;
            font-family: tahoma;
            line-height: 18px;
            width: 5%;
        }
    </style>
<link rel="shortcut icon" href="../../favicon.ico" /></head>
<body>
    <form id="form2" runat="server">
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
                        <img src="images/icon_6.gif" width="19" height="16" />
                    </td>
                    <td valign="middle" class="red14" style="padding-left: 10px;">
                        我的彩票记录
                    </td>
                </tr>
            </table>
            <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                <tr>
                    <td width="20" height="29">
                        &nbsp;
                    </td>
                    <td width="100" align="center" background="images/admin_qh_100_1.jpg" class="blue12">
                        <a href="ViewAccount.aspx"><strong>查看信息</strong></a>
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
            <table width="842" border="0" cellpadding="0" cellspacing="1" bgcolor="#DDDDDD" style="margin-top: 10px;">
                <tr>
                    <td height="30" align="right" bgcolor="#F8F8F8" class="style1">
                        发信人：<span class="red12"></span>
                    </td>
                    <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <asp:Label ID="lbAim" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="Message.aspx" class="blue12">【返回】</a>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right" bgcolor="#F8F8F8" class="style1">
                        内容：
                    </td>
                    <td width="22%" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                        <asp:Label ID="lbContent" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
