<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Web/UserRegAgree.aspx.cs"  inherits="Home_Web_UserRegAgree" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户注册协议-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <meta name="keywords" content="用户注册协议" />
    <link href="../Room/Style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .pass_password_strong
        {
            border-right: #bebebe 1px solid;
            border-left: #ffffff 1px solid;
            color: #999999;
            border-bottom: #bebebe 1px solid;
            background-color: #ebebeb;
            padding: 5px;
        }
    </style>
    <link rel="shortcut icon" href="../../favicon.ico"/>
</head>
<body style="text-align:center">
    <form id="form1" runat="server">
        <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <div>
                <asp:Panel ID="pStep1" runat="server" EnableViewState="false">
                    <table width="1000" border="0" cellpadding="0" cellspacing="0" bgcolor="#9BBFCA">
                        <tr>
                            <td valign="top" bgcolor="#FFFFFF" class="bg_x" style="padding: 12px 20px 12px 20px;">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <img src="images/user_title_1.gif" width="327" height="33" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="12">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="1" bgcolor="#CCCCCC">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="12">
                                        </td>
                                    </tr>
                                </table>
                               <%-- <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="2" class="black12" align="left">
                                            <div style="height: 600px; overflow: scroll; width: 100%; overflow-x: hidden;">
                                                <asp:Label ID="labAgreement" runat="server" EnableViewState="false"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>--%>
                                
                                 <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="2" class="hui12" align="left">
                                            <div style="height: 100%; width: 100%;">
                                                <asp:Label ID="labAgreement" runat="server"  EnableViewState="false"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                               
                           
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
       <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
