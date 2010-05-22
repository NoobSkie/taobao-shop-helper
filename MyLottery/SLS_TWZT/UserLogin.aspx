<%@ page language="C#" autoeventwireup="true" CodeFile="~/UserLogin.aspx.cs" inherits="UserLogin" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员注册 -
        <%=_Site.Name %>－双色球开奖/双色球走势图查询-手机买彩票，就上<%=_Site.Name %></title>
    <meta name="description" content="会员注册，<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。" />
    <meta name="keywords" content="会员注册，双色球开奖，双色球走势图，3d走势图，福彩3d，时时彩" />
    <link href="Home/Room/Style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #box1
        {
            overflow: hidden;
            width: 1002px;
            margin-right: auto;
            margin-left: auto;
            padding: 0px;
        }
        #content1
        {
            width: 1002px;
            padding: 0px;
            overflow: hidden;
        }
    </style>
    <script type="text/javascript">
        function ReloadImage2() {
            Login_Iframe_Reg.location.href = "<%=LoginIframeUrl %>";
//            var o_CheckCode = document.getElementById("Login_Iframe_Reg").contentWindow.document.getElementById("ShoveCheckCode1_imgCode");
//            document.getElementById("ShoveCheckCode2_imgCode").src = o_CheckCode.src;
        }
    </script>
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<body >
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <input type="hidden" id="HomePage" runat="server" />
    <div style="display: none;">
        <iframe id="Login_Iframe_Reg" name="Login_Iframe_Reg" width="100%" frameborder="0" scrolling="no"
            src="<%=LoginIframeUrl %>"></iframe>
    </div>
    <div id="box1">
        <div id="content1">
            <div id="user_left">
                <table width="300" border="0" cellspacing="1" cellpadding="0" style="margin-top: 6px;
                    height: 551px;" bgcolor="#DDDDDD">
                    <tr>
                        <td valign="top" bgcolor="#FFFFFF" style="padding-bottom: 15px;">
                            <table width="298" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <img src="Home/Room/images/user_title_1.jpg" width="298" height="62" />
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
                                <asp:Panel ID="Panel1" runat="server" Visible="false">
                                    <tr id="CheckCode" runat="server">
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
                                        <td width="54" class="blue12_line">
                                            &nbsp;&nbsp;<a href="UserLogin.aspx">刷新</a>
                                        </td>
                                    </tr>
                                </asp:Panel>
                            </table>
                            <table width="260" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
                                <tr>
                                    <td width="109" height="36" align="right" class="hui12">
                                        <ShoveWebUI:ShoveConfirmButton ID="btnLogin" Style="cursor: pointer;" runat="server"
                                            Width="83px" Height="29px" CausesValidation="False" BackgroupImage="Home/Room/images/bt_denglu.jpg"
                                            BorderStyle="None" OnClick="btnLogin_Click" />
                                    </td>
                                    <td width="151" class="blue12_line" style="padding-left: 10px;">
                                        <a href="Home/Room/ForgetPassword.aspx" target="_top">忘记密码</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="15" colspan="2" align="right" class="hui12">
                                        <hr style="height: 1px; color: #DDDDDD" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" colspan="2" align="left" class="hui12">
                                        您还可以通过以下共享登陆口登录：
                                    </td>
                                </tr>
                            </table>
                            <table width="260" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 15px;">
                                <tr>
                                    <td>
                                        <table width="125" border="0" cellspacing="1" cellpadding="0" bgcolor="#DDDDDD">
                                            <tr>
                                                <td height="55" align="center" bgcolor="#E3F2FD" class="red12">
                                                    <%=_Site.Name %>支持3亿QQ会员直接登录
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table width="125" border="0" cellspacing="1" cellpadding="0" bgcolor="#DDDDDD">
                                            <tr>
                                                <td height="30" align="center" bgcolor="#FFFFFF">
                                                    <a href="Home/Room/TencentLogin.aspx" target="_blank">
                                                        <img src="Home/Room/images/user_logo_cft.gif" width="123" height="28" border="0" /></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="25" align="center" bgcolor="#F7F7F7" class="hui12">
                                                    <a href="Home/Room/TencentLogin.aspx" target="_blank">QQ会员登录</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table width="268" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 0px;">
                                <tr>
                                    <td width="260" height="15" align="right" class="hui12">
                                        <hr style="height: 1px; color: #DDDDDD" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="left" class="hui14">
                                        客服服务
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" align="left" class="hui12">
                                        您如遇到问题请联系<%=_Site.Name %>客服：
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" align="left" class="blue12_line">
                                        <span class="hui12">免费客服电话：</span><span class="red14_2"><%= _Site.ServiceTelephone %></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" align="left" class="hui12">
                                        邮箱：<a href="mailto:BD@handtouchworld.com" target="_blank">BD@handtouchworld.com</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" align="right" class="hui12">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="user_center">
                <table width="402" border="0" cellspacing="0" cellpadding="0" style="margin-top: 6px;">
                    <tr>
                        <td>
                            <img id="imgLoginAD" src="Home/Room/images/user_banner.jpg" width="402" height="187" />
                        </td>
                    </tr>
                </table>

                <script type="text/javascript" language="javascript">
                    if (window.location.href.indexOf("lottery.usportnews.com") > 0) {
                        document.getElementById("imgLoginAD").src = "Images_OT/ot_login_ad.jpg";
                    }
                </script>

                <table width="402" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="54" colspan="2" class="red14_2" style="padding-left: 25px;">
                            登录后，您即可享受以下会员服务：
                        </td>
                    </tr>
                    <tr>
                        <td width="51" height="36" align="right">
                            &nbsp;<img src="Home/Room/images/cp_logo.gif" width="25" height="25" />
                        </td>
                        <td width="351" class="hui14_2" style="padding-left: 15px;">
                            在线购买彩票，专家预测为您指明方向
                        </td>
                    </tr>
                    <tr>
                        <td height="36" align="right">
                            <img src="Home/Room/images/icon_31.gif" width="19" height="20" />
                        </td>
                        <td class="hui14_2" style="padding-left: 15px;">
                            交3G彩民、看彩情，时刻掌握彩票最新资讯
                        </td>
                    </tr>
                    <tr>
                        <td height="36" align="right">
                            <img src="Home/Room/images/icon_21.gif" width="19" height="20" />
                        </td>
                        <td class="hui14_2" style="padding-left: 15px;">
                            与众多彩民在线互动交流
                        </td>
                    </tr>
                    <tr>
                        <td height="36" align="right">
                            <img src="Home/Room/images/icon_9.gif" width="20" height="23" />
                        </td>
                        <td class="hui14_2" style="padding-left: 15px;">
                            快乐游戏，娱乐购彩
                        </td>
                    </tr>
                </table>
            </div>
            <div id="user_right">
                <table width="300" border="0" cellspacing="1" cellpadding="0" style="margin-top: 6px;"
                    bgcolor="#DDDDDD">
                    <tr>
                        <td valign="top" bgcolor="#FFFFFF" style="padding-bottom: 15px;">
                            <table width="298" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <img src="Home/Room/images/user_title_2.jpg" width="298" height="62" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 0px 10px 0px 10px;" height="15">
                                        <hr style="height: 1px; color: #DDDDDD" />
                                    </td>
                                </tr>
                            </table>
                            <table width="268" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="72" height="33" align="right" class="hui12">
                                        用户名：
                                    </td>
                                    <td width="203" class="blue12_line">
                                        <asp:TextBox ID="tbRegUserName" runat="server" class="in_text" size="14" MaxLength="16"></asp:TextBox>
                                        <span class="red12">*</span> <a href="javascript:;" onclick="return checkUserName();">
                                            检测用户名</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="36" align="right" class="hui12">
                                        &nbsp;
                                    </td>
                                    <td class="hui122">
                                        <span id="spCheckResult">5-16个字符，由中英文及数字组成<span class="red12"><br />
                                            一旦提交将不可更改</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="33" align="right" class="hui12">
                                        密&nbsp;&nbsp;&nbsp;码：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbFormPassword" runat="server" TextMode="Password" class="in_text"
                                            size="15" MaxLength="16"></asp:TextBox>
                                        <span class="red12">*</span> <span class="hui122">6-16位间</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="33" align="right" class="hui12">
                                        确认密码：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbPassword2" runat="server" TextMode="Password" class="in_text"
                                            size="15" MaxLength="16"></asp:TextBox>
                                        <span class="red12">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="33" align="right" class="hui12">
                                        邮件地址：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbEmail" runat="server" class="in_text" size="20">@</asp:TextBox>
                                        <span class="red12">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right" class="hui12">
                                        &nbsp;
                                    </td>
                                    <td class="hui122">
                                        非常重要，当您要找回密码的时候！
                                    </td>
                                </tr>
                                <tr>
                                    <td height="33" align="right" class="hui12">
                                        真实姓名：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbRealityName" runat="server" class="in_text" size="20"></asp:TextBox><span
                                            class="red12">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="33" align="right" class="hui12">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <span class="red12">非常重要，这是您提款的重要依据，必须与提款银行卡户名一致。真实姓名一旦提交将不可更改 </span>
                                    </td>
                                </tr>
                                <!--
                                <tr>
                                    <td height="33" align="right" class="hui12">
                                        身份证号码：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbIDCardNumber" runat="server" class="in_text" size="20" MaxLength="18"></asp:TextBox>
                                        
                                    </td>
                                </tr>-->
                                <tr id="CheckCodeReg" runat="server">
                                    <td height="33" align="right" class="hui12">
                                        验证码：
                                    </td>
                                    <td class="blue12_line">
                                        <asp:TextBox ID="tbRegCheckCode" runat="server" MaxLength="6" class="in_text" Width="50px"></asp:TextBox>
                                        <ShoveWebUI:ShoveCheckCode ID="ShoveCheckCode2" runat="server" ForeColor="CornflowerBlue"
                                            BackColor="SeaShell" Charset="All" Height="20px" SupportDir="~/ShoveWebUI_client"
                                            Style="vertical-align: top; padding-top: 3px;"></ShoveWebUI:ShoveCheckCode>
                                        <span class="red12">*</span><a href="JavaScript:ReloadImage2();">刷新</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="33" align="right" class="hui12">
                                        &nbsp;
                                    </td>
                                    <td class="blue12_line">
                                        <label>
                                            <asp:CheckBox ID="ckbAgree" runat="server" Text="" Checked="true" />
                                            我已阅读并同意<a href="Home/Web/UserRegAgree.aspx" target="_blank"><%=_Site.Name %>用户协议</a></label>
                                    </td>
                                </tr>
                                <tr style="padding-bottom: 2px;">
                                    <td height="33" align="right" class="hui12" valign="top">
                                        默认主页：
                                    </td>
                                    <td class="blue12_line">
                                        <label>
                                            <asp:CheckBox ID="ckbHomePage" runat="server" Text="" Checked="true" />
                                            将<%=_Site.Name %>设为我的默认主页</label><br />
                                        （您浏览器的默认主页是您每次打开浏览器时首先显示的网页）
                                    </td>
                                </tr>
                                <tr>
                                    <td height="36" align="right" class="hui12">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <ShoveWebUI:ShoveConfirmButton ID="btnReg" Style="cursor: pointer;" runat="server"
                                            Width="83px" Height="29px" CausesValidation="False" BackgroupImage="Home/Room/images/bt_zhuce.jpg"
                                            BorderStyle="None" OnClick="btnReg_Click" OnClientClick="if(!checkReg()){return false}else{if(document.getElementById('ckbHomePage').checked){this.style.behavior='url(#default#homepage)';this.setHomePage(document.getElementById('HomePage').value);};}" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        </div>
        <div>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>

    <script src="JavaScript/Public.js" type="text/javascript"></script>

    </form>
    <!--#includefile="Html/TrafficStatistics/1.htm"-->
