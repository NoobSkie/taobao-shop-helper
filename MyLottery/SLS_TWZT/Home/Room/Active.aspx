<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/Active.aspx.cs" inherits="Home_Room_Active" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>

<%@ Register src="UserControls/Lotteries.ascx" tagname="Lotteries" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=_Site.Name %>欢迎您！-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #box1
        {
            overflow: hidden;
            width: 1002px;
            margin-right: auto;
            margin-left: auto;
            padding: 0px;
        }
    </style>
    <link rel="shortcut icon" href="../../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    
    <uc1:Lotteries ID="Lotteries2" runat="server" />
    <div id="box1">
         <div id="index">
                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9BBFCA" style="margin-top:10px">
                    <tr>
                        <td id="tdright" valign="top" bgcolor="#FFFFFF" class="bg_x" style="padding: 12px 20px 12px 20px;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <img src="../Web/images/privacy.gif" height="33" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="12">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="1" bgcolor="#CCCCCC">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="12">
                                    </td>
                                </tr>
                            </table>
                            <div class="blue12">
                                <div>
                                    尊敬的<asp:Label ID="lbFrom" runat="server" CssClass="red12"></asp:Label>
                                    会员，您好！</div>
                                <div>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    欢迎您来到属于自己的<%=_Site.Name %><a href="<%=_Site.Url %>"> <%=_Site.Url %></a>。当你点击“同意”按钮，<%=_Site.Name %>将接收您的会员信息进行实名制购彩身份校验。 该校验是为了保证你的投注安全与奖金领取，不会造成您的个人隐私安全 ！

                                <div style="margin: 10px; text-align:center;">
                                    <asp:Button ID="btnAgree" runat="server" Text="同意" OnClick="btnAgree_Click"  Width="60px"/>
                                    <span style="margin-left: 50px;"></span>
                                    <asp:Button ID="btnDisagree" runat="server" Text="不同意" OnClick="btnDisagree_Click"/>
                                    <span style="margin-left: 50px;"></span>
                                    <asp:Button ID="btnIntroduce" runat="server" Text="<%=_Site.Name %>简介" 
                                        onclick="btnIntroduce_Click"/>
                                </div>
                            </div>
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
