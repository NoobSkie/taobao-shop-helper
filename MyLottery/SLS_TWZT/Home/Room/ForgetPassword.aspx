<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/ForgetPassword.aspx.cs" inherits="Home_Room_ForgetPassword" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>取回密码-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %></title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <meta name="keywords" content="取回密码-<%=_Site.Name %>"/>
     
    <link href="../Web/Style/css.css" rel="stylesheet" type="text/css" />
    <link href="../Web/Style/div.css" rel="stylesheet" type="text/css" />
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-top: 10px; text-align: center;">
        <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
        <table width="1002" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="15" height="27">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td width="202" align="right" class="blue12" style="padding-right: 10px;">
                                免费咨询电话：<span class="red14"><%= _Site.ServiceTelephone %></span>
                            </td>
                            <td width="77">
                                <a href="#">
                                    <img src="images/head_zixun.jpg" width="77" height="20" border="0" /></a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="2" bgcolor="#6699CC">
                </td>
            </tr>
            <tr>
                <td>
                    <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="42" align="center">
                                <h1><img src="images/user_qhmm.gif" width="248" height="33" alt="取回密码"/></h1>
                            </td>
                        </tr>
                        <tr>
                            <td height="15">
                                <hr style="height: 1px; color: #DDDDDD" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pSetp1" runat="server">
                                    <table width="660" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 20px;">
                                        <tr>
                                            <td height="36" colspan="2" align="center" class="red14_2">
                                                <img src="images/qmlc-5.gif" width="542" height="73" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="122" height="36" align="right" class="black12">
                                                用户名：
                                            </td>
                                            <td width="538" align="left">
                                                <label>
                                                    <asp:TextBox ID="tbFormUserName" runat="server" class="in_text" size="25"></asp:TextBox>
                                                    <span class="red142">*</span> <span class="red">检测用户名。</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="36" align="right" class="black12">
                                                邮&nbsp;&nbsp;&nbsp;箱：
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="tbEmail" runat="server" class="in_text" size="25"></asp:TextBox>
                                                <span class="red142">*</span><br />
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="36" align="right" class="black12">
                                                &nbsp;
                                            </td>
                                            <td class="hui12" align="left">
                                               <span class="red">请填写您已激活的邮箱地址，如果邮箱没有激活，请联系客服人员帮你解决，谢谢合作。</span>
                                            </td>
                                        </tr>
                                        <tr id="CheckCode" bgcolor="#C0DBF9" runat="server">
                                            <td height="33" align="right" bgcolor="#FFFFFF" class="black12">
                                                验证码：
                                            </td>
                                            <td align="left" bgcolor="#FFFFFF" class="black12">
                                                <label>
                                                    <asp:TextBox ID="tbFormCheckCode" runat="server" MaxLength="6" class="in_text" Width="50px"></asp:TextBox>
                                                    <ShoveWebUI:ShoveCheckCode ID="ShoveCheckCode1" runat="server" ForeColor="CornflowerBlue"
                                                        BackColor="SeaShell" Charset="All" Height="20px" SupportDir="~/ShoveWebUI_client"
                                                        Style="vertical-align: top; padding-top: 3px;"></ShoveWebUI:ShoveCheckCode>
                                                </label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="36" align="right" class="black12">
                                                &nbsp;
                                            </td>
                                            <td class="hui12" align="left">
                                                正确填写通行证和邮箱后，系统会发送一封邮件到您的邮箱<br />
                                                您可以点击邮件中的链接进行修改密码的操作
                                                <br />
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td height="54" align="right" class="hui12">
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                <ShoveWebUI:ShoveConfirmButton ID="btnGetPassword" Style="cursor: hand; color: #000000;"
                                                    BackgroupImage="images/qhmm-5.gif" runat="server" Height="28px"
                                                    Width="103px" CausesValidation="False" BorderStyle="None" OnClick="btnGetPassword_Click"
                                                    OnClientClick="if(!checkInput()){return false;}" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pStep2" runat="server">
                                    <table width="660" border="0" cellspacing="0" cellpadding="1" 
                                        style="margin-top: 10px;">
                                        <tr>
                                            <td height="30" align="center"  class="black12" 
                                                style="padding: 5px 10px 5px 10px;">
                                                已发送邮件到您的邮箱，请及时查收并按邮件提示操作，谢谢合作。
                                                <span id="time" style="color:Red">5</span>&nbsp;秒后自动跳转！
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </div>

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
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
<script language="javascript" type="text/javascript">
    function DisplayTimer() {
        var seconds = parseInt(time.innerHTML)-1;
        time.innerHTML = seconds.toString();
            if (seconds == 0) {
            window.top.location.href ="../../Default.aspx";
        }
    }
    <%=script %>
</script>
