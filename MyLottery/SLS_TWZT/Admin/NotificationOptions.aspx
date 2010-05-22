<%@ page language="C#" autoeventwireup="true" CodeFile="NotificationOptions.aspx.cs" inherits="Admin_NotificationOptions" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/Admin.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <table width="707" height="34" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#85BDE2">
                <tr>
                    <td height="32" bgcolor="#B0D5EC" class="STYLE14">
                        <div align="left" class="STYLE4">
                            <div align="center">
                                通知、消息发送选项</div>
                        </div>
                    </td>
                </tr>
            </table>
            <table width="707" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#85BDE2" style="color: #000000; height: 160px;">
                <tr>
                    <td colspan="2" bgcolor="#FFFFFF" style="height: 27px;" class="hon">
                        </td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当注册普通会员成功时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb1_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb1_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb1_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当注册高级会员成功时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb2_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb2_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb2_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当忘记密码，并申请找回时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb3_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb3_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb3_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户资料被修改时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb4_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb4_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb4_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户高级资料被修改时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb5_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb5_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb5_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户发起一个方案时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb6_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb6_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb6_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户入伙一个方案时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb7_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb7_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb7_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户发起一个追号任务时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb8_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb8_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb8_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户的追号任务其中某期到达执行时间被系统自动执行时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb9_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb9_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb9_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户发出提款申请时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb10_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb10_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb10_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户发出的提款申请被受理时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb11_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb11_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb11_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户发出的提款申请被拒绝时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb12_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb12_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb12_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户从某方案中撤单时(不是撤销整个方案)，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb13_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb13_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb13_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户作为发起人，撤销整个方案时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb14_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb14_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb14_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户撤销整个追号任务中的某些期(追号明细任务)时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb15_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb15_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb15_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户撤销整个追号任务时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb16_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb16_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb16_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户中奖时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb17_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb17_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb17_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户申请手机验证时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb18_1" runat="server" Text="发送手机短信" Enabled="False" />
                        <asp:CheckBox ID="cb18_2" runat="server" Text="发送 Email" Enabled="False" />
                        <asp:CheckBox ID="cb18_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户手机通过验证时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb19_1" runat="server" Text="发送手机短信" Enabled="False" />
                        <asp:CheckBox ID="cb19_2" runat="server" Text="发送 Email" Enabled="False" />
                        <asp:CheckBox ID="cb19_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户发起追号套餐时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb20_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb20_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb20_3" runat="server" Text="发送站内信"/></td>
                </tr>
                 <tr>
                    <td height="26" bgcolor="#FFFFFF" style="width: 396px">
                        <div align="right">
                            当用户发起的追号套餐中奖时，发送通知：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:CheckBox ID="cb21_1" runat="server" Text="发送手机短信" />
                        <asp:CheckBox ID="cb21_2" runat="server" Text="发送 Email" />
                        <asp:CheckBox ID="cb21_3" runat="server" Text="发送站内信"/></td>
                </tr>
                <tr>
                    <td colspan="2" bgcolor="#FFFFFF" align="center" style="height: 40px">
                        &nbsp;<ShoveWebUI:ShoveConfirmButton ID="btnOK" runat="server" AlertText="确信输入的资料无误，并立即保存资料吗？" BackgroupImage="../Images/Admin/buttbg.gif" BorderStyle="None" Height="20px" Text="修改" Width="60px" OnClick="btnOK_Click" /></td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
