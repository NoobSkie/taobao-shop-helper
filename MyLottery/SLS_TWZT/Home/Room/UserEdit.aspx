<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/UserEdit.aspx.cs" inherits="Home_Room_UserEdit" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Src="UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改用户资料-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <meta name="keywords" content="修改用户资料" />

    <script src="../../Components/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-size: 12px;
            color: #000000;
            font-family: tahoma;
            line-height: 18px;
            height: 20px;
        }
        .mOver
        {
            border: 1;
        }
        .mOut
        {
            border: none;
        }
    </style>

    <script type="text/javascript" language="javascript">
        function mOut(obj, styleClass) {
            obj.className = styleClass;
            if (styleClass == "mOut") {
                obj.blur();
            }
        }

        function showSameHeight() {
            if (document.getElementById("menu_left").clientHeight < document.getElementById("menu_right").clientHeight) {
                document.getElementById("menu_left").style.height = document.getElementById("menu_right").offsetHeight + "px";
            }
            else {
                if (document.getElementById("menu_right").offsetHeight >= 960) {
                    document.getElementById("menu_left").style.height = document.getElementById("menu_right").offsetHeight + "px";
                }
                else {
                    document.getElementById("menu_left").style.height = "960px";
                }
            }
        }

        /*function checkUserName() {
            var userName = document.getElementById("txtName").value + "";
            var result = 0;
            if(userName != '<%= _User.Name %>')
            {
                result = Home_Room_UserEdit.CheckUserNameAjax(userName).value;
            }

            if (userName.trim() == "") {
                spCheckResult.innerHTML = "<font color='red'>用户名不能为空</font>";
                document.getElementById("txtName").value = "";
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
        }*/
    </script>

