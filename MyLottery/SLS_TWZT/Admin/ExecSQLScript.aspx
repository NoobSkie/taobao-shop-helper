<%@ page language="C#" autoeventwireup="true" CodeFile="ExecSQLScript.aspx.cs" inherits="Admin_ExecSQLScript" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="Table1" cellspacing="0" cellpadding="0" width="672" height="117" align="center" border="0" style="width: 672px; height: 117px">
                <tr>
                    <td valign="top">
                        <p>
                            <font face="宋体"><strong>
                                <br />
                                注意！！！<br />
                                &nbsp; &nbsp; 此功能仅为开发商提供，在修复数据，排查问题时使用。用户请勿使用此功能。<br />
                                &nbsp; &nbsp; 再次提醒您：请谨慎操作！！！<br />
                            </strong></font>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td style="height: 19px">
                        <asp:TextBox ID="tbSQL" runat="server" Height="390px" TextMode="MultiLine" Width="99%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 60px" align="center">
                        开发商提供的密码
                        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" Width="152px"></asp:TextBox>
                        <ShoveWebUI:ShoveConfirmButton ID="btnOK" BackgroupImage="../Images/Admin/buttbg.gif" runat="server" Width="60px" Height="20px" Text="执行 ！" AlertText="确认书写无误，并立即执行 SQL 脚本吗？" OnClick="btnOK_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
