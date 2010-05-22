<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/PromoteCpsReg.aspx.cs" inherits="Home_Room_PromoteCpsReg" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>推广CPS站长商家-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <meta name="keywords" content="合买方案" />
     

    <script src="../../JavaScript/Marquee.js" type="text/javascript"></script>

    <link href="Style/css.css" rel="stylesheet" type="text/css" />
<link rel="shortcut icon" href="../../favicon.ico" /></head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc3:Lotteries ID="Lotteries1" runat="server" />
     <table align="center">
                    <tr>
                        <td style="width: 240px; vertical-align: top;">
                            <table width="100%" border="0" cellspacing="1" cellpadding="0" style="margin-top: 6px;
                    height: 485px;" bgcolor="#DDDDDD">
                    <tr>
                        <td valign="top" bgcolor="#FFFFFF" style="padding-bottom: 15px;">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <img src="images/user_title_1.jpg" width="260" height="62" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 0px 10px 0px 10px;" height="15">
                                        <hr style="height: 1px; color: #DDDDDD" />
                                    </td>
                                </tr>
                            </table>
                            <table width="260" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="74" height="36" align="right" class="hui12">
                                        用户名：
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="tbFormUserName" runat="server" size="20" class="in_text"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="36" align="right" class="hui12">
                                        密&nbsp;&nbsp;&nbsp;码：
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="tbFormUserPassword" runat="server" TextMode="Password" class="in_text"
                                            size="20" />
                                    </td>
                                </tr>
                                <tr id="CheckCode1" runat="server">
                                    <td height="36" align="right" class="hui12">
                                        验证码：
                                    </td>
                                    <td width="80">
                                        <asp:TextBox ID="tbFormCheckCode" runat="server" MaxLength="6" class="in_text" size="6"></asp:TextBox>
                                    </td>
                                    <td width="52">
                                        <ShoveWebUI:ShoveCheckCode ID="ShoveCheckCode1" runat="server" ForeColor="CornflowerBlue"
                                            BackColor="SeaShell" Charset="All" Height="20px" SupportDir="~/ShoveWebUI_client"
                                            Style="vertical-align: top; padding-top: 3px;"></ShoveWebUI:ShoveCheckCode>
                                    </td>
                                    <td  class="blue12_line">
                                        &nbsp;&nbsp;<a href="PromoteUserReg.aspx">刷新</a>
                                    </td>
                                </tr>
                            </table>
                            <table width="260" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
                                <tr>
                                    <td width="109" height="36" align="right" class="hui12">
                                        <ShoveWebUI:ShoveConfirmButton ID="btnLogin" Style="cursor: pointer;" runat="server"
                                            Width="83px" Height="29px" CausesValidation="False" BackgroupImage="images/bt_denglu.jpg"
                                            BorderStyle="None" OnClick="btnLogin_Click" />
                                    </td>
                                    <td width="151" class="blue12_line" style="padding-left: 10px;">
                                        <a href="ForgetPassword.aspx" target="_top">忘记密码</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="15" colspan="2" align="right" class="hui12">
                                        <hr style="height: 1px; color: #DDDDDD" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" colspan="2" align="left" class="hui12" style="padding-left:10px">
                                        您还可以通过以下共享登陆口登录：
                                    </td>
                                </tr>
                            </table>
                            <table width="260" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 15px;">
                                <tr>
                                    <td>
                                        <table width="125" border="0" cellspacing="1" cellpadding="0" bgcolor="#DDDDDD">
                                            <tr>
                                                <td height="55" align="center" bgcolor="#E3F2FD" class="red12" ><%=_Site.Name %>支持3亿QQ会员直接登录</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table width="125" border="0" cellspacing="1" cellpadding="0" bgcolor="#DDDDDD">
                                            <tr>
                                                <td height="30" align="center" bgcolor="#FFFFFF">
                                                    <a href="TencentLogin.aspx" target="_blank">
                                                        <img src="images/user_logo_cft.gif" width="123" height="28" border="0" /></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="25" align="center" bgcolor="#F7F7F7" class="hui12">
                                                    <a href="TencentLogin.aspx" target="_blank">QQ会员登录</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table width="260" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 0px;">
                                <tr>
                                    <td width="260" height="15" align="right" class="hui12">
                                        <hr style="height: 1px; color: #DDDDDD" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="left" class="hui14" style="padding-left:10px">
                                        客服服务
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" align="left" class="hui12" style="padding-left:10px">
                                        您如遇到问题请联系<%=_Site.Name %>客服：
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" align="left" class="blue12_line" style="padding-left:10px">
                                        <span class="hui12">免费客服电话：</span><span class="red14_2"><%= _Site.ServiceTelephone %></span> 
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" align="left" class="hui12" style="padding-left:10px">
                                        邮箱：<a href="mailto:BD@handtouchworld.com" target="_blank">BD@handtouchworld.com</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                        </td>
                        <td valign="top" width="530px">
                            <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0" bgcolor="#CCCCCC">
                                <tr>
                                    <td height="130" colspan="2" align="left" valign="top" background="images/bg_708.gif"
                                        bgcolor="#FFFFFF" class="black14" style="padding: 10px 0px 0px 15px; font-family: 宋体, Arial, Helvetica, sans-serif;
                                        font-size: 14px; font-weight: bold;">
                                        <div style="width: 470px">
                                            <asp:Panel ID="pnlShowPromotionInfo" runat="server">
                                                <span class="red14">
                                                    <asp:Label runat="server" ID="lblCommenderName2">xxx</asp:Label></span>请求加您为好友，接受<span
                                                        class="red14"><asp:Label runat="server" ID="lblCommenderName1">xxx</asp:Label></span>的好友请求,
                                                推荐你代理<%=_Site.Name %>的彩票销售广告，你将获得<span class="red14">2.5%</span>广告注册用户交易量返点，无须审核，实时开通.请在下面完善个人信息，按受他的邀请。
                                            </asp:Panel>
                                            <asp:Panel ID="pnlShowErrorInfo" runat="server">
                                                提示:<asp:Label runat="server" ID="lblShowErrorInfo" class="red14">xxxxxxxxxxxx.</asp:Label>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right" bgcolor="#FFFFFF" class="hui12" width="20%">
                                        你的用户名：
                                    </td>
                                    <td bgcolor="#FFFFFF" style="padding-left: 10px;" class="hui12">
                                            <asp:TextBox ID="tbUserName" runat="server" class="in_text" size="20" MaxLength="16"></asp:TextBox>
                                            <span class="red12">*<span class="blue" style="padding-left: 10px;">
                                                <input id="btnCheckUserName" type="button" value="检测用户名是否可用" onclick="return checkUserName();" />
                                            </span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right" bgcolor="#FFFFFF" class="hui12">
                                        &nbsp;
                                    </td>
                                    <td bgcolor="#FFFFFF" class="hui12" style="padding-left: 10px;">
                                        <span id="spCheckResult">用户名长度在 5-16 个英文字符或数字、中文 3-8 之间。</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right" bgcolor="#FFFFFF" class="hui12">
                                        你的密码：
                                    </td>
                                    <td bgcolor="#FFFFFF" class="hui12" style="padding-left: 10px;">
                                        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" class="in_text" size="20"
                                            MaxLength="16"></asp:TextBox>
                                        <span class="red12">* </span>密码长度在 6-16 位之间。
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" colspan="2" align="left" bgcolor="#FFFFFF" class="hui12">
                                        <hr color="#CCCCCC" style="height: 1px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right" bgcolor="#FFFFFF" class="hui12">
                                        网站名称：
                                    </td>
                                    <td bgcolor="#FFFFFF" class="hui12" style="padding-left: 10px;">
                                        <label class="blue">
                                            <asp:TextBox ID="tbSiteName" runat="server" class="in_text" size="20"></asp:TextBox>
                                            <span class="red12">* </span>
                                        </label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right" bgcolor="#FFFFFF" class="hui12">
                                        网址：
                                    </td>
                                    <td bgcolor="#FFFFFF" class="hui12" style="padding-left: 10px;">
                                        <label class="blue">
                                            <asp:TextBox ID="tbSiteURL" runat="server" class="in_text" size="20"></asp:TextBox>
                                            <span class="red12">* </span>
                                        </label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" colspan="2" align="left" bgcolor="#FFFFFF" class="hui12">
                                        <hr color="#CCCCCC" style="height: 1px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right" bgcolor="#FFFFFF" class="hui12">
                                        联系电话：
                                    </td>
                                    <td bgcolor="#FFFFFF" class="hui12" style="padding-left: 10px;">
                                            <asp:TextBox ID="tbTel" runat="server" class="in_text" size="20"></asp:TextBox>
                                            <span class="red12">*</span><span class="red12">固定电话和手机均可</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right" bgcolor="#FFFFFF" class="hui12">
                                        E-mail：
                                    </td>
                                    <td bgcolor="#FFFFFF" class="style5" style="padding-left: 10px;">
                                        <asp:TextBox ID="tbEmail" runat="server" class="in_text" size="20"></asp:TextBox>
                                        <span class="red12">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right" bgcolor="#FFFFFF" class="hui12">
                                        QQ：
                                    </td>
                                    <td bgcolor="#FFFFFF" class="hui12" style="padding-left: 10px;">
                                        <asp:TextBox ID="tbQQ" runat="server" class="in_text" size="20"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="CheckCode2" runat="server">
                                    <td height="28" align="right" bgcolor="#FFFFFF" class="hui12">
                                        验证码：
                                    </td>
                                    <td bgcolor="#FFFFFF"  style="padding-left: 10px;">
                                        <asp:TextBox ID="tbCheckCode" runat="server" MaxLength="6" class="in_text" Width="50px"></asp:TextBox>
                                        <ShoveWebUI:ShoveCheckCode ID="ShoveCheckCode2" runat="server" ForeColor="CornflowerBlue"
                                            BackColor="SeaShell" Charset="All" Height="20px" SupportDir="~/ShoveWebUI_client"
                                            Style="vertical-align: top; padding-top: 3px;"></ShoveWebUI:ShoveCheckCode>
                                            <span class="red12">* </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right" bgcolor="#FFFFFF">
                                        <hr color="#CCCCCC" style="height: 1px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right" bgcolor="#FFFFFF" class="hui12">
                                        &nbsp;
                                    </td>
                                    <td bgcolor="#FFFFFF" class="blue12_line">
                                        <asp:CheckBox ID="ckbAgree" runat="server" Checked="True" />
                                        接受好友请求!同意广告商家<a target="_blank" href="../Web/UserRegAgree.aspx?type=CPS" style="text-decoration: underline;
                                            font-weight: bold;">注册协议</a>。
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" colspan="2" align="left" bgcolor="#FFFFFF" class="hui12">
                                        <asp:Label ID="lblInputError" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" bgcolor="#FFFFFF">
                                    </td>
                                    <td bgcolor="#FFFFFF" class="hui12" style="padding-top: 15px;">
                                        <ShoveWebUI:ShoveConfirmButton ID="btnReg" Style="cursor: pointer;" runat="server"
                                            Width="204" Height="40" CausesValidation="False" BackgroupImage="images/bt_queding.jpg"
                                            BorderStyle="None" OnClick="btnReg_Click" OnClientClick="if(!checkReg()){return false};" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table width="200" border="0" align="right" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                    <tr>
                        <td height="28" background="images/title_bg_hui.jpg" bgcolor="#FFFFFF" class="hui14"
                            style="padding-left: 15px;">
                            中奖公告
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#FFFFFF">
                            <div runat="server" id="divWinUsers" style="padding-top: 5px; padding-bottom: 5px">
                            </div>
                            <hr color='#CCCCCC' style='height: 1px;' />
                            <table width="97%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <asp:Repeater ID="rptWinAffiches" runat="server" OnItemDataBound="rptWinAffiches_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="12" height="23" class="hui14">
                                                <p>
                                                    &#9642;</p>
                                            </td>
                                            <td width="308" class="blue12">
                                                <asp:HyperLink ID="hlWinAffichesTitle" runat="server" Target="_blank"></asp:HyperLink>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
                        </td>
                    </tr>
                </table>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>

    <script type="text/javascript" language="javascript">
        function checkUserName() {

            var userName = document.getElementById("tbUserName").value;
            var result = Home_Room_PromoteCpsReg.CheckUserName(userName).value;
            if (userName.trim() == "") {
                spCheckResult.innerHTML = "<font color='red'>用户名不能为空</font>";
                document.getElementById("tbUserName").value = "";
                alert("用户名不能为空!");
                return false;
            }

            if (Number(result) < 0) {
                if (Number(result) == -1) {
                    spCheckResult.innerHTML = "<font color='red'>对不起用户名中含有禁止使用的字符</font>";
                    alert("对不起用户名中含有禁止使用的字符");
                    return false;
                }

                if (Number(result) == -2) {
                    spCheckResult.innerHTML = "<font color='red'>用户名 " + userName + " 已被占用，请重新输入一个</font>";
                    alert("用户名 " + userName + " 已被占用，请重新输入一个");
                    return false;
                }

                if (Number(result) == -3) {
                    spCheckResult.innerHTML = "<font color='red'>用户名长度在 5-16 个英文字符或数字、中文 3-8 之间。</font>";
                    alert("用户名长度在 5-16 个英文字符或数字、中文 3-8 之间。");
                    return false;
                }
            }
            else {
                spCheckResult.innerHTML = "<font color='green'>用户名 <font color='red'>" + userName + "</font> 可以使用</font>";

                return true;
            }
        }

        function checkReg() {
            var userName = document.getElementById("tbUserName").value;
            var password = document.getElementById("tbPassword").value;
            var email = document.getElementById("tbEmail").value;

            if (userName.trim() == "") {
                document.getElementById("tbUserName").value = "";
                alert("用户名不能为空。");

                return false;
            }

            if (password.trim() == "") {
                document.getElementById("tbPassword").value = "";
                alert("密码不能为空。");

                return false;
            }

            if (!document.getElementById("tbSiteName").value) {
                document.getElementById("ckbAgree").value = "";
                alert("网站名称不能为空!");
                return false;
            }
            if (!document.getElementById("tbSiteURL").value) {
                document.getElementById("ckbAgree").value = "";
                alert("网站地址不能为空!");
                return false;
            }

            if (email.trim() == "") {
                document.getElementById("tbEmail").value = "";
                alert("邮箱不能为空。");
                return false;
            }
            if (!document.getElementById("ckbAgree").value) {
                document.getElementById("ckbAgree").value = true;
                alert("必须同意本站会员注册协议!");
                return false;
            }

            if (!checkUserName()) {
                return false;
            }

            var result = Home_Room_PromoteCpsReg.CheckReg(userName, password, email).value;

            if (result != "") {
                alert(result);

                return false;
            }

            return true;
        }
    </script>

    <asp:HiddenField ID="hType" runat="server" />
    <asp:HiddenField ID="hUserID" runat="server" />
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>

<script language="javascript" type="text/javascript">
    // <![CDATA[
    var sampleDiv = new scrollingAD("scrollWinUsers");
    sampleDiv.width = 200;
    sampleDiv.height = 100;
    sampleDiv.delay = 20;
    sampleDiv.pauseTime = 5000;
    sampleDiv.move();
    // ]]>
</script>

