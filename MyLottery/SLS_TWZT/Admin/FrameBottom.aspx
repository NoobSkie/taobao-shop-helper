<%@ page language="C#" autoeventwireup="true" CodeFile="FrameBottom.aspx.cs" inherits="Admin_FrameBottom" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/Admin.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="30" background="../Images/Admin/slsht_13.jpg">
                    &nbsp;<a href="News.aspx" target="mainFrame">新闻资讯</a>&nbsp; |&nbsp; <a href="SiteAffiches.aspx" target="mainFrame">站点公告</a>&nbsp; |&nbsp; <a href="Users.aspx" target="mainFrame">用户一览</a>&nbsp; |&nbsp; <a href="UserAddMoney.aspx" target="mainFrame">账户充值</a>&nbsp; |&nbsp; <a href="SelectDefaultFirstPage.aspx" target="mainFrame">缺省首页</a> &nbsp;|&nbsp; <a href="Backup.aspx" target="mainFrame">数据备份</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:LinkButton ID="lbLogout" runat="server" OnClick="lbLogout_Click">【安全退出】</asp:LinkButton>
                </td>
                <td background="../Images/Admin/slsht_13.jpg">
                    版本：&nbsp;Lottery Sales V1.0 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            </tr>
        </table>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
