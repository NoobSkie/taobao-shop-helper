<%@ page language="C#" autoeventwireup="true" CodeFile="~/ForeCast.aspx.cs" inherits="ForeCast" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<%@ Register Src="Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="Home/Room/UserControls/Index_banner.ascx" TagName="Index_banner"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>彩票预测分析[双色球，福彩3D，时时乐、时时彩、十一运夺金]－<%=_Site.Name %></title>
    <meta name="description" content="<%=_Site.Name %>为广大彩民提供双色球，福彩3D，时时乐、时时彩、十一运夺金等彩票开奖号码预测分析。" />
    <meta name="keywords" content="彩票预测，彩票分析" />
    <link href="Home/Room/style/css.css" rel="stylesheet" type="text/css" />
</head>
<link rel="shortcut icon" href="Web/favicon.ico" />
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
    <div id="content">
        <table width="1002" border="0" cellspacing="0" cellpadding="0" style="margin-bottom: 10px;">
            <tr>
                <td>
                    <img src="home/room/images/222.jpg" width="1002" height="66" />
                </td>
            </tr>
        </table>
        <table width="1002" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
            <tr>
                <td bgcolor="#FFFFFF" style="padding: 20px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <table width="315" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
                                    <tr>
                                        <td height="31" bgcolor="#FFFFFF" class="blue12" style="background: url(home/room/images/cpyc.jpg);
                                            padding-left: 10px;">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="83%">
                                                        <h1 class='blue12' style="display: inline;">
                                                            双色球预测</h1>
                                                    </td>
                                                    <td width="17%" align="left">
                                                        <a href="<%= _Site.Url %>/bbs/showforum-7.aspx" target="_blank">更多&gt;&gt;</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center"  height="130px" bgcolor="#FFFFFF" runat="server" id="tdSSQ" valign="top">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="left">
                                <table width="315" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
                                    <tr>
                                        <td height="31" bgcolor="#FFFFFF" class="blue12" style="background: url(home/room/images/cpyc.jpg);
                                            padding-left: 10px;">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="83%">
                                                        <h1 class='blue12' style="display: inline;">
                                                            3D预测</h1>
                                                    </td>
                                                    <td width="17%" align="left">
                                                        <a href="<%= _Site.Url %>/bbs/showforum-6.aspx" target="_blank">更多&gt;&gt;</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center"  height="130px" bgcolor="#FFFFFF" runat="server" id="td3D" valign="top">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="left">
                                <table width="315" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
                                    <tr>
                                        <td height="31" align="left" bgcolor="#FFFFFF" class="blue12" style="background: url(Home/Room/images/cpyc.jpg);
                                            padding-left: 10px;">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="83%">
                                                        <h1 class='blue12' style="display: inline;">超级大乐透预测</h1>
                                                    </td>
                                                    <td width="17%" align="left">
                                                        <a href="<%= _Site.Url %>/bbs/showforum-109.aspx" target="_blank">更多&gt;&gt;</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center"  height="130px" bgcolor="#FFFFFF" runat="server" id="tdCJDLT" valign="top">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="315" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9" style="margin-top: 10px;">
                                    <tr>
                                        <td height="31" bgcolor="#FFFFFF" class="blue12" style="background: url(Home/Room/images/cpyc.jpg);
                                            padding-left: 10px;">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="83%">
                                                       <h1 class='blue12' style="display: inline;">排列3/5预测</h1>
                                                    </td>
                                                    <td width="17%" align="left">
                                                        <a href="<%= _Site.Url %>/bbs/showforum-110.aspx" target="_blank">更多&gt;&gt;</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center"  height="130px" bgcolor="#FFFFFF" runat="server" id="tdPL" valign="top">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="left" valign="bottom">
                                <table width="315" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9" style="margin-top: 10px;">
                                    <tr>
                                        <td height="31" align="left" bgcolor="#FFFFFF" class="blue12" style="background: url(Home/Room/images/cpyc.jpg);
                                            padding-left: 10px;">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="83%">
                                                        <h1 class='blue12' style="display: inline;">时时乐预测</h1>
                                                    </td>
                                                    <td width="17%" align="left">
                                                        <a href="<%= _Site.Url %>/bbs/showforum-12.aspx" target="_blank">更多&gt;&gt;</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center"  height="130px" bgcolor="#FFFFFF" runat="server" id="tdSSL" valign="top">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="left">
                                <table width="315" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9" style="margin-top: 10px;">
                                    <tr>
                                        <td height="31" align="left" bgcolor="#FFFFFF" class="blue12" style="background: url(Home/Room/images/cpyc.jpg);
                                            padding-left: 10px;">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="83%">
                                                        <h1 class='blue12' style="display: inline;">十一运夺金预测</h1>
                                                    </td>
                                                    <td width="17%" align="left">
                                                        <a href="<%= _Site.Url %>/bbs/showforum-120.aspx" target="_blank">更多&gt;&gt;</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td align="center" height="130px" bgcolor="#FFFFFF" runat="server" id="tdSYYDJ" valign="top">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>
