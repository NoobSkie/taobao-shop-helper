<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/FollowFriendSchemeAdd_User.aspx.cs" inherits="Home_Room_FollowFriendSchemeAdd_User" enableEventValidation="false" %>

<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>定制好友跟单-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <meta name="keywords" content="定制好友跟单" />
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />

    <script src="../../javaScript/Public.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function ShowOrHideDZUserList() {
            if (document.all["FollowUseList"].style.display == "") {
                document.all["FollowUseList"].style.display = "none";
            }
            else {
                document.all["FollowUseList"].style.display = "";
            }
        }

        function InputMask_Number() {
            if (window.event.keyCode < 48 || window.event.keyCode > 57)
                return false;
            return true;
        }

        function CheckMultiple(sender) {
            var multiple = StrToInt(sender.value);

            sender.value = multiple;

            if (multiple < 1) {
                if (confirm("输入不正确，按“确定”重新输入，按“取消”自动更正为 1 ，请选择。")) {
                    sender.focus();
                    return;
                }
                else {
                    multiple = 1;
                    sender.value = 1;
                }
            }
        }
    </script>

    <base target="_self" />
<link rel="shortcut icon" href="../../favicon.ico" /></head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc3:Lotteries ID="Lotteries1" runat="server" />
    <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 3px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right" style="margin-top: 0px">
            <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                <tr>
                    <td width="40" height="30" align="right" valign="middle" class="red14">
                        <img src="images/icon_6.gif" width="19" height="16" />
                    </td>
                    <td valign="middle" class="red14" style="padding-left: 10px;">
                        我的彩票记录
                    </td>
                </tr>
            </table>
            <br />
            <table width="842" border="0" cellspacing="0" cellpadding="0" background="images/zfb_left_bg_2.jpg"
                style="margin-top: 10px;">
                <tr>
                    <td width="10" height="29" align="left">
                        &nbsp;
                    </td>
                    <td width="100" align="center" background="images/admin_qh_100_2.jpg" class="blue12">
                        <strong>定制自动跟单</strong>
                    </td>
                    <td width="6">
                        &nbsp;
                    </td>
                    <td width="726">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <table width="842" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="1" colspan="9" bgcolor="#FFFFFF">
                    </td>
                </tr>
                <tr>
                    <td height="2" colspan="9" bgcolor="#6699CC">
                    </td>
                </tr>
            </table>
            <table width="100%" align="center" cellpadding="5" cellspacing="1" bgcolor="#9FC8EA">
                <tr>
                    <td width="150" bgcolor="#f5f5f5" style="text-align: right;">
                        好友用户名
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:Label ID="lbUserName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f5f5f5" style="text-align: right;">
                        定制自动跟单玩法
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:DropDownList ID="ddlLotteries" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLotteries_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlPlayTypes" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f5f5f5" style="text-align: right;">
                        跟单金额范围
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:TextBox ID="tbMinMoney" runat="server" Width="50px" onkeypress="return InputMask_Number();"
                            onblur="CheckMultiple(this);" Text="1"></asp:TextBox>
                        至
                        <asp:TextBox ID="tbMaxMoney" runat="server" Width="50px" onkeypress="return InputMask_Number();"
                            onblur="CheckMultiple(this);"></asp:TextBox>&nbsp;元
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f5f5f5" style="text-align: right;">
                        每次认购份数
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:TextBox ID="tbBuyShareStart" runat="server" Width="50px" onkeypress="return InputMask_Number();"
                            onblur="CheckMultiple(this);" Text="1"></asp:TextBox>
                        至
                        <asp:TextBox ID="tbBuyShareEnd" runat="server" Width="50px" onkeypress="return InputMask_Number();"
                            onblur="CheckMultiple(this);"></asp:TextBox>&nbsp;份
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f5f5f5">
                    </td>
                    <td bgcolor="#FFFFFF">
                        <ShoveWebUI:ShoveConfirmButton ID="btn_OK" runat="server" Text=" 确定 " OnClick="btn_OK_Click"
                            AlertText="您确认输入无误并定制跟单吗?" />
                        <span style="margin-left: 100px;"></span>
                        <asp:Button ID="btnCancel" runat="server" Text=" 取消 " OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="HidFollowUserID" runat="server" />
    </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
        <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
