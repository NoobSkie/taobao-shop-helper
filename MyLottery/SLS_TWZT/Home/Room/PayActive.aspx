<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/PayActive.aspx.cs" inherits="Home_Room_PayActive" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>充值送礼大活动-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <script src="JavaScript/Marquee.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            font-family: "宋体";
            font-size: 12px;
            margin: 0px;
            padding: 0px;
        }
        .bai12
        {
            font-family: "宋体";
            font-size: 12px;
            color: #fff;
            line-height: 18px;
        }
        .bule12
        {
            font-family: "宋体";
            font-size: 12px;
            color: #006699;
        }
        .red12
        {
            font-family: "宋体";
            font-size: 12px;
            color: #C00;
        }
        .hule12 A:link
        {
            font-family: "tahoma";
            color: #006699;
            text-decoration: none;
        }
        .hule12 A:active
        {
            font-family: "tahoma";
            color: #006699;
            text-decoration: none;
        }
        .hule12 A:visited
        {
            font-family: "tahoma";
            color: #006699;
            text-decoration: none;
        }
        .hule12 A:hover
        {
            font-family: "tahoma";
            color: #C00;
            text-decoration: none;
        }
    </style>
<link rel="shortcut icon" href="../../favicon.ico" /></head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <table width="1004" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="259">
                <img src="images/index_r1_c1.jpg" width="259" height="56" />
            </td>
            <td width="398">
                <img src="images/index_r1_c5.jpg" width="398" height="56" border="0" usemap="#Map" />
            </td>
            <td width="349">
                <img src="images/index_r1_c13.jpg" width="347" height="56" border="0" usemap="#Map2" />
            </td>
        </tr>
        <tr>
            <td><img src="images/index_r2_c1.jpg" width="259" height="192"  style="vertical-align:bottom"/></td>
            <td><embed height="192" width="398" src="Images/index_r2_c5.swf" type="application/x-shockwave-flash"></embed></td>
            <td><img src="images/index_r2_c13.jpg" width="347" height="192" style="vertical-align:bottom"/></td>
        </tr>
        <tr>
            <td colspan="3">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="19%"><img src="images/index_r3_c1.jpg" width="191" height="75" style="vertical-align:bottom"/></td>
                        <td width="18%"><a href="BottomNavigationPages/zz.html" target="_blank"><img src="images/index_r3_c4.jpg" width="188" height="75" border="0" style="vertical-align:bottom"/></a></td>
                        <td width="27%"><img src="images/index_r3_c7.jpg" width="320" height="75" style="vertical-align:bottom"/></td>
                        <td width="36%"><img src="images/index_r3_c14.jpg" width="305" height="75" style="vertical-align:bottom"/></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" bgcolor="#C6012F">
                <img src="images/index_r4_c1.jpg" width="104" height="136" /><img src="images/index_r4_c3.jpg"
                    width="155" height="136" /><img src="images/index_r4_c5.jpg" width="199" height="136" /><img
                        src="images/index_r4_c9.jpg" width="322" height="136" /><img src="images/index_r4_c17.jpg"
                            width="224" height="136" />
            </td>
        </tr>
        <tr>
            <td height="266" colspan="3" background="images/index_r6_c1.jpg">
                <table width="818" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="24" background="images/4_r1_c1.jpg" width="100%">
                            <div id="demo" style="overflow: hidden;margin-top: 5px; margin-bottom: 0px;">
                                <asp:DataList ID="dlUsers" RepeatColumns="4" runat="server" CssClass="bai12">
                                <ItemTemplate>
                                    <%# Eval("Name") %>充值了<%# Eval("Money") %>元
                                </ItemTemplate>
                                <ItemStyle Width="194px" Height="21px" HorizontalAlign="Center"/>
                                </asp:DataList>
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="840" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="12">
                            &nbsp;
                        </td>
                        <td width="330" height="126" valign="top">
                            <table width="330" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <img src="images/index_r8_c2.jpg" width="329" height="28" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="18">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="202">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="20%" height="24" align="left" class="red12">
                                                    【双色球】
                                                </td>
                                                <td width="80%" height="24" align="left" class="hule12">
                                                    dgding* 40元揽得双色球<strong><span
                                                        class="red12">113万</span></strong>元大奖！
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="24" align="left" class="red12">
                                                    【福彩3D】
                                                </td>
                                                <td height="24" align="left" class="hule12">
                                                    <%=_Site.Name %>全线出击组三加奖，揽得<span class="red12"><strong>百万</strong></span>组三奖金
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="24" align="left" class="red12">
                                                    【时时乐】
                                                </td>
                                                <td height="24" align="left" class="hule12">
                                                    “我心已旧”率众获<strong><span class="red12">12.3万</span></strong>大奖！
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="24" align="left" class="red12">
                                                    【时时彩】
                                                </td>
                                                <td height="24" align="left" class="hule12">
                                                    liuyi1998217&quot;2元轻取时时彩<strong><span
                                                        class="red12">10万</span></strong>大奖
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="24" align="left" class="red12">
                                                    【双色球】
                                                </td>
                                                <td height="24" align="left" class="hule12">
                                                    pq6910机选1注击中双色球二等奖金<strong><span
                                                        class="red12">27.6万</span></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="24" align="left" class="red12">
                                                    【双色球】
                                                </td>
                                                <td height="24" align="left" class="hule12">
                                                    bicheng722揽双色球二等奖金<strong><span
                                                        class="red12">25万</span></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="24" align="left" class="red12">
                                                    【双色球】
                                                </td>
                                                <td height="24" align="left" class="hule12">
                                                    hgy662追号喜获2等奖金<strong><span
                                                        class="red12">22.455万</span></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="24" align="left" class="red12">
                                                    【双色球】
                                                </td>
                                                <td height="24" align="left" class="hule12">
                                                    laohu0524率领百人合买捕获二等奖<span class="red12"><strong>16万</strong></span>余元
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="24" align="left" class="red12">
                                                    【福彩3D】
                                                </td>
                                                <td height="24" align="left" class="hule12">
                                                    xiaotuzi直选150倍，狂揽<strong><span
                                                        class="red12">15万</span></strong>奖金
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="24" align="left" class="red12">
                                                    【时时乐】
                                                </td>
                                                <td height="24" align="left" class="hule12">
                                                    yzy_888888惊爆中出时时乐<strong><span
                                                        class="red12">8万</span></strong>元巨奖！
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="24" align="left" class="red12">
                                                    【时时彩】
                                                </td>
                                                <td height="24" align="left" class="hule12">
                                                    “xinghun9985 ”单挑一注5星通选中<strong><span
                                                        class="red12">2.044万</span></strong>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="16">
                            <img src="images/4_r4_c9.jpg" width="8" height="353" />
                        </td>
                        <td width="480" valign="top">
                            <table width="480" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="19">
                                        &nbsp;
                                    </td>
                                    <td width="461">
                                        <img src="images/index_r8_c9.jpg" width="322" height="28" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="254" colspan="2">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td height="20" colspan="2" align="center">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="21%" height="28" align="right" class="bule12">
                                                    用户名：
                                                </td>
                                                <td width="79%" height="28" class="bule12">
                                                    <asp:TextBox ID="tbRegUserName" runat="server"  size="20" MaxLength="16"></asp:TextBox><span class="red12">*</span><a href="javascript:;" onclick="return checkUserName();">检测用户名</a> 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="28" align="right" class="bule12">
                                                    &nbsp;
                                                </td>
                                                <td height="28" class="bule12">
                                                    <span id="spCheckResult">5-16个字符，由中英文及数字组成<span class="red12">一旦提交将不可更改</span></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="28" align="right" class="bule12">
                                                    登录密码：
                                                </td>
                                                <td height="28" class="bule12">
                                                    <asp:TextBox ID="tbFormPassword" runat="server" TextMode="Password"  size="22" MaxLength="16"></asp:TextBox><span class="red12">*</span>长度在6—16位之间
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="28" align="right" class="bule12">
                                                    确认登录密码：
                                                </td>
                                                <td height="28" class="bule12">
                                                    <asp:TextBox ID="tbPassword2" runat="server" TextMode="Password" size="22" MaxLength="16"></asp:TextBox><span class="red12">*</span>请再次输入你的登录密码
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="28" align="right" class="bule12">
                                                    电子邮箱：
                                                </td>
                                                <td height="28" class="bule12">
                                                    <asp:TextBox ID="tbEmail" runat="server" size="20"></asp:TextBox><span class="red12">*</span>非常重要，当您要找回密码的时候！
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="28" align="right" class="bule12">
                                                    真实姓名：
                                                </td>
                                                <td height="28" class="bule12">
                                                    <asp:TextBox ID="tbRealityName" runat="server" size="20"></asp:TextBox><span class="red12">*</span>非常重要，这是您提款的重要依据，必须与提款银行卡户名一致。真实姓名一旦提交将不可更改!
                                                </td>
                                            </tr>
                                            <tr id="CheckCodeReg" runat="server">
                                                <td height="28" align="right" class="bule12">
                                                    验证码：
                                                </td>
                                                <td height="28" class="bule12">
                                                    <asp:TextBox ID="tbRegCheckCode" runat="server" MaxLength="6" Width="50px"></asp:TextBox>
                                                    <ShoveWebUI:ShoveCheckCode ID="ShoveCheckCode2" runat="server" ForeColor="CornflowerBlue"
                                            BackColor="SeaShell" Charset="All" Height="20px" SupportDir="~/ShoveWebUI_client"
                                            Style="vertical-align: top; padding-top: 3px;"></ShoveWebUI:ShoveCheckCode>
                                        <span class="red12">*</span><a href="PayActive.aspx">刷新</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10" colspan="2" align="center" style="padding-top: 20px">
                                                    <ShoveWebUI:ShoveConfirmButton ID="btnReg" Style="cursor: pointer;" runat="server"
                                            Width="111px" Height="38px" CausesValidation="False" BackgroupImage="images/index_r10_c12.jpg"
                                            BorderStyle="None" OnClick="btnReg_Click" OnClientClick="if(!checkReg()){return false;}" />
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
        <tr>
            <td height="12" colspan="3" background="images/index_r6_c1.jpg">
                <table width="1002" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="285">
                            <img src="images/index_r12_c1.jpg" width="285" height="80" />
                        </td>
                        <td width="222">
                            <img src="images/index_r12_c6.jpg" width="222" height="80" />
                        </td>
                        <td width="210">
                            <img src="images/index_r12_c10.jpg" width="210" height="80" />
                        </td>
                        <td width="285">
                            <img src="images/index_r12_c15.jpg" width="283" height="80" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="1004" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="10" align="center" bgcolor="#CC0033" class="bai12">
                
            </td>
        </tr>
    </table>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