<link rel="shortcut icon" href="../../favicon.ico" /></head>
<body onload="showSameHeight();">
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="hdIDCardNumber" />
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc3:Lotteries ID="Lotteries1" runat="server" />
    <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 3px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
            <table width="842" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="40" height="30" align="right" valign="middle" class="red14">
                        <img src="images/user_icon_man.gif" width="19" height="16" />
                    </td>
                    <td valign="middle" class="red14" style="padding-left: 10px;">
                        我的资料
                    </td>
                </tr>
            </table>
            <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                <tr>
                    <td width="20" height="29">
                        &nbsp;
                    </td>
                    <td width="100" align="center" background="images/admin_qh_100_1.jpg" class="blue12">
                        <a href="UserEdit.aspx"><strong>个人基本资料</strong></a>
                    </td>
                    <td width="6">
                        &nbsp;
                    </td>
                    <td width="6">
                        &nbsp;
                    </td>
                    <td align="center" class="blue14">
                        &nbsp;
                    </td>
                    <td width="168" class="black12">
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
            <table width="750" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
                <tr bgcolor="#C0DBF9">
                    <td width="100%" height="30" align="center" bgcolor="#FFFFFF" class="black12" style="padding: 10px;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr bgcolor="#C0DBF9">
                                <td width="20%" height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    真实姓名：<span class="red12"></span>
                                </td>
                                <td width="80%" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                    <asp:TextBox ID="tbRealityName" runat="server" Width="160px"></asp:TextBox>
                                    <asp:Label ID="lbRealityName" runat="server" Visible="false"></asp:Label>&nbsp;&nbsp;
                                    <asp:Label ID="lbIsRealityNameValided" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr bgcolor="#C0DBF9">
                                <td width="20%" height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    &nbsp;
                                </td>
                                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                    <span class="red12">非常重要，您提款的重要依据，提款时银行卡的户名必须是这里填写的真实姓名，一旦提交将不可更改！</span>
                                </td>
                            </tr>
                            <tr bgcolor="#C0DBF9">
                                <td width="20%" height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    身份证号码：<span class="red12"></span>
                                </td>
                                <td width="80%" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                    <asp:TextBox ID="tbIdIDCardNumber" Text="" runat="server" Width="160px"></asp:TextBox>
                                    <asp:Label ID="lbIdCardNumber" runat="server" Visible="false"></asp:Label>&nbsp;&nbsp;
                                    <asp:Label ID="lbIsIdCardNumberValided" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr bgcolor="#C0DBF9">
                                <td width="20%" height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    &nbsp;
                                </td>
                                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px; padding-right: 120px;">
                                    <span class="blue12">填写成功后用户不能自行修改，如需修改，请点击&nbsp;</span><span
                                            class="red12">在线客服</span>&nbsp;<span class="blue12">咨询处理流程，请确认。</span>
                                </td>
                            </tr>
                            <tr bgcolor="#C0DBF9">
                                <td width="20%" height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    用户名：<span class="red12"></span>
                                </td>
                                <td width="80%" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                    <asp:Label ID="lbUserName" runat="server" Text=""></asp:Label>
                                    <%--<asp:TextBox ID="txtName" runat="server" Width="160px"></asp:TextBox>
                                    &nbsp;&nbsp;<span class="blue12"><a style="cursor: hand;" onclick="return checkUserName();">检测用户名</a></span>
                                    <span id="spCheckResult"></span>--%>
                                </td>
                            </tr>
                            <tr bgcolor="#C0DBF9">
                                <td width="20%" height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    性别：<span class="red12"></span>
                                </td>
                                <td width="80%" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                    <asp:RadioButton ID="rbSexM" runat="server" GroupName="rbSex" Text="男" />
                                    <asp:RadioButton ID="rbSexW" runat="server" GroupName="rbSex" Text="女" />
                                </td>
                            </tr>
                            <tr bgcolor="#C0DBF9">
                                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    手机号码：
                                </td>
                                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                    <label>
                                        <asp:Label ID="lbMobile" runat="server" Text="" Width="160px"></asp:Label>
                                        <asp:Label ID="labIsMobileVailded" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr bgcolor="#C0DBF9">
                                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    E-mail：
                                </td>
                                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                    <asp:TextBox ID="tbEmail" runat="server" CssClass="in_text_hui" Width="160px" MaxLength="50"></asp:TextBox>&nbsp;
                                    <asp:Label ID="lbIsEmailValided" runat="server"></asp:Label>
                                    <%--<input name="textfield" type="text" id="textfield3" value="test001@163.com" size="20" />--%>
                                </td>
                            </tr>
                            <tr bgcolor="#C0DBF9">
                                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    QQ：
                                </td>
                                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                    <asp:Label ID="lbQQ" runat="server" Text="" Width="160px"></asp:Label>
                                        <asp:Label ID="lbQQValided" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr bgcolor="#C0DBF9">
                                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    城市：
                                </td>
                                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                    <ShoveWebUI:ShoveProvinceCityInput ID="ddlCity" runat="server" SupportDir="~/ShoveWebUI_client" />
                                </td>
                            </tr>
                            <tr bgcolor="#C0DBF9">
                                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    出生日期：
                                </td>
                                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                    <asp:TextBox ID="tbBirthday" CssClass="in_text_hui" runat="server" MaxLength="10" onFocus="WdatePicker({el:'tbBirthday',dateFmt:'yyyy-MM-dd', maxDate:'%y-%M-%d'})"></asp:TextBox>
                                    <span class="blue12">如：1990-9-1</span>
                                </td>
                            </tr>
                            <tr bgcolor="#C0DBF9">
                                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    联系地址：
                                </td>
                                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                    <asp:TextBox ID="tbAddress" CssClass="in_text_hui" Width="260px" runat="server" MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
                            <!--
                        <tr bgcolor="#C0DBF9">
                            <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                邮政编码：
                            </td>
                            <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                <input name="textfield5" type="text" id="textfield6" size="20" />
                            </td>
                        </tr>
                        -->
                            <tr bgcolor="#C0DBF9">
                                <td height="20" colspan="2" align="right" bgcolor="#FFFFFF" class="black12">
                                    <div id="hr">
                                    </div>
                                </td>
                            </tr>
                            <tr bgcolor="#C0DBF9">
                                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    &nbsp;
                                </td>
                                <td align="left" bgcolor="#FFFFFF" class="red12" style="padding-left: 10px;">
                                    （为了您的账户安全，请您输入以下信息进行确认）
                                </td>
                            </tr>
                            
                    <div id="divNewQF" runat="server" visible="false">
                    <tr width="17%" height="30" align="right" class="black12">
                        <td width="17%" height="30" align="right" class="black12">
                            安全保护问题
                        </td>
                        <td align="left" class="black12" style="padding-left: 10px;">
                            <asp:DropDownList ID="ddlQuestion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlQuestion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="trMQ" runat="server" visible="false">
                        <td width="17%" height="30" align="right" class="black12">
                            自定义问题：
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:TextBox ID="tbMyQuestion" runat="server" MaxLength="90" Width="550"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="17%" height="30" align="right" class="black12">
                            答案：
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:TextBox ID="tbAnswer" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </div>
                <div id="divAnswer" visible ="false" runat ="server" >
                            <tr bgcolor="#C0DBF9">
                                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    安全保护问题：
                                </td>
                                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                    <asp:Label ID="lbQuestion" runat="server"></asp:Label>
                                    &nbsp;&nbsp;<span class="blue12"><a href="SafeSet.aspx?FromUrl='UserEdit.aspx'">
                                        <asp:Label ID="lbQuestionInfo" runat="server"></asp:Label>
                                    </a></span>
                                </td>
                            </tr>
                            <tr bgcolor="#C0DBF9">
                                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    答案：
                                </td>
                                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                    <asp:TextBox ID="tbMyA" runat="server"></asp:TextBox>
                                    <span class="red12">*</span>
                                </td>
                            </tr>
                            </div>
                            <tr bgcolor="#C0DBF9">
                                <td colspan="2" align="right" bgcolor="#FFFFFF" class="style1">
                                    <div id="hr">
                                    </div>
                                </td>
                            </tr>
                            <tr bgcolor="#C0DBF9">
                                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                    &nbsp;
                                </td>
                                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding: 10px;">
                                    <ShoveWebUI:ShoveConfirmButton ID="btnOK" runat="server" Text="确定修改" AlertText="确信输入的资料无误，并立即保存资料吗？"
                                        Style="cursor: pointer;" OnClick="btnOK_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 10px;">
                <tr>
                    <td width="775" bgcolor="#FFFEDF" class="blue14" style="padding: 5px 10px 5px 10px;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <span class="blue14" style="padding: 5px 10px 5px 10px;">如有其他问题，请联系网站客服：<span class="red14"><%= _Site.ServiceTelephone %>
                                    </span></span>
                                </td>
                            </tr>
                        </table>
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