</body>
</html>

<script type="text/javascript" language="javascript">
    function checkUserName() {
        var userName = document.getElementById("tbRegUserName").value;
        var result = UserLogin.CheckUserName(userName).value;

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
        //var IDCardNumber = document.getElementById("tbIDCardNumber").value;
        var CheckCode = document.getElementById("tbRegCheckCode");
        var IsAgree = document.getElementById("ckbAgree").checked;

        if (!IsAgree) {
            alert("必须同意注册协议才能注册！");

            return false;
        }

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

        //if (IDCardNumber.trim() == "") {
            //document.getElementById("tbIDCardNumber").value = "";
            //alert("身份证不能为空。");

            //return false;
        // }
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
        var inputCheckCode = document.getElementById("Login_Iframe_Reg").contentWindow.document.getElementById("ShoveCheckCode1_tbCode").value; // document.getElementById("ShoveCheckCode2_tbCode").value;        
        var result = UserLogin.CheckReg(userName, password, password2, email, realityName,inputCheckCode,CheckCode.value, "").value;
        if (result != "") {
            alert(result);

            return false;
        }
        
        return true;
    }

    function document.onkeydown() {
        if (event.keyCode == 13)//回车输入登录
        {
            event.returnValue = false;
            document.getElementById("<%=btnLogin.ClientID%>").click();
        }
    }

    function UserInit() {
        var o_CheckCode = document.getElementById("Login_Iframe_Reg").contentWindow.document.getElementById("ShoveCheckCode1_imgCode");
        document.getElementById("ShoveCheckCode2_imgCode").src = o_CheckCode.src;
    }
</script>

