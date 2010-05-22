<%@ page language="C#" autoeventwireup="true" CodeFile="EditPassWord.aspx.cs" inherits="Agent_CardPassword_EditPassWord" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../../Style/css.css" rel="stylesheet" type="text/css" />
</head><link rel="shortcut icon" href="../favicon.ico"/>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="19%" align="center" background="../../images/daihe_03.gif">
                        <span class="STYLE9"><strong>代理商密码修改</strong><input id="tbLotteryID" runat="server" name="tbLotteryID" style="width: 50px" type="hidden" /><input id="tbPlayTypeID" runat="server" name="tbPlayTypeID" style="width: 50px" type="hidden" /><input id="tbBuyFileName" runat="server" name="tbBuyFileName" style="width: 50px" type="hidden" /></span></td>
                    <td width="81%" height="31" align="right" background="../../images/daihe_04.gif" class="bai">
                    </td>
                </tr>
            </table>
            <br />
            <table width="80%" border="0" align="center" cellpadding="0" cellspacing="1" style="background-color:#CCCCCC">
                <tr>
                    <td height="27" colspan="4" bgcolor="#FFFFFF" style="background-color:#f5f5f5;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 密码修改：</td>
                </tr>
            </table>
            <table width="80%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                <tr>
                    <td align="left" bgcolor="#FAFAFA">
                        <table width="100%" border="1" align="center" cellpadding="5" cellspacing="0" bgcolor="#CCCCCC" bordercolorlight="#CCCCCC" bordercolordark="#FFFFFF">
                            <tr>
                                <td bgcolor="#f5f5f5">
                                    <div align="right">
                                        旧密码：</div>
                                </td>
                                <td bgcolor="#ffffff">
                                    <asp:TextBox ID="tbOldPassWord" runat="server" Width="140px" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#f5f5f5">
                                    <div align="right">
                                        新密码：</div>
                                </td>
                                <td bgcolor="#ffffff">
                                    <asp:TextBox ID="tbNewPassWord" runat="server" TextMode="Password" Width="140px" MaxLength="30"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#f5f5f5">
                                    <div align="right">
                                        确认密码：</div>
                                </td>
                                <td bgcolor="#ffffff">
                                    <asp:TextBox ID="tbRePassWord" runat="server" TextMode="Password" Width="140px" MaxLength="30"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                                <td bgcolor="#ffffff" colspan="4">
                                    <div align="center">
                                        <ShoveWebUI:ShoveConfirmButton ID="btnOK" runat="server" AlertText="确信输入的资料无误，并立即保存资料吗？" BackgroupImage="../../Images/Surrogate/buttbg.gif" BorderStyle="None" Height="20px" Text="修改" Width="60px" OnClick="btnOK_Click" /></div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
