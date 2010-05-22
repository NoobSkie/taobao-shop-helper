<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/UserLoginDialog.aspx.cs" inherits="Home_Room_UserLoginDialog" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
    function UserInit()
    {
        try
        {
            parent.UserInit();
        }
        catch(e)
        {
        }
    }
    </script>

</head>
<body onload="return UserInit();">
    <form id="form1" runat="server">
    <div>
        <table cellspacing="1" cellpadding="0" align="center" border="0" style="background-color: #CDCDCD;" width="948px;">
            <!-- Login -->
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" style="background-image: url(Images/Login_bg.jpg); height: 30px;" class="black12">
                            <tr>
                                <td valign="middle" width="17">
                                </td>
                                <td valign="middle" style="padding-left: 2px; height: 17px" align="center" class="black12">
                                    &nbsp;用户名：
                                </td>
                                <td>
                                    <asp:TextBox ID="tbUserName" runat="server" MaxLength="16" Width="77" Height="15px" CssClass="in_text_hui"></asp:TextBox>
                                </td>
                                <td style="width: 42px" class="black12">
                                    密码：
                                </td>
                                <td>
                                    <asp:TextBox ID="tbUserPassword" runat="server" Width="77" Height="15px" CssClass="in_text_hui" TextMode="Password"></asp:TextBox>
                                </td>
                                <td class="black12">
                                    <%=labCheckCode%>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbCheckCode" runat="server" MaxLength="4" Width="50" Height="15px" CssClass="in_text_hui"></asp:TextBox>
                                </td>
                                <td class="black12" valign="middle">
                                    <div style="height: 22px;">
                                        &nbsp;
                                        <ShoveWebUI:ShoveCheckCode ID="ShoveCheckCode1" runat="server" ForeColor="CornflowerBlue" BackColor="SeaShell" Charset="All" Height="20px" SupportDir="~/ShoveWebUI_client" name="ShoveCheckCode1"></ShoveWebUI:ShoveCheckCode>
                                    </div>
                                </td>
                                <td>
                                    <ShoveWebUI:ShoveConfirmButton ID="btnLogin" Style="cursor: hand; color: #000000; background-image: url(Images/Login.jpg);" runat="server" Width="60px" Height="22px" CausesValidation="False" Text="登 录" BorderStyle="None" OnClick="btnLogin_Click" />
                                </td>
                                <td>
                                    <a href="../../MemberSharing/Alipay/Login.aspx" target="_blank">
                                        <img style="height: 22px; width: 150px;" src="Images/Login_Alipay.jpg" alt="支付宝用户登录" border="0" /></a>
                                </td>
                                <td style="padding-top: 6px; padding-left: 5px;" align="center" class="black12">
                                    <a href="../../UserLogin.aspx" target="_parent">免费注册</a> | <a href="ForgetPassword.aspx" target="_parent">忘记密码</a>
                                </td>
                                <td valign="middle" width="37">
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" style="background-image: url(Images/Login_bg.jpg); height: 30px;">
                            <tr>
                                <td style="width: 30px;" valign="middle">
                                </td>
                                <td valign="middle" align="center" height="17px" class="black12">
                                    <asp:Label ID="lbUserName" runat="server" CssClass="red12">XXX,</asp:Label>
                                    您好
                                </td>
                                <td valign="middle" align="left" class="black12">
                                    <asp:Label ID="lbUserType" runat="server">级别：XX</asp:Label>
                                </td>
                                <td valign="middle" align="left" class="black12">
                                    <asp:Label ID="lbBalance" runat="server">余额：XX 元</asp:Label>
                                </td>
                                <td valign="middle" align="left" width="40%">
                                    <a href="../../Default.aspx" target="_blank" class="black12">购彩大厅</a> | <a href="MyIcaile.aspx?SubPage=UserEdit.aspx" target="_blank" class="black12">我的资料</a> | <a href="MyIcaile.aspx?SubPage=AccountDetail.aspx" target="_blank" class="black12">个人帐户</a> | <a href="MyIcaile.aspx?SubPage=OnlinePay/Default.aspx" target="_blank" class="red12">电话卡充值</a>
                                </td>
                                <td valign="middle" align="center" width="60px">
                                    <asp:Button ID="btnAdmin" Style="cursor: hand; width: 60px; height: 22px" runat="server" CausesValidation="False" Text=" 管 理" BorderStyle="None" OnClick="btnAdmin_Click"></asp:Button>
                                </td>
                                <td valign="middle" align="left" style="padding-left: 3px">
                                    <font face="Tahoma">
                                        <asp:Button ID="btnLogout" Style="cursor: hand; width: 70px; height: 22px" runat="server" CausesValidation="False" Text=" 安全退出" BorderStyle="None" OnClick="btnLogout_Click"></asp:Button></font>
                                </td>
                                <td valign="middle" width="37">
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>