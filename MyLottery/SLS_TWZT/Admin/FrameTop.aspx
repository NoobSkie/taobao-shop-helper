<%@ page language="C#" autoeventwireup="true"  CodeFile="FrameTop.aspx.cs" inherits="Admin_FrameTop" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/Admin.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
    body{ min-width:1003px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" height="88" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="650" background="../Images/Admin/slsht_02.jpg" class="bai">
		</td>
                <td  align="right" background="../Images/Admin/slsht_02.jpg">
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="359">
                                &nbsp;</td>
                            <td width="241" class="bai">
                                <a href="../Lottery/Buy_SSQ.aspx" target="_top">进入购彩大厅</a>&nbsp;|&nbsp;<a href="../Default.aspx" target="_top">进入网站首页 </a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="100%" height="30" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td background="../Images/Admin/slsht_05.jpg">
                    <table width="100%" height="22" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="375">
                                <table width="92%" height="95%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="4%" height="18" class="bai">
                                            &nbsp;</td>
                                        <td width="96%" valign="bottom" class="bai">
                                            欢迎<asp:Label ID="labUserName" runat="server"></asp:Label>登录网站管理后台！&nbsp;<asp:LinkButton ID="lbLogout" runat="server" OnClick="lbLogout_Click">【安全退出】</asp:LinkButton></td>
                                    </tr>
                                </table>
                            </td>
                            <td width="293">
                                &nbsp;</td>
                            <td width="335">
                                <table width="92%" height="95%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="4%" height="18" class="bai">
                                            &nbsp;</td>
                                        <td width="96%" valign="bottom" class="bai">
                                            <div align="right">
                                                服务热线：<%=_Site.SiteOptions["ServiceTelephone"].ToString("")%></div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
