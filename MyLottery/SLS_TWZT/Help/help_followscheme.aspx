<%@ page language="C#" autoeventwireup="true" CodeFile="help_followscheme.aspx.cs" inherits="Help_help_followscheme" enableEventValidation="false" %>

<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/HelpCenter.ascx" TagName="Help" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>方案撤单帮助-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="keywords" content="<%=_Site.Name %>帮助中心-方案撤单" />
    <meta name="description" content="<%=_Site.Name %>提供：用户登录-账户充值-选择彩种、选择玩法、选号投注-点击“立即投注”按钮---投注成功-中大奖了，我要提款！的帮助" />
    <link href="../Home/Room/style/css.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../favicon.ico" />
</head>

<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    
    <uc1:Lotteries ID="Lotteries" runat="server" />
    <div id="user">
        <div id="user_l">
            <uc2:Help ID="Help" runat="server" />
        </div>
        <div id="user_r">
            <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 10px;" width="842">
                <tr>
                    <td height="30" width="20">
                        &nbsp;
                    </td>
                    <td align="center" width="90" id="tdHelpCenter" style="cursor: hand; background-color: #FF6600;"
                        class="bai14">
                        <a href="Help_Default.aspx">帮助中心</a>
                    </td>
                    <td width="5">
                        &nbsp;
                    </td>
                    <td align="center" width="90" id="tdPlayType" style="cursor: hand; background-color: #E4E4E4;"
                        class="hui14">
                        <a href="Play_Default.aspx">玩法介绍</a>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#FF6600" colspan="5" height="2">
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding-top: 20px;">
                <tr>
                    <td height="36" align="center" class="red20">
                        方案撤单
                    </td>
                </tr>
                <tr>
                    <td height="0">
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#C0DBF9">
                <tr bgcolor="#CCCCCC">
                    <td bgcolor="#ffffff" class="black12" style="padding: 20px 25px 20px 25px; background-image: url(../images/zfb_bg_blue.jpg);
                        background-repeat: repeat-x; background-position: center top;">
                        <p>
                            <span class="blue14">用户投注的方案未能委托成功因方案撤单而引起，导致方案撤单的原因主要有四个：</span><br />
                            <br />
                            1、用户撤单<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;方案的发起人在方案的合买进度未超过50%的时候，有权对其发起的合买方案进行撤单操作，一般来说，用户撤单的原因主要有如下几个：重新发布新的合买方案、合买方案发起错误、对方案的整体进度不满意等。<br />
                            <br />
                            2、限号撤单。<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;根据福利彩票发行中心和体育彩票发行中心对各彩种的限号规定，若会员所选择的某些投注方案（包括追号）可能因限号无法投注，未成功投注单将作为失败方案进行限号撤单处理。
                            <br />
                            <br />
                            3、未满员撤单。<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;会员发起的合买方案，到了方案投注截止时间，若该方案未仍未满员，该合买方案将作为失败方案进行未满员方案撤单处理。<br />
                            <br />
                            4、投注通讯故障撤单。<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;因网络中断、系统故障、彩票机故障等不可抗力的原因，<%=_Site.Name %>不保证每一次投注100%成功出票，因此原因引起的投注方案失败，就表示此次的“委托投注”中心没有受理，视为委托服务未成立。该合买方案将作为投注通讯故障进行撤单处理。<br />
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;所有的被撤单方案都做返款处理，并在当期期次开奖前退还用户已支付的费用。除此之外，不再承担任何责任。
                        </p>
                        <p>
                            &nbsp;</p>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
<!--#includefile="../Html/TrafficStatistics/1.htm"--></body>
</html>
