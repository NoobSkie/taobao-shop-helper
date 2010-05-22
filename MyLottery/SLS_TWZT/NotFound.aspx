<%@ page language="C#" autoeventwireup="true" CodeFile="~/NotFound.aspx.cs" inherits="NotFound" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="Style/main.css" type="text/css" rel="stylesheet" />
</head><link rel="shortcut icon" href="favicon.ico"/>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table width="774" border="0" cellpadding="0" cellspacing="0" align="center">
            <tr>
                <td height="200" align="center" valign="middle">
                    <table width="508" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="Images/NotExists/Arrow.gif" width="508" height="39" alt="" />
                            </td>
                        </tr>
                    </table>
                    <table width="508" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="120" align="center" valign="middle" background="Images/NotExists/News_success_bg3.gif">
                                <table border="0" cellspacing="0" cellpadding="0" style="width: 89%">
                                    <tr>
                                        <td width="80%" valign="middle">
                                            <font color="#ff6600"><strong>对不起，您要访问的页面不存在或被移除！<br />
                                            </strong></font>
                                            <br>
                                            <a href="Index.htm">请点击这里这里返回<%=_Site.Name %>
                                                [首页] 再寻找您需要的页面，谢谢！</a><br />
                                            如果您认为这是错误，请联系：<a href="mailto:<%=_Site.Email %>"><%=_Site.Email %></a>
                                        </td>
                                        <td width="20%">
                                            <img src="Images/NotExists/Computer.gif" width="102" height="80" alt="" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="508" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="9">
                                <img src="Images/NotExists/news_success_bg2.gif" width="508" height="9" alt="" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <!--#includefile="Html/TrafficStatistics/1.htm"-->
</body>
</html>
