<%@ page language="C#" autoeventwireup="true" CodeFile="UploadWinLotteryImage.aspx.cs" inherits="Admin_UploadWinLotteryImage" enableEventValidation="false" %>

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
            <br />
            <table id="Table1" cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
                <tr>
                    <td style="height: 36px">
                        <strong>&nbsp;中奖彩票图片上传</strong></td>
                </tr>
                <tr>
                    <td style="height: 100px">
                        &nbsp; &nbsp;&nbsp; 方案号
                        <asp:TextBox ID="tbSchemeNumber" runat="server" Width="160px"></asp:TextBox><br />
                        &nbsp; &nbsp;&nbsp; 彩票图
                        <input id="fileImage" style="width: 500px; height: 21px" type="file" name="fileImage" runat="server">&nbsp;
                        <ShoveWebUI:ShoveConfirmButton ID="btnGO" runat="server" Width="64px" Text="上传" OnClick="btnGO_Click" /></td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
