<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/BuyProtocol.aspx.cs"inherits="Home_Room_BuyProtocol" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=_Site.Name %>电话短信投注协议-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
     
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            min-width: 970x;
            font-family: "tahoma"; font-size:12px;
            text-align:center;
        }
    </style>
    <link rel="shortcut icon" href="../../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <table cellpadding="0" cellspacing="0" style="width:1002px;">
        <tr>
            <td align="left">
                <div style="border: 1px solid #BCD2E9;padding-left:10px;">
                    <asp:Label ID="lbAgreement" runat="server">
                    </asp:Label>
                </div>
            </td>
        </tr>
    </table>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
        <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