<script type="text/javascript" language="javascript">
    var sampleDiv = new scrollingAD("demo");
    sampleDiv.width = 818;
    sampleDiv.height = 24;
    sampleDiv.delay = 20;
    sampleDiv.pauseTime = 2000;
    sampleDiv.move();

    function checkUserName() {
        var userName = document.getElementById("tbRegUserName").value;
        var result = Home_Room_PayActive.CheckUserName(userName).value;

        if (userName.trim() == "") {
            spCheckResult.innerHTML = "<font color='red'>用户名不能为空</font>";
            document.getElementById("tbRegUserName").value = "";
            alert("用户名不能为空");
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
        var userName = document.getElementById("tbRegUserName").value;
        var password = document.getElementById("tbFormPassword").value;
        var password2 = document.getElementById("tbPassword2").value;
        var email = document.getElementById("tbEmail").value;
        var realityName = document.getElementById("tbRealityName").value;
        var CheckCode = document.getElementById("tbRegCheckCode");
        
        if (userName.trim() == "") {
            document.getElementById("tbRegUserName").value = "";
            alert("用户名不能为空。");

            return false;
        }

        if (password.trim() == "") {
            document.getElementById("tbFormPassword").value = "";
            alert("密码不能为空。");

            return false;
        }

        if (password2.trim() == "") {
            document.getElementById("tbPassword2").value = "";
            alert("确认密码不能为空。");

            return false;
        }

        if (password != password2) {
            alert("两次密码输入不一致，请仔细检查。");

            return false;
        }

        if (email.trim() == "") {
            document.getElementById("tbEmail").value = "";
            alert("邮箱不能为空。");

            return false;
        }

        if (realityName.trim() == "") {
            document.getElementById("tbRealityName").value = "";
            alert("真实姓名不能为空。");

            return false;
        }

        if (CheckCode != null && CheckCode.value.trim() == "") {
            alert("请输入验证码！");

            return false;
        }

        if (!checkUserName()) {
            return false;
        }

        var result = Home_Room_PayActive.CheckReg(userName, password, password2, email, realityName, "").value;
        if (result != "") {
            alert(result);

            return false;
        }

        return true;
    }
</script>