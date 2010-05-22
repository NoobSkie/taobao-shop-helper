<%@ page language="C#" autoeventwireup="true" CodeFile="WebConfig.aspx.cs" inherits="Admin_WebConfig" validaterequest="false" enableEventValidation="false" %>

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
            &nbsp;
        </div>
        <div>
            <br />
            <table cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
                <tr>
                    <td style="height: 21px">
                        &nbsp;Web.Config 配置文件，请谨慎修改：</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:TextBox ID="tbContent" runat="server" Width="99%" Height="410px" TextMode="MultiLine" Wrap="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 50px" align="center">
                        <ShoveWebUI:ShoveConfirmButton ID="btnOK" BackgroupImage="../Images/Admin/buttbg.gif" runat="server" Width="60px" Height="20px" Text="保存" AlertText="确认书写无误吗？" OnClick="btnOK_Click" /></td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
