<%@ page language="C#" autoeventwireup="true" CodeFile="~/UserReg.aspx.cs" inherits="UserReg" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员注册 -
        <%=_Site.Name %>－双色球开奖/双色球走势图查询-手机买彩票，就上<%=_Site.Name %></title>
    <meta name="description" content="会员注册，<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。" />
    <meta name="keywords" content="会员注册，双色球开奖，双色球走势图，3d走势图，福彩3d，时时彩" />
    <link href="Home/Room/Style/css.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="favicon.ico" />

    <script type="text/javascript">
        function ReloadImage2() {
            Login_Iframe_Reg.location.href = "<%=LoginIframeUrl %>";
            var o_CheckCode = document.getElementById("Login_Iframe_Reg").contentWindow.document.getElementById("ShoveCheckCode1_imgCode");
            document.getElementById("ShoveCheckCode2_imgCode").src = o_CheckCode.src;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <input type="hidden" id="HomePage" runat="server" />
    <div style="display: none;">
        <iframe id="Login_Iframe_Reg" name="Login_Iframe_Reg" width="100%" frameborder="0"
            scrolling="no" src="<%=LoginIframeUrl %>"></iframe>
    </div>
    <div id="box">
        <table width="1002" border="0" cellspacing="1" cellpadding="0" style="margin-top: 0px;"
            bgcolor="">
            <tr>
                <td height="50" align="center" valign="middle" class="red14_2">
                    <img src="Home/Room/Images/user_title_2.gif" width="326" height="33" />
                </td>
            </tr>
            <tr>
                <td height="333" align="center" valign="top">
                    <table width="900" border="0" cellspacing="0" cellpadding="0" bgcolor="#BCD2E9">
                        <tr>
                            <td height="1" bgcolor="#cccccc">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#FFFFFF" style="padding-top: 10px; padding-bottom: 0px;">
                                <table width="700" border="0" cellspacing="0" bgcolor="#BCD2E9" cellpadding="0">
                                    <tr>
                                        <td height="312" bgcolor="#FFFFFF" style="padding-top: 10px; padding-bottom: 0px;">
                                            <table width="556" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="111" height="26" align="right" class="hui12">
                                                        用户名：
                                                    </td>
                                                    <td width="210" height="26" align="left" colspan="2" class="blue12_line">
                                                        <asp:TextBox ID="tbRegUserName" runat="server" class="in_text" size="14" MaxLength="16"></asp:TextBox>
                                                        <span class="red12">*</span> <a href="javascript:;" onclick="return checkUserName();">
                                                            检测用户名</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="111" height="20" align="right" class="hui12">
                                                        &nbsp;
                                                    </td>
                                                    <td height="20" colspan="2" align="left" class="hui12">
                                                        5-16个字符<span id="spCheckResult">，由中英文及数字组成&nbsp;<span class="red12">一旦提交将不可更改</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="26" align="right" class="hui12">
                                                        密码：
                                                    </td>
                                                    <td height="26" align="left" colspan="2">
                                                        <asp:TextBox ID="tbFormPassword" runat="server" TextMode="Password" class="in_text"
                                                            size="30" MaxLength="16"></asp:TextBox>&nbsp;&nbsp; <span class="red12">*</span>
                                                        <span class="hui122">6-16位间</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="26" align="right" class="hui12">
                                                        确认密码：
                                                    </td>
                                                    <td height="26" align="left" colspan="2">
                                                        <asp:TextBox ID="tbPassword2" runat="server" TextMode="Password" class="in_text"
                                                            size="30" MaxLength="16"></asp:TextBox>&nbsp;&nbsp; <span class="red12">*</span><span
                                                                class="hui12">请重新输入密码</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="26" align="right" class="hui12">
                                                        邮件地址：
                                                    </td>
                                                    <td height="26" align="left" colspan="2">
                                                        <asp:TextBox ID="tbEmail" runat="server" class="in_text" size="30">@</asp:TextBox>&nbsp;&nbsp;
                                                        <span class="red12">*<span class="hui12">非常重要，当您要找回密码的时候！</span></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="26" align="right" class="hui12">
                                                        真实姓名：
                                                    </td>
                                                    <td height="26" align="left" colspan="2">
                                                        <asp:TextBox ID="tbRealityName" runat="server" class="in_text" size="30"></asp:TextBox>&nbsp;&nbsp;
                                                        <span class="red12">*</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="20" align="right" class="hui12">
                                                        &nbsp;
                                                    </td>
                                                    <td height="20" colspan="2" align="left">
                                                        <span class="red12">非常重要，这是您提款的重要依据，必须与提款银行卡户名一致。真实姓名一旦提交将不可更改 </span>
                                                    </td>
                                                </tr>
                                                <tr id="CheckCodeReg" runat="server">
                                                    <td height="26" align="right" class="hui12">
                                                        验证码：
                                                    </td>
                                                    <td height="26" colspan="2" align="left">
                                                        <asp:TextBox ID="tbRegCheckCode" runat="server" MaxLength="6" class="in_text" Width="50px"></asp:TextBox>
                                                        <ShoveWebUI:ShoveCheckCode ID="ShoveCheckCode2" runat="server" ForeColor="CornflowerBlue"
                                                            BackColor="SeaShell" Charset="OnlyNumeric" Height="20px" SupportDir="~/ShoveWebUI_client"
                                                            Style="vertical-align: top; padding-top: 3px;"></ShoveWebUI:ShoveCheckCode>
                                                        <span class="red12">*</span><a href="JavaScript:ReloadImage2();">刷新</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="26" align="right" class="hui12">
                                                        默认主页：
                                                    </td>
                                                    <td height="26" align="left">
                                                        <asp:CheckBox ID="ckbHomePage" runat="server" Text="" Checked="true" />
                                                        <span class="hui12">我将<%=_Site.Name %>设为我的默认主页</span>
                                                    </td>
                                                    <td height="26" align="right">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="20" align="right" class="hui12">
                                                        &nbsp;
                                                    </td>
                                                    <td height="20" colspan="2" align="left">
                                                        <span class="hui12">（您浏览器的默认主页是您每次打开浏览器时首先显示的网页） </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="40" colspan="3" align="center" class="hui12">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="42%" height="55" align="right" valign="bottom">
                                                                    <ShoveWebUI:ShoveConfirmButton ID="btnReg" Style="cursor: pointer;" runat="server"
                                                                        Width="83px" Height="29px" CausesValidation="False" BackgroupImage="Home/Room/images/bt_zhuce.jpg"
                                                                        BorderStyle="None" OnClick="btnReg_Click" OnClientClick="if(!checkReg()){return false}else{if(document.getElementById('ckbHomePage').checked){this.style.behavior='url(#default#homepage)';this.setHomePage(document.getElementById('HomePage').value);};}" />
                                                                </td>
                                                                <td width="58%" align="left" valign="bottom">
                                                                    <asp:CheckBox ID="ckbAgree" runat="server" Text="" Checked="true" />
                                                                    我已阅读并同意<span class="red12"><a href="Home/Web/UserRegAgree.aspx" target="_blank">《<%=_Site.Name %>用户协议》</a></label></span>
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
                </td>
            </tr>
        </table>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>

    <script src="JavaScript/Public.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        String.prototype.trim = function() {
            return this.replace(/(^\s*)|(\s*$)/g, "");
        }

        function checkInput() {
            var userName = document.getElementById("tbFormUserName").value;
            var email = document.getElementById("tbEmail").value;
            var checkCode = document.getElementById("tbFormCheckCode").value;

            if (userName.trim() == "") {
                document.getElementById("tbFormUserName").value = "";
                alert("用户名不能为空");

                return false;
            }

            if (email.trim() == "") {
                document.getElementById("tbEmail").value = "";
                alert("邮箱不能为空");

                return false;
            }

            if (checkCode.trim() == "") {
                document.getElementById("tbFormCheckCode").value = "";
                alert("验证码不能为空");

                return false;
            }

            return true;
        }
    </script>

    </form>
    <!--#includefile="Html/TrafficStatistics/1.htm"-->
</body>
</html>

<script type="text/javascript" language="javascript">
    function checkUserName() {
        var userName = document.getElementById("tbRegUserName").value;
        var result = UserReg.CheckUserName(userName).value;

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

        //var result = UserReg.CheckReg(userName, password, password2, email, realityName, IDCardNumber).value;
        var inputCheckCode = document.getElementById("Login_Iframe_Reg").contentWindow.document.getElementById("ShoveCheckCode1_tbCode").value; // document.getElementById("ShoveCheckCode2_tbCode").value;
        var result = UserReg.CheckReg(userName, password, password2, email, realityName, inputCheckCode, CheckCode.value, "").value;
        if (result != "") {
            alert(result);

            return false;
        }

        return true;
    }

    function UserInit() {
        var o_CheckCode = document.getElementById("Login_Iframe_Reg").contentWindow.document.getElementById("ShoveCheckCode1_imgCode");
        document.getElementById("ShoveCheckCode2_imgCode").src = o_CheckCode.src;
    }
  
</script>

